using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Admin
{
    public partial class UserList : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_keyword = "";
        public string P_product = "";
        public int AllCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Admin/UserList.aspx");
            if (!Page.IsPostBack)
            {
                Entity.TEAMTOOL.ADMIN_PRODUCT pay_product = new Entity.TEAMTOOL.ADMIN_PRODUCT();
                //pay_product.SelectColumns = new string[] { pay_product._PRODUCTID, pay_product._PRODUCTNAME };
                if (!string.IsNullOrEmpty(this.CurrentWebManagerProduct))
                {
                    pay_product.Split_Or_And = true;
                    pay_product[pay_product._PRODUCTID] = this.CurrentWebManagerProduct;
                }
                else
                {
                    pay_product.PRODUCTID = -100;
                }
                pay_product.Distinct = true;
                pay_product.CacheTime = 30;
                DataTable oDt = pay_product.Select();
                this.ddlProduct.DataSource = oDt;
                this.ddlProduct.DataValueField = pay_product._PRODUCTID;
                this.ddlProduct.DataTextField = pay_product._PRODUCTNAME;
                this.ddlProduct.DataBind();

                string ItemValue="";
                foreach(DataRow oDr in oDt.Rows)
                {
                    ItemValue += oDr[pay_product._PRODUCTID].ToString() + "|";
                }
                ItemValue = ItemValue.TrimEnd('|');
                this.ddlProduct.Items.Add(new ListItem("-请选择-", ItemValue));
                this.ddlProduct.SelectedValue = ItemValue;

                if (QueryString("page") != "")
                    this.P_page = int.Parse(QueryString("page"));
                if (QueryString("product") != "")
                    this.P_product = QueryString("product");
                this.P_keyword = QueryString("keyword");

                this.ddlProduct.SelectedValue = this.P_product.ToString();
                this.txtKeyword.Text = this.P_keyword;
                this.BindData();
            }
        }
        private void BindData()
        {
            if (this.ddlProduct.Items == null || this.ddlProduct.Items.Count == 0)
            {
                return;
            }
            #region 绑定列表
            this.P_product = this.ddlProduct.SelectedItem.Value;
            int _PageSize = 20;  
            //列表 
            Entity.TEAMTOOL.ADMIN_WEBMANAGER admin_webmanager = new Entity.TEAMTOOL.ADMIN_WEBMANAGER();
            admin_webmanager.SelectColumns = new string[] { "ADMIN_WEBMANAGER.*", "Group_name"};
            admin_webmanager.INNER_JOIN_ADMIN_WEBMANAGER_GROUP = true;
            admin_webmanager.Split_Or_And = true;
            admin_webmanager.WEBMANAGER_PRODUCT = this.P_product;// "%" + this.P_product.ToString() + "%";
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " and (" + admin_webmanager._WEBMANAGER_NAME + " LIKE '%" + this.txtKeyword.Text + "%' OR " + admin_webmanager._WEBMANAGER_MOBILE + " LIKE '%" + this.txtKeyword.Text + "%' OR " + admin_webmanager._WEBMANAGER_EMAIL + " LIKE '%" + this.txtKeyword.Text + "%' ) ";
            }
            admin_webmanager.WhereSql = wheresql;
            admin_webmanager.OrderBy = admin_webmanager._WEBMANAGER_LAST_LOGINTIME+" DESC";

            DataTable dtAdmin_WebManager = admin_webmanager.SelectByPaging(_PageSize, this.P_page - 1, out AllCount);
            //=====================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.Url = Business.Config.HostUrl + "/Manager/Admin/Userlist.aspx?page={page}&product=" + this.ddlProduct.SelectedItem.Value + "&keyword=" + Server.UrlEncode(this.txtKeyword.Text);
            page.ModelCount = this.AllCount;
            if (this.AllCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page(); 
            this.rptAdmin_WebManager.DataSource = dtAdmin_WebManager;
            this.rptAdmin_WebManager.DataBind();
            #endregion

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            this.BindData();
        }
    }
}