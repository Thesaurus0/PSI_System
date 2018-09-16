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
    public class CacheService
    {
        private static List<Company> _AllCompanies = null;
        private static List<Goods> _AllGoods = null;
        private static List<GoodsCategory> _AllGoodsCategories = null;
        private static List<GoodsFrom> _AllGoodsFroms = null;
        private static List<Storehouse> _AllStorehouses = null;
        private static List<StockBillType> _AllBillTypes = null;


        public StockBillType GetBillType(string name)
        {
            if (_AllBillTypes == null)
            {
                _AllBillTypes = new ModelService().GetAllStockBillTypes();
            }
            foreach(StockBillType sbt in _AllBillTypes)
            {
                if (sbt.Name == name)
                {
                    return sbt;
                }
            }
            throw new SystemException(string.Format("Can not get bill type '{0}'", name));
        }

        /// <summary>
        /// 获取缓存中的所有关联单位（客户/供货商/同盟店）
        /// </summary>
        /// <returns></returns>
        public List<Company> GetAllCompanies()
        {
            if (_AllCompanies == null)
            {
                _AllCompanies = new ModelService().GetAllCompanies();
            }
            return _AllCompanies;
        }

        /// <summary>
        /// 获取缓存中的所有客户
        /// </summary>
        /// <returns></returns>
        public List<Company> GetAllCustomers()
        {
            List<Company> all = GetAllCompanies();
            List<Company> result = new List<Company>();
            foreach (Company c in all)
            {
                if (c.CompanyType == CompanyType.Customer)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取缓存中的所有供货商
        /// </summary>
        /// <returns></returns>
        public List<Company> GetAllSuppliers()
        {
            List<Company> all = GetAllCompanies();
            List<Company> result = new List<Company>();
            foreach (Company c in all)
            {
                if (c.CompanyType == CompanyType.Supplier)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取缓存中的所有同盟店
        /// </summary>
        /// <returns></returns>
        public List<Company> GetAllOthers()
        {
            List<Company> all = GetAllCompanies();
            List<Company> result = new List<Company>();
            foreach (Company c in all)
            {
                if (c.CompanyType == CompanyType.Other)
                {
                    result.Add(c);
                }
            }
            return result;
        }


        /// <summary>
        /// 获取缓存中的所有商品
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetAllGoods()
        {
            if (_AllGoods == null)
            {
                _AllGoods = new ModelService().GetAllGoods();
            }
            return _AllGoods;
        }

        /// <summary>
        /// 获取缓存中所有品种
        /// </summary>
        /// <returns></returns>
        public List<GoodsCategory> GetAllGoodsCategories()
        {
            if (_AllGoodsCategories == null)
            {
                _AllGoodsCategories = new ModelService().GetAllGoodsCategories();
            }
            return _AllGoodsCategories;
        }

        /// <summary>
        /// 获取缓存中所有的产地
        /// </summary>
        /// <returns></returns>
        public List<GoodsFrom> GetAllGoodsFroms()
        {
            if (_AllGoodsFroms == null)
            {
                _AllGoodsFroms = new ModelService().GetAllGoodsFroms();
            }
            return _AllGoodsFroms;
        }

        /// <summary>
        /// 获取缓存中所有的仓库
        /// </summary>
        /// <returns></returns>
        public List<Storehouse> GetAllStorehouses()
        {
            if(_AllStorehouses == null)
            {
                _AllStorehouses = new ModelService().GetAllStorehouses();
            }
            return _AllStorehouses;
        }
    }
}
