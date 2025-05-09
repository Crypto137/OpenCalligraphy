namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeTypeListField : PrototypeListField
    {
        private readonly List<AssetTypeId> _values = new();

        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Type; }

        public IReadOnlyList<AssetTypeId> Values { get => _values; }
        public int Count { get => _values.Count; }
        public AssetTypeId this[int i] { get => _values[i]; }

        public PrototypeTypeListField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            return $"AssetType[{_values.Count}]";
        }

        public List<AssetTypeId>.Enumerator GetEnumerator()
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
                AssetTypeId value = (AssetTypeId)reader.ReadUInt64();
                _values.Add(value);
            }
        }
    }
}
