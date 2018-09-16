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

namespace Tg029.Storage.Model.Base
{
    public abstract class BaseModel
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual bool Actived { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType()
                && !obj.GetType().IsSubclassOf(this.GetType()))
            {
                return false; 
            }

            BaseModel that = (BaseModel)obj;
            return this.ID == that.ID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
