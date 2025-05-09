using OpenCalligraphy.Core.Exceptions;

namespace OpenCalligraphy.Core.Locales
{
    /// <summary>
    /// A singleton that manages <see cref="Locale"/> instances.
    /// </summary>
    public class LocaleManager
    {
        public static LocaleManager Instance { get; } = new();

        public Locale CurrentLocale { get; private set; } = new();

        private LocaleManager() { }

        public void LoadLocale(string path)
        {
            if (File.Exists(path) == false)
                throw new CalligraphyException($"Locale file {path} not found.");

            using FileStream stream = File.OpenRead(path);
            Locale locale = new(stream);

            string stringFileDirectory = Path.Combine(Path.GetDirectoryName(path), locale.Directory);
            if (Directory.Exists(stringFileDirectory) == false)
                throw new CalligraphyException($"String file directory {locale.Directory} not found.");

            foreach (string stringFilePath in Directory.GetFiles(stringFileDirectory, "*.string"))
            {
                using FileStream stringStream = File.OpenRead(stringFilePath);
                locale.ImportStringStream(Path.GetFileName(stringFilePath), stringStream);
            }

            // Replace the locale only after everything is loaded as long as no exceptions are thrown
            CurrentLocale = locale;
        }
    }
}
