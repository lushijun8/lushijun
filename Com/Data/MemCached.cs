
using System;
using BeIT.MemCached;

namespace Com.Data
{

    /// <summary>
    /// 可以指定serverlist，
    /// </summary>
    public class MemCached
    {
        private static object lockobject = new object();
        private static string DefaultPoolName = "default";
        private static string slist = Com.Config.SystemConfig.MemServer;
        private static string _keyPrefix = "";


        private static System.Collections.Generic.Dictionary<string, object> MGet(string[] keys)
        {
            checkPool(DefaultPoolName);
            MemcachedClient mc = getClient(DefaultPoolName);
            ulong[] unique;
            if (mc != null)
            {
                object[] list = mc.Gets(MCKeys(keys), out unique);
                System.Collections.Generic.Dictionary<string, object> hs = new System.Collections.Generic.Dictionary<string, object>();
                for (int i = 0; i < keys.Length; i++)
                {
                    hs.Add(keys[i], list[i]);
                }
                return hs;
            }
            else
                return null;
        }

        private static string[] MCKeys(string[] keys)
        {
            string[] new_keys = new string[keys.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                new_keys[i] = MCKey(keys[i]);
            }
            return new_keys;
        }
        public static object Get(string key)
        {
            return Get(key, DefaultPoolName);
        }
        private static object Get(string key, string poolName)
        {
            checkPool(DefaultPoolName);
            MemcachedClient mc = getClient(DefaultPoolName);
            return mc.Get(MCKey(key));
        }
        /// <summary>
        /// 获取，并返回数据，主要是为了返回计数器
        /// </summary>
        /// <param name="key"></param>
        /// <param name="poolName"></param>
        /// <param name="unique"></param>
        /// <returns></returns>
        private static object Get(string key, string poolName, out ulong unique)
        {
            checkPool(DefaultPoolName);
            MemcachedClient mc = getClient(DefaultPoolName);
            return mc.Gets(MCKey(key), out unique);
        }
        public static void Set(string key, object value)
        {
            Set(key, value, DefaultPoolName);
        }
        private static void Set(string key, object value, string poolName)
        {
            Set(key, value, DateTime.Now.AddYears(1), DefaultPoolName);
        }
        public static void Set(string key, object value, DateTime expiredTime)
        {
            Set(key, value, expiredTime, DefaultPoolName);
        }
        private static void Set(string key, object value, DateTime expiredTime, string poolName)
        {
            checkPool(DefaultPoolName);
            MemcachedClient mc = getClient(DefaultPoolName);
            mc.Set(MCKey(key), value, expiredTime);
        }
         
        public static bool Contains(string key)
        {
            return isExists(key);
        }
        private static bool Contains(string key, string poolName)
        {
            return isExists(key, DefaultPoolName);
        }
        private static bool isExists(string key, string poolName)
        {
            checkPool(DefaultPoolName);
            MemcachedClient mc = getClient(DefaultPoolName);
            return mc.Get(MCKey(key)) == null;
        }
        public static bool isExists(string key)
        {
            return isExists(key, DefaultPoolName);
        }
        public static bool Remove(string key)
        {
            return Remove(key, DefaultPoolName);
        }
        private static bool Remove(string key, string poolName)
        {
            checkPool(DefaultPoolName);
            MemcachedClient mc = getClient(DefaultPoolName);
            return mc.Delete(MCKey(key));
        }
        private static bool FlushAll()
        {
            checkPool(DefaultPoolName);
            MemcachedClient mc = MemcachedClient.GetInstance(DefaultPoolName + ConfigServerListKey);
            return mc.FlushAll();
        }
        private static MemcachedClient getClient(string poolName)
        {
            if (!MemcachedClient.Exists(poolName + ConfigServerListKey))
            {
                InitPool(poolName);
            }
            MemcachedClient mc = MemcachedClient.GetInstance(poolName + ConfigServerListKey);
            mc.CompressionThreshold = 4000;
            return mc;
        }
        private static string MCKey(string key)
        {
            if (key.Length > 250)
            {
                return key.Substring(key.Length - 100) +
                    System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key.Substring(0, key.Length - 100), "md5");
            }
            return key;
        }
        /// <summary>
        /// 检查poolName是否经过了初始化
        /// </summary>
        /// <param name="poolName"></param>
        private static void checkPool(string poolName)
        {
            if (!MemcachedClient.Exists(poolName + ConfigServerListKey))
            //没有这个PoolName的时候，或者，服务器列表已经有更改的时候，需要初始化poolname
            {
                InitPool(poolName);
            }
        }
        /// <summary>
        /// 初始化poolName
        /// </summary>
        /// <param name="poolName">需要初始化的poolName</param>
        private static void InitPool(string poolName)
        {
            if (!MemcachedClient.Exists(poolName + ConfigServerListKey))
            //没有这个PoolName的时候，或者，服务器列表已经有更改的时候，需要初始化poolname
            {

                if (slist == null || slist == "")
                {
                    throw new Exception("没有发现CahceServerList字段，格式：ip地址:端口，比如：192.168.0.1:11277，多个服务器用逗号分隔");
                }
                string[] serverlist = slist.Split(',');

                ConfigServerList = slist; //设置当前CacheServerList
                ConfigServerListKey = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(serverlist + DateTime.Now.Ticks.ToString(), "md5");
                if (!MemcachedClient.Exists(poolName + ConfigServerListKey))
                {
                    lock (lockobject)
                    {
                        if (!MemcachedClient.Exists(poolName + ConfigServerListKey))
                        {
                            MemcachedClient.Setup(poolName + ConfigServerListKey, serverlist);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ConfigServerList的md5码
        /// </summary>
        private static string ConfigServerListKey
        {
            get
            {
                if (_ConfigServerListKey == null)
                {
                    lock (lockobject)
                    {
                        _ConfigServerListKey = new System.Collections.Generic.Dictionary<string, string>();
                    }
                }
                if (_ConfigServerListKey.ContainsKey(_keyPrefix))
                {
                    return _ConfigServerListKey[_keyPrefix];
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {

                lock (lockobject)
                {
                    if (_ConfigServerListKey == null)
                    {
                        _ConfigServerListKey = new System.Collections.Generic.Dictionary<string, string>();
                    }
                    _ConfigServerListKey[_keyPrefix] = value;
                }
            }
        }
        private static System.Collections.Generic.Dictionary<string, string> _ConfigServerListKey = null;
        /// <summary>
        /// ConfigServerList 服务器列表
        /// </summary>
        private static string ConfigServerList
        {
            get
            {
                if (_ConfigServerList == null)
                {
                    lock (lockobject)
                    {
                        _ConfigServerList = new System.Collections.Generic.Dictionary<string, string>();
                    }
                }
                if (_ConfigServerList.ContainsKey(_keyPrefix))
                {
                    return _ConfigServerList[_keyPrefix];
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {

                lock (lockobject)
                {
                    if (_ConfigServerList == null)
                    {
                        _ConfigServerList = new System.Collections.Generic.Dictionary<string, string>();
                    }
                    _ConfigServerList[_keyPrefix] = value;
                }
            }
        }
        private static System.Collections.Generic.Dictionary<string, string> _ConfigServerList = null;

    }
}
