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
    public class PermissionService
    {
        private static User _CurrenUser = null;

        public List<Resource> GetAllResources()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IResourceDAO dao = DAOFactory.Instance.CreateResourceDAO();
                return dao.GetAllResources(conn);
            }
        }

        public List<User> GetAllUsers()
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                return dao.GetAllUsers(conn);
            }
        }
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="code">登录ID</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public User Login(string code, string password)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                User user = dao.SelectUser(code, password, conn);
                if (user == null)
                {
                    throw new ApplicationException("用户名或密码错误，登录失败！");
                }
                if (!user.Actived)
                {
                    throw new ApplicationException("用户已经被注销，登录失败！");
                }
                user.IsAdmin = "Admin".ToLower().Equals(user.Code.ToLower());
                _CurrenUser = user;
                return user;
            }
        }

        /// <summary>
        /// 获取当前登录用户，
        /// 如果没有登录用户，则抛出异常。
        /// </summary>
        /// <returns></returns>
        public static User GetCurrentUser()
        {
            //_CurrenUser = new User();
            //_CurrenUser.Code = "wjb";
            //_CurrenUser.Name = "WangJibin";
            if (_CurrenUser == null)
            {
                throw new ApplicationException("用户还没有登录，请先登录！");
            }
            return _CurrenUser;
        }

        /// <summary>
        /// 获取给定用户可以访问的所有资源
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Resource> GetUserResources(User user)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IResourceDAO dao = DAOFactory.Instance.CreateResourceDAO();
                return dao.GetResources(user.ID, conn); 
            }
        }

        public bool IsUserAccess(string resourceName)
        {
            User user = GetCurrentUser();
            List<Resource> list = this.GetUserResources(user);
            List<string> resourceNameList = new List<string>();
            foreach (Resource r in list)
            {
                resourceNameList.Add(r.Name);
            }

            return resourceNameList.Contains(resourceName);

        }

        /// <summary>
        /// 创建新用户
        /// </summary>
        /// <param name="user">用户的具体信息</param>
        /// <param name="maker">创建人</param>
        public void CreateUser(User user, string maker)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                dao.InsertUser(user, conn);
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">要修改的用户的具体信息</param>
        /// <param name="modifier">修改人</param>
        public void ModifyUser(User user, string modifier)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                dao.UpdateUser(user, conn);
            }
        }

       /// <summary>
       /// 删除一个用户
       /// </summary>
       /// <param name="user">要删除的用户</param>
       /// <param name="deleter">操作人</param>
        public void DeleteUser(User user, string deleter)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                    dao.DeleteUser(user.ID, conn, trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
               
            }
        }

        /// <summary>
        /// 初始化所有资源列表
        /// </summary>
        /// <param name="res"></param>
        public void InitResources(List<Resource> res)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    IResourceDAO dao = DAOFactory.Instance.CreateResourceDAO();
                    foreach (Resource r in res)
                    {
                        dao.InsertResource(r, conn, trans);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                
            }
        }

        /// <summary>
        /// 设置用户所能访问的资源列表
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="res">资源列表（权限列表）</param>
        public void SetUserResources(User user, List<Resource> res)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    IUserDAO dao = DAOFactory.Instance.CreateUserDAO();
                    dao.RemoveResourcesFromUser(user.ID, conn, trans);
                    foreach (Resource r in res)
                    {
                        dao.AddResourceIntoUser(r.ID, user.ID, conn, trans);
                    }

                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                
            }
        }

    }
}
