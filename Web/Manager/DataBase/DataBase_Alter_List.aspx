<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Alter_List.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Alter_List" %>


<%@ Register Src="../Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=this.CurrentWebTitle%></title><meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link href=<%=Business.Config.ResourcePath %>css/style.css?Version=<%=Business.Config.Version %> rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style2 {
            width: 146px;
            text-align:right;
        }
        </style>
     <script language="javascript">
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
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="c2">
                            <!--开始--> 
                            <table width="100%" border="0" cellspacing="10">
                                <tr>
                                    <td class="auto-style2">选择修改的数据库：</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Database_Name" runat="server">
                                        </asp:DropDownList>每个人每天只允许修改一次数据库，如果一天内有多处修改，请合并成一次进行提交。</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">填写执行的SQL：</td>
                                    <td>
                                        <asp:TextBox ID="txt_Alter_Sql" runat="server" TextMode="MultiLine" Width="100%" Height="250px"></asp:TextBox>
                                        <br />
                                        请填写具体修改数据库结构和权限的SQL，并且保证SQL语句在测试库上执行正确，否则可能在正式库上会执行出错。</br>
                                        添加或者修改字段必须有字段说明，否则不予执行，示例：</br>
                                        <font color=green>/*添加字段说明*/</font></br>
                                        <font color=blue>EXEC</font> <font color=lightgreen>sys</font>.<font color="#990033">sp_addextendedproperty</font> @name=<font color="red">N'MS_Description'</font>, @value=<font color="red">N'订单编号'</font> , @level0type=<font color="red">N'SCHEMA'</font>,@level0name=<font color="red">N'dbo'</font>, @level1type=<font color="red">N'TABLE'</font>,@level1name=<font color="red">N'MallPayrecorde'</font>, @level2type=<font color="red">N'COLUMN'</font>,@level2name=<font color="red">N'Orderno'</font></br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*修改字段说明*/</font></br>
                                        <font color=blue>EXEC</font> <font color=lightgreen>sys</font>.<font color="#990033">sp_updateextendedproperty</font> @name=<font color="red">N'MS_Description'</font>, @value=<font color="red">N'搜房卡的用户ID'</font> , @level0type=<font color="red">N'SCHEMA'</font>,@level0name=<font color="red">N'dbo'</font>, @level1type=<font color="red">N'TABLE'</font>,@level1name=<font color="red">N'MallPayrecorde'</font>, @level2type=<font color="red">N'COLUMN'</font>,@level2name=<font color="red">N'CID'</font></br>
                                        <font color=blue>GO</font></br></br>
                                        SQL SERVER 对权限的授予GRANT、拒绝DENY、收回REVOKE，示例：</br>
                                        <font color=green>/*对用户channelsales_oa_r授权，允许其具有对数据对象MallPayrecorde（可以是表、视图）的更新和删除的操作权限*/</font></br>
                                        <font color=blue>GRANT</font> <font color="#ff00ff">UPDATE</font>,<font color=blue>DELETE ON</font> MallPayrecorde <font color=blue>TO</font> channelsales_oa_r <font color=blue>WITH GRANT OPTION</font> ;<font color=green>/*--WITH GRANT OPTION表示该用户可以向其他用户授予他所拥有的权限，这里禁止使用*/</font></br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*对用户channelsales_oa_r授权，允许其具有对数据对象MallPayrecorde（可以是表、视图）的SELECT的操作权限*/</font></br>
                                        <font color=blue>GRANT SELECT ON</font> MallPayrecorde <font color=blue>TO</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>                                            
                                        <font color=green>/*对用户channelsales_oa_r授权，允许其具有对数据对象proc_autorun（存储过程）的EXECUTE的操作权限*/</font></br>
                                        <font color=blue>GRANT EXECUTE ON</font> proc_autorun <font color=blue>TO</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*禁止channelsales_oa_r用户对数据对象MallPayrecorde（可以是表、视图）的更新权限*/</font></br>
                                        <font color=blue>DENY</font> <font color="#ff00ff">UPDATE</font> <font color=blue>ON</font> MallPayrecorde <font color=blue>TO</font> channelsales_oa_r <font color=blue>CASCADE</font> ;</br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*收回用户channelsales_oa_r对对象MallPayrecorde（可以是表、视图）的删除权限*/</font></br>
                                        <font color=blue>REVOKE DELETE ON</font> MallPayrecorde <font color=blue>FROM</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>
                                        <font color=green>/*收回用户channelsales_oa_r对对象proc_autorun（存储过程）的EXECUTE权限*/</font></br>
                                        <font color=blue>REVOKE EXECUTE ON</font> proc_autorun <font color=blue>FROM</font> channelsales_oa_r ;</br>
                                        <font color=blue>GO</font></br>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">备注：</td>
                                    <td>
                                        <asp:TextBox ID="txt_Alter_Remark" runat="server" Height="33px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        <br />
                                        请填写为何要执行此SQL</td>
                                </tr>                                
                                <tr>
                                    <td class="auto-style2"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="确认提交" OnClick="btnSubmit_Click"/>
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                    </td>
                                </tr>                                
                                </table>
  
                     </td> 
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="l2">&nbsp;</td>
        <td class="c2">
			<div class="Body_PageContent">			
                共查到<font color=red><%=LogCount.ToString() %></font>条记录,查找：
                <asp:TextBox ID="txtKeyword" runat="server" Width="21%"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp;<br/> 
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>ID</th>
			            <th>创建时间</th>
			            <th>IP</th>
			            <th>数据库</th>
			            <th><a href="javascript:void(0)" onclick="javascript:showhide_td();" id="showhide_td">执行SQL＋＋＋</a>  </th>
			            <th>问题</th>
			            <th>状态</th>
			            <th>执行时间</th>
			            <th>提交人</th>
			            <th>操作</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                 <td width="25"><%# Eval("id")%></td>
			                     <td width="120"><%# Eval("CreateTime")%></td>
                                 <td width="100"><%# Eval("DATABASE_IP")%></td> 
			                     <td width="80"><%# Eval("DATABASE_NAME")%></td>
			                     <td width="50%" onclick="javascript:showhide('v_<%# Eval("id")%>');"><div class="cell"><font color="green">/**<%# Eval("ALTER_REMARK")%>**/</font><br /><font color="blue"><%# Eval("ALTER_SQL").ToString().Replace("\r\n","<br>")%></font></div></td>
			                     <td onclick="javascript:showhide('v_<%# Eval("id")%>');"><div class="cell"><font color="red"><%# Eval("ALTER_PROBLEM")%></font></div></td>
			                     <td width="40"><%# Eval("ALTER_STATUS").ToString()=="0"?"新建":""%><%# Eval("ALTER_STATUS").ToString()=="1"?"已执行":""%></td>
			                     <td width="120"><%# Eval("ALTER_TIME")%></td>
			                     <td width="40"><%# Eval("WebManager_realname")%></td>
			                     <td><%# (Eval("ALTER_STATUS").ToString()=="0"&&(Eval("WebManager_name").ToString().ToLower()==this.CurrentWebManagerName.ToLower() || this.CurrentIsAdmin==true))?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Alter_Delete.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"\""+" onclick="+"\""+"javascript:return window.confirm('确定删除？')"+"\""+">删除</a><br>":""%>
                                     <%# (Eval("ALTER_STATUS").ToString()=="0"&&this.CurrentIsAdmin==true)?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Alter_Edit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"\""+" onclick="+"\""+"javascript:return window.confirm('确定执行？')"+"\""+">执行</a><br>":""%>
                                     <%# Eval("ALTER_STATUS").ToString()=="1"?"已执行":""%>
                                    <%-- <%if (this.CurrentIsAdmin == true) { %>
                                     <a href="DataBase_Alter_SqlEdit.aspx?Id=<%# Com.Common.EncDec.Encrypt( Eval("id").ToString(),this.Encrypt_key)%>"> <%# Eval("ALTER_STATUS").ToString()=="0"?"修改SQL":""%></a>
                                     <%} %>--%>
                                     <%# (Eval("ALTER_STATUS").ToString()=="0"&&(Eval("WebManager_name").ToString().ToLower()==this.CurrentWebManagerName.ToLower() || this.CurrentIsAdmin==true))?"<a href="+"\""+""+Business.Config.HostUrl+"/Manager/DataBase/DataBase_Alter_SqlEdit.aspx?ID="+ Com.Common.EncDec.Encrypt(Eval("id").ToString(),this.Encrypt_key)+"\""+" onclick="+"\""+"javascript:return window.confirm('确定修改？')"+"\""+">修改</a><br>":""%>
			                     </td>
				            </tr>  
                             <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %> id="v_<%# Eval("id")%>" style="display:none;background-color:lightblue;">
                                 <td colspan="10" style="border:1px solid #cccccc">
                                     <p><font color="green">/**<%# Eval("ALTER_REMARK")%>**/</font><br /><font color="blue"><%# Eval("ALTER_SQL").ToString().Replace("\r\n","<br>")%></font></p>
                                     <p><font color="red"><%# Eval("ALTER_PROBLEM")%></font></p>
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
        <div style="width: 100%; height: 100%; background-color: lightgray; z-index: 9999; display: none; position: absolute; top: 0px; left: 0px; vertical-align: middle;" id="Loading">
            <div style="top: 200px; left: 300px; position: absolute"><b>提交中,请等待....</b></div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function (event) {
                if (window.confirm("确定提交吗？") == true) {
                    $("#Loading").show();
                    return true;
                }
                else {
                    return false;
                }
            });
        })
    </script>
</body>
</html>
