using OpenCalligraphy.Core.Extensions;

namespace OpenCalligraphy.Core.Locales
{
    public class StringVariation
    {
        public ulong FlagsConsumed { get; set; }
        public ushort FlagsProduced { get; set; }
        public string String { get; set; }

        public StringVariation(BinaryReader reader)
        {
            FlagsConsumed = reader.ReadUInt64();
            FlagsProduced = reader.ReadUInt16();
            String = reader.ReadNullTerminatedString(reader.ReadUInt32());
        }
    }
}
