namespace eVision_ShowImage
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.button_load = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnGray = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LBL_PPM = new System.Windows.Forms.Label();
            this.TXT_PX = new System.Windows.Forms.TextBox();
            this.TXT_MM = new System.Windows.Forms.TextBox();
            this.button_PPM = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(10, 54);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(412, 309);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(12, 16);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(108, 23);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Load color image";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnGray
            // 
            this.btnGray.Location = new System.Drawing.Point(501, 24);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(108, 23);
            this.btnGray.TabIndex = 2;
            this.btnGray.Text = "Load gray image";
            this.btnGray.UseVisualStyleBackColor = true;
            this.btnGray.Click += new System.EventHandler(this.btnGray_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBL_PPM);
            this.groupBox1.Controls.Add(this.TXT_PX);
            this.groupBox1.Controls.Add(this.TXT_MM);
            this.groupBox1.Location = new System.Drawing.Point(126, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 36);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // LBL_PPM
            // 
            this.LBL_PPM.AutoSize = true;
            this.LBL_PPM.Location = new System.Drawing.Point(222, 23);
            this.LBL_PPM.Name = "LBL_PPM";
            this.LBL_PPM.Size = new System.Drawing.Size(33, 12);
            this.LBL_PPM.TabIndex = 2;
            this.LBL_PPM.Text = "label1";
            // 
            // TXT_PX
            // 
            this.TXT_PX.Location = new System.Drawing.Point(105, 14);
            this.TXT_PX.Name = "TXT_PX";
            this.TXT_PX.Size = new System.Drawing.Size(100, 22);
            this.TXT_PX.TabIndex = 1;
            // 
            // TXT_MM
            // 
            this.TXT_MM.Location = new System.Drawing.Point(22, 14);
            this.TXT_MM.Name = "TXT_MM";
            this.TXT_MM.Size = new System.Drawing.Size(76, 22);
            this.TXT_MM.TabIndex = 0;
            // 
            // button_PPM
            // 
            this.button_PPM.Location = new System.Drawing.Point(408, 24);
            this.button_PPM.Name = "button_PPM";
            this.button_PPM.Size = new System.Drawing.Size(75, 23);
            this.button_PPM.TabIndex = 4;
            this.button_PPM.Text = "button1";
            this.button_PPM.UseVisualStyleBackColor = true;
            this.button_PPM.Click += new System.EventHandler(this.button_PPM_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(450, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 52);
            this.button2.TabIndex = 6;
            this.button2.Text = "LoadModel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(450, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 54);
            this.button3.TabIndex = 7;
            this.button3.Text = "OFFSET";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(450, 231);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 54);
            this.button4.TabIndex = 8;
            this.button4.Text = "MEASURE";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(450, 291);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 54);
            this.button5.TabIndex = 9;
            this.button5.Text = "CALCULATE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 381);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_PPM);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGray);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.pbImage);
            this.Name = "Form1";
            this.Text = "eVision - Load Image and show";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LBL_PPM;
        private System.Windows.Forms.TextBox TXT_PX;
        private System.Windows.Forms.TextBox TXT_MM;
        private System.Windows.Forms.Button button_PPM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

