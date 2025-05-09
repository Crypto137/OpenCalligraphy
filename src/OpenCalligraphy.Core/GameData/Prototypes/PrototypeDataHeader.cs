namespace OpenCalligraphy.Core.GameData.Prototypes
{
    public readonly struct PrototypeDataHeader
    {
        // CalligraphyReader::ReadPrototypeHeader

        [Flags]
        private enum PrototypeDataDesc : byte
        {
            None            = 0,
            ReferenceExists = 1 << 0,
            DataExists      = 1 << 1,
            PolymorphicData = 1 << 2
        }

        public bool ReferenceExists { get; }
        public bool DataExists { get; }
        public bool PolymorphicData { get; }
        public PrototypeId ReferenceType { get; }     // Parent prototype id, invalid (0) for .defaults

        public PrototypeDataHeader(BinaryReader reader)
        {
            var flags = (PrototypeDataDesc)reader.ReadByte();
            ReferenceExists = flags.HasFlag(PrototypeDataDesc.ReferenceExists);
            DataExists = flags.HasFlag(PrototypeDataDesc.DataExists);
            PolymorphicData = flags.HasFlag(PrototypeDataDesc.PolymorphicData);

            ReferenceType = ReferenceExists ? (PrototypeId)reader.ReadUInt64() : 0;
        }
    }
}
