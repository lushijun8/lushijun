using System;
using Microsoft.Office;
using System.Web;
using System.IO;
using System.Threading;

namespace Com.File
{
	/// <summary>
	/// PowerPoint 的摘要说明。
	/// </summary>
	public class PowerPointUtil
	{
		public PowerPointUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetFileHtmlFromPowerPoint(string FileName)
		{

			string Value="";

			string fileName = FileName;
			string HtmlFileName=FileName.ToLower().Replace(".ppt","ppt.html");
			//另存为Html
			if(System.IO.File.Exists(fileName))
			{

				PowerPoint.Application pptApp = new PowerPoint.ApplicationClass();
				PowerPoint.Presentation pptPre = pptApp.Presentations.Open(fileName,
					Microsoft.Office.Core.MsoTriState.msoTrue,
					Microsoft.Office.Core.MsoTriState.msoFalse,
					Microsoft.Office.Core.MsoTriState.msoFalse);
				try
				{
					pptPre.SaveAs(HtmlFileName,PowerPoint.PpSaveAsFileType.ppSaveAsHTML,Microsoft.Office.Core.MsoTriState.msoCTrue);
				}
				catch(Exception err)
				{
					Com.File.FileLog.WriteLog("PowerPointUtil保存Html文件出错",err.ToString(),"");
					return "";
				}
				finally
				{
					pptPre.Close();
					pptApp.Quit();
					Com.File.OfficeUtil.KillProcess("POWERPNT.EXE");
				}
			}
			Thread.Sleep(1000);//休眠1秒
			//如果已经保存文件,则获取文件内容
			System.IO.FileInfo oFileInfo=new FileInfo(HtmlFileName.Replace(".html",".files")+"/filelist.xml");
			if(oFileInfo.Exists)
			{
				System.IO.DirectoryInfo oDir=new System.IO.DirectoryInfo(HtmlFileName.Replace(".html",".files"));
				try
				{
					if(oDir.Exists)
					{
						FileInfo[] oFiles=oDir.GetFiles();
						Value+=@"<html xmlns:v="+"\""+@"urn:schemas-microsoft-com:vml"+"\""+@"
xmlns:o="+"\""+@"urn:schemas-microsoft-com:office:office"+"\""+@"
xmlns:p="+"\""+@"urn:schemas-microsoft-com:office:powerpoint"+"\""+@"
xmlns:oa="+"\""+@"urn:schemas-microsoft-com:office:activation"+"\""+@"
xmlns="+"\""+@"http://www.w3.org/TR/REC-html40"+"\""+@">

<head>
<meta http-equiv=Content-Type content="+"\""+@"text/html; charset=gb2312"+"\""+@">
<meta name=ProgId content=PowerPoint.Slide>
<meta name=Generator content="+"\""+@"Microsoft PowerPoint 11"+"\""+@">
<!--[if !mso]>
<style>
v\:* {behavior:url(#default#VML);}
o\:* {behavior:url(#default#VML);}
p\:* {behavior:url(#default#VML);}
.shape {behavior:url(#default#VML);}
v\:textbox {display:none;}
</style>
<![endif]-->
<title></title>
<meta name=Description
content="+"\""+@"2006-3-20: Similarity and Dissimilarity Between Objects (Cont.)"+"\""+@">

<![if !ppt]>


<style media=print>
<!--.sld
	{left:0px !important;
	width:6.0in !important;
	height:4.5in !important;
	font-size:107% !important;}
-->
</style><p:slidetransition advancetime="+"\""+@"0"+"\""+@" speed="+"\""+@"255"+"\""+@"
 effect="+"\""+@"strips"+"\""+@" direction="+"\""+@"rightDown"+"\""+@" flag="+"\""+@"1"+"\""+@"/><o:shapelayout v:ext="+"\""+@"edit"+"\""+@">
 <o:idmap v:ext="+"\""+@"edit"+"\""+@" data="+"\""+@"1414,1524"+"\""+@"/>
</o:shapelayout>";
						for(int i=0;i<oFiles.Length;i++)
						{
							if(oFiles[i].Name.ToLower().EndsWith(".css"))
							{
								Value+="<style>"+Com.File.FileUtil.GetFileContent(oFiles[i].FullName)+"</style>";
								break;
							}
						}
						for(int i=0;i<oFiles.Length;i++)
						{
							if(oFiles[i].Name.ToLower()=="script.js")
							{
								Value+="<script>"+Com.File.FileUtil.GetFileContent(oFiles[i].FullName)+"</script>";
								break;
							}
						}
						Value+="<script language=\"javascript\">"+
							"function ChangeBgColor(bcolor)"+
							"{document.all['SlideObj'].style.backgroundColor=bcolor;}"+
							"function ShowSlide(id)"+
							"{"+
							"for(var i=0;i<document.all[\"nav\"].length;i++)"+
							"{document.all[\"nav\"][i].style.backgroundColor=\"yellow\";}"+
							"if(document.all[\"Slide\"+id]!=null)"+
							"{document.all[\"nav\"][id].style.backgroundColor=\"red\";document.all[\"SlideObj\"].innerHTML=document.all[\"Slide\"+id].innerHTML;document.all[\"SlideIndex\"].value=id;}"+
							"else{document.all[\"SlideObj\"].innerHTML=document.all[\"Slide0\"].innerHTML;document.all[\"SlideIndex\"].value=\"0\";document.all[\"nav\"][0].style.backgroundColor=\"red\";}"+
							"}</script>";
						Value+="</head><body  lang=ZH-CN style=\"margin:0px;background-color:black\" onclick=\"DocumentOnClick()\" onresize=\"_RSW()\" onload=\"LoadSld();ShowSlide(0)\" onkeypress=\"_KPH()\">"+
							"<input type=\"hidden\" name=\"SlideIndex\" id=\"SlideIndex\" value=\"0\" /><div id=SlideObj class=sld style='position:absolute;top:100px;left:0px;width:534px;height:400px;font-size:16px;background-color:white;clip:rect(0%, 101%, 101%, 0%);visibility:hidden;filter:revealtrans(Duration=2, Transition=19)' onclick=\"javascript:ShowSlide(parseInt(document.all['SlideIndex'].value)+1)\"></div>";
						string ShowSlide="";
						int index=0;
						for(int i=0;i<oFiles.Length;i++)
						{
							if(oFiles[i].Name.ToLower().EndsWith(".html")&&oFiles[i].Name.ToLower().StartsWith("slide"))
							{
								try
								{
									string Content=Com.File.FileUtil.GetFileContent(oFiles[i].FullName);
									int TrimStartIndex=Content.IndexOf("<body");
									int TrimEndIndex=Content.IndexOf("</body>")+7;
									if(TrimStartIndex>=0 && TrimEndIndex>TrimStartIndex)
										Content=Content.Substring(TrimStartIndex,TrimEndIndex-TrimStartIndex);
									Content=Content.Remove(0,Content.IndexOf(">")+1).Replace("</body>","");


									string DivStyle=Content.Substring(Content.IndexOf("<div"),Content.IndexOf(">")+1-Content.IndexOf("<div"));
									TrimStartIndex=Content.IndexOf("<p:slide");
									TrimEndIndex=Content.IndexOf("</p:slide>")+10;
									if(TrimStartIndex>=0 && TrimEndIndex>TrimStartIndex)
										Value+=DivStyle.Replace("SlideObj","Slide"+index.ToString()+"").Replace("style='","style='display:none;")+Content.Substring(TrimStartIndex,TrimEndIndex-TrimStartIndex)+"</div>";
									else
										Value+=DivStyle.Replace("SlideObj","Slide"+index.ToString()+"").Replace("style='","style='display:none;")+Content+"</div>";
									ShowSlide+="<a href=\"javascript:ShowSlide("+index.ToString()+")\"><font style=\"background-color:yellow\" id=\"nav\" name=\"nav\"> "+index.ToString()+" </font></a>　";
									index++;
								}
								catch(Exception err)
								{
									Com.File.FileLog.WriteLog("PowerPointUtil获取Html文件内容出错",err.ToString(),"");
								}
							}
						}
						Value+="<br><div style='position:absolute;top:0px;left:0px;background-color:yellow;z-index:0:width:100%'>"+ShowSlide+"  背景颜色：<a href=\"javascript:ChangeBgColor('black')\">黑</a> <a href=\"javascript:ChangeBgColor('white')\">白</a> <a href=\"javascript:ChangeBgColor('red')\">红</a> <a href=\"javascript:ChangeBgColor('orange')\">橙</a> <a href=\"javascript:ChangeBgColor('yellow')\">黄</a> <a href=\"javascript:ChangeBgColor('green')\">绿</a></div></body></html>";
					}
				}
				catch(Exception err)
				{
					Com.File.FileLog.WriteLog("PowerPointUtil获取Html文件内容出错",err.ToString(),"");
				}
					//删除临时文件
				finally
				{
					Thread.Sleep(1000);//休眠1秒
					oFileInfo.Directory.Delete(true);
				}
			}
				//直接获取该文件的内容
			else
			{
				Value+=Com.File.FileUtil.GetFileContent(HtmlFileName);
			}
			Thread.Sleep(1000);//休眠1秒
			Com.File.FileUtil.DeleteFile(HtmlFileName);
			return Value;
		}
		public static string GetFileTextFromPowerPoint(string FileName)
		{
			string Value="";
			string Content=Com.File.PowerPointUtil.GetFileHtmlFromPowerPoint(FileName);
//			for(int i=0;i<10;i++)
//			{
//				int TrimStartIndex=Content.ToLower().IndexOf("<style");
//				int TrimEndIndex=Content.ToLower().IndexOf("</style>")+8;
//				if(TrimStartIndex>=0 && TrimEndIndex>TrimStartIndex)
//					Content=Content.Remove(TrimStartIndex,TrimEndIndex-TrimStartIndex);
//				if(Content.ToLower().IndexOf("<style")==-1)
//					break;
//			}
//			for(int i=0;i<10;i++)
//			{
//				int TrimStartIndex=Content.ToLower().IndexOf("<script");
//				int TrimEndIndex=Content.ToLower().IndexOf("</script>")+9;
//				if(TrimStartIndex>=0 && TrimEndIndex>TrimStartIndex)
//					Content=Content.Remove(TrimStartIndex,TrimEndIndex-TrimStartIndex);
//				if(Content.ToLower().IndexOf("<script")==-1)
//					break;
//			}

			Value=Com.Net.HtmlUtil.GetPlainText(Content);

			return Value;
		}
	}
}
