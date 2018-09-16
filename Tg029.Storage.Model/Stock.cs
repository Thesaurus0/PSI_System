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
    public class Stock : Base.BaseModel
    {
        public new string Code {
            get
            {
                throw new NotSupportedException("Not support Code property in Stock class.");
            }
            set
            {
                throw new NotSupportedException("Not support Code property in Stock class.");
            }
        }

        public new string Name
        {
            get
            {
                throw new NotSupportedException("Not support Code property in Stock class.");
            }
            set
            {
                throw new NotSupportedException("Not support Code property in Stock class.");
            }
        }

        public Goods Goods { get; set; }

        public Storehouse Storehouse { get; set; }

        public int Count { get; set; }

    }
}
