<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Owner_List.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Owner_List" %>


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
                <%if (this.CurrentIsAdmin == true) { %><asp:Button CssClass="button" ID="btnSave" runat="server" Text="固化到配置文件dataconfiguration.config中" OnClick="btnSearch_Click" />&nbsp;
                <%} %>
			<!--开始-->
                <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>ID</th>
                        <th>数据库</th> 
                        <th>占用空间</th> 
                        <th>备份</th>
                        <th>操作</th> 
                        <th>内网实IP</th>
                        <th>内网VIP</th>
                        <th>外网VIP</th>
                        <th>堡垒机专IP</th>
                        <th>容灾IP</th>
                        <th>admin用户</th>
                        <th>admin密码</th>
                        <th>只读用户</th>
                        <th>读密码</th>
                        <th>可写用户</th>
                        <th>写密码</th>
                        <th>备注</th> 
		            </tr>
		            <asp:Repeater ID="rptDataBase" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# Eval("DataBase_Id")%></td>
                               <td>
                                     <img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> 
                                        <%# Eval("DataBase_Id").ToString()==""?"":
                                        "<a title=\""+Eval("DataBase_Remark").ToString()+"\" href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)+"\" target=\"_blank\">"
                                        %>
                                        [<%# Eval("DataBase_IP_Romote") %>]..[<%# Eval("DataBase_Name") %>]
                                     <%# Eval("DataBase_Id").ToString()==""?"":"</a>" %>
                                  <%if (this.CurrentIsAdmin == true) { %>
                                    <a href="DataBase_Owner_Edit.aspx?DataBase_Id=<%# Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)%>">修改</a>
                                    <%} %>
					            </td> 
                                <td><%# Eval("Space_Used_String")%></td>
                                <td>  
                                    <a href="<%# Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_BackUp.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key) %>" target="_blank"><img src="<%=Business.Config.ResourcePath %>images/procviewfun.gif" style="vertical-align:middle"/></a>
                                    <a href="<%# Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_BackUp.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key) %>&bak=2" target="_blank"><span class="red">&nbsp;2&nbsp;</span></a>
                                    <a href="<%# Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_BackUp.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key) %>&bak=3" target="_blank"><span class="red">&nbsp;3&nbsp;</span></a>
                                </td> 
                                <td>
                                    <a href="DataBase_Alter_List.aspx?DataBase_IP_Romote=<%# Com.Common.EncDec.Encrypt( Eval("DataBase_IP_Romote").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)%>" target="_blank" title="增删改表结构、存储过程、函数、视图等"><%# Eval("DATABASE_IS_MAIN").ToString()=="1"?"修改":"" %></a>
                                </td>
                                <td><%# Eval("DataBase_IP_Local").ToString().Replace("0.0.0.0","")%></td>
                                <td><%# Eval("DataBase_VIP_Local").ToString().Replace("0.0.0.0","")%></td>
                                <td><%# Eval("DataBase_VIP_Romote").ToString().Replace("0.0.0.0","")%></td>
                                <td><%# Eval("DataBase_IP_Special").ToString().Replace("0.0.0.0","")%></td>
                                <td><%# Eval("DataBase_IP_Recovery").ToString().Replace("0.0.0.0","")%></td>
                                <td><%# Eval("DataBase_Admin_User")%></td>
                                <td><%#this.CurrentIsAdmin==true?Com.Common.EncDec.Decrypt(Eval("DataBase_Admin_PassWord").ToString(), this.Encrypt_key):"***" %></td>
                                <td><%# Eval("DataBase_Reader_User")%></td>
                                <td><%#this.CurrentIsAdmin==true?Com.Common.EncDec.Decrypt(Eval("DataBase_Reader_PassWord").ToString(), this.Encrypt_key):"***" %></td>
                                <td><%# Eval("DataBase_Writer_User")%></td>
                                <td><%#this.CurrentIsAdmin==true?Com.Common.EncDec.Decrypt(Eval("DataBase_Writer_PassWord").ToString(), this.Encrypt_key):"***" %></td>
                                <td><%# Eval("DataBase_Remark")%>
                                    <%if (this.CurrentIsAdmin == true) { %>
                                    <a href="DataBase_Owner_Description_Create.aspx?DataBase_Id=<%# Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)%>" target="_blank"><%# Eval("DATABASE_IS_MAIN").ToString()=="1"?"刷新":"" %></a><br /><%# Eval("LAST_UPDATE_TIME")%>
                                    <%} %>
                                </td>  
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
