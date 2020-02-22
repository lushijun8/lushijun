<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task_List.aspx.cs" Inherits="Web.Manager.Task.Task_List" %>

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
                共查到<font color=red><%=this.LogCount.ToString() %></font>条记录,任务完成率 <font color=red><%=(this.LogCount_finished*100/(this.LogCount==0?1:this.LogCount)).ToString("f2") %>%</font> 。
                 <a class="<%=this.P_Task_Finished=="0"?"button":"button_off" %>" href="Task_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy) %>&Task_Finished=0">未完成</a> 
                <a class="<%=this.P_Task_Finished=="1"?"button":"button_off" %>" href="Task_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy) %>&Task_Finished=1">已完成</a> 
                <a class="<%=this.P_Task_Finished==""?"button":"button_off" %>" href="Task_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy) %>&Task_Finished=">全部</a>
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th>
			            <th><a href="Task_List.aspx?orderby=Task_CreateTime+desc" class="orderby">↓</a>分配时间</th>
			            <th><a href="Task_List.aspx?orderby=Task_WebManager_name+desc" class="orderby">↓</a>接收人</th>
			            <th>任务详情</th>
			            <th><a href="Task_List.aspx?orderby=Task_Finished+desc" class="orderby">↓</a>是否完成</th>
			            <th><a href="Task_List.aspx?orderby=Task_Finished_Time+desc" class="orderby">↓</a>完成时间</th>
			            <th><a href="Task_List.aspx?orderby=Task_WebManager_name_Finished+desc" class="orderby">↓</a>协助人</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# this._PageSize*(this.P_page-1)+ Container.ItemIndex+1%></td> 
                                <td><%# Eval("Task_CreateTime")%></td>
                                <td><%# Eval("WebManager_RealName")%></td> 
                                <td><%# Eval("Task_Remark")%></td> 
                                <td><%# Eval("Task_Finished").ToString()=="1"?"已完成":"<font color=red>未完成</font>"%></td> 
                                <td><%# Eval("Task_Finished_Time")%></td> 
                                <td><%# Eval("Task_WebManager_name_Finished")%></td> 
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
	  		<div class="Body_Pages"><%=this.outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
