using System;

namespace Com.Globalization
{
	public struct ChineseWordUnit
	{
		private string _word;
		private int _power;

		/**//// <summary>
		/// 中文词语单元所对应的中文词。
		/// </summary>
		public string Word
		{
			get
			{
				return _word;
			}
		}
		/**//// <summary>
		/// 该中文词语的权重。
		/// </summary>
		public int Power
		{
			get
			{
				return _power;
			}
		}

		/**//// <summary>
		/// 结构初始化。
		/// </summary>
		/// <param name="word">中文词语</param>
		/// <param name="power">该词语的权重</param>
		public ChineseWordUnit(string word, int power)
		{
			this._word = word;
			this._power = power;
		}
	}	
}