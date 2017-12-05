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
    public partial class FrmManager : Form
    {
        public FrmManager()
        {
            InitializeComponent();
        }
        public static string connStr = "Server=192.168.1.177;Database=bsinfo;Uid=root;Pwd=cmrxcmrx";
        MySqlDB mysql = new MySqlDB(connStr);
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox1.Text==null){
                MessageBox.Show("请填写数据库所在区域");
            }else if(textBox2.Text==""||textBox2.Text==null){
                MessageBox.Show("请填写ip");
            }else if(textBox3.Text==""||textBox3.Text==null){
                MessageBox.Show("请填写SID");
            }
            else if (textBox4.Text == "" || textBox4.Text == null)
            {
                MessageBox.Show("请填写用户名");
            }
            else if (textBox5.Text == "" || textBox5.Text == null)
            {
                MessageBox.Show("请填写密码");
            }
            else {
                string addKctDB = "insert into kctdestdb(oip,oport,osid,oregion,ouser,opass) values('" + textBox2.Text + "','1521','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                int num = mysql.execSqlREF(addKctDB);
                if (num > 0)
                {
                    MessageBox.Show("添加成功");
                    lvOracle.Items.Clear();
                    refreshListview1();

                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
     
        }
        public void refreshListview2() {
            string selectDevice = "select * from device";
            DataSet ds = mysql.getDataSet(selectDevice);
            List<Device> deviceList = new List<Device>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Device dc = new Device();
                dc.Id = (int)ds.Tables[0].Rows[i][0];
                dc.Uuid = ds.Tables[0].Rows[i][1].ToString();
                Console.WriteLine("ssss"+ds.Tables[0].Rows[i][2]);
                dc.State = (int)ds.Tables[0].Rows[i][2];
                dc.Createtime = (DateTime)ds.Tables[0].Rows[i][3];
                dc.Region = ds.Tables[0].Rows[i][4].ToString();
                deviceList.Add(dc);
            }
            Console.WriteLine(deviceList.Count);

            for (int i = 0; i < deviceList.Count; i++)
            {
                //lvDevice.Items.Add(new ListViewItem(deviceList[i]));
                ListViewItem lvi = lvDevice.Items.Add(deviceList[i].Id.ToString());
                lvi.SubItems.Add(deviceList[i].Uuid);
                if (deviceList[i].State == 1)
                {
                    lvi.SubItems.Add("已授权");
                }
                else {
                    lvi.SubItems.Add("未授权");
                }
               // lvi.SubItems.Add(deviceList[i].State.ToString());
                lvi.SubItems.Add(deviceList[i].Createtime.ToString());
                lvi.SubItems.Add(deviceList[i].Region);
            }
        }
        public void refreshListview1()
        {
            string selectKctDB = "select * from kctdestdb";
            DataSet KctDBDataSet = mysql.getDataSet(selectKctDB);
            List<Kctdestdb> kctDB = new List<Kctdestdb>();
            for (int i = 0; i < KctDBDataSet.Tables[0].Rows.Count; i++)
            {
                Kctdestdb kd = new Kctdestdb();
                kd.Oid = (int)KctDBDataSet.Tables[0].Rows[i][0];
                kd.Oip = KctDBDataSet.Tables[0].Rows[i][1].ToString();
                kd.Oport = KctDBDataSet.Tables[0].Rows[i][2].ToString();
                kd.Osid = KctDBDataSet.Tables[0].Rows[i][3].ToString();
                kd.Oregion = KctDBDataSet.Tables[0].Rows[i][4].ToString();
                kd.Ouser = KctDBDataSet.Tables[0].Rows[i][5].ToString();
                kd.Opass = KctDBDataSet.Tables[0].Rows[i][6].ToString();
                
                kctDB.Add(kd);
            }
            Console.WriteLine(kctDB.Count);

            for (int i = 0; i < kctDB.Count; i++)
            {
                //lvDevice.Items.Add(new ListViewItem(deviceList[i]));
                ListViewItem lvi =lvOracle.Items.Add(kctDB[i].Oid.ToString());
                lvi.SubItems.Add(kctDB[i].Oregion);
                lvi.SubItems.Add(kctDB[i].Oip.ToString());
                lvi.SubItems.Add(kctDB[i].Oport.ToString());
                lvi.SubItems.Add(kctDB[i].Osid);
                lvi.SubItems.Add(kctDB[i].Ouser);
                lvi.SubItems.Add(kctDB[i].Opass);

            }
        }
        private void FrmManager_Load(object sender, EventArgs e)
        {
            refreshListview2();
            refreshListview1();
        }

        private void 修改_Click(object sender, EventArgs e)
        {
            string a=lvOracle.SelectedItems[0].SubItems[0].Text;
            string deleteOracleDB = "delete from kctdestdb where oid="+a;
            int num = mysql.execSqlREF(deleteOracleDB);
            if (num > 0)
            {
                MessageBox.Show("删除成功");
                lvOracle.Items.Clear();
                refreshListview1();
            }
            else {
                MessageBox.Show("删除失败");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox6.Text == null)
            {
                MessageBox.Show("请输入设备编号");
            }
            else if (textBox7.Text == "" || textBox7.Text == null)
            {
                MessageBox.Show("请输入设备所属区域");
            }
            else {
               
                string checkUuid = "select count(*) from device where uuid=" + textBox6.Text;
                int nums = int.Parse(mysql.execScalar(checkUuid).ToString());
                if (nums > 0)
                {
                    MessageBox.Show("请勿重复添加同一设备");
                }
                else {
                    string addDevice = "insert into device(uuid,state,createtime,region)values('" + textBox6.Text.Trim() + "',1,NOW(),'" + textBox7.Text.Trim() + "')";
                    Console.WriteLine("sql" + addDevice);
                    int num = mysql.execSqlREF(addDevice);
                    if (num > 0)
                    {
                        MessageBox.Show("授权成功");
                        textBox6.Text = "";
                        textBox7.Text = "";
                        lvDevice.Items.Clear();
                        refreshListview2();
                    }
                    else
                    {
                        MessageBox.Show("授权失败");
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
                string a = lvDevice.SelectedItems[0].SubItems[0].Text;
                string state = lvDevice.SelectedItems[0].SubItems[2].Text;
                string updateDevice = "";
                if (state == "未授权")
                {
                    updateDevice = "update device set state=1 where id=" + a;
                }
                else {
                    updateDevice = "update device set state=-1 where id=" + a; ;
                }
                Console.WriteLine(updateDevice);
                int num = mysql.execSqlREF(updateDevice);
                if (num > 0)
                {
                    if (state == "未授权")
                    {
                        MessageBox.Show("授权成功");
                        lvDevice.Items.Clear();
                        refreshListview2();
                    }
                    else { 
                        MessageBox.Show("取消授权成功");
                        lvDevice.Items.Clear();
                        refreshListview2();
                    }
                  
                }
                else
                {
                    MessageBox.Show("操作失败");
                }
           
          
        }

        private void lvOracle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
