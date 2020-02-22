using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Com.AutoCode
{
    public class TableDescriptionCoder
    {
        public static string GetAutoCode(Microsoft.Practices.EnterpriseLibrary.Data.Database DataBaseOwner, string DataBase_IP, string imagespath)
        {
            bool bShowData = true;
            if (string.IsNullOrEmpty(imagespath))
            {
                imagespath = "http://newhouse.js.soufunimg.com/xfds/channelsales/Resource/Script/jquery.ui/images";
            }
            string jquery = Com.Net.UrlRequest.GetResponse("http://newhouse.js.soufunimg.com/xfds/channelsales/Resource/Script/jquery.js", "");
            string DataBase_Name = DataBaseOwner.GetConnection().Database;
            #region FileContent
            string FileContent = @"<html><head> <title>数据库" + DataBase_IP + ".." + DataBase_Name + "表结构说明,共{TableCount}张表(" + System.DateTime.Now.ToString() + @")</title>
<meta http-equiv=" + "\"" + @"Content-Type" + "\"" + @" content=" + "\"" + @"text/html; charset=gb2312" + "\"" + @" />
<style>
ul{margin-left: 0px;padding-left: 0px;}
li{float: left;width:{li_width}px;list-style:none;border:1px solid #cccccc;margin:1px;}
li.A,li.H,li.O,li.V{background-color:#C7E3BE}
li.B,li.I,li.P,li.W{background-color:#c6e7ff}
li.C,li.J,li.Q,li.X{background-color:#F9D82B}
li.D,li.K,li.R,li.Y{background-color:#ffffff}
li.E,li.L,li.S,li.Z{background-color:#95E8D6}
li.F,li.M,li.T{background-color:#f0f0f0}
li.G,li.N,li.U{background-color:#FEB8E9}
a.ds{float:right;margin-right:3px;width:12px;height:12px;background:url(" + "\"" + @"" + imagespath + @"ui-icons_222222_256x240.png" + "\"" + @") no-repeat scroll 80%;}
a.dt{float:right;margin-right:3px;width:12px;height:12px;background:url(" + "\"" + @"" + imagespath + @"ui-icons_222222_256x240.png" + "\"" + @") no-repeat scroll 53%;}
a.my{float:right;margin-right:3px;width:12px;height:12px;background:url(" + "\"" + @"" + imagespath + @"ui-icons_222222_256x240.png" + "\"" + @") no-repeat scroll 33% 57%;}
a.notmy{float:right;margin-right:3px;width:12px;height:12px;background:url(" + "\"" + @"" + imagespath + @"ui-icons_222222_256x240.png" + "\"" + @") no-repeat scroll 27% 64%;}
a.mys{float:right;margin-right:3px;width:12px;height:12px;background:url(" + "\"" + @"" + imagespath + @"ui-icons_222222_256x240.png" + "\"" + @") no-repeat scroll 60% 43%;}
a.indexs_tooltip{float:right;margin-right:3px;width:12px;height:12px;background: url(" + "\"" + @"" + imagespath + @"indexs.gif" + "\"" + @") no-repeat;}
div.fixed_div{cursor:pointer;color:red;position:fixed;float:right;right:2px;background-color:#f0f0f0;width:22px;border:#000000 1px solid;text-align:center;padding:3px;}
body,table,th,td{font-size:9pt;padding:5px;}
table{border-spacing: 1px;background-color: black;padding: 0px;margin-bottom: 10px;border: medium none;}
table.Dst{width:100%;}
table.Dtt{display:none;}
td{background-color:#ffffff;}
td.bl{color:blue;}
td.ipt{padding:0px;width:50%;cursor:pointer;}
textarea{border:none;}
span.exp{color:red;cursor:pointer;}
span.cl{color:red;cursor:pointer;float:right;}
th,tr.title td{background-color:#cccccc;cursor:pointer;font-weight:bold;}
a{text-decoration:none;color:#000000;}
#bg{z-index:10000;background-color:rgba(128, 128, 128, 0.76);width:100%;height:100%;position:fixed;left:0px;top:0px;margin:0px;padding:0px;display:none;}
#loading{z-index: 10009;background-color:rgba(128, 128, 128, 0.76);position: fixed; width:100%;height:100%; left: 0px; top: 0px; display: none; opacity: 0.9;padding:5px;}
#log{z-index: 20000;display: none;background-color: lightyellow;border: 1px solid #cccccc;}
#div_tooltip{border: 1px solid #cccccc; background-color: lightyellow; position: absolute;line-height: 100%;overflow: auto;};
</style>
<script type=" + "\"" + @"text/javascript" + "\"" + @">
" + jquery + @"
</script>
<script type=" + "\"" + @"text/javascript" + "\"" + @">
function sDst(id)
{
if(!$(" + "\"" + @"#bg" + "\"" + @").is(" + "\"" + @":hidden" + "\"" + @")){return;}
var obj = $(" + "\"" + @"#" + "\"" + @"+id);
obj.show();
obj.css(" + "\"" + @"zIndex" + "\"" + @", " + "\"" + @"10001" + "\"" + @");
obj.css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"absolute" + "\"" + @");
obj.css(" + "\"" + @"top" + "\"" + @", document.body.scrollTop + 20 + " + "\"" + @"px" + "\"" + @");
obj.css(" + "\"" + @"width" + "\"" + @", " + "\"" + @"700px" + "\"" + @");
if (window.innerWidth > 700) { obj.css(" + "\"" + @"left" + "\"" + @",((window.innerWidth - 700) / 2)+" + "\"" + @"px" + "\"" + @"); }
$(" + "\"" + @"#bg" + "\"" + @").show();
$(" + "\"" + @"#CrDst" + "\"" + @").val(id);
}
function cDst(id)
{
$(" + "\"" + @"#" + "\"" + @"+id).hide();
$(" + "\"" + @"#bg" + "\"" + @").hide();
$(" + "\"" + @"#" + "\"" + @"+id).css(" + "\"" + @"width" + "\"" + @", " + "\"" + @"700px" + "\"" + @");
$(" + "\"" + @"#" + "\"" + @"+id).css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"initial" + "\"" + @");
}

function sDtt(id)
{
if(!$(" + "\"" + @"#bg" + "\"" + @").is(" + "\"" + @":hidden" + "\"" + @")){return;}
var obj = $(" + "\"" + @"#" + "\"" + @"+id);
obj.show();
obj.css(" + "\"" + @"zIndex" + "\"" + @", " + "\"" + @"10001" + "\"" + @");
obj.css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"absolute" + "\"" + @");
obj.css(" + "\"" + @"top" + "\"" + @", document.body.scrollTop + 20 + " + "\"" + @"px" + "\"" + @");
$(" + "\"" + @"#bg" + "\"" + @").show();
$(" + "\"" + @"#CrDtt" + "\"" + @").val(id);
}
function cDtt(id)
{
$(" + "\"" + @"#" + "\"" + @"+id).hide();
$(" + "\"" + @"#bg" + "\"" + @").hide();
$(" + "\"" + @"#" + "\"" + @"+id).css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"initial" + "\"" + @");
}
function closeAllTable()
{
if($(" + "\"" + @"#CrDst" + "\"" + @").val()!=" + "\"\"" + @")
{
cDst($(" + "\"" + @"#CrDst" + "\"" + @").val());
}
if($(" + "\"" + @"#CrDtt" + "\"" + @").val()!=" + "\"\"" + @")
{
cDtt($(" + "\"" + @"#CrDtt" + "\"" + @").val());
}
}
function showAllDst()
{
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"#ffffff" + "\"" + @");
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"#cc0000" + "\"" + @");
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#CrDst" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @"#CrDtt" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @".Dtt" + "\"" + @").hide();
    $(" + "\"" + @".Dst" + "\"" + @").show();
    $(" + "\"" + @"#filter" + "\"" + @").show();
    $(" + "\"" + @".Dst" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @".Dst" + "\"" + @").css(" + "\"" + @"width" + "\"" + @", " + "\"" + @"100%" + "\"" + @");
}
function showAllDtt()
{
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"#ffffff" + "\"" + @");
    $(" + "\"" + @"#datas" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"#cc0000" + "\"" + @");
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#designs" + "\"" + @").css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @"#CrDst" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @"#CrDtt" + "\"" + @").val(" + "\"\"" + @");
    $(" + "\"" + @".Dst" + "\"" + @").hide();
    $(" + "\"" + @".Dtt" + "\"" + @").show();
    $(" + "\"" + @"#filter" + "\"" + @").hide();
    $(" + "\"" + @".Dtt" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"" + "\"" + @");
    $(" + "\"" + @".Dtt" + "\"" + @").css(" + "\"" + @"width" + "\"" + @", " + "\"\"" + @");
}
function sli(classname)
{
    if($(" + "\"" + @"#exp_" + "\"" + @" + classname).text()==" + "\"" + @"-" + "\"" + @")
    {
        $(" + "\"" + @".x_" + "\"" + @"+classname" + @").hide();
        $(" + "\"" + @"#exp_" + "\"" + @" + classname).text(" + "\"" + @"+" + "\"" + @")
    }
    else
    {
        $(" + "\"" + @".x_" + "\"" + @"+classname" + @").show();
        $(" + "\"" + @"#exp_" + "\"" + @" + classname).text(" + "\"" + @"-" + "\"" + @")
    }
}
function expAll()
{
    if($(" + "\"" + @"#expall" + "\"" + @").text()==" + "\"" + @"-" + "\"" + @")
    {
        $(" + "\"" + @"#expall" + "\"" + @").text(" + "\"" + @"+" + "\"" + @")
        $(" + "\"" + @".x_all" + "\"" + @").hide();      
        $(" + "\"" + @".Dst" + "\"" + @").hide();
        $(" + "\"" + @".Dtt" + "\"" + @").hide();
        $(" + "\"" + @".exp_pl" + "\"" + @").text(" + "\"" + @"+" + "\"" + @");
    }
    else
    {
        $(" + "\"" + @"#expall" + "\"" + @").text(" + "\"" + @"-" + "\"" + @")
        $(" + "\"" + @".x_all" + "\"" + @").show();        
        $(" + "\"" + @".Dst" + "\"" + @").show();
        $(" + "\"" + @".Dst" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"" + "\"" + @");
        $(" + "\"" + @".Dtt" + "\"" + @").hide();
        $(" + "\"" + @".exp_pl" + "\"" + @").text(" + "\"" + @"-" + "\"" + @");
    }
}
function filterColumn()
{
    var cc=0;
    if($(" + "\"" + @"#cb_t" + "\"" + @").is(':checked')==true)
    {     
        $(" + "\"" + @".c_t" + "\"" + @").show();
        cc=cc+1;
    }
    else{
        $(" + "\"" + @".c_t" + "\"" + @").hide();
    } 
    if($(" + "\"" + @"#cb_p" + "\"" + @").is(':checked')==true)
    {     
        $(" + "\"" + @".c_p" + "\"" + @").show();
        cc=cc+1;
    }
    else{
        $(" + "\"" + @".c_p" + "\"" + @").hide();
    }
    if($(" + "\"" + @"#cb_n" + "\"" + @").is(':checked')==true)
    {     
        $(" + "\"" + @".c_n" + "\"" + @").show();
        cc=cc+1;
    }
    else{
        $(" + "\"" + @".c_n" + "\"" + @").hide();
    } 
    if($(" + "\"" + @"#cb_i" + "\"" + @").is(':checked')==true)
    {     
        $(" + "\"" + @".c_i" + "\"" + @").show();
        cc=cc+1;
    }
    else{
        $(" + "\"" + @".c_i" + "\"" + @").hide();
    }
    if($(" + "\"" + @"#cb_d" + "\"" + @").is(':checked')==true)
    {     
        $(" + "\"" + @".c_d" + "\"" + @").show();
        cc=cc+1;
    }
    else{
        $(" + "\"" + @".c_d" + "\"" + @").hide();
    }
    if($(" + "\"" + @"#cb_r" + "\"" + @").is(':checked')==true)
    {     
        $(" + "\"" + @".c_r" + "\"" + @").show();
        cc=cc+1;
    }
    else{
        $(" + "\"" + @".c_r" + "\"" + @").hide();
    } 
    cc=cc+1;
    $(" + "\"" + @".tbc" + "\"" + @").attr(" + "\"" + @"colspan" + "\"" + @",cc);
}
function seticon()
{
    $(" + "\"" + @".ds" + "\"" + @").text(" + "\"" + @"+" + "\"" + @");
    $(" + "\"" + @".dt" + "\"" + @").text(" + "\"" + @".." + "\"" + @");
}
function input_focus(id) {
            $(" + "\"" + @"#des" + "\"" + @").val($(" + "\"" + @"#" + "\"" + @" + id).val());
            $(" + "\"" + @"#" + "\"" + @" + id).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"yellow" + "\"" + @");
        }
        function input_blur(id) {
            var des_new = $(" + "\"" + @"#" + "\"" + @" + id).val();
            if ($(" + "\"" + @"#des" + "\"" + @").val() != des_new)
             {
                if (window.confirm(" + "\"" + @"该字段说明被修改过，是否要提交到数据库？" + "\"" + @") == true)
                {
                    $(" + "\"" + @"#loading" + "\"" + @").show();
                    var data = " + "\"" + @"ip=" + "\"" + @" + encodeURI(" + "\"" + Com.Common.EncDec.Encrypt(DataBase_IP, "fang.com") + "\"" + @");
                    data = data + " + "\"" + @"&database=" + "\"" + @" + encodeURI(" + "\"" + Com.Common.EncDec.Encrypt(DataBase_Name, "fang.com") + "\"" + @");
                    data = data + " + "\"" + @"&tableColumn=" + "\"" + @" + encodeURI(id);
                    data = data + " + "\"" + @"&des=" + "\"" + @" + encodeURI(encodeURI(des_new));
                    //data = data + " + "\"" + @"&des=" + "\"" + @" + des_new;
                    //查询
                    $.ajax({
                        async: true,
                        type: " + "\"" + @"POST" + "\"" + @",
                        url: " + "\"" + @"DataBase_Update_ColumnDescription.aspx" + "\"" + @",
                        cache: false,
                        timeout:10 * 1000,
                        dataType: " + "\"" + @"json" + "\"" + @",
                        data: data,
                        success: function (result) {
                            if (result.Message == " + "\"" + @"Success" + "\"" + @") {
                                window.alert(" + "\"" + @"更新成功！" + "\"" + @"+result.Error);
                                $(" + "\"" + @"#des" + "\"" + @").val(des_new);
                            }
                            else {
                                window.alert(result.Message);
                                $(" + "\"" + @"#" + "\"" + @" + id).val($(" + "\"" + @"#des" + "\"" + @").val());
                            }
                            $(" + "\"" + @"#" + "\"" + @" + id).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
                            $(" + "\"" + @"#loading" + "\"" + @").hide();
                        },
                        error: function (result) {
                            window.alert(" + "\"" + @"更新失败！可能你没有权限。" + "\"" + @");
                             $(" + "\"" + @"#" + "\"" + @" + id).val($(" + "\"" + @"#des" + "\"" + @").val());
                             $(" + "\"" + @"#" + "\"" + @" + id).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
                             $(" + "\"" + @"#loading" + "\"" + @").hide();
                        }
                    });
                 }
                 else
                 {
                    $(" + "\"" + @"#" + "\"" + @" + id).val($(" + "\"" + @"#des" + "\"" + @").val());
                    $(" + "\"" + @"#" + "\"" + @" + id).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
                 }
            }
            else {
                $(" + "\"" + @"#" + "\"" + @" + id).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
            }
            //恢复原值
            var td_html = $(" + "\"" + @"#" + "\"" + @" + id).val().replace(new RegExp(" + "\"" + @"\r\n" + "\"" + @", " + "\"" + @"g" + "\"" + @"), " + "\"" + @"<br>" + "\"" + @").replace(new RegExp(" + "\"" + @"\n" + "\"" + @", " + "\"" + @"g" + "\"" + @"), " + "\"" + @"<br>" + "\"" + @").replace(new RegExp(" + "\"" + @"\t" + "\"" + @", " + "\"" + @"g" + "\"" + @"), " + "\"" + @"&nbsp;" + "\"" + @");
            $(" + "\"" + @"#td_" + "\"" + @" + id).html(td_html);
        }              
        function Add_Delete_My(v,index,type)
        {
            var myhtml=$(" + "\"" + @"#m" + "\"" + @"+index).html();
            var clsname=" + "\"" + @"" + "\"" + @";
            var typename=" + "\"" + @"" + "\"" + @";
            var typename_anti=" + "\"" + @"" + "\"" + @";
            var type_anti=" + "\"" + @"" + "\"" + @";
            if(type==" + "\"" + @"Delete" + "\"" + @")
            { 
                typename=" + "\"" + @"删除认领" + "\"" + @";
                typename_anti=" + "\"认领" + @"" + "\"" + @";
                clsname=" + "\"" + @"not" + "\"" + @";
                type_anti=" + "\"" + @"Add" + "\"" + @";
            }
            else{
                typename=" + "\"" + @"认领" + "\"" + @";
                typename_anti=" + "\"" + @"删除认领" + "\"" + @";
                clsname=" + "\"" + @"" + "\"" + @";
                type_anti=" + "\"" + @"Delete" + "\"" + @";
            }
            if(window.confirm(" + "\"" + @"确定" + "\"" + @"+typename+" + "\"" + @"吗?" + "\"" + @")==true)
            { 
                $(" + "\"" + @"#m" + "\"" + @"+index).html(" + "\"" + @"<img src='" + imagespath + @"loading.gif' height='10' style='float:right;' />" + "\"" + @");
                $.ajax({
                    async: true,
                    type: " + "\"" + @"GET" + "\"" + @",
                    url: " + "\"" + @"DataBase_Table_My_" + "\"" + @"+type+" + "\"" + @"_Json.aspx?v=" + "\"" + @"+v,
                    cache: false,
                    timeout: 10 * 1000,
                    dataType: " + "\"" + @"json" + "\"" + @",
                    data: " + "\"" + @"" + "\"" + @",
                    success: function (result) {
                        if (result.Message == " + "\"" + @"Success" + "\"" + @") {
                            //window.alert(typename+" + "\"" + @"成功!" + "\"" + @")
                            $(" + "\"" + @"#m" + "\"" + @"+index).html(" + "\"" + @"<a  href=" + "\\\"" + @"javascript:void(0);" + "\\\"" + @" onclick=" + "\\\"" + @"javascript:Add_Delete_My('" + "\"" + @"+v+" + "\"" + @"','" + "\"" + @"+index+" + "\"" + @"','" + "\"" + @"+type_anti+" + "\"" + @"');" + "\\\"" + @" class=" + "\\\"" + @"" + "\"+clsname+\"" + "my tooltip" + "\\\"" + @" titles=" + "\\\"" + @"点击可" + "\"+typename_anti+\"" + "" + "\\\"" + @"></a>" + "\"" + @");
                        }
                        else{
                            window.alert(typename+" + "\"" + @"失败!" + "\"" + @")
                            $(" + "\"" + @"#m" + "\"" + @"+index).html(myhtml);
                        }                  
                    }
                });
            }
        }
        $(document).ready(function () {
            $(" + "\"" + @".ipt" + "\"" + @").click(function () {
                if ($(this).html().indexOf(" + "\"" + @"<textarea" + "\"" + @", 0) < 0) {
                     var text = $(this).html();
                    text = text.replace(new RegExp(" + "\"" + @"<br>" + "\"" + @", " + "\"" + @"g" + "\"" + @"), " + "\"" + @"\n" + "\"" + @").replace(new RegExp(" + "\"" + @"<br/>" + "\"" + @", " + "\"" + @"g" + "\"" + @"), " + "\"" + @"\n" + "\"" + @").replace(new RegExp(" + "\"" + @"&nbsp;" + "\"" + @", " + "\"" + @"g" + "\"" + @"), " + "\"" + @"\t" + "\"" + @");
                    var id = $(this).attr(" + "\"" + @"id" + "\"" + @").substring(3);
                    $(this).html(" + "\"" + @"<textarea style='padding:0px;width:" + "\"" + @" + $(this).width() + " + "\"" + @"px;height:" + "\"" + @" + $(this).height() + " + "\"" + @"px;overflow:auto' id='" + "\"" + @" + id + " + "\"" + @"' onfocus='javascript:input_focus(this.id);' onblur='javascript:input_blur(this.id);'>" + "\"" + @" + text + " + "\"" + @"</textarea>" + "\"" + @");
                }
                $(" + "\"" + @"#" + "\"" + @" + id).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"yellow" + "\"" + @");
                $(" + "\"" + @"#" + "\"" + @" + id).focus();
            }).mouseover(function (e) {
                var id = $(this).attr(" + "\"" + @"id" + "\"" + @").substring(3);
                $(this).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"yellow" + "\"" + @");
                $(" + "\"" + @"#log" + "\"" + @").html(" + "\"" + @"点击可修改<p>修改日志加载中...</p>" + "\"" + @");
                var data=" + "\"" + @"" + "\"" + @";
                $.ajax({
                    async: true,
                    type: " + "\"" + @"GET" + "\"" + @",
                    url: " + "\"" + @"DataBase_Table_UpdateLog.aspx?v0=" + Com.Common.EncDec.Encrypt(DataBase_IP + "," + DataBase_Name, "fang.com") + @"&v1=" + "\"" + @" + id + " + "\"" + @"" + "\"" + @",
                    cache: false,
                    timeout: 10 * 1000,
                    dataType: " + "\"" + @"json" + "\"" + @",
                    data: data,
                    success: function (result) {
                        if (result.Message == " + "\"" + @"Success" + "\"" + @") {
                            $(" + "\"" + @"#log" + "\"" + @").html(result.Log);
                        }                      
                    }
                });
                $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"max-width" + "\"" + @", $(window).width() - 10);
                $(" + "\"" + @"#log" + "\"" + @").show();
                var tip_top = e.y || e.originalEvent.layerY || 0;
                if (e.originalEvent.layerY) {
                    $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"absolute" + "\"" + @");
                }
                else {
                    $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"fixed" + "\"" + @");
                }
                $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"top" + "\"" + @", tip_top + 8);
                var ex = e.x || e.originalEvent.layerX || 0;
                var tip_left = ex - $(" + "\"" + @"#log" + "\"" + @").width() / 2;
                $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", 5);
                if (tip_left < 5) {
                    $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", 5);
                }
                else {
                    $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", tip_left);
                }
                if ($(" + "\"" + @"#log" + "\"" + @").width() < $(window).width() - ex) {
                    $(" + "\"" + @"#log" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", ex + 13);
                }   
            }).mouseout(function () {
                $(this).css(" + "\"" + @"background-color" + "\"" + @", " + "\"" + @"" + "\"" + @");
                $(" + "\"" + @"#log" + "\"" + @").hide();
            });
            //$(" + "\"" + @"body" + "\"" + @").bind(" + "\"" + @"contextmenu" + "\"" + @", function() { return false;});
            //$(" + "\"" + @"body" + "\"" + @").bind(" + "\"" + @"selectstart" + "\"" + @",function(){return false;});
            //-----------------------------------------------------------------------------
            $(" + "\"" + @"{script_IsMyIds}" + "\"" + @").appendTo($(" + "\"" + @"body" + "\"" + @"));
            $(" + "\"" + @"a.my" + "\"" + @").attr(" + "\"" + @"titles" + "\"," + "\"" + @"点击可删除认领" + "\"" + @");
            $(" + "\"" + @"a.notmy" + "\"" + @").attr(" + "\"" + @"titles" + "\"," + "\"" + @"点击可认领" + "\"" + @");
            $(" + "\"" + @"a.dt" + "\"" + @").attr(" + "\"" + @"titles" + "\"," + "\"" + @"点击查看数据样例" + "\"" + @");
            $(" + "\"" + @"a.ds" + "\"" + @").attr(" + "\"" + @"titles" + "\"," + "\"" + @"点击查看表结构" + "\"" + @");
            $(" + "\"" + @"a.dt" + "\"" + @").attr(" + "\"" + @"class" + "\"," + "\"" + @"dt tooltip" + "\"" + @"); 
            $(" + "\"" + @"a.ds" + "\"" + @").attr(" + "\"" + @"class" + "\"," + "\"" + @"ds tooltip" + "\"" + @"); 
            $(" + "\"" + @".indexs_tooltip" + "\"" + @").mouseover(function (e) {
                if ($(this).attr(" + "\"" + @"titles" + "\"" + @") == null) {
                    var id = $(this).attr(" + "\"" + @"id" + "\"" + @");
                    var data = " + "\"" + @"v=" + "\"" + @" + id;
                    //查询
                    $.ajax({
                        async: true,
                        type: " + "\"" + @"GET" + "\"" + @",
                        url: " + "\"" + @"Indexs.aspx" + "\"" + @",
                        cache: false,
                        timeout: 10 * 1000,
                        dataType: " + "\"" + @"json" + "\"" + @",
                        data: data,
                        success: function (result) {
                            $(" + "\"" + @"." + "\"" + @" + id.replace(" + "\"" + @"." + "\"" + @", " + "\"" + @"_" + "\"" + @")).attr(" + "\"" + @"titles" + "\"" + @", result.Message);
                        }
                    });
                }
            });
            $(" + "\"" + @"<div id='div_tooltip' style='display:none'></div>" + "\"" + @").appendTo($(" + "\"" + @"body" + "\"" + @"));
            $(" + "\"" + @".tooltip" + "\"" + @").mousemove(function (e) {
                $(" + "\"" + @"#div_tooltip" + "\"" + @").html(" + "\"" + @"" + "\"" + @");
                if ($(this).attr(" + "\"" + @"titles" + "\"" + @") != " + "\"" + @"" + "\"" + @") {
                    $(" + "\"" + @"#div_tooltip" + "\"" + @").html($(this).attr(" + "\"" + @"titles" + "\"" + @"));
                    $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"max-width" + "\"" + @", $(window).width() - 10);
                    $(" + "\"" + @"#div_tooltip" + "\"" + @").show();
                    var tooltip_top = e.y || e.originalEvent.layerY || 0;
                    if (e.originalEvent.layerY) {
                        $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"absolute" + "\"" + @");
                    }
                    else {
                        $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"position" + "\"" + @", " + "\"" + @"fixed" + "\"" + @");
                    }
                    $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"top" + "\"" + @", tooltip_top + 8);
                    var ex = e.x || e.originalEvent.layerX || 0;
                    var tooltip_left = ex - $(" + "\"" + @"#div_tooltip" + "\"" + @").width() / 2;
                    $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", 5);
                    if (tooltip_left < 5) {
                        $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", 5);
                    }
                    else
                    {
                        $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", tooltip_left);
                    }
                    if ($(" + "\"" + @"#div_tooltip" + "\"" + @").width() < $(window).width() - ex) {
                        $(" + "\"" + @"#div_tooltip" + "\"" + @").css(" + "\"" + @"left" + "\"" + @", ex+13);
                    }

                }
            });
            $(" + "\"" + @"#div_tooltip" + "\"" + @").mouseout(function () {
                $(" + "\"" + @"#div_tooltip" + "\"" + @").hide();
            });
            $(" + "\"" + @"#div_tooltip" + "\"" + @").mouseover(function () {
                $(" + "\"" + @"#div_tooltip" + "\"" + @").show();
            });
            $(" + "\"" + @"table li" + "\"" + @").mouseout(function () {
                 $(" + "\"" + @"#div_tooltip" + "\"" + @").hide();
            });
            //-----------------------------------------------------------------------------           
        });
</script></head><body><div id=" + "\"" + @"log" + "\"" + @"></div><div id=" + "\"" + @"loading" + "\"" + @">执行中...</div><input type=" + "\"hidden\"" + @" id=" + "\"" + @"des" + "\"" + @" value=" + "\"" + @"" + "\"" + @" maxlength=" + "\"" + @"499" + "\"" + @"><img height=" + "\"" + @"1" + "\"" + @" width=" + "\"" + @"1" + "\"" + @" src=" + "\"" + @"" + imagespath + @"/ui-icons_222222_256x240.png" + "\"" + @"/>
<div class=" + "\"" + @"fixed_div" + "\"" + @" style=" + "\"" + @"float:right;top:10px;" + "\"" + @">
<a href=" + "\"" + @"#top" + "\"" + @" target=_self>返回顶部</a>
</div>
<div class=" + "\"" + @"fixed_div" + "\"" + @" id=" + "\"" + @"designs" + "\"" + @" style=" + "\"" + @"right;top:100px;" + "\"" + @" onclick=" + "\"" + @"javascript:showAllDst()" + "\"" + @">
表 结 构
</div>
<div class=" + "\"" + @"fixed_div" + "\"" + @" id=" + "\"" + @"datas" + "\"" + @" style=" + "\"" + @"right;top:170px;" + "\"" + @" onclick=" + "\"" + @"javascript:showAllDtt()" + "\"" + @">
数据样例
</div>
<div class=" + "\"" + @"fixed_div" + "\"" + @" id=" + "\"" + @"expall" + "\"" + @" style=" + "\"" + @"right;top:255px;" + "\"" + @" onclick=" + "\"" + @"javascript:expAll()" + "\"" + @">-</div>
<div class=" + "\"" + @"fixed_div" + "\"" + @" id=" + "\"" + @"filter" + "\"" + @" style=" + "\"" + @"right;top:290px;width:80px;text-align:left" + "\"" + @">
<input id=" + "\"" + @"cb_t" + "\"" + @" type=" + "\"" + @"checkbox" + "\"" + @" name=" + "\"" + @"cb_t" + "\"" + @" checked=checked onclick=" + "\"" + @"javascript:filterColumn()" + "\"" + @">类型<br>
<input id=" + "\"" + @"cb_p" + "\"" + @" type=" + "\"" + @"checkbox" + "\"" + @" name=" + "\"" + @"cb_p" + "\"" + @" checked=checked onclick=" + "\"" + @"javascript:filterColumn()" + "\"" + @">是否主键<br>
<input id=" + "\"" + @"cb_n" + "\"" + @" type=" + "\"" + @"checkbox" + "\"" + @" name=" + "\"" + @"cb_n" + "\"" + @" checked=checked onclick=" + "\"" + @"javascript:filterColumn()" + "\"" + @">可空<br>
<input id=" + "\"" + @"cb_i" + "\"" + @" type=" + "\"" + @"checkbox" + "\"" + @" name=" + "\"" + @"cb_i" + "\"" + @" checked=checked onclick=" + "\"" + @"javascript:filterColumn()" + "\"" + @">自增<br>
<input id=" + "\"" + @"cb_d" + "\"" + @" type=" + "\"" + @"checkbox" + "\"" + @" name=" + "\"" + @"cb_d" + "\"" + @" checked=checked onclick=" + "\"" + @"javascript:filterColumn()" + "\"" + @">默认值<br>
<input id=" + "\"" + @"cb_r" + "\"" + @" type=" + "\"" + @"checkbox" + "\"" + @" name=" + "\"" + @"cb_r" + "\"" + @" checked=checked onclick=" + "\"" + @"javascript:filterColumn()" + "\"" + @">说明</div>
<input name=" + "\"" + @"CrDst" + "\"" + @" type=" + "\"" + @"hidden" + "\"" + @" value=" + "\"\"" + @" id=" + "\"" + @"CrDst" + "\"" + @"/>
<input name=" + "\"" + @"CrDtt" + "\"" + @" type=" + "\"" + @"hidden" + "\"" + @" value=" + "\"\"" + @" id=" + "\"" + @"CrDtt" + "\"" + @"/>
<div id=" + "\"" + @"bg" + "\"" + @" onclick=" + "\"" + @"javascript:closeAllTable();" + "\"" + @">&nbsp;</div>
<h1 id=top>数据库" + DataBase_IP + ".." + DataBase_Name + "表结构说明,共{TableCount}张表(" + System.DateTime.Now.ToString() + @")</h1><table><tr><td><ul>{TableList}</ul></td></tr></table>";
            #endregion
            string TableList = "";
            string letter = "";
            int tablename_maxlen = 0;

            Com.Data.SqlServer.Entity.SYSOBJECTS SYSOBJECTS = new Com.Data.SqlServer.Entity.SYSOBJECTS();
            SYSOBJECTS.Database_Reader = DataBaseOwner;
            SYSOBJECTS.DataBase = DataBase_Name;
            SYSOBJECTS.WhereSql = " (XTYPE='U') ";
            SYSOBJECTS.SelectColumns = new string[] { SYSOBJECTS._NAME, SYSOBJECTS._ID };
            //SYSOBJECTS.NAME = "EB_BehaviorType";
            DataTable oDt_SYSOBJECTS = SYSOBJECTS.Select();
            DataView oDv_SYSOBJECTS = oDt_SYSOBJECTS.DefaultView;
            oDv_SYSOBJECTS.Sort = "NAME";
            int TableCount = oDt_SYSOBJECTS.Rows.Count;
            int index = 0;
            string script_IsMyIds = "";
            string IsMyIds = "";
            int script_count = 60;
            int count = 0;

            foreach (DataRowView oDr_SYSOBJECTS in oDv_SYSOBJECTS)
            {
                string tablename = oDr_SYSOBJECTS[SYSOBJECTS._NAME].ToString();
                IsMyIds += tablename + ";";
                count++;
                if (count % script_count == 0)
                {
                    script_IsMyIds += @"<script src='My.aspx?v=" + System.Web.HttpUtility.UrlEncode(DataBase_Name + "@" + (((count - script_count) / script_count) * script_count) + "@" + IsMyIds.TrimEnd(';')) + @"' async='async' defer='defer'><\/script>";
                    IsMyIds = "";
                    //start_index=index
                }
                string tablename_upper = tablename.ToUpper();
                if (tablename_maxlen < tablename.Length)
                {
                    tablename_maxlen = tablename.Length;
                }
                string Sql = "";
                try
                {
                    #region
                    string[] ColumnNames;
                    string[] XDataTypes;
                    string[] Lengths;
                    string[] IsNullAbles;
                    string[] Defaults;
                    string[] Descriptions;
                    string[] PrimaryKeys;
                    string Identitys;
                    string TableComment;
                    GetProperty(DataBaseOwner, int.Parse(oDr_SYSOBJECTS[SYSOBJECTS._ID].ToString()), tablename,
                        out ColumnNames,
                        out XDataTypes,
                        out Lengths,
                        out IsNullAbles,
                        out Defaults,
                        out Descriptions,
                        out PrimaryKeys,
                        out Identitys,
                        out TableComment);

                    string primarykeys = "";
                    foreach (string PrimaryKey in PrimaryKeys)
                    {
                        if (!string.IsNullOrEmpty(PrimaryKey))
                        {
                            primarykeys += "[" + PrimaryKey + "],";
                        }
                    }
                    primarykeys = primarykeys.TrimEnd(',');
                    string columnnames = "";
                    foreach (string ColumnName in ColumnNames)
                    {
                        if (!string.IsNullOrEmpty(ColumnName))
                        {
                            columnnames += "[" + ColumnName + "],";
                        }
                    }
                    columnnames = columnnames.TrimEnd(',');
                    int topCount = 10;
                    Sql = "SELECT COUNT(1) AS COUNTS FROM [" + DataBase_Name + "]..[" + tablename + "] WITH(NOLOCK);SELECT TOP " + topCount + " " + columnnames + " FROM [" + DataBase_Name + "]..[" + tablename + "] WITH(NOLOCK)";
                    if (PrimaryKeys != null && PrimaryKeys.Length > 0 && !string.IsNullOrEmpty(primarykeys))
                    {
                        Sql += " ORDER BY " + primarykeys + " DESC";
                    }
                    DataSet oDs = DataBaseOwner.ExecuteDataSet(CommandType.Text, Sql);
                    DataTable oDt_Count = oDs.Tables[0];
                    DataTable oDt = oDs.Tables[1];
                    string prefix = "";
                    string ex_classname = "";
                    string ex_all_classname = "";
                    if (letter == tablename.Substring(0, 1).ToUpper())
                    {
                        prefix = "　 ";
                        ex_classname = " x_" + letter;
                        ex_all_classname = " x_all";
                    }
                    else
                    {
                        letter = tablename.Substring(0, 1).ToUpper();
                        prefix = "<span class=\"exp exp_pl\" id=\"exp_" + letter + "\" onclick=\"javascript:sli('" + letter + "')\">-</span><span class=\"exp\" onclick=\"javascript:sli('" + letter + "')\"><b>" + letter + "</b></span>&nbsp;";

                    }
                    TableList += "<li class=\"" + letter + ex_classname + ex_all_classname + "\">" + prefix + "<a href=\"#" + tablename + "\">" + tablename + "</a><a class=\"ds\" href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDst('design_" + tablename + "')\"></a><a class=\"dt\" href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDtt('data_" + tablename + "')\"></a><span class=ismy id=m" + index + "></span></li>";
                    FileContent += "<a id=\"" + tablename + "\"></a>";
                    if (bShowData == true)
                    {

                        FileContent += "<table cellpadding=\"0\" cellspacing=\"1\" id=\"data_" + tablename + "\" class=\"Dtt\"><tr><td colspan=" + ColumnNames.Length + "><a href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDst('design_" + tablename + "')\"><b>" + tablename + "</b> (共<font color=red>" + oDt_Count.Rows[0]["COUNTS"].ToString() + "</font>条记录) >>></a><span class=\"cl\" onclick=\"javascript:cDtt('data_" + tablename + "')\">关闭</span></td></tr>";
                        FileContent += "<tr><td colspan=" + ColumnNames.Length + ">说明：" + TableComment + "</td></tr>";
                        FileContent += "<tr class=title>";
                        for (int i = 0; i < ColumnNames.Length; i++)
                        {
                            string Primary = "";
                            string columnname = "{0}";
                            foreach (string PrimaryKey in PrimaryKeys)
                            {
                                if (ColumnNames[i].ToUpper() == PrimaryKey.ToUpper())
                                {
                                    Primary = "主键";
                                    columnname = "<font color=red>{0}</font>";
                                    break;
                                }
                            }
                            //FileContent += "<td title=\"" +
                            //    XTypes[i] + "(" + Lengths[i] + ")" +
                            //    (Identitys.ToUpper() == ColumnNames[i].ToUpper() ? "\r\n自增" : "") +
                            //     (string.IsNullOrEmpty(Primary) == false ? " " + Primary : "") +
                            //    (IsNullAbles[i] == "0" ? "\r\nNot Null" : "") +
                            //    (string.IsNullOrEmpty(Defaults[i].Trim()) == true ? "" : ("\r\nDefaults(" + Defaults[i] + ")")) +
                            //    "\r\n" + Descriptions[i] + "\">" + string.Format(columnname, ColumnNames[i]) + "</td>";
                            FileContent += "<td>" + string.Format(columnname, ColumnNames[i]) + "</td>";
                        }
                        FileContent += "</tr>";
                        foreach (DataRow oDr in oDt.Rows)
                        {
                            FileContent += "<tr>";
                            foreach (DataColumn oDc in oDt.Columns)
                            {
                                FileContent += "<td>" + System.Web.HttpUtility.HtmlEncode(Com.Common.StringUtil.GetLenContent(oDr[oDc.ColumnName].ToString(), 100)) + "</td>";
                            }
                            FileContent += "</tr>";
                        }
                        if (oDt.Rows.Count >= topCount)
                        {
                            FileContent += "<tr>";
                            foreach (DataColumn oDc in oDt.Columns)
                            {
                                FileContent += "<td>...</td>";
                            }
                            FileContent += "</tr>";
                        }

                        if (oDt.Rows.Count == 0)
                        {
                            FileContent += "<tr><td colspan=" + ColumnNames.Length + ">&nbsp;</td></tr>";
                        }
                        FileContent += "</table>";
                    }
                    string TableHtml = "<table cellpadding=\"0\" cellspacing=\"1\" id=\"design_" + tablename + "\" class=\"Dst\">" +
                        "<tr><td colspan=\"7\" class=\"tbc\"><a href=\"javascript:void(0);\" target=\"_self\" onclick=\"javascript:sDtt('data_" + tablename + "')\"><b>" + tablename + "</b> >>></a><span class=\"cl\" onclick=\"javascript:cDst('design_" + tablename + "')\">关闭</span></td></tr>" +
                        "<tr class=\"title\"><td>字段名</td><td class=\"c_t\">类型</td><td class=\"c_p\">主键</td><td class=\"c_n\">可空</td><td class=\"c_i\">自增</td><td class=\"c_d\">默认值</td><td class=\"c_r\">说明</td></tr>";

                    for (int i = 0; i < ColumnNames.Length; i++)
                    {
                        string ColumnName = ColumnNames[i];
                        string Primary = "";
                        foreach (string PrimaryKey in PrimaryKeys)
                        {
                            if (ColumnName.ToUpper() == PrimaryKey.ToUpper())
                            {
                                Primary = "是";
                                break;
                            }
                        }
                        string XDataType = XDataTypes[i];
                        string Length = Lengths[i];
                        string IsNullAble = IsNullAbles[i];
                        string Default = Defaults[i];
                        string Description = Descriptions[i];

                        string len = "";

                        string XDataType_ToUpper = XDataType.ToUpper();
                        if (XDataType_ToUpper != "INT"
                            && XDataType_ToUpper != "DATETIME"
                            && XDataType_ToUpper != "TEXT"
                            && XDataType_ToUpper != "SMALLDATETIME"
                            && XDataType_ToUpper != "NTEXT"
                            && XDataType_ToUpper != "BIT"
                            && XDataType_ToUpper != "BIGINT")
                        {
                            if (XDataType.ToUpper() == "NCHAR" || XDataType.ToUpper() == "NVARCHAR")
                            {
                                len = (int.Parse(Length) / 2).ToString();
                            }
                            else if (Length == "-1")
                            {
                                len = "max";
                            }
                            else
                            {

                                len = Length;
                            }
                            len = "(" + len + ")";

                        }


                        TableHtml += "<tr>";
                        TableHtml += "<td>" + ColumnName + "</td><td class=\"bl c_t\">" + XDataType.ToLower() + len + "</td><td class=\"c_p\">" + Primary + "</td><td class=\"c_n\">" + (IsNullAble == "0" ? "Not Null" : "") + "</td><td class=\"c_i\">" + (ColumnName == Identitys ? "自增" : "") + "</td><td class=\"c_d\">" + Default + "</td>" +
                            "<td class=\"ipt c_r\" id=\"td_" + Com.Common.EncDec.Encrypt(tablename + "." + ColumnName, "fang.com") + "\">" + Description.Replace("\t", "&nbsp;").Replace("\r\n", "<br/>") + "</td>";
                        TableHtml += "</tr>";
                    }
                    TableHtml += "</table>";
                    FileContent += TableHtml;
                    #endregion
                }
                catch (Exception err)
                {
                    string error = err.Message;
                }
                index++;
            }

            if (!string.IsNullOrEmpty(IsMyIds))
            {
                script_IsMyIds += @"<script src='My.aspx?v=" + System.Web.HttpUtility.UrlEncode(DataBase_Name + "@" + ((count / script_count) * script_count) + "@" + IsMyIds.TrimEnd(';')) + @"' async='async' defer='defer'><\/script>";
            }
            FileContent += "<img height=" + "\"" + @"0" + "\"" + @" width=" + "\"" + @"0" + "\"" + @" src=" + "\"" + @"" + imagespath + @"/ui-icons_222222_256x240.png" + "\"" + @" onerror=" + "\"" + @"javascript:seticon()" + "\"" + @"/>";
            FileContent += "</body></html>";
            return FileContent.Replace("{TableCount}", TableCount.ToString()).Replace("{TableList}", TableList).Replace("{li_width}", (tablename_maxlen * 6.2 + 52).ToString()).Replace("{script_IsMyIds}", script_IsMyIds);

        }
        protected static void GetProperty(Microsoft.Practices.EnterpriseLibrary.Data.Database DataBaseOwner, int TableId, string TableName,
                        out string[] ColumnNames,
                        out string[] XTypes,
                        out string[] Lengths,
                        out string[] IsNullAbles,
                        out string[] Defaults,
                        out string[] Descriptions,
                        out string[] PrimaryKeys,
                        out string Identitys,
                        out string TableComment)
        {
            string DataBase_Name = DataBaseOwner.GetConnection().Database;

            ColumnNames = null;
            XTypes = null;
            Lengths = null;
            IsNullAbles = null;
            Defaults = null;
            Descriptions = null;
            PrimaryKeys = null;
            Identitys = "";
            TableComment = "";

            Com.Data.SqlServer.Entity.SYSCOLUMNS SYSCOLUMNS = new Com.Data.SqlServer.Entity.SYSCOLUMNS();
            SYSCOLUMNS.Database_Reader = DataBaseOwner;
            SYSCOLUMNS.DataBase = DataBase_Name;
            SYSCOLUMNS.ID = TableId;
            SYSCOLUMNS.OrderBy = " COLID ";
            SYSCOLUMNS.Distinct = false;
            SYSCOLUMNS.SelectColumns = new string[] { "ID", "NAME", "XTYPE", "LENGTH", "COLID", "ISNULLABLE", "CDEFAULT" };
            DataTable oDt = SYSCOLUMNS.Select();
            string columnnames = "";
            string xtypes = "";
            string lengths = "";
            string descriptions = "";
            string isnullables = "";
            string defaults = "";
            foreach (DataRow oDr in oDt.Rows)
            {
                columnnames += oDr["NAME"].ToString() + ",";
                Com.Data.SqlServer.Entity.SYSTYPES SYSTYPES = new Com.Data.SqlServer.Entity.SYSTYPES();
                SYSTYPES.Database_Reader = DataBaseOwner;
                SYSTYPES.DataBase = DataBase_Name;
                SYSTYPES.XTYPE = byte.Parse(oDr["XTYPE"].ToString().ToUpper());
                SYSTYPES.SelectColumns = new string[] { "NAME" };
                SYSTYPES.SelectTop1();
                xtypes += SYSTYPES.NAME + ",";
                lengths += oDr["LENGTH"].ToString() + ",";

                Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES SYSPROPERTIES = new Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES();
                SYSPROPERTIES.Database_Reader = DataBaseOwner;
                SYSPROPERTIES.DataBase = DataBase_Name;
                SYSPROPERTIES.TableOwner = "sys";
                SYSPROPERTIES.MAJOR_ID = int.Parse(oDr["ID"].ToString());
                SYSPROPERTIES.MINOR_ID = int.Parse(oDr["COLID"].ToString());
                SYSPROPERTIES.SelectTop1();
                descriptions += (SYSPROPERTIES.VALUE == "" ? " " : SYSPROPERTIES.VALUE.Replace(",", "，")) + ",";
                isnullables += oDr["ISNULLABLE"].ToString() + ",";

                Com.Data.SqlServer.Entity.SYSCOMMENTS SYSCOMMENTS = new Com.Data.SqlServer.Entity.SYSCOMMENTS();
                SYSCOMMENTS.Database_Reader = DataBaseOwner;
                SYSCOMMENTS.DataBase = DataBase_Name;
                SYSCOMMENTS.ID = int.Parse(oDr["CDEFAULT"].ToString());
                SYSCOMMENTS.SelectColumns = new string[] { "TEXT" };
                SYSCOMMENTS.SelectTop1();
                string comments = SYSCOMMENTS.TEXT;
                if (SYSCOMMENTS.TEXT.Trim() == "")
                {
                    comments = " ";
                }
                else if (SYSCOMMENTS.TEXT.IndexOf("'") == -1)
                {
                    comments = SYSCOMMENTS.TEXT.Replace(")", "").Replace("(", "");
                }
                else
                {
                    comments = SYSCOMMENTS.TEXT.Substring(SYSCOMMENTS.TEXT.IndexOf("'") + 1, SYSCOMMENTS.TEXT.LastIndexOf("'") - SYSCOMMENTS.TEXT.IndexOf("'") - 1);
                }
                if (string.IsNullOrEmpty(comments))
                {
                    comments = " ";
                }
                defaults += comments + ",";

                if (string.IsNullOrEmpty(Identitys))
                {
                    string Identity = "0";
                    Identity = Convert.ToString(DataBaseOwner.ExecuteScalar(CommandType.Text, "SELECT COLUMNPROPERTY(  OBJECT_ID('" + TableName + "'),'" + oDr["NAME"].ToString() + "','IsIdentity')"));
                    if (Identity == "1")
                    {
                        Identitys = oDr["NAME"].ToString().ToUpper();
                    }
                }
            }
            ColumnNames = columnnames.TrimEnd(',').Split(',');
            XTypes = xtypes.ToUpper().TrimEnd(',').Split(',');
            Lengths = lengths.TrimEnd(',').Split(',');
            IsNullAbles = isnullables.TrimEnd(',').Split(',');
            Defaults = defaults.TrimEnd(',').Split(',');
            Descriptions = descriptions.TrimEnd(',').Split(',');

            DataTable oDt1 = DataBaseOwner.ExecuteDataSet(CommandType.Text, "EXEC " + DataBase_Name + "..sp_pkeys @table_name='" + TableName + "'").Tables[0];
            string Keys = "";
            foreach (DataRow oDr in oDt1.Rows)
            {
                Keys += oDr["COLUMN_NAME"].ToString().ToUpper() + ",";
            }
            PrimaryKeys = Keys.TrimEnd(',').Split(',');

            Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES SYSPROPERTIES1 = new Com.Data.SqlServer.Entity.EXTENDED_PROPERTIES();
            SYSPROPERTIES1.Database_Reader = DataBaseOwner;
            SYSPROPERTIES1.DataBase = DataBase_Name;
            SYSPROPERTIES1.TableOwner = "sys";
            SYSPROPERTIES1.JoinSql = " INNER JOIN " + DataBase_Name + "..sysobjects sysobjects ON MAJOR_ID = sysobjects.id ";
            SYSPROPERTIES1.WhereSql = " (MINOR_ID = 0) and sysobjects.name='" + TableName + "' ";
            SYSPROPERTIES1.SelectColumns = new string[] { SYSPROPERTIES1._VALUE };
            SYSPROPERTIES1.SelectTop1();
            TableComment = SYSPROPERTIES1.VALUE;
        }
    }
}
