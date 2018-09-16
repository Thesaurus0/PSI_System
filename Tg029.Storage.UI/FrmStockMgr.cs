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
using Tg029.Storage.Core;
using Tg029.Storage.Model;

namespace Tg029.Storage.UI
{
    public partial class FrmStockMgr : Form
    {
        public FrmStockMgr()
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
            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                lblDescription.Text = e.Node.Tag==null?"":e.Node.Tag.ToString();
            }
            PermissionService service = new PermissionService();
            if (!service.IsUserAccess(e.Node.Text))
            {
                throw new ApplicationException("权限不足，无法执行此操作！");
            }
            switch (e.Node.Text)
            {
                case "报废出库":
                    this.AddCtrlIntoPanel(new Bill.CtrlBillInput());
                    break;
                case "":

                    break;
                default:

                    break;
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
