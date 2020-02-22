<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Sql_List_LikeMine.aspx.cs" Inherits="Web.Manager.Sql.DataBase_Sql_List_LikeMine" %>

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
    <script language="javascript" src="<%=Business.Config.ResourcePath %>js/DateSelect.js?Version=<%=Business.Config.Version %>"></script>    
    <script language="javascript">
        function confirm_me(pageurl) {
            if (window.confirm("确定吗?\r\n" + pageurl) == true) {
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
                $("#s_" + id).text("详情＋");
            }
            else {
                $("#" + id).show();
                $("#s_" + id).text("详情－");
            }
        }
        function showhide_td() {
            if ($("#showhide_td").text() == "执行SQL＋＋＋") {

                $(".cell").css("overflow", "visible");
                $(".cell").css("height", "auto");
                $(".cell").css("white-space", "pre-wrap");
                $("#showhide_td").text("执行SQL－－－");
            }
            else {
                $(".cell").css("overflow", "hidden");
                $(".cell").css("height", "20px");
                $(".cell").css("white-space", "normal");
                $("#showhide_td").text("执行SQL＋＋＋");
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
                共查到<font color=red><%=this.LogCount.ToString() %></font>条记录,<asp:Repeater ID="rpt_database_sql_stats_sum" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                本周疑似我的SQL中：<a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank.aspx?orderby=BadRate+ASC"><span class="red">缺少<%# Eval("Lack_With_NoLock_Count")%>个WITH(NOLOCK)</span> , <span class="red">有<%# Eval("Select_All_Count")%>个SELECT*</span>  ,  <span class="red">有<%# Eval("Like_Count")%>个LIKE模糊查询</span>  , <span class="black">有<%# Eval("Lack_Parameter_Count")%>个赋值未参数化</span>  ,  <span class="red">有<%# Eval("Count_All")%>个Count(*)</span>  , <span class="red">问题率<%# Eval("BadRate")%> %</span> , SQL书写规范排名<span class="red">第<%=this.BadSql_Rank==-1?"?":this.BadSql_Rank.ToString() %>位</span></a> , <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_BadSql_Rank.aspx?orderby=Worker_Time+ASC"><span class="red">平均耗时<%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%>秒</span> , 性能排名<span class="red">第<%=this.Worker_Time_Rank==-1?"?":this.Worker_Time_Rank.ToString() %>位</span></a>
			                </ItemTemplate>
		                </asp:Repeater> 。
                 <p>&nbsp;</p> <a <%= this.P_Bug_Type=="0"?"class=button":"class=button_off"%> href="DataBase_Sql_List_LikeMine.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&Bug_Type=0">缺少WITH(NOLOCK)</a>
                      <a <%= this.P_Bug_Type=="1"?"class=button":"class=button_off"%> href="DataBase_Sql_List_LikeMine.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&Bug_Type=1">SELECT*</a>
                      <a <%= this.P_Bug_Type=="2"?"class=button":"class=button_off"%> href="DataBase_Sql_List_LikeMine.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&Bug_Type=2">LIKE</a>
                      <a <%= this.P_Bug_Type=="3"?"class=button":"class=button_off"%> href="DataBase_Sql_List_LikeMine.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&Bug_Type=3">赋值未参数化</a>
                      <a <%= this.P_Bug_Type=="4"?"class=button":"class=button_off"%> href="DataBase_Sql_List_LikeMine.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&Bug_Type=4">COUNT(*)</a>
                      <a <%= this.P_Bug_Type=="5"?"class=button":"class=button_off"%> href="DataBase_Sql_List_LikeMine.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&Bug_Type=5">读写权限未分开</a>
                      <a <%= this.P_Bug_Type==""?"class=button":"class=button_off"%> href="DataBase_Sql_List_LikeMine.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&Bug_Type=">全部</a>
                  
                 <p>&nbsp;</p>
		                
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr> 
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=last_execution_time+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>最后执行时间</th>
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=DATABASE_IP+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>数据库IP</th>
                        <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=DATABASE_USER+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>数据库用户</th>
                        <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=DATABASE_NAME+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>数据库名称</th>
			            <th> 
                            <a href="javascript:void(0)" onclick="javascript:showhide_td();" id="showhide_td">执行SQL＋＋＋</a>  
			            </th> 
                        <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=SQL_ERROR+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>漏洞与问题</th>
                        <th>疑似负责人</th>
                        <th>操作</th>
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=len(text)+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>长度</th> 
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=execution_count+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>执行<br />(次)</th>
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=total_worker_time%2fexecution_count+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>占cpu<br />(毫秒)</th>
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=total_elapsed_time%2fexecution_count+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>执行<br />(毫秒)</th>
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=total_physical_reads%2fexecution_count+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>物理读<br />(次)</th>
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=total_logical_reads%2fexecution_count+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>逻辑读<br />(次)</th> 
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=total_logical_writes%2fexecution_count+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>逻辑写<br />(次)</th> 
			            <th><a href="DataBase_Sql_List_LikeMine.aspx?orderby=total_rows%2fexecution_count+DESC&Bug_Type=<%=this.P_Bug_Type%>" class="orderby">↓</a>影响<br />(条)</th> 
                        <%# Eval("Date")%>
                        <th>详情＋</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td width="120"><%# Eval("LAST_EXECUTION_TIME")%></td>
			                        <td><%# Eval("DATABASE_IP")%></td>
			                        <td<%# (Eval("ISWRONGDATABASEUSER").ToString()=="1"&&Eval("ISRUNTIMESQL").ToString()=="1")?" class=wronguser":""%>><%# Eval("DATABASE_USER")%></td>
			                        <td><%# Eval("DATABASE_NAME")%></td>
			                        <td><div class="cell" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><%# Eval("TEXT_ANALYSIS")%></div></td>
			                         <td width="150" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><div class="cell"><span class=red><%# Eval("SQL_ERROR")%></span></div></td>
			                       <td><%# Eval("SEEMLIKE_WEBMANAGER_REALNAME").ToString()%></td> 
                                    <td>
                                        <a href="<%# Business.Config.HostUrl%>/Manager/Sql/DataBase_My_Sql_Add.aspx?Sql_Md5=<%# Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)%>" onclick="javascript:return confirm_me('确定认领吗？')">认领</a>
                                        <a href="<%# Business.Config.HostUrl%>/Manager/Sql/DataBase_My_Sql_Ignore_Add.aspx?Sql_Md5=<%# Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)%>" onclick="javascript:return confirm_me('确定忽略吗？')">忽略</a>
                                    </td> 
                                    <td<%# this.P_orderby.ToLower()=="len(text) desc"?" class=orderby":""%>><%# Eval("TEXT").ToString().Length%></td>
			                        <td<%# this.P_orderby.ToLower()=="ｅxecution_count desc"?" class=orderby":""%>><%# Eval("execution_count")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_worker_time/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_worker_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_elapsed_time/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_elapsed_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_physical_reads/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_physical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_reads/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_logical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_writes/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_logical_writes").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
                                    <td<%# this.P_orderby.ToLower()=="total_rows/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_rows").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%></td>
			                        <%--<td><%# Eval("SQL_ERROR")%></td>--%>
                                    <td><a href="javascript:void(0);" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');" id="s_v_<%# Eval("sql_md5")%>">详情<%# Container.ItemIndex==0?"＋":"＋"%></a></td>					           
				            </tr>
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("sql_md5")%>" style="display:none;background-color:lightblue;">
                                 <td colspan="17" style="border:1px solid #cccccc">
                                     <p><%# Eval("TEXT_ANALYSIS").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;")%></p> 
                                      <br />---------------------------------------------------------------------
                                     <br />(<b><%# (Convert.ToDecimal(Eval("total_rows").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString()%>行受影响</b>)
                                     <br />逻辑读取 <%# (Convert.ToDecimal(Eval("total_logical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%> 次，物理读取 <%# (Convert.ToDecimal(Eval("total_physical_reads").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())).ToString("f0")%> 次。

                                     <br />SQL Server 执行时间:
                                     <br />  CPU 时间 = <%# (Convert.ToDecimal(Eval("total_worker_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%> 毫秒。

                                     <br />SQL Server 执行时间:
                                      <br /> CPU 时间 = <%# (Convert.ToDecimal(Eval("total_elapsed_time").ToString())/Convert.ToDecimal(Eval("execution_count").ToString())/1000).ToString("f0")%> 毫秒。
                                     <br />----------------------------------------------------------------------
                                     <br />(<b>漏洞与问题</b>)
                                     <br /><span class=red><%# Eval("SQL_ERROR")%></span>
                                     <br />
                                     <%# Eval("PageUrl").ToString()=="" ?"":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_PageUrl.aspx?keyword="+Server.UrlEncode(Eval("PageUrl").ToString())+"\" target=_blank>"+Eval("PageUrl").ToString()+"</a> "+( Eval("IsMyUrl").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除认领</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领此URL</a>")%>
                                       
                                 </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
	  		<div class="Body_Pages">
                  <%=this.outPage %>
	  		</div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
    <script language="javascript">
        //showhide_td();
    </script>
</body>
</html>