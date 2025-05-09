namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeDoubleField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Double; }

        public double Value { get; private set; }

        public PrototypeDoubleField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = reader.ReadDouble();
        }
    }
}
