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
using Tg029.Storage.Data;

namespace Tg029.Storage.Core
{
    public class StockBillService
    {
        /// <summary>
        /// 开票并更改库存
        /// </summary>
        /// <param name="bill"></param>
        public void MakeBill(StockBill bill)
        {

            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. 保存票据信息
                    IStockBillDAO sbDao = DAOFactory.Instance.CreateStockBillDAO();
                    sbDao.InsertBill(bill, conn, trans);

                    // 2. 更改库存数据
                    IStockDAO sDao = DAOFactory.Instance.CreateStockDAO();
                    foreach (StockBillItem item in bill.Items)
                    {
                        Stock stock = sDao.SelectStockByGoodsAndStorehouse(item.Goods.ID, bill.Storehouse.ID, conn, trans);

                        //如果库存中没有该商品，则创建该商品的库存信息。
                        if (stock == null)
                        {
                            stock = new Stock();
                            stock.Storehouse = bill.Storehouse;
                            stock.Goods = item.Goods;
                            stock.Count = 0;
                            sDao.InsertStock(stock, conn, trans);
                        }

                        //执行出入库操作
                        if (bill.BillType.IsOutStorehouse)//出库
                        {
                            stock.Count -= item.Count;
                        }
                        else// 入库
                        {
                            stock.Count += item.Count;
                        }
                        sDao.UpdateStock(stock, conn, trans);
                    }


                    // 3. 提交
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // 4. 回滚
                    trans.Rollback();
                    throw ex;
                }
            }
      
        }

        /// <summary>
        /// 冲销一个票据
        /// </summary>
        /// <param name="bill">要冲销的票据</param>
        /// <param name="maker">冲销人</param>
        /// <param name="makeDate">冲销日期</param>
        /// <param name="remark">备注</param>
        public StockBill CancelOutBill(StockBill bill, string maker, DateTime makeDate, string remark)
        {
           

            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                bill = this.FindBill(bill.ID);

                // 1. 构造负字票
                StockBill redBill = new StockBill();
                redBill.Actived = true;
                redBill.BillType = bill.BillType;
                redBill.Code = bill.Code;
                redBill.Company = bill.Company;
                redBill.CreateDate = DateTime.Now;
                redBill.IsCancelOut = false;
                redBill.IsRedBill = true;
                redBill.MakeDate = makeDate;
                redBill.Maker = maker;
                redBill.Remark = "对冲票据" + bill.ID.ToString();
                redBill.Storehouse = bill.Storehouse;
                foreach (StockBillItem item in bill.Items)
                {
                    StockBillItem redBillItem = new StockBillItem();
                    redBillItem.Goods = item.Goods;
                    redBillItem.Count = item.Count * (-1);
                    redBillItem.UnitPrice = item.UnitPrice;
                    redBill.Items.Add(redBillItem);
                }

                IDbTransaction trans = conn.BeginTransaction();
                try
                {

                    IStockBillDAO sbDao = DAOFactory.Instance.CreateStockBillDAO();
                    // 2. 保存红票
                    sbDao.InsertBill(redBill, conn, trans);

                    // 3. 保存原票据信息
                    bill.IsCancelOut = true;
                    bill.Remark += " 被冲销" + redBill.ID.ToString();
                    sbDao.UpdateBill(bill, conn, trans);

                    // 4. 更改库存数据
                    IStockDAO sDao = DAOFactory.Instance.CreateStockDAO();
                    foreach (StockBillItem redBillItem in redBill.Items)
                    {
                        Stock stock = sDao.SelectStockByGoodsAndStorehouse(redBillItem.Goods.ID, bill.Storehouse.ID, conn, trans);

                        //执行出入库操作
                        if (redBill.BillType.IsOutStorehouse)//出库
                        {
                            stock.Count -= redBillItem.Count;
                        }
                        else// 入库
                        {
                            stock.Count += redBillItem.Count;
                        }
                        sDao.UpdateStock(stock, conn, trans);
                    }


                    // 5. 提交
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // 6. 回滚
                    bill.IsCancelOut = false;
                    trans.Rollback();
                    throw ex;
                }


                return redBill;
            }
        }

        /// <summary>
        /// 作废一个票据
        /// </summary>
        /// <param name="bill">要做作废的票据</param>
        /// <param name="remark">备注</param>
        public void BlankOutBill(StockBill bill, string remark)
        {
            if (!bill.Actived)
            {
                throw new ApplicationException(string.Format("票据{0}已经被作废，不能重复作废。", bill.ID));
            }
            if (bill.IsCancelOut)
            {
                throw new ApplicationException(string.Format("票据{0}已经被冲销，不能作废。", bill.ID));
            }
            if (bill.IsRedBill)
            {
                throw new ApplicationException(string.Format("票据{0}是冲销票，不能作废。", bill.ID));
            }

            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    //1. 更新票据状态
                    bill.Actived = false;
                    bill.Remark += remark;
                    IStockBillDAO sbDao = DAOFactory.Instance.CreateStockBillDAO();
                    sbDao.UpdateBill(bill, conn, trans);

                    //2. 更改库存数据
                    IStockDAO sDao = DAOFactory.Instance.CreateStockDAO();
                    foreach (StockBillItem item in bill.Items)
                    {
                        //List<Stock> stockList = sDao.SelectStocksByGoodsID(item.Goods.ID, conn);
                        //Stock stock = null;
                        //foreach (Stock s in stockList)
                        //{
                        //    if (s.Storehouse.ID == bill.Storehouse.ID)
                        //    {
                        //        stock = s;
                        //        break;
                        //    }
                        //}
                        Stock stock = sDao.SelectStockByGoodsAndStorehouse(item.Goods.ID, bill.Storehouse.ID, conn, trans);


                        //执行出入库操作
                        if (bill.BillType.IsOutStorehouse)//出库
                        {
                            stock.Count += item.Count;
                        }
                        else// 入库
                        {
                            stock.Count -= item.Count;
                        }
                        sDao.UpdateStock(stock, conn, trans);
                    }


                    //3. 记录作废票据的事件日志
                    LogService.Info("作废单据" + bill.ID);


                    // 4. 提交
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // 4. 回滚
                    bill.Actived = true;
                    trans.Rollback();
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 根据ID获取一个票据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StockBill FindBill(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStockBillDAO dao = DAOFactory.Instance.CreateStockBillDAO();
                return dao.SelectBill(id, conn);
            }
        }

        /// <summary>
        /// 根据给定的一些条件进行票据的模糊查找
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="companyCond"></param>
        /// <param name="billMakerCond"></param>
        /// <returns></returns>
        public List<StockBill> SearchBill(DateTime fromDate, DateTime toDate,
            string companyCond,string billMakerCond,string billID,StockBillType billType )
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStockBillDAO dao = DAOFactory.Instance.CreateStockBillDAO();
                List<StockBill> bills = dao.SearchBills(fromDate, toDate, companyCond, billMakerCond, conn);
                for (int i = bills.Count - 1; i >= 0; i--)
                {
                    StockBill bill = bills[i];
                    if (!bill.ID.ToString().Contains(billID))
                    {
                        bills.Remove(bill);
                    }
                    if (billType.Equals(bill.BillType))
                    {
                        bills.Remove(bill);
                    }
                }
                return bills;
            }
        }
    }
}
