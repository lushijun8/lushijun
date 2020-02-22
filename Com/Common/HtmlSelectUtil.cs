
using System;
using System.Data;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Configuration;
using Com.Data;
using Com.Config;

namespace Com.Common
{
    /// <summary>
    /// HtmlSelectUtil 的摘要说明。
    /// </summary>
    public class HtmlSelectUtil
    {

        public static string Findername;
        public static string IDColum;
        public static string IDView;
        public static string NameColum;
        public static string NameView;
        public static string OrderBy;
        public static string Database;
        public static string TableName;
        public static string Wherestr;

        public HtmlSelectUtil()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        static HtmlSelectUtil()
        {
            HtmlSelectUtil.Findername = "";
            HtmlSelectUtil.TableName = "";
            HtmlSelectUtil.Database = "";
            HtmlSelectUtil.IDColum = "";
            HtmlSelectUtil.NameColum = "";
            HtmlSelectUtil.Wherestr = "";
            HtmlSelectUtil.IDView = "";
            HtmlSelectUtil.NameView = "";
            HtmlSelectUtil.OrderBy = "";
        }

        public static DataTable GetDictionaryObjs()
        {
            return HtmlSelectUtil.GetDictionaryObjs("", "");
        }
        public static DataTable GetDictionaryObjs(string FinderName, string FilterStr)
        {
            return HtmlSelectUtil.GetDictionaryObjs(FinderName, FilterStr, "");
        }
        public static DataTable GetDictionaryObjs(string FinderName, string FilterStr, string WhereSql)
        {
            DataTable datatable1 = null;
            #region 读取缓存文件
            string CacheName = Com.Common.EncDec.PasswordEncrypto(HtmlSelectUtil.Findername + WhereSql);
            if (Com.Config.SystemConfig.CacheTime > 0)
            {
                datatable1 = Com.Data.Cache.GetDataTableFromCache(Com.Config.SystemConfig.Caching, CacheName, Com.Config.SystemConfig.CacheTime);
                if (datatable1 != null)
                {
                    return datatable1;
                }
            }
            #endregion

            if (FinderName != "")
            {
                HtmlSelectUtil.TableName = "";
                HtmlSelectUtil.SetHtmlObj(FinderName, "0");
            }
            StringBuilder builder1 = new StringBuilder();
            string[] textArray1 = new string[5] { " Select ", HtmlSelectUtil.IDColum, " as code,", HtmlSelectUtil.NameColum, " as value" };
            builder1.Append(string.Concat(textArray1));

            builder1.Append(" From ");
            builder1.Append(HtmlSelectUtil.TableName);
            builder1.Append(" where 1=1 ");
            builder1.Append(HtmlSelectUtil.Wherestr);
            if (WhereSql.Trim() != "")
            {
                builder1.Append(" AND " + WhereSql + " ");
            }
            if (FilterStr != "")
            {
                string[] textArray2 = new string[5] { " and (", HtmlSelectUtil.IDColum, " like '%", FilterStr, "%'" };
                builder1.Append(string.Concat(textArray2));
                string[] textArray3 = new string[5] { " or ", HtmlSelectUtil.NameColum, " like '%", FilterStr, "%')" };
                builder1.Append(string.Concat(textArray3));
            }
            builder1.Append("  ORDER BY " + HtmlSelectUtil.OrderBy);
            datatable1 = null;
            datatable1 = Com.Data.DatabaseOperater.DataBaseReader.ExecuteDataSet(CommandType.Text, builder1.ToString()).Tables[0];


            HtmlSelectUtil.Wherestr = "";

            #region 写入缓存文件
            if (Com.Config.SystemConfig.CacheTime > 0)//如果记录数超过100,或者超过512K,或者文件缓存时间等于0,则不用缓存文件
            {
                Com.Data.Cache.SetDataTableToCache(Com.Config.SystemConfig.Caching, CacheName, datatable1, Com.Config.SystemConfig.CacheTime);
            }
            #endregion
            return datatable1;
        }
        private static string GetWhereFromOuterAndInner(string WhereStrFromFinder)
        {
            if (WhereStrFromFinder.Trim() != "")
            {
                string text1 = "and " + WhereStrFromFinder.Trim().TrimStart("and ".ToCharArray());
                HtmlSelectUtil.Wherestr = text1 + HtmlSelectUtil.Wherestr.Replace(text1, "");
            }
            if (!HtmlSelectUtil.Wherestr.Trim().ToLower().StartsWith("and"))
            {
                HtmlSelectUtil.Wherestr = "";
            }
            return HtmlSelectUtil.Wherestr;
        }

