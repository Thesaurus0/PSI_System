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
using System.Configuration;

namespace Tg029.Storage.Data
{
    public class DAOFactory
    {
        private enum DatabaseType
        {
            SqlServer,
            MySQL,
        }
        private DatabaseType _DbType;

        private string _ProviderName;
        private string _ConnectionString;
        
        private DAOFactory()
        {
            try
            {
                string connKey = "DbConn";
                _ProviderName = ConfigurationManager.ConnectionStrings[connKey].ProviderName;
                _ConnectionString = ConfigurationManager.ConnectionStrings[connKey].ConnectionString;


                if (_ProviderName == "System.Data.SqlClient")
                {
                    _DbType = DatabaseType.SqlServer;
                }
                else if (_ProviderName == "System.Data.OleDB")
                {
                    _DbType = DatabaseType.MySQL;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("读取配置文件错误，获取数据库配置失败！");
            }
           
            
        }

        private static DAOFactory _Instance = null;
        public static DAOFactory Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAOFactory();
                }
                return _Instance;
            }
        }
        
        public IEventLogDAO CreateEventLogDAO()
        {
            IEventLogDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.EventLogDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IStockBillDAO CreateStockBillDAO()
        {
            IStockBillDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.StockBillDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public ICompanyDAO CreateCompanyDAO()
        {
            ICompanyDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.CompanyDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }


        public IGoodsCategoryDAO CreateGoodsCategoryDAO()
        {
            IGoodsCategoryDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.GoodsCategoryDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IGoodsFromDAO CreateGoodsFromDAO()
        {
            IGoodsFromDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.GoodsFromDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IGoodsDAO CreateGoodsDAO()
        {
            IGoodsDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.GoodsDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IResourceDAO CreateResourceDAO()
        {
            IResourceDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.ResourceDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }


        public IStockBillTypeDAO CreateStockBillTypeDAO()
        {
            IStockBillTypeDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.StockBillTypeDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IStockDAO CreateStockDAO()
        {
            IStockDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.StockDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IStorehouseDAO CreateStorehouseDAO()
        {
            IStorehouseDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.StorehouseDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IUserDAO CreateUserDAO()
        {
            IUserDAO dao = null;
            if (_DbType == DatabaseType.SqlServer)
            {
                dao = new SqlServer.UserDAO();
            }
            else if (_DbType == DatabaseType.MySQL)
            {
                //dao = new MySQL.EventLogDAO();
            }
            return dao;
        }

        public IDbConnection OpenConnection()
        {
            IDbConnection conn = System.Data.Common.DbProviderFactories
                .GetFactory(_ProviderName).CreateConnection();
            conn.ConnectionString = _ConnectionString;
            conn.Open();
            return conn;
        }
    }
}
