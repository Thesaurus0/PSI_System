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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using grproLib;
using Tg029.Storage.Core;
using System.Configuration;


namespace Tg029.Storage.UI.Report
{
    public partial class CtrlReport : UserControl
    {
        public delegate void ReportInitEventHandler(GridppReport report);
        public event ReportInitEventHandler ReportInit;
        private GridppReport _Report = null;

        public CtrlReport()
        {
            InitializeComponent();

            //1.创建报表模型
            _Report = new GridppReport();
            _Report.Initialize += 
                new _IGridppReportEvents_InitializeEventHandler(
                    ReprotInitialize);
        }

        /// <summary>
        /// 获取或设置报表模板全名
        /// </summary>
        public string ReportTemplateFile { get; set; }
        /// <summary>
        /// 是否支持透视报表能来
        /// </summary>
        public bool IsSupportChildReport { get; set; }

        public void DoSerch()
        {
            if (this.ReportViewer.Running)
            {
                this.ReportViewer.Stop();
            }

            //2.加载报表模板
            _Report.LoadFromFile(this.ReportTemplateFile);
            //3.设置数据源链接
            _Report.DetailGrid.Recordset.ConnectionString =
                ConfigurationManager.ConnectionStrings["ReportDbConn"].ConnectionString;
            //4.关联报表模型和报表现实控件
            this.ReportViewer.Report = _Report;
            //5.启动
            this.ReportViewer.Start();
            
        }

        private void ReprotInitialize()
        {
            try
            {
                if (ReportInit != null)
                {
                    ReportInit(_Report);
                }
                if(_Report.ParameterByName("ParamMaker") != null)
                {
                    _Report.ParameterByName("ParamMaker").Value = PermissionService.GetCurrentUser().Name;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoSerch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
           
        }

       

        private void ReportViewer_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
        {
            if (!IsSupportChildReport)
            {
                return;
            }
            try
            {
                int billID = _Report.FieldByName("ID").AsInteger;
                FrmChildReport rpt = new FrmChildReport(billID);
                rpt.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReportViewer.Report == null)
                {
                    throw new ApplicationException("当前没有可以导出的内容。");
                }
                if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    _Report.ExportDirect(GRExportType.gretXLS, this.saveFileDialog1.FileName, false, true);
                }
            }
            catch (Exception ex)
            {
               ErrorHandler.OnError(ex);
            }
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReportViewer.Report == null)
                {
                    throw new ApplicationException("当前没有可以预览的内容。");
                }
               
                _Report.PrintPreview(true);
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReportViewer.Report == null)
                {
                    throw new ApplicationException("当前没有可以打印的内容。");
                }
                _Report.Print(true);
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }



    }
}
