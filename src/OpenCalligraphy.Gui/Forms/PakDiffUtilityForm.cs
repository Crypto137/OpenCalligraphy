using OpenCalligraphy.Core.FileSystem;
using OpenCalligraphy.Core.Helpers;
using OpenCalligraphy.Gui.Helpers;

namespace OpenCalligraphy.Gui.Forms
{
    public enum DiffFlags
    {
        None    = 0,
        Added   = 1 << 0,
        Removed = 1 << 1,
        Changed = 1 << 2,
        All     = -1
    }

    public partial class PakDiffUtilityForm : Form
    {
        private static readonly Color AddedColor   = Color.FromArgb(217, 255, 217);
        private static readonly Color RemovedColor = Color.FromArgb(255, 215, 215);
        private static readonly Color ChangedColor = Color.FromArgb(231, 231, 152);

        private string _diffText = string.Empty;
        private DiffFlags _visibilityFlags = DiffFlags.All;

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
            diffDataGridView.Enabled = false;
            diffDataGridView.Rows.Clear();

            foreach (string line in _diffText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                Color? color = null;

                switch (line[0])
                {
                    case PakDiffUtility.PrefixAdded:
                        if (_visibilityFlags.HasFlag(DiffFlags.Added) == false)
                            continue;
                        color = AddedColor;
                        break;

                    case PakDiffUtility.PrefixRemoved:
                        if (_visibilityFlags.HasFlag(DiffFlags.Removed) == false)
                            continue;
                        color = RemovedColor;
                        break;

                    case PakDiffUtility.PrefixChanged:
                        if (_visibilityFlags.HasFlag(DiffFlags.Changed) == false)
                            continue;
                        color = ChangedColor;
                        break;
                }

                int i = diffDataGridView.Rows.Add(line);
                if (color != null)
                    diffDataGridView.Rows[i].DefaultCellStyle.BackColor = color.Value;
            }

            diffDataGridView.Enabled = true;
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

        private void SetVisibilityFlag(DiffFlags flag, bool value)
        {
            if (value)
                _visibilityFlags |= flag;
            else
                _visibilityFlags &= ~flag;

            if (string.IsNullOrWhiteSpace(_diffText) == false)
            {
                SlowActionForm.ExecuteActions(this,
                    new SlowActionForm.ActionData("Filtering...", "Building data grid...", () => DisplayDiff()));
            }
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

        private void filterAddedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibilityFlag(DiffFlags.Added, filterAddedCheckBox.Checked);
        }

        private void filterRemovedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibilityFlag(DiffFlags.Removed, filterRemovedCheckBox.Checked);
        }

        private void filterChangedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibilityFlag(DiffFlags.Changed, filterChangedCheckBox.Checked);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SlowActionForm.ExecuteActions(this,
                new("Comparing...", "Comparing files...",    () => DoDiff()),
                new("Filtering...", "Building data grid...", () => DisplayDiff()));
        }

        private void saveDiffButton_Click(object sender, EventArgs e)
        {
            SaveDiff();
        }

        #endregion
    }
}