        public static void SetComboxList(object ObjCombobox, string FinderName)
        {
            HtmlSelectUtil.SetComboxList(ObjCombobox, FinderName, false, null, "0");
        }
        public static void SetComboxList(object ObjCombobox, string FinderName, bool All)
        {
            HtmlSelectUtil.SetComboxList(ObjCombobox, FinderName, All, null, "0");
        }
        private static void SetComboxList(object ObjCombobox, string FinderName, bool All, string SelectedValue, string ShowType)
        {
            SetComboxList(ObjCombobox, FinderName, All, SelectedValue, ShowType, "");
        }
        public static void SetComboxList(object ObjCombobox, string FinderName, bool All, string SelectedValue, string ShowType, string WhereSql)
        {
            HtmlSelectUtil.Findername = FinderName;
            HtmlSelectUtil.TableName = "";
            HtmlSelectUtil.SetHtmlObj(FinderName, ShowType);
            DataTable set1 = HtmlSelectUtil.GetDictionaryObjs("", "", WhereSql);
            if (ObjCombobox is DropDownList)
            {
                DropDownList list1 = (DropDownList)ObjCombobox;
                list1.DataSource = set1;
                list1.DataTextField = "Value";
                list1.DataValueField = "Code";
                list1.DataBind();
                if (All)
                {
                    list1.Items.Insert(0, new ListItem("-选择-", ""));
                }
                if (SelectedValue != null && list1.Items.FindByValue(SelectedValue) != null)
                {
                    list1.Items.FindByValue(SelectedValue).Selected = true;
                }
            }
            else if (ObjCombobox is HtmlSelect)
            {
                HtmlSelect select1 = (HtmlSelect)ObjCombobox;
                select1.DataSource = set1;
                select1.DataTextField = "Value";
                select1.DataValueField = "Code";
                select1.DataBind();
                if (All)
                {
                    select1.Items.Insert(0, new ListItem("-选择-", ""));
                }
                if (SelectedValue != null && select1.Items.FindByValue(SelectedValue) != null)
                {
                    select1.Value = SelectedValue;
                }
            }
            else if (ObjCombobox is ListBox)
            {
                ListBox box1 = (ListBox)ObjCombobox;
                box1.DataSource = set1;
                box1.DataTextField = "Value";
                box1.DataValueField = "Code";
                box1.DataBind();
                if (All)
                {
                    box1.Items.Insert(0, new ListItem("-选择-", ""));
                }
                if (SelectedValue != null && box1.Items.FindByValue(SelectedValue) != null)
                {
                    box1.Items.FindByValue(SelectedValue).Selected = true;
                }
            }
            else if (ObjCombobox is CheckBoxList)
            {
                CheckBoxList box1 = (CheckBoxList)ObjCombobox;
                box1.DataSource = set1;
                box1.DataTextField = "Value";
                box1.DataValueField = "Code";
                box1.DataBind();
                //				if (All)
                //				{
                //					box1.Items.Insert(0, new ListItem("-选择-", ""));
                //				}
                if (SelectedValue != null && box1.Items.FindByValue(SelectedValue) != null)
                {
                    box1.Items.FindByValue(SelectedValue).Selected = true;
                }
            }
            else if (ObjCombobox is RadioButtonList)
            {
                RadioButtonList box1 = (RadioButtonList)ObjCombobox;
                box1.DataSource = set1;
                box1.DataTextField = "Value";
                box1.DataValueField = "Code";
                box1.DataBind();
                //				if (All)
                //				{
                //					box1.Items.Insert(0, new ListItem("-选择-", ""));
                //				}
                if (SelectedValue != null && box1.Items.FindByValue(SelectedValue) != null)
                {
                    box1.Items.FindByValue(SelectedValue).Selected = true;
                }
            }
            HtmlSelectUtil.TableName = "";
            HtmlSelectUtil.Wherestr = "";
        }

        public static void SetComboxListByCommon(object ObjCombobox, string FinderName)
        {
            HtmlSelectUtil.SetComboxList(ObjCombobox, FinderName, false, null, "1");
        }

        public static void SetComboxListByCommon(object ObjCombobox, string FinderName, bool All)
        {
            HtmlSelectUtil.SetComboxList(ObjCombobox, FinderName, All, null, "1");
        }

        public static void SetComboxListByDefaultValue(object ObjCombobox, string FinderName, string SelectedValue)
        {
            HtmlSelectUtil.SetComboxList(ObjCombobox, FinderName, false, SelectedValue, "1");
        }

