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
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNewPwd.Text == this.txtNewPwd2.Text)
                {
                    throw new ApplicationException("两次输入的新密码不同，请检查。");
                }


                User user = PermissionService.GetCurrentUser();
                string oldPwd = this.txtOldPwd.Text;
                PermissionService service = new PermissionService();
                
                
                try
                {
                    service.Login(user.Code, oldPwd);
                }
                catch (Exception)
                {
                    throw new ApplicationException("旧密码不正确，不能修改密码。");
                }

                user.Password = txtNewPwd.Text;
                service.ModifyUser(user, user.Name);

            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
    }
}
