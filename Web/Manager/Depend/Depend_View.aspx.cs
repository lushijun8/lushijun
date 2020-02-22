using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Depend
{
    public partial class Depend_View : Business.ManageWeb
    {
        private string P_Depend_PageUrl = "";
        private string P_Stats_Date = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Depend/Depend_View.aspx");

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.QueryString("v")))
                {
                    string[] v = Com.Common.EncDec.Decrypt(this.QueryString("v"), this.Encrypt_key).Split(',');
                    this.P_Depend_PageUrl = v[0];
                    this.P_Stats_Date = v[1];
                    this.BindData();
                }
            }
        }
        private void BindData()
        {
            #region 绑定列表

            Entity.TEAMTOOL.WEBSITE_DEPEND website_depend = new Entity.TEAMTOOL.WEBSITE_DEPEND();
            website_depend.SelectColumns = new string[] {"MAX(" + website_depend._DEPEND_CONTENT + ") AS " + website_depend._DEPEND_CONTENT + "",
                "MAX(" + website_depend._DEPEND_CONTENTTYPE + ") AS " + website_depend._DEPEND_CONTENTTYPE + ""};
            website_depend.DEPEND_PAGEURL = this.P_Depend_PageUrl;
            website_depend.STATS_DATE = DateTime.Parse(this.P_Stats_Date);
            if (website_depend.SelectTop1() != null)
            {
                Response.ContentType = website_depend.DEPEND_CONTENTTYPE;
                Response.Write(website_depend.DEPEND_CONTENT);

            }
            else
            {
                Entity.TEAMTOOL.WEBSITE_DEPEND website_depend1 = new Entity.TEAMTOOL.WEBSITE_DEPEND();
                website_depend1.SelectColumns = new string[] {"MAX(" + website_depend1._DEPEND_CONTENT + ") AS " + website_depend1._DEPEND_CONTENT + "",
                "MAX(" + website_depend._DEPEND_CONTENTTYPE + ") AS " + website_depend._DEPEND_CONTENTTYPE + ""};
                website_depend1.DEPEND_PAGEURL = this.P_Depend_PageUrl;
                if (website_depend1.SelectTop1() != null)
                {
                    Response.ContentType = website_depend1.DEPEND_CONTENTTYPE;
                    Response.Write(website_depend1.DEPEND_CONTENT);

                }
            }

            #endregion

        }

    }
}
