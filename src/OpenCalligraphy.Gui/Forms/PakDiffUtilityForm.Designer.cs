namespace OpenCalligraphy.Gui.Forms
{
    partial class PakDiffUtilityForm
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
            pakDiffUtilityPanel = new Panel();
            diffListView = new ListView();
            buttonTableLayoutPanel = new TableLayoutPanel();
            saveDiffButton = new Button();
            okButton = new Button();
            cancelButton = new Button();
            pakFileGroupBox = new GroupBox();
            pakFileTableLayoutPanel = new TableLayoutPanel();
            oldPakFileLabel = new Label();
            newPakFileLabel = new Label();
            oldPakFileTextBox = new TextBox();
            newPakFileTextBox = new TextBox();
            oldPakFileBrowseButton = new Button();
            newPakFileBrowseButton = new Button();
            pakDiffUtilityPanel.SuspendLayout();
            buttonTableLayoutPanel.SuspendLayout();
            pakFileGroupBox.SuspendLayout();
            pakFileTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pakDiffUtilityPanel
            // 
            pakDiffUtilityPanel.Controls.Add(diffListView);
            pakDiffUtilityPanel.Controls.Add(buttonTableLayoutPanel);
            pakDiffUtilityPanel.Controls.Add(pakFileGroupBox);
            pakDiffUtilityPanel.Dock = DockStyle.Fill;
            pakDiffUtilityPanel.Location = new Point(0, 0);
            pakDiffUtilityPanel.Name = "pakDiffUtilityPanel";
            pakDiffUtilityPanel.Padding = new Padding(16);
            pakDiffUtilityPanel.Size = new Size(624, 601);
            pakDiffUtilityPanel.TabIndex = 0;
            // 
            // diffListView
            // 
            diffListView.Dock = DockStyle.Fill;
            diffListView.Location = new Point(16, 96);
            diffListView.Name = "diffListView";
            diffListView.Size = new Size(592, 460);
            diffListView.TabIndex = 5;
            diffListView.UseCompatibleStateImageBehavior = false;
            // 
            // buttonTableLayoutPanel
            // 
            buttonTableLayoutPanel.AutoSize = true;
            buttonTableLayoutPanel.ColumnCount = 4;
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            buttonTableLayoutPanel.Controls.Add(saveDiffButton, 0, 0);
            buttonTableLayoutPanel.Controls.Add(okButton, 2, 0);
            buttonTableLayoutPanel.Controls.Add(cancelButton, 3, 0);
            buttonTableLayoutPanel.Dock = DockStyle.Bottom;
            buttonTableLayoutPanel.Location = new Point(16, 556);
            buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
            buttonTableLayoutPanel.RowCount = 1;
            buttonTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            buttonTableLayoutPanel.Size = new Size(592, 29);
            buttonTableLayoutPanel.TabIndex = 4;
            // 
            // saveDiffButton
            // 
            saveDiffButton.Dock = DockStyle.Fill;
            saveDiffButton.Location = new Point(3, 3);
            saveDiffButton.Name = "saveDiffButton";
            saveDiffButton.Size = new Size(74, 23);
            saveDiffButton.TabIndex = 0;
            saveDiffButton.Text = "Save";
            saveDiffButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Dock = DockStyle.Fill;
            okButton.Location = new Point(435, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(74, 23);
            okButton.TabIndex = 1;
            okButton.Text = "Compare";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.Location = new Point(515, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(74, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // pakFileGroupBox
            // 
            pakFileGroupBox.AutoSize = true;
            pakFileGroupBox.Controls.Add(pakFileTableLayoutPanel);
            pakFileGroupBox.Dock = DockStyle.Top;
            pakFileGroupBox.Location = new Point(16, 16);
            pakFileGroupBox.Name = "pakFileGroupBox";
            pakFileGroupBox.Size = new Size(592, 80);
            pakFileGroupBox.TabIndex = 3;
            pakFileGroupBox.TabStop = false;
            pakFileGroupBox.Text = "Pak Files";
            // 
            // pakFileTableLayoutPanel
            // 
            pakFileTableLayoutPanel.AutoSize = true;
            pakFileTableLayoutPanel.ColumnCount = 3;
            pakFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            pakFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pakFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            pakFileTableLayoutPanel.Controls.Add(oldPakFileLabel, 0, 0);
            pakFileTableLayoutPanel.Controls.Add(newPakFileLabel, 0, 1);
            pakFileTableLayoutPanel.Controls.Add(oldPakFileTextBox, 1, 0);
            pakFileTableLayoutPanel.Controls.Add(newPakFileTextBox, 1, 1);
            pakFileTableLayoutPanel.Controls.Add(oldPakFileBrowseButton, 2, 0);
            pakFileTableLayoutPanel.Controls.Add(newPakFileBrowseButton, 2, 1);
            pakFileTableLayoutPanel.Dock = DockStyle.Fill;
            pakFileTableLayoutPanel.Location = new Point(3, 19);
            pakFileTableLayoutPanel.Name = "pakFileTableLayoutPanel";
            pakFileTableLayoutPanel.RowCount = 2;
            pakFileTableLayoutPanel.RowStyles.Add(new RowStyle());
            pakFileTableLayoutPanel.RowStyles.Add(new RowStyle());
            pakFileTableLayoutPanel.Size = new Size(586, 58);
            pakFileTableLayoutPanel.TabIndex = 1;
            // 
            // oldPakFileLabel
            // 
            oldPakFileLabel.Anchor = AnchorStyles.Right;
            oldPakFileLabel.AutoSize = true;
            oldPakFileLabel.Location = new Point(25, 7);
            oldPakFileLabel.Name = "oldPakFileLabel";
            oldPakFileLabel.Size = new Size(72, 15);
            oldPakFileLabel.TabIndex = 0;
            oldPakFileLabel.Text = "Old Pak File:";
            // 
            // newPakFileLabel
            // 
            newPakFileLabel.Anchor = AnchorStyles.Right;
            newPakFileLabel.AutoSize = true;
            newPakFileLabel.Location = new Point(20, 36);
            newPakFileLabel.Name = "newPakFileLabel";
            newPakFileLabel.Size = new Size(77, 15);
            newPakFileLabel.TabIndex = 1;
            newPakFileLabel.Text = "New Pak File:";
            // 
            // oldPakFileTextBox
            // 
            oldPakFileTextBox.Dock = DockStyle.Fill;
            oldPakFileTextBox.Location = new Point(103, 3);
            oldPakFileTextBox.Name = "oldPakFileTextBox";
            oldPakFileTextBox.Size = new Size(400, 23);
            oldPakFileTextBox.TabIndex = 2;
            // 
            // newPakFileTextBox
            // 
            newPakFileTextBox.Dock = DockStyle.Fill;
            newPakFileTextBox.Location = new Point(103, 32);
            newPakFileTextBox.Name = "newPakFileTextBox";
            newPakFileTextBox.Size = new Size(400, 23);
            newPakFileTextBox.TabIndex = 3;
            // 
            // oldPakFileBrowseButton
            // 
            oldPakFileBrowseButton.Location = new Point(509, 3);
            oldPakFileBrowseButton.Name = "oldPakFileBrowseButton";
            oldPakFileBrowseButton.Size = new Size(74, 23);
            oldPakFileBrowseButton.TabIndex = 4;
            oldPakFileBrowseButton.Text = "Browse...";
            oldPakFileBrowseButton.UseVisualStyleBackColor = true;
            // 
            // newPakFileBrowseButton
            // 
            newPakFileBrowseButton.Location = new Point(509, 32);
            newPakFileBrowseButton.Name = "newPakFileBrowseButton";
            newPakFileBrowseButton.Size = new Size(74, 23);
            newPakFileBrowseButton.TabIndex = 5;
            newPakFileBrowseButton.Text = "Browse...";
            newPakFileBrowseButton.UseVisualStyleBackColor = true;
            // 
            // PakDiffUtilityForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(624, 601);
            Controls.Add(pakDiffUtilityPanel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PakDiffUtilityForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pak Diff Utility";
            pakDiffUtilityPanel.ResumeLayout(false);
            pakDiffUtilityPanel.PerformLayout();
            buttonTableLayoutPanel.ResumeLayout(false);
            pakFileGroupBox.ResumeLayout(false);
            pakFileGroupBox.PerformLayout();
            pakFileTableLayoutPanel.ResumeLayout(false);
            pakFileTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pakDiffUtilityPanel;
        private GroupBox pakFileGroupBox;
        private TableLayoutPanel pakFileTableLayoutPanel;
        private Label oldPakFileLabel;
        private Label newPakFileLabel;
        private TextBox oldPakFileTextBox;
        private TextBox newPakFileTextBox;
        private Button oldPakFileBrowseButton;
        private Button newPakFileBrowseButton;
        private TableLayoutPanel buttonTableLayoutPanel;
        private Button saveDiffButton;
        private Button okButton;
        private Button cancelButton;
        private ListView diffListView;
    }
}