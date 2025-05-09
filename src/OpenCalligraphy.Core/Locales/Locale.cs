using OpenCalligraphy.Core.Exceptions;
using OpenCalligraphy.Core.Extensions;
using OpenCalligraphy.Core.GameData;

namespace OpenCalligraphy.Core.Locales
{
    public class Locale
    {
        private readonly Dictionary<LocaleStringId, StringMapEntry> _stringMap = new();

        public string Name { get; }
        public string LanguageDisplayName { get; }
        public string RegionDisplayName { get; }
        public string Directory { get; }
        public LocaleFlag[] Flags { get; }

        public int EntryCount { get => _stringMap.Count; }

        public Locale()
        {
            Name = string.Empty;
            LanguageDisplayName = string.Empty;
            RegionDisplayName = string.Empty;
            Directory = string.Empty;
            Flags = Array.Empty<LocaleFlag>();
        }

        public Locale(Stream stream)
        {
            using BinaryReader reader = new(stream);

            // Validate header
            CalligraphyHeader header = new(reader);

            if (header.Magic != "LOC")
                throw new CalligraphyException("Invalid locale file signature.");

            if (header.Version != 2)
                throw new CalligraphyException($"Unsupported locale file version {header.Version}.");

            // Load data
            Name = reader.ReadFixedString16();
            LanguageDisplayName = reader.ReadFixedString16();
            RegionDisplayName = reader.ReadFixedString16();
            Directory = reader.ReadFixedString16();

            Flags = new LocaleFlag[reader.ReadByte()];
            for (int i = 0; i < Flags.Length; i++)
                Flags[i] = new(reader);
        }

        public bool ImportStringStream(string streamName, Stream stream)
        {
            using BinaryReader reader = new(stream);

            // Validate header
            CalligraphyHeader header = new(reader);

            if (header.Magic != "STR")
                throw new CalligraphyException($"Invalid string stream signature for stream {streamName}.");

            if (header.Version != 2)
                throw new CalligraphyException($"Unsupported string stream version {header.Version}.");

            // Load data
            int entryCount = reader.ReadUInt16();
            for (int i = 0; i < entryCount; i++)
            {
                var id = (LocaleStringId)reader.ReadUInt64();
                _stringMap.Add(id, new(reader));
            }

            return true;
        }

        public string GetLocaleString(LocaleStringId stringId)
        {
            if (_stringMap.TryGetValue(stringId, out StringMapEntry entry) == false)
                return string.Empty;

            return entry.String;
        }
    }
}
