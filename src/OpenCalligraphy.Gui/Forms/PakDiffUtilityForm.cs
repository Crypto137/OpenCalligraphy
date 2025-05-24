using System.Text;
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
    }

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

            // Toggle controls
            bool hasDiff = string.IsNullOrWhiteSpace(_diffText) == false;
            saveDiffButton.Enabled = hasDiff;
            saveFilteredButton.Enabled = hasDiff;
            filterGroupBox.Enabled = hasDiff;
        }

        private void DisplayDiff(bool applyFilter)
        {
            if (string.IsNullOrWhiteSpace(_diffText))
            {
                diffDataGridView.Enabled = false;
                diffDataGridView.Rows.Clear();
                diffDataGridView.Enabled = true;

                MessageBox.Show("No differences found in the specified pak files.", "Pak Diff Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filterPattern = default;
            DiffFlags filterFlags = default;

            if (applyFilter)
                GetFilterSettings(out filterPattern, out filterFlags);

            diffDataGridView.Enabled = false;
            diffDataGridView.Rows.Clear();

            foreach (string line in _diffText.Split("\r\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                Color? color = null;

                if (applyFilter && string.IsNullOrWhiteSpace(filterPattern) == false && line.Contains(filterPattern, StringComparison.OrdinalIgnoreCase) == false)
                    continue;

                switch (line[0])
                {
                    case PakDiffUtility.PrefixAdded:
                        if (applyFilter && filterFlags.HasFlag(DiffFlags.Added) == false)
                            continue;
                        color = AddedColor;
                        break;

                    case PakDiffUtility.PrefixRemoved:
                        if (applyFilter && filterFlags.HasFlag(DiffFlags.Removed) == false)
                            continue;
                        color = RemovedColor;
                        break;

                    case PakDiffUtility.PrefixChanged:
                        if (applyFilter && filterFlags.HasFlag(DiffFlags.Changed) == false)
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

        private void SaveDiff(bool applyFilter)
        {
            using SaveFileDialog dialog = new();
            dialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            string filePath = dialog.FileName;
            string diffText = applyFilter ? BuildFilteredDiff() : _diffText;
            FileHelper.WriteTextFile(filePath, diffText);

            MessageBox.Show($"Saved comparison to '{filePath}'.", "Pak Diff Utility", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(_diffText))
                return;

            SlowActionForm.ExecuteActions(this,
                new SlowActionForm.ActionData("Filtering...", "Applying filter...", () => DisplayDiff(true)));
        }

        private void GetFilterSettings(out string pattern, out DiffFlags flags)
        {
            pattern = filterTextBox.Text;

            flags = DiffFlags.None;

            if (filterAddedCheckBox.Checked)
                flags |= DiffFlags.Added;

            if (filterRemovedCheckBox.Checked)
                flags |= DiffFlags.Removed;

            if (filterChangedCheckBox.Checked)
                flags |= DiffFlags.Changed;
        }

        private void ClearFilterSettings()
        {
            filterTextBox.Text = string.Empty;
            filterAddedCheckBox.Checked = true;
            filterRemovedCheckBox.Checked = true;
            filterChangedCheckBox.Checked = true;
        }

        private string BuildFilteredDiff()
        {
            StringBuilder sb = new();

            for (int i = 0; i < diffDataGridView.Rows.Count; i++)
            {
                DataGridViewCellCollection cells = diffDataGridView.Rows[i].Cells;
                if (cells.Count == 0)
                    continue;

                if (cells[0].Value is not string line)
                    continue;

                sb.AppendLine(line);
            }

            return sb.ToString();
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

        private void filterButton_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            ClearFilterSettings();
            ApplyFilter();
        }

        private void filterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyFilter();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SlowActionForm.ExecuteActions(this,
                new("Comparing...", "Comparing files...",    () => DoDiff()),
                new("Comparing...", "Building data grid...", () => DisplayDiff(false)));
        }

        private void saveDiffButton_Click(object sender, EventArgs e)
        {
            SaveDiff(false);
        }

        private void saveFilteredButton_Click(object sender, EventArgs e)
        {
            SaveDiff(true);
        }

        #endregion
    }
}
