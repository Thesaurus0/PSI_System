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
using System.Windows.Forms;

namespace Tg029.Storage.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmMainForm frm = new FrmMainForm();

            //Sunisoft.IrisSkin.SkinEngine se = new Sunisoft.IrisSkin.SkinEngine(
            //    frm, Application.StartupPath + @"\MSN.ssk");

            //Sunisoft.IrisSkin.SkinEngine se = new Sunisoft.IrisSkin.SkinEngine(
            //   frm, Application.StartupPath + @"\SSK\Diamond\DiamondBlue.ssk");

            //Sunisoft.IrisSkin.SkinEngine se = new Sunisoft.IrisSkin.SkinEngine(
            //    frm, Application.StartupPath + @"\SSK\Mp10\Mp10.ssk");

         //   Sunisoft.IrisSkin.SkinEngine se = new Sunisoft.IrisSkin.SkinEngine(
         //frm, Application.StartupPath + @"\SSK\MSN\MSN.ssk");

  //          Sunisoft.IrisSkin.SkinEngine se = new Sunisoft.IrisSkin.SkinEngine(
  //frm, Application.StartupPath + @"\SSK\vista1\vista1_green.ssk");

 //           Sunisoft.IrisSkin.SkinEngine se = new Sunisoft.IrisSkin.SkinEngine(
 //frm, Application.StartupPath + @"\SSK\Wave\Wave.ssk");

            Application.Run(frm);
        }
    }
}
