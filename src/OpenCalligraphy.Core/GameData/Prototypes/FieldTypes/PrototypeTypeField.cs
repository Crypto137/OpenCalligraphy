namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeTypeField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Type; }

        public AssetTypeId Value { get; private set; }

        public PrototypeTypeField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return Value != AssetTypeId.Invalid ? $"{Value.GetName()} ({Value})" : "Invalid";
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = (AssetTypeId)reader.ReadUInt64();
        }
    }
}
