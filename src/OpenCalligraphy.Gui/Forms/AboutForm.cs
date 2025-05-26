using System.Reflection;

namespace OpenCalligraphy.Gui.Forms
{
    public partial class AboutForm : Form
    {
#if DEBUG
        private const string BuildConfig = "Debug";
#else
        private const string BuildConfig = "Release";
#endif

        public AboutForm()
        {
            InitializeComponent();

            SetVersionInfo();
        }

        private void SetVersionInfo()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            versionLabel.Text = $"Version {version?.ToString(3)} ({BuildConfig})";
        }

        #region Event Handlers

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(websiteLinkLabel.Text);
            MessageBox.Show("Link copied to clipboard.", "OpenCalligraphy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
