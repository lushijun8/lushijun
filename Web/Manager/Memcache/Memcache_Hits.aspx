<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Memcache_Hits.aspx.cs" Inherits="Web.Manager.Memcache.Memcache_Hits" %>

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
				                 <a <%# Eval("isCurrentDate").ToString()=="1"?"class=button":"class=button_off"%> href="Memcache_Hits.aspx?keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&orderby=<%=Server.UrlEncode(this.P_orderby) %>&today=<%# Eval("Date")%>"><%# Eval("Date")%></a>
			                </ItemTemplate>
		                </asp:Repeater>      
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th> 
			            <th><a href="Memcache_Hits.aspx?orderby=CreateTime&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>更新时间</th> 
			            <th><a href="Memcache_Hits.aspx?orderby=PageUrl&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>调用Memcached缓存位置</th> 
			            <th><a href="Memcache_Hits.aspx?orderby=ClassName&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>ClassName</th>
                        <th>负责人</th> 
                        <th>认领URL</th>  
			            <th>IP</th>
			            <th>端口</th>
			            <th><a href="Memcache_Hits.aspx?orderby=get_hits_count&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>get命中</th>
			            <th><a href="Memcache_Hits.aspx?orderby=get_misses_count&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>get未命中</th>
			            <th><a href="Memcache_Hits.aspx?orderby=get_hits_count%2f(get_count%2b0.001)&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>get命中率<a href="Memcache_Hits.aspx?orderby=get_misses_count%2f(get_count%2b0.001)&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↑</a></th>
			            <th><a href="Memcache_Hits.aspx?orderby=set_hits_count&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>set命中</th>
			            <th><a href="Memcache_Hits.aspx?orderby=set_misses_count&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>set未命中</th>
			            <th><a href="Memcache_Hits.aspx?orderby=set_hits_count%2f(set_count%2b0.001)&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↓</a>set命中率<a href="Memcache_Hits.aspx?orderby=set_misses_count%2f(set_count%2b0.001)&keyword=<%=Server.UrlEncode(this.txtKeyword.Text) %>&today=<%=this.P_Today%>" class="orderby">↑</a></th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# this._PageSize*(this.P_page-1)+ Container.ItemIndex+1%></td> 
                                <td<%# this.P_orderby.ToLower()=="createtime"?" class=orderby":""%>><%# Eval("CreateTime")%></td>  
                                <td<%# this.P_orderby.ToLower()=="pageurl"?" class=orderby":""%>><a href="<%=Business.Config.HostUrl%>/Manager/DataBase/DataBase_Connect_Log.aspx?page=1&keyword=<%# Server.UrlEncode(Eval("PageUrl").ToString())%>" target="_blank"><%# Eval("PageUrl")%></a><br /><%# Eval("FunctionName")%></td>  
                                <td<%# this.P_orderby.ToLower()=="classname"?" class=orderby":""%>><%# Eval("ClassName").ToString().Replace(";","<br>")%></td>  
                                <td><%# Eval("WebManager_Name").ToString().IndexOf(",")==-1?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_PageUrl.aspx?keyword="+ Eval("WebManager_Name").ToString()+"\">"+Eval("WebManager_RealName").ToString()+"</a>":Eval("WebManager_RealName").ToString()%></td> 
                                <td><%# Eval("IsMy").ToString()=="1"?"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Delete.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),this.Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">删除</a>":"<a href=\""+Business.Config.HostUrl+"/Manager/WebSite/WebSite_My_PageUrl_Add.aspx?PageUrl="+Com.Common.EncDec.Encrypt(Eval("pageurl").ToString(),Encrypt_key)+"\" onclick=\"javascript:return confirm_me('"+Eval("pageurl").ToString()+"')\">认领</a>"%></td> 
                                <td<%# this.P_orderby.ToLower()=="memcache_ip"?" class=orderby":""%>><%# Eval("Memcache_IP")%><img src="<%=Business.Config.HostUrl %>/images/<%# Eval("status").ToString()=="1"?"yes":"no"%>.gif" /></td>  
                                <td<%# this.P_orderby.ToLower()=="memcache_port"?" class=orderby":""%>><%# Eval("Memcache_Port")%><br />
                                    <%if(this.CurrentIsAdmin==true){ %><a href="Memcache_Reset.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("Memcache_IP").ToString()+","+Eval("Memcache_Port").ToString()+",flush_all",this.Encrypt_key)%>" onclick="javascript:return confirm_me('回收?');">回收</a> <br /> 
                                      <a href="Memcache_Reset.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("Memcache_IP").ToString()+","+Eval("Memcache_Port").ToString()+",stats reset",this.Encrypt_key)%>" onclick="javascript:return confirm_me('重新统计?');">重新统计 <br />
                                      <a href="Memcache_Reset.aspx?v=<%# Com.Common.EncDec.Encrypt(Eval("Memcache_IP").ToString()+","+Eval("Memcache_Port").ToString()+",",this.Encrypt_key)%>" onclick="javascript:return confirm_me('刷新?');">刷新</a>
			                     <%}else{%><%} %>
                                </td>  
                                <td<%# this.P_orderby.ToLower()=="get_hits_count"?" class=orderby":""%>><%# Eval("get_hits_count")%></td>  
                                <td<%# this.P_orderby.ToLower()=="get_misses_count"?" class=orderby":""%>><%# Eval("get_misses_count")%></td>  
                                <td<%# this.P_orderby.ToLower().IndexOf("get_count")>-1?" class=orderby":""%>>                                    
                                    <div id="container_<%# Container.ItemIndex%>"></div>
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
                                                        ['get命中', <%# (Eval("get_misses_count").ToString()=="0" && Eval("get_hits_count").ToString()=="0")?"1":Eval("get_hits_count")%>],
                                                        ['get未命中', <%# Eval("get_misses_count")%>]
                                                    ]
                                                }]
                                            });
                                        </script>
                                    get_hits:<%# Eval("get_hits_count")%><br />
                                    get_misses:<%# Eval("get_misses_count")%><br />
                                    get总数:<%# Eval("get_count")%>

                                </td>   
                                <td<%# this.P_orderby.ToLower()=="set_hits_count"?" class=orderby":""%>><%# Eval("set_hits_count")%></td>  
                                <td<%# this.P_orderby.ToLower()=="set_misses_count"?" class=orderby":""%>><%# Eval("set_misses_count")%></td>   
                                <td<%# this.P_orderby.ToLower().IndexOf("set_count")>-1?" class=orderby":""%>> 
                                    <div id="container1_<%# Container.ItemIndex%>"></div>
                                        <script language="javascript">
                                            $('#container1_<%# Container.ItemIndex%>').highcharts({
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
                                                        ['set命中', <%# (Eval("set_misses_count").ToString()=="0" && Eval("set_hits_count").ToString()=="0")?"1":Eval("set_hits_count")%>],
                                                        ['set未命中', <%# Eval("set_misses_count")%>]
                                                    ]
                                                }]
                                            });
                                        </script>
                                    set_hits:<%# Eval("set_hits_count")%><br />
                                    set_misses:<%# Eval("set_misses_count")%><br />
                                    set总数:<%# Eval("set_count")%>
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
