<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Memcache_Stats.aspx.cs" Inherits="Web.Manager.Memcache.Memcache_Stats" %>
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
            }
            else {
                $("#" + id).show();
            }
        }
     </script>

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
                <asp:TextBox ID="txtKeyword" runat="server" Width="40%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;
                 <p>&nbsp;</p>
		                <asp:Repeater ID="rpt_Date" runat="server" EnableViewState="false">
			                <ItemTemplate>
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="Memcache_Stats.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%# Eval("Date")%>&cachetype=<%=Server.UrlEncode(this.P_CacheType) %>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater>&nbsp;&nbsp;&nbsp;&nbsp;
                <a <%=this.P_CacheType.ToString()==""?"class=button":"class=button_off"%> href="Memcache_Stats.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&today=<%=Server.UrlEncode(this.P_Today)%>&cachetype=">全部</a>
                <a <%=this.P_CacheType.ToString()=="0"?"class=button":"class=button_off"%> href="Memcache_Stats.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&today=<%=Server.UrlEncode(this.P_Today)%>&cachetype=0">Memcached</a>
                <a <%=this.P_CacheType.ToString()=="1"?"class=button":"class=button_off"%> href="Memcache_Stats.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text)%>&today=<%=Server.UrlEncode(this.P_Today)%>&cachetype=1">Redis</a>   
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>类型</th> 
			            <th>IP</th> 
			            <th>端口</th>
			            <th>密钥</th>
			            <th>状态</th>
			            <th>站点</th>
			            <th>检查时间</th>  
			            <th>回收时间</th>  
                        <th>详情</th>  
                        <th>set总数</th> 
                        <th>get(命中/未命中)</th>       
                        <th>读写/使用空间(MB)</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> onclick="javascript:showhide('v_<%# Eval("Memcache_IP").ToString().Replace(".","")%>_<%# Eval("Memcache_Port").ToString()%>');" style="cursor:pointer;background-color:<%# Eval("STATUS").ToString()=="0"?"yellow":"" %>;">
                                <td><img src="../../images/<%# Eval("CacheType").ToString()=="0"?"memcached":"redis"%>.gif" height="48" /></td>
                                <td><%# Eval("Memcache_IP")%><br />[<%# Eval("Memcache_Local_IP")%>]<%#  Eval("ERROR").ToString().Replace("Not_Serializable_Class","").Replace("get_misses_count","").Replace("get_hits_count","").Replace("set_hits_count","").Replace("set_misses_count","").Length>20?"<span class=bug_tooltip titles=\"<br>"+Eval("ERROR").ToString().Replace(";","<br>")+"<br>\"></span>":""%>
                                    <%# string.IsNullOrEmpty(Eval("STATSINFO").ToString())==false?"<span class='why_tooltip tooltip' titles='"+Eval("STATSINFO").ToString().Replace("\t","&nbsp;").Replace("\r\n","<br/>")+"'></span>":""%><br /><%# Eval("Remark")%>                                  
                                </td>
			                    <td><%# Eval("Memcache_Port")%></td>
			                    <td><%# Eval("Auth").ToString().Trim()%></td>
                                <td><img src="<%=Business.Config.HostUrl %>/images/<%# Eval("status").ToString()=="1"?"yes":"no"%>.gif" /></td>
                                <td><%# Eval("WebSite").ToString().Replace(";","<br>").Replace("[","<br>[")%></td>
			                    <td><%# Eval("CreateTime")%></td>  
			                    <td><%# Eval("ResetTime")%></td>
                                <td>运行: <%# (long.Parse(Eval("uptime").ToString())/(60*60*24)).ToString("f2").Replace(".00","")%> 天<br /> 
                                    版本: <%# Eval("version")%><br />
                                    系统: <%# Eval("pointer_size")%> 位<br /> 
                                    连接: <%# Eval("curr_connections")%> / <%# Eval("total_connections")%><br />
                                    item: <%# Eval("curr_items")%> / <%# Eval("total_items")%>
                                </td>
                                <td><%# Eval("cmd_set")%></td> 
                                <td><div id="container_<%# Container.ItemIndex%>"></div>
                                    <script language="javascript">
                                        $('#container_<%# Container.ItemIndex%>').highcharts({
                                            chart: {
                                                    backgroundColor: 'transparent',
                                                    plotBackgroundColor: null,
                                                    plotBorderWidth: null,
                                                    plotShadow: false,
                                                    width: 60,
                                                    height: 60,
                                                    margin: [0, 0, 0, 0]
                                            },
                                            colors: [
                                                'green',
                                                'red' ],
                                            title: {
                                                text: ''
                                            },
                                            tooltip: {
                                                borderWidth: 0,
                                                shadow: false,
                                                animation: false,
                                                backgroundColor:'transparent',
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
                                                    ['命中', <%# (Eval("get_misses").ToString()=="0" && Eval("get_hits").ToString()=="0")?"1":Eval("get_hits")%>],
                                                    ['未命中', <%# Eval("get_misses")%>]
                                                ]
                                            }]
                                        }); 
                                    </script><%# Eval("get_hits")%> / <%# Eval("get_misses")%>

                                </td>
                                    
                                <td>
                                    <div id="container1_<%# Container.ItemIndex%>"></div>
                                    <script language="javascript">
                                        $('#container1_<%# Container.ItemIndex%>').highcharts({
                                            chart: {
                                                backgroundColor: 'transparent',
                                                plotBackgroundColor: null,
                                                plotBorderWidth: null,
                                                plotShadow: false,
                                                width: 50,
                                                height: 50,
                                                margin: [0, 0, 0, 0]
                                            },
                                            colors: [
                                                'red',
                                                'green'],
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
                                                    ['已使用', <%# Eval("bytes")%>],
                                                    ['未使用', <%# long.Parse(Eval("limit_maxbytes").ToString())-long.Parse(Eval("bytes").ToString())%>]
                                                ]
                                            }]
                                        });
                                    </script>
                                    读: <%# (long.Parse(Eval("bytes_read").ToString())/(1024*1024)).ToString("f2").Replace(".00","")%>,写: <%# (long.Parse(Eval("bytes_written").ToString())/(1024*1024)).ToString("f2").Replace(".00","")%><br />
                                       
                                已使用: <%# (long.Parse(Eval("bytes").ToString())/(1024*1024)).ToString("f2").Replace(".00","")%> / <%# (long.Parse(Eval("limit_maxbytes").ToString())/(1024*1024)).ToString("f2").Replace(".00","")%>
                                </td>
			                    <td>
                                    <%if(this.CurrentIsAdmin==true){ %> 
                                    <div style="display:<%# Eval("CacheType").ToString()=="0"?"block":"none"%>">
                                    <a href="Memcache_Reset.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("Memcache_IP").ToString()+","+Eval("Memcache_Port").ToString()+",flush_all,"+Eval("cachetype").ToString(),this.Encrypt_key)%>" onclick="javascript:return confirm_me('回收?');">回收</a> <br /> 
                                    <a href="Memcache_Reset.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("Memcache_IP").ToString()+","+Eval("Memcache_Port").ToString()+",stats reset,"+Eval("cachetype").ToString(),this.Encrypt_key)%>" onclick="javascript:return confirm_me('重新统计?');">重新统计 <br />
                                    </div>
                                    <a href="Memcache_Reset.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("Memcache_IP").ToString()+","+Eval("Memcache_Port").ToString()+",refresh,"+Eval("cachetype").ToString(),this.Encrypt_key)%>" onclick="javascript:return confirm_me('刷新?');">刷新</a><br />
                                    <a href="Memcache_Edit.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("Memcache_IP").ToString()+","+Eval("Memcache_Port").ToString()+","+Eval("Memcache_Local_IP").ToString(),this.Encrypt_key)%>" onclick="javascript:return confirm_me('编辑?');">编辑</a>
			                        <%}else{%>-<%} %> </td>			                        
				            </tr>
                              <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("Memcache_IP").ToString().Replace(".","")%>_<%# Eval("Memcache_Port")%>" style="display:none;background-color:lightyellow;">
                                 <td colspan="13" style="border:1px solid #cccccc">
                                     <p><%# Eval("STATSINFO").ToString().Replace("\t","&nbsp;").Replace("\r\n","<br/>")%></p>
                                 </td>
			                       				           
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
