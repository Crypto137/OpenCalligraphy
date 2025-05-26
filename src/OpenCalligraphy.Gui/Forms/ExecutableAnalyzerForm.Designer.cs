namespace OpenCalligraphy.Gui.Forms
{
    partial class ExecutableAnalyzerForm
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
            executableAnalyzerPanel = new Panel();
            sourceFileGroupBox = new GroupBox();
            sourceFileTreeView = new TreeView();
            sourceFileTableLayoutPanel = new TableLayoutPanel();
            saveSourceFileListButton = new Button();
            metadataGroupBox = new GroupBox();
            metadataTableLayoutPanel = new TableLayoutPanel();
            metadataFileNameLabel = new Label();
            metadataVersionLabel = new Label();
            metadataFileNameTextBox = new TextBox();
            metadataVersionTextBox = new TextBox();
            executableFileGroupBox = new GroupBox();
            executableFileTableLayoutPanel = new TableLayoutPanel();
            selectFileTextBox = new TextBox();
            executableFileBrowseButton = new Button();
            cancelButton = new Button();
            analyzeButton = new Button();
            executableAnalyzerPanel.SuspendLayout();
            sourceFileGroupBox.SuspendLayout();
            sourceFileTableLayoutPanel.SuspendLayout();
            metadataGroupBox.SuspendLayout();
            metadataTableLayoutPanel.SuspendLayout();
            executableFileGroupBox.SuspendLayout();
            executableFileTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // executableAnalyzerPanel
            // 
            executableAnalyzerPanel.Controls.Add(sourceFileGroupBox);
            executableAnalyzerPanel.Controls.Add(metadataGroupBox);
            executableAnalyzerPanel.Controls.Add(executableFileGroupBox);
            executableAnalyzerPanel.Dock = DockStyle.Fill;
            executableAnalyzerPanel.Location = new Point(0, 0);
            executableAnalyzerPanel.Name = "executableAnalyzerPanel";
            executableAnalyzerPanel.Padding = new Padding(16);
            executableAnalyzerPanel.Size = new Size(584, 761);
            executableAnalyzerPanel.TabIndex = 1;
            // 
            // sourceFileGroupBox
            // 
            sourceFileGroupBox.Controls.Add(sourceFileTreeView);
            sourceFileGroupBox.Controls.Add(sourceFileTableLayoutPanel);
            sourceFileGroupBox.Dock = DockStyle.Fill;
            sourceFileGroupBox.Enabled = false;
            sourceFileGroupBox.Location = new Point(16, 176);
            sourceFileGroupBox.Name = "sourceFileGroupBox";
            sourceFileGroupBox.Size = new Size(552, 569);
            sourceFileGroupBox.TabIndex = 4;
            sourceFileGroupBox.TabStop = false;
            sourceFileGroupBox.Text = "Source Files";
            // 
            // sourceFileTreeView
            // 
            sourceFileTreeView.Dock = DockStyle.Fill;
            sourceFileTreeView.Location = new Point(3, 19);
            sourceFileTreeView.Name = "sourceFileTreeView";
            sourceFileTreeView.Size = new Size(546, 518);
            sourceFileTreeView.TabIndex = 2;
            sourceFileTreeView.BeforeExpand += sourceFileTreeView_BeforeExpand;
            // 
            // sourceFileTableLayoutPanel
            // 
            sourceFileTableLayoutPanel.AutoSize = true;
            sourceFileTableLayoutPanel.ColumnCount = 2;
            sourceFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sourceFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            sourceFileTableLayoutPanel.Controls.Add(saveSourceFileListButton, 1, 0);
            sourceFileTableLayoutPanel.Dock = DockStyle.Bottom;
            sourceFileTableLayoutPanel.Location = new Point(3, 537);
            sourceFileTableLayoutPanel.Name = "sourceFileTableLayoutPanel";
            sourceFileTableLayoutPanel.RowCount = 1;
            sourceFileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sourceFileTableLayoutPanel.Size = new Size(546, 29);
            sourceFileTableLayoutPanel.TabIndex = 3;
            // 
            // saveSourceFileListButton
            // 
            saveSourceFileListButton.Location = new Point(469, 3);
            saveSourceFileListButton.Name = "saveSourceFileListButton";
            saveSourceFileListButton.Size = new Size(74, 23);
            saveSourceFileListButton.TabIndex = 0;
            saveSourceFileListButton.Text = "Save List...";
            saveSourceFileListButton.UseVisualStyleBackColor = true;
            saveSourceFileListButton.Click += saveSourceFileListButton_Click;
            // 
            // metadataGroupBox
            // 
            metadataGroupBox.AutoSize = true;
            metadataGroupBox.Controls.Add(metadataTableLayoutPanel);
            metadataGroupBox.Dock = DockStyle.Top;
            metadataGroupBox.Enabled = false;
            metadataGroupBox.Location = new Point(16, 96);
            metadataGroupBox.Name = "metadataGroupBox";
            metadataGroupBox.Size = new Size(552, 80);
            metadataGroupBox.TabIndex = 3;
            metadataGroupBox.TabStop = false;
            metadataGroupBox.Text = "Metadata";
            // 
            // metadataTableLayoutPanel
            // 
            metadataTableLayoutPanel.AutoSize = true;
            metadataTableLayoutPanel.ColumnCount = 2;
            metadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            metadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            metadataTableLayoutPanel.Controls.Add(metadataFileNameLabel, 0, 0);
            metadataTableLayoutPanel.Controls.Add(metadataVersionLabel, 0, 1);
            metadataTableLayoutPanel.Controls.Add(metadataFileNameTextBox, 1, 0);
            metadataTableLayoutPanel.Controls.Add(metadataVersionTextBox, 1, 1);
            metadataTableLayoutPanel.Dock = DockStyle.Fill;
            metadataTableLayoutPanel.Location = new Point(3, 19);
            metadataTableLayoutPanel.Name = "metadataTableLayoutPanel";
            metadataTableLayoutPanel.RowCount = 2;
            metadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            metadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            metadataTableLayoutPanel.Size = new Size(546, 58);
            metadataTableLayoutPanel.TabIndex = 0;
            // 
            // metadataFileNameLabel
            // 
            metadataFileNameLabel.Anchor = AnchorStyles.Right;
            metadataFileNameLabel.AutoSize = true;
            metadataFileNameLabel.Location = new Point(14, 7);
            metadataFileNameLabel.Name = "metadataFileNameLabel";
            metadataFileNameLabel.Size = new Size(63, 15);
            metadataFileNameLabel.TabIndex = 0;
            metadataFileNameLabel.Text = "File Name:";
            // 
            // metadataVersionLabel
            // 
            metadataVersionLabel.Anchor = AnchorStyles.Right;
            metadataVersionLabel.AutoSize = true;
            metadataVersionLabel.Location = new Point(29, 36);
            metadataVersionLabel.Name = "metadataVersionLabel";
            metadataVersionLabel.Size = new Size(48, 15);
            metadataVersionLabel.TabIndex = 1;
            metadataVersionLabel.Text = "Version:";
            // 
            // metadataFileNameTextBox
            // 
            metadataFileNameTextBox.Dock = DockStyle.Fill;
            metadataFileNameTextBox.Location = new Point(83, 3);
            metadataFileNameTextBox.Name = "metadataFileNameTextBox";
            metadataFileNameTextBox.ReadOnly = true;
            metadataFileNameTextBox.Size = new Size(460, 23);
            metadataFileNameTextBox.TabIndex = 3;
            // 
            // metadataVersionTextBox
            // 
            metadataVersionTextBox.Dock = DockStyle.Fill;
            metadataVersionTextBox.Location = new Point(83, 32);
            metadataVersionTextBox.Name = "metadataVersionTextBox";
            metadataVersionTextBox.ReadOnly = true;
            metadataVersionTextBox.Size = new Size(460, 23);
            metadataVersionTextBox.TabIndex = 4;
            // 
            // executableFileGroupBox
            // 
            executableFileGroupBox.AutoSize = true;
            executableFileGroupBox.Controls.Add(executableFileTableLayoutPanel);
            executableFileGroupBox.Dock = DockStyle.Top;
            executableFileGroupBox.Location = new Point(16, 16);
            executableFileGroupBox.Name = "executableFileGroupBox";
            executableFileGroupBox.Size = new Size(552, 80);
            executableFileGroupBox.TabIndex = 1;
            executableFileGroupBox.TabStop = false;
            executableFileGroupBox.Text = "Executable File";
            // 
            // executableFileTableLayoutPanel
            // 
            executableFileTableLayoutPanel.AutoSize = true;
            executableFileTableLayoutPanel.ColumnCount = 3;
            executableFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            executableFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            executableFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            executableFileTableLayoutPanel.Controls.Add(selectFileTextBox, 0, 0);
            executableFileTableLayoutPanel.Controls.Add(executableFileBrowseButton, 2, 0);
            executableFileTableLayoutPanel.Controls.Add(cancelButton, 2, 1);
            executableFileTableLayoutPanel.Controls.Add(analyzeButton, 1, 1);
            executableFileTableLayoutPanel.Dock = DockStyle.Fill;
            executableFileTableLayoutPanel.Location = new Point(3, 19);
            executableFileTableLayoutPanel.Name = "executableFileTableLayoutPanel";
            executableFileTableLayoutPanel.RowCount = 2;
            executableFileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            executableFileTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            executableFileTableLayoutPanel.Size = new Size(546, 58);
            executableFileTableLayoutPanel.TabIndex = 0;
            // 
            // selectFileTextBox
            // 
            executableFileTableLayoutPanel.SetColumnSpan(selectFileTextBox, 2);
            selectFileTextBox.Dock = DockStyle.Fill;
            selectFileTextBox.Location = new Point(3, 3);
            selectFileTextBox.Name = "selectFileTextBox";
            selectFileTextBox.Size = new Size(460, 23);
            selectFileTextBox.TabIndex = 0;
            // 
            // executableFileBrowseButton
            // 
            executableFileBrowseButton.Location = new Point(469, 3);
            executableFileBrowseButton.Name = "executableFileBrowseButton";
            executableFileBrowseButton.Size = new Size(74, 23);
            executableFileBrowseButton.TabIndex = 2;
            executableFileBrowseButton.Text = "Browse...";
            executableFileBrowseButton.UseVisualStyleBackColor = true;
            executableFileBrowseButton.Click += selectFileBrowseButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(469, 32);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(74, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // analyzeButton
            // 
            analyzeButton.Location = new Point(389, 32);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(74, 23);
            analyzeButton.TabIndex = 4;
            analyzeButton.Text = "Analyze";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += analyzeButton_Click;
            // 
            // ExecutableAnalyzerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(584, 761);
            Controls.Add(executableAnalyzerPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExecutableAnalyzerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Executable Analyzer";
            executableAnalyzerPanel.ResumeLayout(false);
            executableAnalyzerPanel.PerformLayout();
            sourceFileGroupBox.ResumeLayout(false);
            sourceFileGroupBox.PerformLayout();
            sourceFileTableLayoutPanel.ResumeLayout(false);
            metadataGroupBox.ResumeLayout(false);
            metadataGroupBox.PerformLayout();
            metadataTableLayoutPanel.ResumeLayout(false);
            metadataTableLayoutPanel.PerformLayout();
            executableFileGroupBox.ResumeLayout(false);
            executableFileGroupBox.PerformLayout();
            executableFileTableLayoutPanel.ResumeLayout(false);
            executableFileTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel executableAnalyzerPanel;
        private GroupBox executableFileGroupBox;
        private TableLayoutPanel executableFileTableLayoutPanel;
        private TextBox selectFileTextBox;
        private Button executableFileBrowseButton;
        private Button cancelButton;
        private Button analyzeButton;
        private TreeView sourceFileTreeView;
        private GroupBox metadataGroupBox;
        private TableLayoutPanel metadataTableLayoutPanel;
        private Label metadataFileNameLabel;
        private Label metadataVersionLabel;
        private TextBox metadataFileNameTextBox;
        private GroupBox sourceFileGroupBox;
        private TextBox metadataVersionTextBox;
        private TableLayoutPanel sourceFileTableLayoutPanel;
        private Button saveSourceFileListButton;
    }
}