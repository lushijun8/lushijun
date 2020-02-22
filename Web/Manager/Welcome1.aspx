<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome1.aspx.cs" Inherits="Web.Manager.Welcome1" %>

<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>欢迎登录<%=this.CurrentWebTitle %>后台...</title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <%--<meta http-equiv="Expires" content="Mon, 23 Feb 2016 11:06:17 GM">--%>
    <script language="javascript">
        function confirm_me(pageurl)
        { 
            if (window.confirm("确定吗?\r\n" + pageurl) == true)
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
				    <p>最近7天疑似我的SQL共<span class="red"><%# Eval("counts")%></span>条,<a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank.aspx?orderby=BadRate+ASC"><span class="red">缺少<%# Eval("Lack_With_NoLock_Count")%>个WITH(NOLOCK)</span> , <span class="red">有<%# Eval("Select_All_Count")%>个SELECT*</span>  ,  <span class="red">有<%# Eval("Like_Count")%>个LIKE模糊查询</span>  , <span class="black">有<%# Eval("Lack_Parameter_Count")%>个赋值未参数化</span>  ,  <span class="red">有<%# Eval("Count_All")%>个Count(*)</span>  , <span class="red">问题率<%# Eval("BadRate")%> %</span> , SQL书写规范排名<span class="red">第<%=this.BadSql_Rank==-1?"?":this.BadSql_Rank.ToString() %>位</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank.aspx?orderby=Worker_Time+ASC"><span class="red">平均耗时<%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%>秒</span> , 性能排名<span class="red">第<%=this.Worker_Time_Rank==-1?"?":this.Worker_Time_Rank.ToString() %>位</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List_LikeMine.aspx">认领并优化</a></p> 
			    </ItemTemplate>
		    </asp:Repeater> 
                  
              <asp:Repeater ID="rpt_database_sql_stats_sum_1" runat="server" EnableViewState="false">
			    <ItemTemplate>
				    <p>全部我亲自认领的SQL共<span class="red"><%# Eval("counts")%></span>条,<a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank_My.aspx?orderby=BadRate+ASC"><span class="red">缺少<%# Eval("Lack_With_NoLock_Count")%>个WITH(NOLOCK)</span> , <span class="red">有<%# Eval("Select_All_Count")%>个SELECT*</span>  ,  <span class="red">有<%# Eval("Like_Count")%>个LIKE模糊查询</span>  , <span class="black">有<%# Eval("Lack_Parameter_Count")%>个赋值未参数化</span> ,  <span class="red">有<%# Eval("Count_All")%>个Count(*)</span>  , <span class="red">问题率<%# Eval("BadRate")%> %</span> , SQL书写规范排名<span class="red">第<%=this.BadSql_Rank_My==-1?"?":this.BadSql_Rank_My.ToString() %>位</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank_My.aspx?orderby=Worker_Time+ASC"><span class="red">平均耗时<%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%>秒</span> ， 性能排名<span class="red">第<%=this.Worker_Time_Rank_My==-1?"?":this.Worker_Time_Rank_My.ToString() %>位</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_My_Sql_List.aspx">查看并优化</a></p>
			    </ItemTemplate>
		    </asp:Repeater>
             
             <table border="0" cellspacing="0" cellpadding="0"  width="100%">
                 <%if(rpt_website_my_pageurl_my.Items.Count>0){ %>
                 <tr class="title">
                         <td colspan="8">
                             <b>我已认领的页面 ( Top 50 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=1">更多...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>序号
                                    </th> 
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
                                    <th>连接串使用次数(当天)
                                    </th> 
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_website_my_pageurl_my" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_website_my_pageurl_my_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                      <td><%# Container.ItemIndex+1%>
                                    </td> 
                                      <td>今天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>"%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>    
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <%
                   } 
                   if (rpt_website_my_pageurl_my.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_website_my_pageurl_my_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>

                 <%if(rpt_website_my_pageurl_my_like.Items.Count>0){ %>
                 <tr class="title">
                         <td colspan="8">
                             <b>疑似我的页面(如果不是请忽略)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_My_PageUrl_List.aspx">更多...</a></span>
                         </td>  
				     </tr>
                  <tr>
                                    <th>序号
                                    </th> 
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
                                    <th>连接串使用次数(当天)
                                    </th> 
                                    <th>连接串使用次数(前一天)
                                    </th> 
				                </tr>
                 <asp:Repeater  EnableViewState="false" ID="rpt_website_my_pageurl_my_like" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_website_my_pageurl_my_like_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                    <td>--
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td>
                                    </td> 
                                   <td><%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a> "%>
                                       <%# "<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Ignore_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">忽略</a> "%>
                                   </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <%
                   }
                   if (rpt_website_my_pageurl_my_like.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_website_my_pageurl_my_like_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>
                  <tr class="title">
                         <td colspan="8">
                             <b>数据库连接串使用较频繁的页面( > 1次 , Top 50 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_min">更多...</a></span>
                         </td>  
				     </tr>
                 
                  <%if (rpt_connectionstring_today.Items.Count > 0)
                    { %>
                  <tr>
                                    <th>序号
                                    </th> 
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
                                    <th>连接串使用次数(当天)
                                    </th> 
                                    <th>连接串使用次数(前一天)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_today" runat="server">
			                <ItemTemplate>
				                 <tr class="<%# Container.ItemIndex>=5?"rpt_connectionstring_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                     <td><%# Container.ItemIndex+1%>
                                    </td>
                                     <td>今天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                   <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                 <%
                   }
                     if (rpt_connectionstring_today.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_connectionstring_today_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>
                 <%if (rpt_connectionstring_yestoday.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>序号
                                    </th> 
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
                                    <th>连接串使用次数(当天)
                                    </th> 
                                    <th>连接串使用次数(前一天)
                                    </th> 
				                </tr>
		                <asp:Repeater  EnableViewState="false" ID="rpt_connectionstring_yestoday" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_connectionstring_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                     <td><%# Container.ItemIndex+1%>
                                    </td>
                                    <td>
                                    昨天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
                                    </td> 
                                    <td><%# Eval("request_count_today").ToString()%>
                                    </td>                                     
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_today_min").ToString() %>~<%# Eval("connectionstring_today_max").ToString() %></a> 次
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("connectionstring_yestoday_min").ToString()%>~<%# Eval("connectionstring_yestoday_max").ToString() %></a> 次
                                    </td> 
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater> 
                 <%
                   }
                     if (rpt_connectionstring_yestoday.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_connectionstring_yestoday_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>
                 <tr class="title">
                         <td colspan="8">
                             <b>执行时间较长页面 ( > 1秒 , Top 50)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_min">更多...</a></span>
                         </td>  
				 </tr>
                   <%if (rpt_duration_today.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>序号
                                    </th> 
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
				               <tr class="<%# Container.ItemIndex>=5?"rpt_duration_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                   <td>今天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
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
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_duration_today_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>
                  <%if (rpt_duration_yestoday.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>序号
                                    </th> 
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
				                <tr class="<%# Container.ItemIndex>=5?"rpt_duration_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                   <td><%# Container.ItemIndex+1%>
                                    </td>
                                    <td>昨天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                   <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
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
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_duration_yestoday_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>
                 <tr class="title">
                         <td colspan="8">
                             <b>请求访问较频繁的页面 ( Top 50)</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_today">更多...</a></span>
                         </td>  
				 </tr>
                   <%if (rpt_request_count_today.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>序号
                                    </th> 
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

		                <asp:Repeater  EnableViewState="false" ID="rpt_request_count_today" runat="server">
			                <ItemTemplate>
				               <tr class="<%# Container.ItemIndex>=5?"rpt_request_count_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                   <td>今天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
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
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_request_count_today_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>


                  <%if (rpt_request_count_yestoday.Items.Count > 0)
                    { %>
                 <tr>
                                    <th>序号
                                    </th> 
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

		                <asp:Repeater  EnableViewState="false" ID="rpt_request_count_yestoday" runat="server">
			                <ItemTemplate>
				               <tr class="<%# Container.ItemIndex>=5?"rpt_request_count_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                    <td><%# Container.ItemIndex+1%>
                                    </td>
                                   <td>昨天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?today=<%=this.today %>&page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString())%>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>   
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
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
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_request_count_yestoday_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>

                 <tr class="title">
                         <td colspan="8">
                             <b>报错日志较多的页面 ( Top 50 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx">更多...</a></span>
                         </td>  
				     </tr>
                   <%if(rpt_log_error_today.Items.Count>0){ %>
                  <tr>
                                    <th>序号
                                    </th> 
                                    <th>日期
                                    </th> 
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>  
                                    <th>报错
                                    </th>  
                                    <th>团队
                                    </th> 
                                    <th>详情
                                    </th> 
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_log_error_today" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_log_error_today_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                      <td><%# Container.ItemIndex+1%>
                                    </td> 
                                      <td>今天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                         <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
                                     </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("log_count").ToString() %></a> 次
                                    </td> 
                                    <td>-
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>">详情＋</a>
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <%
                   } 
                   if (rpt_log_error_today.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_log_error_today_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>
                 <%if(rpt_log_error_yestoday.Items.Count>0){ %>
                  <tr>
                                    <th>序号
                                    </th> 
                                    <th>日期
                                    </th> 
                                    <th>请求页面
                                    </th>  
                                    <th>负责人
                                    </th>  
                                    <th>认领
                                    </th>  
                                    <th>报错
                                    </th>  
                                    <th>团队
                                    </th> 
                                    <th>详情
                                    </th> 
				                </tr>
                  <asp:Repeater  EnableViewState="false" ID="rpt_log_error_yestoday" runat="server">
			                <ItemTemplate>
				                <tr class="<%# Container.ItemIndex>=5?"rpt_log_error_yestoday_tr_hide":"" %> <%#(Container.ItemIndex+1)%2==0?" b":"" %>" <%# Container.ItemIndex>=5?" style=\"display:none\"":"" %>>
                                      <td><%# Container.ItemIndex+1%>
                                    </td> 
                                      <td>昨天
                                    </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("pageurl").ToString()%> <%# Eval("querystring_Phone_Encrypt").ToString()=="0"|| Eval("form_Phone_Encrypt").ToString()=="0"?"<span class=\"phone_tooltip\" titles=\"手机号未加密："+(Eval("querystring_Phone_Encrypt").ToString()=="0"?Eval("querystring").ToString().Replace("\"","'"):Eval("form").ToString().Replace("\"","'"))+"<br/><br/>\"></span>":""%>
                                        <%# (Eval("Content").ToString()+Eval("Remarks").ToString()).Trim()!=""?"<span class=\"bug_tooltip\" titles=\"<p>报错时间："+Eval("Error_CreateTime").ToString()+"</p><p>标题："+Eval("Title").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>ip："+Eval("ip").ToString()+"</p><p>username："+Eval("username").ToString()+"</p><p>------------------------</p>报错信息：<p>Content:<br />"+Eval("Content").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><p>Remarks:<br />"+Eval("Remarks").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;").Replace("\"","'")+"</p><br/>\"></span>":""%></a>
                                        <%# Eval("Depend_PageUrl").ToString()!=""?"<span class=\"depend_tooltip\" titles=\""+Eval("Depend_PageUrl").ToString().Replace("\"","'")+"\"></span>":"" %></a>
                                    </td>    
                                    <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                    <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Welcome.aspx")+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%>
                                     </td> 
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>"><%# Eval("log_count").ToString() %></a> 次
                                    </td> 
                                    <td>-
                                    </td>   
                                    <td><a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Error_List.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("pageurl").ToString()) %>">详情＋</a>
                                    </td>  
				                </tr>
			                </ItemTemplate>
		                </asp:Repeater>
                  <%
                   } 
                   if (rpt_log_error_yestoday.Items.Count > 5)
                   { %>
                 <tr><td colspan="8" style="text-align:center">
                     <a href="javascript:void(0);" onclick="javascript:showhide('rpt_log_error_yestoday_tr_hide');">。。。。。。</a>
                     </td></tr>
                 <%}%>
                   <tr class="title">
                         <td colspan="8">
                             <b>近一周 数据增长最快的表 ( Top 10 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx">更多...</a></span>
                         </td>  
				     </tr>
                 <tr>
                     <td colspan="8" style="padding:0px;">
                         <table border="0" cellspacing="0" cellpadding="0" width="100%">
                             <tr>
                                 <asp:Repeater  EnableViewState="false" ID="rpt_DataBase_Table_week_th" runat="server">
			                        <ItemTemplate>
                                            <th width="<%# 100/this.oDt_database_table.Rows.Count %>%">
                                               <img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx?Database_Name=<%# Eval("DATABASE_NAME").ToString() %>&orderby=RowCounts_Increasing_Week_rate">[<%# Eval("DATABASE_IP_ROMOTE").ToString() %>]..<%# Eval("DATABASE_NAME").ToString() %></a> 近一周
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
                             <b>近一月 数据增长最快的表 ( Top 10 )</b>  <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx">更多...</a></span>
                         </td>  
				     </tr>
                 <tr>
                     <td colspan="8" style="padding:0px;">
                         <table border="0" cellspacing="0" cellpadding="0" width="100%">
                             <tr>
                                 <asp:Repeater  EnableViewState="false" ID="rpt_DataBase_Table_month_th" runat="server">
			                        <ItemTemplate>
                                            <th width="<%# 100/this.oDt_database_table.Rows.Count %>%">
                                                 <img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> <a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Table_List.aspx?Database_Name=<%# Eval("DATABASE_NAME").ToString() %>&orderby=RowCounts_Increasing_Month_rate">[<%# Eval("DATABASE_IP_ROMOTE").ToString() %>]..<%# Eval("DATABASE_NAME").ToString() %></a> 近一月
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
                         <b>数据库说明文档</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Owner_List.aspx">更多...</a></span>
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
                         <b>数据库连接串使用情况 ( <%=this.ConnectString_Date_min %> 至 <%=this.ConnectString_Date_max %> 的数据 )</b> <span style="float:right"><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log.aspx">更多...</a></span>
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
                                    <td><%# Eval("WebManager_RealName").ToString()+"  ["+Eval("ip").ToString()+"]" %>
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
                                <td><%# Eval("WebManager_RealName").ToString()+"["+Eval("create_ip").ToString()+"]"%>
                                </td> 
                                 <td>更新 <%# Eval("servername").ToString().Split('_')[0] %> 密码为</td>
                                 <td><%# Eval("decrypt_password").ToString()==""?"<a href=\""+Business.Config.HostUrl+"/Manager/Server/Server_Update_Password.aspx\">查看</a>":(this.CurrentWebManagerName==Eval("decrypt_username").ToString()?Eval("decrypt_password").ToString():"请找 "+Eval("decrypt_username").ToString()+" 要")%></td>
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
			            <th>序号</th> 
			            <th>请求页面</th> 
                        <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=WebManager_Name" class="orderby">↓</a>负责人</th>  
                        <th>操作</th> 
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_today" class="orderby">↓</a>访次(当天)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=request_count_yestoday" class="orderby">↓</a>访次(前一天)</th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_min" class="orderby">↓</a>总连接串使用次数(当天)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_today_max" class="orderby">↓</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_min" class="orderby">↓</a>总连接串使用次数(前一天)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=connectionstring_yestoday_max" class="orderby">↓</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_min" class="orderby">↓</a>今日执行时间(秒)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_today_max" class="orderby">↓</a></th>
			            <th><a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_min" class="orderby">↓</a>昨日执行时间(秒)<a href="<%=Business.Config.HostUrl %>/Manager/DataBase/DataBase_Connect_log_Stats.aspx?orderby=duration_yestoday_max" class="orderby">↓</a></th>
		            </tr><%} %>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# Container.ItemIndex+1%></td> 
					            <td><%# Eval("pageurl")%></td> 
                                <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_List_All.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
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
   </div>
    <!--</form>-->
</body>
</html>
