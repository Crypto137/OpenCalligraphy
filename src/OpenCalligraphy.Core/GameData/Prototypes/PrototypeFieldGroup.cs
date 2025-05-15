namespace OpenCalligraphy.Core.GameData.Prototypes
{
    public class PrototypeFieldGroup
    {
        private readonly List<PrototypeField> _simpleFields = new();
        private readonly List<PrototypeField> _listFields = new();

        public BlueprintId DeclaringBlueprintId { get; }
        public byte BlueprintCopyNumber { get; }

        public IReadOnlyList<PrototypeField> SimpleFields { get => _simpleFields; }
        public IReadOnlyList<PrototypeField> ListFields { get => _listFields; }

        public PrototypeFieldGroup(BlueprintId declaringBlueprintId, byte blueprintCopyNumber)
        {
            DeclaringBlueprintId = declaringBlueprintId;
            BlueprintCopyNumber = blueprintCopyNumber;
        }

        public override string ToString()
        {
            return $"{DeclaringBlueprintId.GetName()}[{BlueprintCopyNumber}]";
        }

        public void AddField(PrototypeField field)
        {
            switch (field.StructureType)
            {
                case CalligraphyStructureType.Simple:
                    _simpleFields.Add(field);
                    break;

                case CalligraphyStructureType.List:
                    _listFields.Add(field);
                    break;

                default:
                    throw new($"Invalid field structure type {field.StructureType}.");
            }
        }

        public void ParseFieldsFrom(BinaryReader reader, CalligraphyStructureType structureType)
        {
            int numSimpleFields = reader.ReadUInt16();
            for (int i = 0; i < numSimpleFields; i++)
            {
                StringId fieldId = (StringId)reader.ReadUInt64();
                CalligraphyBaseType baseType = (CalligraphyBaseType)reader.ReadByte();

                PrototypeField field = PrototypeField.CreateInstance(DeclaringBlueprintId, fieldId, baseType, structureType);
                field.ParseFrom(reader);
                AddField(field);
            }
        }

        public T GetSimpleField<T>(StringId fieldId) where T: PrototypeField
        {
            foreach (PrototypeField field in _simpleFields)
            {
                if (field.FieldId == fieldId)
                    return field as T;
            }

            return null;
        }

        public T GetListField<T>(StringId fieldId) where T: PrototypeField
        {
            foreach (PrototypeField field in _listFields)
            {
                if (field.FieldId == fieldId)
                    return field as T;
            }

            return null;
        }
    }
}
