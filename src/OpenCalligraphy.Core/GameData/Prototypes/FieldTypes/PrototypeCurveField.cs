namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeCurveField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Curve; }

        public CurveId Value { get; private set; }

        public PrototypeCurveField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return Value != CurveId.Invalid ? $"{Value.GetName()} ({Value})" : "Invalid";
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = (CurveId)reader.ReadUInt64();
        }
    }
}
