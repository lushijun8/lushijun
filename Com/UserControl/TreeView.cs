using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using Com.Xml;

namespace Com.UserControl
{
	/// <summary>
	/// TreeView 的摘要说明。
	/// </summary>
	public class TreeView: WebControl
	{
		public string CssFilePath;
		public string SelectedNode;
		public string TreeXml;

		public TreeView()
		{
			this.CssFilePath = "";
			this.SelectedNode = "";
			this.TreeXml = "";
		}
		private void BuildImage(StringBuilder TreeHtml, string AttrString)
		{
			TreeHtml.Append("<IMG border=0 align=absMiddle " + AttrString + ">\n");
		}
 
		private void BuildNode(StringBuilder TreeHtml, XmlNode oNode, bool IsBottom, string[] AttrString, string[] strAttr)
		{
			if (IsBottom)
			{
				this.BuildImage(TreeHtml, AttrString[0]);
			}
			else
			{
				this.BuildImage(TreeHtml, AttrString[1]);
			}
			this.BuildImage(TreeHtml, AttrString[2]);
			if (strAttr[0] == this.SelectedNode)
			{
				TreeHtml.Append("<font face=\u5b8b\u4f53 color=#FF9900 >\n");
			}
			else
			{
				TreeHtml.Append("<font face=\u5b8b\u4f53 color=#336699 >\n");
			}
			TreeHtml.Append(strAttr[1]);
			TreeHtml.Append("</font>\n");
		}
 
		private void BuildTreeView(StringBuilder TreeHtml, XmlNode oNode, int Level, bool IsBottom)
		{
			string[] textArray1 = new string[3] { XmlUtil.GetNodeAttributeValue(oNode, "id"), XmlUtil.GetNodeAttributeValue(oNode, "name"), XmlUtil.GetNodeAttributeValue(oNode.ParentNode, "id") } ;
			string[] textArray2 = new string[3];
			TreeHtml.Append("<TR>\n");
			if (Level > 0)
			{
				TreeHtml.Append("<TD width=15 >&nbsp;</TD>");
			}
			TreeHtml.Append("<TD onMouseOver=mOvr(this,'#c0c0c0'); onMouseOut=mOut(this,'#edecd1');>\n");
			if (oNode.ChildNodes.Count == 0)
			{
				textArray2[0] = @"src='images\t_minusl.gif";
				textArray2[1] = @"src='images\t_minus.gif'";
				textArray2[2] = @"src='images\reddot.gif'";
				this.BuildNode(TreeHtml, oNode, IsBottom, textArray2, textArray1);
				TreeHtml.Append("</TD>\n");
				TreeHtml.Append("</TR>\n");
			}
			else
			{
				if (IsBottom)
				{
					string[] textArray3 = new string[7] { "<A href='javascript:clikker(1,content", textArray1[0], ",img", textArray1[0], ",op", textArray1[0], ")'>\n" } ;
					TreeHtml.Append(string.Concat(textArray3));
				}
				else
				{
					string[] textArray4 = new string[7] { "<A href='javascript:clikker(0,content", textArray1[0], ",img", textArray1[0], ",op", textArray1[0], ")'>\n" } ;
					TreeHtml.Append(string.Concat(textArray4));
				}
				if (this.IsParentNode(oNode))
				{
					textArray2[0] = @"src='images\t_minusl.gif";
					textArray2[1] = @"src='images\t_minus.gif'";
					textArray2[2] = @"src='images\t_open.gif' id='op" + textArray1[0] + "'";
					this.BuildNode(TreeHtml, oNode, IsBottom, textArray2, textArray1);
					TreeHtml.Append("</a>\n");
					TreeHtml.Append("</TD>\n");
					TreeHtml.Append("</TR>\n");
					TreeHtml.Append("<TR>\n");
					if (Level > 0)
					{
						TreeHtml.Append("<TD width=15 ></TD>");
					}
					TreeHtml.Append("<TD>\n");
					TreeHtml.Append("<TABLE align=center width=100% border=0 cellPadding=0 cellSpacing=0 id='content" + textArray1[0] + "'");
				}
				else
				{
					textArray2[0] = @"src='images\t_plusl.gif' id='img" + textArray1[2] + "'";
					textArray2[1] = @"src='images\t_plus.gif' id='img" + textArray1[2] + "'";
					textArray2[2] = @"src='images\t_folder.gif' id='op" + textArray1[2] + "'";
					this.BuildNode(TreeHtml, oNode, IsBottom, textArray2, textArray1);
					TreeHtml.Append("</a>\n");
					TreeHtml.Append("</TD>\n");
					TreeHtml.Append("</TR>\n");
					TreeHtml.Append("<TR>\n");
					if (Level > 0)
					{
						TreeHtml.Append("<TD width=15 ></TD>");
					}
					TreeHtml.Append("<TD>\n");
					TreeHtml.Append("<TABLE align=center width=100% border=0 style='DISPLAY: none' cellPadding=0 cellSpacing=0 id='content" + textArray1[2] + "'");
				}
				TreeHtml.Append("><TBODY>\n");
				for (int num1 = 0; num1 < oNode.ChildNodes.Count; num1++)
				{
					if (num1 == (oNode.ChildNodes.Count - 1))
					{
						this.BuildTreeView(TreeHtml, oNode.ChildNodes[num1], Level + 1, true);
					}
					else
					{
						this.BuildTreeView(TreeHtml, oNode.ChildNodes[num1], Level + 1, false);
					}
				}
				TreeHtml.Append("</TBODY></TABLE>\n");
				TreeHtml.Append("</TD>\n");
				TreeHtml.Append("</TR>\n");
			}
		}
 
