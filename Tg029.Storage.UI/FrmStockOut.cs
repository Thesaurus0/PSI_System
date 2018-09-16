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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tg029.Storage.UI.Bill;
using Tg029.Storage.Core;
using Tg029.Storage.Model;
using Tg029.Storage.UI.Report;

namespace Tg029.Storage.UI
{
    public partial class FrmStockOut : Form
    {
        private const string BILL_TYPE = "销货单";

        public FrmStockOut()
        {
            InitializeComponent();
        }

        private void FrmStockIN_Load(object sender, EventArgs e)
        {
            //把功能菜单全部打开
            this.treeView1.ExpandAll();

           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
                {
                    lblDescription.Text = e.Node.Tag == null ? "" : e.Node.Tag.ToString();
                }

                PermissionService service = new PermissionService();
                if (e.Node.Parent != null)
                {
                    if (!service.IsUserAccess(e.Node.Text))
                    {
                        throw new ApplicationException("权限不足，无法执行此操作！");
                    }
                }

                switch (e.Node.Text)
                {
                    case "销货单录入":
                        CtrlBillInput ctrl = new CtrlBillInput();
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.BillType = new CacheService().GetBillType(BILL_TYPE);
                        ctrl.CompanyType = Tg029.Storage.Model.CompanyType.Customer;
                        break;
                    case "作废我的销货单":
                        CtrlBillOp ctrlOp = new CtrlBillOp();
                        this.AddCtrlIntoPanel(ctrlOp);
                        ctrlOp.BillType = new CacheService().GetBillType(BILL_TYPE);
                        ctrlOp.CancelOutButtonVisible = false;
                        ctrlOp.BlankOutButtonVisible = true;
                        ctrlOp.MakerConditionVisible = false;
                        break;
                    case "冲销我的销货单":
                        CtrlBillOp ctrlC = new CtrlBillOp();
                        this.AddCtrlIntoPanel(ctrlC);
                        ctrlC.BillType = new CacheService().GetBillType(BILL_TYPE);
                        ctrlC.BlankOutButtonVisible = false;
                        ctrlC.CancelOutButtonVisible = true;
                        ctrlC.MakerConditionVisible = false;
                        break;
                    case "作废全部销货单":
                        CtrlBillOp ctrlOpAll = new CtrlBillOp();
                        this.AddCtrlIntoPanel(ctrlOpAll);
                        ctrlOpAll.BillType = new CacheService().GetBillType(BILL_TYPE);
                        ctrlOpAll.CancelOutButtonVisible = false;
                        ctrlOpAll.BlankOutButtonVisible = true;
                        ctrlOpAll.MakerConditionVisible = true;
                        break;
                    case "冲销全部销货单":
                        CtrlBillOp ctrlCAll = new CtrlBillOp();
                        ctrlCAll.BillType = new CacheService().GetBillType(BILL_TYPE);
                        ctrlCAll.CancelOutButtonVisible = true;
                        ctrlCAll.BlankOutButtonVisible = false;
                        ctrlCAll.MakerConditionVisible = true;
                        break;

                    case "客户退货单录入":
                        CtrlBillInput cbi = new CtrlBillInput();
                        this.AddCtrlIntoPanel(cbi);
                        cbi.BillType = new CacheService().GetBillType("客户退货单");
                        cbi.CompanyType = Tg029.Storage.Model.CompanyType.Customer;
                        break;
                    case "客户退还单作废":
                        CtrlBillOp cbo = new CtrlBillOp();
                        this.AddCtrlIntoPanel(cbo);
                        cbo.BillType = new CacheService().GetBillType("客户退货单");
                        cbo.BlankOutButtonVisible = true;
                        cbo.CancelOutButtonVisible = false;
                        cbo.MakerConditionVisible = true;
                        break;
                    case "查询我的销货单":
                        CtrlReport rpt = new CtrlReport();
                        rpt.ReportTemplateFile = System.IO.Path.Combine(Application.StartupPath, "MySalesBill.grf");
                        rpt.IsSupportChildReport = true;
                        this.AddCtrlIntoPanel(rpt);
                        
                        break;
                    case "按商品汇总销量":
                        CtrlReport rpt1 = new CtrlReport();
                        rpt1.ReportTemplateFile = System.IO.Path.Combine(Application.StartupPath, "RptSalesByGoods.grf");
                        rpt1.IsSupportChildReport = false;
                        this.AddCtrlIntoPanel(rpt1);
                        break;
                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }


        private void AddCtrlIntoPanel(UserControl ctrl)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
        }

        private void tsbShowTree_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = false;
        }

        private void tsbHideTree_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = true;
        }

       
    }
}
