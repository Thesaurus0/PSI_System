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
using System.Data.SqlClient;

namespace Tg029.Storage.Data
{
    public interface IResourceDAO
    {
        /// <summary>
        /// 在RESOURCE表中添加一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        void InsertResource(Resource res, IDbConnection conn);

        /// <summary>
        /// 在RESOURCE表中添加一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertResource(Resource res, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 修改RESOURCE表中的一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        void UpdateResource(Resource res, IDbConnection conn);

        /// <summary>
        /// 修改RESOURCE表中的一条记录
        /// </summary>
        /// <param name="res"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateResource(Resource res, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 删除RESOURCE表中的一条记录
        /// </summary>
        /// <param name="resID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteResource(int resID, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 获取RESOURCE表中所有记录
        /// </summary>
        /// <returns></returns>
        List<Resource> GetAllResources(IDbConnection conn);

        /// <summary>
        /// 获取指定用户所能访问资料列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<Resource> GetResources(int userID, IDbConnection conn);
    }
}
