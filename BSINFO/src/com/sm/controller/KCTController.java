package com.sm.controller;

import java.io.IOException;
import java.io.InputStream;
import java.io.StringReader;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Properties;
import java.util.UUID;

import javax.servlet.http.HttpServletResponse;

import org.jdom.Document;
import org.jdom.Element;
import org.jdom.JDOMException;
import org.jdom.input.SAXBuilder;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.xml.sax.InputSource;

import com.sm.dao.impl.ErrorUtil;
import com.sm.dao.impl.JdbcOracleUtil;
import com.sm.dao.impl.JdbcMysqlUtil;
import com.sm.dao.impl.XmlUtil;
import com.sm.entity.KCT_CASE_INFO;

@Controller
public class KCTController {

	@RequestMapping(value = "CheckKCT.do", method = { RequestMethod.POST,RequestMethod.GET }, produces = "text/html;charset=UTF-8")
	@ResponseBody
	public String CheckKCT(@RequestBody String xmlStr,HttpServletResponse response) {
		response.setHeader("Access-Control-Allow-Origin", "*");
		response.setCharacterEncoding("utf-8");
		
		// 创建一个新的字符串
		StringReader read = new StringReader(xmlStr);
		// 创建新的输入源SAX 解析器将使用 InputSource 对象来确定如何读取 XML 输入
		InputSource source = new InputSource(read);
		SAXBuilder builder = new SAXBuilder();
		Document doc = null;
		try {
			doc = builder.build(source);
		} catch (JDOMException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		// Document doc = builder.build(new File("data_10k.xml"));
		Element foo = doc.getRootElement().getChild("PARAMS");
		String username = foo.getChild("USERNAME").getText().trim();
		String password = foo.getChild("PASSWORD").getText().trim();
		String Kct_UUID = foo.getChild("KCT_UUID").getText().trim();
		String kid  = foo.getChild("KID").getText().trim();
		
		InputStream is=this.getClass().getResourceAsStream("/mysql.properties");
	    Properties p = new Properties();
	        try {  
	            p.load(is);  
	            is.close();  
	        } catch (IOException e1) {  
	            e1.printStackTrace();  
	        }  
	        String mip=p.getProperty("ip");
	        String mport=p.getProperty("port");
	        String mdbname=p.getProperty("dbname");
	        String musername=p.getProperty("username");
	        String mpassword=p.getProperty("password");
	        JdbcMysqlUtil myutil =null;
		try {
			myutil = new JdbcMysqlUtil(mip,mport, mdbname,musername,mpassword);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			//e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.SetupError);
		}
		
		String selectUUID = "select region from device where UUID='"
				+ Kct_UUID + "' and state=1";
		List<Map<String, String>> count = null;
		int UUIDCount = 0;
		String region="";
		try {
			count = myutil.GetDBlistBySQL(selectUUID);
			UUIDCount = count.size();
			if (UUIDCount <= 0) {
				return XmlUtil.createReturnXmlStr(ErrorUtil.UUIDError);
			}
			else
			{		
				region=count.get(0).get("region");
				if(!kid.substring(1, 7).equals(region)){
					return XmlUtil.createReturnXmlStr(ErrorUtil.DeviceError);
				}
			}
			
		} catch (SQLException e1) {
			// TODO Auto-generated catch block
			count = null;
			e1.printStackTrace();
		}
		
		/**
		 * 通过region获取目标数据库信息
		 * */
		String oracleConn="select * from kctdestdb where oregion="+region;
		List<Map<String, String>> oracleConns=new ArrayList<Map<String,String>>();
		String oip="";
		String osid="";
		String ouser="";
		String opass="";
		try {
			oracleConns = myutil.GetDBlistBySQL(oracleConn);
			oip = oracleConns.get(0).get("oip");
			osid = oracleConns.get(0).get("osid");
			ouser = oracleConns.get(0).get("ouser");
			opass = oracleConns.get(0).get("opass");
		} catch (SQLException e1) {
			oracleConns=null;
			e1.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.GetOracleError);
		}
		/**
		 *  验证用户名密码是否存在
		 * */
		

		JdbcOracleUtil jdbcOracleUtil = null;
		try {
			jdbcOracleUtil = new JdbcOracleUtil(oip,osid,ouser,opass);
		} catch (Exception e2) {
			// TODO Auto-generated catch block
			e2.printStackTrace();
		}
		String selectuser = "select count(*) from sys_user where username='"
				+ username + "' and password='" + password + "'";
		int num = jdbcOracleUtil.jdbcselect(selectuser);
		if (num <= 0) {
			return XmlUtil.createReturnXmlStr(ErrorUtil.UserError);
		}
	
		/**
		 * 验证k号是否存在
		 * */
		String sql = "select count(*) from scene_investigation where INVESTIGATION_NO='"
				+ kid + "'";
		int selectKid = jdbcOracleUtil.jdbcselect(sql);
		if (selectKid <= 0) {
			return XmlUtil.createReturnXmlStr(ErrorUtil.KidError);
		}
		
		return XmlUtil.createReturnXmlStr(ErrorUtil.Success);
	}
	
