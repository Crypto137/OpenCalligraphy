using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using OpenCalligraphy.Core.Exceptions;
using OpenCalligraphy.Core.Extensions;
using OpenCalligraphy.Core.GameData;

namespace OpenCalligraphy.Core.Locales
{
    public class Locale
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)   // This is needed to export localized strings correctly
        };

        private readonly Dictionary<LocaleStringId, StringMapEntry> _stringMap = new();

        public string Name { get; }
        public string LanguageDisplayName { get; }
        public string RegionDisplayName { get; }
        public string Directory { get; }
        public LocaleFlag[] Flags { get; }

        public IReadOnlyDictionary<LocaleStringId, StringMapEntry> Entries { get => _stringMap; }

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
            {
                if (TryParseLegacyLocaleFile(reader, out string[] values) == false)
                    throw new CalligraphyException("Invalid locale file.");

                Name = values[0];
                LanguageDisplayName = values[1];
                RegionDisplayName = values[2];
                Directory = values[3];
                return;
            }

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

            if (header.Version > 2)
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

        public void ExportToJson(string path)
        {
            string json = JsonSerializer.Serialize(this, JsonOptions);

            string directory = Path.GetDirectoryName(path);
            if (System.IO.Directory.Exists(directory) == false)
                System.IO.Directory.CreateDirectory(directory);

            File.WriteAllText(path, json);
        }

        private static bool TryParseLegacyLocaleFile(BinaryReader reader, out string[] values)
        {
            // Legacy locale files (pre-1.32) are just text files consisting of four lines separated by \r\n.
            // They have no headers, so we identify them by checking the number of values we get.
            const int NumValues = 4;

            reader.BaseStream.Position = 0;
            byte[] bytes = reader.ReadBytes((int)reader.BaseStream.Length);
            string legacyLocale = Encoding.UTF8.GetString(bytes);
            values = legacyLocale.Split("\r\n");

            return values.Length == NumValues;
        }
    }
}
