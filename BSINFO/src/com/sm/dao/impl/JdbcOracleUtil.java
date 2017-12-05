package com.sm.dao.impl;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.StringReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Properties;

public class JdbcOracleUtil {
	private Connection conn = null;
	private boolean transaction = false;
	
	public JdbcOracleUtil(String oip,String oport,String osid,String ousername,String opassword) throws SQLException{
		if(conn==null){
			getConnection(oip,oport, osid, ousername, opassword);
		}
	}
	
	public JdbcOracleUtil(String oip,String osid,String ousername,String opassword) throws SQLException{
		if(conn==null){
			getConnection(oip,"1521", osid, ousername, opassword);
		}
	}
	
	public void getConnection(String ip,String port,String sid,String username,String password) throws SQLException{
			DriverManager.registerDriver(new oracle.jdbc.driver.OracleDriver());
			conn = DriverManager.getConnection(
					"jdbc:oracle:thin:@//"+ip+":"+port+"/"+sid+"",username,password);

	}
	public void CloseConn() {
		if (conn != null)
			try {
				conn.close();
				conn = null;
			} catch (SQLException e) {
				e.printStackTrace();
			}
	}

	public void BeginTransaction() throws SQLException {
//		if(conn==null){
//			getConnection(oip, osid, ousername, opassword);
//		}
		this.conn.setAutoCommit(false);
		transaction = true;
	}

	public void CommitTransaction() throws SQLException {
		this.conn.commit();
		transaction = false;
		this.CloseConn();
	}

	public void RollbackTransaction() {
		try {
			this.conn.rollback();
		} catch (SQLException e) {
			e.printStackTrace();
		}
		transaction = false;
		this.CloseConn();
	}

	public int jdbcselect(String sql) {
		// 1、注册驱动
		// 4、执行SQL语句
		int a = 0;
		try {
			// 3、创建代表SQL语句的对象
//			if(conn==null){
//				getConnection(oip, osid, ousername, opassword);
//			}
			Statement stmt = conn.createStatement();
			ResultSet rs = stmt.executeQuery(sql);
			if (rs.next()) {
				a = rs.getInt(1);
			}
			rs.close();
			stmt.close();
//			if (!transaction)
//				conn.close();
		} catch (SQLException e) {
			e.printStackTrace();
			return 0;
		}
		return a;
	}

	public void jdbcinsert(String sql) throws SQLException {
//		if(conn==null){
//			getConnection(oip, osid, ousername, opassword);
//		}
			Statement stmt = conn.createStatement();
			stmt.executeUpdate(sql);
			stmt.close();
			if (!transaction)
				conn.close();
	}

	public void jdbcinsertXml(String inv_no,String xmlstr)
			throws Exception {

			String sql = "insert into xcky.common_attachment values(sys_guid(),?,'data.xml','01','','',1,0,'设备',sysdate,"
					+ "'','',(select id from xcky.scene_investigation where investigation_no = '"
					+ inv_no + "')," + "'','','','','','','')";
//			if(conn==null){
//				getConnection(oip, osid, ousername, opassword);
//			}
			PreparedStatement stmt = conn.prepareStatement(sql);
			
//			InputStream is=new FileInputStream(new File("C:\\a\\data.xml"));
//			byte[] xml=new byte[is.available()];
//			is.read(xml);
			stmt.setBytes(1, xmlstr.getBytes());

			stmt.execute();
			//is.close();
			stmt.close();
			if (!transaction)
				conn.close();
	}

}
