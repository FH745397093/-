using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BSTool
{
    public partial class FrmRegion : Form
    {
        public FrmRegion()
        {
            InitializeComponent();
        }

        private void tvRegion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level>0)
            {
                lvRegion.Items.Clear(); //先清除所有列表
                string xml ="<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                            @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <OREGION> "+ e.Node.Tag + @" </OREGION>
                                </PARAMS>
                            </REQUEST>";
                string ret = HttpService.HttpPostXML(Program.ServerRoot+ "/Region/DBManager.do", xml);
                JArray list = JsonConvert.DeserializeObject(ret) as JArray;
                if(list.Count>0)
                {
                    for(int i=0;i< list.Count;i++)
                    {
                        ListViewItem lvi = lvRegion.Items.Add(i + 1.ToString());
                        lvi.SubItems.Add(list[i]["oregion"].ToString());
                        lvi.SubItems.Add(list[i]["oip"].ToString());
                        lvi.SubItems.Add(list[i]["oport"].ToString());
                        lvi.SubItems.Add(list[i]["osid"].ToString());
                        lvi.SubItems.Add(list[i]["ouser"].ToString());
                        lvi.SubItems.Add(list[i]["opass"].ToString());
                    }
                }
            }
        }

        private void FrmRegion_Load(object sender, EventArgs e)
        {
            Tool.InitRegions(tvRegion);
        }


        private void EditRegion(ListViewItem lvi)
        {
            DlgRegion dregion = new DlgRegion();
            if(lvi!=null)
            {
                dregion.oregion = lvi.SubItems[1].Text;
                dregion.oip = lvi.SubItems[2].Text;
                dregion.oport = lvi.SubItems[3].Text;
                dregion.osid = lvi.SubItems[4].Text;
                dregion.ouser = lvi.SubItems[5].Text;
                dregion.opass = lvi.SubItems[6].Text;
            }
            DialogResult dr = dregion.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                string xml = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                            @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <OREGION> " + dregion.oregion + @" </OREGION>
                                    <OIP> " + dregion.oip + @" </OIP>
                                    <OPORT> " + dregion.oport + @" </OPORT>
                                    <OSID> " + dregion.osid + @" </OSID>
                                    <OUSER> " + dregion.ouser + @" </OUSER>
                                    <OPASS> " + dregion.opass + @" </OPASS>
                                </PARAMS>
                            </REQUEST>";
                string ret = HttpService.HttpPostXML(Program.ServerRoot + "/Region/DBUpdate.do", xml);
                if (ret.Contains("影响行数：1"))
                    MessageBox.Show("编辑成功！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("发生异常错误，请联系开发人员！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdNewRegion_Click(object sender, EventArgs e)
        {
            EditRegion(null);
        }

        private void cmdTestServer_Click(object sender, EventArgs e)
        {
            if (lvRegion.SelectedItems.Count==0)
            {
                MessageBox.Show("请先选择要测试的服务器!");          
                return;
            }

            ListViewItem lvi = lvRegion.SelectedItems[0];

            string xml = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                            @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <OREGION> " + lvi.SubItems[1].Text + @" </OREGION>
                                    <OIP> " + lvi.SubItems[2].Text + @" </OIP>
                                    <OPORT> " + lvi.SubItems[3].Text + @" </OPORT>
                                    <OSID> " + lvi.SubItems[4].Text + @" </OSID>
                                    <OUSER> " + lvi.SubItems[5].Text + @" </OUSER>
                                    <OPASS> " + lvi.SubItems[6].Text + @" </OPASS>
                                </PARAMS>
                            </REQUEST>";
            string ret = HttpService.HttpPostXML(Program.ServerRoot + "/Region/CheckDB.do", xml);
            if (ret.Contains("目标数据库连接失败"))
                MessageBox.Show("数据库连接失败，请检查配置是否正确！"," 提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
            else if(ret.Contains("目标库缺少数据表"))
                MessageBox.Show("数据库缺少相关表，请使用数据库工具进行详细确认！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ret.Contains("目标库数据表缺少字段"))
                MessageBox.Show("数据库表结构异常，请使用数据库工具进行详细确认！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ret.Contains("目标库验证通过"))
                MessageBox.Show("目标库验证通过！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            else
                MessageBox.Show("发生异常错误，请联系开发人员！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            if (lvRegion.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择要修改的服务器!");
                return;
            }

            EditRegion(lvRegion.SelectedItems[0]);
        }

        private void lvRegion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRegion.SelectedItems.Count == 0)
            {
                return;
            }

            EditRegion(lvRegion.SelectedItems[0]);
        }

        private void cmdDelRegion_Click(object sender, EventArgs e)
        {
            if (lvRegion.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择要删除的服务器!");
                return;
            }

            string xml = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                             @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <OREGION> " + lvRegion.SelectedItems[0].SubItems[1].Text + @" </OREGION>
                                  </PARAMS>
                            </REQUEST>";
            string ret = HttpService.HttpPostXML(Program.ServerRoot + "/Region/DBDel.do", xml);
            if (ret.Contains("影响行数：1"))
                MessageBox.Show("删除成功！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("发生异常错误，请联系开发人员！", " 提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
