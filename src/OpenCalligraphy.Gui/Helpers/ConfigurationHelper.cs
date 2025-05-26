using System.Configuration;

namespace OpenCalligraphy.Gui.Helpers
{
    /// <summary>
    /// Wrapper for <see cref="ConfigurationManager"/>.
    /// </summary>
    internal static class ConfigurationHelper
    {
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.configuration.configurationmanager?view=windowsdesktop-9.0

        #region string

        public static bool Read(string key, out string value)
        {
            value = ConfigurationManager.AppSettings[key];
            return value != null;
        }

        public static bool Read<T>(T key, out string value) where T : Enum
        {
            return Read(key.ToString(), out value);
        }

        public static void Write(string key, string value)
        {
            if (Read(key, out string currentValue) && currentValue == value)
                return;

            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

            if (settings[key] == null)
                settings.Add(key, value);
            else
                settings[key].Value = value;

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        public static void Write<T>(T key, string value) where T : Enum
        {
            Write(key.ToString(), value);
        }

        #endregion

        #region bool

        public static bool Read(string key, out bool value)
        {
            value = false;

            if (Read(key, out string stringValue) == false)
                return false;

            return bool.TryParse(stringValue, out value);
        }

        public static bool Read<T>(T key, out bool value) where T: Enum
        {
            return Read(key.ToString(), out value);
        }

        public static void Write(string key, bool value)
        {
            Write(key, value.ToString());
        }

        public static void Write<T>(T key, bool value) where T: Enum
        {
            Write(key.ToString(), value);
        }

        #endregion
    }
}
