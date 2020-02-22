<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Share_View_List.aspx.cs" Inherits="Web.Manager.Share.Share_View_List" %>

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
                共查到<font color=red><%=this.LogCount.ToString() %></font>条记录。  关键字<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:Button CssClass="button" ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />
                 <!--开始-->
	            <table id="messagelist" width="100%" border="0" cellspacing="0" cellpadding="0" >
		            <tr>
			            <th>序号</th>
			            <th>日期</th>
			            <th>姓名</th>
			            <th>学习内容</th>
			            <th>图片</th>
		            </tr>
		            <asp:Repeater ID="rptLog" runat="server" EnableViewState="false">
			            <ItemTemplate>
				            <tr <%# (Container.ItemIndex+1)%2==0?"class='b'":"" %>>
                                <td><%# (Container.ItemIndex+1)+(this.P_page-1)*20%></td> 
                                <td width="120"><%#Eval("CreateTime").ToString() %></td>
                                <td width="100"><%# Eval("WebManager_RealName") %></td>
                                <td><%# Eval("Article_text") %></td>
                                <td>
                                    <img onclick="javascript:bg_View(this.src);return false;" src="<%# Business.Config.HostUrl+"/images/background/"+ Eval("View_Bg_No").ToString().PadLeft(3,'0')+".jpg" %>"  height="30"/>
                                </td>
				            </tr>
			            </ItemTemplate>
		            </asp:Repeater>
	            </table>
			<!--结束-->
	  		</div> 
	  		<div class="Body_Pages"><%=this.outPage %></div>
          </td>
        <td class="r2">&nbsp;</td>
      </tr>
    </table>
  </div>        
        <div id="bg_View" style="display:none; background-image:url(/images/background/001.jpg);z-index:10000;width:100%;height:2024px;top:0px;left:0px;position:absolute;background-repeat:no-repeat; background-size:100%;">
        </div>
        <script language="javascript">
            $("#bg_View").click(function ()
            {
                $(this).hide();
            });
            function bg_View(href)
            {
                var img = new Image();
                img.src = href;
                img.width = $(window).width();
                var bg_Height = img.height;
                if (bg_Height < $(document).height()) {
                    bg_Height = $(document).height();
                }

                $("#bg_View").css({
                    "background-image": "url(" + href + ")",
                    "height": bg_Height
                });
                $("#bg_View").show();
            }
        </script>
    </form>
</body>
</html>
