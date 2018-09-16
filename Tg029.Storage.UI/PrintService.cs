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
using Tg029.Storage.Model;
using grproLib;
using System.Windows.Forms;

namespace Tg029.Storage.UI
{
    public class PrintService
    {
        private GridppReport _Report = null;

        private static PrintService _Instance = null;
        private PrintService()
        {
            _Report = new GridppReport();
            _Report.Initialize +=new _IGridppReportEvents_InitializeEventHandler(ReportInitialize);
            _Report.LoadFromFile (System.IO.Path.Combine(Application.StartupPath, "PrintTemplate.grf"));
        }

        public static PrintService GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new PrintService();
            }
            return _Instance;
        }


        private StockBill _CurrBill = null;
        public void PrintBill(StockBill bill)
        {
            _CurrBill = bill;
            _Report.Print(false);
        }

        private void ReportInitialize()
        {
            try
            {
                _Report.ParameterByName("ParamBillID").Value = _CurrBill.ID;
                _Report.ParameterByName("ParamMaker").Value = _CurrBill.Maker;
                _Report.ParameterByName("ParamDate").Value = _CurrBill.MakeDate.ToString("yyyy年MM月dd日 HH:mm");
                _Report.ParameterByName("ParamCompany").Value = _CurrBill.Company.Name;
                _Report.ParameterByName("ParamRemark").Value = _CurrBill.Remark;
                _Report.ParameterByName("ParamStorehouse").Value = _CurrBill.Storehouse;

                string goods = "";
                string goodsFrom = "";
                string goodsCategory = "";
                string count = "";
                string unitPrice = "";
                string money = "";
                foreach (StockBillItem item in _CurrBill.Items)
                {
                    goods += "\r\n" + item.Goods.Name;
                    goodsFrom += "\r\n" + item.Goods.From.Name;
                    goodsCategory += "\r\n" + item.Goods.Category.Name;
                    count += "\r\n" + item.Count;
                    unitPrice += "\r\n" + item.UnitPrice.ToString("0.00");
                    money += "\r\n" + item.Money.ToString("0.00");
                }
                _Report.ParameterByName("ParamGoods").Value = goods;
                _Report.ParameterByName("ParamGoodsFrom").Value = goodsFrom;
                _Report.ParameterByName("ParamGoodsCategory").Value = goodsCategory;
                _Report.ParameterByName("ParamCount").Value = count;
                _Report.ParameterByName("ParamUnitPrice").Value = unitPrice;
                _Report.ParameterByName("ParamMoney").Value = money;


            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
    }
}
