namespace BSTool
{
    partial class FrmLog
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("省级");
            this.lvLogs = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvRegion = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBiaoti = new System.Windows.Forms.Label();
            this.cboOPType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLogs
            // 
            this.lvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLogs.Location = new System.Drawing.Point(0, 0);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(572, 369);
            this.lvLogs.TabIndex = 5;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
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
            this.splitContainer1.Panel2.Controls.Add(this.lvLogs);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(864, 523);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvRegion
            // 
            this.tvRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRegion.Location = new System.Drawing.Point(0, 0);
            this.tvRegion.Name = "tvRegion";
            treeNode1.Name = "nroot";
            treeNode1.Text = "省级";
            this.tvRegion.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvRegion.Size = new System.Drawing.Size(288, 523);
            this.tvRegion.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdSearch);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboOPType);
            this.panel1.Controls.Add(this.lblBiaoti);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 154);
            this.panel1.TabIndex = 4;
            // 
            // lblBiaoti
            // 
            this.lblBiaoti.AutoSize = true;
            this.lblBiaoti.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBiaoti.Location = new System.Drawing.Point(17, 14);
            this.lblBiaoti.Name = "lblBiaoti";
            this.lblBiaoti.Size = new System.Drawing.Size(80, 16);
            this.lblBiaoti.TabIndex = 0;
            this.lblBiaoti.Text = "操作类型:";
            // 
            // cboOPType
            // 
            this.cboOPType.FormattingEnabled = true;
            this.cboOPType.Location = new System.Drawing.Point(112, 14);
            this.cboOPType.Name = "cboOPType";
            this.cboOPType.Size = new System.Drawing.Size(188, 20);
            this.cboOPType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "操作日期:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(338, 49);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(188, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(306, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(33, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "关键字:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(414, 21);
            this.textBox1.TabIndex = 7;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(112, 115);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 32);
            this.cmdSearch.TabIndex = 8;
            this.cmdSearch.Text = "搜索日志";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // FrmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 523);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLog";
            this.Text = "FrmLog";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLogs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvRegion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOPType;
        private System.Windows.Forms.Label lblBiaoti;
    }
}