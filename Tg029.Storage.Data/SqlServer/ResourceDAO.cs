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
    public class ResourceDAO:IResourceDAO
    {

        #region IResourceDAO 成员

        public void InsertResource(Resource res, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_Resource(ResourceCode,ResourceName) 
            VALUES(@ResourceCode,@ResourceName)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertResource(Resource res, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_Resource(ResourceCode,ResourceName) 
            VALUES(@ResourceCode,@ResourceName)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateResource(Resource res, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_Resource SET 
                    ResourceCode=@ResourceCode,ResourceName=@ResourceName
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));
            paramList.Add(new SqlParameter("@ID", res.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateResource(Resource res, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_Resource SET 
                    ResourceCode=@ResourceCode,ResourceName=@ResourceName
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ResourceCode", res.Code));
            paramList.Add(new SqlParameter("@ResourceName", res.Name));
            paramList.Add(new SqlParameter("@ID", res.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

      

        public void DeleteResource(int resID, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_User_Resource WHERE Resource_ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", resID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);

            sql = "DELETE MD_Resource WHERE ID=@ID";
            paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", resID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Resource> GetAllResources(IDbConnection conn)
        {
            string sql = "SELECT ID,ResourceCode,ResourceName FROM MD_Resource";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<Resource> resList = new List<Resource>();
            while (reader.Read())
            {
                Resource res = new Resource();
                res.ID = reader.GetInt32(0);
                res.Code = reader.GetString(1);
                res.Name = reader.GetString(2);
                resList.Add(res);
            }
            reader.Close();
            return resList;
        }

        public List<Resource> GetResources(int userID, IDbConnection conn)
        {
            string sql = @"
                SELECT ID,ResourceCode,ResourceName 
                FROM MD_Resource AS Mr
                INNER JOIN MD_User_Resource AS Mur ON Mr.ID=Mur.Resource_ID
                WHERE Mur.User_ID=@UserID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserID", userID));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Resource> resList = new List<Resource>();
            while (reader.Read())
            {
                Resource res = new Resource();
                res.ID = reader.GetInt32(0);
                res.Code = reader.GetString(1);
                res.Name = reader.GetString(2);
                resList.Add(res);
            }
            reader.Close();
            return resList;
        }

        #endregion
    }
}
