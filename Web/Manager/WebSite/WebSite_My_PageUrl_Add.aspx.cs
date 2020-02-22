using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_My_PageUrl_Add : Business.ManageWeb
    {
        protected string P_PageUrl = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_My_PageUrl_Add.aspx");

            if (!Page.IsPostBack)
            {
                this.P_BackUrl = this.QueryString("BackUrl");
                if (string.IsNullOrEmpty(this.P_BackUrl))
                {
                    if (Request.UrlReferrer != null)
                    {
                        if (Request.UrlReferrer != null)
                        {
                            this.P_BackUrl = Request.UrlReferrer.ToString();
                        }
                        else
                        {
                            this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                        }
                    }
                    else
                    {
                        this.P_BackUrl = Business.Config.HostUrl + "/Manager/Welcome.aspx";
                    }

                }
                if (this.QueryString("PageUrl") != "")
                {
                    this.P_PageUrl = Com.Common.EncDec.Decrypt(this.QueryString("PageUrl"), this.Encrypt_key);
                    this.P_PageUrl = (this.P_PageUrl + "?").Split('?')[0];
                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("认领失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            string[] pageurls = this.P_PageUrl.Split('/');
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            website_my_pageurl.WEBMANAGER_NAME = this.CurrentWebManagerName;
            website_my_pageurl.PAGEURL = this.P_PageUrl;
            website_my_pageurl.PAGEURL_REGEX = this.P_PageUrl.Replace(pageurls[2], "(www.)?[a-z0-9\\.]+");//  http://(www.)?[a-z0-9\.]+/MallProjInfo_ChannelManage/ContractManageIndex.html 
            website_my_pageurl.CREATETIME = System.DateTime.Now;

            if (website_my_pageurl.Insert() == true)
            {
                //删除忽略的记录
                Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE website_my_pageurl_ignore = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL_IGNORE();
                website_my_pageurl_ignore.PAGEURL = this.P_PageUrl;
                website_my_pageurl_ignore.WEBMANAGER_NAME = this.CurrentWebManagerName;
                string error = "";
                if (website_my_pageurl_ignore.Delete() == false)
                {
                    error = "删除忽略记录失败！";
                }
                #region 删除首页缓存
                for (int i = 0; i <= 25; i++)
                {
                    Cache.Remove("Welcome_" + this.CurrentWebManagerName + "_" + i.ToString());
                }
                #endregion
                Cache.Remove("DataBase_Sql_List_LikeMine_dtLog");  
                #region 更新任务表Task
                Entity.TEAMTOOL.TASK task_update = new Entity.TEAMTOOL.TASK();
                task_update.TASK_PAGEURL_OR_SQL_MD5 = this.P_PageUrl;
                task_update.UpdateWhereSql = task_update._TASK_FINISHED + "=0 ";
                task_update.TASK_FINISHED = 1;
                task_update.TASK_FINISHED_TIME = DateTime.Now;
                task_update.TASK_WEBMANAGER_NAME_FINISHED = this.CurrentWebManagerName;
                task_update.Update();
                #endregion

                #region 更新表WebSite_PageUrl
                Business.PageUrlAnalysis.Match(this.P_PageUrl);
                #endregion

                this.RedirectConfirm("认领成功！" + error, this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("认领失败,可能您已认领此连接！", this.P_BackUrl);

            }
        }
    }
}