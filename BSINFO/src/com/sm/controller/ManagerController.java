package com.sm.controller;

import java.io.IOException;
import java.io.InputStream;
import java.io.StringReader;
import java.sql.SQLException;
import java.util.List;
import java.util.Map;
import java.util.Properties;

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
import com.sm.dao.impl.JdbcMysqlUtil;
import com.sm.dao.impl.JdbcOracleUtil;
import com.sm.dao.impl.XmlUtil;

@Controller
public class ManagerController {
	
	//����Ӧ�����ݽڵ��Ƿ����Ҫ�󲢿�����������
	@RequestMapping(value = "Region/CheckDB.do", method = RequestMethod.POST, produces = "text/html;charset=UTF-8")
	@ResponseBody
	public String CheckOracle(@RequestBody String xmlStr,HttpServletResponse response) {

		response.setHeader("Access-Control-Allow-Origin", "*");
		response.setCharacterEncoding("utf-8");

		// ����һ���µ��ַ���
		StringReader read = new StringReader(xmlStr);
		// �����µ�����ԴSAX ��������ʹ�� InputSource ������ȷ����ζ�ȡ XML ����
		InputSource source = new InputSource(read);
		SAXBuilder builder = new SAXBuilder();
		Document doc = null;
		try {
			doc = builder.build(source);
		} catch (JDOMException e) {
			//e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
		} catch (IOException e) {
			//e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
		}
		
		Element foo = doc.getRootElement().getChild("PARAMS");
		
	    String oip=foo.getChild("OIP").getText().trim();
	    String oport=foo.getChild("OPORT").getText().trim();
	    String osid=foo.getChild("OSID").getText().trim();
	    String ousername=foo.getChild("OUSER").getText().trim();
	    String opassword=foo.getChild("OPASS").getText().trim();
		JdbcOracleUtil oraUtil =null;
		try {
			oraUtil= new JdbcOracleUtil(oip,oport,osid,ousername,opassword);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.OracleError);
		}
		
