using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Log
{
    public partial class Log_Error_List : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Log/Log_Error_List.aspx");
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                    this.P_page = int.Parse(QueryString("page"));

                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;

                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 20;
            this.LogCount = 0;

            Entity.TEAMTOOL.LOG_ERROR log_error = new Entity.TEAMTOOL.LOG_ERROR();
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " and (" +
                    log_error.TableName + "." + log_error._IP + " = '" + this.txtKeyword.Text + "' or " +
                    log_error.TableName + "." + log_error._USERNAME + " like '%" + this.txtKeyword.Text + "%'  or " +
                    log_error.TableName + "." + log_error._SERVERNAME + " like '%" + this.txtKeyword.Text + "%' or " +
                    log_error.TableName + "." + log_error._PAGEURL + " like '%" + this.txtKeyword.Text + "%' or " +
                    log_error.TableName + "." + log_error._CONTENT + " like '%" + this.txtKeyword.Text + "%' or " +
                    log_error.TableName + "." + log_error._REMARKS + " like '%" + this.txtKeyword.Text + "%' or " +
                    log_error.TableName + "." + log_error._TEAMNAME + " like '%" + this.txtKeyword.Text + "%' or " +
                    log_error.TableName + "." + log_error._TITLE + " like '%" + this.txtKeyword.Text + "%') ";
            }

            log_error.LEFT_JOIN_WEBSITE_PAGEURL = true;
            log_error.SelectColumns = new string[] {
                log_error.TableName+".*",
                "website_pageurl.ErrorInfo",
                "website_pageurl.ErrorTime",
                "website_pageurl.Depend_PageUrl",
                "website_pageurl.Depend_PageUrl_Out",
                "website_pageurl.form_Phone_Encrypt",
                "website_pageurl.querystring_Phone_Encrypt",
                "website_pageurl.querystring",
                "website_pageurl.form",
                "website_pageurl.webmanager_realname_depend",
                "website_pageurl.webmanager_realname_like",
                "website_pageurl.webmanager_realname",
                "website_pageurl.webmanager_name"
            };


            log_error.WhereSql = wheresql;
            log_error.OrderBy = log_error._ID + " DESC ";
            log_error.CacheTime = 10;
            DataTable dtLog = log_error.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //--------------------------------------------------------
            dtLog.Columns.Add(new DataColumn("Server_Ip", typeof(string)));
            dtLog.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr_Error in dtLog.Rows)
            {
                string Server_Ip = "";
                Regex reg_ip = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                MatchCollection matchs_ip = reg_ip.Matches(oDr_Error["Remarks"].ToString(), 0);
                foreach (Match match in matchs_ip)
                {
                    if (!match.Value.StartsWith("192."))
                    {
                        Server_Ip += match.Value + "<br>";
                    }
                }
                oDr_Error["Server_Ip"] = Server_Ip;
                int IsMy = 0;
                if (oDr_Error["WebManager_Name"].ToString().IndexOf(this.CurrentWebManagerName) > -1)
                {
                    IsMy = 1;
                }
                oDr_Error["IsMy"] = IsMy;
            }
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Log/Log_Error_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            //Web.Manager.Welcome.get_Depend(dtLog);//外部依赖
            this.rptLog.DataSource = dtLog;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
