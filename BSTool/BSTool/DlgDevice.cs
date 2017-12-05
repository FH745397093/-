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
    public partial class DlgDevice : Form
    {
        public string oregion;
        public string odeviceid;
        public string ostate;
        public DlgDevice()
        {
            InitializeComponent();
        }

        private void DlgDevice_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(ostate))
                cboState.Text = "授权使用";//默认值
            else
                cboState.Text = Tool.GetState(ostate);

            if (!String.IsNullOrWhiteSpace(oregion))
                txtRegion.Text = oregion;

            if (!String.IsNullOrWhiteSpace(odeviceid))
                txtDeviceID.Text = odeviceid;
        }


        private void cmdOK_Click(object sender, EventArgs e)
        {
            //先做检查
            if (txtRegion.Text.Trim().Length != 6 || !Tool.IsInt(txtRegion.Text.Trim()))
            {
                MessageBox.Show("请输入6位数字行政区划");
                return;
            }

            

            if (String.IsNullOrWhiteSpace(txtDeviceID.Text.Trim()))
            {
                MessageBox.Show("请输入设备编号");
                return;
            }

           

            oregion = txtRegion.Text.Trim();
            odeviceid = txtDeviceID.Text.Trim();
            ostate = Tool.GetStateValue(cboState.Text);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
