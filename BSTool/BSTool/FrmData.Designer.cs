namespace BSTool
{
    partial class FrmData
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
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lvDatas = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvRegion = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOPType = new System.Windows.Forms.ComboBox();
            this.lblBiaoti = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(112, 115);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 32);
            this.cmdSearch.TabIndex = 8;
            this.cmdSearch.Text = "搜索数据";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // lvDatas
            // 
            this.lvDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDatas.Location = new System.Drawing.Point(0, 0);
            this.lvDatas.Name = "lvDatas";
            this.lvDatas.Size = new System.Drawing.Size(542, 381);
            this.lvDatas.TabIndex = 5;
            this.lvDatas.UseCompatibleStateImageBehavior = false;
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
            this.splitContainer1.Panel2.Controls.Add(this.lvDatas);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(818, 535);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 3;
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
            this.tvRegion.Size = new System.Drawing.Size(272, 535);
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
            this.panel1.Location = new System.Drawing.Point(0, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 154);
            this.panel1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(414, 21);
            this.textBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(33, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "设备ID:";
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
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(338, 49);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(188, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "上传日期:";
            // 
            // cboOPType
            // 
            this.cboOPType.FormattingEnabled = true;
            this.cboOPType.Location = new System.Drawing.Point(112, 14);
            this.cboOPType.Name = "cboOPType";
            this.cboOPType.Size = new System.Drawing.Size(188, 20);
            this.cboOPType.TabIndex = 1;
            // 
            // lblBiaoti
            // 
            this.lblBiaoti.AutoSize = true;
            this.lblBiaoti.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBiaoti.Location = new System.Drawing.Point(17, 14);
            this.lblBiaoti.Name = "lblBiaoti";
            this.lblBiaoti.Size = new System.Drawing.Size(80, 16);
            this.lblBiaoti.TabIndex = 0;
            this.lblBiaoti.Text = "筛选类型:";
            // 
            // FrmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 535);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmData";
            this.Text = "FrmData";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ListView lvDatas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvRegion;
        private System.Windows.Forms.Panel panel1;
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