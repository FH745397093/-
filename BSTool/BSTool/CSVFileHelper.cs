using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Xml;
using System.Collections;
using System.Data.OracleClient;
using System.Windows.Forms;
namespace BSTool
{
    class CSVFileHelper
    {
        /*
         *将csv文件数据读取到DataTable
         */
        #region 将csv文件数据读取到DataTable
        public static DataTable OpenCSV(string filePath) {
           
        Encoding encoding = EncodingHelp.GetFileEncodeType(filePath);
        DataTable dt = new DataTable();
        FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        StreamReader sr = new StreamReader(fs, encoding);
        //记录每次读取的一行记录
        string strLine = "";
        //记录每行记录中的各字段内容
        string[] aryLine = null;
        string[] tableHead = null;
        //标示列数
        int columnCount = 0;
        //标示是否是读取的第一行
        //bool IsFirst = true;
        int rowcount = 0;
        //逐行读取CSV中的数据
        while ((strLine = sr.ReadLine()) != null)
        {
            if (strLine.Equals("") || strLine == null)
            {
                continue;
            }
            if (rowcount == 0)
            {
                rowcount++;
                tableHead = strLine.Split(',');
                columnCount = tableHead.Length;
                //创建列
                for (int i = 0; i < columnCount; i++)
                {
                    DataColumn dc = new DataColumn(tableHead[i]);
                    dt.Columns.Add(dc);
                }
            }
            else
            {
                aryLine = strLine.Split(',');
                DataRow dr = dt.NewRow();
                for (int j = 0; j < columnCount; j++)
                {
                    dr[j] = aryLine[j];
                }
                dt.Rows.Add(dr);
            }
        }

            if (aryLine != null && aryLine.Length > 0)
         {
             dt.DefaultView.Sort = tableHead[0] + " " + "asc";
         }
        
          sr.Close();
          fs.Close();
            return dt;
        }
        #endregion
        /*
         *将Datatable数据存入相应集合
         */
        #region 将Datatable数据存入相应集合
        public static  List<KCT_CASE_INFO> ToKctList(DataTable dataTable)
        {
           List<KCT_CASE_INFO> KctDic = new List<KCT_CASE_INFO>();
        //       dataTable.DefaultView.Sort="slong asc,slat asc";
            for(int i=0;i<dataTable.Rows.Count;i++){
                KCT_CASE_INFO kct = new KCT_CASE_INFO();
                kct.Cname = dataTable.Rows[i][0].ToString();
                kct.Cnid = dataTable.Rows[i][1].ToString();
                kct.Kyno = dataTable.Rows[i][2].ToString();
                kct.Jqno = dataTable.Rows[i][3].ToString();
                kct.Createuser = dataTable.Rows[i][4].ToString();
                kct.Lname = dataTable.Rows[i][5].ToString();
                kct.Lid = dataTable.Rows[i][6].ToString();
                kct.Lacsid = dataTable.Rows[i][7].ToString();
                kct.Cellidbid = dataTable.Rows[i][8].ToString();
                if (dataTable.Rows[i][9] != null && !dataTable.Rows[i][9].ToString().Equals(""))
                {
                    kct.Xhqd = dataTable.Rows[i][9].ToString();
                }
                else
                {
                    kct.Xhqd = "";
                }
                if (dataTable.Rows[i][10] != null && !dataTable.Rows[i][10].ToString().Equals(""))
                {
                    kct.Nid = dataTable.Rows[i][10].ToString();
                }
                else
                {
                    kct.Nid = "";
                }
                if (dataTable.Rows[i][11] != null && !dataTable.Rows[i][11].ToString().Equals(""))
                {
                    kct.Yystype = dataTable.Rows[i][11].ToString();
                }
                else
                {
                    kct.Yystype = "";
                }
                kct.Xhtype = dataTable.Rows[i][12].ToString();
                kct.Isms = dataTable.Rows[i][13].ToString();
                kct.Slong = dataTable.Rows[i][14].ToString();
                kct.Slat = dataTable.Rows[i][15].ToString();
                kct.Cdate = dataTable.Rows[i][16].ToString();
                if (dataTable.Rows[i][17] != null && !dataTable.Rows[i][17].ToString().Equals(""))
                {
                    kct.Mlac = dataTable.Rows[i][17].ToString();
                }
                else
                {
                    kct.Mlac = "";
                }

                if (dataTable.Rows[i][18] != null && !dataTable.Rows[i][18].ToString().Equals(""))
                {
                    kct.Mcell = dataTable.Rows[i][18].ToString();
                }
                else
                {
                    kct.Mcell = "";
                }
                kct.Hlac = dataTable.Rows[i][19].ToString();
                kct.Hcell = dataTable.Rows[i][20].ToString();
                if (dataTable.Rows[i][21] != null && !dataTable.Rows[i][21].ToString().Equals(""))
                {
                    kct.Bzinfo = dataTable.Rows[i][21].ToString();
                }
                else
                {
                    kct.Bzinfo = "";
                }
                kct.No3 = dataTable.Rows[i][22].ToString();
                kct.No4 = dataTable.Rows[i][23].ToString();
                kct.Islastgps = dataTable.Rows[i][24].ToString();
                kct.Baidujd = dataTable.Rows[i][25].ToString();
                kct.Baiduwd = dataTable.Rows[i][26].ToString();
                if (dataTable.Rows[i][27] != null && !dataTable.Rows[i][27].ToString().Equals(""))
                {
                    kct.Cellidlong = dataTable.Rows[i][27].ToString();
                }
                else
                {
                    kct.Cellidlong = "";
                }
                kct.Bztype = dataTable.Rows[i][28].ToString();
                KctDic.Add(kct);
            }
            return KctDic;
        }
        #endregion
        /*
         *将集合的值进行分类
         */
        #region 将集合的值进行分类
        public static List<List<KCT_CASE_INFO>> Group(List<KCT_CASE_INFO> KctDic)
        {
            List<List<KCT_CASE_INFO>> kctList = new List<List<KCT_CASE_INFO>>();
            Dictionary<string, List<KCT_CASE_INFO>> stuGroup = new Dictionary<string, List<KCT_CASE_INFO>>();
            foreach (KCT_CASE_INFO item in KctDic)
            {
               
                if (!stuGroup.Keys.Contains(item.Slong + item.Slat))
                {
                    stuGroup.Add(item.Slong + item.Slat, new List<KCT_CASE_INFO>());
                }
                stuGroup[item.Slong + item.Slat].Add(item);
            }
           
            List<string> keys = new List<string>();
            foreach (string item in stuGroup.Keys) {
                keys.Add(item); 
            }
            for (int i = 0; i < keys.Count;i++ ) {
                kctList.Add(stuGroup[keys[i]]);
            }
        
            return kctList;
        }
        #endregion
        /*
         * 将数据生成XML文件
         */
        #region 将数据生成XML文件
        public static XmlDocument CreateXml(List<List<KCT_CASE_INFO>> KctList, string kid, string username, string password, string kct_uuid)
        {

            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点 
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", "");
            xmlDoc.AppendChild(node);
            XmlNode root1 = xmlDoc.CreateElement("REQUEST");
            xmlDoc.AppendChild(root1);
            XmlNode servicekey = xmlDoc.CreateElement("SERVICESKEY");
            servicekey.InnerText = "111";
            root1.AppendChild(servicekey);
            XmlNode appkey = xmlDoc.CreateElement("APPKEY");
            appkey.InnerText = "222";
            root1.AppendChild(appkey);

            //参数节点
            XmlNode paramss = xmlDoc.CreateElement("PARAMS");
            root1.AppendChild(paramss);

            XmlNode KID = xmlDoc.CreateElement("KID");
            KID.InnerText = kid;
            paramss.AppendChild(KID);
            XmlNode KCT_UUID = xmlDoc.CreateElement("KCT_UUID");
            KCT_UUID.InnerText = kct_uuid;
            paramss.AppendChild(KCT_UUID);
            XmlNode USERNAME = xmlDoc.CreateElement("USERNAME");
            USERNAME.InnerText = username;
            paramss.AppendChild(USERNAME);
            XmlNode PASSWOED = xmlDoc.CreateElement("PASSWORD");
            PASSWOED.InnerText = password;
            paramss.AppendChild(PASSWOED);
            XmlNode KCTS_VAL = xmlDoc.CreateElement("KCTS_VAL");
            for (int i = 0; i < KctList.Count; i++)
            {
                for (int j = 0; j < KctList[i].Count; j++)
                {
                    XmlNode KCT_VAL = xmlDoc.CreateElement("KCT_VAL");
                    XmlNode CNAME = xmlDoc.CreateElement("CNAME");
                    CNAME.InnerText = KctList[i][j].Cname;
                    KCT_VAL.AppendChild(CNAME);
                    XmlNode CNID = xmlDoc.CreateElement("CNID");
                    CNID.InnerText = KctList[i][j].Cnid;
                    KCT_VAL.AppendChild(CNID);
                    XmlNode KYNO = xmlDoc.CreateElement("KYNO");
                    KYNO.InnerText = KctList[i][j].Kyno;
                    KCT_VAL.AppendChild(KYNO);
                    XmlNode JQNO = xmlDoc.CreateElement("JQNO");
                    JQNO.InnerText = KctList[i][j].Jqno;
                    KCT_VAL.AppendChild(JQNO);
                    XmlNode CREATEUSER = xmlDoc.CreateElement("CREATEUSER");
                    CREATEUSER.InnerText = KctList[i][j].Createuser;
                    KCT_VAL.AppendChild(CREATEUSER);
                    XmlNode LNAME = xmlDoc.CreateElement("LNAME");
                    LNAME.InnerText = KctList[i][j].Lname;
                    KCT_VAL.AppendChild(LNAME);
                    XmlNode LID = xmlDoc.CreateElement("LID");
                    LID.InnerText = KctList[i][j].Lid;
                    KCT_VAL.AppendChild(LID);
                    XmlNode LACSID = xmlDoc.CreateElement("LACSID");
                    LACSID.InnerText = KctList[i][j].Lacsid;
                    KCT_VAL.AppendChild(LACSID);
                    XmlNode CELLIDBID = xmlDoc.CreateElement("CELLIDBID");
                    CELLIDBID.InnerText = KctList[i][j].Cellidbid;
                    KCT_VAL.AppendChild(CELLIDBID);
                    XmlNode XHQD = xmlDoc.CreateElement("XHQD");
                    XHQD.InnerText = KctList[i][j].Xhqd;
                    KCT_VAL.AppendChild(XHQD);
                    XmlNode NID = xmlDoc.CreateElement("NID");
                    NID.InnerText = KctList[i][j].Nid;
                    KCT_VAL.AppendChild(NID);
                    XmlNode YYSTYPE = xmlDoc.CreateElement("YYSTYPE");
                    YYSTYPE.InnerText = KctList[i][j].Yystype;
                    KCT_VAL.AppendChild(YYSTYPE);
                    XmlNode XHTYPE = xmlDoc.CreateElement("XHTYPE");
                    XHTYPE.InnerText = KctList[i][j].Xhtype;
                    KCT_VAL.AppendChild(XHTYPE);
                    XmlNode ISMS = xmlDoc.CreateElement("ISMS");
                    ISMS.InnerText = KctList[i][j].Isms;
                    KCT_VAL.AppendChild(ISMS);
                    XmlNode SLONG = xmlDoc.CreateElement("SLONG");
                    SLONG.InnerText = KctList[i][j].Slong;
                    KCT_VAL.AppendChild(SLONG);
                    XmlNode SLAT = xmlDoc.CreateElement("SLAT");
                    SLAT.InnerText = KctList[i][j].Slat;
                    KCT_VAL.AppendChild(SLAT);
                    XmlNode CDATE = xmlDoc.CreateElement("CDATE");
                    CDATE.InnerText = KctList[i][j].Cdate;
                    KCT_VAL.AppendChild(CDATE);
                    XmlNode MLAC = xmlDoc.CreateElement("MLAC");
                    MLAC.InnerText = KctList[i][j].Mlac;
                    KCT_VAL.AppendChild(MLAC);
                    XmlNode MCELL = xmlDoc.CreateElement("MCELL");
                    MCELL.InnerText = KctList[i][j].Mcell;
                    KCT_VAL.AppendChild(MCELL);
                    XmlNode HLAC = xmlDoc.CreateElement("HLAC");
                    HLAC.InnerText = KctList[i][j].Hlac;
                    KCT_VAL.AppendChild(HLAC);
                    XmlNode HCELL = xmlDoc.CreateElement("HCELL");
                    HCELL.InnerText = KctList[i][j].Hcell;
                    KCT_VAL.AppendChild(HCELL);
                    XmlNode BZINFO = xmlDoc.CreateElement("BZINFO");
                    BZINFO.InnerText = KctList[i][j].Bzinfo.Replace(">", "@MDZZ@");
                    KCT_VAL.AppendChild(BZINFO);
                    XmlNode NO3 = xmlDoc.CreateElement("NO3");
                    NO3.InnerText = KctList[i][j].No3;
                    KCT_VAL.AppendChild(NO3);
                    XmlNode NO4 = xmlDoc.CreateElement("NO4");
                    NO4.InnerText = KctList[i][j].No4;
                    KCT_VAL.AppendChild(NO4);
                    XmlNode ISLASTGPS = xmlDoc.CreateElement("ISLASTGPS");
                    ISLASTGPS.InnerText = KctList[i][j].Islastgps;
                    KCT_VAL.AppendChild(ISLASTGPS);
                    XmlNode BAIDUJD = xmlDoc.CreateElement("BAIDUJD");
                    BAIDUJD.InnerText = KctList[i][j].Baidujd;
                    KCT_VAL.AppendChild(BAIDUJD);
                    XmlNode BAIDUWD = xmlDoc.CreateElement("BAIDUWD");
                    BAIDUWD.InnerText = KctList[i][j].Baiduwd;
                    KCT_VAL.AppendChild(BAIDUWD);
                    XmlNode CELLIDLONG = xmlDoc.CreateElement("CELLIDLONG");
                    CELLIDLONG.InnerText = KctList[i][j].Cellidlong;
                    KCT_VAL.AppendChild(CELLIDLONG);
                    XmlNode BZTYPE = xmlDoc.CreateElement("BZTYPE");
                    BZTYPE.InnerText = KctList[i][j].Bztype;
                    KCT_VAL.AppendChild(BZTYPE);
                    KCTS_VAL.AppendChild(KCT_VAL);
                }
            }
            paramss.AppendChild(KCTS_VAL);

            

            //创建根节点  
            XmlNode root = xmlDoc.CreateElement("BASESTATION");
            //xmlDoc.AppendChild(root);
            //子节点UUID
            //XmlNode UUID = xmlDoc.CreateNode(XmlNodeType.Element, "UUID", null);
            //UUID.InnerText = "52813100500148620140730230647098";
            //root.AppendChild(UUID);
            ////开始时间
            //XmlNode STARTTIMEs = xmlDoc.CreateNode(XmlNodeType.Element, "STARTTIME", null);
            //STARTTIMEs.InnerText = KctList[0][0].Cdate;
            //root.AppendChild(STARTTIMEs);
            ////结束时间
            //XmlNode ENDTIMEs = xmlDoc.CreateNode(XmlNodeType.Element, "ENDTIME", null);
            //ENDTIMEs.InnerText = KctList[KctList.Count - 1][KctList[KctList.Count - 1].Count - 1].Cdate;
            //root.AppendChild(ENDTIMEs);
            ////子节点GPS
            //XmlNode GPS = xmlDoc.CreateNode(XmlNodeType.Element, "GPS", null);
            //XmlNode LOCATION = xmlDoc.CreateNode(XmlNodeType.Element, "LOCATION", null);
            //LOCATION.InnerText = KctList[0][0].Lname;
            //XmlNode LON = xmlDoc.CreateNode(XmlNodeType.Element, "LON", null);
            //LON.InnerText = KctList[0][0].Slong;
            //XmlNode LAT = xmlDoc.CreateNode(XmlNodeType.Element, "LAT", null);
            //LAT.InnerText = KctList[0][0].Slat;
            //GPS.AppendChild(LOCATION);
            //GPS.AppendChild(LON);
            //GPS.AppendChild(LAT);
            //root.AppendChild(GPS);
            for (int n = 0; n < KctList.Count; n++)
            {
                //子节点BS
                XmlNode BS = xmlDoc.CreateNode(XmlNodeType.Element, "BS", null);
                XmlNode LOCATIONs = xmlDoc.CreateNode(XmlNodeType.Element, "LOCATION", null);
                Console.WriteLine("坐标pp" + KctList[n][0].Lname + "(" + KctList[n][0].Slong + "," + KctList[n][0].Slat + ")");
                LOCATIONs.InnerText = KctList[n][0].Lname + "(" + KctList[n][0].Slong + "," + KctList[n][0].Slat+ ")";
                BS.AppendChild(LOCATIONs);
                XmlNode STARTTIME = xmlDoc.CreateNode(XmlNodeType.Element, "STARTTIME", null);
                STARTTIME.InnerText = KctList[n][0].Cdate;
                BS.AppendChild(STARTTIME);
                #region 区分
                //按照不同信息创建不同子节点
                List<KCT_CASE_INFO> CMCC_GSM = new List<KCT_CASE_INFO>();//移动2G
                List<KCT_CASE_INFO> TD_SCOMA = new List<KCT_CASE_INFO>();//移动3G
                List<KCT_CASE_INFO> CU_GSM = new List<KCT_CASE_INFO>();//联通2G
                List<KCT_CASE_INFO> WCDMA = new List<KCT_CASE_INFO>();//联通3G
                List<KCT_CASE_INFO> CDMA = new List<KCT_CASE_INFO>();//电信2G/3G  
                for (int i = 0; i < KctList[n].Count; i++)
                {
                    if ((KctList[n][i].Yystype + KctList[n][i].Xhtype).Equals("移动2"))
                    {

                        CMCC_GSM.Add(KctList[n][i]);
                    }
                    else if ((KctList[n][i].Yystype + KctList[n][i].Xhtype).Equals("移动3"))
                    {

                        TD_SCOMA.Add(KctList[n][i]);
                    }
                    else if ((KctList[n][i].Yystype + KctList[n][i].Xhtype).Equals("联通2"))
                    {
                        CU_GSM.Add(KctList[n][i]);
                    }
                    else if ((KctList[n][i].Yystype + KctList[n][i].Xhtype).Equals("联通3"))
                    {
                        WCDMA.Add(KctList[n][i]);
                    }
                    else if ((KctList[n][i].Yystype + KctList[n][i].Xhtype).Equals("电信2"))
                    {
                        CDMA.Add(KctList[n][i]);
                    }
                    else if ((KctList[n][i].Yystype + KctList[n][i].Xhtype).Equals("电信3"))
                    {
                        CDMA.Add(KctList[n][i]);
                    }
                }
                #endregion
                #region 电信2G/3G
                //电信节点
                XmlNode CDMAs = xmlDoc.CreateNode(XmlNodeType.Element, "CDMA", null);
                for (int i = 0; i < CDMA.Count; i++)
                {
                    if (i == 0)
                    {
                        XmlNode ACTIVE = xmlDoc.CreateNode(XmlNodeType.Element, "ACTIVE", null);
                        /* XmlNode REG_ZONE = xmlDoc.CreateNode(XmlNodeType.Element, "REG_ZONE", null);
                         REG_ZONE.InnerText = "772";
                         ACTIVE.AppendChild(REG_ZONE);
                         * */
                        XmlNode SID = xmlDoc.CreateNode(XmlNodeType.Element, "SID", null);
                        SID.InnerText = CDMA[i].Lacsid;
                        ACTIVE.AppendChild(SID);
                        XmlNode NID = xmlDoc.CreateNode(XmlNodeType.Element, "NID", null);
                        NID.InnerText = CDMA[i].Nid;
                        ACTIVE.AppendChild(NID);
                        XmlNode BASE_ID = xmlDoc.CreateNode(XmlNodeType.Element, "BASE_ID", null);
                        BASE_ID.InnerText = CDMA[i].Cellidbid;
                        ACTIVE.AppendChild(BASE_ID);
                        /*
                          XmlNode CDMA_CH = xmlDoc.CreateNode(XmlNodeType.Element, "CDMA_CH", null);
                         CDMA_CH.InnerText = "210";
                         ACTIVE.AppendChild(CDMA_CH);
                         XmlNode PN = xmlDoc.CreateNode(XmlNodeType.Element, "PN", null);
                         PN.InnerText = "26";
                         ACTIVE.AppendChild(PN);
                         */
                        CDMAs.AppendChild(ACTIVE);
                    }
                    else
                    {
                        XmlNode NEIGHBOR = xmlDoc.CreateNode(XmlNodeType.Element, "NEIGHBOR", null);
                        /* XmlNode REG_ZONE = xmlDoc.CreateNode(XmlNodeType.Element, "REG_ZONE", null);
                         REG_ZONE.InnerText = "772";
                         NEIGHBOR.AppendChild(REG_ZONE);
                         * */
                        XmlNode SID = xmlDoc.CreateNode(XmlNodeType.Element, "SID", null);
                        SID.InnerText = CDMA[i].Lacsid;
                        NEIGHBOR.AppendChild(SID);
                        XmlNode NID = xmlDoc.CreateNode(XmlNodeType.Element, "NID", null);
                        NID.InnerText = CDMA[i].Nid;
                        NEIGHBOR.AppendChild(NID);
                        XmlNode BASE_ID = xmlDoc.CreateNode(XmlNodeType.Element, "BASE_ID", null);
                        BASE_ID.InnerText = CDMA[i].Cellidbid;
                        NEIGHBOR.AppendChild(BASE_ID);
                        /*
                          XmlNode CDMA_CH = xmlDoc.CreateNode(XmlNodeType.Element, "CDMA_CH", null);
                         CDMA_CH.InnerText = "201";
                         NEIGHBOR.AppendChild(CDMA_CH);
                         XmlNode PN = xmlDoc.CreateNode(XmlNodeType.Element, "PN", null);
                         PN.InnerText = "394";
                         NEIGHBOR.AppendChild(PN);
                         */
                        CDMAs.AppendChild(NEIGHBOR);
                    }
                }
                for (int i = 0; i < CDMA.Count; i++)
                {
                    XmlNode PILOT_SETS = xmlDoc.CreateNode(XmlNodeType.Element, "PILOT_SETS", null);
                    XmlNode PN = xmlDoc.CreateNode(XmlNodeType.Element, "PN", null);
                    PN.InnerText = CDMA[i].Xhqd;
                    PILOT_SETS.AppendChild(PN);
                    XmlNode SETS_TYPE = xmlDoc.CreateNode(XmlNodeType.Element, "SETS_TYPE", null);
                    SETS_TYPE.InnerText = "Neighbor";
                    PILOT_SETS.AppendChild(SETS_TYPE);
                    XmlNode STRENGTH = xmlDoc.CreateNode(XmlNodeType.Element, "STRENGTH", null);
                    STRENGTH.InnerText = CDMA[i].Xhqd;
                    PILOT_SETS.AppendChild(STRENGTH);
                    CDMAs.AppendChild(PILOT_SETS);
                }
                BS.AppendChild(CDMAs);
                #endregion
                #region 移动2G
                //移动2G节点
                XmlNode CMCC_GSMs = xmlDoc.CreateNode(XmlNodeType.Element, "CMCC_GSM", null);
                for (int i = 0; i < CMCC_GSM.Count; i++)
                {
                    if (i == 0)
                    {
                        XmlNode ACTIVE = xmlDoc.CreateNode(XmlNodeType.Element, "ACTIVE", null);
                        /* XmlNode MCC_MNC = xmlDoc.CreateNode(XmlNodeType.Element, "MCC-MNC", null);
                         MCC_MNC.InnerText = "460-00";
                         ACTIVE.AppendChild(MCC_MNC);*/
                        XmlNode LAC = xmlDoc.CreateNode(XmlNodeType.Element, "LAC", null);
                        LAC.InnerText = CMCC_GSM[i].Lacsid;
                        ACTIVE.AppendChild(LAC);
                        XmlNode CELL_ID = xmlDoc.CreateNode(XmlNodeType.Element, "CELL_ID", null);
                        CELL_ID.InnerText = CMCC_GSM[i].Cellidbid;
                        ACTIVE.AppendChild(CELL_ID);
                        /*  XmlNode BCCH = xmlDoc.CreateNode(XmlNodeType.Element, "BCCH", null);
                          BCCH.InnerText = "245";
                          ACTIVE.AppendChild(BCCH);
                          XmlNode BSIC = xmlDoc.CreateNode(XmlNodeType.Element, "BSIC", null);
                          BSIC.InnerText = "61";
                          ACTIVE.AppendChild(BSIC);
                          XmlNode RSSI = xmlDoc.CreateNode(XmlNodeType.Element, "RSSI", null);
                          RSSI.InnerText = "16";
                          ACTIVE.AppendChild(RSSI);*/
                        CMCC_GSMs.AppendChild(ACTIVE);
                    }
                    else
                    {

                        XmlNode NEIGHBOR = xmlDoc.CreateNode(XmlNodeType.Element, "NEIGHBOR", null);
                        /*  XmlNode MCC_MNC = xmlDoc.CreateNode(XmlNodeType.Element, "MCC-MNC", null);
                          MCC_MNC.InnerText = "460-00";
                          NEIGHBOR.AppendChild(MCC_MNC);*/
                        XmlNode LAC = xmlDoc.CreateNode(XmlNodeType.Element, "LAC", null);
                        LAC.InnerText = CMCC_GSM[i].Lacsid;
                        NEIGHBOR.AppendChild(LAC);
                        XmlNode CELL_ID = xmlDoc.CreateNode(XmlNodeType.Element, "CELL_ID", null);
                        CELL_ID.InnerText = CMCC_GSM[i].Cellidbid;
                        NEIGHBOR.AppendChild(CELL_ID);
                        /*  XmlNode BCCH = xmlDoc.CreateNode(XmlNodeType.Element, "BCCH", null);
                          BCCH.InnerText = "245";
                          NEIGHBOR.AppendChild(BCCH);
                          XmlNode BSIC = xmlDoc.CreateNode(XmlNodeType.Element, "BSIC", null);
                          BSIC.InnerText = "61";
                          NEIGHBOR.AppendChild(BSIC);
                          XmlNode RSSI = xmlDoc.CreateNode(XmlNodeType.Element, "RSSI", null);
                          RSSI.InnerText = "16";
                          NEIGHBOR.AppendChild(RSSI);*/
                        CMCC_GSMs.AppendChild(NEIGHBOR);
                    }
                }
                BS.AppendChild(CMCC_GSMs);
                #endregion
                #region 联通3G
                XmlNode WCDMAs = xmlDoc.CreateNode(XmlNodeType.Element, "WCDMA", null);
                for (int i = 0; i < WCDMA.Count; i++)
                {
                    if (i == 0)
                    {
                        XmlNode ACTIVE = xmlDoc.CreateNode(XmlNodeType.Element, "ACTIVE", null);
                        XmlNode LAC = xmlDoc.CreateNode(XmlNodeType.Element, "LAC", null);
                        LAC.InnerText = WCDMA[i].Lacsid;
                        ACTIVE.AppendChild(LAC);
                        XmlNode CELL_ID = xmlDoc.CreateNode(XmlNodeType.Element, "CELL_ID", null);
                        CELL_ID.InnerText = WCDMA[i].Cellidbid;
                        ACTIVE.AppendChild(CELL_ID);
                        /*
                        XmlNode RNCID = xmlDoc.CreateNode(XmlNodeType.Element, "RNCID", null);
                        RNCID.InnerText = "10713";
                        ACTIVE.AppendChild(RNCID);
                        XmlNode RSSI = xmlDoc.CreateNode(XmlNodeType.Element, "RSSI", null);
                        RSSI.InnerText = "10713";
                        ACTIVE.AppendChild(RSSI);
                         * */
                        WCDMAs.AppendChild(ACTIVE);
                    }
                    else
                    {
                        XmlNode NEIGHBOR = xmlDoc.CreateNode(XmlNodeType.Element, "NEIGHBOR", null);
                        XmlNode MCC_MNC = xmlDoc.CreateNode(XmlNodeType.Element, "MCC-MNC", null);
                        MCC_MNC.InnerText = WCDMA[i].Lacsid;
                        NEIGHBOR.AppendChild(MCC_MNC);
                        XmlNode PSC = xmlDoc.CreateNode(XmlNodeType.Element, "PSC", null);
                        PSC.InnerText = "";
                        NEIGHBOR.AppendChild(PSC);
                        XmlNode UARFCN = xmlDoc.CreateNode(XmlNodeType.Element, "UARFCN", null);
                        UARFCN.InnerText = WCDMA[i].Mcell;
                        NEIGHBOR.AppendChild(UARFCN);
                        WCDMAs.AppendChild(NEIGHBOR);
                    }
                }
                BS.AppendChild(WCDMAs);
                #endregion
                #region 联通2G
                //联通2G节点
                XmlNode CU_GSMs = xmlDoc.CreateNode(XmlNodeType.Element, "CU_GSM", null);
                for (int i = 0; i < CU_GSM.Count; i++)
                {
                    if (i == 0)
                    {
                        XmlNode ACTIVE = xmlDoc.CreateNode(XmlNodeType.Element, "ACTIVE", null);
                        XmlNode MCC_MNC = xmlDoc.CreateNode(XmlNodeType.Element, "MCC-MNC", null);
                        MCC_MNC.InnerText = "";
                        ACTIVE.AppendChild(MCC_MNC);
                        XmlNode LAC = xmlDoc.CreateNode(XmlNodeType.Element, "LAC", null);
                        LAC.InnerText = CU_GSM[i].Lacsid;
                        ACTIVE.AppendChild(LAC);
                        XmlNode CELL_ID = xmlDoc.CreateNode(XmlNodeType.Element, "CELL_ID", null);
                        CELL_ID.InnerText = CU_GSM[i].Cellidbid;
                        ACTIVE.AppendChild(CELL_ID);
                        /*
                        XmlNode BCCH = xmlDoc.CreateNode(XmlNodeType.Element, "BCCH", null);
                        BCCH.InnerText ="642";
                        ACTIVE.AppendChild(BCCH);
                        XmlNode SYS_BAND = xmlDoc.CreateNode(XmlNodeType.Element, "SYS_BAND", null);
                        SYS_BAND.InnerText = "3";
                        ACTIVE.AppendChild(SYS_BAND);
                        XmlNode BSIC = xmlDoc.CreateNode(XmlNodeType.Element, "BSIC", null);
                        BSIC.InnerText = "53";
                        ACTIVE.AppendChild(BSIC);
                        XmlNode RSSI = xmlDoc.CreateNode(XmlNodeType.Element, "RSSI", null);
                        RSSI.InnerText = "21";
                        ACTIVE.AppendChild(RSSI);*/
                        CU_GSMs.AppendChild(ACTIVE);
                    }
                    else
                    {
                        XmlNode NEIGHBOR = xmlDoc.CreateNode(XmlNodeType.Element, "NEIGHBOR", null);
                        /* XmlNode MCC_MNC = xmlDoc.CreateNode(XmlNodeType.Element, "MCC-MNC", null);
                         MCC_MNC.InnerText = "460-01";
                         NEIGHBOR.AppendChild(MCC_MNC);*/
                        XmlNode LAC = xmlDoc.CreateNode(XmlNodeType.Element, "LAC", null);
                        LAC.InnerText = CU_GSM[i].Lacsid;
                        NEIGHBOR.AppendChild(LAC);
                        XmlNode CELL_ID = xmlDoc.CreateNode(XmlNodeType.Element, "CELL_ID", null);
                        CELL_ID.InnerText = CU_GSM[i].Cellidbid;
                        NEIGHBOR.AppendChild(CELL_ID);
                        /*
                          XmlNode BCCH = xmlDoc.CreateNode(XmlNodeType.Element, "BCCH", null);
                          BCCH.InnerText = "642";
                          NEIGHBOR.AppendChild(BCCH);
                          XmlNode SYS_BAND = xmlDoc.CreateNode(XmlNodeType.Element, "SYS_BAND", null);
                          SYS_BAND.InnerText = "3";
                          NEIGHBOR.AppendChild(SYS_BAND);
                          XmlNode BSIC = xmlDoc.CreateNode(XmlNodeType.Element, "BSIC", null);
                          BSIC.InnerText = "53";
                          NEIGHBOR.AppendChild(BSIC);
                          XmlNode RSSI = xmlDoc.CreateNode(XmlNodeType.Element, "RSSI", null);
                          RSSI.InnerText = "21";
                          NEIGHBOR.AppendChild(RSSI);*/
                        CU_GSMs.AppendChild(NEIGHBOR);
                    }
                }
                BS.AppendChild(CU_GSMs);
                #endregion
                #region 移动3G
                XmlNode TD_SCOMAs = xmlDoc.CreateNode(XmlNodeType.Element, "TD_SCOMA", null);
                for (int i = 0; i < TD_SCOMA.Count; i++)
                {
                    if (i == 0)
                    {
                        XmlNode ACTIVE = xmlDoc.CreateNode(XmlNodeType.Element, "ACTIVE", null);
                        XmlNode LAC = xmlDoc.CreateNode(XmlNodeType.Element, "LAC", null);
                        LAC.InnerText = TD_SCOMA[i].Lacsid;
                        ACTIVE.AppendChild(LAC);
                        XmlNode CELL_ID = xmlDoc.CreateNode(XmlNodeType.Element, "CELL_ID", null);
                        CELL_ID.InnerText = TD_SCOMA[i].Cellidbid;
                        ACTIVE.AppendChild(CELL_ID);
                        TD_SCOMAs.AppendChild(ACTIVE);
                    }
                    else
                    {
                        XmlNode NEIGHBOR = xmlDoc.CreateNode(XmlNodeType.Element, "NEIGHBOR", null);
                        XmlNode LAC = xmlDoc.CreateNode(XmlNodeType.Element, "LAC", null);
                        LAC.InnerText = TD_SCOMA[i].Lacsid;
                        NEIGHBOR.AppendChild(LAC);
                        XmlNode CELL_ID = xmlDoc.CreateNode(XmlNodeType.Element, "CELL_ID", null);
                        CELL_ID.InnerText = TD_SCOMA[i].Cellidbid;
                        NEIGHBOR.AppendChild(CELL_ID);
                        TD_SCOMAs.AppendChild(NEIGHBOR);
                    }
                }
                BS.AppendChild(TD_SCOMAs);
                #endregion
                XmlNode ENDTIME = xmlDoc.CreateNode(XmlNodeType.Element, "ENDTIME", null);
                ENDTIME.InnerText = KctList[KctList.Count - 1][KctList[KctList.Count - 1].Count - 1].Cdate;
                BS.AppendChild(ENDTIME);
                root.AppendChild(BS);
                paramss.AppendChild(root);
            }
            if (xmlDoc == null)
            {
                Console.WriteLine("xmlnull");
            }
            else {
                Console.WriteLine("xmlnotnull");
            }
            return xmlDoc;

        }
        #endregion
        /*
         *替换
         */ 
        #region 替换
        public static Boolean update(List< List<KCT_CASE_INFO>> listKct, string inv_no,string conn){
            DBHelperORACLE db = new DBHelperORACLE(conn);
            int a = 0, b = 0, c = 0, d = 0;
            try
            {
                db.openConn();
                db.beginTrans();
                string updateCaseInfo = "update xcky.kct_case_info set CASE_ID=(select case_id from xcky.scene_investigation where investigation_no = '" + inv_no.Trim() + "'),KCT_UUID='52813100500148620140730230647098',CASE_START_TIME=(select investigation_date_from from xcky.scene_investigation where investigation_no = '" + inv_no.Trim() + "'),CASE_END_TIME=(select investigation_date_to from xcky.scene_investigation where investigation_no = '" + inv_no.Trim() + "'),CASE_LON='" + listKct[0][0] .Slong+ "',CASE_LAT='" + listKct[0][0].Slat + "',WITNESS_INFO='',REMARK='',CREATE_USER=(select create_user from xcky.scene_investigation where investigation_no = '" + inv_no + "'),CREATE_DATETIME=(select create_datetime from xcky.scene_investigation  where investigation_no = '" + inv_no + "'),UPDATE_USER='',UPDATE_DATETIME='',"
                + "RESERVER1='',RESERVER2='',RESERVER3='',RESERVER4='',RESERVER5='',RESERVER6='',RESERVER7='',RESERVER8='',GPS_NAME='',CASE_NAME='',INVESTIGATION_ID=(select id from xcky.scene_investigation where investigation_no = '" + inv_no.Trim() + "') where ID =(select ID from xcky.kct_case_info where kct_uuid = '52813100500148620140730230647098' and investigation_id =(select id from xcky.scene_investigation where investigation_no = '" + inv_no.Trim() + "') and  rownum=1)";
              Console.WriteLine("一" + updateCaseInfo);
                a = db.execSqlREF(updateCaseInfo);
            string updateloace = "update  xcky.kct_locale_data set LOCALE_NAME='" + listKct[0][0].Lname + "',COL_STARTTIME=sysdate,COL_ENDTIME=sysdate,CREATE_USER=(select create_user from xcky.scene_investigation where investigation_no = '" + inv_no + "'),CREATE_DATETIME=(select create_datetime from xcky.scene_investigation where investigation_no = '" + inv_no.Trim() + "'),UPDATE_USER='',UPDATE_DATETIME='',RESERVER1='',RESERVER2='',RESERVER3='',RESERVER4='',RESERVER5='',RESERVER6='',RESERVER7='',RESERVER8='',DATA_TYPE='1' where  ID =(select id from  xcky.kct_locale_data where case_info_id =(select ID from xcky.kct_case_info where kct_uuid = '52813100500148620140730230647098' and investigation_id =(select id from xcky.scene_investigation where investigation_no = '" + inv_no.Trim() + "') and  rownum=1) and rownum=1)";
                Console.WriteLine("二" + updateloace);
                b = db.execSqlREF(updateloace);
                string updateGsm = "update xcky.kct_basestation_data set BS_TYPE='CMCC_GSM',IFACTIVE='ACTIVE',REG_ZONE='',SID='" + listKct[0][0].Lacsid + "',NID='" + listKct[0][0].Nid + "',BASE_ID='',CDMA_CH='',PN='',STRENGTH='',MCC_MNC='',LAC='" + listKct[0][0].Mlac + "',CELL_ID='',BCCH='',BSIC='',SYS_BAND='',RESERVER1='',RESERVER2='',RESERVER3='',RESERVER4='',RESERVER5='',RESERVER6='',RESERVER7='',RESERVER8='',RESERVER9='',RESERVER10='',LON='" + listKct[0][0].Slong + "',LAT='" + listKct[0][0] .Slat+ "',COL_TIME=sysdate where LOCALE_DATA_ID =(select ID from xcky.kct_locale_data where case_info_id =(select id from xcky.kct_case_info where kct_uuid='52813100500148620140730230647098' and investigation_id=(select id"
                          + " from xcky.scene_investigation where investigation_no = '" + inv_no + "') and  rownum=1) and rownum=1) and BS_TYPE='CMCC_GSM'";
            Console.WriteLine("三" + updateGsm);
                c = db.execSqlREF(updateGsm);
            string insertCdma = "update xcky.kct_basestation_data set BS_TYPE='CDMA',IFACTIVE='ACTIVE',REG_ZONE='',SID='" + listKct[0][0].Lacsid + "',NID='" + listKct[0][0].Nid + "',BASE_ID='',CDMA_CH='',PN='',STRENGTH='',MCC_MNC='',LAC='" + listKct[0][0].Mlac + "',CELL_ID='',BCCH='',BSIC='',SYS_BAND='',RESERVER1='',RESERVER2='',RESERVER3='',RESERVER4='',RESERVER5='',RESERVER6='',RESERVER7='',RESERVER8='',RESERVER9='',RESERVER10='',LON='" + listKct[0][0].Slong + "',LAT='" + listKct[0][0] .Slat+ "',COL_TIME=sysdate where LOCALE_DATA_ID =(select ID from xcky.kct_locale_data where case_info_id =(select id from xcky.kct_case_info where kct_uuid='52813100500148620140730230647098' and investigation_id=(select id"
                          + " from xcky.scene_investigation where investigation_no = '" + inv_no + "') and  rownum=1) and rownum=1) and BS_TYPE='CDMA'";
              Console.WriteLine("四" + insertCdma);
              d = db.execSqlREF(insertCdma);
                db.commitTrans();
                db.closeConn();
            }
            catch (Exception ex)
            {
                 db.rollbackTrans();
                 Program.LastError = ex.Message;
                  return false;
                throw;
            }
            if (a > 0 && b > 0 && c > 0 && d > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /*
         *入库
         */
        #region 入库
        public static Boolean insert(List< List<KCT_CASE_INFO>> listKct, string inv_no,string conn)
        {
            DBHelperORACLE db = new DBHelperORACLE(conn);
          
            int a = 0, b = 0, c = 0, d = 0;
            try
            {
            db.openConn();
            db.beginTrans();
            string newcaseinfoid = Guid.NewGuid().ToString("N");   //代码产生新的CASEINFOID

            string insertCaseInfo = "insert into xcky.kct_case_info (ID,CASE_ID,KCT_UUID,CASE_START_TIME,CASE_END_TIME,CASE_LON,CASE_LAT,WITNESS_INFO,REMARK,CREATE_USER,CREATE_DATETIME,UPDATE_USER,UPDATE_DATETIME,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,GPS_NAME,CASE_NAME,INVESTIGATION_ID) values ('" + newcaseinfoid + "'," + " (select case_id from xcky.scene_investigation where investigation_no = '" + inv_no + "'), '" + "52813100500148620140730230647098" + "',"
                    + " to_date('" + listKct[0][0].Cdate + "','yyyy-MM-dd HH24:mi:ss')," + "to_date('" + listKct[listKct.Count - 1][listKct[listKct.Count - 1].Count - 1].Cdate + "','yyyy-MM-dd HH24:mi:ss'),"
                    + "'" + listKct[0][0].Slong + "','" + listKct[0][0].Slat+ "','','',(select create_user from xcky.scene_investigation where investigation_no = '" + inv_no + "')" + ",(select create_datetime from xcky.scene_investigation  where investigation_no = '" + inv_no + "')" + ",'','','','','','','','','','','','',"
                    + "(select id from xcky.scene_investigation where investigation_no = '"+ inv_no.Trim() +"'))";
                 d = db.execSqlREF(insertCaseInfo);

                 string insertloace = "insert into  xcky.kct_locale_data(ID,LOCALE_NAME,COL_STARTTIME,COL_ENDTIME,CREATE_USER,CREATE_DATETIME,UPDATE_USER,UPDATE_DATETIME,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,DATA_TYPE,CASE_INFO_ID) values(sys_guid(),'" + listKct[0][0].Lname + "',to_date('" + listKct[0][0].Cdate + "','yyyy-MM-dd HH24:mi:ss'),to_date('" + listKct[listKct.Count - 1][listKct[listKct.Count - 1].Count - 1].Cdate + "','yyyy-MM-dd HH24:mi:ss'),(select create_user from xcky.scene_investigation where investigation_no = '" + inv_no + "'),"
                          + "(select create_datetime from xcky.scene_investigation where investigation_no = '" + inv_no + "')," + "'','','','','','','','','','','1','" + newcaseinfoid + "')";
                      
                    a = db.execSqlREF(insertloace);
                    string insertGsm = "insert into xcky.kct_basestation_data (ID,BS_TYPE,IFACTIVE,REG_ZONE,SID,NID,BASE_ID,CDMA_CH,PN,STRENGTH,MCC_MNC,LAC,CELL_ID,BCCH,BSIC,SYS_BAND,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,RESERVER9,RESERVER10,LON,LAT,LOCALE_DATA_ID,COL_TIME)" + "values(sys_guid(),'CMCC_GSM','ACTIVE','','" + listKct[0][0].Lacsid + "','" + listKct[0][0].Nid + "','','','','-21','','13945','" + listKct[0][0].Mlac+ "','','','','','','','','','','','','','','','',(select ID from xcky.kct_locale_data where case_info_id='" + newcaseinfoid + "'),sysdate)";
                  b = db.execSqlREF(insertGsm);

                  string insertCdma = "insert into xcky.kct_basestation_data (ID,BS_TYPE,IFACTIVE,REG_ZONE,SID,NID,BASE_ID,CDMA_CH,PN,STRENGTH,MCC_MNC,LAC,CELL_ID,BCCH,BSIC,SYS_BAND,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,RESERVER9,RESERVER10,LON,LAT,LOCALE_DATA_ID,COL_TIME)" + "values(sys_guid(),'" + "CDMA" + "','ACTIVE','','" + listKct[0][0].Lacsid + "','" + listKct[0][0].Nid + "','110','','','-212','','','','','','','','','','','','','','','','','','',(select ID from xcky.kct_locale_data where case_info_id='" + newcaseinfoid + "'),sysdate)";
                      c = db.execSqlREF(insertCdma);
                   
                  db.commitTrans();
                  db.closeConn();
              }
              catch (Exception ex) 
              {
                  db.rollbackTrans();
                  Console.WriteLine("err"+ex.Message);
                  Program.LastError = ex.Message;
                  return false;
                  throw;
              }
                  if (a > 0 && b > 0 && c > 0 && d > 0)
                  {
                      return true;
                  }
                  else {
                      return false;
                  }
        }
       
        #endregion
        /*
         *插入XML
         */
        #region 插入XML
        public static  bool InsertXml(string inv_no, byte[] xmlbtytes, DBHelperORACLE db)
        {
            string sql = "insert into xcky.common_attachment values(sys_guid(),:xml,'data.xml','01','','',1,0,'设备',to_date('" +DateTime.Now.ToString()+ "','yyyy-MM-dd HH24:mi:ss')," + "'','',(select id from xcky.scene_investigation where investigation_no = '" + inv_no + "')," + "'','','','','','','')";
            OracleParameter[] p = new OracleParameter[] { new OracleParameter(":xml", xmlbtytes) };
            int rowsAffected = db.execSqlREF(sql, p);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
        #endregion
    }
}