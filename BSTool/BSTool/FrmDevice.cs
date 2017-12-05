using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FrmDevice : Form
    {
        public FrmDevice()
        {
            InitializeComponent();
        }

        private void tvRegion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level>0)
            {
                lvDevices.Items.Clear(); //先清除所有列表
                string xml = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                            @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <OREGION> " + e.Node.Tag + @" </OREGION>
                                </PARAMS>
                            </REQUEST>";
                string ret = HttpService.HttpPostXML(Program.ServerRoot + "/Device/DeviceList.do", xml);
                JArray list = JsonConvert.DeserializeObject(ret) as JArray;
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        ListViewItem lvi = lvDevices.Items.Add(i + 1.ToString());
                        lvi.SubItems.Add(list[i]["region"].ToString());
                        lvi.SubItems.Add(list[i]["uuid"].ToString());
                        lvi.SubItems.Add(Tool.GetState(list[i]["state"].ToString()));
                    }
                }
            }
        }

        private void EditDevice(ListViewItem lvi)
        {
            DlgDevice ddevice = new DlgDevice();
            if (lvi != null)
            {
                ddevice.oregion = lvi.SubItems[1].Text;
                ddevice.odeviceid = lvi.SubItems[2].Text;
                ddevice.ostate = Tool.GetStateValue(lvi.SubItems[3].Text);
            }
            DialogResult dr = ddevice.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                string xml = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                            @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <OREGION> " + ddevice.oregion + @" </OREGION>
                                    <ODEVICE> " + ddevice.odeviceid + @" </ODEVICE>
                                    <OSTATE> " + ddevice.ostate + @" </OSTATE>
                                </PARAMS>
                            </REQUEST>";
                string ret = HttpService.HttpPostXML(Program.ServerRoot + "/Device/DeviceAuth.do", xml);
                if (ret.Contains("影响行数：1"))
                    MessageBox.Show("编辑成功！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("发生异常错误，请联系开发人员！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdNewDevice_Click(object sender, EventArgs e)
        {
            EditDevice(null);
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            if (lvDevices.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择要修改的设备!");
                return;
            }

            EditDevice(lvDevices.SelectedItems[0]);
        }


        private void lvDevices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvDevices.SelectedItems.Count == 0)
            {
                return;
            }

            EditDevice(lvDevices.SelectedItems[0]);
        }

        private void FrmDevice_Load(object sender, EventArgs e)
        {
            Tool.InitRegions(tvRegion);
        }

        private void cmdDelRegion_Click(object sender, EventArgs e)
        {
            if (lvDevices.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择要删除的设备!");
                return;
            }

            string xml = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                             @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <OREGION> " + lvDevices.SelectedItems[0].SubItems[1].Text + @" </OREGION>
                                  </PARAMS>
                            </REQUEST>";
            string ret = HttpService.HttpPostXML(Program.ServerRoot + "/Device/DeviceDel.do", xml);
            if (ret.Contains("影响行数：1"))
                MessageBox.Show("删除成功！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("发生异常错误，请联系开发人员！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
