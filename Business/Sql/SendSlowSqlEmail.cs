using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Business.Sql
{
    public class SendSlowSqlEmail
    {
        public static void Run()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return;
            }
            if (System.DateTime.Now.Hour >= 9 && System.DateTime.Now.Hour <= 16)
            { 
                #region 判断今天有人用过服务器更新吗，如果有说明是上班时间
                Entity.TEAMTOOL.SERVER_UPDATE_LOG server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_LOG();
                server_update_log.WhereSql = server_update_log._CREATETIME + ">'" + System.DateTime.Now.ToShortDateString() + "'";
                if(server_update_log.SelectTop1()==null)
                {
                    return;
                }
                #endregion

                string CacheName = "SendSlowSqlEmail";
                if (System.Web.HttpRuntime.Cache[CacheName] != null)
                {
                    return;
                }
                else
                {
                    System.Web.HttpRuntime.Cache.Add(CacheName, "SendSlowSqlEmail", null, System.DateTime.Now.Add(new TimeSpan(0, 20, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
                    #region style
                    string style = @"* {
  word-break: break-all;
  word-wrap: break-word;
  margin: 0;
  padding: 0;
  text-align: left;
}
.Body_PageContent table {
  margin-bottom: 10px;
  border: solid 0px #dfdfdf;
}
.Body_Content table {
  font-size: 12px;
  margin-top: 22px;
}
table, td, tr, th {
  line-height: 170%;
}
tr {
  display: table-row;
  vertical-align: inherit;
  border-color: inherit;
}
#messagelist th {
  white-space: nowrap;
}
.Body_PageContent th {
  background-color: #dfdfdf;
  padding: 4px 5px 1px 5px;
  border-top: solid 0px #BFC4CA;
  border-left: solid 1px #cccccc;
  color: #000000;
}
.Body_PageContent td {
  padding: 4px 5px 1px 5px;
  border-left: solid 1px #cccccc;
}
.Body_PageContent tr.b {
  background-color: #f2f2f2;
}

span.red
{
    background-color:red;
    color:white;
}
span.black
{
    background-color:black;
    color:white;
}
span.green
{
    /*background-color:lightgreen;*/
    background-color:green;
    color:white;
}
span.yellow {
  /* background-color: yellow; */
  background-color: green;
  color: white;
}
";
                    #endregion
                    Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                    //admin_webmanager.WEBMANAGER_NAME = "duhao.bj";
                    admin_webmanager.WEBMANAGER_STATUS = 100;
                    admin_webmanager.CacheTime = 300;
                    admin_webmanager.Select();
                    int max_duration = 10;//执行时间超过10秒的SQL
                    int counts = 10;
                    while (admin_webmanager.Next())
                    {
                        System.Threading.Thread.Sleep(2500);
                        string body = "<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head><title>你的SQL执行较慢~[系统邮件请勿回复]</title><style type=\"text/css\">" + style + "</style></head><body  class=\"Body_Right\"><div class=\"Body_Content\"><div class=\"Body_PageContent\">" +
                            "Hi!!&nbsp;&nbsp;" + admin_webmanager.WEBMANAGER_REALNAME + " 同学.<br/><br/>" +
                           "&nbsp;&nbsp;我们根据URL认领情况匹配出以下SQL疑似你负责的，并且SQL执行较慢，超过了" + max_duration.ToString() + "秒，请立刻认领并针对发现的漏洞与问题进行优化，如果确定不是您负责的请点击“忽略”即可。<br/>" +
                           "<a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View.aspx?Article_Id=FFEE5CC7BFEA797E\">SQL语句最基本的性能优化方法</a><br/><br/><a href=\"" + Business.Config.HostUrl + "/Manager/Sql/DataBase_Sql_List_LikeMine.aspx\">查看更多疑似我的SQL</a><br/>";
                        #region 获取SQL
                        string sql = @"
                                    declare @WebManager_name varchar(50),@today varchar(100),@counts int
                                    SET @WebManager_name='" + admin_webmanager.WEBMANAGER_NAME + @"'
                                    SET @today = (SELECT CONVERT(VARCHAR(100), GETDATE(), 23))

                                    SELECT @counts=count(1) FROM [DataBase_Sql_SendEmail] WITH (NOLOCK) WHERE 
                                    WebManager_name = @WebManager_name 
                                    AND CreateTime>=@today
                                    if(@counts<" + (counts * 3).ToString() + @")
                                        BEGIN
                                            SELECT TOP " + counts.ToString() + @" * FROM DATABASE_SQL_STATS WHERE SEEMLIKE_WEBMANAGER_NAME LIKE '%'+@WebManager_name+'%'
                                            --AND (SQL_MD5 NOT IN (SELECT DISTINCT Sql_Md5 FROM DataBase_Sql_My WITH (NOLOCK))  )
                                            AND (SQL_MD5 NOT IN (SELECT DISTINCT Sql_Md5 FROM DataBase_Sql_My_Ignore WITH (NOLOCK) WHERE WebManager_name = @WebManager_name)  )
                                            AND (SQL_MD5+CONVERT(VARCHAR(100), STATS_DATE, 23) NOT IN (SELECT SQL_MD5+CONVERT(VARCHAR(100), STATS_DATE, 23) FROM [DataBase_Sql_SendEmail] WITH (NOLOCK) WHERE WebManager_name = @WebManager_name )  )
                                            AND (total_worker_time/execution_count )/1000>" + max_duration.ToString() + @"*1000
                                            AND (SEEMLIKE_WEBMANAGER_NAME <> '' AND SEEMLIKE_WEBMANAGER_NAME IS NOT NULL)
											AND STATS_DATE > Dateadd(day,-7,CAST(@today AS DATETIME))   
                                            ORDER BY LAST_EXECUTION_TIME ASC
                                        END
                                    ELSE 
                                        BEGIN
	                                        SELECT TOP " + counts.ToString() + @" * FROM DATABASE_SQL_STATS  WITH(NOLOCK) WHERE 1=2
                                        END";
                        Entity.TEAMTOOL.DATABASE_SQL_STATS database_sql_stats = new Entity.TEAMTOOL.DATABASE_SQL_STATS();
                        DataTable oDt_database_sql_stats = admin_webmanager.Database_Reader.ExecuteDataSet(CommandType.Text, sql).Tables[0];
                        #endregion
                        if (oDt_database_sql_stats.Rows.Count > 0)
                        {
                            #region body
                            body += "<table id=\"messagelist\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr><th>SQL</th><th>操作</th></tr>";
                            int i = 0;
                            foreach (DataRow oDr_database_sql_stats in oDt_database_sql_stats.Rows)
                            {
                                string tr = @"<tr" + (i % 2 == 0 ? "" : " class=b") + "><td><p>" + oDr_database_sql_stats[database_sql_stats._TEXT_ANALYSIS].ToString().Replace("\r\n", "<br>").Replace("\t", "&nbsp;") +
                                    "</p><p><br />---------------------------------------------------------------------<br />(<b>" + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_ROWS].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString())).ToString() + @"行受影响</b>)
                                                                 <br />逻辑读取 " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_LOGICAL_READS].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString())).ToString("f0") + @" 次，物理读取 " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_PHYSICAL_READS].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString())).ToString("f0") + @" 次。
                                                                 <br />SQL Server 执行时间:
                                                                 <br />  CPU 时间 = " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_WORKER_TIME].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString()) / 1000).ToString("f0") + @" 毫秒。
                                                                 <br />SQL Server 执行时间:
                                                                  <br /> CPU 时间 = " + (Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._TOTAL_ELAPSED_TIME].ToString()) / Convert.ToDecimal(oDr_database_sql_stats[database_sql_stats._EXECUTION_COUNT].ToString()) / 1000).ToString("f0") + @" 毫秒。
                                                                  </p><p><br />----------------------------------<br />(<b>漏洞与问题</b>)<br><span class=red>" + oDr_database_sql_stats[database_sql_stats._SQL_ERROR].ToString() + @"</span>
                                                                  </p><p><br />----------------------------------<br />(<b>修改建议</b>)<br>1、尽量不要用LIKE模糊查询；<br>2、不要使用COUNT(*)，可以改成COUNT(1)，不然字段过多的话查询效率下降；<br>3、查询不能缺少WITH(NOLOCK)；<br>4、赋值请使用参数化，不然容易被攻击；<br>5、不要使用SELECT*，请写上明确的字段，不然字段过多的话查询效率下降；
                                                                  </p><p><br />----------------------------------<br /><b>执行时间：</b>" + oDr_database_sql_stats[database_sql_stats._LAST_EXECUTION_TIME].ToString() + "<br><b>数据库：</b>" + oDr_database_sql_stats[database_sql_stats._DATABASE_NAME].ToString() + "</p><br><br></td><td> <a href=\"" + Business.Config.HostUrl + "/Manager/Sql/DataBase_My_Sql_Add.aspx?Sql_Md5=" + Com.Common.EncDec.Encrypt(oDr_database_sql_stats[database_sql_stats._SQL_MD5].ToString(), "fang.com") + "\"" + @">认领</a><br/><a href=" + "\"" + Business.Config.HostUrl + "/Manager/Sql/DataBase_My_Sql_Ignore_Add.aspx?Sql_Md5=" + Com.Common.EncDec.Encrypt(oDr_database_sql_stats[database_sql_stats._SQL_MD5].ToString(), "fang.com") + "\"" + @">忽略</a></td>
                            </tr>";
                                int maxlength = 15000;
                                if (body.Length < maxlength)
                                {
                                    body += tr;
                                    i++;
                                }
                                else
                                {
                                    break;
                                }
                                if (body.Length > maxlength)
                                {
                                    if (i == 1)
                                    {
                                        string v = oDr_database_sql_stats[database_sql_stats._SQL_MD5].ToString() + "," + DateTime.Parse(oDr_database_sql_stats[database_sql_stats._STATS_DATE].ToString()).ToShortDateString() + "," + (i % 2 == 0 ? "0" : "1");
                                        string Image_PageUrl = Business.Config.HostUrl + "/Manager/Sql/DataBase_Sql_View.aspx?v=" + Com.Common.EncDec.Encrypt(v, "fang.com");
                                        body += @"<tr" + (i % 2 == 0 ? "" : " class=b") + "><td><img src=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_View_Image.aspx?pageurl=" + Com.Common.EncDec.Encrypt(Image_PageUrl, "fang.com") + "\" width=\"100%\"/></td><td> <a href=\"" + Business.Config.HostUrl + "/Manager/Sql/DataBase_My_Sql_Add.aspx?Sql_Md5=" + Com.Common.EncDec.Encrypt(oDr_database_sql_stats[database_sql_stats._SQL_MD5].ToString(), "fang.com") + "\"" + @">认领</a><br/><a href=" + "\"" + Business.Config.HostUrl + "/Manager/Sql/DataBase_My_Sql_Ignore_Add.aspx?Sql_Md5=" + Com.Common.EncDec.Encrypt(oDr_database_sql_stats[database_sql_stats._SQL_MD5].ToString(), "fang.com") + "\"" + @">忽略</a></td></tr>";
                                        break;
                                    }
                                    else if (i >= 2)
                                    {
                                        body = body.Replace(tr, "");
                                        i--;
                                        break;
                                    }
                                }
                            }
                            body += "</table></div></div></body></html>";
                            #endregion
                            #region sendemail
                            string MailUserList = admin_webmanager.WEBMANAGER_NAME + "@fang.com";
                            //MailUserList = "sogogo1@126.com";
                            Com.Mail.MailUtil mail = new Com.Mail.MailUtil();
                            mail.MailUserList = MailUserList;
                            mail.CopyToMailUserList = "lushijun@fang.com";
                            mail.MailTitle = "你的SQL执行较慢~[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                            mail.MailContent = body;
                            #endregion
                            if (!mail.SendOneMailByHTML())
                            {
                                Business.MallLog.Create(0, "Web.Report", "TeamTool发送:你的SQL执行较慢~邮件失败", "发送给" + admin_webmanager.WEBMANAGER_NAME + "失败", "127.0.0.1");
                            }
                            else
                            {
                                //mail.MailUserList = Com.Config.SystemConfig.MailUser;
                                //mail.SendOneMailByHTML();
                                #region  DATABASE_SQL_SENDEMAIL.Insert()
                                int k = 0;
                                foreach (DataRow oDr_database_sql_stats in oDt_database_sql_stats.Rows)
                                {
                                    Entity.TEAMTOOL.DATABASE_SQL_SENDEMAIL database_sql_sendemail = new Entity.TEAMTOOL.DATABASE_SQL_SENDEMAIL();
                                    database_sql_sendemail.WEBMANAGER_NAME = admin_webmanager.WEBMANAGER_NAME;
                                    database_sql_sendemail.SQL_MD5 = oDr_database_sql_stats[database_sql_sendemail._SQL_MD5].ToString();
                                    database_sql_sendemail.STATS_DATE = DateTime.Parse(oDr_database_sql_stats[database_sql_sendemail._STATS_DATE].ToString());
                                    database_sql_sendemail.CREATETIME = DateTime.Now;
                                    if (!database_sql_sendemail.Insert())
                                    {
                                        Business.MallLog.Create(0, "Web.Report", "TeamTool发送完你的SQL执行较慢~邮件后database_sql_sendemail.Insert()失败", "发送给" + admin_webmanager.WEBMANAGER_NAME + "失败", "127.0.0.1");
                                    }
                                    k++;
                                    if (k >= i)
                                    {
                                        break;
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
        }
    }
}
