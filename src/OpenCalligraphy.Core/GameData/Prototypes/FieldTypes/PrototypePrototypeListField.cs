namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypePrototypeListField : PrototypeListField
    {
        private readonly List<PrototypeId> _values = new();

        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Prototype; }

        public IReadOnlyList<PrototypeId> Values { get => _values; }
        public int Count { get => _values.Count; }
        public PrototypeId this[int i] { get => _values[i]; }

        public PrototypePrototypeListField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            PrototypeId subtype = (PrototypeId)GetBlueprintMember().Subtype;
            string runtimeBinding = DataDirectory.Instance.GetPrototypeRuntimeBinding(subtype);
            return $"{runtimeBinding}[{_values.Count}] (PrototypeDataRef)";
        }

        public List<PrototypeId>.Enumerator GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        public override void ParseFrom(BinaryReader reader)
        {
            _values.Clear();

            int numValues = reader.ReadUInt16();
            _values.EnsureCapacity(numValues);

            for (int i = 0; i < numValues; i++)
            {
                PrototypeId value = (PrototypeId)reader.ReadUInt64();
                _values.Add(value);
            }
        }
    }
}
