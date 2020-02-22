using System;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.UserControl
{
	/// <summary>
	/// XmlTree 的摘要说明。
	/// </summary>
	public class XmlTree : WebControl
	{
		private string arrStr;
		public string css_file;
		public string SelectedId;
		public string xmlfile;
		public string xmlfile_path;

		public XmlTree()
		{
			this.arrStr = "";
			this.xmlfile = "";
			this.xmlfile_path = "";
			this.SelectedId = "";
			this.css_file = "";
		}
 
		private bool find_parent(string id, string powerid)
		{
			string text1 = id.Trim();
			bool flag1 = false;
			for (int num1 = 1; num1 < text1.Length; num1++)
			{
				if (text1.Substring(0, num1) == powerid.Trim())
				{
					flag1 = true;
				}
			}
			return flag1;
		}
 
		private string get_tree(int level, bool bottom, XmlNode oNode, string id)
		{
			string text1 = "";
			if (oNode.ChildNodes.Count == 0)
			{
				text1 = text1 + "<TR>\n";
				if (level > 0)
				{
					text1 = text1 + "<TD width=15 >&nbsp;</TD>";
				}
				text1 = text1 + "<TD onMouseOver=mOvr(this,'#c0c0c0'); onMouseOut=mOut(this,'#edecd1');>\n";
				string[] textArray1 = new string[6] { text1, "<a href=", this.getAttribute(oNode, "ref"), "&xmlfile_path=", this.xmlfile_path, ">\n" } ;
				text1 = string.Concat(textArray1);
				if (!bottom)
				{
					text1 = text1 + "<IMG border=0 align=absMiddle src='images\\t_minus.gif'>\n";
				}
				else
				{
					text1 = text1 + "<IMG border=0 align=absMiddle src='images\\t_minusl.gif'>\n";
				}
				text1 = text1 + "<IMG border=0 align=absMiddle src='images\\reddot.gif'>\n";
				if (this.getAttribute(oNode, "powerid") == id)
				{
					text1 = text1 + "<font face=\u5b8b\u4f53 color=#FF9900 >\n";
					text1 = text1 + this.getAttribute(oNode, "name");
					text1 = text1 + "</font>\n";
				}
				else
				{
					text1 = text1 + "<font face=\u5b8b\u4f53 color=#336699 >\n";
					text1 = text1 + this.getAttribute(oNode, "name");
					text1 = text1 + "</font>\n";
				}
				text1 = text1 + "</a>\n";
				text1 = text1 + "</TD>\n";
				return (text1 + "</TR>\n");
			}
			text1 = text1 + "<TR>\n";
			if (level > 0)
			{
				text1 = text1 + "<TD width=15 >&nbsp;</TD>\n";
			}
			text1 = text1 + "<TD onMouseOver=mOvr(this,'#c0c0c0'); onMouseOut=mOut(this,'#edecd1'); >\n";
			if (!bottom)
			{
				string[] textArray2 = new string[8] { text1, "<A href='javascript:clikker(0,content", this.getAttribute(oNode, "powerid"), ",img", this.getAttribute(oNode, "powerid"), ",op", this.getAttribute(oNode, "powerid"), ")'>\n" } ;
				text1 = string.Concat(textArray2);
			}
			else
			{
				string[] textArray3 = new string[8] { text1, "<A href='javascript:clikker(1,content", this.getAttribute(oNode, "powerid"), ",img", this.getAttribute(oNode, "powerid"), ",op", this.getAttribute(oNode, "powerid"), ")'>\n" } ;
				text1 = string.Concat(textArray3);
			}
			if (this.find_parent(id, this.getAttribute(oNode, "powerid")))
			{
				if (!bottom)
				{
					text1 = text1 + @"<IMG border=0 align=absMiddle src='images\t_minu.gif' id='img" + this.getAttribute(oNode, "powerid") + "'>\n";
				}
				else
				{
					text1 = text1 + @"<IMG border=0 align=absMiddle src='images\t_minul.gif' id='img" + this.getAttribute(oNode, "powerid") + "'>\n";
				}
				text1 = text1 + @"<IMG border=0 align=absMiddle src='images\t_open.gif' id='op" + this.getAttribute(oNode, "powerid") + "'>\n";
				if (this.getAttribute(oNode, "powerid") == id)
				{
					text1 = text1 + "<font face=\u5b8b\u4f53 color=#FF9900 >\n";
					text1 = text1 + this.getAttribute(oNode, "name");
					text1 = text1 + "</font>\n";
				}
				else
				{
					text1 = text1 + "<font face=\u5b8b\u4f53 color=#336699 >\n";
					text1 = text1 + this.getAttribute(oNode, "name");
					text1 = text1 + "</font>\n";
				}
				text1 = text1 + "</a>\n";
				text1 = text1 + "</TD>\n";
				text1 = text1 + "</TR>\n";
				text1 = text1 + "<TR>\n";
				if (level > 0)
				{
					text1 = text1 + "<TD width=15 ></TD>";
				}
				text1 = text1 + "<TD>\n";
				text1 = text1 + "<TABLE align=center width=100% border=0 cellPadding=0 cellSpacing=0 id='content" + this.getAttribute(oNode, "powerid") + "'";
			}
			else
			{
				if (!bottom)
				{
					text1 = text1 + @"<IMG border=0 align=absMiddle src='images\t_plus.gif' id='img" + this.getAttribute(oNode, "powerid") + "'>\n";
				}
				else
				{
					text1 = text1 + @"<IMG border=0 align=absMiddle src='images\t_plusl.gif' id='img" + this.getAttribute(oNode, "powerid") + "'>\n";
				}
				text1 = text1 + @"<IMG border=0 align=absMiddle src='images\t_folder.gif' id='op" + this.getAttribute(oNode, "powerid") + "'>\n";
				if (this.getAttribute(oNode, "powerid") == id)
				{
					text1 = text1 + "<font face=\u5b8b\u4f53 color=#FF9900 >\n";
					text1 = text1 + this.getAttribute(oNode, "name");
					text1 = text1 + "</font>\n";
				}
				else
				{
					text1 = text1 + "<font face=\u5b8b\u4f53 color=#336699 >\n";
					text1 = text1 + this.getAttribute(oNode, "name");
					text1 = text1 + "</font>\n";
				}
				text1 = text1 + "</a>\n";
				text1 = text1 + "</TD>\n";
				text1 = text1 + "</TR>\n";
				text1 = text1 + "<TR>\n";
				if (level > 0)
				{
					text1 = text1 + "<TD width=15 ></TD>\n";
				}
				text1 = text1 + "<TD >\n";
				text1 = text1 + "<TABLE align=center width=100% border=0 style='DISPLAY: none' cellPadding=0 cellSpacing=0 id='content" + this.getAttribute(oNode, "powerid") + "'";
			}
			text1 = text1 + "><TBODY>\n";
			for (int num1 = 0; num1 < oNode.ChildNodes.Count; num1++)
			{
				if (num1 == (oNode.ChildNodes.Count - 1))
				{
					text1 = text1 + this.get_tree(level + 1, true, oNode.ChildNodes[num1], id);
				}
				else
				{
					text1 = text1 + this.get_tree(level + 1, false, oNode.ChildNodes[num1], id);
				}
			}
			text1 = text1 + "</TBODY></TABLE>\n";
			text1 = text1 + "</TD>\n";
			return (text1 + "</TR>\n");
		}
 
		private string getAttribute(XmlNode node, string xpath)
		{
			return node.SelectSingleNode("@" + xpath).Value;
		}
 
		private XmlDocument LoadXMLFromFile(string Path)
		{
			XmlDocument document1 = new XmlDocument();
			document1.Load(Path);
			return document1;
		}
 
		private void Page_Load(object sender, EventArgs e)
		{
			if (this.SelectedId == null)
			{
				this.SelectedId = "1101";
			}
		}
		protected override void Render(HtmlTextWriter output)
		{
			int num1;
			if (!this.Page.IsPostBack)
			{
				this.SelectedId = this.Page.Request["SelectedId"];
			}
			XmlDocument document1 = this.LoadXMLFromFile(this.xmlfile);
			XmlNodeList list1 = document1.SelectNodes("//item");
			int num2 = list1.Count;
			XmlNode node1 = document1.DocumentElement;
			output.Write("<link href='" + this.css_file + "' type='text/css' rel='stylesheet'><TABLE  align=left border=0 cellPadding=0 cellSpacing=0 ><TBODY>");
			if (node1.ChildNodes.Count > 0)
			{
				for (num1 = 0; num1 < node1.ChildNodes.Count; num1++)
				{
					if (num1 == (node1.ChildNodes.Count - 1))
					{
						output.Write(this.get_tree(0, true, node1.ChildNodes[num1], this.SelectedId));
					}
					else
					{
						output.Write(this.get_tree(0, false, node1.ChildNodes[num1], this.SelectedId));
					}
				}
			}
			output.Write("</TBODY></TABLE>");
			this.arrStr = this.arrStr + "<script language='javascript'>\n";
			this.arrStr = this.arrStr + "arrs = new Array(" + Convert.ToString(num2) + ");\n";
			this.arrStr = this.arrStr + "arrimg = new Array(" + Convert.ToString(num2) + ");\n";
			this.arrStr = this.arrStr + "arrop = new Array(" + Convert.ToString(num2) + ");\n";
			this.arrStr = this.arrStr + " var numTotal=" + Convert.ToString(num2) + ";\n";
			this.arrStr = this.arrStr + "var i;\n";
			this.arrStr = this.arrStr + "var arrval;\n";
			int num3 = -1;
			for (num1 = 0; num1 < num2; num1++)
			{
				if (list1.Item(num1).HasChildNodes)
				{
					num3++;
					this.arrStr = this.arrStr + "arrval=" + this.getAttribute(list1.Item(num1), "powerid") + ";\n";
					object[] objArray1 = new object[4] { this.arrStr, "arrs[", num3, "]='content' + arrval;\n" } ;
					this.arrStr = string.Concat(objArray1);
					object[] objArray2 = new object[4] { this.arrStr, "arrimg[", num3, "]='img' +arrval;\n" } ;
					this.arrStr = string.Concat(objArray2);
					object[] objArray3 = new object[4] { this.arrStr, "arrop[", num3, "]='op' +arrval;\n" } ;
					this.arrStr = string.Concat(objArray3);
				}
			}
			this.arrStr = this.arrStr + "</script>\n";
			this.arrStr = this.arrStr + "<script language='javascript'>\n";
			this.arrStr = this.arrStr + "function mOvr(src, cOvr)\n";
			this.arrStr = this.arrStr + "{if (!src.contains(event.fromElement)) {src.style.cursor = 'default';src.bgColor = cOvr;}}\n";
			this.arrStr = this.arrStr + "function mOut(src, cOut)\n";
			this.arrStr = this.arrStr + "{if (!src.contains(event.toElement)) {src.style.cursor = 'default';src.bgColor = cOut;}}\n";
			this.arrStr = this.arrStr + "</script>\n";
			this.arrStr = this.arrStr + "<script language='javascript'>\n";
			this.arrStr = this.arrStr + "function clikker(islast,block,arrow,srcimg)\n";
			this.arrStr = this.arrStr + "{ //\u70b9\n";
			this.arrStr = this.arrStr + "var lastone\n";
			this.arrStr = this.arrStr + "if (islast==1)\n";
			this.arrStr = this.arrStr + "{lastone=true;}\n";
			this.arrStr = this.arrStr + "else\n";
			this.arrStr = this.arrStr + "{lastone=false;}; \n";
			this.arrStr = this.arrStr + "if (navigator.appName == 'Netscape')\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "var obj,imgobj1,imgobj2\n";
			this.arrStr = this.arrStr + "obj=eval(block);\n";
			this.arrStr = this.arrStr + "imgobj1=eval(arrow);\n";
			this.arrStr = this.arrStr + "imgobj2=eval(srcimg);\n";
			this.arrStr = this.arrStr + "if (obj.visibility=='hide')\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "\tobj.visibility='show';\n";
			this.arrStr = this.arrStr + "\tif (lastone)\n";
			this.arrStr = this.arrStr + "\t {\n";
			this.arrStr = this.arrStr + "\t   imgobj1.src='images/t_minul.gif';\n";
			this.arrStr = this.arrStr + "\t }\n";
			this.arrStr = this.arrStr + "\telse\n";
			this.arrStr = this.arrStr + "\t {\n";
			this.arrStr = this.arrStr + "\t   imgobj1.src='images/t_minu.gif';\n";
			this.arrStr = this.arrStr + "\t };\n";
			this.arrStr = this.arrStr + "\timgobj2.src='images/t_folder.gif';\t\n";
			this.arrStr = this.arrStr + "}\n";
			this.arrStr = this.arrStr + "  else\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "\tobj.visibility='hide';\n";
			this.arrStr = this.arrStr + "\tif (lastone)\n";
			this.arrStr = this.arrStr + "\t {\n";
			this.arrStr = this.arrStr + "imgobj1.src='images/t_plusl.gif';\n";
			this.arrStr = this.arrStr + "}\n";
			this.arrStr = this.arrStr + " else\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "\t\timgobj1.src='images/t_plus.gif';\n";
			this.arrStr = this.arrStr + "\t }; \t\n";
			this.arrStr = this.arrStr + "\timgobj2.src='images/t_open.gif';\t\n";
			this.arrStr = this.arrStr + "};\n";
			this.arrStr = this.arrStr + "\t } \t\n";
			this.arrStr = this.arrStr + "else\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "var blockid\n";
			this.arrStr = this.arrStr + "var str1\n";
			this.arrStr = this.arrStr + "blockid=block.id;\n";
			this.arrStr = this.arrStr + "if (block.style.display =='') \n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "\tblock.style.display = 'none';\n";
			this.arrStr = this.arrStr + "   if (lastone)\n";
			this.arrStr = this.arrStr + "\t\t{\n";
			this.arrStr = this.arrStr + "\t\t  arrow.src = 'images/t_plusl.gif';\n";
			this.arrStr = this.arrStr + "\t\t}\n";
			this.arrStr = this.arrStr + "   else\t\n";
			this.arrStr = this.arrStr + "      \t{\n";
			this.arrStr = this.arrStr + "\t\t   arrow.src = 'images/t_plus.gif';\n";
			this.arrStr = this.arrStr + "\t\t};\n";
			this.arrStr = this.arrStr + "\tsrcimg.src='images/t_folder.gif';\n";
			this.arrStr = this.arrStr + "  }\n";
			this.arrStr = this.arrStr + " else \n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "\tblock.style.display='';\t\n";
			this.arrStr = this.arrStr + "\tif (lastone) \n";
			this.arrStr = this.arrStr + "\t {\t  \n";
			this.arrStr = this.arrStr + "\t  arrow.src = 'images/t_minul.gif';\n";
			this.arrStr = this.arrStr + "\t }\n";
			this.arrStr = this.arrStr + "\telse\n";
			this.arrStr = this.arrStr + "\t {\n";
			this.arrStr = this.arrStr + "\t  arrow.src = 'images/t_minu.gif';\n";
			this.arrStr = this.arrStr + "\t };  \n";
			this.arrStr = this.arrStr + "\t srcimg.src='images/t_open.gif';\t\t\n";
			this.arrStr = this.arrStr + "\tfor(i=0;i<=" + Convert.ToString(num3) + ";i++)\n";
			this.arrStr = this.arrStr + "\t{\n";
			this.arrStr = this.arrStr + "\t   \tcloitm = eval(arrs[i]);\n";
			this.arrStr = this.arrStr + "\t\titmimg = eval(arrimg[i]);\n";
			this.arrStr = this.arrStr + "\t\titmop = eval(arrop[i]);\n";
			this.arrStr = this.arrStr + "\t\t//alert(i);\n";
			this.arrStr = this.arrStr + "\t    str1=itmimg.src;\n";
			this.arrStr = this.arrStr + "\t    str1=str1.substring(str1.lastIndexOf('/')+1);\n";
			this.arrStr = this.arrStr + "\t\tif (block!=cloitm && !is_part(blockid,arrs[i]))\n";
			this.arrStr = this.arrStr + "\t\t{\n";
			this.arrStr = this.arrStr + "\t\t   cloitm.style.display='none'\n";
			this.arrStr = this.arrStr + "\t\t   if ((str1=='t_minul.gif') || (str1=='t_plusl.gif' ))\n";
			this.arrStr = this.arrStr + "\t    \t{\t \n";
			this.arrStr = this.arrStr + "\t\t    \titmimg.src='images/t_plusl.gif';\n";
			this.arrStr = this.arrStr + "\t\t    }\n";
			this.arrStr = this.arrStr + "\t\t   else\n";
			this.arrStr = this.arrStr + "\t\t    {\t\n";
			this.arrStr = this.arrStr + "\t\t    \titmimg.src='images/t_plus.gif';\n";
			this.arrStr = this.arrStr + "\t\t    };\n";
			this.arrStr = this.arrStr + "\t\t\titmop.src='images/t_folder.gif';\n";
			this.arrStr = this.arrStr + "\t\t};\n";
			this.arrStr = this.arrStr + "\t};\n";
			this.arrStr = this.arrStr + "};\n";
			this.arrStr = this.arrStr + "};\n";
			this.arrStr = this.arrStr + "}\n";
			this.arrStr = this.arrStr + "function is_part(str1,str2) //\u5224\u65ad\u4e0a\u7ea7\u8282\u70b9\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "var i,j\n";
			this.arrStr = this.arrStr + "var len1,len2\n";
			this.arrStr = this.arrStr + "len1=str1.length;\n";
			this.arrStr = this.arrStr + "len2=str2.length;\n";
			this.arrStr = this.arrStr + "j=0\n";
			this.arrStr = this.arrStr + "if (len2>len1){return false}\n";
			this.arrStr = this.arrStr + "for (i=len2;i<len1;i++)\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "if (str2==str1.substring(0,i))\n";
			this.arrStr = this.arrStr + "{\n";
			this.arrStr = this.arrStr + "j=1;\n";
			this.arrStr = this.arrStr + "break;\n";
			this.arrStr = this.arrStr + "}\n";
			this.arrStr = this.arrStr + "};\n";
			this.arrStr = this.arrStr + "if (j==0)\n";
			this.arrStr = this.arrStr + "{return false}\n";
			this.arrStr = this.arrStr + "else\n";
			this.arrStr = this.arrStr + "{return true};\n";
			this.arrStr = this.arrStr + "}\n";
			this.arrStr = this.arrStr + "</script>\n";
			output.Write(this.arrStr);
		}
 

	}
}
