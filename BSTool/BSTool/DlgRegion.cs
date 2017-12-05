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
    public partial class DlgRegion : Form
    {
        public string oregion;
        public string oip;
        public string oport;
        public string osid;
        public string ouser;
        public string opass;

        public DlgRegion()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //先做检查
            if (txtRegion.Text.Trim().Length != 6 || !Tool.IsInt(txtRegion.Text.Trim()))
            { 
                MessageBox.Show("请输入6位数字行政区划");
                return;
            }

            if (!Tool.IsIp(txtOIP.Text.Trim()))
            {
                MessageBox.Show("请输入正确格式的IP地址");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtOPort.Text.Trim()))
            {
                MessageBox.Show("请输入端口号");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtOSID.Text.Trim()))
            {
                MessageBox.Show("请输入SID");
                return;
            }

            if(String.IsNullOrWhiteSpace(txtOUser.Text.Trim()))
            {
                MessageBox.Show("请输入用户名");
                return;
            }

            if(String.IsNullOrWhiteSpace(txtOPass.Text.Trim()))
            {
                MessageBox.Show("请输入密码");
                return;
            }

            oregion = txtRegion.Text.Trim();
            oip = txtOIP.Text.Trim();
            oport = txtOPort.Text.Trim();
            osid = txtOSID.Text.Trim();
            ouser = txtOUser.Text.Trim();
            opass = txtOPass.Text.Trim();

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void DlgRegion_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(oport))
                txtOPort.Text = "1521";//默认值
            else
                txtOPort.Text = oport.Trim();

            if (String.IsNullOrWhiteSpace(ouser))
                txtOUser.Text = "xcky";//默认值
            else
                txtOUser.Text = ouser.Trim();

            if (String.IsNullOrWhiteSpace(opass))
                txtOPass.Text = "xcky";//默认值
            else
                txtOPass.Text = opass.Trim();

            if (!String.IsNullOrWhiteSpace(oregion))
                txtRegion.Text = oregion;

            if (!String.IsNullOrWhiteSpace(oip))
                txtOIP.Text = oip;

            if (!String.IsNullOrWhiteSpace(osid))
                txtOSID.Text = osid;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}

