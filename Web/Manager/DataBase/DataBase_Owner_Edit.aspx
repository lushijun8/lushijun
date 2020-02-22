<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBase_Owner_Edit.aspx.cs" Inherits="Web.Manager.DataBase.DataBase_Owner_Edit" %>


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
        .auto-style1 {
            text-align: right;
        }
        .button {
            height: 21px;
        }
    </style>
</head>
<body class="Body_Right">
    <form id="form1" runat="server">
        <div class="Body_Content">
            <uc1:Menu ID="Menu1" runat="server" />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="l2">&nbsp;</td>
                    <td class="c2">
                            <!--开始-->
                            <table width="100%" border="0">
                                <tr>
                                    <td class="auto-style1">数据库名称：</td>
                                    <td>

                                        <asp:TextBox ID="txt_DataBase_Name" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">备注：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Remark" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">内网实IP：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Local" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">外网实IP：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Romote" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">内网VIP：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_VIP_Local" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">外网VIP：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_VIP_Romote" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">堡垒机专线IP：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Special" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">容灾IP：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_IP_Recovery" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">admin用户名：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Admin_User" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">admin用户密码：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Admin_PassWord" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">只读用户名：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Reader_User" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">只读用户密码：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Reader_PassWord" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">可写用户名：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Writer_User" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">可写用户密码：</td>
                                    <td>
                                        <asp:TextBox ID="txt_DataBase_Writer_PassWord" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="确认修改" OnClick="btnSubmit_Click" />
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                    </td>
                                </tr>
                            </table>
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
                $("#Loading").show();
            });
        })
    </script>
</body>
</html>
