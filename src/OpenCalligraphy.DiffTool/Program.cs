using OpenCalligraphy.Core.Exceptions;
using OpenCalligraphy.Core.FileSystem;
using OpenCalligraphy.Core.Helpers;

namespace OpenCalligraphy.DiffTool
{
    internal class Program
    {
        const char PrefixAdded      = '+';
        const char PrefixRemoved    = '-';
        const char PrefixChanged    = '!';
        const char PrefixUnchanged  = ' ';
        const char PrefixUnknown    = '?';

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: OpenCalligraphy.DiffTool [oldPakFile] [newPakFile]");
                return;
            }

            if (LoadPakFile(args[0], out PakFile oldPakFile) == false)
                return;

            if (LoadPakFile(args[1], out PakFile newPakFile) == false)
                return;

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

                Console.WriteLine($"{prefix} {fileName}");
            }
        }

        static bool LoadPakFile(string path, out PakFile pakFile)
        {
            pakFile = null;

            if (File.Exists(path) == false)
            {
                Console.WriteLine($"'{path}' not found.");
                return false;
            }

            try
            {
                pakFile = new(path);
            }
            catch (CalligraphyException calligraphyException)
            {
                Console.WriteLine($"Failed to load {path}: '{calligraphyException.Message}'");
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Failed to load {path}:\n{exception}");
                return false;
            }

            return true;
        }

        static void CalculateFileChecksums(PakFile pakFile, out Dictionary<string, uint> checksumDict)
        {
            checksumDict = new();

            foreach (PakFile.Entry entry in pakFile)
            {
                Stream stream = pakFile.LoadFileDataInPak(entry.FilePath);
                checksumDict.Add(entry.FilePath, HashHelper.Djb2(stream));
            }
        }

        static char GetFilePrefix(string fileName, Dictionary<string, uint> oldChecksums, Dictionary<string, uint> newChecksums)
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

            return PrefixUnknown;   // This shouldn't happen
        }

        readonly struct FileInfo(string name, uint checksum)
        {
            public readonly string Name = name;
            public readonly uint Checksum = checksum;
        }
    }
}
