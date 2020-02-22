using System;
namespace Entity.TUAN_TEST
{
    /// <summary>
    /// Entity 的摘要说明。
    /// </summary>
    public class EntityBase : Com.Common.Entity
    {
        public EntityBase()
        {
            string cacheName = "DataBase_TUAN_TEST";
            try
            {
                if (System.Web.HttpContext.Current.Cache[cacheName] != null)
                {
                    this.DataBase = (string)System.Web.HttpContext.Current.Cache[cacheName];
                }
                if (this.DataBase.Trim() == "")
                {
                    this.DataBase = Com.Data.DatabaseOperater.DataBaseWriter_Tuan_Test.GetConnection().Database;
                    System.Web.HttpContext.Current.Cache.Add(cacheName, this.DataBase, null, System.DateTime.Now.Add(new TimeSpan(0, 0, 30 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            catch 
            {
                this.DataBase = Com.Data.DatabaseOperater.DataBaseWriter_Tuan_Test.GetConnection().Database; 
            }
            this.Database_Reader = Com.Data.DatabaseOperater.DataBaseReader_Tuan_Test;
            this.Database_Writer = Com.Data.DatabaseOperater.DataBaseWriter_Tuan_Test;
            this.Database_Owner = Com.Data.DatabaseOperater.DataBaseOwner_Tuan_Test;
        }
    }
}