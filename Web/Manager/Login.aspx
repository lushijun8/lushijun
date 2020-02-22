<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Login.aspx.cs" Inherits="Web.Manager.Login"
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TeamTool</title>
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="full-screen" content="yes" />
    <link href=<%=Business.Config.ResourcePath %>css/style.css?Version=<%=Business.Config.Version %> rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="<%=Business.Config.ResourcePath %>js/jquery-1.8.3.min.js"></script>
</head>
<body id="loginbg"> 
    <form id="form1" runat="server">              
        <img src="<%=Business.Config.HostUrl %>/images/background/<%=this.img%>.jpg" style="display:none;" id="bgimg"/>
        <table border="0" cellpadding="5" cellspacing="1" align="center" style="margin:0px auto;background-color:#cccccc;margin-top:30%">
        <tr>
            <td colspan="2"  style="background-color:#ffffff">
                <b>TeamTool管理后台</b>
            </td>
            <td  style="background-color:#ffffff" rowspan="4">
                <img src="Login_Qrcode.aspx" height="120" width="120" /></td>
        </tr>
        <tr>
            <td style="background-color:#ffffff">
                用户名：</td>
            <td align="left" style="background-color:#ffffff">
                <asp:TextBox ID="txtUserCode" runat="server" MaxLength="20" Width="112px"></asp:TextBox><br />@fang.com
            </td>
        </tr>
        <tr>
            <td style="background-color:#ffffff">
                验证码：</td>
            <td align="left" style="background-color:#ffffff">
                <asp:TextBox ID="txtIdentifyCode" runat="server" MaxLength="10" Width="36px"></asp:TextBox>
                <asp:Button ID="btnGetIdentifyCode" runat="server" CssClass="button" OnClick="btnGetIdentifyCode_Click" Text="获取验证码" />
            </td>
        </tr>
        <tr>
            <td style="background-color:#ffffff">
                &nbsp;<asp:Literal ID="ReturnURL" runat="server" Visible="False"></asp:Literal></td>
            <td style="background-color:#ffffff">
                <asp:Button CssClass="button" ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
                <br />
                <asp:Label ID="lblError" runat="server" BackColor="Red"></asp:Label></td>
        </tr>
    </table>  
    </form>
    <script type="text/javascript">
        function setBackGround(loginbg,bgimg) {
            var rate = $(window).width() / $(window).height();
            var rate1 = $(bgimg).width() / $(bgimg).height();
            var src = $(bgimg).attr("src")
            $(loginbg).css({
                "background": "url(" + src + ")"
            });

            if (rate1 < rate)//按照窗体的高度
            {
                $(loginbg).css({
                    "background-size": "auto " + $(window).height() + "px"
                });
            }
            else//按照窗体的宽度
            {
                $(loginbg).css({
                    "background-size":  $(window).width() + "px auto"
                });
            }
        }
        $(function () {
            $("#btnGetIdentifyCode").click(function (event) {
                if ($("#txtUserCode").val() == "") {
                    window.alert("请填写用户名！");
                    return false;
                }
                else {
                    return window.confirm("确定获取验证码吗？验证码会发到您的邮箱里！");
                }
            });
            $("#btnLogin").click(function (event) {
                if ($("#txtUserCode").val() == "" || $("#txtIdentifyCode").val() == "") {
                    window.alert("请填写用户名、验证码！");
                    return false;
                }
                else {
                    return window.confirm("确定登录吗？");
                }
            });
            $("#bgimg").load(function () {
                setBackGround("#loginbg", "#bgimg");
            });
            $(window).resize(function () {
                setBackGround("#loginbg", "#bgimg");
            });
        })
    </script>
</body>
</html>
