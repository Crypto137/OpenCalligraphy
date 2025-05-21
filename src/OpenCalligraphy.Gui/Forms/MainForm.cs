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

        private readonly Stack<PrototypeId> _prototypeBackStack = new();
        private readonly Stack<PrototypeId> _prototypeForwardStack = new();

        private readonly FileTree _searchFileTree = new("Calligraphy");

        private bool _updatingSettings;

        private bool _prototypeMetadataToggle;
        private bool _evalExpressionStringToggle;
        private bool _embedEmptyRHStructsToggle;

        public MainForm()
        {
            InitializeComponent();

            InitializeSettings();
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
                ClearOpenedFiles();
            }
        }

        private void InitializeGameDatabase(string filePath)
        {
            if (GameDatabase.Initialize(filePath) == false)
                return;

            Text = $"OpenCalligraphy - {filePath}";

            ClearFileSearchResults();
            ClearOpenedFiles();
            ClearPrototypeInspectHistory();
        }

        private void BuildFileTree()
        {
            // Initialize internal file tree
            _fileTree.Clear();

            List<string> fileList = new();
            foreach (PrototypeId prototypeId in DataDirectory.Instance.IteratePrototypes())
                fileList.Add(prototypeId.GetName());
            fileList.Sort();

            _fileTree.AddFileList(fileList);

            // Load initial TreeView data
            FileTreeHelper.InitializeFileTreeView(fileTreeView, _fileTree);

            fileTabControl.SelectedIndex = 0;
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

            // TODO: Other file types? (curves / asset types)
            string prototypeName = fileTreeNode.FilePath;
            if (prototypeName != null)
            {
                Prototype prototype = GameDatabase.GetPrototype(prototypeName);
                if (prototype != null)
                    InspectPrototype(prototype);
            }
        }

        private void ClearOpenedFiles()
        {
            InspectPrototype(null);
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

        private void SearchReferences(AssetId dataRef)
        {
            List<string> fileList = _dataRefIndex.GetReferencers(dataRef).Select(referencer => referencer.GetName()).ToList();
            SearchReferencesHelper(dataRef.GetName(), fileList);
        }

        private void SearchReferences(CurveId dataRef)
        {
            List<string> fileList = _dataRefIndex.GetReferencers(dataRef).Select(referencer => referencer.GetName()).ToList();
            SearchReferencesHelper(dataRef.GetName(), fileList);
        }

        private void SearchReferences(PrototypeId dataRef)
        {
            List<string> fileList = _dataRefIndex.GetReferencers(dataRef).Select(referencer => referencer.GetName()).ToList();
            SearchReferencesHelper(dataRef.GetName(), fileList);
        }

        private void SearchReferences(AssetTypeId dataRef)
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

            fileTabControl.SelectedIndex = 1;

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

        #region Prototype Inspector

        private void InspectPrototype(Prototype prototype, bool addToHistory = true)
        {
            // NOTE: null prototype is valid input here to clear the inspector

            if (addToHistory)
                AddPrototypeToInspectHistory(prototypeTreeView.Tag as Prototype);

            ClearPrototypeSearchResults();

            EnablePrototypeControls(prototype);

            SetPrototypeMetadata(prototype);

            PopulatePrototypeTreeView(prototype);
        }

        private void ReloadPrototype()
        {
            if (_updatingSettings)
                return;

            if (prototypeTreeView.Tag is Prototype prototype)
                InspectPrototype(prototype, false);
        }

        private void EnablePrototypeControls(Prototype prototype)
        {
            bool hasPrototype = prototype != null;

            prototypeInspectParentButton.Enabled = hasPrototype && prototype.ParentDataRef != PrototypeId.Invalid;
            prototypeFindReferencesButton.Enabled = hasPrototype;

            prototypeSearchClearButton.Enabled = hasPrototype;
            prototypeSearchTextBox.Enabled = hasPrototype;
            prototypeSearchButton.Enabled = hasPrototype;
        }

        private void SetPrototypeMetadata(Prototype prototype)
        {
            string name = string.Empty;
            string parent = string.Empty;
            string blueprint = string.Empty;
            string flags = string.Empty;
            string runtimeBinding = string.Empty;

            if (prototype != null)
            {
                PrototypeDataRefRecord dataRefRecord = DataDirectory.Instance.GetPrototypeDataRefRecord(prototype.DataRef);
                if (dataRefRecord != null)
                {
                    name = $"{dataRefRecord.PrototypeId.GetName()} (id={dataRefRecord.PrototypeId}, guid={dataRefRecord.PrototypeGuid})";

                    if (prototype.ParentDataRef != PrototypeId.Invalid)
                        parent = $"{prototype.ParentDataRef.GetName()} ({prototype.ParentDataRef})";

                    blueprint = $"{dataRefRecord.BlueprintId.GetName()} ({dataRefRecord.BlueprintId})";
                    flags = dataRefRecord.Flags.ToString();
                    runtimeBinding = dataRefRecord.RuntimeBinding;
                }
            }

            prototypeNameTextBox.Text = name;
            prototypeParentTextBox.Text = parent;
            prototypeBlueprintTextBox.Text = blueprint;
            prototypeFlagsTextBox.Text = flags;
            prototypeRuntimeBindingTextBox.Text = runtimeBinding;
        }

        private void PopulatePrototypeTreeView(Prototype prototype)
        {
            prototypeTreeView.BeginUpdate();
            prototypeTreeView.Nodes.Clear();

            TreeNode root = null;

            if (prototype != null)
            {
                root = prototypeTreeView.Nodes.Add(string.Empty);

                PrototypeTreeHelperFlags flags = PrototypeTreeHelperFlags.None;
                if (_evalExpressionStringToggle)
                    flags |= PrototypeTreeHelperFlags.UseEvalExpressionStrings;

                if (_embedEmptyRHStructsToggle)
                    flags |= PrototypeTreeHelperFlags.EmbedEmptyRHStructs;

                PrototypeTreeHelper.SetPrototype(root, prototype, prototype?.ToString(), flags);
                root.Expand();
            }

            prototypeTreeView.EndUpdate();

            prototypeTreeView.SelectedNode = root;
            prototypeTreeView.Tag = prototype;
        }

        #endregion

        #region Prototype Inspect History

        private void PrototypeGoBack()
        {
            if (_prototypeBackStack.Count == 0)
                return;

            if (prototypeTreeView.Tag is Prototype prototype)
                _prototypeForwardStack.Push(prototype.DataRef);

            PrototypeId previousProtoRef = _prototypeBackStack.Pop();
            Prototype previousProto = previousProtoRef.AsPrototype();
            InspectPrototype(previousProto, false);

            RefreshPrototypeInspectHistoryButtons();
        }

        private void PrototypeGoForward()
        {
            if (_prototypeForwardStack.Count == 0)
                return;

            if (prototypeTreeView.Tag is Prototype prototype)
                _prototypeBackStack.Push(prototype.DataRef);

            PrototypeId nextProtoRef = _prototypeForwardStack.Pop();
            Prototype nextProto = nextProtoRef.AsPrototype();
            InspectPrototype(nextProto, false);

            RefreshPrototypeInspectHistoryButtons();
        }

        private void AddPrototypeToInspectHistory(Prototype prototype)
        {
            if (prototype != null)
                _prototypeBackStack.Push(prototype.DataRef);

            _prototypeForwardStack.Clear();

            RefreshPrototypeInspectHistoryButtons();
        }

        private void ClearPrototypeInspectHistory()
        {
            _prototypeBackStack.Clear();
            _prototypeForwardStack.Clear();

            RefreshPrototypeInspectHistoryButtons();
        }

        private void RefreshPrototypeInspectHistoryButtons()
        {
            prototypeBackButton.Enabled = _prototypeBackStack.Count > 0;
            prototypeForwardButton.Enabled = _prototypeForwardStack.Count > 0;
        }

        #endregion

        #region Prototype Search

        private void SearchInPrototype(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return;

            pattern = pattern.Trim();

            PrototypeTreeHelper.ClearTreeViewBackColor(prototypeTreeView);

            List<TreeNode> nodeList = new();
            PrototypeTreeHelper.SearchTreeView(prototypeTreeView, pattern, nodeList);

            prototypeTreeView.BeginUpdate();

            foreach (TreeNode treeNode in nodeList)
                PrototypeTreeHelper.ColorAndExpandTreeNode(treeNode, Color.Yellow);

            prototypeTreeView.EndUpdate();

            if (nodeList.Count > 0)
                prototypeTreeView.SelectedNode = nodeList[0];

            MessageBox.Show($"Found {nodeList.Count} {(nodeList.Count == 1 ? "node" : "nodes")} containing '{pattern}'.",
                "Prototype Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearPrototypeSearchResults()
        {
            prototypeSearchTextBox.Text = string.Empty;
            PrototypeTreeHelper.ClearTreeViewBackColor(prototypeTreeView);
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
            ReloadPrototype();

            Locale locale = LocaleManager.Instance.CurrentLocale;
            MessageBox.Show($"Loaded locale '{locale.Name}' ({locale.Entries.Count} entries).", "Locale Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #endregion

        #region Settings

        private void InitializeSettings()
        {
            // TODO: Save settings
            _updatingSettings = true;

            SetPrototypeMetadataToggle(false);
            SetEvalExpressionStringToggle(true);
            SetEmbedEmptyRHStructsToggle(false);

            _updatingSettings = false;

            ReloadPrototype();
        }

        private void SetPrototypeMetadataToggle(bool value)
        {
            _prototypeMetadataToggle = value;

            prototypeBlueprintLabel.Visible = value;
            prototypeBlueprintTextBox.Visible = value;
            prototypeFlagsLabel.Visible = value;
            prototypeFlagsTextBox.Visible = value;
            prototypeRuntimeBindingLabel.Visible = value;
            prototypeRuntimeBindingTextBox.Visible = value;

            showAdditionalPrototypeMetadataToolStripMenuItem.Checked = value;
        }

        private void SetEvalExpressionStringToggle(bool value)
        {
            _evalExpressionStringToggle = value;
            showEvalExpressionStringsToolStripMenuItem.Checked = value;

            ReloadPrototype();
        }

        private void SetEmbedEmptyRHStructsToggle(bool value)
        {
            _embedEmptyRHStructsToggle = value;
            embedEmptyRHStructsToolStripMenuItem.Checked = value;

            ReloadPrototype();
        }

        #endregion

        #region Event Handlers

        #region ToolStrip Events

        private void openPakFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPakFile();
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
            SetPrototypeMetadataToggle(_prototypeMetadataToggle == false);
        }

        private void showEvalExpressionStringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEvalExpressionStringToggle(_evalExpressionStringToggle == false);
        }

        private void embedEmptyRHStructsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEmbedEmptyRHStructsToggle(_embedEmptyRHStructsToggle == false);
        }

        private void loadLocaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLocale();
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

        #region Prototype Events

        private void prototypeBackButton_Click(object sender, EventArgs e)
        {
            PrototypeGoBack();
        }

        private void prototypeForwardButton_Click(object sender, EventArgs e)
        {
            PrototypeGoForward();
        }

        private void prototypeInspectParentButton_Click(object sender, EventArgs e)
        {
            if (prototypeTreeView.Tag is not Prototype prototype)
                return;

            if (prototype.ParentDataRef == PrototypeId.Invalid)
                return;

            InspectPrototype(prototype.ParentDataRef.AsPrototype());
        }

        private void prototypeFindReferencesButton_Click(object sender, EventArgs e)
        {
            if (prototypeTreeView.Tag is not Prototype prototype)
                return;

            SearchReferences(prototype.DataRef);
        }

        private void prototypeTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Show context menu on right click
            if (e.Button != MouseButtons.Right)
                return;

            if (e.Node.Tag is DataRefTreeNodeTag dataRefTag)
            {
                dataRefContextMenuStrip.Tag = dataRefTag;
                dataRefContextMenuStrip.Show(e.Node.TreeView, e.Location);
            }
            else if (e.Node.Tag is PrimitiveValueTreeNodeTag primitiveValueTag)
            {
                primitiveValueContextMenuStrip.Tag = primitiveValueTag;
                primitiveValueContextMenuStrip.Show(e.Node.TreeView, e.Location);
            }
        }

        private void prototypeTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Go to data ref on double left click
            if (e.Button != MouseButtons.Left)
                return;

            if (e.Node.Tag is not DataRefTreeNodeTag dataRefTag)
                return;

            object data = dataRefTag.GetData();
            switch (data)
            {
                case Prototype prototype:
                    InspectPrototype(prototype);
                    break;

                    // TODO: Add other inspectable types
            }
        }

        private void dataRefCopyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem)
                return;

            if (menuItem.Owner.Tag is not DataRefTreeNodeTag dataRefTag)
                return;

            Clipboard.SetText(dataRefTag.GetNameString());
        }

        private void dataRefCopyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem)
                return;

            if (menuItem.Owner.Tag is not DataRefTreeNodeTag dataRefTag)
                return;

            Clipboard.SetText(dataRefTag.GetValueString());
        }

        private void dataRefFindReferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem)
                return;

            if (menuItem.Owner.Tag is not DataRefTreeNodeTag dataRefTag)
                return;

            switch (dataRefTag.Type)
            {
                case CalligraphyBaseType.Asset:     SearchReferences((AssetId)dataRefTag.DataRef); break;
                case CalligraphyBaseType.Curve:     SearchReferences((CurveId)dataRefTag.DataRef); break;
                case CalligraphyBaseType.Prototype: SearchReferences((PrototypeId)dataRefTag.DataRef); break;
                case CalligraphyBaseType.Type:      SearchReferences((AssetTypeId)dataRefTag.DataRef); break;
            }
        }

        private void primitiveValueCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem)
                return;

            if (menuItem.Owner.Tag is not PrimitiveValueTreeNodeTag primitiveValueTag)
                return;

            Clipboard.SetText(primitiveValueTag.ToString());
        }

        private void prototypeSearchButton_Click(object sender, EventArgs e)
        {
            SearchInPrototype(prototypeSearchTextBox.Text);
        }

        private void prototypeSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchInPrototype(prototypeSearchTextBox.Text);
        }

        private void prototypeSearchClearButton_Click(object sender, EventArgs e)
        {
            ClearPrototypeSearchResults();
        }

        #endregion

        #endregion
    }
}
