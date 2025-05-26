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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pakDiffUtilityPanel = new Panel();
            diffDataGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            filterGroupBox = new GroupBox();
            filterTableLayoutPanel = new TableLayoutPanel();
            filterAddedCheckBox = new CheckBox();
            filterButton = new Button();
            filterRemovedCheckBox = new CheckBox();
            filterChangedCheckBox = new CheckBox();
            filterTextBox = new TextBox();
            clearFilterButton = new Button();
            comparisonGroupBox = new GroupBox();
            comparisonButtonTableLayoutPanel = new TableLayoutPanel();
            compareButton = new Button();
            cancelButton = new Button();
            comparisonPakFileTableLayoutPanel = new TableLayoutPanel();
            oldPakFileLabel = new Label();
            newPakFileLabel = new Label();
            oldPakFileTextBox = new TextBox();
            newPakFileTextBox = new TextBox();
            oldPakFileBrowseButton = new Button();
            newPakFileBrowseButton = new Button();
            diffButtonTableLayoutPanel = new TableLayoutPanel();
            saveDiffButton = new Button();
            saveFilteredButton = new Button();
            pakDiffUtilityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)diffDataGridView).BeginInit();
            filterGroupBox.SuspendLayout();
            filterTableLayoutPanel.SuspendLayout();
            comparisonGroupBox.SuspendLayout();
            comparisonButtonTableLayoutPanel.SuspendLayout();
            comparisonPakFileTableLayoutPanel.SuspendLayout();
            diffButtonTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pakDiffUtilityPanel
            // 
            pakDiffUtilityPanel.Controls.Add(diffDataGridView);
            pakDiffUtilityPanel.Controls.Add(filterGroupBox);
            pakDiffUtilityPanel.Controls.Add(comparisonGroupBox);
            pakDiffUtilityPanel.Controls.Add(diffButtonTableLayoutPanel);
            pakDiffUtilityPanel.Dock = DockStyle.Fill;
            pakDiffUtilityPanel.Location = new Point(0, 0);
            pakDiffUtilityPanel.Name = "pakDiffUtilityPanel";
            pakDiffUtilityPanel.Padding = new Padding(16);
            pakDiffUtilityPanel.Size = new Size(984, 661);
            pakDiffUtilityPanel.TabIndex = 0;
            // 
            // diffDataGridView
            // 
            diffDataGridView.AllowUserToAddRows = false;
            diffDataGridView.AllowUserToDeleteRows = false;
            diffDataGridView.AllowUserToResizeColumns = false;
            diffDataGridView.AllowUserToResizeRows = false;
            diffDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            diffDataGridView.ColumnHeadersVisible = false;
            diffDataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            diffDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            diffDataGridView.Dock = DockStyle.Fill;
            diffDataGridView.Location = new Point(16, 125);
            diffDataGridView.Name = "diffDataGridView";
            diffDataGridView.RowHeadersVisible = false;
            diffDataGridView.Size = new Size(952, 440);
            diffDataGridView.TabIndex = 5;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // filterGroupBox
            // 
            filterGroupBox.AutoSize = true;
            filterGroupBox.Controls.Add(filterTableLayoutPanel);
            filterGroupBox.Dock = DockStyle.Bottom;
            filterGroupBox.Enabled = false;
            filterGroupBox.Location = new Point(16, 565);
            filterGroupBox.Name = "filterGroupBox";
            filterGroupBox.Size = new Size(952, 51);
            filterGroupBox.TabIndex = 7;
            filterGroupBox.TabStop = false;
            filterGroupBox.Text = "Filter";
            // 
            // filterTableLayoutPanel
            // 
            filterTableLayoutPanel.AutoSize = true;
            filterTableLayoutPanel.ColumnCount = 6;
            filterTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            filterTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            filterTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            filterTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            filterTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            filterTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            filterTableLayoutPanel.Controls.Add(filterAddedCheckBox, 2, 0);
            filterTableLayoutPanel.Controls.Add(filterButton, 5, 0);
            filterTableLayoutPanel.Controls.Add(filterRemovedCheckBox, 3, 0);
            filterTableLayoutPanel.Controls.Add(filterChangedCheckBox, 4, 0);
            filterTableLayoutPanel.Controls.Add(filterTextBox, 1, 0);
            filterTableLayoutPanel.Controls.Add(clearFilterButton, 0, 0);
            filterTableLayoutPanel.Dock = DockStyle.Fill;
            filterTableLayoutPanel.Location = new Point(3, 19);
            filterTableLayoutPanel.Name = "filterTableLayoutPanel";
            filterTableLayoutPanel.RowCount = 1;
            filterTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filterTableLayoutPanel.Size = new Size(946, 29);
            filterTableLayoutPanel.TabIndex = 0;
            // 
            // filterAddedCheckBox
            // 
            filterAddedCheckBox.Anchor = AnchorStyles.Left;
            filterAddedCheckBox.AutoSize = true;
            filterAddedCheckBox.Checked = true;
            filterAddedCheckBox.CheckState = CheckState.Checked;
            filterAddedCheckBox.Location = new Point(640, 5);
            filterAddedCheckBox.Name = "filterAddedCheckBox";
            filterAddedCheckBox.Size = new Size(61, 19);
            filterAddedCheckBox.TabIndex = 0;
            filterAddedCheckBox.Text = "Added";
            filterAddedCheckBox.UseVisualStyleBackColor = true;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(869, 3);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(74, 23);
            filterButton.TabIndex = 0;
            filterButton.Text = "Filter";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // filterRemovedCheckBox
            // 
            filterRemovedCheckBox.Anchor = AnchorStyles.Left;
            filterRemovedCheckBox.AutoSize = true;
            filterRemovedCheckBox.Checked = true;
            filterRemovedCheckBox.CheckState = CheckState.Checked;
            filterRemovedCheckBox.Location = new Point(707, 5);
            filterRemovedCheckBox.Name = "filterRemovedCheckBox";
            filterRemovedCheckBox.Size = new Size(76, 19);
            filterRemovedCheckBox.TabIndex = 1;
            filterRemovedCheckBox.Text = "Removed";
            filterRemovedCheckBox.UseVisualStyleBackColor = true;
            // 
            // filterChangedCheckBox
            // 
            filterChangedCheckBox.Anchor = AnchorStyles.Left;
            filterChangedCheckBox.AutoSize = true;
            filterChangedCheckBox.Checked = true;
            filterChangedCheckBox.CheckState = CheckState.Checked;
            filterChangedCheckBox.Location = new Point(789, 5);
            filterChangedCheckBox.Name = "filterChangedCheckBox";
            filterChangedCheckBox.Size = new Size(74, 19);
            filterChangedCheckBox.TabIndex = 4;
            filterChangedCheckBox.Text = "Changed";
            filterChangedCheckBox.UseVisualStyleBackColor = true;
            // 
            // filterTextBox
            // 
            filterTextBox.Dock = DockStyle.Fill;
            filterTextBox.Location = new Point(32, 3);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(602, 23);
            filterTextBox.TabIndex = 5;
            filterTextBox.KeyDown += filterTextBox_KeyDown;
            // 
            // clearFilterButton
            // 
            clearFilterButton.Location = new Point(3, 3);
            clearFilterButton.Name = "clearFilterButton";
            clearFilterButton.Size = new Size(23, 23);
            clearFilterButton.TabIndex = 6;
            clearFilterButton.Text = "✖";
            clearFilterButton.UseVisualStyleBackColor = true;
            clearFilterButton.Click += clearFilterButton_Click;
            // 
            // comparisonGroupBox
            // 
            comparisonGroupBox.AutoSize = true;
            comparisonGroupBox.Controls.Add(comparisonButtonTableLayoutPanel);
            comparisonGroupBox.Controls.Add(comparisonPakFileTableLayoutPanel);
            comparisonGroupBox.Dock = DockStyle.Top;
            comparisonGroupBox.Location = new Point(16, 16);
            comparisonGroupBox.Name = "comparisonGroupBox";
            comparisonGroupBox.Size = new Size(952, 109);
            comparisonGroupBox.TabIndex = 3;
            comparisonGroupBox.TabStop = false;
            comparisonGroupBox.Text = "Comparison";
            // 
            // comparisonButtonTableLayoutPanel
            // 
            comparisonButtonTableLayoutPanel.AutoSize = true;
            comparisonButtonTableLayoutPanel.ColumnCount = 3;
            comparisonButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            comparisonButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            comparisonButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            comparisonButtonTableLayoutPanel.Controls.Add(compareButton, 1, 0);
            comparisonButtonTableLayoutPanel.Controls.Add(cancelButton, 2, 0);
            comparisonButtonTableLayoutPanel.Dock = DockStyle.Top;
            comparisonButtonTableLayoutPanel.Location = new Point(3, 77);
            comparisonButtonTableLayoutPanel.Name = "comparisonButtonTableLayoutPanel";
            comparisonButtonTableLayoutPanel.RowCount = 1;
            comparisonButtonTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            comparisonButtonTableLayoutPanel.Size = new Size(946, 29);
            comparisonButtonTableLayoutPanel.TabIndex = 2;
            // 
            // compareButton
            // 
            compareButton.Dock = DockStyle.Fill;
            compareButton.Location = new Point(789, 3);
            compareButton.Name = "compareButton";
            compareButton.Size = new Size(74, 23);
            compareButton.TabIndex = 0;
            compareButton.Text = "Compare";
            compareButton.UseVisualStyleBackColor = true;
            compareButton.Click += compareButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.Location = new Point(869, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(74, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // comparisonPakFileTableLayoutPanel
            // 
            comparisonPakFileTableLayoutPanel.AutoSize = true;
            comparisonPakFileTableLayoutPanel.ColumnCount = 3;
            comparisonPakFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            comparisonPakFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            comparisonPakFileTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            comparisonPakFileTableLayoutPanel.Controls.Add(oldPakFileLabel, 0, 0);
            comparisonPakFileTableLayoutPanel.Controls.Add(newPakFileLabel, 0, 1);
            comparisonPakFileTableLayoutPanel.Controls.Add(oldPakFileTextBox, 1, 0);
            comparisonPakFileTableLayoutPanel.Controls.Add(newPakFileTextBox, 1, 1);
            comparisonPakFileTableLayoutPanel.Controls.Add(oldPakFileBrowseButton, 2, 0);
            comparisonPakFileTableLayoutPanel.Controls.Add(newPakFileBrowseButton, 2, 1);
            comparisonPakFileTableLayoutPanel.Dock = DockStyle.Top;
            comparisonPakFileTableLayoutPanel.Location = new Point(3, 19);
            comparisonPakFileTableLayoutPanel.Name = "comparisonPakFileTableLayoutPanel";
            comparisonPakFileTableLayoutPanel.RowCount = 2;
            comparisonPakFileTableLayoutPanel.RowStyles.Add(new RowStyle());
            comparisonPakFileTableLayoutPanel.RowStyles.Add(new RowStyle());
            comparisonPakFileTableLayoutPanel.Size = new Size(946, 58);
            comparisonPakFileTableLayoutPanel.TabIndex = 1;
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
            oldPakFileTextBox.Size = new Size(760, 23);
            oldPakFileTextBox.TabIndex = 2;
            // 
            // newPakFileTextBox
            // 
            newPakFileTextBox.Dock = DockStyle.Fill;
            newPakFileTextBox.Location = new Point(103, 32);
            newPakFileTextBox.Name = "newPakFileTextBox";
            newPakFileTextBox.Size = new Size(760, 23);
            newPakFileTextBox.TabIndex = 3;
            // 
            // oldPakFileBrowseButton
            // 
            oldPakFileBrowseButton.Location = new Point(869, 3);
            oldPakFileBrowseButton.Name = "oldPakFileBrowseButton";
            oldPakFileBrowseButton.Size = new Size(74, 23);
            oldPakFileBrowseButton.TabIndex = 4;
            oldPakFileBrowseButton.Text = "Browse...";
            oldPakFileBrowseButton.UseVisualStyleBackColor = true;
            oldPakFileBrowseButton.Click += oldPakFileBrowseButton_Click;
            // 
            // newPakFileBrowseButton
            // 
            newPakFileBrowseButton.Location = new Point(869, 32);
            newPakFileBrowseButton.Name = "newPakFileBrowseButton";
            newPakFileBrowseButton.Size = new Size(74, 23);
            newPakFileBrowseButton.TabIndex = 5;
            newPakFileBrowseButton.Text = "Browse...";
            newPakFileBrowseButton.UseVisualStyleBackColor = true;
            newPakFileBrowseButton.Click += newPakFileBrowseButton_Click;
            // 
            // diffButtonTableLayoutPanel
            // 
            diffButtonTableLayoutPanel.AutoSize = true;
            diffButtonTableLayoutPanel.ColumnCount = 3;
            diffButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            diffButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            diffButtonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            diffButtonTableLayoutPanel.Controls.Add(saveDiffButton, 1, 0);
            diffButtonTableLayoutPanel.Controls.Add(saveFilteredButton, 2, 0);
            diffButtonTableLayoutPanel.Dock = DockStyle.Bottom;
            diffButtonTableLayoutPanel.Enabled = false;
            diffButtonTableLayoutPanel.Location = new Point(16, 616);
            diffButtonTableLayoutPanel.Name = "diffButtonTableLayoutPanel";
            diffButtonTableLayoutPanel.RowCount = 1;
            diffButtonTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            diffButtonTableLayoutPanel.Size = new Size(952, 29);
            diffButtonTableLayoutPanel.TabIndex = 4;
            // 
            // saveDiffButton
            // 
            saveDiffButton.Dock = DockStyle.Fill;
            saveDiffButton.Location = new Point(755, 3);
            saveDiffButton.Name = "saveDiffButton";
            saveDiffButton.Size = new Size(94, 23);
            saveDiffButton.TabIndex = 0;
            saveDiffButton.Text = "Save All...";
            saveDiffButton.UseVisualStyleBackColor = true;
            saveDiffButton.Click += saveDiffButton_Click;
            // 
            // saveFilteredButton
            // 
            saveFilteredButton.Dock = DockStyle.Fill;
            saveFilteredButton.Location = new Point(855, 3);
            saveFilteredButton.Name = "saveFilteredButton";
            saveFilteredButton.Size = new Size(94, 23);
            saveFilteredButton.TabIndex = 3;
            saveFilteredButton.Text = "Save Filtered...";
            saveFilteredButton.UseVisualStyleBackColor = true;
            saveFilteredButton.Click += saveFilteredButton_Click;
            // 
            // PakDiffUtilityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(984, 661);
            Controls.Add(pakDiffUtilityPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PakDiffUtilityForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pak Diff Utility";
            pakDiffUtilityPanel.ResumeLayout(false);
            pakDiffUtilityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)diffDataGridView).EndInit();
            filterGroupBox.ResumeLayout(false);
            filterGroupBox.PerformLayout();
            filterTableLayoutPanel.ResumeLayout(false);
            filterTableLayoutPanel.PerformLayout();
            comparisonGroupBox.ResumeLayout(false);
            comparisonGroupBox.PerformLayout();
            comparisonButtonTableLayoutPanel.ResumeLayout(false);
            comparisonPakFileTableLayoutPanel.ResumeLayout(false);
            comparisonPakFileTableLayoutPanel.PerformLayout();
            diffButtonTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pakDiffUtilityPanel;
        private GroupBox comparisonGroupBox;
        private TableLayoutPanel comparisonPakFileTableLayoutPanel;
        private Label oldPakFileLabel;
        private Label newPakFileLabel;
        private TextBox oldPakFileTextBox;
        private TextBox newPakFileTextBox;
        private Button oldPakFileBrowseButton;
        private Button newPakFileBrowseButton;
        private TableLayoutPanel diffButtonTableLayoutPanel;
        private Button saveDiffButton;
        private DataGridView diffDataGridView;
        private DataGridViewTextBoxColumn Column1;
        private GroupBox filterGroupBox;
        private TableLayoutPanel filterTableLayoutPanel;
        private CheckBox filterAddedCheckBox;
        private Button filterButton;
        private CheckBox filterRemovedCheckBox;
        private CheckBox filterChangedCheckBox;
        private TextBox filterTextBox;
        private Button clearFilterButton;
        private Button saveFilteredButton;
        private TableLayoutPanel comparisonButtonTableLayoutPanel;
        private Button compareButton;
        private Button cancelButton;
    }
}