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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openPakFileToolStripMenuItem = new ToolStripMenuItem();
            loadLocaleToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            exportCurveToolStripMenuItem = new ToolStripMenuItem();
            exportPrototypeClassesToolStripMenuItem = new ToolStripMenuItem();
            exportLocaleToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            showAdditionalPrototypeMetadataToolStripMenuItem = new ToolStripMenuItem();
            showEvalExpressionStringsToolStripMenuItem = new ToolStripMenuItem();
            embedEmptyRHStructsToolStripMenuItem = new ToolStripMenuItem();
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
            prototypeInspectorUserControl = new OpenCalligraphy.Gui.UserControls.PrototypeInspectorUserControl();
            curveTabPage = new TabPage();
            curveInspectorUserControl = new OpenCalligraphy.Gui.UserControls.CurveInspectorUserControl();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            pakDiffUtilityToolStripMenuItem = new ToolStripMenuItem();
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
            curveTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openPakFileToolStripMenuItem, loadLocaleToolStripMenuItem, toolStripSeparator2, exportToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
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
            // loadLocaleToolStripMenuItem
            // 
            loadLocaleToolStripMenuItem.Name = "loadLocaleToolStripMenuItem";
            loadLocaleToolStripMenuItem.Size = new Size(152, 22);
            loadLocaleToolStripMenuItem.Text = "Load Locale...";
            loadLocaleToolStripMenuItem.Click += loadLocaleToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(149, 6);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportCurveToolStripMenuItem, exportPrototypeClassesToolStripMenuItem, exportLocaleToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(152, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // exportCurveToolStripMenuItem
            // 
            exportCurveToolStripMenuItem.Name = "exportCurveToolStripMenuItem";
            exportCurveToolStripMenuItem.Size = new Size(167, 22);
            exportCurveToolStripMenuItem.Text = "Curve";
            exportCurveToolStripMenuItem.Click += exportCurveToolStripMenuItem_Click;
            // 
            // exportPrototypeClassesToolStripMenuItem
            // 
            exportPrototypeClassesToolStripMenuItem.Name = "exportPrototypeClassesToolStripMenuItem";
            exportPrototypeClassesToolStripMenuItem.Size = new Size(167, 22);
            exportPrototypeClassesToolStripMenuItem.Text = "Prototype Classes";
            exportPrototypeClassesToolStripMenuItem.Click += exportPrototypeClassesToolStripMenuItem_Click;
            // 
            // exportLocaleToolStripMenuItem
            // 
            exportLocaleToolStripMenuItem.Name = "exportLocaleToolStripMenuItem";
            exportLocaleToolStripMenuItem.Size = new Size(167, 22);
            exportLocaleToolStripMenuItem.Text = "Locale";
            exportLocaleToolStripMenuItem.Click += exportLocaleToolStripMenuItem_Click;
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
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showAdditionalPrototypeMetadataToolStripMenuItem, showEvalExpressionStringsToolStripMenuItem, embedEmptyRHStructsToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // showAdditionalPrototypeMetadataToolStripMenuItem
            // 
            showAdditionalPrototypeMetadataToolStripMenuItem.Name = "showAdditionalPrototypeMetadataToolStripMenuItem";
            showAdditionalPrototypeMetadataToolStripMenuItem.Size = new Size(269, 22);
            showAdditionalPrototypeMetadataToolStripMenuItem.Text = "Show Additional Prototype Metadata";
            showAdditionalPrototypeMetadataToolStripMenuItem.Click += showAdditionalPrototypeMetadataToolStripMenuItem_Click;
            // 
            // showEvalExpressionStringsToolStripMenuItem
            // 
            showEvalExpressionStringsToolStripMenuItem.Name = "showEvalExpressionStringsToolStripMenuItem";
            showEvalExpressionStringsToolStripMenuItem.Size = new Size(269, 22);
            showEvalExpressionStringsToolStripMenuItem.Text = "Show Eval Expression Strings";
            showEvalExpressionStringsToolStripMenuItem.Click += showEvalExpressionStringsToolStripMenuItem_Click;
            // 
            // embedEmptyRHStructsToolStripMenuItem
            // 
            embedEmptyRHStructsToolStripMenuItem.Name = "embedEmptyRHStructsToolStripMenuItem";
            embedEmptyRHStructsToolStripMenuItem.Size = new Size(269, 22);
            embedEmptyRHStructsToolStripMenuItem.Text = "Embed Empty RHStructs";
            embedEmptyRHStructsToolStripMenuItem.Click += embedEmptyRHStructsToolStripMenuItem_Click;
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
            aboutToolStripMenuItem.Size = new Size(180, 22);
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
            inspectorTabControl.Controls.Add(curveTabPage);
            inspectorTabControl.Dock = DockStyle.Fill;
            inspectorTabControl.Location = new Point(0, 0);
            inspectorTabControl.Name = "inspectorTabControl";
            inspectorTabControl.SelectedIndex = 0;
            inspectorTabControl.Size = new Size(839, 737);
            inspectorTabControl.TabIndex = 0;
            // 
            // prototypeTabPage
            // 
            prototypeTabPage.Controls.Add(prototypeInspectorUserControl);
            prototypeTabPage.Location = new Point(4, 24);
            prototypeTabPage.Name = "prototypeTabPage";
            prototypeTabPage.Padding = new Padding(3);
            prototypeTabPage.Size = new Size(831, 709);
            prototypeTabPage.TabIndex = 0;
            prototypeTabPage.Text = "Prototype";
            prototypeTabPage.UseVisualStyleBackColor = true;
            // 
            // prototypeInspectorUserControl
            // 
            prototypeInspectorUserControl.Dock = DockStyle.Fill;
            prototypeInspectorUserControl.Location = new Point(3, 3);
            prototypeInspectorUserControl.MainForm = null;
            prototypeInspectorUserControl.Name = "prototypeInspectorUserControl";
            prototypeInspectorUserControl.Size = new Size(825, 703);
            prototypeInspectorUserControl.TabIndex = 0;
            // 
            // curveTabPage
            // 
            curveTabPage.Controls.Add(curveInspectorUserControl);
            curveTabPage.Location = new Point(4, 24);
            curveTabPage.Name = "curveTabPage";
            curveTabPage.Padding = new Padding(3);
            curveTabPage.Size = new Size(831, 709);
            curveTabPage.TabIndex = 1;
            curveTabPage.Text = "Curve";
            curveTabPage.UseVisualStyleBackColor = true;
            // 
            // curveInspectorUserControl
            // 
            curveInspectorUserControl.Dock = DockStyle.Fill;
            curveInspectorUserControl.Location = new Point(3, 3);
            curveInspectorUserControl.MainForm = null;
            curveInspectorUserControl.Name = "curveInspectorUserControl";
            curveInspectorUserControl.Size = new Size(825, 703);
            curveInspectorUserControl.TabIndex = 0;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pakDiffUtilityToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // pakDiffUtilityToolStripMenuItem
            // 
            pakDiffUtilityToolStripMenuItem.Name = "pakDiffUtilityToolStripMenuItem";
            pakDiffUtilityToolStripMenuItem.Size = new Size(180, 22);
            pakDiffUtilityToolStripMenuItem.Text = "Pak Diff Utility";
            pakDiffUtilityToolStripMenuItem.Click += pakDiffUtilityToolStripMenuItem_Click;
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
            curveTabPage.ResumeLayout(false);
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
        private Panel searchPanel;
        private TableLayoutPanel searchTableLayoutPanel;
        private Button fileSearchButton;
        private TextBox fileSearchTextBox;
        private TreeView fileSearchTreeView;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem showAdditionalPrototypeMetadataToolStripMenuItem;
        private Button fileSearchClearButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exportPrototypeClassesToolStripMenuItem;
        private ToolStripMenuItem exportLocaleToolStripMenuItem;
        private ToolStripMenuItem showEvalExpressionStringsToolStripMenuItem;
        private ToolStripMenuItem embedEmptyRHStructsToolStripMenuItem;
        private UserControls.PrototypeInspectorUserControl prototypeInspectorUserControl;
        private TabPage curveTabPage;
        private UserControls.CurveInspectorUserControl curveInspectorUserControl;
        private ToolStripMenuItem exportCurveToolStripMenuItem;
        private ToolStripMenuItem loadLocaleToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem pakDiffUtilityToolStripMenuItem;
    }
}