namespace OpenCalligraphy.Core.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Creates a directory if needed and saves the provided text to the specified path.
        /// </summary>
        public static void WriteTextFile(string path, string text)
        {
            string directory = Path.GetDirectoryName(path);
            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            File.WriteAllText(path, text);
        }
    }
}
