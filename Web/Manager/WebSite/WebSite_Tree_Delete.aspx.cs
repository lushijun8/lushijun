using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.WebSite
{
    public partial class WebSite_Tree_Delete : Business.ManageWeb
    {
        public string P_PageUrl = "";
        protected string P_BackUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/WebSite/WebSite_Tree_Delete.aspx");
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
                        this.P_BackUrl = Business.Config.HostUrl + "/Manager/WebSite/WebSite_Tree.aspx";
                    }
                }
                if (this.QueryString("PageUrl") != "")
                {
                    this.P_PageUrl = Com.Common.EncDec.Decrypt(this.QueryString("PageUrl"), this.Encrypt_key);
                    this.BindData();
                }
                else
                {
                    this.RedirectConfirm("删除失败，参数有误！", this.P_BackUrl);
                }
            }
        }
        private void BindData()
        {
            string Sql = @"delete  from WebSite_My_PageUrl where PageUrl like '" + this.P_PageUrl + @"%'
delete  from WebSite_My_PageUrl_Ignore where PageUrl like '" + this.P_PageUrl + @"%'
delete  from DataBase_Connect_Log_Stats where PageUrl like '" + this.P_PageUrl + @"%'
delete  from DataBase_Connect_Log where PageUrl like '" + this.P_PageUrl + @"%' 
delete  from task where Task_PageUrl_Or_Sql_Md5 like '" + this.P_PageUrl + @"%' 
delete  from Log_Stats where PageUrl like '" + this.P_PageUrl + @"%'
delete  from Log_Error where PageUrl like '" + this.P_PageUrl + @"%'";
            Entity.TEAMTOOL.WEBSITE_MY_PAGEURL website_my_pageurl = new Entity.TEAMTOOL.WEBSITE_MY_PAGEURL();
            int iResult = website_my_pageurl.Database_Writer.ExecuteNonQuery(CommandType.Text, Sql);
            if (iResult > 0)
            {
                #region 删除首页缓存
                for (int i = 0; i <= 25; i++)
                {
                    Cache.Remove("Welcome_" + this.CurrentWebManagerName + "_" + i.ToString());
                }
                #endregion
                this.RedirectConfirm("成功删除" + iResult + "条记录！", this.P_BackUrl);
            }
            else
            {
                this.RedirectConfirm("删除失败,可能您已删除此连接！", this.P_BackUrl);

            }
        }
    }
}