using System;
using System.Collections;
namespace Com.Globalization
{
	/**//// <summary>
	/// ��¼�ַ��������������ֵ���¼���Ĵ����ǰ�˵Ĵ������ֵ��ࡣ���ַ������С������ڡ��й�����ǰ�ˣ������ֵ��м�¼һ��������
	/// </summary>
	public class ChineseWordsHashCountSet
	{
		/**//// <summary>
		/// ��¼�ַ��������Ĵ����г��ִ�����Hashtable����Ϊ�ض����ַ�����ֵΪ���ַ��������Ĵ����г��ֵĴ�����
		/// </summary>
		private Hashtable _rootTable;

		/**//// <summary>
		/// ���ͳ�ʼ����
		/// </summary>
		public ChineseWordsHashCountSet()
		{
			_rootTable = new Hashtable();
		}

		/**//// <summary>
		/// ��ѯָ���ַ��������������ֵ���¼���Ĵ����ǰ�˵Ĵ�����
		/// </summary>
		/// <param name="s">ָ���ַ���</param>
		/// <returns>�ַ��������������ֵ���¼���Ĵ����ǰ�˵Ĵ�������Ϊ-1����ʾ�����֡�</returns>
		public int GetCount(string s)
		{
			if (!this._rootTable.ContainsKey(s.Length))
			{
				return -1;
			}
			Hashtable _tempTable = (Hashtable)this._rootTable[s.Length];
			if (!_tempTable.ContainsKey(s))
			{
				return -1;
			}
			return (int)_tempTable[s];
		}

		/**//// <summary>
		/// ������ֵ��в���һ����������ô����������ֵ䡣
		/// </summary>
		/// <param name="s">��������ַ�����</param>
		public void InsertWord(string s)
		{
			for(int i=0;i<s.Length;i++)
			{
				string _s = s.Substring(0,i+1);
				this.InsertSubString(_s);
			}
		}

		/**//// <summary>
		/// ������ֵ��в���һ���ַ����Ĵ�����¼��
		/// </summary>
		/// <param name="s">��������ַ�����</param>
		private void InsertSubString(string s)
		{
			if (!_rootTable.ContainsKey(s.Length)&&s.Length>0)
			{
				Hashtable _newHashtable = new Hashtable();
				_rootTable.Add(s.Length,_newHashtable);
			}
			Hashtable _tempTable = (Hashtable)_rootTable[s.Length];
			if (!_tempTable.ContainsKey(s))
			{
				_tempTable.Add(s,1);
			}
			else
			{
				_tempTable[s]=(int)_tempTable[s]+1;
			}
		}
	}
}