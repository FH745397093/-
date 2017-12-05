using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BSTool
{
    public partial class FrmSample : Form
    {

        private List<List<KCT_CASE_INFO>> dic;

        public FrmSample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dlgFile.Title = "请选择正确格式的基站数据文件";
            dlgFile.Filter = "CSV文件|*.csv";
            DialogResult dr = dlgFile.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                txtfile.Text = dlgFile.FileName;
            }
        }

        public Boolean checkInput()
        {
            string inv_no = txtKCH.Text.Trim();
            string filePath = txtfile.Text.Trim();
            string deviceid = txtUUID.Text.Trim();
            string xkuser=txtuser.Text.Trim();
            string xkpass = txtpass.Text.Trim();

            if (xkuser == null || xkuser.Equals(""))
            {
                MessageBox.Show("请输入现勘用户名");
                return false;
            }
            else if (xkpass == null || xkpass.Equals(""))
            {
                MessageBox.Show("请输入现勘密码");
                return false;
            }
            else if (deviceid == null || deviceid.Equals(""))
            {
                MessageBox.Show("请输入设备编号");
                return false;
            }
            else if (inv_no == null || inv_no.Equals(""))
            {
                MessageBox.Show("请输入勘验号");
                return false;
            }
            else if (filePath == null || filePath.Equals(""))
            {
                MessageBox.Show("请选择CSV数据文件");
                return false;
            }
            else if(!File.Exists(filePath))
            {
                MessageBox.Show("请确认CSV数据文件存在");
                return false;
            }
            else
            {
                return true;
            }
        }

        public XmlDocument createXml(string kid, string username, string password, string kct_uuid)
        {
            DataTable dt = CSVFileHelper.OpenCSV(txtfile.Text.Trim());
            List<KCT_CASE_INFO> kctList = CSVFileHelper.ToKctList(dt);
            dic = CSVFileHelper.Group(kctList);
            XmlDocument xmlStr = CSVFileHelper.CreateXml(dic, kid, username, password, kct_uuid);
            
            return xmlStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(checkInput())
            {
                string inv_no = txtKCH.Text.Trim();
                string filePath = txtfile.Text.Trim();
                string deviceid = txtUUID.Text.Trim();
                string xkuser = txtuser.Text.Trim();
                string xkpass = Tool.GetMD5(txtpass.Text.Trim());

                string xml = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" +
                            @"<REQUEST>
                                <SERVICESKEY> 111 </SERVICESKEY >
                                <APPKEY> 222 </APPKEY >
                                <PARAMS>
                                    <KID> " + inv_no + @" </KID>
                                    <KCT_UUID> " + deviceid + @" </KCT_UUID>
                                    <USERNAME> " + xkuser + @" </USERNAME>
                                    <PASSWORD> " + xkpass + @" </PASSWORD>
                                </PARAMS>
                            </REQUEST>";

                string checkOraclexml = HttpService.HttpPostXML(Program.ServerRoot + "CheckKCT.do", xml);
                XmlDocument xmlDoc1 = new XmlDocument();
                xmlDoc1.LoadXml(checkOraclexml);
                XmlNode rootNode1 = xmlDoc1.SelectSingleNode("response");
                XmlNodeList datas1 = rootNode1.ChildNodes[0].ChildNodes;
                string returnMessage = datas1[0].InnerText;
                if (returnMessage == "解密失败")
                {
                    MessageBox.Show("解密失败");
                    return;
                }
                else if (returnMessage == "此设备已超出使用范围")
                {
                    MessageBox.Show("此设备已超出使用范围");
                    return;
                }
                else if (returnMessage == "用户名或密码错误")
                {
                    MessageBox.Show("用户名或密码错误！");
                    return;
                }
                else if (returnMessage == "此设备没有权限")
                {
                    MessageBox.Show("此设备没有权限");
                    return;
                }
                else if (returnMessage == "您输入的k号不存在")
                {
                    MessageBox.Show("您输入的k号不存在");
                    return;
                }


                XmlDocument xmldoc = createXml(inv_no, xkuser, xkpass, deviceid);
                if (xmldoc != null)
                {
                    //最后将转换后的数据按地址（GPS）为依据逐个作为这个K号的多个记录导入
                    string path = Application.StartupPath + "\\data.xml";
                    xmldoc.Save(path);

                    Program.LastError = "";
                    
                    string xmlStr = HttpService.HttpPost(Program.ServerRoot + "AddKCT.do", xmldoc);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlStr);
                    XmlNode rootNode = xmlDoc.SelectSingleNode("response");
                    XmlNodeList datas = rootNode.ChildNodes[0].ChildNodes;
                    returnMessage = datas[0].InnerText;
                    if (returnMessage == "解密失败")
                    {
                        MessageBox.Show("解密失败");
                    }
                    else if (returnMessage == "此设备已超出使用范围")
                    {
                        MessageBox.Show("此设备已超出使用范围");
                    }
                    else if (returnMessage == "用户名或密码错误")
                    {
                        MessageBox.Show("用户名或密码错误！");
                    }
                    else if (returnMessage == "此设备没有权限")
                    {
                        MessageBox.Show("此设备没有权限");
                    }
                    else if (returnMessage == "您输入的k号不存在")
                    {
                        MessageBox.Show("您输入的k号不存在");
                    }
                    else
                    {
                        if (returnMessage == "success")
                        {
                            MessageBox.Show("导入完成!");
                        }
                        else
                        {
                            MessageBox.Show("导入失败!");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("XML文件生成失败");
                }
            }
        }


    }
}