		private bool IsParentNode(XmlNode oNode)
		{
			bool flag1 = false;
			for (int num1 = 0; num1 < oNode.ChildNodes.Count; num1++)
			{
				if (XmlUtil.GetNodeAttributeValue(oNode.ChildNodes[num1], "id") == this.SelectedNode)
				{
					flag1 = true;
					break;
				}
				flag1 = this.IsParentNode(oNode.ChildNodes[num1]);
			}
			return flag1;
		}
 
		protected override void Render(HtmlTextWriter output)
		{
			XmlDocument document1 = new XmlDocument();
			StringBuilder builder1 = new StringBuilder();
			document1.LoadXml(this.TreeXml);
			XmlNodeList list1 = document1.FirstChild.ChildNodes;
			builder1.Append("<link href='" + this.CssFilePath + "' type='text/css' rel='stylesheet'>");
			builder1.Append("<TABLE  align=left border=0 cellPadding=0 cellSpacing=0 " + base.Style.ToString() + "><TBODY>");
			if (list1.Count > 0)
			{
				for (int num1 = 0; num1 < list1.Count; num1++)
				{
					if (num1 == (list1.Count - 1))
					{
						this.BuildTreeView(builder1, list1[num1], 0, true);
					}
					else
					{
						this.BuildTreeView(builder1, list1[num1], 0, false);
					}
				}
			}
			builder1.Append("</TBODY></TABLE>");
			builder1.Append("<script language='javascript'>\n");
			builder1.Append("arrs = new Array(" + Convert.ToString(list1.Count) + ");\n");
			builder1.Append("arrimg = new Array(" + Convert.ToString(list1.Count) + ");\n");
			builder1.Append("arrop = new Array(" + Convert.ToString(list1.Count) + ");\n");
			builder1.Append(" var numTotal=" + Convert.ToString(list1.Count) + ";\n");
			builder1.Append("var i;\n");
			builder1.Append("var arrval;\n");
			int num2 = -1;
			for (int num3 = 0; num3 < list1.Count; num3++)
			{
				if (list1.Item(num3).HasChildNodes)
				{
					num2++;
					builder1.Append("arrval=" + XmlUtil.GetNodeAttributeValue(list1.Item(num3), "id") + ";\n");
					builder1.Append("arrs[" + num2 + "]='content' + arrval;\n");
					builder1.Append("arrimg[" + num2 + "]='img' +arrval;\n");
					builder1.Append("arrop[" + num2 + "]='op' +arrval;\n");
				}
			}
			builder1.Append("</script>\n");
			builder1.Append("<script language='javascript'>\n");
			builder1.Append("function mOvr(src, cOvr)\n");
			builder1.Append("{if (!src.contains(event.fromElement)) {src.style.cursor = 'default';src.bgColor = cOvr;}}\n");
			builder1.Append("function mOut(src, cOut)\n");
			builder1.Append("{if (!src.contains(event.toElement)) {src.style.cursor = 'default';src.bgColor = cOut;}}\n");
			builder1.Append("</script>\n");
			builder1.Append("<script language='javascript'>\n");
			builder1.Append("function clikker(islast,block,arrow,srcimg)\n");
			builder1.Append("{ \n");
			builder1.Append("var lastone\n");
			builder1.Append("if (islast==1)\n");
			builder1.Append("{lastone=true;}\n");
			builder1.Append("else\n");
			builder1.Append("{lastone=false;}; \n");
			builder1.Append("if (navigator.appName == 'Netscape')\n");
			builder1.Append("{\n");
			builder1.Append("var obj,imgobj1,imgobj2\n");
			builder1.Append("obj=eval(block);\n");
			builder1.Append("imgobj1=eval(arrow);\n");
			builder1.Append("imgobj2=eval(srcimg);\n");
			builder1.Append("if (obj.visibility=='hide')\n");
			builder1.Append("{\n");
			builder1.Append("\tobj.visibility='show';\n");
			builder1.Append("\tif (lastone)\n");
			builder1.Append("\t {\n");
			builder1.Append("\t   imgobj1.src='images/t_minul.gif';\n");
			builder1.Append("\t }\n");
			builder1.Append("\telse\n");
			builder1.Append("\t {\n");
			builder1.Append("\t   imgobj1.src='images/t_minu.gif';\n");
			builder1.Append("\t };\n");
			builder1.Append("\timgobj2.src='images/t_folder.gif';\t\n");
			builder1.Append("}\n");
			builder1.Append("  else\n");
			builder1.Append("{\n");
			builder1.Append("\tobj.visibility='hide';\n");
			builder1.Append("\tif (lastone)\n");
			builder1.Append("\t {\n");
			builder1.Append("imgobj1.src='images/t_plusl.gif';\n");
			builder1.Append("}\n");
			builder1.Append(" else\n");
			builder1.Append("{\n");
			builder1.Append("\t\timgobj1.src='images/t_plus.gif';\n");
			builder1.Append("\t }; \t\n");
			builder1.Append("\timgobj2.src='images/t_open.gif';\t\n");
			builder1.Append("};\n");
			builder1.Append("\t } \t\n");
			builder1.Append("else\n");
			builder1.Append("{\n");
			builder1.Append("var blockid\n");
			builder1.Append("var str1\n");
			builder1.Append("blockid=block.id;\n");
			builder1.Append("if (block.style.display =='') \n");
			builder1.Append("{\n");
			builder1.Append("\tblock.style.display = 'none';\n");
			builder1.Append("   if (lastone)\n");
			builder1.Append("\t\t{\n");
			builder1.Append("\t\t  arrow.src = 'images/t_plusl.gif';\n");
			builder1.Append("\t\t}\n");
			builder1.Append("   else\t\n");
			builder1.Append("      \t{\n");
			builder1.Append("\t\t   arrow.src = 'images/t_plus.gif';\n");
			builder1.Append("\t\t};\n");
			builder1.Append("\tsrcimg.src='images/t_folder.gif';\n");
			builder1.Append("  }\n");
			builder1.Append(" else \n");
			builder1.Append("{\n");
			builder1.Append("\tblock.style.display='';\t\n");
			builder1.Append("\tif (lastone) \n");
			builder1.Append("\t {\t  \n");
			builder1.Append("\t  arrow.src = 'images/t_minul.gif';\n");
			builder1.Append("\t }\n");
			builder1.Append("\telse\n");
			builder1.Append("\t {\n");
			builder1.Append("\t  arrow.src = 'images/t_minu.gif';\n");
			builder1.Append("\t };  \n");
			builder1.Append("\t srcimg.src='images/t_open.gif';\t\t\n");
			builder1.Append("\tfor(i=0;i<=" + Convert.ToString(num2) + ";i++)\n");
			builder1.Append("\t{\n");
			builder1.Append("\t   \tcloitm = eval(arrs[i]);\n");
			builder1.Append("\t\titmimg = eval(arrimg[i]);\n");
			builder1.Append("\t\titmop = eval(arrop[i]);\n");
			builder1.Append("\t    str1=itmimg.src;\n");
			builder1.Append("\t    str1=str1.substring(str1.lastIndexOf('/')+1);\n");
			builder1.Append("\t\tif (block!=cloitm && !is_part(blockid,arrs[i]))\n");
			builder1.Append("\t\t{\n");
			builder1.Append("\t\t   cloitm.style.display='none'\n");
			builder1.Append("\t\t   if ((str1=='t_minul.gif') || (str1=='t_plusl.gif' ))\n");
			builder1.Append("\t    \t{\t \n");
			builder1.Append("\t\t    \titmimg.src='images/t_plusl.gif';\n");
			builder1.Append("\t\t    }\n");
			builder1.Append("\t\t   else\n");
			builder1.Append("\t\t    {\t\n");
			builder1.Append("\t\t    \titmimg.src='images/t_plus.gif';\n");
			builder1.Append("\t\t    };\n");
			builder1.Append("\t\t\titmop.src='images/t_folder.gif';\n");
			builder1.Append("\t\t};\n");
			builder1.Append("\t};\n");
			builder1.Append("};\n");
			builder1.Append("};\n");
			builder1.Append("}\n");
			builder1.Append("function is_part(str1,str2) //\u5224\u65ad\u4e0a\u7ea7\u8282\u70b9\n");
			builder1.Append("{\n");
			builder1.Append("var i,j\n");
			builder1.Append("var len1,len2\n");
			builder1.Append("len1=str1.length;\n");
			builder1.Append("len2=str2.length;\n");
			builder1.Append("j=0\n");
			builder1.Append("if (len2>len1){return false}\n");
			builder1.Append("for (i=len2;i<len1;i++)\n");
			builder1.Append("{\n");
			builder1.Append("if (str2==str1.substring(0,i))\n");
			builder1.Append("{\n");
			builder1.Append("j=1;\n");
			builder1.Append("break;\n");
			builder1.Append("}\n");
			builder1.Append("};\n");
			builder1.Append("if (j==0)\n");
			builder1.Append("{return false}\n");
			builder1.Append("else\n");
			builder1.Append("{return true};\n");
			builder1.Append("}\n");
			builder1.Append("</script>\n");
			output.Write(builder1.ToString());
		}
 

	}
}
