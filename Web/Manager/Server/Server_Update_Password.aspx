<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Server_Update_Password.aspx.cs" Inherits="Web.Manager.Server.Server_Update_Password" %>

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
         function Password_Decrypt(openhref) {
             $("#remark").show();
             $("#openhref").val(openhref);
         }
         function Password_Decrypt_Submit(href) {
             if($("#txtDecrypt_Remark").val().length <40)
             {
                 window.alert("����д����20���������ϣ�");
                 return false;
             }
             else {
                 var txtDecrypt_Remark_val = $("#txtDecrypt_Remark").val();
                 var openhref_val = $("#openhref").val();
                 Password_Decrypt_Cancel();
                 window.open(openhref_val + "&remark=" + txtDecrypt_Remark_val);
             }
             return false;
         }
         function Password_Decrypt_Cancel()
         {
             $("#txtDecrypt_Remark").val("");
             $("#openhref").val("");
             $('#remark').hide();
         }
     </script>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
    <div id="remark" style="display:none;position:fixed;margin:0 auto;border:2px solid #a0a0a0;background-color:#cccccc;text-align:center;top:20%;left:20%;">
        <img src="<%=Business.Config.HostUrl %>/images/why.gif" style="vertical-align:middle;"/> ȷ���鿴��һ���鿴�ͻ��ռ���룬������ǰ���˲������á�<br />
        ������Ʋ���Ҫ���ÿ�θ��µĳ��������ƣ�����д����Ҫ���µľ��幦�ܣ�<br />
        <asp:TextBox ID="txtDecrypt_Remark" runat="server" Height="300px" TextMode="MultiLine" Width="600px"></asp:TextBox><br />
        �벻Ҫ��д�����������Ա�����޷�����<br />
        <input type="hidden" id="openhref"/>
        <input id="btnSubmit" type="button" value="ȷ��" class="button" onclick="javascript:return Password_Decrypt_Submit();"/>&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="btnCancel" type="button" value="ȡ��" class="button" onclick="javascript:Password_Decrypt_Cancel();"/>
        </div>
   <div class="Body_Content">
       <uc1:Menu ID="Menu1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">
			<!--��ʼ-->
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼��<br/>���ң�
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;
                 
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>id</th>
			            <th>������</th>
			            <%--<th>������IP</th>--%>
			            <th>����������</th>
			            <th>����ʱ��</th>
			            <%--<th>�鿴��IP</th>--%>
			            <th>�鿴������</th>
			            <th>�鿴����</th>
			            <th>�鿴ʱ��</th>
			            <th>��ע</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Eval("id")%></td>
			                    <td><%# Eval("servername")%></td>
			                    <%--<td><%# Eval("create_ip")%></td>--%>
			                    <td><%# Eval("WebManager_RealName")%> <%# Eval("create_ip")%></td>                              
			                    <td><%# Eval("create_time")%></td>                                
			                    <%--<td><%# Eval("decrypt_ip")%></td>--%>                                 
			                    <td><%# Eval("WebManager_RealName_Decrypt_UserName")%> <%# Eval("decrypt_ip")%></td>                                 
			                    <td><%# Eval("hidden").ToString()=="1"?"���ڲ��ܸ�����ʽվ<br />��ʽվ����ʱ��Ϊ��<br /> 00:00��09:00<br /> 12:00��13:10<br /> 17:45��23:59":(Eval("decrypt_password").ToString()==""?"<a href=\"javascript:void(0);\" onclick=\"javascript:return Password_Decrypt('Server_Update_Password_Decrypt.aspx?id="+Com.Common.EncDec.Encrypt(Eval("id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)+"');\" target=_blank>�鿴</a>":(this.CurrentWebManagerName==Eval("decrypt_username").ToString()?Eval("decrypt_password").ToString():"���� <font color=red>"+Eval("WebManager_RealName_Decrypt_UserName").ToString()+"</font> Ҫ"))%> <%#this.CurrentIsAdmin==true?Com.Common.EncDec.Decrypt(Eval("create_password").ToString(),this.Encrypt_key):"" %></td>                                 
			                    <td><%# Eval("decrypt_time")%></td>
                                <td><%# Eval("decrypt_remark").ToString().Replace("\t","&nbsp;").Replace("\r\n","<br/>")%></td>
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
