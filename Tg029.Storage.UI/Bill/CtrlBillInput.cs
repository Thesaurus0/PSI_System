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
    public partial class CtrlBillInput : UserControl
    {
        public CtrlBillInput()
        {
            InitializeComponent();
        }


        #region 公共属性
        /// <summary>
        /// 要冲销或作废的单据类型
        /// </summary>
        public StockBillType BillType { get; set; }

        /// <summary>
        /// 当前单据类型对应的关联公司类型
        /// </summary>
        private CompanyType _CompanyType;
        public CompanyType CompanyType {
            get
            {
                return _CompanyType;
            }
            set
            {
                _CompanyType = value;
                CacheService service = new CacheService();
                if (_CompanyType == Tg029.Storage.Model.CompanyType.Customer)
                {
                    this.cmbCompany.DataSource = service.GetAllCustomers();
                }
                else if (_CompanyType == Tg029.Storage.Model.CompanyType.Supplier)
                {
                    this.cmbCompany.DataSource = service.GetAllSuppliers();
                }
                else
                {
                    this.cmbCompany.DataSource = service.GetAllOthers();
                }
                this.cmbCompany.SelectedItem = null;
            }
        }

     

        #endregion

        #region 公共方法



        /// <summary>
        /// 保存单据并修改库存
        /// </summary>
        public void DoSave()
        {
            //Do Verify
            if (this.cmbStorehouse.SelectedItem == null)
            {
                throw new ApplicationException("请指定仓库！");
            }
            if (this.cmbCompany.SelectedItem == null)
            {
                throw new ApplicationException("请指定管理单位！");
            }
            if (this.dgvGoodsList.Rows.Count <= 1)
            {
                throw new ApplicationException("请指定商品！");
            }

            //Contruct model
            StockBill bill = new StockBill();
            bill.BillType = this.BillType;
            bill.Actived = true;
            bill.Code = DateTime.Now.ToString("yyyyMMddHHmmssddd");
            bill.Company = (Company)this.cmbCompany.SelectedItem;
            bill.IsCancelOut = false;
            bill.IsRedBill = false;
            bill.MakeDate = this.dtpMakeDate.Value;
            bill.Remark = this.txtRemark.Text.Trim();
            bill.Storehouse = (Storehouse)this.cmbStorehouse.SelectedItem;
            bill.Maker = this.txtMaker.Text.Trim();
            
            foreach (DataGridViewRow row in this.dgvGoodsList.Rows)
            {
                if (row.Tag != null)
                {
                    StockBillItem billItem = (StockBillItem)row.Tag;
                    bill.Items.Add(billItem);
                }
            }


            //Do Save
            StockBillService service = new StockBillService();
            service.MakeBill(bill);

            if (MessageBox.Show("是否打印？", "打印提示",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintService.GetInstance().PrintBill(bill);
            }

            //Reset the form
            this.DoReset();
        }


       
        /// <summary>
        /// 重置画面，准备录入一张单据
        /// </summary>
        public void DoNextBill()
        {
            this.DoReset();
        }

        /// <summary>
        /// 复位画面状态
        /// </summary>
        public void DoReset()
        {
            this.dtpMakeDate.Value = DateTime.Now;
            this.txtMaker.Text = PermissionService.GetCurrentUser().Name;
            this.cmbCompany.SelectedItem = null;
            this.cmbStorehouse.SelectedItem = null;
            this.txtRemark.Clear();
            this.dgvGoodsList.Rows.Clear();
        }

        #endregion

        #region 工具按钮事件
        private void tsbSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.DoSave();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }


       

        private void tsbNext_Click(object sender, EventArgs e)
        {
           
            try
            {
                this.DoNextBill();
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
        #endregion

        private void dgvGoodsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvGoodsList.Rows[e.RowIndex];
                object value = this.dgvGoodsList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == null)
                {
                    return;
                }
                StockBillItem item = null;
                switch (e.ColumnIndex)
                {
                    case 0://输入商品编码
                        string goodsCode = value.ToString();

                        ModelService service = new ModelService();
                        Goods goods = service.GetGoodsByCode(goodsCode);
                        if (goods == null)
                        {
                            throw new ApplicationException("编码输入错误，没有匹配的商品！");
                        }

                        //Fill Goods Info into datagridview row
                        DataGridViewTextBoxCell cell = null;
                        cell = new DataGridViewTextBoxCell();
                        cell.Value = goods.Name;
                        row.Cells[1] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = goods.Standard;
                        row.Cells[2] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = goods.Unit;
                        row.Cells[3] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = goods.Category.Name;
                        row.Cells[4] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = goods.From.Name;
                        row.Cells[5] = cell;


                        //TODO: add StockBillItem into row's tag
                        item = (StockBillItem)row.Tag;
                        if (item == null)
                        {
                            item = new StockBillItem();
                            row.Tag = item;
                        }
                        item.Goods = goods;
                        
                        break;
                    case 6://输入数量编码
                        int count = int.Parse(value.ToString());
                        item = (StockBillItem)row.Tag;
                        if (item == null)
                        {
                            item = new StockBillItem();
                            row.Tag = item;
                        }
                        item.Count = count;


                        if (item.Count != 0 && item.UnitPrice != 0)
                        {
                            row.Cells[8].Value = item.Count * item.UnitPrice;
                            //item.Money = item.Count * item.UnitPrice;
                        }
                        break;
                    case 7://输入单价编码
                        decimal unitPrice = decimal.Parse(value.ToString());
                        item = (StockBillItem)row.Tag;
                        if (item == null)
                        {
                            item = new StockBillItem();
                            row.Tag = item;
                        }
                        item.UnitPrice = unitPrice;

                        if (item.Count != 0 && item.UnitPrice != 0)
                        {
                            row.Cells[8].Value = item.Count * item.UnitPrice;
                            //item.Money = item.Count * item.UnitPrice;
                        }
                        break;
                    case 8://输入金额编码
                        decimal money = decimal.Parse(value.ToString());
                        item = (StockBillItem)row.Tag;
                        if (item == null)
                        {
                            item = new StockBillItem();
                            row.Tag = item;
                        }
                        //item.Money = money;
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

        private void CtrlBillInput_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtMaker.Text = PermissionService.GetCurrentUser().Name;

                CacheService service = new CacheService();
                this.cmbStorehouse.DataSource = service.GetAllStorehouses();
                this.cmbStorehouse.SelectedItem = null;

                this.cmbCompany.DataSource = service.GetAllCompanies();
                this.cmbCompany.SelectedItem = null;
            }
            catch (Exception ex)
            {
              ErrorHandler.OnError(ex);
            }
        }

    }
}
