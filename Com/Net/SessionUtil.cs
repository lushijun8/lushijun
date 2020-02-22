using System;
using System.IO;
using System.Collections;
using Com.Data;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace Com.Net
{
	/// <summary>
	/// SessionUtil 的摘要说明。
	/// </summary>
	
	public class SessionUtil
	{
		private static ArrayList _onlineUserList;
		private static DateTime _onlineUserUpdateTime;
		private static Type[] s_serializedTypes;
		public  SessionUtil()
		{
			Type[] typeArray1 = new Type[0x16];
			typeArray1[1] = typeof(string);
			typeArray1[2] = typeof(int);
			typeArray1[3] = typeof(bool);
			typeArray1[4] = typeof(DateTime);
			typeArray1[5] = typeof(decimal);
			typeArray1[6] = typeof(byte);
			typeArray1[7] = typeof(char);
			typeArray1[8] = typeof(float);
			typeArray1[9] = typeof(double);
			typeArray1[10] = typeof(sbyte);
			typeArray1[11] = typeof(short);
			typeArray1[12] = typeof(long);
			typeArray1[13] = typeof(ushort);
			typeArray1[14] = typeof(uint);
			typeArray1[15] = typeof(ulong);
			typeArray1[0x10] = typeof(TimeSpan);
			typeArray1[0x11] = typeof(Guid);
			typeArray1[0x12] = typeof(IntPtr);
			typeArray1[0x13] = typeof(UIntPtr);
			SessionUtil.s_serializedTypes = typeArray1;
		}
		public static object ReadValueFromStream(System.IO.BinaryReader reader)
		{
			int num1;
			int[] numArray1;
			object obj1 = null;
			switch (reader.ReadByte())
			{
				case 1:
				{
					return reader.ReadString();
				}
				case 2:
				{
					return reader.ReadInt32();
				}
				case 3:
				{
					return reader.ReadBoolean();
				}
				case 4:
				{
					return new DateTime(reader.ReadInt64());
				}
				case 5:
				{
					numArray1 = new int[5];
					num1 = 0;
					goto Label_00CA;
				}
				case 6:
				{
					return reader.ReadByte();
				}
				case 7:
				{
					return reader.ReadChar();
				}
				case 8:
				{
					return reader.ReadSingle();
				}
				case 9:
				{
					return reader.ReadDouble();
				}
				case 10:
				{
					return reader.ReadSByte();
				}
				case 11:
				{
					return reader.ReadInt16();
				}
				case 12:
				{
					return reader.ReadInt64();
				}
				case 13:
				{
					return reader.ReadUInt16();
				}
				case 14:
				{
					return reader.ReadUInt32();
				}
				case 15:
				{
					return reader.ReadUInt64();
				}
				case 16:
				{
					return new TimeSpan(reader.ReadInt64());
				}
				case 17:
				{
					byte[] buffer1 = reader.ReadBytes(0x10);
					return new Guid(buffer1);
				}
				case 18:
				{
					if (IntPtr.Size == 4)
					{
						return new IntPtr(reader.ReadInt32());
					}
					goto Label_01D3;
				}
				case 19:
				{
					if (UIntPtr.Size == 4)
					{
						return new UIntPtr(reader.ReadUInt32());
					}
					goto Label_0201;
				}
				case 20:
				{
					System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter1 = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					return formatter1.Deserialize(reader.BaseStream);
				}
				case 21:
				{
					goto Label_022B;
				}
				default:
				{
					return obj1;
				}
			}
			Label_00BD:
			{
				numArray1[num1] = reader.ReadInt32();
				num1++;
			}
			Label_00CA:
			{
				if (num1>= 4)
				{
					goto Label_00BD; 
				}
				return new decimal(numArray1);
			}
			Label_01D3: 
			{
				return new IntPtr(reader.ReadInt64());
			}
			Label_0201: 
			{
				return new UIntPtr(reader.ReadUInt64());
			}
			Label_022B: 
			{
				return null; 
			}
		}
		public static ArrayList GetSessionList(string SessionName)
		{
			if (SessionUtil._onlineUserList == null)
			{
				SessionUtil._onlineUserList = new ArrayList();
				SessionUtil._onlineUserUpdateTime = System.DateTime.Now;
			}
			if ((DateTime.Compare(SessionUtil._onlineUserUpdateTime.AddMinutes(1),  System.DateTime.Now) < 0) || (SessionUtil._onlineUserList.Count == 0))
			{
				SessionUtil._onlineUserList.Clear();
				string text1 = "select * from tempdb..ASPStateTempSessions where datediff(minute, LockDateLocal, GetDate()) < 20";
                DataTable table1 = null;// Com.Data.SqlHelper.ExecuteDataTable(text1);
				MemoryStream stream1 = new MemoryStream();
				BinaryReader reader1 = new BinaryReader(stream1);
				NameValueCollection collection1 = new NameValueCollection();
				int num6 = table1.Rows.Count - 1;
				for (int num2 = 0; num2 <= num6; num2++)
				{
					byte[] buffer1=null;
					try
					{
						buffer1= (byte[]) table1.Rows[num2]["SessionItemShort"];
					}
					catch
					{
						continue;
					}
					stream1.SetLength(0);
					stream1.Write(buffer1, 0, buffer1.Length);
					stream1.Seek(0, SeekOrigin.Begin);
					reader1.ReadInt32();
					reader1.ReadBoolean();
					reader1.ReadBoolean();
					reader1.ReadBoolean();
					int num3 = reader1.ReadInt32();
					reader1.ReadInt32();
					int num5 = num3 - 1;
					for (int num4 = 0; num4 <= num5; num4++)
					{
						string text2 = reader1.ReadString();
						object obj1;
						obj1 = SessionUtil.ReadValueFromStream(reader1);
						if ((text2 == SessionName) && (SessionUtil._onlineUserList.BinarySearch(RuntimeHelpers.GetObjectValue(obj1)) < 0))
						{
							SessionUtil._onlineUserList.Add((string) obj1);
							break;
						}
					}
				}
				reader1.Close();
				stream1.Close();
				SessionUtil._onlineUserUpdateTime =  System.DateTime.Now;
			}
			return SessionUtil._onlineUserList;
		}

		private enum TypeID
		{
			// Fields
			Boolean = 3,
			Byte = 6,
			Char = 7,
			DateTime = 4,
			Decimal = 5,
			Double = 9,
			Guid = 0x11,
			Int16 = 11,
			Int32 = 2,
			Int64 = 12,
			IntPtr = 0x12,
			Null = 0x15,
			Object = 20,
			SByte = 10,
			Single = 8,
			String = 1,
			TimeSpan = 0x10,
			UInt16 = 13,
			UInt32 = 14,
			UInt64 = 15,
			UIntPtr = 0x13
		}
	}
}