	@RequestMapping(value = "AddKCT.do", method = { RequestMethod.POST,RequestMethod.GET }, produces = "text/html;charset=UTF-8")
	@ResponseBody
	public String AddKCT(@RequestBody String xmlStr,HttpServletResponse response) {
		response.setHeader("Access-Control-Allow-Origin", "*");
		response.setCharacterEncoding("utf-8");
		
		// 解析Xml的到用户名密码以及其他信息
		Map<String, Object> valMap = XmlUtil.xmlElements(xmlStr);
		/**
		 * 得到设备编号，并验证设备权限,以及此设备是否在规定区域使用
		 * */
		InputStream is=this.getClass().getResourceAsStream("/mysql.properties");
	    Properties p = new Properties();
	        try {  
	            p.load(is);  
	            is.close();  
	        } catch (IOException e1) {  
	            e1.printStackTrace();  
	        }  
	        String mip=p.getProperty("ip");
	        String mport=p.getProperty("port");
	        String mdbname=p.getProperty("dbname");
	        String musername=p.getProperty("username");
	        String mpassword=p.getProperty("password");
	        JdbcMysqlUtil myutil =null;
		try {
			myutil = new JdbcMysqlUtil(mip,mport, mdbname,musername,mpassword);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			//e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.SetupError);
		}
		
		String kid = valMap.get("kid").toString();
		String Kct_UUID = valMap.get("kct_uuid").toString();
		String selectUUID = "select region from device where UUID='"
				+ Kct_UUID + "' and state=1";
		List<Map<String, String>> count = null;
		int UUIDCount = 0;
		String region="";
		try {
			count = myutil.GetDBlistBySQL(selectUUID);
			UUIDCount = count.size();
			if (UUIDCount <= 0) {
				return XmlUtil.createReturnXmlStr(ErrorUtil.UUIDError);
			}
			else{
				region=count.get(0).get("region");
				if(!kid.substring(1, 7).equals(region)){
					return XmlUtil.createReturnXmlStr(ErrorUtil.DeviceError);
				}
			}
		} catch (SQLException e1) {
			// TODO Auto-generated catch block
			count = null;
			e1.printStackTrace();
		}
		/**
		 * 通过region获取目标数据库信息
		 * */
		String oracleConn="select * from kctdestdb where oregion="+region;
		List<Map<String, String>> oracleConns=new ArrayList<Map<String,String>>();
		String oip="";
		String osid="";
		String ouser="";
		String opass="";
		try {
			oracleConns = myutil.GetDBlistBySQL(oracleConn);
			oip = oracleConns.get(0).get("oip");
			osid = oracleConns.get(0).get("osid");
			ouser = oracleConns.get(0).get("ouser");
			opass = oracleConns.get(0).get("opass");
		} catch (SQLException e1) {
			oracleConns=null;
			e1.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.GetOracleError);
		}
		/**
		 *  验证用户名密码是否存在
		 * */
		String username = valMap.get("username").toString();
		String password = valMap.get("password").toString();

		JdbcOracleUtil jdbcOracleUtil = null;
		try {
			jdbcOracleUtil = new JdbcOracleUtil(oip,osid,ouser,opass);
		} catch (Exception e2) {
			// TODO Auto-generated catch block
			e2.printStackTrace();
		}
		String selectuser = "select count(*) from sys_user where username='"
				+ username + "' and password='" + password + "'";
		int num = jdbcOracleUtil.jdbcselect(selectuser);
		if (num <= 0) {
			return XmlUtil.createReturnXmlStr(ErrorUtil.UserError);
		}
	
