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
	[Description("һ��ASP.Net WebӦ�ó�������ڿؼ�")]
	[Designer(typeof(CalendarDesigner))]
	[ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>")]
	public class Calendar : Panel, INamingContainer
	{


		/// <summary>
		/// ���û��ؼ���id
		/// </summary>
		private string ControlID;

		/// <summary>
		/// �����ڿؼ������
		/// </summary>		
		public int Year;

		/// <summary>
		/// �����ڿؼ����·�
		/// </summary>
		public int Month;

		/// <summary>
		/// ͼƬ·��
		/// </summary>
		private string imageurl;

		/// <summary>
		/// �����ڿؼ�����
		/// </summary>
		public int Day;

		/// <summary>
		/// �ؼ��Ŀ��
		/// </summary>
		private int width=70;

		/// <summary>
		/// �ؼ���������Ŀ��
		/// </summary>
		private int yearwidth=25;

		/// <summary>
		/// �ؼ��������µĿ��
		/// </summary>
		private int monthwidth=13;

		/// <summary>
		/// �ؼ��������յĿ��
		/// </summary>
		private int daywidth=13;

		/// <summary>
		/// �Ƿ񼤻�
		/// </summary>
		private bool enabled = true;


		/// <summary>
		/// ��ȡ������һ��ֵ����ֵָʾ�Ƿ����� ���ڿؼ�
		/// </summary>
		[Browsable(true),Description("���ڿؼ���״̬"),Category("Appearance")]
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
		/// �յĿ��
		/// </summary>
		[Browsable(true),Description("���ڿؼ����յĿ��"),Category("Appearance")]
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
		/// �µĿ��
		/// </summary>
		[Browsable(true),Description("���ڿؼ����µĿ��"),Category("Appearance")]
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
		/// ��Ŀ��
		/// </summary>
		[Browsable(true),Description("���ڿؼ�����Ŀ��"),Category("Appearance")]
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
		/// �ؼ����
		/// </summary>
		[Browsable(true),Description("���ڿؼ��Ŀ��"),Category("Appearance")]
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
		/// ��������
		/// </summary>
		[Browsable(true),Description("���ڿؼ�������"),Category("Data")]
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
		/// ͼƬ·��
		/// </summary>
		[Browsable(true),Description("���ڿؼ���ͼƬ·��"),Category("Data"),Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
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
		/// ��дSystem.Web.UI.Control.OnPreRender������
		/// </summary>
		/// <param name="e">�����¼����ݵĶ���</param>
		protected override void OnPreRender(EventArgs e)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder("<style>INPUT.txtClass { font-size: 8pt; border: solid 0 black; height: 16; background: transparent; }	DIV.TextBox{border-style:None;font-size: 8pt; width : "+ width +"; height : 16; }TD.broder{border-style:None; background: #ffffff; font-size: 8pt; width : "+ width +"; height : 16; }</style>");

			str.Append(@"<script language=javascript>//

//********************************************************************************************************//
//********************************************��������****************************************************//
//********************************************************************************************************//

//=============================================================
//�õ�ĳ��ĳ�¹��ж�����
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
//�������
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
//��ʼ������
//strWeekday----���µ�һ�������ڼ�
//strTotalDays--���¹��м���
//strToday------�����Ǳ��µļ���
//=============================================================

function setDaysToCalendar(strWeekday,strTotalDays,strToday,control_id)
{
	//============
	//�õ�һ���ؼ�
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
//��������������е����ݴ�������
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
//�õ�ѡ�������
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
//���������Ƿ�������
//==============================================================
function CheckNum()
{
	if(event.keyCode < 48 || event.keyCode > 57)
	{
		alert(""����������"");
		return false;
	}
	
	return true;
}


//********************************************************************************************************//
//********************************************�¼�����****************************************************//
//********************************************************************************************************//


//===============================================================
//�����µ�������ʱ
//===============================================================
function btn_onclick(control_id)
{
	//============
	//�õ�һ���ؼ�
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
//�����������ʧȥ���뽹��ʱ
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
		alert(""���������ݲ������� ������"");
		document.all.item(control_id+"":txtYear"").focus();
		return;		
	}	

	if(isNaN(strMonth))
	{
		alert(""��������·ݲ������� ������"");
		document.all.item(control_id+"":txtMonth"").focus();
		return;		
	}

	if(isNaN(strDay))
	{
		alert(""������������������� ������"");
		document.all.item(control_id+"":txtDay"").focus();
		return;		
	}

	if(dtCurrent.getDate() !=strDay)
	{
		alert(""���������������ȷ��"");
		document.all.item(control_id+"":txtDay"").focus();
		return;		
	}
	

	if(dtCurrent.getMonth()!=(strMonth-1))
	{
		alert(""��������·ݲ���ȷ��"");
		document.all.item(control_id+"":txtMonth"").focus();
		return;		
	}

	

	if(dtCurrent.getFullYear()!=strYear || strYear<1900)
	{		
		alert(""���������ݲ���ȷ��"");
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
//��ѡ�������б��е��·�
//=============================================================
function selOnClick(control_id)
{
	document.all.item(control_id+"":txtMonth"").value = document.all.item(control_id+"":selMonth"").value;
	createDateBox(control_id);
}

//=================================================================
//�������е��������ʧȥ����
//=================================================================
function selBlur(control_id)
{
	document.all.item(control_id+"":txtYear"").value = document.all.item(control_id+"":selYear"").value;
	createDateBox(control_id);
}

//===============================================================
//��������ݵ��ڰ�ť�����ϣ�
//===============================================================
function imgUpOnclick(control_id)
{
	document.all.item(control_id+"":selYear"").value=++document.all.item(control_id+"":txtYear"").value;
	createDateBox(control_id);	
}


//===============================================================
//��������ݵ��ڰ�ť�����£�
//===============================================================
function imgDownOnclick(control_id)
{
	document.all.item(control_id+"":selYear"").value=--document.all.item(control_id+"":txtYear"").value;
	createDateBox(control_id);
}

//===============================================================
//����������е�����
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
//��˫�������е�����
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
		/// ���������ؼ����ݷ��͵��ṩ�� HtmlTextWriter ����
		/// </summary>
		/// <param name="writer">HtmlTextWriter ����</param>
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

			str ="<div id='"+ControlID+":DateBox' style='BORDER-RIGHT: #000000 0px; BORDER-TOP: #000000 0px; Z-INDEX: 99999; VISIBILITY: hidden; BORDER-LEFT: #000000 0px; WIDTH: 200px; CURSOR: hand; BORDER-BOTTOM: #000000 0px; POSITION: absolute; HEIGHT: 115px'><table id='"+ControlID+":tblTotalCalendar' style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; FONT-SIZE: 9pt; BACKGROUND: #ffffff; BORDER-LEFT: #5661a8 1px solid; BORDER-BOTTOM: #5661a8 1px solid' cellSpacing=2 cellPadding=0 border=1><tr borderColorLight='#ffffff' bgColor='#ffffff' borderColorDark='#ffffff' height='18'><td style='FONT-SIZE: 12pt' colSpan='3'><select id='"+ControlID+":selMonth' style='FONT-SIZE: 12px; WIDTH: 70px; HEIGHT: 20px' accessKey=M onchange=\"return selOnClick('"+ControlID+"');\"><option value='01' selected>һ��</option><option value='02'>����</option><option value='03'>����</option><option value='04'>����</option><option value='05'>����</option><option value='06'>����</option><option value='07'>����</option><option value='08'>����</option><option value='09'>����</option><option value='10'>ʮ��</option><option value='11'>ʮһ��</option><option value='12'>ʮ����</option></select></td><td style='FONT-SIZE: 9pt' align='right' colSpan='3'><input onkeypress=CheckNum() id='"+ControlID+":selYear' onblur=\"selBlur('"+ControlID+"')\" style='WIDTH: 70px; HEIGHT: 20px' type=\"text\" align=right name=selYear></td><td bgColor='#ffffff'><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT: #5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgUp' onclick=\"return imgUpOnclick('"+ControlID+"');\" height=9 src='"+imageurl+"calendar_002.gif'></div><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT:#5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgDown' onclick=\"return imgDownOnclick('"+ControlID+"')\" height=9 src='"+imageurl+"calendar_003.gif' >";

			writer.Write(str);

			str = "</div></td></tr><tr style='BACKGROUND: #5661a8; COLOR: #ffffff' borderColorLight='#5661a8' borderColorDark='#5661a8'><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>һ</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>��</td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td>";


			writer.Write(str);


			str = "<td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr>";

			writer.Write(str);

			str = "<tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr></table></div>";

			writer.Write(str);
		}		
		


		/// <summary>
		/// ���� Init �¼�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			this.ControlID = this.UniqueID;			
		}

		

		/// <summary>
		/// ���� Load �¼�
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
		/// �� HTML Ԫ�صĿ�ʼ���д�� HtmlTextWriter �������
		/// </summary>
		/// <param name="writer">HtmlTextWriter �����</param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			writer.WriteLine();
			//�����Լ��İ�Ȩ��Ϣ��	
			writer.Write("<!------------------------------ ");
			writer.Write("Calendar Start");
			writer.WriteLine(" ------------------------------->");
			writer.Write("<!-------- ");
			
			writer.Write(" -----------");
			writer.WriteLine(">");		
			base.RenderBeginTag(writer);
			
		}

		/// <summary>
		/// �� HTML Ԫ�صĽ������д�� HtmlTextWriter �����
		/// </summary>
		/// <param name="writer">HtmlTextWriter �����</param>
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
	/// �������ؼ������
	/// </summary>
	public class CalendarDesigner:System.Web.UI.Design.WebControls.PanelDesigner
	{
		/// <summary>
		/// ��ʼ��CalendarDesigner��ʵ��
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
		/// ��ȡ���������ʱ��ʾ�����ؼ��� HTML
		/// </summary>
		/// <returns>���������ʱ��ʾ�ؼ��� HTML</returns>
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

				//				str = "<div id='"+ControlID+":DateBox' style='BORDER-RIGHT: #000000 0px; BORDER-TOP: #000000 0px; Z-INDEX: 99999; VISIBILITY: hidden; BORDER-LEFT: #000000 0px; WIDTH: 200px; CURSOR: hand; BORDER-BOTTOM: #000000 0px; POSITION: absolute; HEIGHT: 115px'><table id='"+ControlID+":tblTotalCalendar' style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; FONT-SIZE: 9pt; BACKGROUND: #ffffff; BORDER-LEFT: #5661a8 1px solid; BORDER-BOTTOM: #5661a8 1px solid' cellSpacing=2 cellPadding=0 border=1><tr borderColorLight='#ffffff' bgColor='#ffffff' borderColorDark='#ffffff' height='18'><td style='FONT-SIZE: 12pt' colSpan='3'><select id='"+ControlID+":selMonth' style='FONT-SIZE: 12px; WIDTH: 70px; HEIGHT: 20px' accessKey=M onchange=\"return selOnClick('"+ControlID+"');\"><option value='01' selected>һ��</option><option value='02'>����</option><option value='03'>����</option><option value='04'>����</option><option value='05'>����</option><option value='06'>����</option><option value='07'>����</option><option value='08'>����</option><option value='09'>����</option><option value='10'>ʮ��</option><option value='11'>ʮһ��</option><option value='12'>ʮ����</option></select></td><td style='FONT-SIZE: 9pt' align='right' colSpan='3'><input onkeypress=CheckNum() id='"+ControlID+":selYear' onblur=\"selBlur('"+ControlID+"')\" style='WIDTH: 70px; HEIGHT: 20px' type=\"text\" align=right name=selYear></td><td bgColor='#ffffff'><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT: #5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgUp' onclick=\"return imgUpOnclick('"+ControlID+"');\" height=9 src='"+imageurl+"calendar_002.gif'></div><div style='BORDER-RIGHT: #5661a8 1px solid; BORDER-TOP: #5661a8 1px solid; BORDER-LEFT:#5661a8 1px solid; WIDTH: 100%; BORDER-BOTTOM: #5661a8 1px solid; HEIGHT: 10px' align='left'><IMG id='"+ControlID+":imgDown' onclick=\"return imgDownOnclick('"+ControlID+"')\" height=9 src='"+imageurl+"calendar_003.gif' >";
				//				anchor.InnerHtml= str;
				//				anchor.RenderControl(tw);
				//
				//				str = "</div></td></tr><tr style='BACKGROUND: #5661a8; COLOR: #ffffff' borderColorLight='#5661a8' borderColorDark='#5661a8'><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>һ</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px' align='middle'>��</td><td style='WIDTH: 25px; COLOR: #fada40' align='middle'>��</td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td></tr><tr ondblclick=\"return tdOndblclick('"+ControlID+"');\" onclick=\"return tdOnclick('"+ControlID+"');\" borderColorDark=#ffffff><td style='COLOR: #ff0000' borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td><td borderColorLight='#5661a8' align='middle'></td>";
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
		/// ��ȡ�ڳ��ֿؼ�ʱ��������������ʱΪָ�����쳣��ʾ�� HTML
		/// </summary>
		/// <param name="e">ҪΪ����ʾ������Ϣ���쳣</param>
		/// <returns>���ʱΪָ�����쳣��ʾ�� HTML</returns>
		protected override string GetErrorDesignTimeHtml(Exception e)
		{
			string errorstr="�����ؼ�ʱ����"+e.Message;
			return CreatePlaceHolderDesignTimeHtml(errorstr);
		}

		#endregion


	}

	#endregion
   
}
