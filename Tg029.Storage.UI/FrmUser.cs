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
    public partial class FrmUser : Form
    {
        private User _Model { get; set; }

        /// <summary>
        /// 用于创建
        /// </summary>
        public FrmUser()
        {
            InitializeComponent();
            this.Text = string.Format(this.Text, "新建");
        }

        /// <summary>
        /// 用于修改
        /// </summary>
        /// <param name="model"></param>
        public FrmUser(User model)
        {
            InitializeComponent();
            this._Model = model;

            this.Text = string.Format(this.Text, "修改");
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.txtPassword.Text = model.Password;
            this.txtRemark.Text = model.Remark ;
            this.txtCode.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //Verify
                if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
                {
                    throw new ApplicationException("编码不能为空");
                }
                if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                {
                    throw new ApplicationException("名称不能为空");
                }

                //Save
                PermissionService service = new PermissionService();
                if (this._Model == null) //新建
                {
                    User newModel = new User();
                    newModel.Code = this.txtCode.Text.Trim();
                    newModel.Name = this.txtName.Text.Trim();
                    newModel.Remark = this.txtRemark.Text.Trim();
                    newModel.Actived = true;
                    newModel.Password = this.txtPassword.Text;
                    service.CreateUser(newModel, PermissionService.GetCurrentUser().Name);
                }
                else//修改
                {
                    this._Model.Name = this.txtName.Text.Trim();
                    this._Model.Remark = this.txtRemark.Text.Trim();
                    this._Model.Password = this.txtPassword.Text;
                    service.ModifyUser(this._Model, PermissionService.GetCurrentUser().Name);
                }

                //Close dialog
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Close dialog
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

    }
}
