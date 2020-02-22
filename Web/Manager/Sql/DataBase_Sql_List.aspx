<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Sql_List.aspx.cs" Inherits="Web.Manager.Sql.DataBase_Sql_List" %>

<%@ Register Src="../Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=this.CurrentWebTitle%></title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />    
    <link href=<%=Business.Config.ResourcePath %>css/style.css?Version=<%=Business.Config.Version %> rel="stylesheet" type="text/css" />  
    <script language="javascript" src="<%=Business.Config.ResourcePath %>js/DateSelect.js?Version=<%=Business.Config.Version %>"></script>    
    <script language="javascript">
        function confirm_me(pageurl) {
            if (window.confirm("ȷ����?\r\n" + pageurl) == true) {
                return true;
            }
            return false;
        }
        function showhide(id) {
            var ishidden = 0;
            $("#" + id).each(function () {
                if ($(this).is(":hidden")) {
                    ishidden = 1;
                }
            });
            if (ishidden == 0) {
                $("#" + id).hide();
                $("#s_" + id).text("���飫");
            }
            else {
                $("#" + id).show();
                $("#s_" + id).text("���飭");
            }
        }
        function showhide_td() {
            if ($("#showhide_td").text() == "ִ��SQL������") {

                $(".cell").css("overflow", "visible");
                $(".cell").css("height", "auto");
                $(".cell").css("white-space", "pre-wrap");
                $("#showhide_td").text("ִ��SQL������");
            }
            else {
                $(".cell").css("overflow", "hidden");
                $(".cell").css("height", "20px");
                $(".cell").css("white-space", "normal");
                $("#showhide_td").text("ִ��SQL������");
            }
        }
     </script>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
   <div class="Body_Content">
       <uc1:Menu ID="Menu1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">			
                ���鵽<font color=red><%=this.LogCount.ToString() %></font>����¼,<asp:Repeater ID="rpt_database_sql_stats_sum" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 ©��������ͳ��:<span class="red">ȱ��<%# Eval("Lack_With_NoLock_Count")%>��WITH(NOLOCK)</span> , <span class="red">��<%# Eval("Select_All_Count")%>��SELECT*</span>  ,  <span class="red">��<%# Eval("Like_Count")%>��LIKEģ����ѯ</span>  , <span class="black">��<%# Eval("Lack_Parameter_Count")%>����ֵδ������</span>  ,  <span class="red">��<%# Eval("Count_All")%>��Count(*)</span> , <span class="red">������<%# Eval("BadRate")%> %</span> , <span class="red">ƽ����ʱ<%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%>��</span>
			                </ItemTemplate>
		                </asp:Repeater> ��<br/>���ң�
               <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                ִ��ʱ��
                <asp:TextBox ID="txtLast_Execution_Time_Begin" runat="server" Width="59px">00:00:00</asp:TextBox>��
                <asp:TextBox ID="txtLast_Execution_Time_End" runat="server" Width="58px">23:59:59</asp:TextBox>
                <asp:CheckBox ID="cb_Sql_Error" runat="server" Checked="False" Text="ֻ��ʾ�������" />
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;
                 <p>&nbsp;</p> <a <%= this.P_Bug_Type=="0"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=0">ȱ��WITH(NOLOCK)</a>
                      <a <%= this.P_Bug_Type=="1"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=1&My=<%=this.P_My %>">SELECT*</a>
                      <a <%= this.P_Bug_Type=="2"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=2&My=<%=this.P_My %>">LIKE</a>
                      <a <%= this.P_Bug_Type=="3"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=3&My=<%=this.P_My %>">��ֵδ������</a>
                      <a <%= this.P_Bug_Type=="4"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=4&My=<%=this.P_My %>">COUNT(*)</a>
                      <a <%= this.P_Bug_Type=="5"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=5&My=<%=this.P_My %>">��дȨ��δ�ֿ�</a>
                      <a <%= this.P_Bug_Type==""?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=&My=<%=this.P_My %>">ȫ��</a>

                
                <p>&nbsp;</p> 
                <a <%=this.P_My.ToString()=="0"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=0">��ȫ��</a>
                <a <%=this.P_My.ToString()=="1"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=1">ֻ���ҵ�</a>
                <a <%=this.P_My.ToString()=="2"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=2">ֻ�������ҵ�</a>
                <a <%=this.P_My.ToString()=="3"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=3">ֻ���������</a>
                <%--<a <%=this.P_My.ToString()=="4"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&My=4">ֻ���Һ��Ե�</a>
                <a <%=this.P_My.ToString()=="5"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&My=5">ֻ�������Ե�</a>--%>
                  
                 <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=<%=this.P_My %>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> 
                <a <%= this.P_Today==""?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=<%=this.P_My %>">ȫ��</a>

                 <img id="plus" src="<%=Business.Config.HostUrl %>/images/plus.gif" style="vertical-align:bottom;cursor:pointer" height="30" />  
                 <div id="div_plus" style="display:none;">
                 <p>&nbsp;</p>   
                <a class=button>���ݿ�IP</a>
                 <asp:Repeater ID="rpt_DataBase_Ip" runat="server" EnableViewState="false">
			                <ItemTemplate>
                                 <%# (Container.ItemIndex+1)%10==0?"<p>&nbsp;</p>":"" %>
				                 <a <%# this.P_keyword==Eval("DATABASE_IP").ToString()?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%#Server.UrlEncode(Eval("DATABASE_IP").ToString()) %>&today=<%=Server.UrlEncode(this.P_Today)%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=<%=this.P_My %>"><%# Eval("DATABASE_IP")%></a>
			                </ItemTemplate>
		         </asp:Repeater>                
                 <p>&nbsp;</p>   
                <a class=button>���ݿ��û�</a>
                 <asp:Repeater ID="rpt_DataBase_User" runat="server" EnableViewState="false">
			                <ItemTemplate>
                                 <%# (Container.ItemIndex+1)%10==0?"<p>&nbsp;</p>":"" %>
				                 <a <%# this.P_keyword==Eval("DATABASE_USER").ToString()?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%#Server.UrlEncode(Eval("DATABASE_USER").ToString()) %>&today=<%=Server.UrlEncode(this.P_Today)%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=<%=this.P_My %>"><%# Eval("DATABASE_USER")%></a>
			                </ItemTemplate>
		                </asp:Repeater>                   
                     
                 <p>&nbsp;</p> 
                <a class=button>���ݿ�����</a>
                 <asp:Repeater ID="rpt_DataBase_Name" runat="server" EnableViewState="false">
			                <ItemTemplate>
                                 <%# (Container.ItemIndex+1)%10==0?"<p>&nbsp;</p>":"" %>
				                 <a <%# this.P_keyword==Eval("DATABASE_NAME").ToString()?"class=button":"class=button_off"%> href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%# Server.UrlEncode(Eval("DATABASE_NAME").ToString()) %>&today=<%=Server.UrlEncode(this.P_Today)%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>&My=<%=this.P_My %>"><%# Eval("DATABASE_NAME")%></a>
			                </ItemTemplate>
		                </asp:Repeater>  
                     </div>            
                 <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr> 
			            <th><a href="DataBase_Sql_List.aspx?orderby=last_execution_time+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ִ��ʱ��</th>
			            <th><a href="DataBase_Sql_List.aspx?orderby=DATABASE_IP+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ݿ�IP</th>
                        <th><a href="DataBase_Sql_List.aspx?orderby=DATABASE_USER+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ݿ��û�</th>
                        <th><a href="DataBase_Sql_List.aspx?orderby=DATABASE_NAME+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>���ݿ�����</th>
			            <th> 
                            <a href="javascript:void(0)" onclick="javascript:showhide_td();" id="showhide_td">ִ��SQL������</a>  
			            </th> 
                        <th><a href="DataBase_Sql_List.aspx?orderby=SQL_ERROR+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>©��������</th>
                        <th>���Ƹ�����</th>
                        <th>������</th>
                        <th>����</th>
			            <th>����</th> 
			            <th><a href="DataBase_Sql_List.aspx?orderby=execution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>ִ��<br />(��)</th>
			            <th><a href="DataBase_Sql_List.aspx?orderby=total_worker_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>ռcpu<br />(����)</th>
			            <th><a href="DataBase_Sql_List.aspx?orderby=total_elapsed_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>ִ��<br />(����)</th>
			            <th><a href="DataBase_Sql_List.aspx?orderby=total_physical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>�����<br />(��)</th>
			            <th><a href="DataBase_Sql_List.aspx?orderby=total_logical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>�߼���<br />(��)</th> 
			            <th><a href="DataBase_Sql_List.aspx?orderby=total_logical_writes%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>�߼�д<br />(��)</th> 
			            <th><a href="DataBase_Sql_List.aspx?orderby=total_rows%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby">��</a>Ӱ��<br />(��)</th> 
                        <%# Eval("Date")%>
                        <th>���飫</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td width="120"<%# this.P_orderby.ToLower()=="last_��xecution_time desc"?" class=orderby":""%>><%# Eval("LAST_EXECUTION_TIME")%></td>
			                        <td<%# this.P_orderby.ToLower()=="database_ip desc"?" class=orderby":""%>><a href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby) %>&keyword=<%# Server.UrlEncode(Eval("DATABASE_IP").ToString())%>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby"><%# Eval("DATABASE_IP")%></a></td>
			                        <td<%# (Eval("ISWRONGDATABASEUSER").ToString()=="1"&&Eval("ISRUNTIMESQL").ToString()=="1")?" class=wronguser":""%>><a href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby) %>&keyword=<%# Server.UrlEncode(Eval("DATABASE_USER").ToString())%>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby"><%# Eval("DATABASE_USER")%></a></td>
			                        <td<%# this.P_orderby.ToLower()=="database_name desc"?" class=orderby":""%>><a href="DataBase_Sql_List.aspx?orderby=<%=Server.UrlEncode(this.P_orderby) %>&keyword=<%# Server.UrlEncode(Eval("DATABASE_NAME").ToString())%>&today=<%=this.P_Today%>&Last_Execution_Time_Begin=<%=Server.UrlEncode(this.txtLast_Execution_Time_Begin.Text) %>&Last_Execution_Time_End=<%=Server.UrlEncode(this.txtLast_Execution_Time_End.Text) %>&Sql_Error=<%=this.cb_Sql_Error.Checked==true?"1":"0" %>&Bug_Type=<%=this.P_Bug_Type %>" class="orderby"><%# Eval("DATABASE_NAME")%></a></td>
			                        <td><div class="cell" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><%# Eval("TEXT_ANALYSIS")%></div></td>
			                        <td width="150" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"<%# this.P_orderby.ToLower()=="sql_error desc"?" class=orderby":""%>><div class="cell"><span class=red><%# Eval("SQL_ERROR")%></span></div></td>
			                        <td><%# Eval("SEEMLIKE_WEBMANAGER_REALNAME").ToString()%></td> 
                                    <td><%# Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMySql").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Delete.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_Sql_List.aspx?page="+this.P_page+"&today="+Server.UrlEncode(this.P_Today)+"&keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('ȷ��ɾ����')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Add.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_Sql_List.aspx?page="+this.P_page+"&today="+Server.UrlEncode(this.P_Today)+"&keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('ȷ��������')\">����</a>"%></td> 
                                    <td<%# this.P_orderby.ToLower()=="len(text) desc"?" class=orderby":""%>><%# Eval("TEXT").ToString().Length%></td>
			                        <td<%# this.P_orderby.ToLower()=="��xecution_count desc"?" class=orderby":""%>><%# Eval("execution_count")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_worker_time/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_worker_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_elapsed_time/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_elapsed_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_physical_reads/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_physical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_reads/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_logical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_writes/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_logical_writes").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
                                    <td<%# this.P_orderby.ToLower()=="total_rows/��xecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_rows").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
			                        <%--<td><%# Eval("SQL_ERROR")%></td>--%>
                                    <td><a href="javascript:void(0);" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');" id="s_v_<%# Eval("sql_md5")%>">����<%# Container.ItemIndex==0?"��":"��"%></a></td>					           
				            </tr>
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("sql_md5")%>" style="display:none;background-color:lightblue;">
                                 <td colspan="18" style="border:1px solid #cccccc">
                                     <p><%# Eval("TEXT_ANALYSIS").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;")%></p> 
                                      <br />---------------------------------------------------------------------
                                     <br />(<b><%# (Convert.ToDecimal(Eval("total_rows").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString()%>����Ӱ��</b>)
                                     <br />�߼���ȡ <%# (Convert.ToDecimal(Eval("total_logical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%> �Σ������ȡ <%# (Convert.ToDecimal(Eval("total_physical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%> �Ρ�

                                     <br />SQL Server ִ��ʱ��:
                                     <br />  CPU ʱ�� = <%# (Convert.ToDecimal(Eval("total_worker_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%> ���롣

                                     <br />SQL Server ִ��ʱ��:
                                      <br /> CPU ʱ�� = <%# (Convert.ToDecimal(Eval("total_elapsed_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%> ���롣
                                      <br />----------------------------------------------------------------------
                                     <br />(<b>©��������</b>)
                                     <br /><span class=red><%# Eval("SQL_ERROR")%></span>
                                     <br />----------------------------------<br />(<b>�޸Ľ���</b>)<br>1��������Ҫ��LIKEģ����ѯ��<br>2����Ҫʹ��COUNT(*)�����Ըĳ�COUNT(1)����Ȼ�ֶι���Ļ���ѯЧ���½���<br>3����ѯ����ȱ��WITH(NOLOCK)��<br>4����ֵ��ʹ�ò���������Ȼ���ױ�������<br>5����Ҫʹ��SELECT*����д����ȷ���ֶΣ���Ȼ�ֶι���Ļ���ѯЧ���½���
                                     <br />
                                     <%# Eval("PageUrl").ToString()=="" ?"":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_PageUrl.aspx?keyword="+Server.UrlEncode(Eval("PageUrl").ToString())+"\" target=_blank>"+Eval("PageUrl").ToString()+"</a> "+( Eval("IsMyUrl").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ������</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">�����URL</a>")%>
                                                            
                                 </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--����-->
	  		</div> 
	  		<div class="Body_Pages">
                  <%=this.outPage %>
	  		</div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
    <script language="javascript">
        //showhide_td();
    </script>
</body>
</html>