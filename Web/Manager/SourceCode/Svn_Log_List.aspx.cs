using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.SourceCode
{
    public partial class Svn_Log_List : Business.ManageWeb
    {
        public string html = "";
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/SourceCode/Svn_Log_List.aspx");

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
            int _PageSize = 60;
            this.LogCount = 0;

            Entity.TEAMTOOL.SVN_LOG svn_log = new Entity.TEAMTOOL.SVN_LOG();
            svn_log.SelectColumns = new string[] { "ADMIN_WEBMANAGER.WebManager_RealName", svn_log.TableName + ".*" };
            svn_log.OrderBy = svn_log._COMMIT_TIME + " DESC";
            svn_log.LEFT_JOIN_ADMIN_WEBMANAGER = true;
            if (!string.IsNullOrEmpty(this.txtKeyword.Text.Trim()))
            {
                svn_log.WhereSql = "(" + svn_log.TableName + "." + svn_log._WEBMANAGER_NAME + "='" + this.txtKeyword.Text + "' OR " +
                    "ADMIN_WEBMANAGER.WebManager_RealName='" + this.txtKeyword.Text + "' OR " +
                    svn_log._COMMIT_SERVER + " LIKE '%" + this.txtKeyword.Text + "%' OR " +
                    svn_log._COMMIT_FILE + " LIKE '%" + this.txtKeyword.Text + "%' OR " +
                    svn_log._COMMIT_MESSAGE + " LIKE '%" + this.txtKeyword.Text + "%' ";
                try
                {
                    int.Parse(this.txtKeyword.Text.Trim());
                    svn_log.WhereSql += " OR " + svn_log._REVISION + "='" + this.txtKeyword.Text + "'";
                }
                catch
                {
                }
                svn_log.WhereSql += ")";

            }
            DataTable oDt_svn_log = svn_log.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);

            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/SourceCode/Svn_Log_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //============================ 


            html += "<table class=\"svnlist\" width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\"><tr><th>提交人</th><th>提交人姓名</th><th>ID</th><th>提交时间</th><th>提交备注</th><th>修改类型</th><th>修改文件</th><th>SVN服务器</th></tr><tr>";
            DataRow oDr = oDt_svn_log.NewRow();
            foreach (DataRow oDr_svn_log in oDt_svn_log.Rows)
            {
                bool bsametd = true;
                if (oDr_svn_log[svn_log._WEBMANAGER_NAME].ToString() != oDr[svn_log._WEBMANAGER_NAME].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/SourceCode/Svn_Log_List.aspx?keyword=" + Server.UrlEncode(oDr_svn_log[svn_log._WEBMANAGER_NAME].ToString()) + "\">" + (bsametd == false ? oDr_svn_log[svn_log._WEBMANAGER_NAME].ToString() : "") + "</a></td>";
                if (oDr_svn_log["WEBMANAGER_REALNAME"].ToString() != oDr["WEBMANAGER_REALNAME"].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/SourceCode/Svn_Log_List.aspx?keyword=" + Server.UrlEncode(oDr_svn_log["WEBMANAGER_REALNAME"].ToString()) + "\">" + (bsametd == false ? oDr_svn_log["WEBMANAGER_REALNAME"].ToString() : "") + "</a></td>";

                if (oDr_svn_log[svn_log._REVISION].ToString() != oDr[svn_log._REVISION].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/SourceCode/Svn_Log_List.aspx?keyword=" + Server.UrlEncode(oDr_svn_log[svn_log._REVISION].ToString()) + "\">" + (bsametd == false ? oDr_svn_log[svn_log._REVISION].ToString() : "") + "</a></td>";
                if (oDr_svn_log[svn_log._COMMIT_TIME].ToString() != oDr[svn_log._COMMIT_TIME].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\">" + (bsametd == false ? oDr_svn_log[svn_log._COMMIT_TIME].ToString() : "") + "</td>";
                 

                if (oDr_svn_log[svn_log._COMMIT_MESSAGE].ToString() != oDr[svn_log._COMMIT_MESSAGE].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/SourceCode/Svn_Log_List.aspx?keyword=" + Server.UrlEncode(oDr_svn_log[svn_log._COMMIT_MESSAGE].ToString()) + "\">" + (bsametd == false ? oDr_svn_log[svn_log._COMMIT_MESSAGE].ToString() : "") + "</a></td>";
                if (oDr_svn_log[svn_log._COMMIT_TYPE].ToString() != oDr[svn_log._COMMIT_TYPE].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\">" + (oDr_svn_log[svn_log._COMMIT_TYPE].ToString() == "0" ? "Added" : "") + (oDr_svn_log[svn_log._COMMIT_TYPE].ToString() == "1" ? "Modified" : "") + (oDr_svn_log[svn_log._COMMIT_TYPE].ToString() == "2" ? "Deleted" : "") + (oDr_svn_log[svn_log._COMMIT_TYPE].ToString() == "3" ? "replacing" : "") + "</td>";
                if (oDr_svn_log[svn_log._COMMIT_FILE].ToString() != oDr[svn_log._COMMIT_FILE].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/SourceCode/Svn_Log_List.aspx?keyword=" + Server.UrlEncode(oDr_svn_log[svn_log._COMMIT_FILE].ToString()) + "\">" + (bsametd == false ? oDr_svn_log[svn_log._COMMIT_FILE].ToString() : "") + "</a></td>";
                if (oDr_svn_log[svn_log._COMMIT_SERVER].ToString() != oDr[svn_log._COMMIT_SERVER].ToString())
                {
                    bsametd = false;
                }
                html += "<td class=\"" + (bsametd == false ? "notsametd" : "sametd") + "\">" + (bsametd == false ? oDr_svn_log[svn_log._COMMIT_SERVER].ToString() : "") + "</td>";
                html += "</tr><tr>";
                oDr.ItemArray = oDr_svn_log.ItemArray;
            }
            html += "</tr></table>";
            html = html.Replace("<tr></tr>", "");
            #endregion
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
