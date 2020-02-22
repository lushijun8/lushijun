using  System;
using  System.Runtime.InteropServices;

namespace Com.Common
{
	public enum NCBCONST
	{
		// Fields
		MAX_LANA = 0xfe,
		NCBASTAT = 0x33,
		NCBENUM = 0x37,
		NCBNAMSZ = 0x10,
		NCBRESET = 50,
		NRC_GOODRET = 0,
		NUM_NAMEBUF = 30
	}
	/// <summary>
	/// HardwareUtil 的摘要说明。
	/// </summary>
	public class HardwareUtil
	{
		public HardwareUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct ADAPTER_STATUS
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
			public byte[] adapter_address;
			public byte rev_major;
			public byte reserved0;
			public byte adapter_type;
			public byte rev_minor;
			public ushort duration;
			public ushort frmr_recv;
			public ushort frmr_xmit;
			public ushort iframe_recv_err;
			public ushort xmit_aborts;
			public uint xmit_success;
			public uint recv_success;
			public ushort iframe_xmit_err;
			public ushort recv_buff_unavail;
			public ushort t1_timeouts;
			public ushort ti_timeouts;
			public uint reserved1;
			public ushort free_ncbs;
			public ushort max_cfg_ncbs;
			public ushort max_ncbs;
			public ushort xmit_buf_unavail;
			public ushort max_dgram_size;
			public ushort pending_sess;
			public ushort max_cfg_sess;
			public ushort max_sess;
			public ushort max_sess_pkt_size;
			public ushort name_count;
		}
 

		public struct ASTAT
		{
			// Fields
			public HardwareUtil.ADAPTER_STATUS adapt;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=30)]
			public HardwareUtil.NAME_BUFFER[] NameBuff;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct LANA_ENUM
		{
			public byte length;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=0xfe)]
			public byte[] lana;
		}
 

		[StructLayout(LayoutKind.Sequential)]
		public struct NAME_BUFFER
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
			public byte[] name;
			public byte name_num;
			public byte name_flags;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct NCB
		{
			public byte ncb_command;
			public byte ncb_retcode;
			public byte ncb_lsn;
			public byte ncb_num;
			public IntPtr ncb_buffer;
			public ushort ncb_length;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
			public byte[] ncb_callname;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
			public byte[] ncb_name;
			public byte ncb_rto;
			public byte ncb_sto;
			public IntPtr ncb_post;
			public byte ncb_lana_num;
			public byte ncb_cmd_cplt;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
			public byte[] ncb_reserve;
			public IntPtr ncb_event;
		}

		public class Win32API
		{
			public Win32API()
			{
			}
			
			[DllImport("NETAPI32.DLL")]
			public static extern char Netbios(ref HardwareUtil.NCB ncb);
		}
 
		/// <summary>
		/// 获得客户端mac地址
		/// </summary>
		/// <returns></returns>
		public static string GetMacAddress()
		{
			HardwareUtil.NCB ncb1;
			string text1 = "";
			ncb1 = new HardwareUtil.NCB();
			ncb1.ncb_command = 0x37;
			int num1 = Marshal.SizeOf(typeof(HardwareUtil.LANA_ENUM));
			ncb1.ncb_buffer = Marshal.AllocHGlobal(num1);
			ncb1.ncb_length = (ushort) num1;
			char ch1 = HardwareUtil.Win32API.Netbios(ref ncb1);
			HardwareUtil.LANA_ENUM lana_enum1 = (HardwareUtil.LANA_ENUM) Marshal.PtrToStructure(ncb1.ncb_buffer, typeof(HardwareUtil.LANA_ENUM));
			Marshal.FreeHGlobal(ncb1.ncb_buffer);
			if (ch1 != '\0')
			{
				return "";
			}
			for (int num2 = 0; num2 < lana_enum1.length; num2++)
			{
				HardwareUtil.ASTAT astat1;
				ncb1.ncb_command = 50;
				ncb1.ncb_lana_num = lana_enum1.lana[num2];
				ch1 = HardwareUtil.Win32API.Netbios(ref ncb1);
				if (ch1 != '\0')
				{
					return "";
				}
				ncb1.ncb_command = 0x33;
				ncb1.ncb_lana_num = lana_enum1.lana[num2];
				ncb1.ncb_callname[0] = 0x2a;
				num1 = Marshal.SizeOf(typeof(HardwareUtil.ADAPTER_STATUS)) + (Marshal.SizeOf(typeof(HardwareUtil.NAME_BUFFER)) * 30);
				ncb1.ncb_buffer = Marshal.AllocHGlobal(num1);
				ncb1.ncb_length = (ushort) num1;
				ch1 = HardwareUtil.Win32API.Netbios(ref ncb1);
				astat1.adapt = (HardwareUtil.ADAPTER_STATUS) Marshal.PtrToStructure(ncb1.ncb_buffer, typeof(HardwareUtil.ADAPTER_STATUS));
				Marshal.FreeHGlobal(ncb1.ncb_buffer);
				if (ch1 == '\0')
				{
					if (num2 > 0)
					{
						text1 = text1 + ":";
					}
					object[] objArray1 = new object[6] { astat1.adapt.adapter_address[0], astat1.adapt.adapter_address[1], astat1.adapt.adapter_address[2], astat1.adapt.adapter_address[3], astat1.adapt.adapter_address[4], astat1.adapt.adapter_address[5] } ;
					text1 = string.Format("{0,2:X}{1,2:X}{2,2:X}{3,2:X}{4,2:X}{5,2:X}", objArray1);
				}
			}
			return text1.Replace(' ', '0');
		}
 


		[DllImport("kernel32.dll")]
		private  static  extern  int  GetVolumeInformation(
			string  lpRootPathName,
			string  lpVolumeNameBuffer,
			int  nVolumeNameSize,
			ref  int  lpVolumeSerialNumber,
			int  lpMaximumComponentLength,
			int  lpFileSystemFlags,
			string  lpFileSystemNameBuffer,
			int  nFileSystemNameSize
			);
		/// <summary>
		/// 获取指定的硬盘序列号   string  sVol  =  GetVolumeSerialNumberOf("C");
		/// </summary>
		/// <param name="drvid"></param>
		/// <returns></returns>
		public  static  string  GetVolumeSerialNumberOf(string  drvid)
		{
			const  int  MAX_FILENAME_LEN  =  256;
			int  retVal  =  0;
			int  a  =0;
			int  b  =0;
			string  str1  =  null;
			string  str2  =  null;


			int  i  =  GetVolumeInformation(
				drvid  +  @":\",
				str1,
				MAX_FILENAME_LEN,
				ref  retVal,
				a,
				b,
				str2,
				MAX_FILENAME_LEN
				);

			return  retVal.ToString("x");
		}

	}


}
