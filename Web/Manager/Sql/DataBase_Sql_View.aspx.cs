using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Sql
{
    public partial class DataBase_Sql_View : Business.ManageWeb
    {
        public string Html = "";
        private string P_Sql_Md5 = "";
        private string P_Stats_Date = "";
        public string P_b = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] v=Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
            this.P_Sql_Md5 = v[0];
            this.P_Stats_Date = v[1];
            this.P_b = v[2];
            if (!string.IsNullOrEmpty(this.P_Sql_Md5) && !string.IsNullOrEmpty(this.P_Stats_Date))
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
            database_sql_stats.SQL_MD5 = this.P_Sql_Md5;
            database_sql_stats.STATS_DATE = DateTime.Parse(this.P_Stats_Date);
            DataRow oDr_database_sql_stats = database_sql_stats.SelectTop1();
            if (oDr_database_sql_stats != null)
            {
                this.Html = "<p>" + oDr_database_sql_stats[database_sql_stats._TEXT_ANALYSIS].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;") +
                                "</p><p><br />---------------------------------------------------------------------<br />(<b>" + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_ROWS].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString())).ToString() + @"行受影响</b>)
                                     <br />逻辑读取 " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_LOGICAL_READS].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString())).ToString("f0") + @" 次，物理读取 " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_PHYSICAL_READS].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString())).ToString("f0") + @" 次。
                                     <br />SQL Server 执行时间:
                                     <br />  CPU 时间 = " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_WORKER_TIME].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString()) / 1000).ToString("f0") + @" 毫秒。
                                     <br />SQL Server 执行时间:
                                      <br /> CPU 时间 = " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_ELAPSED_TIME].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString()) / 1000).ToString("f0") + @" 毫秒。
                                      </p><p><br />----------------------------------<br />(<b>漏洞与问题</b>)<br><span class=red>" + oDr_database_sql_stats[database_sql_stats._SQL_ERROR].ToString() + @"</span>
                                      </p><p><br />----------------------------------<br /><b>执行时间：</b>" + oDr_database_sql_stats[database_sql_stats._LAST_EXECUTION_TIME].ToString() + "<br><b>数据库：</b>" + oDr_database_sql_stats[database_sql_stats._DATABASE_NAME].ToString() + "</p><br><br>";
            }
        }
    }
}