        public static void SetHashTableToHtmlSelect(Hashtable SetHashtable, HtmlSelect GetSelect)
        {
            HtmlSelectUtil.SetHashTableToHtmlSelect(SetHashtable, GetSelect, false);
        }

        public static void SetHashTableToHtmlSelect(Hashtable SetHashtable, HtmlSelect GetSelect, bool All)
        {
            IDictionaryEnumerator enumerator1 = SetHashtable.GetEnumerator();
            GetSelect.Items.Clear();
            if (All)
            {
                GetSelect.Items.Add(new ListItem("--\u8bf7\u9009\u62e9--", ""));
            }
            while (enumerator1.MoveNext())
            {
                GetSelect.Items.Add(new ListItem(enumerator1.Value.ToString(), enumerator1.Key.ToString()));
            }
        }

        public static void SetHtmlObj(string FinderName, string ShowType)
        {
            if (HtmlSelectUtil.TableName == "")
            {
                HtmlSelectUtil.SetHtmlObjFromXML(FinderName, ShowType);
            }
            //if (HtmlSelectUtil.TableName == "")
            //{
            //    HtmlSelectUtil.SetHtmlObjFromSimpleDict(FinderName, ShowType);
            //}
        }

        public static void SetHtmlObjFromSimpleDict(string FinderName, string ShowType)
        {
            if (SystemConfig.SecSimpleDictName == "")
            {
                return;
            }
            string[] textArray1 = new string[5] { "select Count(*) from ", SystemConfig.SecSimpleDictName, " where DictType='", FinderName, "'" };
            DataSet set1 = null;
            //if (HtmlSelectUtil.Database.ToUpper() == "CONFIG")
            //{
            set1 = Com.Data.DatabaseOperater.DataBaseReader.ExecuteDataSet(CommandType.Text, string.Concat(textArray1));
            //}
            //else if (HtmlSelectUtil.Database.ToUpper() == "ANNOUNCEID")
            //{
            //    set1 = Com.Data.DatabaseOperater.DataBaseReader .ExecuteDataSet(CommandType.Text, string.Concat(textArray1));
            //}
            if ((set1 == null) || (set1.Tables[0].Rows[0][0].ToString() == "0"))
            {
                return;
            }
            HtmlSelectUtil.IDView = "\u4ee3\u7801";
            HtmlSelectUtil.NameView = "\u503c";
            HtmlSelectUtil.TableName = SystemConfig.SecSimpleDictName;
            if (ShowType == "1")
            {
                HtmlSelectUtil.IDColum = "DictCode";
            }
            else
            {
                HtmlSelectUtil.IDColum = "DictName";
            }
            HtmlSelectUtil.NameColum = "DictName";
            string text1 = "and DictType= '" + FinderName + "'";
            if (HtmlSelectUtil.Wherestr != "")
            {
                HtmlSelectUtil.Wherestr = HtmlSelectUtil.Wherestr.Replace(text1, "") + " " + text1;
            }
            else
            {
                HtmlSelectUtil.Wherestr = text1;
            }

        }

        public static void SetHtmlObjFromXML(string FinderName, string ShowType)
        {
            XmlDocument document1 = new XmlDocument();
            string text1 = Com.Config.SystemConfig.FinderFilePath;
            document1.Load(text1);
            XmlNode node1 = document1.DocumentElement.SelectSingleNode("//root/node[@name='" + FinderName + "']");
            if (node1 == null)
            {
                return;
            }
            HtmlSelectUtil.IDView = node1.Attributes["idview"].Value;
            HtmlSelectUtil.NameView = node1.Attributes["nameview"].Value;
            HtmlSelectUtil.TableName = node1.Attributes["tablename"].Value;
            //HtmlSelectUtil.Database = node1.Attributes["database"].Value;
            HtmlSelectUtil.IDColum = node1.Attributes["idcolum"].Value;
            HtmlSelectUtil.NameColum = node1.Attributes["namecolum"].Value;
            HtmlSelectUtil.Wherestr = HtmlSelectUtil.GetWhereFromOuterAndInner(node1.Attributes["wherestr"].Value);
            if (node1.OuterXml.IndexOf("orderby") >= 0)
            {
                HtmlSelectUtil.OrderBy = node1.Attributes["orderby"].Value;
            }
            else
            {
                HtmlSelectUtil.OrderBy = " DICT_ORDER ASC ";
                //				HtmlSelectUtil.OrderBy = node1.Attributes["idcolum"].Value;
            }

        }
    }
}
