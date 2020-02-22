<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="Web.Manager.Welcome" %>

<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��ӭ��¼<%=this.CurrentWebTitle %>��̨...</title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"> 
</head>
<body class="Body_Right">
    <style type="text/css">        
    <!--#include file="../css/style.css"-->
    </style>
    <!--<form id="form1" runat="server">-->
    <!--ɾ����ʼ-->
   <div class="Body_PageContent Body_Content">
    <uc1:Menu ID="Menu1" runat="server" />
    <script language="javascript" type="text/javascript" src="<%=Business.Config.ResourcePath %>js/highcharts.js"></script>
       
        <asp:Repeater ID="rtp_Admin_Webmanager" runat="server" EnableViewState="false">
			<ItemTemplate>
              <a <%# this.CurrentWebManagerName_v.ToString()==Eval("WEBMANAGER_NAME").ToString()?"class=button":"class=button_off"%> href="<%=Business.Config.HostUrl %>/Manager/Welcome.aspx?WebManager_Name=<%#  Com.Common.EncDec.Encrypt(Eval("WEBMANAGER_NAME").ToString(),this.Encrypt_key)%>"><%# Eval("WEBMANAGER_REALNAME")%></a>
			</ItemTemplate>
		</asp:Repeater> 
   </div>
    <!--ɾ������-->
    <asp:Repeater ID="rpt_database_sql_stats_sum_0" runat="server" EnableViewState="false">
			<ItemTemplate>
                <div class="index_item">
				    <b>�����ҵ�SQL</b><br />
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=2">
                     ������ <span class="red"><%# Eval("BadRate")%> %</span><br />
                    <font style="font-size:48pt;line-height:220%"><span class="red"><%# Eval("COUNTS")%>��</span></font>  <br />
                    </a>
                     <div id="container1"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=2"class="red">���첢�Ż�</font></a>
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
                                                        
                                     ['�淶SQL', <%# decimal.Parse(Eval("BadRate").ToString())>100?"1":(100-decimal.Parse(Eval("BadRate").ToString())).ToString()%>],
                                                        ['����SQL',<%# decimal.Parse(Eval("BadRate").ToString())>100?"100":Eval("BadRate").ToString()%> ]
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
				    <b>�ҵ�SQL</b> <span class="red"><%# Eval("counts")%></span> ��<br />
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=1">������ <span class="red"><%# Eval("BadRate")%> %</span><br />
                    ��д�淶���� <span class="red">��<%=this.BadSql_Rank_My==-1?"?":this.BadSql_Rank_My.ToString() %>λ</span><br />
                    ����<span class="red"><%# (decimal.Parse(Eval("WORKER_TIME").ToString())/1000).ToString("f0").Replace(".00","")%>����</span> ���<span class="red"><%# (decimal.Parse(Eval("WORKER_TIME_MAX").ToString())/1000).ToString("f0").Replace(".00","")%>����</span><br />
                    �������� <span class="red">��<%=this.Worker_Time_Rank_My==-1?"?":this.Worker_Time_Rank_My.ToString() %>λ</span></a><br /><br />
                     <div id="container2"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Sql/DataBase_Sql_List.aspx?My=1">�鿴���Ż�</a>
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
                                   ['�淶SQL', <%# decimal.Parse(Eval("BadRate").ToString())>100?"1":(100-decimal.Parse(Eval("BadRate").ToString())).ToString()%>],
                                                        ['����SQL',<%# decimal.Parse(Eval("BadRate").ToString())>100?"100":Eval("BadRate").ToString()%> ]
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
				    <b>�����ҵ�ҳ��</b><br /><br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=3">
                          <font style="font-size:48pt;line-height:220%"><span class="red"><%# Eval("MYCOUNT")%>��</span></font>  <br />
				    </a>                  
                    <div id="container3"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=3">����ȥ����</a>
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
                                     ['�����ҵ�', <%# Eval("MYCOUNT")%>],
                                                        ['�����˵�ҳ��', <%# Eval("ALLCOUNT")%>-<%# Eval("MYCOUNT")%>]
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
				    <b>�ҵ�ҳ��</b> <span class="red"><%# Eval("MYCOUNT")%></span> / <%# Eval("ALLCOUNT")%> ��<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=1">
                    <span class="red"><b>ÿҳÿ��</b></span> ƽ������ <span class="red"><%# Eval("REQUEST_COUNT")%></span> ��<br />
                    ������� <span class="red"><%# Eval("REQUEST_COUNT_MAX")%></span> ��<br />
				    ƽ����ʱ <span class="red"><%# Eval("DURATION_AVG")%></span> ����<br />
				    ����ʱ <span class="red"><%# Eval("DURATION_AVG_MAX")%></span> ����<br />
				    ÿ������ƽ���������ݿ�<span class="red"><%# Eval("CONNECT_TIMES_AVG")%></span>�Σ����<span class="red"><%# Eval("CONNECT_TIMES_AVG_MAX")%></span>��<br />
				    </a>                  
                    <div id="container4"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/WebSite/WebSite_PageUrl.aspx?My=1">�鿴�ҵ�ҳ��</a>
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
                                     ['�ҵ�ҳ��', <%# Eval("MYCOUNT")%>],
                                                        ['�����˵�ҳ��', <%# Eval("ALLCOUNT")%>-<%# Eval("MYCOUNT")%>]
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
				    <b>�������Ľӿ�</b> <span class="red"><%# Eval("MYCOUNT")%></span> ��<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/Depend/Depend_List_All.aspx?My=1">
                    �վ����� <span class="red"><%# Eval("Depend_Count")%></span> ��<br />
				    ���� <span class="red"><%# Eval("Depend_TimeSpan_Average")%></span>���룬���<span class="red"><%# Eval("Depend_TimeSpan_Average_max")%></span>����<br />
				    �վ����� <span class="red"><%# Eval("Depend_Count_Error")%></span>�Σ����<span class="red"><%# Eval("Depend_Count_Error_max")%></span> ��<br />
                    �վ���ʱ<span class="red"><%# Eval("Depend_Count_TimeOut")%></span>�Σ����<span class="red"><%# Eval("Depend_Count_TimeOut_max")%></span>��<br />
				    �վ�����&��ʱ�� <span class="red"><%# decimal.Parse(Eval("DEPEND_ERROR_RATE").ToString()).ToString("f2").Replace(".00","")%></span> %<br /> 

				    </a>                  
                    <div id="container5"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Depend/Depend_List_All.aspx?My=1">�鿴�������Ľӿ�</a>
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
                                     ['�����', <%# Eval("DEPEND_ERROR_RATE")%>],
                                                        ['������', 100-<%# Eval("DEPEND_ERROR_RATE")%>]
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
				    <b>�ҵĻ���������</b> <span class="red"><%# decimal.Parse(Eval("hits_rate").ToString()).ToString("f2").Replace(".00","")%></span> %<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/Memcache/Memcache_Hits.aspx?orderby=get_misses_count&keyword=<%= Server.UrlEncode(this.CurrentWebManagerName_v) %>">
                    <span class="red"><b>ÿҳ�վ�</b></span> GET<span class="red"><%# Eval("get_count")%></span>�Σ�����<span class="red"><%# Eval("get_hits_count")%></span>��<br />
                    SET<span class="red"><%# Eval("set_count")%></span>�Σ�����<span class="red"><%# Eval("set_hits_count")%></span>��<br />
                    ���GET<span class="red"><%# Eval("get_count_max")%></span>�Σ�����<span class="red"><%# Eval("get_hits_count_max")%></span>��<br />
                    ���SET<span class="red"><%# Eval("set_count_max")%></span>�Σ�����<span class="red"><%# Eval("set_hits_count_max")%></span>��<br />
                    Ч�ܱ�<span class="red"><%# decimal.Parse(Eval("avail_rate").ToString()).ToString("f2").Replace(".00","")%></span>����<span class="red"><%# Eval("avail_remark")%></span><br />
				    </a>                  
                    <div id="container6"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Memcache/Memcache_Hits.aspx?orderby=get_misses_count&keyword=<%= Server.UrlEncode(this.CurrentWebManagerName_v) %>">�鿴�ҵĻ���������</a>
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
                                     ['���е�', <%# Eval("hits_rate")%>],
                                     ['δ���е�', 100-<%# Eval("hits_rate")%>]
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
				    <b>�ҵ���־</b> <span class="red"><%# decimal.Parse(Eval("LOG_COUNT").ToString()).ToString("f2").Replace(".00","")%></span> ��<br />
				    <a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Stats_List.aspx?My=1">
                    <span class="red"><b>����</b></span> �������� <span class="red"><%# Eval("log_date_count0")%></span> �죬����ҳ�� <span class="red"><%# Eval("pageurl_count0")%></span> ��<br />
                        ������־<span class="red"><%# Eval("LOG_COUNT0")%></span>�����վ�<span class="red"><%# Eval("LOG_COUNT_AVG0")%></span>���������<span class="red"><%# Eval("LOG_COUNT_MAX0")%></span>��<br /> 
                        ҵ����־<span class="red"><%# Eval("LOG_COUNT1")%></span>�����վ�<span class="red"><%# Eval("LOG_COUNT_AVG1")%></span>��<br />ҵ����־�վ����<span class="red"><%# Eval("LOG_COUNT_MAX1")%></span>��<br /><br /> 
				    </a>                  
                    <div id="container7"></div>
                    <a href="<%=Business.Config.HostUrl %>/Manager/Log/Log_Stats_List.aspx?My=1">�鿴�ҵ���־</a>
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
                                     ['�ҵı���', <%# Eval("LOG_COUNT0")%>],
                                     ['�����˵ı���', <%# Eval("LOG_COUNT_ALL0")%>]
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
