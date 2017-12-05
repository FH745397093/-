using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.IO;
namespace BSTool
{
    public class DBHelperORACLE
    {
        public OracleConnection conn = null;
        private OracleCommand cmd = null;
        private OracleDataAdapter adapter = null;
        private bool isTrans = false;
        private OracleTransaction trans = null;
        private bool canuse = true;

        public bool Canuse
        {
            get { return canuse; }
        }

        public DBHelperORACLE(string ConnAddStr) { getConn(ConnAddStr); }

        /**
         * 获取数据库连接对象
         * */
        public void getConn(string ConnAddStr)
        {
            string connStr = ConnAddStr;
            this.conn = new OracleConnection(connStr);
          
        }

      
        /**
         * 打开数据库连接
         * */
        public void openConn()
        {
            //this.getConn();
            if ((this.conn != null) && (this.conn.State == ConnectionState.Closed))
            {
                this.conn.Open();
            }
        }

        /**
         *  关闭数据库连接
         * */
        public void closeConn()
        {
            if ((this.conn != null) && (this.conn.State != ConnectionState.Closed) && !this.isTrans)
            {
                this.conn.Close();
            }
        }

        /**
         * 开始事务
         * */
        public void beginTrans()
        {
            this.openConn();
            this.isTrans = true;
            this.trans = this.conn.BeginTransaction();
        }

        /**
         * 提交事务
         * */
        public void commitTrans()
        {
            this.trans.Commit();
            this.isTrans = false;
            this.closeConn();
        }

        /**
         * 回滚事务
         * */
        public void rollbackTrans()
        {
            this.trans.Rollback();
            this.isTrans = false;
            this.closeConn();
        }

        /**
         * 执行DML语句
         * */
        public void execSql(string sql)
        {
            if (this.isTrans)
            {
                this.cmd = conn.CreateCommand();
                this.cmd.Transaction = this.trans;
            }
            else
            {
                this.openConn();
                this.cmd = conn.CreateCommand();
            }

            this.cmd.CommandText = sql;
            this.cmd.ExecuteNonQuery();
            this.closeConn();
        }

        /**
         * 执行DML语句（可带参数）
         * */
        public int execSql(string sql, OracleParameter[] para)
        {
            if (this.isTrans)
            {
                this.cmd = conn.CreateCommand();
                this.cmd.Transaction = this.trans;
            }
            else
            {
                this.openConn();
                this.cmd = conn.CreateCommand();
            }

            this.cmd.CommandText = sql;
            foreach (OracleParameter parameter in para)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput
                    || parameter.Direction == ParameterDirection.Input)
                    && (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }

                this.cmd.Parameters.Add(parameter);
            }
            int result = this.cmd.ExecuteNonQuery();
            this.closeConn();
            return result;
        }

        /**
         * 执行DML语句，并返回单独一列的值
         * */
        public object execScalar(string sql)
        {
            if (this.isTrans)
            {
                this.cmd = conn.CreateCommand();
                this.cmd.Transaction = this.trans;
            }
            else
            {
                this.openConn();
                this.cmd = conn.CreateCommand();
            }
           
            this.cmd.CommandText = sql;
            object returnval = cmd.ExecuteScalar();
            this.closeConn();
            return returnval;
        }

        /**
         * 执行DML语句，并返回影响行数
         * */
        public int execSqlREF(string sql)
        {
            int J;
            if (this.isTrans)
            {
                this.cmd = conn.CreateCommand();
                this.cmd.Transaction = this.trans;
            }
            else
            {
                this.openConn();
                this.cmd = conn.CreateCommand();
            }

            this.cmd.CommandText = sql;
            J = this.cmd.ExecuteNonQuery();
            this.closeConn();
            return J;
        }

        /**
         * 执行DML语句（可带参数）并返回影响行数
         * */
        public int execSqlREF(string sql, OracleParameter[] para)
        {
            int J = 0;
            if (this.isTrans)
            {
                this.cmd = conn.CreateCommand();
                this.cmd.Transaction = this.trans;
            }
            else
            {
                this.openConn();
                this.cmd = conn.CreateCommand();
            }
            this.cmd.CommandText = sql;
            if (para != null)
            {
                for (int i = 0; i < para.Length; i++)
                {
                    this.cmd.Parameters.Add(para[i]);
                }
            }
            J = this.cmd.ExecuteNonQuery();
            this.closeConn();
            return J;
        }

        /**
         * 通过SQL语句返回结果集
         * */
        public System.Data.DataSet getDataSet(string sql)
        {
            DataSet dataSet = new DataSet();
            if (this.isTrans)
            {
                this.cmd = conn.CreateCommand();
                this.cmd.Transaction = this.trans;
            }
            else
            {
                this.openConn();
                this.cmd = conn.CreateCommand();
            }
            cmd.CommandText = sql;
            adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dataSet);
            this.closeConn();
            return dataSet;
        }

        /**
        * 通过SQL语句返回结果集
        * */
        public System.Data.DataSet getDataSet(string sql, OracleParameter[] para)
        {
            DataSet dataSet = new DataSet();
            try
            {
                if (this.isTrans)
                {
                    this.cmd = conn.CreateCommand();
                    this.cmd.Transaction = this.trans;
                }
                else
                {
                    this.openConn();
                }
                this.cmd = getSqlCmd(sql, para);
                adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.conn.Close();
            }
            return dataSet;
        }


        /// <summary>过滤SQL语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private string GetSqlStr(string strSql)
        {
            int startIndex = 0;
            int num2 = 0;
            while (startIndex < strSql.Length)
            {
                char ch = strSql[startIndex];
                if (ch.ToString() == "?")
                {
                    strSql = strSql.Remove(startIndex, 1).Insert(startIndex, ":p" + num2.ToString());
                    num2++;
                }
                startIndex++;
            }
            return strSql;
        }

        /**
         * 将参数传入Command对象后返回该Command对象
         **/
        private OracleCommand getSqlCmd(string sql, OracleParameter[] para)
        {
            OracleCommand command = conn.CreateCommand();
            command.CommandText = sql;
            for (int i = 0; i < para.Length; i++)
            {
                command.Parameters.Add(para[i]);
            }
            return command;
        }

        /**
        * 执行DML语句
        * */
        public int execOracleRowCount(string sql)
        {
            int row = 0;
            if (this.isTrans)
            {
                this.cmd = conn.CreateCommand();
                this.cmd.Transaction = this.trans;
            }
            else
            {
                this.openConn();
                this.cmd = conn.CreateCommand();
            }

            this.cmd.CommandText = sql;
            row = this.cmd.ExecuteNonQuery();
            this.closeConn();

            return row;
        }
    }
}
