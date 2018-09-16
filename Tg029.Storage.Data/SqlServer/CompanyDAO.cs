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
    public class CompanyDAO : ICompanyDAO
    {
        #region ICompanyDAO 成员

        public void InsertCompany(Company company, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_Company(CompanyCode,CompanyName,CompanyType,Actived,Remark) 
            VALUES(@CompanyCode,@CompanyName,@CompanyType,@Actived,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType", (int)company.CompanyType));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertCompany(Company company, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_Company(CompanyCode,CompanyName,CompanyType,Actived,Remark) 
            VALUES(@CompanyCode,@CompanyName,@CompanyType,@Actived,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType", (int)company.CompanyType));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void UpdateCompany(Company company, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_Company SET 
                    CompanyCode=@CompanyCode,CompanyName=@CompanyName,
                    Actived=@Actived,CompanyType=@CompanyType,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType", (int)company.CompanyType));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            paramList.Add(new SqlParameter("@ID", company.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateCompany(Company company, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_Company SET 
                    CompanyCode=@CompanyCode,CompanyName=@CompanyName,
                    Actived=@Actived,CompanyType=@CompanyType,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyCode", company.Code));
            paramList.Add(new SqlParameter("@CompanyName", company.Name));
            paramList.Add(new SqlParameter("@CompanyType", (int)company.CompanyType));
            paramList.Add(new SqlParameter("@Actived", company.Actived));
            paramList.Add(new SqlParameter("@Remark", company.Remark));
            paramList.Add(new SqlParameter("@ID", company.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteCompany(int id, IDbConnection conn)
        {
            string sql = "DELETE MD_Company WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteCompany(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_Company WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Company> SelectAllCompanies(IDbConnection conn)
        {
            string sql = "SELECT ID,CompanyCode,CompanyName,CompanyType,Actived,Remark FROM MD_Company";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<Company> list = new List<Company>();
            while (reader.Read())
            {
                Company company = new Company();
                company.ID = reader.GetInt32(0);
                company.Code = reader.GetString(1);
                company.Name = reader.GetString(2);
                company.CompanyType = (CompanyType)reader.GetInt32(3);
                company.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    company.Remark = reader.GetString(5);
                }
                list.Add(company);
            }
            reader.Close();
            return list;
        }

        public List<Company> SelectCompanies(CompanyType compType, IDbConnection conn)
        {
            string sql = @"
                SELECT ID,CompanyCode,CompanyName,CompanyType,Actived,Remark 
                FROM MD_Company
                WHERE CompanyType=@CompanyType";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyType", compType));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<Company> list = new List<Company>();
            while (reader.Read())
            {
                Company company = new Company();
                company.ID = reader.GetInt32(0);
                company.Code = reader.GetString(1);
                company.Name = reader.GetString(2);
                company.CompanyType = (CompanyType)reader.GetInt32(3);
                company.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    company.Remark = reader.GetString(5);
                }
                list.Add(company);
            }
            reader.Close();
            return list;
        }

        public Company SelectCompany(int id, IDbConnection conn)
        {
            string sql = @"
                SELECT ID,CompanyCode,CompanyName,CompanyType,Actived,Remark 
                FROM MD_Company
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);

            Company company = null;
            while (reader.Read())
            {
                company = new Company();
                company.ID = reader.GetInt32(0);
                company.Code = reader.GetString(1);
                company.Name = reader.GetString(2);
                company.CompanyType = (CompanyType)reader.GetInt32(3);
                company.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    company.Remark = reader.GetString(5);
                }
            }
            reader.Close();
            return company;
        }

        public List<Company> SearchCompanies(string codeCond, string nameCond, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,CompanyCode,CompanyName,CompanyType,Actived,Remark 
            FROM MD_Company
            WHERE (CompanyCode LIKE @CodeCond)AND(CompanyName LIKE @NameCond)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CodeCond", string.Format("'%{0}%'", codeCond)));
            paramList.Add(new SqlParameter("@NameCond", string.Format("'%{0}%'", nameCond)));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<Company> list = new List<Company>();
            while (reader.Read())
            {
                Company company = new Company();
                company.ID = reader.GetInt32(0);
                company.Code = reader.GetString(1);
                company.Name = reader.GetString(2);
                company.CompanyType = (CompanyType)reader.GetInt32(3);
                company.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    company.Remark = reader.GetString(5);
                }
                list.Add(company);
            }
            reader.Close();
            return list;
        }

        public Company SelectCompany(string code, IDbConnection conn)
        {
            string sql = @"
                SELECT ID,CompanyCode,CompanyName,CompanyType,Actived,Remark 
                FROM MD_Company
                WHERE Code=@Code";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Code", code));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);

            Company company = null;
            while (reader.Read())
            {
                company = new Company();
                company.ID = reader.GetInt32(0);
                company.Code = reader.GetString(1);
                company.Name = reader.GetString(2);
                company.CompanyType = (CompanyType)reader.GetInt32(3);
                company.Actived = reader.GetBoolean(4);
                if (!reader.IsDBNull(5))
                {
                    company.Remark = reader.GetString(5);
                }
            }
            reader.Close();
            return company;
        }

        #endregion
    }
}
