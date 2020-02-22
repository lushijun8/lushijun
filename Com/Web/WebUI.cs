using System;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using Com.Web;

namespace Com.Web
{
    public class WebUI : Page
    {
        public WebUI()
        {

        }
        /// <summary>
        /// ��ȡQueryString���������Ϊnull�򷵻�"",�Ѿ�����SafeSql����
        /// </summary>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public string QueryString(string paraName)
        {
            string text1 = "";
            text1 = PageUtil.GetParaValueFromQueryString(base.Request, paraName);
            if (text1 == null)
                text1 = "";
            return text1;
        }
        /// <summary>
        /// ��ȡSession���������Ϊnull�򷵻�"",�Ѿ�����SafeSql����
        /// </summary>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public string Sessions(string paraName)
        {
            string text1 = "";
            text1 = PageUtil.GetParaValueFromSession(base.Session, paraName);
            if (text1 == null)
                text1 = "";
            return text1;
        }
        /// <summary>
        /// ��ȡForm���������Ϊnull�򷵻�"",�Ѿ�����SafeSql����
        /// </summary>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public string Forms(string paraName)
        {
            string text1 = "";
            text1 = PageUtil.GetParaValueFromForm(base.Request, paraName);
            if (text1 == null)
                text1 = "";
            return text1;
        }
        /// <summary>
        /// ��ȡCookie���������Ϊnull�򷵻�"",�Ѿ�����SafeSql����
        /// </summary>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public string Cookie(string paraName)
        {
            //System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string text1 = "";
            text1 = PageUtil.GetParaValueFromCookie(base.Request, paraName);
            if (text1 == null)
                text1 = "";
            return text1;
        }
        /// <summary>
        /// ��ȡViewState���������Ϊnull�򷵻�"",�Ѿ�����SafeSql����
        /// </summary>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public string ViewStates(string paraName)
        {
            string text1 = "";
            text1 = PageUtil.GetParaValueFromViewState(this.ViewState, paraName);
            if (text1 == null)
                text1 = "";
            return text1;
        }

