namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeAssetField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Asset; }

        public AssetId Value { get; private set; }

        public PrototypeAssetField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            AssetTypeId assetTypeId = (AssetTypeId)GetBlueprintMember().Subtype;
            string assetName = Value != AssetId.Invalid ? Value.GetName() : "Invalid";
            string assetType = Path.GetFileNameWithoutExtension(assetTypeId.GetName());
            return $"{assetName} ({assetType})";
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = (AssetId)reader.ReadUInt64();
        }
    }
}
