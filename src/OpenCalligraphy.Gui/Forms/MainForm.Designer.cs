namespace OpenCalligraphy.Gui.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openPakFileToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            exportPrototypeClassesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            prototypeToggleMetadataToolStripMenuItem = new ToolStripMenuItem();
            localeToolStripMenuItem = new ToolStripMenuItem();
            loadLocaleToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            fileTabControl = new TabControl();
            browseTabPage = new TabPage();
            fileTreeView = new TreeView();
            searchTabPage = new TabPage();
            searchPanel = new Panel();
            fileSearchTreeView = new TreeView();
            searchTableLayoutPanel = new TableLayoutPanel();
            fileSearchButton = new Button();
            fileSearchTextBox = new TextBox();
            fileSearchClearButton = new Button();
            inspectorTabControl = new TabControl();
            prototypeTabPage = new TabPage();
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
            dataRefContextMenuStrip = new ContextMenuStrip(components);
            dataRefCopyNameToolStripMenuItem = new ToolStripMenuItem();
            dataRefCopyValueToolStripMenuItem = new ToolStripMenuItem();
            dataRefFindReferencesToolStripMenuItem = new ToolStripMenuItem();
            primitiveValueContextMenuStrip = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            fileTabControl.SuspendLayout();
            browseTabPage.SuspendLayout();
            searchTabPage.SuspendLayout();
            searchPanel.SuspendLayout();
            searchTableLayoutPanel.SuspendLayout();
            inspectorTabControl.SuspendLayout();
            prototypeTabPage.SuspendLayout();
            prototypePanel.SuspendLayout();
            prototypeSearchTableLayoutPanel.SuspendLayout();
            prototypeMetadataGroupBox.SuspendLayout();
            prototypeMetadataTableLayoutPanel.SuspendLayout();
            prototypeButtonPanel.SuspendLayout();
            prototypeButtonTableLayoutPanel.SuspendLayout();
            dataRefContextMenuStrip.SuspendLayout();
            primitiveValueContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, localeToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openPakFileToolStripMenuItem, toolStripSeparator2, exportToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openPakFileToolStripMenuItem
            // 
            openPakFileToolStripMenuItem.Name = "openPakFileToolStripMenuItem";
            openPakFileToolStripMenuItem.Size = new Size(152, 22);
            openPakFileToolStripMenuItem.Text = "Open PakFile...";
            openPakFileToolStripMenuItem.Click += openPakFileToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(149, 6);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportPrototypeClassesToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(152, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // exportPrototypeClassesToolStripMenuItem
            // 
            exportPrototypeClassesToolStripMenuItem.Name = "exportPrototypeClassesToolStripMenuItem";
            exportPrototypeClassesToolStripMenuItem.Size = new Size(167, 22);
            exportPrototypeClassesToolStripMenuItem.Text = "Prototype Classes";
            exportPrototypeClassesToolStripMenuItem.Click += exportPrototypeClassesToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(152, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { prototypeToggleMetadataToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // prototypeToggleMetadataToolStripMenuItem
            // 
            prototypeToggleMetadataToolStripMenuItem.Name = "prototypeToggleMetadataToolStripMenuItem";
            prototypeToggleMetadataToolStripMenuItem.Size = new Size(269, 22);
            prototypeToggleMetadataToolStripMenuItem.Text = "Show Additional Prototype Metadata";
            prototypeToggleMetadataToolStripMenuItem.Click += prototypeToggleMetadataToolStripMenuItem_Click;
            // 
            // localeToolStripMenuItem
            // 
            localeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadLocaleToolStripMenuItem });
            localeToolStripMenuItem.Name = "localeToolStripMenuItem";
            localeToolStripMenuItem.Size = new Size(53, 20);
            localeToolStripMenuItem.Text = "Locale";
            // 
            // loadLocaleToolStripMenuItem
            // 
            loadLocaleToolStripMenuItem.Name = "loadLocaleToolStripMenuItem";
            loadLocaleToolStripMenuItem.Size = new Size(146, 22);
            loadLocaleToolStripMenuItem.Text = "Load Locale...";
            loadLocaleToolStripMenuItem.Click += loadLocaleToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(fileTabControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(inspectorTabControl);
            splitContainer1.Size = new Size(1264, 737);
            splitContainer1.SplitterDistance = 421;
            splitContainer1.TabIndex = 1;
            // 
            // fileTabControl
            // 
            fileTabControl.Controls.Add(browseTabPage);
            fileTabControl.Controls.Add(searchTabPage);
            fileTabControl.Dock = DockStyle.Fill;
            fileTabControl.Location = new Point(0, 0);
            fileTabControl.Name = "fileTabControl";
            fileTabControl.SelectedIndex = 0;
            fileTabControl.Size = new Size(421, 737);
            fileTabControl.TabIndex = 0;
            // 
            // browseTabPage
            // 
            browseTabPage.Controls.Add(fileTreeView);
            browseTabPage.Location = new Point(4, 24);
            browseTabPage.Name = "browseTabPage";
            browseTabPage.Padding = new Padding(3);
            browseTabPage.Size = new Size(413, 709);
            browseTabPage.TabIndex = 0;
            browseTabPage.Text = "Browse";
            browseTabPage.UseVisualStyleBackColor = true;
            // 
            // fileTreeView
            // 
            fileTreeView.Dock = DockStyle.Fill;
            fileTreeView.Location = new Point(3, 3);
            fileTreeView.Name = "fileTreeView";
            fileTreeView.Size = new Size(407, 703);
            fileTreeView.TabIndex = 0;
            fileTreeView.BeforeExpand += fileTreeView_BeforeExpand;
            fileTreeView.AfterSelect += fileTreeView_AfterSelect;
            // 
            // searchTabPage
            // 
            searchTabPage.Controls.Add(searchPanel);
            searchTabPage.Location = new Point(4, 24);
            searchTabPage.Name = "searchTabPage";
            searchTabPage.Padding = new Padding(3);
            searchTabPage.Size = new Size(413, 709);
            searchTabPage.TabIndex = 1;
            searchTabPage.Text = "Search";
            searchTabPage.UseVisualStyleBackColor = true;
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(fileSearchTreeView);
            searchPanel.Controls.Add(searchTableLayoutPanel);
            searchPanel.Dock = DockStyle.Fill;
            searchPanel.Location = new Point(3, 3);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(407, 703);
            searchPanel.TabIndex = 0;
            // 
            // fileSearchTreeView
            // 
            fileSearchTreeView.Dock = DockStyle.Fill;
            fileSearchTreeView.Location = new Point(0, 25);
            fileSearchTreeView.Name = "fileSearchTreeView";
            fileSearchTreeView.Size = new Size(407, 678);
            fileSearchTreeView.TabIndex = 1;
            fileSearchTreeView.BeforeExpand += fileSearchTreeView_BeforeExpand;
            fileSearchTreeView.AfterSelect += fileSearchTreeView_AfterSelect;
            // 
            // searchTableLayoutPanel
            // 
            searchTableLayoutPanel.AutoSize = true;
            searchTableLayoutPanel.ColumnCount = 3;
            searchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            searchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            searchTableLayoutPanel.Controls.Add(fileSearchButton, 2, 0);
            searchTableLayoutPanel.Controls.Add(fileSearchTextBox, 1, 0);
            searchTableLayoutPanel.Controls.Add(fileSearchClearButton, 0, 0);
            searchTableLayoutPanel.Dock = DockStyle.Top;
            searchTableLayoutPanel.Location = new Point(0, 0);
            searchTableLayoutPanel.Name = "searchTableLayoutPanel";
            searchTableLayoutPanel.RowCount = 1;
            searchTableLayoutPanel.RowStyles.Add(new RowStyle());
            searchTableLayoutPanel.Size = new Size(407, 25);
            searchTableLayoutPanel.TabIndex = 0;
            // 
            // fileSearchButton
            // 
            fileSearchButton.Anchor = AnchorStyles.Left;
            fileSearchButton.AutoSize = true;
            fileSearchButton.Location = new Point(355, 0);
            fileSearchButton.Margin = new Padding(0);
            fileSearchButton.Name = "fileSearchButton";
            fileSearchButton.Size = new Size(52, 25);
            fileSearchButton.TabIndex = 0;
            fileSearchButton.Text = "Search";
            fileSearchButton.UseVisualStyleBackColor = true;
            fileSearchButton.Click += fileSearchButton_Click;
            // 
            // fileSearchTextBox
            // 
            fileSearchTextBox.Dock = DockStyle.Fill;
            fileSearchTextBox.Location = new Point(26, 1);
            fileSearchTextBox.Margin = new Padding(1);
            fileSearchTextBox.Name = "fileSearchTextBox";
            fileSearchTextBox.Size = new Size(328, 23);
            fileSearchTextBox.TabIndex = 1;
            fileSearchTextBox.KeyDown += fileSearchTextBox_KeyDown;
            // 
            // fileSearchClearButton
            // 
            fileSearchClearButton.Location = new Point(0, 0);
            fileSearchClearButton.Margin = new Padding(0);
            fileSearchClearButton.Name = "fileSearchClearButton";
            fileSearchClearButton.Size = new Size(25, 25);
            fileSearchClearButton.TabIndex = 2;
            fileSearchClearButton.Text = "✖";
            fileSearchClearButton.UseVisualStyleBackColor = true;
            fileSearchClearButton.Click += fileSearchClearButton_Click;
            // 
            // inspectorTabControl
            // 
            inspectorTabControl.Controls.Add(prototypeTabPage);
            inspectorTabControl.Dock = DockStyle.Fill;
            inspectorTabControl.Location = new Point(0, 0);
            inspectorTabControl.Name = "inspectorTabControl";
            inspectorTabControl.SelectedIndex = 0;
            inspectorTabControl.Size = new Size(839, 737);
            inspectorTabControl.TabIndex = 0;
            // 
            // prototypeTabPage
            // 
            prototypeTabPage.Controls.Add(prototypePanel);
            prototypeTabPage.Location = new Point(4, 24);
            prototypeTabPage.Name = "prototypeTabPage";
            prototypeTabPage.Padding = new Padding(3);
            prototypeTabPage.Size = new Size(831, 709);
            prototypeTabPage.TabIndex = 0;
            prototypeTabPage.Text = "Prototype";
            prototypeTabPage.UseVisualStyleBackColor = true;
            // 
            // prototypePanel
            // 
            prototypePanel.Controls.Add(prototypeTreeView);
            prototypePanel.Controls.Add(prototypeSearchTableLayoutPanel);
            prototypePanel.Controls.Add(prototypeMetadataGroupBox);
            prototypePanel.Controls.Add(prototypeButtonPanel);
            prototypePanel.Dock = DockStyle.Fill;
            prototypePanel.Location = new Point(3, 3);
            prototypePanel.Name = "prototypePanel";
            prototypePanel.Size = new Size(825, 703);
            prototypePanel.TabIndex = 0;
            // 
            // prototypeTreeView
            // 
            prototypeTreeView.Dock = DockStyle.Fill;
            prototypeTreeView.Location = new Point(0, 202);
            prototypeTreeView.Name = "prototypeTreeView";
            prototypeTreeView.Size = new Size(825, 472);
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
            prototypeSearchTableLayoutPanel.Location = new Point(0, 674);
            prototypeSearchTableLayoutPanel.Name = "prototypeSearchTableLayoutPanel";
            prototypeSearchTableLayoutPanel.RowCount = 1;
            prototypeSearchTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            prototypeSearchTableLayoutPanel.Size = new Size(825, 29);
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
            prototypeSearchButton.Location = new Point(750, 2);
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
            prototypeSearchTextBox.Size = new Size(719, 23);
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
            prototypeMetadataGroupBox.Size = new Size(825, 171);
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
            prototypeMetadataTableLayoutPanel.Size = new Size(819, 149);
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
            prototypeFindReferencesButton.Location = new Point(702, 3);
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
            prototypeInspectParentButton.Location = new Point(702, 34);
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
            prototypeNameTextBox.Size = new Size(613, 23);
            prototypeNameTextBox.TabIndex = 2;
            // 
            // prototypeParentTextBox
            // 
            prototypeParentTextBox.Dock = DockStyle.Fill;
            prototypeParentTextBox.Location = new Point(83, 34);
            prototypeParentTextBox.Name = "prototypeParentTextBox";
            prototypeParentTextBox.ReadOnly = true;
            prototypeParentTextBox.Size = new Size(613, 23);
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
            prototypeBlueprintTextBox.Size = new Size(613, 23);
            prototypeBlueprintTextBox.TabIndex = 7;
            // 
            // prototypeFlagsTextBox
            // 
            prototypeFlagsTextBox.Dock = DockStyle.Fill;
            prototypeFlagsTextBox.Location = new Point(83, 94);
            prototypeFlagsTextBox.Name = "prototypeFlagsTextBox";
            prototypeFlagsTextBox.ReadOnly = true;
            prototypeFlagsTextBox.Size = new Size(613, 23);
            prototypeFlagsTextBox.TabIndex = 8;
            // 
            // prototypeRuntimeBindingTextBox
            // 
            prototypeRuntimeBindingTextBox.Dock = DockStyle.Fill;
            prototypeRuntimeBindingTextBox.Location = new Point(83, 123);
            prototypeRuntimeBindingTextBox.Name = "prototypeRuntimeBindingTextBox";
            prototypeRuntimeBindingTextBox.ReadOnly = true;
            prototypeRuntimeBindingTextBox.Size = new Size(613, 23);
            prototypeRuntimeBindingTextBox.TabIndex = 9;
            // 
            // prototypeButtonPanel
            // 
            prototypeButtonPanel.AutoSize = true;
            prototypeButtonPanel.Controls.Add(prototypeButtonTableLayoutPanel);
            prototypeButtonPanel.Dock = DockStyle.Top;
            prototypeButtonPanel.Location = new Point(0, 0);
            prototypeButtonPanel.Name = "prototypeButtonPanel";
            prototypeButtonPanel.Size = new Size(825, 31);
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
            prototypeButtonTableLayoutPanel.Size = new Size(825, 31);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 761);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpenCalligraphy";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            fileTabControl.ResumeLayout(false);
            browseTabPage.ResumeLayout(false);
            searchTabPage.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            searchTableLayoutPanel.ResumeLayout(false);
            searchTableLayoutPanel.PerformLayout();
            inspectorTabControl.ResumeLayout(false);
            prototypeTabPage.ResumeLayout(false);
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
            dataRefContextMenuStrip.ResumeLayout(false);
            primitiveValueContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem openPakFileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TabControl fileTabControl;
        private TabPage browseTabPage;
        private TabPage searchTabPage;
        private TabControl inspectorTabControl;
        private TabPage prototypeTabPage;
        private TreeView fileTreeView;
        private Panel prototypePanel;
        private TreeView prototypeTreeView;
        private GroupBox prototypeMetadataGroupBox;
        private TableLayoutPanel prototypeMetadataTableLayoutPanel;
        private Label prototypeNameLabel;
        private Label prototypeParentLabel;
        private TextBox prototypeNameTextBox;
        private TextBox prototypeParentTextBox;
        private Panel searchPanel;
        private TableLayoutPanel searchTableLayoutPanel;
        private Button fileSearchButton;
        private TextBox fileSearchTextBox;
        private TreeView fileSearchTreeView;
        private ContextMenuStrip dataRefContextMenuStrip;
        private ToolStripMenuItem dataRefCopyValueToolStripMenuItem;
        private ToolStripMenuItem dataRefCopyNameToolStripMenuItem;
        private Panel prototypeButtonPanel;
        private TableLayoutPanel prototypeButtonTableLayoutPanel;
        private Button prototypeBackButton;
        private Button prototypeForwardButton;
        private Button prototypeInspectParentButton;
        private Button prototypeFindReferencesButton;
        private Label prototypeBlueprintLabel;
        private Label prototypeFlagsLabel;
        private Label prototypeRuntimeBindingLabel;
        private TextBox prototypeBlueprintTextBox;
        private TextBox prototypeFlagsTextBox;
        private TextBox prototypeRuntimeBindingTextBox;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem prototypeToggleMetadataToolStripMenuItem;
        private Button fileSearchClearButton;
        private TableLayoutPanel prototypeSearchTableLayoutPanel;
        private Button prototypeSearchClearButton;
        private Button prototypeSearchButton;
        private TextBox prototypeSearchTextBox;
        private ToolStripMenuItem localeToolStripMenuItem;
        private ToolStripMenuItem loadLocaleToolStripMenuItem;
        private ContextMenuStrip primitiveValueContextMenuStrip;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem dataRefFindReferencesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exportPrototypeClassesToolStripMenuItem;
    }
}