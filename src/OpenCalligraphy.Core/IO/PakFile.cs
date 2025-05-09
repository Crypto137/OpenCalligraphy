using OpenCalligraphy.Core.Exceptions;
using OpenCalligraphy.Core.Extensions;
using OpenCalligraphy.Core.Helpers;

namespace OpenCalligraphy.Core.IO
{
    // TODO: This implementation is based on MHServerEmu and is designed for efficient reads, probably need to overhaul this for output.

    /// <summary>
    /// Represents a loaded .sip package file.
    /// </summary>
    public class PakFile
    {
        // PAK / GPAK / .sip files are package files that contain compressed game data files.
        // They consist of a header, an entry table, and data for all stored files compressed using the LZ4 algorithm.

        private const uint Signature = 1196441931;  // KAPG
        private const uint SQLiteSignature = 1766609235;    // SQLi(ite format 3)
        private const uint Version = 1;

        private readonly Dictionary<string, PakEntry> _entryDict = new();
        private readonly byte[] _data;

        public uint Checksum { get; private set; }

        /// <summary>
        /// Loads a <see cref="PakFile"/> from the specified path.
        /// </summary>
        public PakFile(string pakFilePath)
        {
            if (File.Exists(pakFilePath) == false)
                throw new CalligraphyException($"PakFile {pakFilePath} not found.");

            using FileStream stream = File.OpenRead(pakFilePath);
            using BinaryReader reader = new(stream);

            // Read file header
            uint signature = reader.ReadUInt32();
            if (signature != Signature)
            {
                if (signature == SQLiteSignature)    // SQLi
                    throw new CalligraphyException($"Attempting to load a legacy PakFile, which is not supported.");
                else
                    throw new CalligraphyException($"Invalid PakFile signature 0x{signature:X}, expected 0x{Signature:X}.");
            }

            uint version = reader.ReadUInt32();
            if (version != Version)
                throw new CalligraphyException($"Invalid PakFile version {version}, expected {Version}.");

            // Read all entries
            int numEntries = reader.ReadInt32();

            if (numEntries > 0)
            {
                _entryDict.EnsureCapacity(numEntries);

                // We make use of the fact that entries are in the same order as their compressed data that follows,
                // so we can get the full size of the compressed data section from the last entry.
                PakEntry newEntry = default;

                for (int i = 0; i < numEntries; i++)
                {
                    newEntry = new(reader);
                    _entryDict.Add(newEntry.FilePath, newEntry);
                }

                // Read and store compressed data as a single array we will slice with spans
                int dataSize = newEntry.Offset + newEntry.CompressedSize;
                _data = reader.ReadBytes(dataSize);
            }
            else
            {
                // Empty pak file
                _data = Array.Empty<byte>();
            }

            Checksum = CalculateChecksum();
        }

        /// <summary>
        /// Returns a <see cref="Stream"/> of decompressed data for the file stored at the specified path in this <see cref="PakFile"/>.
        /// </summary>
        public Stream LoadFileDataInPak(string filePath)
        {
            if (_entryDict.TryGetValue(filePath, out PakEntry entry) == false)
                throw new CalligraphyException($"File '{filePath}' not found in the PakFile.");

            ReadOnlySpan<byte> compressedData = _data.AsSpan(entry.Offset, entry.CompressedSize);
            byte[] uncompressedData = new byte[entry.UncompressedSize];
            CompressionHelper.LZ4Decode(compressedData, uncompressedData);
            return new MemoryStream(uncompressedData);
        }

        private uint CalculateChecksum()
        {
            if (_data == null || _data.Length == 0)
                return 0;

            return HashHelper.Djb2(_data);
        }

        /// <summary>
        /// Metadata for a file contained in a <see cref="PakFile"/>.
        /// </summary>
        private readonly struct PakEntry
        {
            public ulong FileHash { get; }
            public string FilePath { get; }
            public int ModTime { get; }
            public int Offset { get; }
            public int CompressedSize { get; }
            public int UncompressedSize { get; }

            public PakEntry(BinaryReader reader)
            {
                FileHash = reader.ReadUInt64();
                FilePath = reader.ReadFixedString32();
                ModTime = reader.ReadInt32();
                Offset = reader.ReadInt32();
                CompressedSize = reader.ReadInt32();
                UncompressedSize = reader.ReadInt32();
            }
        }
    }
}
