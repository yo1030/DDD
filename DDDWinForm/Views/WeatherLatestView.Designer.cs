namespace DDDWinForm
{
    partial class WeatherLatestView
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
            this.label1 = new System.Windows.Forms.Label();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.ConditionLabel = new System.Windows.Forms.Label();
            this.DataDateLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LatestBtn = new System.Windows.Forms.Button();
            this.AreasComboBox = new System.Windows.Forms.ComboBox();
            this.List = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地域";
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.Location = new System.Drawing.Point(143, 258);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(35, 12);
            this.TemperatureLabel.TabIndex = 1;
            this.TemperatureLabel.Text = "label2";
            // 
            // ConditionLabel
            // 
            this.ConditionLabel.AutoSize = true;
            this.ConditionLabel.Location = new System.Drawing.Point(143, 193);
            this.ConditionLabel.Name = "ConditionLabel";
            this.ConditionLabel.Size = new System.Drawing.Size(35, 12);
            this.ConditionLabel.TabIndex = 2;
            this.ConditionLabel.Text = "label3";
            // 
            // DataDateLabel
            // 
            this.DataDateLabel.AutoSize = true;
            this.DataDateLabel.Location = new System.Drawing.Point(143, 141);
            this.DataDateLabel.Name = "DataDateLabel";
            this.DataDateLabel.Size = new System.Drawing.Size(35, 12);
            this.DataDateLabel.TabIndex = 3;
            this.DataDateLabel.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "温度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "状態";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "日時";
            // 
            // LatestBtn
            // 
            this.LatestBtn.Location = new System.Drawing.Point(293, 82);
            this.LatestBtn.Name = "LatestBtn";
            this.LatestBtn.Size = new System.Drawing.Size(75, 23);
            this.LatestBtn.TabIndex = 8;
            this.LatestBtn.Text = "直近値";
            this.LatestBtn.UseVisualStyleBackColor = true;
            this.LatestBtn.Click += new System.EventHandler(this.LatestBtn_Click);
            // 
            // AreasComboBox
            // 
            this.AreasComboBox.FormattingEnabled = true;
            this.AreasComboBox.Location = new System.Drawing.Point(136, 85);
            this.AreasComboBox.Name = "AreasComboBox";
            this.AreasComboBox.Size = new System.Drawing.Size(121, 20);
            this.AreasComboBox.TabIndex = 9;
            // 
            // List
            // 
            this.List.Location = new System.Drawing.Point(32, 30);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(75, 23);
            this.List.TabIndex = 10;
            this.List.Text = "List";
            this.List.UseVisualStyleBackColor = true;
            this.List.Click += new System.EventHandler(this.List_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "追加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Save_Click);
            // 
            // WeatherLatestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 439);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.List);
            this.Controls.Add(this.AreasComboBox);
            this.Controls.Add(this.LatestBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DataDateLabel);
            this.Controls.Add(this.ConditionLabel);
            this.Controls.Add(this.TemperatureLabel);
            this.Controls.Add(this.label1);
            this.Name = "WeatherLatestView";
            this.Text = "WeatherLatestView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TemperatureLabel;
        private System.Windows.Forms.Label ConditionLabel;
        private System.Windows.Forms.Label DataDateLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button LatestBtn;
        private System.Windows.Forms.ComboBox AreasComboBox;
        private System.Windows.Forms.Button List;
        private System.Windows.Forms.Button button1;
    }
}