        /// <summary>
        /// ��ȡWeb.config��AppSetting��ȡ���������Ϊnull�򷵻�"",�Ѿ�����SafeSql����
        /// </summary>
        /// <param name="paraName"></param>
        /// <returns></returns>
        public string AppSetting(string key)
        {
            string text1 = "";
            text1 = PageUtil.GetParaValueFromWebConfig(key);
            if (text1 == null)
                text1 = "";
            return text1;
        }
        public void OpenURL(string strUrl, string sendString)
        {
           
            if (sendString.Length > 0)
            {
                strUrl = strUrl + "?" + sendString;
            }
            this.Page.RegisterClientScriptBlock("WindowOpen", "<Script language=\"javascript\">window.open('" + strUrl + "');</script>");
        }
        private void SetViewState(string PropertyName, string PropertyValue)
        {
            this.ViewState[PropertyName] = PropertyValue;
        }
        /// <summary>
        /// �������ͼ,Ҫ��ImagesRoot�ļ������ж�Ӧ������ͼ,ͼƬ��ʽҪ����GIF/JPG/JPEG
        /// </summary>
        /// <param name="BigImageUrl">�ļ�·��</param>
        /// <param name="ImagesRoot">ͼƬ���ڵ��ļ���</param>
        /// <returns></returns>
        public string GetSmallImageUrl(string BigImageUrl, string ImagesRoot)
        {
            string Value = BigImageUrl;
            Value = BigImageUrl.ToUpper().Replace(ImagesRoot.ToUpper() + "/", ImagesRoot.ToUpper() + "/SMALL/").Replace(".GIF", "S.GIF").Replace(".JPG", "S.JPG").Replace(".JPEG", "S.JPEG");
            return Value;
        }
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="Message">������Ϣ</param>
        public void Alert(string Message)
        {
            Page.RegisterClientScriptBlock("Alert", @"
<script language=" + "\"" + @"JavaScript" + "\"" + @">function gid(id){return window.top.document.getElementById?window.top.document.getElementById(id):null;}
function Browser(){var ua, s, i;this.isIE = false;this.isNS = false;this.isOP = false;this.isSF = false;ua = navigator.userAgent.toLowerCase();s = " + "\"" + @"opera" + "\"" + @";if ((i = ua.indexOf(s)) >= 0){this.isOP = true;return;}s = " + "\"" + @"msie" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isIE = true;return;}s = " + "\"" + @"netscape6/" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isNS = true;return;}s = " + "\"" + @"gecko" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isNS = true;return;}s = " + "\"" + @"safari" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isSF = true;return;}}
function gname(name){return window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(name):new Array()}
function DialogLoc(){var dde = window.top.document.documentElement;if (window.innerWidth){var ww = window.window.innerWidth;var wh = window.window.innerHeight;var bgX = window.pageXOffset;var bgY = window.pageYOffset;}else{var ww = dde.offsetWidth;var wh = dde.offsetHeight;var bgX = dde.scrollLeft;var bgY = dde.scrollTop;}t_DiglogX = (bgX + ((ww - t_DiglogW)/2));t_DiglogY = (bgY + ((wh - t_DiglogH)/2));}
function ScreenClean(){var objScreen = window.top.document.getElementById('ScreenOver');if (objScreen) objScreen.style.display = 'none';var allselect = gname('select');for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = 'visible';}" + @"
function DialogHide(){ScreenClean();var objDialog = window.top.document.getElementById('DialogMove');if (objDialog) objDialog.style.display = 'none';}
function DialogShow(showdata,ow,oh,w,h){var objDialog = window.top.document.getElementById(" + "\"" + @"DialogMove" + "\"" + @");if (!objDialog) objDialog = window.top.document.createElement(" + "\"" + @"div" + "\"" + @");t_DiglogW = ow;t_DiglogH = oh;DialogLoc();objDialog.id = " + "\"" + @"DialogMove" + "\"" + @";var oS = objDialog.style;oS.display = " + "\"" + @"block" + "\"" + @";oS.top = t_DiglogY + " + "\"" + @"px" + "\"" + @";oS.left = t_DiglogX + " + "\"" + @"px" + "\"" + @";oS.margin = " + "\"" + @"0px" + "\"" + @";oS.padding = " + "\"" + @"0px" + "\"" + @";oS.width = w + " + "\"" + @"px" + "\"" + @";oS.height = h + " + "\"" + @"px" + "\"" + @";oS.position = " + "\"" + @"absolute" + "\"" + @";oS.zIndex = " + "\"" + @"5" + "\"" + @";oS.background = " + "\"" + @"#FFF" + "\"" + @";objDialog.innerHTML = showdata;window.top.document.body.appendChild(objDialog);}

function ScreenConvert(){
var browser = new Browser();
var objScreen = gid(" + "\"" + @"ScreenOver" + "\"" + @");
if(!objScreen) 
var objScreen = window.top.document.createElement(" + "\"" + @"div" + "\"" + @");
var oS = objScreen.style;
objScreen.id = " + "\"" + @"ScreenOver" + "\"" + @";
oS.display = " + "\"" + @"block" + "\"" + @";
oS.top = oS.left = oS.margin = oS.padding = " + "\"" + @"0px" + "\"" + @";
if (window.top.document.body.clientHeight)	{var wh = window.top.document.body.clientHeight + " + "\"" + @"px" + "\"" + @";}
else if (window.top.innerHeight){var wh = window.top.innerHeight + " + "\"" + @"px" + "\"" + @";}
else{var wh = " + "\"" + @"100%" + "\"" + @";}oS.width = " + "\"" + @"100%" + "\"" + @";oS.height = wh;oS.position = " + "\"" + @"absolute" + "\"" + @";oS.zIndex = " + "\"" + @"3" + "\"" + @";
if ((!browser.isSF) && (!browser.isOP)){oS.background = " + "\"" + @"#181818" + "\"" + @";}else{oS.background = " + "\"" + @"#F0F0F0" + "\"" + @";}
oS.filter = " + "\"" + @"alpha(opacity=40)" + "\"" + @";oS.opacity = 40/100;oS.MozOpacity = 40/100;
window.top.document.body.appendChild(objScreen);var allselect = gname(" + "\"" + @"select" + "\"" + @");
for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\"" + @"hidden" + "\"" + @";
}

function AlertWindow()
{
	ScreenConvert();
	var AJAX_LoginBody=" + "\"" + @"<div style='border:2px solid #e6e6e6;height:120px;width:350px;text-align:center; background-color:#f0f0f0;padding: 2px 2px 2px 2px;'><div style='width:100%;height:20px;background-color:blue;'><div style='float:left'><font color='#ffffff'>���棡</font></div><div style='float:right;width:20px;'><font color='#ffffff' style='cursor:pointer' onclick='javascript:var objScreen = window.top.document.getElementById(" + "\\\"" + "ScreenOver" + "\\\"" + ");if (objScreen) objScreen.style.display = " + "\\\"" + "none" + "\\\"" + ";var allselect = window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(" + "\\\"" + "select" + "\\\"" + "):new Array();for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\\\"" + "visible" + "\\\"" + ";var objDialog = window.top.document.getElementById(" + "\\\"" + "DialogMove" + "\\\"" + ");if (objDialog) objDialog.style.display = " + "\\\"" + "none" + "\\\"" + ";'>X</font></div></div><div style='text-align:center; vertical-align:middle;width:350px;height:75px;padding:3px 3px 3px 3px;'><p></p><font color=#000000>" + Message + @"</font><p></p></div><span style='background-color:#ffffff;color:blue;width:30px;height:25px'><a onclick='javascript:var objScreen = window.top.document.getElementById(" + "\\\"" + "ScreenOver" + "\\\"" + ");if (objScreen) objScreen.style.display = " + "\\\"" + "none" + "\\\"" + ";var allselect = window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(" + "\\\"" + "select" + "\\\"" + "):new Array();for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\\\"" + "visible" + "\\\"" + ";var objDialog = window.top.document.getElementById(" + "\\\"" + "DialogMove" + "\\\"" + ");if (objDialog) objDialog.style.display = " + "\\\"" + "none" + "\\\"" + ";' style='cursor:pointer'>ȷ��</a></span></div>" + "\"" + @";
	DialogShow(AJAX_LoginBody,250,120,280,100);	
}
if(document.body!=null)
{
    document.body.onload=new function(){AlertWindow();}
}
else
{
	AlertWindow();
}
</script>");
        }
        /// <summary>
        /// ����ȷ����Ϣ
        /// </summary>
        /// <param name="Message">ȷ����Ϣ</param>
        /// <param name="NextUrl">ȷ���Ƿ���ת����URL</param>
        public void RedirectConfirm(string Message, string NextUrl)
        {
            string sConfirm = @"
			<script language=" + "\"" + @"JavaScript" + "\"" + @">function gid(id){return window.top.document.getElementById?window.top.document.getElementById(id):null;}
function Browser(){var ua, s, i;this.isIE = false;this.isNS = false;this.isOP = false;this.isSF = false;ua = navigator.userAgent.toLowerCase();s = " + "\"" + @"opera" + "\"" + @";if ((i = ua.indexOf(s)) >= 0){this.isOP = true;return;}s = " + "\"" + @"msie" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isIE = true;return;}s = " + "\"" + @"netscape6/" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isNS = true;return;}s = " + "\"" + @"gecko" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isNS = true;return;}s = " + "\"" + @"safari" + "\"" + @";if ((i = ua.indexOf(s)) >= 0) {this.isSF = true;return;}}
function gname(name){return window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(name):new Array()}
function DialogLoc(){var dde = window.top.document.documentElement;if (window.innerWidth){var ww = window.window.innerWidth;var wh = window.window.innerHeight;var bgX = window.pageXOffset;var bgY = window.pageYOffset;}else{var ww = dde.offsetWidth;var wh = dde.offsetHeight;var bgX = dde.scrollLeft;var bgY = dde.scrollTop;}t_DiglogX = (bgX + ((ww - t_DiglogW)/2));t_DiglogY = (bgY + ((wh - t_DiglogH)/2));}
function ScreenClean(){var objScreen = window.top.document.getElementById('ScreenOver');if (objScreen) objScreen.style.display = 'none';var allselect = gname('select');for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = 'visible';}" + @"
function DialogHide(){ScreenClean();var objDialog = window.top.document.getElementById('DialogMove');if (objDialog) objDialog.style.display = 'none';}
function DialogShow(showdata,ow,oh,w,h){var objDialog = window.top.document.getElementById(" + "\"" + @"DialogMove" + "\"" + @");if (!objDialog) objDialog = window.top.document.createElement(" + "\"" + @"div" + "\"" + @");t_DiglogW = ow;t_DiglogH = oh;DialogLoc();objDialog.id = " + "\"" + @"DialogMove" + "\"" + @";var oS = objDialog.style;oS.display = " + "\"" + @"block" + "\"" + @";oS.top = t_DiglogY + " + "\"" + @"px" + "\"" + @";oS.left = t_DiglogX + " + "\"" + @"px" + "\"" + @";oS.margin = " + "\"" + @"0px" + "\"" + @";oS.padding = " + "\"" + @"0px" + "\"" + @";oS.width = w + " + "\"" + @"px" + "\"" + @";oS.height = h + " + "\"" + @"px" + "\"" + @";oS.position = " + "\"" + @"absolute" + "\"" + @";oS.zIndex = " + "\"" + @"5" + "\"" + @";oS.background = " + "\"" + @"#FFF" + "\"" + @";objDialog.innerHTML = showdata;window.top.document.body.appendChild(objDialog);}

function ScreenConvert(){
var browser = new Browser();
var objScreen = gid(" + "\"" + @"ScreenOver" + "\"" + @");
if(!objScreen) 
var objScreen = window.top.document.createElement(" + "\"" + @"div" + "\"" + @");
var oS = objScreen.style;
objScreen.id = " + "\"" + @"ScreenOver" + "\"" + @";
oS.display = " + "\"" + @"block" + "\"" + @";
oS.top = oS.left = oS.margin = oS.padding = " + "\"" + @"0px" + "\"" + @";
if (window.top.document.body.clientHeight)	{var wh = window.top.document.body.clientHeight + " + "\"" + @"px" + "\"" + @";}
else if (window.top.innerHeight){var wh = window.top.innerHeight + " + "\"" + @"px" + "\"" + @";}
else{var wh = " + "\"" + @"100%" + "\"" + @";}oS.width = " + "\"" + @"100%" + "\"" + @";oS.height = wh;oS.position = " + "\"" + @"absolute" + "\"" + @";oS.zIndex = " + "\"" + @"3" + "\"" + @";
if ((!browser.isSF) && (!browser.isOP)){oS.background = " + "\"" + @"#181818" + "\"" + @";}else{oS.background = " + "\"" + @"#F0F0F0" + "\"" + @";}
oS.filter = " + "\"" + @"alpha(opacity=40)" + "\"" + @";oS.opacity = 40/100;oS.MozOpacity = 40/100;
window.top.document.body.appendChild(objScreen);var allselect = gname(" + "\"" + @"select" + "\"" + @");
for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\"" + @"hidden" + "\"" + @";
}
function DialogHide(){ScreenClean();var objDialog = window.top.document.getElementById(" + "\"" + @"DialogMove" + "\"" + @");if (objDialog) objDialog.style.display = " + "\"" + @"none" + "\"" + @";}
function AlertWindow()
{
	ScreenConvert();
    var target = " + "\"" + @"_self" + "\"" + @";
    if(window.top && window.top.location!=window.self.location)
    {
        target=window.name;
    }
	var AJAX_LoginBody=" + "\"" + @"<div style='border:2px solid #e6e6e6;height:120px;width:350px;text-align:center; background-color:#f0f0f0;padding: 2px 2px 2px 2px;'><div style='width:100%;height:20px;background-color:blue;'><div style='float:left'><font color='#ffffff'/>ȷ�ϣ�</font></div>" +
"<div style='float:right;width:20px;'><font color='#ffffff' style='cursor:pointer' onclick='javascript:var objScreen = window.top.document.getElementById(" + "\\\"" + "ScreenOver" + "\\\"" + ");if (objScreen) objScreen.style.display = " + "\\\"" + "none" + "\\\"" + ";var allselect = window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(" + "\\\"" + "select" + "\\\"" + "):new Array();for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\\\"" + "visible" + "\\\"" + ";var objDialog = window.top.document.getElementById(" + "\\\"" + "DialogMove" + "\\\"" + ");if (objDialog) objDialog.style.display = " + "\\\"" + "none" + "\\\"" + ";' />X</font></div></div><div style='text-align:center; vertical-align:middle;width:350px;height:75px;padding:3px 3px 3px 3px;'>" +
"<p></p><font color=#000000>" + Message + @"</font><p></p></div><span style='background-color:#ffffff;color:blue;width:30px;height:25px'>" +
                //"<a onclick='javascript:var objScreen = window.top.document.getElementById(" + "\\\"" + "ScreenOver" + "\\\"" + ");if (objScreen) objScreen.style.display = " + "\\\"" + "none" + "\\\"" + ";var allselect = window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(" + "\\\"" + "select" + "\\\"" + "):new Array();for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\\\"" + "visible" + "\\\"" + ";var objDialog = window.top.document.getElementById(" + "\\\"" + "DialogMove" + "\\\"" + ");if (objDialog) objDialog.style.display = " + "\\\"" + "none" + "\\\"" + ";" + window + "=\\\"" + NextUrl + "\\\";' style='cursor:pointer'>ȷ��</a>"+
"<a href='" + NextUrl + "' target='" + "\"" + "+target+" + "\"" + "' onclick='javascript:var objScreen = window.top.document.getElementById(" + "\\\"" + "ScreenOver" + "\\\"" + ");if (objScreen) objScreen.style.display = " + "\\\"" + "none" + "\\\"" + ";var allselect = window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(" + "\\\"" + "select" + "\\\"" + "):new Array();for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\\\"" + "visible" + "\\\"" + ";var objDialog = window.top.document.getElementById(" + "\\\"" + "DialogMove" + "\\\"" + ");if (objDialog) objDialog.style.display = " + "\\\"" + "none" + "\\\"" + ";' style='cursor:pointer'>ȷ��</a>" +
"</span>&nbsp;&nbsp;<span style='background-color:#ffffff;color:blue;width:30px;height:25px'>" +
"<a onclick='javascript:var objScreen = window.top.document.getElementById(" + "\\\"" + "ScreenOver" + "\\\"" + ");if (objScreen) objScreen.style.display = " + "\\\"" + "none" + "\\\"" + ";var allselect = window.top.document.getElementsByTagName?window.top.document.getElementsByTagName(" + "\\\"" + "select" + "\\\"" + "):new Array();for (var i=0; i<allselect.length; i++) allselect[i].style.visibility = " + "\\\"" + "visible" + "\\\"" + ";var objDialog = window.top.document.getElementById(" + "\\\"" + "DialogMove" + "\\\"" + ");if (objDialog) objDialog.style.display = " + "\\\"" + "none" + "\\\"" + ";' style='cursor:pointer'>ȡ��</a></span></div>" + "\"" + @";
	DialogShow(AJAX_LoginBody,250,120,280,100);	
}
if(document.body!=null)
{
    document.body.onload=new function(){AlertWindow();}
}
else
{
	AlertWindow();
}
</script>
			";
            Page.RegisterClientScriptBlock("ConfirmGoOn", sConfirm);
        }
        /// <summary>
        /// javascript������תȷ��
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="NextUrl"></param>
        public void RedirectConfirmScript(string Message, string NextUrl)
        {
            string sConfirm = @"
			<script language=" + "\"" + @"JavaScript" + "\"" + @">
function AlertWindow()
{
	if(window.confirm(" + "\"" + Message + "" + "\"" + @"))
    {
       window.location=" + "\"" + NextUrl + "" + "\"" + @";
    }
    return false;
}
if(document.body!=null)
{
    document.body.onload=new function(){AlertWindow();}
}
else
{
	AlertWindow();
}
</script>
			";
            Page.RegisterClientScriptBlock("ConfirmGoOn", sConfirm);

        }
        /// <summary>
        /// javascript����ȷ��
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="NextUrl"></param>
        public void AlertScript(string Message)
        {
            Page.RegisterClientScriptBlock("Alert", @"
<script language=" + "\"" + @"JavaScript" + "\"" + @">
function AlertWindow()
{
	window.alert(" + "\"" + Message + "" + "\"" + @");
    return false;
}
if(document.body!=null)
{
    document.body.onload=new function(){AlertWindow();}
}
else
{
	AlertWindow();
}
</script>");
        }
        /// <summary>
        /// ����Cookies
        /// </summary>
        /// <param name="keystr"></param>
        /// <param name="values"></param>
        /// <param name="timeout">���Թ���ʱ��</param>
        public void setCookies(string keystr, string values, DateTime timeout)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Cookies[keystr].Value = values;
            Response.Cookies[keystr].Expires = timeout;
            //Response.Cookies[keystr].Domain = "fang.com";
            return;
        }
        /// <summary>
        /// ����Cookies
        /// </summary>
        /// <param name="keystr"></param>
        /// <param name="values"></param>
        /// <param name="minutes">������</param>
        public void setCookies(string keystr, string values, int minutes)
        {
            setCookies(keystr, values, DateTime.Now.AddMinutes(minutes));
        }
        /// <summary>
        /// ɾ��Cookies
        /// </summary>
        /// <param name="keystr"></param>
        public void RemoveCookies(string keystr)
        {
            this.setCookies(keystr, "", DateTime.Now.AddMilliseconds(1));
            //System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            //Response.Cookies.Remove(keystr);
        }
    }
}
