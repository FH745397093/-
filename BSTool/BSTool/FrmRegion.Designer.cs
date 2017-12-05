namespace BSTool
{
    partial class FrmRegion
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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("省级");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvRegion = new System.Windows.Forms.TreeView();
            this.lvRegion = new System.Windows.Forms.ListView();
            this.clindex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clregion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clport = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clsid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cluser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clpass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdTestServer = new System.Windows.Forms.Button();
            this.cmdDelRegion = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdNewRegion = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel2.Controls.Add(this.lvRegion);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(843, 527);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvRegion
            // 
            this.tvRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRegion.Location = new System.Drawing.Point(0, 0);
            this.tvRegion.Name = "tvRegion";
            treeNode4.Name = "nroot";
            treeNode4.Text = "省级";
            this.tvRegion.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvRegion.Size = new System.Drawing.Size(281, 527);
            this.tvRegion.TabIndex = 0;
            this.tvRegion.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRegion_AfterSelect);
            // 
            // lvRegion
            // 
            this.lvRegion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clindex,
            this.clregion,
            this.clip,
            this.clport,
            this.clsid,
            this.cluser,
            this.clpass});
            this.lvRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRegion.FullRowSelect = true;
            this.lvRegion.HideSelection = false;
            this.lvRegion.Location = new System.Drawing.Point(0, 0);
            this.lvRegion.Name = "lvRegion";
            this.lvRegion.Size = new System.Drawing.Size(558, 490);
            this.lvRegion.TabIndex = 5;
            this.lvRegion.UseCompatibleStateImageBehavior = false;
            this.lvRegion.View = System.Windows.Forms.View.Details;
            this.lvRegion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvRegion_MouseDoubleClick);
            // 
            // clindex
            // 
            this.clindex.Text = "序号";
            this.clindex.Width = 40;
            // 
            // clregion
            // 
            this.clregion.Text = "区域行政区划";
            this.clregion.Width = 100;
            // 
            // clip
            // 
            this.clip.Text = "OracleIP";
            this.clip.Width = 120;
            // 
            // clport
            // 
            this.clport.Text = "Oracle端口";
            this.clport.Width = 100;
            // 
            // clsid
            // 
            this.clsid.Text = "OracleSID";
            this.clsid.Width = 100;
            // 
            // cluser
            // 
            this.cluser.Text = "Oracle用户";
            this.cluser.Width = 100;
            // 
            // clpass
            // 
            this.clpass.Text = "Oracle密码";
            this.clpass.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdTestServer);
            this.panel1.Controls.Add(this.cmdDelRegion);
            this.panel1.Controls.Add(this.cmdModify);
            this.panel1.Controls.Add(this.cmdNewRegion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 37);
            this.panel1.TabIndex = 4;
            // 
            // cmdTestServer
            // 
            this.cmdTestServer.Location = new System.Drawing.Point(434, 3);
            this.cmdTestServer.Name = "cmdTestServer";
            this.cmdTestServer.Size = new System.Drawing.Size(121, 29);
            this.cmdTestServer.TabIndex = 7;
            this.cmdTestServer.Text = "测试区域服务器";
            this.cmdTestServer.UseVisualStyleBackColor = true;
            this.cmdTestServer.Click += new System.EventHandler(this.cmdTestServer_Click);
            // 
            // cmdDelRegion
            // 
            this.cmdDelRegion.Location = new System.Drawing.Point(266, 3);
            this.cmdDelRegion.Name = "cmdDelRegion";
            this.cmdDelRegion.Size = new System.Drawing.Size(121, 29);
            this.cmdDelRegion.TabIndex = 6;
            this.cmdDelRegion.Text = "删除区域";
            this.cmdDelRegion.UseVisualStyleBackColor = true;
            this.cmdDelRegion.Click += new System.EventHandler(this.cmdDelRegion_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.Location = new System.Drawing.Point(139, 3);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(121, 29);
            this.cmdModify.TabIndex = 5;
            this.cmdModify.Text = "修改区域";
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdNewRegion
            // 
            this.cmdNewRegion.Location = new System.Drawing.Point(12, 3);
            this.cmdNewRegion.Name = "cmdNewRegion";
            this.cmdNewRegion.Size = new System.Drawing.Size(121, 29);
            this.cmdNewRegion.TabIndex = 4;
            this.cmdNewRegion.Text = "新增区域";
            this.cmdNewRegion.UseVisualStyleBackColor = true;
            this.cmdNewRegion.Click += new System.EventHandler(this.cmdNewRegion_Click);
            // 
            // FrmRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 527);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegion";
            this.Text = "FrmRegion";
            this.Load += new System.EventHandler(this.FrmRegion_Load);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdDelRegion;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdNewRegion;
        private System.Windows.Forms.ListView lvRegion;
        private System.Windows.Forms.Button cmdTestServer;
        private System.Windows.Forms.ColumnHeader clindex;
        private System.Windows.Forms.ColumnHeader clregion;
        private System.Windows.Forms.ColumnHeader clip;
        private System.Windows.Forms.ColumnHeader clport;
        private System.Windows.Forms.ColumnHeader clsid;
        private System.Windows.Forms.ColumnHeader cluser;
        private System.Windows.Forms.ColumnHeader clpass;
    }
}