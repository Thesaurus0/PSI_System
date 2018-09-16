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
    public interface IStorehouseDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storehouse"></param>
        /// <param name="conn"></param>
        void InsertStorehouse(Storehouse storehouse, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storehouse"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertStorehouse(Storehouse storehouse, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storehouse"></param>
        /// <param name="conn"></param>
        void UpdateStorehouse(Storehouse storehouse, IDbConnection conn);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="storehouse"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateStorehouse(Storehouse storehouse, IDbConnection conn, IDbTransaction trans);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        void DeleteStorehouse(int id, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteStorehouse(int id, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        List<Storehouse> SelectAllStorehouses(IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Storehouse SelectStorehouse(int id, IDbConnection conn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        Storehouse SelectStorehouse(string code, IDbConnection conn);

    }
}
