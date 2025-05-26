using OpenCalligraphy.Core.ExecutableAnalysis;
using OpenCalligraphy.Core.FileSystem;
using OpenCalligraphy.Core.Helpers;
using OpenCalligraphy.Gui.Helpers;
using System.Text;

namespace OpenCalligraphy.Gui.Forms
{
    public partial class ExecutableAnalyzerForm : Form
    {
        private readonly List<string> _sourceFileList = new();
        private readonly FileTree _sourceFileTree = new();

        private ExecutableFile _executableFile;

        public ExecutableAnalyzerForm()
        {
            InitializeComponent();
        }

        private void SelectFile()
        {
            using OpenFileDialog dialog = new();
            dialog.FileName = "MarvelGame.exe";
            dialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Multiselect = false;

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            selectFileTextBox.Text = dialog.FileName;
        }

        private void AnalyzeFile(string filePath, bool validate)
        {
            _executableFile = new(filePath, validate);

            _sourceFileList.Clear();
            _executableFile.ExtractSourceFileList(_sourceFileList);

            _sourceFileTree.Clear();
            _sourceFileTree.Root.Name = _executableFile.FileName;
            _sourceFileTree.AddFileList(_sourceFileList);
        }

        private void DisplayAnalysis()
        {
            metadataFileNameTextBox.Text = _executableFile.FileName;
            metadataVersionTextBox.Text = _executableFile?.GetVersionString();

            FileTreeHelper.InitializeFileTreeView(sourceFileTreeView, _sourceFileTree);

            metadataGroupBox.Enabled = true;
            sourceFileGroupBox.Enabled = true;
        }

        private void SaveSourceFileList()
        {
            using SaveFileDialog dialog = new();
            dialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            string filePath = dialog.FileName;
            string fileList = string.Join("\r\n", _sourceFileList);
            FileHelper.WriteTextFile(filePath, fileList);

            MessageBox.Show($"Saved source file list to '{filePath}'.", "Executable Analyzer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Event Handlers

        private void selectFileBrowseButton_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            SlowActionForm.ExecuteActions(this,
                new("Analyzing...", "Analyzing executable...", () => AnalyzeFile(selectFileTextBox.Text, true)),
                new("Analyzing...", "Outputting results...",   () => DisplayAnalysis()));
        }

        private void sourceFileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            FileTreeHelper.TryLoadFileTreeNode(e.Node);
        }

        private void saveSourceFileListButton_Click(object sender, EventArgs e)
        {
            SaveSourceFileList();
        }

        #endregion
    }
}
