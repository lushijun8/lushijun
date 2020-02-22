using System;
using System.Collections;

namespace Com.Common
{
	/// <summary>
	/// HashTableUtil ��ժҪ˵����
	/// </summary>
	public class HashTableUtil
	{
		public HashTableUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
