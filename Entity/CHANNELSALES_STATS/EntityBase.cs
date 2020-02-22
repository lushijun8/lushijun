using System;
namespace Entity.CHANNELSALES_STATS
{
    /// <summary>
    /// Entity 的摘要说明。
    /// </summary>
    public class EntityBase : Com.Common.Entity
    {
        public EntityBase()
        {
            string cacheName = "DataBase_CHANNELSALES_STATS";
            try
            {
                if (System.Web.HttpContext.Current.Cache[cacheName] != null)
                {
                    this.DataBase = (string)System.Web.HttpContext.Current.Cache[cacheName];
                }
                if (this.DataBase.Trim() == "")
                {
                    this.DataBase = Com.Data.DatabaseOperater.DataBaseWriter_Channelsales_Stats.GetConnection().Database;
                    System.Web.HttpContext.Current.Cache.Add(cacheName, this.DataBase, null, System.DateTime.Now.Add(new TimeSpan(0, 0, 30 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                }
            }
            catch 
            {
                this.DataBase = Com.Data.DatabaseOperater.DataBaseWriter_Channelsales_Stats.GetConnection().Database; 
            }
            this.Database_Reader = Com.Data.DatabaseOperater.DataBaseReader_Channelsales_Stats;
            this.Database_Writer = Com.Data.DatabaseOperater.DataBaseWriter_Channelsales_Stats;
            this.Database_Owner = Com.Data.DatabaseOperater.DataBaseOwner_Channelsales_Stats;
        }
    }
}