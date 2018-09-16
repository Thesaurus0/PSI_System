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
using Tg029.Storage.Model;

namespace Tg029.Storage.Data
{
    /// <summary>
    /// 提供往来单位（客户/供应商）相关的数据源操作（增、删、改、查等）
    /// </summary>
    public interface ICompanyDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        void InsertCompany(Company company, IDbConnection conn);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertCompany(Company company, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        void UpdateCompany(Company company, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateCompany(Company company, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteCompany(int id, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteCompany(int id, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Company> SelectAllCompanies(IDbConnection conn);

        /// <summary>
        /// 获取指定类型的往来单位类别
        /// 如：获取所有客户、获取所有供货商
        /// </summary>
        /// <param name="compType"></param>
        /// <returns></returns>
        List<Company> SelectCompanies(CompanyType compType, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Company SelectCompany(int id, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Company SelectCompany(string code, IDbConnection conn);

        /// <summary>
        /// 通过指定条件进行模糊检索
        /// </summary>
        /// <param name="codeCond"></param>
        /// <param name="nameCond"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Company> SearchCompanies(string codeCond, string nameCond, IDbConnection conn);
    }
}
