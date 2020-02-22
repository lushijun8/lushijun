using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data; 

namespace Com.Json
{
    public class Convert
    {
        #region dataTable转换成Json格式
        /// <summary>  
        /// dataTable转换成Json格式  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTable2Json(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(dt.TableName);
            jsonBuilder.Append("\":");
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        #endregion dataTable转换成Json格式
        #region DataSet转换成Json格式
        /// <summary>  
        /// DataSet转换成Json格式  
        /// </summary>  
        /// <param name="ds">DataSet</param> 
        /// <returns></returns>  
        public static string Dataset2Json(DataSet ds)
        {
            StringBuilder json = new StringBuilder();

            foreach (DataTable dt in ds.Tables)
            {
                json.Append("{\"");
                json.Append(dt.TableName);
                json.Append("\":");
                json.Append(DataTable2Json(dt));
                json.Append("}");
            } return json.ToString();
        }
        #endregion

        /// <summary>
        /// Msdn
        /// </summary>
        /// <param name="jsonName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(string jsonName, DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }
        /// <summary>   
        /// 根据Json返回DateTable,JSON数据格式如:   
        /// {table:[{column1:1,column2:2,column3:3},{column1:1,column2:2,column3:3}]}   
        /// items:{"2750884":{clicknum:"50",title:"鲍鱼",href:"/shop/E06B14B40110/dish/2750884#menu",desc:"<br/>",src:"15f38721-49da-48f0-a283-8057c621b472.jpg",price:78.00,units:"",list:[],joiner:""}}
        /// </summary>   
        /// <param name="strJson">Json字符串</param>   
        /// <returns></returns>   
        public static DataTable JsonToDataTable(string strJson)
        {
            //取出表名   
            //var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            var rg = new Regex(@"([^:])+(?=:\{)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            try
            {
                //去除表名   
                //strJson = strJson.Substring(strJson.IndexOf("{") + 1);
                //strJson = strJson.Substring(0, strJson.IndexOf("}"));

                //获取数据   
                //rg = new Regex(@"(?<={)[^}]+(?=})");
                rg = new Regex(@"(?<={)[^}]+(?=})");

                System.Text.RegularExpressions.MatchCollection mc = rg.Matches(strJson);
                for (int i = 0; i < mc.Count; i++)
                {
                    string strRow = mc[i].Value;
                    string[] strRows = strRow.Split(',');

                    //创建表   
                    if (tb == null)
                    {
                        tb = new DataTable();
                        tb.TableName = strName;
                        foreach (string str in strRows)
                        {
                            var dc = new DataColumn();
                            string[] strCell = str.Split(':');
                            dc.ColumnName = strCell[0];
                            tb.Columns.Add(dc);
                        }
                        tb.AcceptChanges();
                    }

                    //增加内容   
                    DataRow dr = tb.NewRow();
                    for (int r = 0; r < strRows.Length; r++)
                    {
                        //dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                        dr[r] = strRows[r];
                    }
                    tb.Rows.Add(dr);
                    tb.AcceptChanges();
                }
            }
            catch
            {
                tb = null;
            }
            return tb;
        }

    }
}