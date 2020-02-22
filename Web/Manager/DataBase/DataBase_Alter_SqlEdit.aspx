<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Alter_SqlEdit.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Alter_SqlEdit" %>

<%@ Register Src="../Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html>

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
        .button {
            height: 21px;
        }
    </style>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
        <div class="Body_Content">
            <uc1:Menu ID="Menu1" runat="server" />
            <table border="0" cellpadding="5" cellspacing="5" width="100%">
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
                                         <asp:TextBox ID="txt_Alter_Sql" runat="server" TextMode="MultiLine" Width="100%" Height="450px"></asp:TextBox>
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
            </div>   
  
    </form>
</body>
</html>
