using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TeamToolTask
{
    public class JobWindowsController
    {
        private static string runtime = "";
        private delegate void MyDelegate();
        public static void Sync()
        {
            MyDelegate caller = new MyDelegate(Monitor);
            caller.BeginInvoke(null, null);
        }
        public static void Monitor()
        {
            if (runtime == DateTime.Now.ToString("yyyyMMddHH"))//每小时监控一次
            {
                return;
            }
            else
            {
                runtime = DateTime.Now.ToString("yyyyMMddHH");
            }
            #region 备份正式环境和测试环境的windows作业
            Entity.TEAMTOOL.TUANTASKAUTORUN tuantaskautorun_teamtool_delete = new Entity.TEAMTOOL.TUANTASKAUTORUN();
            tuantaskautorun_teamtool_delete.CREATEDATE = DateTime.Parse(DateTime.Now.ToShortDateString());
            tuantaskautorun_teamtool_delete.PrimaryKey = new string[] { tuantaskautorun_teamtool_delete._CREATEDATE };
            tuantaskautorun_teamtool_delete.Delete();

            //---------------------------------------------
            Entity.TEAMTOOL.TUANTASKAUTORUN tuantaskautorun_teamtool = new Entity.TEAMTOOL.TUANTASKAUTORUN();
            tuantaskautorun_teamtool.SelectColumns = new string[] { tuantaskautorun_teamtool.TableName + ".*" };
            tuantaskautorun_teamtool.ID = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            DataTable oDt_tuantaskautorun_teamtool = tuantaskautorun_teamtool.Select(1);
            //---------------------------------------------
            Entity.TUAN.TUANTASKAUTORUN tuantaskautorun_tuan = new Entity.TUAN.TUANTASKAUTORUN();
            DataTable oDt_tuantaskautorun_tuan = tuantaskautorun_tuan.Select();

            Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun_tuan_test = new Entity.TUAN_TEST.TUANTASKAUTORUN();
            DataTable oDt_tuantaskautorun_tuan_test = tuantaskautorun_tuan_test.Select();

            //---------------------------------------------
            foreach (DataRow oDr_tuantaskautorun_tuan in oDt_tuantaskautorun_tuan.Rows)
            {
                DataRow oDr_New = oDt_tuantaskautorun_teamtool.NewRow();
                foreach (DataColumn oDc_tuantaskautorun_tuan in oDt_tuantaskautorun_tuan.Columns)
                {
                    if (oDt_tuantaskautorun_teamtool.Columns.Contains(oDc_tuantaskautorun_tuan.ColumnName) == true)
                    {
                        oDr_New[oDc_tuantaskautorun_tuan.ColumnName] = oDr_tuantaskautorun_tuan[oDc_tuantaskautorun_tuan.ColumnName];
                    }
                }
                oDr_New[tuantaskautorun_teamtool._CREATEDATE] = DateTime.Parse(DateTime.Now.ToShortDateString());
                oDr_New[tuantaskautorun_teamtool._DATABASE_NAME] = "tuan";
                oDt_tuantaskautorun_teamtool.Rows.Add(oDr_New);
            }

            foreach (DataRow oDr_tuantaskautorun_tuan_test in oDt_tuantaskautorun_tuan_test.Rows)
            {
                DataRow oDr_New = oDt_tuantaskautorun_teamtool.NewRow();
                foreach (DataColumn oDc_tuantaskautorun_tuan_test in oDt_tuantaskautorun_tuan_test.Columns)
                {
                    if (oDt_tuantaskautorun_teamtool.Columns.Contains(oDc_tuantaskautorun_tuan_test.ColumnName) == true)
                    {
                        oDr_New[oDc_tuantaskautorun_tuan_test.ColumnName] = oDr_tuantaskautorun_tuan_test[oDc_tuantaskautorun_tuan_test.ColumnName];
                    }
                }
                oDr_New[tuantaskautorun_teamtool._CREATEDATE] = DateTime.Parse(DateTime.Now.ToShortDateString());
                oDr_New[tuantaskautorun_teamtool._DATABASE_NAME] = "tuan_test";
                oDt_tuantaskautorun_teamtool.Rows.Add(oDr_New);
            }
            tuantaskautorun_teamtool.BulkCopy(oDt_tuantaskautorun_teamtool);

            #endregion

            #region 监控未运行或者运行失败的windows作业
            Entity.TUAN.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN.TUANTASKAUTORUN();
            tuantaskautorun.ISOPEN = 1;
            tuantaskautorun.SelectColumns = new string[] { tuantaskautorun.TableName + ".*", "'正式' as database_name" };
            DataTable oDt_tuantaskautorun = tuantaskautorun.Select();
            //-----------------------------------------------------------
            Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun_test = new Entity.TUAN_TEST.TUANTASKAUTORUN();
            tuantaskautorun_test.ISOPEN = 1;
            tuantaskautorun_test.SelectColumns = new string[] { tuantaskautorun_test.TableName + ".*", "'测试' as database_name" };
            DataTable oDt_tuantaskautorun_test = tuantaskautorun_test.Select();
            foreach (DataRow oDr_tuantaskautorun_test in oDt_tuantaskautorun_test.Rows)
            {
                DataRow oDr_New = oDt_tuantaskautorun.NewRow();
                oDr_New.ItemArray = oDr_tuantaskautorun_test.ItemArray;
                oDt_tuantaskautorun.Rows.Add(oDr_New);
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
</head><body><a href=" + "\"" + Business.Config.HostUrl + "/Manager/Job/Job_List.aspx\"" + @">点击此处查看详情</a>{0}</body></html>";
            #endregion
            string Error = "";
            string Email_Author = "";
            foreach (DataRow oDr_tuantaskautorun in oDt_tuantaskautorun.Rows)
            {
                bool bWrong = false;
                string WhatWrong = "";
                #region 检查是否超时未运行
                if (oDr_tuantaskautorun[tuantaskautorun._ISOPEN].ToString() == "1")//在执行的
                {
                    TimeSpan ts = new TimeSpan();
                    if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "1")//每隔一段时间执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr_tuantaskautorun[tuantaskautorun._LASTRUNTIME].ToString()).AddMinutes(double.Parse(oDr_tuantaskautorun[tuantaskautorun._RUNMINITEOF].ToString()));
                        if (ts.TotalMinutes > 10) //超过10分钟未运行的
                        {
                            bWrong = true;
                        }
                    }
                    else if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "2")//每天定时执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr_tuantaskautorun[tuantaskautorun._LASTRUNTIME].ToString());
                        if (ts.TotalMinutes > 1470) //超过半小时未运行的
                        {
                            bWrong = true;
                        }
                    }
                    else if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "3")//每周定时执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr_tuantaskautorun[tuantaskautorun._LASTRUNTIME].ToString());
                        if (ts.TotalMinutes > 10140) //超过1小时未运行的
                        {
                            bWrong = true;
                        }
                    }
                    else if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "4")//每月定时执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr_tuantaskautorun[tuantaskautorun._LASTRUNTIME].ToString());
                        if (ts.TotalMinutes > 44760) //超过2小时未运行的
                        {
                            bWrong = true;
                        }
                    }
                    if (bWrong == true)
                    {
                        WhatWrong += "<font color=red>超过 ";

                        if (ts.TotalMinutes <= 60)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes, 1) + " 分钟";
                        }
                        else if (ts.TotalMinutes <= 1440)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 60, 1) + " 小时";
                        }
                        else if (ts.TotalMinutes <= 10080)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 1440, 1) + " 天";
                        }
                        else if (ts.TotalMinutes <= 44640)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 10080, 1) + " 周";
                        }
                        else if (ts.TotalMinutes <= 535680)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 44640, 1) + " 月";
                        }
                        else
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 535680, 1) + " 年";
                        }


                        WhatWrong += "未运行.</font>";

                    }
                }
                #endregion
                #region 拼装出错信息
                string runtypename = "";
                if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "1")//每隔一段时间执行
                {
                    runtypename = "每隔 " + oDr_tuantaskautorun["runminiteof"].ToString() + " 分钟";
                }
                if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "2")//每天定时执行
                {
                    runtypename = "每天 " + oDr_tuantaskautorun["runtimeat"] + " 执行一次";
                }
                if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "3")//每周定时执行
                {
                    runtypename = "每周 " + oDr_tuantaskautorun["runtimeat"] + " 执行一次";
                }
                if (oDr_tuantaskautorun[tuantaskautorun._RUNTYPE].ToString() == "4")//每月定时执行
                {
                    runtypename = "每月 " + oDr_tuantaskautorun["runtimeat"] + " 执行一次";
                }

                if (bWrong == true)
                {
                    Error += "<div class=" + "\"" + @"div_tooltip" + "\"" +
                      @"><p><b>问    题</b> ： " + WhatWrong +
                     @"<br/><b>运行环境</b> ： " + oDr_tuantaskautorun["database_name"].ToString() +
                     @"<br/><b>      ID</b> ： " + oDr_tuantaskautorun[tuantaskautorun._ID].ToString() +
                     @"<br/><b>作业名称</b> ： " + oDr_tuantaskautorun[tuantaskautorun._NAME].ToString() +
                     @"<br/><b>部署目录</b> ： " + oDr_tuantaskautorun[tuantaskautorun._PATH].ToString() + " <a href=\"" + Business.Config.HostUrl + "/Manager/Job/Job_My_Add.aspx?JobName=" + Com.Common.EncDec.Encrypt(oDr_tuantaskautorun[tuantaskautorun._PATH].ToString(), "fang.com") + "\">认领</a>" +
                     @"<br/><b>执行时间</b> ： " + runtypename +
                     @"<br/><b>上次执行</b> ： " + oDr_tuantaskautorun[tuantaskautorun._LASTRUNTIME].ToString() +
                     @"<br/><b>创 建 人</b> ： " + oDr_tuantaskautorun[tuantaskautorun._AUTHOR].ToString() +
                     @"<br/><b>负 责 人</b> ： " + //oDr_tuantaskautorun[tuantaskautorun._AUTHOR].ToString() +
                     @"<br/>---------------------------------------------------------------</p>" +
                     "<b>描    述</b> ： <p>" + oDr_tuantaskautorun[tuantaskautorun._TASKDETAIL].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;").Replace("\"", "'") + "</p><p>---------------------------------------------------------------</p></div><p>---------------------------------------------------------------</p>";


                    Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                    admin_webmanager.WhereSql = "(" +
                        admin_webmanager._WEBMANAGER_NAME + "='" + oDr_tuantaskautorun[tuantaskautorun._AUTHOR].ToString() + "' OR " +
                        admin_webmanager._WEBMANAGER_REALNAME + "='" + oDr_tuantaskautorun[tuantaskautorun._AUTHOR].ToString() + "')";
                    admin_webmanager.SelectTop1();
                    Email_Author += admin_webmanager.WEBMANAGER_NAME + "@fang.com;";
                }
                #endregion

            }
            if (!string.IsNullOrEmpty(Error))
            {
                #region 发报错邮件
                string MailUserList = Business.WebManager.OnLineUser.GetWebmanagerEmails(30, 1);

                Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                mail.MailTitle = "Windows作业有问题,请及时处理[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                mail.MailContent = body.Replace("{0}", Error);
                mail.MailUserList = MailUserList + ";" + Email_Author.TrimEnd(';');
                if (!mail.SendOneMailByHTML())
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "报错邮件发给“" + MailUserList + "”失败！");
                    Business.MallLog.Create(0, "AutoRunJob.JobWindowsController", "TeamTool报错邮件发送失败", "发送给" + MailUserList + "失败", "127.0.0.1");
                }
                #endregion
            }
            #endregion
        }
    }
}
