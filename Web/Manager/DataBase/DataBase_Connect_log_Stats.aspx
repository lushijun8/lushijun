<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Connect_log_Stats.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Connect_log_Stats" %>


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
              if (window.confirm("确定吗?\r\n" + pageurl) == true) {
                  return true;
              }
              return false;
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
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>
                pageurl：<asp:TextBox ID="txtKeyword" runat="server" Width="469px"></asp:TextBox>
                日期：<asp:TextBox ID="txtToday" runat="server" Width="85px"  onfocus="javascript:ShowCalendar(this.id)"></asp:TextBox>
                 
                团队：<asp:DropDownList ID="ddl_TeamName" runat="server">
                </asp:DropDownList>
                 
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="DataBase_Connect_log_Stats.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> 
                <!--stats开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" style="white-space:nowrap">
		            <tr>
			            <th>序号</th> 
			            <th>请求页面</th> 
                        <th><a href="DataBase_Connect_log_Stats.aspx?orderby=WebManager_Name&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a>负责人</th>  
                        <th>操作</th> 
			            <th><a href="DataBase_Connect_log_Stats.aspx?orderby=request_count_today&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a>访次(当天)</th>
			            <th><a href="DataBase_Connect_log_Stats.aspx?orderby=request_count_yestoday&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a>访次(前一天)</th>
			            <th><a href="DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a>连接数据库次数(当天)<a href="DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a></th>
			            <th><a href="DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a>连接数据库次数(前一天)<a href="DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a></th>
			            <th><a href="DataBase_Connect_log_Stats.aspx?orderby=duration_today_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a>今日执行时间(秒)<a href="DataBase_Connect_log_Stats.aspx?orderby=duration_today_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a></th>
			            <th><a href="DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a>昨日执行时间(秒)<a href="DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>" class="orderby">↓</a></th>
			            <th>数据库连接使用情况(当天)</th>
                        <th>数据库连接使用情况(前一天)</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex%></td> 
					            <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_Log.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%></a> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                    <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                    <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
					            </td> 
                                <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today="+Server.UrlEncode(this.txtToday.Text)+"&keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_OrderBy))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today="+Server.UrlEncode(this.txtToday.Text)+"&keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_OrderBy))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%></td> 
					            <td><%# Eval("request_count_today")%></td>
					            <td><%# Eval("request_count_yestoday")%></td>
                                <td><%# Eval("connectionstring_today_min").ToString()%>~<%# Eval("connectionstring_today_max").ToString() %></a> 次</td>
                                <td><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次</td>
                                <td><%# Eval("duration_today")%></td>
					            <td><%# Eval("duration_yestoday")%></td>
                                 <td>
                                    <%# Eval("connectionstring_channelsales_read_today").ToString()=="0~0 平均0"?"":"connectionstring_channelsales_read_today: <font color=red>"+Eval("connectionstring_channelsales_read_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_channelsales_readstatic_today").ToString()=="0~0 平均0"?"":"connectionstring_channelsales_readstatic_today: <font color=red> "+Eval("connectionstring_channelsales_readstatic_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_channelsales_writer_today").ToString()=="0~0 平均0"?"":"connectionstring_channelsales_writer_today: <font color=red> "+Eval("connectionstring_channelsales_writer_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_tuan_read_today").ToString()=="0~0 平均0"?"":"connectionstring_tuan_read_today: <font color=red> "+Eval("connectionstring_tuan_read_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_tuan_writer_today").ToString()=="0~0 平均0"?"":"connectionstring_tuan_writer_today: <font color=red> "+Eval("connectionstring_tuan_writer_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_recordread_today").ToString()=="0~0 平均0"?"":"connectionstring_recordread_today: <font color=red> "+Eval("connectionstring_recordread_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_recordwrite_today").ToString()=="0~0 平均0"?"":"connectionstring_recordwrite_today: <font color=red> "+Eval("connectionstring_recordwrite_today").ToString()+"</font><br>"%>                                     
                                    <%# Eval("connectionstring_north_realty_read_today").ToString()=="0~0 平均0"?"":"connectionstring_north_realty_read_today: <font color=red> "+Eval("connectionstring_north_realty_read_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_north_realty_write_today").ToString()=="0~0 平均0"?"":"connectionstring_north_realty_write_today: <font color=red> "+Eval("connectionstring_north_realty_write_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_north_realty_admin_today").ToString()=="0~0 平均0"?"":"connectionstring_north_realty_admin_today: <font color=red> "+Eval("connectionstring_north_realty_admin_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_south_realty_read_today").ToString()=="0~0 平均0"?"":"connectionstring_south_realty_read_today: <font color=red> "+Eval("connectionstring_south_realty_read_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_south_realty_write_today").ToString()=="0~0 平均0"?"":"connectionstring_south_realty_write_today: <font color=red> "+Eval("connectionstring_south_realty_write_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_south_realty_admin_today").ToString()=="0~0 平均0"?"":"connectionstring_south_realty_admin_today: <font color=red> "+Eval("connectionstring_south_realty_admin_today").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_glht_monitor_read_today").ToString()=="0~0 平均0"?"":"connectionstring_glht_monitor_read_today: <font color=red> "+Eval("connectionstring_glht_monitor_read_today").ToString()+"</font><br>"%>
                                     <%# Eval("channelsales_conn_read_today").ToString()=="0~0 平均0"?"":"channelsales_conn_read_today: <font color=red> "+Eval("channelsales_conn_read_today").ToString()+"</font><br>"%>
                                     <%# Eval("tuanMall_conn_read_today").ToString()=="0~0 平均0"?"":"tuanMall_conn_read_today: <font color=red> "+Eval("tuanMall_conn_read_today").ToString()+"</font><br>"%>
                                     <%# Eval("tuan_conn_read_today").ToString()=="0~0 平均0"?"":"tuan_conn_read_today: <font color=red> "+Eval("tuan_conn_read_today").ToString()+"</font><br>"%>

                                 </td>
                                   <td>
                                    <%# Eval("connectionstring_channelsales_read_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_channelsales_read_yestoday: <font color=red> "+Eval("connectionstring_channelsales_read_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_channelsales_readstatic_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_channelsales_readstatic_yestoday: <font color=red> "+Eval("connectionstring_channelsales_readstatic_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_channelsales_writer_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_channelsales_writer_yestoday: <font color=red> "+Eval("connectionstring_channelsales_writer_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_tuan_read_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_tuan_read_yestoday: <font color=red> "+Eval("connectionstring_tuan_read_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_tuan_writer_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_tuan_writer_yestoday: <font color=red> "+Eval("connectionstring_tuan_writer_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_recordread_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_recordread_yestoday: <font color=red> "+Eval("connectionstring_recordread_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_recordwrite_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_recordwrite_yestoday: <font color=red> "+Eval("connectionstring_recordwrite_yestoday").ToString()+"</font><br>"%>                                     
                                    <%# Eval("connectionstring_north_realty_read_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_north_realty_read_yestoday: <font color=red> "+Eval("connectionstring_north_realty_read_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_north_realty_write_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_north_realty_write_yestoday: <font color=red> "+Eval("connectionstring_north_realty_write_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_north_realty_admin_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_north_realty_admin_yestoday: <font color=red> "+Eval("connectionstring_north_realty_admin_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_south_realty_read_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_south_realty_read_yestoday: <font color=red> "+Eval("connectionstring_south_realty_read_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_south_realty_write_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_south_realty_write_yestoday: <font color=red> "+Eval("connectionstring_south_realty_write_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_south_realty_admin_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_south_realty_admin_yestoday: <font color=red> "+Eval("connectionstring_south_realty_admin_yestoday").ToString()+"</font><br>"%>
                                    <%# Eval("connectionstring_glht_monitor_read_yestoday").ToString()=="0~0 平均0"?"":"connectionstring_glht_monitor_read_yestoday: <font color=red> "+Eval("connectionstring_glht_monitor_read_yestoday").ToString()+"</font><br>"%>
                                      <%# Eval("channelsales_conn_read_yestoday").ToString()=="0~0 平均0"?"":"channelsales_conn_read_yestoday: <font color=red> "+Eval("channelsales_conn_read_yestoday").ToString()+"</font><br>"%>
                                     <%# Eval("tuanMall_conn_read_yestoday").ToString()=="0~0 平均0"?"":"tuanMall_conn_read_yestoday: <font color=red> "+Eval("tuanMall_conn_read_yestoday").ToString()+"</font><br>"%>
                                     <%# Eval("tuan_conn_read_yestoday").ToString()=="0~0 平均0"?"":"tuan_conn_read_yestoday: <font color=red> "+Eval("tuan_conn_read_yestoday").ToString()+"</font><br>"%>

                                 </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--stats结束-->
	  		</div>  
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
