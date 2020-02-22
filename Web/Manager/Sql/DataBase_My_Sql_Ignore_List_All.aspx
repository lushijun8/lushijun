<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_My_Sql_Ignore_List_All.aspx.cs" Inherits="Web.Manager.Sql.DataBase_My_Sql_Ignore_List_All" %>

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
			<!--开始-->
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>查找：
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                <%-- <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=<%=Server.UrlEncode(this.P_orderby)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> --%>
	            <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=last_execution_time+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>最后执行时间</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=DATABASE_IP+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>数据库IP</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=DATABASE_USER+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>数据库用户</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=DATABASE_NAME+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>数据库名称</th>
			            <th> 
                            <a href="javascript:void(0)" onclick="javascript:showhide_td(this);" id="showhide_td">执行SQL＋＋＋</a>  
			            </th> 
                        <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=SQL_ERROR+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>漏洞与问题</th>
                        <th>忽略人</th>
                        <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=WebManager_name+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>负责人</th>
                        <th>认领</th>
                        <th>删除</th>
			            <th>长度</th> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=execution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>次</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_worker_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>占cpu(毫秒)</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_elapsed_time%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>执行(毫秒)</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_physical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>物理读(次)</th>
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_logical_reads%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>逻辑读(次)</th> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_logical_writes%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>逻辑写(次)</th> 
			            <th><a href="DataBase_My_Sql_Ignore_List_All.aspx?orderby=total_rows%2fexecution_count+DESC&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>" class="orderby">↓</a>影响(条)</th> 
			            <th>详情＋</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td width="120"<%# this.P_orderby.ToLower()=="last_ｅxecution_time desc"?" class=orderby":""%>><%# Eval("LAST_EXECUTION_TIME")%></td>
			                        <td<%# this.P_orderby.ToLower()=="database_ip desc"?" class=orderby":""%>><%# Eval("DATABASE_IP")%></td>
			                        <td<%# this.P_orderby.ToLower()=="database_user desc"?" class=orderby":""%>><%# Eval("DATABASE_USER")%></td>
			                        <td<%# this.P_orderby.ToLower()=="database_name desc"?" class=orderby":""%>><%# Eval("DATABASE_NAME")%></td>
			                        <td><div class="cell" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><%# Eval("TEXT_ANALYSIS")%></div></td>
                                    <td width="150" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');"><div class="cell"><span class=red><%# Eval("SQL_ERROR")%></span></div></td>
			                        <td><%# Eval("WebManager_RealName").ToString()%></td> 
			                        <td><%# Eval("WebManager_RealName_Charge").ToString()%></td> 
                                    <td><%# Eval("IsMy_Charge").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Delete.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Ignore_List_All.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('确定删除吗？')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Add.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),Encrypt_key)+"&BackUrl="+Server.UrlEncode(Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Ignore_List_All.aspx?keyword="+Server.UrlEncode(this.txtKeyword.Text)+"&orderby="+Server.UrlEncode(this.P_orderby))+"\" onclick=\"javascript:return confirm_me('确定认领吗？')\">认领</a>"%></td> 
                                    <td><%# Eval("IsMy_Ignore").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/Sql/DataBase_My_Sql_Ignore_Delete.aspx?Sql_Md5="+Com.Common.EncDec.Encrypt(Eval("sql_md5").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('确定删除吗？')\">删除</a>":"-"%></td> 
                                    <td><%# Eval("TEXT_ANALYSIS").ToString().Length%></td>
			                        <td<%# this.P_orderby.ToLower()=="ｅxecution_count desc"?" class=orderby":""%>><%# Eval("execution_count")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_worker_time/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_worker_time/execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_elapsed_time/ｅxecution_count desc"?" class=orderby":""%>><%# (Convert.ToDecimal(Eval("total_elapsed_time/execution_count").ToString())/1000).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_physical_reads/ｅxecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_physical_reads/execution_count").ToString()).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_reads/ｅxecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_logical_reads/execution_count").ToString()).ToString("f0")%></td>
			                        <td<%# this.P_orderby.ToLower()=="total_logical_writes/ｅxecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_logical_writes/execution_count").ToString()).ToString("f0")%></td>
                                    <td<%# this.P_orderby.ToLower()=="total_rows/ｅxecution_count desc"?" class=orderby":""%>><%# Convert.ToDecimal(Eval("total_rows/execution_count").ToString()).ToString("f0")%></td>
			                        <td><a href="javascript:void(0);" onclick="javascript:showhide('v_<%# Eval("sql_md5")%>');" id="s_v_<%# Eval("sql_md5")%>">详情<%# Container.ItemIndex==0?"＋":"＋"%></a></td>					           
				            </tr>
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("sql_md5")%>" style="display:none;background-color:lightblue;">
                                 <td colspan="19" style="border:1px solid #cccccc">
                                     <p><%# Eval("TEXT_ANALYSIS").ToString().Replace("\r\n","<br>").Replace("\t","&nbsp;")%></p> 
                                      <br />---------------------------------------------------------------------
                                     <br />(<b><%# Convert.ToDecimal(Eval("total_rows/execution_count").ToString()).ToString()%> 行受影响</b>)
                                     <br />逻辑读取 <%# Convert.ToDecimal(Eval("total_logical_reads/execution_count").ToString()).ToString("f0")%> 次，物理读取 <%# Convert.ToDecimal(Eval("total_physical_reads/execution_count").ToString()).ToString("f0")%> 次。

                                     <br />SQL Server 执行时间:
                                     <br />  CPU 时间 = <%# (Convert.ToDecimal(Eval("total_worker_time/execution_count").ToString())/1000).ToString("f0")%> 毫秒。

                                     <br />SQL Server 执行时间:
                                      <br /> CPU 时间 = <%# (Convert.ToDecimal(Eval("total_elapsed_time/execution_count").ToString())/1000).ToString("f0")%> 毫秒。
                                      <br />----------------------------------------------------------------------
                                     <br />(<b>漏洞与问题</b>)
                                     <br /><span class=red><%# Eval("SQL_ERROR")%></span>
                                     <br />----------------------------------<br />(<b>修改建议</b>)<br>1、尽量不要用LIKE模糊查询；<br>2、不要使用COUNT(*)，可以改成COUNT(1)，不然字段过多的话查询效率下降；<br>3、查询不能缺少WITH(NOLOCK)；<br>4、赋值请使用参数化，不然容易被攻击；<br>5、不要使用SELECT*，请写上明确的字段，不然字段过多的话查询效率下降；
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
