<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_Stats_List.aspx.cs" Inherits="Web.Manager.Log.Log_Stats_List" %>

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
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="Log_Stats_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=<%=this.P_My %>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater>  <a <%=string.IsNullOrEmpty(this.txtToday.Text)?"class=button":"class=button_off"%> href="Log_Stats_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=<%=this.P_My %>">全部</a>
                <p>&nbsp;</p>
                <a <%=this.P_My.ToString()=="0"?"class=button":"class=button_off"%> href="Log_Stats_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>">看全部</a>
                <a <%=this.P_My.ToString()=="1"?"class=button":"class=button_off"%> href="Log_Stats_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=1">只看我的</a>
                <!--stats开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" style="white-space:nowrap">
		            <tr>
			            <th>序号</th> 
			            <th><a href="Log_Stats_List.aspx?orderby=pageurl&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=<%=this.P_My %>" class="orderby">↓</a>请求页面</th> 
			            <th><a href="Log_Stats_List.aspx?orderby=log_type&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=<%=this.P_My %>" class="orderby">↓</a>类型<a href="Log_Stats_List.aspx?orderby=log_type+asc&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=<%=this.P_My %>" class="orderby">↑</a></th> 
                        <th><a href="Log_Stats_List.aspx?orderby=WebManager_Name&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=<%=this.P_My %>" class="orderby">↓</a>负责人</th>  
                        <th>操作</th> 
			            <th><a href="Log_Stats_List.aspx?orderby=log_count&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&teamname=<%=Server.UrlEncode(this.ddl_TeamName.SelectedValue) %>&My=<%=this.P_My %>" class="orderby">↓</a>报警次数(当天)</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex%></td> 
					            <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_<%# Eval("log_type").ToString()=="0"?"Error":"Business"%>_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%></a> 
                                     <%# Eval("ErrorInfo").ToString()!=""?"<span class=\"bug_tooltip\" titles=\""+Eval("ErrorInfo").ToString().Replace("\"","'")+"\"></span>":""%>
                                     <%# (Eval("Depend_PageUrl").ToString()+Eval("Depend_PageUrl_Out").ToString())!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+Eval("Depend_PageUrl_Out").ToString().Replace("\"","'")+"\"></span>":"" %>
                                     <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
			                    </td>
			                    <td><%# Eval("log_type").ToString()=="0"?"<font color=red>报错</font>":"业务"%></td> 
                                <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_PageUrl.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Log/Log_Stats_List.aspx?today="+Server.UrlEncode(this.txtToday.Text)+"&keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_OrderBy))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Log/Log_Stats_List.aspx?today="+Server.UrlEncode(this.txtToday.Text)+"&keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_OrderBy))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%></td> 
					            <td><%# Eval("log_count")%></td>
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