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
    public class StockDAO : IStockDAO
    {
        #region IStockDAO 成员

        public void InsertStock(Stock stock, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_Stock(Storehouse_ID,Goods_ID,Count) 
            VALUES(@StorehouseID,@GoodsID,@Count)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@GoodsID", stock.Goods.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
   
        }

        public void InsertStock(Stock stock, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            INSERT INTO MD_Stock(Storehouse_ID,Goods_ID,Count) 
            VALUES(@StorehouseID,@GoodsID,@Count)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@GoodsID", stock.Goods.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            DataAccessUtil.ExecuteNonQuery(sql, paramList,(SqlTransaction)trans);
            object idObj = DataAccessUtil.ExecuteScalar("SELECT @@IDENTITY", new List<SqlParameter>(), (SqlTransaction)trans);
            if (idObj != null)
            {
                stock.ID = int.Parse(idObj.ToString());
            }
        }

        public void UpdateStock(Stock stock, IDbConnection conn)
        {
            string sql = @"
                UPDATE MD_Stock SET 
                    Storehouse_ID=@StorehouseID,Goods_ID=@GoodsID,Count=@Count 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@GoodsID", stock.Goods.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            paramList.Add(new SqlParameter("@ID", stock.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void UpdateStock(Stock stock, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
                UPDATE MD_Stock SET 
                    Storehouse_ID=@StorehouseID,Goods_ID=@GoodsID,Count=@Count 
                WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseID", stock.Storehouse.ID));
            paramList.Add(new SqlParameter("@GoodsID", stock.Goods.ID));
            paramList.Add(new SqlParameter("@Count", stock.Count));
            paramList.Add(new SqlParameter("@ID", stock.ID));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public void DeleteStock(int id, IDbConnection conn)
        {
            string sql = "DELETE MD_Stock WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteStock(int id, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_Stock WHERE ID=@ID";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", id));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlTransaction)trans);
        }

        public List<Stock> SelectAllStocks(IDbConnection conn)
        {
            string sql = @"
            SELECT 
                Ms.ID, Ms.Count,
                Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,Mg.Unit,Mg.Standard,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived
            FROM MD_Stock AS Ms
            INNER JOIN MD_Storehouse AS Msh ON Ms.Storehouse_ID=Msh.ID
            INNER JOIN MD_Goods AS Mg ON Ms.Goods_ID=Mg.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            ";

            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, new List<SqlParameter>(), (SqlConnection)conn);
            return this.SelectStocks(sql, new List<SqlParameter>(), reader);
        }

        public List<Stock> SelectStocksByStorehouseID(int storehouseID, IDbConnection conn)
        {
            string sql = @"
            SELECT 
                 Ms.ID, Ms.Count,
                Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,Mg.Unit,Mg.Standard,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived
            FROM MD_Stock AS Ms
            INNER JOIN MD_Storehouse AS Msh ON Ms.Storehouse_ID=Msh.ID
            INNER JOIN MD_Goods AS Mg ON Ms.Goods_ID=Mg.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            WHERE Ms.Storehouse_ID=@StorehouseID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@StorehouseID", storehouseID));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            return this.SelectStocks(sql, paramList, reader);
        }

        public List<Stock> SelectStocksByGoodsID(int goodsID, IDbConnection conn)
        {
            string sql = @"
            SELECT 
                Ms.ID, Ms.Count,
                Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,Mg.Unit,Mg.Standard,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived
            FROM MD_Stock AS Ms
            INNER JOIN MD_Storehouse AS Msh ON Ms.Storehouse_ID=Msh.ID
            INNER JOIN MD_Goods AS Mg ON Ms.Goods_ID=Mg.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            WHERE Ms.Goods_ID=@GoodsID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsID", goodsID));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            return this.SelectStocks(sql, paramList, reader);
        }

        public List<Stock> SelectStocksByGoodsCategoryID(int goodsCategoryID, IDbConnection conn)
        {
            string sql = @"
            SELECT 
                 Ms.ID, Ms.Count,
                Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,Mg.Unit,Mg.Standard,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived
            FROM MD_Stock AS Ms
            INNER JOIN MD_Storehouse AS Msh ON Ms.Storehouse_ID=Msh.ID
            INNER JOIN MD_Goods AS Mg ON Ms.Goods_ID=Mg.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            WHERE Mgc.ID=@GoodsCategoryID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsCategoryID", goodsCategoryID));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            return this.SelectStocks(sql, paramList, reader);
        }



        public Stock SelectStockByGoodsAndStorehouse(int goodsID, int storehouseID, IDbConnection conn, IDbTransaction trans)
        {
            string sql = @"
            SELECT 
                Ms.ID, Ms.Count,
                Msh.ID,Msh.StorehouseCode,Msh.StorehouseName,Msh.Actived,Msh.Remark,
                Mg.ID,Mg.GoodsCode,Mg.GoodsName,Mg.Actived,Mg.Remark,Mg.Unit,Mg.Standard,
                Mgf.ID,Mgf.GoodsFromCode,Mgf.GoodsFromName,Mgf.Actived,
                Mgc.ID,Mgc.GoodsCategoryCode,Mgc.GoodsCategoryName,Mgc.Actived
            FROM MD_Stock AS Ms
            INNER JOIN MD_Storehouse AS Msh ON Ms.Storehouse_ID=Msh.ID
            INNER JOIN MD_Goods AS Mg ON Ms.Goods_ID=Mg.ID
            INNER JOIN MD_GoodsFrom AS Mgf ON Mg.GoodsFrom_ID=Mgf.ID
            INNER JOIN MD_GoodsCategory AS Mgc ON Mg.GoodsCategory_ID=Mgc.ID
            WHERE Ms.Goods_ID=@GoodsID AND Ms.Storehouse_ID=@StorehouseID
            ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@GoodsID", goodsID));
            paramList.Add(new SqlParameter("@StorehouseID", storehouseID));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlTransaction)trans);
            List<Stock> list = this.SelectStocks(sql, paramList, reader);
            if (list.Count == 0)
            {
                return null;
            }
            return list[0];
        }
        #endregion


        private List<Stock> SelectStocks(string sql, List<SqlParameter> paramList, SqlDataReader reader)
        {
            List<Stock> list = new List<Stock>();
            while (reader.Read())
            {
                Stock stock = new Stock();
                stock.ID = reader.GetInt32(0);
                stock.Count = reader.GetInt32(1);

                stock.Storehouse = new Storehouse();
                stock.Storehouse.ID = reader.GetInt32(2);
                stock.Storehouse.Code = reader.GetString(3);
                stock.Storehouse.Name = reader.GetString(4);
                stock.Storehouse.Actived = reader.GetBoolean(5);
                if (!reader.IsDBNull(6))
                {
                    stock.Storehouse.Remark = reader.GetString(6);
                }

                stock.Goods = new Goods();
                stock.Goods.ID = reader.GetInt32(7);
                stock.Goods.Code = reader.GetString(8);
                stock.Goods.Name = reader.GetString(9);
                stock.Goods.Actived = reader.GetBoolean(10);
                if (!reader.IsDBNull(11))
                {
                    stock.Goods.Remark = reader.GetString(11);
                }
                stock.Goods.Unit = reader.GetString(12);
                stock.Goods.Standard = reader.GetString(13);

                stock.Goods.From = new GoodsFrom();
                stock.Goods.From.ID = reader.GetInt32(14);
                stock.Goods.From.Code = reader.GetString(15);
                stock.Goods.From.Name = reader.GetString(16);
                stock.Goods.From.Actived = reader.GetBoolean(17);

                stock.Goods.Category = new GoodsCategory();
                stock.Goods.Category.ID = reader.GetInt32(18);
                stock.Goods.Category.Code = reader.GetString(19);
                stock.Goods.Category.Name = reader.GetString(20);
                stock.Goods.Category.Actived = reader.GetBoolean(21);

                list.Add(stock);
            }
            reader.Close();
            return list;
        }

        
    }
}
