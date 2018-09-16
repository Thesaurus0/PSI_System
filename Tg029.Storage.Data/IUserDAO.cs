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
    public interface IUserDAO
    {
        /// <summary>
        /// 在USER表中INSERT一行数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        void InsertUser(User user, IDbConnection conn);

        /// <summary>
        /// 在USER表中INSERT一行数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void InsertUser(User user, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 更新USER表中已有的一行数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        void UpdateUser(User user, IDbConnection conn);

        /// <summary>
        /// 更新USER表中已有的一行数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void UpdateUser(User user, IDbConnection conn, IDbTransaction trans);


        /// <summary>
        /// 删除USER表中一行数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void DeleteUser(int id, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 获取USER表中的所有数据
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers(IDbConnection conn);

        /// <summary>
        /// 根据CODE和PASSWORD查找USER表中的数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User SelectUser(string code, string password, IDbConnection conn);

      
        /// <summary>
        /// 给一个用户添加一个资源
        /// </summary>
        /// <param name="resourceID"></param>
        /// <param name="userID"></param>
        /// <param name="conn"></param>
        void AddResourceIntoUser(int resourceID, int userID, IDbConnection conn);

        /// <summary>
        /// 给一个用户添加一个资源
        /// </summary>
        /// <param name="resourceID"></param>
        /// <param name="userID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void AddResourceIntoUser(int resourceID, int userID, IDbConnection conn, IDbTransaction trans);


        /// <summary>
        /// 取消一个用户的所有权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="conn"></param>
        void RemoveResourceIntoUser(int userID, IDbConnection conn);

        /// <summary>
        /// 取消一个用户的所有权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        void RemoveResourcesFromUser(int userID, IDbConnection conn, IDbTransaction trans);
    }
}
