using System;
using Microsoft.Win32;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
namespace Com.Config
{
    /// <summary>
    /// SystemConfig 的摘要说明。
    /// </summary>
    public class SystemConfig
    {
        public static DBType DatabaseType;
        public static string DefaultConnectionString;
        /// <summary>
        /// 字典Xml存放日志
        /// </summary>
        public static string FinderFilePath;
        /// <summary>
        /// 错误日志存放路径
        /// </summary>
        public static string LogFilePath;
        /// <summary>
        /// 缓存方式：0传统的内存缓存，1文件缓存，2Memcache缓存
        /// </summary>
        public static int Caching = 0;
        /// <summary>
        /// 缓存时间，如果小于等于0则不使用缓存机制
        /// </summary>
        public static int CacheTime = 0;
        /// <summary>
        /// 数据缓存最大值，默认为512K，如果不存在该节点则取默认值
        /// </summary>
        public static int CacheSize = 25600;
        public static string MailAddess;
        public static string MailPassWord;
        public static string MailServer;
        public static string MailUser;
        public static string MailServers;
        public static string MailUsers;
        public static string SecSimpleDictName;
        public static string MemServer;
        public static DboType DBOType = DboType.Parameter;


        public SystemConfig()
        {
        }

        static SystemConfig()
        {
            SystemConfig.MailServer = ConfigUtil.GetValueFromWebConfig("MailServer");
            SystemConfig.MailUser = ConfigUtil.GetValueFromWebConfig("MailUser");
            SystemConfig.MailServers = ConfigUtil.GetValueFromWebConfig("MailServers");
            SystemConfig.MailUsers = ConfigUtil.GetValueFromWebConfig("MailUsers");
            SystemConfig.MailPassWord = ConfigUtil.GetValueFromWebConfig("MailPassWord");
            SystemConfig.MailAddess = ConfigUtil.GetValueFromWebConfig("MailAddess");
            SystemConfig.LogFilePath = ConfigUtil.GetValueFromWebConfig("LogFilePath");
            SystemConfig.MemServer = ConfigUtil.GetValueFromWebConfig("MemServer");
            if (ConfigUtil.GetValueFromWebConfig("CacheTime") != "")
            {
                try
                {
                    SystemConfig.CacheTime = int.Parse(ConfigUtil.GetValueFromWebConfig("CacheTime"));//以分钟计算的数据缓存时间;
                }
                catch
                {
                }
            }
            if (ConfigUtil.GetValueFromWebConfig("CacheSize") != "")
            {
                try
                {
                    SystemConfig.CacheSize = int.Parse(ConfigUtil.GetValueFromWebConfig("CacheSize"));//K
                }
                catch
                {
                }
            }
            string caching = ConfigUtil.GetValueFromWebConfig("Caching").ToUpper();
            //if (caching == "YES" || caching == "1" || caching == "TRUE")
            if (caching == "0")
            {
                SystemConfig.Caching = 0;
            }
            else if (caching == "1")
            {
                SystemConfig.Caching = 1;
            }
            else if (caching == "2")
            {
                SystemConfig.Caching = 2;
            }
            if (System.Web.HttpContext.Current != null)
            {
                SystemConfig.FinderFilePath = System.Web.HttpContext.Current.Server.MapPath("/Manage/Comm/Finder/Finder.xml");
            }
            string FinderFilePath = ConfigUtil.GetValueFromWebConfig("FinderFilePath");
            if (FinderFilePath!="")
            {
                SystemConfig.FinderFilePath = FinderFilePath;
            }

            SystemConfig.DatabaseType = SystemConfig.GetDbTypeFromConfig();
            SystemConfig.SecSimpleDictName = SystemConfig.GetDictNameFromConfig();
            SystemConfig.DefaultConnectionString = SystemConfig.GetDefaultConnectString("");
            SystemConfig.DBOType = SystemConfig.GetDboTypeFromConfig();

        }

        private static DboType GetDboTypeFromConfig()
        {
            string text2;
            string text1 = ConfigUtil.GetValueFromWebConfig("DboType").ToUpper();
            if ((text2 = text1) != null)
            {
                text2 = string.IsInterned(text2);
                if (text2 == "SQL")
                {
                    return DboType.Sql;
                }
                else if (text2 == "PARAMETER")
                {
                    return DboType.Parameter;
                }
                else if (text2 == "PROCEDURE")
                {
                    return DboType.Procedure;
                }
            }
            return DboType.Parameter;
        }

        private static DBType GetDbTypeFromConfig()
        {
            string text2;
            string text1 = ConfigUtil.GetValueFromWebConfig("DbType").ToUpper();
            if ((text2 = text1) != null)
            {
                text2 = string.IsInterned(text2);
                if (text2 != "SQLSERVER")
                {
                    if (text2 == "ORACLE")
                    {
                        return DBType.Oracle;
                    }
                }
                else
                {
                    return DBType.SQLServer;
                }
            }
            return DBType.SQLServer;
        }

        private static string GetDefaultConnectString(string DbType)
        {
            string text1 = "";
            try
            {
                text1 = ConfigUtil.GetValueFromWebConfig("ConnectionString");
            }
            catch (Exception)
            {
            }
            if ((text1 == "") || (text1 == null))
            {
                try
                {
                    RegistryKey key1 = Registry.LocalMachine.OpenSubKey("SOFTWARE");
                    RegistryKey key2 = key1.OpenSubKey("HR3Software");
                    text1 = key2.GetValue("DBServer").ToString();
                }
                catch (Exception)
                {
                }
            }
            return text1;
        }

        private static string GetDictNameFromConfig()
        {
            string text1 = ConfigUtil.GetValueFromWebConfig("SecSimpleDictName");
            if ((text1 == null) && (text1 == ""))
            {
                text1 = "";
            }
            return text1;
        }

        /// <summary>
        /// 获取数据库配置文件中指定实例的指定参数
        /// </summary>
        /// <param name="instanceName">实例名称</param>
        /// <param name="parameter">参数名称</param>
        /// <returns></returns>
        public static string GetDataSettingParam(string instanceName, string parameter)
        {
            string strValue = String.Empty;

            DatabaseSettings data = ConfigurationManager.GetConfiguration("dataConfiguration") as DatabaseSettings;
            if (data != null)
            {
                InstanceData instanceData = data.Instances[instanceName];
                if (instanceData != null)
                {
                    string strConnectionString = instanceData.ConnectionString;
                    if (strConnectionString != null)
                    {
                        ConnectionStringData con = data.ConnectionStrings[strConnectionString];
                        if (con != null)
                        {
                            strValue = con.Parameters[parameter].Value;
                        }
                    }
                }
            }

            return strValue;
        }

    }
}