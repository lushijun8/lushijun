using System;
using System.Collections.Generic;
using System.Text;
using BeIT.MemCached;
namespace Business
{
    public class Memcached
    {
        private string _MemcachedServer = "";
        private MemcachedClient memClient;
        private Memcached _instance;
        private static object lockObj = new object();
        public Memcached Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new Memcached(_MemcachedServer);
                        }
                    }
                }
                return _instance;
            }
        }
        public Memcached(string MemcachedServer)
        {
            this._MemcachedServer = MemcachedServer;
            string name = Com.Common.EncDec.PasswordEncrypto(MemcachedServer);
            if (!MemcachedClient.Exists(name))
            {
                if (!String.IsNullOrEmpty(MemcachedServer))
                {
                    MemcachedClient.Setup(name, MemcachedServer.Split(new char[] { ',' }));
                }
            }
            this.memClient = MemcachedClient.GetInstance(name);

        }
        public void Add(string key, object value, uint seconds = 300)
        {
            memClient.Set(key, value, DateTime.Now.AddSeconds(seconds));
        }

        public void Remove(string key)
        {
            memClient.Delete(key);
        }

        public object Get(string key)
        {
            return memClient.Get(key);
        }

        public bool Reset()
        {
            return memClient.FlushAll();
        }
    }
}
