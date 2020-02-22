<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="Web.Manager.Admin.Permission" %>
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
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
   <div class="Body_Content">
       <uc1:Menu ID="Menu1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
            <%=this.QueryString("Group_name") %>：
            <br />
            <asp:CheckBoxList ID="cblPermission" runat="server" RepeatColumns="2">
            </asp:CheckBoxList>
            <asp:Button CssClass="button" ID="btnSave" runat="server" Text="确定修改" OnClick="btnSave_Click" />
          </td>
        <td class="r2">&nbsp;</td>
      </tr>     
    </table>
  </div>
    </form>
</body>
</html>