		/**
		 * 验证k号是否存在
		 * */
		String sql = "select count(*) from scene_investigation where INVESTIGATION_NO='"
				+ kid + "'";
		int selectKid = jdbcOracleUtil.jdbcselect(sql);
		if (selectKid <= 0) {
			return XmlUtil.createReturnXmlStr(ErrorUtil.KidError);
		}
		/**
		 * 拿到xml
		 * */
		String insertXml=valMap.get("xml").toString();
		/**
		 * 如以上验证通过，则将数据入库
		 * */
		//得到入库数据
		List<KCT_CASE_INFO> kctlist = (List<KCT_CASE_INFO>) valMap.get("kctlist");
        //生成新的UUID
		UUID uuids = java.util.UUID.randomUUID();
		String uuid = uuids.toString().replace("-", "");
		//封装sql语句
		String insertCaseInfo = "insert into xcky.kct_case_info (ID,CASE_ID,KCT_UUID,CASE_START_TIME,CASE_END_TIME,CASE_LON,CASE_LAT,WITNESS_INFO,REMARK,CREATE_USER,CREATE_DATETIME,UPDATE_USER,UPDATE_DATETIME,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,GPS_NAME,CASE_NAME,INVESTIGATION_ID) values ('"
				+ uuid.toString()
				+ "',"
				+ " (select case_id from xcky.scene_investigation where investigation_no = '"
				+ kid
				+ "'), '"
				+ Kct_UUID
				+ "',"
				+ " to_date('"
				+ kctlist.get(0).getCdate()
				+ "','yyyy-MM-dd HH24:mi:ss'),"
				+ "to_date('"
				+ kctlist.get(kctlist.size() - 1).getCdate()
				+ "','yyyy-MM-dd HH24:mi:ss'),"
				+ "'"
				+ kctlist.get(0).getSlong()
				+ "','"
				+ kctlist.get(0).getSlat()
				+ "','','',(select create_user from xcky.scene_investigation where investigation_no = '"
				+ kid
				+ "')"
				+ ",(select create_datetime from xcky.scene_investigation  where investigation_no = '"
				+ kid
				+ "')"
				+ ",'','','','','','','','','','','','',"
				+ "(select id from xcky.scene_investigation where investigation_no = '"
				+ kid + "'))";
		String insertloace = "insert into  xcky.kct_locale_data(ID,LOCALE_NAME,COL_STARTTIME,COL_ENDTIME,CREATE_USER,CREATE_DATETIME,UPDATE_USER,UPDATE_DATETIME,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,DATA_TYPE,CASE_INFO_ID) values(sys_guid(),'"
				+ kctlist.get(0).getLname()
				+ "',to_date('"
				+ kctlist.get(0).getCdate()
				+ "','yyyy-MM-dd HH24:mi:ss'),to_date('"
				+ kctlist.get(kctlist.size() - 1).getCdate()
				+ "','yyyy-MM-dd HH24:mi:ss'),(select create_user from xcky.scene_investigation where investigation_no = '"
				+ kid
				+ "'),"
				+ "(select create_datetime from xcky.scene_investigation where investigation_no = '"
				+ kid
				+ "'),"
				+ "'','','','','','','','','','','1','"
				+ uuid.toString() + "')";
		String insertGsm = "insert into xcky.kct_basestation_data (ID,BS_TYPE,IFACTIVE,REG_ZONE,SID,NID,BASE_ID,CDMA_CH,PN,STRENGTH,MCC_MNC,LAC,CELL_ID,BCCH,BSIC,SYS_BAND,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,RESERVER9,RESERVER10,LON,LAT,LOCALE_DATA_ID,COL_TIME)"
				+ "values(sys_guid(),'CMCC_GSM','ACTIVE','','"
				+ kctlist.get(0).getLacsid()
				+ "','"
				+ kctlist.get(0).getNid()
				+ "','','','','-21','','13945','"
				+ kctlist.get(0).getMlac()
				+ "','','','','','','','','','','','','','','','',(select ID from xcky.kct_locale_data where case_info_id='"
				+ uuid.toString() + "'),sysdate)";

		String insertCdma = "insert into xcky.kct_basestation_data (ID,BS_TYPE,IFACTIVE,REG_ZONE,SID,NID,BASE_ID,CDMA_CH,PN,STRENGTH,MCC_MNC,LAC,CELL_ID,BCCH,BSIC,SYS_BAND,RESERVER1,RESERVER2,RESERVER3,RESERVER4,RESERVER5,RESERVER6,RESERVER7,RESERVER8,RESERVER9,RESERVER10,LON,LAT,LOCALE_DATA_ID,COL_TIME)"
				+ "values(sys_guid(),'"
				+ "CDMA"
				+ "','ACTIVE','','"
				+ kctlist.get(0).getLacsid()
				+ "','"
				+ kctlist.get(0).getNid()
				+ "','110','','','-212','','','','','','','','','','','','','','','','','','',(select ID from xcky.kct_locale_data where case_info_id='"
				+ uuid.toString() + "'),sysdate)";
          //创建事务将数据插入数据库
//		try {
//			jdbcOracleUtil = new JdbcOracleUtil();
//		} catch (Exception e1) {
//			// TODO Auto-generated catch block
//			e1.printStackTrace();
//		}
		try {
			jdbcOracleUtil.BeginTransaction();
			jdbcOracleUtil.jdbcinsert(insertloace);
			jdbcOracleUtil.jdbcinsert(insertGsm);
			jdbcOracleUtil.jdbcinsert(insertCdma);
			jdbcOracleUtil.jdbcinsertXml(kid,insertXml);
			jdbcOracleUtil.CommitTransaction();
		} catch (Exception e) {
			jdbcOracleUtil.RollbackTransaction();
			e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.Error);
		}
		// 若数据插入成功，添加日志记录
		String insertLog = "insert into devicelog(logdid,logtype,logtime,logKCH,logKCI) values(1,2,NOW(),'"+Kct_UUID+"','"+kid+"')";  
		try {
			 myutil.ExecuteBySQL(insertLog);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.LogError);
		}
	    //日志添加成功后  将数据备份
	    String insertKctInfo="insert into kctinfo(kctID,kctKCH,intime,binfo)values('"+kid+"','"+Kct_UUID+"',NOW(),'"+xmlStr+"')";
	    try {
			myutil.ExecuteBySQL(insertKctInfo);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.KctInfoError);
		}
		return XmlUtil.createReturnXmlStr(ErrorUtil.Success);
	}
}
