using OpenCalligraphy.Core.Extensions;

namespace OpenCalligraphy.Core.Locales
{
    public class LocaleFlag
    {
        public ushort BitValue { get; }
        public ushort BitMask { get; }
        public string FlagText { get; }

        public LocaleFlag(BinaryReader reader)
        {
            BitValue = reader.ReadUInt16();
            BitMask = reader.ReadUInt16();
            FlagText = reader.ReadFixedString16();
        }

        public override string ToString()
        {
            return FlagText;
        }
    }
}
