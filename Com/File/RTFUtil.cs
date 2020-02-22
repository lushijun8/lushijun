using System;
using Microsoft.Office;
using System.Web;
using System.IO;
using System.Drawing;
using System.Threading;
namespace Com.File
{
	/// <summary>
	/// RTF 的摘要说明。
	/// </summary>
	public class RTFUtil
	{
		public RTFUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetFileHtmlFromRTF(string FileName)
		{
			string Value="";
			//另存为Html
			object Source=FileName;
			object Target=FileName.ToLower().Replace(".rtf","rtf.html");
			string HtmlFileName=FileName.ToLower().Replace(".rtf","rtf.html");
			object Unknown =Type.Missing;
			if(System.IO.File.Exists(FileName))
			{
				Word.Application newApp = new Word.Application(); 
				newApp.Visible = false;

				try
				{
					object openformat =Word.WdOpenFormat.wdOpenFormatRTF;
					newApp.Documents.Open(ref Source,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref openformat,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown,ref Unknown,ref Unknown);

					object format = Word.WdSaveFormat.wdFormatHTML;// kein XML, nutzen?
					newApp.ActiveDocument.SaveAs(ref Target,ref format, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown);
					newApp.Quit(ref Unknown,ref Unknown,ref Unknown);
					Thread.Sleep(1000);
					Value=Com.File.FileUtil.GetFileContent(HtmlFileName);
				}
				catch(Exception err)
				{
					Com.File.FileLog.WriteLog("WordUtil读取Html文件出错",err.ToString(),"");
				}
				finally
				{
					Thread.Sleep(1000);
					System.IO.FileInfo oFileInfo=new FileInfo(HtmlFileName.Replace(".html",".files")+"/filelist.xml");
					if(oFileInfo.Exists)
					{
						oFileInfo.Directory.Delete(true);
					}
					Com.File.FileUtil.DeleteFile(HtmlFileName);
					Com.File.OfficeUtil.KillProcess("WINWORD.EXE");
				}

			}
			return Value;
		}
		public static string GetFileTextFromRTF(string FileName)
		{
			string Value="";
			string Content=Com.File.RTFUtil.GetFileHtmlFromRTF(FileName);
			Value=Com.Net.HtmlUtil.GetPlainText(Content);
			return Value;
		}
		
	}
}
