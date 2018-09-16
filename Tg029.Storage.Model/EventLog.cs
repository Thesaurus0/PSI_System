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

namespace Tg029.Storage.Model
{
    public class EventLog
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Maker { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime MakeDate { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 操作计算机的IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
