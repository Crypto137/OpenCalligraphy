using OpenCalligraphy.Core.CodeGeneration;
using OpenCalligraphy.Core.FileSystem;
using OpenCalligraphy.Core.GameData;
using OpenCalligraphy.Core.GameData.Prototypes;
using OpenCalligraphy.Core.Locales;
using OpenCalligraphy.Gui.Helpers;
using OpenCalligraphy.Gui.Models;

namespace OpenCalligraphy.Gui.Forms
{
    public partial class MainForm : Form
    {
        private readonly FileTree _fileTree = new("Calligraphy");
        private readonly DataRefIndex _dataRefIndex = new();

        private readonly FileTree _searchFileTree = new("Calligraphy");

        public SettingsManager Settings { get; }

        public MainForm()
        {
            InitializeComponent();

            prototypeInspectorUserControl.MainForm = this;
            curveInspectorUserControl.MainForm = this;

            Settings = new(this);
            Settings.Initialize();
        }

        #region Data Logic

        private void OpenPakFile()
        {
            using OpenFileDialog dialog = new();
            dialog.FileName = "Calligraphy.sip";
            dialog.Filter = "Pak files (*.sip)|*.sip|All files (*.*)|*.*";
            dialog.Multiselect = false;

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            string filePath = dialog.FileName;

            bool actionResult = SlowActionForm.ExecuteActions(this,
                new("Loading...", "Initializing game database...", () => InitializeGameDatabase(filePath)),
                new("Loading...", "Initializing data ref index...", () => InitializeDataRefIndex(filePath)),
                new("Loading...", "Building file tree...", BuildFileTree));

            // Clean up if failed
            if (actionResult == false)
            {
                Text = "OpenCalligraphy";
                _fileTree.Clear();
                fileTreeView.Nodes.Clear();
                ClearInspectors();
            }
        }

        private void InitializeGameDatabase(string filePath)
        {
            if (GameDatabase.Initialize(filePath) == false)
                return;

            Text = $"OpenCalligraphy - {filePath}";

            ClearFileSearchResults();
            ClearInspectors();
        }

        private void BuildFileTree()
        {
            // Initialize internal file tree
            _fileTree.Clear();

            List<string> fileList = new();

            foreach (PrototypeId prototypeId in DataDirectory.Instance.IteratePrototypes())
                fileList.Add(prototypeId.GetName());

            foreach (CurveId curveId in CurveDirectory.Instance)
                fileList.Add(curveId.GetName());

            fileList.Sort();

            _fileTree.AddFileList(fileList);

            // Load initial TreeView data
            FileTreeHelper.InitializeFileTreeView(fileTreeView, _fileTree);

            fileTabControl.SelectedIndex = fileTabControl.TabPages.IndexOf(browseTabPage);
        }

        private void InitializeDataRefIndex(string filePath)
        {
            string cacheFilePath = $"{filePath}.index";

            // If we have a cached data ref index, load it and use it if the checksum matches our current data
            if (File.Exists(cacheFilePath))
            {
                try
                {
                    _dataRefIndex.LoadFromFile(cacheFilePath);

                    if (_dataRefIndex.Checksum == DataDirectory.Instance.DataChecksum)
                        return;
                }
                catch
                {
                    // If something goes wrong while loading, just let the index be rebuilt silently
                    // instead of aborting the entire game database initialization.
                }
            }

            // No file, the checksum does not match, or something else went wrong, so build a new index (slow)
            _dataRefIndex.Build();
            _dataRefIndex.SaveToFile(cacheFilePath);
        }

