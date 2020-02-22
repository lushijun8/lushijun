using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TeamToolTask
{
    public class JobDataBaseController
    {
        private static DataTable oDt_admin_webmanager = null;
        public static void Monitor()
        {
            if (oDt_admin_webmanager == null)
            {
                Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_NAME };
                admin_webmanager.Distinct = true;
                admin_webmanager.CacheTime = 1440;
                oDt_admin_webmanager = admin_webmanager.Select();
            }
            #region 邮件body
            string body = @"<!DOCTYPE HTML PUBLIC " + "\"" + @"-//W3C//DTD HTML 4.01//EN" + "\"" + @" " + "\"" + @"http://www.w3.org/TR/html4/strict.dtd" + "\"" + @">
<html>
<head>
    <meta http-equiv=" + "\"" + @"Content-Type" + "\"" + @" content=" + "\"" + @"text/html; charset=gb2312" + "\"" + @" />
<style type=" + "\"" + @"text/css" + "\"" + @">   
* {word-break:break-all;word-wrap:break-word;margin:0;padding:0;text-align:left;}
body {text-align:center;font-family:" + "\"" + @"微软雅黑" + "\"" + @",Arial;font-size:12px;color:#000;background:#ffffff;}
div.div_tooltip
{
    border:1px solid #cccccc;
    background-color:lightyellow;
}
</style>
</head><body><a href=" + "\"" + Business.Config.HostUrl + "/Manager/Job/Job_List_SqlServer.aspx\"" + @">点击此处查看详情</a>{0}</body></html>";
            #endregion
            string MailUserList = "lushijun@fang.com";
            string Error = "";
            int ErrorCount = 0;
            #region 获取数据库列表
            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.DATABASE_IS_MAIN = 1;
            database_owner.SelectColumns = new string[] { database_owner._DATABASE_IP_ROMOTE, database_owner._DATABASE_NAME };
            database_owner.Select();
            #endregion
            while (database_owner.Next())
            {
                Entity.TEAMTOOL.JOB_LOG job_log = new Entity.TEAMTOOL.JOB_LOG();
                job_log.DATABASE_IP = database_owner.DATABASE_IP_ROMOTE;
                job_log.DATABASE_NAME = database_owner.DATABASE_NAME;
                job_log.SelectColumns = new string[] { "isnull(max(" + job_log._RUN_DATE + "+" + job_log._RUN_TIME + "),0) as " + job_log._RUN_TIME + "" };
                DataRow oDr = job_log.SelectTop1();
                string Max_Run_Time = oDr[job_log._RUN_TIME].ToString().PadRight(14, '0');
                try
                {
                    #region 获取job列表
                    Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
                    DataTable oDt_Job_Log = Database_Owner.ExecuteDataSet(CommandType.Text, @"select  a.run_date,replicate('0',6 - len(cast(run_time as VARCHAR(10)))) + cast(run_time as VARCHAR(10)) as run_time, b.name,step_id,step_name,a.message,b.description,b.enabled,b.date_created,b.date_modified,a.run_status,a.run_duration
                                                from msdb.dbo.sysjobhistory a ,msdb.dbo.sysjobs b 
                                                where a.job_id=b.job_id 
                                                and name like('%" + database_owner.DATABASE_NAME + @"%') 
                                                and name not like('%备份%') 
                                                --and a.step_id>0 
                                                --and a.run_status=0
                                                and cast(cast(a.run_date as VARCHAR(10))+cast(replicate('0',6 - len(cast(run_time as VARCHAR(10)))) + cast(run_time as VARCHAR(10))  as VARCHAR(10)) as bigint)>" + Max_Run_Time + @"
                                                order by run_date desc,run_time desc,step_id desc").Tables[0];
                    #endregion
                    foreach (DataRow oDr_Job_Log in oDt_Job_Log.Rows)
                    {
                        #region 插入本地数据库
                        string error = "";
                        string email = "";
                        Insert(database_owner.DATABASE_IP_ROMOTE, database_owner.DATABASE_NAME, oDr_Job_Log, out error, out email);
                        if (!string.IsNullOrEmpty(error) && ErrorCount <= 5)
                        {
                            Error += error;
                            ErrorCount++;
                            if (!string.IsNullOrEmpty(email))
                            {
                                if (MailUserList.IndexOf(email) == -1)
                                {
                                    MailUserList += ";" + email;
                                }
                            }
                        }
                        #endregion
                    }
                }
                catch
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "监控" + database_owner.DATABASE_IP_ROMOTE + ".." + database_owner.DATABASE_NAME + "作业失败,开始从xfds_monitor库抓取!");
                    #region 获取正式库job列表

                    Database Database_Owner = DatabaseFactory.CreateDatabase("124.251.44.233_xfds_monitor_DataBaseInstance");
                    DataTable oDt_Job_Log = Database_Owner.ExecuteDataSet(CommandType.Text, @"SELECT TOP 1000
	                                        rundate as run_date,
	                                        replicate('0',6 - len(cast(runtime as VARCHAR(10)))) + cast(runtime as VARCHAR(10)) AS run_time,
	                                        jobname as name,
	                                        step as step_id,
	                                        stepname as step_name,
	                                        message,
	                                        '无描述' as description,
	                                        1 as enabled,
	                                        '2016-1-1' as date_created,
	                                        '2016-1-1' as date_modified,
	                                        case status when 'Succeeded' then 1 else 0 end  as run_status,
	                                        duration as run_duration
                                        FROM job_monitor_byxf
                                        WHERE CAST(CAST(rundate AS VARCHAR(10)) + CAST(replicate('0',6 - len(cast(runtime as VARCHAR(10)))) + cast(runtime as VARCHAR(10)) AS VARCHAR(10)) AS BIGINT) > " + Max_Run_Time + @"
                                        and host_ip='" + database_owner.DATABASE_IP_ROMOTE + @"' 
                                        and jobname LIKE '%" + database_owner.DATABASE_NAME + @"%'").Tables[0];
                    #endregion

                    foreach (DataRow oDr_Job_Log in oDt_Job_Log.Rows)
                    {
                        #region 插入本地数据库
                        string error = "";
                        string email = "";
                        Insert(database_owner.DATABASE_IP_ROMOTE, database_owner.DATABASE_NAME, oDr_Job_Log, out error, out email);
                        if (!string.IsNullOrEmpty(error) && ErrorCount <= 5)
                        {
                            Error += error;
                            ErrorCount++; 
                            if (!string.IsNullOrEmpty(email))
                            {
                                if (MailUserList.IndexOf(email) == -1)
                                {
                                    MailUserList += ";" + email;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }

            if (!string.IsNullOrEmpty(Error))
            {
                #region 发报错邮件
                Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                mail.MailTitle = "数据库作业有报错,请及时处理[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                mail.MailContent = body.Replace("{0}", Error);
                mail.MailUserList = MailUserList;
                if (!mail.SendOneMailByHTML())
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "报错邮件发给“" + MailUserList + "”失败！");
                    Business.MallLog.Create(0, "AutoRunJob.JobController", "TeamTool报错邮件发送失败", "发送给" + MailUserList + "失败", "127.0.0.1");
                }
                #endregion
            }
        }
        private static bool Insert(string DATABASE_IP_ROMOTE, string DATABASE_NAME, DataRow oDr, out string Error, out string Email)
        {
            Error = "";
            Email = "";
            Entity.TEAMTOOL.JOB_LOG job_log_new = new Entity.TEAMTOOL.JOB_LOG();
            if (oDr[job_log_new._RUN_STATUS].ToString() == "0")
            {
                Error = "<div class=" + "\"" + @"div_tooltip" + "\"" +
                    @"><p>数据库 : " + DATABASE_IP_ROMOTE + ".." + DATABASE_NAME +
              @"<br/>作业名称 : " + oDr[job_log_new._NAME].ToString() +
              @"<br/>步骤名称 : " + oDr[job_log_new._STEP_NAME].ToString() +
              @"<br/>执行时间 : " + oDr[job_log_new._RUN_DATE].ToString().Substring(0, 4) + "-" + oDr[job_log_new._RUN_DATE].ToString().Substring(4, 2) + "-" + oDr[job_log_new._RUN_DATE].ToString().Substring(6, 2) + " " + oDr[job_log_new._RUN_TIME].ToString().Substring(0, 2) + ":" + oDr[job_log_new._RUN_TIME].ToString().Substring(2, 2) + ":" + oDr[job_log_new._RUN_TIME].ToString().Substring(4, 2) +
              @"<br/>---------------------------------------------------------------</p>报错信息 : <p>" + oDr[job_log_new._MESSAGE].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;").Replace("\"", "'") + "</p><p>---------------------------------------------------------------</p></div><p>---------------------------------------------------------------</p>";
                foreach (DataRow oDr_admin_webmanager in oDt_admin_webmanager.Rows)
                {
                    string WebManager_Name = oDr_admin_webmanager["WEBMANAGER_NAME"].ToString().ToLower();
                    if (oDr[job_log_new._STEP_NAME].ToString().ToLower().IndexOf(WebManager_Name) > -1)
                    {
                        Email = WebManager_Name + "@fang.com";
                        break;
                    }
                }
            }
            #region 插入本地数据库
            job_log_new.DATABASE_IP = DATABASE_IP_ROMOTE;
            job_log_new.DATABASE_NAME = DATABASE_NAME;
            job_log_new.RUN_DATE = oDr[job_log_new._RUN_DATE].ToString();
            job_log_new.RUN_TIME = oDr[job_log_new._RUN_TIME].ToString().PadLeft(6, '0');
            job_log_new.STEP_ID = int.Parse(oDr[job_log_new._STEP_ID].ToString());
            job_log_new.NAME = oDr[job_log_new._NAME].ToString();
            job_log_new.STEP_NAME = oDr[job_log_new._STEP_NAME].ToString();
            job_log_new.MESSAGE = oDr[job_log_new._MESSAGE].ToString();
            job_log_new.DESCRIPTION = oDr[job_log_new._DESCRIPTION].ToString();
            job_log_new.ENABLED = int.Parse(oDr[job_log_new._ENABLED].ToString());
            job_log_new.DATE_CREATED = DateTime.Parse(oDr[job_log_new._DATE_CREATED].ToString());
            job_log_new.DATE_MODIFIED = DateTime.Parse(oDr[job_log_new._DATE_MODIFIED].ToString());
            job_log_new.RUN_STATUS = int.Parse(oDr[job_log_new._RUN_STATUS].ToString());
            job_log_new.RUN_DURATION = int.Parse(oDr[job_log_new._RUN_DURATION].ToString());
            bool bResult = job_log_new.Insert();
            return bResult;
            #endregion
        }
    }
}
