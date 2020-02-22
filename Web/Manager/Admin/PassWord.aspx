<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassWord.aspx.cs" Inherits="Web.Manager.Admin.PassWord" %>

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
            width: 16px;
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
                        <div class="Body_PageContent">
                            <p>输入原密码：<asp:TextBox runat="server" ID="txt_Password" TextMode="Password"></asp:TextBox></p>
                            <p>输入新密码：<asp:TextBox runat="server" ID="txt_Password_New" TextMode="Password"></asp:TextBox></p>
                            <p>新密码确认：<asp:TextBox runat="server" ID="txt_Password_New1" TextMode="Password"></asp:TextBox></p>
                            <p>
                                <asp:Button CssClass="button" runat="server" ID="btnSubmit" Text="确认修改密码" OnClick="btnSubmit_Click" />&nbsp;<font color="red"><asp:Literal
                                    ID="ltrError" runat="server" EnableViewState="false"></asp:Literal></font>
                            </p>
                            <p>&nbsp;</p>
                            <p>--请填写正确手机号和邮箱，否则不能正常登录--</p>
                            <p>&nbsp;</p>
                            <p>手&nbsp;机&nbsp;号：<asp:TextBox runat="server" ID="txt_Mobile"></asp:TextBox></p>
                            <p>邮&nbsp;&nbsp;&nbsp;&nbsp;箱：<asp:TextBox runat="server" ID="txt_Email"></asp:TextBox></p>
                            <p>
                                <asp:Button CssClass="button" runat="server" ID="btnSubmit1" Text="确认修改资料" OnClick="btnSubmit1_Click" />&nbsp;<font color="red"><asp:Literal
                                    ID="ltrError1" runat="server" EnableViewState="false"></asp:Literal></font>
                            </p>
                            <!--结束-->
                        </div>

                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function (event) {
                if( $("#txt_Password").val()==""||$("#txt_Password_New").val()==""||$("#txt_Password_New1").val()=="")
                {
                    window.alert("请填写完毕！");
                    return false;
                }
            });
            $("#btnSubmit1").click(function (event) {
                if ($("#txt_Mobile").val() == "" || $("#txt_Email").val() == "") {
                    window.alert("请填写完毕！");
                    return false;
                }
            });
        })
    </script>
</body>
</html>
