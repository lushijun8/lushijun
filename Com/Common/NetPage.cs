using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Com.Common
{
    //样式一  页次:2/2 总数:2 首页 上页 [1] [2] 下页 尾页 跳转
    public class NetPage
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex;

        /// <summary>
        /// 每页显示数据数
        /// </summary>
        public int PageSize = 50;
        /// <summary>
        /// 分页条显示页码数
        /// </summary>
        public int PageStep = 6;

        /// <summary>
        /// 数据条数
        /// </summary>
        public long ModelCount;

        /// <summary>
        /// 语言（"EN"和""CN）
        /// </summary>
        public string Lang = "CN";

        /// <summary>
        /// 跳转页面
        /// </summary>
        public string Url;


        public string PagerHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 分页
        /// </summary>
        public void Init()
        {
            PagerHtml = this.Page();
        }
        public string Page()
        {
            if (this.ModelCount < this.PageSize)
            {
                this.PageIndex = 1;
            }
            return LangReplace(PageStyle());

        }

        /// <summary>
        /// 语言替换
        /// </summary>
        /// <param name="temp"></param>
        protected string LangReplace(string temp)
        {
            string[,] LangString = { { "首页", "Home" }, { "上页", "Previous" }, { "下页", "Next" }, { "上页", "Previous" }, { "下页", "Next" }, { "尾页", "Last" }, { "最后一页", "Last" }, { "页次", "Page" }, { "共有页面", "Page" }, { "总数", "Total" }, { "跳转", "GOTO" } };
            if (Lang == "EN")
            {
                for (int i = 0; i < LangString.GetLength(0); i++)
                {
                    temp = temp.Replace(LangString[i, 0], LangString[i, 1]);
                }
            }
            return temp;
        }


        /// <summary>
        /// 原型
        /// </summary>
        /// <returns></returns>
        protected string PageStyle()
        {

            long fPage = 1, ePage = 0;

            long PageCount = 0;//页数
            if (ModelCount % PageSize == 0)
            {
                PageCount = ModelCount / PageSize;
            }
            else
            {
                PageCount = ModelCount / PageSize + 1;
            }
            if (ModelCount == 0)
            {
                return "";
            }
            if (PageIndex > PageCount)
            {
                PageIndex = (int)PageCount;
            }
            string temp = "";
            temp += "共<font class=\"red\">" + ModelCount.ToString() + "</font>条,第<font class=\"red\">" + PageIndex + "</font>/" + PageCount + "页 ";
            //if (PageCount > 1)
            {

                //显示首页
                if (PageIndex > this.PageStep)
                {
                    temp += "<a href='" + PageUrl(1) + "' target=\"_self\">首页</a> ";
                }
                if (PageIndex > 1)
                {
                    temp += " <a href=\"" + PageUrl(PageIndex - 1) + "\" target=\"_self\">上页</a> ";
                }
                else
                {
                    temp += " <a disabled href=#>上页</a> ";
                }
                //上一节
                if (PageIndex > this.PageStep)
                {
                    temp += " <a href=\"" + PageUrl(PageIndex - this.PageStep) + "\" target=\"_self\"> << </a> ";
                }

                if (PageIndex > (this.PageStep / 2))
                {
                    fPage = PageIndex - (this.PageStep / 2);
                }

                if (Convert.ToInt32(PageCount) > this.PageStep)
                {
                    ePage = fPage + this.PageStep - 1;
                    if (ePage > Convert.ToInt32(PageCount))
                    {
                        fPage = ePage - (this.PageStep / 2);
                        ePage = ePage - 1;
                    }
                }
                else
                {
                    ePage = Convert.ToInt32(PageCount);
                }

                for (long i = fPage; i <= ePage; i++)
                {
                    if (i > PageCount)
                    {
                        break;
                    }
                    if (PageIndex == i)
                    {
                        temp += "<a href=\"" + PageUrl(i) + "\" target=\"_self\"><font class=\"red\">" + i + "</font></a> ";
                    }
                    else
                    {
                        temp += "<a href=\"" + PageUrl(i) + "\" target=\"_self\">" + i + "</a> ";
                    }
                }

                //下一节
                if (PageCount > this.PageStep && PageIndex < (PageCount - this.PageStep / 2) && (PageIndex + this.PageStep) <= PageCount)
                {
                    temp += " <a href=\"" + PageUrl(PageIndex + this.PageStep) + "\" target=\"_self\"> >> </a> ";
                }
                //下一页
                if (PageIndex < PageCount)
                {
                    temp += "<a href='" + PageUrl(PageIndex + 1) + "' target=\"_self\">下页</a> ";
                }
                else
                {
                    temp += " <a disabled href=#>下页</a> ";
                }
                //显示末页
                if (PageCount > this.PageStep && PageIndex < (PageCount - this.PageStep / 2) && (PageIndex + this.PageStep) <= PageCount)
                {
                    temp += "<a href='" + PageUrl(PageCount) + "' target=\"_self\">末页</a> ";
                }
            }
            return temp;
        }

        /// <summary>
        /// 获得当前地址及参数
        /// </summary>
        /// <returns>返回地址及参数</returns>
        protected string PageUrl(long n)
        {
            if (string.IsNullOrEmpty(Url))
            {
                string[] a, query;
                string UrlLast = "", _Url;
                string hosturl = System.Web.Configuration.WebConfigurationManager.AppSettings["HostUrl"];
                _Url = hosturl + System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"];
                query = System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"].Split('&');
                foreach (string x in query)
                {
                    a = x.Split('=');
                    if (!a[0].Equals("Page"))
                    {
                        try
                        {
                            UrlLast = UrlLast + a[0] + "=" + a[1] + "&";
                        }
                        catch
                        {
                            UrlLast = "";
                        }
                    }
                }
                return _Url + "?" + UrlLast + "Page=" + n.ToString();
            }
            else
            {
                return Url.Replace("{page}", n.ToString());
            }
        }

    }
}
