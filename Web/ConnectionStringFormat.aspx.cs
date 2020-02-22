using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft;

namespace Web
{
    public partial class ConnectionStringFormat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnSubmit_Click(this, null);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtXml.Text.Trim()))
            {
                this.txtJson.Text = "";
                return;
            }

            DataTable oDt = null;
            try
            {
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(this.txtXml.Text);
                oDt = Com.Xml.XmlUtil.GetDataSetFromXmlString("<?xml version=\"1.0\" encoding=\"utf-8\"?><appSettings>" + xmldoc.SelectSingleNode("configuration").SelectSingleNode("appSettings").InnerXml + "</appSettings>").Tables[0];
            }
            catch
            {
                oDt = Com.Xml.XmlUtil.GetDataSetFromXmlString("<?xml version=\"1.0\" encoding=\"utf-8\"?><appSettings>" + this.txtXml.Text + "</appSettings>").Tables[0];
            }
            string formatstring = @"
    " + "\"" + @"{key}" + "\"" + @": {
        " + "\"" + @"DBname" + "\"" + @": " + "\"" + @"{DBname}" + "\"" + @",
        " + "\"" + @"DBtype" + "\"" + @": " + "\"" + @"{DBtype}" + "\"" + @",
        " + "\"" + @"DBaddr" + "\"" + @": " + "\"" + @"{DBaddr}" + "\"" + @",
        " + "\"" + @"DBport" + "\"" + @": " + "\"" + @"{DBport}" + "\"" + @",
        " + "\"" + @"DBusertype" + "\"" + @": " + "\"" + @"{DBusertype}" + "\"" + @",
        " + "\"" + @"DBusername" + "\"" + @": " + "\"" + @"{DBusername}" + "\"" + @",
        " + "\"" + @"DBpw" + "\"" + @": " + "\"" + @"{DBpw}" + "\"" + @"
    }";
            string jsonText = @"{
            ";
            ArrayList arr = new ArrayList();
            foreach (DataRow oDr in oDt.Rows)
            {
                string Key = oDr["key"].ToString().ToLower();
                string[] Values = oDr["value"].ToString().Split(';');

                if (arr.Contains(Key))
                {
                    continue;
                }
                string jsonstring = formatstring.Replace("{key}", Key);
                int Count = 0;
                foreach (string Value in Values)
                {
                    if (!string.IsNullOrEmpty(Value.Trim()))
                    {
                        string[] vals = Value.TrimEnd().TrimStart().Split('=');
                        string name = vals[0].ToLower().Replace(" ", "");
                        if (name == "datasource" || name == "server")
                        {
                            jsonstring = jsonstring.Replace("{DBaddr}", vals[1]);
                            Count++;
                        }
                        else if (name == "port")
                        {
                            jsonstring = jsonstring.Replace("{DBport}", vals[1]);
                            Count++;
                        }
                        else if (name == "database" || name == "initialcatalog")
                        {
                            jsonstring = jsonstring.Replace("{DBname}", vals[1]);
                            Count++;
                        }
                        else if (name == "uid" || name == "userid")
                        {
                            jsonstring = jsonstring.Replace("{DBusername}", vals[1]);
                            Count++;
                        }
                        else if (name == "pwd" || name == "password")
                        {
                            jsonstring = jsonstring.Replace("{DBpw}", vals[1]);
                            Count++;
                        }
                    }
                }
                if (Count >= 3)
                {
                    string DBtype = "MSsql";
                    //判断是否是sqlserver
                    //try
                    //{
                    //    SqlConnection sqlconnection = new SqlConnection(oDr["value"].ToString());
                    //    SqlCommand sqlcommand = new SqlCommand("SELECT GETDATE();", sqlconnection);
                    //    sqlconnection.Open();
                    //    sqlcommand.ExecuteScalar();
                    //    sqlcommand.Clone();
                    //    sqlconnection.Close();
                    //    sqlcommand.Dispose();
                    //    sqlconnection.Dispose();
                    //    DBtype = "MSsql";
                    //}
                    //catch
                    //{
                    //    DBtype = "Mysql";
                    //}
                    if (oDr["value"].ToString().ToLower().Replace(" ", "").IndexOf("port=") > -1)
                    {
                        DBtype = "Mysql";
                    }
                    if (Key.IndexOf("read") > -1)
                    {
                        jsonstring = jsonstring.Replace("{DBusertype}", "readonly");
                    }
                    else
                    {
                        jsonstring = jsonstring.Replace("{DBusertype}", "write");
                    }
                    jsonstring = jsonstring.Replace("{DBtype}", DBtype);
                    jsonstring = jsonstring.Replace("{DBport}", "1433");
                    jsonText += jsonstring + @",";
                    arr.Add(Key);
                }
            }
            jsonText = jsonText.TrimEnd(',') + @"
}";
            this.txtJson.Text = jsonText;
        }

        protected void btnSubmit0_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtXml.Text.Trim()))
            {
                this.txtJson.Text = "";
                return;
            }

            DataTable oDt = null;
            try
            {
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(this.txtXml.Text);
                oDt = Com.Xml.XmlUtil.GetDataSetFromXmlString("<?xml version=\"1.0\" encoding=\"utf-8\"?><appSettings>" + xmldoc.SelectSingleNode("configuration").SelectSingleNode("appSettings").InnerXml + "</appSettings>").Tables[0];
            }
            catch
            {
                oDt = Com.Xml.XmlUtil.GetDataSetFromXmlString("<?xml version=\"1.0\" encoding=\"utf-8\"?><appSettings>" + this.txtXml.Text + "</appSettings>").Tables[0];
            }

            ArrayList arr = new ArrayList();
            string jsonText = "";
            foreach (DataRow oDr in oDt.Rows)
            {
                string Key = oDr["key"].ToString().ToLower();
                string Value = oDr["value"].ToString();

                if (arr.Contains(Key) || jsonText.IndexOf(Value) > -1)
                {
                    continue;
                }
                if (Value.ToLower().StartsWith("http"))
                {
                    jsonText += Value + @"
";
                    arr.Add(Key);
                }

            }

            this.txtJson.Text = jsonText;
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            Newtonsoft.Json.Linq.JObject jobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(this.txtXml.Text);
            string tr_Format = "<tr><td>{website}</td><td>{key}</td><td>{DBname}</td><td>{DBtype}</td><td>{DBaddr}</td><td>{DBport}</td><td>{DBusertype}</td><td>{DBusername}</td><td>{DBpw}</td></tr>";//mysql的端口号用分号隔开

            string html = "<table border=1>";
            html += tr_Format.Replace("{", "").Replace("}", "");
            foreach (Newtonsoft.Json.Linq.JProperty jo in (Newtonsoft.Json.Linq.JToken)jobject)
            {

                string tr = tr_Format;
                tr = System.Text.RegularExpressions.Regex.Replace(tr, "{website}", this.txtWebSite.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase);//不区分大小写就能替换
                tr = System.Text.RegularExpressions.Regex.Replace(tr, "{key}", jo.Name, System.Text.RegularExpressions.RegexOptions.IgnoreCase);//不区分大小写就能替换
                Newtonsoft.Json.Linq.JToken jobject1 = (Newtonsoft.Json.Linq.JToken)Newtonsoft.Json.JsonConvert.DeserializeObject(jobject[jo.Name].ToString());
                foreach (Newtonsoft.Json.Linq.JProperty jo1 in jobject1)
                {
                    tr = System.Text.RegularExpressions.Regex.Replace(tr, "{" + jo1.Name + "}", jo1.Value.ToString().TrimEnd('"').TrimStart('"'), System.Text.RegularExpressions.RegexOptions.IgnoreCase);//不区分大小写就能替换
                }
                html += tr;
            }
            html += "</table>";
            this.Literal1.Text = html;

        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            #region 先拼出DataTable
            DataTable oDt = new DataTable();
            string[] rows = this.txtXml.Text.Split("\r\n".ToCharArray());
            string[] columns = rows[0].Split("\t".ToCharArray());
            int website_index = -1;
            int key_index = -1;
            int index = 0;
            foreach (string column in columns)
            {
                if (column.ToLower() == "website")
                {
                    website_index = index;
                }
                else if (column.ToLower() == "key")
                {
                    key_index = index;
                }
                oDt.Columns.Add(new DataColumn(column, typeof(string)));
                index++;
            }
            for (int i = 1; i < rows.Length; i++)
            {
                if (!string.IsNullOrEmpty(rows[i].Trim()))
                {
                    string[] cells = rows[i].Split("\t".ToCharArray());
                    DataRow[] oDrs = oDt.Select("website='" + cells[website_index].ToString() + "' and key='" + cells[key_index].ToString() + "'");
                    if (oDrs == null || oDrs.Length == 0)
                    {
                        DataRow oDr = oDt.NewRow();
                        int j = 0;
                        foreach (string cell in cells)
                        {
                            oDr[j] = cell;
                            j++;
                        }
                        oDt.Rows.Add(oDr);
                        oDt.AcceptChanges();
                    }
                }
            }

            ArrayList websites = new ArrayList();
            foreach (DataRow oDr in oDt.Rows)
            {
                if (!websites.Contains(oDr["website"].ToString()))
                {
                    websites.Add(oDr["website"].ToString());
                }
            }
            #endregion



            #region 拼Json串
            string jsonText = "";
            for (int i = 0; i < websites.Count; i++)
            {
                string jsonText_website = "";
                string website = websites[i].ToString();

                string formatstring = @"
    " + "\"" + @"{key}" + "\"" + @": {
        " + "\"" + @"DBname" + "\"" + @": " + "\"" + @"{DBname}" + "\"" + @",
        " + "\"" + @"DBtype" + "\"" + @": " + "\"" + @"{DBtype}" + "\"" + @",
        " + "\"" + @"DBaddr" + "\"" + @": " + "\"" + @"{DBaddr}" + "\"" + @",
        " + "\"" + @"DBport" + "\"" + @": " + "\"" + @"{DBport}" + "\"" + @",
        " + "\"" + @"DBusertype" + "\"" + @": " + "\"" + @"{DBusertype}" + "\"" + @",
        " + "\"" + @"DBusername" + "\"" + @": " + "\"" + @"{DBusername}" + "\"" + @",
        " + "\"" + @"DBpw" + "\"" + @": " + "\"" + @"{DBpw}" + "\"" + @"
    }";
                jsonText_website += @"{
            ";
                DataRow[] oDrs = oDt.Select("website='" + website + "'");
                foreach (DataRow oDr in oDrs)
                {
                    string jsonstring = formatstring;
                    foreach (DataColumn oDc in oDt.Columns)
                    {
                        jsonstring = jsonstring.Replace("{" + oDc.ColumnName + "}", oDr[oDc.ColumnName].ToString());
                    }
                    jsonText_website += jsonstring + @",";
                }
                jsonText_website = jsonText_website.TrimEnd(',') + @"
}";
                string filepath = @"d:\cfgfiles\" + website + @"\dbcfg.conf";
                Com.File.FileUtil.FileCreate(filepath, 1);
                Com.File.FileUtil.AppendFileContent(filepath, jsonText_website);
                jsonText += @"

