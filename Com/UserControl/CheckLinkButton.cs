using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace Com.UserControl
{
	/// <summary>
	/// CheckLinkButton 的摘要说明。
	/// </summary>
	public class CheckLinkButton : WebControl, IPostBackEventHandler
	{
		public event EventHandler Click;
		private string text;

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
 

		public CheckLinkButton()
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
			output.WriteLine("<script language='javascript'>");
			output.WriteLine("function myPostBack()");
			output.WriteLine("{");
			string text1 = " ";
			IEnumerator enumerator1 = base.Attributes.Keys.GetEnumerator();
			while (enumerator1.MoveNext())
			{
				string text2 = enumerator1.Current.ToString();
				if (text2.ToUpper() == "ONCLICK")
				{
					output.Write(base.Attributes[text2] + ";");
					continue;
				}
				string[] textArray1 = new string[5] { text1, text2, "='", base.Attributes[text2], "'  " } ;
				text1 = string.Concat(textArray1);
			}
			if (this.Parent is System.Web.UI.UserControl)
			{
				output.WriteLine("  if (check_form(" + this.Parent.Parent.UniqueID + "))");
			}
			else
			{
				output.WriteLine("  if (check_form(" + this.Parent.UniqueID + "))");
			}
			output.WriteLine("   {" + this.Page.GetPostBackEventReference(this) + ";};    ");
			output.WriteLine("}");
			output.WriteLine("</script>");
			string[] textArray2 = new string[5] { "<a  id =\"", this.UniqueID, "\" href=\"javascript:myPostBack();\"  ", this.getStyle(), " " } ;
			output.Write(string.Concat(textArray2));
			output.Write(text1);
			output.Write(">");
			output.Write(" " + this.Text + "</a>");
		}
 

	}
}
