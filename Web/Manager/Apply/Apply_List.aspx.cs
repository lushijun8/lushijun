using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Apply
{
    public partial class Apply_List : Business.ManageWeb
    {
        public string P_OrderBy = "";
        protected string outPage = "";
        public int P_page = 1;
        public int LogCount = 0;
        public int Apply_Pen = 0;
        public int Apply_PenLead = 0;
        public int Apply_Book = 0;
        public int Apply_Glue = 0;
        public int Apply_NotePaper = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Apply/Apply_List.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "Apply_CreateTime desc";
            }
            if (!Page.IsPostBack)
            {
                if (QueryString("page") != "")
                {
                    this.P_page = int.Parse(QueryString("page"));
                }
                Entity.TEAMTOOL.APPLY apply_year = new Entity.TEAMTOOL.APPLY();
                apply_year.SelectColumns = new string[] { apply_year._APPLY_YEAR };
                apply_year.CacheTime = 30;
                apply_year.Distinct = true;
                apply_year.OrderBy = apply_year._APPLY_YEAR + " desc";
                DataTable oDt_apply_year = apply_year.Select();
                this.ddl_apply_year.DataSource = oDt_apply_year;
                this.ddl_apply_year.DataTextField = apply_year._APPLY_YEAR;
                this.ddl_apply_year.DataValueField = apply_year._APPLY_YEAR;
                this.ddl_apply_year.DataBind();
                //--------------------------------------------
                Entity.TEAMTOOL.APPLY apply_month = new Entity.TEAMTOOL.APPLY();
                apply_month.SelectColumns = new string[] { apply_month._APPLY_MONTH };
                apply_month.CacheTime = 30;
                apply_month.Distinct = true;
                apply_month.OrderBy = apply_month._APPLY_MONTH + " desc";
                DataTable oDt_apply_month = apply_month.Select();
                this.ddl_apply_month.DataSource = oDt_apply_month;
                this.ddl_apply_month.DataTextField = apply_month._APPLY_MONTH;
                this.ddl_apply_month.DataValueField = apply_month._APPLY_MONTH;
                this.ddl_apply_month.DataBind();
                //-------------------------------------------
                if (DateTime.Now.Month == 1)
                {
                    if (this.ddl_apply_year.Items.FindByValue((DateTime.Now.Year - 1).ToString()) != null)
                    {
                        this.ddl_apply_year.SelectedValue = (DateTime.Now.Year - 1).ToString();
                    }
                    if (this.ddl_apply_month.Items.FindByValue("12") != null)
                    {
                        this.ddl_apply_month.SelectedValue = "12";
                    }
                }
                else
                {
                    if (this.ddl_apply_year.Items.FindByValue((DateTime.Now.Year).ToString()) != null)
                    {
                        this.ddl_apply_year.SelectedValue = (DateTime.Now.Year).ToString();
                    }
                    if (this.ddl_apply_month.Items.FindByValue((DateTime.Now.Month - 1).ToString()) != null)
                    {
                        this.ddl_apply_month.SelectedValue = (DateTime.Now.Month - 1).ToString();
                    }
                }
                this.BindData();
            }
        }
        private void BindData()
        {
            if (this.ddl_apply_year.Items.Count == 0 || this.ddl_apply_month.Items.Count == 0)
            {
                return;
            }
            #region 绑定列表
            int _PageSize = 20;
            this.LogCount = 0;
            Entity.TEAMTOOL.APPLY apply = new Entity.TEAMTOOL.APPLY();
            apply.APPLY_YEAR = int.Parse(this.ddl_apply_year.SelectedValue);
            apply.APPLY_MONTH = int.Parse(this.ddl_apply_month.SelectedValue);
            apply.Distinct = false;
            apply.OrderBy = this.P_OrderBy;
            DataTable oDt_apply = apply.SelectByPaging(_PageSize, this.P_page - 1, out this.LogCount);
            //====================================================
            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = _PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Apply/Apply_List.aspx?page={page}&orderby=" + Server.UrlEncode(this.P_OrderBy);

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //==================================================== 

            while (apply.Next())
            {
                if (apply.APPLY_PEN_ToString == "1")
                {
                    this.Apply_Pen += 1;
                } 
                if (apply.APPLY_PENLEAD_ToString == "1")
                {
                    this.Apply_PenLead += 1;
                }
                if (apply.APPLY_BOOK_ToString == "1")
                {
                    this.Apply_Book += 1;
                }
                if (apply.APPLY_GLUE_ToString == "1")
                {
                    this.Apply_Glue += 1;
                }
                if (apply.APPLY_NOTEPAPER_ToString == "1")
                {
                    this.Apply_NotePaper += 1;
                }
            }
            this.rptLog.DataSource = oDt_apply;
            this.rptLog.DataBind();
            #endregion

        }

        protected void ddl_apply_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void ddl_apply_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void btn_Lock_Click(object sender, EventArgs e)
        {
            if (this.ddl_apply_year.Items.Count == 0 || this.ddl_apply_month.Items.Count == 0)
            {
                return;
            }
            Entity.TEAMTOOL.APPLY apply_update = new Entity.TEAMTOOL.APPLY();
            apply_update.APPLY_YEAR = int.Parse(this.ddl_apply_year.SelectedValue);
            apply_update.APPLY_MONTH = int.Parse(this.ddl_apply_month.SelectedValue);
            apply_update.APPLY_LOCK = 1;
            apply_update.PrimaryKey = new string[] { apply_update._APPLY_YEAR, apply_update._APPLY_MONTH };
            if (apply_update.Update() == true)
            {
                this.AlertScript("锁定成功！");
            }
            else
            {
                this.AlertScript("锁定失败！");
            }
            this.BindData();
        }
    }
}
