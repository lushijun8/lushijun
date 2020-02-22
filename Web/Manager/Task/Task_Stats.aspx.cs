using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Task
{
    public partial class Task_Stats : Business.ManageWeb
    {
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Task/Task_Stats.aspx");
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            this.LogCount = 0;
            string CacheName = "Task_Stats";
            DataTable dt_task = null;
            if (Cache[CacheName] != null)
            {
                dt_task = (DataTable)Cache[CacheName];
            }
            else
            {
                Entity.TEAMTOOL.TASK task = new Entity.TEAMTOOL.TASK();
                dt_task = task.Database_Reader.ExecuteDataSet(CommandType.Text, @"select Task_WebManager_name,WebManager_Realname,count(1) as counts,0 as counts_Finished,0 as MINUTE_Cost into #temp from task  
left JOIN Admin_WebManager on Admin_WebManager.WebManager_name=Task_WebManager_name
group by Task_WebManager_name,WebManager_Realname

select Task_WebManager_name,count(1) as counts_Finished,avg(DATEDIFF ( MINUTE , Task_CreateTime , Task_Finished_Time )) as MINUTE_Cost
into #temp1 from task where Task_Finished=1  
group by Task_WebManager_name 

update #temp set 
#temp.counts_Finished=#temp1.counts_Finished,
#temp.MINUTE_Cost=#temp1.MINUTE_Cost
  from #temp1
where #temp.Task_WebManager_name=#temp1.Task_WebManager_name

select * from #temp 
order by cast(counts_Finished as FLOAT)/cast(counts as FLOAT) desc,MINUTE_Cost asc

DROP TABLE #temp
DROP TABLE #temp1
 
").Tables[0];
                Cache.Add(CacheName, dt_task.Copy(), null, System.DateTime.Now.Add(new TimeSpan(0, 0, 60 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            //====================================================
            this.LogCount = dt_task.Rows.Count;
            this.rptLog.DataSource = dt_task;
            this.rptLog.DataBind();
            #endregion

        }
    }
}
