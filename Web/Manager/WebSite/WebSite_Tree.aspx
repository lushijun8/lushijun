<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSite_Tree.aspx.cs" Inherits="Web.Manager.WebSite.WebSite_Tree" %>
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
    <link href=<%=Business.Config.ResourcePath %>css/jquery.treeview.css?Version=<%=Business.Config.Version %> rel="stylesheet" type="text/css" />   
    <style type="text/css">
        .treeview-gray li {
            line-height: 100%;
        }
    </style> 
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
    <script src="<%=Business.Config.ResourcePath %>js/jquery.treeview.js?Version=<%=Business.Config.Version %>" type="text/javascript"></script> 
        共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>查找：
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
    <table border="0" cellpadding="0" cellspacing="0" style="white-space:nowrap">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
            <div id="treecontrol" style="display: block;">
               <%-- <a title="Collapse the entire tree below" href="#"> Collapse All</a>
                <a title="Expand the entire tree below" href="#">Expand All</a>
                <a title="展开" href="#">展开</a>--%>
            </div>
			<div class="Body_PageContent">
                <ul class="treeview-gray treeview" id="graytree">
                    <%=this.treehtml %>
                </ul>
			<!--结束-->
	  		</div> 
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
    <script language="javascript">
        $("#graytree").treeview({ control: "#treecontrol" });
    </script>
</body>
</html>
