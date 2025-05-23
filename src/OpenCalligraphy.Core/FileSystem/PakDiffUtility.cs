using OpenCalligraphy.Core.Helpers;

namespace OpenCalligraphy.Core.FileSystem
{
    /// <summary>
    /// Compares <see cref="PakFile"/> instances.
    /// </summary>
    public static class PakDiffUtility
    {
        public const char PrefixAdded     = '+';
        public const char PrefixRemoved   = '-';
        public const char PrefixChanged   = '!';
        public const char PrefixUnchanged = ' ';

        /// <summary>
        /// Loads <see cref="PakFile"/> instances from specified file paths and compares them. The result is written to the provided <see cref="TextWriter"/>.
        /// </summary>
        public static void Diff(string oldFilePath, string newFilePath, TextWriter outputWriter)
        {
            PakFile oldPakFile = new(oldFilePath);
            PakFile newPakFile = new(newFilePath);

            Diff(oldPakFile, newPakFile, outputWriter);
        }

        /// <summary>
        /// Compares provided <see cref="PakFile"/> instances. The result is written to the provided <see cref="TextWriter"/>.
        /// </summary>
        public static void Diff(PakFile oldPakFile, PakFile newPakFile, TextWriter outputWriter)
        {
            ArgumentNullException.ThrowIfNull(oldPakFile);
            ArgumentNullException.ThrowIfNull(newPakFile);
            ArgumentNullException.ThrowIfNull(outputWriter);

            CalculateFileChecksums(oldPakFile, out Dictionary<string, uint> oldChecksums);
            CalculateFileChecksums(newPakFile, out Dictionary<string, uint> newChecksums);

            SortedSet<string> fileSet = new();
            fileSet.UnionWith(oldChecksums.Keys);
            fileSet.UnionWith(newChecksums.Keys);

            foreach (string fileName in fileSet)
            {
                char prefix = GetFilePrefix(fileName, oldChecksums, newChecksums);
                if (prefix == PrefixUnchanged)
                    continue;

                outputWriter.WriteLine($"{prefix} {fileName}");
            }
        }

        /// <summary>
        /// Calculates checksums for all files in the provided <see cref="PakFile"/> and adds them to the provided <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        private static void CalculateFileChecksums(PakFile pakFile, out Dictionary<string, uint> checksumDict)
        {
            checksumDict = new();

            foreach (PakFile.Entry entry in pakFile)
            {
                Stream stream = pakFile.LoadFileDataInPak(entry.FilePath);
                checksumDict.Add(entry.FilePath, HashHelper.Djb2(stream));
            }
        }

        /// <summary>
        /// Determines prefix for the specified file name based on the provided checksum collections.
        /// </summary>
        private static char GetFilePrefix(string fileName, Dictionary<string, uint> oldChecksums, Dictionary<string, uint> newChecksums)
        {
            bool wasPresentBefore = oldChecksums.TryGetValue(fileName, out uint oldChecksum);
            bool isPresentNow = newChecksums.TryGetValue(fileName, out uint newChecksum);

            if (wasPresentBefore && isPresentNow)
            {
                if (oldChecksum != newChecksum)
                    return PrefixChanged;
                else
                    return PrefixUnchanged;
            }
            else
            {
                if (wasPresentBefore)
                    return PrefixRemoved;
                else if (isPresentNow)
                    return PrefixAdded;
            }

            throw new($"Failed to determine prefix for file '{fileName}'.");   // This should never happen
        }
    }
}
