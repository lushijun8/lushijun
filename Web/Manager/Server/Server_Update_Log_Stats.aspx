<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Server_Update_Log_Stats.aspx.cs" Inherits="Web.Manager.Server.Server_Update_Log_Stats" %>

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
			<!--stats开始-->
                统计<asp:DropDownList ID="ddl_GroupBy" runat="server" Visible="false">
                    <asp:ListItem Value="IP,WebManager_RealName">IP,WebManager_RealName</asp:ListItem>
                    <asp:ListItem Value="IP">IP</asp:ListItem>
                    <asp:ListItem Value="WebManager_realname">WebManager_realname</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtCreateTime0" runat="server" Width="102px" onfocus="javascript:ShowCalendar(this.id)">1900-1-1</asp:TextBox>
                到<asp:TextBox ID="txtCreateTime1" runat="server" onfocus="javascript:ShowCalendar(this.id)">2090-1-1</asp:TextBox>
                站点<asp:DropDownList ID="ddl_WebSite" runat="server">
                </asp:DropDownList>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />&nbsp;
                 
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr> 
			            <th>用户名</th>
			            <th>IP</th> 
			            <th>使用次数</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
			                    <td><%# Eval("WebManager_RealName")%></td>
			                    <td><%# Eval("IP")%></td>
			                    <td><%# Eval("counts")%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--stats结束-->
	  		</div> 
	  		<div class="Body_Pages"> </div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
