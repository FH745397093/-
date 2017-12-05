namespace BSTool
{
    partial class FrmDevice
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("省级");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvRegion = new System.Windows.Forms.TreeView();
            this.lvDevices = new System.Windows.Forms.ListView();
            this.clIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clDeviceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdDelRegion = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdNewDevice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvRegion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvDevices);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(861, 536);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvRegion
            // 
            this.tvRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRegion.Location = new System.Drawing.Point(0, 0);
            this.tvRegion.Name = "tvRegion";
            treeNode3.Name = "nroot";
            treeNode3.Text = "省级";
            this.tvRegion.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tvRegion.Size = new System.Drawing.Size(287, 536);
            this.tvRegion.TabIndex = 0;
            this.tvRegion.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRegion_AfterSelect);
            // 
            // lvDevices
            // 
            this.lvDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clIndex,
            this.clRegion,
            this.clDeviceID,
            this.clState});
            this.lvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDevices.FullRowSelect = true;
            this.lvDevices.Location = new System.Drawing.Point(0, 0);
            this.lvDevices.Name = "lvDevices";
            this.lvDevices.Size = new System.Drawing.Size(570, 499);
            this.lvDevices.TabIndex = 5;
            this.lvDevices.UseCompatibleStateImageBehavior = false;
            this.lvDevices.View = System.Windows.Forms.View.Details;
            this.lvDevices.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDevices_MouseDoubleClick);
            // 
            // clIndex
            // 
            this.clIndex.Text = "序号";
            // 
            // clRegion
            // 
            this.clRegion.Text = "所属行政区划";
            this.clRegion.Width = 120;
            // 
            // clDeviceID
            // 
            this.clDeviceID.Text = "设备编号";
            this.clDeviceID.Width = 240;
            // 
            // clState
            // 
            this.clState.Text = "授权状态";
            this.clState.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdDelRegion);
            this.panel1.Controls.Add(this.cmdModify);
            this.panel1.Controls.Add(this.cmdNewDevice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 499);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 37);
            this.panel1.TabIndex = 4;
            // 
            // cmdDelRegion
            // 
            this.cmdDelRegion.Location = new System.Drawing.Point(266, 3);
            this.cmdDelRegion.Name = "cmdDelRegion";
            this.cmdDelRegion.Size = new System.Drawing.Size(121, 29);
            this.cmdDelRegion.TabIndex = 6;
            this.cmdDelRegion.Text = "删除设备";
            this.cmdDelRegion.UseVisualStyleBackColor = true;
            this.cmdDelRegion.Click += new System.EventHandler(this.cmdDelRegion_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.Location = new System.Drawing.Point(139, 3);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(121, 29);
            this.cmdModify.TabIndex = 5;
            this.cmdModify.Text = "修改设备";
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdNewDevice
            // 
            this.cmdNewDevice.Location = new System.Drawing.Point(12, 3);
            this.cmdNewDevice.Name = "cmdNewDevice";
            this.cmdNewDevice.Size = new System.Drawing.Size(121, 29);
            this.cmdNewDevice.TabIndex = 4;
            this.cmdNewDevice.Text = "新增设备";
            this.cmdNewDevice.UseVisualStyleBackColor = true;
            this.cmdNewDevice.Click += new System.EventHandler(this.cmdNewDevice_Click);
            // 
            // FrmDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 536);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDevice";
            this.Text = "FrmDevice";
            this.Load += new System.EventHandler(this.FrmDevice_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvRegion;
        private System.Windows.Forms.ListView lvDevices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdDelRegion;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdNewDevice;
        private System.Windows.Forms.ColumnHeader clIndex;
        private System.Windows.Forms.ColumnHeader clRegion;
        private System.Windows.Forms.ColumnHeader clDeviceID;
        private System.Windows.Forms.ColumnHeader clState;
    }
}