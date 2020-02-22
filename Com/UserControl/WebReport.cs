//********************************************************************
//                通用报表控件 1.0  2004年5月份   作者：陆世军
//********************************************************************
#region using
using System;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
#endregion
namespace Com.UserControl
{
	/// <summary>
	/// 1、这是一个通用报表打印控件，用户只需要传入DataSource、Template(用‘[..]’将要套打的数据列名标识出来的字符串模板)。[Date]---当前日期；[PageNext]----分页打印
	/// 2、默认情况下只分一页，用户可以自定义分页，可以定义每页打印模板数。
	/// 3、用户可以根据需要选择“套打形式”、“列表形式”、“统计分析”。
	/// 4、页面上提供模板接口，id=控件ID+'InputTemplate' 的Value值。
	/// 5、版本：1.0。
	/// </summary>
	[ParseChildren(true),DefaultProperty("Template"),PersistChildren(false),Designer(typeof(WebReportDesigner)),
	ToolboxData("<{0}:WebReport runat=\"server\"></{0}:WebReport>")]
	public class WebReport: System.Web.UI.Control
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public WebReport()
		{

		}
		#region 变量
		private TableItemStyle _AlternatingItemStyle;	//交替项样式
		private TableItemStyle _HeaderStyle;	//报表头样式
		private TableItemStyle _ItemStyle;	//数据项样式
		private Style _Style;	//字体属性
		private LiteralControl tBody;	//报表内容
		#region -------页面上注册的隐藏文本框----------
		private HtmlInputHidden InputTemplate; //页面的模板HTML
		private HtmlInputHidden InputCurrentPageIndex; //当前页面索引
		private HtmlInputHidden InputPageSize; //每页显示记录数
		private HtmlInputHidden InputPrintColumns; //显示列数
		private HtmlInputHidden InputPrintSize; //打印行数
		#endregion
		#region -------顶端工具栏---------
		private Table tToolBar;	//工具栏
		private LinkButton ibFirst;	//第一个记录
		private LinkButton ibPre;	//前一个记录
		private LinkButton ibNext;	//下一个记录
		private LinkButton ibLast;	//最后一个记录
		private DropDownList ddlCurrentPageIndex;	//页码
		private TextBox tbPageSize;	//每页记录数
		private Label lPageCount;	//页面总数
		private Label lRowCount;	//记录总数
		private Label lRowFrom;	//开始记录号
		private Label lRowTo;	//结束记录号
		private TextBox tbPrintColumns;	//显示列数
		private TextBox tbPrintSize;	//每页打印行数
		private LinkButton ibGo;	//执行按钮
		private HtmlAnchor ibPrint;	//打印按钮
		private HtmlAnchor ibTemplate;	//模板编辑按钮
		private LinkButton ibExport;	//导出Excel按钮
		private LinkButton ibAnalysis;	//统计分析按钮
		private LinkButton ibFreeForm;	//套打形式
		private LinkButton ibListForm;	//列表形式
		private LinkButton ibSendEmail;	//群发邮件
		private LinkButton ibSendFax;	//群发传真
		private LinkButton ibSendSms;	//群发短信
		#endregion

		//========================================

		#region --------底端工具栏--------
		private Table tToolBar1;	//工具栏
		private LinkButton ibFirst1;	//第一个记录
		private LinkButton ibPre1;	//前一个记录
		private LinkButton ibNext1;	//下一个记录
		private LinkButton ibLast1;	//最后一个记录
		private DropDownList ddlCurrentPageIndex1;	//页码
		private TextBox tbPageSize1;	//每页记录数
		private Label lPageCount1;	//页面总数
		private Label lRowCount1;	//记录总数
		private Label lRowFrom1;	//开始记录号
		private Label lRowTo1;	//结束记录号
		private TextBox tbPrintColumns1;	//显示列数
		private TextBox tbPrintSize1;	//每页打印行数
		private LinkButton ibGo1;	//执行按钮
		private HtmlAnchor ibPrint1;	//打印按钮
		private HtmlAnchor ibTemplate1;	//模板编辑按钮
		private LinkButton ibExport1;	//导出Excel按钮
		private LinkButton ibAnalysis1;	//统计分析按钮
		private LinkButton ibFreeForm1;	//套打形式
		private LinkButton ibListForm1;	//列表形式
		private LinkButton ibSendEmail1;	//群发邮件
		private LinkButton ibSendFax1;	//群发传真
		private LinkButton ibSendSms1;	//群发短信
		#endregion
		#endregion

		#region 事件
		public event EventHandler OnSendEmailClick;
		public event EventHandler OnSendFaxClick;
		public event EventHandler OnSendSmsClick;
		#endregion

