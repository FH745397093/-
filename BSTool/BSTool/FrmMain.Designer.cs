namespace BSTool
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnRegion = new System.Windows.Forms.ToolStripButton();
            this.btnDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnData = new System.Windows.Forms.ToolStripButton();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelForms = new System.Windows.Forms.Panel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSample = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegion,
            this.btnDevice,
            this.toolStripSeparator3,
            this.btnData,
            this.btnLog,
            this.toolStripSeparator1,
            this.btnSample,
            this.toolStripSeparator2,
            this.btnExit});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(760, 51);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnRegion
            // 
            this.btnRegion.Image = ((System.Drawing.Image)(resources.GetObject("btnRegion.Image")));
            this.btnRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.Size = new System.Drawing.Size(57, 48);
            this.btnRegion.Text = "区域授权";
            this.btnRegion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegion.Click += new System.EventHandler(this.btnRegion_Click);
            // 
            // btnDevice
            // 
            this.btnDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnDevice.Image")));
            this.btnDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevice.Name = "btnDevice";
            this.btnDevice.Size = new System.Drawing.Size(57, 48);
            this.btnDevice.Text = "设备授权";
            this.btnDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDevice.Click += new System.EventHandler(this.btnDevice_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 51);
            // 
            // btnData
            // 
            this.btnData.Image = ((System.Drawing.Image)(resources.GetObject("btnData.Image")));
            this.btnData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(57, 48);
            this.btnData.Text = "数据管理";
            this.btnData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnLog
            // 
            this.btnLog.Image = ((System.Drawing.Image)(resources.GetObject("btnLog.Image")));
            this.btnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(57, 48);
            this.btnLog.Text = "日志管理";
            this.btnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 48);
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(760, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelForms
            // 
            this.panelForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForms.Location = new System.Drawing.Point(0, 51);
            this.panelForms.Name = "panelForms";
            this.panelForms.Size = new System.Drawing.Size(760, 358);
            this.panelForms.TabIndex = 2;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            // 
            // btnSample
            // 
            this.btnSample.Image = ((System.Drawing.Image)(resources.GetObject("btnSample.Image")));
            this.btnSample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(57, 48);
            this.btnSample.Text = "导入测试";
            this.btnSample.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 431);
            this.Controls.Add(this.panelForms);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip);
            this.Name = "FrmMain";
            this.Text = "后台管理";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnRegion;
        private System.Windows.Forms.ToolStripButton btnDevice;
        private System.Windows.Forms.ToolStripButton btnData;
        private System.Windows.Forms.ToolStripButton btnLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelForms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSample;
    }
}