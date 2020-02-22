using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;
using Com.Common;
using Com.File;
using System.Text.RegularExpressions;
namespace Com.Web
{
    public class PageUtil
    {
        public PageUtil()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static string SafeSql(string Querystring)
        {
            string Value = Querystring;
            Value = Regex.Replace(Value, "insert", "ｉnsert", RegexOptions.IgnoreCase);
            Value = Regex.Replace(Value, "update", "ｕpdate", RegexOptions.IgnoreCase);
            Value = Regex.Replace(Value, "delete", "ｄelete", RegexOptions.IgnoreCase);
            Value = Regex.Replace(Value, "drop", "ｄrop", RegexOptions.IgnoreCase);
            Value = Regex.Replace(Value, "declare", "ｄeclare", RegexOptions.IgnoreCase);
            Value = Regex.Replace(Value, "exec", "ｅxec", RegexOptions.IgnoreCase);
            return Value;
        }
        /// <summary>
        /// 从Session获得参数
        /// </summary>
        /// <param name="oSession"></param>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public static string GetParaValueFromSession(HttpSessionState oSession, string paraName)
        {
            string text1 = null;
            if (oSession[paraName] == null)
                return null;
            else
                text1 = oSession[paraName].ToString();
            return SafeSql(text1);
        }
        /// <summary>
        /// 从QueryString获得参数
        /// </summary>
        /// <param name="oRequest"></param>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public static string GetParaValueFromQueryString(HttpRequest oRequest, string paraName)
        {
            string text1 = null;
            if (oRequest.QueryString[paraName] == null)
                return null;
            else
                text1 = oRequest.QueryString[paraName].ToString();
            return SafeSql(text1);
        }
        /// <summary>
        /// 从Form获得参数
        /// </summary>
        /// <param name="oRequest"></param>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public static string GetParaValueFromForm(HttpRequest oRequest, string paraName)
        {
            string text1 = null;
            if (oRequest.Form[paraName] == null)
                return null;
            else
                text1 = oRequest.Form[paraName].ToString();
            return SafeSql(text1);
        }
        /// <summary>
        /// 从Cookie获得参数
        /// </summary>
        /// <param name="oRequest"></param>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public static string GetParaValueFromCookie(HttpRequest oRequest, string paraName)
        {
            string text1 = null;
            if (oRequest.Cookies[paraName] == null)
                return null;
            else
                text1 = oRequest.Cookies[paraName].Value;
            return SafeSql(text1);
        }
        /// <summary>
        /// 从页面ViewState获得参数的值
        /// </summary>
        /// <param name="oViewState"></param>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public static string GetParaValueFromViewState(StateBag oViewState, string paraName)
        {
            string text1 = null;
            if (oViewState[paraName] == null)
                return null;
            else
                text1 = oViewState[paraName].ToString();
            return text1;
        }

        /// <summary>
        /// 从项目WebConfig获得参数的值
        /// </summary>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public static string GetParaValueFromWebConfig(string paraName)
        {
            string text1 = null;
            if (Com.Config.ConfigUtil.GetValueFromWebConfig(paraName) == "")
                return null;
            else
                text1 = Com.Config.ConfigUtil.GetValueFromWebConfig(paraName);
            return text1;
        }
        public static void SetPageHeader(Page ObjPage)
        {
            bool flag1 = true;
            string text1 = "60";
            try
            {
                flag1 = Convert.ToBoolean(int.Parse(ConfigurationSettings.AppSettings.Get("IsPageCache")));
                text1 = ConfigurationSettings.AppSettings.Get("PageTimeOut");
            }
            catch (Exception exception1)
            {
                FileLog.WriteLog("\u9875\u9762\u7f13\u5b58\u8bbe\u7f6e", exception1.Message);
                return;
            }
            if (!flag1)
            {
                ObjPage.Response.Buffer = true;
                ObjPage.Response.ExpiresAbsolute = DateTime.Today.AddMilliseconds(-1);
                ObjPage.Response.Expires = 0;
                ObjPage.Response.CacheControl = "no-cache";
                ObjPage.Response.CacheControl = "private";
            }
        }

        public static int SetPageReadOnly(Page ObjPage)
        {
            int num1 = 0;
            for (int num2 = 0; num2 < ObjPage.Controls.Count; num2++)
            {
                if (ObjPage.Controls[num2].GetType().Name.Equals("HtmlForm"))
                {
                    HtmlForm form1 = (HtmlForm)ObjPage.Controls[num2];
                    for (int num3 = 0; num3 < form1.Controls.Count; num3++)
                    {
                        try
                        {
                            form1.Controls[num3].GetType().GetProperty("ReadOnly").SetValue(form1.Controls[num3], true, null);
                            num1++;
                        }
                        catch (Exception exception1)
                        {
                            string text1 = exception1.Message;
                        }
                        try
                        {
                            form1.Controls[num3].GetType().GetProperty("Disable").SetValue(form1.Controls[num3], true, null);
                            num1++;
                        }
                        catch (Exception exception2)
                        {
                            string text2 = exception2.Message;
                        }
                    }
                    break;
                }
            }
            return num1;
        }

        public static void SetReadOnlyTextColor(Page ObjPage)
        {
            for (int num1 = 0; num1 < ObjPage.Controls.Count; num1++)
            {
                if (ObjPage.Controls[num1].GetType().Name.Equals("HtmlForm"))
                {
                    HtmlForm form1 = (HtmlForm)ObjPage.Controls[num1];
                    for (int num2 = 0; num2 < form1.Controls.Count; num2++)
                    {
                        if (form1.Controls[num2] is HtmlInputText)
                        {
                            HtmlInputText text1 = (HtmlInputText)form1.Controls[num2];
                            if (text1.Attributes["readOnly"] != null)
                            {
                                text1.Attributes.Add("class", "ReadOnlyShow");
                            }
                            if (text1.Attributes["disabled"] != null)
                            {
                                text1.Attributes.Add("class", "ReadOnlyShow");
                            }
                        }
                        if (form1.Controls[num2] is TextBox)
                        {
                            TextBox box1 = (TextBox)form1.Controls[num2];
                            if (box1.ReadOnly)
                            {
                                box1.CssClass = "ReadOnlyShow";
                            }
                            if (!box1.Enabled)
                            {
                                box1.CssClass = "ReadOnlyShow";
                            }
                        }
                    }
                }
            }
        }


    }
}
