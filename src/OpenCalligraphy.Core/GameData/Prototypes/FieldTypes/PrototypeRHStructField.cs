namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeRHStructField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.RHStruct; }

        public Prototype Value { get; private set; }
        public bool IsNull { get => Value.HasInstanceData == false && Value.ParentDataRef == PrototypeId.Invalid; }

        public PrototypeRHStructField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = new();
            Value.ParseFrom(reader);
        }
    }
}
