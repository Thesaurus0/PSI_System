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
using Tg029.Storage.Model;

namespace Tg029.Storage.Core
{
    public class ReportService
    {
        /// <summary>
        /// 根据报表名称获取该报表的数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public Report GenerateReport(string reportName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 把报表的数据导出到Excel
        /// </summary>
        /// <param name="rpt"></param>
        /// <param name="fileName"></param>
        public void ExportExcel(Report rpt, string fileName)
        {
            throw new NotImplementedException();
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="rpt"></param>
        //public void FillReportData(Report rpt)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
