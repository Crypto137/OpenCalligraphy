using OpenCalligraphy.Core.GameData.Prototypes;
using OpenCalligraphy.Core.Logging;
using System.Diagnostics;

namespace OpenCalligraphy.Core.GameData
{
    public static class GameDatabase
    {
        // DataRef is a unique ulong id that may change across different versions of the game (e.g. a prototype DataRef is hashed file path).
        // In the client data refs are structs that encapsulate a 64-bit DataId.
        public static DataRefManager<StringId> StringRefManager { get; } = new(false);   // AssetId inherits from StringId in the client, which is why this is called StringRefManager
        public static DataRefManager<AssetTypeId> AssetTypeRefManager { get; } = new(true);
        public static DataRefManager<CurveId> CurveRefManager { get; } = new(true);
        public static DataRefManager<BlueprintId> BlueprintRefManager { get; } = new(true);
        public static DataRefManager<PrototypeId> PrototypeRefManager { get; } = new(true);

        private static readonly Logger Logger = LogManager.CreateLogger();

        private static bool _isInitialized = false;

        public static DataDirectory DataDirectory { get; } = DataDirectory.Instance;

        public static bool Initialize(string filePath)
        {
            if (File.Exists(filePath) == false)
                return false;

            if (_isInitialized)
                Clear();

            Logger.Info("Initializing game database...");
            var stopwatch = Stopwatch.StartNew();

            // Initialize DataDirectory
            DataDirectory.Initialize(filePath);

            // Finish game database initialization
            stopwatch.Stop();
            Logger.Info($"Finished initializing game database in {stopwatch.ElapsedMilliseconds} ms");
            _isInitialized = true;
            return true;
        }

        public static void Clear()
        {
            StringRefManager.Clear();
            AssetTypeRefManager.Clear();
            CurveRefManager.Clear();
            BlueprintRefManager.Clear();
            PrototypeRefManager.Clear();

            DataDirectory.Clear();

            _isInitialized = false;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #region Data Access

        public static Blueprint GetBlueprint(BlueprintId blueprintId)
        {
            return DataDirectory.GetBlueprint(blueprintId);
        }

        public static Prototype GetPrototype(PrototypeId prototypeId)
        {
            return DataDirectory.GetPrototype(prototypeId);
        }

        public static Prototype GetPrototype(string prototypeName)
        {
            PrototypeId prototypeId = PrototypeRefManager.GetDataRefByName(prototypeName);
            return DataDirectory.GetPrototype(prototypeId);
        }

        public static string GetAssetName(AssetId assetId)
        {
            return StringRefManager.GetReferenceName((StringId)assetId);
        }

        public static string GetAssetTypeName(AssetTypeId assetTypeId)
        {
            return AssetTypeRefManager.GetReferenceName(assetTypeId);
        }

        public static string GetCurveName(CurveId curveId)
        {
            return CurveRefManager.GetReferenceName(curveId); ;
        }

        public static string GetBlueprintName(BlueprintId blueprintId)
        {
            return BlueprintRefManager.GetReferenceName(blueprintId);
        }

        public static string GetStringName(StringId stringId)
        {
            return StringRefManager.GetReferenceName(stringId);
        }

        public static string GetPrototypeName(PrototypeId prototypeId)
        {
            return PrototypeRefManager.GetReferenceName(prototypeId);
        }

        public static string GetFormattedPrototypeName(PrototypeId prototypeId)
        {
            return Path.GetFileNameWithoutExtension(GetPrototypeName(prototypeId));
        }

        #endregion
    }
}
