using System;
using System.Data;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
namespace Com.Globalization
{
	/// <summary>
	/// 中文分词器。请先设置   
	/// </summary>
	public class ChineseSegmenter 
	{

//		private static ChineseSegmenter segmenter = null;

		private Hashtable keywords;

		private ArrayList foreignwords, numberswords;

		/// <summary>
		/// 词语列表
		/// </summary>
		public Hashtable KeyWords
		{
			set
			{
				this.keywords=value;
			}
			get
			{
				return this.keywords;
			}
		}

		/// <summary>
		/// 外来词列表
		/// </summary>
		public ArrayList ForeignWords
		{
			set
			{
				this.foreignwords=value;
			}
			get
			{
				return this.foreignwords;
			}
		}
		/// <summary>
		/// 中文数字列表
		/// </summary>
		public ArrayList NumbersWords
		{
			set
			{
				this.numberswords=value;
			}
			get
			{
				return this.numberswords;
			}
		}
		/// <summary>
		/// 繁体
		/// </summary>
		public  static int TRAD = 0;

		/// <summary>
		/// 简体
		/// </summary>
		public  static int SIMP = 1;

		/// <summary>
		/// 简体和繁体
		/// </summary>
		public  static int BOTH = 2;

		/// <summary>
		/// 请先设置 KeyWords,ForeignWords,NumbersWords
		/// </summary>
		/// <param name="charform">0:繁体;1简体;2简体和繁体</param>
		/// <param name="WordTable">包含KEYWORD_NAME,KEYWORD_TYPE的关键字表</param>
		public ChineseSegmenter(int charform, DataTable WordTable) 
		{
		/* 0	both
		1   simp
		2	trad
		3	sforeign
		4	snotname
		5	snumbers
		6	ssurname
		7	tforeign
		8	tnotname
		9	tnumbers
		10	tsurname
		*/
			foreignwords = new ArrayList();
			numberswords = new ArrayList();

			if (charform == SIMP) 
			{
				loadset(numberswords, WordTable.Select("KEYWORD_TYPE='5'"));
				loadset(foreignwords, WordTable.Select("KEYWORD_TYPE='3'"));
			} 
			else if (charform == TRAD) 
			{
				loadset(numberswords, WordTable.Select("KEYWORD_TYPE='9'"));
				loadset(foreignwords, WordTable.Select("KEYWORD_TYPE='7'"));
			} 
			else 
			{ // BOTH
				loadset(numberswords, WordTable.Select("KEYWORD_TYPE='5'"));
				loadset(foreignwords, WordTable.Select("KEYWORD_TYPE='3'"));
				loadset(numberswords, WordTable.Select("KEYWORD_TYPE='9'"));
				loadset(foreignwords, WordTable.Select("KEYWORD_TYPE='7'"));
			}

			 keywords = new Hashtable(120000);

			string newword = null;
			try 
			{
				DataRow[] oDr=null;
				if (charform == SIMP) 
				{
					oDr=WordTable.Select("KEYWORD_TYPE='1'");
				} 
				else if (charform == TRAD) 
				{
					oDr=WordTable.Select("KEYWORD_TYPE='2'");
				} 
				else if (charform == BOTH) 
				{
					oDr=WordTable.Select("KEYWORD_TYPE='0'");
				}

				for(int i=0;i<oDr.Length ; i ++)
				{
					newword=oDr[i]["KEYWORD_NAME"].ToString().Trim();
					if ((newword.IndexOf("#") == -1) && (newword.Length < 5)) 
					{
						if(!keywords.ContainsKey(newword))
						keywords.Add(newword, "1");
						if (newword.Length == 3) 
						{
							if (keywords.ContainsKey(newword.Substring(0, 2)) == false) 
							{
								keywords.Add(newword.Substring(0, 2), "2");
							}
						}

						if (newword.Length == 4) 
						{
							if (keywords.ContainsKey(newword.Substring(0, 2)) == false) 
							{
								keywords.Add(newword.Substring(0, 2), "2");
							}
							if (keywords.ContainsKey(newword.Substring(0, 3)) == false) 
							{
								keywords.Add(newword.Substring(0, 3), "2");
							}
						}
					}
				}
			}
			catch (IOException e) 
			{
				Com.File.FileLog.WriteLog("Com.Globalization.ChineseSegmenter.ChineseSegmenter()",e.ToString());
			}

		}
   
