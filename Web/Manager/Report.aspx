<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Web.Manager.Report" EnableViewState="false" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>欢迎登录TeamTool后台...</title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <base target="_blank" />
    <script language="javascript">
        function confirm_me(pageurl) {
            if (window.confirm("确定吗?\r\n" + pageurl) == true) {
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
    <h2>大家看见自己负责的页面请及时认领,主要是为了发现问题能及时找到对应的负责人,谢谢！</h2>
   <div class="Body_PageContent"> 
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td style="vertical-align:top" colspan="2">
             <table border="0" cellspacing="0" cellpadding="0"  width="100%">
                 <%if(rpt_website_my_pageurl_my.Items.Count>0){ %>
                 <tr>
                         <td colspan="7">
                             <b><%=this.CurrentWebManagerName %> 已认领的页面 ( Top 5 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx">更多...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>日期
                                    </th> 
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>  
                                    <th>访次
                                    </th>  
                                    <th>连接次数(当天)
                                    </th> 
                                    <th>连接次数(前一天)
                                    </th> 
				                </tr>
                 <%} %>
                  <asp:Repeater  EnableViewState="false" ID="rpt_website_my_pageurl_my" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>今天
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>"%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <%if(rpt_website_my_pageurl_my_like.Items.Count>0){ %>
                 <tr>
                         <td colspan="7">
                             <b>疑似 <%=this.CurrentWebManagerName %> 的页面(如果不是请忽略)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx">更多...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>日期
                                    </th> 
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>  
                                    <th>访次
                                    </th>  
                                    <th>连接次数(当天)
                                    </th> 
                                    <th>连接次数(前一天)
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
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a> "%>
                                       <%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Ignore_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">忽略</a> "%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次
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
                             <b>数据库连接串使用较频繁的页面( > 1次 , Top 5 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx">更多...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>日期
                                    </th> 
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>  
                                    <th>访次
                                    </th>  
                                    <th>连接次数(当天)
                                    </th> 
                                    <th>连接次数(前一天)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_today" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>今天
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                   <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <tr>
                                    <th>日期
                                    </th> 
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>  
                                    <th>访次
                                    </th>  
                                    <th>连接次数(当天)
                                    </th> 
                                    <th>连接次数(前一天)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_yestoday" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>
                                    昨天
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>                                     
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <tr>
                         <td colspan="7">
                             <b>执行时间较长页面 ( > 1秒 , Top 5)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx">更多...</a></span>
                         </td>  
				     </tr>
                 <tr>
                                    <th>日期
                                    </th>
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>
                                    <th>访次
                                    </th>  
                                    <th>执行秒数(当天)
                                    </th> 
                                    <th>执行秒数(前一天)
                                    </th>
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_duration_today" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td>今天
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
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
                                    <th>日期
                                    </th>
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>
                                    <th>访次
                                    </th>  
                                    <th>执行秒数(当天)
                                    </th> 
                                    <th>执行秒数(前一天)
                                    </th>
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_duration_yestoday" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>> 
                                    <td>昨天
                                    </td> 
                                    <td><%# Eval("pageurl").ToString()%>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString()%>
                                    </td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
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
                         <b>数据库说明文档</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_List.aspx">更多...</a></span>
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
                         <b>数据库连接串使用情况 ( <%=this.ConnectString_Date %> 以来的数据 )</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx">更多...</a></span>
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
                                    今日<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx"><%# Eval("DataBase_Connect_Times_Today") %></a>次
                                </td>  
                                <td>
                                    总 <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx"><%# Eval("DataBase_Connect_Times") %></a> 次
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
                             <b>局域网服务器使用情况</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/Server/Server_Update_Log.aspx">更多...</a></span>
                         </td>  
				     </tr>
		                <asp:Repeater  EnableViewState="false" ID="rptServerUpdateLog" runat="server">
			                <ItemTemplate>
				                <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                    <td><%# Eval("username").ToString()+"  ["+Eval("ip").ToString()+"]" %>
                                    </td> 
                                    <td>更新了
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
                         <b>局域网服务器密码跟踪</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/Server/Server_Update_Password.aspx">更多...</a></span>
                     </td>  
				 </tr>
		            <asp:Repeater  EnableViewState="false" ID="rptServerUpdatePassword" runat="server">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# Eval("create_username").ToString()+"["+Eval("create_ip").ToString()+"]"%>
                                </td> 
                                 <td>更新 <%# Eval("servername").ToString().Split('_')[0] %> 密码为</td>
                                 <td>**** <%# "<a href=\""+Business.Config.HostUrl+"/Manager/Server/Server_Update_Password.aspx\">查看</a>"%></td>
                                <td><%# Eval("create_time").ToString()%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>                 
               </td>
        </tr>
    </table>  
       &nbsp;&nbsp;<b>效率最差综合排行</b>
       <table border="0" cellspacing="0" cellpadding="0">
		            <tr>
			            <th>序号</th> 
			            <th>请求页面</th> 
                        <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=WebManager_Name" class="orderby">↓</a>负责人</th>  
                        <th>认领</th> 
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_today" class="orderby">↓</a>访次(当天)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_yestoday" class="orderby">↓</a>访次(前一天)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_min" class="orderby">↓</a>总连接次数(当天)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_max" class="orderby">↓</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_min" class="orderby">↓</a>总连接次数(前一天)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_max" class="orderby">↓</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_min" class="orderby">↓</a>今日执行时间(秒)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_max" class="orderby">↓</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_min" class="orderby">↓</a>昨日执行时间(秒)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_max" class="orderby">↓</a></th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex+1%></td> 
					            <td><%# Eval("pageurl")%></td> 
                                <td><%# Eval("WebManager_Name").ToString()%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log_Stats.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/DataBase/DataBase_Connect_log_Stats.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%></td> 
					            <td><%# Eval("request_count_today")%></td>
					            <td><%# Eval("request_count_yestoday")%></td>
                                <td><%# Eval("connectionstring_today_min").ToString()%>~<%# Eval("connectionstring_today_max").ToString() %></a> 次</td>
                                <td><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次</td>
                                <td><%# Eval("duration_today")%></td>
					            <td><%# Eval("duration_yestoday")%></td> 
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
     <!--替换内容-->
   </div>
    <!--</form>-->
</body>
</html>
