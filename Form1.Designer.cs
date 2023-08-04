namespace Bmpconversion
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.text_path = new System.Windows.Forms.TextBox();
            this.btn_choose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.log = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "生成BIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnConvert2_Click);
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(9, 27);
            this.text_path.Name = "text_path";
            this.text_path.Size = new System.Drawing.Size(264, 25);
            this.text_path.TabIndex = 1;
            // 
            // btn_choose
            // 
            this.btn_choose.Location = new System.Drawing.Point(279, 19);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(85, 37);
            this.btn_choose.TabIndex = 6;
            this.btn_choose.Text = "选择文件";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 449);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(367, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 449);
            this.panel1.TabIndex = 8;
            // 
            // log
            // 
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log.Location = new System.Drawing.Point(9, 251);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(352, 186);
            this.log.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(95, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 70);
            this.button2.TabIndex = 10;
            this.button2.Text = "生成TXT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnConvertc_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(133, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 70);
            this.button3.TabIndex = 11;
            this.button3.Text = "批量处理";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonhex_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(222, 150);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 70);
            this.button4.TabIndex = 12;
            this.button4.Text = "BIN合成";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnConcatenate_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(22, 150);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 70);
            this.button5.TabIndex = 13;
            this.button5.Text = "索引表生成";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonindex_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 449);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.log);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "图片转换";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

