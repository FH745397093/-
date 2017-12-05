package com.sm.dao.impl;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Map;
import java.util.Properties;
import java.util.TimeZone;
import java.util.UUID;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONException;
import org.codehaus.jettison.json.JSONObject;
import org.w3c.dom.NodeList;

import com.google.gson.JsonObject;

public class StringUtil {
	public static int toInt(String str){
		if(isNullOrEmpty(str)){
			return 0;
		}else{
			return Integer.parseInt(str);
		}
	}
	/**
	 * ת��Ϊdouble
	 * @param str
	 * @return
	 */
	public static double toDouble(String str){
		if(isNullOrEmpty(str)){
			return 0d;
		}else{
			return Double.parseDouble(str);
		}
	}
	/**
	 * ���ڸ�ʽ�� yyyy-MM-dd
	 */
	public final static String DATEFORMATSTR = "yyyy-MM-dd";
	/**
	 * ����ʱ���ʽ�� yyyy-MM-dd HH:mm:ss
	 */
	public final static String DATETIMEFORMATSTR = "yyyy-MM-dd HH:mm:ss";
	/**
	 * ����ʱ���ʽ�� yyyy-MM-dd HH:mm 
	 */
	public final static String DATETIMEFORMATSTR2 = "yyyy-MM-dd HH:mm";
	/**
	 * �ж��Ƿ�Ϊ��
	 * 
	 * @param str
	 * @return true:�� false:��
	 */
	public static boolean isNullOrEmpty(String str) {
		if (str == null || str.equals("")) {
			return true;
		} else {
			return false;
		}
	}
	/**
	 * �ַ���ת��ΪCalendar����
	 */
	public static Calendar toNowCalendar() {
		Calendar calendar =Calendar.getInstance();
		calendar.setTimeZone(TimeZone.getTimeZone("GMT+0"));
		return calendar;
	}
	/**
	 * ��ȡ��ǰ����/ʱ��
	 * 
	 * @return
	 */
	public static String getNow(String formatStr) {
		SimpleDateFormat sdf = new SimpleDateFormat(formatStr);
		return sdf.format(new Date());
	}
	/**
	 * ��ȡΨһID
	 * @return
	 */
	public static String getGuid(){
		return UUID.randomUUID().toString().replace("-", "");
	}
	/**
	 * ��ʽ������/ʱ��
	 * 
	 * @return
	 */
	public static String getDate(String dateStr, String formatStr) {
		SimpleDateFormat sdf = new SimpleDateFormat(formatStr);
		Date date = null;
		try {
			date = sdf.parse(dateStr);
		} catch (ParseException e) {
			e.printStackTrace();
			return "";
		}
		return sdf.format(date);
	}
	/**
	 * �ַ���ת��Ϊ��������
	 * @param dateStr
	 * @return
	 */
	public static Date toDate(String dateStr) {
		try {
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
			Date date = sdf.parse(dateStr);
			return date;
		} catch (Exception e) {
			return null;
		}
	}
	public final static String formatStr="yyyy��MM��dd�� HH:mm";
	
	/**
	 *�ַ���ת��ΪCalendar����
	 */
	public static Calendar toCalendar(String dateStr) {
		try {
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy��MM��dd�� HH:mm");
			Date date = sdf.parse(dateStr);
			Calendar calendar=Calendar.getInstance();
			calendar.set(date.getYear()+1900, date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(),date.getSeconds());
			return calendar;
		} catch (Exception e) {
			return null;
		}
	}
	/**
	 * 
	 * @param val
	 * @return
	 */
	public static String[] retStringItem(String val) {
		String[] allStr = new String[3];
		if (isNullOrEmpty(val)) {
			allStr[0] = "";
			allStr[1] = "";
			allStr[2] = "";
			return allStr;
		}

		String[] strItem = val.split("&\\u0024",-2);
		String[] strItem2 = strItem[0].split(";",-2);
		if (strItem2.length > 1) {
			allStr[0] = strItem2[1];
		} else {
			allStr[0] = "";
		}
		if (strItem2.length == 1)
			allStr[1] = "";
		else
			allStr[1] = strItem2[0];
		if (strItem2.length == 1)
			allStr[2] = "";
		else
			allStr[2] = strItem[1];
		allStr[2] = strItem[1];
		return allStr;


	}

	/**
	 * ��֤�Ƿ����ֻ�����
	 * 
	 * @param phone
	 *            ����֤����
	 * @return
	 */
	public static boolean isPhone(String phone) {
		// String regExp = "^[1]([3][0-9]{1}|59|58|88|89|83)[0-9]{8}$";

		String regExp = "^[\\d]{11}$";
		Pattern p = Pattern.compile(regExp);
		Matcher m = p.matcher(phone);
		return m.find();// boolean
	}

	public static boolean isFloatNumber(String number) {
		if (number.equals("0") || number.equals("0.0")) {
			return true;
		}
		String regExp = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
		Pattern p = Pattern.compile(regExp);
		Matcher m = p.matcher(number);
		return m.find();// boolean
	}
	/**
	 * mapתjson
	 * @param map
	 * @return
	 * @throws JSONException 
	 */
	public static String mapToJsonstr(int staticCode,String msg,Map<String,String> data) {
		try {
			JSONObject jsonObject=new JSONObject();		
			jsonObject.put("Code", String.valueOf(staticCode));
			jsonObject.put("Msg", msg);
			if(data!=null){
				JSONObject dataJson=new JSONObject();
				for (String key : data.keySet()) {
					dataJson.put(key, data.get(key));
				}
				jsonObject.put("data", dataJson);
			}else{
				jsonObject.put("data", "");
			}
			return jsonObject.toString();
		} catch (Exception e) {
			return "1";
		}
		
	}
	
	/**
	 * mapתjson
	 * @param map
	 * @return
	 * @throws JSONException 
	 */
	public static String mapToJsonstr1(int staticCode,String msg,JSONObject data) {
		try {
			JSONObject jsonObject=new JSONObject();		
			jsonObject.put("Code", String.valueOf(staticCode));
			jsonObject.put("Msg", msg);
			jsonObject.put("data", data);
		 
			return jsonObject.toString();
		} catch (Exception e) {
			return "1";
		}
		
	}
 
	
	/**
	 * 
	 * @param nodeList
	 * @return
	 * @throws JSONException
	 */
	public static JSONArray nodeListToJsonArray(NodeList nodeList) throws JSONException{
		JSONArray jsonArray=new JSONArray();
		for (int i = 0; i < nodeList.getLength(); i++) {// ����ÿ��SysDict��¼
			NodeList sysDictTemp = nodeList.item(i).getChildNodes();
			JSONObject jsonObject = new JSONObject();
			for (int j = 0; j < sysDictTemp.getLength(); j++) {
				jsonObject.put(sysDictTemp.item(j).getNodeName(), sysDictTemp.item(j).getFirstChild().toString());
			}
			jsonArray.put(jsonObject);
		}
		return jsonArray;
	}
}
