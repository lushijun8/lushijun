using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Com.Net
{
    /// <summary>
    /// HtmlUtil ��ժҪ˵����
    /// </summary>
    public class HtmlUtil
    {
        public HtmlUtil()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        /// <summary>
        /// ��HTML�л�ȡ���ı�
        /// </summary>
        /// <param name="HtmlText">HTML</param>
        /// <returns>����html��ʶ���ı�</returns>
        public static string GetPlainText(string HtmlText)
        {
            //			string Value=HtmlText;
            //			Value=TrimStyle(Value);
            //			Value=TrimScript(Value);
            //
            //			Regex HtmlTag = new Regex(@"<(.|\n)+?>",RegexOptions.IgnoreCase|RegexOptions.Singleline);
            //			string HtmlTags="";
            //			foreach(Match m in  HtmlTag.Matches(HtmlText))
            //			{
            //				HtmlTags=m.Value;
            //				Value=Value.Replace(HtmlTags,"");
            //			}
            string Value = HtmlText.ToLower();
            Value = TrimStyle(Value);
            Value = TrimScript(Value);
            Value = Regex.Replace(Value, "<[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return Value.Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(" ", "").Replace("��", "").Replace("&nbsp;", "").Replace("&gt;", "").Trim();
        }
        /// <summary>
        /// ȥ��html��style��������
        /// </summary>
        /// <param name="HtmlText"></param>
        /// <returns></returns>
        private static string TrimStyle(string HtmlText)
        {
            string Content = HtmlText;
            for (int i = 0; i < 20; i++)
            {
                int TrimStartIndex = Content.IndexOf("<style");
                int TrimEndIndex = Content.IndexOf("</style>") + 8;
                if (TrimStartIndex >= 0 && TrimEndIndex > TrimStartIndex)
                    Content = Content.Remove(TrimStartIndex, TrimEndIndex - TrimStartIndex);
                if (Content.IndexOf("<style") == -1)
                    break;
            }
            return Content;
        }
        /// <summary>
        /// ȥ��html�������ַ���������
        /// </summary>
        /// <param name="HtmlText"></param>
        /// <returns></returns>
        public static string TrimSpecialCode(string HtmlText)
        {
            string Content = HtmlText;
            char[] SpecialCodes = new char[] { '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '{', '}', '|', ':', '"', '<', '>', '?', '`', '-', '=', '[', ']', '\\', ';', '\'', ',', '.', '/' };
            for (int i = 0; i < SpecialCodes.Length; i++)
            {
                Content = Content.Replace(SpecialCodes[i].ToString(), "");
            }
            return Content;
        }
        /// <summary>
        /// ȥ��html��Script��������
        /// </summary>
        /// <param name="HtmlText"></param>
        /// <returns></returns>
        private static string TrimScript(string HtmlText)
        {
            string Content = HtmlText;
            for (int i = 0; i < 20; i++)
            {
                int TrimStartIndex = Content.IndexOf("<script");
                int TrimEndIndex = Content.IndexOf("</script>") + 9;
                if (TrimStartIndex >= 0 && TrimEndIndex > TrimStartIndex)
                    Content = Content.Remove(TrimStartIndex, TrimEndIndex - TrimStartIndex);
                if (Content.IndexOf("<script") == -1)
                    break;
            }
            return Content;
        }
        /// <summary>
        /// ȥ��html�г������Ӳ�������
        /// </summary>
        /// <param name="HtmlText"></param>
        /// <param name="MinLength">���������б�������С�ı����ȣ�С�ڴ˳��ȵ�ȥ��</param>
        /// <returns></returns>
        public static string TrimAnchor(string HtmlText, int MinLength)
        {
            string Content = HtmlText.ToLower();
            ArrayList Anchors = GetAnchorsFromHtmlText(Content);
            for (int i = 0; i < Anchors.Count; i++)
            {
                string text = GetPlainText(Anchors[i].ToString());
                if (text.Length < MinLength)
                {
                    Content = Content.Replace(Anchors[i].ToString(), "");
                }
            }
            return Content;
        }
        /// <summary>
        /// ����ҳ�����л�ȡ������������<a ...>...</a>
        /// </summary>
        /// <param name="HtmlText"></param>
        /// <returns></returns>
        public static ArrayList GetAnchorsFromHtmlText(string HtmlText)
        {
            ArrayList Value = new ArrayList();
            //			Regex rehref = new Regex(@"\<a[^>]*>[^>]*</a>",RegexOptions.IgnoreCase|RegexOptions.Multiline);
            Regex rehref = new Regex(@"<a.+?>[\s\S]+?</a>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            foreach (Match hrefMatch in rehref.Matches(HtmlText))
            {
                string HrefUrl = hrefMatch.Value;
                if (!Value.Contains(HrefUrl))
                {
                    Value.Add(HrefUrl);
                }
            }
            return Value;

        }
        /// <summary>
        /// ���ַ����л�ȡָ��������ʽ��ƥ������
        /// </summary>
        /// <param name="RegexString">������ʽ</param>
        /// /// <param name="HtmlText">����</param>
        /// <returns></returns>
        public static ArrayList GetRegexFromString(string RegexString, string HtmlText, System.Text.RegularExpressions.RegexOptions RegexOptions)
        {
            ArrayList Value = new ArrayList();
            Regex rehref = new Regex(RegexString, RegexOptions);
            foreach (Match hrefMatch in rehref.Matches(HtmlText))
            {
                string HrefUrl = hrefMatch.Value;
                if (!Value.Contains(HrefUrl))
                {
                    Value.Add(HrefUrl);
                }
            }
            return Value;
        }
        /// <summary>
        /// ͨ��������ʽ��ȡ����ƥ�������
        /// </summary>
        /// <param name="RegexString">����</param>
        /// <param name="MatchText">��Ҫƥ����ַ���</param>
        /// <returns></returns>
        public static string[] GetRegexGroupFromString(string RegexString, string MatchText, RegexOptions regexOptions)
        {
            string[] Params = null;
            Regex resrc = new Regex(RegexString, regexOptions);
            Match match = resrc.Match(MatchText);
            if (match.Success)
            {
                int MatchCount = match.Groups.Count;
                if (MatchCount > 0)
                {
                    Params = new string[MatchCount];
                    for (int i = 0; i < MatchCount - 1; i++)
                    {
                        Params[i] = match.Groups[i + 1].Value;
                    }
                }
            }
            return Params;
        }
        /// <summary>
        /// ͨ��������ʽ��ȡ����ƥ�������
        /// </summary>
        /// <param name="RegexString">����</param>
        /// <param name="MatchText">��Ҫƥ����ַ���</param>
        /// <returns></returns>
        public static string[] GetRegexGroupFromString(string RegexString, string MatchText)
        {
            return GetRegexGroupFromString(RegexString, MatchText, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }
        /// <summary>
        /// ��ȡHtml��������������Դ
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetSourceFromHtml(string HtmlText)
        {
            ArrayList Value = new ArrayList();
            ArrayList ValueHrefs = GetHrefsFromHtml(HtmlText);
            ArrayList ValueSrcs = GetIframeSrcsFromHtml(HtmlText);
            ArrayList ValueUrls = GetUrlsFromHtml(HtmlText);
            ArrayList ValueImgSrcs = GetImgSrcsFromHtml(HtmlText);
            ArrayList ValueFlashSrcs = GetFlashSrcsFromHtml(HtmlText);

            for (int i = 0; i < ValueHrefs.Count; i++)
            {
                if (!Value.Contains(ValueHrefs[i].ToString()))
                {
                    Value.Add(ValueHrefs[i].ToString());
                }
            }
            for (int i = 0; i < ValueSrcs.Count; i++)
            {
                if (!Value.Contains(ValueSrcs[i].ToString()))
                {
                    Value.Add(ValueSrcs[i].ToString());
                }
            }
            for (int i = 0; i < ValueUrls.Count; i++)
            {
                if (!Value.Contains(ValueUrls[i].ToString()))
                {
                    Value.Add(ValueUrls[i].ToString());
                }
            }
            for (int i = 0; i < ValueImgSrcs.Count; i++)
            {
                if (!Value.Contains(ValueImgSrcs[i].ToString()))
                {
                    Value.Add(ValueImgSrcs[i].ToString());
                }
            }

            for (int i = 0; i < ValueFlashSrcs.Count; i++)
            {
                if (!Value.Contains(ValueFlashSrcs[i].ToString()))
                {
                    Value.Add(ValueFlashSrcs[i].ToString());
                }
            }
            return Value;
        }
        public static ArrayList GetUrlsFromHtml(string HtmlText)
        {
            ArrayList Value = new ArrayList();
            Regex reurl = new Regex(@"\<(.*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (reurl.Matches(HtmlText).Count > 0)
            {
                string url = reurl.Matches(HtmlText)[0].Value;
                Regex re = new Regex(@"<[^>]*?url\s*=\s*(""(?<url>[^""]+?)""|'(?<url>[^']+?)'|(?<url>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                foreach (Match urlMatch in re.Matches(url))
                {
                    string UrlUrl = urlMatch.Groups["url"].Value;
                    if (!Value.Contains(UrlUrl))
                    {
                        Value.Add(UrlUrl);
                    }
                }
            }
            return Value;
        }
        public static ArrayList GetHrefsFromHtml(string HtmlText)
        {
            ArrayList Value = new ArrayList();
            Regex rehref = new Regex(@"\<(a|area|link|base)(.*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (rehref.Matches(HtmlText).Count > 0)
            {
                string href = rehref.Matches(HtmlText)[0].Value;
                Regex re = new Regex(@"<(a|area|link|base)[^>]*?href\s*=\s*(""(?<href>[^""]+?)""|'(?<href>[^']+?)'|(?<href>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                foreach (Match hrefMatch in re.Matches(href))
                {
                    string HrefUrl = hrefMatch.Groups["href"].Value;
                    if (!Value.Contains(HrefUrl))
                    {
                        Value.Add(HrefUrl);
                    }
                }
            }
            return Value;
        }
        public static ArrayList GetSrcsFromHtml(string HtmlText)
        {
            //			ArrayList Value=new ArrayList();
            //			string str=HtmlText;
            //			string pattern = "(src='[^']*(?=')|src=\"[^\"]*(?=\")|src=[^\\s>]*)";
            //			MatchCollection srcs = Regex.Matches(str,pattern);
            //			foreach(Match src in srcs)
            //			{
            //				pattern = "^src=(\"|'|)";
            //				string ss=Regex.Replace(src.Value,pattern,"");
            //				if(!Value.Contains(ss))
            //				{
            //					Value.Add(ss);
            //				}
            //				
            //			}


            ArrayList Value = new ArrayList();
            Regex resrc = new Regex(@"\<(.*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (resrc.Matches(HtmlText).Count > 0)
            {
                string src = resrc.Matches(HtmlText)[0].Value;
                Regex re = new Regex(@"<[^>]*?src\s*=\s*(""(?<src>[^""]+?)""|'(?<src>[^']+?)'|(?<src>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match srcMatch in re.Matches(src))
                {
                    try
                    {
                        string SrcUrl = srcMatch.Groups["src"].Value;
                        Uri URL = new Uri(SrcUrl);
                        string aa = URL.AbsoluteUri;
                        if (!Value.Contains(SrcUrl))
                        {
                            Value.Add(SrcUrl);
                        }
                    }
                    catch { }
                }
            }
            return Value;
        }
        public static ArrayList GetImgSrcsFromHtml(string HtmlText)
        {
            ArrayList Value = new ArrayList();
            Regex resrc = new Regex(@"\<img(.*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (resrc.Matches(HtmlText).Count > 0)
            {
                string src = resrc.Matches(HtmlText)[0].Value;
                Regex re = new Regex(@"<img[^>]*?src\s*=\s*(""(?<src>[^""]+?)""|'(?<src>[^']+?)'|(?<src>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                foreach (Match srcMatch in re.Matches(src))
                {
                    string SrcUrl = srcMatch.Groups["src"].Value;
                    if (!Value.Contains(SrcUrl))
                    {
                        Value.Add(SrcUrl);
                    }
                }
            }
            return Value;
        }
        public static ArrayList GetFlashSrcsFromHtml(string HtmlText)
        {
            ArrayList Value = new ArrayList();
            Regex resrc = new Regex(@"\<embed(.*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (resrc.Matches(HtmlText).Count > 0)
            {
                string src = resrc.Matches(HtmlText)[0].Value;
                Regex re = new Regex(@"<embed[^>]*?src\s*=\s*(""(?<src>[^""]+?)""|'(?<src>[^']+?)'|(?<src>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                foreach (Match srcMatch in re.Matches(src))
                {
                    string SrcUrl = srcMatch.Groups["src"].Value;
                    if (!Value.Contains(SrcUrl))
                    {
                        Value.Add(SrcUrl);
                    }
                }
            }
            return Value;
        }
        public static ArrayList GetIframeSrcsFromHtml(string HtmlText)
        {
            ArrayList Value = new ArrayList();
            Regex resrc = new Regex(@"\<iframe(.*)>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (resrc.Matches(HtmlText).Count > 0)
            {
                string src = resrc.Matches(HtmlText)[0].Value;
                Regex re = new Regex(@"<iframe[^>]*?src\s*=\s*(""(?<src>[^""]+?)""|'(?<src>[^']+?)'|(?<src>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                foreach (Match srcMatch in re.Matches(src))
                {
                    string SrcUrl = srcMatch.Groups["src"].Value;
                    if (!Value.Contains(SrcUrl))
                    {
                        Value.Add(SrcUrl);
                    }
                }
            }
            return Value;
        }
    }
}
