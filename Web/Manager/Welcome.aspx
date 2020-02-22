<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="Web.Manager.Welcome" %>

<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>欢迎登录<%=this.CurrentWebTitle %>后台...</title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"> 
</head>
<body class="Body_Right">
    <style type="text/css">        
    <!--#include file="../css/style.css"-->
    </style>
    <!--<form id="form1" runat="server">-->
    <!--删除开始-->
   <div class="Body_PageContent Body_Content">
    <uc1:Menu ID="Menu1" runat="server" />
    <script language="javascript" type="text/javascript" src="<%=Business.Config.ResourcePath %>js/highcharts.js"></script>
       
        <asp:Repeater ID="rtp_Admin_Webmanager" runat="server" EnableViewState="false">
			<ItemTemplate>
              <a <%# this.CurrentWebManagerName_v.ToString()==Eval("WEBMANAGER_NAME").ToString()?"class=button":"class=button_off"%> href="<%=Business.Config.HostUrl %>/Manager/Welcome.aspx?WebManager_Name=<%#  Com.Common.EncDec.Encrypt(Eval("WEBMANAGER_NAME").ToString(),this.Encrypt_key)%>"><%# Eval("WEBMANAGER_REALNAME")%></a>
			</ItemTemplate>
		</asp:Repeater> 
   </div>
    <!--删除结束-->
    <asp:Repeater ID="rpt_database_sql_stats_sum_0" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item">
				    <b>疑似我的SQL</b><br />
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=2">
                     问题率 <span class="red"><%# Eval("BadRate")%> %</span><br />
                    <font style="font-size:48pt;line-height:220%"><span class="red"><%# Eval("COUNTS")%>条</span></font>  <br />
                    </a>
                     <div id="container1"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=2"class="red">认领并优化</font></a>
                     <script language="javascript">
                                            $('#container1').highcharts({
                                                chart: {
                                                    backgroundColor: 'transparent',
                                                    plotBackgroundColor: null,
                                                    plotBorderWidth: null,
                                                    plotShadow: false,
                                                    width: 100,
                                                    height: 100,
                                                    margin: [0, 0, 0, 0]
                                                },
                                                colors: [
                                                    'green',
                                                    'red'],
                                                title: {
                                                    text: ''
                                                },
                                                tooltip: {
                                                    borderWidth: 0,
                                                    shadow: false,
                                                    animation: false,
                                                    backgroundColor: 'transparent',
                                                    pointFormat: '<b>{point.percentage:.1f}%</b>',
                                                    style: { color: "#000000", fontSize: "10px" }

                                                },
                                                plotOptions: {
                                                    pie: {
                                                        allowPointSelect: false,
                                                        cursor: 'pointer',
                                                        dataLabels: {
                                                            enabled: false,
                                                        }
                                                    }
                                                },
                                                series: [{
                                                    type: 'pie',
                                                    name: '',
                                                    data: [
                                                        
                                     ['规范SQL', <%# decimal.Parse(Eval("BadRate").ToString())>100?"1":(100-decimal.Parse(Eval("BadRate").ToString())).ToString()%>],
                                                        ['问题SQL',<%# decimal.Parse(Eval("BadRate").ToString())>100?"100":Eval("BadRate").ToString()%> ]
                                                    ]
                                                }]
                                            });
                                        </script>

                </div>
			</ItemTemplate>
		</asp:Repeater> 
    <asp:Repeater ID="rpt_database_sql_stats_sum_1" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item">
				    <b>我的SQL</b> <span class="red"><%# Eval("counts")%></span> 条<br />
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=1">问题率 <span class="red"><%# Eval("BadRate")%> %</span><br />
                    书写规范排名 <span class="red">第<%=this.BadSql_Rank_My==-1?"?":this.BadSql_Rank_My.ToString() %>位</span><br />
                    均耗<span class="red"><%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000).ToString("f0").Replace(".00","")%>毫秒</span> 最大<span class="red"><%# (decimal.Parse(Eval("WORKER_TIME_MAX").ToString())/1000).ToString("f0").Replace(".00","")%>毫秒</span><br />
                    性能排名 <span class="red">第<%=this.Worker_Time_Rank_My==-1?"?":this.Worker_Time_Rank_My.ToString() %>位</span></a><br /><br />
                     <div id="container2"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=1">查看并优化</a>
                     <script language="javascript">
                         $('#container2').highcharts({
                             chart: {
                                 backgroundColor: 'transparent',
                                 plotBackgroundColor: null,
                                 plotBorderWidth: null,
                                 plotShadow: false,
                                 width: 100,
                                 height: 100,
                                 margin: [0, 0, 0, 0]
                             },
                             colors: [
                                 'green',
                                 'red'],
                             title: {
                                 text: ''
                             },
                             tooltip: {
                                 borderWidth: 0,
                                 shadow: false,
                                 animation: false,
                                 backgroundColor: 'transparent',
                                 pointFormat: '<b>{point.percentage:.1f}%</b>',
                                 style: { color: "#000000", fontSize: "10px" }

                             },
                             plotOptions: {
                                 pie: {
                                     allowPointSelect: false,
                                     cursor: 'pointer',
                                     dataLabels: {
                                         enabled: false,
                                     }
                                 }
                             },
                             series: [{
                                 type: 'pie',
                                 name: '',
                                 data: [
                                   ['规范SQL', <%# decimal.Parse(Eval("BadRate").ToString())>100?"1":(100-decimal.Parse(Eval("BadRate").ToString())).ToString()%>],
                                                        ['问题SQL',<%# decimal.Parse(Eval("BadRate").ToString())>100?"100":Eval("BadRate").ToString()%> ]
                                                    ]
                             }]
                           });
                     </script>
                </div>
			</ItemTemplate>
		</asp:Repeater>    
    <asp:Repeater ID="rpt_My_PageUrl_Like" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item" style="background-color:#ffd800">
				    <b>疑似我的页面</b><br /><br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=3">
                          <font style="font-size:48pt;line-height:220%"><span class="red"><%# Eval("MYCOUNT")%>个</span></font>  <br />
				    </a>                  
                    <div id="container3"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=3">立刻去认领</a>
                     <script language="javascript">
                         $('#container3').highcharts({
                             chart: {
                                 backgroundColor: 'transparent',
                                 plotBackgroundColor: null,
                                 plotBorderWidth: null,
                                 plotShadow: false,
                                 width: 100,
                                 height: 100,
                                 margin: [0, 0, 0, 0]
                             },
                             colors: [
                                 'green',
                                 'yellowgreen'],
                             title: {
                                 text: ''
                             },
                             tooltip: {
                                 borderWidth: 0,
                                 shadow: false,
                                 animation: false,
                                 backgroundColor: 'transparent',
                                 pointFormat: '<b>{point.percentage:.1f}%</b>',
                                 style: { color: "#000000", fontSize: "10px" }

                             },
                             plotOptions: {
                                 pie: {
                                     allowPointSelect: false,
                                     cursor: 'pointer',
                                     dataLabels: {
                                         enabled: false,
                                     }
                                 }
                             },
                             series: [{
                                 type: 'pie',
                                 name: '',
                                 data: [
                                     ['疑似我的', <%# Eval("MYCOUNT")%>],
                                                        ['其他人的页面', <%# Eval("ALLCOUNT")%>-<%# Eval("MYCOUNT")%>]
                                 ]
                             }]
                         });
                                        </script>
                </div>
			</ItemTemplate>
		</asp:Repeater>
    <asp:Repeater ID="rpt_My_PageUrl" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item" style="background-color:#ffd800">
				    <b>我的页面</b> <span class="red"><%# Eval("MYCOUNT")%></span> / <%# Eval("ALLCOUNT")%> 个<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=1">
                    <span class="red"><b>每页每日</b></span> 平均请求 <span class="red"><%# Eval("REQUEST_COUNT")%></span> 次<br />
                    最大请求 <span class="red"><%# Eval("REQUEST_COUNT_MAX")%></span> 次<br />
				    平均耗时 <span class="red"><%# Eval("DURATION_AVG")%></span> 毫秒<br />
				    最大耗时 <span class="red"><%# Eval("DURATION_AVG_MAX")%></span> 毫秒<br />
				    每次请求平均连接数据库<span class="red"><%# Eval("CONNECT_TIMES_AVG")%></span>次，最多<span class="red"><%# Eval("CONNECT_TIMES_AVG_MAX")%></span>次<br />
				    </a>                  
                    <div id="container4"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=1">查看我的页面</a>
                     <script language="javascript">
                         $('#container4').highcharts({
                             chart: {
                                 backgroundColor: 'transparent',
                                 plotBackgroundColor: null,
                                 plotBorderWidth: null,
                                 plotShadow: false,
                                 width: 100,
                                 height: 100,
                                 margin: [0, 0, 0, 0]
                             },
                             colors: [
                                 'green',
                                 'yellowgreen'],
                             title: {
                                 text: ''
                             },
                             tooltip: {
                                 borderWidth: 0,
                                 shadow: false,
                                 animation: false,
                                 backgroundColor: 'transparent',
                                 pointFormat: '<b>{point.percentage:.1f}%</b>',
                                 style: { color: "#000000", fontSize: "10px" }

                             },
                             plotOptions: {
                                 pie: {
                                     allowPointSelect: false,
                                     cursor: 'pointer',
                                     dataLabels: {
                                         enabled: false,
                                     }
                                 }
                             },
                             series: [{
                                 type: 'pie',
                                 name: '',
                                 data: [
                                     ['我的页面', <%# Eval("MYCOUNT")%>],
                                                        ['其他人的页面', <%# Eval("ALLCOUNT")%>-<%# Eval("MYCOUNT")%>]
                                 ]
                             }]
                         });
                                        </script>
                </div>
			</ItemTemplate>
		</asp:Repeater>
    <asp:Repeater ID="rpt_My_PageUrl_Depend" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item" style="background-color:#f4dcff">
				    <b>我依赖的接口</b> <span class="red"><%# Eval("MYCOUNT")%></span> 个<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/Depend/Depend_List_All.aspx?My=1">
                    日均请求 <span class="red"><%# Eval("Depend_Count")%></span> 次<br />
				    均耗 <span class="red"><%# Eval("Depend_TimeSpan_Average")%></span>毫秒，最大<span class="red"><%# Eval("Depend_TimeSpan_Average_max")%></span>毫秒<br />
				    日均报错 <span class="red"><%# Eval("Depend_Count_Error")%></span>次，最多<span class="red"><%# Eval("Depend_Count_Error_max")%></span> 次<br />
                    日均超时<span class="red"><%# Eval("Depend_Count_TimeOut")%></span>次，最多<span class="red"><%# Eval("Depend_Count_TimeOut_max")%></span>次<br />
				    日均报错&超时率 <span class="red"><%# decimal.Parse(Eval("DEPEND_ERROR_RATE").ToString()).ToString("f2").Replace(".00","")%></span> %<br /> 

				    </a>                  
                    <div id="container5"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Depend/Depend_List_All.aspx?My=1">查看我依赖的接口</a>
                     <script language="javascript">
                         $('#container5').highcharts({
                             chart: {
                                 backgroundColor: 'transparent',
                                 plotBackgroundColor: null,
                                 plotBorderWidth: null,
                                 plotShadow: false,
                                 width: 100,
                                 height: 100,
                                 margin: [0, 0, 0, 0]
                             },
                             colors: [
                                 'red',
                                 'yellowgreen'],
                             title: {
                                 text: ''
                             },
                             tooltip: {
                                 borderWidth: 0,
                                 shadow: false,
                                 animation: false,
                                 backgroundColor: 'transparent',
                                 pointFormat: '<b>{point.percentage:.1f}%</b>',
                                 style: { color: "#000000", fontSize: "10px" }

                             },
                             plotOptions: {
                                 pie: {
                                     allowPointSelect: false,
                                     cursor: 'pointer',
                                     dataLabels: {
                                         enabled: false,
                                     }
                                 }
                             },
                             series: [{
                                 type: 'pie',
                                 name: '',
                                 data: [
                                     ['报错的', <%# Eval("DEPEND_ERROR_RATE")%>],
                                                        ['正常的', 100-<%# Eval("DEPEND_ERROR_RATE")%>]
                                 ]
                             }]
                         });
                                        </script>
                </div>
			</ItemTemplate>
		</asp:Repeater>
    <asp:Repeater ID="rpt_My_Memcache" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item" style="background-color:lightblue;">
				    <b>我的缓存命中率</b> <span class="red"><%# decimal.Parse(Eval("hits_rate").ToString()).ToString("f2").Replace(".00","")%></span> %<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/Memcache/Memcache_Hits.aspx?orderby=get_misses_count&keyword=<%= Server.UrlEncode(this.CurrentWebManagerName_v) %>">
                    <span class="red"><b>每页日均</b></span> GET<span class="red"><%# Eval("get_count")%></span>次，命中<span class="red"><%# Eval("get_hits_count")%></span>次<br />
                    SET<span class="red"><%# Eval("set_count")%></span>次，命中<span class="red"><%# Eval("set_hits_count")%></span>次<br />
                    最大GET<span class="red"><%# Eval("get_count_max")%></span>次，命中<span class="red"><%# Eval("get_hits_count_max")%></span>次<br />
                    最大SET<span class="red"><%# Eval("set_count_max")%></span>次，命中<span class="red"><%# Eval("set_hits_count_max")%></span>次<br />
                    效能比<span class="red"><%# decimal.Parse(Eval("avail_rate").ToString()).ToString("f2").Replace(".00","")%></span>倍，<span class="red"><%# Eval("avail_remark")%></span><br />
				    </a>                  
                    <div id="container6"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Memcache/Memcache_Hits.aspx?orderby=get_misses_count&keyword=<%= Server.UrlEncode(this.CurrentWebManagerName_v) %>">查看我的缓存命中率</a>
                     <script language="javascript">
                         $('#container6').highcharts({
                             chart: {
                                 backgroundColor: 'transparent',
                                 plotBackgroundColor: null,
                                 plotBorderWidth: null,
                                 plotShadow: false,
                                 width: 100,
                                 height: 100,
                                 margin: [0, 0, 0, 0]
                             },
                             colors: [
                                 'green',
                                 'red'],
                             title: {
                                 text: ''
                             },
                             tooltip: {
                                 borderWidth: 0,
                                 shadow: false,
                                 animation: false,
                                 backgroundColor: 'transparent',
                                 pointFormat: '<b>{point.percentage:.1f}%</b>',
                                 style: { color: "#000000", fontSize: "10px" }

                             },
                             plotOptions: {
                                 pie: {
                                     allowPointSelect: false,
                                     cursor: 'pointer',
                                     dataLabels: {
                                         enabled: false,
                                     }
                                 }
                             },
                             series: [{
                                 type: 'pie',
                                 name: '',
                                 data: [
                                     ['命中的', <%# Eval("hits_rate")%>],
                                     ['未命中的', 100-<%# Eval("hits_rate")%>]
                                 ]
                             }]
                         });
                                        </script>
                </div>
			</ItemTemplate>
		</asp:Repeater>
    <asp:Repeater ID="rpt_My_Log" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item" style="background-color:lightyellow;">
				    <b>我的日志</b> <span class="red"><%# decimal.Parse(Eval("LOG_COUNT").ToString()).ToString("f2").Replace(".00","")%></span> 条<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Stats_List.aspx?My=1">
                    <span class="red"><b>本周</b></span> 报错天数 <span class="red"><%# Eval("log_date_count0")%></span> 天，报错页数 <span class="red"><%# Eval("pageurl_count0")%></span> 个<br />
                        报错日志<span class="red"><%# Eval("LOG_COUNT0")%></span>条，日均<span class="red"><%# Eval("LOG_COUNT_AVG0")%></span>条，日最多<span class="red"><%# Eval("LOG_COUNT_MAX0")%></span>条<br /> 
                        业务日志<span class="red"><%# Eval("LOG_COUNT1")%></span>条，日均<span class="red"><%# Eval("LOG_COUNT_AVG1")%></span>条<br />业务日志日均最多<span class="red"><%# Eval("LOG_COUNT_MAX1")%></span>条<br /><br /> 
				    </a>                  
                    <div id="container7"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Stats_List.aspx?My=1">查看我的日志</a>
                     <script language="javascript">
                         $('#container7').highcharts({
                             chart: {
                                 backgroundColor: 'transparent',
                                 plotBackgroundColor: null,
                                 plotBorderWidth: null,
                                 plotShadow: false,
                                 width: 100,
                                 height: 100,
                                 margin: [0, 0, 0, 0]
                             },
                             colors: [
                                 'red',
                                 'orange'],
                             title: {
                                 text: ''
                             },
                             tooltip: {
                                 borderWidth: 0,
                                 shadow: false,
                                 animation: false,
                                 backgroundColor: 'transparent',
                                 pointFormat: '<b>{point.percentage:.1f}%</b>',
                                 style: { color: "#000000", fontSize: "10px" }

                             },
                             plotOptions: {
                                 pie: {
                                     allowPointSelect: false,
                                     cursor: 'pointer',
                                     dataLabels: {
                                         enabled: false,
                                     }
                                 }
                             },
                             series: [{
                                 type: 'pie',
                                 name: '',
                                 data: [
                                     ['我的报错', <%# Eval("LOG_COUNT0")%>],
                                     ['其他人的报错', <%# Eval("LOG_COUNT_ALL0")%>]
                                 ]
                             }]
                         });
                                        </script>
                </div>
			</ItemTemplate>
		</asp:Repeater>
    <!--</form>-->
</body>
</html>
