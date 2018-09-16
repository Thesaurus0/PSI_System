/*****************************************************************
 * 
 * 本代码仅供【众志进销存管理系统视频教程】配套学习使用，不得用于
 * 任何商业用途，违者必究！
 * 
 * =====不得传播、转载！=====
 * 
 * 版权所有： 众志教程网(www.tg029.com)
 * 作者    ： 王继彬
 * 
 * *************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Tg029.Storage.Data.SqlServer
{
    internal class DataAccessUtil
    {
        public static object ExecuteScalar(string sql, List<SqlParameter> paramList, SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteScalar();
        }


        public static object ExecuteScalar(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlCommand cmd = trans.Connection.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteScalar();
        }


        public static void ExecuteNonQuery(string sql, List<SqlParameter> paramList, SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.ExecuteNonQuery();
        }

        public static void ExecuteNonQuery(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlConnection conn = trans.Connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            cmd.ExecuteNonQuery();
        }


        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> paramList, SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }


        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlConnection conn = trans.Connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteReader();
        }

        public static DataSet ExecuteDataSet(string sql, List<SqlParameter> paramList, SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());

            DataSet ds = new DataSet();
            SqlDataAdapter dapter = new SqlDataAdapter(cmd);
            dapter.Fill(ds);
            return ds;
        }


        public static DataTable ExecuteDataTable(string sql, List<SqlParameter> paramList, SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());

            DataTable dt = new DataTable();
            SqlDataAdapter dapter = new SqlDataAdapter(cmd);
            dapter.Fill(dt);
            return dt;
        }


    }
}
