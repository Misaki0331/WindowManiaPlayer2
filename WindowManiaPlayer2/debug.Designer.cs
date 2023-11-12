
namespace WindowManiaPlayer
{
    partial class DebugWindow
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
            this.displaytext = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // displaytext
            // 
            this.displaytext.AutoSize = true;
            this.displaytext.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.displaytext.Location = new System.Drawing.Point(0, 0);
            this.displaytext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displaytext.Name = "displaytext";
            this.displaytext.Size = new System.Drawing.Size(281, 240);
            this.displaytext.TabIndex = 0;
            this.displaytext.Text = "Window : 300\r\nFPS : 0\r\nUpdate: 0\r\n0:00/0:00\r\n0000/0000";
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(379, 299);
            this.Controls.Add(this.displaytext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugWindow";
            this.ShowInTaskbar = false;
            this.Text = "debug";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.debug_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label displaytext;
    }
}