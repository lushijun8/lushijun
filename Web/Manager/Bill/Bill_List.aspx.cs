using System;
using System.Collections.Generic;

using System.Web;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Bill
{
    public partial class Bill_List : Business.ManageWeb
    {
        public int TotalSum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Bill/Bill_List.aspx");
            if (!Page.IsPostBack)
            {
                Entity.TEAMTOOL.BILL bill_year = new Entity.TEAMTOOL.BILL();
                bill_year.SelectColumns = new string[] { bill_year._BILL_YEAR };
                bill_year.CacheTime = 30;
                bill_year.Distinct = true;
                bill_year.OrderBy = bill_year._BILL_YEAR + " desc";
                DataTable oDt_bill_year = bill_year.Select();
                this.ddl_bill_year.DataSource = oDt_bill_year;
                this.ddl_bill_year.DataTextField = bill_year._BILL_YEAR;
                this.ddl_bill_year.DataValueField = bill_year._BILL_YEAR;
                this.ddl_bill_year.DataBind();
                //--------------------------------------------
                Entity.TEAMTOOL.BILL bill_month = new Entity.TEAMTOOL.BILL();
                bill_month.SelectColumns = new string[] { bill_month._BILL_MONTH };
                bill_month.CacheTime = 30;
                bill_month.Distinct = true;
                bill_month.OrderBy = bill_month._BILL_MONTH + " desc";
                DataTable oDt_bill_month = bill_month.Select();
                this.ddl_bill_month.DataSource = oDt_bill_month;
                this.ddl_bill_month.DataTextField = bill_month._BILL_MONTH;
                this.ddl_bill_month.DataValueField = bill_month._BILL_MONTH;
                this.ddl_bill_month.DataBind();
                //-------------------------------------------
                if (DateTime.Now.Month == 1)
                {
                    if (this.ddl_bill_year.Items.FindByValue((DateTime.Now.Year - 1).ToString()) != null)
                    {
                        this.ddl_bill_year.SelectedValue = (DateTime.Now.Year - 1).ToString();
                    }
                    if (this.ddl_bill_month.Items.FindByValue("12") != null)
                    {
                        this.ddl_bill_month.SelectedValue = "12";
                    }
                }
                else
                {
                    if (this.ddl_bill_year.Items.FindByValue((DateTime.Now.Year).ToString()) != null)
                    {
                        this.ddl_bill_year.SelectedValue = (DateTime.Now.Year).ToString();
                    }
                    if (this.ddl_bill_month.Items.FindByValue((DateTime.Now.Month - 1).ToString()) != null)
                    {
                        this.ddl_bill_month.SelectedValue = (DateTime.Now.Month - 1).ToString();
                    }
                }
                //------------------------------------------- 
                if (this.CurrentIsAdmin == true)
                {
                    Entity.TEAMTOOL.BILL bill_leader_realname = new Entity.TEAMTOOL.BILL();
                    bill_leader_realname.SelectColumns = new string[] { bill_leader_realname._BILL_LEADER_REALNAME };
                    bill_leader_realname.CacheTime = 30;
                    bill_leader_realname.Distinct = true;
                    bill_leader_realname.OrderBy = bill_leader_realname._BILL_LEADER_REALNAME + " desc";
                    DataTable oDt_bill_leader_realname = bill_leader_realname.Select();
                    this.ddl_bill_leader_realname.DataSource = oDt_bill_leader_realname;
                    this.ddl_bill_leader_realname.DataTextField = bill_leader_realname._BILL_LEADER_REALNAME;
                    this.ddl_bill_leader_realname.DataValueField = bill_leader_realname._BILL_LEADER_REALNAME;
                    this.ddl_bill_leader_realname.DataBind();

                    this.ddl_bill_leader_realname.Items.Insert(0, new ListItem("-全部-", ""));
                    this.ddl_bill_leader_realname.SelectedValue = "";
                }
                else
                {
                    this.ddl_bill_leader_realname.Items.Add(new ListItem(this.CurrentWebManagerLeaderRealName, this.CurrentWebManagerLeaderRealName));
                    this.ddl_bill_leader_realname.SelectedValue = this.CurrentWebManagerLeaderRealName;
                }
                this.BindData();

            }

        }
        private void BindData()
        {
            if (this.ddl_bill_year.Items.Count == 0)
            {
                return;
            }
            Entity.TEAMTOOL.BILL bill = new Entity.TEAMTOOL.BILL();
            bill.BILL_YEAR = int.Parse(this.ddl_bill_year.SelectedValue);
            bill.BILL_MONTH = int.Parse(this.ddl_bill_month.SelectedValue);
            //bill.CacheTime = 30;
            bill.OrderBy = bill._BILL_DATE + " ASC";
            DataTable oDt_bill = bill.Select();

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

            DataView oDv_bill = oDt_bill.DefaultView;
            oDv_bill.RowFilter = "";
            if (this.ddl_bill_leader_realname.SelectedValue.Trim() != "")
            {
                oDv_bill.RowFilter = bill._BILL_LEADER_REALNAME + "='" + this.ddl_bill_leader_realname.SelectedValue + "'";
            }

            DataTable oDt_sum_by_person = new DataTable();
            DataTable oDt_sum_by_leader = new DataTable();
            DataTable oDt_sum = new DataTable();
            oDt_sum_by_person.Columns.Add(new DataColumn(bill._BILL_WEBMANAGER_REALNAME, typeof(string)));
            oDt_sum_by_person.Columns.Add(new DataColumn(bill._BILL_TOTAL_MONEY, typeof(int)));

            oDt_sum_by_leader.Columns.Add(new DataColumn(bill._BILL_LEADER_REALNAME, typeof(string)));
            oDt_sum_by_leader.Columns.Add(new DataColumn(bill._BILL_TOTAL_MONEY, typeof(int)));
            oDt_sum_by_leader.Columns.Add(new DataColumn(bill._BILL_LOCK, typeof(int)));
            oDt_sum_by_leader.Columns.Add(new DataColumn("BILL_RECEIVE", typeof(int)));

            oDt_sum.Columns.Add(new DataColumn(bill._BILL_DATE, typeof(DateTime)));
            oDt_sum.Columns.Add(new DataColumn(bill._BILL_REASON, typeof(string)));
            oDt_sum.Columns.Add(new DataColumn(bill._BILL_STAFF_WORKER, typeof(string)));
            oDt_sum.Columns.Add(new DataColumn(bill._BILL_TOTAL_MONEY, typeof(int)));
            oDt_sum.Columns.Add(new DataColumn("BILL_TOTAL_MONEY_OVER", typeof(int)));


            foreach (DataRowView oDrv in oDv_bill)
            {
                #region
                DataRow[] oDrs_sum_by_person = oDt_sum_by_person.Select(bill._BILL_WEBMANAGER_REALNAME + "='" + oDrv.Row[bill._BILL_WEBMANAGER_REALNAME].ToString() + "'");
                if (oDrs_sum_by_person != null && oDrs_sum_by_person.Length > 0)
                {
                    oDrs_sum_by_person[0][bill._BILL_TOTAL_MONEY] = int.Parse(oDrs_sum_by_person[0][bill._BILL_TOTAL_MONEY].ToString()) +
                        int.Parse(oDrv.Row[bill._BILL_TOTAL_MONEY].ToString());
                }
                else
                {

                    DataRow oNewRow = oDt_sum_by_person.NewRow();
                    oNewRow[bill._BILL_WEBMANAGER_REALNAME] = oDrv.Row[bill._BILL_WEBMANAGER_REALNAME].ToString();
                    oNewRow[bill._BILL_TOTAL_MONEY] = oDrv.Row[bill._BILL_TOTAL_MONEY].ToString();
                    oDt_sum_by_person.Rows.Add(oNewRow);
                }
                //---------------------------------------------------------------------------------------------
                DataRow[] oDrs_sum_by_leader = oDt_sum_by_leader.Select(bill._BILL_LEADER_REALNAME + "='" + oDrv.Row[bill._BILL_LEADER_REALNAME].ToString() + "'");
                if (oDrs_sum_by_leader != null && oDrs_sum_by_leader.Length > 0)
                {
                    oDrs_sum_by_leader[0][bill._BILL_TOTAL_MONEY] = int.Parse(oDrs_sum_by_leader[0][bill._BILL_TOTAL_MONEY].ToString()) +
                        int.Parse(oDrv.Row[bill._BILL_TOTAL_MONEY].ToString());
                }
                else
                {

                    DataRow oNewRow = oDt_sum_by_leader.NewRow();
                    oNewRow[bill._BILL_LEADER_REALNAME] = oDrv.Row[bill._BILL_LEADER_REALNAME].ToString();
                    oNewRow[bill._BILL_TOTAL_MONEY] = oDrv.Row[bill._BILL_TOTAL_MONEY].ToString();
                    oDt_sum_by_leader.Rows.Add(oNewRow);
                }
                //---------------------------------------------------------------------------------------------
                DataRow[] oDrs_sum = oDt_sum.Select(bill._BILL_DATE + "='" + oDrv.Row[bill._BILL_DATE].ToString() + "'");
                if (oDrs_sum != null && oDrs_sum.Length > 0)
                {
                    oDrs_sum[0][bill._BILL_REASON] = oDrs_sum[0][bill._BILL_REASON].ToString().Trim() + "," + oDrv.Row[bill._BILL_REASON].ToString();
                    oDrs_sum[0][bill._BILL_STAFF_WORKER] = oDrs_sum[0][bill._BILL_STAFF_WORKER].ToString().Trim() + " " + oDrv.Row[bill._BILL_STAFF_WORKER].ToString();
                    oDrs_sum[0][bill._BILL_TOTAL_MONEY] = int.Parse(oDrs_sum[0][bill._BILL_TOTAL_MONEY].ToString()) + int.Parse(oDrv.Row[bill._BILL_TOTAL_MONEY].ToString());

                }
                else
                {
                    DataRow oNewRow = oDt_sum.NewRow();
                    oNewRow[bill._BILL_DATE] = oDrv.Row[bill._BILL_DATE].ToString();
                    oNewRow[bill._BILL_REASON] = oDrv.Row[bill._BILL_REASON].ToString();
                    oNewRow[bill._BILL_STAFF_WORKER] = oDrv.Row[bill._BILL_STAFF_WORKER].ToString();
                    oNewRow[bill._BILL_TOTAL_MONEY] = oDrv.Row[bill._BILL_TOTAL_MONEY].ToString();
                    oDt_sum.Rows.Add(oNewRow);
                }
                #endregion
            }

            foreach (DataRow oDr_sum in oDt_sum.Rows)
            {
                string[] RealNames = oDr_sum[bill._BILL_STAFF_WORKER].ToString().Trim().Split(' ');
                ArrayList realnames = new ArrayList();
                foreach (string RealName in RealNames)
                {
                    if (realnames.Contains(RealName))
                    {
                        oDr_sum[bill._BILL_STAFF_WORKER] = oDr_sum[bill._BILL_STAFF_WORKER].ToString().Replace(RealName, "<font color=red>" + RealName + "</font>");
                    }
                    else
                    {
                        realnames.Add(RealName);
                    }
                }
                oDr_sum["BILL_TOTAL_MONEY_OVER"] = int.Parse(oDr_sum[bill._BILL_TOTAL_MONEY].ToString()) - RealNames.Length * 25;
                TotalSum += int.Parse(oDr_sum[bill._BILL_TOTAL_MONEY].ToString());
            }
            //-----------------------------------------------
            Entity.TEAMTOOL.BILL_LOCK bill_lock = new Entity.TEAMTOOL.BILL_LOCK();
            bill_lock.BILL_LOCK_YEAR = int.Parse(this.ddl_bill_year.SelectedValue);
            bill_lock.BILL_LOCK_MONTH = int.Parse(this.ddl_bill_month.SelectedValue);
            DataTable oDt_bill_lock = bill_lock.Select();
            foreach (DataRow oDr_sum_by_leader in oDt_sum_by_leader.Rows)
            {
                DataRow[] oDrs_bill_lock = oDt_bill_lock.Select(
                    bill_lock._BILL_LOCK_YEAR + "=" + this.ddl_bill_year.SelectedValue + " and " +
                    bill_lock._BILL_LOCK_MONTH + "=" + this.ddl_bill_month.SelectedValue + " and " +
                    bill_lock._BILL_LOCK_LEADER_REALNAME + "='" + oDr_sum_by_leader[bill._BILL_LEADER_REALNAME].ToString() + "' ");
                if (oDrs_bill_lock != null && oDrs_bill_lock.Length > 0)
                {
                    oDr_sum_by_leader[bill._BILL_LOCK] = 1;
                }
            }
            //---------------------------------------------------------------------------------
            Entity.TEAMTOOL.BILL_RECEIVE bill_receive = new Entity.TEAMTOOL.BILL_RECEIVE();
            bill_receive.BILL_RECEIVE_YEAR = int.Parse(this.ddl_bill_year.SelectedValue);
            bill_receive.BILL_RECEIVE_MONTH = int.Parse(this.ddl_bill_month.SelectedValue);
            DataTable oDt_bill_receive = bill_receive.Select();
            foreach (DataRow oDr_sum_by_leader in oDt_sum_by_leader.Rows)
            {
                DataRow[] oDrs_bill_receive = oDt_bill_receive.Select(
                    bill_receive._BILL_RECEIVE_YEAR + "=" + this.ddl_bill_year.SelectedValue + " and " +
                    bill_receive._BILL_RECEIVE_MONTH + "=" + this.ddl_bill_month.SelectedValue + " and " +
                    bill_receive._BILL_RECEIVE_LEADER_REALNAME + "='" + oDr_sum_by_leader[bill._BILL_LEADER_REALNAME].ToString() + "' ");
                if (oDrs_bill_receive != null && oDrs_bill_receive.Length > 0)
                {
                    oDr_sum_by_leader["BILL_RECEIVE"] = 1;
                }
            }
            //-----------------------------------------------------------------------------------

            this.rpt_bill.DataSource = oDv_bill;
            this.rpt_bill.DataBind();
            this.rpt_sum.DataSource = oDt_sum;
            this.rpt_sum.DataBind();
            this.rpt_sum_by_leader.DataSource = oDt_sum_by_leader;
            this.rpt_sum_by_leader.DataBind();
            this.rpt_sum_by_person.DataSource = oDt_sum_by_person;
            this.rpt_sum_by_person.DataBind();
        }

        protected void btn_Lock_Click(object sender, EventArgs e)
        {
            if (this.ddl_bill_year.Items.Count == 0)
            {
                return;
            }
            if (this.ddl_bill_leader_realname.SelectedValue.Trim() == "")
            {
                this.AlertScript("锁定失败，请选择团队！");
                return;
            }
            Entity.TEAMTOOL.BILL bill_update = new Entity.TEAMTOOL.BILL();
            bill_update.BILL_YEAR = int.Parse(this.ddl_bill_year.SelectedValue);
            bill_update.BILL_MONTH = int.Parse(this.ddl_bill_month.SelectedValue);
            bill_update.BILL_LOCK = 1;
            bill_update.PrimaryKey = new string[] { bill_update._BILL_YEAR, bill_update._BILL_MONTH };
            if (!string.IsNullOrEmpty(this.ddl_bill_leader_realname.SelectedValue))
            {
                bill_update.BILL_LEADER_REALNAME = this.ddl_bill_leader_realname.SelectedValue;
                bill_update.PrimaryKey = new string[] { bill_update._BILL_YEAR, bill_update._BILL_MONTH, bill_update._BILL_LEADER_REALNAME };
            }
            //------------------------------------
            Entity.TEAMTOOL.BILL_LOCK bill_lock = new Entity.TEAMTOOL.BILL_LOCK();
            bill_lock.BILL_LOCK_YEAR = int.Parse(this.ddl_bill_year.SelectedValue);
            bill_lock.BILL_LOCK_MONTH = int.Parse(this.ddl_bill_month.SelectedValue);
            bill_lock.BILL_LOCK_LEADER_REALNAME = this.ddl_bill_leader_realname.SelectedValue;
            string error = "";
            if (bill_lock.Insert() == true)
            {
                error = "bill_lock添加成功！";
            }
            else
            {
                error = "bill_lock添加失败(可能已经锁定过)！";
            }
            //-------------------------------------
            if (bill_update.Update() == true)
            {
                this.AlertScript("锁定成功！" + error);
            }
            else
            {
                this.AlertScript("锁定失败！" + error);
            }
            this.BindData();
        }

        protected void ddl_bill_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void ddl_bill_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void ddl_bill_leader_realname_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}