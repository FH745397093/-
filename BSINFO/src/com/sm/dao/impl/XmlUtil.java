package com.sm.dao.impl;

import java.io.IOException;
import java.io.StringReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.dom4j.DocumentException;
import org.dom4j.DocumentHelper;
import org.jdom.Document;
import org.jdom.Element;
import org.jdom.JDOMException;
import org.jdom.input.SAXBuilder;
import org.xml.sax.InputSource;

import com.sm.entity.KCT_CASE_INFO;

public class XmlUtil {
	public static String createReturnXmlStr(String message) {

		String xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
				+ "<response>" + "<datas>" + "<Result>" + message + "</Result>"
				+ "</datas></response>";
		return xml;
	}

	public static Map<String, Object> xmlElements(String xmlDoc) {
		// 要返回的值 username,password kcrt_uuid,Kid,KctList
		Map<String, Object> valMap = new HashMap<String, Object>();
		List<KCT_CASE_INFO> kctList = new ArrayList<KCT_CASE_INFO>();
		String username = "";
		String password = "";
		String kct_uuid = "";
		String kid = "";
		String xml = "";
		// 创建一个新的字符串
		StringReader read = new StringReader(xmlDoc);
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
		username = foo.getChild("USERNAME").getText();
		password = foo.getChild("PASSWORD").getText();
		kct_uuid = foo.getChild("KCT_UUID").getText();
		kid = foo.getChild("KID").getText();

		foo.getChildren("");
		// Element pramas=foo.getChild("KCTS_VAL").getChild("KCT_VAL");
		List<Element> elementList = foo.getChild("KCTS_VAL").getChildren(
				"KCT_VAL");

		for (int i = 0; i < elementList.size(); i++) {
			KCT_CASE_INFO kct = new KCT_CASE_INFO();
			kct.setCname(elementList.get(i).getChild("CNAME").getText());
			kct.setCnid(elementList.get(i).getChild("CNID").getText());
			kct.setKyno(elementList.get(i).getChild("KYNO").getText());
			kct.setJqno(elementList.get(i).getChild("JQNO").getText());
			kct.setCreateuser(elementList.get(i).getChild("CREATEUSER")
					.getText());
			kct.setLname(elementList.get(i).getChild("LNAME").getText());
			kct.setLid(elementList.get(i).getChild("LID").getText());
			kct.setLacsid(elementList.get(i).getChild("LACSID").getText());
			kct.setCellidbid(elementList.get(i).getChild("CELLIDBID").getText());
			kct.setXhqd(elementList.get(i).getChild("XHQD").getText());
			kct.setNid(elementList.get(i).getChild("NID").getText());
			kct.setYystype(elementList.get(i).getChild("YYSTYPE").getText());
			kct.setXhtype(elementList.get(i).getChild("XHTYPE").getText());
			kct.setIsms(elementList.get(i).getChild("ISMS").getText());
			kct.setSlong(elementList.get(i).getChild("SLONG").getText());
			kct.setSlat(elementList.get(i).getChild("SLAT").getText());
			kct.setCdate(elementList.get(i).getChild("CDATE").getText());
			kct.setMlac(elementList.get(i).getChild("MLAC").getText());
			kct.setMcell(elementList.get(i).getChild("MCELL").getText());
			kct.setHlac(elementList.get(i).getChild("HLAC").getText());
			kct.setHcell(elementList.get(i).getChild("HCELL").getText());
			kct.setBzinfo(elementList.get(i).getChild("BZINFO").getText()
					.replace("@MDZZ@", ">"));
			kct.setNo3(elementList.get(i).getChild("NO3").getText());
			kct.setNo4(elementList.get(i).getChild("NO4").getText());
			kct.setIslastgps(elementList.get(i).getChild("ISLASTGPS").getText());
			kct.setBaidujd(elementList.get(i).getChild("BAIDUJD").getText());
			kct.setBaiduwd(elementList.get(i).getChild("BAIDUWD").getText());
			kct.setCellidlong(elementList.get(i).getChild("CELLIDLONG")
					.getText());
			kct.setBztype(elementList.get(i).getChild("BZTYPE").getText());
			if(kct.getXhtype().equals("2")||kct.getXhtype().equals("3")){
				kctList.add(kct);
			}
		}

		org.dom4j.Document document4j;
		try {
			document4j = DocumentHelper.parseText(xmlDoc);
			org.dom4j.Element xmlstr = document4j.getRootElement()
					.element("PARAMS").element("BASESTATION");
			document4j = DocumentHelper
					.parseText("<?xml version=\"1.0\" encoding=\"gb2312\"?>"
							+ xmlstr.asXML());
			xml = document4j.asXML();
		} catch (DocumentException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
		valMap.put("username", username);
		valMap.put("password", password);
		valMap.put("kct_uuid", kct_uuid);
		valMap.put("kid", kid);
		valMap.put("kctlist", kctList);
		valMap.put("xml", xml);
		return valMap;
	}
}
