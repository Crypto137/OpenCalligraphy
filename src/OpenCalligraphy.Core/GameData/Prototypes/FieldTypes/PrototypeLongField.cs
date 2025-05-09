namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeLongField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Long; }

        public long Value { get; private set; }

        public PrototypeLongField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = reader.ReadInt64();
        }
    }
}
