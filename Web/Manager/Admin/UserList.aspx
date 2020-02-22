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
			<!--开始-->
                <br/>查找:<asp:DropDownList ID="ddlProduct" runat="server"> 
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />
                <br/>
	<table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		<tr>
			<th>序号</th>
			<th>所属分组</th>
			<th>产品</th>
			<th>用户名</th>
			<th>姓名</th>
			<th>团队</th>
			<th>IP</th>
			<th>邮箱</th>
			<th>最后登录时间</th>
			<th>添加时间</th>
			<th>手机号</th>
			<th>备注</th>
			<th>状态</th>
			<th>操作</th>
			<th>报错邮件</th>
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
					<td ><%# Eval("WebManager_Status").ToString()=="100"?"正常":"已停用"%></td>   
					<td ><a href ="AddUser.aspx?WebManager_id=<%#Com.Common.EncDec.Encrypt(Eval("WebManager_id").ToString(),this.Encrypt_key)%>" onclick="javascript:return window.confirm('确定编辑<%# Eval("WebManager_name")%>吗？');">编辑</a>|<a href ="UpdateUserStatus.aspx?v=<%#Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString()+","+( Eval("WebManager_Status").ToString()=="100"?"200":"100")+","+System.DateTime.Now.ToString("yyyyMMdd"))%>" onclick="javascript:return window.confirm('确定<%# Eval("WebManager_Status").ToString()=="100"?"停用":"启用"%>吗？');"><%# Eval("WebManager_Status").ToString()=="100"?"停用":"启用"%></a>|<a href ="DeleteUser.aspx?wid=<%#Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString())%>" onclick="javascript:return window.confirm('确定删除<%# Eval("WebManager_name")%>吗？');">删除</a>|<a href ="AutoLogin.aspx?v=<%# Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString()+","+System.DateTime.Now.AddMinutes(20).ToString())%>" onclick="javascript:return window.confirm('确定登录<%# Eval("WebManager_name")%>吗？');">登录</a></td>   
                    <td><a href ="Update_Recieve_AlertEmail.aspx?v=<%#Com.Common.EncDec.Base64Encrypt(Eval("WebManager_id").ToString()+","+( Eval("WebManager_Recieve_AlertEmail").ToString()=="1"?"0":"1")+","+System.DateTime.Now.ToString("yyyyMMdd"))%>" onclick="javascript:return window.confirm('确定<%# Eval("WebManager_Recieve_AlertEmail").ToString()=="1"?"不接收":"接收"%>吗？');"><%# Eval("WebManager_Recieve_AlertEmail").ToString()=="1"?"不接收":"接收"%></a></td>
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
