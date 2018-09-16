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

namespace Tg029.Storage.Data.MySQL
{
    public class EventLogDAO : IEventLogDAO
    {
        #region IEventLogDAO 成员

        public void InsertEventLog(Tg029.Storage.Model.EventLog eventLog, System.Data.IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        public void DeleteEventLog(DateTime deadline, System.Data.IDbConnection conn, System.Data.IDbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public List<Tg029.Storage.Model.EventLog> SelectEventLogs(DateTime fromDate, DateTime toDate, System.Data.IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
