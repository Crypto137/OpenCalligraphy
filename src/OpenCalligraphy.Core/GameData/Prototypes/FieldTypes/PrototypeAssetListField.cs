namespace OpenCalligraphy.Core.GameData.Prototypes.FieldTypes
{
    public sealed class PrototypeAssetListField : PrototypeListField
    {
        private readonly List<AssetId> _values = new();

        public override CalligraphyBaseType BaseType { get => CalligraphyBaseType.Asset; }

        public IReadOnlyList<AssetId> Values { get => _values; }
        public int Count { get => _values.Count; }
        public AssetId this[int i] { get => _values[i]; }

        public PrototypeAssetListField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }

        public override string ToString()
        {
            AssetTypeId subtype = (AssetTypeId)GetBlueprintMember().Subtype;
            string assetType = subtype.GetName();
            return $"{assetType}[{_values.Count}]";
        }

        public List<AssetId>.Enumerator GetEnumerator()
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
                AssetId value = (AssetId)reader.ReadUInt64();
                _values.Add(value);
            }
        }
    }
}
