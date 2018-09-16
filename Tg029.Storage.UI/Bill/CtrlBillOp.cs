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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tg029.Storage.Model;
using Tg029.Storage.Core;

namespace Tg029.Storage.UI.Bill
{
    public partial class CtrlBillOp : UserControl
    {
        public CtrlBillOp()
        {
            InitializeComponent();
        }


        #region 公共属性

        /// <summary>
        /// 单据类型
        /// </summary>
        public StockBillType BillType { get; set; }

        /// <summary>
        /// 是否显示【冲销单据】按钮
        /// </summary>
        public bool CancelOutButtonVisible
        {
            get
            {
                return tsbCancelOut.Visible;
            }
            set
            {
                tsbCancelOut.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示【作废单据】按钮
        /// </summary>
        public bool BlankOutButtonVisible 
        {
            get
            {
                return tsbBlankOut.Visible;
            }
            set
            {
                tsbBlankOut.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示【开票人】条件
        /// </summary>
        public bool MakerConditionVisible
        {
            get
            {
                return txtMaker.Visible;
            }
            set
            {
                txtMaker.Visible = value;
                lblMaker.Visible = value;
            }
        }
        #endregion


        #region 公共方法

        public void DoReset()
        {
            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;
            this.txtMaker.Clear();
            this.txtID.Clear();

            this.dgvBillList.Rows.Clear();
            this.dgvItems.Rows.Clear();
        }


        public void DoSearch()
        {

            string maker = this.MakerConditionVisible ? 
                txtMaker.Text.Trim() : 
                PermissionService.GetCurrentUser().Name;

            DateTime fromDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0, 0);
            DateTime toDate = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59, 998);

            StockBillService service = new StockBillService();
            List<StockBill> bills = service.SearchBill(
                fromDate, toDate,
                null, maker, txtID.Text.Trim(),
                this.BillType);

            //Fill Bills into datagridview control
            this.dgvBillList.Rows.Clear();
            foreach (StockBill bill in bills)
            {
                if (!bill.Actived || bill.IsCancelOut || bill.IsRedBill)
                {
                    continue;
                }

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = bill;
                DataGridViewCell cell = null;
                cell = new DataGridViewCheckBoxCell();
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.ID.ToString();
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Maker;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.MakeDate.ToString("yyyy-MM-dd HH:mm:ss");
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Storehouse.Name;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Company.Name;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.TotalMoney;
                row.Cells.Add(cell);


                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Remark + (bill.Actived == false ? "已作废" : "");
                row.Cells.Add(cell);

                dgvBillList.Rows.Add(row);
            }

        }


        public void DoBlankOut()
        {
            List<StockBill> selectedList = GetSelectedStockBills();
            StockBillService service = new StockBillService();
            foreach (StockBill bill in selectedList)
            {
                StockBill b = service.FindBill(bill.ID);
                service.BlankOutBill(b, "");
            }

            this.DoReset();
        }


        public void DoCancelOut()
        {
            List<StockBill> selectedList = GetSelectedStockBills();
            StockBillService service = new StockBillService();
            foreach (StockBill bill in selectedList)
            {
                StockBill b = service.FindBill(bill.ID);
                service.CancelOutBill(bill, PermissionService.GetCurrentUser().Name, DateTime.Now, "");
            }

            this.DoReset();
        }

        #endregion


        #region 事件响应

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoSearch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbBlankOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoBlankOut();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }


        private void tsbCancelOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoCancelOut();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
        private void tsbReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoReset();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }


        private void dgvBillList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvItems.Rows.Clear();
                if (dgvBillList.SelectedRows.Count > 0)
                {
                    StockBill bill = (StockBill)dgvBillList.SelectedRows[0].Tag;
                    StockBillService service = new StockBillService();
                    bill = service.FindBill(bill.ID);

                    foreach (StockBillItem item in bill.Items)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.Tag = item;

                        DataGridViewTextBoxCell cell = null;
                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Goods.Code;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Goods.Name;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Goods.Category.Name;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Goods.From.Name;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Goods.Unit;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Goods.Standard;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.UnitPrice.ToString("0.00");
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Count;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Money.ToString("0.00");
                        row.Cells.Add(cell);


                        dgvItems.Rows.Add(row);
                    }
                }
                dgvItems.ClearSelection();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
        #endregion



        private List<StockBill> GetSelectedStockBills()
        {
            List<StockBill> selectedList = new List<StockBill>();
            foreach (DataGridViewRow row in dgvBillList.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cell.EditedFormattedValue != null && (bool)cell.EditedFormattedValue == true)
                {
                    StockBill selectedOne = (StockBill)row.Tag;
                    selectedList.Add(selectedOne);
                }
            }

            if (selectedList.Count == 0)
            {
                throw new ApplicationException("请先选择要操作的内容。");
            }
            return selectedList;
        }

       
    }
}
