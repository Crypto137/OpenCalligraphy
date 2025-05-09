using OpenCalligraphy.Core.GameData;
using OpenCalligraphy.Core.GameData.Prototypes;
using OpenCalligraphy.Core.GameData.Prototypes.FieldTypes;

namespace OpenCalligraphy.Core.FileSystem
{
    public enum DataRefIndexType    // These correspond to Calligraphy base types
    {
        Asset,
        Curve,
        Prototype,
        String,
        Type,
        NumTypes,
    }

    public class DataRefIndex
    {
        private const ushort CurrentVersion = 2;

        private readonly IndexDictionary[] _indexes = new IndexDictionary[(int)DataRefIndexType.NumTypes];

        public uint Checksum { get; private set; }

        public DataRefIndex()
        {
            for (int i = 0; i < (int)DataRefIndexType.NumTypes; i++)
                _indexes[i] = new();
        }

        #region Data Access

        public IReadOnlyCollection<PrototypeId> GetReferencers(AssetId dataRef)
        {
            if (GetIndex(DataRefIndexType.Asset).TryGetValue((ulong)dataRef, out HashSet<PrototypeId> referencers) == false)
                return Array.Empty<PrototypeId>();

            return referencers;
        }

        public IReadOnlyCollection<PrototypeId> GetReferencers(CurveId dataRef)
        {
            if (GetIndex(DataRefIndexType.Curve).TryGetValue((ulong)dataRef, out HashSet<PrototypeId> referencers) == false)
                return Array.Empty<PrototypeId>();

            return referencers;
        }

        public IReadOnlyCollection<PrototypeId> GetReferencers(PrototypeId dataRef)
        {
            if (GetIndex(DataRefIndexType.Prototype).TryGetValue((ulong)dataRef, out HashSet<PrototypeId> referencers) == false)
                return Array.Empty<PrototypeId>();

            return referencers;
        }

        public IReadOnlyCollection<PrototypeId> GetReferencers(LocaleStringId dataRef)
        {
            if (GetIndex(DataRefIndexType.String).TryGetValue((ulong)dataRef, out HashSet<PrototypeId> referencers) == false)
                return Array.Empty<PrototypeId>();

            return referencers;
        }

        public IReadOnlyCollection<PrototypeId> GetReferencers(AssetTypeId dataRef)
        {
            if (GetIndex(DataRefIndexType.Type).TryGetValue((ulong)dataRef, out HashSet<PrototypeId> referencers) == false)
                return Array.Empty<PrototypeId>();

            return referencers;
        }

        private IndexDictionary GetIndex(DataRefIndexType type)
        {
            if (type < 0 || type >= DataRefIndexType.NumTypes)
                throw new IndexOutOfRangeException();

            return _indexes[(int)type];
        }

        #endregion

        #region Building

        public void Build()
        {
            Clear();

            foreach (PrototypeId protoRef in DataDirectory.Instance.IteratePrototypes())
            {
                Prototype prototype = protoRef.AsPrototype();
                // Do not add parent references from most RHStructs to avoid spam
                if (prototype.ParentDataRef != PrototypeId.Invalid)
                    AddReference(prototype.ParentDataRef, protoRef);

                AddReferencesFromPrototype(prototype, protoRef);
            }

            Checksum = DataDirectory.Instance.DataChecksum;
        }

        private void Clear()
        {
            foreach (IndexDictionary index in _indexes)
                index.Clear();

            Checksum = 0;
        }

