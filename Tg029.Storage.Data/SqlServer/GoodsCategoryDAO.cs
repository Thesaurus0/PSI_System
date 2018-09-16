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
    public class GoodsCategoryDAO : IGoodsCategoryDAO
    {

        #region IGoodsCategoryDAO 成员

        public void InsertGoodsCategory(GoodsCategory goodsCategory, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_GoodsCategory(GoodsCategoryCode,GoodsCategoryName,Actived) 
            VALUES(@GoodsCategoryCode,@GoodsCategoryName,@Actived)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCategoryCode", goodsCategory.Code));
            paramList.Add(new SqlParameter("@GoodsCategoryName", goodsCategory.Name));
            paramList.Add(new SqlParameter("@Actived", goodsCategory.Actived));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertGoodsCategory(GoodsCategory goodsCategory, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_GoodsCategory(GoodsCategoryCode,GoodsCategoryName,Actived) 
            VALUES(@GoodsCategoryCode,@GoodsCategoryName,@Actived)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCategoryCode", goodsCategory.Code));
            paramList.Add(new SqlParameter("@GoodsCategoryName", goodsCategory.Name));
            paramList.Add(new SqlParameter("@Actived", goodsCategory.Actived));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateGoodsCategory(GoodsCategory goodsCategory, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_GoodsCategory SET 
                    GoodsCategoryCode=@GoodsCategoryCode,GoodsCategoryName=@GoodsCategoryName,
                    Actived=@Actived
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCategoryCode", goodsCategory.Code));
            paramList.Add(new SqlParameter("@GoodsCategoryName", goodsCategory.Name));
            paramList.Add(new SqlParameter("@Actived", goodsCategory.Actived));
            paramList.Add(new SqlParameter("@ID", goodsCategory.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateGoodsCategory(GoodsCategory goodsCategory, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_GoodsCategory SET 
                    GoodsCategoryCode=@GoodsCategoryCode,GoodsCategoryName=@GoodsCategoryName,
                    Actived=@Actived 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCategoryCode", goodsCategory.Code));
            paramList.Add(new SqlParameter("@GoodsCategoryName", goodsCategory.Name));
            paramList.Add(new SqlParameter("@Actived", goodsCategory.Actived));
            paramList.Add(new SqlParameter("@ID", goodsCategory.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteGoodsCategory(int id, IDbConnection conn)
        {
            string sql = "DELETE MD_GoodsCategory WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteGoodsCategory(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_GoodsCategory WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<GoodsCategory> SelectAllGoodsCategories(IDbConnection conn)
        {

            string sql = "SELECT ID,GoodsCategoryCode,GoodsCategoryName,Actived FROM MD_GoodsCategory";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<GoodsCategory> list = new List<GoodsCategory>();
            while (reader.Read())
            {
                GoodsCategory sh = new GoodsCategory();
                sh.ID = reader.GetInt32(0);
                sh.Code = reader.GetString(1);
                sh.Name = reader.GetString(2);
                sh.Actived = reader.GetBoolean(3);
                list.Add(sh);
            }
            reader.Close();
            return list;

        }

        public GoodsCategory SelectGoodsCategory(int id, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,GoodsCategoryCode,GoodsCategoryName,Actived,Remark 
            FROM MD_GoodsCategory
            WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            GoodsCategory result = null;
            while (reader.Read())
            {
                result = new GoodsCategory();
                result.ID = reader.GetInt32(0);
                result.Code = reader.GetString(1);
                result.Name = reader.GetString(2);
                result.Actived = reader.GetBoolean(3);
            }
            reader.Close();
            return result;
        }

     

        public GoodsCategory SelectGoodsCategory(string code, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,GoodsCategoryCode,GoodsCategoryName,Actived,Remark 
            FROM MD_GoodsCategory
            WHERE Code=@Code";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", code));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            GoodsCategory result = null;
            while (reader.Read())
            {
                result = new GoodsCategory();
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
