<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Depend_List_All.aspx.cs" Inherits="Web.Manager.Depend.Depend_List_All" %>

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
                <asp:TextBox ID="txtKeyword" runat="server" Width="30%"></asp:TextBox>,不包含关键字<asp:TextBox ID="txtNotLikeKeyWord" runat="server" Width="80px"></asp:TextBox>多个请用","隔开
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                 <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="Depend_List_All.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%# Eval("Date")%>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater>&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_My.ToString()=="0"?"class=button":"class=button_off"%> href="Depend_List_All.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>">看全部</a>
                <a <%=this.P_My.ToString()=="1"?"class=button":"class=button_off"%> href="Depend_List_All.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&today=<%=Server.UrlEncode(this.P_Today)%>&My=1">只看我依赖的</a>
                
                <img id="plus" src="<%=Business.Config.HostUrl %>/images/plus.gif" style="vertical-align:bottom;cursor:pointer" height="30" />
                <div id="div_plus" style="display:none;"><p>&nbsp;</p>
                 <asp:Repeater ID="rpt_Domain" runat="server" EnableViewState="false">
			                <ItemTemplate>
                                 <%# (Container.ItemIndex+1)%10==0?"<p>&nbsp;</p>":"" %>
				                 <a <%# this.P_keyword==Eval("DOMAIN").ToString()?"class=button":"class=button_off"%> href="Depend_List_All.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%#Server.UrlEncode(Eval("DOMAIN").ToString()) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=Server.UrlEncode(this.P_Today)%>"><%# Eval("DOMAIN")%></a>
			                </ItemTemplate>
		         </asp:Repeater>
                <a <%=this.P_keyword==""?"class=button":"class=button_off"%> href="Depend_List_All.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=&notlikekeyword=&today=<%=Server.UrlEncode(this.P_Today)%>">全部</a>			                
                </div>
                <!--开始-->                  
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			           <th>序号</th>
			           <th><a href="Depend_List_All.aspx?orderby=DEPEND_PAGEURL&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>被调用的接口URL</th>
                       <th><a href="Depend_List_All.aspx?orderby=WEBMANAGER_REALNAME+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>负责人</th>
                       <th><a href="Depend_List_All.aspx?orderby=WEBMANAGER_REALNAME_DEPEND+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>调用人</th>
                       <th><a href="Depend_List_All.aspx?orderby=DEPEND_TIMEOUT+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>超时设置</th> 
			           <th><a href="Depend_List_All.aspx?orderby=DEPEND_COUNT+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>请求数</th>
			           <th><a href="Depend_List_All.aspx?orderby=DEPEND_COUNT_ERROR+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>错误数</th>
                       <th><a href="Depend_List_All.aspx?orderby=DEPEND_ERROR_RATE+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>错误率</th>
			           <th><a href="Depend_List_All.aspx?orderby=DEPEND_COUNT_TIMEOUT+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>超时数</th>
                       <th><a href="Depend_List_All.aspx?orderby=DEPEND_TIMEOUT_RATE+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>超时率</th>
			           <th><a href="Depend_List_All.aspx?orderby=DEPEND_TIMESPAN_MIN+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>耗时<a href="Depend_List_All.aspx?orderby=DEPEND_TIMESPAN_MAX+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a></th> 
			           <th><a href="Depend_List_All.aspx?orderby=DEPEND_TIMESPAN_AVERAGE+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>平均</th>   
			           <th><a href="Depend_List_All.aspx?orderby=DEPEND_CONTENTLENGTH+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>长度</th>
                       <th><a href="Depend_List_All.aspx?orderby=DEPEND_CREATETIME+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&notlikekeyword=<%=Server.UrlEncode(this.txtNotLikeKeyWord.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>最后调用时间</th> 
			           </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex+1%></td>
					            <td<%# this.P_orderby.ToUpper()=="DEPEND_PAGEURL"?" class=orderby":""%>><img src="<%=Business.Config.HostUrl %>/images/<%# Eval("DEPEND_CONTENTTYPE_NEW")%>.gif" height="21"/> <a href="<%=Business.Config.HostUrl %>/Manager/Depend/Depend_View.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("DEPEND_PAGEURL").ToString()+","+Eval("STATS_DATE").ToString(),this.Encrypt_key) %>" target="_blank" titles="<%# Eval("DEPEND_PAGEURL_DETAIL")%>" class="tooltip"><%# Eval("DEPEND_PAGEURL")%></a>
                                    <%# Eval("ErrorInfo").ToString()!=""?"<span class=\"bug_tooltip\" titles=\""+Eval("ErrorInfo").ToString().Replace("\"","'")+"\"></span>":""%>
                                    <%# (Eval("Depend_PageUrl_Info").ToString()+Eval("Depend_PageUrl_Out").ToString())!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl_Info").ToString().Replace("\"","'")+Eval("Depend_PageUrl_Out").ToString().Replace("\"","'")+"\"></span>":"" %>
                                    <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                    <%# Eval("DEPEND_CONTENTTYPE_ERROR").ToString()=="1"?"<img src='"+Business.Config.HostUrl+"/images/no.gif' alt='今日有报错' title='今日有报错'/>":""%>
					            </td>                                 
					            <td<%# this.P_orderby.ToUpper()=="WEBMANAGER_REALNAME DESC"?" class=orderby":""%>><%# Eval("WebManager_RealName")%> 
                                    <%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("DEPEND_PAGEURL").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Depend/Depend_List_All.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&notlikekeyword="+Server.UrlEncode(this.txtNotLikeKeyWord.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"&today="+Server.UrlEncode(this.P_Today)+"\" onclick=\"javascript:return confirm_me('"+Eval("DEPEND_PAGEURL").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("DEPEND_PAGEURL").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Depend/Depend_List_All.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"&today="+Server.UrlEncode(this.P_Today)+"\" onclick=\"javascript:return confirm_me('"+Eval("DEPEND_PAGEURL").ToString()+"')\">认领</a>"%></td> 
					            <td<%# this.P_orderby.ToUpper()=="WEBMANAGER_REALNAME_DEPEND DESC"?" class=orderby":""%>><%# Eval("WEBMANAGER_REALNAME_DEPEND")%></td> 
                                <td<%# this.P_orderby.ToUpper()=="DEPEND_TIMEOUT DESC"?" class=orderby":""%>><%# (decimal.Parse(Eval("DEPEND_TIMEOUT").ToString())/1000).ToString("f2").Replace(".00", "")%>秒</td> 
					            <td<%# this.P_orderby.ToUpper()=="DEPEND_COUNT DESC"?" class=orderby":""%>><%# Eval("DEPEND_COUNT")%></td> 
					            <td<%# this.P_orderby.ToUpper()=="DEPEND_COUNT_ERROR DESC"?" class=orderby":""%>><%# Eval("DEPEND_COUNT_ERROR")%></td> 
					            <td<%# this.P_orderby.ToUpper()=="DEPEND_ERROR_RATE DESC"?" class=orderby":""%>><%# decimal.Parse(Eval("DEPEND_ERROR_RATE").ToString()).ToString("f2").Replace(".00","")%> %</td> 
                                <td<%# this.P_orderby.ToUpper()=="DEPEND_COUNT_TIMEOUT DESC"?" class=orderby":""%>><%# Eval("DEPEND_COUNT_TIMEOUT")%></td> 
					            <td<%# this.P_orderby.ToUpper()=="DEPEND_TIMEOUT_RATE DESC"?" class=orderby":""%>><%# decimal.Parse(Eval("DEPEND_TIMEOUT_RATE").ToString()).ToString("f2").Replace(".00","")%> %</td> 
					            <td<%# this.P_orderby.ToUpper()=="DEPEND_TIMESPAN_MIN DESC"?" class=orderby":""%>><%# (decimal.Parse(Eval("DEPEND_TIMESPAN_MIN").ToString())/1000).ToString("f2").Replace(".00", "")+"～"+(decimal.Parse(Eval("DEPEND_TIMESPAN_MAX").ToString())/1000).ToString("f2").Replace(".00", "")%>秒</td> 
                                <td<%# this.P_orderby.ToUpper()=="DEPEND_TIMESPAN_AVERAGE DESC"?" class=orderby":""%>><%# (decimal.Parse(Eval("DEPEND_TIMESPAN_AVERAGE").ToString())/1000).ToString("f2").Replace(".00", "")%>秒</td>
					            <td<%# this.P_orderby.ToUpper()=="DEPEND_CONTENTLENGTH DESC"?" class=orderby":""%>><%# Eval("DEPEND_CONTENTLENGTH")%></td>  
			                    <td<%# this.P_orderby.ToUpper()=="DEPEND_CREATETIME DESC"?" class=orderby":""%>><%# Eval("DEPEND_CREATETIME")%></td> 
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
