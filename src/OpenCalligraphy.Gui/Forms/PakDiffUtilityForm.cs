using OpenCalligraphy.Core.FileSystem;
using OpenCalligraphy.Core.Helpers;
using OpenCalligraphy.Gui.Helpers;
using System.Drawing;

namespace OpenCalligraphy.Gui.Forms
{
    public partial class PakDiffUtilityForm : Form
    {
        private static readonly Color AddedColor   = Color.FromArgb(217, 255, 217);
        private static readonly Color RemovedColor = Color.FromArgb(255, 215, 215);
        private static readonly Color ChangedColor = Color.FromArgb(231, 231, 152);

        private string _diffText = string.Empty;

        public PakDiffUtilityForm()
        {
            InitializeComponent();
        }

        private bool SelectPakFile(out string filePath)
        {
            filePath = string.Empty;

            using OpenFileDialog dialog = new();
            dialog.Filter = "Pak files (*.sip)|*.sip|All files (*.*)|*.*";
            dialog.Multiselect = false;

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return false;

            filePath = dialog.FileName;
            return true;
        }

        private void DoDiff()
        {
            string oldFilePath = oldPakFileTextBox.Text;
            string newFilePath = newPakFileTextBox.Text;
            StringBuilderTextWriter outputWriter = new();

            PakDiffUtility.Diff(oldFilePath, newFilePath, outputWriter);

            _diffText = outputWriter.ToString();
        }

        private void DisplayDiff()
        {
            diffDataGridView.Rows.Clear();

            foreach (string line in _diffText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                int i = diffDataGridView.Rows.Add(line);

                Color? color = line[0] switch
                {
                    PakDiffUtility.PrefixAdded   => AddedColor,
                    PakDiffUtility.PrefixRemoved => RemovedColor,
                    PakDiffUtility.PrefixChanged => ChangedColor,
                    _                            => null,
                };
                
                if (color != null)
                    diffDataGridView.Rows[i].Cells[0].Style.BackColor = color.Value;
            }
        }

        private void SaveDiff()
        {
            using SaveFileDialog dialog = new();
            dialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            string filePath = dialog.FileName;
            FileHelper.WriteTextFile(filePath, _diffText);

            MessageBox.Show($"Saved comparison to '{filePath}'.", "Pak Diff Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Handlers

        private void oldPakFileBrowseButton_Click(object sender, EventArgs e)
        {
            if (SelectPakFile(out string filePath))
                oldPakFileTextBox.Text = filePath;
        }

        private void newPakFileBrowseButton_Click(object sender, EventArgs e)
        {
            if (SelectPakFile(out string filePath))
                newPakFileTextBox.Text = filePath;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SlowActionForm.ExecuteActions(this,
                new("Comparing...", "Comparing files...",    () => DoDiff()),
                new("Comparing...", "Building data grid...", () => DisplayDiff()));
        }

        private void saveDiffButton_Click(object sender, EventArgs e)
        {
            SaveDiff();
        }

        #endregion
    }
}
