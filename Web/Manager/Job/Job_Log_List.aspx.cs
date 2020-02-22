using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.Manager.Job
{
    public partial class Job_Log_List : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_OrderBy = "";
        public string P_keyword = "";
        public int LogCount = 0;
        public int _PageSize = 200;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_List.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "LASTWRITETIME";
            }
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
            int LogCount_tuan = 0;
            Entity.TUAN.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TUAN.TUANTASKAUTORUN_LOG();
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " AND (" + tuantaskautorun_log._TASKID + " LIKE '%" + this.txtKeyword.Text + "%' OR " + tuantaskautorun_log._FILEPATH + " LIKE '%" + this.txtKeyword.Text + "%')";
            }

            tuantaskautorun_log.WhereSql = wheresql;
            tuantaskautorun_log.OrderBy = this.P_OrderBy + " DESC";
            //tuantaskautorun.CacheTime = 5;
            tuantaskautorun_log.SelectColumns = new string[] { tuantaskautorun_log.TableName + ".*", "'正式' as database_name" };
            DataTable oDt_tuantaskautorun_log = tuantaskautorun_log.SelectByPaging(this._PageSize, this.P_page - 1, out LogCount_tuan);
            //====================================================
            int LogCount_tuan_test = 0;
            Entity.TUAN_TEST.TUANTASKAUTORUN_LOG tuantaskautorun_test_log = new Entity.TUAN_TEST.TUANTASKAUTORUN_LOG();
            wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " AND (" + tuantaskautorun_test_log._TASKID + " LIKE '%" + this.txtKeyword.Text + "%' OR " + tuantaskautorun_test_log._FILEPATH + " LIKE '%" + this.txtKeyword.Text + "%')";
            }

            tuantaskautorun_test_log.WhereSql = wheresql;
            tuantaskautorun_test_log.OrderBy = this.P_OrderBy + " DESC";
            //tuantaskautorun.CacheTime = 5;
            tuantaskautorun_test_log.SelectColumns = new string[] { tuantaskautorun_test_log.TableName + ".*", "'测试' as database_name" };
            DataTable oDt_tuantaskautorun_test_log = tuantaskautorun_test_log.SelectByPaging(this._PageSize, this.P_page - 1, out LogCount_tuan_test);
            //====================================================
            this.LogCount = LogCount_tuan + LogCount_tuan_test;

            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = this._PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Job/Job_Log_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text) + "&orderby=" + Server.UrlEncode(this.P_OrderBy) + "";

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //==================================================== 
            foreach (DataColumn oDc in oDt_tuantaskautorun_log.Columns)
            {
                if (!oDt_tuantaskautorun_test_log.Columns.Contains(oDc.ColumnName))
                {
                    oDt_tuantaskautorun_test_log.Columns.Add(new DataColumn(oDc.ColumnName, oDc.DataType));
                }
            }
            foreach (DataColumn oDc in oDt_tuantaskautorun_test_log.Columns)
            {
                if (!oDt_tuantaskautorun_log.Columns.Contains(oDc.ColumnName))
                {
                    oDt_tuantaskautorun_log.Columns.Add(new DataColumn(oDc.ColumnName, oDc.DataType));
                }
            }
            DataTable dtLog = oDt_tuantaskautorun_log;
            foreach (DataRow oDr in oDt_tuantaskautorun_test_log.Rows)
            {
                DataRow oDr_New = dtLog.NewRow();
                foreach (DataColumn oDc in dtLog.Columns)
                {
                    oDr_New[oDc.ColumnName] = oDr[oDc.ColumnName];
                }
                dtLog.Rows.Add(oDr_New);
            }
            dtLog.Columns.Add(new DataColumn("filesizestr", typeof(string)));
            foreach (DataRow oDr in dtLog.Rows)
            {
                if (!string.IsNullOrEmpty(oDr["filesize"].ToString()))
                {
                    long filesize = long.Parse(oDr["filesize"].ToString());
                    string filesizestr = filesize + "字节";
                    if (filesize > 1024)
                    {
                        filesizestr = (filesize / 1024) + "KB";
                    }
                    if (filesize > 1024 * 1024)
                    {
                        filesizestr = (filesize / (1024 * 1024)) + "MB";
                    }
                    if (filesize > 1024 * 1024 * 1024)
                    {
                        filesizestr = (filesize / (1024 * 1024 * 1024)) + "GB";
                    }
                    oDr["filesizestr"] = filesizestr;
                }
            }
            DataView oDv = dtLog.DefaultView;
            oDv.Sort = "Remark ASC,"+this.P_OrderBy + " DESC";
            this.rptLog.DataSource = oDv;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string form_filepath = this.Forms("filepath");
            int i = 0;
            int i_false = 0;
            if (!string.IsNullOrEmpty(form_filepath))
            {
                string[] filepaths = form_filepath.Split(',');
                foreach (string filepath in filepaths)
                {
                    string[] Params = filepath.Split('|');
                    if (Params[0] == "正式")
                    {
                        Entity.TUAN.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TUAN.TUANTASKAUTORUN_LOG();
                        tuantaskautorun_log.FILEPATH = Params[1];
                        if (tuantaskautorun_log.Delete() == true)
                        {
                            i++;
                        }
                        else
                        {
                            i_false++;
                        }
                    }
                    else
                    {
                        Entity.TUAN_TEST.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TUAN_TEST.TUANTASKAUTORUN_LOG();
                        tuantaskautorun_log.FILEPATH = Params[1]; 
                        if (tuantaskautorun_log.Delete() == true)
                        {
                            i++;
                        }
                        else
                        {
                            i_false++;
                        }
                    }

                }
            }
            this.AlertScript("成功删除" + i + "条数据,失败" + i_false + "条!");
            this.BindData();
        }

        protected void btnDeleteFile_Click(object sender, EventArgs e)
        {
            string form_filepath = this.Forms("filepath");
            int i = 0;
            int i_false = 0;
            if (!string.IsNullOrEmpty(form_filepath))
            {
                string[] filepaths = form_filepath.Split(',');
                foreach (string filepath in filepaths)
                {
                    string[] Params = filepath.Split('|');
                    if (Params[0] == "正式")
                    {
                        Entity.TUAN.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TUAN.TUANTASKAUTORUN_LOG();
                        tuantaskautorun_log.FILEPATH = Params[1];
                        tuantaskautorun_log.NEEDDELETE = 1;
                        tuantaskautorun_log.REMARK = this.CurrentWebManagerRealName + "" + DateTime.Now.ToString() + "删除;";
                        if (tuantaskautorun_log.Update() == true)
                        {
                            i++;
                        }
                        else
                        {
                            i_false++;
                        }
                    }
                    else
                    {
                        Entity.TUAN_TEST.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TUAN_TEST.TUANTASKAUTORUN_LOG();
                        tuantaskautorun_log.FILEPATH = Params[1];
                        tuantaskautorun_log.NEEDDELETE = 1;
                        tuantaskautorun_log.REMARK = this.CurrentWebManagerRealName + "" + DateTime.Now.ToString() + "删除;";
                        if (tuantaskautorun_log.Update() == true)
                        {
                            i++;
                        }
                        else
                        {
                            i_false++;
                        }
                    }

                }
            }
            this.AlertScript("成功删除" + i + "个日志文件,失败" + i_false + "条!");
            this.BindData();
        }
    }
}
