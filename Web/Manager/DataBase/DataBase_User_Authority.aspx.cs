using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.Manager.DataBase
{
    public partial class DataBase_User_Authority : Business.ManageWeb
    {
        public string html = "";
        public string P_keyword = "";
        public int LogCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/DataBase/DataBase_User_Authority.aspx");

            if (!Page.IsPostBack)
            {
                this.P_keyword = QueryString("keyword");
                this.txtKeyword.Text = this.P_keyword;
                this.BindData();
            }
        }
        private void BindData()
        {

            /*
            SELECT DISTINCT
	[DataBase_User].[DataBase_IP_Romote],
	[DataBase_User].[DataBase_Name],
	[DataBase_User].[uName],
	ISNULL([DataBase_User_Authority].[tName], '') AS [tName],
	ISNULL([DataBase_User_Authority].[tType], '') AS [tType],
	SUM(DISTINCT ISNULL([tReferences], 0)) AS [tReferences],
	SUM(DISTINCT ISNULL([tInsert], 0)) AS [tInsert],
	SUM(DISTINCT ISNULL([tSelect], 0)) AS [tSelect],
	SUM(DISTINCT ISNULL([tUpdate], 0)) AS [tUpdate],
	SUM(DISTINCT ISNULL([tDelete], 0)) AS [tDelete],
	SUM(DISTINCT ISNULL([tExecute], 0)) AS [tExecute]
FROM [DataBase_User_Authority]

RIGHT JOIN [DataBase_User]
	ON [DataBase_User].[DataBase_IP_Romote] = [DataBase_User_Authority].[DataBase_IP_Romote]
	AND [DataBase_User].[DataBase_Name] = [DataBase_User_Authority].[DataBase_Name]
	AND [DataBase_User].[uName] = [DataBase_User_Authority].[uName]
             * 
             * 
GROUP BY	[DataBase_User].[DataBase_IP_Romote],
			[DataBase_User].[DataBase_Name],
			[DataBase_User].[uName],
			[DataBase_User_Authority].[tName],
			[DataBase_User_Authority].[tType]
			order by [DataBase_IP_Romote],[DataBase_Name],[uName]

			 */



            #region 绑定列表
            Entity.TEAMTOOL.DATABASE_USER database_user = new Entity.TEAMTOOL.DATABASE_USER();
            Entity.TEAMTOOL.DATABASE_USER_AUTHORITY database_user_authority = new Entity.TEAMTOOL.DATABASE_USER_AUTHORITY();
            database_user_authority.Distinct = true;
            database_user_authority.SelectColumns = new string[]{
            "["+database_user.TableName+@"].["+database_user_authority._DATABASE_IP_ROMOTE+@"]",
	        "["+database_user.TableName+@"].[" + database_user_authority._DATABASE_NAME + @"]",
	        "["+database_user.TableName+@"].[" + database_user_authority._UNAME+"]",
	        "ISNULL(["+database_user_authority.TableName+"].["+database_user_authority._TNAME+"], '') AS ["+database_user_authority._TNAME+"]",
	        "ISNULL(["+database_user_authority.TableName+"].["+database_user_authority._TTYPE+"], '') AS ["+database_user_authority._TTYPE+"]",
	        "SUM(DISTINCT ISNULL(["+database_user_authority._TREFERENCES+"], 0)) AS ["+database_user_authority._TREFERENCES+"]",
	        "SUM(DISTINCT ISNULL(["+database_user_authority._TINSERT+"], 0)) AS ["+database_user_authority._TINSERT+"]",
	        "SUM(DISTINCT ISNULL(["+database_user_authority._TSELECT+"], 0)) AS ["+database_user_authority._TSELECT+"]",
	        "SUM(DISTINCT ISNULL(["+database_user_authority._TUPDATE+"], 0)) AS ["+database_user_authority._TUPDATE+"]",
	        "SUM(DISTINCT ISNULL(["+database_user_authority._TDELETE+"], 0)) AS ["+database_user_authority._TDELETE+"]",
	        "SUM(DISTINCT ISNULL(["+database_user_authority._TEXECUTE+"], 0)) AS ["+database_user_authority._TEXECUTE+"]"

            };
            database_user_authority.JoinSql = @"RIGHT JOIN [" + database_user.TableName + @"] ON 
                                            [" + database_user.TableName + @"].[" + database_user_authority._DATABASE_IP_ROMOTE + @"] = [" + database_user_authority.TableName + @"].[" + database_user_authority._DATABASE_IP_ROMOTE + @"] AND 
                                            [" + database_user.TableName + @"].[" + database_user_authority._DATABASE_NAME + @"] = [" + database_user_authority.TableName + @"].[" + database_user_authority._DATABASE_NAME + @"] AND 
                                            [" + database_user.TableName + @"].[" + database_user_authority._UNAME + "] = [" + database_user_authority.TableName + @"].[" + database_user_authority._UNAME + "]";
            database_user_authority.GroupBy = @"[" + database_user.TableName + @"].[" + database_user_authority._DATABASE_IP_ROMOTE + @"],
			                                    [" + database_user.TableName + @"].[" + database_user_authority._DATABASE_NAME + @"],
			                                    [" + database_user.TableName + @"].[" + database_user_authority._UNAME + @"],
			                                    [" + database_user_authority.TableName + "].[" + database_user_authority._TNAME + @"],
			                                    [" + database_user_authority.TableName + "].[" + database_user_authority._TTYPE + "]";
            database_user_authority.OrderBy = "[" + database_user.TableName + @"].[" + database_user_authority._DATABASE_IP_ROMOTE + @"],[" + database_user.TableName + @"].[" + database_user_authority._DATABASE_NAME + @"],[" + database_user.TableName + @"].[" + database_user_authority._UNAME + @"]";
            if (!string.IsNullOrEmpty(this.txtKeyword.Text))
            {
                database_user_authority.WhereSql = "([" + database_user.TableName + @"].[" + database_user_authority._DATABASE_IP_ROMOTE + @"]='" + this.txtKeyword.Text + "' OR [" + database_user.TableName + @"].[" + database_user_authority._DATABASE_NAME + @"]='" + this.txtKeyword.Text + "' OR [" + database_user.TableName + @"].[" + database_user_authority._UNAME + "]='" + this.txtKeyword.Text + "')";
            }
            DataTable oDt_database_user_authority = database_user_authority.Select();
            this.LogCount = oDt_database_user_authority.Rows.Count;

            ArrayList database_ip_remotes = new ArrayList();
            foreach (DataRow oDr in oDt_database_user_authority.Rows)
            {
                if (!database_ip_remotes.Contains(oDr[database_user_authority._DATABASE_IP_ROMOTE].ToString()))
                {
                    database_ip_remotes.Add(oDr[database_user_authority._DATABASE_IP_ROMOTE].ToString());
                }
            }
            html += "<table class=\"joblist\" width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\"><tr><th>数据库IP</th><th>数据库名称</th><th>用户名</th><th>角色</th><th>对象</th><th>对象类型</th><th>References</th><th>Insert</th><th>Select</th><th>Update</th><th>Delete</th><th>Execute</th></tr><tr>";
            for (int i = 0; i < database_ip_remotes.Count; i++)
            {
                DataRow[] oDrs_database_ip_remotes = oDt_database_user_authority.Select(database_user_authority._DATABASE_IP_ROMOTE + "='" + database_ip_remotes[i].ToString() + "'");
                if (i > 0)
                {
                    html += "</tr><tr>";
                }
                html += "<td rowspan=\"" + oDrs_database_ip_remotes.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/DataBase/DataBase_User_Authority.aspx?keyword=" + Server.UrlEncode(database_ip_remotes[i].ToString()) + "\">" + database_ip_remotes[i].ToString() + "</a></td>";
                #region 获取数据库名称
                ArrayList database_names = new ArrayList();
                foreach (DataRow oDr in oDrs_database_ip_remotes)
                {
                    if (!database_names.Contains(oDr[database_user_authority._DATABASE_NAME].ToString()))
                    {
                        database_names.Add(oDr[database_user_authority._DATABASE_NAME].ToString());
                    }
                }
                for (int j = 0; j < database_names.Count; j++)
                {
                    DataRow[] oDrs_database_names = oDt_database_user_authority.Select(database_user_authority._DATABASE_IP_ROMOTE + "='" + database_ip_remotes[i].ToString() + "' and " + database_user_authority._DATABASE_NAME + "='" + database_names[j].ToString() + "'");
                    if (j > 0)
                    {
                        html += "</tr><tr>";
                    }
                    html += "<td rowspan=\"" + oDrs_database_names.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/DataBase/DataBase_User_Authority.aspx?keyword=" + Server.UrlEncode(database_names[j].ToString()) + "\">" + database_names[j].ToString() + "</a></td>";
                    #region 获取用户名
                    ArrayList unames = new ArrayList();
                    foreach (DataRow oDr in oDrs_database_names)
                    {
                        if (!unames.Contains(oDr[database_user_authority._UNAME].ToString()))
                        {
                            unames.Add(oDr[database_user_authority._UNAME].ToString());
                        }
                    }
                    for (int k = 0; k < unames.Count; k++)
                    {
                        DataRow[] oDrs_unames = oDt_database_user_authority.Select(database_user_authority._DATABASE_IP_ROMOTE + "='" + database_ip_remotes[i].ToString() + "' and " + database_user_authority._DATABASE_NAME + "='" + database_names[j].ToString() + "' and " + database_user_authority._UNAME + "='" + unames[k].ToString() + "'");
                        if (k > 0)
                        {
                            html += "</tr><tr>";
                        }

                        string RoleName = "";
                        Entity.TEAMTOOL.DATABASE_USER database_user_select = new Entity.TEAMTOOL.DATABASE_USER();
                        database_user_select.CacheTime = 10;
                        DataTable oDt_database_user_select = database_user_select.Select();
                        DataRow[] oDrs_database_user_select = oDt_database_user_select.Select(database_user_select._DATABASE_IP_ROMOTE + "='" + database_ip_remotes[i].ToString() + "' AND " +
                            database_user_select._DATABASE_NAME + "='" + database_names[j].ToString() + "' AND " +
                            database_user_select._UNAME + "='" + unames[k].ToString() + "'");
                        if (oDrs_database_user_select != null && oDrs_database_user_select.Length > 0)
                        {
                            foreach (DataRow oDr_database_user_select in oDrs_database_user_select)
                            {
                                RoleName += oDr_database_user_select[database_user_select._RNAME].ToString() + "<br>";
                            }
                        }

                        html += "<td rowspan=\"" + oDrs_unames.Length + "\"><a href=\"" + Business.Config.HostUrl + "/Manager/DataBase/DataBase_User_Authority.aspx?keyword=" + Server.UrlEncode(unames[k].ToString()) + "\">" + unames[k].ToString() + "</a></td>" +
                            "<td rowspan=\"" + oDrs_unames.Length + "\">" + RoleName + "</td>";
                        #region 获取步骤
                        ArrayList tnames = new ArrayList();
                        ArrayList ttypes = new ArrayList();
                        ArrayList treferences = new ArrayList();
                        ArrayList tinserts = new ArrayList();
                        ArrayList tselects = new ArrayList();
                        ArrayList tupdates = new ArrayList();
                        ArrayList tdeletes = new ArrayList();
                        ArrayList texecutes = new ArrayList();

                        foreach (DataRow oDr in oDrs_unames)
                        {
                            if (!tnames.Contains(oDr[database_user_authority._TNAME].ToString()))
                            {
                                tnames.Add(oDr[database_user_authority._TNAME].ToString());
                                ttypes.Add(oDr[database_user_authority._TTYPE].ToString());
                                treferences.Add(oDr[database_user_authority._TREFERENCES].ToString());
                                tinserts.Add(oDr[database_user_authority._TINSERT].ToString());
                                tselects.Add(oDr[database_user_authority._TSELECT].ToString());
                                tupdates.Add(oDr[database_user_authority._TUPDATE].ToString());
                                tdeletes.Add(oDr[database_user_authority._TDELETE].ToString());
                                texecutes.Add(oDr[database_user_authority._TEXECUTE].ToString());
                            }
                        }
                        for (int l = 0; l < tnames.Count; l++)
                        {
                            html +=
                                "<td>" + tnames[l].ToString() + "</td>" +
                                "<td>" +
                                (ttypes[l].ToString().ToUpper().Trim() == "P" ? "存储过程" : "") +
                                (ttypes[l].ToString().ToUpper().Trim() == "V" ? "视图" : "") +
                                (ttypes[l].ToString().ToUpper().Trim() == "U" ? "表" : "") +
                                (ttypes[l].ToString().ToUpper().Trim() == "FN" ? "函数" : "") +
                                "</td>" +

                                "<td>" +
                                (treferences[l].ToString() == "1" ? "references <img src=\"" + Business.Config.HostUrl + "/images/yes.gif\"/>" : "") +
                                (treferences[l].ToString() == "-1" ? "references <img src=\"" + Business.Config.HostUrl + "/images/no.gif\"/>" : "") +
                                (treferences[l].ToString() == "0" ? "" : "") +
                                "</td>" +

                                "<td>" +
                                (tinserts[l].ToString() == "1" ? "insert <img src=\"" + Business.Config.HostUrl + "/images/yes.gif\"/>" : "") +
                                (tinserts[l].ToString() == "-1" ? "insert <img src=\"" + Business.Config.HostUrl + "/images/no.gif\"/>" : "") +
                                (tinserts[l].ToString() == "0" ? "" : "") +
                                "</td>" +

                                "<td>" +
                                (tselects[l].ToString() == "1" ? "select <img src=\"" + Business.Config.HostUrl + "/images/yes.gif\"/>" : "") +
                                (tselects[l].ToString() == "-1" ? "select <img src=\"" + Business.Config.HostUrl + "/images/no.gif\"/>" : "") +
                                (tselects[l].ToString() == "0" ? "" : "") +
                                "</td>" +

                                "<td>" +
                                (tupdates[l].ToString() == "1" ? "update <img src=\"" + Business.Config.HostUrl + "/images/yes.gif\"/>" : "") +
                                (tupdates[l].ToString() == "-1" ? "update <img src=\"" + Business.Config.HostUrl + "/images/no.gif\"/>" : "") +
                                (tupdates[l].ToString() == "0" ? "" : "") +
                                "</td>" +

                                "<td>" +
                                (tdeletes[l].ToString() == "1" ? "delete <img src=\"" + Business.Config.HostUrl + "/images/yes.gif\"/>" : "") +
                                (tdeletes[l].ToString() == "-1" ? "delete <img src=\"" + Business.Config.HostUrl + "/images/no.gif\"/>" : "") +
                                (tdeletes[l].ToString() == "0" ? "" : "") +
                                "</td>" +

                                "<td>" +
                                (texecutes[l].ToString() == "1" ? "execute <img src=\"" + Business.Config.HostUrl + "/images/yes.gif\"/>" : "") +
                                (texecutes[l].ToString() == "-1" ? "execute <img src=\"" + Business.Config.HostUrl + "/images/no.gif\"/>" : "") +
                                (texecutes[l].ToString() == "0" ? "" : "") +
                                "</td>" +
                                "</tr><tr>";
                        }
                        #endregion
                        html += "";
                    }
                    #endregion
                    html += "";
                }
                #endregion
                html += "";
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