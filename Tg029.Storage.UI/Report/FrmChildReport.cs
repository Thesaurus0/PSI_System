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

namespace Tg029.Storage.UI.Report
{
    public partial class FrmChildReport : Form
    {
        private int _BillID;

        public FrmChildReport()
        {
            InitializeComponent();
            this.ctrlReport1.ReportTemplateFile = System.IO.Path.Combine(Application.StartupPath, "MySalesBillItem.grf");
        }

        public FrmChildReport(int billId)
        {
            _BillID = billId;
            InitializeComponent();
            this.ctrlReport1.ReportTemplateFile = System.IO.Path.Combine(Application.StartupPath, "MySalesBillItem.grf");
        }

        private void ctrlReport1_ReportInit(grproLib.GridppReport report)
        {
            try
            {
                report.ParameterByName("ParamBillID").Value = this._BillID;
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
         
        }

        private void FrmChildReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.ctrlReport1.DoSerch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
    }
}
