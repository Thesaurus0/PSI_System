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
    
    
    public class StockBill : Base.BaseModel
    {
        /// <summary>
        /// 从BaseModel继承而来，在此类中不支持！
        /// </summary>
        public override string Name
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException("Not support Name property in StockBill class.");
            }
        }

        private List<StockBillItem> _Items = new List<StockBillItem>();
        public List<StockBillItem> Items
        {
            get
            {
                return _Items;
            }
        }

        public Storehouse Storehouse { get; set; }
        public StockBillType BillType { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime MakeDate { get; set; }
        public string Maker { get; set; }

        public Company Company { get; set; }

        /// <summary>
        /// 是否被冲销
        /// </summary>
        public bool IsCancelOut { get; set; }

        /// <summary>
        /// 是否为红票
        /// </summary>
        public bool IsRedBill { get; set; }


        public decimal TotalMoney
        {
            get
            {
                decimal result = 0;
                foreach (StockBillItem item in _Items)
                {
                    result += item.UnitPrice * item.Count;
                }
                return result;
            }
        }

    }
}
