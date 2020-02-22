using System;
using System.Collections;
using Microsoft.Office;
using System.Web;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
namespace Com.File
{
	/// <summary>
	/// ExcelUtil 的摘要说明。
	/// </summary>
	public class ExcelUtil
	{
		public ExcelUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetFileHtmlFromExcel(string FileName)
		{
			string Value="";

			string fileName = FileName;
			string HtmlFileName=FileName.ToLower().Replace(".xls","xls.html");
			//另存为Html
			int Sheet=0;
			if(System.IO.File.Exists(fileName))
			{
				Excel.Application   xls   =   new Excel.ApplicationClass();
				Object   missing   =     System.Reflection.Missing.Value;
				xls.Visible   =   true;
				
				try
				{
					xls.Workbooks.Open(fileName,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing,missing);
					Sheet=xls.Sheets.Count;
					xls.ActiveWorkbook.SaveAs(HtmlFileName,Excel.XlFileFormat.xlHtml,missing,missing,missing,missing,Excel.XlSaveAsAccessMode.xlNoChange,missing,missing,missing,missing,missing);
					xls.ActiveWorkbook.Close(true,missing,missing);
				}
				catch(Exception err)
				{
					Com.File.FileLog.WriteLog("ExcelUtil保存Html文件出错",err.ToString(),"");
					return "";
				}
				finally
				{
					xls.DisplayAlerts   =   false;
					xls.Quit();
					Com.File.OfficeUtil.KillProcess("EXCEL.EXE");
				}
			}
			Thread.Sleep(1000);//休眠1秒
			//如果已经保存文件,则获取文件内容
			System.IO.FileInfo oFileInfo=new FileInfo(HtmlFileName.Replace(".html",".files")+"/filelist.xml");
			if(oFileInfo.Exists)
			{
				Value+="<style>"+Com.File.FileUtil.GetFileContent(HtmlFileName.Replace(".html",".files")+"/stylesheet.css")+"</style>";
				try
				{
					for(int i=1;i<=Sheet;i++)
					{
						string SheetFile=HtmlFileName.Replace(".html",".files")+"/sheet"+i.ToString().PadLeft(3,'0')+".html";
						System.IO.FileInfo oSheet=new FileInfo(SheetFile);
						if(oSheet.Exists)
						{
							string Content=Com.File.FileUtil.GetFileContent(SheetFile);
							int TrimStartIndex=Content.IndexOf("<body");
							int TrimEndIndex=Content.IndexOf("</body>")+7;
							if(TrimStartIndex>=0 && TrimEndIndex>TrimStartIndex)
								Value+="<b>Sheet"+i.ToString().PadLeft(3,'0')+"</b><br><br>"+Content.Substring(TrimStartIndex,TrimEndIndex-TrimStartIndex)+"<hr>";
							else
								Value+=Content;
						}
					}
				}
				catch(Exception err)
				{
					Com.File.FileLog.WriteLog("ExcelUtil获取Html文件内容出错",err.ToString(),"");
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
		public static string GetFileTextFromExcel(string FileName)
		{
			string Value="";
			string Content=Com.File.ExcelUtil.GetFileHtmlFromExcel(FileName);
			Value=Com.Net.HtmlUtil.GetPlainText(Content);
			return Value;
		}
        public static string GetExcelStringFromDataSet(DataSet oDs)
        {
            StringBuilder xmlString = new StringBuilder(@"<?xml version='1.0'?><?mso-application progid='Excel.Sheet'?>");
            xmlString.Append("<Workbook xmlns='urn:schemas-microsoft-com:office:spreadsheet'");
            xmlString.Append(" xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel'");
            xmlString.Append(" xmlns:ss='urn:schemas-microsoft-com:office:spreadsheet' xmlns:html='http://www.w3.org/TR/REC-html40'>");

            xmlString.Append("<DocumentProperties xmlns='urn:schemas-microsoft-com:office:office'>");
            xmlString.Append("<Author></Author><LastAuthor></LastAuthor>");
            xmlString.Append("<Created></Created><Company></Company><Version></Version>");
            xmlString.Append("</DocumentProperties>");
            xmlString.Append("<Styleduo s><Style ss:ID='Default' ss:Name='Normal'><Alignment ss:Vertical='Center'/>");
            xmlString.Append("<Borders/><Font ss:FontName='宋体' x:CharSet='134' ss:Size='12'/><Interior/><NumberFormat/><Protection/></Style>");
            xmlString.Append("<Style ss:ID='Header'>");
            xmlString.Append("<Alignment ss:Horizontal=\"Center\" " + "ss:Vertical=\"Center\"/>");
            xmlString.Append("<Borders><Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='0'/>");
            xmlString.Append("<Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>");
            xmlString.Append("<Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='0'/>");
            xmlString.Append("<Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='0'/></Borders>");
            xmlString.Append("<Font ss:FontName='宋体' x:CharSet='134' ss:Size='10' ss:Bold='0'/></Style> ");
            xmlString.Append("</Styles>");
            System.Text.StringBuilder sb = new StringBuilder();
            foreach(DataTable oDt in oDs.Tables)
            {
                sb.Append(RenderExcelCell(oDt, oDt.TableName, true));
            }
            StringBuilder ExcelString = xmlString.Append(sb);
            ExcelString.Append("</Workbook>");
            return ExcelString.ToString();
        }

        /// <summary>
        /// 指定表头格式，用于有合并的较复杂的表头及单元格
        /// </summary>
        /// <param name="oDt"></param>
        /// <param name="SheetName"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static StringBuilder RenderExcelCell(DataTable oDt, string SheetName, bool format)
        {
            string tableHeader = "<Row>";
            string Columns = "";
            foreach (DataColumn oDc in oDt.Columns)
            {
                tableHeader += "<Cell ss:StyleID='Header'><Data ss:Type='String'>" + oDc.ColumnName + "</Data></Cell>";
                Columns += "<Column ss:AutoFitWidth='0' ss:Width='100'/>";

            }
            tableHeader += "</Row>";
            StringBuilder sb = new StringBuilder("<Worksheet ss:Name='" + SheetName + "'>");
            sb.Append("<Table x:FullColumns='1' x:FullRows='1' ss:DefaultRowHeight='20'>");
            sb.Append(Columns);
            //sb.Append("<Column ss:AutoFitWidth='0' ss:Width='140'/>"); 
            sb.Append(tableHeader);
            #region //数据 按顺序取head指定的前n列
            if (format == true)
            {
                for (int i = 0; i < oDt.Rows.Count; i++)
                {
                    sb.Append("<Row>");
                    for (int j = 0; j < oDt.Columns.Count; j++)
                    {
                        if (oDt.Columns[j].ColumnName != "RowNumber")
                        {
                            sb.Append("<Cell ss:StyleID='Header'>");
                            sb.Append("<Data ss:Type=\"String\">");
                            sb.Append(oDt.Rows[i][j] == null ? "" : oDt.Rows[i][j].ToString());
                            sb.Append("</Data></Cell>");
                        }
                    }
                    sb.Append("</Row>");
                }
            }
            else
            {
                for (int i = 0; i < oDt.Rows.Count; i++)
                {
                    StringBuilder sbRow = new StringBuilder();
                    sbRow.Append(format);
                    for (int j = 0; j < oDt.Columns.Count; j++)
                    {
                        sbRow = sbRow.Replace("{" + oDt.Columns[j].ColumnName + "}", oDt.Rows[i][j] == null ? "" : oDt.Rows[i][j].ToString());
                    }
                    sb.Append(sbRow.ToString());
                }
            }
            #endregion

            sb.Append("</Table>");
            sb.Append("</Worksheet>");
            return sb;

        }
	}
}
