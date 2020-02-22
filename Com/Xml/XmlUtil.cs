using System;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using Com.File;
using Com.Common;
namespace Com.Xml
{
    /// <summary>
    /// XmlUtil 的摘要说明。
    /// </summary>
    public class XmlUtil
    {
        public XmlUtil()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serialize(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion


        public static XmlNode GetAbsoluteNode(XmlDocument oXml, string NodeName)
        {
            return oXml.SelectSingleNode(NodeName);
        }

        public static XmlDocument GetDocFromFile(string strFileName)
        {
            XmlDocument document2;
            try
            {
                XmlDocument document1 = new XmlDocument();
                document1.Load(strFileName);
                document2 = document1;
            }
            catch (XmlException exception1)
            {
                FileLog.WriteLog("XmlUtil--GetDocFromFile", exception1.ToString());
                document2 = null;
            }
            return document2;
        }

        public static XmlDocument GetDocFromString(string strXmlInput)
        {
            XmlDocument document2;
            try
            {
                XmlDocument document1 = new XmlDocument();
                document1.LoadXml(strXmlInput);
                document2 = document1;
            }
            catch (XmlException exception1)
            {
                FileLog.WriteLog("XmlUtil--GetDocFromString", exception1.ToString());
                document2 = null;
            }
            return document2;
        }

        public static XmlNode GetNode(XmlDocument oXml, string NodeName)
        {
            XmlNode node1 = null;
            XmlNodeList list1 = XmlUtil.GetNodeList(oXml, NodeName);
            try
            {
                if (list1.Count > 0)
                {
                    node1 = list1[0];
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                list1 = null;
            }
            return node1;
        }

        public static XmlAttribute GetNodeAttribute(XmlNode oNode, string AttrName)
        {
            XmlAttributeCollection collection1 = oNode.Attributes;
            XmlAttribute attribute1 = null;
            for (int num1 = 0; num1 < collection1.Count; num1++)
            {
                if (collection1[num1].Name.Equals(AttrName))
                {
                    attribute1 = collection1[num1];
                }
            }
            return attribute1;
        }

        public static string GetNodeAttributeValue(XmlNode oNode, string AttrName)
        {
            XmlAttribute attribute1 = XmlUtil.GetNodeAttribute(oNode, AttrName);
            string text1 = "";
            try
            {
                text1 = attribute1.Value;
            }
            catch (Exception)
            {
            }
            return text1;
        }

        public static XmlNode GetNodeByAttribute(XmlDocument oXml, string NodeName, string AttrName, string AttrValue)
        {
            XmlNode node1 = null;
            XmlNodeList list1 = oXml.SelectNodes(NodeName);
            for (int num1 = 0; num1 < list1.Count; num1++)
            {
                if (XmlUtil.GetNodeAttribute(list1[num1], AttrName).Value.Equals(AttrValue))
                {
                    node1 = list1[num1];
                }
            }
            return node1;
        }

        public static string GetNodeInnerText(XmlNode ObjNode)
        {
            if (ObjNode == null)
            {
                return "";
            }
            return ObjNode.InnerText;
        }

        public static ArrayList GetNodeList(object oInput, string strNodeName)
        {
            ArrayList list4;
            ArrayList list1 = new ArrayList();
            Type type1 = oInput.GetType();
            ArrayList list3 = null;
            try
            {
                XmlNodeList list2 = (XmlNodeList)type1.GetProperty("ChildNodes").GetValue(oInput, null);
                for (int num1 = 0; num1 < list2.Count; num1++)
                {
                    XmlNode node1 = list2.Item(num1);
                    if (node1.Name.Equals(strNodeName))
                    {
                        list1.Add(node1);
                    }
                    if (node1.ChildNodes.Count > 0)
                    {
                        list3 = XmlUtil.GetNodeList(node1, strNodeName);
                    }
                    if ((list3 != null) && (list3.Count > 0))
                    {
                        for (int num2 = 0; num2 < list3.Count; num2++)
                        {
                            list1.Add(list3[num2]);
                        }
                    }
                }
                list4 = list1;
            }
            catch (Exception)
            {
                list4 = null;
            }
            return list4;
        }

        public static XmlNodeList GetNodeList(XmlDocument oXml, string NodeName)
        {
            return oXml.GetElementsByTagName(NodeName);
        }

        public static ArrayList GetNodesByAttribute(XmlDocument oXml, string NodeName, string AttrName, string AttrValue)
        {
            ArrayList list1 = new ArrayList();
            XmlNodeList list2 = XmlUtil.GetNodeList(oXml, NodeName);
            for (int num2 = 0; num2 < list2.Count; num2++)
            {
                try
                {
                    if (XmlUtil.GetNodeAttribute(list2[num2], AttrName).Value.Equals(AttrValue))
                    {
                        int num1 = list1.Add(list2[num2]);
                    }
                }
                catch (Exception)
                {
                }
            }
            return list1;
        }
        public static string UpdateNode(string FileName, string ParentNodeName, string ChildNodeName, string KeyName, string KeyValue, string PropertyName, string PropertyValue, bool IsEncription)
        {
            string text1 = "";
            try
            {
                XmlDocument document1 = new XmlDocument();
                document1.Load(FileName);
                XmlNode node1 = document1.SelectSingleNode(ParentNodeName);
                for (XmlNode node2 = node1.FirstChild; node2 != null; node2 = node2.NextSibling)
                {
                    if ((node2.Name == ChildNodeName) && (KeyValue == node2.Attributes[KeyName].Value))
                    {
                        string text2 = PropertyValue;
                        if (IsEncription)
                        {
                            text2 = EncDec.Base64Encrypt(text2);
                        }
                        node2.Attributes[PropertyName].Value = text2;
                        break;
                    }
                }
                document1.Save(FileName);
                document1 = null;
            }
            catch (Exception exception1)
            {
                text1 = exception1.Message;
            }
            return text1;
        }
        public static bool SetNodeAttributeValue(XmlNode oNode, string AttrName, string AttrValue)
        {
            bool flag1;
            XmlAttribute attribute1 = XmlUtil.GetNodeAttribute(oNode, AttrName);
            try
            {
                attribute1.Value = AttrValue;
                flag1 = true;
            }
            catch (Exception)
            {
                flag1 = false;
            }
            return flag1;
        }

        public static string XmlStringAppendNode(string XmlStr, string NodeName, string NodeText)
        {
            return XmlUtil.XmlStringAppendNode(XmlStr, NodeName, NodeText, "");
        }

        public static string XmlStringAppendNode(string XmlStr, string NodeName, string NodeText, string NodeAttr)
        {
            XmlDocument document1 = new XmlDocument();
            XmlNode node1 = document1.CreateNode(XmlNodeType.Element, NodeName, "");
            node1.InnerText = NodeText;
            if (NodeAttr.Length > 0)
            {
                string[] textArray1 = NodeAttr.Split(";".ToCharArray());
                for (int num1 = 0; num1 < textArray1.Length; num1++)
                {
                    string[] textArray2 = textArray1[num1].Split(",".ToCharArray());
                    XmlAttribute attribute1 = document1.CreateAttribute(textArray2[0]);
                    attribute1.Value = textArray2[1];
                    node1.Attributes.Append(attribute1);
                }
            }
            document1.AppendChild(node1);
            XmlStr = XmlStr + document1.InnerXml;
            node1 = null;
            document1 = null;
            return XmlStr;
        }

        public static string XmlStringGetNodeValue(string XmlStr, string NodeName)
        {
            XmlNodeList list1;
            string text1;
            XmlDocument document1 = new XmlDocument();
            try
            {
                XmlStr = "<Root>" + XmlStr + "</Root>";
                document1.LoadXml(XmlStr);
                list1 = document1.GetElementsByTagName(NodeName);
                text1 = list1[0].InnerXml;
            }
            catch (Exception)
            {
                text1 = "";
            }
            finally
            {
                list1 = null;
                document1 = null;
            }
            return text1;
        }

        /// <summary>
        /// 通过xmlString读取DataSet
        /// </summary>
        /// <param name="XmlString"></param>
        /// <returns></returns>
        public static DataSet GetDataSetFromXmlString(string XmlString)
        {
            DataSet oDs = new DataSet();
            XmlDataDocument xd = new XmlDataDocument();
            xd.LoadXml(XmlString);
            oDs.ReadXml(new XmlNodeReader(xd));
            /*
            string xml="<?xml version=\"1.0\" standalone=\"yes\"?>"+XmlString;
            //先将xml写入文件文件
            string sFileName=Com.Config.SystemConfig.LogFilePath+"\\"+System.DateTime.Now.Millisecond+".xml";
            Com.File.FileUtil.FileCreate(sFileName,1);//创建xml文件
            Com.File.FileUtil.WriteFileContent(sFileName,xml,"UTF-8");

            oDs.ReadXml(sFileName);
            Com.File.FileUtil.DeleteFile(sFileName);//删除xml文件*/
            return oDs;
        }
    }
}
