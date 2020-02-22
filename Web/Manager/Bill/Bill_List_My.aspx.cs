using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Bill
{
    public partial class Bill_List_My : Business.ManageWeb
    {
        public string P_OrderBy = "";
        protected string outPage = "";
        public int P_page = 1;
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Bill/Bill_List_My.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "bill_Date desc";
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            #region 绑定列表
            int _PageSize = 20;
            this.LogCount = 0;
            Entity.TEAMTOOL.BILL bill = new Entity.TEAMTOOL.BILL();
            bill.BILL_WEBMANAGER_NAME = (this.QueryString("v") == "" ? this.CurrentWebManagerName : this.QueryString("v"));
            bill.Distinct = false;
            bill.OrderBy = this.P_OrderBy;
            DataTable oDt_bill = bill.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Bill/Bill_List_My.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_OrderBy);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //==================================================== 
            oDt_bill.Columns.Add(new DataColumn("bill_receive", typeof(int)));
            foreach (DataRow oDr in oDt_bill.Rows)
            {
                Entity.TEAMTOOL.BILL_RECEIVE bill_receive_select = new Entity.TEAMTOOL.BILL_RECEIVE();
                bill_receive_select.BILL_RECEIVE_YEAR = int.Parse(oDr[bill._BILL_YEAR].ToString());
                bill_receive_select.BILL_RECEIVE_MONTH = int.Parse(oDr[bill._BILL_MONTH].ToString());
                bill_receive_select.BILL_RECEIVE_LEADER_REALNAME = oDr[bill._BILL_LEADER_REALNAME].ToString();
                bill_receive_select.CacheTime = 600;
                if (bill_receive_select.SelectTop1() != null)
                {
                    oDr["bill_receive"] = "1";
                }
            }
            this.rptLog.DataSource = oDt_bill;
            this.rptLog.DataBind();
            #endregion

        }
    }
}
