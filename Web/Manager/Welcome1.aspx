<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome1.aspx.cs" Inherits="Web.Manager.Welcome1" %>

<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��ӭ��¼<%=this.CurrentWebTitle %>��̨...</title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <%--<meta http-equiv="Expires" content="Mon, 23 Feb 2016 11:06:17 GM">--%>
    <script language="javascript">
        function confirm_me(pageurl)
        { 
            if (window.confirm("ȷ����?\r\n" + pageurl) == true)
            {
                return true;
            }
            return false;
        }
        function showhide(classname) {
            var ishidden=0;
            $("." + classname).each(function () {
                if ($(this).is(":hidden")) {
                    ishidden = 1;
                }
            }); 
            if (ishidden==0) {
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
   <div class="Body_PageContent Body_Content">
            <uc1:Menu ID="Menu1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td style="vertical-align:top" colspan="2">
              <asp:Repeater ID="rpt_database_sql_stats_sum_0" runat="server" EnableViewState="false">
			    <ItemTemplate>
				    <p>���7�������ҵ�SQL��<span class="red"><%# Eval("counts")%></span>��,<a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank.aspx?orderby=BadRate+ASC"><span class="red">ȱ��<%# Eval("Lack_With_NoLock_Count")%>��WITH(NOLOCK)</span> , <span class="red">��<%# Eval("Select_All_Count")%>��SELECT*</span>  ,  <span class="red">��<%# Eval("Like_Count")%>��LIKEģ����ѯ</span>  , <span class="black">��<%# Eval("Lack_Parameter_Count")%>����ֵδ������</span>  ,  <span class="red">��<%# Eval("Count_All")%>��Count(*)</span>  , <span class="red">������<%# Eval("BadRate")%> %</span> , SQL��д�淶����<span class="red">��<%=this.BadSql_Rank==-1?"?":this.BadSql_Rank.ToString() %>λ</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank.aspx?orderby=Worker_Time+ASC"><span class="red">ƽ����ʱ<%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%>��</span> , ��������<span class="red">��<%=this.Worker_Time_Rank==-1?"?":this.Worker_Time_Rank.ToString() %>λ</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List_LikeMine.aspx">���첢�Ż�</a></p> 
			    </ItemTemplate>
		    </asp:Repeater> 
                  
              <asp:Repeater ID="rpt_database_sql_stats_sum_1" runat="server" EnableViewState="false">
			    <ItemTemplate>
				    <p>ȫ�������������SQL��<span class="red"><%# Eval("counts")%></span>��,<a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank_My.aspx?orderby=BadRate+ASC"><span class="red">ȱ��<%# Eval("Lack_With_NoLock_Count")%>��WITH(NOLOCK)</span> , <span class="red">��<%# Eval("Select_All_Count")%>��SELECT*</span>  ,  <span class="red">��<%# Eval("Like_Count")%>��LIKEģ����ѯ</span>  , <span class="black">��<%# Eval("Lack_Parameter_Count")%>����ֵδ������</span> ,  <span class="red">��<%# Eval("Count_All")%>��Count(*)</span>  , <span class="red">������<%# Eval("BadRate")%> %</span> , SQL��д�淶����<span class="red">��<%=this.BadSql_Rank_My==-1?"?":this.BadSql_Rank_My.ToString() %>λ</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank_My.aspx?orderby=Worker_Time+ASC"><span class="red">ƽ����ʱ<%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%>��</span> �� ��������<span class="red">��<%=this.Worker_Time_Rank_My==-1?"?":this.Worker_Time_Rank_My.ToString() %>λ</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_My_Sql_List.aspx">�鿴���Ż�</a></p>
			    </ItemTemplate>
		    </asp:Repeater>
             
             <table border="0" cellspacing="0" cellpadding="0"  width="100%">
                 <%if(rpt_website_my_pageurl_my.Items.Count>0){ %>
                 <tr class="title">
                         <td colspan="8">
                             <b>���������ҳ�� ( Top 50 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=1">����...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>���
                                    </th> 
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
                                    <th>���Ӵ�ʹ�ô���(����)
                                    </th> 
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_website_my_pageurl_my" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_website_my_pageurl_my_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                      <td><%# Container.ItemIndex+1%>
                                    </td> 
                                      <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>"%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>    
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <%
                   } 
                   if (rpt_website_my_pageurl_my.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_website_my_pageurl_my_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>

                 <%if(rpt_website_my_pageurl_my_like.Items.Count>0){ %>
                 <tr class="title">
                         <td colspan="8">
                             <b>�����ҵ�ҳ��(������������)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx">����...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>���
                                    </th> 
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
                                    <th>���Ӵ�ʹ�ô���(����)
                                    </th> 
                                    <th>���Ӵ�ʹ�ô���(ǰһ��)
                                    </th> 
				                </tr>
                 <asp:Repeater  EnableViewState="false" ID="rpt_website_my_pageurl_my_like" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_website_my_pageurl_my_like_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                    <td>--
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td>
                                    </td> 
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a> "%>
                                       <%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Ignore_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a> "%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <%
                   }
                   if (rpt_website_my_pageurl_my_like.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_website_my_pageurl_my_like_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>
                  <tr class="title">
                         <td colspan="8">
                             <b>���ݿ����Ӵ�ʹ�ý�Ƶ����ҳ��( > 1�� , Top 50 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_min">����...</a></span>
                         </td>  
				     </tr>
                 
                  <%if (rpt_connectionstring_today.Items.Count > 0)
                    { %>
                  <tr>
                                    <th>���
                                    </th> 
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
                                    <th>���Ӵ�ʹ�ô���(����)
                                    </th> 
                                    <th>���Ӵ�ʹ�ô���(ǰһ��)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_today" runat="server">
			                <ItemTemplate>
				                 <tr class="<%# Container.ItemIndex>=5?"rpt_connectionstring_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                     <td><%# Container.ItemIndex+1%>
                                    </td>
                                     <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                   <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <%
                   }
                     if (rpt_connectionstring_today.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_connectionstring_today_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>
                 <%if (rpt_connectionstring_yestoday.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>���
                                    </th> 
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
                                    <th>���Ӵ�ʹ�ô���(����)
                                    </th> 
                                    <th>���Ӵ�ʹ�ô���(ǰһ��)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_yestoday" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_connectionstring_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                     <td><%# Container.ItemIndex+1%>
                                    </td>
                                    <td>
                                    ����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>                                     
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> ��
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> ��
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater> 
                 <%
                   }
                     if (rpt_connectionstring_yestoday.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_connectionstring_yestoday_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>
                 <tr class="title">
                         <td colspan="8">
                             <b>ִ��ʱ��ϳ�ҳ�� ( > 1�� , Top 50)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_min">����...</a></span>
                         </td>  
				 </tr>
                   <%if (rpt_duration_today.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>���
                                    </th> 
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
				               <tr class="<%# Container.ItemIndex>=5?"rpt_duration_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                   <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>  
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_today").ToString() %></a>
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_yestoday").ToString() %></a>
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>  
                 <%
                   }
                     if (rpt_duration_today.Items.Count > 5)
                   { %>               
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_duration_today_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>
                  <%if (rpt_duration_yestoday.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>���
                                    </th> 
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
				                <tr class="<%# Container.ItemIndex>=5?"rpt_duration_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                   <td><%# Container.ItemIndex+1%>
                                    </td>
                                    <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                   <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>  
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_today").ToString() %></a>
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_yestoday").ToString() %></a>
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>    
                 <%
                   }
                     if (rpt_duration_yestoday.Items.Count > 5)
                   { %>                              
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_duration_yestoday_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>
                 <tr class="title">
                         <td colspan="8">
                             <b>������ʽ�Ƶ����ҳ�� ( Top 50)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_today">����...</a></span>
                         </td>  
				 </tr>
                   <%if (rpt_request_count_today.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>���
                                    </th> 
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

		                <asp:Repeater  EnableViewState="false" ID="rpt_request_count_today" runat="server">
			                <ItemTemplate>
				               <tr class="<%# Container.ItemIndex>=5?"rpt_request_count_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                   <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>  
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_today").ToString() %></a>
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_yestoday").ToString() %></a>
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>      
                 <%
                   }
                     if (rpt_request_count_today.Items.Count > 5)
                   { %>                       
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_request_count_today_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>


                  <%if (rpt_request_count_yestoday.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>���
                                    </th> 
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

		                <asp:Repeater  EnableViewState="false" ID="rpt_request_count_yestoday" runat="server">
			                <ItemTemplate>
				               <tr class="<%# Container.ItemIndex>=5?"rpt_request_count_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                   <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>  
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_today").ToString() %></a>
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("duration_yestoday").ToString() %></a>
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>    
                 <%
                   }
                     if (rpt_request_count_yestoday.Items.Count > 5)
                   { %>                            
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_request_count_yestoday_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>

                 <tr class="title">
                         <td colspan="8">
                             <b>������־�϶��ҳ�� ( Top 50 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx">����...</a></span>
                         </td>  
				     </tr>
                   <%if(rpt_log_error_today.Items.Count>0){ %>
                  <tr>
                                    <th>���
                                    </th> 
                                    <th>����
                                    </th> 
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>�Ŷ�
                                    </th> 
                                    <th>����
                                    </th> 
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_log_error_today" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_log_error_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                      <td><%# Container.ItemIndex+1%>
                                    </td> 
                                      <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                         <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                     </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("log_count").ToString() %></a> ��
                                    </td> 
                                    <td>-
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>">���飫</a>
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <%
                   } 
                   if (rpt_log_error_today.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_log_error_today_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>
                 <%if(rpt_log_error_yestoday.Items.Count>0){ %>
                  <tr>
                                    <th>���
                                    </th> 
                                    <th>����
                                    </th> 
                                    <th>����ҳ��
                                    </th>  
                                    <th>������
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>����
                                    </th>  
                                    <th>�Ŷ�
                                    </th> 
                                    <th>����
                                    </th> 
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_log_error_yestoday" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_log_error_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                      <td><%# Container.ItemIndex+1%>
                                    </td> 
                                      <td>����
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"�ֻ���δ���ܣ�"+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>����ʱ�䣺"+Eval("Error_CreateTime").ToString()+"</p><p>���⣺"+Eval("Title").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>ip��"+Eval("ip").ToString()+"</p><p>username��"+Eval("username").ToString()+"</p><p>------------------------</p>������Ϣ��<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">ɾ��</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">����</a>"%>
                                     </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("log_count").ToString() %></a> ��
                                    </td> 
                                    <td>-
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>">���飫</a>
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <%
                   } 
                   if (rpt_log_error_yestoday.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_log_error_yestoday_tr_hide');">������������</a>
                     </td></tr>
                 <%}%>
                   <tr class="title">
                         <td colspan="8">
                             <b>��һ�� �����������ı� ( Top 10 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx">����...</a></span>
                         </td>  
				     </tr>
                 <tr>
                     <td colspan="8" style="padding:0px;">
                         <table border="0" cellspacing="0" cellpadding="0" width="100%">
                             <tr>
                                 <asp:Repeater  EnableViewState="false" ID="rpt_DataBase_Table_week_th" runat="server">
			                        <ItemTemplate>
                                            <th width="<%# 100/this.oDt_database_table.Rows.Count %>%">
                                               <img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx?Database_Name=<%# Eval("DATABASE_NAME").ToString() %>&orderby=RowCounts_Increasing_Week_rate">[<%# Eval("DATABASE_IP_ROMOTE").ToString() %>]..<%# Eval("DATABASE_NAME").ToString() %></a> ��һ��
                                            </th>  
			                        </ItemTemplate>
		                        </asp:Repeater>
                             </tr>
                             <tr>
                                 <asp:Repeater  EnableViewState="false" ID="rpt_DataBase_Table_week_td" runat="server">
			                        <ItemTemplate>
                                        <td valign="top" style="padding:0px;">
                                           <%# this.Get_DataBase_Table_List(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), Eval("DATABASE_NAME").ToString(),"_week",5) %>
                                         </td>
			                        </ItemTemplate>
		                        </asp:Repeater>
                             </tr>
                         </table>
                     </td>
                 </tr>
                 <tr class="title">
                         <td colspan="8">
                             <b>��һ�� �����������ı� ( Top 10 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx">����...</a></span>
                         </td>  
				     </tr>
                 <tr>
                     <td colspan="8" style="padding:0px;">
                         <table border="0" cellspacing="0" cellpadding="0" width="100%">
                             <tr>
                                 <asp:Repeater  EnableViewState="false" ID="rpt_DataBase_Table_month_th" runat="server">
			                        <ItemTemplate>
                                            <th width="<%# 100/this.oDt_database_table.Rows.Count %>%">
                                                 <img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx?Database_Name=<%# Eval("DATABASE_NAME").ToString() %>&orderby=RowCounts_Increasing_Month_rate">[<%# Eval("DATABASE_IP_ROMOTE").ToString() %>]..<%# Eval("DATABASE_NAME").ToString() %></a> ��һ��
                                            </th>  
			                        </ItemTemplate>
		                        </asp:Repeater>
                             </tr>
                             <tr>
                                 <asp:Repeater  EnableViewState="false" ID="rpt_DataBase_Table_month_td" runat="server">
			                        <ItemTemplate>
                                        <td valign="top" style="padding:0px;">
                                           <%# this.Get_DataBase_Table_List(System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), Eval("DATABASE_NAME").ToString(),"_month",5) %>
                                         </td>
			                        </ItemTemplate>
		                        </asp:Repeater>
                             </tr>
                         </table>
                     </td>
                 </tr>
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
                                       <a href="<%# Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_BackUp.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key) %>" target="_blank"><img src="<%=Business.Config.ResourcePath %>images/procviewfun.gif" style="vertical-align:middle"/></a>
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
                         <b>���ݿ����Ӵ�ʹ����� ( <%=this.ConnectString_Date_min %> �� <%=this.ConnectString_Date_max %> ������ )</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx">����...</a></span>
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
                                    <td><%# Eval("WebManager_RealName").ToString()+"  ["+Eval("ip").ToString()+"]" %>
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
                                <td><%# Eval("WebManager_RealName").ToString()+"["+Eval("create_ip").ToString()+"]"%>
                                </td> 
                                 <td>���� <%# Eval("servername").ToString().Split('_')[0] %> ����Ϊ</td>
                                 <td><%# Eval("decrypt_password").ToString()==""?"<a href=\""+Business.Config.HostUrl+"/Manager/Server/Server_Update_Password.aspx\">�鿴</a>":(this.CurrentWebManagerName==Eval("decrypt_username").ToString()?Eval("decrypt_password").ToString():"���� "+Eval("decrypt_username").ToString()+" Ҫ")%></td>
                                <td><%# Eval("create_time").ToString()%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>                 
               </td>
        </tr>
    </table>  
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="white-space:nowrap">
		            <%if (rptLog.Items.Count > 0)
                { %> <tr>
			            <th>���</th> 
			            <th>����ҳ��</th> 
                        <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=WebManager_Name" class="orderby">��</a>������</th>  
                        <th>����</th> 
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_today" class="orderby">��</a>�ô�(����)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_yestoday" class="orderby">��</a>�ô�(ǰһ��)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_min" class="orderby">��</a>�����Ӵ�ʹ�ô���(����)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_max" class="orderby">��</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_min" class="orderby">��</a>�����Ӵ�ʹ�ô���(ǰһ��)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_max" class="orderby">��</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_min" class="orderby">��</a>����ִ��ʱ��(��)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_max" class="orderby">��</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_min" class="orderby">��</a>����ִ��ʱ��(��)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_max" class="orderby">��</a></th>
		            </tr><%} %>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex+1%></td> 
					            <td><%# Eval("pageurl")%></td> 
                                <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
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
   </div>
    <!--</form>-->
</body>
</html>
