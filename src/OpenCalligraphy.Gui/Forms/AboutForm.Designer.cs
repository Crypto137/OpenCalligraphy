namespace OpenCalligraphy.Gui.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            aboutPanel = new Panel();
            aboutTableLayoutPanel = new TableLayoutPanel();
            iconPictureBox = new PictureBox();
            infoTableLayoutPanel = new TableLayoutPanel();
            titleLabel = new Label();
            copyrightLabel = new Label();
            websiteLinkLabel = new LinkLabel();
            versionLabel = new Label();
            licenseLabel = new Label();
            aboutPanel.SuspendLayout();
            aboutTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            infoTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // aboutPanel
            // 
            aboutPanel.Controls.Add(aboutTableLayoutPanel);
            aboutPanel.Dock = DockStyle.Fill;
            aboutPanel.Location = new Point(0, 0);
            aboutPanel.Name = "aboutPanel";
            aboutPanel.Padding = new Padding(8);
            aboutPanel.Size = new Size(464, 141);
            aboutPanel.TabIndex = 0;
            // 
            // aboutTableLayoutPanel
            // 
            aboutTableLayoutPanel.ColumnCount = 2;
            aboutTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            aboutTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            aboutTableLayoutPanel.Controls.Add(iconPictureBox, 0, 0);
            aboutTableLayoutPanel.Controls.Add(infoTableLayoutPanel, 1, 0);
            aboutTableLayoutPanel.Dock = DockStyle.Fill;
            aboutTableLayoutPanel.Location = new Point(8, 8);
            aboutTableLayoutPanel.Name = "aboutTableLayoutPanel";
            aboutTableLayoutPanel.RowCount = 1;
            aboutTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            aboutTableLayoutPanel.Size = new Size(448, 125);
            aboutTableLayoutPanel.TabIndex = 6;
            // 
            // iconPictureBox
            // 
            iconPictureBox.Image = (Image)resources.GetObject("iconPictureBox.Image");
            iconPictureBox.Location = new Point(3, 3);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(128, 119);
            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox.TabIndex = 5;
            iconPictureBox.TabStop = false;
            // 
            // infoTableLayoutPanel
            // 
            infoTableLayoutPanel.Anchor = AnchorStyles.Left;
            infoTableLayoutPanel.ColumnCount = 1;
            infoTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            infoTableLayoutPanel.Controls.Add(titleLabel, 0, 0);
            infoTableLayoutPanel.Controls.Add(versionLabel, 0, 1);
            infoTableLayoutPanel.Controls.Add(websiteLinkLabel, 0, 4);
            infoTableLayoutPanel.Controls.Add(copyrightLabel, 0, 2);
            infoTableLayoutPanel.Controls.Add(licenseLabel, 0, 3);
            infoTableLayoutPanel.Location = new Point(137, 3);
            infoTableLayoutPanel.Name = "infoTableLayoutPanel";
            infoTableLayoutPanel.RowCount = 5;
            infoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            infoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayoutPanel.Size = new Size(308, 119);
            infoTableLayoutPanel.TabIndex = 6;
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Left;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(3, 2);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(96, 15);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "OpenCalligraphy";
            // 
            // copyrightLabel
            // 
            copyrightLabel.Anchor = AnchorStyles.Left;
            copyrightLabel.AutoSize = true;
            copyrightLabel.Location = new Point(3, 42);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new Size(158, 15);
            copyrightLabel.TabIndex = 3;
            copyrightLabel.Text = "Copyright © 2025 Crypto137";
            // 
            // websiteLinkLabel
            // 
            websiteLinkLabel.Anchor = AnchorStyles.Left;
            websiteLinkLabel.AutoSize = true;
            websiteLinkLabel.Location = new Point(3, 101);
            websiteLinkLabel.Name = "websiteLinkLabel";
            websiteLinkLabel.Size = new Size(262, 15);
            websiteLinkLabel.TabIndex = 4;
            websiteLinkLabel.TabStop = true;
            websiteLinkLabel.Text = "https://github.com/Crypto137/OpenCalligraphy";
            websiteLinkLabel.LinkClicked += websiteLinkLabel_LinkClicked;
            // 
            // versionLabel
            // 
            versionLabel.Anchor = AnchorStyles.Left;
            versionLabel.AutoSize = true;
            versionLabel.Location = new Point(3, 22);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(118, 15);
            versionLabel.TabIndex = 2;
            versionLabel.Text = "Version 0.0.0 (Debug)";
            // 
            // licenseLabel
            // 
            licenseLabel.Anchor = AnchorStyles.Left;
            licenseLabel.AutoSize = true;
            licenseLabel.Location = new Point(3, 64);
            licenseLabel.Name = "licenseLabel";
            licenseLabel.Size = new Size(295, 30);
            licenseLabel.TabIndex = 5;
            licenseLabel.Text = "This software is licensed under the MIT License.\r\nSee the included LICENSE.txt file for more information.";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 141);
            Controls.Add(aboutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About OpenCalligraphy";
            aboutPanel.ResumeLayout(false);
            aboutTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            infoTableLayoutPanel.ResumeLayout(false);
            infoTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel aboutPanel;
        private Label copyrightLabel;
        private Label versionLabel;
        private Label titleLabel;
        private PictureBox iconPictureBox;
        private LinkLabel websiteLinkLabel;
        private TableLayoutPanel aboutTableLayoutPanel;
        private TableLayoutPanel infoTableLayoutPanel;
        private Label licenseLabel;
    }
}