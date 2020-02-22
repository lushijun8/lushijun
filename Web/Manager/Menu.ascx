<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Web.Manager.Menu"
    EnableTheming="false" %>
<script language="javascript" type="text/javascript" src="<%=Business.Config.ResourcePath %>js/jquery-1.8.3.min.js"></script>
<!--menu开始-->
<%=menu %>
<img src="<%=Business.Config.HostUrl %>/images/background/<%=this.bg_no.ToString().PadLeft(3,'0')%>.jpg" style="display:none;" id="bgimg"/>
<div id="loginbg" style="display:<%=this.msg_display%>;">    
    <img id="close_img" src="<%=Business.Config.HostUrl %>/images/close.png" onclick="javascript:$('#loginbg').hide();" /><div id="msg">一句话道理:<BR />&nbsp;&nbsp;&nbsp;&nbsp;<%=this.msg.Replace("\t","&nbsp;").Replace("\r\n","<br/>") %>（<a href="<%=Business.Config.HostUrl %>/Manager/Share/Share_Article_Good.aspx?Article_Id=<%=this.Article_Id %>" target="_blank">点赞</a>）</div>
</div>
<img id="qrcode_copy" src="" style="display:none; margin: 0 auto;position:fixed;top:29px;left:64px;z-index:100000;"/>
<!--menu结束-->

<script type="text/javascript">
    function clearshow() {
        $("#module li").each(function () {
            $(this).attr("class", "menu off");
            //$("#module").hide();
            $("#" + $(this).attr("id") + "_menu").attr("class", "menu off");
        });
    }
    function setBackGround(loginbg, bgimg) {     
        var rate = $(window).width() / $(window).height();
        var rate1 = $(bgimg).width() / $(bgimg).height();
        var src = $(bgimg).attr("src")
        $(loginbg).css({
            "background": "url(" + src + ")",            
            "height": $(window).height() + "px",
            "width": $(window).width() + "px",
            "top": "0px",
            "position": "fixed",
            "z-index": "900000"
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
                "background-size": $(window).width() + "px auto"
            });
        }
    }
    function msgcss() {
        $('#msg').width(($(window).width()/2)+"px");
        $('#msg').css({
            position: "fixed",
            "font-size": "<%=this.fontsize%>pt",
            left: ($(window).width() - $('#msg').outerWidth()) / 2,
            margin: "0 auto",
            top: ($(window).height() - $('#msg').outerHeight()) / 2
        });
        //$('#close_img').css({
        //    left: $(window).width() - $('#close_img').outerWidth()
        //});
    }
    function showmsg() {
        $('#loginbg').show();
        msgcss();
    }
    $(document).ready(function () {
        $("<div id='div_tooltip' style='display:none'></div>").appendTo($("body"));
        $(".phone_tooltip,.bug_tooltip,.sql_tooltip,.depend_tooltip,.indexs_tooltip,.tooltip").mousemove(function (e) {

            $("#div_tooltip").html("");
            if ($(this).attr("titles") != "") {
                $("#div_tooltip").html($(this).attr("titles"));
                $("#div_tooltip").css("max-width", $(window).width() - 10);
                $("#div_tooltip").show();
                var tooltip_top = e.y || e.originalEvent.layerY || 0;
                if (e.originalEvent.layerY) {
                    $("#div_tooltip").css("position", "absolute");
                }
                else {
                    $("#div_tooltip").css("position", "fixed");
                }
                $("#div_tooltip").css("top", tooltip_top + 8);
                var ex = e.x || e.originalEvent.layerX || 0;
                var tooltip_left = ex - $("#div_tooltip").width() / 2;
                $("#div_tooltip").css("left", 5);
                if (tooltip_left < 5) {
                    $("#div_tooltip").css("left", 5);
                }
                else {
                    $("#div_tooltip").css("left", tooltip_left);
                }
                if ($("#div_tooltip").width() < $(window).width() - ex) {
                    $("#div_tooltip").css("left", ex + 13);
                }
                $("#div_tooltip").css("padding", 2);
            }
        });
        $("#div_tooltip").mouseout(function () {
            $("#div_tooltip").hide();
        });
        $("#div_tooltip").mouseover(function () {
            $("#div_tooltip").show();
        });
        $("body").click(function () {
            //clearshow();
        });
        $("#menu").click(function () {
            if ($("#module").is(":hidden")) {
                $("#module").show();
            }
            else {
                $("#module").hide();
                clearshow();
            }
        });
        $("#qrcode").mouseover(function () {
            $("#qrcode_copy").attr("src", $(this).attr("src"));
            $("#qrcode_copy").show();
        }).mouseout(function () {
            $("#qrcode_copy").hide();
        });
        $("#module li").each(function () {
            $(this).mouseover(function () {
                clearshow();
                $(this).attr("class", "menu on");
                $("#" + $(this).attr("id") + "_menu").attr("class", "menu on");
                $("#" + $(this).attr("id") + "_menu").css("top", $(this).offset().top + "px");
                $("#" + $(this).attr("id") + "_menu").css("left", ($(this).offset().left + 68) + "px");
            });
            $(this).click(function () {
                clearshow();
                $(this).attr("class", "menu on");
                $("#" + $(this).attr("id") + "_menu").attr("class", "menu on");
                $("#" + $(this).attr("id") + "_menu").css("top", $(this).offset().top + "px");
                $("#" + $(this).attr("id") + "_menu").css("left", ($(this).offset().left + 68) + "px");
            });
        });
        $(window).resize(function () {
            msgcss();
            setBackGround("#loginbg", "#bgimg");
        });
        $(window).resize();
        //----------------------------------------------
        var _move = false;//移动标记  
        var _x, _y;//鼠标离控件左上角的相对位置  
        $("#msg").click(function () {
            //alert("click");//点击（松开后触发）  
        }).mousedown(function (e) {
            _move = true;
            _x = e.pageX - parseInt($("#msg").css("left"));
            _y = e.pageY - parseInt($("#msg").css("top"));
            $("#msg").fadeTo(20, 0.3);//点击后开始拖动并透明显示  
        }).mouseover(function () {
            $("#msg").css({
                background: "rgba(255, 255, 255, 1)"
            });
        }).mouseout(function () {
            $("#msg").css({
                background: "rgba(255, 255, 255, 0.20)"
            });
        });
        $(document).mousemove(function (e) {
            if (_move) {
                var x = e.pageX - _x;//移动时根据鼠标位置计算控件左上角的绝对位置  
                var y = e.pageY - _y;
                $("#msg").css({ top: y, left: x });//控件新位置
            }
        }).mouseup(function () {
            _move = false;
            $("#msg").fadeTo("fast", 1);//松开鼠标后停止移动并恢复成不透明
        });
        $("#plus").click(function () {
            if ($("#div_plus").is(":visible")) {
                $("#plus").attr("src", "<%=Business.Config.HostUrl %>/images/plus.gif")
            }
            else {
                $("#plus").attr("src", "<%=Business.Config.HostUrl %>/images/hide.gif")
            }
            $("#div_plus").toggle(300);
        });
        $("#bgimg").load(function () {
            setBackGround("#loginbg", "#bgimg");
        });
    });
</script>