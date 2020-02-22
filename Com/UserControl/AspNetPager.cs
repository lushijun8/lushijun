using System;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using  System.Web.UI.HtmlControls;
using System.Web.UI.Design;
using System.ComponentModel;
using System.Collections.Specialized ;

namespace Com.UserControl
{

    [PersistChildren(false), Description("\u4e13\u7528\u4e8eASP.Net Web\u5e94\u7528\u7a0b\u5e8f\u7684\u5206\u9875\u63a7\u4ef6"), Designer(typeof(PagerDesigner)), ParseChildren(false), DefaultProperty("PageSize"), ToolboxData("<{0}:AspNetPager runat=server></{0}:AspNetPager>"), DefaultEvent("PageChanged")]
    public class AspNetPager : Panel, INamingContainer, IPostBackEventHandler, IPostBackDataHandler
    {
        // Events
        public event PageChangedEventHandler PageChanged;

        // Methods
        public AspNetPager()
        {
        }
        private void CreatePageButton(HtmlTextWriter writer, string btnname)
        {
            int num1;
            if (!this.ShowFirstLast)
            {
                if (btnname == "first")
                {
                    return;
                }
                if (btnname == "last")
                {
                    return;
                }
            }
            if (!this.ShowPrevNext)
            {
                if (btnname == "prev")
                {
                    return;
                }
                if (btnname == "next")
                {
                    return;
                }
            }
            string text1 = "";
            if ((btnname == "prev") || (btnname == "first"))
            {
                text1 = (btnname == "prev") ? this.PrevPageText : this.FirstPageText;
                if (this.CurrentPageIndex <= 1)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                }
                else
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, this.cssclassname);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, this.Page.GetPostBackClientHyperlink(this, (btnname == "first") ? "1" : (num1 = this.CurrentPageIndex - 1).ToString()));
                }
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(text1);
                writer.RenderEndTag();
                writer.Write("&nbsp;&nbsp;");
            }
            if ((btnname == "next") || (btnname == "last"))
            {
                text1 = (btnname == "next") ? this.NextPageText : this.LastPageText;
                if (this.CurrentPageIndex >= this.PageCount)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                }
                else
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, this.cssclassname);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, this.Page.GetPostBackClientHyperlink(this, (btnname == "last") ? this.PageCount.ToString() : (num1 = this.CurrentPageIndex + 1).ToString()));
                }
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(text1);
                writer.RenderEndTag();
                writer.Write("&nbsp;&nbsp;");
            }
        }

        public virtual bool LoadPostData(string pkey, NameValueCollection pcol)
        {
            string text1 = pcol[this.UniqueID + "_input"];
            if ((text1 != null) && (text1.Trim().Length > 0))
            {
                try
                {
                    int num1 = int.Parse(text1);
                    if ((num1 > 0) && (num1 <= this.PageCount))
                    {
                        this.InputPageNumber = text1.Trim(',');
                        this.Page.RegisterRequiresRaiseEvent(this);
                    }
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException("\u8f93\u5165\u7684\u9875\u7d22\u5f15\u65e0\u6548\uff01");
                }
                catch (Exception exception1)
                {
                    throw new Exception("\u51fa\u9519\u4e86\uff1a" + exception1.Message);
                }
            }
            return false;
        }

        protected virtual void OnPageChanged(PageChangedEventArgs e)
        {
            if (this.PageChanged != null)
            {
                this.PageChanged(this, e);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.ShowInput = ((this.ShowInputBox == ShowInputBox.Always) || ((this.ShowInputBox == ShowInputBox.Auto) && (this.PageCount >= this.ShowBoxThreshold))) || false;
            //				<script language="Javascript">function docheck(el){var r=new RegExp("^\\s*(\\d+)\\s*$");if(r.test(el.value)){if(RegExp.$1<1||RegExp.$1>22){alert("页数必须介于1和22之间！");return false;}return true;}alert("输入的页索引无效！");return false;}</script>
            string[] textArray1 = new string[5] { "<script language=\"Javascript\">function docheck(el){var r=new RegExp(\"^\\\\s*(\\\\d+)\\\\s*$\");if(r.test(el.value)){if(RegExp.$1<1||RegExp.$1>", this.PageCount.ToString(), "){alert(\"页数必须介于1和！", this.PageCount.ToString(), "之间\");return false;}return true;}alert(\"输入的页索引无效！\");return false;}</script>" };
            string text1 = string.Concat(textArray1);
            if (this.ShowInput && !this.Page.IsClientScriptBlockRegistered("checkinput"))
            {
                this.Page.RegisterClientScriptBlock("checkinput", text1);
            }
            base.OnPreRender(e);
        }

        public void RaisePostBackEvent(string args)
        {
            try
            {
                if ((args == null) || (args == ""))
                {
                    args = this.InputPageNumber;
                }
                int num1 = int.Parse(args);
                this.OnPageChanged(new PageChangedEventArgs(num1));
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("\u9875\u7d22\u5f15\u53c2\u6570\u65e0\u6548\uff01");
            }
            catch (Exception exception1)
            {
                throw new Exception("\u51fa\u9519\u4e86\uff1a" + exception1.Message);
            }
        }

        public virtual void RaisePostDataChangedEvent()
        {
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.WriteLine();
            base.RenderBeginTag(writer);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (this.Enabled == false)
            {
                writer.Write("分页\uff1a<font color=\"red\"><b>" + this.CurrentPageIndex.ToString() + "</b></font>/" + this.PageCount.ToString() + "&nbsp;&nbsp;共<font color=\"red\"><b>" + this.RecordCount.ToString() + "</b></font>条记录");
            }
            else if (this.PageCount > 1)
            {
                string text1 = "分页\uff1a<font color=\"red\"><b>" + this.CurrentPageIndex.ToString() + "</b></font>/" + this.PageCount.ToString() + "&nbsp;&nbsp;共<font color=\"red\"><b>" + this.RecordCount.ToString() + "</b></font>条记录";
                string text2 = "&nbsp;&nbsp;&nbsp;&nbsp;";
                if (this.TextBeforePager != null)
                {
                    writer.Write(this.TextBeforePager + text2);
                }
                if (this.ShowPageInfo == ShowPageInfo.Before)
                {
                    writer.Write(text1 + text2);
                }
                int num1 = (this.CurrentPageIndex - 1) / this.PageButtonCount;
                int num2 = num1 * this.PageButtonCount;
                int num3 = ((num2 + this.PageButtonCount) > this.PageCount) ? this.PageCount : (num2 + this.PageButtonCount);
                this.CreatePageButton(writer, "first");
                this.CreatePageButton(writer, "prev");
                if (this.ShowPageIndex)
                {
                    if (this.CurrentPageIndex > this.PageButtonCount)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, this.cssclassname);
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, this.Page.GetPostBackClientHyperlink(this, num2.ToString()));
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write("...");
                        writer.RenderEndTag();
                        writer.Write("&nbsp;");
                    }
                    for (int num4 = num2 + 1; num4 <= num3; num4++)
                    {
                        if (num4 == this.CurrentPageIndex)
                        {
                            writer.Write("<font color=\"Red\"><b>" + num4.ToString() + "</b></font>");
                        }
                        else
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, this.cssclassname);
                            writer.AddAttribute("href", this.Page.GetPostBackClientHyperlink(this, num4.ToString()));
                            writer.RenderBeginTag("a");
                            writer.Write(num4.ToString());
                            writer.RenderEndTag();
                        }
                        writer.Write("&nbsp;");
                    }
                    if ((this.PageCount > this.PageButtonCount) && (num3 < this.PageCount))
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, this.cssclassname);
                        int num5 = num3 + 1;
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, this.Page.GetPostBackClientHyperlink(this, num5.ToString()));
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write("...");
                        writer.RenderEndTag();
                    }
                }
                writer.Write("&nbsp;&nbsp;");
                this.CreatePageButton(writer, "next");
                this.CreatePageButton(writer, "last");
                if (this.ShowInput)
                {
                    writer.Write("&nbsp;&nbsp;&nbsp;&nbsp;");
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "30px");
                    writer.AddAttribute(HtmlTextWriterAttribute.Value, this.InputPageNumber);
                    writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID + "_input");
                    writer.RenderBeginTag(HtmlTextWriterTag.Input);
                    writer.RenderEndTag();
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "Submit");
                    writer.AddAttribute(HtmlTextWriterAttribute.Value, "GO");
                    writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "return docheck(document.all['" + this.UniqueID + "_input'])");
                    writer.RenderBeginTag(HtmlTextWriterTag.Input);
                    writer.RenderEndTag();
                }
                if (this.ShowPageInfo == ShowPageInfo.After)
                {
                    writer.Write(text2 + text1);
                }
                if (this.TextAfterPager != null)
                {
                    writer.Write(text2 + this.TextAfterPager);
                }
            }
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer);
            writer.WriteLine();

            writer.WriteLine();
        }



        // Properties
        [Description("\u5e94\u7528\u4e8e\u63a7\u4ef6\u7684CSS\u7c7b\u540d"), Browsable(true), Category("Appearance"), DefaultValue((string)null)]
        public override string CssClass
        {
            get
            {
                return base.CssClass;
            }
            set
            {
                base.CssClass = value;
                this.cssclassname = value;
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(1), ReadOnly(true), Browsable(true), Description("\u5f53\u524d\u663e\u793a\u9875\u7684\u7d22\u5f15"), Category("\u5206\u9875")]
        public int CurrentPageIndex
        {
            get
            {
                object obj1 = this.ViewState["CurrentPageIndex"];
                int num1 = (obj1 == null) ? 1 : ((int)obj1);
                if (num1 > this.PageCount)
                {
                    return this.PageCount;
                }
                if (num1 < 1)
                {
                    return 1;
                }
                return num1;
            }
            set
            {
                int num1 = value;
                if (num1 < 1)
                {
                    num1 = 1;
                }
                else if (num1 > this.PageCount)
                {
                    num1 = this.PageCount;
                }
                this.ViewState["CurrentPageIndex"] = num1;
            }
        }


        [DefaultValue(true), Browsable(true), ReadOnly(true), Category("Behavior"), Description("\u662f\u5426\u542f\u7528\u63a7\u4ef6\u7684\u89c6\u56fe\u72b6\u6001\uff0cAspNetPager\u5fc5\u987b\u542f\u7528\u89c6\u56fe\u72b6\u6001\u624d\u80fd\u6b63\u5e38\u5de5\u4f5c\uff0c\u6240\u4ee5\u6b64\u5c5e\u6027\u7684\u503c\u6c38\u8fdc\u662ftrue\uff0c\u7528\u6237\u65e0\u6cd5\u7981\u7528\u89c6\u56fe\u72b6\u6001\u3002")]
        public override bool EnableViewState
        {
            get
            {
                return base.EnableViewState;
            }
            set
            {
                base.EnableViewState = true;
            }
        }

        [DefaultValue("<font>首页</font>"), Browsable(true), Description("\u7b2c\u4e00\u9875\u6309\u94ae\u4e0a\u663e\u793a\u7684\u6587\u672c"), Category("Appearance")]
        public string FirstPageText
        {
            get
            {
                object obj1 = this.ViewState["FirstPageText"];
                return ((obj1 == null) ? "<font>首页</font>" : ((string)obj1));
            }
            set
            {
                this.ViewState["FirstPageText"] = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        private string InputPageNumber
        {
            get
            {
                object obj1 = this.ViewState["InputPageNumber"];
                return ((obj1 == null) ? "" : ((string)obj1));
            }
            set
            {
                this.ViewState["InputPageNumber"] = value;
            }
        }

        [Description("\u6700\u540e\u4e00\u9875\u6309\u94ae\u4e0a\u663e\u793a\u7684\u6587\u672c"), Browsable(true), DefaultValue("<font>末页</font>"), Category("Appearance")]
        public string LastPageText
        {
            get
            {
                object obj1 = this.ViewState["LastPageText"];
                return ((obj1 == null) ? "<font>末页</font>" : ((string)obj1));
            }
            set
            {
                this.ViewState["LastPageText"] = value;
            }
        }

        [DefaultValue("<font>下页</font>"), Browsable(true), Description("\u4e0b\u4e00\u9875\u6309\u94ae\u4e0a\u663e\u793a\u7684\u6587\u672c"), Category("Appearance")]
        public string NextPageText
        {
            get
            {
                object obj1 = this.ViewState["NextPageText"];
                return ((obj1 == null) ? "<font>下页</font>" : ((string)obj1));
            }
            set
            {
                this.ViewState["NextPageText"] = value;
            }
        }

        [Description("\u8981\u663e\u793a\u7684\u9875\u7d22\u5f15\u6570\u503c\u6309\u94ae\u7684\u6570\u76ee"), Browsable(true), Category("\u5206\u9875"), DefaultValue(10)]
        public int PageButtonCount
        {
            get
            {
                object obj1 = this.ViewState["PageButtonCount"];
                return ((obj1 == null) ? 10 : int.Parse(obj1.ToString()));
            }
            set
            {
                this.ViewState["PageButtonCount"] = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(((double)this.RecordCount) / ((double)this.PageSize));
            }
        }

        [Category("\u5206\u9875"), Browsable(true), DefaultValue(10), Description("\u6bcf\u9875\u663e\u793a\u7684\u8bb0\u5f55\u6570")]
        public int PageSize
        {
            get
            {
                object obj1 = this.ViewState["_pagesize"];
                return ((obj1 == null) ? 10 : ((int)obj1));
            }
            set
            {
                this.ViewState["_pagesize"] = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PagesRemain
        {
            get
            {
                return (this.PageCount - this.CurrentPageIndex);
            }
        }

        [Category("Appearance"), Description("\u4e0a\u4e00\u9875\u6309\u94ae\u4e0a\u663e\u793a\u7684\u6587\u672c"), DefaultValue("<font>上页</font>"), Browsable(true)]
        public string PrevPageText
        {
            get
            {
                object obj1 = this.ViewState["PrevPageText"];
                return ((obj1 == null) ? "<font>上页</font>" : ((string)obj1));
            }
            set
            {
                this.ViewState["PrevPageText"] = value;
            }
        }

        [Description("\u8981\u5206\u9875\u7684\u6240\u6709\u8bb0\u5f55\u7684\u603b\u6570\uff0c\u8be5\u503c\u987b\u5728\u7a0b\u5e8f\u8fd0\u884c\u65f6\u8bbe\u7f6e\uff0c\u9ed8\u8ba4\u503c\u4e3a225\u662f\u4e3a\u8bbe\u8ba1\u65f6\u652f\u6301\u800c\u8bbe\u7f6e\u7684\u53c2\u7167\u503c\u3002"), ReadOnly(true), Browsable(true), DefaultValue(0xe1), Category("Data")]
        public int RecordCount
        {
            get
            {
                object obj1 = this.ViewState["_recordcount"];
                return ((obj1 == null) ? 0 : ((int)obj1));
            }
            set
            {
                this.ViewState["_recordcount"] = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int RecordsRemain
        {
            get
            {
                if (this.CurrentPageIndex < this.PageCount)
                {
                    return (this.RecordCount - (this.CurrentPageIndex * this.PageSize));
                }
                return 0;
            }
        }

        [DefaultValue(30), Category("Behavior"), Browsable(true), Description("\u6307\u5b9a\u5f53ShowInputBox\u8bbe\u4e3aShowInputBox.Auto\u65f6\uff0c\u5f53\u603b\u9875\u6570\u8fbe\u5230\u591a\u5c11\u65f6\u624d\u663e\u793a\u9875\u7d22\u5f15\u8f93\u5165\u6587\u672c\u6846")]
        public int ShowBoxThreshold
        {
            get
            {
                object obj1 = this.ViewState["ShowBoxThreshold"];
                return ((obj1 == null) ? 30 : ((int)obj1));
            }
            set
            {
                this.ViewState["ShowBoxThreshold"] = value;
            }
        }

        [Description("\u662f\u5426\u5728\u9875\u5bfc\u822a\u5143\u7d20\u4e2d\u663e\u793a\u7b2c\u4e00\u9875\u548c\u6700\u540e\u4e00\u9875\u6309\u94ae"), DefaultValue(true), Browsable(true), Category("Appearance")]
        public bool ShowFirstLast
        {
            get
            {
                object obj1 = this.ViewState["ShowFirstLast"];
                return ((obj1 == null) || ((bool)obj1));
            }
            set
            {
                this.ViewState["ShowFirstLast"] = value;
            }
        }

        [Browsable(true), Description("\u6307\u5b9a\u9875\u7d22\u5f15\u6587\u672c\u6846\u7684\u663e\u793a\u65b9\u5f0f"), DefaultValue(1), Category("Appearance")]
        public ShowInputBox ShowInputBox
        {
            get
            {
                object obj1 = this.ViewState["ShowInputBox"];
                return ((obj1 == null) ? ShowInputBox.Auto : ((ShowInputBox)obj1));
            }
            set
            {
                this.ViewState["ShowInputBox"] = value;
            }
        }

        [Browsable(true), DefaultValue(true), Description("\u662f\u5426\u5728\u9875\u5bfc\u822a\u5143\u7d20\u4e2d\u663e\u793a\u6570\u503c\u6309\u94ae"), Category("Appearance")]
        public bool ShowPageIndex
        {
            get
            {
                object obj1 = this.ViewState["ShowPageIndex"];
                return ((obj1 == null) || ((bool)obj1));
            }
            set
            {
                this.ViewState["ShowPageIndex"] = value;
            }
        }

        [DefaultValue(0), Description("\u663e\u793a\u5f53\u524d\u9875\u548c\u603b\u9875\u6570\u4fe1\u606f\uff0c\u9ed8\u8ba4\u503c\u4e3a\u4e0d\u663e\u793a\uff0c\u503c\u4e3aShowPageInfo.Before\u65f6\u5c06\u663e\u793a\u5728\u9875\u7d22\u5f15\u524d\uff0c\u4e3aShowPageInfo.After\u65f6\u5c06\u663e\u793a\u5728\u9875\u7d22\u5f15\u540e"), Browsable(true), Category("Appearance")]
        public ShowPageInfo ShowPageInfo
        {
            get
            {
                object obj1 = this.ViewState["ShowPageInfo"];
                return ((obj1 == null) ? ShowPageInfo.Never : ((ShowPageInfo)obj1));
            }
            set
            {
                this.ViewState["ShowPageInfo"] = value;
            }
        }

        [DefaultValue(true), Category("Appearance"), Browsable(true), Description("\u662f\u5426\u5728\u9875\u5bfc\u822a\u5143\u7d20\u4e2d\u663e\u793a\u4e0a\u4e00\u9875\u548c\u4e0b\u4e00\u9875\u6309\u94ae")]
        public bool ShowPrevNext
        {
            get
            {
                object obj1 = this.ViewState["ShowPrevNext"];
                return ((obj1 == null) || ((bool)obj1));
            }
            set
            {
                this.ViewState["ShowPrevNext"] = value;
            }
        }

        [Browsable(true), Category("Appearance"), DefaultValue((string)null), Description("\u8981\u663e\u793a\u5728\u9875\u5bfc\u822a\u5143\u7d20\u6700\u53f3\u8fb9\u7684\u6587\u5b57")]
        public string TextAfterPager
        {
            get
            {
                object obj1 = this.ViewState["TextAfterPager"];
                return ((obj1 == null) ? "" : obj1.ToString());
            }
            set
            {
                this.ViewState["TextAfterPager"] = value;
            }
        }
        [Browsable(true), Description("\u8981\u663e\u793a\u5728\u9875\u5bfc\u822a\u5143\u7d20\u6700\u5de6\u8fb9\u7684\u6587\u5b57"), Category("Appearance"), DefaultValue((string)null)]
        public string TextBeforePager
        {
            get
            {
                object obj1 = this.ViewState["TextBeforePager"];
                return ((obj1 == null) ? "" : obj1.ToString());
            }
            set
            {
                this.ViewState["TextBeforePager"] = value;
            }
        }


        // Fields
        private string cssclassname;
        private bool ShowInput;
    }

    public sealed class PageChangedEventArgs : EventArgs
    {
        // Methods
        public PageChangedEventArgs(int newPageIndex)
        {
            this._newpageindex = newPageIndex;
        }


        // Properties
        public int NewPageIndex
        {
            get
            {
                return this._newpageindex;
            }
        }



        // Fields
        private readonly int _newpageindex;
    }

    public delegate void PageChangedEventHandler(object src, PageChangedEventArgs e);


    public class PagerDesigner : PanelDesigner
    {
        // Methods
        public PagerDesigner()
        {
            base.ReadOnly = true;
        }


        private string GetAnchorHtml(string aname)
        {
            string text2;
            AspNetPager pager1 = (AspNetPager)base.Component;
            if (!pager1.ShowFirstLast && ((aname == "first") || (aname == "last")))
            {
                return string.Empty;
            }
            if (!pager1.ShowPrevNext && ((aname == "prev") || (aname == "next")))
            {
                return string.Empty;
            }
            if ((text2 = aname) != null)
            {
                text2 = string.IsInterned(text2);
                if (text2 != "first")
                {
                    if (text2 == "prev")
                    {
                        return pager1.PrevPageText;
                    }
                    if (text2 == "next")
                    {
                        return pager1.NextPageText;
                    }
                }
                else
                {
                    return pager1.FirstPageText;
                }
            }
            return pager1.LastPageText;
        }


        public override string GetDesignTimeHtml()
        {
            string text4;
            try
            {
                LiteralControl control1;
                AspNetPager pager1 = (AspNetPager)base.Component;
                int num1 = pager1.PageButtonCount;
                StringWriter writer1 = new StringWriter();
                HtmlTextWriter writer2 = new HtmlTextWriter(writer1);
                pager1.RecordCount = 0xe1;
                int num2 = pager1.PageButtonCount;
                int num3 = pager1.PageCount;
                if (pager1.CurrentPageIndex > num3)
                {
                    pager1.CurrentPageIndex = num3;
                }
                if (pager1.CurrentPageIndex <= 0)
                {
                    pager1.CurrentPageIndex = 1;
                }
                int num4 = pager1.RecordCount;
                int num5 = pager1.CurrentPageIndex;
                int num6 = (pager1.CurrentPageIndex - 1) / num2;
                int num7 = num6 * num2;
                int num8 = ((num7 + num2) > num3) ? num3 : (num7 + num2);
                StringBuilder builder1 = new StringBuilder("分页:");
                builder1.Append("<font color=\"red\"><b>");
                builder1.Append(num5.ToString());
                builder1.Append("</b></font>");
                builder1.Append("/");
                builder1.Append(num3.ToString());
                builder1.Append("&nbsp;&nbsp;共?条记录");
                string text1 = builder1.ToString();
                string text2 = "&nbsp;&nbsp;&nbsp;&nbsp;";
                if ((pager1.TextBeforePager != null) && (pager1.TextBeforePager.Length > 0))
                {
                    control1 = new LiteralControl(pager1.TextBeforePager + text2);
                    control1.RenderControl(writer2);
                }
                if (pager1.ShowPageInfo == ShowPageInfo.Before)
                {
                    control1 = new LiteralControl(text1 + text2);
                    control1.RenderControl(writer2);
                }
                HtmlAnchor anchor1 = new HtmlAnchor();
                anchor1.InnerHtml = this.GetAnchorHtml("first");
                anchor1.HRef = "first";
                if (num5 <= 1)
                {
                    anchor1.Disabled = true;
                }
                anchor1.RenderControl(writer2);
                control1 = new LiteralControl("&nbsp;&nbsp;");
                control1.RenderControl(writer2);
                anchor1 = new HtmlAnchor();
                anchor1.InnerHtml = this.GetAnchorHtml("prev");
                anchor1.HRef = "prev";
                if (num5 <= 1)
                {
                    anchor1.Disabled = true;
                }
                anchor1.RenderControl(writer2);
                control1 = new LiteralControl("&nbsp;&nbsp;");
                control1.RenderControl(writer2);
                if (pager1.ShowPageIndex)
                {
                    if (num7 >= num2)
                    {
                        anchor1 = new HtmlAnchor();
                        anchor1.InnerText = "...";
                        anchor1.HRef = num7.ToString();
                        anchor1.RenderControl(writer2);
                        control1 = new LiteralControl("&nbsp;&nbsp;");
                        control1.RenderControl(writer2);
                    }
                    for (int num9 = num7 + 1; num9 <= num8; num9++)
                    {
                        control1 = new LiteralControl("&nbsp;");
                        control1.RenderControl(writer2);
                        if (pager1.CurrentPageIndex == num9)
                        {
                            control1 = new LiteralControl("<font color=\"red\"><b>" + num9.ToString() + "</b></font>");
                            control1.RenderControl(writer2);
                        }
                        else
                        {
                            anchor1 = new HtmlAnchor();
                            anchor1.InnerText = num9.ToString();
                            anchor1.HRef = num9.ToString();
                            anchor1.RenderControl(writer2);
                        }
                        control1 = new LiteralControl("&nbsp;");
                        control1.RenderControl(writer2);
                    }
                    control1 = new LiteralControl("&nbsp;");
                    control1.RenderControl(writer2);
                    if ((num3 > num2) && (num8 < num3))
                    {
                        anchor1 = new HtmlAnchor();
                        anchor1.HRef = "more";
                        anchor1.InnerText = "...";
                        anchor1.RenderControl(writer2);
                    }
                }
                control1 = new LiteralControl("&nbsp;&nbsp;");
                control1.RenderControl(writer2);
                anchor1 = new HtmlAnchor();
                anchor1.InnerHtml = this.GetAnchorHtml("next");
                anchor1.HRef = "next";
                if (num5 >= num3)
                {
                    anchor1.Disabled = true;
                }
                anchor1.RenderControl(writer2);
                control1 = new LiteralControl("&nbsp;&nbsp;");
                control1.RenderControl(writer2);
                anchor1 = new HtmlAnchor();
                anchor1.InnerHtml = this.GetAnchorHtml("last");
                anchor1.HRef = "last";
                if (num5 >= num3)
                {
                    anchor1.Disabled = true;
                }
                anchor1.RenderControl(writer2);
                if ((pager1.ShowInputBox == ShowInputBox.Always) || ((pager1.ShowInputBox == ShowInputBox.Auto) && (num3 >= pager1.ShowBoxThreshold)))
                {
                    control1 = new LiteralControl("&nbsp;&nbsp;&nbsp;");
                    control1.RenderControl(writer2);
                    HtmlInputText text3 = new HtmlInputText("Text");
                    text3.Size = 2;
                    text3.RenderControl(writer2);
                    HtmlInputButton button1 = new HtmlInputButton("Submit");
                    button1.Value = "GO";
                    button1.RenderControl(writer2);
                }
                if (pager1.ShowPageInfo == ShowPageInfo.After)
                {
                    control1 = new LiteralControl(text2 + text1);
                    control1.RenderControl(writer2);
                }
                if ((pager1.TextAfterPager != null) && (pager1.TextAfterPager.Length > 0))
                {
                    control1 = new LiteralControl(text2 + pager1.TextAfterPager);
                    control1.RenderControl(writer2);
                }
                text4 = writer1.ToString();
            }
            catch (Exception exception1)
            {
                text4 = this.GetErrorDesignTimeHtml(exception1);
            }
            return text4;
        }


        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            string text1 = "\u521b\u5efa\u63a7\u4ef6\u65f6\u51fa\u9519\uff01" + e.Message;
            return base.CreatePlaceHolderDesignTimeHtml(text1);
        }

    }

    public enum ShowInputBox : byte
    {
        // Fields
        Always = 2,
        Auto = 1,
        Never = 0
    }

    public enum ShowPageInfo : byte
    {
        // Fields
        After = 2,
        Before = 1,
        Never = 0
    }



}
