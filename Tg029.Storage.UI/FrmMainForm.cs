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
using Tg029.Storage.Model;
using Tg029.Storage.Core;

namespace Tg029.Storage.UI
{
    public partial class FrmMainForm : Form
    {
        public FrmMainForm()
        {
            InitializeComponent();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog(this);
        }

        private void 采购入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockIn));
        }

        private void 销售出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockOut));
        }

        private void 库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockMgr));
        }

        private void 报表查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockReport));
        }

        private void 调拨ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockTrac));
        }


        private void OpenChildForm(Type childType)
        {
            bool isOpened = false;
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == childType)
                {
                    child.Activate();
                    isOpened = true;
                    break;
                }
            }

            if (!isOpened)
            {
                //动态生成一个类型的实例
                Form childFrm = (Form)Activator.CreateInstance(childType);
                childFrm.MdiParent = this;
                childFrm.WindowState = FormWindowState.Maximized;
                childFrm.Show();
            }
        }

        private void 基础数据维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmInfo));
        }

        private void 权限控制台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                User user = PermissionService.GetCurrentUser();
                if (user.IsAdmin)
                {
                    FrmPermission frm = new FrmPermission();
                    frm.ShowDialog(this);
                }
                else
                {
                    throw new ApplicationException("权限不足，无法执行此操作！");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
            
        }

        private void FrmMainForm_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.tslUserName.Text = PermissionService.GetCurrentUser().Name;
                this.tslVersion.Text = Application.ProductVersion.ToString();
            }
            else
            {
                this.Close();
            }
        }

        private void 窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

      
    }
}
