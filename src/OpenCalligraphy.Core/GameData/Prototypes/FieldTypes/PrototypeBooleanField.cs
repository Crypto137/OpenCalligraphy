namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeBooleanField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Boolean; }

        public bool Value { get; private set; }

        public PrototypeBooleanField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = Convert.ToBoolean(reader.ReadUInt64());
        }
    }
}
