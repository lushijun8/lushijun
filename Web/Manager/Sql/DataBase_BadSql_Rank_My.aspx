<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_BadSql_Rank_My.aspx.cs" Inherits="Web.Manager.Sql.DataBase_BadSql_Rank_My" %>

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
			<!--stats开始-->                 
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr> 
			            <th>序号</th>
			            <th>认领人</th>
			            <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=Lack_With_NoLock_Count+DESC" class="orderby">↓</a>缺少WITH(NOLOCK)</th> 
			            <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=Select_All_Count+DESC" class="orderby">↓</a>SELECT*</th> 
			            <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=Like_Count+DESC" class="orderby">↓</a>LIKE</th> 
			            <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=Lack_Parameter_Count+DESC" class="orderby">↓</a>赋值未参数化</th> 
			            <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=count_all+DESC" class="orderby">↓</a>COUNT(*)</th> 
                        <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=count_sum+DESC" class="orderby">↓</a>总问题数</th> 
		                <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=counts+DESC" class="orderby">↓</a>认领sql数</th> 
		                <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=BadRate+DESC" class="orderby">↓</a>问题率</th> 
		                <th><a href="DataBase_BadSql_Rank_My.aspx?orderby=WORKER_TIME+DESC" class="orderby">↓</a>平均耗时（秒）</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate> 
                           <tr class="<%# (Container.ItemIndex+1)%2==0?"b":""%><%# this.CurrentWebManagerRealName==Eval("WEBMANAGER_REALNAME").ToString()?" red":""%>">
			                    <td><%# Container.ItemIndex+1%></td>
			                    <td><%# Eval("WEBMANAGER_REALNAME")%></td>
			                    <td><%# Eval("Lack_With_NoLock_Count")%></td>
			                    <td><%# Eval("Select_All_Count")%></td>
			                    <td><%# Eval("Like_Count")%></td>
			                    <td><%# Eval("Lack_Parameter_Count")%></td>
			                    <td><%# Eval("count_all")%></td>
			                    <td><%# Eval("count_sum")%></td>
			                    <td><%# Eval("counts")%></td>
			                    <td><%# Eval("BadRate")%> %</td>
			                    <td><%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000000).ToString("f2").Replace(".00","")%></td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--stats结束-->
	  		</div> 
	  		<div class="Body_Pages"></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
    </form>
</body>
</html>
