namespace OpenCalligraphy.Gui.UserControls
{
    partial class CurveInspectorUserControl
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
            curvePanel = new Panel();
            curveMetadataGroupBox = new GroupBox();
            curveMetadataTableLayoutPanel = new TableLayoutPanel();
            curveFindReferencesButton = new Button();
            curveNameTextBox = new TextBox();
            curveNameLabel = new Label();
            curvePanel.SuspendLayout();
            curveMetadataGroupBox.SuspendLayout();
            curveMetadataTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // curvePanel
            // 
            curvePanel.Controls.Add(curveMetadataGroupBox);
            curvePanel.Dock = DockStyle.Fill;
            curvePanel.Location = new Point(0, 0);
            curvePanel.Name = "curvePanel";
            curvePanel.Size = new Size(800, 600);
            curvePanel.TabIndex = 0;
            // 
            // curveMetadataGroupBox
            // 
            curveMetadataGroupBox.AutoSize = true;
            curveMetadataGroupBox.Controls.Add(curveMetadataTableLayoutPanel);
            curveMetadataGroupBox.Dock = DockStyle.Top;
            curveMetadataGroupBox.Location = new Point(0, 0);
            curveMetadataGroupBox.Name = "curveMetadataGroupBox";
            curveMetadataGroupBox.Size = new Size(800, 51);
            curveMetadataGroupBox.TabIndex = 0;
            curveMetadataGroupBox.TabStop = false;
            curveMetadataGroupBox.Text = "Metadata";
            // 
            // curveMetadataTableLayoutPanel
            // 
            curveMetadataTableLayoutPanel.AutoSize = true;
            curveMetadataTableLayoutPanel.ColumnCount = 3;
            curveMetadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            curveMetadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            curveMetadataTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            curveMetadataTableLayoutPanel.Controls.Add(curveFindReferencesButton, 2, 0);
            curveMetadataTableLayoutPanel.Controls.Add(curveNameTextBox, 1, 0);
            curveMetadataTableLayoutPanel.Controls.Add(curveNameLabel, 0, 0);
            curveMetadataTableLayoutPanel.Dock = DockStyle.Fill;
            curveMetadataTableLayoutPanel.Location = new Point(3, 19);
            curveMetadataTableLayoutPanel.Name = "curveMetadataTableLayoutPanel";
            curveMetadataTableLayoutPanel.RowCount = 1;
            curveMetadataTableLayoutPanel.RowStyles.Add(new RowStyle());
            curveMetadataTableLayoutPanel.Size = new Size(794, 29);
            curveMetadataTableLayoutPanel.TabIndex = 0;
            // 
            // curveFindReferencesButton
            // 
            curveFindReferencesButton.Location = new Point(677, 3);
            curveFindReferencesButton.Name = "curveFindReferencesButton";
            curveFindReferencesButton.Size = new Size(114, 23);
            curveFindReferencesButton.TabIndex = 0;
            curveFindReferencesButton.Text = "Find References";
            curveFindReferencesButton.UseVisualStyleBackColor = true;
            curveFindReferencesButton.Click += curveFindReferencesButton_Click;
            // 
            // curveNameTextBox
            // 
            curveNameTextBox.Dock = DockStyle.Fill;
            curveNameTextBox.Location = new Point(83, 3);
            curveNameTextBox.Name = "curveNameTextBox";
            curveNameTextBox.ReadOnly = true;
            curveNameTextBox.Size = new Size(588, 23);
            curveNameTextBox.TabIndex = 1;
            // 
            // curveNameLabel
            // 
            curveNameLabel.Anchor = AnchorStyles.Right;
            curveNameLabel.AutoSize = true;
            curveNameLabel.Location = new Point(36, 7);
            curveNameLabel.Name = "curveNameLabel";
            curveNameLabel.Size = new Size(41, 15);
            curveNameLabel.TabIndex = 2;
            curveNameLabel.Text = "Curve:";
            // 
            // CurveInspectorUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(curvePanel);
            Name = "CurveInspectorUserControl";
            Size = new Size(800, 600);
            curvePanel.ResumeLayout(false);
            curvePanel.PerformLayout();
            curveMetadataGroupBox.ResumeLayout(false);
            curveMetadataGroupBox.PerformLayout();
            curveMetadataTableLayoutPanel.ResumeLayout(false);
            curveMetadataTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel curvePanel;
        private GroupBox curveMetadataGroupBox;
        private TableLayoutPanel curveMetadataTableLayoutPanel;
        private Button curveFindReferencesButton;
        private TextBox curveNameTextBox;
        private Label curveNameLabel;
    }
}