        private void AddReferencesFromPrototype(Prototype prototype, PrototypeId referencer)
        {
            // Some RHStructs do not contain any field groups and are essentially just references to their parents
            if (prototype.DataRef == PrototypeId.Invalid && prototype.FieldGroups.Count == 0 && prototype.ParentDataRef != PrototypeId.Invalid)
            {
                AddReference(prototype.ParentDataRef, referencer);
                return;
            }

            foreach (PrototypeFieldGroup fieldGroup in prototype)
            {
                for (int i = 0; i < fieldGroup.SimpleFields.Count; i++)
                {
                    PrototypeField field = fieldGroup.SimpleFields[i];
                    switch (field)
                    {
                        case PrototypeAssetField assetField:
                            AddReference(assetField.Value, referencer);
                            break;

                        case PrototypeCurveField curveField:
                            AddReference(curveField.Value, referencer);
                            break;

                        case PrototypePrototypeField protoField:
                            AddReference(protoField.Value, referencer);
                            break;

                        case PrototypeRHStructField rhStructField:
                            AddReferencesFromPrototype(rhStructField.Value, referencer);
                            break;

                        case PrototypeStringField stringField:
                            AddReference(stringField.Value, referencer);
                            break;

                        case PrototypeTypeField typeField:
                            AddReference(typeField.Value, referencer);
                            break;
                    }
                }

                for (int i = 0; i < fieldGroup.ListFields.Count; i++)
                {
                    PrototypeField field = fieldGroup.ListFields[i];
                    switch (field)
                    {
                        case PrototypeAssetListField assetListField:
                            foreach (AssetId assetRef in assetListField)
                                AddReference(assetRef, referencer);
                            break;

                        case PrototypePrototypeListField protoListField:
                            foreach (PrototypeId protoRef in protoListField)
                                AddReference(protoRef, referencer);
                            break;

                        case PrototypeRHStructListField rhStructListField:
                            foreach (Prototype rhStruct in rhStructListField)
                                AddReferencesFromPrototype(rhStruct, referencer);
                            break;

                        case PrototypeTypeListField typeListField:
                            foreach (AssetTypeId assetTypeRef in typeListField)
                                AddReference(assetTypeRef, referencer);
                            break;
                    }
                }
            }
        }

        private void AddReference(AssetId assetRef, PrototypeId referencer)
        {
            AddReference(GetIndex(DataRefIndexType.Asset), (ulong)assetRef, referencer);
        }

        private void AddReference(CurveId curveRef, PrototypeId referencer)
        {
            AddReference(GetIndex(DataRefIndexType.Curve), (ulong)curveRef, referencer);
        }

        private void AddReference(PrototypeId protoRef, PrototypeId referencer)
        {
            AddReference(GetIndex(DataRefIndexType.Prototype), (ulong)protoRef, referencer);
        }

        private void AddReference(LocaleStringId localeStringId, PrototypeId referencer)
        {
            AddReference(GetIndex(DataRefIndexType.String), (ulong)localeStringId, referencer);
        }

        private void AddReference(AssetTypeId assetTypeRef, PrototypeId referencer)
        {
            AddReference(GetIndex(DataRefIndexType.Type), (ulong)assetTypeRef, referencer);
        }

        private static void AddReference(IndexDictionary index, ulong dataRef, PrototypeId referencer)
        {
            if (index.TryGetValue(dataRef, out HashSet<PrototypeId> referencers) == false)
            {
                referencers = new();
                index.Add(dataRef, referencers);
            }

            referencers.Add(referencer);
        }

        #endregion

        #region Serialization

        public void LoadFromFile(string path)
        {
            Clear();

            using FileStream fs = File.OpenRead(path);
            using BinaryReader reader = new(fs);

            int version = reader.ReadUInt16();
            if (version != CurrentVersion)
                return;

            Checksum = reader.ReadUInt32();

            foreach (IndexDictionary index in _indexes)
                LoadIndex(index, reader);
        }

        public void SaveToFile(string path)
        {
            using FileStream fs = File.Create(path);
            using BinaryWriter writer = new(fs);

            writer.Write(CurrentVersion);
            writer.Write(Checksum);

            foreach (IndexDictionary index in _indexes)
                SaveIndex(index, writer);
        }

        private static void LoadIndex(Dictionary<ulong, HashSet<PrototypeId>> index, BinaryReader reader)
        {
            index.Clear();

            int numValues = reader.ReadInt32();
            for (int i = 0; i < numValues; i++)
            {
                ulong dataRef = reader.ReadUInt64();
                int numReferencers = reader.ReadInt32();

                HashSet<PrototypeId> referencers = new(numReferencers);
                for (int j = 0; j < numReferencers; j++)
                    referencers.Add((PrototypeId)reader.ReadUInt64());

                index.Add(dataRef, referencers);
            }
        }

        private static void SaveIndex(Dictionary<ulong, HashSet<PrototypeId>> index, BinaryWriter writer)
        {
            writer.Write(index.Count);
            foreach (var kvp in index)
            {
                writer.Write(kvp.Key);
                writer.Write(kvp.Value.Count);
                foreach (PrototypeId referencer in kvp.Value)
                    writer.Write((ulong)referencer);
            }
        }

        #endregion

        private sealed class IndexDictionary : Dictionary<ulong, HashSet<PrototypeId>>
        {
        }
    }
}
