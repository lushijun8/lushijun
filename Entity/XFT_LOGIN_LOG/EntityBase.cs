using System;
namespace Entity.XFT_LOGIN_LOG
{
    /// <summary>
    /// Entity ��ժҪ˵����
    /// </summary>
    public class EntityBase : Com.Common.Entity
    {
        public EntityBase()
        {
            string cacheName = "DataBase_XFT_LOGIN_LOG";
            try
            {
                if (System.Web.HttpContext.Current.Cache[cacheName] != null)
                {
                    this.DataBase = (string)System.Web.HttpContext.Current.Cache[cacheName];
                }
                if (this.DataBase.Trim() == "")
                {
                    this.DataBase = Com.Data.DatabaseOperater.DataBaseWriter_Xft_Login_Log.GetConnection().Database;
                    System.Web.HttpContext.Current.Cache.Add(cacheName, this.DataBase, null, System.DateTime.Now.Add(new TimeSpan(0, 0, 30 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            catch 
            {
                this.DataBase = Com.Data.DatabaseOperater.DataBaseWriter_Xft_Login_Log.GetConnection().Database; 
            }
            this.Database_Reader = Com.Data.DatabaseOperater.DataBaseReader_Xft_Login_Log;
            this.Database_Writer = Com.Data.DatabaseOperater.DataBaseWriter_Xft_Login_Log;
            this.Database_Owner = Com.Data.DatabaseOperater.DataBaseOwner_Xft_Login_Log;
        }
    }
}