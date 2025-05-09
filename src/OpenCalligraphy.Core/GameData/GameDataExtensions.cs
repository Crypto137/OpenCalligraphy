using OpenCalligraphy.Core.GameData.Prototypes;

namespace OpenCalligraphy.Core.GameData
{
    /// <summary>
    /// Provides shortcuts for access to game data.
    /// </summary>
    public static class GameDataExtensions
    {
        /// <summary>
        /// Returns the <see cref="Blueprint"/> that this <see cref="BlueprintId"/> refers to.
        /// </summary>
        public static Blueprint AsBlueprint(this BlueprintId blueprintId)
        {
            return GameDatabase.GetBlueprint(blueprintId);
        }

        /// <summary>
        /// Returns the <typeparamref name="T"/> that this <see cref="PrototypeId"/> refers to.
        /// </summary>
        public static Prototype AsPrototype(this PrototypeId prototypeId)
        {
            return GameDatabase.GetPrototype(prototypeId);
        }

        /// <summary>
        /// Returns the name of this <see cref="AssetTypeId"/>.
        /// </summary>
        public static string GetName(this AssetTypeId assetTypeId)
        {
            return GameDatabase.GetAssetTypeName(assetTypeId);
        }

        /// <summary>
        /// Returns the name of this <see cref="AssetId"/>.
        /// </summary>
        public static string GetName(this AssetId assetId)
        {
            return GameDatabase.GetAssetName(assetId);
        }

        /// <summary>
        /// Returns the name of this <see cref="CurveId"/>.
        /// </summary>
        public static string GetName(this CurveId curveId)
        {
            return GameDatabase.GetCurveName(curveId);
        }

        /// <summary>
        /// Returns the name of this <see cref="BlueprintId"/>.
        /// </summary>
        public static string GetName(this BlueprintId blueprintId)
        {
            return GameDatabase.GetBlueprintName(blueprintId);
        }

        /// <summary>
        /// Returns the name of this <see cref="PrototypeId"/>.
        /// </summary>
        public static string GetName(this PrototypeId prototypeId)
        {
            return GameDatabase.GetPrototypeName(prototypeId);
        }

        /// <summary>
        /// Returns the name of this <see cref="StringId"/>.
        /// </summary>
        public static string GetName(this StringId stringId)
        {
            return GameDatabase.GetStringName(stringId);
        }
    }
}
