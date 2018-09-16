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
using Tg029.Storage.Data;

namespace Tg029.Storage.Core
{
    public class LogService
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            WriteLog(message, "ERROR");
           
        }

        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            WriteLog(message, "INFO");
        }

        /// <summary>
        /// 记录DEBGU日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            WriteLog(message, "DEBUG");
        }



        private static void WriteLog(string message, string remark)
        {
            EventLog log = new EventLog();
            log.IP = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[0].ToString();
            log.Message = message;
            log.MakeDate = DateTime.Now;
            log.Remark = remark;
            try
            {
                log.Maker = PermissionService.GetCurrentUser().ToString();
            }
            catch (Exception)
            {

            }

            IEventLogDAO dao = DAOFactory.Instance.CreateEventLogDAO();
            dao.InsertEventLog(log, DAOFactory.Instance.OpenConnection());
        }
    }
}
