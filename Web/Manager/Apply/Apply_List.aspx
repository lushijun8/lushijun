<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply_List.aspx.cs" Inherits="Web.Manager.Apply.Apply_List" %>

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
			<div class="Body_PageContent">		
                <asp:DropDownList ID="ddl_apply_year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_apply_year_SelectedIndexChanged">
                </asp:DropDownList>��
                <asp:DropDownList ID="ddl_apply_month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_apply_month_SelectedIndexChanged">
                </asp:DropDownList>��<asp:Button CssClass="button" ID="btn_Lock" runat="server" Text="������������" OnClick="btn_Lock_Click" OnClientClick="javascript:return Lock_Click();" /><br />
                 &nbsp;���鵽<font color=red><%=this.LogCount.ToString() %></font>����¼,�ܹ�����<font color=red><%=this.Apply_Pen.ToString() %></font>֧�ʣ�<font color=red><%=this.Apply_PenLead.ToString() %></font>֧��о��<font color=red><%=this.Apply_Book.ToString() %></font>���ʼǲ���<font color=red><%=this.Apply_Glue.ToString() %></font>����ˮ��<font color=red><%=this.Apply_NotePaper.ToString() %></font>����ǩֽ��
                 <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>���</th>
			            <th>ʱ��</th>
			            <th>������</th>
			            <th>�����·�</th>
			            <th>��Ʒ</th>
			            <th>����</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td><%# (Container.ItemIndex+1)+(P_page-1)*20%></td> 
                                 <td><%# Eval("Apply_CreateTime").ToString()%></td>
                                 <td><%# Eval("Apply_WebManager_realname")%></td> 
                                 <td><%# Eval("Apply_year")%>��<%# Eval("Apply_month")%>��</td> 
                                 <td><%# Eval("Apply_pen").ToString()=="1"?"1֧�ʡ�":""%>
                                     <%# Eval("Apply_penlead").ToString()=="1"?"1֧��о��":""%>
                                     <%# Eval("Apply_book").ToString()=="1"?"1���ʼǲ���":""%>
                                     <%# Eval("Apply_glue").ToString()=="1"?"��ˮ��":""%>
                                     <%# Eval("Apply_notepaper").ToString()=="1"?"��ǩֽ��":""%>
                                 </td> 
			                     <td><%# Eval("Apply_lock").ToString()=="1"?"������":"δ����"%>                                       
                                     <%# Eval("Apply_Receive").ToString()=="1"?"�ѷ���":"<a href=\""+Business.Config.HostUrl+"/Manager/Apply/Apply_Receive.aspx?v="+ Com.Common.EncDec.Encrypt(Eval("Apply_WebManager_name").ToString()+","+Eval("Apply_year").ToString()+","+Eval("Apply_month").ToString(), this.Encrypt_key)+"\" onclick=\"javascript:return window.confirm('ȷ����ȡ��');\">��ȡ</a>"%>                                  
			                     </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--����-->
	  		</div> 
	  		<div class="Body_Pages"><%=this.outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
