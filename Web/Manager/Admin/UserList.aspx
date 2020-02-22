<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Web.Manager.Admin.UserList" %>

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
			<!--��ʼ-->
                <br/>����:<asp:DropDownList ID="ddlProduct" runat="server"> 
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />
                <br/>
	<table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		<tr>
			<th>���</th>
			<th>��������</th>
			<th>��Ʒ</th>
			<th>�û���</th>
			<th>����</th>
			<th>�Ŷ�</th>
			<th>IP</th>
			<th>����</th>
			<th>����¼ʱ��</th>
			<th>���ʱ��</th>
			<th>�ֻ���</th>
			<th>��ע</th>
			<th>״̬</th>
			<th>����</th>
			<th>�����ʼ�</th>
		</tr>
		<asp:Repeater ID="rptAdmin_WebManager" runat="server" EnableViewState="false">
			<ItemTemplate>
				<tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                    <td><%# (Container.ItemIndex+1)+(P_page-1)*20%></td> 
					<td >
                          <%if (this.CurrentIsAdmin == true){ %><a href="Permission.aspx?Group_id=<%# Com.Common.EncDec.Encrypt( Eval("WebManager_Group_id").ToString(),this.Encrypt_key)%>&Group_name=<%# Server.UrlEncode(Eval("Group_name").ToString())%>" target="_blank"><%} %>
                            <%# Eval("Group_name")%>
                          <%if (this.CurrentIsAdmin == true){ %></a><%} %></td>
					<td ><%# Eval("WebManager_Product")%></td>
					<td ><%# Eval("WebManager_name")%></td> 
					<td ><%# Eval("WebManager_realname")%></td> 
					<td ><%# Eval("WebManager_leader_realname")%></td>
					<td ><%# Eval("WebManager_IP")%></td>  
					<td ><%# Eval("WebManager_Email")%></td>  
					<td ><%# Eval("WebManager_Last_logintime")%></td>  
					<td ><%# Eval("WebManager_Createtime")%></td>  
					<td ><%# Eval("WebManager_mobile")%></td>   
					<td ><%# Eval("WebManager_Remark")%></td>   
					<td ><%# Eval("WebManager_Status").ToString()=="100"?"����":"��ͣ��"%></td>   
					<td ><a href ="AddUser.aspx?WebManager_id=<%#Com.Common.EncDec.Encrypt(Eval("WebManager_id").ToString(),this.Encrypt_key)%>" onclick="javascript:return window.confirm('ȷ���༭<%# Eval("WebManager_name")%>��');">�༭</a>|<a href ="UpdateUserStatus.aspx?v=<%#Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString()+","+( Eval("WebManager_Status").ToString()=="100"?"200":"100")+","+System.DateTime.Now.ToString("yyyyMMdd"))%>" onclick="javascript:return window.confirm('ȷ��<%# Eval("WebManager_Status").ToString()=="100"?"ͣ��":"����"%>��');"><%# Eval("WebManager_Status").ToString()=="100"?"ͣ��":"����"%></a>|<a href ="DeleteUser.aspx?wid=<%#Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString())%>" onclick="javascript:return window.confirm('ȷ��ɾ��<%# Eval("WebManager_name")%>��');">ɾ��</a>|<a href ="AutoLogin.aspx?v=<%# Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString()+","+System.DateTime.Now.AddMinutes(20).ToString())%>" onclick="javascript:return window.confirm('ȷ����¼<%# Eval("WebManager_name")%>��');">��¼</a></td>   
                    <td><a href ="Update_Recieve_AlertEmail.aspx?v=<%#Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString()+","+( Eval("WebManager_Recieve_AlertEmail").ToString()=="1"?"0":"1")+","+System.DateTime.Now.ToString("yyyyMMdd"))%>" onclick="javascript:return window.confirm('ȷ��<%# Eval("WebManager_Recieve_AlertEmail").ToString()=="1"?"������":"����"%>��');"><%# Eval("WebManager_Recieve_AlertEmail").ToString()=="1"?"������":"����"%></a></td>
				</tr>
			</ItemTemplate>
		</asp:Repeater>
	</table>
			<!--����-->
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
