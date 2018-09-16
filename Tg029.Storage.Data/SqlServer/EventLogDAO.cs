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
using System.Data;
using System.Data.SqlClient;
using Tg029.Storage.Model;

namespace Tg029.Storage.Data.SqlServer
{
    public class EventLogDAO : IEventLogDAO
    {
        #region IEventLogDAO 成员

        public void InsertEventLog(EventLog eventLog, IDbConnection conn)
        {
            string sql = @"
            INSERT INTO MD_EventLog(Maker,MakeDate,Message,ClientPC,Remark) 
            VALUES(@Maker,@MakeDate,@Message,@ClientPC,@Remark)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Maker", eventLog.Maker));
            paramList.Add(new SqlParameter("@MakeDate", eventLog.MakeDate));
            paramList.Add(new SqlParameter("@Message", eventLog.Message));
            paramList.Add(new SqlParameter("@ClientPC", eventLog.IP));
            paramList.Add(new SqlParameter("@Remark", eventLog.Remark));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public void DeleteEventLog(DateTime deadline, IDbConnection conn, IDbTransaction trans)
        {
            string sql = "DELETE MD_EventLog WHERE MakeDate<@Deadline";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Deadline", deadline));
            DataAccessUtil.ExecuteNonQuery(sql, paramList, (SqlConnection)conn);
        }

        public List<EventLog> SelectEventLogs(DateTime fromDate, DateTime toDate, IDbConnection conn)
        {
            string sql = @"
            SELECT ID,Maker,MakeDate,Message,ClientPC,Remark
            FROM MD_EventLog
            WHERE MakeDate BETWEEN @FromDate AND @ToDate";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FromDate", fromDate));
            paramList.Add(new SqlParameter("@ToDate", toDate));
            SqlDataReader reader = DataAccessUtil.ExecuteReader(sql, paramList, (SqlConnection)conn);
            List<EventLog> list = new List<EventLog>();
            while (reader.Read())
            {
                EventLog log = new EventLog();
                log.ID = reader.GetInt32(0);
                log.Maker = reader.GetString(1);
                log.MakeDate = reader.GetDateTime(2);
                log.Message = reader.GetString(3);
                if (!reader.IsDBNull(4))
                {
                    log.IP = reader.GetString(4);
                }
                if (!reader.IsDBNull(5))
                {
                    log.Remark = reader.GetString(5);
                }
                list.Add(log);
            }
            reader.Close();
            return list;
        }

        #endregion
    }
}
