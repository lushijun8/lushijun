using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Web.Manager.DataBase
{
    public partial class DataBase_Update_ColumnDescription : Business.ManageWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.AdminCheck("Manager/DataBase/DataBase_Update_ColumnDescription.aspx");
            string Result = "{\"Message\":\"请求异常！\"}";
            if (!Page.IsPostBack)
            {
                Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
                database_owner.SelectColumns = new string[] { database_owner._DATABASE_ID,
                    database_owner._DATABASE_TABLE_DESCRIPTION,
                    database_owner._DATABASE_IP_ROMOTE,
                    database_owner._DATABASE_NAME ,
                    database_owner._DATABASE_IS_MAIN,
                    database_owner._DATABASE_ADMIN_USER};
                database_owner.DATABASE_IP_ROMOTE = Com.Common.EncDec.Decrypt(this.Forms("ip"), "fang.com");
                database_owner.DATABASE_NAME = Com.Common.EncDec.Decrypt(this.Forms("database"), "fang.com");
                database_owner.DATABASE_IS_MAIN = 1;
                if (database_owner.SelectTop1() != null)
                {
                    string tableColumn = this.Forms("tableColumn");
                    string[] Table = Com.Common.EncDec.Decrypt(tableColumn, "fang.com").Split('.');
                    string Description = System.Web.HttpUtility.UrlDecode(this.Forms("des"), Encoding.GetEncoding("utf-8")).Replace("'", "''").Replace("\n", "\r\n").Replace("\r\r", "\r");
                    string Declare = @"
                                        DECLARE @TableName varchar(100),@ColumnName varchar(100),@Description nvarchar(500)
                                        set @TableName='" + Table[0] + @"';
                                        set @ColumnName='" + Table[1] + @"';
                                        set @Description='" + Description + @"';
                                        ";
                    Database Database_Owner = DatabaseFactory.CreateDatabase(database_owner.DATABASE_IP_ROMOTE + "_" + database_owner.DATABASE_NAME + "_DataBaseInstance");
                    try
                    {
                        Database_Owner.ExecuteNonQuery(CommandType.Text, Declare + @"
                                                    EXEC sys.SP_ADDEXTENDEDPROPERTY  @name=N'MS_Description', @value=@Description , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=@TableName, @level2type=N'COLUMN',@level2name=@ColumnName
                                                   ");
                    }
                    catch { }

                    int i = Database_Owner.ExecuteNonQuery(CommandType.Text, Declare + @"
                                                    EXEC sys.SP_UPDATEEXTENDEDPROPERTY @name=N'MS_Description', @value=@Description , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=@TableName, @level2type=N'COLUMN',@level2name=@ColumnName
                                                    ");

                    if (i == 0)
                    {
                        Result = "{\"Message\":\"更新失败！\"}";
                    }
                    else
                    {
                        string error = "";
                        #region 记录修改日志
                        Entity.TEAMTOOL.DATABASE_TABLE_UPDATELOG database_table_updatelog = new Entity.TEAMTOOL.DATABASE_TABLE_UPDATELOG();
                        database_table_updatelog.WEBMANAGER_NAME=this.CurrentWebManagerName;
                        database_table_updatelog.DATABASE_IP_ROMOTE = database_owner.DATABASE_IP_ROMOTE;
                        database_table_updatelog.DATABASE_NAME = database_owner.DATABASE_NAME;
                        database_table_updatelog.TABLE_NAME = Table[0];
                        database_table_updatelog.COLUMN_NAME = Table[1];
                        database_table_updatelog.DESCRIPTION = Description;
                        database_table_updatelog.CREATETIME = DateTime.Now;
                        if (database_table_updatelog.Insert() == true)
                        {
                            error += "同时记录日志成功！";
                        }
                        else
                        {
                            error += "同时记录日志失败！";
                        }
                        #endregion
                        string DataBase_Table_Description = database_owner.DATABASE_TABLE_DESCRIPTION;
                        DataBase_Table_Description = Regex.Replace(DataBase_Table_Description, "<td class=\"ipt\" id=\"td_" + tableColumn + "\">.*?</td>", "<td class=\"ipt\" id=\"td_" + tableColumn + "\">" + Description + "</td>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        
                        Entity.TEAMTOOL.DATABASE_OWNER database_owner_update = new Entity.TEAMTOOL.DATABASE_OWNER();
                        database_owner_update.PrimaryKey = new string[] { database_owner_update._DATABASE_NAME, database_owner_update._DATABASE_ADMIN_USER };
                        database_owner_update.DATABASE_NAME = database_owner.DATABASE_NAME;
                        database_owner_update.DATABASE_ADMIN_USER = database_owner.DATABASE_ADMIN_USER;
                        database_owner_update.DATABASE_TABLE_DESCRIPTION = DataBase_Table_Description;
                        database_owner_update.LAST_UPDATE_TIME = System.DateTime.Now;
                        if (database_owner_update.Update() == true)
                        {
                            error += "同时更新表结构说明成功！";
                        }
                        else
                        {
                            error += "同时更新表结构说明失败！";
                        }
                        Result = "{\"Message\":\"Success\",\"Error\":\"" + error + "\"}";
                    }

                }
                else
                {
                    Result = "{\"Message\":\"此数据库不是主库，不能编辑字段说明！\"}";
                }
            }
            Response.ContentType = "application/json;";
            Response.Write(Result);
        }
    }
}
