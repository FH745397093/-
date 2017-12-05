using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 区域管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegion_Click(object sender, EventArgs e)
        {
            if(panelForms.Controls.Count>0)
            {
                Form subform = panelForms.Controls[0] as Form;
                if (subform.Name == "FrmRegion")
                    return;
                panelForms.Controls.Remove(subform);
                subform.Close();
            }

            FrmRegion fregion = new FrmRegion();
            fregion.TopLevel = false;
            fregion.Dock = DockStyle.Fill;
            fregion.Visible = true;
            panelForms.Controls.Add(fregion);
        }

        /// <summary>
        /// 设备管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDevice_Click(object sender, EventArgs e)
        {
            if (panelForms.Controls.Count > 0)
            {
                Form subform = panelForms.Controls[0] as Form;
                if (subform.Name == "FrmDevice")
                    return;
                panelForms.Controls.Remove(subform);
                subform.Close();
            }

            FrmDevice fdevice = new FrmDevice();
            fdevice.TopLevel = false;
            fdevice.Dock = DockStyle.Fill;
            fdevice.Visible = true;
            panelForms.Controls.Add(fdevice);
        }

        /// <summary>
        /// 数据管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnData_Click(object sender, EventArgs e)
        {
            if (panelForms.Controls.Count > 0)
            {
                Form subform = panelForms.Controls[0] as Form;
                if (subform.Name == "FrmData")
                    return;
                panelForms.Controls.Remove(subform);
                subform.Close();
            }

            FrmData fdata = new FrmData();
            fdata.TopLevel = false;
            fdata.Dock = DockStyle.Fill;
            fdata.Visible = true;
            panelForms.Controls.Add(fdata);
        }

        /// <summary>
        /// 日志管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLog_Click(object sender, EventArgs e)
        {
            if (panelForms.Controls.Count > 0)
            {
                Form subform = panelForms.Controls[0] as Form;
                if (subform.Name == "FrmLog")
                    return;
                panelForms.Controls.Remove(subform);
                subform.Close();
            }

            FrmLog flog = new FrmLog();
            flog.TopLevel = false;
            flog.Dock = DockStyle.Fill;
            flog.Visible = true;
            panelForms.Controls.Add(flog);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("确定退出管理工具吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            FrmSample fsa = new FrmSample();
            fsa.ShowDialog();
        }
    }
}
