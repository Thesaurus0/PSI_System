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
    public class GoodsDAO : IGoodsDAO
    {
        #region IGoodsDAO 成员

        public void InsertGoods(Goods goods, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_Goods(GoodsCode,GoodsName,Actived,Remark,GoodsFrom_ID,GoodsCategory_ID,Unit,Standard) 
            VALUES(@GoodsCode,@GoodsName,@Actived,@Remark,@GoodsFromID,@GoodsCategoryID,@Unit,@Standard)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCode", goods.Code));
            paramList.Add(new SqlParameter("@GoodsName", goods.Name));
            paramList.Add(new SqlParameter("@Actived", goods.Actived));
            paramList.Add(new SqlParameter("@Remark", goods.Remark));
            paramList.Add(new SqlParameter("@GoodsFromID", goods.From.ID));
            paramList.Add(new SqlParameter("@GoodsCategoryID", goods.Category.ID));
            paramList.Add(new SqlParameter("@Unit", goods.Unit));
            paramList.Add(new SqlParameter("@Standard", goods.Standard));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertGoods(Goods goods, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_Goods(GoodsCode,GoodsName,Actived,Remark,GoodsFrom_ID,GoodsCategory_ID,Unit,Standard) 
            VALUES(@GoodsCode,@GoodsName,@Actived,@Remark,@GoodsFromID,@GoodsCategoryID,@Unit,@Standard)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCode", goods.Code));
            paramList.Add(new SqlParameter("@GoodsName", goods.Name));
            paramList.Add(new SqlParameter("@Actived", goods.Actived));
            paramList.Add(new SqlParameter("@Remark", goods.Remark));
            paramList.Add(new SqlParameter("@GoodsFromID", goods.From.ID));
            paramList.Add(new SqlParameter("@GoodsCategoryID", goods.Category.ID));
            paramList.Add(new SqlParameter("@Unit", goods.Unit));
            paramList.Add(new SqlParameter("@Standard", goods.Standard));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateGoods(Goods goods, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_Goods SET 
                    GoodsCode=@GoodsCode,GoodsName=@GoodsName,Actived=@Actived ,
                    Remark=@Remark,GoodsFrom_ID=@GoodsFromID,GoodsCategory_ID=@GoodsCategoryID,
                    Unit=@Unit,Standard=@Standard
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCode", goods.Code));
            paramList.Add(new SqlParameter("@GoodsName", goods.Name));
            paramList.Add(new SqlParameter("@Actived", goods.Actived));
            paramList.Add(new SqlParameter("@Remark", goods.Remark));
            paramList.Add(new SqlParameter("@GoodsFromID", goods.From.ID));
            paramList.Add(new SqlParameter("@GoodsCategoryID", goods.Category.ID));
            paramList.Add(new SqlParameter("@Unit", goods.Unit));
            paramList.Add(new SqlParameter("@Standard", goods.Standard));
            paramList.Add(new SqlParameter("@ID", goods.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateGoods(Goods goods, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_Goods SET 
                    GoodsCode=@GoodsCode,GoodsName=@GoodsName,Actived=@Actived ,
                    Remark=@Remark,GoodsFrom_ID=@GoodsFromID,GoodsCategory_ID=@GoodsCategoryID,
                    Unit=@Unit,Standard=@Standard
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCode", goods.Code));
            paramList.Add(new SqlParameter("@GoodsName", goods.Name));
            paramList.Add(new SqlParameter("@Actived", goods.Actived));
            paramList.Add(new SqlParameter("@Remark", goods.Remark));
            paramList.Add(new SqlParameter("@GoodsFromID", goods.From.ID));
            paramList.Add(new SqlParameter("@GoodsCategoryID", goods.Category.ID));
            paramList.Add(new SqlParameter("@Unit", goods.Unit));
            paramList.Add(new SqlParameter("@Standard", goods.Standard));
            paramList.Add(new SqlParameter("@ID", goods.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteGoods(int id, IDbConnection conn)
        {
            string sql = "DELETE MD_Goods WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteGoods(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_Goods WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Goods> SelectAllGoods(IDbConnection conn)
        {
            string sql = @"
            SELECT 
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived,
                Mg.Unit,Mg.Standard
            FROM MD_Goods AS Mg
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            ";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<Goods> list = new List<Goods>();
            while (reader.Read())
            {
                Goods g = new Goods();
                g.ID = reader.GetInt32(0);
                g.Code = reader.GetString(1);
                g.Name = reader.GetString(2);
                g.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    g.Remark = reader.GetString(4);
                }

                g.From = new GoodsFrom();
                g.From.ID = reader.GetInt32(5);
                g.From.Code = reader.GetString(6);
                g.From.Name = reader.GetString(7);
                g.From.Actived = reader.GetBoolean(8);
               
                g.Category = new GoodsCategory();
                g.Category.ID = reader.GetInt32(9);
                g.Category.Code = reader.GetString(10);
                g.Category.Name = reader.GetString(11);
                g.Category.Actived = reader.GetBoolean(12);

                g.Unit = reader.GetString(13);
                g.Standard = reader.GetString(14);
                list.Add(g);
            }
            reader.Close();
            return list;
        }

        public Goods SelectGoods(int id, IDbConnection conn)
        {
            string sql = @"
            SELECT 
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived,
                Mg.Unit,Mg.Standard
            FROM MD_Goods AS Mg
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            WHERE Mg.ID=@ID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Goods g = null;
            while (reader.Read())
            {
                g = new Goods();
                g.ID = reader.GetInt32(0);
                g.Code = reader.GetString(1);
                g.Name = reader.GetString(2);
                g.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    g.Remark = reader.GetString(4);
                }

                g.From = new GoodsFrom();
                g.From.ID = reader.GetInt32(5);
                g.From.Code = reader.GetString(6);
                g.From.Name = reader.GetString(7);
                g.From.Actived = reader.GetBoolean(8);
                

                g.Category = new GoodsCategory();
                g.Category.ID = reader.GetInt32(9);
                g.Category.Code = reader.GetString(10);
                g.Category.Name = reader.GetString(11);
                g.Category.Actived = reader.GetBoolean(12);

                g.Unit = reader.GetString(13);
                g.Standard = reader.GetString(14);
            }
            reader.Close();
            return g;
        }

        
        public Goods SelectGoods(string code, IDbConnection conn)
        {
            string sql = @"
            SELECT 
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived,
                Mg.Unit,Mg.Standard
            FROM MD_Goods AS Mg
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            WHERE Mg.GoodsCode=@Code
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", code));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Goods g = null;
            while (reader.Read())
            {
                g = new Goods();
                g.ID = reader.GetInt32(0);
                g.Code = reader.GetString(1);
                g.Name = reader.GetString(2);
                g.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    g.Remark = reader.GetString(4);
                }

                g.From = new GoodsFrom();
                g.From.ID = reader.GetInt32(5);
                g.From.Code = reader.GetString(6);
                g.From.Name = reader.GetString(7);
                g.From.Actived = reader.GetBoolean(8);


                g.Category = new GoodsCategory();
                g.Category.ID = reader.GetInt32(9);
                g.Category.Code = reader.GetString(10);
                g.Category.Name = reader.GetString(11);
                g.Category.Actived = reader.GetBoolean(12);

                g.Unit = reader.GetString(13);
                g.Standard = reader.GetString(14);
            }
            reader.Close();
            return g;
        }

        #endregion
    }
}