        private void ExportPrototypeClasses()
        {
            using SaveFileDialog dialog = new();
            dialog.FileName = "Prototypes.cs";
            dialog.Filter = "C# source file (*.cs)|*.cs|All files (*.*)|*.*";

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            string filePath = dialog.FileName;
            PrototypeClassGenerator.Generate(filePath);

            MessageBox.Show($"Exported prototype classes to '{filePath}'.", "Prototype Class Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportLocale()
        {
            using SaveFileDialog dialog = new();
            dialog.FileName = "Locale.json";
            dialog.Filter = "JSON file (*.json)|*.json|All files (*.*)|*.*";

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            string filePath = dialog.FileName;
            LocaleManager.Instance.CurrentLocale.ExportToJson(filePath);

            MessageBox.Show($"Exported locale to '{filePath}'.", "Locale Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TryOpenFile(TreeNode treeNode)
        {
            if (treeNode.Tag is not FileTreeNode fileTreeNode)
                return;

            if (fileTreeNode.IsFile == false)
                return;

            string filePath = fileTreeNode.FilePath;
            switch (Path.GetExtension(filePath))
            {
                case ".prototype":
                case ".defaults":
                    OpenPrototype(GameDatabase.GetPrototype(filePath));
                    break;

                case ".curve":
                    OpenCurve(GameDatabase.GetCurve(filePath));
                    break;
            }
        }

        internal void OpenDataRefTag(DataRefTreeNodeTag dataRefTag)
        {
            object data = dataRefTag.GetData();
            switch (data)
            {
                case Prototype prototype:
                    OpenPrototype(prototype);
                    break;

                case Curve curve:
                    OpenCurve(curve);
                    break;
            }
        }

        private void OpenPrototype(Prototype prototype)
        {
            if (prototype == null)
                return;

            inspectorTabControl.SelectedIndex = inspectorTabControl.TabPages.IndexOf(prototypeTabPage);
            prototypeInspectorUserControl.InspectPrototype(prototype);
        }

        private void OpenCurve(Curve curve)
        {
            if (curve == null)
                return;

            inspectorTabControl.SelectedIndex = inspectorTabControl.TabPages.IndexOf(curveTabPage);
            curveInspectorUserControl.InspectCurve(curve);
        }

        private void ClearInspectors()
        {
            prototypeInspectorUserControl.Clear();
            curveInspectorUserControl.Clear();
        }

        #region File Search

        private void SearchByPattern(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return;

            pattern = pattern.Trim();

            if (ulong.TryParse(pattern, out ulong dataRef))
            {
                // If the search pattern is a data ref, return the exact thing the user is looking for.
                SearchByDataRef(dataRef);
                return;
            }

            List<string> fileList = new();

            foreach (PrototypeId protoRef in DataDirectory.Instance.IteratePrototypes())
            {
                string prototypeName = protoRef.GetName();
                if (prototypeName.Contains(pattern, StringComparison.OrdinalIgnoreCase) == false)
                    continue;

                fileList.Add(prototypeName);
            }

            foreach (CurveId curveRef in CurveDirectory.Instance)
            {
                string curveName = curveRef.GetName();
                if (curveName.Contains(pattern, StringComparison.OrdinalIgnoreCase) == false)
                    continue;

                fileList.Add(curveName);
            }

            BuildSearchFileTree(fileList);

            fileSearchTreeView.Nodes[0].Text = $"Search Results for '{pattern}':";
            MessageBox.Show($"Found {fileList.Count} {(fileList.Count == 1 ? "file" : "files")} containing '{pattern}'.",
                "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SearchByDataRef(ulong dataRef)
        {
            List<string> fileList = new();

            // Check if this is a prototype id
            string prototypeName = GameDatabase.GetPrototypeName((PrototypeId)dataRef);
            if (string.IsNullOrWhiteSpace(prototypeName) == false)
                fileList.Add(prototypeName);

            // If this is a locale string id, add all references to it
            foreach (PrototypeId referencer in _dataRefIndex.GetReferencers((LocaleStringId)dataRef))
                fileList.Add(referencer.GetName());

            BuildSearchFileTree(fileList);

            fileSearchTreeView.Nodes[0].Text = $"Search Results for '{dataRef}':";

            MessageBox.Show($"Found {fileList.Count} {(fileList.Count == 1 ? "file" : "files")} matching data ref '{dataRef}'.",
                "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SearchReferences(AssetId dataRef)
        {
            List<string> fileList = _dataRefIndex.GetReferencers(dataRef).Select(referencer => referencer.GetName()).ToList();
            SearchReferencesHelper(dataRef.GetName(), fileList);
        }

        public void SearchReferences(CurveId dataRef)
        {
            List<string> fileList = _dataRefIndex.GetReferencers(dataRef).Select(referencer => referencer.GetName()).ToList();
            SearchReferencesHelper(dataRef.GetName(), fileList);
        }

        public void SearchReferences(PrototypeId dataRef)
        {
            List<string> fileList = _dataRefIndex.GetReferencers(dataRef).Select(referencer => referencer.GetName()).ToList();
            SearchReferencesHelper(dataRef.GetName(), fileList);
        }

        public void SearchReferences(AssetTypeId dataRef)
        {
            List<string> fileList = _dataRefIndex.GetReferencers(dataRef).Select(referencer => referencer.GetName()).ToList();
            SearchReferencesHelper(dataRef.GetName(), fileList);
        }

        private void SearchReferencesHelper(string dataRefName, List<string> fileList)
        {
            BuildSearchFileTree(fileList);

            fileSearchTreeView.Nodes[0].Text = $"Referencers of '{dataRefName}':";
            MessageBox.Show($"Found {fileList.Count} {(fileList.Count == 1 ? "prototype" : "prototypes")} referencing '{dataRefName}'.",
                "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuildSearchFileTree(List<string> fileList)
        {
            const int MaxAutoExpandSearchResults = 100;

            fileList.Sort();

            _searchFileTree.Clear();
            _searchFileTree.AddFileList(fileList);

            FileTreeHelper.InitializeFileTreeView(fileSearchTreeView, _searchFileTree);

            fileTabControl.SelectedIndex = fileTabControl.TabPages.IndexOf(searchTabPage);

            if (fileList.Count <= MaxAutoExpandSearchResults)
                fileSearchTreeView.ExpandAll();

            fileSearchTreeView.SelectedNode = fileSearchTreeView.Nodes[0];
        }

        private void ClearFileSearchResults()
        {
            fileSearchTextBox.Text = string.Empty;
            fileSearchTreeView.Nodes.Clear();
        }

        #endregion

        #region Locales

        private void LoadLocale()
        {
            using OpenFileDialog dialog = new();
            dialog.Filter = "Locale files (*.locale)|*.locale|All files (*.*)|*.*";
            dialog.Multiselect = false;

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
                return;

            string filePath = dialog.FileName;

            bool actionResult = SlowActionForm.ExecuteActions(this,
                new SlowActionForm.ActionData("Loading...", "Initializing locale...", () => LocaleManager.Instance.LoadLocale(filePath)));

            if (actionResult == false)
                return;

            // Reload the current prototype if succesfully loaded
            prototypeInspectorUserControl.ReloadPrototype();

            Locale locale = LocaleManager.Instance.CurrentLocale;
            MessageBox.Show($"Loaded locale '{locale.Name}' ({locale.Entries.Count} entries).", "Locale Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #endregion

        #region Event Handlers

        #region ToolStrip Events

        private void openPakFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPakFile();
        }

        private void loadLocaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLocale();
        }

        private void exportCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curveInspectorUserControl.Export();
        }

        private void exportPrototypeClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportPrototypeClasses();
        }

        private void exportLocaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportLocale();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showAdditionalPrototypeMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.SetPrototypeMetadataToggle(Settings.PrototypeMetadataToggle == false);
        }

        private void showEvalExpressionStringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.SetEvalExpressionStringToggle(Settings.EvalExpressionStringToggle == false);
        }

        private void embedEmptyRHStructsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.SetEmbedEmptyRHStructsToggle(Settings.EmbedEmptyRHStructsToggle == false);
        }

        private void pakDiffUtilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PakDiffUtilityForm pakDiffUtilityForm = new();
            pakDiffUtilityForm.ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Show a separate About form as a modal dialog
#if DEBUG
            string buildConfig = "Debug";
#else
            string buildConfig = "Release";
#endif
            MessageBox.Show($"OpenCalligraphy\n\nVersion 0.2.0 ({buildConfig})\n\nCopyright © 2025 Crypto137", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region File Events

        private void fileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            FileTreeHelper.TryLoadFileTreeNode(e.Node);
        }

        private void fileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TryOpenFile(e.Node);
        }

        private void fileSearchButton_Click(object sender, EventArgs e)
        {
            SearchByPattern(fileSearchTextBox.Text);
        }

        private void fileSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchByPattern(fileSearchTextBox.Text);
        }

        private void fileSearchClearButton_Click(object sender, EventArgs e)
        {
            ClearFileSearchResults();
        }

        private void fileSearchTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            FileTreeHelper.TryLoadFileTreeNode(e.Node);
        }

        private void fileSearchTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TryOpenFile(e.Node);
        }

        #endregion

        #endregion

        public class SettingsManager
        {
            // NOTE: This is nested in MainForm to give it access to MainForm's private fields
            private readonly MainForm _mainForm;

            private bool _fullUpdate = false;

            public bool PrototypeMetadataToggle { get; private set; }
            public bool EvalExpressionStringToggle { get; private set; }
            public bool EmbedEmptyRHStructsToggle { get; private set; }

            public SettingsManager(MainForm mainForm)
            {
                _mainForm = mainForm;
            }

            public void Initialize()
            {
                _fullUpdate = true;   // Disable certain features (e.g. prototype reloading) when we do a full update

                // PrototypeMetadataToggle
                if (ConfigurationHelper.Read(Settings.PrototypeMetadataToggle, out bool prototypeMetadataToggle) == false)
                    prototypeMetadataToggle = false;
                SetPrototypeMetadataToggle(prototypeMetadataToggle);

                // EvalExpressionStringToggle
                if (ConfigurationHelper.Read(Settings.EvalExpressionStringToggle, out bool evalExpressionStringToggle) == false)
                    evalExpressionStringToggle = true;
                SetEvalExpressionStringToggle(evalExpressionStringToggle);

                // EmbedEmptyRHStructsToggle
                if (ConfigurationHelper.Read(Settings.EmbedEmptyRHStructsToggle, out bool embedEmptyRHStructsToggle) == false)
                    embedEmptyRHStructsToggle = false;
                SetEmbedEmptyRHStructsToggle(embedEmptyRHStructsToggle);

                _fullUpdate = false;

                _mainForm.prototypeInspectorUserControl.ReloadPrototype();
            }

            public void SetPrototypeMetadataToggle(bool value)
            {
                PrototypeMetadataToggle = value;
                ConfigurationHelper.Write(Settings.PrototypeMetadataToggle, value);

                _mainForm.showAdditionalPrototypeMetadataToolStripMenuItem.Checked = value;

                _mainForm.prototypeInspectorUserControl.ToggleMetadataVisibility(value);
            }

            public void SetEvalExpressionStringToggle(bool value)
            {
                EvalExpressionStringToggle = value;
                ConfigurationHelper.Write(Settings.EvalExpressionStringToggle, value);

                _mainForm.showEvalExpressionStringsToolStripMenuItem.Checked = value;

                if (_fullUpdate == false)
                    _mainForm.prototypeInspectorUserControl.ReloadPrototype();
            }

            public void SetEmbedEmptyRHStructsToggle(bool value)
            {
                EmbedEmptyRHStructsToggle = value;
                ConfigurationHelper.Write(Settings.EmbedEmptyRHStructsToggle, value);

                _mainForm.embedEmptyRHStructsToolStripMenuItem.Checked = value;

                if (_fullUpdate == false)
                    _mainForm.prototypeInspectorUserControl.ReloadPrototype();
            }

            private enum Settings
            {
                PrototypeMetadataToggle,
                EvalExpressionStringToggle,
                EmbedEmptyRHStructsToggle,
            }
        }
    }
}
