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
namespace BSTool
{
    public partial class prompt : Form
    {
        public prompt()
        {
            InitializeComponent();
        }
        public string csvPath = "";
        public string inv_no = "";
        public string oracleSid = "";
        public string oracleName = "";
        public string oraclePwd = "";
        List<List<KCT_CASE_INFO>> dic;
        //生成XML文件
        public Boolean createXml()
        {
            DataTable dt = CSVFileHelper.OpenCSV(csvPath);
            List<KCT_CASE_INFO> kctList = CSVFileHelper.ToKctList(dt);
            dic = CSVFileHelper.Group(kctList);
            Boolean a = false;// CSVFileHelper.CreateXml(dic);
            if (a)
            {
                //MessageBox.Show("XML文件已生成！");
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
            catch (Exception )
            {
                return -1;
                throw;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            string constring = "Data Source=" + oracleSid + ";Persist Security Info=True;User ID=" + oracleName + ";Password=" + oraclePwd + ";Unicode=True";
            DBHelperORACLE doo = new DBHelperORACLE(constring);
            doo.openConn();
          
            Boolean createXmlOk = createXml();
            if (createXmlOk)
            {
              
                DataTable dt = CSVFileHelper.OpenCSV(csvPath);
                List<KCT_CASE_INFO> kctList = CSVFileHelper.ToKctList(dt);
                dic = CSVFileHelper.Group(kctList);
                Boolean updateOk = CSVFileHelper.update(dic, inv_no, constring);
                string path = Application.StartupPath + "\\data.xml";
               
                byte[] data;
                FileStream fs = File.OpenRead(path);
                data = new byte[fs.Length];
                fs.Read(data, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                Boolean XmlisOk = CSVFileHelper.InsertXml(inv_no, data, doo);
                if (updateOk && XmlisOk)
                {
                    MessageBox.Show("更新成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("更新失败！");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("XML文件生成失败");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=" + oracleSid + ";Persist Security Info=True;User ID=" + oracleName + ";Password=" + oraclePwd + ";Unicode=True";
            DBHelperORACLE doo = new DBHelperORACLE(constring);
            //再尝试转换对应的文件
            Boolean createXmlOk = createXml();
            if (createXmlOk)
            {
                //最后将转换后的数据按地址（GPS）为依据逐个作为这个K号的多个记录导入
                string path = Application.StartupPath + "\\data.xml";
                byte[] data;
                FileStream fs = File.OpenRead(path);
                data = new byte[fs.Length];
                fs.Read(data, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                Program.LastError = "";
                DataTable dt = CSVFileHelper.OpenCSV(csvPath);
                List<KCT_CASE_INFO> kctList = CSVFileHelper.ToKctList(dt);
                dic = CSVFileHelper.Group(kctList);
                Boolean isOk = CSVFileHelper.insert(dic, inv_no, constring);
                Boolean XmlisOk = CSVFileHelper.InsertXml(inv_no, data, doo);
                if (isOk && XmlisOk)
                {
                    MessageBox.Show("导入完成！");
                    this.Close();
                }
                else
                {
                    if (!isOk && !XmlisOk)
                        MessageBox.Show("索引和数据均导入失败!\r\n" + Program.LastError);
                    else if (!isOk)
                        MessageBox.Show("索引导入失败!\r\n" + Program.LastError);
                    else
                        MessageBox.Show("数据均导入失败!\r\n" + Program.LastError);
                }
            }
            else
            {
                MessageBox.Show("XML文件生成失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}