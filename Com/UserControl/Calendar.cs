using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Com.UserControl
{
	
	#region
	/// <summary>
	///		Summary description for DateDropBox.
	/// </summary>
	[DefaultProperty("Calendar_Width")]
	[Description("一个ASP.Net Web应用程序的日期控件")]
	[Designer(typeof(CalendarDesigner))]
	[ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>")]
	public class Calendar : Panel, INamingContainer
	{


		/// <summary>
		/// 该用户控件的id
		/// </summary>
		private string ControlID;

		/// <summary>
		/// 该日期控件的年份
		/// </summary>		
		public int Year;

		/// <summary>
		/// 该日期控件的月份
		/// </summary>
		public int Month;

		/// <summary>
		/// 图片路径
		/// </summary>
		private string imageurl;

		/// <summary>
		/// 该日期控件的日
		/// </summary>
		public int Day;

		/// <summary>
		/// 控件的宽度
		/// </summary>
		private int width=70;

		/// <summary>
		/// 控件中输入年的宽度
		/// </summary>
		private int yearwidth=25;

		/// <summary>
		/// 控件中输入月的宽度
		/// </summary>
		private int monthwidth=13;

		/// <summary>
		/// 控件中输入日的宽度
		/// </summary>
		private int daywidth=13;

		/// <summary>
		/// 是否激活
		/// </summary>
		private bool enabled = true;


		/// <summary>
		/// 获取或设置一个值，该值指示是否启用 日期控件
		/// </summary>
		[Browsable(true),Description("日期控件的状态"),Category("Appearance")]
		public override bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				enabled = false;
			}
		}


		/// <summary>
		/// 日的宽度
		/// </summary>
		[Browsable(true),Description("日期控件中日的宽度"),Category("Appearance")]
		public int DayWidth
		{
			get
			{
				return daywidth;
			}
			set
			{
				daywidth = value;
			}
		}



		/// <summary>
		/// 月的宽度
		/// </summary>
		[Browsable(true),Description("日期控件中月的宽度"),Category("Appearance")]
		public int MonthWidth
		{
			get
			{
				return monthwidth;
			}
			set
			{
				monthwidth = value;
			}
		}

		/// <summary>
		/// 年的宽度
		/// </summary>
		[Browsable(true),Description("日期控件中年的宽度"),Category("Appearance")]
		public int YearWidth
		{
			get
			{
				return yearwidth;
			}
			set
			{
				yearwidth = value;
			}
		}

		/// <summary>
		/// 控件宽度
		/// </summary>
		[Browsable(true),Description("日期控件的宽度"),Category("Appearance")]
		public int Calendar_Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}


		/// <summary>
		/// 日期属性
		/// </summary>
		[Browsable(true),Description("日期控件的日期"),Category("Data")]
		public System.DateTime DateTime
		{
			get
			{
				System.DateTime DateTime = new System.DateTime(Year,Month,Day);
				return DateTime;
			}
			set
			{				
				System.DateTime DateTime = value;				
				Year = DateTime.Year;
				Month = DateTime.Month;
				Day = DateTime.Day;
			}
		}

		/// <summary>
		/// 图片路径
		/// </summary>
		[Browsable(true),Description("日期控件的图片路径"),Category("Data"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
		public string ImageUrl
		{
			get
			{
				return imageurl;
			}
			set
			{
				imageurl = value;
			}
		}       


		/// <summary>
		/// 重写System.Web.UI.Control.OnPreRender方法。
		/// </summary>
		/// <param name="e">包含事件数据的对象。</param>
		protected override void OnPreRender(EventArgs e)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder("<style>INPUT.txtClass { font-size: 8pt; border: solid 0 black; height: 16; background: transparent; }	DIV.TextBox{border-style:None;font-size: 8pt; width : "+ width +"; height : 16; }TD.broder{border-style:None; background: #ffffff; font-size: 8pt; width : "+ width +"; height : 16; }</style>");

			str.Append(@"<script language=javascript>//

//********************************************************************************************************//
//********************************************辅助函数****************************************************//
//********************************************************************************************************//

//=============================================================
//得到某年某月共有多少天
//=============================================================
 function HowManyDays(strMonth,strYear)
 {  
	var strDate1=strMonth+""-""+""01""+""-""+strYear
	strMonth=parseInt(strMonth,10)+1
	var strDate2=strMonth +""-""+""01""+""-""+strYear	
	var date1=new Date(strDate1)
	var date2=new Date(strDate2)
	var days=(date2 - date1)/24/60/60/1000
	return days;
}


//============================================================
//清除日历
//============================================================
function WriteNullToCalendar(control_id)
{
	var obj_tblTotalCalendar=document.all.item(control_id+"":tblTotalCalendar"");

	var i, j;
	var td;
	for(i=2; i<obj_tblTotalCalendar.rows.length; i++)
		for(j=0; j<7; j++)
		{
			td = obj_tblTotalCalendar.rows(i).cells(j);
			td.innerText = """";
			td.style.backgroundColor=""#ffffff"";
		}
		return true;
}

//=============================================================
//初始化日历
//strWeekday----本月第一天是星期几
//strTotalDays--本月共有几天
//strToday------今天是本月的几号
//=============================================================

function setDaysToCalendar(strWeekday,strTotalDays,strToday,control_id)
{
	//============
	//得到一个控件
	//============

	var obj_tblTotalCalendar=document.all.item(control_id+"":tblTotalCalendar"");
	
	var i,j,td,count
	count=1
	for(i=2;i<=8;i++)
	{ 
		if(i==2) 
			for(j=0;j<=6;j++)
			{
				td=obj_tblTotalCalendar.rows(i).cells(j);
				if (j<strWeekday)
				{
					td.Active = false;
				}
				else
				{
					td.innerText=count;
					if(count==strToday) 
					{
						td.style.backgroundColor = ""#8991c8"";
						td.Active = true;
					}
					else td.Active = false;
					count=count+1;
				}
			}
		else if(count<=strTotalDays) 
			for(j=0;j<=6;j++)
			{
				td=obj_tblTotalCalendar.rows(i).cells(j);
				td.innerText=count;
				if(count==strToday)
				{
					td.style.backgroundColor = ""#8991c8"";
					td.Active = true;
				}
				else td.Active = false;
				count=count+1;        
				if (count>strTotalDays) 
					return true;
			}
	}  
}

//===============================================================
//根据日期输入框中的内容创建日历
//===============================================================
function createDateBox(control_id)
{
	var strYear,strMonth,strDate,strDay;
	strYear = document.all.item(control_id+"":txtYear"").value;
	strMonth = document.all.item(control_id+"":txtMonth"").value;
	strDay = document.all.item(control_id+"":txtDay"").value;
	var dtCurrent=new Date(strYear,strMonth-1,strDay);
	strDate = dtCurrent.getDate();
	var iWeekDate,iHowManyDays,strTemp;
	iWeekDate=(new Date(strYear,strMonth-1,1)).getDay();
	iHowManyDays=HowManyDays(strMonth,strYear);
	WriteNullToCalendar(control_id);
	setDaysToCalendar(iWeekDate,iHowManyDays,strDate,control_id);

}

//===========================================================
//得到选择的日期
//===========================================================
function WhichDaySelected(control_id)
{
	var obj_tblTotalCalendar=document.all.item(control_id+"":tblTotalCalendar"");
	var i,j,td;
	var ls_date;
	for (i=3;i<=8;i++)
		for(j=0;j<=6;j++)
		{
			td = obj_tblTotalCalendar.rows(i).cells(j);
			if(td.Active == true)
			{
				ls_date=td.innerText;
				return ls_date;		   
			}
		}
}  


//==============================================================
//检测输入的是否是数字
//==============================================================
function CheckNum()
{
	if(event.keyCode < 48 || event.keyCode > 57)
	{
		alert(""请输入数字"");
		return false;
	}
	
	return true;
}


//********************************************************************************************************//
//********************************************事件函数****************************************************//
//********************************************************************************************************//


//===============================================================
//当按下弹出日历时
//===============================================================
function btn_onclick(control_id)
{
	//============
	//得到一个控件
	//============
	var obj_DateBox=document.all.item(control_id+"":DateBox"");

	if(obj_DateBox.style.visibility==""hidden"")
	{
		obj_DateBox.style.visibility=""visible"";
		
		createDateBox(control_id);		
		document.all.item(control_id+"":selYear"").value = document.all.item(control_id+"":txtYear"").value;
		document.all.item(control_id+"":selMonth"").selectedIndex = document.all.item(control_id+"":txtMonth"").value-1;	
	}
	else
	{
		obj_DateBox.style.visibility=""hidden"";
	}
	
}

//=============================================================
//当日期输入框失去输入焦点时
//=============================================================
function txt_OnBlue(control_id)
{
	var strYear,strMonth,strDay;
	strYear = document.all.item(control_id+"":txtYear"").value;
	strMonth = document.all.item(control_id+"":txtMonth"").value;
	strDay = document.all.item(control_id+"":txtDay"").value;
	var dtCurrent=new Date(strYear,strMonth-1,strDay);

	if(isNaN(strYear))
	{		
		alert(""您输入的年份不是数字 ：）！"");
		document.all.item(control_id+"":txtYear"").focus();
		return;		
	}	

	if(isNaN(strMonth))
	{
		alert(""您输入的月份不是数字 ：）！"");
		document.all.item(control_id+"":txtMonth"").focus();
		return;		
	}

	if(isNaN(strDay))
	{
		alert(""您输入的天数不是数字 ：）！"");
		document.all.item(control_id+"":txtDay"").focus();
		return;		
	}

	if(dtCurrent.getDate() !=strDay)
	{
		alert(""您输入的天数不正确！"");
		document.all.item(control_id+"":txtDay"").focus();
		return;		
	}
	

	if(dtCurrent.getMonth()!=(strMonth-1))
	{
		alert(""您输入的月份不正确！"");
		document.all.item(control_id+"":txtMonth"").focus();
		return;		
	}

	

	if(dtCurrent.getFullYear()!=strYear || strYear<1900)
	{		
		alert(""您输入的年份不正确！"");
		document.all.item(control_id+"":txtYear"").focus();
		return;		
	}	
	
	
	var obj_DateBox=document.all.item(control_id+"":DateBox"");

	if(obj_DateBox.style.visibility==""visible"")
	{
		createDateBox(control_id);		
		document.all.item(control_id+"":selYear"").value = document.all.item(control_id+"":txtYear"").value;
		document.all.item(control_id+"":selMonth"").selectedIndex = document.all.item(control_id+"":txtMonth"").value-1;	
	}
	
}


//=============================================================
//当选择下拉列表中的月份
//=============================================================
function selOnClick(control_id)
{
	document.all.item(control_id+"":txtMonth"").value = document.all.item(control_id+"":selMonth"").value;
	createDateBox(control_id);
}

//=================================================================
//当日历中的年输入框失去焦点
//=================================================================
function selBlur(control_id)
{
	document.all.item(control_id+"":txtYear"").value = document.all.item(control_id+"":selYear"").value;
	createDateBox(control_id);
}

//===============================================================
//当按下年份调节按钮（向上）
//===============================================================
function imgUpOnclick(control_id)
{
	document.all.item(control_id+"":selYear"").value=++document.all.item(control_id+"":txtYear"").value;
	createDateBox(control_id);	
}


//===============================================================
//当按下年份调节按钮（向下）
//===============================================================
function imgDownOnclick(control_id)
{
	document.all.item(control_id+"":selYear"").value=--document.all.item(control_id+"":txtYear"").value;
	createDateBox(control_id);
}

//===============================================================
//当点击日历中的日子
//===============================================================
function tdOnclick(control_id)
{
	var src = event.srcElement ;
	if (src.tagName != ""TD"")return false;

	if (src.innerText!="""" && src.innerText!="" "")
	{
		document.all.item(control_id+"":txtDay"").value=src.innerText;
		createDateBox(control_id);	
        document.all.item(control_id+"":DateBox"").style.visibility=""hidden"";
	}

}

//===============================================================
//当双击日历中的日子
//===============================================================
function tdOndblclick(control_id)
{
	var src = event.srcElement ;
	if (src.tagName != ""TD"")return false;

	if (src.innerText!="""" && src.innerText!="" "")
	{
		document.all.item(control_id+"":txtDay"").value=src.innerText;
		createDateBox(control_id);	
		document.all.item(control_id+"":DateBox"").style.visibility=""hidden"";
	}
}
</script>");
			if(!base.Page.IsStartupScriptRegistered("Canlendar"))
			{
				Page.RegisterStartupScript("Canlendar",str.ToString());
			}
			base.OnPreRender(e);
		}
	

		/// <summary>
		/// 将服务器控件内容发送到提供的 HtmlTextWriter 对象
		/// </summary>
		/// <param name="writer">HtmlTextWriter 对象</param>
		protected override void RenderContents( HtmlTextWriter writer)
		{
			
			string str = "";

			str = "<table cellSpacing='0' cellPadding='0' border='0'><tr><td class='broder'><div class='TextBox'>";


			writer.Write(str);

			
			if(!enabled)
			{
				str = "<input class=txtClass disabled='disabled' id='"+ControlID+":txtYear' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:"+this.BorderStyle.ToString()+";WIDTH: "+ yearwidth +"px' type=\"text\" maxLength=4 value="+Year+" name='"+ControlID+":txtYearName' ><input class='txtClass' style='border-style:"+this.BorderStyle.ToString()+";WIDTH: 6; CURSOR: default' tabIndex='-1' disabled='disabled' readOnly type='text' value='-' name='text1'><input class='txtClass' disabled='disabled' id='"+ControlID+":txtMonth' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:"+this.BorderStyle.ToString()+";WIDTH: "+ monthwidth +"px' type=\"text\" maxLength=2 value="+Month+" name='"+ControlID+":txtMonthName'><input class='txtClass' style='border-style:"+this.BorderStyle.ToString()+";WIDTH:6; CURSOR: default' tabIndex='-1' disabled='disabled' readOnly type='text' value='-' name='text2'><input class=txtClass disabled='disabled' id='"+ControlID+":txtDay' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:"+this.BorderStyle.ToString()+";WIDTH: "+daywidth+"px' type=\"text\" maxLength=2 value="+Day+" name='"+ControlID+":txtDayName'><input class='txtClass' style='border-style:"+this.BorderStyle.ToString()+";WIDTH: 0; CURSOR: default' tabIndex='-1' disabled='disabled' readOnly type='text' value='-' name='text3'></div></td><td><button id='"+ControlID+":btnChoose' class='Button' disabled='disabled' style='BORDER-RIGHT: black 0px solid; BORDER-TOP: black 0px solid; MARGIN: 0px; BORDER-LEFT: black 0px solid; WIDTH: 22px; BORDER-BOTTOM: black 0px solid; HEIGHT: 22px' onclick=\"btn_onclick('"+ControlID+"')\" tabIndex=-1 type=button ><IMG src=\""+imageurl+"calendar_001.gif\"></button></td></tr></table>";
			}
			else
			{
				str = "<input class=txtClass id='"+ControlID+":txtYear' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:"+this.BorderStyle.ToString()+";WIDTH: "+ yearwidth +"px' type=\"text\" maxLength=4 value="+Year+" name='"+ControlID+":txtYearName' ><input class='txtClass' style='border-style:"+this.BorderStyle.ToString()+";WIDTH: 6; CURSOR: default' tabIndex='-1' readOnly type='text' value='-' name='text1'><input class='txtClass' id='"+ControlID+":txtMonth' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:"+this.BorderStyle.ToString()+";WIDTH: "+ monthwidth +"px' type=\"text\" maxLength=2 value="+Month+" name='"+ControlID+":txtMonthName'><input class='txtClass' style='border-style:"+this.BorderStyle.ToString()+";WIDTH:6; CURSOR: default' tabIndex='-1' readOnly type='text' value='-' name='text2'><input class=txtClass id='"+ControlID+":txtDay' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:"+this.BorderStyle.ToString()+";WIDTH: "+daywidth+"px' type=\"text\" maxLength=2 value="+Day+" name='"+ControlID+":txtDayName'><input class='txtClass' style='border-style:"+this.BorderStyle.ToString()+";WIDTH: 0; CURSOR: default' tabIndex='-1' readOnly type='text' value='-' name='text3'></div></td><td><button id='"+ControlID+":btnChoose' style='BORDER-RIGHT: black 0px solid; BORDER-TOP: black 0px solid; MARGIN: 0px; BORDER-LEFT: black 0px solid; WIDTH: 22px; BORDER-BOTTOM: black 0px solid; HEIGHT: 22px' onclick=\"btn_onclick('"+ControlID+"')\" tabIndex=-1 type=button ><IMG class='ImageButton' src=\""+imageurl+"calendar_001.gif\"></button></td></tr></table>";
			}

			writer.Write(str);

			str ="<div id='"+ControlID+":DateBox' style='BORDER-RIGHT: #000000 0px; BORDER-TOP: #000000 0px; Z-INDEX: 99999; VISIBILITY: hidden; BORDER-LEFT: #000000 0px; WIDTH: 200px; CURSOR: hand; BORDER-BOTTOM: #000000 0px; POSITION: absolute; HEIGHT: 115px'><table id='"+ControlID+":tblTotalCalendar' style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; FONT-SIZE: 9pt; BACKGROUND: #ffffff; BORDER-LEFT: #5661a8 1px solid; BORDER-BOTTOM: #5661a8 1px solid' cellSpacing=2 cellPadding=0 border=1><tr borderColorLight='#ffffff' bgColor='#ffffff' borderColorDark='#ffffff' height='18'><td style='FONT-SIZE: 12pt' colSpan='3'><select id='"+ControlID+":selMonth' style='FONT-SIZE: 12px; WIDTH: 70px; HEIGHT: 20px' accessKey=M onchange=\"return selOnClick('"+ControlID+"');\"><option value='01' selected>一月</option><option value='02'>二月</option><option value='03'>三月</option><option value='04'>四月</option><option value='05'>五月</option><option value='06'>六月</option><option value='07'>七月</option><option value='08'>八月</option><option value='09'>九月</option><option value='10'>十月</option><option value='11'>十一月</option><option value='12'>十二月</option></select></td><td style='FONT-SIZE: 9pt' align='right' colSpan='3'><input onkeypress=CheckNum() id='"+ControlID+":selYear' onblur=\"selBlur('"+ControlID+"')\" style='WIDTH: 70px; HEIGHT: 20px' type=\"text\" align=right name=selYear></td><td bgColor='#ffffff'><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT: #5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgUp' onclick=\"return imgUpOnclick('"+ControlID+"');\" height=9 src='"+imageurl+"calendar_002.gif'></div><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT:#5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgDown' onclick=\"return imgDownOnclick('"+ControlID+"')\" height=9 src='"+imageurl+"calendar_003.gif' >";

			writer.Write(str);

			str = "</div></td></tr><tr style='BACKGROUND: #5661a8; COLOR: #ffffff' borderColorLight='#5661a8' borderColorDark='#5661a8'><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>日</td><td style='WIDTH: 25px' align='middle'>一</td><td style='WIDTH: 25px' align='middle'>二</td><td style='WIDTH: 25px' align='middle'>三</td><td style='WIDTH: 25px' align='middle'>四</td><td style='WIDTH: 25px' align='middle'>五</td><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>六</td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td>";


			writer.Write(str);


			str = "<td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr>";

			writer.Write(str);

			str = "<tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr></table></div>";

			writer.Write(str);
		}		
		


		/// <summary>
		/// 引发 Init 事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			this.ControlID = this.UniqueID;			
		}

		

		/// <summary>
		/// 引发 Load 事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			if(!Page.IsPostBack)
			{				
				if(Year==0 && Month==0 && Day==0)
				{
					System.DateTime DateTime = System.DateTime.Today;
					Year = DateTime.Year;
					Month = DateTime.Month;
					Day = DateTime.Day;
				}
			}				
			else
			{
				Year= System.Convert.ToInt16(Page.Request.Params[ControlID+":txtYearName"]);
				Month =System.Convert.ToInt16(Page.Request.Params[ControlID+":txtMonthName"]);
				Day =System.Convert.ToInt16(Page.Request.Params[ControlID+":txtDayName"]);			
			}
		}



		/// <summary>
		/// 将 HTML 元素的开始标记写入 HtmlTextWriter 输出流。
		/// </summary>
		/// <param name="writer">HtmlTextWriter 输出流</param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			writer.WriteLine();
			//加入自己的版权信息！	
			writer.Write("<!------------------------------ ");
			writer.Write("Calendar Start");
			writer.WriteLine(" ------------------------------->");
			writer.Write("<!-------- ");
			
			writer.Write(" -----------");
			writer.WriteLine(">");		
			base.RenderBeginTag(writer);
			
		}

		/// <summary>
		/// 将 HTML 元素的结束标记写入 HtmlTextWriter 输出流
		/// </summary>
		/// <param name="writer">HtmlTextWriter 输出流</param>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
			base.RenderEndTag(writer);
			writer.WriteLine();
			writer.Write("<!------------------------------- ");
			writer.Write("Calendar End");
			writer.Write(" ---------------------------------");
			writer.WriteLine(">");
			writer.WriteLine();
		}

	
	
		


	}
	#endregion
	#region CalendarDesigner

	/// <summary>
	/// 服务器控件设计器
	/// </summary>
	public class CalendarDesigner:System.Web.UI.Design.WebControls.PanelDesigner
	{
		/// <summary>
		/// 初始化CalendarDesigner新实例
		/// </summary>
		public CalendarDesigner()
		{
			//
			// TODO: Add constructor logic here
			//
			this.ReadOnly=true;
		}

		#region GetDesignTimeHtml

		/// <summary>
		/// 获取用于在设计时表示关联控件的 HTML
		/// </summary>
		/// <returns>用于在设计时表示控件的 HTML</returns>
		public override string GetDesignTimeHtml()
		{
			try
			{
				Calendar Calendar = (Calendar)Component;			
				StringWriter sw=new StringWriter();
				HtmlTextWriter tw=new HtmlTextWriter(sw);
				HtmlAnchor anchor;
				anchor=new HtmlAnchor();

				string ControlID = Calendar.UniqueID;
				int yearwidth = Calendar.YearWidth;
				int monthwidth = Calendar.MonthWidth;
				string imageurl = Calendar.ImageUrl;
				int Year = Calendar.Year;
				int Month = Calendar.Month;
				int Day = Calendar.Day;
				int daywidth = Calendar.DayWidth;
				string str = "";

				str = "<table cellSpacing='0' cellPadding='0' border='0'><tr><td class='broder'><div class='TextBox'>";
				anchor.InnerHtml= str;
				anchor.RenderControl(tw);
				str="<input class=txtClass id='"+ControlID+":txtYear' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:None;WIDTH: "+ yearwidth +"px' type=\"text\" maxLength=4 value="+Year+" name='"+ControlID+":txtYearName' >";
				anchor.InnerHtml= str;
				anchor.RenderControl(tw);

				str = "<input class='txtClass' style='border-style:None;WIDTH: 6; CURSOR: default' tabIndex='-1' readOnly type='text' value='-' name='text1'><input class='txtClass' id='"+ControlID+":txtMonth' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:None;WIDTH: "+ monthwidth +"px' type=\"text\" maxLength=2 value="+Month+" name='"+ControlID+":txtMonthName'><input class='txtClass' style='border-style:None;WIDTH:6; CURSOR: default' tabIndex='-1' readOnly type='text' value='-' name='text2'><input class=txtClass id='"+ControlID+":txtDay' onblur=\"txt_OnBlue('"+ControlID+"')\" style='border-style:None;WIDTH: "+daywidth+"px' type=\"text\" maxLength=2 value="+Day+" name='"+ControlID+":txtDayName'><input class='txtClass' style='border-style:None;WIDTH: 0; CURSOR: default' tabIndex='-1' readOnly type='text' value='-' name='text3'></div></td><td><button id='"+ControlID+":btnChoose' style='BORDER-RIGHT: black 0px solid; BORDER-TOP: black 0px solid; MARGIN: 0px; BORDER-LEFT: black 0px solid; WIDTH: 22px; BORDER-BOTTOM: black 0px solid; HEIGHT: 22px' onclick=\"btn_onclick('"+ControlID+"')\" tabIndex=-1 type=button ><IMG src=\""+imageurl+"calendar_001.gif\"></button></td></tr></table>";
				anchor.InnerHtml= str;
				anchor.RenderControl(tw);

				//				str = "<div id='"+ControlID+":DateBox' style='BORDER-RIGHT: #000000 0px; BORDER-TOP: #000000 0px; Z-INDEX: 99999; VISIBILITY: hidden; BORDER-LEFT: #000000 0px; WIDTH: 200px; CURSOR: hand; BORDER-BOTTOM: #000000 0px; POSITION: absolute; HEIGHT: 115px'><table id='"+ControlID+":tblTotalCalendar' style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; FONT-SIZE: 9pt; BACKGROUND: #ffffff; BORDER-LEFT: #5661a8 1px solid; BORDER-BOTTOM: #5661a8 1px solid' cellSpacing=2 cellPadding=0 border=1><tr borderColorLight='#ffffff' bgColor='#ffffff' borderColorDark='#ffffff' height='18'><td style='FONT-SIZE: 12pt' colSpan='3'><select id='"+ControlID+":selMonth' style='FONT-SIZE: 12px; WIDTH: 70px; HEIGHT: 20px' accessKey=M onchange=\"return selOnClick('"+ControlID+"');\"><option value='01' selected>一月</option><option value='02'>二月</option><option value='03'>三月</option><option value='04'>四月</option><option value='05'>五月</option><option value='06'>六月</option><option value='07'>七月</option><option value='08'>八月</option><option value='09'>九月</option><option value='10'>十月</option><option value='11'>十一月</option><option value='12'>十二月</option></select></td><td style='FONT-SIZE: 9pt' align='right' colSpan='3'><input onkeypress=CheckNum() id='"+ControlID+":selYear' onblur=\"selBlur('"+ControlID+"')\" style='WIDTH: 70px; HEIGHT: 20px' type=\"text\" align=right name=selYear></td><td bgColor='#ffffff'><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT: #5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgUp' onclick=\"return imgUpOnclick('"+ControlID+"');\" height=9 src='"+imageurl+"calendar_002.gif'></div><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT:#5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgDown' onclick=\"return imgDownOnclick('"+ControlID+"')\" height=9 src='"+imageurl+"calendar_003.gif' >";
				//				anchor.InnerHtml= str;
				//				anchor.RenderControl(tw);
				//
				//				str = "</div></td></tr><tr style='BACKGROUND: #5661a8; COLOR: #ffffff' borderColorLight='#5661a8' borderColorDark='#5661a8'><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>日</td><td style='WIDTH: 25px' align='middle'>一</td><td style='WIDTH: 25px' align='middle'>二</td><td style='WIDTH: 25px' align='middle'>三</td><td style='WIDTH: 25px' align='middle'>四</td><td style='WIDTH: 25px' align='middle'>五</td><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>六</td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td>";
				//				anchor.InnerHtml= str;
				//				anchor.RenderControl(tw);
				//
				//
				//				str = "<td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr>";
				//				anchor.InnerHtml= str;
				//				anchor.RenderControl(tw);
				//
				//				str = "<tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr></table></div>";
				//
				//				anchor.InnerHtml= str;
				//				anchor.RenderControl(tw);

				return sw.ToString();
			}
			catch(Exception e)
			{
				return GetErrorDesignTimeHtml(e);
			}
		}

		#endregion


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
   
}
