namespace OpenCalligraphy.Gui.UserControls
{
    partial class PrototypeInspectorUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            prototypePanel = new Panel();
            prototypeTreeView = new TreeView();
            prototypeSearchTableLayoutPanel = new TableLayoutPanel();
            prototypeSearchClearButton = new Button();
            prototypeSearchButton = new Button();
            prototypeSearchTextBox = new TextBox();
            prototypeMetadataGroupBox = new GroupBox();
            prototypeMetadataTableLayoutPanel = new TableLayoutPanel();
            prototypeNameLabel = new Label();
            prototypeParentLabel = new Label();
            prototypeFindReferencesButton = new Button();
            prototypeInspectParentButton = new Button();
            prototypeNameTextBox = new TextBox();
            prototypeParentTextBox = new TextBox();
            prototypeBlueprintLabel = new Label();
            prototypeFlagsLabel = new Label();
            prototypeRuntimeBindingLabel = new Label();
            prototypeBlueprintTextBox = new TextBox();
            prototypeFlagsTextBox = new TextBox();
            prototypeRuntimeBindingTextBox = new TextBox();
            prototypeButtonPanel = new Panel();
            prototypeButtonTableLayoutPanel = new TableLayoutPanel();
            prototypeBackButton = new Button();
            prototypeForwardButton = new Button();
            primitiveValueContextMenuStrip = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            dataRefContextMenuStrip = new ContextMenuStrip(components);
            dataRefCopyNameToolStripMenuItem = new ToolStripMenuItem();
            dataRefCopyValueToolStripMenuItem = new ToolStripMenuItem();
            dataRefFindReferencesToolStripMenuItem = new ToolStripMenuItem();
            prototypePanel.SuspendLayout();
            prototypeSearchTableLayoutPanel.SuspendLayout();
            prototypeMetadataGroupBox.SuspendLayout();
            prototypeMetadataTableLayoutPanel.SuspendLayout();
            prototypeButtonPanel.SuspendLayout();
            prototypeButtonTableLayoutPanel.SuspendLayout();
            primitiveValueContextMenuStrip.SuspendLayout();
            dataRefContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // prototypePanel
            // 
            prototypePanel.Controls.Add(prototypeTreeView);
            prototypePanel.Controls.Add(prototypeSearchTableLayoutPanel);
            prototypePanel.Controls.Add(prototypeMetadataGroupBox);
            prototypePanel.Controls.Add(prototypeButtonPanel);
            prototypePanel.Dock = DockStyle.Fill;
            prototypePanel.Location = new Point(0, 0);
            prototypePanel.Name = "prototypePanel";
            prototypePanel.Size = new Size(800, 600);
            prototypePanel.TabIndex = 1;
            // 
            // prototypeTreeView
            // 
            prototypeTreeView.Dock = DockStyle.Fill;
            prototypeTreeView.Location = new Point(0, 202);
            prototypeTreeView.Name = "prototypeTreeView";
            prototypeTreeView.Size = new Size(800, 369);
            prototypeTreeView.TabIndex = 1;
            prototypeTreeView.NodeMouseClick += prototypeTreeView_NodeMouseClick;
            prototypeTreeView.NodeMouseDoubleClick += prototypeTreeView_NodeMouseDoubleClick;
            // 
            // prototypeSearchTableLayoutPanel
            // 
            prototypeSearchTableLayoutPanel.AutoSize = true;
            prototypeSearchTableLayoutPanel.ColumnCount = 3;
            prototypeSearchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            prototypeSearchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            prototypeSearchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            prototypeSearchTableLayoutPanel.Controls.Add(prototypeSearchClearButton, 0, 0);
            prototypeSearchTableLayoutPanel.Controls.Add(prototypeSearchButton, 2, 0);
            prototypeSearchTableLayoutPanel.Controls.Add(prototypeSearchTextBox, 1, 0);
            prototypeSearchTableLayoutPanel.Dock = DockStyle.Bottom;
            prototypeSearchTableLayoutPanel.Location = new Point(0, 571);
            prototypeSearchTableLayoutPanel.Name = "prototypeSearchTableLayoutPanel";
            prototypeSearchTableLayoutPanel.RowCount = 1;
            prototypeSearchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            prototypeSearchTableLayoutPanel.Size = new Size(800, 29);
            prototypeSearchTableLayoutPanel.TabIndex = 3;
            // 
            // prototypeSearchClearButton
            // 
            prototypeSearchClearButton.Anchor = AnchorStyles.Left;
            prototypeSearchClearButton.Enabled = false;
            prototypeSearchClearButton.Location = new Point(0, 2);
            prototypeSearchClearButton.Margin = new Padding(0);
            prototypeSearchClearButton.Name = "prototypeSearchClearButton";
            prototypeSearchClearButton.Size = new Size(25, 25);
            prototypeSearchClearButton.TabIndex = 0;
            prototypeSearchClearButton.Text = "✖";
            prototypeSearchClearButton.UseVisualStyleBackColor = true;
            prototypeSearchClearButton.Click += prototypeSearchClearButton_Click;
            // 
            // prototypeSearchButton
            // 
            prototypeSearchButton.Anchor = AnchorStyles.Left;
            prototypeSearchButton.Enabled = false;
            prototypeSearchButton.Location = new Point(725, 2);
            prototypeSearchButton.Margin = new Padding(0);
            prototypeSearchButton.Name = "prototypeSearchButton";
            prototypeSearchButton.Size = new Size(75, 25);
            prototypeSearchButton.TabIndex = 1;
            prototypeSearchButton.Text = "Search";
            prototypeSearchButton.UseVisualStyleBackColor = true;
            prototypeSearchButton.Click += prototypeSearchButton_Click;
            // 
            // prototypeSearchTextBox
            // 
            prototypeSearchTextBox.Dock = DockStyle.Fill;
            prototypeSearchTextBox.Enabled = false;
            prototypeSearchTextBox.Location = new Point(28, 3);
            prototypeSearchTextBox.Name = "prototypeSearchTextBox";
            prototypeSearchTextBox.Size = new Size(694, 23);
            prototypeSearchTextBox.TabIndex = 2;
            prototypeSearchTextBox.KeyDown += prototypeSearchTextBox_KeyDown;
            // 
            // prototypeMetadataGroupBox
            // 
            prototypeMetadataGroupBox.AutoSize = true;
            prototypeMetadataGroupBox.Controls.Add(prototypeMetadataTableLayoutPanel);
            prototypeMetadataGroupBox.Dock = DockStyle.Top;
            prototypeMetadataGroupBox.Location = new Point(0, 31);
            prototypeMetadataGroupBox.Name = "prototypeMetadataGroupBox";
            prototypeMetadataGroupBox.Size = new Size(800, 171);
            prototypeMetadataGroupBox.TabIndex = 0;
            prototypeMetadataGroupBox.TabStop = false;
            prototypeMetadataGroupBox.Text = "Metadata";
            // 
            // prototypeMetadataTableLayoutPanel
            // 
            prototypeMetadataTableLayoutPanel.AutoSize = true;
            prototypeMetadataTableLayoutPanel.ColumnCount = 3;
            prototypeMetadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            prototypeMetadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            prototypeMetadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeNameLabel, 0, 0);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeParentLabel, 0, 1);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeFindReferencesButton, 2, 0);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeInspectParentButton, 2, 1);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeNameTextBox, 1, 0);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeParentTextBox, 1, 1);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeBlueprintLabel, 0, 2);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeFlagsLabel, 0, 3);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeRuntimeBindingLabel, 0, 4);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeBlueprintTextBox, 1, 2);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeFlagsTextBox, 1, 3);
            prototypeMetadataTableLayoutPanel.Controls.Add(prototypeRuntimeBindingTextBox, 1, 4);
            prototypeMetadataTableLayoutPanel.Dock = DockStyle.Fill;
            prototypeMetadataTableLayoutPanel.Location = new Point(3, 19);
            prototypeMetadataTableLayoutPanel.Name = "prototypeMetadataTableLayoutPanel";
            prototypeMetadataTableLayoutPanel.RowCount = 5;
            prototypeMetadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            prototypeMetadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            prototypeMetadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            prototypeMetadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            prototypeMetadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            prototypeMetadataTableLayoutPanel.Size = new Size(794, 149);
            prototypeMetadataTableLayoutPanel.TabIndex = 0;
            // 
            // prototypeNameLabel
            // 
            prototypeNameLabel.Anchor = AnchorStyles.Right;
            prototypeNameLabel.AutoSize = true;
            prototypeNameLabel.Location = new Point(15, 8);
            prototypeNameLabel.Name = "prototypeNameLabel";
            prototypeNameLabel.Size = new Size(62, 15);
            prototypeNameLabel.TabIndex = 0;
            prototypeNameLabel.Text = "Prototype:";
            // 
            // prototypeParentLabel
            // 
            prototypeParentLabel.Anchor = AnchorStyles.Right;
            prototypeParentLabel.AutoSize = true;
            prototypeParentLabel.Location = new Point(33, 39);
            prototypeParentLabel.Name = "prototypeParentLabel";
            prototypeParentLabel.Size = new Size(44, 15);
            prototypeParentLabel.TabIndex = 1;
            prototypeParentLabel.Text = "Parent:";
            // 
            // prototypeFindReferencesButton
            // 
            prototypeFindReferencesButton.AutoSize = true;
            prototypeFindReferencesButton.Dock = DockStyle.Fill;
            prototypeFindReferencesButton.Enabled = false;
            prototypeFindReferencesButton.Location = new Point(677, 3);
            prototypeFindReferencesButton.Name = "prototypeFindReferencesButton";
            prototypeFindReferencesButton.Size = new Size(114, 25);
            prototypeFindReferencesButton.TabIndex = 3;
            prototypeFindReferencesButton.Text = "Find References";
            prototypeFindReferencesButton.UseVisualStyleBackColor = true;
            prototypeFindReferencesButton.Click += prototypeFindReferencesButton_Click;
            // 
            // prototypeInspectParentButton
            // 
            prototypeInspectParentButton.AutoSize = true;
            prototypeInspectParentButton.Dock = DockStyle.Fill;
            prototypeInspectParentButton.Enabled = false;
            prototypeInspectParentButton.Location = new Point(677, 34);
            prototypeInspectParentButton.Name = "prototypeInspectParentButton";
            prototypeInspectParentButton.Size = new Size(114, 25);
            prototypeInspectParentButton.TabIndex = 2;
            prototypeInspectParentButton.Text = "Inspect Parent";
            prototypeInspectParentButton.UseVisualStyleBackColor = true;
            prototypeInspectParentButton.Click += prototypeInspectParentButton_Click;
            // 
            // prototypeNameTextBox
            // 
            prototypeNameTextBox.Dock = DockStyle.Fill;
            prototypeNameTextBox.Location = new Point(83, 3);
            prototypeNameTextBox.Name = "prototypeNameTextBox";
            prototypeNameTextBox.ReadOnly = true;
            prototypeNameTextBox.Size = new Size(588, 23);
            prototypeNameTextBox.TabIndex = 2;
            // 
            // prototypeParentTextBox
            // 
            prototypeParentTextBox.Dock = DockStyle.Fill;
            prototypeParentTextBox.Location = new Point(83, 34);
            prototypeParentTextBox.Name = "prototypeParentTextBox";
            prototypeParentTextBox.ReadOnly = true;
            prototypeParentTextBox.Size = new Size(588, 23);
            prototypeParentTextBox.TabIndex = 3;
            // 
            // prototypeBlueprintLabel
            // 
            prototypeBlueprintLabel.Anchor = AnchorStyles.Right;
            prototypeBlueprintLabel.AutoSize = true;
            prototypeBlueprintLabel.Location = new Point(19, 69);
            prototypeBlueprintLabel.Name = "prototypeBlueprintLabel";
            prototypeBlueprintLabel.Size = new Size(58, 15);
            prototypeBlueprintLabel.TabIndex = 4;
            prototypeBlueprintLabel.Text = "Blueprint:";
            // 
            // prototypeFlagsLabel
            // 
            prototypeFlagsLabel.Anchor = AnchorStyles.Right;
            prototypeFlagsLabel.AutoSize = true;
            prototypeFlagsLabel.Location = new Point(40, 98);
            prototypeFlagsLabel.Name = "prototypeFlagsLabel";
            prototypeFlagsLabel.Size = new Size(37, 15);
            prototypeFlagsLabel.TabIndex = 5;
            prototypeFlagsLabel.Text = "Flags:";
            // 
            // prototypeRuntimeBindingLabel
            // 
            prototypeRuntimeBindingLabel.Anchor = AnchorStyles.Right;
            prototypeRuntimeBindingLabel.AutoSize = true;
            prototypeRuntimeBindingLabel.Location = new Point(40, 127);
            prototypeRuntimeBindingLabel.Name = "prototypeRuntimeBindingLabel";
            prototypeRuntimeBindingLabel.Size = new Size(37, 15);
            prototypeRuntimeBindingLabel.TabIndex = 6;
            prototypeRuntimeBindingLabel.Text = "Class:";
            // 
            // prototypeBlueprintTextBox
            // 
            prototypeBlueprintTextBox.Dock = DockStyle.Fill;
            prototypeBlueprintTextBox.Location = new Point(83, 65);
            prototypeBlueprintTextBox.Name = "prototypeBlueprintTextBox";
            prototypeBlueprintTextBox.ReadOnly = true;
            prototypeBlueprintTextBox.Size = new Size(588, 23);
            prototypeBlueprintTextBox.TabIndex = 7;
            // 
            // prototypeFlagsTextBox
            // 
            prototypeFlagsTextBox.Dock = DockStyle.Fill;
            prototypeFlagsTextBox.Location = new Point(83, 94);
            prototypeFlagsTextBox.Name = "prototypeFlagsTextBox";
            prototypeFlagsTextBox.ReadOnly = true;
            prototypeFlagsTextBox.Size = new Size(588, 23);
            prototypeFlagsTextBox.TabIndex = 8;
            // 
            // prototypeRuntimeBindingTextBox
            // 
            prototypeRuntimeBindingTextBox.Dock = DockStyle.Fill;
            prototypeRuntimeBindingTextBox.Location = new Point(83, 123);
            prototypeRuntimeBindingTextBox.Name = "prototypeRuntimeBindingTextBox";
            prototypeRuntimeBindingTextBox.ReadOnly = true;
            prototypeRuntimeBindingTextBox.Size = new Size(588, 23);
            prototypeRuntimeBindingTextBox.TabIndex = 9;
            // 
            // prototypeButtonPanel
            // 
            prototypeButtonPanel.AutoSize = true;
            prototypeButtonPanel.Controls.Add(prototypeButtonTableLayoutPanel);
            prototypeButtonPanel.Dock = DockStyle.Top;
            prototypeButtonPanel.Location = new Point(0, 0);
            prototypeButtonPanel.Name = "prototypeButtonPanel";
            prototypeButtonPanel.Size = new Size(800, 31);
            prototypeButtonPanel.TabIndex = 2;
            // 
            // prototypeButtonTableLayoutPanel
            // 
            prototypeButtonTableLayoutPanel.AutoSize = true;
            prototypeButtonTableLayoutPanel.ColumnCount = 3;
            prototypeButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            prototypeButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            prototypeButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            prototypeButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            prototypeButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            prototypeButtonTableLayoutPanel.Controls.Add(prototypeBackButton, 0, 0);
            prototypeButtonTableLayoutPanel.Controls.Add(prototypeForwardButton, 1, 0);
            prototypeButtonTableLayoutPanel.Dock = DockStyle.Fill;
            prototypeButtonTableLayoutPanel.Location = new Point(0, 0);
            prototypeButtonTableLayoutPanel.Name = "prototypeButtonTableLayoutPanel";
            prototypeButtonTableLayoutPanel.RowCount = 1;
            prototypeButtonTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            prototypeButtonTableLayoutPanel.Size = new Size(800, 31);
            prototypeButtonTableLayoutPanel.TabIndex = 0;
            // 
            // prototypeBackButton
            // 
            prototypeBackButton.AutoSize = true;
            prototypeBackButton.Enabled = false;
            prototypeBackButton.Location = new Point(3, 3);
            prototypeBackButton.Name = "prototypeBackButton";
            prototypeBackButton.Size = new Size(80, 25);
            prototypeBackButton.TabIndex = 0;
            prototypeBackButton.Text = "<< Back";
            prototypeBackButton.UseVisualStyleBackColor = true;
            prototypeBackButton.Click += prototypeBackButton_Click;
            // 
            // prototypeForwardButton
            // 
            prototypeForwardButton.AutoSize = true;
            prototypeForwardButton.Enabled = false;
            prototypeForwardButton.Font = new Font("Segoe UI", 9F);
            prototypeForwardButton.Location = new Point(89, 3);
            prototypeForwardButton.Name = "prototypeForwardButton";
            prototypeForwardButton.Size = new Size(80, 25);
            prototypeForwardButton.TabIndex = 1;
            prototypeForwardButton.Text = "Forward >>";
            prototypeForwardButton.UseVisualStyleBackColor = true;
            prototypeForwardButton.Click += prototypeForwardButton_Click;
            // 
            // primitiveValueContextMenuStrip
            // 
            primitiveValueContextMenuStrip.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem });
            primitiveValueContextMenuStrip.Name = "primitiveValueContextMenuStrip";
            primitiveValueContextMenuStrip.Size = new Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(102, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += primitiveValueCopyToolStripMenuItem_Click;
            // 
            // dataRefContextMenuStrip
            // 
            dataRefContextMenuStrip.Items.AddRange(new ToolStripItem[] { dataRefCopyNameToolStripMenuItem, dataRefCopyValueToolStripMenuItem, dataRefFindReferencesToolStripMenuItem });
            dataRefContextMenuStrip.Name = "prototypeFieldContextMenuStrip";
            dataRefContextMenuStrip.Size = new Size(158, 70);
            // 
            // dataRefCopyNameToolStripMenuItem
            // 
            dataRefCopyNameToolStripMenuItem.Name = "dataRefCopyNameToolStripMenuItem";
            dataRefCopyNameToolStripMenuItem.Size = new Size(157, 22);
            dataRefCopyNameToolStripMenuItem.Text = "Copy Name";
            dataRefCopyNameToolStripMenuItem.Click += dataRefCopyNameToolStripMenuItem_Click;
            // 
            // dataRefCopyValueToolStripMenuItem
            // 
            dataRefCopyValueToolStripMenuItem.Name = "dataRefCopyValueToolStripMenuItem";
            dataRefCopyValueToolStripMenuItem.Size = new Size(157, 22);
            dataRefCopyValueToolStripMenuItem.Text = "Copy Value";
            dataRefCopyValueToolStripMenuItem.Click += dataRefCopyValueToolStripMenuItem_Click;
            // 
            // dataRefFindReferencesToolStripMenuItem
            // 
            dataRefFindReferencesToolStripMenuItem.Name = "dataRefFindReferencesToolStripMenuItem";
            dataRefFindReferencesToolStripMenuItem.Size = new Size(157, 22);
            dataRefFindReferencesToolStripMenuItem.Text = "Find References";
            dataRefFindReferencesToolStripMenuItem.Click += dataRefFindReferencesToolStripMenuItem_Click;
            // 
            // PrototypeInspectorUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(prototypePanel);
            Name = "PrototypeInspectorUserControl";
            Size = new Size(800, 600);
            prototypePanel.ResumeLayout(false);
            prototypePanel.PerformLayout();
            prototypeSearchTableLayoutPanel.ResumeLayout(false);
            prototypeSearchTableLayoutPanel.PerformLayout();
            prototypeMetadataGroupBox.ResumeLayout(false);
            prototypeMetadataGroupBox.PerformLayout();
            prototypeMetadataTableLayoutPanel.ResumeLayout(false);
            prototypeMetadataTableLayoutPanel.PerformLayout();
            prototypeButtonPanel.ResumeLayout(false);
            prototypeButtonPanel.PerformLayout();
            prototypeButtonTableLayoutPanel.ResumeLayout(false);
            prototypeButtonTableLayoutPanel.PerformLayout();
            primitiveValueContextMenuStrip.ResumeLayout(false);
            dataRefContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel prototypePanel;
        private TreeView prototypeTreeView;
        private TableLayoutPanel prototypeSearchTableLayoutPanel;
        private Button prototypeSearchClearButton;
        private Button prototypeSearchButton;
        private TextBox prototypeSearchTextBox;
        private GroupBox prototypeMetadataGroupBox;
        private TableLayoutPanel prototypeMetadataTableLayoutPanel;
        private Label prototypeNameLabel;
        private Label prototypeParentLabel;
        private Button prototypeFindReferencesButton;
        private Button prototypeInspectParentButton;
        private TextBox prototypeNameTextBox;
        private TextBox prototypeParentTextBox;
        private Label prototypeBlueprintLabel;
        private Label prototypeFlagsLabel;
        private Label prototypeRuntimeBindingLabel;
        private TextBox prototypeBlueprintTextBox;
        private TextBox prototypeFlagsTextBox;
        private TextBox prototypeRuntimeBindingTextBox;
        private Panel prototypeButtonPanel;
        private TableLayoutPanel prototypeButtonTableLayoutPanel;
        private Button prototypeBackButton;
        private Button prototypeForwardButton;
        private ContextMenuStrip primitiveValueContextMenuStrip;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ContextMenuStrip dataRefContextMenuStrip;
        private ToolStripMenuItem dataRefCopyNameToolStripMenuItem;
        private ToolStripMenuItem dataRefCopyValueToolStripMenuItem;
        private ToolStripMenuItem dataRefFindReferencesToolStripMenuItem;
    }
}
