namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeRHStructListField : PrototypeListField
    {
        private readonly List<Prototype> _values = new();

        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.RHStruct; }

        public IReadOnlyList<Prototype> Values { get => _values; }
        public int Count { get => _values.Count; }
        public Prototype this[int i] { get => _values[i]; }

        public PrototypeRHStructListField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            PrototypeId subtype = (PrototypeId)GetBlueprintMember().Subtype;
            string runtimeBinding = DataDirectory.Instance.GetPrototypeRuntimeBinding(subtype);
            return $"{runtimeBinding}[{_values.Count}] (RHStruct)";
        }

        public List<Prototype>.Enumerator GetEnumerator()
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
                Prototype value = new();
                value.ParseFrom(reader);
                _values.Add(value);
            }
        }
    }
}
