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
    public class UserDAO: IUserDAO
    {
        #region IUserDAO 成员

        public void InsertUser(User user, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_User(UserCode,UserName,Password,Actived,Remark) 
            VALUES(@UserCode,@UserName,@Password,@Actived,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);

        }

        public void InsertUser(User user, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_User(UserCode,UserName,Password,Actived,Remark) 
            VALUES(@UserCode,@UserName,@Password,@Actived,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
        }

        public void UpdateUser(User user, IDbConnection conn)
        {           
            string sql = @"
                UPDATE MD_User SET 
                    UserCode=@UserCode,UserName=@UserName,
                    Actived=@Actived,Password=@Password,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            paramList.Add(new SqlParameter("@ID", user.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateUser(User user, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_User SET 
                    UserCode=@UserCode,UserName=@UserName,
                    Actived=@Actived,Password=@Password,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", user.Code));
            paramList.Add(new SqlParameter("@UserName", user.Name));
            paramList.Add(new SqlParameter("@Password", user.Password));
            paramList.Add(new SqlParameter("@Actived", user.Actived));
            paramList.Add(new SqlParameter("@Remark", user.Remark));
            paramList.Add(new SqlParameter("@ID", user.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }


        public void DeleteUser(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_User_Resource WHERE User_ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);

            sql = "DELETE MD_User WHERE ID=@ID";
            paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<User> GetAllUsers(IDbConnection conn)
        {
            string sql = "SELECT ID,UserCode,UserName,Password,Actived,Remark FROM MD_User";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<User> userList = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.ID = reader.GetInt32(0);
                user.Code = reader.GetString(1);
                user.Name = reader.GetString(2);
                user.Password = reader.GetString(3);
                user.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    user.Remark = reader.GetString(5);
                }
                userList.Add(user);
            }
            reader.Close();
            return userList;
        }

        public User SelectUser(string code, string password, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,UserCode,UserName,Password,Actived,Remark 
            FROM MD_User
            WHERE UserCode=@UserCode AND Password=@Password";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserCode", code));
            paramList.Add(new SqlParameter("@Password", password));
            DataTable dt = DataAccessUtil.ExecuteDataTable(sql, paramList, (SqlConnection)conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            if (dt.Rows.Count > 1)
            {
                throw new ApplicationException("用户不唯一。");
            }
            DataRow row = dt.Rows[0];

            User user = new User();
            user.ID = (int)row[0];
            user.Code = (string)row[1];
            user.Name = (string)row[2];
            user.Password = (string)row[3];
            user.Actived = (bool)row[4];
            user.Remark = (string)row[5];
            //user.Actived = row["Actived"];
            return user;
        }

        public void AddResourceIntoUser(int resourceID, int userID, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_User_Resource(User_ID,Resource_ID) 
            VALUES(@UserID,@ResourceID)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserID", userID));
            paramList.Add(new SqlParameter("@ResourceID", resourceID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void AddResourceIntoUser(int resourceID, int userID, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_User_Resource(User_ID,Resource_ID) 
            VALUES(@UserID,@ResourceID)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserID", userID));
            paramList.Add(new SqlParameter("@ResourceID", resourceID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }


        public void RemoveResourceIntoUser(int userID, IDbConnection conn)
        {
            string sql = "DELETE MD_User_Resource WHERE User_ID=@UserID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserID", userID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void RemoveResourcesFromUser(int userID, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_User_Resource WHERE User_ID=@UserID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@UserID", userID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        #endregion
    }
}
