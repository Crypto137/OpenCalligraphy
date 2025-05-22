using OpenCalligraphy.Core.GameData;
using OpenCalligraphy.Core.GameData.Prototypes;
using OpenCalligraphy.Gui.Forms;
using OpenCalligraphy.Gui.Helpers;
using OpenCalligraphy.Gui.Models;

namespace OpenCalligraphy.Gui.UserControls
{
    public partial class PrototypeInspectorUserControl : UserControl
    {
        private readonly Stack<PrototypeId> _prototypeBackStack = new();
        private readonly Stack<PrototypeId> _prototypeForwardStack = new();

        public MainForm MainForm { get; set; }

        public PrototypeInspectorUserControl()
        {
            InitializeComponent();
        }

        #region Prototype Inspector

        public void InspectPrototype(Prototype prototype, bool addToHistory = true)
        {
            // NOTE: null prototype is valid input here to clear the inspector

            if (addToHistory)
                AddPrototypeToInspectHistory(prototypeTreeView.Tag as Prototype);

            ClearPrototypeSearchResults();

            EnablePrototypeControls(prototype);

            SetPrototypeMetadata(prototype);

            PopulatePrototypeTreeView(prototype);
        }

        public void ReloadPrototype()
        {
            if (prototypeTreeView.Tag is Prototype prototype)
                InspectPrototype(prototype, false);
        }

        public void Clear()
        {
            ClearPrototypeInspectHistory();
        }

        public void ToggleMetadataVisibility(bool value)
        {
            prototypeBlueprintLabel.Visible = value;
            prototypeBlueprintTextBox.Visible = value;
            prototypeFlagsLabel.Visible = value;
            prototypeFlagsTextBox.Visible = value;
            prototypeRuntimeBindingLabel.Visible = value;
            prototypeRuntimeBindingTextBox.Visible = value;
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

                PrototypeTreeHelperFlags flags = BuildPrototypeTreeFlags();
                PrototypeTreeHelper.SetPrototype(root, prototype, prototype?.ToString(), flags);

                root.Expand();
            }

            prototypeTreeView.EndUpdate();

            prototypeTreeView.SelectedNode = root;
            prototypeTreeView.Tag = prototype;
        }

        private PrototypeTreeHelperFlags BuildPrototypeTreeFlags()
        {
            PrototypeTreeHelperFlags flags = PrototypeTreeHelperFlags.None;

            MainForm.SettingsManager settings = MainForm?.Settings;
            if (settings != null)
            {
                if (settings.EvalExpressionStringToggle)
                    flags |= PrototypeTreeHelperFlags.UseEvalExpressionStrings;

                if (settings.EmbedEmptyRHStructsToggle)
                    flags |= PrototypeTreeHelperFlags.EmbedEmptyRHStructs;
            }

            return flags;
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

        #region Event Handlers

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

            MainForm?.SearchReferences(prototype.DataRef);
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
                case CalligraphyBaseType.Asset:     MainForm?.SearchReferences((AssetId)dataRefTag.DataRef); break;
                case CalligraphyBaseType.Curve:     MainForm?.SearchReferences((CurveId)dataRefTag.DataRef); break;
                case CalligraphyBaseType.Prototype: MainForm?.SearchReferences((PrototypeId)dataRefTag.DataRef); break;
                case CalligraphyBaseType.Type:      MainForm?.SearchReferences((AssetTypeId)dataRefTag.DataRef); break;
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
    }
}
