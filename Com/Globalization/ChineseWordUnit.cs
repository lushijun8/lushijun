using System;

namespace Com.Globalization
{
	public struct ChineseWordUnit
	{
		private string _word;
		private int _power;

		/**//// <summary>
		/// ���Ĵ��ﵥԪ����Ӧ�����Ĵʡ�
		/// </summary>
		public string Word
		{
			get
			{
				return _word;
			}
		}
		/**//// <summary>
		/// �����Ĵ����Ȩ�ء�
		/// </summary>
		public int Power
		{
			get
			{
				return _power;
			}
		}

		/**//// <summary>
		/// �ṹ��ʼ����
		/// </summary>
		/// <param name="word">���Ĵ���</param>
		/// <param name="power">�ô����Ȩ��</param>
		public ChineseWordUnit(string word, int power)
		{
			this._word = word;
			this._power = power;
		}
	}	
}