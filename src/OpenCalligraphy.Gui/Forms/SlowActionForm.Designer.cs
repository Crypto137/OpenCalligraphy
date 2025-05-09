namespace OpenCalligraphy.Gui.Forms
{
    partial class SlowActionForm
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
            textLabel = new Label();
            SuspendLayout();
            // 
            // textLabel
            // 
            textLabel.Dock = DockStyle.Fill;
            textLabel.Location = new Point(0, 0);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(344, 81);
            textLabel.TabIndex = 0;
            textLabel.Text = "text";
            textLabel.TextAlign = ContentAlignment.MiddleCenter;
            textLabel.UseWaitCursor = true;
            // 
            // SlowActionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 81);
            ControlBox = false;
            Controls.Add(textLabel);
            Name = "SlowActionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Title";
            UseWaitCursor = true;
            Shown += SlowActionForm_Shown;
            ResumeLayout(false);
        }

        #endregion

        private Label textLabel;
    }
}