using System.Diagnostics;
using System.Text;
using OpenCalligraphy.Core.Exceptions;
using OpenCalligraphy.Core.Logging;

namespace OpenCalligraphy.Core.ExecutableAnalysis
{
    /// <summary>
    /// Represents a loaded Marvel Heroes executable.
    /// </summary>
    public class ExecutableFile
    {
        private static readonly Logger Logger = LogManager.CreateLogger();

        private static readonly byte[] ShippingSignature = Convert.FromHexString("5368697070696E675C"); // Shipping\
        private static readonly byte[] PathSignature = Convert.FromHexString("3A5C6D");                 // :\m (from D:\mirrorBuilds\);

        public string FileName { get; }
        public string Version { get; }
        public byte[] Data { get; }

        public bool IsShipping { get; }

        /// <summary>
        /// Loads an <see cref="ExecutableFile"/> from the provided path and validates it if needed.
        /// </summary>
        public ExecutableFile(string filePath, bool validate)
        {
            Logger.Info($"Analyzing {filePath}...");

            // Check if the file even exists
            if (File.Exists(filePath) == false)
                throw new CalligraphyException($"File '{filePath}' not found.");

            // Check version info
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filePath);

            if (validate && versionInfo.CompanyName != "Gazillion, Inc.")
                throw new CalligraphyException($"File '{filePath}' is not a Marvel Heroes executable.");

            FileName = Path.GetFileName(filePath);
            Version = versionInfo.FileVersion.Replace(',', '.');

            // Load the executable and check for the Shipping signature
            Data = File.ReadAllBytes(filePath);
            IsShipping = Data.AsSpan().IndexOf(ShippingSignature) != -1;
        }

        public override string ToString()
        {
            return $"{FileName} {GetVersionString()}";
        }

        public string GetVersionString()
        {
            return $"{Version} ({(IsShipping ? "Shipping" : "Internal")})";
        }

        /// <summary>
        /// Extracts source file paths from this <see cref="ExecutableFile"/> and adds them to the provided <see cref="List{T}"/>.
        /// </summary>
        public void ExtractSourceFileList(List<string> outputFilePathList)
        {
            Logger.Info($"Extracting source file paths from {this}...");

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<string> filePathList = new();

            byte firstByte = PathSignature[0];
            int signatureLength = PathSignature.Length;

            // Look for our source file path signature
            for (int i = 0; i < Data.Length; i++)
            {
                // Check the entire signature only if the first byte matches
                if (Data[i] != firstByte)
                    continue;

                if (Data.AsSpan(i, signatureLength).SequenceEqual(PathSignature) == false)
                    continue;

                List<byte> byteList = new();

                // Our signature contains the beginning of a path after the drive letter
                // because the letter can be both lower and upper case.
                // We start our inner loop one position before and then read bytes until
                // we reach a null, because paths are null-terminated strings.
                for (int j = i - 1; Data[j] != 0x00; j++)
                    byteList.Add(Data[j]);

                string filePath = Encoding.UTF8.GetString(byteList.ToArray());
                filePathList.Add(filePath);
            }

            stopwatch.Stop();
            Logger.Info($"Found {filePathList.Count} file path strings in {stopwatch.ElapsedMilliseconds} ms");

            // Clean up our list
            Logger.Info("Cleaning up the list...");

            // Fix directory separator chars
            for (int i = 0; i < filePathList.Count; i++)
                filePathList[i] = filePathList[i].Replace('/', '\\');

            // Remove duplicates
            filePathList = filePathList.Distinct(StringComparer.OrdinalIgnoreCase).ToList();

            // Remove invalid file paths (in case our signature caught random junk)
            filePathList.RemoveAll(filePath => filePath.Contains("MarvelGame", StringComparison.OrdinalIgnoreCase) == false);

            // Sort
            filePathList.Sort();

            Logger.Info($"Found {filePathList.Count} unique file paths");

            outputFilePathList.AddRange(filePathList);
        }
    }
}
