namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypePrototypeField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Prototype; }

        public PrototypeId Value { get; private set; }

        public PrototypePrototypeField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return Value != PrototypeId.Invalid ? $"{Value.GetName()} ({Value})" : "Invalid";
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = (PrototypeId)reader.ReadUInt64();
        }
    }
}
