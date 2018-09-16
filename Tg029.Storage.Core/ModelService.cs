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
using System.Data;
using Tg029.Storage.Data;

namespace Tg029.Storage.Core
{
    public class ModelService
    {

        #region 关联单位

        /// <summary>
        /// 创建一个关联单位（客户/供货商）
        /// </summary>
        /// <param name="company"></param>
        /// <param name="creator"></param>
        public void CreateCompany(Company company, string creator)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                dao.InsertCompany(company, conn);
            }
        }

        /// <summary>
        /// 修改一个关联单位（客户/供货商）
        /// </summary>
        /// <param name="company"></param>
        /// <param name="modifier"></param>
        public void SaveCompany(Company company, string modifier)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                dao.UpdateCompany(company, conn);
            }
        }

        /// <summary>
        /// 删除一个关联单位（客户/供货商）
        /// </summary>
        /// <param name="company"></param>
        /// <param name="deleter"></param>
        public void DeleteCompany(Company company, string deleter)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                dao.DeleteCompany(company.ID, conn);
            }
        }

        /// <summary>
        /// 获取所有的关联单位（客户/供货商）
        /// </summary>
        /// <returns></returns>
        public List<Company> GetAllCompanies()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                return dao.SelectAllCompanies(conn);
            }
        }

        /// <summary>
        /// 根据ID获取管理单位对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company RetrieveCompany(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                return dao.SelectCompany(id, conn);
            }
        }


        public Company GetCompanyByCode(string code)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                ICompanyDAO dao = DAOFactory.Instance.CreateCompanyDAO();
                return dao.SelectCompany(code, conn);
            }
        }
        #endregion


        #region 商品

        /// <summary>
        /// 创建一个新商品
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="creator"></param>
        public void CreateGoods(Goods goods, string creator)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsDAO dao = DAOFactory.Instance.CreateGoodsDAO();
                dao.InsertGoods(goods, conn);
            }
        }

        /// <summary>
        /// 保存修改过的商品信息
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="modifier"></param>
        public void SaveGoods(Goods goods, string modifier)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsDAO dao = DAOFactory.Instance.CreateGoodsDAO();
                dao.UpdateGoods(goods, conn);
            }
        }

        /// <summary>
        /// 删除一个商品
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="deleter"></param>
        public void DeleteGoods(Goods goods, string deleter)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsDAO dao = DAOFactory.Instance.CreateGoodsDAO();
                dao.DeleteGoods(goods.ID, conn);
            }
        }

        /// <summary>
        /// 获取所有的商品列表
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetAllGoods()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsDAO dao = DAOFactory.Instance.CreateGoodsDAO();
                return dao.SelectAllGoods(conn);
            }
        }

        /// <summary>
        /// 获取指定编码的商品
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Goods GetGoodsByCode(string code)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsDAO dao = DAOFactory.Instance.CreateGoodsDAO();
                return dao.SelectGoods(code, conn);
            }
        }

        /// <summary>
        /// 根据ID获取一个商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Goods RetrieveGoods(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsDAO dao = DAOFactory.Instance.CreateGoodsDAO();
                return dao.SelectGoods(id,conn);
            }
        }

        #endregion


        #region 品种

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="creator"></param>
        public void CreateGoodsCategory(GoodsCategory category, string creator)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsCategoryDAO dao = DAOFactory.Instance.CreateGoodsCategoryDAO();
                dao.InsertGoodsCategory(category, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="modifier"></param>
        public void SaveGoodsCategory(GoodsCategory category, string modifier)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsCategoryDAO dao = DAOFactory.Instance.CreateGoodsCategoryDAO();
                dao.UpdateGoodsCategory(category, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="deleter"></param>
        public void DeleteGoodsCategory(GoodsCategory category, string deleter)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsCategoryDAO dao = DAOFactory.Instance.CreateGoodsCategoryDAO();
                dao.DeleteGoodsCategory(category.ID, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GoodsCategory> GetAllGoodsCategories()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsCategoryDAO dao = DAOFactory.Instance.CreateGoodsCategoryDAO();
                return dao.SelectAllGoodsCategories(conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoodsCategory RetrieveGoodsCategory(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsCategoryDAO dao = DAOFactory.Instance.CreateGoodsCategoryDAO();
                return dao.SelectGoodsCategory(id, conn);
            }
        }

        public GoodsCategory GetGoodsCategoryByCode(string code)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsCategoryDAO dao = DAOFactory.Instance.CreateGoodsCategoryDAO();
                return dao.SelectGoodsCategory(code, conn);
            }
        }

        #endregion


        #region 产地

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="creator"></param>
        public void CreateGoodsFrom(GoodsFrom from, string creator)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsFromDAO dao = DAOFactory.Instance.CreateGoodsFromDAO();
                dao.InsertGoodsFrom(from, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="modifier"></param>
        public void SaveGoodsFrom(GoodsFrom from, string modifier)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsFromDAO dao = DAOFactory.Instance.CreateGoodsFromDAO();
                dao.UpdateGoodsFrom(from, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="deleter"></param>
        public void DeleteGoodsFrom(GoodsFrom from, string deleter)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsFromDAO dao = DAOFactory.Instance.CreateGoodsFromDAO();
                dao.DeleteGoodsFrom(from.ID, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GoodsFrom> GetAllGoodsFroms()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsFromDAO dao = DAOFactory.Instance.CreateGoodsFromDAO();
                return dao.SelectAllGoodsFroms(conn);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoodsFrom RetrieveGoodsFrom(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsFromDAO dao = DAOFactory.Instance.CreateGoodsFromDAO();
                return dao.SelectGoodsFrom(id, conn);
            }
        }

        public GoodsFrom GetGoodsFromByCode(string code)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IGoodsFromDAO dao = DAOFactory.Instance.CreateGoodsFromDAO();
                return dao.SelectGoodsFrom(code, conn);
            }
        }

        #endregion


        #region 仓库

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storehouse"></param>
        /// <param name="creator"></param>
        public void CreateStorehouse(Storehouse storehouse, string creator)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                dao.InsertStorehouse(storehouse, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storehouse"></param>
        /// <param name="modifier"></param>
        public void SaveStorehouse(Storehouse storehouse, string modifier)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                dao.UpdateStorehouse(storehouse, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storehouse"></param>
        /// <param name="deleter"></param>
        public void DeleteStorehouse(Storehouse storehouse, string deleter)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                dao.DeleteStorehouse(storehouse.ID, conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Storehouse> GetAllStorehouses()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                return dao.SelectAllStorehouses(conn);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Storehouse RetireveStorehouse(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                return dao.SelectStorehouse(id, conn);
            }
        }

        public Storehouse GetStorehouseByCode(string code)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStorehouseDAO dao = DAOFactory.Instance.CreateStorehouseDAO();
                return dao.SelectStorehouse(code, conn);
            }
        }

        #endregion

        /// <summary>
        /// 获取所有的单据类型
        /// </summary>
        /// <returns></returns>
        public List<StockBillType> GetAllStockBillTypes()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IStockBillTypeDAO dao = DAOFactory.Instance.CreateStockBillTypeDAO();
                return dao.SelectAllBillTypes(conn);
            }
        }

    }

}
