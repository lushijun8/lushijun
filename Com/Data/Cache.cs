using System;
using System.Data;
namespace Com.Data
{
    /// <summary>
    /// Cache ��ժҪ˵����
    /// </summary>
    public class Cache
    {
        /// <summary>
        /// �ӻ����ȡDataTable
        /// </summary>
        /// <param name="Caching"></param>
        /// <param name="CacheName"></param>
        /// <param name="CacheTime"></param>
        /// <returns></returns>
        public static DataTable GetDataTableFromCache(int Caching, string CacheName, int CacheTime)
        {
            DataTable Value = null;
            if (Caching == 0)
            {
                Value = GetDataTableFromCaching(CacheName);
            }
            else if (Caching == 1)
            {
                Value = GetDataTableFromFile(CacheName, CacheTime);
            }
            else if (Caching == 2)
            {
                Value = GetDataTableFromMemcache(CacheName);
            }
            return Value;

        }
        /// <summary>
        /// �����ݱ�DataTable���浽����
        /// </summary>
        /// <param name="Caching"></param>
        /// <param name="CacheName"></param>
        /// <param name="table1"></param>
        /// <param name="CacheTime"></param>
        /// <returns></returns>
        public static bool SetDataTableToCache(int Caching, string CacheName, DataTable table1, int CacheTime)
        {
            bool Value = false;
            if (Caching == 0)
            {
                Value = SetDataTableToCaching(CacheName, table1, CacheTime);
            }
            else if (Caching == 1)
            {
                Value = SetDataTableToFile(CacheName, table1);
            }
            else if (Caching == 2)
            {
                Value = SetDataTableToMemcache(CacheName, table1, CacheTime);
            }
            return Value;
        }
        #region File��������

        /// <summary>
        /// ���ļ���ȡ�����DataTable
        /// </summary>
        /// <param name="CacheName">CacheName���</param>
        /// <param name="CacheTime">����ʱ�䣨���ӣ�</param>
        /// <returns></returns>
        private static DataTable GetDataTableFromFile(string CacheName, int CacheTime)
        {
            DataTable table1 = null;
            DataSet set1 = null;
            set1 = GetDataSetFromFile(CacheName, CacheTime);
            if (set1 != null && set1.Tables.Count > 0)
            {
                table1 = set1.Tables[0];
                set1.Dispose();
            }
            return table1;
        }
        /// <summary>
        /// ���ļ���ȡ�����DataSet
        /// </summary>
        /// <param name="CacheName"></param>
        /// <returns></returns>
        private static DataSet GetDataSetFromFile(string CacheName, int CacheTime)
        {
            DataSet set1 = null;
            string FileName = Com.Config.SystemConfig.LogFilePath + "\\log\\Cache\\" + CacheName.Substring(0, 1) + "\\" + CacheName;

            if (Com.File.FileUtil.FileExists(FileName))
            {
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(FileName);
                TimeSpan ts = System.DateTime.Now - fileinfo.LastWriteTime;//��ȡ��ʱ�ļ�����ʱ����
                if (ts.TotalMinutes < CacheTime)//�жϻ���ʱ��
                {
                    try
                    {
                        set1 = new DataSet();
                        set1.ReadXml(FileName, System.Data.XmlReadMode.ReadSchema);//�ӻ����ļ���ȡ
                    }
                    catch (Exception err)
                    {
                        Com.File.FileLog.WriteLog(" Com.Data.Cache.GetDataSetFromFile(string CacheName,int CacheTime)", "set1.ReadXml(FileName);�ӻ����ļ���ȡDataTable����", err.ToString());
                    }
                }
            }
            return set1;
        }
        /// <summary>
        /// �����ݱ��浽�ļ�
        /// </summary>
        /// <param name="table1"></param>
        /// <returns></returns>
        private static bool SetDataTableToFile(string CacheName, DataTable table1)
        {
            bool Value = false;
            DataSet set1 = new DataSet();
            set1.Tables.Add(table1.Copy());
            Value = SetDataSetToFile(CacheName, set1);
            set1.Dispose();
            return Value;
        }
        /// <summary>
        /// ������DataSet���浽�ļ�
        /// </summary>
        /// <param name="CacheName"></param>
        /// <param name="set1"></param>
        /// <returns></returns>
        private static bool SetDataSetToFile(string CacheName, DataSet set1)
        {
            bool Value = false;
            string FileName = Com.Config.SystemConfig.LogFilePath + "\\log\\Cache\\" + CacheName.Substring(0, 1) + "\\" + CacheName;
            string sXml = set1.GetXml();
            int length = sXml.Length / 85;
            if (set1 != null && sXml.Length > 0 && length < Com.Config.SystemConfig.CacheSize)//�����¼������100,���߳���512K,�����ļ�����ʱ�����0,���û����ļ�
            {

                try
                {
                    Com.File.FileUtil.FileCreate(FileName, 1);
                    set1.WriteXml(FileName, System.Data.XmlWriteMode.WriteSchema);//д�뻺���ļ�
                    Value = true;
                }
                catch (Exception err)
                {
                    Com.File.FileLog.WriteLog("Com.Data.Cache.SetDataSetToFile(string CacheName,DataSet set1)", "set1.WriteXml(FileName);Datasetд�뻺���ļ�����", err.ToString());
                }
            }
            return Value;
        }
        #endregion
        #region Caching��������

