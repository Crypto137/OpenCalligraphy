using OpenCalligraphy.Core.Extensions;

namespace OpenCalligraphy.Core.Locales
{
    public class StringMapEntry
    {
        public StringVariation[] Variants { get; set; }
        public ushort FlagsProduced { get; set; }
        public string String { get; set; }

        public StringMapEntry(BinaryReader reader)
        {
            ushort variantNum = reader.ReadUInt16();
            Variants = variantNum > 0
                ? new StringVariation[variantNum - 1]
                : Array.Empty<StringVariation>();

            FlagsProduced = reader.ReadUInt16();
            String = reader.ReadNullTerminatedString(reader.ReadUInt32());

            for (int i = 0; i < Variants.Length; i++)
                Variants[i] = new(reader);
        }

        public override string ToString()
        {
            return String;
        }
    }
}
