using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Job
{
    public partial class Job_List : Business.ManageWeb
    {
        protected string outPage = "";
        public int P_page = 1;
        public string P_OrderBy = "";
        public string P_keyword = "";
        public string P_Type = "";
        public string P_runType = "";
        public string P_IsOpen = "";
        public string P_path = "";
        public int LogCount = 0;
        public int _PageSize = 200;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Job/Job_List.aspx");
            this.P_OrderBy = this.QueryString("orderby");
            this.P_Type = this.QueryString("type");
            this.P_runType = this.QueryString("runtype");
            this.P_path = this.QueryString("path");
            this.P_IsOpen = this.QueryString("isopen");
            if (string.IsNullOrEmpty(this.P_OrderBy))
            {
                this.P_OrderBy = "LASTRUNTIME";
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
            Entity.TUAN.TUANTASKAUTORUN tuantaskautorun = new Entity.TUAN.TUANTASKAUTORUN();
            string wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " AND (" +
                    tuantaskautorun._NAME + " like '%" + this.txtKeyword.Text + "%' or " +
                    tuantaskautorun._PATH + " like '%" + this.txtKeyword.Text + "%'  or " +
                    tuantaskautorun._AUTHOR + " like '%" + this.txtKeyword.Text + "%') ";
            }
            if (!string.IsNullOrEmpty(this.P_runType))
            {
                tuantaskautorun.RUNTYPE = int.Parse(this.P_runType);
            }
            if (!string.IsNullOrEmpty(this.P_path))
            {
                tuantaskautorun.Split_Or_And = true;
                tuantaskautorun.PATH = (this.P_path.ToLower().IndexOf("exe") > -1 ? "%" : "") + this.P_path + (this.P_path.ToLower().IndexOf("http") > -1 ? "%" : "");
            }
            if (this.P_Type == "1")
            {
                wheresql += " AND 1=2 ";
            }
            if (this.P_IsOpen == "1")
            {
                tuantaskautorun.ISOPEN = 1;
            }
            else if (!string.IsNullOrEmpty(this.P_IsOpen))
            {
                wheresql += " AND ISOPEN!=1 ";
            }
            tuantaskautorun.WhereSql = wheresql;
            tuantaskautorun.OrderBy = this.P_OrderBy + " DESC";// tuantaskautorun._LASTRUNTIME + " DESC";
            //tuantaskautorun.CacheTime = 5;
            tuantaskautorun.SelectColumns = new string[] { tuantaskautorun.TableName + ".*", tuantaskautorun.TableName + ".path as JobName", "'正式' as database_name" };
            DataTable oDt_tuantaskautorun = null;
            try
            {
                oDt_tuantaskautorun = tuantaskautorun.SelectByPaging(this._PageSize, this.P_page - 1, out LogCount_tuan);
            }
            catch { }
            //====================================================
            int LogCount_tuan_test = 0;
            Entity.TUAN_TEST.TUANTASKAUTORUN tuantaskautorun_test = new Entity.TUAN_TEST.TUANTASKAUTORUN();
            wheresql = "1=1 ";//
            if (this.txtKeyword.Text.Trim() != "")
            {
                wheresql += " AND (" +
                    tuantaskautorun_test._NAME + " like '%" + this.txtKeyword.Text + "%' or " +
                    tuantaskautorun_test._PATH + " like '%" + this.txtKeyword.Text + "%'  or " +
                    tuantaskautorun_test._AUTHOR + " like '%" + this.txtKeyword.Text + "%') ";
            }
            if (!string.IsNullOrEmpty(this.P_runType))
            {
                tuantaskautorun_test.RUNTYPE = int.Parse(this.P_runType);
            }
            if (!string.IsNullOrEmpty(this.P_path))
            {
                tuantaskautorun_test.Split_Or_And = true;
                tuantaskautorun_test.PATH = (this.P_path.ToLower().IndexOf("exe") > -1 ? "%" : "") + this.P_path + (this.P_path.ToLower().IndexOf("http") > -1 ? "%" : "");
            }
            if (this.P_Type == "0")
            {
                wheresql += " AND 1=2 ";
            }
            if (this.P_IsOpen == "1")
            {
                tuantaskautorun_test.ISOPEN = 1;
            }
            else if (!string.IsNullOrEmpty(this.P_IsOpen))
            {
                wheresql += " AND ISOPEN!=1 ";
            }
            tuantaskautorun_test.WhereSql = wheresql;
            tuantaskautorun_test.OrderBy = this.P_OrderBy + " DESC";//tuantaskautorun_test._LASTRUNTIME + " DESC";
            //tuantaskautorun.CacheTime = 5;
            tuantaskautorun_test.SelectColumns = new string[] { tuantaskautorun_test.TableName + ".*", tuantaskautorun_test.TableName + ".path as JobName", "'测试' as database_name" };
            DataTable oDt_tuantaskautorun_test = null;
            try
            {
                oDt_tuantaskautorun_test = tuantaskautorun_test.SelectByPaging(this._PageSize, this.P_page - 1, out LogCount_tuan_test);
            }
            catch { }
            //====================================================
            this.LogCount = LogCount_tuan + LogCount_tuan_test;

            Com.Common.NetPage page = new Com.Common.NetPage();
            page.Lang = "CN";
            page.PageIndex = this.P_page;
            page.PageSize = this._PageSize;
            page.ModelCount = this.LogCount;
            page.Url = Business.Config.HostUrl + "/Manager/Job/Job_List.aspx?page={page}&keyword=" + Server.UrlEncode(this.txtKeyword.Text) + "&type=" + Server.UrlEncode(this.P_Type) + "&runtype=" + Server.UrlEncode(this.P_runType) + "&path=" + Server.UrlEncode(this.P_path) + "&isopen=" + Server.UrlEncode(this.P_IsOpen) + "&orderby=" + Server.UrlEncode(this.P_OrderBy) + "";

            if (this.LogCount < _PageSize)
            {
                this.P_page = 1;
                page.PageIndex = 1;
            }
            outPage = page.Page();
            //====================================================
            if (oDt_tuantaskautorun != null)
            {
                foreach (DataColumn oDc in oDt_tuantaskautorun.Columns)
                {
                    if (oDt_tuantaskautorun_test != null && !oDt_tuantaskautorun_test.Columns.Contains(oDc.ColumnName))
                    {
                        oDt_tuantaskautorun_test.Columns.Add(new DataColumn(oDc.ColumnName, oDc.DataType));
                    }
                }
            }
            if (oDt_tuantaskautorun_test != null)
            {
                foreach (DataColumn oDc in oDt_tuantaskautorun_test.Columns)
                {
                    if (oDt_tuantaskautorun != null && !oDt_tuantaskautorun.Columns.Contains(oDc.ColumnName))
                    {
                        oDt_tuantaskautorun.Columns.Add(new DataColumn(oDc.ColumnName, oDc.DataType));
                    }
                }
            }
            DataTable dtLog = oDt_tuantaskautorun;
            if (dtLog == null)
            {
                if (oDt_tuantaskautorun_test != null)
                {
                    dtLog = oDt_tuantaskautorun_test.Clone();
                }                
            }
            foreach (DataRow oDr in oDt_tuantaskautorun_test.Rows)
            {
                DataRow oDr_New = dtLog.NewRow();
                foreach (DataColumn oDc in dtLog.Columns)
                {
                    oDr_New[oDc.ColumnName] = oDr[oDc.ColumnName];
                }
                //oDr_New.ItemArray = oDr.ItemArray;
                dtLog.Rows.Add(oDr_New);
            }
            Entity.TEAMTOOL.TUANTASKAUTORUN_LOG tuantaskautorun_log = new Entity.TEAMTOOL.TUANTASKAUTORUN_LOG();
            tuantaskautorun_log.CacheTime = 10;
            DataTable oDt_tuantaskautorun_log = tuantaskautorun_log.Database_Reader.ExecuteDataSet(CommandType.Text, @"
                                                                                                                    SELECT
	                                                                                                                    *
                                                                                                                    FROM (SELECT
	                                                                                                                    *,
	                                                                                                                    ROW_NUMBER() OVER (PARTITION BY DataBase_Name, id ORDER BY CreateTime DESC) AS RowNumber
                                                                                                                    FROM TUANTASKAUTORUN_LOG) TUANTASKAUTORUN_LOG
                                                                                                                    WHERE RowNumber <= 20").Tables[0];
            dtLog = MatchWebManager(dtLog, this.CurrentWebManagerName);
            dtLog.Columns.Add(new DataColumn("ftp", typeof(string)));
            dtLog.Columns.Add(new DataColumn("runtypename", typeof(string)));
            dtLog.Columns.Add(new DataColumn("loglengthstr", typeof(string)));
            dtLog.Columns.Add(new DataColumn("whatwrong", typeof(string)));
            dtLog.Columns.Add(new DataColumn("Log", typeof(string)));
            string[] ftps = new string[] { "ftp://xujianshi:11E011Eq$J@124.251.50.114:33321/", "ftp://xujianshi:xujianshi@10.2.136.156/" };
            string[] roots = new string[] { "E:\\soufun\\", "E:\\SouFunWeb\\" };
            foreach (DataRow oDr in dtLog.Rows)
            {
                DataRow[] oDrs_tuantaskautorun_log = oDt_tuantaskautorun_log.Select(
                    tuantaskautorun_log._DATABASE_NAME + "='" + (oDr[tuantaskautorun_log._DATABASE_NAME].ToString() == "测试" ? "tuan_test" : "tuan") + "' AND " +
                    tuantaskautorun_log._ID + "='" + oDr[tuantaskautorun_log._ID].ToString() + "'"
                    );
                if (oDrs_tuantaskautorun_log != null && oDrs_tuantaskautorun_log.Length > 0)
                {
                    string Log = "";
                    foreach (DataRow oDr_tuantaskautorun_log in oDrs_tuantaskautorun_log)
                    {
                        Log += oDr_tuantaskautorun_log[tuantaskautorun_log._CREATETIME].ToString() + "," +
                            oDr_tuantaskautorun_log[tuantaskautorun_log._WEBMANAGER_REALNAME].ToString() + "," +
                            oDr_tuantaskautorun_log[tuantaskautorun_log._REMARK].ToString() + "";

                    }
                    oDr["Log"] = Log;
                }
                if (oDr[tuantaskautorun._PATH].ToString().ToLower().StartsWith("http") == false)
                {
                    int type = 0;
                    if (oDr["database_name"].ToString() == "正式")
                    {
                        type = 0;
                    }
                    else
                    {
                        type = 1;
                    }
                    string[] paths = roots[type].Split('\\');
                    string[] file_paths = oDr[tuantaskautorun._PATH].ToString().Split('\\');
                    string ftp = ftps[type];
                    for (int i = paths.Length - 1; i < file_paths.Length; i++)
                    {
                        ftp += file_paths[i] + "/";

                    }
                    oDr["ftp"] = ftp.TrimEnd('/');
                }
                else
                {
                    oDr["ftp"] = "";
                }
                #region 执行情况
                if (oDr[tuantaskautorun._RUNTYPE].ToString() == "1")//每隔一段时间执行
                {
                    oDr["runtypename"] = "每隔 " + oDr["runminiteof"].ToString() + " 分钟";
                }
                if (oDr[tuantaskautorun._RUNTYPE].ToString() == "2")//每天定时执行
                {
                    oDr["runtypename"] = "每天 " + oDr["runtimeat"] + " 执行一次";
                }
                if (oDr[tuantaskautorun._RUNTYPE].ToString() == "3")//每周定时执行
                {
                    oDr["runtypename"] = "每周 " + oDr["runtimeat"] + " 执行一次";
                }
                if (oDr[tuantaskautorun._RUNTYPE].ToString() == "4")//每月定时执行
                {
                    oDr["runtypename"] = "每月 " + oDr["runtimeat"] + " 执行一次";
                }
                #endregion

                bool bWrong = false;
                string WhatWrong = "";
                #region 检查是否超时未运行
                if (oDr[tuantaskautorun._ISOPEN].ToString() == "1" && !string.IsNullOrEmpty(oDr[tuantaskautorun._LASTRUNTIME].ToString()))//在执行的
                {
                    TimeSpan ts = new TimeSpan();
                    if (oDr[tuantaskautorun._RUNTYPE].ToString() == "1")//每隔一段时间执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr[tuantaskautorun._LASTRUNTIME].ToString()).AddMinutes(double.Parse(oDr[tuantaskautorun._RUNMINITEOF].ToString()));
                        if (ts.TotalMinutes > 10) //超过10分钟未运行的
                        {
                            bWrong = true;
                        }
                    }
                    else if (oDr[tuantaskautorun._RUNTYPE].ToString() == "2")//每天定时执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr[tuantaskautorun._LASTRUNTIME].ToString());
                        if (ts.TotalMinutes > 1470) //超过半小时未运行的
                        {
                            bWrong = true;
                        }
                    }
                    else if (oDr[tuantaskautorun._RUNTYPE].ToString() == "3")//每周定时执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr[tuantaskautorun._LASTRUNTIME].ToString());
                        if (ts.TotalMinutes > 10140) //超过1小时未运行的
                        {
                            bWrong = true;
                        }
                    }
                    else if (oDr[tuantaskautorun._RUNTYPE].ToString() == "4")//每月定时执行
                    {
                        ts = DateTime.Now - DateTime.Parse(oDr[tuantaskautorun._LASTRUNTIME].ToString());
                        if (ts.TotalMinutes > 44760) //超过2小时未运行的
                        {
                            bWrong = true;
                        }
                    }
                    if (bWrong == true)
                    {
                        WhatWrong += "<font color=red>超过 ";

                        if (ts.TotalMinutes <= 60)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes, 1) + " 分钟";
                        }
                        else if (ts.TotalMinutes <= 1440)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 60, 1) + " 小时";
                        }
                        else if (ts.TotalMinutes <= 10080)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 1440, 1) + " 天";
                        }
                        else if (ts.TotalMinutes <= 44640)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 10080, 1) + " 周";
                        }
                        else if (ts.TotalMinutes <= 535680)
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 44640, 1) + " 月";
                        }
                        else
                        {
                            WhatWrong += Math.Round(ts.TotalMinutes / 535680, 1) + " 年";
                        }
                        WhatWrong += "未运行.</font>";

                    }
                }
                #endregion

                oDr["whatwrong"] = WhatWrong;

                if (!string.IsNullOrEmpty(oDr["loglength"].ToString()))
                {
                    long loglength = long.Parse(oDr["loglength"].ToString());
                    string loglengthstr = loglength + "字节";
                    if (loglength > 1024)
                    {
                        loglengthstr = (loglength / 1024) + "KB";
                    }
                    if (loglength > 1024 * 1024)
                    {
                        loglengthstr = (loglength / (1024 * 1024)) + "MB";
                    }
                    if (loglength > 1024 * 1024 * 1024)
                    {
                        loglengthstr = (loglength / (1024 * 1024 * 1024)) + "GB";
                    }
                    oDr["loglengthstr"] = loglengthstr;
                }
            }
            DataView oDv = dtLog.DefaultView;
            oDv.Sort = "whatwrong DESC," + this.P_OrderBy + " DESC";
            this.rptLog.DataSource = oDv;
            this.rptLog.DataBind();
            #endregion
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        public static DataTable MatchWebManager(DataTable oDt, string CurrentWebManagerName)
        {
            Entity.TEAMTOOL.JOB_MY job_my = new Entity.TEAMTOOL.JOB_MY();
            job_my.INNER_JOIN_ADMIN_WEBMANAGER = true;
            job_my.SelectColumns = new string[] { job_my.TableName + ".*", "ADMIN_WEBMANAGER.WEBMANAGER_NAME", "ADMIN_WEBMANAGER.WEBMANAGER_REALNAME" };
            DataTable oDt_job = job_my.Select();
            oDt.Columns.Add(new DataColumn(job_my._WEBMANAGER_NAME, typeof(string)));
            oDt.Columns.Add(new DataColumn("WEBMANAGER_REALNAME", typeof(string)));
            oDt.Columns.Add(new DataColumn("IsMy", typeof(int)));
            foreach (DataRow oDr in oDt.Rows)
            {
                DataRow[] oDrs_job_my = oDt_job.Select(job_my._JOBNAME + "='" + oDr["JobName"].ToString() + "'");
                if (oDrs_job_my != null && oDrs_job_my.Length > 0)
                {
                    #region 匹配负责人
                    string WebManager_Name = "";
                    string WebManager_RealName = "";
                    int IsMy = 0;
                    foreach (DataRow oDr_job_my in oDrs_job_my)
                    {
                        WebManager_Name += oDr_job_my[job_my._WEBMANAGER_NAME].ToString() + " ";
                        WebManager_RealName += oDr_job_my["WEBMANAGER_REALNAME"].ToString() + " ";
                        if (oDr_job_my[job_my._WEBMANAGER_NAME].ToString() == CurrentWebManagerName)
                        {
                            IsMy = 1;
                        }
                    }
                    oDr[job_my._WEBMANAGER_NAME] = WebManager_Name.TrimEnd(' ');
                    oDr["WEBMANAGER_REALNAME"] = WebManager_RealName.TrimEnd(' ');
                    oDr["IsMy"] = IsMy;
                    #endregion

                }
            }
            return oDt;
        }
    }
}