------------------------------------------------------------" + website + @"----------------------------------------------------------------

" + jsonText_website;
            }
            this.txtJson.Text = jsonText;
            #endregion

        }

        protected void btnSubmit3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtXml.Text.Trim()))
            {
                this.txtJson.Text = "";
                return;
            }

            DataTable oDt = null;
            try
            {
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(this.txtXml.Text);
                oDt = Com.Xml.XmlUtil.GetDataSetFromXmlString("<?xml version=\"1.0\" encoding=\"utf-8\"?><appSettings>" + xmldoc.SelectSingleNode("configuration").SelectSingleNode("appSettings").InnerXml + "</appSettings>").Tables[0];
            }
            catch
            {
                oDt = Com.Xml.XmlUtil.GetDataSetFromXmlString("<?xml version=\"1.0\" encoding=\"utf-8\"?><appSettings>" + this.txtXml.Text + "</appSettings>").Tables[0];
            }
            string formatstring = @"
{key}={value}";
            string apolloText = @"
            ";
            ArrayList arr = new ArrayList();
            foreach (DataRow oDr in oDt.Rows)
            {
                string Key = oDr["key"].ToString();
                string Value = oDr["value"].ToString();

                if (arr.Contains(Key))
                {
                    continue;
                }
                string apollostring = formatstring.Replace("{key}", Key).Replace("{value}", Value);
                apolloText += apollostring;
            }
            this.txtJson.Text = apolloText;
        }

        protected void btnSubmit4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtXml.Text.Trim()) || string.IsNullOrEmpty(this.txtTemplate.Text.Trim()))
            {
                this.txtJson.Text = "";
                return;
            }

            string CodeText = "";
            string[] items = this.txtXml.Text.Split(',');
            if (items != null && items.Length > 0)
            {
                foreach (string item in items)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        string[] paras = item.Split(' ');
                        int i = 0;
                        string formatstring = this.txtTemplate.Text;
                        foreach (string para in paras)
                        {
                            formatstring = formatstring.Replace("{" + i.ToString() + "}", para);
                            i++;
                        }
                        CodeText += @"
" + formatstring + @"
";
                    }
                }
            }

            this.txtJson.Text = CodeText;
        }
    }
}