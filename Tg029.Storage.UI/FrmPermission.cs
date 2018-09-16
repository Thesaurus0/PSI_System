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
    public partial class FrmPermission : Form
    {
        public FrmPermission()
        {
            InitializeComponent();
        }

        private void LoadResourceView()
        {
            PermissionService service = new PermissionService();
            List<Resource> allResources = service.GetAllResources();
            foreach (Resource res in allResources)
            {
                CheckBox chk = new CheckBox();
                chk.AutoSize = false;
                chk.Width = 150;
                chk.Tag = res;
                chk.Text = res.Name;
                chk.Name = res.Code;

                flpResourcePanel.Controls.Add(chk);
            }
        }

        private void LoadUserView()
        {
            PermissionService service = new PermissionService();
            List<User> allUsers = service.GetAllUsers();

            dgvUserList.Rows.Clear();
            foreach (User user in allUsers)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = user;

                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = user.Code;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = user.Name;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = user.Actived ? "否" : "是";
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = user.Remark;
                row.Cells.Add(cell);

                dgvUserList.Rows.Add(row);
            }
        }

        private void SaveSetting()
        {
            if (dgvUserList.SelectedRows.Count == 0)
            {
                throw new ApplicationException("请先选择一个用户。");
            }
            User user = (User)dgvUserList.SelectedRows[0].Tag;
            List<Resource> res = new List<Resource>();
            foreach (CheckBox chk in flpResourcePanel.Controls)
            {
                if (chk.Checked)
                {
                    res.Add((Resource)chk.Tag);
                }
            }

            PermissionService service = new PermissionService();
            service.SetUserResources(user, res);
        }

        private void FrmPermission_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadResourceView();
                this.LoadUserView();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.flpResourcePanel.Controls.Count > 0)
                {
                    throw new ApplicationException("权限列表已经被初始化过，不能重复初始化。");
                }


                List<Resource> resList = new List<Resource>();
                resList.Add(new Resource("采购单录入"));
                resList.Add(new Resource("作废我的采购单"));
                resList.Add(new Resource("冲销我的采购单"));
                resList.Add(new Resource("查询我的采购单"));
                resList.Add(new Resource("查询全部采购单"));
                resList.Add(new Resource("作废全部采购单"));
                resList.Add(new Resource("冲销全部采购单"));
                resList.Add(new Resource("己方退货单录入"));
                resList.Add(new Resource("己方退货单作废"));
                resList.Add(new Resource("己方退货单查询"));
                resList.Add(new Resource("按商品汇总采购量"));
                resList.Add(new Resource("按品种汇总采购量"));
                resList.Add(new Resource("按产地汇总采购量"));
                resList.Add(new Resource("按开票员汇总采购量"));

                resList.Add(new Resource("销货单录入"));
                resList.Add(new Resource("作废我的销货单"));
                resList.Add(new Resource("冲销我的销货单"));
                resList.Add(new Resource("查询我的销货单"));
                resList.Add(new Resource("查询全部销货单"));
                resList.Add(new Resource("作废全部销货单"));
                resList.Add(new Resource("冲销全部销货单"));
                resList.Add(new Resource("客方退货单录入"));
                resList.Add(new Resource("客方退货单作废"));
                resList.Add(new Resource("客方退货单查询"));
                resList.Add(new Resource("按商品汇总销量"));
                resList.Add(new Resource("按品种汇总销量"));
                resList.Add(new Resource("按产地汇总销量"));
                resList.Add(new Resource("按开票员汇总销量"));

                resList.Add(new Resource("报废出库"));
                resList.Add(new Resource("废品库查询"));
                resList.Add(new Resource("废品库管理"));
                resList.Add(new Resource("盘亏调整"));
                resList.Add(new Resource("盘盈调整"));
                resList.Add(new Resource("盘点日志查询"));
                resList.Add(new Resource("缺货预警"));
                resList.Add(new Resource("积压预警"));
                resList.Add(new Resource("库存商品明细查询"));
                resList.Add(new Resource("库存分析"));
                resList.Add(new Resource("设置预警边界"));

                resList.Add(new Resource("调拨出库单"));
                resList.Add(new Resource("调补出库单作废"));
                resList.Add(new Resource("调拨入库单"));
                resList.Add(new Resource("调补入库单作废"));
                resList.Add(new Resource("调拨出库单查询"));
                resList.Add(new Resource("调拨入库单查询"));

                resList.Add(new Resource("销售收入统计"));
                resList.Add(new Resource("采购成本统计"));
                resList.Add(new Resource("利润统计"));
                resList.Add(new Resource("销售员考核"));
                resList.Add(new Resource("业务员考核"));
                
                PermissionService service = new PermissionService();
                service.InitResources(resList);

                //显示权限列表
                this.LoadResourceView();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveSetting();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbAddUser_Click(object sender, EventArgs e)
        {
            FrmUser frm = new FrmUser();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.LoadUserView();
            }
        }

        private void tsbRemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUserList.SelectedRows.Count == 0)
                {
                    throw new ApplicationException("请先选择一个用户。");
                }
                User user = (User)dgvUserList.SelectedRows[0].Tag;
                user.Actived = false;
                PermissionService service = new PermissionService();
                service.ModifyUser(user, PermissionService.GetCurrentUser().Name);

                this.LoadUserView();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbModifyUser_Click(object sender, EventArgs e)
        {
            if (dgvUserList.SelectedRows.Count == 0)
            {
                throw new ApplicationException("请先选择一个用户。");
            }
            User user = (User)dgvUserList.SelectedRows[0].Tag;
            FrmUser frm = new FrmUser(user);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.LoadUserView();
            }
        }

        private void dgvUserList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUserList.SelectedRows.Count == 0)
                {
                    return;
                }
                User user = (User)dgvUserList.SelectedRows[0].Tag;
                PermissionService service = new PermissionService();
                List<Resource> list = service.GetUserResources(user);

                foreach (CheckBox chk in flpResourcePanel.Controls)
                {
                    if (list.Contains((Resource)chk.Tag))
                    {
                        chk.Checked = true;
                    }
                    else
                    {
                        chk.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        
    }
}
