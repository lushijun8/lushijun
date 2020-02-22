using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_SqlServer : Business.ManageWeb
    {
        public string jobhtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_SqlServer.aspx");

            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            Entity.TEAMTOOL.JOB_LOG job_log = new Entity.TEAMTOOL.JOB_LOG();
            job_log.Distinct = true;
            job_log.SelectColumns = new string[]{job_log._DATABASE_IP,
                job_log._DATABASE_NAME,
                job_log._NAME,
                job_log._STEP_ID,

                job_log._DATABASE_IP+"+"+
                job_log._DATABASE_NAME+"+"+
                job_log._NAME+"+CAST("+
                job_log._STEP_ID+
                " AS VARCHAR(10)) AS JobName",

                job_log._STEP_NAME};
            job_log.OrderBy = job_log.TableName + "." + job_log._NAME + "," + job_log.TableName + "." + job_log._STEP_ID + " ASC";
            job_log.WhereSql = job_log._STEP_ID + "<>0";
            DataTable oDt_job_log = job_log.Select();

            oDt_job_log = Job_List.MatchWebManager(oDt_job_log, this.CurrentWebManagerName);//匹配负责人

            ArrayList database_ips = new ArrayList();
            foreach (DataRow oDr in oDt_job_log.Rows)
            {
                if (!database_ips.Contains(oDr[job_log._DATABASE_IP].ToString()))
                {
                    database_ips.Add(oDr[job_log._DATABASE_IP].ToString());
                }
            }
            jobhtml += "<table class=\"joblist\" width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\"><tr><th>数据库IP</th><th>数据库名称</th><th>作业名称</th><th>步骤</th><th>名称</th><th>负责人</th><th>认领</th><th>最后执行时间</th><th>状态</th></tr><tr>";
            for (int i = 0; i < database_ips.Count; i++)
            {
                DataRow[] oDrs_database_ips = oDt_job_log.Select(job_log._DATABASE_IP + "='" + database_ips[i].ToString() + "'");
                if (i > 0)
                {
                    jobhtml += "</tr><tr>";
                }
                jobhtml += "<td rowspan=\"" + oDrs_database_ips.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/Job/Job_List_SqlServer.aspx?keyword=" + database_ips[i].ToString() + "\">" + database_ips[i].ToString() + "</a></td>";
                #region 获取数据库名称
                ArrayList database_names = new ArrayList();
                foreach (DataRow oDr in oDrs_database_ips)
                {
                    if (!database_names.Contains(oDr[job_log._DATABASE_NAME].ToString()))
                    {
                        database_names.Add(oDr[job_log._DATABASE_NAME].ToString());
                    }
                }
                for (int j = 0; j < database_names.Count; j++)
                {
                    DataRow[] oDrs_database_names = oDt_job_log.Select(job_log._DATABASE_IP + "='" + database_ips[i].ToString() + "' and " + job_log._DATABASE_NAME + "='" + database_names[j].ToString() + "'");
                    if (j > 0)
                    {
                        jobhtml += "</tr><tr>";
                    }
                    jobhtml += "<td rowspan=\"" + oDrs_database_names.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/Job/Job_List_SqlServer.aspx?DataBase=" + database_ips[i].ToString() + "%7c" + database_names[j].ToString() + "\">" + database_names[j].ToString() + "</a></td>";
                    #region 获取作业
                    ArrayList names = new ArrayList();
                    foreach (DataRow oDr in oDrs_database_names)
                    {
                        if (!names.Contains(oDr[job_log._NAME].ToString()))
                        {
                            names.Add(oDr[job_log._NAME].ToString());
                        }
                    }
                    for (int k = 0; k < names.Count; k++)
                    {
                        DataRow[] oDrs_names = oDt_job_log.Select(job_log._DATABASE_IP + "='" + database_ips[i].ToString() + "' and " + job_log._DATABASE_NAME + "='" + database_names[j].ToString() + "' and " + job_log._NAME + "='" + names[k].ToString() + "'");
                        if (k > 0)
                        {
                            jobhtml += "</tr><tr>";
                        }
                        jobhtml += "<td rowspan=\"" + oDrs_names.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/Job/Job_List_SqlServer.aspx?DataBase=" + database_ips[i].ToString() + "%7c" + database_names[j].ToString() + "&keyword=" + Server.UrlEncode(names[k].ToString()) + "\">" + names[k].ToString() + "</a></td>";
                        #region 获取步骤
                        ArrayList step_names = new ArrayList();
                        ArrayList step_ids = new ArrayList();
                        ArrayList webmanager_realnames = new ArrayList();
                        ArrayList ismys = new ArrayList();
                        foreach (DataRow oDr in oDrs_names)
                        {
                            if (!step_names.Contains(oDr[job_log._STEP_NAME].ToString()))
                            {
                                step_names.Add(oDr[job_log._STEP_NAME].ToString());
                                step_ids.Add(oDr[job_log._STEP_ID].ToString());
                                webmanager_realnames.Add(oDr["webmanager_realname"].ToString());
                                ismys.Add(oDr["ismy"].ToString());

                            }
                        }
                        for (int l = 0; l < step_names.Count; l++)
                        {

                            Entity.TEAMTOOL.JOB_LOG job_log_step = new Entity.TEAMTOOL.JOB_LOG();
                            job_log_step.SelectColumns = new string[] { 
                                job_log_step._RUN_DATE, 
                                job_log_step ._RUN_TIME, 
                                job_log_step ._RUN_STATUS
                            };
                            job_log_step.OrderBy = "" + job_log.TableName + "." + job_log._RUN_DATE + "+" + job_log.TableName + "." + job_log._RUN_TIME + " DESC";
                            job_log_step.WhereSql = job_log_step._DATABASE_IP + "='" + database_ips[i].ToString() +
                                "' AND " + job_log_step._DATABASE_NAME + "='" + database_names[j].ToString() +
                                "' AND " + job_log_step._NAME + "='" + names[k].ToString() +
                                "' AND " + job_log_step._STEP_NAME + "='" + step_names[l].ToString() + "'";
                            job_log_step.SelectTop1();

                            string JobName = Com.Common.EncDec.Encrypt(database_ips[i].ToString() + database_names[j].ToString() + names[k].ToString() + step_ids[l].ToString(), this.Encrypt_key);
                            string run_time = job_log_step.RUN_TIME.PadLeft(6, '0');
                            string run_date = job_log_step.RUN_DATE.PadLeft(8, '0');
                            jobhtml += "<td>" + step_ids[l].ToString() + "</td><td><a href=\"" + Business.Config.HostUrl + "/Manager/Job/Job_List_SqlServer.aspx?DataBase=" + database_ips[i].ToString() + "%7c" + database_names[j].ToString() + "&keyword=" + Server.UrlEncode(step_names[l].ToString()) + "\">" + step_names[l].ToString() + "</a></td>" +
                                "<td>" + webmanager_realnames[l] + "</td><td>" +
                                (ismys[l].ToString() == "1" ? "<a href=\"" + Business.Config.HostUrl + "/Manager/Job/Job_My_Delete.aspx?JobName=" + JobName + "\" onclick=\"javascript:return confirm_me('" + JobName + "')\">删除认领</a>" : "<a href=\"" + Business.Config.HostUrl + "/Manager/Job/Job_My_Add.aspx?JobName=" + JobName + "\" onclick=\"javascript:return confirm_me('" + JobName + "')\">认领</a>") +
                                "</td><td>" + run_date.Substring(0, 4) + "-" + run_date.Substring(4, 2) + "-" + run_date.Substring(6, 2) + " " + run_time.Substring(0, 2) + ":" + run_time.Substring(2, 2) + ":" + run_time.Substring(4, 2) + "</td><td><img src=\"" + Business.Config.HostUrl + "/images/" + (job_log_step.RUN_STATUS_ToString == "1" ? "yes" : "no") + ".gif\" height=16 /></td>" +
                                "</tr><tr>";
                        }
                        #endregion
                        jobhtml += "";
                    }
                    #endregion
                    jobhtml += "";
                }
                #endregion
                jobhtml += "";
            }
            jobhtml += "</tr></table>";
            jobhtml = jobhtml.Replace("<tr></tr>", "");
            #endregion
        }
    }
}
