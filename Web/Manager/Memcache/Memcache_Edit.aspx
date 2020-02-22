<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Memcache_Edit.aspx.cs" Inherits="Web.Manager.Memcache.Memcache_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        IP：<asp:TextBox ID="txt_Memcache_IP" runat="server"></asp:TextBox>
&nbsp;LocalIP:<asp:TextBox ID="txt_Memcache_Local_IP" runat="server"></asp:TextBox>
        ,端口：<asp:TextBox ID="txt_Memcache_Port" runat="server"></asp:TextBox>
        ,备注：<asp:TextBox ID="txt_Remark" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Text="确定修改" />
    
    </div>
    </form>
</body>
</html>
