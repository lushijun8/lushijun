using System;
using System.Collections;

namespace Com.Common
{
	/// <summary>
	/// HashTableUtil 的摘要说明。
	/// </summary>
	public class HashTableUtil
	{
		public HashTableUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static object GetHashtableValue(Hashtable hashtable, object key)
		{
			IDictionaryEnumerator enumerator1 = hashtable.GetEnumerator();
			while (enumerator1.MoveNext())
			{
				DictionaryEntry entry1 = enumerator1.Entry;
				if (entry1.Key.ToString().ToUpper() == key.ToString().ToUpper())
				{
					return entry1.Value;
				}
			}
			return string.Empty;
		}
 

	}
}
