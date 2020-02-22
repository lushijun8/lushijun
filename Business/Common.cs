using System;
using System.Data ;
using System.Data.SqlClient ;
using System.Text  ;
using System.Xml ;
using System.Web ;
using System.Collections ;
using System.Collections.Specialized  ;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Com.Data;
using System.Reflection;  
using Com.Common;
using Com.Xml;

namespace Business
{
	/// <summary>
	/// Common 的摘要说明。
	/// </summary>
	
	public class Common
	{
		public Common()
		{
		}



        /// <summary>
        /// 设置控件可用属性
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="Value"></param>
        public static void SetEnabled(Control Ctrl, bool Value)
        {
            foreach (Control SubCtrl in Ctrl.Controls)
            {
                if (SubCtrl is WebControl)
                {
                    if (SubCtrl is CheckBoxList)
                    {
                        continue;
                    }
                    else
                        ((WebControl)SubCtrl).Enabled = Value;
                }
                SetEnabled(SubCtrl, Value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ctrls"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public static void SetAttribute(WebControl[] Ctrls, string Key, string Value)
        {
            for (int i = 0; i < Ctrls.Length; i++)
            {
                if (Ctrls[i].Attributes[Key] == null)
                {
                    Ctrls[i].Attributes.Add(Key, Value);
                }
                else
                {
                    string Attr = "";
                    if (Ctrls[i].Attributes[Key].IndexOf(Value) == -1)
                    {
                        Attr = Value + ";" + Ctrls[i].Attributes[Key].Replace(Value, "");
                        Ctrls[i].Attributes.Add(Key, Attr.Replace(";;", ";"));
                    }
                }
            }
        }
        public static void SetAttribute(HtmlControl[] Ctrls, string Key, string Value)
        {
            for (int i = 0; i < Ctrls.Length; i++)
            {
                if (Ctrls[i].Attributes[Key] == null)
                {
                    Ctrls[i].Attributes.Add(Key, Value);
                }
                else
                {
                    string Attr = "";
                    if (Ctrls[i].Attributes[Key].IndexOf(Value) == -1)
                    {
                        Attr = Value + ";" + Ctrls[i].Attributes[Key].Replace(Value, "");
                        Ctrls[i].Attributes.Add(Key, Attr.Replace(";;", ";"));
                    }
                }
            }
        }
        public static void SetNumberTextBoxAttribute(TextBox[] Ctrls)
        {
            SetAttribute(Ctrls, "style", "TEXT-ALIGN:RIGHT;");
            SetAttribute(Ctrls, "onblur", "if(this.value==''){this.value='0';}");
            SetAttribute(Ctrls, "onkeydown", "return CheckKeyCode(this,event.keyCode)");
            SetAttribute(Ctrls, "onkeyup", "if(this.value==''){this.value='0';}");
            SetAttribute(Ctrls, "onpaste", "return false");
            SetAttribute(Ctrls, "onpaste", "return false");
            SetAttribute(Ctrls, "ondragenter", "return false");
        }
        public static void SetNumberTextBoxAttribute(HtmlInputText[] Ctrls)
        {
            SetAttribute(Ctrls, "style", "TEXT-ALIGN:RIGHT;");
            SetAttribute(Ctrls, "onblur", "if(this.value==''){this.value='0';}");
            SetAttribute(Ctrls, "onkeydown", "return CheckKeyCode(this,event.keyCode)");
            SetAttribute(Ctrls, "onkeyup", "if(this.value==''){this.value='0';}");
            SetAttribute(Ctrls, "onpaste", "return false");
            SetAttribute(Ctrls, "onpaste", "return false");
            SetAttribute(Ctrls, "ondragenter", "return false");
        }
        public static void DeleteDataItem(DataGrid oDg, DataTable oDt)
        {
            int flag = 0;
            for (int i = oDt.Rows.Count - 1; i > -1; i--)
            {
                CheckBox cbSelect = (CheckBox)oDg.Items[i].Cells[0].FindControl("cbSelect");
                if (cbSelect.Checked == true)
                {
                    try
                    {
                        DataRow oDr = oDt.Rows[i];
                        oDt.Rows.Remove(oDr);
                        flag = 1;
                    }
                    catch
                    {
                    }
                }
            }
            if (flag == 1)
            {
                oDt.AcceptChanges();
                oDg.DataSource = oDt;
                oDg.DataBind();
            }
        }
        public static void AddDataItem(DataGrid oDg, DataTable oDt)
        {
            DataRow NRow = oDt.NewRow();

            oDt.Rows.Add(NRow);
            oDt.AcceptChanges();
            oDg.DataSource = oDt;
            oDg.DataBind();
        }

        /// <summary>
        /// 根据当前时间，生成19位流水号
        /// </summary>
        /// <returns></returns>
        public static string GenFileNameFromDateTime()
        {
            string strResult = "";
            System.Random ro = new System.Random();
            int iResult;
            iResult = ro.Next(999);

            strResult = DateTime.Now.Year.ToString().Substring(2, 2) +
                DateTime.Now.Month.ToString().PadLeft(2, '0') +
                DateTime.Now.Day.ToString().PadLeft(2, '0') +
                DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                DateTime.Now.Minute.ToString().PadLeft(2, '0') +
                DateTime.Now.Second.ToString().PadLeft(2, '0') +
                DateTime.Now.Millisecond.ToString().PadLeft(4, '0') + iResult.ToString().PadLeft(3, '0');
            return strResult;
        }
        /// <summary>
        /// 要求Item.Value用','隔开
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="Value"></param>
        public static void SetValueToListControl(WebControl Ctrl, string Value)
        {
            string[] array = Value.Split(',');
            if (Ctrl is CheckBox)
            {
                CheckBox cb = (CheckBox)Ctrl;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == cb.Text)
                    {
                        cb.Checked = true;
                        break;
                    }

                }
            }
            else if (Ctrl is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)Ctrl;
                foreach (ListItem oItem in cbl.Items)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == oItem.Value)
                        {
                            oItem.Selected = true;
                            break;
                        }

                    }
                }
            }
            else if (Ctrl is RadioButtonList)
            {
                RadioButtonList rbl = (RadioButtonList)Ctrl;
                if (array.Length > 0)
                {
                    try
                    {
                        rbl.SelectedValue = array[0];
                    }
                    catch { }
                }
            }
        }
        public static string GetValueFromListControl(WebControl Ctrl)
        {
            string Value = "";
            if (Ctrl is CheckBox)
            {
                CheckBox cb = (CheckBox)Ctrl;
                if (cb.Checked == true)
                {
                    Value += cb.Text + ",";
                }
            }
            else if (Ctrl is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)Ctrl;
                foreach (ListItem oItem in cbl.Items)
                {

                    if (oItem.Selected == true)
                    {
                        Value += oItem.Value + ",";
                    }
                }
            }
            else if (Ctrl is RadioButtonList)
            {
                RadioButtonList rbl = (RadioButtonList)Ctrl;
                if (rbl.SelectedIndex != -1)
                    Value += rbl.SelectedItem.Value;
            }
            return Value.TrimEnd(',');
        }
        public static string resumeXml(string strXml)
        {
            string strResult = strXml;

            strResult = strResult.Replace("$@!", "<");
            strResult = strResult.Replace("\"", "'");
            strResult = strResult.Replace("%@!", "#");

            return strResult;
        }
		 

	}
}
