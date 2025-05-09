namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeStringField : PrototypeSimpleField
    {
        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.String; }

        public LocaleStringId Value { get; private set; }

        public PrototypeStringField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return $"{Value} (LocaleStringId)";
        }

        public override void ParseFrom(BinaryReader reader)
        {
            Value = (LocaleStringId)reader.ReadUInt64();
        }
    }
}
