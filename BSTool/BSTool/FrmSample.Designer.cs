namespace BSTool
{
    partial class FrmSample
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtKCH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtlog = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "工作日志";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(355, 184);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(108, 22);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "开始导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtKCH
            // 
            this.txtKCH.BackColor = System.Drawing.Color.White;
            this.txtKCH.Location = new System.Drawing.Point(13, 185);
            this.txtKCH.Name = "txtKCH";
            this.txtKCH.Size = new System.Drawing.Size(333, 21);
            this.txtKCH.TabIndex = 13;
            this.txtKCH.Text = "K3101150000002016050042";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "请输入对应现场的勘验号（K打头的32位编号）";
            // 
            // txtlog
            // 
            this.txtlog.Location = new System.Drawing.Point(12, 252);
            this.txtlog.Multiline = true;
            this.txtlog.Name = "txtlog";
            this.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtlog.Size = new System.Drawing.Size(333, 229);
            this.txtlog.TabIndex = 11;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(355, 32);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(111, 22);
            this.btnFile.TabIndex = 10;
            this.btnFile.Text = "浏览文件...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtfile
            // 
            this.txtfile.BackColor = System.Drawing.Color.White;
            this.txtfile.Location = new System.Drawing.Point(13, 32);
            this.txtfile.Name = "txtfile";
            this.txtfile.ReadOnly = true;
            this.txtfile.Size = new System.Drawing.Size(333, 21);
            this.txtfile.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "请选择要导入的数据文件(*.csv)";
            // 
            // txtpass
            // 
            this.txtpass.BackColor = System.Drawing.Color.White;
            this.txtpass.Location = new System.Drawing.Point(253, 120);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(92, 21);
            this.txtpass.TabIndex = 19;
            this.txtpass.Text = "tj";
            // 
            // txtuser
            // 
            this.txtuser.BackColor = System.Drawing.Color.White;
            this.txtuser.Location = new System.Drawing.Point(95, 120);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(94, 21);
            this.txtuser.TabIndex = 18;
            this.txtuser.Text = "admin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "现勘用户名：";
            // 
            // txtUUID
            // 
            this.txtUUID.BackColor = System.Drawing.Color.White;
            this.txtUUID.Location = new System.Drawing.Point(14, 83);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.Size = new System.Drawing.Size(333, 21);
            this.txtUUID.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "请输入设备编号";
            // 
            // FrmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 500);
            this.Controls.Add(this.txtUUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtKCH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtlog);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtfile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据导入测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtKCH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtlog;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUUID;
        private System.Windows.Forms.Label label4;
    }
}