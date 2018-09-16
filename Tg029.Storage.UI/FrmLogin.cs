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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                PermissionService service = new PermissionService();
                string userID = this.txtUserID.Text.Trim();
                string password = this.txtPassword.Text;

                if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(password))
                {
                    throw new ApplicationException("用户名和密码不能为空！");
                }
                service.Login(userID, password);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
    }
}
