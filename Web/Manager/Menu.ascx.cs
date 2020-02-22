using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager
{
    public partial class Menu : System.Web.UI.UserControl
    {
        public int bg_no = 0;
        public int fontsize = 9;
        public string msg_display = "none";
        public string msg = "";
        public string menu = "<div id=\"navbar\"><span id=\"menu\"></span> {CurrentWebTitle} ,浏览{View_Count}次<span class=\"right\"><img onclick=\"javascript:showmsg();\" src=\"" + Business.Config.HostUrl + "/images/msg.gif\"/>&nbsp;&nbsp;&nbsp;<a href=\"" + Business.Config.HostUrl + "/Manager/logout.aspx\"><font color=#ffffff>注销{CurrentWebManagerName}</font></a></span></div><ul class=\"menu off\">";
        public string Article_Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Cache["bg_no"] == null)
            //{
            //    Random rd = new Random();
            //    while (bg_no == 0)
            //    {
            //        bg_no = rd.Next(110);
            //    }
            //    Cache.Add("bg_no", bg_no.ToString(), null, System.DateTime.Now.Add(new TimeSpan(0, 16, 0)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            //}
            //else
            //{
            //    bg_no = int.Parse(Cache["bg_no"].ToString());
            //}

            Business.ManageWeb web = (Business.ManageWeb)this.Page;
            string function_url = web.AppRelativeVirtualPath.Replace("~/", "");
            string FunctionIds = web.CurrentGroupFunctionIds;
            string Cachekey = "Manage_Index_Menu_" + web.CurrentWebManagerGroupId + "_" + function_url.Trim() + "_" + web.CurrentWebManagerId;
            if (Cache[Cachekey] != null)
            {
                menu = (string)Cache[Cachekey];
            }
            else
            {
                Entity.TEAMTOOL.ADMIN_FUNCTION admin_function = new Entity.TEAMTOOL.ADMIN_FUNCTION();
                admin_function.CacheTime = 30;
                admin_function.SelectColumns = new string[] { "Module_name", admin_function._FUNCTION_URL, admin_function._FUNCTION_NAME, admin_function._FUNCTION_MODULE_ID, admin_function._FUNCTION_VIEW_COUNT, admin_function._FUNCTION_TYPE };
                admin_function.Distinct = true;
                //admin_function.FUNCTION_TYPE = 1;
                admin_function.INNER_JOIN_ADMIN_MODULE = true;
                admin_function.WhereSql = admin_function._FUNCTION_ID + " IN (" + FunctionIds + ")";
                admin_function.OrderBy = "Module_Order,ADMIN_FUNCTION." + admin_function._FUNCTION_ORDER + " ASC";
                DataTable oDt_admin_function = admin_function.Select();
                string Module = "";
                string module_id = "";
                DataView oDv_admin_function = oDt_admin_function.DefaultView;
                oDv_admin_function.RowFilter = admin_function._FUNCTION_TYPE + "=1";
                foreach (DataRowView oDv in oDv_admin_function)
                {
                    DataRow oDr = oDv.Row;

                    bool bCurrentModule = false;
                    bool bCurrentUrl = false;
                    if (function_url.ToUpper() == oDr[admin_function._FUNCTION_URL].ToString().ToUpper())
                    {
                        bCurrentUrl = true;
                    }
                    DataRow[] oDrs = oDt_admin_function.Select(admin_function._FUNCTION_URL + "='" + function_url + "' and " + admin_function._FUNCTION_TYPE + "=1");

                    if (oDrs != null && oDrs.Length > 0 && oDr[admin_function._FUNCTION_MODULE_ID].ToString() == oDrs[0][admin_function._FUNCTION_MODULE_ID].ToString())
                    {
                        bCurrentModule = true;
                    }
                    if (oDr[admin_function._FUNCTION_MODULE_ID].ToString() != module_id)
                    {
                        menu += "</ul><ul class=\"menu " + (bCurrentModule == true ? "off" : "off") + "\" id=\"module_" + oDr[admin_function._FUNCTION_MODULE_ID].ToString() + "_menu\">";
                        //Module += "<li class=\"" + (bCurrentModule == true ? "off" : "off") + "\" id=\"module_" + oDr[admin_function._FUNCTION_MODULE_ID].ToString() + "\"><a href=\"" + Business.Config.HostUrl + "/" + oDr[admin_function._FUNCTION_URL].ToString() + "\">" + oDr["Module_name"].ToString() + "</a></li>";
                        Module += "<li class=\"" + (bCurrentModule == true ? "off" : "off") + "\" id=\"module_" + oDr[admin_function._FUNCTION_MODULE_ID].ToString() + "\">" + oDr["Module_name"].ToString() + "</li>";
                    }
                    menu += "<li><a href=\"" + Business.Config.HostUrl + "/" + oDr[admin_function._FUNCTION_URL].ToString() + "\"" + (bCurrentUrl == true ? " class=\"red\"" : "") + ">" + oDr[admin_function._FUNCTION_NAME].ToString() + "</a></li>";
                    module_id = oDr[admin_function._FUNCTION_MODULE_ID].ToString();
                }
                menu += "</ul>";
                string url = Business.Config.HostUrl + "/Manager/Admin/AutoLogin.aspx?v=" + Com.Common.EncDec.Base64Encrypt(web.CurrentWebManagerId + "," + System.DateTime.Now.AddMinutes(30).ToString());
                menu = "<ul id=\"module\">" + Module + "<li class=\"menu off\"><a target=\"_blank\" href=\"" + Business.Config.HostUrl + "/Manager/Login_Qrcode.aspx?url=" + Server.UrlEncode(url) + "\"><img id=\"qrcode\" src=\"" + Business.Config.HostUrl + "/Manager/Login_Qrcode.aspx?url=" + Server.UrlEncode(url) + "\" height=\"63\" width=\"63\"></a></li></ul>" + menu;


                string View_Count = "0";
                DataRow[] oDrs_view_count = oDt_admin_function.Select(admin_function._FUNCTION_URL + "='" + function_url + "'");
                if (oDrs_view_count != null && oDrs_view_count.Length > 0)
                {
                    View_Count = oDrs_view_count[0][admin_function._FUNCTION_VIEW_COUNT].ToString();
                }
                menu = menu.Replace("{CurrentWebTitle}", web.FunctionName);
                menu = menu.Replace("{View_Count}", View_Count);
                menu = menu.Replace("{CurrentWebManagerName}", web.CurrentWebManagerName);
                Cache.Add(Cachekey, menu, null, System.DateTime.Now.Add(new TimeSpan(0, 0, 30 * 60)), System.TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            #region 判断是否显示消息
            Entity.TEAMTOOL.SHARE_VIEW share_view = new Entity.TEAMTOOL.SHARE_VIEW();
            share_view.SelectColumns = new string[] { "ARTICLE_TEXT", "ARTICLE_ID", share_view._VIEW_BG_NO };
            share_view.VIEW_TIME = DateTime.Parse(System.DateTime.Now.ToShortDateString());
            share_view.VIEW_WEBMANAGER_NAME = web.CurrentWebManagerName;
            share_view.Distinct = false;
            share_view.INNER_JOIN_SHARE_ARTICLE = true;
            share_view.CacheTime = 720;
            DataRow oDr_share_view = share_view.SelectTop1();
            if (oDr_share_view == null)
            {
                Entity.TEAMTOOL.SHARE_ARTICLE share_article = new Entity.TEAMTOOL.SHARE_ARTICLE();
                share_article.OrderBy = "NEWID()";
                share_article.WhereSql = "([Article_id] not in (select [View_Article_Id] as [Article_id] from [Share_View] where [View_WebManager_name]='" + web.CurrentWebManagerName + "'))";
                share_article.ARTICLE_TYPE = 0;
                share_article.SelectTop1();
                if (share_article.Items.Count > 0 && string.IsNullOrEmpty(web.QueryString("WebManager_Name")))
                {
                    Entity.TEAMTOOL.SHARE_VIEW share_view_select = new Entity.TEAMTOOL.SHARE_VIEW();
                    share_view_select.VIEW_WEBMANAGER_NAME = web.CurrentWebManagerName;
                    share_view_select.Distinct = true;
                    share_view_select.SelectColumns = new string[] { share_view_select._VIEW_BG_NO };
                    DataTable oDt_Share_view = share_view_select.Select();
                    //--------------------------------------------------------------
                    int bg_count = 283;
                    Random rd = new Random();
                    if (oDt_Share_view.Rows.Count >= bg_count)
                    {
                        this.bg_no = rd.Next(bg_count);
                    }
                    else
                    {
                        while (this.bg_no == 0 || oDt_Share_view.Select(share_view_select._VIEW_BG_NO + "=" + this.bg_no.ToString()).Length > 0)
                        {
                            this.bg_no = rd.Next(bg_count);
                        }
                    }
                    Entity.TEAMTOOL.SHARE_VIEW share_view_insert = new Entity.TEAMTOOL.SHARE_VIEW();
                    share_view_insert.VIEW_ARTICLE_ID = int.Parse(share_article.ARTICLE_ID_ToString);
                    share_view_insert.VIEW_WEBMANAGER_NAME = web.CurrentWebManagerName;
                    share_view_insert.VIEW_TIME = DateTime.Parse(System.DateTime.Now.ToShortDateString());
                    share_view_insert.VIEW_BG_NO = this.bg_no;
                    share_view_insert.Insert();
                    this.msg = share_article.ARTICLE_TEXT;
                    this.Article_Id = share_article.ARTICLE_ID_ToString;
                }
            }
            else
            {
                this.msg = oDr_share_view["ARTICLE_TEXT"].ToString();
                this.Article_Id = oDr_share_view["ARTICLE_ID"].ToString();
                this.bg_no = int.Parse(oDr_share_view["View_Bg_No"].ToString());
            }
            if (!string.IsNullOrEmpty(this.msg))
            {
                this.fontsize = 2500 / Com.Net.HtmlUtil.GetPlainText(this.msg).Length;
            }
            if (fontsize < 9)
            {
                fontsize = 9;
            }
            if (fontsize > 32)
            {
                fontsize = 32;
            }
            string cookie_name = "showmsg" + System.DateTime.Now.ToString("yyyyMMdd");
            string Cookie_showmsg = web.Cookie(cookie_name);
            if (string.IsNullOrEmpty(Cookie_showmsg))
            {
                //展示
                web.setCookies(cookie_name, "1", System.DateTime.Now.AddHours(24));
                msg_display = "block";
            }
            else
            {
                msg_display = "none";
            }

            #endregion
        }
    }
}