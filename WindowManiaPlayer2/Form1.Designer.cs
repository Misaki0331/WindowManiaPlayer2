
namespace WindowManiaPlayer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.playerplay = new System.Windows.Forms.Button();
            this.beatmap = new System.Windows.Forms.Button();
            this.filedialog = new System.Windows.Forms.OpenFileDialog();
            this.IsDebugMode = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.link_github = new System.Windows.Forms.Button();
            this.link_twitter = new System.Windows.Forms.Button();
            this.link_repository = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 31);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(418, 23);
            this.textBox1.TabIndex = 0;
            // 
            // playerplay
            // 
            this.playerplay.Location = new System.Drawing.Point(440, 58);
            this.playerplay.Margin = new System.Windows.Forms.Padding(4);
            this.playerplay.Name = "playerplay";
            this.playerplay.Size = new System.Drawing.Size(88, 29);
            this.playerplay.TabIndex = 2;
            this.playerplay.Text = "再生";
            this.playerplay.UseVisualStyleBackColor = true;
            this.playerplay.Click += new System.EventHandler(this.playerplay_Click);
            // 
            // beatmap
            // 
            this.beatmap.Location = new System.Drawing.Point(440, 31);
            this.beatmap.Margin = new System.Windows.Forms.Padding(4);
            this.beatmap.Name = "beatmap";
            this.beatmap.Size = new System.Drawing.Size(88, 24);
            this.beatmap.TabIndex = 5;
            this.beatmap.Text = "譜面ファイル";
            this.beatmap.UseVisualStyleBackColor = true;
            this.beatmap.Click += new System.EventHandler(this.beatmap_Click);
            // 
            // filedialog
            // 
            this.filedialog.FileOk += new System.ComponentModel.CancelEventHandler(this.filedialog_FileOk);
            // 
            // IsDebugMode
            // 
            this.IsDebugMode.AutoSize = true;
            this.IsDebugMode.Checked = true;
            this.IsDebugMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsDebugMode.Location = new System.Drawing.Point(13, 64);
            this.IsDebugMode.Margin = new System.Windows.Forms.Padding(4);
            this.IsDebugMode.Name = "IsDebugMode";
            this.IsDebugMode.Size = new System.Drawing.Size(86, 19);
            this.IsDebugMode.TabIndex = 6;
            this.IsDebugMode.Text = "デバッグモード";
            this.IsDebugMode.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(218, 62);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 23);
            this.numericUpDown1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "オフセット(ms) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "このアプリの製作者 : 水咲(みさき)";
            // 
            // link_github
            // 
            this.link_github.Location = new System.Drawing.Point(188, 5);
            this.link_github.Margin = new System.Windows.Forms.Padding(4);
            this.link_github.Name = "link_github";
            this.link_github.Size = new System.Drawing.Size(85, 26);
            this.link_github.TabIndex = 10;
            this.link_github.Text = "HomePage";
            this.link_github.UseVisualStyleBackColor = true;
            this.link_github.Click += new System.EventHandler(this.link_github_Click);
            // 
            // link_twitter
            // 
            this.link_twitter.Location = new System.Drawing.Point(276, 5);
            this.link_twitter.Margin = new System.Windows.Forms.Padding(4);
            this.link_twitter.Name = "link_twitter";
            this.link_twitter.Size = new System.Drawing.Size(61, 26);
            this.link_twitter.TabIndex = 11;
            this.link_twitter.Text = "Misskey";
            this.link_twitter.UseVisualStyleBackColor = true;
            this.link_twitter.Click += new System.EventHandler(this.link_twitter_Click);
            // 
            // link_repository
            // 
            this.link_repository.Location = new System.Drawing.Point(344, 5);
            this.link_repository.Margin = new System.Windows.Forms.Padding(4);
            this.link_repository.Name = "link_repository";
            this.link_repository.Size = new System.Drawing.Size(89, 26);
            this.link_repository.TabIndex = 12;
            this.link_repository.Text = "Repository";
            this.link_repository.UseVisualStyleBackColor = true;
            this.link_repository.Click += new System.EventHandler(this.link_repository_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "ショートサイズ";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(369, 64);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 23);
            this.numericUpDown2.TabIndex = 14;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 3;
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Location = new System.Drawing.Point(440, 94);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(88, 23);
            this.numericUpDown3.TabIndex = 15;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "スクロール速度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "スクロール対応版！";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 122);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.link_repository);
            this.Controls.Add(this.link_twitter);
            this.Controls.Add(this.link_github);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.IsDebugMode);
            this.Controls.Add(this.beatmap);
            this.Controls.Add(this.playerplay);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Window Mania Player2";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button playerplay;
        private System.Windows.Forms.Button beatmap;
        private System.Windows.Forms.OpenFileDialog filedialog;
        private System.Windows.Forms.CheckBox IsDebugMode;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button link_github;
        private System.Windows.Forms.Button link_twitter;
        private System.Windows.Forms.Button link_repository;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private Label label4;
        private Label label5;
    }
}

