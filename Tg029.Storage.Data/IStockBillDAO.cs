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
    public interface IStockBillDAO
    {
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertBill(StockBill bill, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        void UpdateBill(StockBill bill, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateBill(StockBill bill, IDbConnection conn, IDbTransaction trans);

        

        /// <summary>
        /// 根据ID检索票据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StockBill SelectBill(int id, IDbConnection conn);

        /// <summary>
        /// 模糊检索票据
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="companyCond"></param>
        /// <param name="makerCond"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<StockBill> SearchBills(DateTime fromDate, DateTime toDate,
            string companyCond, string makerCond,IDbConnection conn);
        
    }
}
