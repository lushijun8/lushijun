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

namespace Com.UserControl
{
	#region WebDataBinder
	/// <summary>
	/// 对页面所有的控件（TextBox,ListBox,RadioButtonList,DropDownList,Button）进行数据,控件命名：控件类型缩写+对应数据集的字段名(ColumnName)比如:tbcName,ddlcCountry
	/// </summary>
	[ParseChildren(true,"Items"),DefaultProperty("Items"),PersistChildren(false),Designer(typeof(WebDataBinderDesigner)),
	ToolboxData("<{0}:WebDataBinder runat=\"server\" AutoPostBack=\"False\" ></{0}:WebDataBinder>")]
	public class WebDataBinder : System.Web.UI.Control,INamingContainer
	{
		/// <summary>
		/// 
		/// </summary>
		public event EventHandler OnUpdateClick;
		/// <summary>
		/// 
		/// </summary>
		public event EventHandler OnAddClick;
		/// <summary>
		/// 
		/// </summary>
		public event EventHandler OnDeleteClick;

		private MappingItemCollection _Items;
		
		private ImageButton ibModify;
		private ImageButton ibAdd;
		private ImageButton ibDelete;

		private ImageButton ibFirst;
		private ImageButton ibPre;

		private Label lCurrentRowIndex;
		private Label lRowCount;

		private ImageButton ibNext;
		private ImageButton ibLast;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{
			if(!Page.IsClientScriptBlockRegistered("Style"))
			{
				Page.RegisterClientScriptBlock("Style",@"<script language='javascript'>
	function FieldFocus(obj)
	{
    obj.style.backgroundColor='#cccccc';
	//obj.style.border='black 1px solid';
	}
	function FieldBlur(obj)
	{
	obj.style.backgroundColor='#ffffff';
	//obj.style.border='white 1px solid';
	}
    function ButtonOnfocus(obj)
	{
	obj.style.border='black 1px solid';
	}
	function ButtonOnBlur(obj)
	{
	obj.style.border='black 1px solid';
	}
function SetNull(obj)
	{
		 if(obj.value=='')
         {
           obj.value='0';
          }
	 }
		function CheckKeyCode(obj,keyCodes)
		{
			if(event.keyCode==110 || event.keyCode==190)
			{
				if(obj.value.indexOf('.')!=-1)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				var keyCodes=new Array(8,9,13,16,17,35,36,37,38,39,40,46,48,49,50,51,52,53,54,55,56,57,96,97,98,99,100,101,102,103,104,105);
				for(var i=0;i<keyCodes.length;i++)
				{
					if(event.keyCode==keyCodes[i])
					{
						return true;
					}
				}
				return false;
			}
		}
		</script>");
			}
			if(!Page.IsClientScriptBlockRegistered("RegexCheck"))
			{
				Page.RegisterClientScriptBlock("RegexCheck","<script Language=\"JavaScript\">"+"\n"+
					"function RegexCheck(obj,RegexName,RegexStr)"+"\n"+
					"{"+"\n"+

					"var m,exp,txt;"+"\n"+
					"txt=document.all[obj].value;"+"\n"+

					"if(txt!='')"+"\n"+
					"{"+"\n"+//

					"exp = new RegExp(RegexStr);"+"\n"+
					"if(txt.match(exp)!=null)"+"\n"+
					"{return true;}"+"\n"+
					"else"+"\n"+
					"{return false;}"+"\n"+
					"}"+"\n"+//
					"else"+"\n"+
					"{return true;}"+"\n"+
					"}"+"\n"+

					"function IsNull(obj)"+"\n"+
					"{"+"\n"+

					"var txt;"+"\n"+
					"txt=document.all[obj].value;"+"\n"+

					"if(txt=='')"+"\n"+
					"{"+"\n"+//
					"return true;"+"\n"+
					"}"+"\n"+//
					"else"+"\n"+
					"{"+"\n"+//
					"return false;"+"\n"+
					"}"+"\n"+//
					"}"+"\n"+
					"</script>"+"\n");
			}
			string strOnSubmitFun="";
			foreach(MappingItem oItem in this.Items)
			{
				if(oItem.CanNull==false)
				{
					strOnSubmitFun+=" if(IsNull('"+oItem.Ctrl+"')) \n { \n alert('"+oItem.RegularName+"不能为空！');"+"\n"+"document.all['"+oItem.Ctrl+"'].focus();\n return false;}"+"\n";
				}
				if(oItem.IsCheck==true)
				{
					string RegexStr="";
					string RegexName="";
					//自定义表达式
					#region
					if(oItem.RegularExpression!=null)
					{
						RegexName=oItem.RegularName;
						RegexStr=oItem.RegularExpression;
					}
						//模式表达式
					else
					{
						switch(oItem.CheckMode)
						{
							case RegexMode.Email:
								RegexName="邮件地址";
								RegexStr="^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|com|gov|mil|org|edu|int)$";
								break;
							case RegexMode.Fax:
								RegexName="传真";
								RegexStr="^[+]{0,1}(\\d){1,3}[ ]?([-]?((\\d)|[ ]){1,12})+$";
								break;
							case RegexMode.Mobile:
								RegexName="手机";
								RegexStr="^0{0,1}13[0-9]{9}$/";
								break;
							case RegexMode.Tel:
								RegexName="电话";
								RegexStr="^[+]{0,1}(\\d){1,3}[ ]?([-]?((\\d)|[ ]){1,12})+$";
								break;
							case RegexMode.WebSite:
								RegexName="网址";
								RegexStr="^http:\\/\\/[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}\\/(\\S*)?$";
								break;
							case RegexMode.ZipCode:
								RegexName="邮编";
								RegexStr="^[0-9]{6}$";
								break;
							case RegexMode.Number:
								RegexName="数字";
								RegexStr="\\d";
								break;
							default:
								RegexName="邮件地址";
								RegexStr="^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|com|gov|mil|org|edu|int)$";
								break;

						}
						
						if(oItem.RegularName!=null && oItem.RegularName!="")
						{
							RegexName=oItem.RegularName;
						}
					}
					#endregion
					strOnSubmitFun+=" if(!RegexCheck('"+oItem.Ctrl+"','"+RegexName+"','"+RegexStr+"')) \n { \n alert('请正确填写"+RegexName+"');"+"\n"+"document.all['"+oItem.Ctrl+"'].focus();\n return false;}"+"\n";
				}
			}
			
			if(!Page.IsClientScriptBlockRegistered(this.UniqueID+"_checkform"))
			{
				Page.RegisterClientScriptBlock(this.UniqueID+"_checkform","<script Language='JavaScript'>"+"\n"+"function "+this.UniqueID+"_checkform()\n{document.all['WebDataBinder_tbDataChange'].value='0';"+"\n"+strOnSubmitFun+"\n"+" if(confirm('确定要提交吗？')){return true;}else{return false;}}"+"\n"+"</script>");
			}
			if(this.ShowModifyButton!=false)
			{
				ibModify.Attributes.Add("onclick","return "+this.UniqueID+"_checkform();");
			}
			if(this.ShowAddButton!=false)
			{
				ibAdd.Attributes.Add("onclick","return "+this.UniqueID+"_checkform();");
			}
			if(this.ShowDeleteButton!=false)
			{
				ibDelete.Attributes.Add("onclick","return "+this.UniqueID+"_checkform();");
			}
			if(!Page.IsClientScriptBlockRegistered("onbeforeunload"))
			{
				//				Page.RegisterClientScriptBlock("onbeforeunload", "<script language='javascript'>document.body.onbeforeunload=function onbeforeunload(){if(document.all['WebDataBinder_tbDataChange'].value!='0' && window.opener!=null){return '数据已被改变！确定不保存就离开吗？'}};document.body.onunload=function onunload(){if(window.opener!=null){window.opener.document.forms[0].submit()}}</script><script language=\"javascript\">document.write(\"<LINK href='"+this.CssClass+"' type='text/css' rel='stylesheet'>\");</script>");
			}
			if(!Page.IsClientScriptBlockRegistered("WebBrowser"))
			{
				Page.RegisterClientScriptBlock("WebBrowser", @"<OBJECT id=WebBrowser classid=CLSID:8856F961-340A-11D0-A96B-00C04FD705A2  height=0  width=0> </OBJECT><LINK href='../../../pub/css/PrintUI.css' type='text/css' rel='stylesheet'  media=print>");
			}
			Page.RegisterHiddenField("WebDataBinder_tbDataChange","0");
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}
		#region  OnInit
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			#region 添加控件
			if(this.FindControl(this.UniqueID+"tToolBar")==null)
			{
				Table tToolBar=new Table();
				tToolBar.ID=this.UniqueID+"tToolBar";
				tToolBar.Width = new Unit("100%");
				TableCell tcToolBar=new TableCell();
				TableCell tcNavigation=new TableCell();

				tToolBar.Rows.Add(new TableRow());
				tcToolBar.Wrap = false;
				tcToolBar.Width = new Unit("50%");
				tcToolBar.HorizontalAlign=HorizontalAlign.Center;
				tcNavigation.Width = new Unit("50%");
				tcNavigation.HorizontalAlign=HorizontalAlign.Right;
				//tToolBar.Rows[0].Cells.Add(cToolBar);
				if(this.ShowAddButton!=false)
				{
					ibAdd=new ImageButton();
					ibAdd.ID=this.UniqueID+"ibAdd";
					//ibAdd.Src=this.AddButtonImgUrl;
					ibAdd.AlternateText="添加";
					ibAdd.Click+=new ImageClickEventHandler(ibAdd_Click);
					ibAdd.Attributes.Add("class","ImageButton");
					tcToolBar.Controls.Add(ibAdd);
					tcToolBar.Controls.Add(new LiteralControl("　"));
				}
				if(this.ShowModifyButton!=false)
				{
					ibModify=new ImageButton();
					ibModify.ID=this.UniqueID+"ibModify";
					//ibModify.Src=this.ModifyButtonImgUrl;
					ibModify.AlternateText="修改";
					ibModify.Click+=new ImageClickEventHandler(ibModify_Click);
					ibModify.Attributes.Add("class","ImageButton");
					tcToolBar.Controls.Add(ibModify);
					tcToolBar.Controls.Add(new LiteralControl("　"));
				}
				
				if(this.ShowDeleteButton!=false)
				{
					ibDelete=new ImageButton();
					ibDelete.ID=this.UniqueID+"ibDelete";
					//ibDelete.Src=this.DeleteButtonImgUrl;
					ibDelete.AlternateText="删除";
					ibDelete.Click+=new ImageClickEventHandler(ibDelete_Click);
					ibDelete.Attributes.Add("class","ImageButton");
					tcToolBar.Controls.Add(ibDelete);
					tcToolBar.Controls.Add(new LiteralControl("　"));
				}
				if(this.ShowPrintButton!=false)
				{
					HtmlImage imgPrint=new HtmlImage();
					imgPrint.Src=this.PrintButtonImgUrl;
					imgPrint.Alt="打印";
					imgPrint.Attributes.Add("onclick","document.all['WebBrowser'].ExecWB(7,1);");
					imgPrint.Attributes.Add("style","CURSOR: hand;");
					imgPrint.Attributes.Add("class","ImageButton");
					tcToolBar.Controls.Add(imgPrint);
					tcToolBar.Controls.Add(new LiteralControl("　"));
				}
				if(this.ShowResetButton!=false)
				{
					HtmlImage imgReset=new HtmlImage();
					imgReset.Src=this.ResetButtonImgUrl;
					imgReset.Alt="重置";
					imgReset.Attributes.Add("onclick","document.forms[0].reset();");
					imgReset.Attributes.Add("style","CURSOR: hand;");
					imgReset.Attributes.Add("class","ImageButton");
					tcToolBar.Controls.Add(imgReset);
					tcToolBar.Controls.Add(new LiteralControl("　"));
				}
				if(this.ShowCloseButton!=false)
				{
					HtmlImage imgClose=new HtmlImage();
					imgClose.Src=this.CloseButtonImgUrl;
					imgClose.Alt="关闭";
					imgClose.Attributes.Add("onclick","window.close();");
					imgClose.Attributes.Add("style","CURSOR: hand;");
					imgClose.Attributes.Add("class","ImageButton");
					tcToolBar.Controls.Add(imgClose);
					tcToolBar.Controls.Add(new LiteralControl("　"));
				}
				if(this.ShowNavigationButton!=false)
				{
					ibFirst=new ImageButton();
					ibFirst.ID=this.UniqueID+"ibFirst";
					//ibFirst.ImageUrl=this.FirstNavigationImgUrl;
					ibFirst.AlternateText="|<";
					ibFirst.Click+=new ImageClickEventHandler(ibFirst_Click);
					ibFirst.Attributes.Add("class","ImageButton");

					ibPre=new ImageButton();
					ibPre.ID=this.UniqueID+"ibPre";
					//ibPre.ImageUrl=this.PreNavigationImgUrl;
					ibPre.AlternateText="<";
					ibPre.Click+=new ImageClickEventHandler(ibPre_Click);
					ibPre.Attributes.Add("class","ImageButton");

					lCurrentRowIndex=new Label();
					lCurrentRowIndex.ID=this.UniqueID+"lCurrentRowIndex";
					lCurrentRowIndex.Text=Convert.ToString(this.CurrentRowIndex+1);
					lCurrentRowIndex.Attributes.Add("class","ImageButton");

					lRowCount=new Label();
					lRowCount.ID=this.UniqueID+"lRowCount";
					lRowCount.Attributes.Add("class","ImageButton");
					//lRowCount.Text=this.DataSource.Tables[0].Rows.Count.ToString();

					ibNext=new ImageButton();
					ibNext.ID=this.UniqueID+"ibNext";
					//ibNext.ImageUrl=this.NextNavigationImgUrl;
					ibNext.AlternateText=">";
					ibNext.Click+=new ImageClickEventHandler(ibNext_Click);
					ibNext.Attributes.Add("class","ImageButton");

					ibLast=new ImageButton();
					ibLast.ID=this.UniqueID+"ibLast";
					//ibLast.ImageUrl=this.LastNavigationImgUrl;
					ibLast.AlternateText=">|";
					ibLast.Click+=new ImageClickEventHandler(ibLast_Click);
					ibLast.Attributes.Add("class","ImageButton");

					tcNavigation.Controls.Add(ibFirst);
					tcNavigation.Controls.Add(ibPre);

					tcNavigation.Controls.Add(lCurrentRowIndex);
					tcNavigation.Controls.Add(lRowCount);

					tcNavigation.Controls.Add(ibNext);
					tcNavigation.Controls.Add(ibLast);
				}
				tToolBar.Rows[0].Cells.Add(tcToolBar);
				tToolBar.Rows[0].Cells.Add(tcNavigation);
				//				HtmlGenericControl AlertForm=new HtmlGenericControl("DIV");
				//				AlertForm.ID="AlertForm";
				//				AlertForm.InnerHtml=@"<TABLE style='HEIGHT: 76px' cellSpacing='0' cellPadding='0' width='100%' border='0'>
				//						<TR>
				//							<TD bgColor='#0099ff'>提示信息</TD>
				//						</TR>
				//						<TR>
				//							<TD height='60'><DIV id='AlertFormText'></DIV></TD>
				//						</TR>
				//					</TABLE>
				//                    <INPUT type='button' value='确定' onclick='showhide('"+this.UniqueID+"_AlertForm')'>";
				//				AlertForm.Attributes.Add("style","Z-INDEX: 102; LEFT: 200px; VISIBILITY: hidden; WIDTH: 200px; CURSOR: move; POSITION: absolute; TOP: 168px; HEIGHT: 95px; BACKGROUND-COLOR: #cccccc");
				//				if(Page.FindControl("AlertForm")==null)
				//				{
				//					this.Controls.Add(AlertForm);
				//				}
				this.Controls.Add(tToolBar);
				
			}
			//			foreach(System.Web.UI.Control ctrl in this.Page.Controls)
			//			{
			//				if(ctrl is  HtmlForm)
			//				{
			//					foreach(System.Web.UI.Control subctrl in ctrl.Controls)
			//					{
			//						if(subctrl.ID!=null)
			//						{
			//							this.SetAttribute(subctrl);
			//						}
			//					}
			//				}
			//			}
			#region
					
			if((ImageButton)this.FindControl(this.UniqueID+"ibAdd")!=null)
			{
				if(this.ShowAddButton==false)
				{
					((ImageButton)this.FindControl(this.UniqueID+"ibAdd")).Visible=false;
				}
				((ImageButton)this.FindControl(this.UniqueID+"ibAdd")).ImageUrl=this.AddButtonImgUrl;
			}
			if((ImageButton)this.FindControl(this.UniqueID+"ibModify")!=null)
			{
				if(this.ShowModifyButton==false)
				{
					((ImageButton)this.FindControl(this.UniqueID+"ibModify")).Visible=false;
				}
				((ImageButton)this.FindControl(this.UniqueID+"ibModify")).ImageUrl=this.ModifyButtonImgUrl;
			}
			if((ImageButton)this.FindControl(this.UniqueID+"ibDelete")!=null)
			{
				if(this.ShowDeleteButton==false)
				{
					((ImageButton)this.FindControl(this.UniqueID+"ibDelete")).Visible=false;
				}
				((ImageButton)this.FindControl(this.UniqueID+"ibDelete")).ImageUrl=this.DeleteButtonImgUrl;
			}

			if((ImageButton)this.FindControl(this.UniqueID+"ibFirst")!=null)
			{
				if(this.ShowNavigationButton==false)
				{
					((ImageButton)this.FindControl(this.UniqueID+"ibFirst")).Visible=false;
				}
				((ImageButton)this.FindControl(this.UniqueID+"ibFirst")).ImageUrl=this.FirstNavigationImgUrl;
			}
			if((ImageButton)this.FindControl(this.UniqueID+"ibPre")!=null)
			{
				if(this.ShowNavigationButton==false)
				{
					((ImageButton)this.FindControl(this.UniqueID+"ibPre")).Visible=false;
				}
				((ImageButton)this.FindControl(this.UniqueID+"ibPre")).ImageUrl=this.PreNavigationImgUrl;
			}
			if((Label)this.FindControl(this.UniqueID+"lRowCount")!=null)
			{
				if(this.ShowNavigationButton==false)
				{
					((Label)this.FindControl(this.UniqueID+"lRowCount")).Visible=false;
				}
				((Label)this.FindControl(this.UniqueID+"lRowCount")).Text="/"+this.DataSource.Tables[this.DataTable].Rows.Count.ToString();
			}
			if((Label)this.FindControl(this.UniqueID+"lCurrentRowIndex")!=null)
			{
				if(this.ShowNavigationButton==false)
				{
					((Label)this.FindControl(this.UniqueID+"lCurrentRowIndex")).Visible=false;
				}
				((Label)this.FindControl(this.UniqueID+"lCurrentRowIndex")).Text=Convert.ToString(this.CurrentRowIndex+1);
			}
			if((ImageButton)this.FindControl(this.UniqueID+"ibNext")!=null)
			{
				if(this.ShowNavigationButton==false)
				{
					((ImageButton)this.FindControl(this.UniqueID+"ibNext")).Visible=false;
				}
				((ImageButton)this.FindControl(this.UniqueID+"ibNext")).ImageUrl=this.NextNavigationImgUrl;
			}
			if((ImageButton)this.FindControl(this.UniqueID+"ibLast")!=null)
			{
				if(this.ShowNavigationButton==false)
				{
					((ImageButton)this.FindControl(this.UniqueID+"ibLast")).Visible=false;
				}
				((ImageButton)this.FindControl(this.UniqueID+"ibLast")).ImageUrl=this.LastNavigationImgUrl;
			}
			#endregion
			this.SetAttributes();
			#endregion
		}
		#endregion

