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
    //��ʽһ  ҳ��:2/2 ����:2 ��ҳ ��ҳ [1] [2] ��ҳ βҳ ��ת
    public class NetPage
    {
        /// <summary>
        /// ��ǰҳ
        /// </summary>
        public int PageIndex;

        /// <summary>
        /// ÿҳ��ʾ������
        /// </summary>
        public int PageSize = 50;
        /// <summary>
        /// ��ҳ����ʾҳ����
        /// </summary>
        public int PageStep = 6;

        /// <summary>
        /// ��������
        /// </summary>
        public long ModelCount;

        /// <summary>
        /// ���ԣ�"EN"��""CN��
        /// </summary>
        public string Lang = "CN";

        /// <summary>
        /// ��תҳ��
        /// </summary>
        public string Url;


        public string PagerHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// ��ҳ
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
        /// �����滻
        /// </summary>
        /// <param name="temp"></param>
        protected string LangReplace(string temp)
        {
            string[,] LangString = { { "��ҳ", "Home" }, { "��ҳ", "Previous" }, { "��ҳ", "Next" }, { "��ҳ", "Previous" }, { "��ҳ", "Next" }, { "βҳ", "Last" }, { "���һҳ", "Last" }, { "ҳ��", "Page" }, { "����ҳ��", "Page" }, { "����", "Total" }, { "��ת", "GOTO" } };
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
        /// ԭ��
        /// </summary>
        /// <returns></returns>
        protected string PageStyle()
        {

            long fPage = 1, ePage = 0;

            long PageCount = 0;//ҳ��
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
            temp += "��<font class=\"red\">" + ModelCount.ToString() + "</font>��,��<font class=\"red\">" + PageIndex + "</font>/" + PageCount + "ҳ ";
            //if (PageCount > 1)
            {

                //��ʾ��ҳ
                if (PageIndex > this.PageStep)
                {
                    temp += "<a href='" + PageUrl(1) + "' target=\"_self\">��ҳ</a> ";
                }
                if (PageIndex > 1)
                {
                    temp += " <a href=\"" + PageUrl(PageIndex - 1) + "\" target=\"_self\">��ҳ</a> ";
                }
                else
                {
                    temp += " <a disabled href=#>��ҳ</a> ";
                }
                //��һ��
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

                //��һ��
                if (PageCount > this.PageStep && PageIndex < (PageCount - this.PageStep / 2) && (PageIndex + this.PageStep) <= PageCount)
                {
                    temp += " <a href=\"" + PageUrl(PageIndex + this.PageStep) + "\" target=\"_self\"> >> </a> ";
                }
                //��һҳ
                if (PageIndex < PageCount)
                {
                    temp += "<a href='" + PageUrl(PageIndex + 1) + "' target=\"_self\">��ҳ</a> ";
                }
                else
                {
                    temp += " <a disabled href=#>��ҳ</a> ";
                }
                //��ʾĩҳ
                if (PageCount > this.PageStep && PageIndex < (PageCount - this.PageStep / 2) && (PageIndex + this.PageStep) <= PageCount)
                {
                    temp += "<a href='" + PageUrl(PageCount) + "' target=\"_self\">ĩҳ</a> ";
                }
            }
            return temp;
        }

        /// <summary>
        /// ��õ�ǰ��ַ������
        /// </summary>
        /// <returns>���ص�ַ������</returns>
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
