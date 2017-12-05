package com.sm.dao.impl;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gson.JsonArray;
import com.google.gson.JsonObject;





public class JdbcMysqlUtil {
	public ResultSet rs = null;
	public Statement stmt = null;
	public Connection conn = null;

	public JdbcMysqlUtil(String ip, String port,String dbname, String user, String pwd){
		try {
			Class.forName("com.mysql.jdbc.Driver");
			conn = DriverManager.getConnection("jdbc:mysql://" + ip
					+ ":"+port+"/"+dbname+"?user=" + user + "&password=" + pwd);
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public void CloseCon() {
		try {
			this.conn.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public String GetDBJsonBySQL(String sql)throws SQLException
	{
		JsonArray array = new JsonArray();  
		// 获取列数  
		try {
			stmt = conn.createStatement();
			rs = stmt.executeQuery(sql);
			ResultSetMetaData metaData = rs.getMetaData();  
			int columnCount = metaData.getColumnCount();  

			while (rs.next()) {
				JsonObject jsonObj = new JsonObject();  
				// 遍历每一列  
				for (int i = 1; i <= columnCount; i++) {  
					String columnName =metaData.getColumnLabel(i);  
					String value = rs.getString(columnName);  
					jsonObj.addProperty(columnName, value);  
				}   
				array.add(jsonObj);   
			}
		} catch (SQLException e) {
			throw e;
		} finally {
			rs.close();
			stmt.close();
		}
		return array.toString(); 
	}
	
	public List<Map<String, String>> GetDBlistBySQL(String sql)
			throws SQLException {
		List<Map<String, String>> list = new ArrayList<Map<String, String>>();
		try {
			stmt = conn.createStatement();
			rs = stmt.executeQuery(sql);
			while (rs.next()) {
				Map<String, String> rsMap = new HashMap<String, String>();
				for (int i = 1; i < rs.getMetaData().getColumnCount() + 1; i++) {
					rsMap.put(rs.getMetaData().getColumnLabel(i),
							rs.getString(i));
				}
				list.add(rsMap);
			}
			rs.close();
			stmt.close();
		} catch (SQLException e) {
			throw e;
		} finally {
			rs.close();
			stmt.close();
		}
		return list;
	}

	// 通用删除、更新方法
	public int ExecuteBySQL(String sql) throws SQLException {
		try {
			stmt = conn.createStatement();
			int i = stmt.executeUpdate(sql);
			stmt.close();
			return i;
		} catch (SQLException e) {
			throw e;
			
		} finally {
			stmt.close();
		}
	}

}
