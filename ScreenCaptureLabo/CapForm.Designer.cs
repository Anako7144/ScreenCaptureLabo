namespace CapMaster
{
    partial class CapForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.AppListBox = new System.Windows.Forms.ListBox();
            this.capButton = new System.Windows.Forms.Button();
            this.timerIntervalNum = new System.Windows.Forms.NumericUpDown();
            this.timerCheckBox = new System.Windows.Forms.CheckBox();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.EndTextBox = new System.Windows.Forms.TextBox();
            this.EndLabel = new System.Windows.Forms.Label();
            this.OpenCapDirButton = new System.Windows.Forms.Button();
            this.secLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalNum)).BeginInit();
            this.SuspendLayout();
            // 
            // AppListBox
            // 
            this.AppListBox.FormattingEnabled = true;
            this.AppListBox.ItemHeight = 12;
            this.AppListBox.Location = new System.Drawing.Point(12, 12);
            this.AppListBox.Name = "AppListBox";
            this.AppListBox.Size = new System.Drawing.Size(260, 172);
            this.AppListBox.TabIndex = 0;
            this.AppListBox.SelectedIndexChanged += new System.EventHandler(this.AppListBox_SelectedIndexChanged);
            this.AppListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AppListBox_KeyDown);
            // 
            // capButton
            // 
            this.capButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.capButton.Location = new System.Drawing.Point(199, 190);
            this.capButton.Name = "capButton";
            this.capButton.Size = new System.Drawing.Size(73, 23);
            this.capButton.TabIndex = 1;
            this.capButton.Text = "キャプチャ";
            this.capButton.UseVisualStyleBackColor = false;
            this.capButton.Click += new System.EventHandler(this.capButton_Click);
            // 
            // timerIntervalNum
            // 
            this.timerIntervalNum.Location = new System.Drawing.Point(97, 192);
            this.timerIntervalNum.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.timerIntervalNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.timerIntervalNum.Name = "timerIntervalNum";
            this.timerIntervalNum.Size = new System.Drawing.Size(37, 19);
            this.timerIntervalNum.TabIndex = 2;
            this.timerIntervalNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // timerCheckBox
            // 
            this.timerCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.timerCheckBox.AutoSize = true;
            this.timerCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.timerCheckBox.Location = new System.Drawing.Point(12, 190);
            this.timerCheckBox.Name = "timerCheckBox";
            this.timerCheckBox.Size = new System.Drawing.Size(76, 22);
            this.timerCheckBox.TabIndex = 3;
            this.timerCheckBox.Text = "定期ｷｬﾌﾟﾁｬ";
            this.timerCheckBox.UseVisualStyleBackColor = false;
            this.timerCheckBox.CheckedChanged += new System.EventHandler(this.timerCheckBox_CheckedChanged);
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(44, 218);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(44, 19);
            this.StartTextBox.TabIndex = 4;
            this.StartTextBox.Text = "1";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(10, 221);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(29, 12);
            this.startLabel.TabIndex = 5;
            this.startLabel.Text = "開始";
            // 
            // EndTextBox
            // 
            this.EndTextBox.Location = new System.Drawing.Point(139, 218);
            this.EndTextBox.Name = "EndTextBox";
            this.EndTextBox.Size = new System.Drawing.Size(44, 19);
            this.EndTextBox.TabIndex = 4;
            this.EndTextBox.Text = "1";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(105, 221);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(29, 12);
            this.EndLabel.TabIndex = 5;
            this.EndLabel.Text = "終了";
            // 
            // OpenCapDirButton
            // 
            this.OpenCapDirButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.OpenCapDirButton.Location = new System.Drawing.Point(199, 218);
            this.OpenCapDirButton.Name = "OpenCapDirButton";
            this.OpenCapDirButton.Size = new System.Drawing.Size(73, 26);
            this.OpenCapDirButton.TabIndex = 6;
            this.OpenCapDirButton.Text = "CapDir";
            this.OpenCapDirButton.UseVisualStyleBackColor = false;
            this.OpenCapDirButton.Click += new System.EventHandler(this.OpenCapDirButton_Click);
            // 
            // secLabel
            // 
            this.secLabel.AutoSize = true;
            this.secLabel.Location = new System.Drawing.Point(137, 195);
            this.secLabel.Name = "secLabel";
            this.secLabel.Size = new System.Drawing.Size(29, 12);
            this.secLabel.TabIndex = 7;
            this.secLabel.Text = "秒毎";
            // 
            // CapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 251);
            this.Controls.Add(this.secLabel);
            this.Controls.Add(this.OpenCapDirButton);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.EndTextBox);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.timerCheckBox);
            this.Controls.Add(this.timerIntervalNum);
            this.Controls.Add(this.capButton);
            this.Controls.Add(this.AppListBox);
            this.Name = "CapForm";
            this.Text = "キャプチャ";
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AppListBox;
        private System.Windows.Forms.Button capButton;
        private System.Windows.Forms.NumericUpDown timerIntervalNum;
        private System.Windows.Forms.CheckBox timerCheckBox;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.TextBox EndTextBox;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Button OpenCapDirButton;
        private System.Windows.Forms.Label secLabel;
    }
}