        /// <summary>
        /// ��Caching��ȡ�����DataTable
        /// </summary>
        /// <param name="CacheName">CacheName���</param>
        /// <returns></returns>
        private static DataTable GetDataTableFromCaching(string CacheName)
        {
            DataTable table1 = null;
            DataSet set1 = null;
            set1 = GetDataSetFromCaching(CacheName);
            if (set1 != null && set1.Tables.Count > 0)
            {
                table1 = set1.Tables[0].Copy();
            }
            return table1;
        }

        /// <summary>
        /// ��Caching��ȡ�����DataSet
        /// </summary>
        /// <param name="CacheName">CacheName���</param>
        /// <returns></returns>
        private static DataSet GetDataSetFromCaching(string CacheName)
        {
            DataSet set1 = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Cache[CacheName] != null)
            {
                set1 = ((DataSet)System.Web.HttpContext.Current.Cache[CacheName]).Copy();
            }
            else
            {
                System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;
                if (cache != null && cache[CacheName] != null)
                {
                    set1 = ((DataSet)cache.Get(CacheName)).Copy();
                }
            }
            return set1;
        }
        /// <summary>
        /// �����ݱ��浽Caching
        /// </summary>
        /// <param name="table1"></param>
        /// <returns></returns>
        private static bool SetDataTableToCaching(string CacheName, DataTable table1, int CacheTime)
        {
            bool Value = false;
            DataSet set1 = new DataSet();
            set1.Tables.Add(table1.Copy());
            Value = SetDataSetToCaching(CacheName, set1, CacheTime);
            set1.Dispose();
            return Value;
        }


        /// <summary>
        ///  ��DataSet���浽Caching
        /// </summary>
        /// <param name="CacheName"></param>
        /// <param name="set1"></param>
        /// <param name="CacheTime"></param>
        /// <returns></returns>
        private static bool SetDataSetToCaching(string CacheName, DataSet set1, int CacheTime)
        {
            bool Value = false;
            //string sXml=set1.GetXml();
            //int length= sXml.Length/85;
            //if(CacheTime>0 && set1!=null && sXml.Length>0 && length<Com.Config.SystemConfig.CacheSize)//�����¼������100,���߳���512K,�����ļ�����ʱ�����0,���û����ļ�
            if (CacheTime > 0 && set1 != null)
            {
                //DateTime expireTime = CacheMan.GetAbsoluteTime(CacheTime);
                //DB.NormalCache.Add(CacheName, set1.Copy(), expireTime); 
                if (System.Web.HttpContext.Current != null)
                {
                    System.Web.HttpContext.Current.Cache.Add(CacheName, set1.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, CacheTime * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                    Value = true;
                }
                else
                {
                    System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;
                    if (cache != null)
                    {
                        if (cache[CacheName] != null)
                        {
                            cache.Remove(CacheName);
                        }
                        cache.Insert(CacheName, set1.Copy());
                        Value = true;
                    }
                }
            }
            return Value;
        }
        #endregion
        #region Memcache��������

        /// <summary>
        /// ��Memcache��ȡ�����DataTable
        /// </summary>
        /// <param name="CacheName">CacheName���</param>
        /// <param name="CacheTime">����ʱ�䣨���ӣ�</param>
        /// <returns></returns>
        private static DataTable GetDataTableFromMemcache(string CacheName)
        {
            DataTable table1 = null;
            DataSet set1 = null;
            set1 = GetDataSetFromMemcache(CacheName);
            if (set1 != null && set1.Tables.Count > 0)
            {
                table1 = set1.Tables[0];
                set1.Dispose();
            }
            return table1;
        }


        /// <summary>
        /// ��Memcache��ȡ�����DataSet
        /// </summary>
        /// <param name="CacheName">CacheName���</param>
        /// <returns></returns>
        private static DataSet GetDataSetFromMemcache(string CacheName)
        {
            DataSet set1 = null;
            if (MemCached.Contains(CacheName))
            {
                set1 = (DataSet)MemCached.Get(CacheName);
            }
            return set1;
        }
        /// <summary>
        /// �����ݱ��浽Memcache
        /// </summary>
        /// <param name="table1"></param>
        /// <returns></returns>
        private static bool SetDataTableToMemcache(string CacheName, DataTable table1, int CacheTime)
        {
            bool Value = false;
            DataSet set1 = new DataSet();
            set1.Tables.Add(table1.Copy());
            Value = SetDataSetToMemcache(CacheName, set1, CacheTime);
            set1.Dispose();
            return Value;
        }
        /// <summary>
        ///  ��DataSet���浽Memcache
        /// </summary>
        /// <param name="CacheName"></param>
        /// <param name="set1"></param>
        /// <param name="CacheTime"></param>
        /// <returns></returns>
        private static bool SetDataSetToMemcache(string CacheName, DataSet set1, int CacheTime)
        {
            bool Value = false;
            if (CacheTime > 0 && set1 != null)
            {
                DateTime expireTime = System.DateTime.Now.AddMinutes(CacheTime);
                MemCached.Set(CacheName, set1, expireTime);
                Value = true;
            }
            return Value;
        }

        #endregion
    }
}
