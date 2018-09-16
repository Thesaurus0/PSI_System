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
using System.Text;

namespace Tg029.Storage.UI
{
    class ErrorHandler
    {
        internal static void OnError(Exception ex)
        {
            if (ex.GetType() == typeof(ApplicationException) ||
                ex.GetType().IsSubclassOf(typeof(ApplicationException)))
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.Message, "提示信息！", 
                    System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.Message + "\r\n\r\n" + ex.StackTrace, "系统错误！",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error
                    );
            }
            
        }
    }
}
