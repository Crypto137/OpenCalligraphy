using OpenCalligraphy.Core.Extensions;
using OpenCalligraphy.Core.FileSystem;
using OpenCalligraphy.Core.GameData.Prototypes;
using OpenCalligraphy.Core.Logging;

namespace OpenCalligraphy.Core.GameData
{
    public enum DataOrigin : byte
    {
        Unknown,        // Default value returned by DataDirectory::GetDataOrigin()
        Calligraphy,
        Resource,
        Dynamic         // Unused? Mentioned in DataDirectory::GetPrototypeBlueprintDataRef()
    }

    public class DataDirectory
    {
        private static readonly Logger Logger = LogManager.CreateLogger();

        // Lookup dictionaries
        private readonly Dictionary<BlueprintId, LoadedBlueprintRecord> _blueprintRecordDict = new();
        private readonly Dictionary<BlueprintGuid, BlueprintId> _blueprintGuidToDataRefDict = new();

        private readonly Dictionary<PrototypeId, PrototypeDataRefRecord> _prototypeRecordDict = new();
        private readonly Dictionary<PrototypeGuid, PrototypeId> _prototypeGuidToDataRefDict = new();

        private PakFile _pakFile;

        public static DataDirectory Instance { get; } = new();

        // Subdirectories
        public AssetDirectory AssetDirectory { get; } = AssetDirectory.Instance;
        public ReplacementDirectory ReplacementDirectory { get; } = ReplacementDirectory.Instance;

        public uint DataChecksum { get => _pakFile != null ? _pakFile.Checksum : 0; }

        private DataDirectory() { }

        #region Initialization

        public void Initialize(string filePath)
        {
            // Load pak
            _pakFile = new(filePath);

            // Define directories
            var directories = new (string, Action<BinaryReader>, Action)[]
            {
                // Directory file path                  // Entry read method            // Callback
                ("Calligraphy/Curve.directory",         ReadCurveDirectoryEntry,        () => { }),
                ("Calligraphy/Type.directory",          ReadTypeDirectoryEntry,         () => Logger.Info($"Loaded {AssetDirectory.AssetCount} asset entries of {AssetDirectory.AssetTypeCount} types")),
                ("Calligraphy/Blueprint.directory",     ReadBlueprintDirectoryEntry,    () => Logger.Info($"Loaded {_blueprintRecordDict.Count} blueprints")),
                ("Calligraphy/Prototype.directory",     ReadPrototypeDirectoryEntry,    () => Logger.Info($"Loaded {_prototypeRecordDict.Count} Calligraphy prototype entries")),
                ("Calligraphy/Replacement.directory",   ReadReplacementDirectoryEntry,  () => { } )
            };

            // Load all directories
            foreach (var directory in directories)
            {
                using Stream stream = LoadPakDataFile(directory.Item1);
                using BinaryReader reader = new(stream);

                CalligraphyHeader header = new(reader);
                int recordCount = header.Version >= 11 ? reader.ReadInt32() : reader.ReadInt16();   // 1.17 and before use Int16 here

                // Read all records
                for (int i = 0; i < recordCount; i++)
                    directory.Item2(reader);

                // Do the callback
                directory.Item3();
            }
        }

        public void Clear()
        {
            _pakFile = null;

            _blueprintRecordDict.Clear();
            _blueprintGuidToDataRefDict.Clear();

            _prototypeRecordDict.Clear();
            _prototypeGuidToDataRefDict.Clear();

            AssetDirectory.Clear();
            ReplacementDirectory.Clear();
        }

        private Stream LoadPakDataFile(string filePath)
        {
            return _pakFile.LoadFileDataInPak(filePath);
        }

        /// <summary>
        /// Loads a <see cref="Blueprint"/> and creates a <see cref="LoadedBlueprintRecord"/> for it.
        /// </summary>
        private void LoadBlueprint(BlueprintId id, BlueprintGuid guid, BlueprintRecordFlags flags)
        {
            // Add guid lookup
            _blueprintGuidToDataRefDict[guid] = id;

            // Deserialize
            using (Stream stream = LoadPakDataFile($"Calligraphy/{GameDatabase.GetBlueprintName(id)}"))
            {
                Blueprint blueprint = new(stream, id, guid);

                // Add a new blueprint record
                _blueprintRecordDict.Add(id, new(blueprint, flags));
            }
        }

