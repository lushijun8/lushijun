using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace Com.Json
{
    public class JsonUtil
    {
        /// <summary>
        /// Serialize object to json string.
        /// </summary>
        /// <typeparam name="T">The type to be serialized.</typeparam>
        /// <param name="obj">Instance of the type T.</param>
        /// <returns>json string.</returns>
        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                return "{}";
            }

            // Get the type of obj.
            Type t = obj.GetType();

            // Just deal with the public instance properties. others ignored.
            BindingFlags bf = BindingFlags.Instance | BindingFlags.Public;

            PropertyInfo[] pis = t.GetProperties(bf);

            StringBuilder json = new StringBuilder("{");

            if (pis != null && pis.Length > 0)
            {
                int i = 0;
                int lastIndex = pis.Length - 1;

                foreach (PropertyInfo p in pis)
                {
                    // Simple string
                    if (p.PropertyType.Equals(typeof(string)))
                    {
                        json.AppendFormat("\"{0}\":\"{1}\"", p.Name, p.GetValue(obj, null));
                    }
                    // Number,boolean.
                    else if (p.PropertyType.Equals(typeof(int)) ||
                        p.PropertyType.Equals(typeof(bool)) ||
                        p.PropertyType.Equals(typeof(double)) ||
                        p.PropertyType.Equals(typeof(decimal))
                        )
                    {
                        json.AppendFormat("\"{0}\":{1}", p.Name, p.GetValue(obj, null).ToString().ToLower());
                    }
                    // Array.
                    else if (isArrayType(p.PropertyType))
                    {
                        // Array case.
                        object o = p.GetValue(obj, null);

                        if (o == null)
                        {
                            json.AppendFormat("\"{0}\":{1}", p.Name, "null");
                        }
                        else
                        {
                            json.AppendFormat("\"{0}\":{1}", p.Name, getArrayValue((Array)p.GetValue(obj, null)));
                        }
                    }
                    // Class type. custom class, list collections and so forth.
                    else if (isCustomClassType(p.PropertyType))
                    {
                        object v = p.GetValue(obj, null);
                        if (v is IList)
                        {
                            IList il = v as IList;
                            string subJsString = getIListValue(il);

                            json.AppendFormat("\"{0}\":{1}", p.Name, subJsString);
                        }
                        else
                        {
                            // Normal class type.
                            string subJsString = Serialize(p.GetValue(obj, null));

                            json.AppendFormat("\"{0}\":{1}", p.Name, subJsString);
                        }
                    }
                    // Datetime
                    else if (p.PropertyType.Equals(typeof(DateTime)))
                    {
                        DateTime dt = (DateTime)p.GetValue(obj, null);

                        if (dt == default(DateTime))
                        {
                            json.AppendFormat("\"{0}\":\"\"", p.Name);
                        }
                        else
                        {
                            json.AppendFormat("\"{0}\":\"{1}\"", p.Name, ((DateTime)p.GetValue(obj, null)).ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                    else
                    {
                        // TODO: extend.
                    }

                    if (i >= 0 && i != lastIndex)
                    {
                        json.Append(",");
                    }

                    ++i;
                }
            }

            json.Append("}");

            return json.ToString();
        }

        /// <summary>
        /// Deserialize json string to object.
        /// </summary>
        /// <typeparam name="T">The type to be deserialized.</typeparam>
        /// <param name="jsonString">json string.</param>
        /// <returns>instance of type T.</returns>
        public static T Deserialize<T>(string jsonString)
        {
            throw new NotImplementedException("Not implemented :(");
        }

        /// <summary>
        /// Get array json format string value.
        /// </summary>
        /// <param name="obj">array object</param>
        /// <returns>js format array string.</returns>
        private static string getArrayValue(Array obj)
        {
            if (obj != null)
            {
                if (obj.Length == 0)
                {
                    return "[]";
                }

                object firstElement = obj.GetValue(0);
                Type et = firstElement.GetType();
                bool quotable = et == typeof(string);

                StringBuilder sb = new StringBuilder("[");
                int index = 0;
                int lastIndex = obj.Length - 1;

                if (quotable)
                {
                    foreach (var item in obj)
                    {
                        sb.AppendFormat("\"{0}\"", item.ToString());

                        if (index >= 0 && index != lastIndex)
                        {
                            sb.Append(",");
                        }

                        ++index;
                    }
                }
                else
                {
                    foreach (var item in obj)
                    {
                        sb.Append(item.ToString());

                        if (index >= 0 && index != lastIndex)
                        {
                            sb.Append(",");
                        }

                        ++index;
                    }
                }

                sb.Append("]");

                return sb.ToString();
            }

            return "null";
        }

        /// <summary>
        /// Get Ilist json format string value.
        /// </summary>
        /// <param name="obj">IList object</param>
        /// <returns>js format IList string.</returns>
        private static string getIListValue(IList obj)
        {
            if (obj != null)
            {
                if (obj.Count == 0)
                {
                    return "[]";
                }

                object firstElement = obj[0];
                Type et = firstElement.GetType();
                bool quotable = et == typeof(string);

                StringBuilder sb = new StringBuilder("[");
                int index = 0;
                int lastIndex = obj.Count - 1;

                if (quotable)
                {
                    foreach (var item in obj)
                    {
                        sb.AppendFormat("\"{0}\"", item.ToString());

                        if (index >= 0 && index != lastIndex)
                        {
                            sb.Append(",");
                        }

                        ++index;
                    }
                }
                else
                {
                    foreach (var item in obj)
                    {
                        sb.Append(item.ToString());

                        if (index >= 0 && index != lastIndex)
                        {
                            sb.Append(",");
                        }

                        ++index;
                    }
                }

                sb.Append("]");

                return sb.ToString();
            }

            return "null";
        }

        /// <summary>
        /// Check whether t is array type.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static bool isArrayType(Type t)
        {
            if (t != null)
            {
                return t.IsArray;
            }

            return false;
        }

        /// <summary>
        /// Check whether t is custom class type.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static bool isCustomClassType(Type t)
        {
            if (t != null)
            {
                return t.IsClass && t != typeof(string);
            }

            return false;
        }
    }
}