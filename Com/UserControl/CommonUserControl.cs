using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.UserControl
{
	/// <summary>
	/// CommonUserControl 的摘要说明。
	/// </summary>
	public class CommonUserControl: Control, INamingContainer
	{
		public string Height;
		public string style;
		public string Width;

		public CommonUserControl()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public bool SetControlStyle(object oControl, string style)
		{
			bool flag1;
			try
			{
				string[] textArray2 = style.Split(";".ToCharArray());
				CssStyleCollection collection1 = (CssStyleCollection) oControl.GetType().GetProperty("Style").GetValue(oControl, null);
				for (int num1 = 0; num1 < textArray2.Length; num1++)
				{
					string[] textArray1 = textArray2[num1].Split(":".ToCharArray());
					collection1.Add(textArray1[0], textArray1[1]);
				}
				flag1 = true;
			}
			catch (Exception)
			{
				flag1 = false;
			}
			return flag1;
		}
 

	}
}
