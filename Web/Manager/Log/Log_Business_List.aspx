<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_Business_List.aspx.cs" Inherits="Web.Manager.Log.Log_Business_List" %>

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
        function showhide(id) {
            var ishidden = 0;
            $("#" + id).each(function () {
                if ($(this).is(":hidden")) {
                    ishidden = 1;
                }
            });
            if (ishidden == 0) {
                $("#" + id).hide();
                $("#s_" + id).text("���飫");
            }
            else {
                $("#" + id).show();
                $("#s_" + id).text("���飭");
            }
        }
     </script>
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
                ���鵽<font color=red><%=LogCount.ToString() %></font>����¼��<br/>���ң�
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="����" OnClick="btnSearch_Click" />&nbsp;
                 <!--��ʼ-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>ID</th>
			            <th>ʱ��</th>
			            <th>������IP</th>
			            <th>����</th>
			            <th>�û�</th>
			            <th>pageurl</th>
			            <th>������</th>
			            <th>����</th>
			            <th>�Ŷ�</th>
			            <th>����</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td><%# Eval("id")%></td>
			                        <td><%# Eval("createtime")%></td>
			                        <td><%# Eval("ip")%></td>
			                        <td><%# Eval("title")%></td>
			                        <td><%# Eval("username")%></td>
			                        <td><a href="<%# Business.Config.HostUrl %>/Manager/Log/Log_Business_List.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl")%></a> 
                                        <%# Eval("ErrorInfo").ToString()!=""?"<span class=\"bug_tooltip\" titles=\""+Eval("ErrorInfo").ToString().Replace("\"","'")+"\"></span>":""%>
                                        <%# (Eval("Depend_PageUrl").ToString()+Eval("Depend_PageUrl_Out").ToString())!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+Eval("Depend_PageUrl_Out").ToString().Replace("\"","'")+"\"></span>":"" %>
                                        <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
			                        </td>
			                        <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_PageUrl.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Log/Log_Business_List.aspx?page="+this.P_page+"&keyword="+Server.UrlEncode(this.txtKeyword.Text))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Log/Log_Business_List.aspx?page="+this.P_page+"&keyword="+Server.UrlEncode(this.txtKeyword.Text))+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%></td> 
					                <td><%# Eval("teamname")%></td>
			                        <td><a href="javascript:void(0);" onclick="javascript:showhide('v_<%# Eval("id")%>');" id="s_v_<%# Eval("id")%>">����<%# Container.ItemIndex==0?"��":"��"%></a></td>					           
				            </tr>
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("id")%>" style="<%# Container.ItemIndex==0?"":"display:none;"%>background-color:lightyellow;">
                                 <td colspan="10" style="border:1px solid #cccccc">
                                     <p>Content:<br /><%# Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;")%></p>
                                     <p>Remarks:<br /><%# Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;")%></p>
                                     ---------------------------------------------------------------------
                                     <p><%# Eval("send_email").ToString()=="1"?"�ѽ��и�����ƥ��":""%></p>
                                     <p><%# Eval("send_WebManager_name").ToString().Replace(",","")==""?"ûƥ���ϸ�����":"�Ѹ�������"+Eval("send_WebManager_name").ToString()+"���ʼ�"%></p>
                                 </td>
			                       				           
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
