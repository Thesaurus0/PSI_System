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
    public class StockBillDAO : IStockBillDAO
    {

        #region IBillDAO 成员

      

        public void InsertBill(StockBill bill, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_Bill(Storehouse_ID,BillType_ID,Maker,MakeDate,Actived,IsCancelOut,IsRedBill,Company_ID,Remark) 
            VALUES(@StorehouseID,@BillTypeID,@Maker,@MakeDate,@Actived,@IsCancelOut,@IsRedBill,@CompanyID,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseID", bill.Storehouse.ID));
            paramList.Add(new SqlParameter("@BillTypeID", bill.BillType.ID));
            paramList.Add(new SqlParameter("@Maker", bill.Maker));
            paramList.Add(new SqlParameter("@MakeDate", bill.MakeDate));
            paramList.Add(new SqlParameter("@Actived", bill.Actived));
            paramList.Add(new SqlParameter("@IsCancelOut", bill.IsCancelOut));
            paramList.Add(new SqlParameter("@IsRedBill", bill.IsRedBill));
            paramList.Add(new SqlParameter("@CompanyID", bill.Company.ID));
            paramList.Add(new SqlParameter("@Remark", bill.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
            object idObj = DataAccessUtil.ExecuteScalar("SELECT @@IDENTITY", new List<SqlParameter>(), (SqlTransaction)trans);
            int newID = int.Parse(idObj.ToString());
           

            foreach (StockBillItem item in bill.Items)
            {
                sql = @"
                INSERT INTO MD_BillItem(Bill_ID,Goods_ID,UnitPrice,Count,Remark) 
                VALUES(@BillID,@GoodsID,@UnitPrice,@Count,@Remark)";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@BillID", newID));
                paramList.Add(new SqlParameter("@GoodsID", item.Goods.ID));
                paramList.Add(new SqlParameter("@UnitPrice", item.UnitPrice));
                paramList.Add(new SqlParameter("@Count", item.Count));
                paramList.Add(new SqlParameter("@Remark", ""));
                DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
            }
            bill.ID = newID;
        }

        public void UpdateBill(StockBill bill, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_Bill SET 
                    Actived=@Actived,IsCancelOut=@IsCancelOut,IsRedBill=@IsRedBill,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Actived", bill.Actived));
            paramList.Add(new SqlParameter("@IsCancelOut", bill.IsCancelOut));
            paramList.Add(new SqlParameter("@IsRedBill", bill.IsRedBill));
            paramList.Add(new SqlParameter("@Remark", bill.Remark));
            paramList.Add(new SqlParameter("@ID", bill.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateBill(StockBill bill, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_Bill SET 
                    Actived=@Actived,IsCancelOut=@IsCancelOut,IsRedBill=@IsRedBill,Remark=@Remark 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Actived", bill.Actived));
            paramList.Add(new SqlParameter("@IsCancelOut", bill.IsCancelOut));
            paramList.Add(new SqlParameter("@IsRedBill", bill.IsRedBill));
            paramList.Add(new SqlParameter("@Remark", bill.Remark));
            paramList.Add(new SqlParameter("@ID", bill.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }



        public StockBill SelectBill(int id, IDbConnection conn)
        {
            string sql = @"
            SELECT 
                Mb.ID,Mb.Maker,Mb.MakeDate,Mb.CreateDate,Mb.Actived,Mb.IsCancelOut,Mb.IsRedBill,Mb.Remark,
                Mbt.ID,Mbt.Name,Mbt.Actived,Mbt.IsOut,
                Ms.ID,Ms.StorehouseCode,Ms.StorehouseName,Ms.Actived,Ms.Remark,
                Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.CompanyType,Mc.Actived,Mc.Remark
            FROM MD_Bill AS Mb 
            INNER JOIN MD_BillType AS Mbt ON Mb.BillType_ID=Mbt.ID
            INNER JOIN MD_Storehouse AS Ms ON Mb.Storehouse_ID=Ms.ID
            INNER JOIN MD_Company AS Mc ON Mb.Company_ID=Mc.ID
            WHERE Mb.ID=@ID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            StockBill bill = null;
            while (reader.Read())
            {
                bill = new StockBill();
                bill.ID = reader.GetInt32(0);
                bill.Maker = reader.GetString(1);
                bill.MakeDate = reader.GetDateTime(2);
                bill.CreateDate = reader.GetDateTime(3);
                bill.Actived = reader.GetBoolean(4);
                bill.IsCancelOut = reader.GetBoolean(5);
                bill.IsRedBill = reader.GetBoolean(6);
                if (!reader.IsDBNull(7))
                {
                    bill.Remark = reader.GetString(7);
                }

                bill.BillType = new StockBillType();
                bill.BillType.ID = reader.GetInt32(8);
                bill.BillType.Name = reader.GetString(9);
                bill.BillType.Actived = reader.GetBoolean(10);
                bill.BillType.IsOutStorehouse = reader.GetBoolean(11);

                // Ms.ID,Ms.StorehouseCode,Ms.StorehouseName,Ms.Actived,Ms.Remark,
                bill.Storehouse = new Storehouse();
                bill.Storehouse.ID = reader.GetInt32(12);
                bill.Storehouse.Code = reader.GetString(13);
                bill.Storehouse.Name = reader.GetString(14);
                bill.Storehouse.Actived = reader.GetBoolean(15);
                if (!reader.IsDBNull(16))
                {
                    bill.Storehouse.Remark = reader.GetString(16);
                }

                //Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.CompanyType,Mc.Actived,Mc.Remark
                bill.Company = new Company();
                bill.Company.ID = reader.GetInt32(17);
                bill.Company.Code = reader.GetString(18);
                bill.Company.Name = reader.GetString(19);
                bill.Company.CompanyType = (CompanyType)reader.GetInt32(20);
                bill.Company.Actived = reader.GetBoolean(21);
                if (!reader.IsDBNull(22))
                {
                    bill.Company.Remark = reader.GetString(22);
                }
            }
            reader.Close();

            if (bill != null)
            {
                sql = @"
                SELECT 
                    Mbi.ID,Mbi.UnitPrice,Mbi.Count,Mbi.Remark,
                    Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,
                    Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                    Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived
                FROM MD_BillItem AS Mbi
                INNER JOIN MD_Goods AS Mg ON Mbi.Goods_ID=Mg.ID
                INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
                INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
                WHERE Mbi.Bill_ID=@ID
                ";
                paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@ID", id));
                reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
                while (reader.Read())
                {
                    StockBillItem item = new StockBillItem();
                    item.UnitPrice = reader.GetDecimal(1);
                    item.Count = reader.GetInt32(2);

                    item.Goods = new Goods();
                    item.Goods.ID = reader.GetInt32(4);
                    item.Goods.Code = reader.GetString(5);
                    item.Goods.Name = reader.GetString(6);
                    item.Goods.Actived = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                    {
                        item.Goods.Remark = reader.GetString(8);
                    }

                    item.Goods.From = new GoodsFrom();
                    item.Goods.From.ID = reader.GetInt32(9);
                    item.Goods.From.Code = reader.GetString(10);
                    item.Goods.From.Name = reader.GetString(11);
                    item.Goods.From.Actived = reader.GetBoolean(12);
                    
                    item.Goods.Category = new GoodsCategory();
                    item.Goods.Category.ID = reader.GetInt32(13);
                    item.Goods.Category.Code = reader.GetString(14);
                    item.Goods.Category.Name = reader.GetString(15);
                    item.Goods.Category.Actived = reader.GetBoolean(16);
                    

                    bill.Items.Add(item);
                }
                reader.Close();
            }
            return bill;
        }

 
        public List<StockBill> SearchBills(DateTime fromDate, DateTime toDate, 
            string companyCond, string makerCond,
            IDbConnection conn)
        {
            string sql = @"
            SELECT 
                Mb.ID,Mb.Maker,Mb.MakeDate,Mb.CreateDate,Mb.Actived,Mb.IsCancelOut,Mb.IsRedBill,Mb.Remark,
                Mbt.ID,Mbt.Name,Mbt.Actived,Mbt.IsOut,
                Ms.ID,Ms.StorehouseCode,Ms.StorehouseName,Ms.Actived,Ms.Remark,
                Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.CompanyType,Mc.Actived,Mc.Remark
            FROM MD_Bill AS Mb 
            INNER JOIN MD_BillType AS Mbt ON Mb.BillType_ID=Mbt.ID
            INNER JOIN MD_Storehouse AS Ms ON Mb.Storehouse_ID=Ms.ID
            INNER JOIN MD_Company AS Mc ON Mb.Company_ID=Mc.ID
            WHERE (Mb.MakeDate BETWEEN @FromDate AND @ToDate)
                AND(Mc.CompanyCode LIKE @CompanyCond OR Mc.CompanyName LIKE @CompanyCond)
                AND(Mb.Maker LIKE @MakerCond)
                
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FromDate", fromDate));
            paramList.Add(new SqlParameter("@ToDate", toDate));
            paramList.Add(new SqlParameter("@CompanyCond", "%" + companyCond == null ? "" : companyCond + "%"));
            paramList.Add(new SqlParameter("@MakerCond", "%" + makerCond == null ? "" : makerCond + "%"));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<StockBill> billList = new List<StockBill>();
            while (reader.Read())
            {
                StockBill bill = new StockBill();
                bill.ID = reader.GetInt32(0);
                bill.Maker = reader.GetString(1);
                bill.MakeDate = reader.GetDateTime(2);
                bill.CreateDate = reader.GetDateTime(3);
                bill.Actived = reader.GetBoolean(4);
                bill.IsCancelOut = reader.GetBoolean(5);
                bill.IsRedBill = reader.GetBoolean(6);
                if (!reader.IsDBNull(7))
                {
                    bill.Remark = reader.GetString(7);
                }

                bill.BillType = new StockBillType();
                bill.BillType.ID = reader.GetInt32(8);
                bill.BillType.Name = reader.GetString(9);
                bill.BillType.Actived = reader.GetBoolean(10);
                bill.BillType.IsOutStorehouse = reader.GetBoolean(11);

                // Ms.ID,Ms.StorehouseCode,Ms.StorehouseName,Ms.Actived,Ms.Remark,
                bill.Storehouse = new Storehouse();
                bill.Storehouse.ID = reader.GetInt32(12);
                bill.Storehouse.Code = reader.GetString(13);
                bill.Storehouse.Name = reader.GetString(14);
                bill.Storehouse.Actived = reader.GetBoolean(15);
                if (!reader.IsDBNull(16))
                {
                    bill.Storehouse.Remark = reader.GetString(16);
                }

                //Mc.ID,Mc.CompanyCode,Mc.CompanyName,Mc.CompanyType,Mc.Actived,Mc.Remark
                bill.Company = new Company();
                bill.Company.ID = reader.GetInt32(17);
                bill.Company.Code = reader.GetString(18);
                bill.Company.Name = reader.GetString(19);
                bill.Company.CompanyType = (CompanyType)reader.GetInt32(20);
                bill.Company.Actived = reader.GetBoolean(21);
                if (!reader.IsDBNull(22))
                {
                    bill.Company.Remark = reader.GetString(22);
                }

                billList.Add(bill);
            }
            reader.Close();

            return billList;
        }

        #endregion
    }
}