        /// <summary>
        /// Creates a <see cref="PrototypeDataRefRecord"/> for a Calligraphy <see cref="Prototype"/> without loading it.
        /// </summary>
        private void AddCalligraphyPrototype(PrototypeId prototypeId, PrototypeGuid prototypeGuid, BlueprintId blueprintId, PrototypeRecordFlags flags, string filePath)
        {
            // Create a dataRef
            GameDatabase.PrototypeRefManager.AddDataRef(prototypeId, filePath);
            _prototypeGuidToDataRefDict.Add(prototypeGuid, prototypeId);

            // Get blueprint and class type
            Blueprint blueprint = GetBlueprint(blueprintId);
            string runtimeBinding = blueprint.RuntimeBinding;

            // Add a new prototype record
            PrototypeDataRefRecord record = new()
            {
                PrototypeId = prototypeId,
                PrototypeGuid = prototypeGuid,
                BlueprintId = blueprintId,
                Flags = flags,
                RuntimeBinding = runtimeBinding,
                DataOrigin = DataOrigin.Calligraphy,
                Blueprint = blueprint
            };

            // omitting EditorOnly flag for NaviFragmentPrototype since we probably don't need it here

            _prototypeRecordDict.Add(prototypeId, record);
            // Load the prototype on demand
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Retrieves a potential replacement for a GUID. Returns <see langword="true"/> if replacement found.
        /// </summary>
        public bool GetGuidReplacement(ulong guid, ref ulong newGuid)
        {
            var record = ReplacementDirectory.GetReplacementRecord(guid);
            if (record == null) return false;
            newGuid = record.NewGuid;
            return true;
        }

        /// <summary>
        /// Returns the <see cref="Blueprint"/> that the specified <see cref="BlueprintId"/> refers to.
        /// </summary>
        public Blueprint GetBlueprint(BlueprintId id)
        {
            if (_blueprintRecordDict.TryGetValue(id, out var record) == false)
                return null;

            return record.Blueprint;
        }

        public Prototype GetPrototype(PrototypeId prototypeId)
        {
            if (prototypeId == PrototypeId.Invalid)
                return null;

            if (_prototypeRecordDict.TryGetValue(prototypeId, out PrototypeDataRefRecord record) == false)
                return null;

            if (record.Prototype == null)
            {
                using Stream stream = LoadPakDataFile($"Calligraphy/{GameDatabase.GetPrototypeName(record.PrototypeId)}");
                using BinaryReader reader = new(stream);

                record.Prototype = new() { DataRef = record.PrototypeId };

                CalligraphyHeader header = new(reader);

                // Mods/EnemyBoosts/Sets/EndGameNoAnimAffixes.prototype in 1.10 is corrupted and has an extra header byte (0x0D)
                if (header.Version <= 11)
                    record.Prototype.ParseFrom(reader);
            }

            return record.Prototype;
        }

        public string GetPrototypeRuntimeBinding(PrototypeId prototypeId)
        {
            if (_prototypeRecordDict.TryGetValue(prototypeId, out var record) == false)
                return Logger.WarnReturn(string.Empty, $"Failed to get type for prototype id {prototypeId}");

            return record.RuntimeBinding;
        }

        public IEnumerable<PrototypeId> IteratePrototypes()
        {
            // TODO: Improve this
            foreach (PrototypeDataRefRecord record in _prototypeRecordDict.Values)
                yield return record.PrototypeId;
        }

        public PrototypeDataRefRecord GetPrototypeDataRefRecord(PrototypeId prototypeId)
        {
            if (_prototypeRecordDict.TryGetValue(prototypeId, out PrototypeDataRefRecord record) == false)
                return null;

            return record;
        }

        #endregion

        #region Deserialization

        /// <summary>
        /// Helper method for deserializing <see cref="Calligraphy.AssetDirectory"/> entries.
        /// </summary>
        private void ReadTypeDirectoryEntry(BinaryReader reader)
        {
            var dataId = (AssetTypeId)reader.ReadUInt64();
            var assetTypeGuid = (AssetTypeGuid)reader.ReadUInt64();
            var flags = (AssetTypeRecordFlags)reader.ReadByte();
            string filePath = reader.ReadFixedString16().Replace('\\', '/');

            GameDatabase.AssetTypeRefManager.AddDataRef(dataId, filePath);
            var record = AssetDirectory.CreateAssetTypeRecord(dataId, flags);

            using (Stream stream = LoadPakDataFile($"Calligraphy/{filePath}"))
                record.AssetType = new(stream, AssetDirectory, dataId, assetTypeGuid);
        }

        /// <summary>
        /// Helper method for deserializing <see cref="Calligraphy.CurveDirectory"/> entries.
        /// </summary>
        private void ReadCurveDirectoryEntry(BinaryReader reader)
        {
            var curveId = (CurveId)reader.ReadUInt64();
            var guid = (CurveGuid)reader.ReadUInt64();          // Doesn't seem to be used at all
            var flags = (CurveRecordFlags)reader.ReadByte();    // Neither is this, none of the curve records have any flags set
            string filePath = reader.ReadFixedString16().Replace('\\', '/');

            GameDatabase.CurveRefManager.AddDataRef(curveId, filePath);

            /* TODO
            var record = CurveDirectory.CreateCurveRecord(curveId, flags);

            // Load this curve
            CurveDirectory.GetCurve(curveId);
            */
        }

        /// <summary>
        /// Helper method for deserializing <see cref="Blueprint"/> directory entries.
        /// </summary>
        private void ReadBlueprintDirectoryEntry(BinaryReader reader)
        {
            var dataId = (BlueprintId)reader.ReadUInt64();
            var guid = (BlueprintGuid)reader.ReadUInt64();
            var flags = (BlueprintRecordFlags)reader.ReadByte();
            string filePath = reader.ReadFixedString16().Replace('\\', '/');

            GameDatabase.BlueprintRefManager.AddDataRef(dataId, filePath);
            LoadBlueprint(dataId, guid, flags);
        }

        /// <summary>
        /// Helper method for deserializing <see cref="Prototype"/> directory entries.
        /// </summary>
        private void ReadPrototypeDirectoryEntry(BinaryReader reader)
        {
            var prototypeId = (PrototypeId)reader.ReadUInt64();
            var prototypeGuid = (PrototypeGuid)reader.ReadUInt64();
            var blueprintId = (BlueprintId)reader.ReadUInt64();
            var flags = (PrototypeRecordFlags)reader.ReadByte();
            string filePath = reader.ReadFixedString16().Replace('\\', '/');

            AddCalligraphyPrototype(prototypeId, prototypeGuid, blueprintId, flags, filePath);
        }

        /// <summary>
        /// Helper method for deserializing replacement directory entries.
        /// </summary>
        private void ReadReplacementDirectoryEntry(BinaryReader reader)
        {
            ulong oldGuid = reader.ReadUInt64();
            ulong newGuid = reader.ReadUInt64();
            string name = reader.ReadFixedString16();

            ReplacementDirectory.AddReplacementRecord(oldGuid, newGuid, name);
        }

        #endregion

        /// <summary>
        /// Contains a record of a loaded <see cref="Calligraphy.Blueprint"/> managed by the <see cref="DataDirectory"/>.
        /// </summary>
        struct LoadedBlueprintRecord
        {
            public Blueprint Blueprint { get; set; }
            public BlueprintRecordFlags Flags { get; set; }

            public LoadedBlueprintRecord(Blueprint blueprint, BlueprintRecordFlags flags)
            {
                Blueprint = blueprint;
                Flags = flags;
            }
        }
    }
}