		#region 属性
		#region 外观
		/// <summary>
		/// 背景颜色
		/// </summary>
		[Category("AppearanceProperty"),Description("背景颜色"),DefaultValue("#ffffff")]
		public Color BackColor
		{
			get
			{
				if(ViewState["BackColor"]==null)
				{
					ViewState["BackColor"]=Color.White;
					return Color.White;
				}
				else
				{
					return (Color)ViewState["BackColor"];
				}
			}
			set
			{
				ViewState["BackColor"] = value;
			}
		}
		/// <summary>
		/// 报表背景图片
		/// </summary>
		[Category("AppearanceProperty"),Description("背景图片"),DefaultValue(""),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string BackImageUrl
		{
			get
			{
				if(ViewState["BackImageUrl"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["BackImageUrl"];
				}
			}
			set
			{
				ViewState["BackImageUrl"] = value;
			}
		}
		/// <summary>
		/// 报表边框颜色
		/// </summary>
		[Category("AppearanceProperty"),Description("报表边框颜色")]
		public Color BorderColor
		{
			get
			{
				if(ViewState["BorderColor"]==null)
				{
					ViewState["BorderColor"]=Color.Empty;
					return Color.Empty;
				}
				else
				{
					return (Color)ViewState["BorderColor"];
				}
			}
			set
			{
				ViewState["BorderColor"] = value;
			}
		}
		/// <summary>
		/// 报表边框样式
		/// </summary>
		[Category("AppearanceProperty"),Description("报表边框样式"),DefaultValue(BorderStyle.None)]
		public BorderStyle BorderStyle
		{
			get
			{
				if(ViewState["BorderStyle"]==null)
				{
					ViewState["BorderStyle"]=BorderStyle.None;
					return BorderStyle.None;
				}
				else
				{
					return (BorderStyle)ViewState["BorderStyle"];
				}
			}
			set
			{
				ViewState["BorderStyle"] = value;
			}
		}
		/// <summary>
		/// 表格线宽
		/// </summary>
		[Category("DataProperty"),Description("表格线宽")]
		public Unit BorderWidth
		{
			get
			{
				if(ViewState["BorderWidth"]==null)
				{
					ViewState["BorderWidth"]=new Unit("0");
					return new Unit("0");
				}
				else
				{
					return (Unit)ViewState["BorderWidth"];
				}
			}
			set
			{
				ViewState["BorderWidth"] = value;
			}
		}
		/// <summary>
		/// 样式类CssClass
		/// </summary>
		[Category("AppearanceProperty"),Description("样式类CssClass"),DefaultValue("")]
		public string CssClass
		{
			get
			{
				if(ViewState["CssClass"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["CssClass"];
				}
			}
			set
			{
				ViewState["CssClass"] = value;
			}
		}
		/// <summary>
		/// 报表字体属性
		/// </summary>
		[Category("AppearanceProperty"),Description("报表字体属性"),NotifyParentProperty(true),DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public FontInfo Font
		{
			get
			{
				if (_Style == null) 
				{
					_Style = new Style();
					if (IsTrackingViewState) 
					{
						((IStateManager)_Style).TrackViewState();
					}
				}
				return _Style.Font;
			}
		}
		/// <summary>
		/// 报表字体颜色
		/// </summary>
		[Category("AppearanceProperty"),Description("报表字体颜色")]
		public Color ForeColor
		{
			get
			{
				if(ViewState["ForeColor"]==null)
				{
					ViewState["ForeColor"]=Color.Empty;
					return Color.Empty;
				}
				else
				{
					return (Color)ViewState["ForeColor"];
				}
			}
			set
			{
				ViewState["ForeColor"] = value;
			}
		}
		/// <summary>
		/// 报表字体颜色
		/// </summary>
		[Category("AppearanceProperty"),Description("报表字体颜色"),DefaultValue(GridLines.None)]
		public GridLines GridLines
		{
			get
			{
				if(ViewState["GridLines"]==null)
				{
					ViewState["GridLines"]=GridLines.None;
					return GridLines.None;
				}
				else
				{
					return (GridLines)ViewState["GridLines"];
				}
			}
			set
			{
				ViewState["GridLines"] = value;
			}
		}
		/// <summary>
		/// 报表宽度
		/// </summary>
		[Category("DataProperty"),Description("报表宽度"),DefaultValue("800px")]
		public Unit Width
		{
			get
			{
				if(ViewState["Width"]==null)
				{
					return new Unit("800px");
				}
				else
				{
					return (Unit)ViewState["Width"];
				}
			}
			set
			{
				ViewState["Width"] = value;
			}
		}
		/// <summary>
		/// 报表高度
		/// </summary>
		[Category("DataProperty"),Description("报表高度"),DefaultValue("1070px")]
		public Unit Height
		{
			get
			{
				if(ViewState["Height"]==null)
				{
					return new Unit("1070px");
				}
				else
				{
					return (Unit)ViewState["Height"];
				}
			}
			set
			{
				ViewState["Height"] = value;
			}
		}
		#endregion
		#region 数据
		/// <summary>
		/// 
		/// </summary>
		[Category("DataProperty"),Description("纸张页眉")]
		public string PageHeader
		{
			get
			{
				if(ViewState["PageHeader"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["PageHeader"];
				}
			}
			set
			{
				ViewState["PageHeader"] = value;
			}
		}
		/// <summary>
		/// 纸张页脚
		/// </summary>
		[Category("DataProperty"),Description("纸张页脚")]
		public string PageFooter
		{
			get
			{
				if(ViewState["PageFooter"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["PageFooter"];
				}
			}
			set
			{
				ViewState["PageFooter"] = value;
			}
		}
		/// <summary>
		/// 报表页眉
		/// </summary>
		[Category("DataProperty"),Description("报表页眉")]
		public string Header
		{
			get
			{
				if(ViewState["Header"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["Header"];
				}
			}
			set
			{
				ViewState["Header"] = value;
			}
		}
		/// <summary>
		/// 套打出来的报表内容：HTML
		/// </summary>
		[Category("DataProperty"),Description("套打出来的报表内容：HTML")]
		private string ReportHtml
		{
			get
			{
				if(ViewState["ReportHtml"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["ReportHtml"];
				}
			}
			set
			{
				ViewState["ReportHtml"] = value;
			}
		}
		/// <summary>
		/// 报表页脚
		/// </summary>
		[Category("DataProperty"),Description("报表页脚")]
		public string Footer
		{
			get
			{
				if(ViewState["Footer"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["Footer"];
				}
			}
			set
			{
				ViewState["Footer"] = value;
			}
		}
		/// <summary>
		/// 报表形式：套打、列表
		/// </summary>
		[Category("StyleProperty"),Description("报表形式：套打、列表"),DefaultValue(ReportStyle.ListForm)]
		public ReportStyle ReportStyle
		{
			get
			{
				if(ViewState["ReportStyle"]==null)
				{
					ViewState["ReportStyle"]=ReportStyle.FreeForm;
					return ReportStyle.FreeForm;
				}
				else
				{
					return (ReportStyle)ViewState["ReportStyle"];
				}
				
			}
			set
			{
				ViewState["ReportStyle"] = value;
			}
		}
		/// <summary>
		/// 工具栏显示方式:上、下、上下
		/// </summary>
		[Category("StyleProperty"),Description("工具栏显示方式:上、下、上下"),DefaultValue(ToolBarStyle.Top)]
		public ToolBarStyle ToolBarStyle
		{
			get
			{
				if(ViewState["ToolBarStyle"]==null)
				{
					ViewState["ToolBarStyle"]=ToolBarStyle.Top;
					return ToolBarStyle.Top;
				}
				else
				{
					return (ToolBarStyle)ViewState["ToolBarStyle"];
				}
				
			}
			set
			{
				ViewState["ToolBarStyle"] = value;
			}
		}
		/// <summary>
		/// 报表眉脚样式：分页、不分页
		/// </summary>
		[Category("StyleProperty"),Description("报表眉脚样式：分页、不分页"),DefaultValue(Header_FooterStyle.NoCycle)]
		public Header_FooterStyle Header_FooterStyle
		{
			get
			{
				if(ViewState["Header_FooterStyle"]==null)
				{
					ViewState["Header_FooterStyle"]=Header_FooterStyle.NoCycle;
					return Header_FooterStyle.NoCycle;
				}
				else
				{
					return (Header_FooterStyle)ViewState["Header_FooterStyle"];
				}
				
			}
			set
			{
				ViewState["Header_FooterStyle"] = value;
			}
		}
		/// <summary>
		/// 列表形式下的交替项样式
		/// </summary>
		[Category("ListFormStyleProperty"),Description("列表形式下的交替项样式"),NotifyParentProperty(true),DesignerSerializationVisibility(DesignerSerializationVisibility.Content),PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle AlternatingItemStyle
		{
			get
			{
				if (_AlternatingItemStyle == null) 
				{
					_AlternatingItemStyle = new TableItemStyle();
					if (IsTrackingViewState) 
					{
						((IStateManager)_AlternatingItemStyle).TrackViewState();
					}
				}
				return _AlternatingItemStyle;
			}

		}
		/// <summary>
		/// 列表形式下的表头样式
		/// </summary>
		[Category("ListFormStyleProperty"),Description("列表形式下的表头样式"),NotifyParentProperty(true),DesignerSerializationVisibility(DesignerSerializationVisibility.Content),PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle HeaderStyle
		{
			get
			{
				if (_HeaderStyle == null) 
				{
					_HeaderStyle = new TableItemStyle();
					if (IsTrackingViewState) 
					{
						((IStateManager)_HeaderStyle).TrackViewState();
					}
				}
				return _HeaderStyle;
			}

		}
		/// <summary>
		/// 列表形式下的数据项样式
		/// </summary>
		[Category("ListFormStyleProperty"),Description("列表形式下的数据项样式"),NotifyParentProperty(true),DesignerSerializationVisibility(DesignerSerializationVisibility.Content),PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle ItemStyle
		{
			get
			{
				if (_ItemStyle == null) 
				{
					_ItemStyle = new TableItemStyle();
					_ItemStyle.HorizontalAlign=HorizontalAlign.Center;
					_ItemStyle.VerticalAlign=VerticalAlign.Middle;
					if (IsTrackingViewState) 
					{
						((IStateManager)_ItemStyle).TrackViewState();
					}
				}
				return _ItemStyle;
			}
		}
		/// <summary>
		/// 套打模板
		/// </summary>
		[Category("DataProperty"),Description("套打模板")]
		public string Template
		{
			get
			{
				if(ViewState["Template"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["Template"];
				}
			}
			set
			{
				ViewState["Template"] = value;
			}
		}
		/// <summary>
		/// 列表形式专用模板
		/// </summary>
		[Category("DataProperty"),Description("列表形式专用模板")]
		private string ListTemplate
		{
			get
			{
				if(ViewState["ListTemplate"]==null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["ListTemplate"];
				}
			}
			set
			{
				ViewState["ListTemplate"] = value;
			}
		}
		//		/// <summary>
		//		/// DataSet,默认取第一张DataTable
		//		/// </summary>
		//		[Category("DataProperty"),Description("DataSource"),TypeConverter(typeof(DataSetTypeConverter))]
		//		public DataSet DataSource
		//		{
		//			get
		//			{
		//				if(ViewState["DataSource"]==null)
		//				{
		//					return null;
		//				}
		//				else
		//				{
		//					return (DataSet)ViewState["DataSource"];
		//				}
		//			}
		//			set
		//			{
		//				ViewState["DataSource"] = value;
		//			}
		//		}
		/// <summary>
		/// DataSource，可以为空
		/// </summary>
		[Category("DataProperty"),Description("DataSource"),TypeConverter(typeof(DataTableTypeConverter))]
		public DataTable DataSource
		{
			get
			{
				if(ViewState["DataSource"]==null)
				{
					return null;
				}
				else
				{
					return (DataTable)ViewState["DataSource"];
				}
			}
			set
			{
				ViewState["DataSource"] = value;
				string Tem="";
				foreach(DataColumn oDc in this.DataSource.Columns)
				{
					Tem+="["+oDc.ColumnName+"]</td><td>";
				}
				char[] cTem=new char[]{'/','<','t','d','>'};
				Tem=Tem.TrimEnd(cTem);
				if(this.Template==null || this.Template=="")
				{
					this.Template=Tem;
				}
				this.ListTemplate=Tem;
				if(this.PrintSize==1000)
				{
					if(DataSource.Rows.Count!=0)
					{
						this.PrintSize=DataSource.Rows.Count;
					}
				}
			}
		}
		/// <summary>
		/// 当前页面索引
		/// </summary>
		[Category("DataProperty"),Description("当前页面索引")]
		public int CurrentPageIndex
		{
			get
			{
				if(ViewState["CurrentPageIndex"]==null)
				{
					return 0;
				}
				else
				{
					return (int)ViewState["CurrentPageIndex"];
				}
			}
			set
			{
				ViewState["CurrentPageIndex"] = value;
			}
		}
		
		/// <summary>
		/// 每页显示记录数
		/// </summary>
		[Category("DataProperty"),Description("每页显示记录数")]
		public int PageSize
		{
			get
			{
				if(ViewState["PageSize"]==null)
				{
					return 1000;
				}
				else
				{
					return (int)ViewState["PageSize"];
				}
			}
			set
			{
				ViewState["PageSize"] = value;
			}
		}
		/// <summary>
		/// 每页打印模板行数
		/// </summary>
		[Category("DataProperty"),Description("每页打印模板行数")]
		public int PrintSize
		{
			get
			{
				if(ViewState["PrintSize"]==null)
				{
					return 1000;
				}
				else
				{
					return (int)ViewState["PrintSize"];
				}
			}
			set
			{
				ViewState["PrintSize"] = value;
			}
		}
		/// <summary>
		/// 每页打印模板列数
		/// </summary>
		[Category("DataProperty"),Description("每页打印模板列数")]
		public int PrintColumns
		{
			get
			{
				if(ViewState["PrintColumns"]==null)
				{
					return 1;
				}
				else
				{
					return (int)ViewState["PrintColumns"];
				}
			}
			set
			{
				ViewState["PrintColumns"] = value;
			}
		}
		public string[] Items
		{
			get
			{
				string[] Templates=new string[this.DataSource.Rows.Count];
				int i=0;
				foreach(DataRow oDr in this.DataSource.Rows)
				{
					foreach(DataColumn oDc in this.DataSource.Columns)
					{
						Templates[i]=this.Template.Replace("["+oDc.ColumnName+"]",oDr[oDc.ColumnName].ToString());
					}
					i++;
				}
				return Templates;
			}
		}
		#endregion
		#region 图片路径
		/// <summary>
		/// 首页图片
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/First16.gif"),Description("首页图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string FirstPageImgUrl
		{
			get
			{
				if(ViewState["FirstPageImgUrl"]==null)
				{
					ViewState["FirstPageImgUrl"]="../../../pub/img/button/First16.gif";
					return "../../../pub/img/button/First16.gif";
				}
				else
				{
					return (string)ViewState["FirstPageImgUrl"];
				}
			}
			set
			{
				ViewState["FirstPageImgUrl"] = value;
			}
		}
		/// <summary>
		/// 前页记录图片
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/Pre16.gif"),Description("前页记录图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string PrePageImgUrl
		{
			get
			{
				if(ViewState["PrePageImgUrl"]==null)
				{
					ViewState["PrePageImgUrl"]="../../../pub/img/button/Pre16.gif";
					return "../../../pub/img/button/Pre16.gif";
				}
				else
				{
					return (string)ViewState["PrePageImgUrl"];
				}
			}
			set
			{
				ViewState["PrePageImgUrl"] = value;
			}
		}
		/// <summary>
		///  下一页记录图片
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/Next16.gif"),Description("下一页记录图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string NextPageImgUrl
		{
			get
			{
				if(ViewState["NextPageImgUrl"]==null)
				{
					ViewState["NextPageImgUrl"]="../../../pub/img/button/Next16.gif";
					return "../../../pub/img/button/Next16.gif";
				}
				else
				{
					return (string)ViewState["NextPageImgUrl"];
				}
			}
			set
			{
				ViewState["NextPageImgUrl"] = value;
			}
		}
		/// <summary>
		///  最后一页记录图片
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/Last16.gif"),Description("最后一页记录图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string LastPageImgUrl
		{
			get
			{
				if(ViewState["LastPageImgUrl"]==null)
				{
					ViewState["LastPageImgUrl"]="../../../pub/img/button/Last16.gif";
					return "../../../pub/img/button/Last16.gif";
				}
				else
				{
					return (string)ViewState["LastPageImgUrl"];
				}
			}
			set
			{
				ViewState["LastPageImgUrl"] = value;
			}
		}
		/// <summary>
		/// Go按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/Go16.gif"),Description("GO按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string GoButtonImgUrl
		{
			get
			{
				if(ViewState["GoButtonImgUrl"]==null || (string)ViewState["GoButtonImgUrl"]=="")
				{
					ViewState["GoButtonImgUrl"]="../../../pub/img/button/Go16.gif";
					return "../../../pub/img/button/Go16.gif";
				}
				else
				{
					return (string)ViewState["GoButtonImgUrl"];
				}
			}
			set
			{
				ViewState["GoButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 打印按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/Print16.gif"),Description("打印按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string PrintButtonImgUrl
		{
			get
			{
				if(ViewState["PrintButtonImgUrl"]==null || (string)ViewState["PrintButtonImgUrl"]=="")
				{
					ViewState["PrintButtonImgUrl"]="../../../pub/img/button/Print16.gif";
					return "../../../pub/img/button/Print16.gif";
				}
				else
				{
					return (string)ViewState["PrintButtonImgUrl"];
				}
			}
			set
			{
				ViewState["PrintButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 模板按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/Template16.gif"),Description("模板按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string TemplateButtonImgUrl
		{
			get
			{
				if(ViewState["TemplateButtonImgUrl"]==null || (string)ViewState["TemplateButtonImgUrl"]=="")
				{
					ViewState["TemplateButtonImgUrl"]="../../../pub/img/button/Template16.gif";
					return "../../../pub/img/button/Template16.gif";
				}
				else
				{
					return (string)ViewState["TemplateButtonImgUrl"];
				}
			}
			set
			{
				ViewState["TemplateButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 统计分析按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/Analysis16.gif"),Description("统计分析按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string AnalysisButtonImgUrl
		{
			get
			{
				if(ViewState["AnalysisButtonImgUrl"]==null || (string)ViewState["AnalysisButtonImgUrl"]=="")
				{
					ViewState["AnalysisButtonImgUrl"]="../../../pub/img/button/Analysis16.gif";
					return "../../../pub/img/button/Analysis16.gif";
				}
				else
				{
					return (string)ViewState["AnalysisButtonImgUrl"];
				}
			}
			set
			{
				ViewState["AnalysisButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 套打形式按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/FreeForm16.gif"),Description("套打形式按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string FreeFormButtonImgUrl
		{
			get
			{
				if(ViewState["FreeFormButtonImgUrl"]==null || (string)ViewState["FreeFormButtonImgUrl"]=="")
				{
					ViewState["FreeFormButtonImgUrl"]="../../../pub/img/button/FreeForm16.gif";
					return "../../../pub/img/button/FreeForm16.gif";
				}
				else
				{
					return (string)ViewState["FreeFormButtonImgUrl"];
				}
			}
			set
			{
				ViewState["FreeFormButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 列表形式按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/ListForm16.gif"),Description("列表形式按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string ListFormButtonImgUrl
		{
			get
			{
				if(ViewState["ListFormButtonImgUrl"]==null || (string)ViewState["ListFormButtonImgUrl"]=="")
				{
					ViewState["ListFormButtonImgUrl"]="../../../pub/img/button/ListForm16.gif";
					return "../../../pub/img/button/ListForm16.gif";
				}
				else
				{
					return (string)ViewState["ListFormButtonImgUrl"];
				}
			}
			set
			{
				ViewState["ListFormButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 群发邮件按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/SendEmail16.gif"),Description("群发邮件按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string SendEmailButtonImgUrl
		{
			get
			{
				if(ViewState["SendEmailButtonImgUrl"]==null || (string)ViewState["SendEmailButtonImgUrl"]=="")
				{
					ViewState["SendEmailButtonImgUrl"]="../../../pub/img/button/SendEmail16.gif";
					return "../../../pub/img/button/SendEmail16.gif";
				}
				else
				{
					return (string)ViewState["SendEmailButtonImgUrl"];
				}
			}
			set
			{
				ViewState["SendEmailButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 群发传真按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/SendFax16.gif"),Description("群发传真按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string SendFaxButtonImgUrl
		{
			get
			{
				if(ViewState["SendFaxButtonImgUrl"]==null || (string)ViewState["SendFaxButtonImgUrl"]=="")
				{
					ViewState["SendFaxButtonImgUrl"]="../../../pub/img/button/SendFax16.gif";
					return "../../../pub/img/button/SendFax16.gif";
				}
				else
				{
					return (string)ViewState["SendFaxButtonImgUrl"];
				}
			}
			set
			{
				ViewState["SendFaxButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 群发短信按钮图片路径
		/// </summary>
		[Category("ImgUrlProperty"),DefaultValue("../../../pub/img/button/SendSms16.gif"),Description("群发短信按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string SendSmsButtonImgUrl
		{
			get
			{
				if(ViewState["SendSmsButtonImgUrl"]==null || (string)ViewState["SendSmsButtonImgUrl"]=="")
				{
					ViewState["SendSmsButtonImgUrl"]="../../../pub/img/button/SendSms16.gif";
					return "../../../pub/img/button/SendSms16.gif";
				}
				else
				{
					return (string)ViewState["SendSmsButtonImgUrl"];
				}
			}
			set
			{
				ViewState["SendSmsButtonImgUrl"] = value;
			}
		}
		#endregion
		#region 设置显示参数
		/// <summary>
		/// 是否显示页码
		/// </summary>
		[Category("BoolProperty"),DefaultValue(true),Description("是否显示页码")]
		public bool ShowPageNumber
		{
			get
			{
				
				if(ViewState["ShowPageNumber"]==null)
				{
					ViewState["ShowPageNumber"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowPageNumber"];
				}
				
			}
			set
			{
				ViewState["ShowPageNumber"] = value;
			}
		}
		/// <summary>
		/// 是否显示导航分页工具栏
		/// </summary>
		[Category("BoolProperty"),DefaultValue(true),Description("是否显示导航分页工具栏")]
		public bool ShowNavigationBar
		{
			get
			{
				
				if(ViewState["ShowNavigationBar"]==null)
				{
					ViewState["ShowNavigationBar"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowNavigationBar"];
				}
				
			}
			set
			{
				ViewState["ShowNavigationBar"] = value;
			}
		}
		/// <summary>
		/// 是否显示打印按钮
		/// </summary>
		[Category("BoolProperty"),DefaultValue(true),Description("是否显示打印按钮")]
		public bool ShowPrintButton
		{
			get
			{
				
				if(ViewState["ShowPrintButton"]==null)
				{
					ViewState["ShowPrintButton"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowPrintButton"];
				}
				
			}
			set
			{
				ViewState["ShowPrintButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示模板按钮
		/// </summary>
		[Category("BoolProperty"),DefaultValue(true),Description("是否显示模板按钮")]
		public bool ShowTemplateButton
		{
			get
			{
				
				if(ViewState["ShowTemplateButton"]==null)
				{
					ViewState["ShowTemplateButton"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowTemplateButton"];
				}
				
			}
			set
			{
				ViewState["ShowTemplateButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示导出Excel按钮
		/// </summary>
		[Category("BoolProperty"),DefaultValue(true),Description("是否显示导出Excel按钮")]
		public bool ShowExportButton
		{
			get
			{
				
				if(ViewState["ShowExportButton"]==null)
				{
					ViewState["ShowExportButton"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowExportButton"];
				}
				
			}
			set
			{
				ViewState["ShowExportButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示统计分析按钮
		/// </summary>
		[Category("BoolProperty"),DefaultValue(false),Description("是否显示统计分析按钮")]
		public bool ShowAnalysisButton
		{
			get
			{
				
				if(ViewState["ShowAnalysisButton"]==null)
				{
					ViewState["ShowAnalysisButton"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["ShowAnalysisButton"];
				}
				
			}
			set
			{
				ViewState["ShowAnalysisButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示报表形式按钮：套打形式、列表形式
		/// </summary>
		[Category("BoolProperty"),DefaultValue(false),Description("是否显示报表形式按钮：套打形式、列表形式")]
		public bool ShowReportStyleButton
		{
			get
			{
				
				if(ViewState["ShowReportStyleButton"]==null)
				{
					ViewState["ShowReportStyleButton"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["ShowReportStyleButton"];
				}
				
			}
			set
			{
				ViewState["ShowReportStyleButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示群发邮件按钮
		/// </summary>
		[Category("BoolProperty"),DefaultValue(false),Description("是否显示群发邮件按钮")]
		public bool ShowSendEmailButton
		{
			get
			{
				
				if(ViewState["ShowSendEmailButton"]==null)
				{
					ViewState["ShowSendEmailButton"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["ShowSendEmailButton"];
				}
				
			}
			set
			{
				ViewState["ShowSendEmailButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示群发传真按钮
		/// </summary>
		[Category("BoolProperty"),DefaultValue(false),Description("是否显示群发传真按钮")]
		public bool ShowSendFaxButton
		{
			get
			{
				
				if(ViewState["ShowSendFaxButton"]==null)
				{
					ViewState["ShowSendFaxButton"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["ShowSendFaxButton"];
				}
				
			}
			set
			{
				ViewState["ShowSendFaxButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示群发短信按钮
		/// </summary>
		[Category("BoolProperty"),DefaultValue(false),Description("是否显示群发短信按钮")]
		public bool ShowSendSmsButton
		{
			get
			{
				
				if(ViewState["ShowSendSmsButton"]==null)
				{
					ViewState["ShowSendSmsButton"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["ShowSendSmsButton"];
				}
				
			}
			set
			{
				ViewState["ShowSendSmsButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示列表形式的表头
		/// </summary>
		[Category("ListFormStyleProperty"),DefaultValue(true),Description("是否显示列表形式的表头")]
		public bool ShowHeader
		{
			get
			{
				
				if(ViewState["ShowHeader"]==null)
				{
					ViewState["ShowHeader"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowHeader"];
				}
				
			}
			set
			{
				ViewState["ShowHeader"] = value;
			}
		}
		/// <summary>
		/// 是否显示行号
		/// </summary>
		[Category("BoolProperty"),DefaultValue(true),Description("是否显示行号")]
		public bool ShowRowCount
		{
			get
			{
				if(ViewState["ShowRowCount"]==null)
				{
					ViewState["ShowRowCount"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowRowCount"];
				}
				
			}
			set
			{
				ViewState["ShowRowCount"] = value;
			}
		}
		/// <summary>
		/// 是否显示阴影
		/// </summary>
		[Category("BoolProperty"),DefaultValue(true),Description("是否显示阴影")]
		public bool ShowShadow
		{
			get
			{
				if(ViewState["ShowShadow"]==null)
				{
					ViewState["ShowShadow"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowShadow"];
				}
				
			}
			set
			{
				ViewState["ShowShadow"] = value;
			}
		}
		#endregion
		#endregion

		#region 函数
		/// <summary>
		/// 点击第一条记录按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibFirst_Click(object sender, EventArgs e)
		{
			//			if(this.DataSource!=null)
		{
			GetParamFromPage();
			this.CurrentPageIndex=0;
			this.DataBind();
		}
		}
		/// <summary>
		/// 点击前一条记录按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibPre_Click(object sender, EventArgs e)
		{
			//			if(this.DataSource!=null)
		{
			GetParamFromPage();
			if(this.CurrentPageIndex>=1)
			{
				this.CurrentPageIndex-=1;
			}
				
			this.DataBind();
		}
		}
		/// <summary>
		/// 点击下一条记录按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibNext_Click(object sender, EventArgs e)
		{
			if(this.DataSource!=null && this.DataSource.Rows.Count>0)
			{
				GetParamFromPage();
				int iMaxPage=DataSource.Rows.Count/this.PageSize;
				if(DataSource.Rows.Count%this.PageSize>0)
				{
					iMaxPage=iMaxPage+1;
				}
				if(this.CurrentPageIndex<iMaxPage-1)
				{
					this.CurrentPageIndex+=1;
				}
				this.DataBind();
			}
			else
			{
				this.tBody.Text="没有设定数据源！";
				this.ReportHtml="没有设定数据源！";
			}
		}
		/// <summary>
		/// 点击最后一条记录按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibLast_Click(object sender, EventArgs e)
		{
			if(this.DataSource!=null && this.DataSource.Rows.Count>0)
			{
				GetParamFromPage();
				int iMaxPage=DataSource.Rows.Count/this.PageSize;
				if(DataSource.Rows.Count%this.PageSize>0)
				{
					iMaxPage=iMaxPage+1;
				}
				this.CurrentPageIndex=iMaxPage-1;
				this.DataBind();
			}
			else
			{
				this.tBody.Text="没有设定数据源！";
				this.ReportHtml="没有设定数据源！";
			}
		}
		/// <summary>
		/// 点击Go
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibGo_Click(object sender, EventArgs e)
		{
			GetParamFromPage();
			this.DataBind();
		}
		/// <summary>
		/// 点击导出Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibExport_Click(object sender, EventArgs e)
		{
			System.Web.HttpResponse oResponse=Page.Response;
			oResponse.ContentType ="application/vnd.ms-excel";
			oResponse.Charset = "UTF-8";
			oResponse.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			oResponse.AddFileDependency("Report.xls");
			oResponse.AppendHeader("Content-Disposition", "attachment;filename=Report.xls");
			System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN",true);
			System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad); 
			System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
			this.tBody.Text=this.ReportHtml;
			tBody.RenderControl(oHtmlTextWriter); 
			oResponse.Write(oStringWriter.ToString());
			oResponse.End();
		}
		/// <summary>
		/// 点击统计分析按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibAnalysis_Click(object sender, EventArgs e)
		{
			//暂时不做
		}
		/// <summary>
		/// 点击套打形式按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibFreeForm_Click(object sender, EventArgs e)
		{
			this.ReportStyle=ReportStyle.FreeForm;
			GetParamFromPage();
			this.DataBind();
		}
		/// <summary>
		/// 点击列表形式按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibListForm_Click(object sender, EventArgs e)
		{
			//			string Tem="";
			//			foreach(DataColumn oDc in this.DataSource.Columns)
			//			{
			//				Tem+="["+oDc.ColumnName+"]</td><td>";
			//			}
			//			char[] cTem=new char[]{'/','<','t','d','>'};
			//			Tem=Tem.TrimEnd(cTem);
			this.ReportStyle=ReportStyle.ListForm;
			GetParamFromPage();
			//判断每页记录数是否超过了记录总数
			if(this.PageSize>this.DataSource.Rows.Count)
			{
				this.PageSize=this.DataSource.Rows.Count;
			}
			if(this.PrintColumns>this.PageSize)
			{
				this.PrintColumns=this.PageSize;
				this.PrintSize=1;
			}
			if(this.PrintSize>this.PageSize)
			{
				this.PrintSize=this.PageSize;
			}
			try
			{
				DataBind(this.DataSource,this.ListTemplate,this.PageSize,this.CurrentPageIndex,this.PrintColumns,this.PrintSize,this.Header,this.Footer,this.Header_FooterStyle);
			}
			catch(Exception err)
			{
				this.tBody.Text=err.ToString();
				this.ReportHtml=err.ToString();
			}

			
		}
		/// <summary>
		/// 点击群发邮件按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibSendEmail_Click(object sender, EventArgs e)
		{
			if(OnSendEmailClick!=null)
			{
				this.OnSendEmailClick(this.Page,null);
			}
		}
		/// <summary>
		/// 点击群发传真按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibSendFax_Click(object sender, EventArgs e)
		{
			if(OnSendFaxClick!=null)
			{
				this.OnSendFaxClick(this.Page,null);
			}
		}
		/// <summary>
		/// 点击群发短信按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ibSendSms_Click(object sender, EventArgs e)
		{
			if(OnSendSmsClick!=null)
			{
				this.OnSendSmsClick(this.Page,null);
			}
		}
		/// <summary>
		/// 获取页面上的用户自定义参数
		/// </summary>
		private void GetParamFromPage()
		{
			this.CurrentPageIndex=Convert.ToInt32(((HtmlInputHidden)this.FindControl(this.UniqueID+"_InputCurrentPageIndex")).Value)-1;
			this.PageSize=Convert.ToInt32(((HtmlInputHidden)this.FindControl(this.UniqueID+"_InputPageSize")).Value);
			this.PrintColumns=Convert.ToInt32(((HtmlInputHidden)this.FindControl(this.UniqueID+"_InputPrintColumns")).Value);
			this.PrintSize=Convert.ToInt32(((HtmlInputHidden)this.FindControl(this.UniqueID+"_InputPrintSize")).Value);
			//			this.Template=((HtmlInputHidden)this.FindControl(this.UniqueID+"_InputTemplate")).Value;
		}
		private string GetHtmlAttributeFromStyle(Color backColor,string backImageUrl,Color borderColor,BorderStyle borderStyle,Unit borderWidth,string cssClass,FontInfo font,Color foreColor,GridLines gridLines)
		{
			string Value="";
			if(cssClass!=null && cssClass!="")
			{
				Value+=" class=\""+cssClass+"\" ";
			}
			//================================
			if(gridLines!=GridLines.None)
			{
				if(gridLines==GridLines.Horizontal)
				{
					Value+=" rules=\"rows\" ";
				}
				else if(gridLines==GridLines.Vertical)
				{
					Value+=" rules=\"cols\" ";
				}
				else if(gridLines==GridLines.Both)
				{
					Value+=" rules=\"all\" ";
				}
			}
			//================================
			if(borderColor!=Color.Empty)
			{
				Value+=" bordercolor=\""+borderColor.Name+"\" ";
			}
			//================================
			if(borderWidth!=Unit.Empty)
			{
				Value+=" border=\""+borderWidth.Value+"\" ";
			}
			//================================
			Value+=" Style=\"";
			if(foreColor!=Color.Empty)
			{
				Value+="color:"+foreColor.Name+";";
			}
			//==========================================
			if(backColor!=Color.Empty)
			{
				Value+="background-color:"+backColor.Name+";";
			}
			else
			{
				Value+="background-color:#ffffff;";
			}
			//==========================================
			if(borderColor!=Color.Empty)
			{
				Value+="border-color:"+borderColor.Name+";";
			}
			//==========================================
			if(borderWidth!=Unit.Empty)
			{
				//Value+="border-width:"+borderWidth.Value+";";
			}
			//==========================================
			if(borderStyle!=BorderStyle.None)
			{
				Value+="border-style:"+borderStyle.ToString()+";";
			}
			//==========================================
			if(font.Name!=null && font.Name!="")
			{
				Value+="font-family:"+font.Name+";";
			}
			//==========================================
			if(font.Size!=FontUnit.Empty)
			{
				Value+="font-size:"+font.Size.Unit.Value+";";
			}
			//==========================================
			if(font.Bold!=false)
			{
				Value+="font-weight:bold;";
			}
			//==========================================
			if(font.Italic!=false)
			{
				Value+="font-style:italic;";
			}
			//==========================================
			Value+="text-decoration:";
			if(font.Underline!=false)
			{
				Value+="underline ";
			}
			if(font.Overline!=false)
			{
				Value+=" overline ";
			}
			if(font.Strikeout!=false)
			{
				Value+=" line-through";
			}
			Value+=";";
			if(backImageUrl!=null && backImageUrl!="")
			{
				Value+="background-image:url("+backImageUrl+")";
			}
			Value+="border-collapse:collapse;\"";
			return Value;
		}
		/// <summary>
		/// 获取由样式生成的html代码
		/// </summary>
		/// <param name="oStyle"></param>
		/// <returns></returns>
		private string GetHtmlAttributeFromStyle(TableItemStyle oStyle)
		{
			string Value="";
			if(oStyle.CssClass!=null && oStyle.CssClass!="")
			{
				Value+=" class=\""+oStyle.CssClass+"\" ";
			}
			//====================================
			//			if(this.GridLines!=GridLines.None)
			//			{
			//				if(this.GridLines==GridLines.Horizontal)
			//				{
			//					Value+=" rules=\"rows\" ";
			//				}
			//				else if(this.GridLines==GridLines.Vertical)
			//				{
			//					Value+=" rules=\"cols\" ";
			//				}
			//				else if(this.GridLines==GridLines.Both)
			//				{
			//					Value+=" rules=\"all\" ";
			//				}
			//			}
			//========================================
			if(oStyle.Wrap==false)
			{
				Value+=" nowrap=\"nowrap\" ";
			}
			//====================================
			if(oStyle.HorizontalAlign==HorizontalAlign.Center)
			{
				Value+=" align=\"Center\" ";
			}
			else if(oStyle.HorizontalAlign==HorizontalAlign.Left)
			{
				Value+=" align=\"Left\" ";
			}
			else if(oStyle.HorizontalAlign==HorizontalAlign.Right)
			{
				Value+=" align=\"Right\" ";
			}
			else if(oStyle.HorizontalAlign==HorizontalAlign.Justify)
			{
				Value+=" align=\"Justify\" ";
			}
			//====================================
			if(oStyle.VerticalAlign==VerticalAlign.Top)
			{
				Value+=" valign=\"Top\" ";
			}
			else if(oStyle.VerticalAlign==VerticalAlign.Middle)
			{
				Value+=" valign=\"Middle\" ";
			}
			else if(oStyle.VerticalAlign==VerticalAlign.Bottom)
			{
				Value+=" valign=\"Bottom\" ";
			}
			//===========================================
			Value+=" Style=\"";
			if(oStyle.ForeColor!=Color.Empty)
			{
				Value+="color:"+oStyle.ForeColor.Name+";";
			}
			//==========================================
			if(oStyle.BackColor!=Color.Empty)
			{
				Value+="background-color:"+oStyle.BackColor.Name+";";
			}
			//==========================================
			if(oStyle.BorderColor!=Color.Empty)
			{
				Value+="border-color:"+oStyle.BorderColor.Name+";";
			}
			//==========================================
			if(oStyle.BorderWidth!=Unit.Empty)
			{
				Value+="border-width:"+oStyle.BorderWidth.Value+";";
			}
			//==========================================
			if(oStyle.BorderStyle!=BorderStyle.None && oStyle.BorderStyle!=BorderStyle.NotSet)
			{
				Value+="border-style:"+oStyle.BorderStyle.ToString()+";";
			}
			//==========================================
			if(oStyle.Font.Name!=null && oStyle.Font.Name!="")
			{
				Value+="font-family:"+oStyle.Font.Name+";";
			}
			//==========================================
			if(oStyle.Font.Size!=FontUnit.Empty)
			{
				Value+="font-size:"+oStyle.Font.Size.Unit.Value+";";
			}
			//==========================================
			if(oStyle.Font.Bold!=false)
			{
				Value+="font-weight:bold;";
			}
			//==========================================
			if(oStyle.Font.Italic!=false)
			{
				Value+="font-style:italic;";
			}
			//==========================================
			Value+="text-decoration:";
			if(oStyle.Font.Underline!=false)
			{
				Value+="underline ";
			}
			if(oStyle.Font.Overline!=false)
			{
				Value+=" overline ";
			}
			if(oStyle.Font.Strikeout!=false)
			{
				Value+=" line-through";
			}
			Value+=";";
			//========================
			if(oStyle.Height!=Unit.Empty)
			{
				Value+="height:"+oStyle.Height.Value+";";
			}
			//========================
			if(oStyle.Width!=Unit.Empty)
			{
				Value+="width:"+oStyle.Width.Value+";";
			}
			Value+=" \"";
			return Value;
		}
		/// <summary>
		/// 初始化页面脚本
		/// </summary>
		private void OnPreRender()
		{
			if(!Page.IsClientScriptBlockRegistered("WebBrowser"))
			{
				string Styles=@"<OBJECT id=WebBrowser classid=CLSID:8856F961-340A-11D0-A96B-00C04FD705A2  height=0  width=0> </OBJECT>
<style  media=print>
input{display:None}
.LinkButton{display:None}
Button{display:None}
input.Button{display:None}
.DropDownList{FONT-SIZE: 9pt; COLOR: #000000; BACKGROUND-COLOR: #ffffff;border:None;}
.TextBox{FONT-SIZE: 9pt; COLOR: #ffffff; border:solid 0px white;BACKGROUND-COLOR: #000000; TEXT-ALIGN:left;}
.CheckBox{FONT-SIZE: 9pt; COLOR: #ffffff; border-style:none;BACKGROUND-COLOR: #000000; TEXT-ALIGN:left;}
.PageNext{page-break-after: always;Align:Center;}
Table.PrintPage{WIDTH:100%;HEIGHT:"+this.Height.Value+@";border-width:0px;BORDER-RIGHT: white 0px solid; BORDER-TOP: white 0px solid; BORDER-LEFT: white 0px solid; BORDER-BOTTOM: white 0px solid;}
.NoPrint{display:None;HEIGHT: 0px;WIDTH: 0px;}
</style>
<style media=screen>
Table.PrintPage{WIDTH:"+this.Width.Value+";HEIGHT:"+this.Height.Value+@";";
				if(this.ShowShadow)
					Styles+=@"BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid;FILTER:progid:DXImageTransform.Microsoft.Shadow(color=gray,direction=135);";
				Styles+=@"}
</style>";
					Page.RegisterClientScriptBlock("WebBrowser",Styles);
			}
			
			if(!Page.IsClientScriptBlockRegistered("Script"))
			{
				Page.RegisterClientScriptBlock("Script",@"<script language='javascript'>
var hkey_root,hkey_path,hkey_key
hkey_root='HKEY_CURRENT_USER'
hkey_path='\\Software\\Microsoft\\Internet Explorer\\PageSetup\\'
//设置网页打印的页眉页脚为空
function pagesetup_null()
{
  try{
    var RegWsh = new ActiveXObject('WScript.Shell')
    hkey_key='header'    
    RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,'"+this.PageHeader+@"')
    hkey_key='footer'
    RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,'"+this.PageFooter+@"')
  }catch(e){}
}
//设置网页打印的页眉页脚为默认值
function pagesetup_default()
{
  try{
    var RegWsh = new ActiveXObject('WScript.Shell')
    hkey_key='header'    
    RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,'&w&b页码，&p/&P')
    hkey_key='footer'
    RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,'&u&b&d')
  }catch(e){}
}
function showhide(obj)
{
	if(document.all(obj).style.visibility=='visible')
	{
		document.all(obj).style.visibility='hidden';
	}
	else
	{
		document.all(obj).style.visibility='visible';
        //document.all('"+this.UniqueID+@"_tbTemplate').InnerText=document.all['"+this.UniqueID+@"_InputTemplate'].value;
	}
}
//window.screen.width>800 ? Image_height=200:Image_height=250//在这设计图片离顶端的距离
//function my_pro_price()
//{ 
		//document.all('"+this.UniqueID+@"_divTemplate').style.top=document.body.scrollTop+document.body.offsetHeight-Image_height;
		//document.all('"+this.UniqueID+@"_divTemplate').style.align='center';
		//document.all('"+this.UniqueID+@"_divTemplate').style.link='color:black;text-decoration: none';
		//setTimeout('my_pro_price();',1);
//}
//my_pro_price();
		        </script>");
			}
		}
		/// <summary>
		/// 页面初始化
		/// </summary>
		private void OnInit()
		{
			
			if(this.FindControl(this.UniqueID+"_tBody")==null)
			{
				//========页面上的隐藏模板文本框========
				InputTemplate=new HtmlInputHidden();
				InputTemplate.ID=this.UniqueID+"_InputTemplate";
				this.Controls.Add(InputTemplate);
				//==========页面上的隐藏当前页面索引文本框==========
				InputCurrentPageIndex=new HtmlInputHidden();
				InputCurrentPageIndex.ID=this.UniqueID+"_InputCurrentPageIndex";
				this.Controls.Add(InputCurrentPageIndex);
				//=========页面上的隐藏每页显示记录数文本框==========
				InputPageSize=new HtmlInputHidden();
				InputPageSize.ID=this.UniqueID+"_InputPageSize";
				this.Controls.Add(InputPageSize);
				//=========页面上的隐藏显示列数文本框=======
				InputPrintColumns=new HtmlInputHidden();
				InputPrintColumns.ID=this.UniqueID+"_InputPrintColumns";
				this.Controls.Add(InputPrintColumns);
				//=========页面上的隐藏打印行数文本框==========
				InputPrintSize=new HtmlInputHidden();
				InputPrintSize.ID=this.UniqueID+"_InputPrintSize";
				this.Controls.Add(InputPrintSize);
				//==========================
				this.Controls.Add(new LiteralControl("<center>"));
				//========================================
				if(this.ToolBarStyle==ToolBarStyle.Top || this.ToolBarStyle==ToolBarStyle.Both)
				{
					#region 添加顶端工具栏
					tToolBar=new Table();
					tToolBar.ID=this.UniqueID+"_tToolBar";
					tToolBar.Width = new Unit("100%");

					TableCell tcNavigation=new TableCell();
					TableCell tcToolBar=new TableCell();
					tcNavigation.Attributes.Add("noWrap","noWrap");
					tcToolBar.Attributes.Add("noWrap","noWrap");

					tToolBar.Rows.Add(new TableRow());
					tcToolBar.Wrap = false;
					tcToolBar.Width = new Unit("15%");
					tcToolBar.HorizontalAlign=HorizontalAlign.Right;
					tcNavigation.Width = new Unit("85%");
					tcNavigation.HorizontalAlign=HorizontalAlign.Left;

					tToolBar.Font.Size=new FontUnit("9");
					tToolBar.Attributes.Add("Class","NoPrint");

					if(this.ShowNavigationBar!=false)
					{
						ibFirst=new LinkButton();
						ibFirst.ID=this.UniqueID+"_ibFirst";
						ibFirst.Text="首页";
						//						ibFirst.ImageAlign=ImageAlign.Middle;
						ibFirst.Click+=new EventHandler(ibFirst_Click);

						ibPre=new LinkButton();
						ibPre.ID=this.UniqueID+"_ibPre";
						ibPre.Text="上页";
						//						ibPre.ImageAlign=ImageAlign.Middle;
						ibPre.Click+=new EventHandler(ibPre_Click);

						//=============================================
						ddlCurrentPageIndex=new DropDownList();
						ddlCurrentPageIndex.ID=this.UniqueID+"_ddlCurrentPageIndex";
						ddlCurrentPageIndex.Attributes.Add("onchange","document.all['"+this.UniqueID+"_InputCurrentPageIndex'].value=this.value");

						tbPageSize=new TextBox();
						tbPageSize.ID=this.UniqueID+"_tbPageSize";
						tbPageSize.Width=new Unit("30");
						tbPageSize.Attributes.Add("onblur","document.all['"+this.UniqueID+"_InputPageSize'].value=this.value");

						lPageCount=new Label();
						lPageCount.ID=this.UniqueID+"_lPageCount";
						lPageCount.ForeColor=Color.Red;

						lRowCount=new Label();
						lRowCount.ID=this.UniqueID+"_lRowCount";
						lRowCount.ForeColor=Color.Red;

						lRowFrom=new Label();
						lRowFrom.ID=this.UniqueID+"_lRowFrom";
						lRowFrom.ForeColor=Color.Red;

						lRowTo=new Label();
						lRowTo.ID=this.UniqueID+"_lRowTo";
						lRowTo.ForeColor=Color.Red;

						tbPrintColumns=new TextBox();
						tbPrintColumns.ID=this.UniqueID+"_tbPrintColumns";
						tbPrintColumns.Width=new Unit("30");
						tbPrintColumns.Attributes.Add("onblur","document.all['"+this.UniqueID+"_InputPrintColumns'].value=this.value");

						tbPrintSize=new TextBox();
						tbPrintSize.ID=this.UniqueID+"_tbPrintSize";
						tbPrintSize.Width=new Unit("30");
						tbPrintSize.Attributes.Add("onblur","document.all['"+this.UniqueID+"_InputPrintSize'].value=this.value");
						//=============================================
						ibGo=new LinkButton();
						ibGo.ID=this.UniqueID+"_ibGo";
						ibGo.Text="Go";
						//						ibGo.ImageAlign=ImageAlign.Middle;
						ibGo.Click+=new EventHandler(ibGo_Click);

                      

						ibNext=new LinkButton();
						ibNext.ID=this.UniqueID+"_ibNext";
						ibNext.Text="下页";
						//						ibNext.ImageAlign=ImageAlign.Middle;
						ibNext.Click+=new EventHandler(ibNext_Click);

						ibLast=new LinkButton();
						ibLast.ID=this.UniqueID+"_ibLast";
						ibLast.Text="末页";
						//						ibLast.ImageAlign=ImageAlign.Middle;
						ibLast.Click+=new EventHandler(ibLast_Click);

						tcNavigation.Controls.Add(ibFirst);
						tcNavigation.Controls.Add(new LiteralControl("　"));
						tcNavigation.Controls.Add(ibPre);

						tcNavigation.Controls.Add(new LiteralControl("第"));
						tcNavigation.Controls.Add(ddlCurrentPageIndex);
						tcNavigation.Controls.Add(new LiteralControl("/共"));
						tcNavigation.Controls.Add(lPageCount);
						tcNavigation.Controls.Add(new LiteralControl("页,每页"));
						tcNavigation.Controls.Add(tbPageSize);
						tcNavigation.Controls.Add(new LiteralControl("/共"));
						tcNavigation.Controls.Add(lRowCount);
						tcNavigation.Controls.Add(new LiteralControl("条/本页第"));
						tcNavigation.Controls.Add(lRowFrom);
						tcNavigation.Controls.Add(new LiteralControl("～"));
						tcNavigation.Controls.Add(lRowTo);
						tcNavigation.Controls.Add(new LiteralControl("条记录;分"));
						tcNavigation.Controls.Add(tbPrintColumns);
						tcNavigation.Controls.Add(new LiteralControl("列,每页打印"));
						tcNavigation.Controls.Add(tbPrintSize);
						tcNavigation.Controls.Add(new LiteralControl("行"));

						tcNavigation.Controls.Add(ibNext);
						tcNavigation.Controls.Add(new LiteralControl("　"));
						tcNavigation.Controls.Add(ibLast);
						tcNavigation.Controls.Add(new LiteralControl("　"));
						tcNavigation.Controls.Add(ibGo);
					}
					if(this.ShowPrintButton!=false)
					{
						ibPrint=new HtmlAnchor();
						ibPrint.ID=this.UniqueID+"_ibPrint";
						ibPrint.HRef="#Print";
						ibPrint.Name="Print";
						ibPrint.InnerText="打印";
						//						ibPrint.Src=this.PrintButtonImgUrl;
						//						ibPrint.Alt="打印";
						ibPrint.Attributes.Add("onclick","document.all['WebBrowser'].ExecWB(7,1);");
						//						ibPrint.Attributes.Add("style","CURSOR: hand;");
						tcToolBar.Controls.Add(ibPrint);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowTemplateButton!=false)
					{
						ibTemplate=new HtmlAnchor();
						ibTemplate.ID=this.UniqueID+"_ibTemplate";
						ibTemplate.HRef="#Template";
						ibTemplate.Name="Template";
						ibTemplate.InnerText="模板";
						//						ibTemplate.Src=this.TemplateButtonImgUrl;
						//						ibTemplate.Alt="模板";
						//						ibTemplate.Attributes.Add("onclick","showhide('"+this.UniqueID+"_divTemplate')");
						//						ibTemplate.Attributes.Add("style","CURSOR: hand;");
						tcToolBar.Controls.Add(ibTemplate);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowExportButton!=false)
					{
						ibExport=new LinkButton();
						ibExport.ID=this.UniqueID+"_ibExport";
						ibExport.Text="导出";
						ibExport.Click+=new EventHandler(ibExport_Click);
						tcToolBar.Controls.Add(ibExport);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					
					if(this.ShowAnalysisButton!=false)
					{
						ibAnalysis=new LinkButton();
						ibAnalysis.ID=this.UniqueID+"_ibAnalysis";
						//						ibAnalysis.ImageUrl=this.AnalysisButtonImgUrl;
						ibAnalysis.Text="统计";
						ibAnalysis.Click+=new EventHandler(ibAnalysis_Click);
						tcToolBar.Controls.Add(ibAnalysis);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowReportStyleButton!=false)
					{
						ibFreeForm=new LinkButton();
						ibFreeForm.ID=this.UniqueID+"_ibFreeForm";
						//						ibFreeForm.ImageUrl=this.AnalysisButtonImgUrl;
						ibFreeForm.Text="套打";
						ibFreeForm.Click+=new EventHandler(ibFreeForm_Click);
						tcToolBar.Controls.Add(ibFreeForm);
						tcToolBar.Controls.Add(new LiteralControl("　"));

						ibListForm=new LinkButton();
						ibListForm.ID=this.UniqueID+"_ibListForm";
						//						ibListForm.ImageUrl=this.AnalysisButtonImgUrl;
						ibListForm.Text="列表";
						ibListForm.Click+=new EventHandler(ibListForm_Click);
						tcToolBar.Controls.Add(ibListForm);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowSendEmailButton!=false)
					{
						ibSendEmail=new LinkButton();
						ibSendEmail.ID=this.UniqueID+"_ibSendEmail";
						//						ibSendEmail.ImageUrl=this.AnalysisButtonImgUrl;
						ibSendEmail.Text="邮件";
						ibSendEmail.Click+=new EventHandler(ibSendEmail_Click);
						tcToolBar.Controls.Add(ibSendEmail);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowSendFaxButton!=false)
					{
						ibSendFax=new LinkButton();
						ibSendFax.ID=this.UniqueID+"_ibSendFax";
						//						ibSendFax.ImageUrl=this.AnalysisButtonImgUrl;
						ibSendFax.Text="传真";
						ibSendFax.Click+=new EventHandler(ibSendFax_Click);
						tcToolBar.Controls.Add(ibSendFax);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowSendSmsButton!=false)
					{
						ibSendSms=new LinkButton();
						ibSendSms.ID=this.UniqueID+"_ibSendSms";
						//						ibSendSms.ImageUrl=this.AnalysisButtonImgUrl;
						ibSendSms.Text="短信";
						ibSendSms.Click+=new EventHandler(ibSendSms_Click);
						tcToolBar.Controls.Add(ibSendSms);
						tcToolBar.Controls.Add(new LiteralControl("　"));
					}
					tToolBar.Rows[0].Cells.Add(tcNavigation);
					tToolBar.Rows[0].Cells.Add(tcToolBar);
					//========添加横杠==============
					if(this.ShowNavigationBar!=false)
					{
						TableRow trTopToolBarHr=new TableRow();
						TableCell tcTopToolBarHr=new TableCell();
						tcTopToolBarHr.ColumnSpan=2;
						tcTopToolBarHr.Text="<hr>";
						trTopToolBarHr.Cells.Add(tcTopToolBarHr);
						tToolBar.Rows.Add(trTopToolBarHr);
					}
					//===============================
					this.Controls.Add(tToolBar);
					#endregion
				}
				//				//=============添加报表表头===============
				//				LiteralControl Header=new LiteralControl("<p align=center>"+this.Header+"</p><center>");
				//				Header.ID=this.UniqueID+"_Header";
				//				this.Controls.Add(Header);
				//=============添加报表===============
				tBody=new LiteralControl();
				tBody.ID=this.UniqueID+"_tBody";
				this.Controls.Add(tBody);
				//				//=============添加报表脚=================
				//				LiteralControl Footer=new LiteralControl("</center><p align=center>"+this.Footer+"</p>");
				//				Footer.ID=this.UniqueID+"_Footer";
				//				this.Controls.Add(Footer);
				//=======================================
				if(this.ToolBarStyle==ToolBarStyle.Bottom || this.ToolBarStyle==ToolBarStyle.Both)
				{
					#region 添加底端工具栏
					tToolBar1=new Table();
					tToolBar1.ID=this.UniqueID+"_tToolBar1";
					tToolBar1.Width = new Unit("100%");

					TableCell tcNavigation1=new TableCell();
					TableCell tcToolBar1=new TableCell();
					tcNavigation1.Attributes.Add("noWrap","noWrap");
					tcToolBar1.Attributes.Add("noWrap","noWrap");

					tcToolBar1.Wrap = false;
					tcToolBar1.Width = new Unit("15%");
					tcToolBar1.HorizontalAlign=HorizontalAlign.Right;
					tcNavigation1.Width = new Unit("85%");
					tcNavigation1.HorizontalAlign=HorizontalAlign.Left;

					tToolBar1.Font.Size=new FontUnit("9");
					tToolBar1.Attributes.Add("Class","NoPrint");

					if(this.ShowNavigationBar!=false)
					{
						ibFirst1=new LinkButton();
						ibFirst1.ID=this.UniqueID+"_ibFirst1";
						ibFirst1.Text="首页";
						//						ibFirst1.ImageAlign=ImageAlign.Middle;
						ibFirst1.Click+=new EventHandler(ibFirst_Click);

						ibPre1=new LinkButton();
						ibPre1.ID=this.UniqueID+"_ibPre1";
						ibPre1.Text="上页";
						//						ibPre1.ImageAlign=ImageAlign.Middle;
						ibPre1.Click+=new EventHandler(ibPre_Click);

						//=============================================
						ddlCurrentPageIndex1=new DropDownList();
						ddlCurrentPageIndex1.ID=this.UniqueID+"_ddlCurrentPageIndex1";
						ddlCurrentPageIndex1.Attributes.Add("onchange","document.all['"+this.UniqueID+"_InputCurrentPageIndex'].value=this.value");

						tbPageSize1=new TextBox();
						tbPageSize1.ID=this.UniqueID+"_tbPageSize1";
						tbPageSize1.Width=new Unit("30");
						tbPageSize1.Attributes.Add("onblur","document.all['"+this.UniqueID+"_InputPageSize'].value=this.value");

						lPageCount1=new Label();
						lPageCount1.ID=this.UniqueID+"_lPageCount1";
						lPageCount1.ForeColor=Color.Red;

						lRowCount1=new Label();
						lRowCount1.ID=this.UniqueID+"_lRowCount1";
						lRowCount1.ForeColor=Color.Red;

						lRowFrom1=new Label();
						lRowFrom1.ID=this.UniqueID+"_lRowFrom1";
						lRowFrom1.ForeColor=Color.Red;

						lRowTo1=new Label();
						lRowTo1.ID=this.UniqueID+"_lRowTo1";
						lRowTo1.ForeColor=Color.Red;

						tbPrintColumns1=new TextBox();
						tbPrintColumns1.ID=this.UniqueID+"_tbPrintColumns1";
						tbPrintColumns1.Width=new Unit("30");
						tbPrintColumns1.Attributes.Add("onblur","document.all['"+this.UniqueID+"_InputPrintColumns'].value=this.value");

						tbPrintSize1=new TextBox();
						tbPrintSize1.ID=this.UniqueID+"_tbPrintSize1";
						tbPrintSize1.Width=new Unit("30");
						tbPrintSize1.Attributes.Add("onblur","document.all['"+this.UniqueID+"_InputPrintSize'].value=this.value");
						//=============================================
						ibGo1=new LinkButton();
						ibGo1.ID=this.UniqueID+"_ibGo1";
						ibGo1.Text="Go";
						//						ibGo1.ImageAlign=ImageAlign.Middle;
						ibGo1.Click+=new EventHandler(ibGo_Click);

						ibNext1=new LinkButton();
						ibNext1.ID=this.UniqueID+"_ibNext1";
						ibNext1.Text="下页";
						//						ibNext1.ImageAlign=ImageAlign.Middle;
						ibNext1.Click+=new EventHandler(ibNext_Click);

						ibLast1=new LinkButton();
						ibLast1.ID=this.UniqueID+"_ibLast1";
						ibLast1.Text="末页";
						//						ibLast1.ImageAlign=ImageAlign.Middle;
						ibLast1.Click+=new EventHandler(ibLast_Click);

						tcNavigation1.Controls.Add(ibFirst1);
						tcNavigation1.Controls.Add(new LiteralControl("　"));
						tcNavigation1.Controls.Add(ibPre1);

						tcNavigation1.Controls.Add(new LiteralControl("第"));
						tcNavigation1.Controls.Add(ddlCurrentPageIndex1);
						tcNavigation1.Controls.Add(new LiteralControl("/共"));
						tcNavigation1.Controls.Add(lPageCount1);
						tcNavigation1.Controls.Add(new LiteralControl("页,每页"));
						tcNavigation1.Controls.Add(tbPageSize1);
						tcNavigation1.Controls.Add(new LiteralControl("/共"));
						tcNavigation1.Controls.Add(lRowCount1);
						tcNavigation1.Controls.Add(new LiteralControl("条/本页第"));
						tcNavigation1.Controls.Add(lRowFrom1);
						tcNavigation1.Controls.Add(new LiteralControl("～"));
						tcNavigation1.Controls.Add(lRowTo1);
						tcNavigation1.Controls.Add(new LiteralControl("条记录;分"));
						tcNavigation1.Controls.Add(tbPrintColumns1);
						tcNavigation1.Controls.Add(new LiteralControl("列,每页打印"));
						tcNavigation1.Controls.Add(tbPrintSize1);
						tcNavigation1.Controls.Add(new LiteralControl("行"));

						tcNavigation1.Controls.Add(ibNext1);
						tcNavigation1.Controls.Add(new LiteralControl("　"));
						tcNavigation1.Controls.Add(ibLast1);
						tcNavigation1.Controls.Add(new LiteralControl("　"));
						tcNavigation1.Controls.Add(ibGo1);
					}
					if(this.ShowPrintButton!=false)
					{
						ibPrint1=new HtmlAnchor();
						ibPrint1.ID=this.UniqueID+"_ibPrint1";
						ibPrint1.HRef="#Print1";
						ibPrint1.Name="Print1";
						ibPrint1.InnerText="打印";
						//						ibPrint1.Src=this.PrintButtonImgUrl;
						//						ibPrint1.Alt="打印";
						ibPrint1.Attributes.Add("onclick","document.all['WebBrowser'].ExecWB(7,1);");
						//						ibPrint1.Attributes.Add("style","CURSOR: hand;");
						tcToolBar1.Controls.Add(ibPrint1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowTemplateButton!=false)
					{
						ibTemplate1=new HtmlAnchor();
						ibTemplate1.ID=this.UniqueID+"_ibTemplate1";
						ibTemplate1.HRef="#Template1";
						ibTemplate1.Name="#Template1";
						ibTemplate1.InnerText="模板";
						//						ibTemplate1.Src=this.TemplateButtonImgUrl;
						//						ibTemplate1.Alt="模板";
						//						ibTemplate1.Attributes.Add("onclick","showhide('"+this.UniqueID+"_divTemplate')");
						//						ibTemplate1.Attributes.Add("style","CURSOR: hand;");
						tcToolBar1.Controls.Add(ibTemplate1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowExportButton!=false)
					{
						ibExport1=new LinkButton();
						ibExport1.ID=this.UniqueID+"_ibExport1";
						ibExport1.Text="导出";
						ibExport1.Click+=new EventHandler(ibExport_Click);
						tcToolBar1.Controls.Add(ibExport1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowAnalysisButton!=false)
					{
						ibAnalysis1=new LinkButton();
						ibAnalysis1.ID=this.UniqueID+"_ibAnalysis1";
						ibAnalysis1.Text="统计";
						tcToolBar1.Controls.Add(ibAnalysis1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowReportStyleButton!=false)
					{
						ibFreeForm1=new LinkButton();
						ibFreeForm1.ID=this.UniqueID+"_ibFreeForm1";
						//						ibFreeForm1.ImageUrl=this.AnalysisButtonImgUrl;
						ibFreeForm1.Text="套打";
						ibFreeForm1.Click+=new EventHandler(ibFreeForm_Click);
						tcToolBar1.Controls.Add(ibFreeForm1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));

						ibListForm1=new LinkButton();
						ibListForm1.ID=this.UniqueID+"_ibListForm1";
						//						ibListForm1.ImageUrl=this.AnalysisButtonImgUrl;
						ibListForm1.Text="列表";
						ibListForm1.Click+=new EventHandler(ibListForm_Click);
						tcToolBar1.Controls.Add(ibListForm1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowSendEmailButton!=false)
					{
						ibSendEmail1=new LinkButton();
						ibSendEmail1.ID=this.UniqueID+"_ibSendEmail1";
						//						ibSendEmail1.ImageUrl=this.AnalysisButtonImgUrl;
						ibSendEmail1.Text="邮件";
						ibSendEmail1.Click+=new EventHandler(ibSendEmail_Click);
						tcToolBar1.Controls.Add(ibSendEmail1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowSendFaxButton!=false)
					{
						ibSendFax1=new LinkButton();
						ibSendFax1.ID=this.UniqueID+"_ibSendFax1";
						//						ibSendFax1.ImageUrl=this.AnalysisButtonImgUrl;
						ibSendFax1.Text="传真";
						ibSendFax1.Click+=new EventHandler(ibSendFax_Click);
						tcToolBar1.Controls.Add(ibSendFax1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					if(this.ShowSendSmsButton!=false)
					{
						ibSendSms1=new LinkButton();
						ibSendSms1.ID=this.UniqueID+"_ibSendSms1";
						//						ibSendSms1.ImageUrl=this.AnalysisButtonImgUrl;
						ibSendSms1.Text="短信";
						ibSendSms1.Click+=new EventHandler(ibSendSms_Click);
						tcToolBar1.Controls.Add(ibSendSms1);
						tcToolBar1.Controls.Add(new LiteralControl("　"));
					}
					//========添加横杠==============
					if(this.ShowNavigationBar!=false)
					{
						TableRow trBottomToolBarHr=new TableRow();
						TableCell tcBottomToolBarHr=new TableCell();
						tcBottomToolBarHr.ColumnSpan=2;
						tcBottomToolBarHr.Text="<hr>";
						trBottomToolBarHr.Cells.Add(tcBottomToolBarHr);
						tToolBar1.Rows.Add(trBottomToolBarHr);
					}
					//===============================
					tToolBar1.Rows.Add(new TableRow());
					tToolBar1.Rows[1].Cells.Add(tcNavigation1);
					tToolBar1.Rows[1].Cells.Add(tcToolBar1);
				
					this.Controls.Add(tToolBar1);
					#endregion
				}
				//=======================================
				//this.Controls.Add(new LiteralControl("<Div id='"+this.UniqueID+"_divTemplate' style='VISIBILITY: hidden;' Class='NoPrint'><textarea id='"+this.UniqueID+"_tbTemplate' rows='11' cols='107' onblur=\"document.all['"+this.UniqueID+"_InputTemplate'].value=this.value\">"+this.Template+"</textarea></Div>"));
				this.Controls.Add(new LiteralControl("</center>"));
			}
			
			DataBind();
		}
		/// <summary>
		/// 公用函数，数据绑定
		/// </summary>
		public new void DataBind()
		{
			if(this.DataSource==null || this.DataSource.Rows.Count==0)
			{
				if(this.DataSource==null)
				{
					this.tBody.Text="没有设定数据源！";
					this.ReportHtml="没有设定数据源！";
				}
				else
				{
					this.tBody.Text="数据表中没有套打数据！";
					this.ReportHtml="数据表中没有套打数据！";
				}
				//==========初始化控件的值=========
				if(!Page.IsPostBack)
				{
					tBody.Text=this.ReportHtml;
					//					InputTemplate.Value=this.Template;
					InputCurrentPageIndex.Value=Convert.ToString(this.CurrentPageIndex+1);
					InputPageSize.Value=this.PageSize.ToString();
					InputPrintColumns.Value=this.PrintColumns.ToString();
					InputPrintSize.Value=this.PrintSize.ToString();
					//					((HtmlTextArea)this.FindControl(this.UniqueID+"_tbTemplate")).InnerText=this.Template;

					if(this.ShowNavigationBar!=false)
					{
						if(this.ToolBarStyle==ToolBarStyle.Top || this.ToolBarStyle==ToolBarStyle.Both)
						{
							this.tbPageSize.Text=this.PageSize.ToString();
							this.lPageCount.Text="0";
							this.lRowCount.Text="0";
							this.lRowFrom.Text="0";
							this.lRowTo.Text="0";
							this.tbPrintColumns.Text=this.PrintColumns.ToString();
							this.tbPrintSize.Text=this.PrintSize.ToString();
						}
						if(this.ToolBarStyle==ToolBarStyle.Bottom || this.ToolBarStyle==ToolBarStyle.Both)
						{
							this.tbPageSize1.Text=this.PageSize.ToString();
							this.lPageCount1.Text="0";
							this.lRowCount1.Text="0";
							this.lRowFrom1.Text="0";
							this.lRowTo1.Text="0";
							this.tbPrintColumns1.Text=this.PrintColumns.ToString();
							this.tbPrintSize1.Text=this.PrintSize.ToString();
						}
					}
				}
				//=================================
				return;
			}

			//判断每页记录数是否超过了记录总数
			if(this.PageSize>this.DataSource.Rows.Count)
			{
				this.PageSize=this.DataSource.Rows.Count;
			}
			if(this.PrintColumns>this.PageSize)
			{
				this.PrintColumns=this.PageSize;
				this.PrintSize=1;
			}
			if(this.PrintSize>this.PageSize)
			{
				this.PrintSize=this.PageSize;
			}
			try
			{
				if(this.ReportStyle==ReportStyle.FreeForm)
				{
					DataBind(this.DataSource,this.Template,this.PageSize,this.CurrentPageIndex,this.PrintColumns,this.PrintSize,this.Header,this.Footer,this.Header_FooterStyle);
				}
				else
				{
					DataBind(this.DataSource,this.ListTemplate,this.PageSize,this.CurrentPageIndex,this.PrintColumns,this.PrintSize,this.Header,this.Footer,this.Header_FooterStyle);
				}
			}
			catch(Exception err)
			{
				this.tBody.Text=err.ToString();
				this.ReportHtml=err.ToString();
			}
		}
		/// <summary>
		/// 对报表进行数据绑定
		/// </summary>
		private void DataBind(DataTable oTable,string strTemplate,int iPageSize,int iCurrentPageIndex,int iPrintColumns,int iPrintSize,string strHeader,string strFooter,Header_FooterStyle HeaderFooterStyle)
		{
			//发送传真
			//			FAXCOMEXLib.FaxDocumentClass FaxDoc=new FAXCOMEXLib.FaxDocumentClass();
			//			FaxDoc.Body="E:\\test.txt";
			//			FaxDoc.CoverPage="E:\\test.txt";
			//			FaxDoc.Note="E:\\test.txt";
			//			FaxDoc.GroupBroadcastReceipts=true;
			//FaxDoc.DocumentName="E:\\test.txt";
			//			FaxDoc.Subject="Subject";
			//			FaxDoc.Recipients.Add("01063260698","接收人1");
			//			FaxDoc.Recipients.Add("01088888888","接收人2");
			//			FaxDoc.Sender.Name="发件人";
			//			FaxDoc.Submit("guoyu");

			//			FAXCOMLib.FaxServerClass fsc = new FAXCOMLib.FaxServerClass(); 
			//			fsc.Connect("guoyu"); 
			//			object obj = fsc.CreateDocument("E:\\help.htm"); 
			//			FAXCOMLib.FaxDoc fd = (FAXCOMLib.FaxDoc)obj; 
			//			fd.DisplayName="DisplayName";
			//			fd.CoverpageNote="CoverpageNote";
			//			fd.CoverpageSubject="CoverpageSubject";
			//			fd.FaxNumber = "027905007"; 
			//			fd.RecipientName = "北京昆仑亿发科技发展公司";
			//			fd.Send();
			//			fsc.Disconnect();
			//			if(this.ReportStyle==ReportStyle.FreeForm)
		{
			//============================================================
			string Html=this.GetReportValue(oTable,strTemplate,iPageSize,iCurrentPageIndex,iPrintColumns,iPrintSize,strHeader,strFooter,HeaderFooterStyle);
			tBody.Text=Html;
			this.ReportHtml=Html;
			//============================================================
			//			InputTemplate.Value=this.Template;
			InputCurrentPageIndex.Value=Convert.ToString(iCurrentPageIndex+1);
			InputPageSize.Value=iPageSize.ToString();
			InputPrintColumns.Value=iPrintColumns.ToString();
			InputPrintSize.Value=iPrintSize.ToString();

			if(this.ShowNavigationBar!=false)
			{
				int iMaxPage=DataSource.Rows.Count/iPageSize;
				if(DataSource.Rows.Count%iPageSize>0)
				{
					iMaxPage=iMaxPage+1;
				}
				if(this.ToolBarStyle==ToolBarStyle.Both)
				{
					this.ddlCurrentPageIndex.Items.Clear();
					for(int i=1;i<=iMaxPage;i++)
					{
						this.ddlCurrentPageIndex.Items.Add(new ListItem(i.ToString()));
					}
					//=========================================
					this.ddlCurrentPageIndex.SelectedIndex=iCurrentPageIndex;
					this.tbPageSize.Text=iPageSize.ToString();
					this.lPageCount.Text=this.ddlCurrentPageIndex.Items.Count.ToString();
					this.lRowCount.Text=oTable.Rows.Count.ToString();
					this.lRowFrom.Text=Convert.ToString(iCurrentPageIndex*iPageSize+1);
					this.lRowTo.Text=Convert.ToString((iCurrentPageIndex+1)*iPageSize);
					this.tbPrintColumns.Text=iPrintColumns.ToString();
					this.tbPrintSize.Text=iPrintSize.ToString();

					this.ddlCurrentPageIndex1.Items.Clear();
					for(int i=1;i<=iMaxPage;i++)
					{
						this.ddlCurrentPageIndex1.Items.Add(new ListItem(i.ToString()));
					}
					//=========================================
					this.ddlCurrentPageIndex1.SelectedIndex=iCurrentPageIndex;
					this.tbPageSize1.Text=this.tbPageSize.Text;
					this.lPageCount1.Text=this.lPageCount.Text;
					this.lRowCount1.Text=this.lRowCount.Text;
					this.lRowFrom1.Text=this.lRowFrom.Text;
					this.lRowTo1.Text=this.lRowTo.Text;
					this.tbPrintColumns1.Text=this.tbPrintColumns.Text;
					this.tbPrintSize1.Text=this.tbPrintSize.Text;
				}
				else if(this.ToolBarStyle==ToolBarStyle.Top)
				{
					this.ddlCurrentPageIndex.Items.Clear();
					for(int i=1;i<=iMaxPage;i++)
					{
						this.ddlCurrentPageIndex.Items.Add(new ListItem(i.ToString()));
					}
					//=========================================
					this.ddlCurrentPageIndex.SelectedIndex=iCurrentPageIndex;
					this.tbPageSize.Text=iPageSize.ToString();
					this.lPageCount.Text=this.ddlCurrentPageIndex.Items.Count.ToString();
					this.lRowCount.Text=oTable.Rows.Count.ToString();
					this.lRowFrom.Text=Convert.ToString(iCurrentPageIndex*iPageSize+1);
					this.lRowTo.Text=Convert.ToString((iCurrentPageIndex+1)*iPageSize);
					this.tbPrintColumns.Text=iPrintColumns.ToString();
					this.tbPrintSize.Text=iPrintSize.ToString();
				}
				else if(this.ToolBarStyle==ToolBarStyle.Bottom)
				{
					this.ddlCurrentPageIndex1.Items.Clear();
					for(int i=1;i<=iMaxPage;i++)
					{
						this.ddlCurrentPageIndex1.Items.Add(new ListItem(i.ToString()));
					}
					//=========================================
					this.ddlCurrentPageIndex1.SelectedIndex=iCurrentPageIndex;
					this.tbPageSize1.Text=iPageSize.ToString();
					this.lPageCount1.Text=this.ddlCurrentPageIndex1.Items.Count.ToString();
					this.lRowCount1.Text=oTable.Rows.Count.ToString();
					this.lRowFrom1.Text=Convert.ToString(iCurrentPageIndex*iPageSize+1);
					this.lRowTo1.Text=Convert.ToString((iCurrentPageIndex+1)*iPageSize);
					this.tbPrintColumns1.Text=iPrintColumns.ToString();
					this.tbPrintSize1.Text=iPrintSize.ToString();
				}
			}
		}
			//			else if(this.ReportStyle==ReportStyle.ListForm)
			//			{
			//				this.tBody.Text="";
			//				DataGrid oDgr=new DataGrid();
			//				oDgr.DataSource=this.DataSource;
			//				oDgr.DataBind();
			//				this.Controls.AddAt(this.Controls.IndexOf(this.FindControl(this.UniqueID+"_tBody")),oDgr);
			//			}
		}
		/// <summary>
		/// 返回套打的报表结果
		/// </summary>
		/// <param name="oTable">要套打的源数据表</param>
		/// <param name="strTemplate">套打模板</param>
		/// <param name="iPageSize">每页记录数</param>
		/// <param name="iCurrentPageIndex">当前页码</param>
		/// <param name="iPrintColumns">显示列数</param>
		/// <param name="iPrintSize">每页打印行数</param>
		/// <param name="strHeader">报表表头</param>
		/// <param name="strFooter">报表脚</param>
		/// <param name="HeaderFooterStyle">报表眉脚样式：分页、不分页</param>
		/// <returns></returns>
		private string GetReportValue(DataTable oTable,string strTemplate,int iPageSize,int iCurrentPageIndex,int iPrintColumns,int iPrintSize,string strHeader,string strFooter,Header_FooterStyle HeaderFooterStyle)
		{
			System.Text.StringBuilder Value=new System.Text.StringBuilder();
			//Value.Append("<Table bgcolor=\""+this.BackColor.Name+"\"' cellSpacing=\"0\" cellPadding=\"0\"  border=\"0\" width=\"100%\"><tr><td align=\"center\" valign=\"center\"><p Class='PageNext'></p>");
			Value.Append("<p Class='PageNext'></p>");
			string ListHeader="";
			//if(HeaderFooterStyle==Header_FooterStyle.NoCycle)//报表眉脚不分页的情况
		{
			//如果报表表头不为空，则添加
			if(strHeader.Trim()!="")
			{
				Value.Append("<p align=center>"+strHeader+"</p>");
			}
		}
			if(this.ReportStyle==ReportStyle.FreeForm)
			{
				Value.Append("<Table class=\"PrintPage\" "+this.GetHtmlAttributeFromStyle(this.BackColor,this.BackImageUrl,this.BorderColor,this.BorderStyle,this.BorderWidth,this.CssClass,this.Font,this.ForeColor,this.GridLines)+">");
				//Value.Append("<Table class=\"PrintPage\" width=\""+this.Width.Value+"\" height=\""+this.Height.Value+"\">");
			}
			else
			{
				//如果显示表头
				if(this.ShowHeader!=false)
				{
					ListHeader="<tr "+this.GetHtmlAttributeFromStyle(this.HeaderStyle)+">";
					string Tem="";
					foreach(DataColumn oDc in oTable.Columns)
					{
						Tem+="<td align=\"center\" valign=\"center\">"+oDc.ColumnName+"</td>";
					}
					for(int i=0;i<iPrintColumns;i++)
					{
						ListHeader+=Tem;
					}
					ListHeader+="</tr>";
				}
				Value.Append("<table class=\"PrintPage\" "+this.GetHtmlAttributeFromStyle(this.BackColor,this.BackImageUrl,this.BorderColor,this.BorderStyle,this.BorderWidth,this.CssClass,this.Font,this.ForeColor,this.GridLines)+">"+ListHeader);
				//Value.Append("<table class=\"PrintPage\"  width=\""+this.Width.Value+"\" height=\""+this.Height.Value+"\" >"+ListHeader);
			}
			//计算最大行数
			int iRowStep=iPageSize/iPrintColumns;
			if(iPageSize%iPrintColumns>0)
			{
				iRowStep=iRowStep+1;
			}
			//			int iMaxRow=(iPageSize*(iCurrentPageIndex+1))/iPrintColumns;
			//			if((iPageSize*(iCurrentPageIndex+1))%iPrintColumns>0)
			//			{
			//				iMaxRow=iMaxRow+1;
			//			}
			int iMinRow=(iPageSize*iCurrentPageIndex)/iPrintColumns;
			if((iPageSize*iCurrentPageIndex)%iPrintColumns>0)
			{
				iMinRow=iMinRow+1;
			}
			int RowCount=oTable.Rows.Count/iPrintColumns;
			if(oTable.Rows.Count%iPrintColumns>0)
			{
				RowCount=RowCount+1;
			}
			int iMaxRow=iRowStep*(iCurrentPageIndex+1);
			if(iMaxRow>RowCount)
			{
				iMaxRow=RowCount;
			}
			//按行添加
			int iRowSize=0;
			for(int iRow=iMinRow;iRow<iMaxRow;iRow++)
			{
				//如果模板不为空，则进行套打
				if(strTemplate.Trim()!="")
				{
					//if((iRow+1)*iPrintColumns-1<oTable.Rows.Count)
				{
					Value.Append("<tr "+this.GetHtmlAttributeFromStyle(this.ItemStyle)+">");
					//分列
					for(int iColumn=0;iColumn<iPrintColumns;iColumn++)
					{
						//if(iRow*iPrintColumns+iColumn+1<=(iCurrentPageIndex+1)*iPageSize)
						if(iRowSize<iPageSize)
						{
							string strTemplateValue=strTemplate;
							//套打模板
							foreach(DataColumn oDc in oTable.Columns)
							{
								try
								{
									strTemplateValue=strTemplateValue.Replace("["+oDc.ColumnName+"]",oTable.Rows[iCurrentPageIndex*iPageSize+iRowSize][oDc.ColumnName].ToString());
								}
								catch(Exception err)
								{
									Com.File.FileLog.WriteLog("Com.UserControl.WebReport",err.ToString());
									strTemplateValue="";
								}
							}
							//套入当前日期
							strTemplateValue=strTemplateValue.Replace("[Date]",System.DateTime.Now.Date.Year.ToString()+"年"+System.DateTime.Now.Date.Month.ToString()+"月"+System.DateTime.Now.Date.Day.ToString()+"日");
							//分页
							if(ShowRowCount)
								strTemplateValue=(iCurrentPageIndex*iPageSize+iRowSize+1)+"、"+strTemplateValue.Replace("[PageNext]","<p Class='PageNext'></p>");
							else
								strTemplateValue=strTemplateValue.Replace("[PageNext]","<p Class='PageNext'></p>");
							if(this.ReportStyle==ReportStyle.FreeForm)
							{
								if(this.Template==this.ListTemplate)
								{
									Value.Append("<td>"+strTemplateValue+"</td>");	
								}
								else
								{
									Value.Append("<td align="+this.ItemStyle.HorizontalAlign.ToString()+" valign="+this.ItemStyle.VerticalAlign.ToString()+" cellpadding='20' width='"+100/iPrintColumns+"%' height=\""+100/iPrintSize+"%\">"+strTemplateValue+"</td>");	
								}
							}
							else
							{
								Value.Append("<td>"+strTemplateValue);
							}
								
						}
						else
						{
							if(this.ReportStyle==ReportStyle.FreeForm)
							{
								if(this.Template==this.ListTemplate)
								{
									Value.Append("<td></td>");
								}
								else
								{
									Value.Append("<td align="+this.ItemStyle.HorizontalAlign.ToString()+" valign="+this.ItemStyle.VerticalAlign.ToString()+" cellpadding='20' width='"+100/iPrintColumns+"%' height=\""+100/iPrintSize+"%\"></td>");
								}
							}
							else
							{
								Value.Append("<td>");
							}
								
						}
							
						iRowSize++;
					}
					Value.Append("</tr>");
				}
					//判断是否该分页打印了
					//if((iRow-iMinRow+1)%iPrintSize==0 && iRow-iMinRow!=0 && iRow<iMinRow+iRowStep-1)
					if((iRow-iMinRow+1)%iPrintSize==0 && iRow>=iMinRow && iRow<iMaxRow-1 && iRow<iMinRow+iRowStep-1)
					{
						//Value.Append("<tr height='100%'><td colspan='"+iPrintColumns.ToString()+"'></td></tr></table>");
						Value.Append("</table>");
						if(HeaderFooterStyle==Header_FooterStyle.Cycle)
						{
							//如果报表表脚不为空，则添加
							if(strFooter.Trim()!="")
							{
								Value.Append("<p align=center>"+strFooter+"</p>");
							}
						}
						Value.Append("<p Class='PageNext'><hr size='1' color='black' Class='NoPrint' style='border-style: dotted;'></p>");
						if(HeaderFooterStyle==Header_FooterStyle.Cycle)
						{
							//如果报表表头不为空，则添加
							if(strHeader.Trim()!="")
							{
								Value.Append("<p align=center>"+strHeader+"</p>");
							}
						}
						if(this.ReportStyle==ReportStyle.FreeForm)
						{
							Value.Append("<Table class=\"PrintPage\" "+this.GetHtmlAttributeFromStyle(this.BackColor,this.BackImageUrl,this.BorderColor,this.BorderStyle,this.BorderWidth,this.CssClass,this.Font,this.ForeColor,this.GridLines)+">");
							//Value.Append("<Table class=\"PrintPage\" width=\""+this.Width.Value+"\" height=\""+this.Height.Value+"\">");
						}
						else
						{
							Value.Append("<table class=\"PrintPage\"   "+this.GetHtmlAttributeFromStyle(this.BackColor,this.BackImageUrl,this.BorderColor,this.BorderStyle,this.BorderWidth,this.CssClass,this.Font,this.ForeColor,this.GridLines)+">"+ListHeader);
							//Value.Append("<table class=\"PrintPage\"  width=\""+this.Width.Value+"\" height=\""+this.Height.Value+"\" >"+ListHeader);
						}
					}
				}
			}
			//Value.Append("<tr height='100%'><td colspan='"+iPrintColumns.ToString()+"'></td></tr></Table>");
			Value.Append("</Table>");
			//if(HeaderFooterStyle==Header_FooterStyle.NoCycle)//报表眉脚不分页的情况
		{
			//如果报表表脚不为空，则添加
			if(strFooter.Trim()!="")
			{
				Value.Append("<p align=center>"+strFooter+"</p>");
			}
		}
			//Value.Append("<p Class='PageNext'></p></td></tr></table>");
			Value.Append("<p Class='PageNext'></p>");
			return Value.ToString();
		}
		#endregion
		/// <summary>
		/// 重写OnPreRender
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			this.OnPreRender();
		}
		/// <summary>
		/// 重写OnInit
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			this.OnInit();
		}
	}
	#region WebReportDesigner
	/// <summary>
	/// 
	/// </summary>
	[ToolboxItem(false)]
	public class WebReportDesigner : System.Web.UI.Design.ControlDesigner
	{
		/// <summary>
		/// 
		/// </summary>
		public WebReportDesigner(){}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string GetDesignTimeHtml() 
		{
			WebReport oControl = ( WebReport )Component ;
			string strValue="<TABLE width=\"100%\"cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><TR><TD valign=\"middle\" align=\"center\">"+oControl.ID.ToString()+"</TD></TR></TABLE>";
			return strValue;
		}
		#region GetErrrorDesignTimeHtml

		/// <summary>
		/// 获取在呈现控件时遇到错误后在设计时为指定的异常显示的 HTML
		/// </summary>
		/// <param name="e">要为其显示错误信息的异常</param>
		/// <returns>设计时为指定的异常显示的 HTML</returns>
		protected override string GetErrorDesignTimeHtml(Exception e)
		{
			string errorstr="创建控件时出错！"+e.Message;
			return CreatePlaceHolderDesignTimeHtml(errorstr);
		}

		#endregion
	}
	#endregion
	#region ReportStyle Enumerations
	/// <summary>
	/// 报表形式。
	/// </summary>
	public enum ReportStyle:byte
	{
		/// <summary>
		/// 套打形式。
		/// </summary>
		FreeForm,
		/// <summary>
		/// 列表形式。
		/// </summary>
		ListForm
	}
	#endregion
	#region ToolBarStyle Enumerations
	/// <summary>
	/// 工具栏样式。
	/// </summary>
	public enum ToolBarStyle:byte
	{
		/// <summary>
		/// 只在顶端。
		/// </summary>
		Top,
		/// <summary>
		/// 只在底端。
		/// </summary>
		Bottom,
		/// <summary>
		/// 上下都有。
		/// </summary>
		Both
	}
	#endregion
	#region Header_FooterStyle Enumerations
	/// <summary>
	/// 报表形式。
	/// </summary>
	public enum Header_FooterStyle:byte
	{
		/// <summary>
		/// 不分页。
		/// </summary>
		NoCycle,
		/// <summary>
		/// 分页。
		/// </summary>
		Cycle
	}
	#endregion
	#region DataSetTypeConverter
	//	/// <summary>
	//	/// 
	//	/// </summary>
	//	[ToolboxItem(false)]
	//	protected class DataSetTypeConverter : TypeConverter
	//	{ 
	//		/// <summary>
	//		/// 
	//		/// </summary>
	//		/// <param name="context"></param>
	//		/// <returns></returns>
	//		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) 
	//		{
	//			ArrayList ctrls=new ArrayList();
	//			IDesignerHost host=(IDesignerHost)context.GetService(typeof(System.ComponentModel.Design.IDesignerHost));
	//			IContainer container=host.Container;
	//			if(container!=null)
	//			{
	//				for(int i=0;i<container.Components.Count;i++)
	//				{
	//					IComponent compt=container.Components[i];
	//					if(compt is DataSet)
	//					{
	//						ctrls.Add(((DataSet)compt).);
	//					}
	//				}
	//			}
	//			return new StandardValuesCollection(ctrls);
	//			//			return svc; 
	//		} 
	//		/// <summary>
	//		/// 
	//		/// </summary>
	//		/// <param name="context"></param>
	//		/// <returns></returns>
	//		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) 
	//		{
	//			return false; 
	//		} 
	//		/// <summary>
	//		/// 
	//		/// </summary>
	//		/// <param name="context"></param>
	//		/// <returns></returns>
	//		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) 
	//		{ 
	//			return true; 
	//		} 
	//
	//	}
	#endregion
	#region DataTableTypeConverter
	/// <summary>
	/// 
	/// </summary>
	[ToolboxItem(false)]
	public class DataTableTypeConverter : TypeConverter
	{ 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) 
		{
			ArrayList ctrls=new ArrayList();
			IDesignerHost host=(IDesignerHost)context.GetService(typeof(System.ComponentModel.Design.IDesignerHost));
			IContainer container=host.Container;
			if(container!=null)
			{
				for(int i=0;i<container.Components.Count;i++)
				{
					IComponent compt=container.Components[i];
					if(compt is DataTable)
					{
						ctrls.Add(((DataTable)compt).TableName);
					}
				}
			}
			return new StandardValuesCollection(ctrls);
		} 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) 
		{
			return false; 
		} 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) 
		{ 
			return true; 
		} 

	}
	#endregion
}

