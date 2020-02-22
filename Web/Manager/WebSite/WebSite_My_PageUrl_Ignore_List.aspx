<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSite_My_PageUrl_Ignore_List.aspx.cs" Inherits="Web.Manager.WebSite.WebSite_My_PageUrl_Ignore_List" %>

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
    <table border="0" cellpadding="0" cellspacing="0" style="white-space:nowrap">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">
			<!--开始-->
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>查找：
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                 
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			           <th>序号</th>
			           <th>请求页面</th>
			           <th>负责人</th>
			           <th><a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=createtime&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>认领时间</th>    
                        <th>认领</th> 
                        <th>删除</th> 
			            <th><a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=request_count_today&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>访次(今)</th>
			            <th><a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=request_count_yestoday&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>访次(昨)</th>
			            <th><a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=connectionstring_today_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>连接数据库次数(今)<a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=connectionstring_today_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a></th>
			            <th><a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=connectionstring_yestoday_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>连接数据库次数(昨)<a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=connectionstring_yestoday_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a></th>
			            <th><a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=duration_today_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>今日执行时间(秒)<a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=duration_today_max" class="orderby&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a></th>
			            <th><a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=duration_yestoday_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>昨日执行时间(秒)<a href="WebSite_My_PageUrl_Ignore_List.aspx?orderby=duration_yestoday_max" class="orderby&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a></th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex+1%></td>
					            <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_Log.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%></a>
                                     <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
					            </td>
					            <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
			                    <td><%# Eval("createtime")%></td> 
                                <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%></td> 
                                <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Ignore_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>"%></td> 
                                <td><%# Eval("request_count_today")%></td>
					            <td><%# Eval("request_count_yestoday")%></td>
                                <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_today_min").ToString()%>~<%# Eval("connectionstring_today_max").ToString() %> 次</a></td>
                                <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %> 次</a></td>
			                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_today")%></a></td>
					            <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_yestoday")%></a></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