		String kctCaseInfo = "SELECT COUNT(*) as count FROM all_tables WHERE table_name= 'KCT_CASE_INFO'";
		int kctCaseInfocount = oraUtil.jdbcselect(kctCaseInfo);
		String kctLocaleData = "SELECT COUNT(*) as count FROM all_tables WHERE table_name= 'KCT_LOCALE_DATA'";
		int kctLocaleDatacount = oraUtil.jdbcselect(kctLocaleData);
		String kctBasestationData = "SELECT COUNT(*) as count FROM all_tables WHERE table_name= 'KCT_BASESTATION_DATA'";
		int kctBasestationDatacount = oraUtil.jdbcselect(kctBasestationData);
		if (kctCaseInfocount <= 0 || kctLocaleDatacount <= 0
				|| kctBasestationDatacount <= 0) {
			return XmlUtil.createReturnXmlStr(ErrorUtil.TableNULLError);
		}
		String kctCaseInfoColumn = "select count(*) from user_tab_columns where table_name='KCT_CASE_INFO' and column_name in('ID','CASE_ID',"
				+ "'KCT_UUID','CASE_START_TIME','CASE_END_TIME','CASE_LON','CASE_LAT','WITNESS_INFO',"
				+ "'REMARK','CREATE_USER','CREATE_DATETIME','UPDATE_USER','UPDATE_DATETIME','RESERVER1',"
				+ "'RESERVER2','RESERVER3','RESERVER4','RESERVER5','RESERVER6','RESERVER7','RESERVER8',"
				+ "'GPS_NAME','CASE_NAME','INVESTIGATION_ID')";
		String kctLocaleDataColumn = "select count(*) from user_tab_columns where table_name='KCT_LOCALE_DATA' and column_name in('ID',"
				+ "'LOCALE_NAME','COL_STARTTIME','COL_ENDTIME','CREATE_USER','CREATE_DATETIME','UPDATE_USER','UPDATE_DATETIME',"
				+ "'RESERVER1','RESERVER2','RESERVER3','RESERVER4','RESERVER5','RESERVER6','RESERVER7','RESERVER8','DATA_TYPE','CASE_INFO_ID')";
		String kctBasestationDataColumn = "select count(*) from user_tab_columns where table_name='KCT_BASESTATION_DATA' and column_name in('ID',"
				+ "'BS_TYPE','IFACTIVE','REG_ZONE','SID','NID','BASE_ID','CDMA_CH','PN','STRENGTH','MCC_MNC','LAC','CELL_ID','BCCH','BSIC','SYS_BAND',"
				+ "'RESERVER1','RESERVER2','RESERVER3','RESERVER4','RESERVER5','RESERVER6','RESERVER7','RESERVER8','RESERVER9','RESERVER10',"
				+ "'LON','LAT','LOCALE_DATA_ID','COL_TIME')";
		int kctCaseInfoColumnCount=oraUtil.jdbcselect(kctCaseInfoColumn);//24
		int kctLocaleDataColumnCount=oraUtil.jdbcselect(kctLocaleDataColumn);//18
		int kctBasestationDataColumnCount=oraUtil.jdbcselect(kctBasestationDataColumn);//30
		if(kctCaseInfoColumnCount!=24||kctLocaleDataColumnCount!=18||kctBasestationDataColumnCount!=30){
			return XmlUtil.createReturnXmlStr(ErrorUtil.TableColumnError);
		}
		return XmlUtil.createReturnXmlStr(ErrorUtil.OracleSuccess);
	}
	
	//�����µ���������ݿ�֮���ӳ���ϵ
		@RequestMapping(value = "Region/DBDel.do", method = RequestMethod.POST, produces = "text/html;charset=UTF-8")
		@ResponseBody
		public String DBDel(@RequestBody String xmlStr,HttpServletResponse response) {
			response.setHeader("Access-Control-Allow-Origin", "*");
			response.setCharacterEncoding("utf-8");
			InputStream is=this.getClass().getResourceAsStream("/mysql.properties");
		    Properties p = new Properties();
		        try {  
		            p.load(is);  
		            is.close();  
		        } catch (IOException e1) {  
		            e1.printStackTrace();  
		        }  
		        String ip=p.getProperty("ip");
		        String port=p.getProperty("port");
		        String dbname=p.getProperty("dbname");
		        String username=p.getProperty("username");
		        String password=p.getProperty("password");
		        JdbcMysqlUtil myutil =null;
			try {
				myutil = new JdbcMysqlUtil(ip,port, dbname,username,password);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				//e.printStackTrace();
				return XmlUtil.createReturnXmlStr(ErrorUtil.SetupError);
			}
			
			// ����һ���µ��ַ���
			StringReader read = new StringReader(xmlStr);
			// �����µ�����ԴSAX ��������ʹ�� InputSource ������ȷ����ζ�ȡ XML ����
			InputSource source = new InputSource(read);
			SAXBuilder builder = new SAXBuilder();
			Document doc = null;
			try {
				doc = builder.build(source);
			} catch (JDOMException e) {
				//e.printStackTrace();
				return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
			} catch (IOException e) {
				//e.printStackTrace();
				return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
			}
			
			Element foo = doc.getRootElement().getChild("PARAMS");
			String modifysql="delete from kctdestdb"
					+" where oregion='"+foo.getChild("OREGION").getText().trim()+"'";
			int ret=-1;
			try {
				ret= myutil.ExecuteBySQL(modifysql);
				if(ret==0)
				{
					return XmlUtil.createReturnXmlStr(ErrorUtil.ExecNum +ret);
				}
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				return XmlUtil.createReturnXmlStr(ErrorUtil.OracleError);
			}
			
			return XmlUtil.createReturnXmlStr(ErrorUtil.ExecNum +ret);
		}
	
	//�����µ���������ݿ�֮���ӳ���ϵ
	@RequestMapping(value = "Region/DBManager.do", method = RequestMethod.POST, produces = "text/html;charset=UTF-8")
	@ResponseBody
	public String DBManager(@RequestBody String xmlStr,HttpServletResponse response) {
		response.setHeader("Access-Control-Allow-Origin", "*");
		response.setCharacterEncoding("utf-8");
		InputStream is=this.getClass().getResourceAsStream("/mysql.properties");
	    Properties p = new Properties();
	        try {  
	            p.load(is);  
	            is.close();  
	        } catch (IOException e1) {  
	            e1.printStackTrace();  
	        }  
	        String ip=p.getProperty("ip");
	        String port=p.getProperty("port");
	        String dbname=p.getProperty("dbname");
	        String username=p.getProperty("username");
	        String password=p.getProperty("password");
	        JdbcMysqlUtil myutil =null;
		try {
			myutil = new JdbcMysqlUtil(ip,port, dbname,username,password);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			//e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.SetupError);
		}
		
		// ����һ���µ��ַ���
		StringReader read = new StringReader(xmlStr);
		// �����µ�����ԴSAX ��������ʹ�� InputSource ������ȷ����ζ�ȡ XML ����
		InputSource source = new InputSource(read);
		SAXBuilder builder = new SAXBuilder();
		Document doc = null;
		try {
			doc = builder.build(source);
		} catch (JDOMException e) {
			//e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
		} catch (IOException e) {
			//e.printStackTrace();
			return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
		}
		
		Element foo = doc.getRootElement().getChild("PARAMS");
		String region=foo.getChild("OREGION").getText().trim();
		String modifysql="select * from kctdestdb order by oregion";
		if(region!="")
			modifysql="select * from kctdestdb where oregion like '%"+ region +"%' order by oregion";
		String ret=null;
		try {
			ret= myutil.GetDBJsonBySQL(modifysql);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			return XmlUtil.createReturnXmlStr(ErrorUtil.OracleError);
		}
		
		return ret;
	}
	
	//�����µ���������ݿ�֮���ӳ���ϵ
		@RequestMapping(value = "Region/DBUpdate.do", method = RequestMethod.POST, produces = "text/html;charset=UTF-8")
		@ResponseBody
		public String DBUpdate(@RequestBody String xmlStr,HttpServletResponse response) {
			response.setHeader("Access-Control-Allow-Origin", "*");
			response.setCharacterEncoding("utf-8");
			InputStream is=this.getClass().getResourceAsStream("/mysql.properties");
		    Properties p = new Properties();
		        try {  
		            p.load(is);  
		            is.close();  
		        } catch (IOException e1) {  
		            e1.printStackTrace();  
		        }  
		        String ip=p.getProperty("ip");
		        String port=p.getProperty("port");
		        String dbname=p.getProperty("dbname");
		        String username=p.getProperty("username");
		        String password=p.getProperty("password");
		        JdbcMysqlUtil myutil =null;
			try {
				myutil = new JdbcMysqlUtil(ip,port, dbname,username,password);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				//e.printStackTrace();
				return XmlUtil.createReturnXmlStr(ErrorUtil.SetupError);
			}
			
			// ����һ���µ��ַ���
			StringReader read = new StringReader(xmlStr);
			// �����µ�����ԴSAX ��������ʹ�� InputSource ������ȷ����ζ�ȡ XML ����
			InputSource source = new InputSource(read);
			SAXBuilder builder = new SAXBuilder();
			Document doc = null;
			try {
				doc = builder.build(source);
			} catch (JDOMException e) {
				//e.printStackTrace();
				return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
			} catch (IOException e) {
				//e.printStackTrace();
				return XmlUtil.createReturnXmlStr(ErrorUtil.ParamError);
			}
			
			Element foo = doc.getRootElement().getChild("PARAMS");
			String modifysql="update kctdestdb set oip='"+ foo.getChild("OIP").getText().trim() +"',oport='"+ foo.getChild("OPORT").getText().trim() +"',"
					+"osid='"+ foo.getChild("OSID").getText().trim() +"',ouser='"+ foo.getChild("OUSER").getText().trim() +"',opass='"
					+ foo.getChild("OPASS").getText().trim() +"',optime=now()"
					+" where oregion='"+foo.getChild("OREGION").getText().trim()+"'";
			int ret=-1;
			try {
				ret= myutil.ExecuteBySQL(modifysql);
				if(ret==0)
				{
					String insertsql="insert into kctdestdb(oip,oport,osid,oregion,ouser,opass,optime) values('"
							+ foo.getChild("OIP").getText().trim()+ "','" + foo.getChild("OPORT").getText().trim()+"','" 
							+ foo.getChild("OSID").getText().trim() +"','" + foo.getChild("OREGION").getText().trim()+"','"
							+ foo.getChild("OUSER").getText().trim()+"','" + foo.getChild("OPASS").getText().trim() +"',now())";
					ret= myutil.ExecuteBySQL(insertsql);
					if(ret==0)
						return XmlUtil.createReturnXmlStr(ErrorUtil.ExecNum +ret);
				}
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				return XmlUtil.createReturnXmlStr(ErrorUtil.OracleError);
			}
			
			return XmlUtil.createReturnXmlStr(ErrorUtil.ExecNum +ret);
		}
}
