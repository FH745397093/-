package com.sm.dao.impl;

import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;

import org.codehaus.jettison.json.JSONException;
import org.codehaus.jettison.json.JSONObject;

public class JsonUtil {
	private JSONObject requestData;

	private String tempPath;

	public JsonUtil(String requestStr, String tempPath) {

		try {
			this.tempPath = tempPath;
			String relData = URLDecoder.decode(requestStr, "UTF-8");
			requestData = new JSONObject(requestStr);
		} catch (UnsupportedEncodingException e) {
			FileUtil.writeErrLog(tempPath, "json���ݱ���ת��ʧ�ܣ�" + e.toString());

		} catch (JSONException e) {
			FileUtil.writeErrLog(tempPath, "json���ݸ�ʽ��ʧ�ܣ�" + e.toString());
		}

	}

	public JsonUtil(String requestStr, String tempPath, String sign) {

		try {
			this.tempPath = tempPath;
			requestData = new JSONObject(requestStr);
		} catch (JSONException e) {
			FileUtil.writeErrLog(tempPath, "json���ݸ�ʽ��ʧ�ܣ�" + e.toString());
		}

	}

	/**
	 * 
	 * @param key
	 * @return
	 */
	public boolean has(String key) {

		return requestData.has(key);
	}

	/**
	 * 
	 * @param key
	 * @return
	 * @throws JSONException
	 */
	public String getStrvalByKey(String key) {

		try {
			return requestData.getString(key);
		} catch (JSONException e) {
			FileUtil.writeErrLog(tempPath, "json���ݸ�ʽ��ʧ�ܣ�" + e.toString());
			return null;
		}
	}

	/**
	 * 
	 * @param key
	 * @return
	 * @throws JSONException
	 */
	public int getIntvalByKey(String key) {
		try {
			return requestData.getInt(key);
		} catch (JSONException e) {
			FileUtil.writeErrLog(tempPath, "json���ݸ�ʽ��ʧ�ܣ�" + e.toString());
			return -1;
		}
	}

}
