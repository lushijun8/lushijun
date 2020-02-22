using System;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
namespace Com.Globalization
{
	/**//// <summary>
	/// ���ķִ�����
	/// </summary>
	public class ChineseParse
	{
		private static ChineseWordsHashCountSet _countTable;
		static ChineseParse()
		{
			_countTable = new ChineseWordsHashCountSet();
			InitFromFile("ChineseDictionary.txt");
		}
		/**//// <summary>
		/// ��ָ�����ļ��г�ʼ�����Ĵ����ֵ���ַ��������ֵ䡣
		/// </summary>
		/// <param name="fileName">�ļ���</param>
		private static void InitFromFile(string fileName)
		{
			string path = Directory.GetCurrentDirectory() +@"\" + fileName;
			if (System.IO.File.Exists(path))
			{
				using (StreamReader sr = System.IO.File.OpenText(path)) 
				{
					string s = "";
					while ((s = sr.ReadLine()) != null) 
					{
						ChineseWordUnit _tempUnit = InitUnit(s);
						_countTable.InsertWord(_tempUnit.Word);
					}
				}
			}
		}
		/**//// <summary>
		/// ��һ���ַ�������ΪChineseWordUnit��
		/// </summary>
		/// <param name="s">�ַ���</param>
		/// <returns>�����õ���ChineseWordUnit</returns>
		private static ChineseWordUnit InitUnit(string s)
		{
			Regex reg = new Regex(@"\s+");
			string[] temp = reg.Split(s);
			if (temp.Length!=2)
			{
				throw new Exception("�ַ�����������"+s);
			}
			return new ChineseWordUnit(temp[0],Int32.Parse(temp[1]));
		}
		/**//// <summary>
		/// ����������ַ����������и��һ�����Ĵ��
		/// </summary>
		/// <param name="s">���и���ַ���</param>
		/// <returns>���и�õ������Ĵ�������</returns>
		public static string[] ParseChinese(string s)
		{
			int _length = s.Length;
			string _temp = String.Empty;
			ArrayList _words = new ArrayList();
			for(int i=0;i<s.Length;)
			{
				_temp = s.Substring(i,1);
				if (_countTable.GetCount(_temp)>1)
				{
					int j=2;

					for (;i+j<s.Length+1&&_countTable.GetCount(s.Substring(i,j))>0;j++)
					{
					}
					_temp = s.Substring(i,j-1);
					i = i + j - 2;
				}
				i++;
				_words.Add(_temp);
			}
			string[] _tempStringArray = new string[_words.Count];
			_words.CopyTo(_tempStringArray);
			return _tempStringArray;
		}
	}
}
