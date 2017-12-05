namespace BSTool
{
    partial class DlgDevice
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(26, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "授权状态:";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Location = new System.Drawing.Point(175, 155);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(101, 27);
            this.cmdCancel.TabIndex = 37;
            this.cmdCancel.Text = "取 消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDeviceID.Location = new System.Drawing.Point(112, 62);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(164, 26);
            this.txtDeviceID.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "设备编号:";
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdOK.Location = new System.Drawing.Point(29, 155);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(101, 27);
            this.cmdOK.TabIndex = 28;
            this.cmdOK.Text = "确 定";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtRegion
            // 
            this.txtRegion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegion.Location = new System.Drawing.Point(112, 25);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(164, 26);
            this.txtRegion.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "所属区域:";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "授权使用",
            "暂停使用",
            "废弃"});
            this.cboState.Location = new System.Drawing.Point(112, 102);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(164, 24);
            this.cboState.TabIndex = 39;
            // 
            // DlgDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 200);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgDevice";
            this.Load += new System.EventHandler(this.DlgDevice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtDeviceID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboState;
    }
}