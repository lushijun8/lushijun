<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSite_PageUrl.aspx.cs" Inherits="Web.Manager.WebSite.WebSite_PageUrl" %>
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
                 <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>&My=<%=this.P_My%>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> 
                <p>&nbsp;</p> 
                <a <%=this.P_My.ToString()=="0"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>">看全部</a>
                <a <%=this.P_My.ToString()=="1"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=1">只看我的</a>
                <a <%=this.P_My.ToString()=="2"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=2">只看被认领的</a>
                <a <%=this.P_My.ToString()=="3"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=3">只看疑似我的</a>
                <a <%=this.P_My.ToString()=="4"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=4">只看当天执行的</a>
                <a <%=this.P_My.ToString()=="5"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=5">只看报错的</a>
                <a <%=this.P_My.ToString()=="6"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=6">只看手机号未加密的</a>
                <a <%=this.P_My.ToString()=="7"?"class=button":"class=button_off"%> href="WebSite_PageUrl.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=7">只看被调用的</a>
               <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			           <th>序号</th>
			           <th><a href="WebSite_PageUrl.aspx?orderby=pageurl&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>请求页面</th>
			           <th><a href="WebSite_PageUrl.aspx?orderby=webmanager_realname_depend&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>调用人</th>
			           <th><a href="WebSite_PageUrl.aspx?orderby=webmanager_realname_like&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>疑似负责人</th>
			           <th><a href="WebSite_PageUrl.aspx?orderby=WebManager_Name&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>负责人</th>
			           <th>操作</th> 
			           <th><a href="WebSite_PageUrl.aspx?orderby=ismy_createtime&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>认领时间</th>
			           <th><a href="WebSite_PageUrl.aspx?orderby=lastconnecttime&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>最后执行时间</th> 
                       <th><a href="WebSite_PageUrl.aspx?orderby=request_count&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>访次(今)</th>
			           <th><a href="WebSite_PageUrl.aspx?orderby=connect_times_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>连接数据库次数(今)<a href="WebSite_PageUrl.aspx?orderby=connect_times_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a> 平均<a href="WebSite_PageUrl.aspx?orderby=connect_times_avg&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a></th>
			           <th><a href="WebSite_PageUrl.aspx?orderby=duration_min&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a>今日执行时间(毫秒)<a href="WebSite_PageUrl.aspx?orderby=duration_max&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a> 平均<a href="WebSite_PageUrl.aspx?orderby=duration_avg&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>&My=<%=this.P_My%>" class="orderby">↓</a></th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex+1%></td>
					            <td<%# this.P_orderby.ToLower()=="pageurl"?" class=orderby":""%>><%# Eval("pageurl").ToString()%> 
                                    <%# Eval("ErrorInfo").ToString()!=""?"<span class=\"bug_tooltip\" titles=\""+Eval("ErrorInfo").ToString().Replace("\"","'")+"\"></span>":""%>
                                    <%# (Eval("Depend_PageUrl").ToString()+Eval("Depend_PageUrl_Out").ToString())!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+Eval("Depend_PageUrl_Out").ToString().Replace("\"","'")+"\"></span>":"" %>
                                    <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
					            </td> 
                                <td<%# this.P_orderby.ToLower()=="webmanager_realname_depend"?" class=orderby":""%>><%# Eval("webmanager_realname_depend")%></td> 	
                                <td<%# this.P_orderby.ToLower()=="webmanager_realname_like"?" class=orderby":""%>><%# Eval("webmanager_realname_like")%></td> 				
					            <td<%# this.P_orderby.ToLower()=="webmanager_name"?" class=orderby":""%>><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_PageUrl.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除认领</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%></td> 
                                <td<%# this.P_orderby.ToLower()=="ismy_createtime"?" class=orderby":""%>><%# Eval("ismy_createtime")%></td> 					            
                                <td<%# this.P_orderby.ToLower()=="lastconnecttime"?" class=orderby":""%>><%# Eval("lastconnecttime").ToString()%></td>
                                <td<%# this.P_orderby.ToLower()=="request_count"?" class=orderby":""%>><%# Eval("request_count")%></td>
                                <td<%# this.P_orderby.ToLower().IndexOf("connect_times")>-1?" class=orderby":""%>><%# Eval("connect_times_min").ToString()%>~<%# Eval("connect_times_max").ToString() %> 平均 <%# Eval("connect_times_avg").ToString() %> 次</td>
			                    <td<%# this.P_orderby.ToLower().IndexOf("duration")>-1?" class=orderby":""%>><%# Eval("duration_min").ToString()%>~<%# Eval("duration_max").ToString() %> 平均 <%# Eval("duration_avg").ToString() %> 毫秒</td>
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
