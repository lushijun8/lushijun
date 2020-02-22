<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Web.Manager.Admin.AddUser" %>

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
        .auto-style2 {
            color: #FF0000;
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
                                    <td class="auto-style1">业务类别：</td>
                                    <td>

                                        <asp:DropDownList ID="ddlProduct" runat="server">
                                            <asp:ListItem Value="8">金融案场</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">所属分组：</td>
                                    <td>
                                        <asp:DropDownList ID="ddlWebManager_Group_id" runat="server">
                                            <asp:ListItem Value="6">金融案场专员</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">所属团队：</td>
                                    <td>
                                        <asp:DropDownList ID="ddlWebManager_leader_realname" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">级别：</td>
                                    <td>
                                        <asp:DropDownList ID="ddlWebManager_leader_level" runat="server">
                                            <asp:ListItem Value="0">组员</asp:ListItem>
                                            <asp:ListItem Value="1">小团队长</asp:ListItem>
                                            <asp:ListItem Value="2">大团队长</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">用户名：</td>
                                    <td>
                                        <asp:TextBox ID="txtWebManager_name" runat="server" MaxLength="20"></asp:TextBox>
                                        (<span class="auto-style2">*</span>请填写字母)</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">真实姓名：</td>
                                    <td>
                                        <asp:TextBox ID="txtWebManager_realname" runat="server" MaxLength="20"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">手机号：</td>
                                    <td>
                                        <asp:TextBox ID="txtWebManager_mobile" runat="server" MaxLength="11"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">邮箱：</td>
                                    <td>
                                        <asp:TextBox ID="txtWebManager_Email" runat="server" MaxLength="50"></asp:TextBox>
                                        <span class="auto-style2">*</span></td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">报错邮件</td>
                                    <td>
                                       <asp:DropDownList ID="ddlWebManager_Recieve_AlertEmail" runat="server">
                                            <asp:ListItem Value="0" Selected="True">不接收</asp:ListItem>
                                            <asp:ListItem Value="1">接收</asp:ListItem>
                                        </asp:DropDownList>一般技术人员才接收</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="确认提交" OnClick="btnSubmit_Click" />
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
