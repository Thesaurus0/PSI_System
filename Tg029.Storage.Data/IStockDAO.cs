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
using Tg029.Storage.Model;

namespace Tg029.Storage.Data
{
    public interface IStockDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        void InsertStock(Stock stock, IDbConnection conn);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertStock(Stock stock, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        void UpdateStock(Stock stock, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateStock(Stock stock, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteStock(int id, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteStock(int id, IDbConnection conn, IDbTransaction trans);


        List<Stock> SelectAllStocks(IDbConnection conn);

        //List<Stock> SelectStocks(Storehouse storehouse, IDbConnection conn);

        //List<Stock> SelectStocks(Goods goods, IDbConnection conn);

        //List<Stock> SelectStocks(GoodsCategory goodsCategory, IDbConnection conn);

        List<Stock> SelectStocksByStorehouseID(int storehouseID, IDbConnection conn);

        List<Stock> SelectStocksByGoodsID(int goodsID, IDbConnection conn);

        Stock SelectStockByGoodsAndStorehouse(int goodsID, int storehouseID, IDbConnection conn, IDbTransaction trans);

        List<Stock> SelectStocksByGoodsCategoryID(int goodsCategoryID, IDbConnection conn);

    }
}