		private void loadset(ArrayList targetset,DataRow[] oDr) 
		{
			string dataline;
			try 
			{
				for(int i=0;i<oDr.Length ; i ++)
				{
					dataline=oDr[i]["KEYWORD_NAME"].ToString().Trim();
					if ((dataline.IndexOf("#") > -1) || (dataline.Length == 0)) 
					{
						continue;
					}
					targetset.Add(dataline);
				}	
			} 
			catch (Exception e) 
			{
				Com.File.FileLog.WriteLog("Com.Globalization.ChineseSegmenter","读取关键字DataTable出错："+e.ToString());
			}
		}

		public bool isNumber(string testword) 
		{
			bool result = true;
			for (int i = 0; i < testword.Length; i++) 
			{
				if (numberswords.Contains(testword.Substring(i,1)) == false) 
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public bool isAllForeign(string testword) 
		{
			bool result = true;
			for (int i = 0; i < testword.Length; i++) 
			{
				if (foreignwords.Contains(testword.Substring(i,1)) == false) 
				{
					result = false;
					break;
				}
			}

			return result;
		}

		public string segmentLine(string cline, string separator) 
		{
			StringBuilder currentword = new StringBuilder();
			StringBuilder outline = new StringBuilder();
			int i, clength;
			char currentchar;
			// separator = " ";

			clength = cline.Length;
      
			for (i = 0; i < clength; i++) 
			{
				currentchar = char.Parse(cline.Substring(i,1));
				Encoding strGB = Encoding.Default;
				char [] c=new char[]{currentchar}; 
				byte []Hz=strGB.GetBytes(c);
				if (Hz.GetLength(0)==1)   // 普通字符
				{
					if (currentword.Length > 0) 
					{
						outline.Append(currentword.ToString());
						if (currentchar.ToString().Trim()!="")
						{
							outline.Append(separator);
						}
						currentword.Length=0;
					}
					outline.Append(currentchar);
					continue;
				}
				int k = Hz[0]*256+Hz[1];
				if ((k>= 45217 && k < 55290) || isNumber(cline.Substring(i,1)) == true) 
				{
					// Character in CJK block
					if (currentword.Length == 0) 
					{ // start looking for next
						// word
						if (i > 0 && (cline.Substring(i-1,1).Trim() != "")) 
						{
							outline.Append(separator);
						}
						currentword.Append(currentchar);

					} 
					else 
					{
						if (keywords.ContainsKey(currentword.ToString()+ currentchar.ToString()) == true
							&& keywords[currentword.ToString()+ currentchar.ToString()].ToString() == "1") 
						{
							// word is in lexicon
							currentword.Append(currentchar);
						} 
						else if (isAllForeign(currentword.ToString())
							&& foreignwords.Contains(new string(
							new char[] { currentchar }))
							&& i + 2 < clength
							&& (keywords.ContainsKey(cline.Substring(i,  2)
							) == false)) 
						{
							// Possible a transliteration of a foreign name
							currentword.Append(currentchar);
						} 
						else if (isNumber(currentword.ToString())
							&& numberswords.Contains(new string(
							new char[] { currentchar }))
							/*
							 * && (i + 2 < clength) &&
							 * (keywords.ContainsKey(cline.Substring(i, i+2)) ==
							 * false)
							 */) 
						{
							// Put all consecutive number characters together
							currentword.Append(currentchar);
						} 
						else if (keywords.ContainsKey(currentword.ToString()+ currentchar.ToString())
							&& keywords[currentword.ToString()+ currentchar.ToString()].ToString()=="2"
							&& i + 1 < clength
							&& (keywords.ContainsKey(currentword.ToString()+ currentchar + cline.Substring(i + 1,1)) == true)) 
						{
							// Starts a word in the lexicon
							currentword.Append(currentchar);

						}
						else 
						{ // Start anew
							outline.Append(currentword.ToString());
							if (currentchar.ToString().Trim()!="") 
							{
								outline.Append(separator);
							}
							currentword.Length=0;
							currentword.Append(currentchar);
						}
					}

				} 
				else 
				{ // Not chinese character
					// System.err.println("not cjk");
					if (currentword.Length > 0) 
					{
						outline.Append(currentword.ToString());
						if (currentchar.ToString().Trim()!="")
						{
							outline.Append(separator);
						}
						currentword.Length=0;
					}
					outline.Append(currentchar);
				}
			}

			outline.Append(currentword.ToString());

			return outline.ToString();
			// return offsets;
		}
	}
}