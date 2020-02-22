<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Connect_Log.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Connect_Log" %>

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
    <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">
			<!--开始-->
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>查找：
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找(全字匹配)" OnClick="btnSearch_Click" />&nbsp;
                 
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>id</th>
			            <th>连接时间</th>
			            <th>数据库</th>
			            <%--<th>今日使用(次)</th>--%>
			            <th>详情</th>  
                        <th>负责人</th>  
                         <th>认领</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server"  EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td width="50"><%# Eval("id")%></td>
			                    <td width="120"><%# Eval("connectime")%></td> 
			                    <td width="230"> 
                                    [<%# Eval("DataBase_Remark")%>],[<%# Eval("DataBase_Name")%>]<br />
                                    <b><%# Eval("connectname")%></b><br />  

			                    </td>
                                <%--<td width="50"><%# Eval("DataBase_connect_times_today")%></td>--%>
                                 <td><font color=blue>Sessionid :</font> <a href="DataBase_Connect_Log.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("Sessionid").ToString())%>"><font color=black><%# string.IsNullOrEmpty(this.txtKeyword.Text)?Eval("Sessionid").ToString():Eval("Sessionid").ToString().Replace(this.txtKeyword.Text,"<font color=red>"+this.txtKeyword.Text+"</font>")%></font></a><br />
                                     <font color=blue>pageurl :</font> <a href="DataBase_Connect_Log.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><font color=black><b><%# string.IsNullOrEmpty(this.txtKeyword.Text)?Eval("pageurl").ToString():Eval("pageurl").ToString().Replace(this.txtKeyword.Text,"<font color=red>"+this.txtKeyword.Text+"</font>")%></b></font></a><br />
                                     <font color=blue>username :</font> <%# Eval("username")%><br />
                                     <font color=blue>querystring : </font><%# string.IsNullOrEmpty(this.txtKeyword.Text)?Eval("querystring").ToString():Eval("querystring").ToString().Replace(this.txtKeyword.Text,"<font color=red>"+this.txtKeyword.Text+"</font>")%><br />
                                     <font color=blue>form :</font> <%# Eval("form")%><br /></td>
                                <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log.aspx?page="+Server.UrlEncode(this.P_page.ToString())+"&keyword="+Server.UrlEncode(this.txtKeyword.Text))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log.aspx?page="+Server.UrlEncode(this.P_page.ToString())+"&keyword="+Server.UrlEncode(this.txtKeyword.Text))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%></td> 
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
	  		<div class="Body_Pages"><%=outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
