<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_Add.aspx.cs" Inherits="Web.Manager.Bill.Bill_Add" %>


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
    <script language="javascript" src="<%=Business.Config.ResourcePath %>js/DateSelect.js?Version=<%=Business.Config.Version %>"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
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
                            <!--��ʼ-->

                            <table width="100%" border="0" cellspacing="10">
                                <tr>
                                    <td class="auto-style1">�������ͣ�</td>
                                    <td>�ͷѱ���</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">�����ˣ�</td>
                                    <td>
                                        <%=this.CurrentWebManagerRealName %>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">�����Ŷӣ�</td>
                                    <td>                                       
                                        <%=this.CurrentWebManagerLeaderRealName %>�Ŷ�</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">�������ڣ�</td>
                                    <td>

                                        <asp:TextBox ID="txt_Bill_Date" runat="server" MaxLength="12" Width="102px" onfocus="javascript:ShowCalendar(this.id)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">���ɣ�</td>
                                    <td>
                                        <asp:TextBox ID="txt_Bill_Reason" runat="server" MaxLength="12" Width="439px">����ƽ̨����ɿ���</asp:TextBox>
                                        �ü����ȷ��һ�仰˵������</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">��Ա��</td>
                                    <td>
                                        <asp:TextBox ID="txt_Bill_Staff_Worker" runat="server" MaxLength="100" Width="600px" Height="52px" TextMode="MultiLine">������ ���� ���� ������</asp:TextBox>
                                        <br />
                                        ����֮�����ÿո���������ֱ����ܺ��пո�</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">��</td>
                                    <td>
                                        <asp:TextBox ID="txt_Bill_Total_Money" runat="server" MaxLength="6" Width="65px"></asp:TextBox>
                                        Ԫ������д����������������С�ڻ���ڷ�Ʊʵ�����</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1"></td>
                                    <td>
                                        <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="ȷ���ύ" OnClick="btnSubmit_Click" />
                                        <font color="red">
                                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">&nbsp;</td>
                                    <td>
                                        <font color="red"> * ��˾�涨���ϼӰൽ��7���Ժ���ܱ����ͷѣ���ȷ�������˵�����7���Ժ��п��ڴ򿨼�¼����Ϳ�����7��ǰԤ��������Ϊ�����鿼�ڣ���ĩ�Ӱ౨����Ҳ��Ҫ�п��ڴ򿨼�¼��</font><br />
                                        <font color="red"> * ���ڷ�Ʊ����ǩ�ϱ����˵�������ͬ��ͬ�ߴ�ķ�Ʊ���ŷ�Ʊ����ý�ˮ����һ���ٽ�������Ŷӳ�</font> <%=this.CurrentWebManagerLeaderRealName %>��<br />   
                                        <font color="red"> * ����Ʊ���λ����<font color=black>�����갶ͼ�����缼�����޹�˾</font>���������ȷ���ܱ�����</font><br /> 
                                        <font color="red"> * �Ӱ�ͷѱ���ʹ�ù�˰�ּ��Ƶķ�Ʊ���ܱ�����</font><br />  
                                        <font color="red"> * һ�μӰ�ļ����ˣ�һ�𶩲͵��ˣ�����һ��ͳһ�������ɡ�</font><br />   
                                        <img src="../../images/bill.png" />                                   
                                     <%--   <font color="red"> * ÿ��Ӱ�����ʱ����Ҫ���ʼ��������ް�caoyanbai@fang.com���������͸�����Ŷӳ������б������������Ӱ��ʱ���Դ�Ϊ���ݡ�Ҫ�����£�</font><br /> 
                                        <font color="red">01���Ӱ��������ʱ���͡�</font><br />
                                        <font color="red">02��һ�μӰ�ļ����ˣ�һ�������ˣ�����һ��ͳһ���ʼ����ɡ�</font><br />
                                        <font color="red">03���ʼ�����Ϊ���Ӱ౸�� xxxx-xx-xx xx:xx:xx���������г���Ա�������ɡ�</font><br />--%> 
                                    </td>
                                </tr>
                            </table>
                     </td> 
                </tr>
            </table>
        </div>
        <div style="width: 100%; height: 100%; background-color: lightgray; z-index: 9999; display: none; position: absolute; top: 0px; left: 0px; vertical-align: middle;" id="Loading">
            <div style="top: 200px; left: 300px; position: absolute"><b>�ύ��,��ȴ�....</b></div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function (event) {
                if (window.confirm("ȷ���ύ��") == true)
                {
                    $("#Loading").show();
                    return true;
                }
                else
                {
                    return false;
                }
            });
        })
    </script>
</body>
</html>
