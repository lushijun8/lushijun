<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayLog.aspx.cs" Inherits="Web.Manager.PayLog" EnableViewState="false"%>

<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
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
                共查到<font color=red><%=MallLogCount.ToString() %></font>条记录。<br/>查找：
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                 <%if (this.CurrentIsAdmin == true){ %><asp:Button CssClass="button" ID="btn_Clear" runat="server" Text="清空日志" OnClick="btn_Clear_Click" /><%} %>
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>MallLogID</th>
			            <th>UserType</th>
			            <th>UserID</th>
			            <th>UserName</th>
			            <th>RealName</th>
			            <th>ItemType</th>
			            <th>ItemID</th>
			            <th>Description</th>
			            <th>IP</th>
			            <th>AddedTime</th>
		            </tr>
		            <asp:Repeater ID="rptMallLog" runat="server">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td width=80><%# Eval("MallLogID")%></td>
					            <td width=60><%# Eval("UserType")%></td>
					            <td width=60><%# Eval("UserID")%></td>
			                    <td width=60><%# Eval("UserName")%></td>
			                    <td width=60><%# Eval("RealName")%></td>
			                    <td width=60><%# Eval("ItemType")%></td>
			                    <td width=60><%# Eval("ItemID")%></td>
					            <td><div><textarea style="width:100%;height:80px;border:solid 1px #000000; "><%# Eval("Description")%></textarea></div></td>
			                    <td width=80><%# Eval("IP")%></th>
			                    <td width=120><%# Eval("AddedTime")%></td>
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
