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

using Tg029.Storage.UI.Info;

namespace Tg029.Storage.UI
{
    public partial class FrmInfo : Form
    {
        public FrmInfo()
        {
            InitializeComponent();
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                {
                    if (e.Node.Tag != null)
                    {
                        lblDescription.Text = e.Node.Tag.ToString();
                    }

                    if (e.Node.Text == "仓库")
                    {
                        CtrlStorehouse ctrl = new CtrlStorehouse();
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.RefreshListView();
                    }
                    else if (e.Node.Text == "货物")
                    {
                        CtrlGoods ctrl = new CtrlGoods();
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.RefreshListView();
                    }
                    else if (e.Node.Text == "货物产地")
                    {
                        CtrlGoodsFrom ctrl = new CtrlGoodsFrom();
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.RefreshListView();
                    }
                    else if (e.Node.Text == "货物品种")
                    {
                        CtrlGoodsCategory ctrl = new CtrlGoodsCategory();
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.RefreshListView();
                    }
                    else if (e.Node.Text == "客户")
                    {
                        CtrlCompany ctrl = new CtrlCompany();
                        ctrl.CompanyType = Tg029.Storage.Model.CompanyType.Customer;
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.RefreshListView();
                    }
                    else if (e.Node.Text == "供货商")
                    {
                        CtrlCompany ctrl = new CtrlCompany();
                        ctrl.CompanyType = Tg029.Storage.Model.CompanyType.Supplier;
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.RefreshListView();
                    }
                    else if (e.Node.Text == "同盟店")
                    {
                        CtrlCompany ctrl = new CtrlCompany();
                        ctrl.CompanyType = Tg029.Storage.Model.CompanyType.Other;
                        this.AddCtrlIntoPanel(ctrl);
                        ctrl.RefreshListView();
                    }
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

       
    }
}
