using System;
using System.Data;
using System.Web;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.File
{
	/// <summary>
	/// OfficeUtil 的摘要说明。
	/// </summary>
	public class OfficeUtil
	{
		public OfficeUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//		public static void CreateExcelFile(DataSet oIn, HttpResponse oResponse)
		//		{
		//			StringBuilder builder1 = new StringBuilder();
		//			DataTable table1 = oIn.Tables[0];
		//			StringWriter writer1 = new StringWriter();
		//			builder1.Append("<Table border=1>");
		//			builder1.Append("<TR>");
		//			for (int num1 = 0; num1 < table1.Columns.Count; num1++)
		//			{
		//				builder1.Append("<TD align=\"center\" >" + table1.Columns[num1].Caption + "</TD>");
		//			}
		//			builder1.Append("</TR>");
		//			for (int num2 = 0; num2 < table1.Rows.Count; num2++)
		//			{
		//				builder1.Append("<TR>");
		//				for (int num3 = 0; num3 < table1.Columns.Count; num3++)
		//				{
		//					builder1.Append("<TD align=\"center\" >" + table1.Rows[num2][num3].ToString() + "</TD>");
		//				}
		//				builder1.Append("</TR>");
		//			}
		//			builder1.Append("</Table>");
		//			oResponse.Clear();
		//			oResponse.ContentEncoding = Encoding.GetEncoding("GB2312");
		//			oResponse.AppendHeader("Content-Disposition", "attachment;filename=download.xls");
		//			writer1.Write(builder1.ToString());
		//			oResponse.Write(writer1.ToString());
		//			oResponse.End();
		//			builder1 = null;
		//			writer1.Close();
		//			table1 = null;
		//		}
 
		/// <summary>
		/// 返回指定路径文件的HTML预览版本
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public static string GetFileHtml(string FileName)
		{
			string Value="";
			switch(System.IO.Path.GetExtension(FileName).Replace(".","").ToUpper())
			{
				
				case "DOC":
					Value=Com.File.WordUtil.GetFileHtmlFromWord(FileName);
					break;
				case "XLS":
					Value=Com.File.ExcelUtil.GetFileHtmlFromExcel(FileName);
					break;
				case "PPT":
					Value=Com.File.PowerPointUtil.GetFileHtmlFromPowerPoint(FileName);
					break;
				case "PDF":
					break;
				case "RTF":
					Value=Com.File.RTFUtil.GetFileHtmlFromRTF(FileName);
					break;
				case "SWF":
					break;
					//-------------------以下为文本类型，直接提取---------------------
				case "TXT":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "HTML":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "HTM":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "CSS":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "JS":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "ASP":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "ASPX":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "INC":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "CS":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
				case "XML":
					Value=Com.File.FileUtil.GetFileContent(FileName);
					break;
			}
			return Value;
		}

		/// <summary>
		/// 返回指定路径文件的文本
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public static string GetFileText(string FileName)
		{
			string Value="";
			switch(System.IO.Path.GetExtension(FileName).Replace(".","").ToUpper())
			{
				
				case "DOC":
					Value=Com.File.WordUtil.GetFileTextFromWord(FileName);
					break;
				case "XLS":
					Value=Com.File.ExcelUtil.GetFileTextFromExcel(FileName);
					break;
				case "PPT":
					Value=Com.File.PowerPointUtil.GetFileTextFromPowerPoint(FileName);
					break;
				case "PDF":
					break;
				case "RTF":
					Value=Com.File.RTFUtil.GetFileTextFromRTF(FileName);
					break;
				case "SWF":
					break;
					//-------------------以下为文本类型，直接提取---------------------
				case "TXT":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "HTML":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "HTM":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "CSS":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "JS":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "ASP":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "ASPX":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "INC":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "CS":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
				case "XML":
					Value=Com.Net.HtmlUtil.GetPlainText(Com.File.FileUtil.GetFileContent(FileName));
					break;
			}
			return Value.Trim().Replace("\t","").Replace("\r\n","").Replace(" ","");
		}

		
		public static void CreateExcelFile(DataGrid oDg,HttpResponse oResponse)
		{
			oResponse.ContentType ="application/vnd.ms-excel";
			oResponse.Charset = "UTF-8";
			oResponse.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			oResponse.AddFileDependency("Sheet1.xls");
			oResponse.AppendHeader("Content-Disposition", "attachment;filename=Sheet1.xls");

			System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN",true);
			System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad); 
			System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
			oDg.RenderControl(oHtmlTextWriter); 
			oResponse.Write(oStringWriter.ToString());
			oResponse.End();

		}
		public static void CreateExcelFile(DataTable oDt,HttpResponse oResponse)
		{
			DataGrid oDg=new DataGrid();
			oDg.AutoGenerateColumns=false;
			foreach(DataColumn oDc in oDt.Columns)
			{
				BoundColumn oBc=new BoundColumn();
				oBc.DataField=oDc.ColumnName;
				oBc.HeaderText=oDc.ColumnName;
				string Datatype=oDc.DataType.ToString();
				if(Datatype=="System.Int16"||Datatype=="System.Int32"||Datatype=="System.Int64"||
					Datatype=="System.Decimal"||Datatype=="System.Double"||Datatype=="System.Byte"||
					Datatype=="System.Boolean")
				{
				
					oBc.ItemStyle.BackColor=System.Drawing.Color.LightBlue;
				}
				else if(Datatype=="System.DateTime")
				{
					oBc.ItemStyle.BackColor=System.Drawing.Color.LightGray;
				}
				oDg.Columns.Add(oBc);
			}
			oDg.DataSource=oDt;
			oDg.DataBind();
			foreach(DataColumn oDc in oDt.PrimaryKey)
			{
				foreach(DataGridColumn oDgc in oDg.Columns)
				{
					if(oDgc.HeaderText==oDc.ColumnName)
					{
						oDgc.ItemStyle.BackColor=System.Drawing.Color.Red;
						break;
					}
				}
			}
			CreateExcelFile(oDg,oResponse);
			oDg.Dispose();
		}
		public static void CreateExcelFile(DataSet oDs,HttpResponse oResponse)
		{
			if(oDs.Tables.Count>0)
			{
				OfficeUtil.CreateExcelFile(oDs.Tables[0],oResponse);
			}
		}
		public static void KillProcess(string processName)
		{
			//得到所有打开的进程
			try
			{
				foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(processName)) 
				{
					if(!thisproc.CloseMainWindow())
					{
						thisproc.Kill();
					}
				}
			}
			catch(Exception Exc)
			{
				Com.File.FileLog.WriteLog("Com.File.OfficeUtil", "杀死进程 " + processName + "失败！" +Exc.ToString());
			}
		}
	}
}
