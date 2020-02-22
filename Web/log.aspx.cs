using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Threading;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Web
{
    public partial class log : Com.Web.WebUI
    {
        private string P_PARAMS = "";
        private string P_IP = "";
        private string P_WEBSITE = "";
        private string P_PASSWORD = "";

        private delegate void AsyncDelegate();
        protected void Page_Load(object sender, EventArgs e)
        {
            //发送分享邀请邮件
            AsyncDelegate caller = new AsyncDelegate(SendShareEmail);
            caller.BeginInvoke(null, caller);

            this.P_PARAMS = this.QueryString("p");
            if (string.IsNullOrEmpty(this.P_PARAMS))
            {
                return;
            }

            string[] Params = this.P_PARAMS.Split(',');
            this.P_IP = Params[0];
            if (Params.Length >= 2)
            {
                this.P_WEBSITE = Params[1];
            } 
            if (Params.Length >= 3)
            {
                this.P_PASSWORD = Params[2];
            }
            Entity.TEAMTOOL.SERVER_UPDATE_LOG server_update_log = new Entity.TEAMTOOL.SERVER_UPDATE_LOG();
            server_update_log.IP = this.P_IP;
            server_update_log.SERVERNAME = this.P_WEBSITE;
            server_update_log.Insert();

            if (!string.IsNullOrEmpty(this.P_PASSWORD))
            {
                Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD server_update_password = new Entity.TEAMTOOL.SERVER_UPDATE_PASSWORD();
                server_update_password.CREATE_IP = this.P_IP;
                server_update_password.CREATE_PASSWORD = Com.Common.EncDec.Encrypt(this.P_PASSWORD, "fang.com");
                server_update_password.CREATE_TIME = System.DateTime.Now;
                server_update_password.SERVERNAME = this.P_WEBSITE;
                server_update_password.Insert();
            }

        }
        private void SendShareEmail()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return;
            }
            if (System.DateTime.Now.Hour >= 7 && System.DateTime.Now.Hour <= 14)
            {
                int top = 10;
                #region 查出pageurl
                Entity.TEAMTOOL.TASK task = new Entity.TEAMTOOL.TASK();
                DataTable oDt_task = task.Database_Reader.ExecuteDataSet(CommandType.Text, @"                     
                                    declare @counts int 
                                    select @counts=count(DISTINCT Task_PageUrl_Or_Sql_Md5) from task where task_date 
                                    IN (CONVERT(VARCHAR(100), GETDATE(), 23)) 
                                    if(@counts<3*" + top.ToString() + @")
                                        begin
                                            SELECT DISTINCT TOP " + top.ToString() + @"
	                                            pageurl
                                            FROM (SELECT
	                                            pageurl
                                            FROM DataBase_Connect_Log_Stats
                                            WHERE connect_date IN
                                            (CONVERT(VARCHAR(100), GETDATE(), 23), CONVERT(VARCHAR(100), DATEADD(DAY, -1, GETDATE()), 23)) UNION SELECT
	                                            pageurl
                                            FROM Log_Stats
                                            WHERE log_date IN
                                            (CONVERT(VARCHAR(100), GETDATE(), 23), CONVERT(VARCHAR(100), DATEADD(DAY, -1, GETDATE()), 23)) UNION
											SELECT 
	                                            pageurl
                                            FROM WebSite_Depend
                                            WHERE Stats_Date IN
                                            (CONVERT(VARCHAR(100), GETDATE(), 23), CONVERT(VARCHAR(100), DATEADD(DAY, -1, GETDATE()), 23)) ) c
                                            WHERE pageurl NOT IN (SELECT
	                                            pageurl
                                            FROM WebSite_My_PageUrl)
                                            AND pageurl NOT IN (SELECT
	                                            Task_PageUrl_Or_Sql_Md5 AS pageurl
                                            FROM Task
                                            WHERE task_type = 0)
                                            AND pageurl NOT LIKE '%ecorder.%'
                                            AND pageurl NOT LIKE '%localhost%'
                                            ORDER BY pageurl
                                        end
                                    else
                                        begin
                                            select 1 
                                        end").Tables[0];
                #endregion
                if (oDt_task.Rows.Count >= top)
                {
                    #region 发任务
                    DataTable oDt_WebManager_Name = task.Database_Reader.ExecuteDataSet(CommandType.Text, @"
                                    select top 1 WebManager_name,WebManager_realname,count(Task_PageUrl_Or_Sql_Md5) as counts 
                                    from Admin_WebManager 
                                    left join task
                                    on task.task_webmanager_name=Admin_WebManager.WebManager_name
                                    group by WebManager_name,WebManager_realname
                                    order by counts asc,newid()").Tables[0];

                    string WebManager_Name = oDt_WebManager_Name.Rows[0]["WebManager_name"].ToString();//"lushijun";
                    string WebManager_RealName = oDt_WebManager_Name.Rows[0]["WebManager_realname"].ToString();
                    string MailContent = "";
                    int i = 1;
                    foreach (DataRow oDr in oDt_task.Rows)
                    {
                        Entity.TEAMTOOL.TASK task_insert = new Entity.TEAMTOOL.TASK();
                        task_insert.TASK_PAGEURL_OR_SQL_MD5 = oDr["pageurl"].ToString();
                        task_insert.TASK_DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
                        task_insert.TASK_WEBMANAGER_NAME = WebManager_Name;
                        task_insert.TASK_TYPE = 0;
                        task_insert.TASK_FINISHED = 0;
                        task_insert.TASK_CREATETIME = DateTime.Now;
                        task_insert.TASK_REMARK = oDr["pageurl"].ToString() + "，找出此URL负责人，并让TA认领";
                        if (task_insert.Insert() == true)
                        {
                            MailContent += i.ToString().PadLeft(2, '0') + "、" + oDr["pageurl"].ToString() + "  &nbsp;&nbsp;&nbsp;--- <a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl=" + Com.Common.EncDec.Encrypt(oDr["pageurl"].ToString(), "fang.com") + "&BackUrl=" + Server.UrlEncode(Business.Config.HostUrl + "/Manager/Welcome.aspx") + "\">认领</a><br/>";
                        }
                        i++;
                    }
                    if (!string.IsNullOrEmpty(MailContent))
                    {
                        #region 发邮件
                        Com.Mail.MailUtil mail0 = new Com.Mail.MailUtil();
                        mail0.MailUserList = WebManager_Name + "@fang.com";
                        mail0.CopyToMailUserList = "lushijun@fang.com";
                        mail0.MailTitle = "你有未完成的任务~[系统邮件请勿回复," + System.DateTime.Now.ToString() + "]";
                        mail0.MailContent = "Hi!!&nbsp;&nbsp;" + WebManager_RealName + " 同学.<br/><br/>" +
                            "&nbsp;&nbsp;你的任务是找出以下URL的负责人，并且让TA们到<a href=\"" + Business.Config.HostUrl + "/Manager/WebSite/WebSite_PageUrl.aspx\">TeamTool->所有页面</a>里认领：<br/><br/>" +
                            MailContent + "<a href=\"" + Business.Config.HostUrl + "/Manager/Task/Task_List_My.aspx\">查看所有任务</a><br/>" +
                            "<br/>" +
                            "任务攻略：<br/><br/>" +
                            "01、把此邮件转发给大团队所有人，然后留言“这些URL是谁的？帮忙认领一下”（<font color=red>拼人品，不推荐</font>）。<br/>" +
                            "02、把这些URL发到大团队QQ群里，问问看是谁的，如果有人回答你，赶紧去找TA面对面沟通，<br>" +
                            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;然后迅速跟TA成为朋友，把此邮件转发给TA,让TA去认领一下（<font color=red>还是拼人品，拼颜值</font>）。<br/>" +
                            "03、打开Visual Studio,找到该URL所在解决方案，如果本地没有可以从SVN上Check Out一份；<br>" +
                            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;然后根据URL名字查找到该代码文件，在文件上点击右键->VisualSVN->Show Log看看历史有谁更新了这个文件，<br>" +
                            "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;然后逐个面对面沟通，跟TA们成为朋友，问问TA们这个页面大概功能，确定负责人，然后让TA认领（<font color=red>技术活，成功率高</font>）。<br/>" +
                            "04、发动大团队里所有你认识的好朋友帮你做以上工作（<font color=red>拼智商，拼人品，推荐</font>）。<br/>" +
                            "05、你也可以自己认领这些URL，自己对它们负责(<font color=red>后果自负，呵呵~</font>)。<br>" +
                            //"06、你还可以忽略此邮件（<font color=red>还是后果自负，呵呵~</font>）。<br/>" +
                            "<br/>怎么样，看起来很简单吧！速度行动吧，该是你人品爆发的时候了。。。<br/><br/>附图<br/><br/><img src=\"" + Business.Config.HostUrl + "/images/task01.png\" /><br/><br/><img src=\"" + Business.Config.HostUrl + "/images/task02.png\" /><br/><br/>";
                        if (!mail0.SendOneMailByHTML())
                        {
                            Business.MallLog.Create(0, "Share", "TeamTool发送:你有未完成的任务~邮件失败", "发送给" + WebManager_Name + "失败", Request.UserHostAddress);
                        }
                        else
                        {
                            //mail0.MailUserList = Com.Config.SystemConfig.MailUser;
                            //mail0.SendOneMailByHTML();
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            if (System.DateTime.Now.Hour >= 7 && System.DateTime.Now.Hour <= 14)
            {
                #region 发分享邀请
                /*
                Entity.TEAMTOOL.SHARE_INVITE share_invite = new Entity.TEAMTOOL.SHARE_INVITE();
                share_invite.INVITE_DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
                if (share_invite.SelectTop1() == null)//还没发邀请
                {
                    //发送分享邀请邮件
                    Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
                    DataTable oDt = admin_webmanager.Database_Reader.ExecuteDataSet(CommandType.Text, @"select top 1  WebManager_name,WebManager_realname,count(Article_id) as counts from 
Admin_WebManager left join 
Share_Article 
on Share_Article.Article_Share_WebManager_name=Admin_WebManager.WebManager_name 
and Article_type=1
group by WebManager_name,WebManager_realname
order by counts asc,newid()").Tables[0];
                    string v = Com.Common.EncDec.Encrypt(oDt.Rows[0]["WebManager_name"].ToString() + "|" + DateTime.Now.ToShortDateString(), "fang.com");
                    Com.Mail.MailUtil mail0 = new Com.Mail.MailUtil();
                    mail0.MailUserList = oDt.Rows[0]["WebManager_name"].ToString() + "@fang.com";
                    mail0.MailTitle = oDt.Rows[0]["WebManager_realname"].ToString() + ",今天轮到你给大家分享了~[系统邮件请勿回复]";
                    mail0.MailContent = "Hi!!&nbsp;" + oDt.Rows[0]["WebManager_realname"].ToString() + " 同学.<br/><br/>" +
                        "&nbsp;&nbsp;今天轮到你给大家分享了,分享内容可以是任意形式，比如：<br/><br/>" +
                        "1、一篇你觉得对大家有用的技术文章;<br/>" +
                        "2、一个你自己经历过而且觉得对大家有启发意义的个人经验;<br/>" +
                        "3、一个对大家有启发的,能拯救世界的小故事^_^;<br/>" +
                        "4、一组自己亲自拍摄的能反映当地风土人情的旅行图片（自己家乡的更好哦）;<br/>" +
                        "5、一段超级搞笑的,让人笑掉大牙的小段子：) ;<br/>" +
                        "6、一篇自己写过的论文或者宇宙无敌的技术干货;<br/>" +
                        "7、一组过眼不忘的搞笑图片;<br/>" +
                        "8、一篇美文;<br/><br/>" +
                        "等等.......<br/><br/>速度晒出你的干货吧：<a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_Add.aspx?v=" + v + "\">点击此处立即分享</a>;<br/><br/>大家都期待着呢~我们会给你点赞的！" +
                        "<br/><br/><a href=\"" + Business.Config.HostUrl + "/Manager/Share/Share_Article_List.aspx\">看看大家都分享了什么？</a>";
                    if (!mail0.SendOneMailByHTML())
                    {
                        Business.MallLog.Create(0, "Share", "TeamTool发送分享邀请失败", "发送给" + oDt.Rows[0]["WebManager_name"].ToString() + "失败", Request.UserHostAddress);
                    }
                    else
                    {
                        Entity.TEAMTOOL.SHARE_INVITE share_invite_insert = new Entity.TEAMTOOL.SHARE_INVITE();
                        share_invite_insert.INVITE_DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
                        share_invite_insert.INVITE_WEBMANAGER_NAME = oDt.Rows[0]["WebManager_name"].ToString();
                        share_invite_insert.Insert();
                        //=================================
                        //mail0.MailUserList = Com.Config.SystemConfig.MailUser;
                        //mail0.SendOneMailByHTML();
                        //=================================
                        Entity.TEAMTOOL.TASK task_insert = new Entity.TEAMTOOL.TASK();
                        task_insert.TASK_PAGEURL_OR_SQL_MD5 = oDt.Rows[0]["WebManager_name"].ToString() + "," + DateTime.Now.ToString("yyyyMMdd") + ",share";
                        task_insert.TASK_DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
                        task_insert.TASK_WEBMANAGER_NAME = oDt.Rows[0]["WebManager_name"].ToString();
                        task_insert.TASK_TYPE = 2;
                        task_insert.TASK_FINISHED = 0;
                        task_insert.TASK_CREATETIME = DateTime.Now;
                        task_insert.TASK_REMARK = "给大家分享，分享内容可以是任意形式，比如：1、一篇你觉得对大家有用的技术文章;2、一个你自己经历过而且觉得对大家有启发意义的个人经验;3、一个对大家有启发的,能拯救世界的小故事^_^;4、一组自己亲自拍摄的能反映当地风土人情的旅行图片（自己家乡的更好哦）;5、一段超级搞笑的,让人笑掉大牙的小段子：) ;6、一篇自己写过的论文或者宇宙无敌的技术干货;7、一组过眼不忘的搞笑图片;8、一篇美文;";
                        task_insert.Insert();
                    }
                }*/
                #endregion
            }
        }

    }
}