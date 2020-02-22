using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.ComponentModel;

namespace Com.UserControl
{
	/// <summary>
	/// PageLinkButton 的摘要说明。
	/// </summary>
	public class PageLinkButton: WebControl, IPostBackEventHandler
	{
		private string text;
		public event EventHandler Click;
 

		[Category("Appearance"), DefaultValue(""), Bindable(true)]
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
			}
		}
 

		public PageLinkButton()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private string getStyle()
		{
			StringBuilder builder1 = new StringBuilder("style=\"");
			if (base.Style["Z-INDEX"] != null)
			{
				builder1.Append("Z-INDEX:" + base.Style["Z-INDEX"] + ";");
			}
			if (base.Style["LEFT"] != null)
			{
				builder1.Append("LEFT:" + base.Style["LEFT"] + ";");
			}
			if (base.Style["POSITION"] != null)
			{
				builder1.Append("POSITION:" + base.Style["POSITION"] + ";");
			}
			if (base.Style["TOP"] != null)
			{
				builder1.Append("TOP:" + base.Style["TOP"] + ";");
			}
			builder1.Append("\"");
			if (builder1.ToString() != "style=\"\"")
			{
				return builder1.ToString();
			}
			return "";
		}
 
		protected virtual void OnClick(EventArgs e)
		{
			if (this.Click != null)
			{
				this.Click(this, e);
			}
		}
 
		public void RaisePostBackEvent(string eventArgument)
		{
			this.OnClick(new EventArgs());
		}
 
		protected override void Render(HtmlTextWriter output)
		{
			string[] textArray1 = new string[5] { "<a  id =\"", this.UniqueID, "\" href=\"javascript:___BeforePagePostBack();\"  ", this.getStyle(), ">" } ;
			output.Write(string.Concat(textArray1));
			output.Write(" " + this.Text + "</a>");
		}
 

	}
}
