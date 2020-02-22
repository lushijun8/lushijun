using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TeamToolTask
{
    public class ErrorController
    {
        public static void SendEmail()
        {
            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager.SelectColumns = new string[] { admin_webmanager._WEBMANAGER_NAME };
            DataTable oDt_admin_webmanager = admin_webmanager.Select();

            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            DataTable dt_website_my_pageurl = website_my_pageurl.Select();


            Entity.TEAMTOOL.LOG_BUSINESS log_business = new Entity.TEAMTOOL.LOG_BUSINESS();
            log_business.SEND_EMAIL = 0;
            log_business.LOGLEVEL = 3;
            log_business.OrderBy = log_business._ID + " ASC";
            DataTable dt_log_business = log_business.Select(100);



            Entity.TEAMTOOL.LOG_ERROR log_error = new Entity.TEAMTOOL.LOG_ERROR();
            log_error.SEND_EMAIL = 0;
            log_error.OrderBy = log_error._ID + " ASC";
            DataTable dt_log_error = log_error.Select();
            dt_log_error.Columns.Add(new DataColumn("TableName", typeof(string)));
            foreach (DataRow oDr_log_business in dt_log_business.Rows)
            {
                DataRow oDr_New = dt_log_error.NewRow();
                oDr_New.ItemArray = oDr_log_business.ItemArray;
                oDr_New["TableName"] = "LOG_BUSINESS";
                dt_log_error.Rows.Add(oDr_New);
            }

            foreach (DataRow oDr_log_error in dt_log_error.Rows)
            {

                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + "正在处理LOG_ERROR.ID=" + oDr_log_error[log_error._ID].ToString() + "的报错日志");
                #region cachename
                string cachename =
                    oDr_log_error[log_error._TITLE].ToString() + "_" +
                    oDr_log_error[log_error._LOGLEVEL].ToString() + "_" +
                    oDr_log_error[log_error._CLASSNAME].ToString() + "_" +
                    oDr_log_error[log_error._METHODNAME].ToString() + "_" +
                    oDr_log_error[log_error._PAGEURL].ToString();// + "_" +
                //oDr_log_error[log_error._IP].ToString() +
                //oDr_log_error[log_error._USERNAME].ToString();
                cachename = cachename.Trim();
                #endregion
                System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;
                bool need_sendemail = false;
                string errorcount = "";
                if (cache[cachename] != null)
                {
                    #region 5分钟内已经发过邮件报警
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错邮件已经发过！");
                    //5分钟内计数累计超过50次就重新算
                    int cacheCount = int.Parse(cache[cachename].ToString());
                    cacheCount++;
                    cache.Remove(cachename);
                    cache.Add(cachename, cacheCount, null, System.DateTime.Now.Add(new TimeSpan(0, 5, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                    if (cacheCount >= 50)
                    {
                        errorcount = "5分钟内超过50次";
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错 " + errorcount);
                        need_sendemail = true;
                        cache.Remove(cachename);
                    }
                    #endregion
                }
                else
                {
                    need_sendemail = true;

                }
                string send_webmanager_name = "";
                if (need_sendemail == true)
                {
                    Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "需要发报警邮件！");
                    string pageurl = oDr_log_error[log_error._PAGEURL].ToString();
                    DataTable oDt_PageUrl = null;
                    ArrayList list_webmanager = Business.WebManager.MatchErrorManager.MatchWebManager(pageurl + " " + oDr_log_error[log_error._CONTENT].ToString() + " " + oDr_log_error[log_error._REMARKS].ToString() + " " + oDr_log_error[log_error._USERNAME].ToString(), out oDt_PageUrl);
                    DataRow[] MainUrl = oDt_PageUrl.Select("PageUrl='" + pageurl + "'");
                    DataRow[] NotMainUrl = oDt_PageUrl.Select("PageUrl<>'" + pageurl + "'");
                    #region 邮件内容
                    string body = @"<!DOCTYPE HTML PUBLIC " + "\"" + @"-//W3C//DTD HTML 4.01//EN" + "\"" + @" " + "\"" + @"http://www.w3.org/TR/html4/strict.dtd" + "\"" + @">
<html>
<head>
    <meta http-equiv=" + "\"" + @"Content-Type" + "\"" + @" content=" + "\"" + @"text/html; charset=gb2312" + "\"" + @" />
<style type=" + "\"" + @"text/css" + "\"" + @">   
* {word-break:break-all;word-wrap:break-word;margin:0;padding:0;text-align:left;}
body {text-align:center;font-family:" + "\"" + @"微软雅黑" + "\"" + @",Arial;font-size:12px;color:#000;background:#ffffff;}
#div_tooltip
{
    border:1px solid #cccccc;
    background-color:lightyellow;
    text-align:left;
}
</style>
</head><body><div id=" + "\"" + @"div_tooltip" + "\"" + @"><p><a href=" + "\"" + "" + Business.Config.HostUrl + "/Manager/Log/Log_" +
                       (oDr_log_error["TableName"].ToString() == "LOG_BUSINESS" ? "Business" : "Error") +
                       "_List.aspx?keyword=" + System.Web.HttpUtility.UrlEncode(pageurl, Encoding.GetEncoding("gb2312")) + "\">点击此处查看详情</a></p>" +
                       "<p>报错地址：" + pageurl;
                    if (MainUrl != null && MainUrl.Length > 0)
                    {
                        body += " <font color=red>" + MainUrl[0]["WebManager_RealName"].ToString() + "</font>";
                    }
                    body += @" <a href=" + "\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(pageurl, "fang.com") + "\">认领</a></p>";
                    if (NotMainUrl != null && NotMainUrl.Length > 0)
                    {
                        body += @"<p>相关地址 : <br/>";
                        foreach (DataRow oDr_PageUrl in NotMainUrl)
                        {
                            string lower_PageUrl = oDr_PageUrl["PageUrl"].ToString().ToLower();
                            if (lower_PageUrl.EndsWith(".jpg") == false &&
                                lower_PageUrl.EndsWith(".gif") == false &&
                                lower_PageUrl.EndsWith(".bmp") == false &&
                                lower_PageUrl.EndsWith(".png") == false &&
                                lower_PageUrl.EndsWith(".jpeg") == false)
                            {
                                body += oDr_PageUrl["PageUrl"].ToString() + " <font color=red>" + oDr_PageUrl["WebManager_RealName"].ToString() + "</font> <a href=" + "\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(oDr_PageUrl["PageUrl"].ToString(), "fang.com") + "\">认领</a><br/>";
                            }
                        }
                        body += @"</p>";
                    }

                    body += @"<p>报错时间 : " + oDr_log_error[log_error._CREATETIME].ToString() +
                            @"<br/>服务器IP : " + oDr_log_error[log_error._IP].ToString() +
                            @"<br/>标题 : " + oDr_log_error[log_error._TITLE].ToString() +
                            @"<br/>username : " + oDr_log_error[log_error._USERNAME].ToString() +
                            @"<br/>methodname : " + oDr_log_error[log_error._METHODNAME].ToString() +
                            @"<br/>loglevel : " + oDr_log_error[log_error._LOGLEVEL].ToString() +
                           @"<br/>---------------------------------------------------------------</p>详细信息 : <p>Content:<br />" + oDr_log_error[log_error._CONTENT].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;").Replace("\"", "'") + "</p><p>Remarks:<br />" + oDr_log_error[log_error._REMARKS].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;").Replace("\"", "'") + "</p><p>---------------------------------------------------------------</p></div></body></html>";

                    Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                    if (oDr_log_error["TableName"].ToString() == "LOG_BUSINESS")
                    {
                        mail.MailTitle = oDr_log_error[log_error._TITLE].ToString() + "[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                    }
                    else
                    {
                        string title = oDr_log_error[log_error._TITLE].ToString().ToLower();
                        int lastindex = title.LastIndexOf('.');

                        if (lastindex > 0)
                        {
                            title = title.Substring(0, lastindex);
                        }
                        if (pageurl.ToLower().IndexOf(title) > -1)
                        {
                            mail.MailTitle = pageurl + "报错,请及时处理[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                        }
                        else
                        {
                            mail.MailTitle = oDr_log_error[log_error._TITLE].ToString() + "[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                        }
                    }
                    mail.MailContent = body;
                    #endregion


                    if (list_webmanager.Count > 0)
                    {
                        string MailUserList = "";
                        for (int i = 0; i < list_webmanager.Count; i++)
                        {
                            MailUserList += list_webmanager[i].ToString() + "@fang.com;";
                            send_webmanager_name += list_webmanager[i].ToString() + ",";
                        }
                        #region 发邮件
                        mail.MailUserList = MailUserList.TrimEnd(';');
                        if (MailUserList.IndexOf("lushijun") == -1)
                        {
                            mail.CopyToMailUserList = "lushijun@fang.com";
                        }
                        System.Threading.Thread.Sleep(1500);
                        if (!mail.SendOneMailByHTML())
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错邮件发给“" + MailUserList + "”失败！");
                            Business.MallLog.Create(0, "AutoRunJob.SendEmail", "TeamTool报错邮件发送失败", "发送给" + MailUserList + "失败", "127.0.0.1");
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错邮件发给“" + MailUserList + "”成功！");
                            //3分钟内报警一次
                            cache.Add(cachename, "1", null, System.DateTime.Now.Add(new TimeSpan(0, 5, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                        }
                        #endregion
                    }
                    #region
                    //string[] pageurls = pageurl.Split('/');
                    //string pageurl_regex = oDr_log_error[log_error._PAGEURL_REGEX].ToString();
                    //DataRow[] oDrs_website_my_pageurl = dt_website_my_pageurl.Select(website_my_pageurl._PAGEURL_REGEX + "='" + pageurl_regex + "'");
                    //if (oDrs_website_my_pageurl != null && oDrs_website_my_pageurl.Length > 0)
                    //{
                    //    foreach (DataRow oDr_website_my_pageurl in oDrs_website_my_pageurl)
                    //    {
                    //        if (send_webmanager_name.IndexOf(oDr_website_my_pageurl[website_my_pageurl._WEBMANAGER_NAME].ToString()) > -1)
                    //        {
                    //            continue;
                    //        }
                    //        #region 发邮件
                    //        //"lushijun@fang.com"
                    //        string MailUserList = oDr_website_my_pageurl[website_my_pageurl._WEBMANAGER_NAME].ToString() + "@fang.com";
                    //        mail.MailUserList = MailUserList;
                    //        mail.CopyToMailUserList = "lushijun@fang.com";
                    //        System.Threading.Thread.Sleep(1500);
                    //        if (!mail.SendOneMailByHTML())
                    //        {
                    //            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错邮件发给“" + MailUserList + "”失败！");
                    //            Business.MallLog.Create(0, "AutoRunJob.SendEmail", "TeamTool报错邮件发送失败", "发送给" + MailUserList + "失败", "127.0.0.1");
                    //        }
                    //        else
                    //        {
                    //            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错邮件发给“" + MailUserList + "”成功！");
                    //            //3分钟内报警一次
                    //            cache.Add(cachename, "1", null, System.DateTime.Now.Add(new TimeSpan(0, 5, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                    //            send_webmanager_name += oDr_website_my_pageurl[website_my_pageurl._WEBMANAGER_NAME].ToString() + ",";
                    //        }
                    //        #endregion
                    //    }
                    //}
                    #endregion
                    else if (!string.IsNullOrEmpty(oDr_log_error[log_error._USERNAME].ToString()))
                    {
                        DataRow[] oDrs_admin_webmanager = oDt_admin_webmanager.Select(admin_webmanager._WEBMANAGER_NAME + "='" + oDr_log_error[log_error._USERNAME].ToString() + "'");
                        if (oDrs_admin_webmanager != null && oDrs_admin_webmanager.Length > 0)
                        {
                            #region 发邮件
                            string MailUserList = oDr_log_error[log_error._USERNAME].ToString() + "@fang.com";
                            mail.MailUserList = MailUserList;
                            mail.CopyToMailUserList = "lushijun@fang.com";
                            System.Threading.Thread.Sleep(1500);
                            if (!mail.SendOneMailByHTML())
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错邮件发给“" + MailUserList + "”失败！");
                                Business.MallLog.Create(0, "AutoRunJob.SendEmail", "TeamTool报错邮件发送失败", "发送给" + MailUserList + "失败", "127.0.0.1");
                            }
                            else
                            {
                                Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + cachename + "报错邮件发给“" + MailUserList + "”成功！");
                                //3分钟内报警一次
                                cache.Add(cachename, "1", null, System.DateTime.Now.Add(new TimeSpan(0, 5, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                                send_webmanager_name += oDr_log_error[log_error._USERNAME].ToString() + ",";
                            }
                            #endregion
                        }
                        else
                        {
                            Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + pageurl + " 没有匹配上负责人！");
                        }
                    }
                    else
                    {
                        Log.WriteLog("\r\n" + System.DateTime.Now.ToString() + pageurl + " 没有匹配上负责人！");
                    }
                }
                #region 记录已经处理过
                Entity.TEAMTOOL.LOG_ERROR log_error_update = new Entity.TEAMTOOL.LOG_ERROR();
                log_error_update.ID = int.Parse(oDr_log_error[log_error_update._ID].ToString());
                log_error_update.SEND_EMAIL = 1;
                log_error_update.SEND_WEBMANAGER_NAME = send_webmanager_name.TrimEnd(',');
                log_error_update.SEND_EMAIL_TIME = System.DateTime.Now;
                if (oDr_log_error["TableName"].ToString() == "LOG_BUSINESS")
                {
                    log_error_update.TableName = oDr_log_error["TableName"].ToString();
                }
                if (!log_error_update.Update())
                {
                    Log.WriteLog("\r\n" + log_error_update.TableName + "_update.Update()失败！ID=" + oDr_log_error[log_error_update._ID].ToString());
                }
                #endregion
            }
        }
    }
}
