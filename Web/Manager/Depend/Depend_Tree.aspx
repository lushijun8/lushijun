<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Depend_Tree.aspx.cs" Inherits="Web.Manager.Depend.Depend_Tree" %>


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
            if (window.confirm("ȷ����?\r\n" + pageurl) == true) {
                return true;
            }
            return false;
        }
     </script>
    <style type="text/css">
        .button {
            height: 21px;
        }
    </style>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
   <div class="Body_Content">
       <uc1:Menu ID="Menu1" runat="server" />
    <script language="javascript" type="text/javascript" src="<%=Business.Config.ResourcePath %>js/highcharts.js"></script> 
    <table border="0" cellpadding="0" cellspacing="0" style="white-space:nowrap">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">	
            ���鵽<font color=red><%=LogCount.ToString() %></font>����¼��<br/>���ң�
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;
            <p>&nbsp;</p>
		        <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			        <ItemTemplate>
				            <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="Depend_Tree.aspx?today=<%# Eval("Date")%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>"><%# Eval("Date")%></a>
			        </ItemTemplate>
		        </asp:Repeater>
            <a <%= this.P_Today.Trim()=="all"?"class=button":"class=button_off"%> href="Depend_Tree.aspx?today=all&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>">ȫ��</a> 
            <img id="plus" src="<%=Business.Config.HostUrl %>/images/plus.gif" style="vertical-align:bottom;cursor:pointer" height="30" />
             <div id="div_plus" style="display:none;"><p>&nbsp;</p>
                 <asp:Repeater ID="rpt_Domain" runat="server" EnableViewState="false">
			                <ItemTemplate>
                                 <%# (Container.ItemIndex+1)%10==0?"<p>&nbsp;</p>":"" %>
				                 <a <%# this.P_keyword==Eval("DOMAIN").ToString()?"class=button":"class=button_off"%> href="Depend_Tree.aspx?today=<%=Server.UrlEncode(this.P_Today)%>&keyword=<%#Server.UrlEncode(Eval("DOMAIN").ToString()) %>"><%# Eval("DOMAIN")%></a>
			                </ItemTemplate>
		         </asp:Repeater>
                <a <%=this.P_keyword==""?"class=button":"class=button_off"%> href="Depend_Tree.aspx?keyword=&today=<%=Server.UrlEncode(this.P_Today)%>">ȫ��</a>			                
                </div> 	
            <!--��ʼ-->
	           <%=this.dependhtml %>
			<!--����-->
        </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>        
    </form>    
</body>
</html>
