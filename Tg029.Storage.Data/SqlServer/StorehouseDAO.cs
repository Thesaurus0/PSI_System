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
    public class StorehouseDAO : IStorehouseDAO
    {
        #region IStorehouseDAO 成员

        public void InsertStorehouse(Storehouse storehouse, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_Storehouse(StorehouseCode,StorehouseName,Actived,Remark) 
            VALUES(@StorehouseCode,@StorehouseName,@Actived,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", storehouse.Code));
            paramList.Add(new SqlParameter("@StorehouseName", storehouse.Name));
            paramList.Add(new SqlParameter("@Actived", storehouse.Actived));
            paramList.Add(new SqlParameter("@Remark", storehouse.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertStorehouse(Storehouse storehouse, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_Storehouse(StorehouseCode,StorehouseName,Actived,Remark) 
            VALUES(@StorehouseCode,@StorehouseName,@Actived,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", storehouse.Code));
            paramList.Add(new SqlParameter("@StorehouseName", storehouse.Name));
            paramList.Add(new SqlParameter("@Actived", storehouse.Actived));
            paramList.Add(new SqlParameter("@Remark", storehouse.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateStorehouse(Storehouse storehouse, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_Storehouse SET 
                    StorehouseCode=@StorehouseCode,StorehouseName=@StorehouseName,
                    Actived=@Actived,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", storehouse.Code));
            paramList.Add(new SqlParameter("@StorehouseName", storehouse.Name));
            paramList.Add(new SqlParameter("@Actived", storehouse.Actived));
            paramList.Add(new SqlParameter("@Remark", storehouse.Remark));
            paramList.Add(new SqlParameter("@ID", storehouse.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateStorehouse(Storehouse storehouse, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_Storehouse SET 
                    StorehouseCode=@StorehouseCode,StorehouseName=@StorehouseName,
                    Actived=@Actived,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseCode", storehouse.Code));
            paramList.Add(new SqlParameter("@StorehouseName", storehouse.Name));
            paramList.Add(new SqlParameter("@Actived", storehouse.Actived));
            paramList.Add(new SqlParameter("@Remark", storehouse.Remark));
            paramList.Add(new SqlParameter("@ID", storehouse.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteStorehouse(int id, IDbConnection conn)
        {
            string sql = "DELETE MD_Storehouse WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteStorehouse(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_Storehouse WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Storehouse> SelectAllStorehouses(IDbConnection conn)
        {

            string sql = "SELECT ID,StorehouseCode,StorehouseName,Actived,Remark FROM MD_Storehouse";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<Storehouse> list = new List<Storehouse>();
            while (reader.Read())
            {
                Storehouse sh = new Storehouse();
                sh.ID = reader.GetInt32(0);
                sh.Code = reader.GetString(1);
                sh.Name = reader.GetString(2);
                sh.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    sh.Remark = reader.GetString(4);
                }
                list.Add(sh);
            }
            reader.Close();
            return list;
           
        }

        public Storehouse SelectStorehouse(int id, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,StorehouseCode,StorehouseName,Actived,Remark 
            FROM MD_Storehouse
            WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Storehouse result = null;
            while (reader.Read())
            {
                result = new Storehouse();
                result.ID = reader.GetInt32(0);
                result.Code = reader.GetString(1);
                result.Name = reader.GetString(2);
                result.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    result.Remark = reader.GetString(4);
                }
            }
            reader.Close();
            return result;
        }



        public Storehouse SelectStorehouse(string code, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,StorehouseCode,StorehouseName,Actived,Remark 
            FROM MD_Storehouse
            WHERE StorehouseCode=@Code";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", code));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            Storehouse result = null;
            while (reader.Read())
            {
                result = new Storehouse();
                result.ID = reader.GetInt32(0);
                result.Code = reader.GetString(1);
                result.Name = reader.GetString(2);
                result.Actived = reader.GetBoolean(3);
                if (!reader.IsDBNull(4))
                {
                    result.Remark = reader.GetString(4);
                }
            }
            reader.Close();
            return result;
        }

//        public List<Storehouse> SearchStorehoures(string codeCond, string nameCond, IDbConnection conn)
//        {
//            string sql = @"
//            SELECT ID,StorehouseCode,StorehouseName,Actived,Remark 
//            FROM MD_Storehouse
//            WHERE (StorehouseCode LIKE @CodeCond)
//                AND(StorehouseName LIKE @NameCond)";
//            List<SqlParameter> paramList = new List<SqlParameter>();
//            paramList.Add(new SqlParameter("@CodeCond", string.Format("'%{0}%'", codeCond)));
//            paramList.Add(new SqlParameter("@NameCond", string.Format("'%{0}%'", nameCond)));
//            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList);
//            List<Storehouse> list = new List<Storehouse>();
//            while (reader.Read())
//            {
//                Storehouse sh = new Storehouse();
//                sh.ID = reader.GetInt32(0);
//                sh.Code = reader.GetString(1);
//                sh.Name = reader.GetString(2);
//                sh.Actived = reader.GetBoolean(3);
//                if (!reader.IsDBNull(4))
//                {
//                    sh.Remark = reader.GetString(4);
//                }
//                list.Add(sh);
//            }
//            reader.Close();
//            return list;
//        }

      



        #endregion
    }
}
