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
    public class StockBillTypeDAO: IStockBillTypeDAO
    {

        #region IBillTypeDAO 成员

        public void InsertBillType(StockBillType stockBillType, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_BillType(Name,Actived,IsOut) 
            VALUES(@Name,@Actived,@IsOut)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", stockBillType.Name));
            paramList.Add(new SqlParameter("@Actived", stockBillType.Actived));
            paramList.Add(new SqlParameter("@isOut", stockBillType.IsOutStorehouse));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void InsertBillType(StockBillType stockBillType, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_BillType(Name,Actived,IsOut) 
            VALUES(@Name,@Actived,@IsOut)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", stockBillType.Name));
            paramList.Add(new SqlParameter("@Actived", stockBillType.Actived));
            paramList.Add(new SqlParameter("@isOut", stockBillType.IsOutStorehouse));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
          
        }

        public void UpdateBillType(StockBillType stockBillType, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_BillType SET 
                    Name=@Name,Actived=@Actived,IsOut=@IsOut
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", stockBillType.Name));
            paramList.Add(new SqlParameter("@Actived", stockBillType.Actived));
            paramList.Add(new SqlParameter("@isOut", stockBillType.IsOutStorehouse));
            paramList.Add(new SqlParameter("@ID", stockBillType.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateBillType(StockBillType stockBillType, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_BillType SET 
                    StockBillTypeCode=@StockBillTypeCode,StockBillTypeName=@StockBillTypeName,
                    Actived=@Actived 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StockBillTypeCode", stockBillType.Code));
            paramList.Add(new SqlParameter("@StockBillTypeName", stockBillType.Name));
            paramList.Add(new SqlParameter("@Actived", stockBillType.Actived));
            paramList.Add(new SqlParameter("@ID", stockBillType.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteBillType(int id, IDbConnection conn)
        {
            string sql = "DELETE MD_BillType WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteBillType(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_BillType WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<StockBillType> SelectAllBillTypes(IDbConnection conn)
        {

            string sql = "SELECT ID,Name,Actived,IsOut FROM MD_BillType";
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            List<StockBillType> list = new List<StockBillType>();
            while (reader.Read())
            {
                StockBillType sh = new StockBillType();
                sh.ID = reader.GetInt32(0);
                sh.Name = reader.GetString(1);
                sh.Actived = reader.GetBoolean(2);
                sh.IsOutStorehouse = reader.GetBoolean(3);
                list.Add(sh);
            }
            reader.Close();
            return list;

        }

     

        #endregion

    }
}
