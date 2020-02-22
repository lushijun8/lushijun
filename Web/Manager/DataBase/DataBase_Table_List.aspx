<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Table_List.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Table_List" %>

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
                共查到<font color=red><%=LogCount.ToString() %></font>条记录。<br/>
                表名：<asp:TextBox ID="txtKeyword" runat="server" Width="166px"></asp:TextBox>
                日期：<asp:TextBox ID="txtToday" runat="server" Width="85px"  onfocus="javascript:ShowCalendar(this.id)"></asp:TextBox>
                 
                服务器：<asp:DropDownList ID="ddl_DataBase_Ip_Romote" runat="server">
                </asp:DropDownList>
                 
                数据库：<asp:DropDownList ID="ddl_DataBase_Name" runat="server">
                </asp:DropDownList>
                 
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                   <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="DataBase_Table_List.aspx?orderby=<%=Server.UrlEncode(this.P_OrderBy)%>&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater> 
                <!--stats开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" style="white-space:nowrap">
		            <tr>
			            <th>序号</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=DataBase_Name&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>数据库</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=Table_Name&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>表名称</th> 
			            <th>认领人</th>
                        <th>操作</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=CountDate&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>日期</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=ColumnCounts&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>列数</th>
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>记录数(当天)</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长数(当天)</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing_Rate&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长率(当天)</th>  
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing_Week&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长数(本周)</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing_Week_Rate&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长率(本周)</th>  
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing_Month&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长数(本月)</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing_Month_Rate&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长率(本月)</th>  
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing_Year&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长数(本年)</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=RowCounts_Increasing_Year_Rate&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>增长率(本年)</th> 

                        
			            <th><a href="DataBase_Table_List.aspx?orderby=Space_Allocation&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>保留空间</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=Space_Used&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>使用空间</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=Space_Index_Used&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>索引使用空间</th> 
			            <th><a href="DataBase_Table_List.aspx?orderby=Space_Available&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=Server.UrlEncode(this.txtToday.Text) %>&DataBase_Ip_Romote=<%=Server.UrlEncode(this.ddl_DataBase_Ip_Romote.SelectedValue) %>&DataBase_Name=<%=Server.UrlEncode(this.ddl_DataBase_Name.SelectedValue) %>" class="orderby">↓</a>未用空间</th> 
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
					            <td><%# (Container.ItemIndex+1)+(P_page-1)*20%></td> 
					            <td<%# this.P_OrderBy.ToLower()=="database_name"?" class=orderby":""%>>
                                     <img src="<%=Business.Config.ResourcePath %>images/db.gif" style="vertical-align:middle"/> 
                                        <%# Eval("DataBase_Id").ToString()==""?"":
                                        "<a title=\""+Eval("DataBase_Remark").ToString()+"\" href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)+"\" target=\"_blank\">"
                                        %>
                                        [<%# Eval("DataBase_IP_Romote") %>]..[<%# Eval("DataBase_Name") %>]
                                     <%# Eval("DataBase_Id").ToString()==""?"":"</a>" %>

					            </td> 
			                    <td<%# this.P_OrderBy.ToLower()=="table_name"?" class=orderby":""%>><%# Eval("DataBase_Id").ToString()==""?"":
                                        "<a href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Owner_Description.aspx?DataBase_Id="+ Com.Common.EncDec.Encrypt( Eval("DataBase_Id").ToString()+","+System.DateTime.Now.ToString(),this.Encrypt_key)+"#"+Eval("Table_Name").ToString()+"\" target=\"_blank\">"
                                        %>
                                    <%# Eval("Table_Name")%> <span class="indexs_tooltip <%# Eval("DataBase_Name").ToString()+"_"+Eval("Table_Name").ToString()%>" id="<%# Eval("DataBase_Name").ToString()+"."+Eval("Table_Name").ToString()%>"></span></td> 
                                     <%# Eval("DataBase_Id").ToString()==""?"":"</a>" %>
			                    
                                <td><%# Eval("WebManager_RealName").ToString().Replace(",","<br>")%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Table_My_Delete.aspx?v="+Com.Common.EncDec.Encrypt(Eval("DataBase_Name").ToString()+","+Eval("Table_Name").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('删除认领?')\">删除认领</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Table_My_Add.aspx?v="+Com.Common.EncDec.Encrypt(Eval("DataBase_Name").ToString()+","+Eval("Table_Name").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('认领?')\">认领</a>"%></td> 
			                    <td<%# this.P_OrderBy.ToLower()=="countdate"?" class=orderby":""%>><%# Convert.ToDateTime(Eval("CountDate").ToString()).ToShortDateString()%></td> 
			                    <td<%# this.P_OrderBy.ToLower()=="columncounts"?" class=orderby":""%>><%# Eval("ColumnCounts")%></td>
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts"?" class=orderby":""%>><%# Eval("RowCounts")%></td> 
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing"?" class=orderby":""%>><%# Eval("RowCounts_Increasing")%></td> 
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing_rate"?" class=orderby":""%>><font color=red><%# Convert.ToDouble(Eval("RowCounts_Increasing_Rate").ToString()).ToString("f2")%></font> %</td> 
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing_week"?" class=orderby":""%>><%# Eval("RowCounts_Increasing_Week")%></td>  
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing_week_rate"?" class=orderby":""%>><font color=red><%# Convert.ToDouble(Eval("RowCounts_Increasing_Week_Rate").ToString()).ToString("f2")%></font> %</td> 
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing_month"?" class=orderby":""%>><%# Eval("RowCounts_Increasing_Month")%></td>  
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing_month_rate"?" class=orderby":""%>><font color=red><%# Convert.ToDouble(Eval("RowCounts_Increasing_Month_Rate").ToString()).ToString("f2")%></font> %</td> 
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing_year"?" class=orderby":""%>><%# Eval("RowCounts_Increasing_Year")%></td>  
                                <td<%# this.P_OrderBy.ToLower()=="rowcounts_increasing_year_rate"?" class=orderby":""%>><font color=red><%# Convert.ToDouble(Eval("RowCounts_Increasing_Year_Rate").ToString()).ToString("f2")%></font> %</td>  
                                    
                                <td<%# this.P_OrderBy.ToLower()=="space_allocation"?" class=orderby":""%>><%#Eval("Space_Allocation_String")%> </td>  
                                <td<%# this.P_OrderBy.ToLower()=="space_used"?" class=orderby":""%>><%# Eval("Space_Used_String")%> </td>  
                                <td<%# this.P_OrderBy.ToLower()=="space_index_used"?" class=orderby":""%>><%# Eval("Space_Index_Used_String")%></td>  
                                <td<%# this.P_OrderBy.ToLower()=="space_available"?" class=orderby":""%>><%# Eval("Space_Available_String")%> </td>  
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--stats结束-->
	  		</div>  
	  		<div class="Body_Pages"><%=outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>
        <script language="javascript">
            $(".indexs_tooltip").mouseover(function (e) {
                if ($(this).attr("titles") == null) {
                    var id = $(this).attr("id");
                    var data = "v=" + id;
                    //查询
                    $.ajax({
                        async: true,
                        type: "GET",
                        url: "<%=Business.Config.HostUrl%>/Manager/DataBase/Indexs.aspx",
                        cache: false,
                        timeout: 10 * 1000,
                        dataType: "json",
                        data: data,
                        success: function (result) {
                            $("." + id.replace(".", "_")).attr("titles", result.Message);
                        }
                    });
                }
            });
        </script>
    </form>
</body>
</html>
