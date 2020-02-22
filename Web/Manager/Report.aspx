<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Web.Manager.Report" EnableViewState="false" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��ӭ��¼TeamTool��̨...</title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <base target="_blank" />
    <script language="javascript">
        function confirm_me(pageurl) {
            if (window.confirm("ȷ����?\r\n" + pageurl) == true) {
                return true;
            }
            return false;
        }
        function showhide(classname) {
            var ishidden = 0;
            $("." + classname).each(function () {
                if ($(this).is(":hidden")) {
                    ishidden = 1;
                }
            });
            if (ishidden == 0) {
                $("." + classname).hide();
            }
            else {
                $("." + classname).show();
            }
        }
    </script>
</head>
<body class="Body_Right"> 
     <style type="text/css">        
    <!--#include file="../css/style.css"-->
         td,th {
             white-space:nowrap; font-size:9pt;
         } 
    </style>
    <!--<form id="form1" runat="server">-->
    <h2>��ҿ����Լ������ҳ���뼰ʱ����,��Ҫ��Ϊ�˷��������ܼ�ʱ�ҵ���Ӧ�ĸ�����,лл��</h2>
   <div class="Body_PageContent"> 
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td style="vertical-align:top" colspan="2">
             <table border="0" cellspacing="0" cellpadding="0"  width="100%">
                 <%if(rpt_website_my_pageurl_my.Items.Count>0){ %>
                 <tr>
                         <td colspan="7">
                             <b><%=this.CurrentWebManagerName %> �������ҳ�� ( Top 5 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx">����...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>����
                                    </th> 
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>�ô�
                                    </th>  
                                    <th>���Ӵ���(����)
                                    </th> 
                                    <th>���Ӵ���(ǰһ��)
                                    </th> 
				                </tr>
                 <%} %>
                  <asp:Repeater  EnableViewState="false" ID="rpt_website_my_pageurl_my" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>����
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>"%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <%if(rpt_website_my_pageurl_my_like.Items.Count>0){ %>
                 <tr>
                         <td colspan="7">
                             <b>���� <%=this.CurrentWebManagerName %> ��ҳ��(������������)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx">����...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>����
                                    </th> 
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>�ô�
                                    </th>  
                                    <th>���Ӵ���(����)
                                    </th> 
                                    <th>���Ӵ���(ǰһ��)
                                    </th> 
				                </tr>
                 <%} %>
                 <asp:Repeater  EnableViewState="false" ID="rpt_website_my_pageurl_my_like" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_website_my_pageurl_my_like_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td>--
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>    
                                    <td>
                                    </td> 
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a> "%>
                                       <%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Ignore_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a> "%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <%if (rpt_website_my_pageurl_my_like.Items.Count>5){ %>
                 <tr><td colspan="7" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_website_my_pageurl_my_like_tr_hide');">................</a>
                     </td></tr>
                 <%}%>
                  <tr>
                         <td colspan="7">
                             <b>���ݿ����Ӵ�ʹ�ý�Ƶ����ҳ��( > 1�� , Top 5 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx">����...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>����
                                    </th> 
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>�ô�
                                    </th>  
                                    <th>���Ӵ���(����)
                                    </th> 
                                    <th>���Ӵ���(ǰһ��)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_today" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>����
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                   <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <tr>
                                    <th>����
                                    </th> 
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>�ô�
                                    </th>  
                                    <th>���Ӵ���(����)
                                    </th> 
                                    <th>���Ӵ���(ǰһ��)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_yestoday" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>
                                    ����
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>                                     
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <tr>
                         <td colspan="7">
                             <b>ִ��ʱ��ϳ�ҳ�� ( > 1�� , Top 5)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx">����...</a></span>
                         </td>  
				     </tr>
                 <tr>
                                    <th>����
                                    </th>
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>
                                    <th>�ô�
                                    </th>  
                                    <th>ִ������(����)
                                    </th> 
                                    <th>ִ������(ǰһ��)
                                    </th>
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_duration_today" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>����
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>  
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("duration_today").ToString() %></a>
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("duration_yestoday").ToString() %></a>
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <tr>
                                    <th>����
                                    </th>
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>
                                    <th>�ô�
                                    </th>  
                                    <th>ִ������(����)
                                    </th> 
                                    <th>ִ������(ǰһ��)
                                    </th>
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_duration_yestoday" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>> 
                                    <td>����
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>  
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("duration_today").ToString() %></a>
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("duration_yestoday").ToString() %></a>
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
	            </table>
          </td> 
        </tr> 
      <tr> 
        <td style="background-color:#eeeeee;vertical-align:top" width="50%"> 
			 <table border="0" cellspacing="0" cellpadding="0" width="100%" >
                  <tr>
                     <td colspan="2">
                         <b>���ݿ�˵���ĵ�</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_List.aspx">����...</a></span>
                     </td>  
				 </tr>
		            <asp:Repeater  EnableViewState="false" ID="rptDataBase" runat="server">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> <a title="<%# Eval("DataBase_Remark").ToString() %>" href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id=<%# Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)%>" target="_blank"><%# "["+Eval("DataBase_IP_Romote").ToString()+"]..["+Eval("DataBase_Name").ToString()+"]" %> </a>
                                </td>  
                                <td>
                                    <%# Eval("DataBase_Remark").ToString() %>
                                </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
          </td>
          <td  style="background-color:#ffffff;vertical-align:top">
              <table border="0" cellspacing="0" cellpadding="0"  width="100%">
                   <tr>
                     <td colspan="4">
                         <b>���ݿ����Ӵ�ʹ����� ( <%=this.ConnectString_Date %> ���������� )</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx">����...</a></span>
                     </td>  
				 </tr>
		            <asp:Repeater  EnableViewState="false" ID="rptConnectstring" runat="server">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td>
                                    <%# Eval("DataBase_ConnectString_Name") %>
                                </td>
                                <td>
                                    <img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> 
                                        <%# Eval("DataBase_Id").ToString()==""?"":
                                        "<a title=\""+Eval("DataBase_Remark").ToString()+"\" href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)+"\" target=\"_blank\">"
                                        %>
                                        [<%# Eval("DataBase_IP_Romote") %>]..[<%# Eval("DataBase_Name") %>]
                                     <%# Eval("DataBase_Id").ToString()==""?"":"</a>" %>
                                </td>  
                                <td>
                                    ����<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx"><%# Eval("DataBase_Connect_Times_Today") %></a>��
                                </td>  
                                <td>
                                    �� <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx"><%# Eval("DataBase_Connect_Times") %></a> ��
                                </td> 
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
          </td>
      </tr>
        <tr>
          <td style="background-color:#ffffff;vertical-align:top">
             <table border="0" cellspacing="0" cellpadding="0"  width="100%">
                  <tr>
                         <td colspan="4">
                             <b>������������ʹ�����</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/Server/Server_Update_Log.aspx">����...</a></span>
                         </td>  
				     </tr>
		                <asp:Repeater  EnableViewState="false" ID="rptServerUpdateLog" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td><%# Eval("username").ToString()+"  ["+Eval("ip").ToString()+"]" %>
                                    </td> 
                                    <td>������
                                    </td> 
                                    <td><%# Eval("servername").ToString() %>
                                    </td> 
                                    <td><%# Eval("createtime").ToString() %>
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
	            </table>
          </td>
               <td style="background-color:#eeeeee;vertical-align:top"> 
                    <table border="0" cellspacing="0" cellpadding="0"  width="100%">
                   <tr>
                     <td colspan="4">
                         <b>�������������������</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/Server/Server_Update_Password.aspx">����...</a></span>
                     </td>  
				 </tr>
		            <asp:Repeater  EnableViewState="false" ID="rptServerUpdatePassword" runat="server">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# Eval("create_username").ToString()+"["+Eval("create_ip").ToString()+"]"%>
                                </td> 
                                 <td>���� <%# Eval("servername").ToString().Split('_')[0] %> ����Ϊ</td>
                                 <td>**** <%# "<a href=\""+Business.Config.HostUrl+"/Manager/Server/Server_Update_Password.aspx\">�鿴</a>"%></td>
                                <td><%# Eval("create_time").ToString()%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>                 
               </td>
        </tr>
    </table>  
       &nbsp;&nbsp;<b>Ч������ۺ�����</b>
       <table border="0" cellspacing="0" cellpadding="0">
		            <tr>
			            <th>���</th> 
			            <th>����ҳ��</th> 
                        <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=WebManager_Name" class="orderby">��</a>������</th>  
                        <th>����</th> 
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_today" class="orderby">��</a>�ô�(����)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_yestoday" class="orderby">��</a>�ô�(ǰһ��)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_min" class="orderby">��</a>�����Ӵ���(����)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_max" class="orderby">��</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_min" class="orderby">��</a>�����Ӵ���(ǰһ��)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_max" class="orderby">��</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_min" class="orderby">��</a>����ִ��ʱ��(��)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_max" class="orderby">��</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_min" class="orderby">��</a>����ִ��ʱ��(��)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_max" class="orderby">��</a></th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex+1%></td> 
					            <td><%# Eval("pageurl")%></td> 
                                <td><%# Eval("WebManager_Name").ToString()%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log_Stats.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log_Stats.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%></td> 
					            <td><%# Eval("request_count_today")%></td>
					            <td><%# Eval("request_count_yestoday")%></td>
                                <td><%# Eval("connectionstring_today_min").ToString()%>~<%# Eval("connectionstring_today_max").ToString() %></a> ��</td>
                                <td><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��</td>
                                <td><%# Eval("duration_today")%></td>
					            <td><%# Eval("duration_yestoday")%></td> 
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
     <!--�滻����-->
   </div>
    <!--</form>-->
</body>
</html>
