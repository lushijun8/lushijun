<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job_List_SqlServer.aspx.cs" Inherits="Web.Manager.Job.Job_List_SqlServer" %>

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
     </script>
    <style type="text/css">
        .button {
            height: 21px;
        }
    </style>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
   <div class="Body_Content">
       <uc1:Menu ID="Menu1" runat="server" />
    <script language="javascript" type="text/javascript" src="<%=Business.Config.ResourcePath %>js/highcharts.js"></script> 
    <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">			
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>查找：
                 
                <asp:DropDownList ID="ddlDataBase" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server" Width="280px"></asp:TextBox>
                <asp:CheckBox ID="cbRun_Status" runat="server" Text="只显示报错的" />
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                 <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="Job_List_SqlServer.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&orderby=<%=Server.UrlEncode(this.P_orderby) %>&today=<%# Eval("Date")%>&DataBase=<%=Server.UrlEncode(this.ddlDataBase.SelectedItem.Value) %>&Run_Status=<%=(this.cbRun_Status.Checked == true ? "1" : "0")%>"><%# Eval("Date1")%></a>
			                </ItemTemplate>
		                </asp:Repeater>      
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th> 
			            <th>数据库</th>
			            <th>作业名称</th>
			            <th>详情</th>
			            <th>是否可用</th>
			            <th>步骤建立时间</th>
			            <th>步骤修改时间</th>
			            <th>执行状态</th>
			            <th>耗时(秒)</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# this._PageSize*(this.P_page-1)+ Container.ItemIndex+1%></td>  
                                <td><%# Eval("DataBase_IP")%>..<%# Eval("DataBase_Name")%></td>
			                    <td><%# Eval("name")%></td>
			                    <td>
                                    时间：<%# Eval("run_date").ToString().Substring(0,4)+"-"+Eval("run_date").ToString().Substring(4,2)+"-"+Eval("run_date").ToString().Substring(6,2)%> <%# Eval("run_time").ToString().Substring(0,2)+":"+Eval("run_time").ToString().Substring(2,2)+":"+Eval("run_time").ToString().Substring(4,2)%><br />
                                    序号：<%# Eval("step_id")%><br />
                                    步骤：<%# Eval("step_name")%><br />
                                    描述：<%#Eval("description")%><br />
                                    消息：<font color=red><%#Eval("message")%></font><br />
			                    </td>
			                    <td><%# Eval("enabled")%></td>
			                    <td><%# Eval("date_created")%></td>
			                    <td><%# Eval("date_modified")%></td>
			                    <td><img src="<%=Business.Config.HostUrl %>/images/<%# Eval("run_status").ToString()=="1"?"yes":"no"%>.gif" /></td>
			                    <td><%# Eval("run_duration")%></td>                              
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
