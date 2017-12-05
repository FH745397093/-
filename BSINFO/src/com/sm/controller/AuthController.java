package com.sm.controller;

import java.io.IOException; 
import java.io.IOException;
import java.io.InputStream;
import java.io.StringReader;
import java.sql.SQLException;
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
import com.sm.dao.impl.XmlUtil;

@Controller
public class AuthController {
	
	//���豸������ɾ�Ĳ�
	@RequestMapping(value = "Device/DeviceAuth.do", method = RequestMethod.POST, produces = "text/html;charset=UTF-8")
	@ResponseBody
	public String DeviceAuth(@RequestBody String xmlStr,HttpServletResponse response){
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
		
		//��ȡ���������в�������
		Element foo = doc.getRootElement().getChild("PARAMS");
		String modifysql="update device set uuid='"+ foo.getChild("ODEVICE").getText().trim() +"',state='"+ foo.getChild("OSTATE").getText().trim() +"',"
				+ "createtime=now()"
				+" where region='"+foo.getChild("OREGION").getText().trim()+"'";
		int ret=-1;
		try {
			ret= myutil.ExecuteBySQL(modifysql);
			if(ret==0)
			{
				String insertsql="insert into device(uuid,state,region,createtime) values('"
						+ foo.getChild("ODEVICE").getText().trim() +"','" + foo.getChild("OSTATE").getText().trim()+"','"
						+ foo.getChild("OREGION").getText().trim()+"'" +",now())";
				ret= myutil.ExecuteBySQL(insertsql);
				if(ret==0)
					return XmlUtil.createReturnXmlStr(ErrorUtil.ExecNum +ret);
				System.out.print("vv");
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			return XmlUtil.createReturnXmlStr(ErrorUtil.OracleError);
		}
		
		return XmlUtil.createReturnXmlStr(ErrorUtil.ExecNum +ret);
	}
	
	//�����µ���������ݿ�֮���ӳ���ϵ
	@RequestMapping(value = "Device/DeviceList.do", method = RequestMethod.POST, produces = "text/html;charset=UTF-8")
	@ResponseBody
	public String DeviceList(@RequestBody String xmlStr,HttpServletResponse response) {
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
		String modifysql="select * from device order by region";
		if(region!="")
			modifysql="select * from device where region like '%"+ region +"%' order by region";
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
	@RequestMapping(value = "Device/DeviceDel.do", method = RequestMethod.POST, produces = "text/html;charset=UTF-8")
	@ResponseBody
	public String DeviceDel(@RequestBody String xmlStr,HttpServletResponse response) {
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
		String modifysql="delete from device"
				+" where region='"+foo.getChild("OREGION").getText().trim()+"'";
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
}
