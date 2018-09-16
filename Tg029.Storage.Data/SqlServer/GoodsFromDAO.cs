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
using Tg029.Storage.Model;

namespace Tg029.Storage.Data.SqlServer
{
    public class GoodsFromDAO : IGoodsFromDAO
    {

        #region IGoodsFromDAO 成员

        public void InsertGoodsFrom(GoodsFrom goodsFrom, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_GoodsFrom(GoodsFromCode,GoodsFromName,Actived) 
            VALUES(@GoodsFromCode,@GoodsFromName,@Actived)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsFromCode", goodsFrom.Code));
            paramList.Add(new SqlParameter("@GoodsFromName", goodsFrom.Name));
            paramList.Add(new SqlParameter("@Actived", goodsFrom.Actived));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertGoodsFrom(GoodsFrom goodsFrom, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_GoodsFrom(GoodsFromCode,GoodsFromName,Actived) 
            VALUES(@GoodsFromCode,@GoodsFromName,@Actived)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsFromCode", goodsFrom.Code));
            paramList.Add(new SqlParameter("@GoodsFromName", goodsFrom.Name));
            paramList.Add(new SqlParameter("@Actived", goodsFrom.Actived));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateGoodsFrom(GoodsFrom goodsFrom, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_GoodsFrom SET 
                    GoodsFromCode=@GoodsFromCode,GoodsFromName=@GoodsFromName,
                    Actived=@Actived
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsFromCode", goodsFrom.Code));
            paramList.Add(new SqlParameter("@GoodsFromName", goodsFrom.Name));
            paramList.Add(new SqlParameter("@Actived", goodsFrom.Actived));
            paramList.Add(new SqlParameter("@ID", goodsFrom.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateGoodsFrom(GoodsFrom goodsFrom, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_GoodsFrom SET 
                    GoodsFromCode=@GoodsFromCode,GoodsFromName=@GoodsFromName,
                    Actived=@Actived 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsFromCode", goodsFrom.Code));
            paramList.Add(new SqlParameter("@GoodsFromName", goodsFrom.Name));
            paramList.Add(new SqlParameter("@Actived", goodsFrom.Actived));
            paramList.Add(new SqlParameter("@ID", goodsFrom.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteGoodsFrom(int id, IDbConnection conn)
        {
            string sql = "DELETE MD_GoodsFrom WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteGoodsFrom(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_GoodsFrom WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<GoodsFrom> SelectAllGoodsFroms(IDbConnection conn)
        {

            string sql = "SELECT ID,GoodsFromCode,GoodsFromName,Actived FROM MD_GoodsFrom";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<GoodsFrom> list = new List<GoodsFrom>();
            while (reader.Read())
            {
                GoodsFrom sh = new GoodsFrom();
                sh.ID = reader.GetInt32(0);
                sh.Code = reader.GetString(1);
                sh.Name = reader.GetString(2);
                sh.Actived = reader.GetBoolean(3);
                list.Add(sh);
            }
            reader.Close();
            return list;

        }

        public GoodsFrom SelectGoodsFrom(int id, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,GoodsFromCode,GoodsFromName,Actived,Remark 
            FROM MD_GoodsFrom
            WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            GoodsFrom result = null;
            while (reader.Read())
            {
                result = new GoodsFrom();
                result.ID = reader.GetInt32(0);
                result.Code = reader.GetString(1);
                result.Name = reader.GetString(2);
                result.Actived = reader.GetBoolean(3);
            }
            reader.Close();
            return result;
        }


        public GoodsFrom SelectGoodsFrom(string code, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,GoodsFromCode,GoodsFromName,Actived,Remark 
            FROM MD_GoodsFrom
            WHERE Code=@Code";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", code));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            GoodsFrom result = null;
            while (reader.Read())
            {
                result = new GoodsFrom();
                result.ID = reader.GetInt32(0);
                result.Code = reader.GetString(1);
                result.Name = reader.GetString(2);
                result.Actived = reader.GetBoolean(3);
            }
            reader.Close();
            return result;
        }

        #endregion
    }
}