		#region CreateChildControls
		/// <summary>
		/// 
		/// </summary>
		protected override void CreateChildControls()
		{
			//			Table tToolBar=new Table();
			//			TableCell tcToolBar=new TableCell();
			//
			//			tToolBar.Rows.Add(new TableRow());
			//			tcToolBar.Wrap = false;
			//			tcToolBar.Width = new Unit("100%");
			//			//tToolBar.Rows[0].Cells.Add(cToolBar);
			//
			//			if(this.ShowModifyButton!=false)
			//			{
			//				ibModify=new ImageButton();
			//				ibModify.ImageUrl=this.ModifyButtonImgUrl;
			//				ibModify.AlternateText="修改";
			//				ibModify.Click+=new ImageClickEventHandler(ibModify_Click);
			//				tcToolBar.Controls.Add(ibModify);
			//			}
			//			if(this.ShowAddButton!=false)
			//			{
			//				ibAdd=new ImageButton();
			//				ibAdd.ImageUrl=this.AddButtonImgUrl;
			//				ibAdd.AlternateText="添加";
			//				ibAdd.Click+=new ImageClickEventHandler(ibAdd_Click);
			//				tcToolBar.Controls.Add(ibAdd);
			//			}
			//			if(this.ShowDeleteButton!=false)
			//			{
			//				ibDelete=new ImageButton();
			//				ibDelete.ImageUrl=this.DeleteButtonImgUrl;
			//				ibDelete.AlternateText="删除";
			//				ibDelete.Click+=new ImageClickEventHandler(ibDelete_Click);
			//				tcToolBar.Controls.Add(ibDelete);
			//			}
			//			ibFirst=new ImageButton();
			////			ibFirst.Attributes.Add("onclick","First()");
			//			ibFirst.ImageUrl=this.FirstNavigationImgUrl;
			//			ibFirst.AlternateText="|<";
			//			ibFirst.Click+=new ImageClickEventHandler(ibFirst_Click);
			//
			//			ibPre=new ImageButton();
			////			ibPre.Attributes.Add("onclick","Pre()");
			//			ibPre.ImageUrl=this.PreNavigationImgUrl;
			//			ibPre.AlternateText="<";
			//			ibPre.Click+=new ImageClickEventHandler(ibPre_Click);
			//
			//			lCurrentRowIndex=new TextBox();
			//			//lCurrentRowIndex.ID="lCurrentRowIndex";
			//			lCurrentRowIndex.Width=20;
			//			//int iRowCount=int.Parse(((TextBox)this.FindControl(this.UniqueID)).Text);
			////			if(MyDataSet.Tables[MyTable].Rows.Count>=iRowCount)
			////			{
			////				this.CurrentRowIndex=int.Parse(((TextBox)ctrl.FindControl(this.UniqueID)).Text);
			////				lCurrentRowIndex.Text=((TextBox)ctrl.FindControl(this.UniqueID)).Text;
			////			}
			////			else
			////			{
			//				//this.CurrentRowIndex=1;
			//				lCurrentRowIndex.Text=Convert.ToString(this.CurrentRowIndex+1);
			//				//((TextBox)this.FindControl(this.UniqueID)).Text="1";
			////			}
			//			lRowCount=new TextBox();
			//			lRowCount.ID="lRowCount";
			//			lRowCount.Width=20;
			////			lRowCount.Text=MyDataSet.Tables[MyTable].Rows.Count.ToString();
			//
			//			ibNext=new ImageButton();
			////			ibNext.Attributes.Add("onclick","Next()");
			//			ibNext.ImageUrl=this.NextNavigationImgUrl;
			//			ibNext.AlternateText=">";
			//			ibNext.Click+=new ImageClickEventHandler(ibNext_Click);
			//
			//			ibLast=new ImageButton();
			////			ibLast.Attributes.Add("onclick","Last()");
			//			ibLast.ImageUrl=this.LastNavigationImgUrl;
			//			ibLast.AlternateText=">|";
			//			ibLast.Click+=new ImageClickEventHandler(ibLast_Click);
			//
			//			tcToolBar.Controls.Add(ibFirst);
			//			tcToolBar.Controls.Add(ibPre);
			//
			//			tcToolBar.Controls.Add(lCurrentRowIndex);
			//			tcToolBar.Controls.Add(lRowCount);
			//
			//			tcToolBar.Controls.Add(ibNext);
			//			tcToolBar.Controls.Add(ibLast);
			//			tToolBar.Rows[0].Cells.Add(tcToolBar);
			//			this.Controls.Add(tToolBar);
		}
		#endregion
		/// <summary>
		/// 
		/// </summary>
		public WebDataBinder(): base()
		{
			_Items = new MappingItemCollection();
		}
		#region 属性
		/// <summary>
		/// 
		/// </summary>
		[Browsable(true),Bindable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		NotifyParentProperty(true),
		PersistenceMode(PersistenceMode.InnerDefaultProperty),Category("MyProperty"),Description("Items"),
		Editor(typeof(System.ComponentModel.Design.CollectionEditor),typeof(System.Drawing.Design.UITypeEditor))]
		public MappingItemCollection Items
		{
			get
			{
				if (this._Items == null) 
				{ 
 
					this._Items= new MappingItemCollection(); 
 
				} 
				return this._Items;
			}
			//			set
			//			{
			//				this._Items = value;
			//			}
		}
		/// <summary>
		/// Css样式表文件位置
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/css/AddUI.css"),Description("Css样式表文件位置"),Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
		public string CssClass
		{
			get
			{
				if(ViewState["CssClass"]==null || (string)ViewState["CssClass"]=="")
				{
					ViewState["CssClass"]="../../../pub/css/AddUI.css";
					return "../../../pub/css/AddUI.css";
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
		/// 
		/// </summary>
		[Category("MyProperty"),DefaultValue(MappingItemsBindMode.View),Description("添加,更新,浏览,打印的模式")]
		public MappingItemsBindMode BindMode
		{
			get
			{
				if(ViewState["BindMode"]==null)
				{
					ViewState["BindMode"]=MappingItemsBindMode.View;
					return MappingItemsBindMode.View;
				}
				else
				{
					return (MappingItemsBindMode)ViewState["BindMode"];
				}
				
			}
			set
			{
				ViewState["BindMode"] = value;
			}
		}
		/// <summary>
		/// 当选定内容改变后，数据是否自动回送服务器
		/// </summary>
		[Category("MyProperty"),Description("是否显示添加按钮")]
		public bool AutoUpdate
		{
			get
			{
				if(ViewState["AutoUpdate"]==null)
				{
					ViewState["AutoUpdate"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["AutoUpdate"];
				}
			}
			set
			{
				ViewState["AutoUpdate"] = value;
			}
		}
		/// <summary>
		/// 当选定内容改变后，数据是否自动回送服务器
		/// </summary>
		[Category("MyProperty"),Description("是否显示添加按钮")]
		public bool AutoPostBack
		{
			get
			{
				if(ViewState["AutoPostBack"]==null)
				{
					ViewState["AutoPostBack"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["AutoPostBack"];
				}
			}
			set
			{
				ViewState["AutoPostBack"] = value;
			}
		}
		/// <summary>
		/// 是否显示添加按钮
		/// </summary>
		[Category("MyProperty"),DefaultValue(true),Description("是否显示添加按钮")]
		public bool ShowAddButton
		{
			get
			{
				if(ViewState["ShowAddButton"]==null)
				{
					ViewState["ShowAddButton"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowAddButton"];
				}
				
			}
			set
			{
				ViewState["ShowAddButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示删除按钮
		/// </summary>
		[Category("MyProperty"),DefaultValue(true),Description("是否显示删除按钮")]
		public bool ShowDeleteButton
		{
			get
			{
				
				if(ViewState["ShowDeleteButton"]==null)
				{
					ViewState["ShowDeleteButton"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowDeleteButton"];
				}
				
			}
			set
			{
				ViewState["ShowDeleteButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示修改按钮
		/// </summary>
		[Category("MyProperty"),DefaultValue(true),Description("是否显示修改按钮")]
		public bool ShowModifyButton
		{
			get
			{
				
				if(ViewState["ShowModifyButton"]==null)
				{
					ViewState["ShowModifyButton"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowModifyButton"];
				}
				
			}
			set
			{
				ViewState["ShowModifyButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示打印按钮
		/// </summary>
		[Category("MyProperty"),DefaultValue(true),Description("是否显示打印按钮")]
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
		/// 是否显示重置按钮
		/// </summary>
		[Category("MyProperty"),DefaultValue(false),Description("是否显示重置按钮")]
		public bool ShowResetButton
		{
			get
			{
				
				if(ViewState["ShowResetButton"]==null)
				{
					ViewState["ShowResetButton"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["ShowResetButton"];
				}
				
			}
			set
			{
				ViewState["ShowResetButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示关闭按钮
		/// </summary>
		[Category("MyProperty"),DefaultValue(false),Description("是否显示关闭按钮")]
		public bool ShowCloseButton
		{
			get
			{
				
				if(ViewState["ShowCloseButton"]==null)
				{
					ViewState["ShowCloseButton"]=false;
					return false;
				}
				else
				{
					return (bool)ViewState["ShowCloseButton"];
				}
				
			}
			set
			{
				ViewState["ShowCloseButton"] = value;
			}
		}
		/// <summary>
		/// 是否显示导航按钮
		/// </summary>
		[Category("MyProperty"),DefaultValue(true),Description("是否显示导航按钮")]
		public bool ShowNavigationButton
		{
			get
			{
				
				if(ViewState["ShowNavigationButton"]==null)
				{
					ViewState["ShowNavigationButton"]=true;
					return true;
				}
				else
				{
					return (bool)ViewState["ShowNavigationButton"];
				}
				
			}
			set
			{
				ViewState["ShowNavigationButton"] = value;
			}
		}
		/// <summary>
		/// 选中的索引
		/// </summary>
		[Category("MyProperty"),DefaultValue(0),Description("默认选中的索引")]
		public int CurrentRowIndex
		{
			get
			{
				if(ViewState["CurrentRowIndex"]==null)
				{
					ViewState["CurrentRowIndex"] = 0;
					return 0;
					
				}
				else
				{
					try{return int.Parse(ViewState["CurrentRowIndex"].ToString());}
					catch{ViewState["CurrentRowIndex"] = 0; return 0;}
				}
			}
			set
			{
				ViewState["CurrentRowIndex"] = value;
			}
		}
		/// <summary>
		/// DataSet
		/// </summary>
		[Category("MyProperty"),Description("DataSource")]
		public DataSet DataSource
		{
			get
			{
				if(ViewState["DataSource"]==null)
				{
					return null;
				}
				else
				{
					return (DataSet)ViewState["DataSource"];
				}
			}
			set
			{
				ViewState["DataSource"] = value;
			}
		}
		#endregion
		/// <summary>
		/// DataTable
		/// </summary>
		[Category("MyProperty"),Description("DataTable")]
		public string DataTable
		{
			get
			{
				return (string)ViewState["DataTable"];
				//				if(ViewState["DataSource"]==null)
				//				{
				//					return null;
				//				}
				//				else
				//				{
				//					if(ViewState["DataTable"]==null)
				//					{
				//						ViewState["DataTable"]=this.DataSource.Tables[0].TableName;
				//						return this.DataSource.Tables[0].TableName;
				//					}
				//					else
				//					{
				//						return (string)ViewState["DataTable"];
				//					}
				//				}
			}
			set
			{
				ViewState["DataTable"] = value;
			}
		}
		/// <summary>
		/// PrimaryKey
		/// </summary>
		[Category("MyProperty"),DefaultValue("iID"),Description("PrimaryKey")]
		public string PrimaryKey
		{
			get
			{
				if(ViewState["PrimaryKey"]==null)
				{
					ViewState["PrimaryKey"]="iID";
					return "iID";
				}
				else
				{
					return (string)ViewState["PrimaryKey"];
				}
			}
			set
			{
				ViewState["PrimaryKey"] = value;
			}
		}
		/// <summary>
		/// OtherQueryString
		/// </summary>
		[Category("MyProperty"),DefaultValue(""),Description("OtherQueryString")]
		public string OtherQueryString
		{
			get
			{
				return (string)ViewState["OtherQueryString"];
			}
			set
			{
				ViewState["OtherQueryString"] = value;
			}
		}
		/// <summary>
		/// 修改按钮图片路径
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Save16.gif"),Description("修改按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string ModifyButtonImgUrl
		{
			get
			{
				if(ViewState["ModifyButtonImgUrl"]==null || (string)ViewState["ModifyButtonImgUrl"]=="")
				{
					ViewState["ModifyButtonImgUrl"]="../../../pub/img/button/Save16.gif";
					return "../../../pub/img/button/Save16.gif";
				}
				else
				{
					return (string)ViewState["ModifyButtonImgUrl"];
				}
			}
			set
			{
				ViewState["ModifyButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 添加按钮图片路径
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Save16.gif"),Description("添加按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string AddButtonImgUrl
		{
			get
			{
				if(ViewState["AddButtonImgUrl"]==null || (string)ViewState["AddButtonImgUrl"]=="")
				{
					ViewState["AddButtonImgUrl"]="../../../pub/img/button/Save16.gif";
					return "../../../pub/img/button/Save16.gif";
				}
				else
				{
					return (string)ViewState["AddButtonImgUrl"];
				}
			}
			set
			{
				ViewState["AddButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 删除按钮图片路径
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Delete16.gif"),Description("删除按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string DeleteButtonImgUrl
		{
			get
			{
				if(ViewState["DeleteButtonImgUrl"]==null || (string)ViewState["DeleteButtonImgUrl"]=="")
				{
					ViewState["DeleteButtonImgUrl"]="../../../pub/img/button/Delete16.gif";
					return "../../../pub/img/button/Delete16.gif";
				}
				else
				{
					return (string)ViewState["DeleteButtonImgUrl"];
				}
			}
			set
			{
				ViewState["DeleteButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 打印按钮图片路径
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Print16.gif"),Description("打印按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
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
		/// 重置按钮图片路径
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Reset16.gif"),Description("重置按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string ResetButtonImgUrl
		{
			get
			{
				if(ViewState["ResetButtonImgUrl"]==null || (string)ViewState["ResetButtonImgUrl"]=="")
				{
					ViewState["ResetButtonImgUrl"]="../../../pub/img/button/Reset16.gif";
					return "../../../pub/img/button/Reset16.gif";
				}
				else
				{
					return (string)ViewState["ResetButtonImgUrl"];
				}
			}
			set
			{
				ViewState["ResetButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 关闭按钮图片路径
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Close16.gif"),Description("关闭按钮图片路径"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string CloseButtonImgUrl
		{
			get
			{
				if(ViewState["CloseButtonImgUrl"]==null || (string)ViewState["CloseButtonImgUrl"]=="")
				{
					ViewState["CloseButtonImgUrl"]="../../../pub/img/button/Close16.gif";
					return "../../../pub/img/button/Close16.gif";
				}
				else
				{
					return (string)ViewState["CloseButtonImgUrl"];
				}
			}
			set
			{
				ViewState["CloseButtonImgUrl"] = value;
			}
		}
		/// <summary>
		/// 首页图片
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/First16.gif"),Description("首页图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string FirstNavigationImgUrl
		{
			get
			{
				if(ViewState["FirstNavigationImgUrl"]==null)
				{
					ViewState["FirstNavigationImgUrl"]="../../../pub/img/button/First16.gif";
					return "../../../pub/img/button/First16.gif";
				}
				else
				{
					return (string)ViewState["FirstNavigationImgUrl"];
				}
			}
			set
			{
				ViewState["FirstNavigationImgUrl"] = value;
			}
		}
		/// <summary>
		/// 前一页记录图片
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Pre16.gif"),Description("前一页记录图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string PreNavigationImgUrl
		{
			get
			{
				if(ViewState["PreNavigationImgUrl"]==null)
				{
					ViewState["PreNavigationImgUrl"]="../../../pub/img/button/Pre16.gif";
					return "../../../pub/img/button/Pre16.gif";
				}
				else
				{
					return (string)ViewState["PreNavigationImgUrl"];
				}
			}
			set
			{
				ViewState["PreNavigationImgUrl"] = value;
			}
		}
		/// <summary>
		///  下一页记录图片
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Next16.gif"),Description("下一页记录图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string NextNavigationImgUrl
		{
			get
			{
				if(ViewState["NextNavigationImgUrl"]==null)
				{
					ViewState["NextNavigationImgUrl"]="../../../pub/img/button/Next16.gif";
					return "../../../pub/img/button/Next16.gif";
				}
				else
				{
					return (string)ViewState["NextNavigationImgUrl"];
				}
			}
			set
			{
				ViewState["NextNavigationImgUrl"] = value;
			}
		}
		/// <summary>
		///  最后一页记录图片
		/// </summary>
		[Category("MyProperty"),DefaultValue("../../../pub/img/button/Last16.gif"),Description("最后一页记录图片"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string LastNavigationImgUrl
		{
			get
			{
				if(ViewState["LastNavigationImgUrl"]==null)
				{
					ViewState["LastNavigationImgUrl"]="../../../pub/img/button/Last16.gif";
					return "../../../pub/img/button/Last16.gif";
				}
				else
				{
					return (string)ViewState["LastNavigationImgUrl"];
				}
			}
			set
			{
				ViewState["LastNavigationImgUrl"] = value;
			}
		}
		#region GetTables
		/// <summary>
		/// 
		/// </summary>
		public string[] GetTables()
		{
			ArrayList Table=new ArrayList();
			foreach(MappingItem oItem in this.Items)
			{
				if(oItem.SubTable==null || oItem.SubTable=="")
				{
					if(!Table.Contains(this.DataTable))
					{
						Table.Add(this.DataTable);
					}
				}
				else
				{
					if(!Table.Contains(oItem.SubTable))
					{
						Table.Add(oItem.SubTable);
					}
				}
			}
			string[] Tables=new string[Table.Count];
			for(int i=0;i<Table.Count;i++)
			{
				Tables[i]=Table[i].ToString();
			}
			return Tables;
		}
		#endregion
		#region GetColumns,GetValues
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <returns></returns>
		public string[] GetColumns(string Table)
		{
			ArrayList Columns=new ArrayList();
			foreach(MappingItem oItem in this.Items)
			{
				if(oItem.Ctrl==null)
				{
					continue;
				}
				if(Table==this.DataTable)
				{
					if((oItem.SubTable=="" || oItem.SubTable==null || oItem.SubTable==Table) && Page.FindControl(oItem.Ctrl.ToString())!=null)
					{
						Columns.Add(oItem.Column);
					}
				}
				else
				{
					if(oItem.SubTable==Table && Page.FindControl(oItem.Ctrl.ToString())!=null)
					{
						Columns.Add(oItem.Column);
					}
				}
			}
			string[] Column=new string[Columns.Count];
			for(int i=0;i<Columns.Count;i++)
			{
				Column[i]=Columns[i].ToString();
			}
			return Column;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <returns></returns>
		public string[] GetValues(string Table)
		{
			ArrayList Values=new ArrayList();
			foreach(MappingItem oItem in this.Items)
			{
				if(oItem.Ctrl==null)
				{
					continue;
				}
				if(Table==this.DataTable)
				{
					if((oItem.SubTable=="" || oItem.SubTable==null || oItem.SubTable==Table) && Page.FindControl(oItem.Ctrl.ToString())!=null)
					{
						if(oItem.DbType==DbTypes.String)
						{
							Values.Add("'"+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+"'");
						}
						else
						{
							Values.Add(GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString())));
						}
						
					}
				}
				else
				{
					if(oItem.SubTable==Table && Page.FindControl(oItem.Ctrl.ToString())!=null)
					{
						Values.Add("'"+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+"'");
					}
				}
			}
			string[] Value=new string[Values.Count];
			for(int i=0;i<Values.Count;i++)
			{
				Value[i]=Values[i].ToString();
			}
			return Value;
		}
		#endregion
		#region GetSelectSql
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetSelectSql()
		{
			string Sql="",ColumnName="";
			ArrayList strJoin=new ArrayList();
			if(this.PrimaryKey!="" && this.PrimaryKey!=null)
			{
				ColumnName=ColumnName+this.DataTable+"."+this.PrimaryKey+",";
			}
			foreach(MappingItem oItem in this.Items)
			{
				string Table=this.DataTable;
				if(oItem.SubTable!="" && oItem.SubTable!=null)
				{
					string iID="iID",Fk="",SubTableAlias=oItem.SubTable;
					Table=oItem.SubTable;
					if(oItem.Pk!="" &&  oItem.Pk!=null)
					{
						iID=oItem.Pk;
					}
					if(oItem.Fk!="" &&  oItem.Fk!=null)
					{
						Fk=oItem.Fk;
					}
					if(oItem.SubTableAlias!="" &&  oItem.SubTableAlias!=null)
					{
						SubTableAlias=oItem.SubTableAlias;
						Table=oItem.SubTableAlias;
					}
					if(Fk!="" && !strJoin.Contains(" left join "+oItem.SubTable+" "+SubTableAlias+" on "+SubTableAlias+"."+iID+"="+this.DataTable+"."+Fk+" "))
					{
						strJoin.Add(" left join "+oItem.SubTable+" "+SubTableAlias+" on "+SubTableAlias+"."+iID+"="+this.DataTable+"."+Fk+" ");
					}
				}
				if(oItem.Column!="" && oItem.Column!=null)
				{
					if(oItem.ColumnAlias=="" || oItem.ColumnAlias==null)
					{
						ColumnName=ColumnName+Table+"."+oItem.Column+",";
					}
					else
					{
						ColumnName=ColumnName+Table+"."+oItem.Column+" as "+oItem.ColumnAlias+",";
					}
				}
			}
			ColumnName=ColumnName.TrimEnd(',');
			
			if(ColumnName.Trim()!="")
			{
				Sql=" Select Distinct "+ColumnName+" From "+this.DataTable+" ";
				for(int i=0;i<strJoin.Count;i++)
				{
					Sql+=strJoin[i].ToString();
				}
				if(this.OtherQueryString!="" && this.OtherQueryString!=null)
				{
					Sql+=" Where "+this.OtherQueryString;
				}
			}
			return Sql;
		}
		#endregion
		#region GetInsertSql
		/// <summary>
		/// 
		/// </summary>
		public string GetInsertSql()
		{
			string Sql="";
			Sql+=" "+this.GetInsertSql(this.GetTables())+" ";
			return Sql;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Tables"></param>
		public string GetInsertSql(string[] Tables)
		{
			string Sql="";
			for(int i=0;i<Tables.Length;i++)
			{
				Sql+=" "+this.GetInsertSql(Tables[i])+" ";
			}
			return Sql;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		public string GetInsertSql(string Table)
		{
			string Sql="";
			ArrayList ColumnList=new ArrayList();
			
			foreach(MappingItem oItem in this.Items)
			{
				if(oItem.Ctrl==null)
				{
					continue;
				}
				if(Table==this.DataTable)
				{
					if((oItem.SubTable=="" || oItem.SubTable==null || oItem.SubTable==Table)&& Page.FindControl(oItem.Ctrl.ToString())!=null)
					{
						ColumnList.Add(oItem.Column);
					}
				}
				else
				{
					if(oItem.SubTable==Table)
					{
						ColumnList.Add(oItem.Column);
					}
				}
			}
			
			string[] Columns=new string[ColumnList.Count];
			for(int i=0;i<ColumnList.Count;i++)
			{
				Columns[i]=ColumnList[i].ToString();
			}
			if(ColumnList.Count>0)
			{
				Sql+=" "+this.GetInsertSql(Table,Columns)+" ";
			}
			return Sql;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="Columns"></param>
		/// <returns></returns>
		public string GetInsertSql(string Table,string[] Columns)
		{
			string ColumnValue="";
			string ColumnName="";
			string Sql="";
			
			for(int i=0;i<Columns.Length;i++)
			{
				foreach(MappingItem oItem in this.Items)
				{
					if(oItem.Ctrl==null)
					{
						continue;
					}
					if(Table==this.DataTable)
					{
						if(oItem.Column==Columns[i] && (oItem.SubTable=="" || oItem.SubTable==null || oItem.SubTable==Table) && Page.FindControl(oItem.Ctrl.ToString())!=null)
						{
							if(oItem.DbType==DbTypes.String)
							{
								ColumnValue=ColumnValue+"'"+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+"'"+",";
							}
							else
							{
								ColumnValue=ColumnValue+""+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+""+",";
							}
							ColumnName=ColumnName+Columns[i]+",";
						}
					}
					else
					{
						if(oItem.Column==Columns[i] && oItem.SubTable==Table && Page.FindControl(oItem.Ctrl.ToString())!=null)
						{
							if(oItem.DbType==DbTypes.String)
							{
								ColumnValue=ColumnValue+"'"+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+"'"+",";
							}
							else
							{
								ColumnValue=ColumnValue+""+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+""+",";
							}
							ColumnName=ColumnName+Columns[i]+",";
						}
					}
				}
			}
			ColumnValue=ColumnValue.TrimEnd(',');
			ColumnName=ColumnName.TrimEnd(',');
			if(ColumnValue.Trim()!="")
			{
				Sql=" Insert Into "+Table+"("+ColumnName+") Values("+ColumnValue+") ";
			}
			return Sql;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="Columns"></param>
		/// <param name="Values"></param>
		/// <returns></returns>
		public string GetInsertSql(string Table,string[] Columns,string[] Values)
		{
			string ColumnValue="";
			string ColumnName="";
			string Sql="";
			for(int i=0;i<Columns.Length;i++)
			{
				ColumnValue=ColumnValue+Values[i]+",";
				ColumnName=ColumnName+Columns[i]+",";
			}
			ColumnValue=ColumnValue.TrimEnd(',');
			ColumnName=ColumnName.TrimEnd(',');
			if(ColumnValue.Trim()!="")
			{
				Sql=" Insert Into "+Table+"("+ColumnName+") Values("+ColumnValue+") ";
			}
			return Sql;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="PlusColumns"></param>
		/// <param name="PlusValues"></param>
		/// <returns></returns>
		public string GetPlusInsertSql(string Table,string[] PlusColumns,string[] PlusValues)
		{
			string[] Columns=this.GetColumns(Table);
			string[] Values=this.GetValues(Table);

			string ColumnValue="";
			string ColumnName="";
			string Sql="";

			for(int i=0;i<Columns.Length;i++)
			{
				ColumnValue=ColumnValue+Values[i]+",";
				ColumnName=ColumnName+Columns[i]+",";
			}
			for(int i=0;i<PlusColumns.Length;i++)
			{
				ColumnValue=ColumnValue+PlusValues[i]+",";
				ColumnName=ColumnName+PlusColumns[i]+",";
			}
			ColumnValue=ColumnValue.TrimEnd(',');
			ColumnName=ColumnName.TrimEnd(',');
			if(ColumnValue.Trim()!="")
			{
				Sql=" Insert Into "+Table+"("+ColumnName+") Values("+ColumnValue+") ";
			}
			return Sql;
		}
		#endregion
		#region GetUpdateSql
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="Columns"></param>
		/// <returns></returns>
		public string GetUpdateSql(string Table,string[] Columns)
		{
			string ColumnValue=" ";
			string Sql="";
			for(int i=0;i<Columns.Length;i++)
			{
				foreach(MappingItem oItem in this.Items)
				{
					if(oItem.Ctrl==null)
					{
						continue;
					}
					if(oItem.Column==Columns[i] && (oItem.SubTable==Table || oItem.SubTable=="" || oItem.SubTable==null)&& Page.FindControl(oItem.Ctrl.ToString())!=null)
					{
						if(oItem.DbType==DbTypes.String)
						{
							ColumnValue=ColumnValue+Columns[i]+"='"+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+"'"+",";
						}
						else
						{
							ColumnValue=ColumnValue+Columns[i]+"="+GetCtrlValue(Page.FindControl(oItem.Ctrl.ToString()))+",";
						}
					}
				}
			}
			ColumnValue=ColumnValue.TrimEnd(',');
			if(ColumnValue.Trim()!="")
			{
				if(Table==this.DataTable)
				{
					Sql=" Update "+Table+" Set "+ColumnValue+" Where "+this.PrimaryKey+"="+this.DataSource.Tables[Table].Rows[this.CurrentRowIndex][PrimaryKey];
				}
			}
			return Sql;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="PlusColumns"></param>
		/// <param name="PlusValues"></param>
		/// <returns></returns>
		public string GetPlusUpdateSql(string Table,string[] PlusColumns,string[] PlusValues)
		{
			string[] Columns=this.GetColumns(Table);
			string[] Values=this.GetValues(Table);

			string ColumnValue="";
			string Sql="";

			for(int i=0;i<Columns.Length;i++)
			{
				ColumnValue=ColumnValue+Columns[i]+"="+Values[i]+""+",";
			}
			for(int i=0;i<PlusColumns.Length;i++)
			{
				ColumnValue=ColumnValue+PlusColumns[i]+"="+PlusValues[i]+""+",";
			}
			ColumnValue=ColumnValue.TrimEnd(',');
			if(ColumnValue.Trim()!="")
			{
				Sql=" Update "+Table+" Set "+ColumnValue+" Where "+this.PrimaryKey+"="+this.DataSource.Tables[Table].Rows[this.CurrentRowIndex][PrimaryKey];
			}
			return Sql;
		}
		#endregion
		#region Select
		/// <summary>
		/// 从数据库提取数据
		/// </summary>
		public virtual void Select()
		{
			this.DataSource=DbUtil.GetSqlDataSet(this.GetSelectSql(),this.DataTable);
			this.DataBind(this.DataTable,this.PrimaryKey);
		}
		#endregion
		#region Insert
		/// <summary>
		/// 
		/// </summary>
		public virtual void Insert()
		{
			foreach(DataTable oTable in this.DataSource.Tables)
			{
				this.Insert(oTable.TableName);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Tables"></param>
		public virtual void Insert(string[] Tables)
		{
			for(int i=0;i<Tables.Length;i++)
			{
				this.Insert(Tables[i]);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		public virtual void Insert(string Table)
		{
			ArrayList ColumnList=new ArrayList();
			foreach(MappingItem oItem in this.Items)
			{
				if(oItem.Ctrl==null)
				{
					continue;
				}
				if((oItem.SubTable==Table|| oItem.SubTable=="" || oItem.SubTable==null)&& Page.FindControl(oItem.Ctrl.ToString())!=null)
				{
					ColumnList.Add(oItem.Column);
				}
			}
			string[] Columns=new string[ColumnList.Count];
			for(int i=0;i<ColumnList.Count;i++)
			{
				Columns[i]=ColumnList[i].ToString();
			}
			if(ColumnList.Count>0)
			{
				this.Insert(Table,Columns);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="Columns"></param>
		public virtual void Insert(string Table,string[] Columns)
		{
			if(this.GetInsertSql(Table,Columns)!="")
			{
				TransObj oTrans=new TransObj();
				oTrans.AddTask(this.GetInsertSql(Table,Columns));
				if(oTrans!=null)
				{
					DbUtil.ExecuteTransaction(oTrans);
				}
				//DbUtil.ExecuteSql(this.GetInsertSql(Table,Columns));
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="PlusColumns"></param>
		/// <param name="PlusValues"></param>
		public virtual void Insert(string Table,string[] PlusColumns,string[] PlusValues)
		{
			string[] Columns=this.GetColumns(Table);
			string[] Values=this.GetValues(Table);

			string ColumnValue="";
			string ColumnName="";
			string Sql="";

			for(int i=0;i<Columns.Length;i++)
			{
				ColumnValue=ColumnValue+Values[i]+",";
				ColumnName=ColumnName+Columns[i]+",";
			}
			for(int i=0;i<PlusColumns.Length;i++)
			{
				ColumnValue=ColumnValue+PlusValues[i]+",";
				ColumnName=ColumnName+PlusColumns[i]+",";
			}
			ColumnValue=ColumnValue.TrimEnd(',');
			ColumnName=ColumnName.TrimEnd(',');
			if(ColumnValue.Trim()!="")
			{
				Sql=" Insert Into "+Table+"("+ColumnName+") Values("+ColumnValue+") ";
			}
			if(Sql!="")
			{
				TransObj oTrans=new TransObj();
				oTrans.AddTask(Sql);
				if(oTrans!=null)
				{
					DbUtil.ExecuteTransaction(oTrans);
				}
			}
		}
		#endregion
		#region Update
		/// <summary>
		/// 
		/// </summary>
		public virtual void Update()
		{
			foreach(DataTable oTable in this.DataSource.Tables)
			{
				this.Update(oTable.TableName);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Tables"></param>
		public virtual void Update(string[] Tables)
		{
			for(int i=0;i<Tables.Length;i++)
			{
				this.Update(Tables[i]);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		public virtual void Update(string Table)
		{
			if(this.DataSource==null)
				return;
			if(!this.DataSource.Tables.Contains(Table))
			{
				((Label)this.FindControl(this.UniqueID+"lRowCount")).Text+="数据源不存在表:"+Table;
				return;
			}
			else
			{
				ArrayList ColumnList=new ArrayList();
				foreach(MappingItem oItem in this.Items)
				{
					if(oItem.SubTable=="" || oItem.SubTable==null || oItem.SubTable==Table)
					{
						ColumnList.Add(oItem.Column);
					}
				}
				string[] Columns=new string[ColumnList.Count];
				for(int i=0;i<ColumnList.Count;i++)
				{
					Columns[i]=ColumnList[i].ToString();
				}
				if(ColumnList.Count>0)
				{
					this.Update(Table,Columns);
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="Columns"></param>
		public virtual void Update(string Table,string[] Columns)
		{
			string Sql="";
			Sql=this.GetUpdateSql(Table,Columns);
			if(Sql!="")
			{
				TransObj oTrans=new TransObj();
				oTrans.AddTask(Sql);
				if(oTrans!=null)
				{
					DbUtil.ExecuteTransaction(oTrans);
				}
				//DbUtil.ExecuteSql(Sql);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Table"></param>
		/// <param name="PlusColumns"></param>
		/// <param name="PlusValues"></param>
		public virtual void Update(string Table,string[] PlusColumns,string[] PlusValues)
		{
			string[] Columns=this.GetColumns(Table);
			string[] Values=this.GetValues(Table);

			string ColumnValue="";
			string Sql="";

			for(int i=0;i<Columns.Length;i++)
			{
				ColumnValue=ColumnValue+Columns[i]+"="+Values[i]+""+",";
			}
			for(int i=0;i<PlusColumns.Length;i++)
			{
				ColumnValue=ColumnValue+PlusColumns[i]+"="+PlusValues[i]+""+",";
			}
			ColumnValue=ColumnValue.TrimEnd(',');
			if(ColumnValue.Trim()!="")
			{
				Sql=" Update "+Table+" Set "+ColumnValue+" Where "+this.PrimaryKey+"="+this.DataSource.Tables[Table].Rows[this.CurrentRowIndex][PrimaryKey];
			}
			if(Sql!="")
			{
				TransObj oTrans=new TransObj();
				oTrans.AddTask(Sql);
				if(oTrans!=null)
				{
					DbUtil.ExecuteTransaction(oTrans);
				}
			}
		}
		#endregion
		#region Delete
		/// <summary>
		/// 
		/// </summary>
		public virtual void Delete()
		{
		}
		#endregion
		#region DataBind
		/// <summary>
		/// 对页面所有的控件（TextBox,ListBox,RadioButtonList,DropDownList,Button）进行数据,控件命名：控件类型缩写+对应数据集的字段名(ColumnName)比如:tbcName,ddlcCountry
		/// </summary>
		/// <param name="MyTable">数据表名</param>
		/// <param name="MyPrimaryKey">更新用的主键</param>
		/// <returns></returns>
		public void DataBind(string MyTable,string MyPrimaryKey)
		{
			if(this.DataTable==null || this.DataTable=="")
			{
				this.DataTable=MyTable;
				this.PrimaryKey=MyPrimaryKey;
			}
			System.Web.UI.Page MyPage=this.Page;
			int iRowIndex=this.CurrentRowIndex;
			//			if(this.Items.Count<1)
			//			{
			foreach(System.Web.UI.Control ctrl in MyPage.Controls)
			{
				if(ctrl is  HtmlForm)
				{
					if(this.DataSource.Tables[MyTable].Rows.Count==0)
					{
						((Table)this.FindControl(this.UniqueID+"tToolBar")).Visible=false;
						//						Label lNoRowCount=new Label();
						//						lNoRowCount.Text="<font color=red>没有符合条件的记录!</font>";
						//						ctrl.Controls.AddAt(ctrl.Controls.Count-1,lNoRowCount);
					}
					else if(this.DataSource.Tables[MyTable].Rows.Count==1)
					{
						if((ImageButton)this.FindControl(this.UniqueID+"ibFirst")!=null)
						{
							((ImageButton)this.FindControl(this.UniqueID+"ibFirst")).Visible=false;
							((ImageButton)this.FindControl(this.UniqueID+"ibPre")).Visible=false;
							((ImageButton)this.FindControl(this.UniqueID+"ibNext")).Visible=false;
							((ImageButton)this.FindControl(this.UniqueID+"ibLast")).Visible=false;
							((Label)this.FindControl(this.UniqueID+"lCurrentRowIndex")).Visible=false;
							((Label)this.FindControl(this.UniqueID+"lRowCount")).Visible=false;
						}
					}
					if(this.Items.Count<1)
					{
						foreach(System.Web.UI.Control subctrl in ctrl.Controls)
						{
							if(subctrl.ID!=null)
							{
								this.SetCtrlValue(subctrl,MyTable,iRowIndex,GetColumnFromCtrl(subctrl));
								//this.SetAttribute(subctrl);
							}
						}
					}
					else
					{
						
						for(int i=0;i<this.Items.Count;i++)
						{
							if(this.Items[i].Ctrl!=null && this.Items[i].Ctrl!="")
							{
								if(Page.FindControl(this.Items[i].Ctrl.ToString())!=null)
								{
									if(this.Items[i].ColumnAlias=="" || this.Items[i].ColumnAlias==null)
									{
										this.SetCtrlValue(Page.FindControl(this.Items[i].Ctrl.ToString()),MyTable,iRowIndex,this.Items[i].Column.ToString());
									}
									else
									{
										this.SetCtrlValue(Page.FindControl(this.Items[i].Ctrl.ToString()),MyTable,iRowIndex,this.Items[i].ColumnAlias.ToString());
									}
									if(this.Items[i].DbType==DbTypes.Number&&this.GetCtrlValue(Page.FindControl(this.Items[i].Ctrl.ToString()))=="")
									{
										if(Page.FindControl(this.Items[i].Ctrl.ToString()) is TextBox)
										{
											((TextBox)Page.FindControl(this.Items[i].Ctrl.ToString())).Text="0";
										}
										
									}
									//this.SetAttribute(Page.FindControl(this.Items[i].Ctrl.ToString()));
								}
							}
						}
					}
					break;
				}
			}
			//			}
			//			else
			//			{
			//			}
		}
		#endregion
		#region GetCtrlValue
		private string GetCtrlValue(System.Web.UI.Control ctrl)
		{
			string strValue="";
			if(ctrl is TextBox)
			{
				strValue=((TextBox)ctrl).Text.Replace("'","''");
			}
			if(ctrl is Label)
			{
				strValue=((Label)ctrl).Text.Replace("'","''");
			}
			if(ctrl is ListControl)
			{
				strValue=((ListControl)ctrl).SelectedItem.Value.Replace("'","''");
			}
			if(ctrl is Calendar)
			{
				strValue=((Calendar)ctrl).DateTime.ToShortDateString().Replace("'","''");		
			}
			if(ctrl is ComboBox)
			{
				strValue=((ComboBox)ctrl).Text.Replace("'","''");		
			}
			if(ctrl is RadioButton)
			{
				if(((RadioButton)ctrl).Checked==true)
				{
					strValue="1";
				}
				else
				{
					strValue="0";
				}
			}
			if(ctrl is CheckBox)
			{
				if(((CheckBox)ctrl).Checked==true)
				{
					strValue="1";
				}
				else
				{
					strValue="0";
				}
			}
			if(ctrl is HyperLink)
			{
				strValue=((HyperLink)ctrl).Text.Replace("'","''");
			}
			return strValue;
		}
		#endregion
		#region SetCtrlValue
		private void SetCtrlValue(System.Web.UI.Control subctrl,string MyTable,int iRowIndex,string MyField)
		{
			#region 
			if(subctrl==null)
				return;
			if(subctrl is TextBox)
			{
				if(this.DataSource.Tables[MyTable].Columns.Contains(MyField))
				{
					if(this.DataSource.Tables[MyTable].Rows.Count>0)
					{
						((TextBox)subctrl).Text=this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString();
					}
					else
					{
						((TextBox)subctrl).Text="";
						//((TextBox)subctrl).ReadOnly=true;
					}
				}
			}
			//====================================================
			if(subctrl is Label)
			{
				if(((Label)subctrl).ID!=null)
				{											
					if(this.DataSource.Tables[MyTable].Columns.Contains(MyField))
					{
						if(this.DataSource.Tables[MyTable].Rows.Count>0)
						{
							((Label)subctrl).Text=this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString();
						}
						else
						{
							((Label)subctrl).Text="";
							//((Label)subctrl).Enabled=false;
						}
					}
				}
			}
			if(subctrl is Calendar)
			{
				if(this.DataSource.Tables[MyTable].Columns.Contains(MyField))
				{
					if(this.DataSource.Tables[MyTable].Rows.Count>0)
					{
						((Calendar)subctrl).DateTime=Convert.ToDateTime(this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString());
					}
					else
					{
						((Calendar)subctrl).DateTime=DateTime.Parse("0000-00-00");
					}
				}
			}
			if(subctrl is ListControl)
			{
				if(this.DataSource.Tables[MyTable].Columns.Contains(MyField))
				{
					if(this.DataSource.Tables[MyTable].Rows.Count>1 && this.AutoPostBack==true && ((ListControl)subctrl).Items.Count==this.DataSource.Tables[MyTable].Rows.Count)
					{
						((ListControl)subctrl).SelectedIndexChanged+=new EventHandler(WebDataBinder_SelectedIndexChanged);
						((ListControl)subctrl).AutoPostBack=true;
					}
					int iFlag=0;
					if(this.DataSource.Tables[MyTable].Rows.Count>0)
					{
						foreach(ListItem oItem in ((ListControl)subctrl).Items)
						{
							for(int i=0;i<this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString().Split(',').Length;i++)
							{
								
								if(oItem.Value==this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString().Split(',')[i])
								{
									if(subctrl is CheckBoxList)
									{
										oItem.Selected=true;
									}
									iFlag=1;
									break;
								}
								
							}
						}
						if(iFlag==0)
						{
							foreach(DataRow oDr in this.DataSource.Tables[MyTable].Rows)
							{
								if(((ListControl)subctrl).Items.FindByValue(oDr[MyField].ToString())==null)
								{
									((ListControl)subctrl).Items.Add(oDr[MyField].ToString());
								}
									
							}
						}
						if(!(subctrl is CheckBoxList))
						{
							((ListControl)subctrl).SelectedValue=this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString();
						}
						if(subctrl is Com.UserControl.ComboBox)
						{
							((ComboBox)subctrl).Text=this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString();
						}
					}
					else
					{
						//((ListControl)subctrl).Enabled=false;
					}
				}
			}
			if(subctrl is RadioButton)
			{
				if(((RadioButton)subctrl).ID!=null)
				{											
					if(this.DataSource.Tables[MyTable].Columns.Contains(MyField))
					{
						if(this.DataSource.Tables[MyTable].Rows.Count>0)
						{
							if(this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString().ToLower()=="true" || this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString()=="1")
							{
								((RadioButton)subctrl).Checked=true;
							}
							else
							{
								((RadioButton)subctrl).Checked=false;
							}
						}
						else
						{
							((RadioButton)subctrl).Checked=false;
							//((RadioButton)subctrl).Enabled=false;
						}
					}
				}
			}
			if(subctrl is CheckBox)
			{
				if(((CheckBox)subctrl).ID!=null)
				{											
					if(this.DataSource.Tables[MyTable].Columns.Contains(MyField))
					{
						if(this.DataSource.Tables[MyTable].Rows.Count>0)
						{
							if(this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString().ToLower()=="true" || this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString()=="1")
							{
								((CheckBox)subctrl).Checked=true;
							}
							else
							{
								((CheckBox)subctrl).Checked=false;
							}
						}
						else
						{
							((CheckBox)subctrl).Checked=false;
							//((CheckBox)subctrl).Enabled=false;
						}
					}
				}
			}
			if(subctrl is HyperLink)
			{
				if(((HyperLink)subctrl).ID!=null)
				{											
					if(this.DataSource.Tables[MyTable].Columns.Contains(MyField))
					{
						if(this.DataSource.Tables[MyTable].Rows.Count>0)
						{
							((HyperLink)subctrl).Text=this.DataSource.Tables[MyTable].Rows[iRowIndex][MyField].ToString();
						}
						else
						{
							((HyperLink)subctrl).Text="";
							//((HyperLink)subctrl).Enabled=false;
						}
					}
				}
			}
			//====================================================
			if(subctrl is ComboBox)
			{
							
			}

			//======================================================
			if(subctrl is Button)
			{
				if(this.DataSource.Tables[MyTable].Rows.Count==0)
				{
					//((Button)subctrl).Enabled=false;
				}
			}
			//======================================================
			if(subctrl is ImageButton)
			{
				if(this.DataSource.Tables[MyTable].Rows.Count==0)
				{
					//((ImageButton)subctrl).Enabled=false;
				}
			}
			//====================================================
			if(subctrl is HtmlButton)
			{
				if(this.DataSource.Tables[MyTable].Rows.Count==0)
				{
					//((HtmlButton)subctrl).Disabled=true;
				}
			}
			//====================================================
			//			}
			//			if(strCtrl.Count>0)
			//			{
			//				for(int i=0;i<strCtrl.Count;i++)
			//				{
			//					HtmlTable t=new HtmlTable();
			//					HtmlTableRow tr=new HtmlTableRow();
			//					HtmlTableCell tc=new HtmlTableCell();
			//					tc.InnerText=(string)strCtrl[i];
			//					t.ID="TD"+(string)strCtrl[i];
			//					tc.Attributes.Add("onmousemove","CtrlTDOnMouseMove('"+(string)strCtrl[i]+"')");
			//					tc.Attributes.Add("onblur","CtrlTDOnMouseOut('"+(string)strCtrl[i]+"')");
			//					//tc.Text="123123232131";
			//					//tc.Attributes["width"]="100%";
			//					//t.Width="100%";
			//					ctrl.Controls.AddAt(ctrl.Controls.IndexOf(ctrl.FindControl((string)strCtrl[i])),t);
			//					//tc.Controls.Add(ctrl.FindControl((string)strCtrl[i]));
			//					tr.Cells.Add(tc);
			//					t.Rows.Add(tr);
			//				}
			//			}
			#endregion
		}
		
		#endregion
		#region SetCtrlEnable
		public void SetCtrlEnable(bool Value)
		{
			foreach(MappingItem oItem in this.Items)
			{
				if(Page.FindControl(oItem.Ctrl.ToString())!=null)
				{
					((WebControl)Page.FindControl(oItem.Ctrl.ToString())).Enabled=Value;
				}
			}
		}
		#endregion
		#region SetAttributes
		private void SetAttributes()
		{
			foreach(System.Web.UI.Control ctrl in this.Page.Controls)
			{
				if(ctrl is  HtmlForm)
				{
					ArrayList dbTypes=new ArrayList();
					ArrayList Ctrls=new ArrayList();
					foreach(MappingItem oItem in this.Items)
					{
						if(oItem.Ctrl!=null && oItem.Ctrl!="")
						{
							dbTypes.Add(oItem.DbType);
							Ctrls.Add(oItem.Ctrl);
						}
					}
					foreach(System.Web.UI.Control subctrl in ctrl.Controls)
					{
						if(subctrl.ID!=null)
						{
							if(Ctrls.Contains(subctrl.ID))
							{
								this.SetAttribute(subctrl,(DbTypes)dbTypes[Ctrls.IndexOf(subctrl.ID)]);
							}
							else
							{
								this.SetAttribute(subctrl,DbTypes.String);
							}
						}
					}
				}
			}
		}
		#endregion 
		#region SetAttribute
		private void SetAttribute(System.Web.UI.Control  subctrl,DbTypes DbType)
		{
			#region
			//			foreach(System.Web.UI.Control subctrl in ctrl.Controls)
			//			{
			//====================================================
			if(subctrl==null)
				return;
			if(subctrl is TextBox)
			{
				//				string strField=((TextBox)subctrl).ID.Substring(2,((TextBox)subctrl).ID.Length-2);
				//				if(this.DataTable!=null)
				//				{
				//					if(this.DataSource.Tables[this.DataTable].Columns.Contains(strField))
				//					{
				//Unit unit=new Unit("100%");
				//((TextBox)subctrl).Width=unit;
				//AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"class","OnBlur");
			
				if(DbType==DbTypes.Number)
				{
					Com.WebUI.SetAttribute(new WebControl[]{((TextBox)subctrl)},"style","TEXT-ALIGN:RIGHT;");
					AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onblur","SetNull(this);");
					AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onkeydown","return CheckKeyCode(this,event.keyCode);");
					AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onpaste","return false;");
					AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"ondragenter","return false;");
					AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"value","0");
					AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onkeyup","if(this.value==''){this.value='0';};");
				}	
				AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"style","Border-Bottom:black 1px solid;border-top:None;Border-left:None;Border-right:None");
				AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onblur","FieldBlur(this)");
				AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onfocus","FieldFocus(this)");
				AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onchange","document.all['WebDataBinder_tbDataChange'].value='1';");
				AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"onkeyup","this.onchange()");
				//					}
				//						
				//				}
				//				else
				//				{
				//					//AttributeUtil.SetAttribute(new WebControl[]{((TextBox)subctrl)},"class","OnBlur");
				//				}
			}
			if(subctrl is CheckBox)
			{
				AttributeUtil.SetAttribute(new WebControl[]{((CheckBox)subctrl)},"onclick","document.all['WebDataBinder_tbDataChange'].value='1';");
			}
			if(subctrl is CheckBoxList)
			{
				AttributeUtil.SetAttribute(new WebControl[]{((CheckBoxList)subctrl)},"onclick","document.all['WebDataBinder_tbDataChange'].value='1';");
			}
			if(subctrl is RadioButton)
			{
				AttributeUtil.SetAttribute(new WebControl[]{((RadioButton)subctrl)},"onclick","document.all['WebDataBinder_tbDataChange'].value='1';");
			}
			if(subctrl is RadioButtonList)
			{
				AttributeUtil.SetAttribute(new WebControl[]{((RadioButtonList)subctrl)},"onclick","document.all['WebDataBinder_tbDataChange'].value='1';");
			}

			if(subctrl is ListControl)
			{
				if(subctrl is ComboBox)
				{
					this.SetAttribute(((ComboBox)subctrl).TextControl,DbTypes.String);
					//					AttributeUtil.SetAttribute(new WebControl[]{((ComboBox)subctrl).TextControl},"onchange","document.all['WebDataBinder_tbDataChange'].value='1';");
					//					AttributeUtil.SetAttribute(new WebControl[]{((ComboBox)subctrl).TextControl},"onkeyup","this.onchange()");
				}
				else if(subctrl is DropDownList)
				{
					AttributeUtil.SetAttribute(new WebControl[]{((DropDownList)subctrl)},"onclick","document.all['WebDataBinder_tbDataChange'].value='1';");
					AttributeUtil.SetAttribute(new WebControl[]{((DropDownList)subctrl)},"onchange","document.all['WebDataBinder_tbDataChange'].value='0';");
				}
			}
			if(subctrl is Calendar)
			{
				try
				{
					AttributeUtil.SetAttribute(new HtmlControl[]{(System.Web.UI.HtmlControls.HtmlInputText)((Calendar)subctrl).FindControl(subctrl.UniqueID+":txtYear"),(System.Web.UI.HtmlControls.HtmlInputText)((Calendar)subctrl).FindControl(subctrl.UniqueID+":txtMonth"),(System.Web.UI.HtmlControls.HtmlInputText)((Calendar)subctrl).FindControl(subctrl.UniqueID+":txtDay")},"onchange","document.all['WebDataBinder_tbDataChange'].value='1';");
					AttributeUtil.SetAttribute(new HtmlControl[]{(System.Web.UI.HtmlControls.HtmlInputText)((Calendar)subctrl).FindControl(subctrl.UniqueID+":txtYear"),(System.Web.UI.HtmlControls.HtmlInputText)((Calendar)subctrl).FindControl(subctrl.UniqueID+":txtMonth"),(System.Web.UI.HtmlControls.HtmlInputText)((Calendar)subctrl).FindControl(subctrl.UniqueID+":txtDay")},"onkeyup","this.onchange()");
				}
				catch
				{
				}
			}
			//====================================================
			if(subctrl is Label)
			{
				if(((Label)subctrl).ID!=null)
				{				
					//AttributeUtil.SetAttribute(new WebControl[]{((Label)subctrl)},"class","OnBlur");
				}
			}
			//======================================================
			if(subctrl is Button)
			{
				//AttributeUtil.SetAttribute(new WebControl[]{((Button)subctrl)},"class","OnBlur");
				AttributeUtil.SetAttribute(new WebControl[]{((Button)subctrl)},"onblur","ButtonOnBlur(this)");
				AttributeUtil.SetAttribute(new WebControl[]{((Button)subctrl)},"onmousemove","ButtonOnfocus(this)");
				AttributeUtil.SetAttribute(new WebControl[]{((Button)subctrl)},"onclick","document.all['WebDataBinder_tbDataChange'].value='0'");
			}
			//======================================================
			if(subctrl is ImageButton)
			{
				//AttributeUtil.SetAttribute(new WebControl[]{((ImageButton)subctrl)},"class","OnBlur");
				AttributeUtil.SetAttribute(new WebControl[]{((ImageButton)subctrl)},"onblur","ButtonOnBlur(this)");
				AttributeUtil.SetAttribute(new WebControl[]{((ImageButton)subctrl)},"onmousemove","ButtonOnfocus(this)");
				AttributeUtil.SetAttribute(new WebControl[]{((ImageButton)subctrl)},"onclick","document.all['WebDataBinder_tbDataChange'].value='0'");
			}
			//====================================================
			if(subctrl is HtmlButton)
			{
				//				AttributeUtil.SetAttribute(new WebControl[]{((HtmlButton)subctrl)},"style","border-style:None;BACKGROUND-COLOR:#ffffff");
				//				AttributeUtil.SetAttribute(new WebControl[]{((HtmlButton)subctrl)},"onblur","ButtonOnBlur(this)");
				//				AttributeUtil.SetAttribute(new WebControl[]{((HtmlButton)subctrl)},"onmousemove","ButtonOnfocus(this)");
			}
			//====================================================
			//			}
			#endregion
		}
		
		#endregion
		#region
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Ctrl"></param>
		/// <returns>返回符合命名规则的对应字段</returns>
		public static string GetColumnFromCtrl(System.Web.UI.Control Ctrl)
		{
			if(Ctrl.ID!=null)
			{
				string CtrlType=Ctrl.GetType().ToString().Split('.')[4];
				int i=0;
				for(int k=0;k<CtrlType.Length;k++)
				{
					if(CtrlType[k]>='A' && CtrlType[k]<='Z')
					{
						i++;
					}
				}
			
				return Ctrl.ID.Substring(i,Ctrl.ID.Length-i);
			}
			return "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Ctrl"></param>
		/// <returns>返回符合命名规则的对应字段</returns>
		public static string GetColumnFromCtrl(string Ctrl)
		{
			int i=0;
			for(int k=0;k<Ctrl.Length;k++)
			{
				if(Ctrl[k]>='A' && Ctrl[k]<='Z')
				{
					break;
				}
				i++;
			}
			return Ctrl.Substring(i-1,Ctrl.Length-i+1);
		}
		#endregion
		private void ibModify_Click(object sender, ImageClickEventArgs e)
		{
			if(this.AutoUpdate==true)
			{
				this.Update();
			}
			else
			{
				if(OnUpdateClick!=null)
				{
					this.OnUpdateClick(this.Page,null);
				}
			}
		}

		private void ibAdd_Click(object sender, ImageClickEventArgs e)
		{
			if(OnAddClick!=null)
			{
				this.OnAddClick(this.Page,null);
			}
		}

		private void ibDelete_Click(object sender, ImageClickEventArgs e)
		{
			if(OnDeleteClick!=null)
			{
				this.OnDeleteClick(this.Page,null);
			}
		}

		private void ibFirst_Click(object sender, ImageClickEventArgs e)
		{
			if(this.DataSource!=null)
			{
				this.CurrentRowIndex=0;
				this.DataBind(this.DataTable,this.PrimaryKey);
			}
		}

		private void ibPre_Click(object sender, ImageClickEventArgs e)
		{
			if(this.DataSource!=null)
			{
				if(this.CurrentRowIndex>=1)
				{
					this.CurrentRowIndex-=1;
				}
				this.DataBind(this.DataTable,this.PrimaryKey);
			}
		}

		private void ibNext_Click(object sender, ImageClickEventArgs e)
		{
			if(this.DataSource!=null)
			{
				if(this.CurrentRowIndex<this.DataSource.Tables[this.DataTable].Rows.Count-1)
				{
					this.CurrentRowIndex+=1;
				}
				this.DataBind(this.DataTable,this.PrimaryKey);
			}
		}

		private void ibLast_Click(object sender, ImageClickEventArgs e)
		{
			if(this.DataSource!=null)
			{
				this.CurrentRowIndex=this.DataSource.Tables[0].Rows.Count-1;
				this.DataBind(this.DataTable,this.PrimaryKey);
			}
		}
		private void WebDataBinder_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CurrentRowIndex=((ListControl)sender).SelectedIndex;
			this.DataBind(this.DataTable,this.PrimaryKey);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		protected override void AddParsedSubObject(object obj) 
		{
			if (obj is MappingItem)
			{
				_Items.Add((MappingItem)obj);
			}
		}
	}
	#endregion
	#region WebDataBinderDesigner
	/// <summary>
	/// 
	/// </summary>
	[ToolboxItem(false)]
	public class WebDataBinderDesigner : System.Web.UI.Design.ControlDesigner
	{
		/// <summary>
		/// 
		/// </summary>
		public WebDataBinderDesigner(){}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string GetDesignTimeHtml() 
		{
			WebDataBinder oControl = ( WebDataBinder )Component ;
			string strValue="<TABLE width=\"100%\"cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><TR><TD valign=\"middle\" align=\"center\">";
			if(oControl.ShowAddButton==true)
			{
				strValue+="<img src='"+oControl.AddButtonImgUrl+"'>　";
			}
			if(oControl.ShowDeleteButton==true)
			{
				strValue+="<img src='"+oControl.DeleteButtonImgUrl+"'>　";
			}
			if(oControl.ShowModifyButton==true)
			{
				strValue+="<img src='"+oControl.ModifyButtonImgUrl+"'>　";
			}
			if(oControl.ShowPrintButton==true)
			{
				strValue+="<img src='"+oControl.PrintButtonImgUrl+"'>　";
			}
			if(oControl.ShowResetButton==true)
			{
				strValue+="<img src='"+oControl.ResetButtonImgUrl+"'>　";
			}
			if(oControl.ShowCloseButton==true)
			{
				strValue+="<img src='"+oControl.CloseButtonImgUrl+"'>　";
			}
			if(oControl.ShowNavigationButton==true)
			{
				strValue+="<img src='"+oControl.FirstNavigationImgUrl+"'><img src='"+oControl.PreNavigationImgUrl+"'><img src='"+oControl.NextNavigationImgUrl+"'><img src='"+oControl.LastNavigationImgUrl+"'>";
			}
			if(strValue=="<TABLE width=\"100%\"cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><TR><TD valign=\"middle\" align=\"center\">")
			{
				strValue+="["+oControl.UniqueID+"]</TD></TR></TABLE>";
			}
			else
			{
				strValue+="</TD></TR></TABLE><LINK href=\""+oControl.CssClass+"\" type=\"text/css\" rel=\"stylesheet\">";
			}
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
	#region MappingItemsBindMode Enumerations
	/// <summary>
	/// 校验模式。
	/// </summary>
	public enum MappingItemsBindMode:byte
	{
		/// <summary>
		/// 添加模式。
		/// </summary>
		Add,
		/// <summary>
		/// 更新模式。
		/// </summary>
		Update,
		/// <summary>
		/// 浏览模式。
		/// </summary>
		View,
		/// <summary>
		/// 打印模式。
		/// </summary>
		Print
	}
	#endregion
	#region RegexMode Enumerations
	/// <summary>
	/// 校验模式。
	/// </summary>
	public enum RegexMode:byte
	{
		/// <summary>
		/// 未设置。
		/// </summary>
		NotSet,
		/// <summary>
		/// 电子邮件。
		/// </summary>
		Email,
		/// <summary>
		/// 手机。
		/// </summary>
		Mobile,
		/// <summary>
		/// 电话。
		/// </summary>
		Tel,
		/// <summary>
		/// 网址。
		/// </summary>
		WebSite,
		/// <summary>
		/// 传真。
		/// </summary>
		Fax,
		/// <summary>
		/// 邮编。
		/// </summary>
		ZipCode,
		/// <summary>
		/// 日期(yyyy-mm-dd)。
		/// </summary>
		Date,
		/// <summary>
		/// 数字。
		/// </summary>
		Number
	}
	#endregion
	#region DbTypes Enumerations
	/// <summary>
	/// 校验模式。
	/// </summary>
	public enum DbTypes:byte
	{
		/// <summary>
		/// VarChar,DateTime,Char,Text
		/// </summary>
		String,
		/// <summary>
		/// Int,Decimal,Money,Bit,Numeric
		/// </summary>
		Number
	}
	#endregion
	#region MappingItem
	/// <summary>
	/// MappingItem 的摘要说明。
	/// </summary>
	[ToolboxItem(false)]	
	public class MappingItem :IStateManager
	{
		
		#region 构造函数...
		/// <summary>
		/// 
		/// </summary>
		public MappingItem()
		{
			
		}
		#endregion
		#region GetCtrlValue
		private string GetCtrlValue(System.Web.UI.Control ctrl)
		{
			string strValue="";
			if(ctrl is TextBox)
			{
				strValue=((TextBox)ctrl).Text.Replace("'","''");
			}
			if(ctrl is Label)
			{
				strValue=((Label)ctrl).Text.Replace("'","''");
			}
			if(ctrl is ListControl)
			{
				strValue=((ListControl)ctrl).SelectedItem.Value.Replace("'","''");
			}
			if(ctrl is Calendar)
			{
				strValue=((Calendar)ctrl).DateTime.ToShortDateString().Replace("'","''");		
			}
			if(ctrl is ComboBox)
			{
				strValue=((ComboBox)ctrl).Text.Replace("'","''");		
			}
			if(ctrl is RadioButton)
			{
				if(((RadioButton)ctrl).Checked==true)
				{
					strValue="1";
				}
				else
				{
					strValue="0";
				}
			}
			if(ctrl is CheckBox)
			{
				if(((CheckBox)ctrl).Checked==true)
				{
					strValue="1";
				}
				else
				{
					strValue="0";
				}
			}
			if(ctrl is HyperLink)
			{
				strValue=((HyperLink)ctrl).Text.Replace("'","''");
			}
			return strValue;
		}
		#endregion
		#region SetCtrlValue
		public void SetCtrlValue(System.Web.UI.Control subctrl,string Value)
		{
			#region 
			if(subctrl==null)
				return;
			if(subctrl is TextBox)
			{
				((TextBox)subctrl).Text="";
			}
			//====================================================
			if(subctrl is Label)
			{
				((Label)subctrl).Text="";
			}
			if(subctrl is Calendar)
			{
				((Calendar)subctrl).DateTime=Convert.ToDateTime(Value);
			}
			if(subctrl is ListControl)
			{
				int iFlag=0;
				foreach(ListItem oItem in ((ListControl)subctrl).Items)
				{
					for(int i=0;i<Value.Split(',').Length;i++)
					{
								
						if(oItem.Value==Value.Split(',')[i])
						{
							if(subctrl is CheckBoxList)
							{
								oItem.Selected=true;
							}
							iFlag=1;
							break;
						}
								
					}
				}
				if(iFlag==0)
				{
							
					if(((ListControl)subctrl).Items.FindByValue(Value)==null)
					{
						((ListControl)subctrl).Items.Add(Value);
					}
				}
				if(!(subctrl is CheckBoxList))
				{
					((ListControl)subctrl).SelectedValue=Value;
				}
				if(subctrl is Com.UserControl.ComboBox)
				{
					((ComboBox)subctrl).Text=Value;
				}
			}
			if(subctrl is RadioButton)
			{
				if(Value.ToLower()=="true" || Value=="1")
				{
					((RadioButton)subctrl).Checked=true;
				}
				else
				{
					((RadioButton)subctrl).Checked=false;
				}
						
			}
			if(subctrl is CheckBox)
			{
				
				if(Value.ToLower()=="true" || Value=="1")
				{
					((CheckBox)subctrl).Checked=true;
				}
				else
				{
					((CheckBox)subctrl).Checked=false;
				}
						
			}
			if(subctrl is HyperLink)
			{
				
				((HyperLink)subctrl).Text=Value;
						
			}
			//====================================================
			if(subctrl is ComboBox)
			{
							
			}

			//======================================================
			if(subctrl is Button)
			{
				
			}
			//======================================================
			if(subctrl is ImageButton)
			{
				
			}
			//====================================================
			if(subctrl is HtmlButton)
			{
				
			}
			//====================================================
			#endregion
		}
		
		#endregion
		#region 变量...
		private bool _IsTrackingViewState = false;
		private StateBag _ViewState;
		#endregion
		#region 属性
		/// <summary>
		/// 是否可以为空,
		/// </summary>
		[Description("是否可以为空"),
		Category("Check"),DefaultValue(true),RefreshProperties(RefreshProperties.Repaint)] 
		public bool CanNull
		{
			get
			{
				return (ViewState["CanNull"] == null) ? true : (bool)ViewState["CanNull"];
			}
			set
			{ 
				ViewState["CanNull"] = value;
			}
		}
		/// <summary>
		/// 设置校验的正则表达式
		/// </summary>
		[Description("设置是否需要校验"),
		Category("Check"),DefaultValue(false),RefreshProperties(RefreshProperties.Repaint)] 
		public bool IsCheck
		{
			get
			{
				return (ViewState["IsCheck"] == null) ? false : (bool)ViewState["IsCheck"];
			}
			set
			{ 
				ViewState["IsCheck"] = value;
				if(value==true && (ViewState["RegularExpression"] == null || (string)ViewState["RegularExpression"]=="") && (ViewState["CheckMode"] == null || (RegexMode)ViewState["CheckMode"]==RegexMode.NotSet))
				{
					ViewState["CheckMode"] = RegexMode.Email; 
				}
				//				else
				//				{
				//					ViewState["RegularExpression"] = null; 
				//					ViewState["CheckMode"] = null; 
				//				}
			}
		}
		/// <summary>
		/// 设置校验的正则表达式
		/// </summary>
		[Description("设置校验的正则表达式"),
		Category("Check"),RefreshProperties(RefreshProperties.Repaint)] 
		public string RegularExpression
		{
			get
			{
				return (string)ViewState["RegularExpression"];
			}
			set
			{ 
				ViewState["RegularExpression"] = value; 
				ViewState["CheckMode"] = null; 
			}
		}
		/// <summary>
		/// 设置校验的表达式名称
		/// </summary>
		[Description("设置校验的表达式名称"),
		Category("Check")] 
		public string RegularName
		{
			get
			{
				return (string)ViewState["RegularName"];
			}
			set
			{ 
				ViewState["RegularName"] = value; 
			}
		}
		/// <summary>
		/// 校验模式
		/// </summary>
		[Description("设置校验的模式"),
		Category("Check"), 
		DefaultValue(typeof(RegexMode),"NotSet"),RefreshProperties(RefreshProperties.Repaint)] 
		public RegexMode CheckMode
		{
			get
			{
				if(ViewState["CheckMode"]==null)
				{
					ViewState["CheckMode"]=RegexMode.NotSet;
					return RegexMode.NotSet;
				}
				else
				{
					return (RegexMode)ViewState["CheckMode"];
				}
			}
			set
			{ 
				ViewState["CheckMode"] = value;
				ViewState["RegularExpression"] = null; 
				if((RegexMode)value!=RegexMode.NotSet)
				{
					ViewState["IsCheck"] = true;
				}
			}
		}
		//		/// <summary>
		//		/// 获取或者设置控件的值
		//		/// </summary>
		//		[Category("Data"), Description("控件的值"),RefreshProperties(RefreshProperties.Repaint)]
		//		public string CtrlValue
		//		{
		//			get
		//			{
		//				return this.GetCtrlValue(Page.FindControl(this.Ctrl));
		//			}
		//		}

		/// <summary>
		/// 
		/// </summary>
		[Category("Data"), Description("字段影射的控件"),TypeConverter(typeof(WebControlsTypeConverter)),RefreshProperties(RefreshProperties.Repaint)]
		public string Ctrl
		{
			get
			{
				return (string)ViewState["Ctrl"];
			}
			set
			{ 
				ViewState["Ctrl"] = value;
				if((this.Column=="" || this.Column==null)&&value!="None")
				{
					this.Column=WebDataBinder.GetColumnFromCtrl((string)value);
				}
				//				if(WebDataBinder.GetColumnFromCtrl((string)value).StartsWith("c") || WebDataBinder.GetColumnFromCtrl((string)value).StartsWith("d"))
				//				{
				//					this.DbType=DbTypes.String;
				//				}
				//				else
				//				{
				//					this.DbType=DbTypes.Number;
				//				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("Data"), Description("该控件对应的子表名称"),RefreshProperties(RefreshProperties.Repaint)]
		public string SubTable
		{
			get
			{
				return (string)ViewState["SubTable"];
			}
			set
			{
				ViewState["SubTable"] = value;
				if((this.Pk=="" || this.Pk==null)&&(value!="" || value!=null))
				{
					this.Pk="iID";
				}
			}
		}
		/// <summary>
		/// SubTableAlias
		/// </summary>
		[Category("Data"), Description("该控件对应的子表的别名")]
		public string SubTableAlias
		{
			get
			{
				return (string)ViewState["SubTableAlias"];
			}
			set
			{
				ViewState["SubTableAlias"] = value;
			}
		}
		/// <summary>
		/// Fk
		/// </summary>
		[Category("Data"), Description("主表的外键")]
		public string Fk
		{
			get
			{
				return (string)ViewState["Fk"];
			}
			set
			{
				ViewState["Fk"] = value;
			}
		}
		/// <summary>
		/// Pk
		/// </summary>
		[Category("Data"), Description("子表的外键,默认为iID")]
		public string Pk
		{
			get
			{
				return (string)ViewState["Pk"];
			}
			set
			{
				ViewState["Pk"] = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("Data"), Description("该控件对应的子表列名称"),RefreshProperties(RefreshProperties.Repaint)]
		public string Column
		{
			get
			{
				return (string)ViewState["Column"];
			}
			set
			{
				ViewState["Column"] = value;
				if(this.ColumnAlias!="" && this.ColumnAlias!=null)
				{
					this.ColumnAlias=value;
				}
				//				if(value.StartsWith("c") || value.StartsWith("d"))
				//				{
				//					this.DbType=DbTypes.String;
				//				}
				//				else
				//				{
				//					this.DbType=DbTypes.Number;
				//				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("Data"), Description("该控件对应的子表列名称的别名")]
		public string ColumnAlias
		{
			get
			{
				return (string)ViewState["ColumnAlias"];
			}
			set
			{
				ViewState["ColumnAlias"] = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Description("对应数据库的数据类型"),
		Category("Data"),DefaultValue(DbTypes.String)] 
		public DbTypes DbType
		{
			get
			{
				if(ViewState["DbType"]==null)
				{
					ViewState["DbType"]=DbTypes.String;
					return DbTypes.String;
				}
				else
				{
					return (DbTypes)ViewState["DbType"];
				}
			}
			set
			{ 
				ViewState["DbType"] = value;
			}
		}
		#endregion

		#region IStateManager 成员

		/// <summary>
		/// Sets all items within the StateBag to be dirty
		/// </summary>
		protected void SetViewStateDirty()
		{
			if (_ViewState != null)
			{
				foreach (StateItem item in ViewState.Values)
				{
					item.IsDirty = true;
				}
			}
		}

		/// <summary>
		/// Sets all items within the StateBag to be clean
		/// </summary>
		protected void SetViewStateClean()
		{
			if (_ViewState != null)
			{
				foreach (StateItem item in ViewState.Values)
				{
					item.IsDirty = false;
				}
			}
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			MappingItem copy = (MappingItem)Activator.CreateInstance(this.GetType(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, null);

			// Merge in the properties from this object into the copy
			copy._IsTrackingViewState = this._IsTrackingViewState;

			if (this._ViewState != null)
			{
				StateBag viewState = copy.ViewState;
				foreach (string key in this.ViewState.Keys)
				{
					object item = this.ViewState[key];
					if (item is ICloneable)
					{
						item = ((ICloneable)item).Clone();
					}

					viewState[key] = item;
				}
			}

			return copy;
		}

		/// <summary>
		/// An instance of the StateBag class that contains the view state information.
		/// </summary>
		StateBag ViewState
		{
			get
			{
				// To concerve resources, especially on the page,
				// only create the view state when needed.
				if (_ViewState == null)
				{
					_ViewState = new StateBag();
					if (((IStateManager)this).IsTrackingViewState)
					{
						((IStateManager)_ViewState).TrackViewState();
					}
				}

				return _ViewState;
			}
		}

		/// <summary>
		/// Loads the node's previously saved view state.
		/// </summary>
		/// <param name="state">An Object that contains the saved view state values for the node.</param>
		void IStateManager.LoadViewState(object state)
		{
			((MappingItem)this).LoadViewState(state);
		}

		/// <summary>
		/// Loads the node's previously saved view state.
		/// </summary>
		/// <param name="state">An Object that contains the saved view state values for the node.</param>
		void LoadViewState(object state)
		{
			if (state != null)
			{
				((IStateManager)ViewState).LoadViewState(state);
			}
		}

		/// <summary>
		/// Saves the changes to the node's view state to an Object.
		/// </summary>
		/// <returns>The Object that contains the view state changes.</returns>
		object IStateManager.SaveViewState()
		{
			return ((MappingItem)this).SaveViewState();
		}

		/// <summary>
		/// Saves the changes to the node's view state to an Object.
		/// </summary>
		/// <returns>The Object that contains the view state changes.</returns>
		object SaveViewState()
		{
			if (_ViewState != null)
			{
				return ((IStateManager)_ViewState).SaveViewState();
			}

			return null;
		}

		/// <summary>
		/// Instructs the node to track changes to its view state.
		/// </summary>
		void IStateManager.TrackViewState()
		{
			((MappingItem)this).TrackViewState();
		}

		/// <summary>
		/// Instructs the node to track changes to its view state.
		/// </summary>
		void TrackViewState()
		{
			_IsTrackingViewState = true;

			if (_ViewState != null)
			{
				((IStateManager)_ViewState).TrackViewState();
			}
		}

		/// <summary>
		/// Gets a value indicating whether a server control is tracking its view state changes.
		/// </summary>
		bool IStateManager.IsTrackingViewState
		{
			get { return _IsTrackingViewState; }
		}
		#endregion
	}
	#endregion
	#region MappingItemCollection
	/// <summary>
	/// MappingItemCollection 的摘要说明。
	/// </summary>
	[ToolboxItem(false),Editor(typeof(CollectionEditor),typeof(UITypeEditor))]
	public class MappingItemCollection : System.Collections.CollectionBase,IStateManager
	{
		private bool _Tracking = false;
		private bool _Reloading = false;
		/// <summary>
		/// 
		/// </summary>
		public MappingItemCollection(): base()
		{
			
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Add(MappingItem item)
		{
			if (!Contains(item))
			{
				List.Add(item);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void AddAt(int index, MappingItem item)
		{
			if (!Contains(item))
			{
				List.Insert(index, item);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(MappingItem item)
		{
			return List.Contains(item);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(MappingItem item)
		{
			return List.IndexOf(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Remove(MappingItem item)
		{
			List.Remove(item);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		public new void RemoveAt(int index)
		{
			if (Contains(this[index]))
			{
				List.RemoveAt(index);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public MappingItem this[int Index]
		{
			get
			{
				if(Index >= Count || Index < 0)
				{
					return null;
				}
				return (MappingItem)List[Index];
			}
			set
			{
				List[Index] = value;
			}
		}
		#region IStateManager 成员
		bool Reloading
		{
			get { return _Reloading; }
		}
		/// <summary>
		/// Gets a value indicating whether a server control is tracking its view state changes.
		/// </summary>
		bool IStateManager.IsTrackingViewState
		{
			get { return _Tracking; }
		}
		/// <summary>
		/// Loads the collection's previously saved view state.
		/// </summary>
		/// <param name="state">An Object that contains the saved view state values for the collection.</param>
		void IStateManager.LoadViewState(object state)
		{
			if (state == null)
			{
				return;
			}

			object[] viewState = (object[])state;

			if (viewState[0] != null)
			{
				_Reloading = true;

				//				// Restore and re-do actions
				//				object[] actions = (object[])viewState[0];
				//
				//				ArrayList newActionList = new ArrayList();
				//				foreach (object actionState in actions)
				//				{
				//					Action action = new Action();
				//					action.Load(actionState);
				//
				//					newActionList.Add(action);
				//
				//					switch (action.ActionType)
				//					{
				//						case ActionType.Clear:
				//							List.Clear();
				//							break;
				//
				//						case ActionType.Remove:
				//							List.RemoveAt(action.Index);
				//							break;
				//
				//						case ActionType.Insert:
				//							RedoInsert(action.Index, action.NodeType);
				//							break;
				//					}
				//				}
				//
				//				_Actions = newActionList;
				_Reloading = false;
			}

			if (viewState[1] != null)
			{
				// Load view state changes

				object[] lists = (object[])viewState[1];
				ArrayList indices = (ArrayList)lists[0];
				ArrayList items = (ArrayList)lists[1];

				for (int i = 0; i < indices.Count; i++)
				{
					((IStateManager)List[(int)indices[i]]).LoadViewState(items[i]);
				}
			}
		}

		/// <summary>
		/// Saves the changes to the collection's view state to an Object.
		/// </summary>
		/// <returns>The Object that contains the view state changes.</returns>
		object IStateManager.SaveViewState()
		{
			object[] state = new object[2];

			//			if (Actions.Count > 0)
			//			{
			//				// Save the actions made to the collection
			//				object[] obj = new object[Actions.Count];
			//				for (int i = 0; i < Actions.Count; i++)
			//				{
			//					obj[i] = ((Action)Actions[i]).Save();
			//				}
			//				state[0] = obj;
			//			}

			if (List.Count > 0)
			{
				// Save the view state changes of the child nodes

				ArrayList indices = new ArrayList(4);
				ArrayList items = new ArrayList(4);

				for (int i = 0; i < List.Count; i++)
				{
					object item = ((IStateManager)List[i]).SaveViewState();
					if (item != null)
					{
						indices.Add(i);
						items.Add(item);
					}
				}

				if (indices.Count > 0)
				{
					state[1] = new object[] { indices, items };
				}
			}

			if ((state[0] != null) || (state[1] != null))
			{
				return state;
			}
            
			return null;
		}

		/// <summary>
		/// Instructs the collection to track changes to its view state.
		/// </summary>
		void IStateManager.TrackViewState()
		{
			_Tracking = true;

			// Tracks view state changes in the child nodes
			foreach (MappingItem node in List)
			{
				((IStateManager)node).TrackViewState();
			}
		}
		#endregion

	}
	#endregion
	#region WebControlsTypeConverter
	/// <summary>
	/// 
	/// </summary>
	[ToolboxItem(false)]
	public class WebControlsTypeConverter : TypeConverter
	{ 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) 
		{
			ArrayList ctrls=new ArrayList();
			ctrls.Add("None");
			IDesignerHost host=(IDesignerHost)context.GetService(typeof(System.ComponentModel.Design.IDesignerHost));
			IContainer container=host.Container;
			if(container!=null)
			{
				for(int i=0;i<container.Components.Count;i++)
				{
					IComponent compt=container.Components[i];
					if(compt is TextBox)
					{
						ctrls.Add(((TextBox)compt).ID);
					}
					else if(compt is ListControl)
					{
						ctrls.Add(((ListControl)compt).ID);
					}
					else if(compt is Calendar)
					{
						ctrls.Add(((Calendar)compt).ID);
					}
					else if(compt is ComboBox)
					{
						ctrls.Add(((ComboBox)compt).ID);
					}
					else if(compt is RadioButton)
					{
						ctrls.Add(((RadioButton)compt).ID);
					}
					else if(compt is CheckBox)
					{
						ctrls.Add(((CheckBox)compt).ID);
					}
					else if(compt is Label)
					{
						ctrls.Add(((Label)compt).ID);
					}
					else if(compt is HyperLink)
					{
						ctrls.Add(((Label)compt).ID);
					}
				}
			}
			return new StandardValuesCollection(ctrls);
			//			return svc; 
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
