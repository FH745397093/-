using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OracleClient;
using System.Data.Odbc;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Net;
using System.Xml;

namespace BSTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List< List<KCT_CASE_INFO>> dic;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择正确格式的基站数据文件";
            openFileDialog1.Filter = "CSV文件|*.csv";
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        //生成XML文件
        public XmlDocument createXml(string kid,string username,string password,string kct_uuid)
        {
            DataTable dt = CSVFileHelper.OpenCSV(textBox1.Text);
            List<KCT_CASE_INFO> kctList = CSVFileHelper.ToKctList(dt);
            dic = CSVFileHelper.Group(kctList);
            XmlDocument xmlStr = CSVFileHelper.CreateXml(dic, kid, username, password, kct_uuid);
                if(xmlStr==null){
                Console.WriteLine("f1null");
                }else{
                Console.WriteLine("f1ookokok");
                }
            return xmlStr;
          //  return CSVFileHelper.CreateXml(dic, "K3101150000002011080064", "admin", "d54335949bd2b7f43bca357350e164ed", "52813100500148620140730230647098");
            //if (a)
            //{
            //    //MessageBox.Show("XML文件已生成！");
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //string oracleIp = textBox3.Text.Trim();
            string oracleSid = textBox4.Text.Trim();
            string oracleName = textBox5.Text.Trim();
            string oraclePwd = textBox6.Text.Trim();
            string windowsB = comboBox1.Text.Trim();
            //先测试数据库配置是否可工作
            int isOK=checkOracleConn(oracleSid, oracleName, oraclePwd);
            if (isOK > 0)
            {
                //再根据选择的版本好去查对应的数据库是否有2.0的数据表来验证选择是否正确
                if (windowsB.Equals("2.0版本"))
                {
                    if (!isTwo())
                    {
                        MessageBox.Show("系统版本选择有误！");
                    }
                    else
                    {
                        MessageBox.Show("检测成功！");
                    }
                }
                else
                {
                    if (isSupport())
                        MessageBox.Show("检测成功！");
                    else
                        MessageBox.Show("该版本数据库还不支持基站信息！");
                }
            }
            else
            {
                MessageBox.Show("连接数据库失败，请检查以下情况\r\n" + "1、本机是否已安装ORACLE客户端?\r\n" + "2、您的现勘库配置信息有误?", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        //检测是否是2.0版本
        public Boolean isTwo()
        {
            string oracleSid = textBox4.Text.Trim();
            string oracleName = textBox5.Text.Trim();
            string oraclePwd = textBox6.Text.Trim();
            string constring = "Data Source=" + oracleSid + ";Persist Security Info=True;User ID=" + oracleName + ";Password=" + oraclePwd + ";Unicode=True";
            DBHelperORACLE doo = new DBHelperORACLE(constring);
            string sql = "select count(*) from user_tables where table_name = 'DZWZSB_DN'"; //电子物证设备_电脑表
            Object c = doo.execScalar(sql);
            int count = int.Parse(c.ToString());
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //检测是否是2.0版本
        public Boolean isSupport()
        {
            string oracleSid = textBox4.Text.Trim();
            string oracleName = textBox5.Text.Trim();
            string oraclePwd = textBox6.Text.Trim();
            string constring = "Data Source=" + oracleSid + ";Persist Security Info=True;User ID=" + oracleName + ";Password=" + oraclePwd + ";Unicode=True";
            DBHelperORACLE doo = new DBHelperORACLE(constring);
            string sql = "select count(*) from user_tables where table_name like 'KCT%'";
            Object c = doo.execScalar(sql);
            int count = int.Parse(c.ToString());
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //测试数据库连接是否可用
        public int checkOracleConn(string oracleSid, string oracleName, string oraclePwd)
        {
            string constring = "Data Source=" + oracleSid + ";Persist Security Info=True;User ID=" + oracleName + ";Password=" + oraclePwd + ";Unicode=True";
            DBHelperORACLE doo = new DBHelperORACLE(constring);
            try
            {
                doo.openConn();
                return 1;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }

        //检查k号是否存在
        //public Boolean checkKno(string Kno) {
        //    string oracleSid = textBox4.Text.Trim();
        //    string oracleName = textBox5.Text.Trim();
        //    string oraclePwd = textBox6.Text.Trim();
        //    string constring = "Data Source=" + oracleSid + ";Persist Security Info=True;User ID=" + oracleName + ";Password=" + oraclePwd + ";Unicode=True";
        //    DBHelperORACLE doo = new DBHelperORACLE(constring);
        //    string sql = "select count(*) from scene_investigation where INVESTIGATION_NO='"+Kno+"'";
        //    Object c = doo.execScalar(sql);
        //    int count = int.Parse(c.ToString());
        //    if (count > 0)
        //    {
        //        return true;
        //    }
        //    else {
        //        return false;
        //    }
        //}
        private void button2_Click(object sender, EventArgs e)
        {
           if(checkInput()){
               //先检查数据库配置是否正确
               string inv_no = textBox2.Text.Trim();
               //string oracleSid = textBox4.Text.Trim();
               //string oracleName = textBox5.Text.Trim();
               //string oraclePwd = textBox6.Text.Trim();
               // string aa = HttpService.HttpPost("http://localhost:8080/BSINFO/manager/selectKid.do?inv_no=" + inv_no,"");
               //if (aa=="Yes")
               //{
               //再检查文件是否真实存在并可正确读取
                  
                       if (File.Exists(textBox1.Text))
                       {
                //if (checkCaseInfo(inv_no))
                //{
                //尝试转换对应的文件
                           XmlDocument xmldoc = createXml(inv_no, "admin", "456c2e75fe0faa57fd1cfd87117e0963", "52813100500148620140730230647098");
                        
                           if (xmldoc!=null)
                               {
                             //最后将转换后的数据按地址（GPS）为依据逐个作为这个K号的多个记录导入
                             string path = Application.StartupPath + "\\data.xml";
                             byte[] data;
                             FileStream fs = File.OpenRead(path);
                             data = new byte[fs.Length];
                             fs.Read(data, 0, Convert.ToInt32(fs.Length));
                             fs.Close();
                             Program.LastError = "";
                             string checkOraclexml = HttpService.HttpPost1("http://localhost:8080/BSINFO/CheckDB.do");
                             Console.WriteLine("TTTT" + checkOraclexml);
                             XmlDocument xmlDoc1 = new XmlDocument();
                             xmlDoc1.LoadXml(checkOraclexml);
                             XmlNode rootNode1 = xmlDoc1.SelectSingleNode("response");
                             XmlNodeList datas1 = rootNode1.ChildNodes[0].ChildNodes;
                             string checkOracle =datas1[0].InnerText;
                              if (checkOracle == "目标库验证通过")
                              {
                                  Console.WriteLine("oracleok");
                                  string xmlStr = HttpService.HttpPost("http://localhost:8080/BSINFO/AddKCT.do", xmldoc);
                                  XmlDocument xmlDoc = new XmlDocument();
                                  xmlDoc.LoadXml(xmlStr);
                                  XmlNode rootNode = xmlDoc.SelectSingleNode("response");
                                  XmlNodeList datas = rootNode.ChildNodes[0].ChildNodes;
                                  string returnMessage = datas[0].InnerText;
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
                              else if(checkOracle==""){
                                  MessageBox.Show("");
                              }
                              else if (checkOracle == "")
                              {
                                  MessageBox.Show("");
                              }
                              else { 
                              
                              }
                             Console.WriteLine("oracle"+checkOracle);
                        
                           }
                           else
                           {
                               MessageBox.Show("XML文件生成失败");
                           }
                       }
                       else
                       {
                           MessageBox.Show("文件不存在！");
                       }
               
           }
           
        }
    
       //检查数据是否输入
        public Boolean checkInput() {
            //string oracleIp = textBox3.Text.Trim();
            string oracleSid = textBox4.Text.Trim();
            string oracleName = textBox5.Text.Trim();
            string oraclePwd = textBox6.Text.Trim();
            string windowsB = comboBox1.Text.Trim();
            string inv_no = textBox2.Text.Trim();
            string filePath = textBox1.Text.Trim();
            
            if (oracleSid == null || oracleSid.Equals("")) {
                MessageBox.Show("请输入数据库SID!");
                return false;
            }
            else if (oracleName == null || oracleName.Equals(""))
            {
                MessageBox.Show("请输入数据库用户名!");
                return false;
            }
            else if (oraclePwd == null || oraclePwd.Equals(""))
            {
                MessageBox.Show("请输入数据库密码!");
                return false;
            }
            else if (windowsB == null || windowsB.Equals(""))
            {
                MessageBox.Show("请选择数据库版本!");
                return false;
            }
            else if (inv_no == null || inv_no.Equals(""))
            {
                MessageBox.Show("请输入勘验号");
                return false;
            }else if(filePath==null||filePath.Equals("")){
                MessageBox.Show("请选择文件");
                return false;
            }
            else {
                return true;
            }
        }

        //检查K好在case_info中有数据
        public Boolean checkCaseInfo(string  kno) {
            string oracleSid = textBox4.Text.Trim();
            string oracleName = textBox5.Text.Trim();
            string oraclePwd = textBox6.Text.Trim();
            string constring = "Data Source=" + oracleSid + ";Persist Security Info=True;User ID=" + oracleName + ";Password=" + oraclePwd + ";Unicode=True";
            DBHelperORACLE doo = new DBHelperORACLE(constring);
            string sql = "select count(id)  from xcky.kct_case_info where kct_uuid = '52813100500148620140730230647098' and investigation_id =(select id from xcky.scene_investigation where investigation_no = '"+kno+"')";
            Object c = doo.execScalar(sql);
            int count = int.Parse(c.ToString());
            if (count > 0)
            {
                return false; ;
            }
            else
            {
                return true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        
        
    }
}
