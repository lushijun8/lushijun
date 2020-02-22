<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Share_Article_View_1.aspx.cs" Inherits="Web.Manager.Share.Share_Article_View_1" %>
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
<body> 
    <form id="form2" runat="server"> 
	        <table width="860" border="0" cellspacing="20" cellpadding="20" align="center">
            <tr>
                <td>
                    <p>&nbsp;</p>
                    <h1><%=this.Article_Title %></h1><p>&nbsp;</p>
                    <%=this.Article_Text.Replace("\t","&nbsp;").Replace("\r\n","<br/>") %>
                    <p>&nbsp;</p>
            </td>
            </tr>
            </table>
    </form> 
</body>
</html> 