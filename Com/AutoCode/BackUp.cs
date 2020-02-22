using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Com.AutoCode
{
    public class BackUp
    {
        public static string Get_Proc_View_Fun_Bak(Microsoft.Practices.EnterpriseLibrary.Data.Database DataBaseOwner, string DataBase_IP)
        {
            string DataBase_Name = DataBaseOwner.GetConnection().Database;
            #region FileContent
            string FileContent = @"<html><head><title>数据库" + DataBase_IP + ".." + DataBase_Name + "表、存储过程、视图、函数、触发器(" + System.DateTime.Now.ToString() + @")</title><meta http-equiv=" + "\"" + @"Content-Type" + "\"" + @" content=" + "\"" + @"text/html; charset=gb2312" + "\"" + @" /><style>p,ul,li{font-size:9pt;}p{clear:both}p.b{border-top:solid 1px #cccccc;border-bottom:solid 1px #cccccc;background-color:#f2f2f2}#list{margin-left: 0px;padding-left: 0px;clear:both}li{padding-left: 22px;float: left;width: 293.8px;list-style: none;border: 1px solid #cccccc;margin: 1px;height: 20px;vertical-align: middle;}li.u{background: url('/images/u.gif') no-repeat 3 50%;}li.fn{background: url('/images/fn.gif') no-repeat 3 50%;background-color: lightgray;}li.tr{background: url('/images/tr.gif') no-repeat 3 50%;background-color: lightyellow;}li.v{background: url('/images/v.gif') no-repeat 3 50%;background-color: lightblue;}li.p{background: url('/images/p.gif') no-repeat 3 50%;background-color: lightpink;}li.if{background: url('/images/if.gif') no-repeat 3 50%;background-color: #f0f0f0;}li.tf{background: url('/images/tf.gif') no-repeat 3 50%;background-color: #f0f0f0;}</style></head><body><h2 id=top>数据库" + DataBase_IP + ".." + DataBase_Name + "表、存储过程、视图、函数、触发器(" + System.DateTime.Now.ToString() + @")</h2>";

            Com.Data.SqlServer.Entity.SYSOBJECTS sysobjects = new Com.Data.SqlServer.Entity.SYSOBJECTS();
            sysobjects.Database_Reader = DataBaseOwner;
            sysobjects.DataBase = DataBase_Name;
            sysobjects.SelectColumns = new string[] { sysobjects._NAME, sysobjects._ID };
            sysobjects.XTYPE = "U";
            DataTable oDt_SYSOBJECTS = sysobjects.Select();

            //------------------------------------------------------------------------------------------
            Com.Data.SqlServer.Entity.SYSCOMMENTS syscomments = new Com.Data.SqlServer.Entity.SYSCOMMENTS();
            syscomments.Database_Reader = DataBaseOwner;
            syscomments.DataBase = DataBase_Name;
            syscomments.JoinSql = "INNER join sysobjects on object_id(sysobjects.name)=syscomments.id";
            syscomments.SelectColumns = new string[] { "sysobjects.xtype", "sysobjects.name", "syscomments.COLID", "syscomments.TEXT" };
            syscomments.OrderBy = " syscomments." + syscomments._ID + ", syscomments." + syscomments._COLID + " ";
            syscomments.Distinct = false;
            syscomments.WhereSql = "sysobjects.xtype in('FN','TR','V','P','IF','TF')";
            DataTable oDt_syscomments = syscomments.Select();
            //------------------------------------------------------------------------------------------

            FileContent += "<ul id=\"list\">";
            foreach (DataRow oDr in oDt_SYSOBJECTS.Rows)
            {
                FileContent += "<li class=\"u\"><a href=\"#u_" + oDr[sysobjects._NAME].ToString() + "\">" + oDr[sysobjects._NAME].ToString() + "</a></li>";

            }

            DataView oDv_syscomments = oDt_syscomments.DefaultView;
            oDv_syscomments.Sort = sysobjects._XTYPE;
            for (int k = 0; k < oDv_syscomments.Count; k++)
            {
                if (oDv_syscomments[k][syscomments._COLID].ToString() == "1")
                {
                    FileContent += "<li class=\"" + oDv_syscomments[k][sysobjects._XTYPE].ToString().ToLower().Trim() + "\"><a href=\"#" + oDv_syscomments[k][sysobjects._XTYPE].ToString().ToLower().Trim() + "_" + oDv_syscomments[k][sysobjects._NAME].ToString() + "\">" + oDv_syscomments[k][sysobjects._NAME].ToString() + "</a></li>";
                }
            }
            FileContent += "</ul>";

            FileContent += "<p>";
            int i = 0;
            while (sysobjects.Next())
            {
                #region 表备份
                Com.Data.SqlServer.Entity.SYSCOLUMNS syscolumns = new Com.Data.SqlServer.Entity.SYSCOLUMNS();
                syscolumns.Database_Reader = DataBaseOwner;
                syscolumns.DataBase = DataBase_Name;
                syscolumns.ID = int.Parse(sysobjects.ID_ToString);
                syscolumns.OrderBy = " COLID ";
                syscolumns.Distinct = false;
                syscolumns.SelectColumns = new string[] { syscolumns._ID, syscolumns._NAME, syscolumns._XTYPE, syscolumns._LENGTH, syscolumns._COLID, syscolumns._ISNULLABLE, syscolumns._CDEFAULT };
                DataTable oDt = syscolumns.Select();
                string columns = "";
                string datatypes = "";
                string lengths = "";
                string descriptions = "";
                string isnullables = "";
                string defaults = "";
                string identity = "";
                foreach (DataRow oDr in oDt.Rows)
                {

                    columns += oDr["NAME"].ToString() + ",";
                    Com.Data.SqlServer.Entity.SYSTYPES systypes = new Com.Data.SqlServer.Entity.SYSTYPES();
                    systypes.Database_Reader = DataBaseOwner;
                    systypes.DataBase = DataBase_Name;
                    systypes.XTYPE = byte.Parse(oDr[systypes._XTYPE].ToString().ToUpper());
                    systypes.SelectColumns = new string[] { systypes._NAME };
                    systypes.SelectTop1();
                    datatypes += systypes.NAME + ",";
                    lengths += oDr["LENGTH"].ToString() + ",";

                    Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES SYSPROPERTIES = new Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES();
                    SYSPROPERTIES.Database_Reader = DataBaseOwner;
                    SYSPROPERTIES.DataBase = DataBase_Name;
                    SYSPROPERTIES.TableOwner = "sys";
                    SYSPROPERTIES.MAJOR_ID = int.Parse(oDr["ID"].ToString());
                    SYSPROPERTIES.MINOR_ID = int.Parse(oDr["COLID"].ToString());
                    SYSPROPERTIES.SelectTop1();
                    descriptions += (SYSPROPERTIES.VALUE == "" ? " " : SYSPROPERTIES.VALUE.Replace(",", "，")) + ",";
                    isnullables += oDr["ISNULLABLE"].ToString() + ",";

                    Com.Data.SqlServer.Entity.SYSCOMMENTS SYSCOMMENTS = new Com.Data.SqlServer.Entity.SYSCOMMENTS();
                    SYSCOMMENTS.Database_Reader = DataBaseOwner;
                    SYSCOMMENTS.DataBase = DataBase_Name;
                    SYSCOMMENTS.ID = int.Parse(oDr["CDEFAULT"].ToString());
                    SYSCOMMENTS.SelectColumns = new string[] { "TEXT" };
                    SYSCOMMENTS.SelectTop1();
                    string cdefault = SYSCOMMENTS.TEXT;
                    if (SYSCOMMENTS.TEXT.Trim() == "")
                    {
                        cdefault = " ";
                    }
                    else
                    {
                        cdefault = SYSCOMMENTS.TEXT;
                    }
                    defaults += cdefault + ",";
                    if (string.IsNullOrEmpty(identity))
                    {
                        string isIdentity = "0";
                        isIdentity = Convert.ToString(DataBaseOwner.ExecuteScalar(CommandType.Text, "SELECT COLUMNPROPERTY(  OBJECT_ID('" + sysobjects.NAME + "'),'" + oDr["NAME"].ToString() + "','IsIdentity')").ToString());
                        if (isIdentity == "1")
                        {
                            identity = oDr["NAME"].ToString().ToUpper();
                        }
                    }

                }

                DataTable oDt1 = DataBaseOwner.ExecuteDataSet(CommandType.Text, "EXEC " + DataBase_Name + "..sp_pkeys @table_name='" + sysobjects.NAME + "'").Tables[0];
                string Keys = "";
                foreach (DataRow oDr in oDt1.Rows)
                {
                    Keys += oDr["COLUMN_NAME"].ToString().ToUpper() + ",";
                }

                Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES SYSPROPERTIES1 = new Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES();
                SYSPROPERTIES1.Database_Reader = DataBaseOwner;
                SYSPROPERTIES1.DataBase = DataBase_Name;
                SYSPROPERTIES1.TableOwner = "sys";
                SYSPROPERTIES1.JoinSql = " INNER JOIN " + DataBase_Name + "..sysobjects sysobjects ON MAJOR_ID = sysobjects.id ";
                SYSPROPERTIES1.WhereSql = " (MINOR_ID = 0) and sysobjects.name='" + sysobjects.NAME + "' ";
                SYSPROPERTIES1.SelectColumns = new string[] { SYSPROPERTIES1._VALUE };
                SYSPROPERTIES1.SelectTop1();

                FileContent += "</p><p class=\"" + ((i % 2) == 0 ? "b" : "") + "\">";
                if (!string.IsNullOrEmpty(SYSPROPERTIES1.VALUE))
                {

                    FileContent += "</p><p class=\"" + ((i % 2) == 0 ? "b" : "") + "\">/*" + SYSPROPERTIES1.VALUE + @"*/
                    ";
                }
                FileContent += "<a id=\"u_" + sysobjects.NAME + "\"></a>" + CreateTableCoder.CetSql(sysobjects.NAME, columns.TrimEnd(','), datatypes.ToUpper().TrimEnd(','), lengths.TrimEnd(','), isnullables.TrimEnd(','), defaults.TrimEnd(','), descriptions.TrimEnd(','), Keys.TrimEnd(','), identity);
                i++;
                #endregion
            }

            //Com.Data.SqlServer.Entity.SYSCOMMENTS syscomments = new Com.Data.SqlServer.Entity.SYSCOMMENTS();
            //syscomments.Database_Reader = DataBaseOwner;
            //syscomments.DataBase = DataBase_Name;
            //syscomments.SelectColumns = new string[] { syscomments._COLID, syscomments._TEXT };
            //syscomments.OrderBy = " " + syscomments._ID + ", " + syscomments._COLID + " ";
            //syscomments.Distinct = false;
            //syscomments.WhereSql = " " + syscomments._ID + " IN  (SELECT object_id(name) FROM dbo.sysobjects  WHERE xtype in('FN','TR','V','P','IF','TF')) ";
            //syscomments.Select();


            i = 0;
            int rowidex = 0;
            int pre_colid = 2;
            while (syscomments.Next())
            {
                #region 存储过程、视图、函数、触发器 备份
                DataRow oDr_syscomments = oDt_syscomments.Rows[rowidex];
                int colid = int.Parse(syscomments.COLID_ToString);
                if (colid <= pre_colid)
                {

                    FileContent += "<br/>GO<br/></p><p class=\"" + ((i % 2) == 0 ? "b" : "") + "\">";
                    i++;
                }
                if (colid == 1)
                {
                    FileContent += "<a id=\"" + oDr_syscomments[sysobjects._XTYPE].ToString().ToLower().Trim() + "_" + oDr_syscomments[sysobjects._NAME].ToString() + "\"></a>";
                }
                FileContent += System.Web.HttpUtility.HtmlEncode(syscomments.TEXT).Replace("\t", "&nbsp;").Replace("\r\n", "<br/>");
                pre_colid = colid;
                rowidex++;
                #endregion
            }

            FileContent += "</p></body></html>";
            #endregion
            return FileContent;
        }
    }
}
