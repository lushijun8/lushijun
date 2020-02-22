using System;
using System.Text;

namespace Com.Common
{
	/// <summary>
	/// ScriptUtil 的摘要说明。
	/// </summary>
	public class ScriptUtil
	{
		public ScriptUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string CatchPageKeyFunction(int KeyCode, string strOper)
		{
			StringBuilder builder1 = new StringBuilder();
			builder1.Append("<script language=javascript>\n");
			builder1.Append("function ___onKeyDown()\n");
			builder1.Append("{\n");
			builder1.Append("    if(event.keyCode==" + KeyCode + ")\n");
			builder1.Append("    {\n");
			builder1.Append("       " + strOper + "\n");
			builder1.Append("    }\n");
			builder1.Append("}\n");
			builder1.Append("document.onkeydown=___onKeyDown;\n");
			builder1.Append("</script>\n");
			return builder1.ToString();
		}
 
		public static string GetConfirmInfo(string strInput)
		{
			return (" if(confirm(\"" + strInput + "\")==false) return   ");
		}
 
		public static string GetConfirmInfo(string strInput, string style)
		{
			if (style == "1")
			{
				return (" if(confirm(" + strInput + ")==false) return false  ");
			}
			return (" if(confirm(\"" + strInput + "\")==false) return false  ");
		}
 
		public static string GetConfirmInfoByLinkButton(string strInput)
		{
			return (" if(confirm(\"" + strInput + "\")==false) return false  ");
		}
 
		public static string GetScriptInfo(string strInput)
		{
			strInput = "<script language='javascript'>" + strInput + "</script>";
			return strInput;
		}
 
		public static string GetShowAlertInfo(string strInput)
		{
			string text1 = "<script language='javascript'>alert('";
			return (text1 + strInput + "')</script>");
		}
 

	}
}
