using System;
using System.Data;
using System.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace Business
{
    /// <summary>
    /// 异常处理类
    /// </summary>
    public class HandleException
    {

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="policyName"></param>
        public static void Handle(Exception ex, string policyName)
        {
            if (!(ex is System.Threading.ThreadAbortException))
            {
                try
                {
                    string url = "";
                    string IP = "0.0.0.0";
                    try
                    {
                        System.Web.HttpContext http = System.Web.HttpContext.Current;
                        url = "";
                        //url = "\r\n;<br>Url:" + http.Request.Url.ToString();
                        url += "\r\n;<br>UrlReferrer:" + http.Request.UrlReferrer.ToString();
                        url += "\r\n;<br>RawUrl:" + http.Request.RawUrl.ToString();
                        url += "\r\n;<br>HTTP_X_FORWARDED_FOR:" + http.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        url += "\r\n;<br>REMOTE_ADDR:" + http.Request.ServerVariables["REMOTE_ADDR"];
                        url += "\r\n;<br>Request.Form:" + http.Request.Form.ToString();
                        IP = http.Request.UserHostAddress;
                    }
                    catch { }
                    string Sql = "INSERT INTO PAY_LOG(UserType, UserID, UserName, RealName, ItemType, ItemID, Description, IP, AddedTime) " +
                        " values(0, 0, '', '', 0, 0, @Description, '" + IP + "', getdate())";
                    DBCommandWrapper cmd = Com.Data.DatabaseOperater.DataBaseWriter.GetSqlStringCommandWrapper(Sql);
                    cmd.AddParameter("@Description", DbType.String, 1000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, policyName + ";" + ex.Source + ";" + ex.ToString() + url);
                }
                catch { }
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        public static void LogException(Exception ex)
        {
            if (!(ex is System.Threading.ThreadAbortException))
            {
                try
                {
                    Handle(ex, "Log Policy");
                }
                catch { }
            }
        }
    }
}
