using System;
using System.DirectoryServices;

namespace Com.Net
{
	/// <summary>
	/// IISUtil ��ժҪ˵����
	///***********************************************************
	///************** IIS���ƹ����� **************
	///***********************************************************
	/// </summary>
	public class IISUtil
	{
		//������Ҫʹ�õ�
		private string _server,_website;
		private VirtualDirectories _virdirs;
		/// <summary>
		/// 
		/// </summary>
		protected System.DirectoryServices.DirectoryEntry rootfolder;
		private bool _batchflag;
		/// <summary>
		/// ���캯��
		/// </summary>
		public IISUtil()
		{
			//Ĭ�������ʹ��localhost�������ʱ��ػ�
			_server = "localhost";
			_website = "1";
			_batchflag = false;
		}
		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="strServer">����������</param>
		public IISUtil(string strServer)
		{
			_server = strServer;
			_website = "1"; 
			_batchflag = false;
		}
		/// <summary>
		/// Server���Զ�����ʻ��������֣�������IP�������
		/// </summary>
		public string Server
		{
			get{ return _server;}
			set{ _server = value;}
		}
		
		/// <summary>
		/// WebSite���Զ��壬Ϊһ���֣�Ϊ���㣬ʹ��string ��һ����˵��һ̨����Ϊ1,�ڶ�̨����Ϊ2����������
		/// </summary>
		public string WebSite
		{
			get{ return _website; }
			set{ _website = value; }
		}

		/// <summary>
		/// ����Ŀ¼������
		/// </summary>
		public VirtualDirectories VirDirs
		{
			get{ return _virdirs; }
			set{ _virdirs = value;}
		}

		#region ���幫������
		/// <summary>
		/// ���ӷ�����
		/// </summary>
		public void Connect()
		{
			ConnectToServer();
		}
		/// <summary>
		/// Ϊ��������
		/// </summary>
		/// <param name="strServer"></param>
		public void Connect(string strServer)
		{
			_server = strServer;
			ConnectToServer();
		}
		/// <summary>
		/// Ϊ��������
		/// </summary>
		/// <param name="strServer"></param>
		/// <param name="strWebSite"></param>
		public void Connect(string strServer,string strWebSite)
		{
			_server = strServer;
			_website = strWebSite;
			ConnectToServer();
		}
		/// <summary>
		/// �ж��Ƿ���������Ŀ¼
		/// </summary>
		/// <param name="strVirdir"></param>
		/// <returns></returns>
		public bool Exists(string strVirdir)
		{
			return _virdirs.Contains(strVirdir);
		}
		/// <summary>
		/// ���һ������Ŀ¼
		/// </summary>
		/// <param name="newdir"></param>
		public void Create(VirtualDirectory newdir)
		{
			string strPath = "IIS://" + _server + "/W3SVC/" + _website + "/ROOT/" + newdir.Name;
			if(!_virdirs.Contains(newdir.Name) || _batchflag )
			{
				try
				{
					//���뵽ROOT��Children������ȥ
					DirectoryEntry newVirDir = rootfolder.Children.Add(newdir.Name,"IIsWebVirtualDir");
					newVirDir.Invoke("AppCreate",true);
					newVirDir.CommitChanges();
					rootfolder.CommitChanges();
					//Ȼ���������
					UpdateDirInfo(newVirDir,newdir);
				}
				catch(Exception ee)
				{
					throw new Exception(ee.ToString());
				}
			}
			else
			{
				throw new Exception("This virtual directory is already exist.");
			}
		}
		/// <summary>
		/// �õ�һ������Ŀ¼
		/// </summary>
		/// <param name="strVirdir"></param>
		/// <returns></returns>
		public VirtualDirectory GetVirDir(string strVirdir)
		{
			VirtualDirectory tmp = null;
			if(_virdirs.Contains(strVirdir))
			{
				tmp = _virdirs.Find(strVirdir);
				((VirtualDirectory)_virdirs[strVirdir]).flag = 2;
			}
			else
			{
				throw new Exception("This virtual directory is not exists");
			}
			return tmp;
		}
		/// <summary>
		/// ����һ������Ŀ¼
		/// </summary>
		/// <param name="dir"></param>
		public void Update(VirtualDirectory dir)
		{
			//�ж���Ҫ���ĵ�����Ŀ¼�Ƿ����
			if(_virdirs.Contains(dir.Name))
			{
				DirectoryEntry ode = rootfolder.Children.Find(dir.Name,"IIsWebVirtualDir");
				UpdateDirInfo(ode,dir);
			}
			else
			{
				throw new Exception("This virtual directory is not exists.");
			}
		}
��
		/// <summary>
		/// ɾ��һ������Ŀ¼
		/// </summary>
		/// <param name="strVirdir"></param>
		public void Delete(string strVirdir)
		{
			if(_virdirs.Contains(strVirdir))
			{
				object[] paras = new object[2];
				paras[0] = "IIsWebVirtualDir"; //��ʾ������������Ŀ¼
				paras[1] = strVirdir;
				rootfolder.Invoke("Delete",paras);
				rootfolder.CommitChanges();
			}
			else
			{
				throw new Exception("Can't delete " + strVirdir + ",because it isn't exists.");
			}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public void UpdateBatch()
		{
			BatchUpdate(_virdirs);
		}
		/// <summary>
		/// ����һ����-)
		/// </summary>
		/// <param name="vds"></param>
		public void UpdateBatch(VirtualDirectories vds)
		{
			BatchUpdate(vds);
		}
		#endregion��
		#region ˽�з���

		/// <summary>
		/// ���ӷ�����
		/// </summary>
		private void ConnectToServer()
		{
			string strPath = "IIS://" + _server + "/W3SVC/" + _website +"/ROOT";
			try
			{
				this.rootfolder = new DirectoryEntry(strPath);
				_virdirs = GetVirDirs(this.rootfolder.Children);
			} 
			catch(Exception e)
			{
				throw new Exception("Can't connect to the server ["+ _server +"] ...",e);
			}
		}
		/// <summary>
		/// ִ����������
		/// </summary>
		/// <param name="vds"></param>
		private void BatchUpdate(VirtualDirectories vds)
		{
			_batchflag = true;
			foreach(object item in vds.Values)
			{
				VirtualDirectory vd = (VirtualDirectory)item;
				switch(vd.flag)
				{
					case 0:
						break;
					case 1:
						Create(vd);
						break;
					case 2:
						Update(vd);
						break;
				}
			}
			_batchflag = false;
		}
		/// <summary>
		/// ���¶���
		/// </summary>
		/// <param name="de"></param>
		/// <param name="vd"></param>
		private void UpdateDirInfo(DirectoryEntry de,VirtualDirectory vd)
		{
			de.Properties["AnonymousUserName"][0] = vd.AnonymousUserName;
			de.Properties["AnonymousUserPass"][0] = vd.AnonymousUserPass;
			de.Properties["AccessRead"][0] = vd.AccessRead;
			de.Properties["AccessExecute"][0] = vd.AccessExecute;
			de.Properties["AccessWrite"][0] = vd.AccessWrite;
			de.Properties["AuthBasic"][0] = vd.AuthBasic;
			de.Properties["AuthNTLM"][0] = vd.AuthNTLM;
			de.Properties["ContentIndexed"][0] = vd.ContentIndexed;
			de.Properties["EnableDefaultDoc"][0] = vd.EnableDefaultDoc;
			de.Properties["EnableDirBrowsing"][0] = vd.EnableDirBrowsing;
			de.Properties["AccessSSL"][0] = vd.AccessSSL;
			de.Properties["AccessScript"][0] = vd.AccessScript;
			de.Properties["DefaultDoc"][0] = vd.DefaultDoc;
			de.Properties["Path"][0] = vd.Path;
			de.CommitChanges();
		}

		/// <summary>
		/// ��ȡ����Ŀ¼����
		/// </summary>
		/// <param name="des"></param>
		/// <returns></returns>
		private VirtualDirectories GetVirDirs(DirectoryEntries des)
		{
			VirtualDirectories tmpdirs = new VirtualDirectories();
			foreach(DirectoryEntry de in des)
			{
				if(de.SchemaClassName == "IIsWebVirtualDir")
				{
					VirtualDirectory vd = new VirtualDirectory();
					vd.Name = de.Name;
					vd.AccessRead = (bool)de.Properties["AccessRead"][0];
					vd.AccessExecute = (bool)de.Properties["AccessExecute"][0];
					vd.AccessWrite = (bool)de.Properties["AccessWrite"][0];
					vd.AnonymousUserName = (string)de.Properties["AnonymousUserName"][0];
					vd.AnonymousUserPass = (string)de.Properties["AnonymousUserName"][0];
					vd.AuthBasic = (bool)de.Properties["AuthBasic"][0];
					vd.AuthNTLM = (bool)de.Properties["AuthNTLM"][0];
					vd.ContentIndexed = (bool)de.Properties["ContentIndexed"][0];
					vd.EnableDefaultDoc = (bool)de.Properties["EnableDefaultDoc"][0];
					vd.EnableDirBrowsing = (bool)de.Properties["EnableDirBrowsing"][0];
					vd.AccessSSL = (bool)de.Properties["AccessSSL"][0];
					vd.AccessScript = (bool)de.Properties["AccessScript"][0];
					vd.Path = (string)de.Properties["Path"][0];
					vd.flag = 0;
					vd.DefaultDoc = (string)de.Properties["DefaultDoc"][0];
					tmpdirs.Add(vd.Name,vd);
				}
			}
			return tmpdirs;
		}

	}
	#endregion

	/// <summary>
	/// VirtualDirectory��
	/// </summary>
	public class VirtualDirectory
	{
		private bool _read,_execute,_script,_ssl,_write,_authbasic,_authntlm,_indexed,_endirbrow,_endefaultdoc;
		private string _ausername,_auserpass,_name,_path;
		private int _flag;
		private string _defaultdoc;
		/// <summary>
		/// ���캯��
		/// </summary>
		public VirtualDirectory()
		{
			SetValue();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strVirDirName"></param>
		public VirtualDirectory(string strVirDirName)
		{
			_name = strVirDirName;
			SetValue();
		}
		/// <summary>
		/// 
		/// </summary>
		private void SetValue()
		{
			_read = true;_execute = false;_script = false;_ssl= false;_write=false;_authbasic=false;_authntlm=false;
			_indexed =false;_endirbrow=false;_endefaultdoc = false;
			_flag = 1;
			_defaultdoc = "default.htm,default.aspx,default.asp,index.htm";
			_path = "C:\\";
			_ausername = "";_auserpass ="";_name="";
		}
		///<summary>
		///��������,IISVirtualDir̫��������
		///��ֻ���˱Ƚ���Ҫ��һЩ�������Ĵ����Ҫ���Ը��Ӱɡ�
		///</summary>

		public int flag
		{
			get{ return _flag;}
			set{ _flag = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AccessRead
		{
			get{ return _read;}
			set{ _read = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AccessWrite
		{
			get{ return _write;}
			set{ _write = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AccessExecute
		{
			get{ return _execute;}
			set{ _execute = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AccessSSL
		{
			get{ return _ssl;}
			set{ _ssl = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AccessScript
		{
			get{ return _script;}
			set{ _script = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AuthBasic
		{
			get{ return _authbasic;}
			set{ _authbasic = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool AuthNTLM
		{
			get{ return _authntlm;}
			set{ _authntlm = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ContentIndexed
		{
			get{ return _indexed;}
			set{ _indexed = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool EnableDirBrowsing
		{
			get{ return _endirbrow;}
			set{ _endirbrow = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool EnableDefaultDoc
		{
			get{ return _endefaultdoc;}
			set{ _endefaultdoc = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get{ return _name;}
			set{ _name = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Path
		{
			get{ return _path;}
			set{ _path = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefaultDoc
		{
			get{ return _defaultdoc;}
			set{ _defaultdoc = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnonymousUserName
		{
			get{ return _ausername;}
			set{ _ausername = value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AnonymousUserPass
		{
			get{ return _auserpass;}
			set{ _auserpass = value;}
		}
	}
	/// <summary>
	/// ����VirtualDirectories
	/// </summary>

	public class VirtualDirectories : System.Collections.Hashtable
	{
		/// <summary>
		/// 
		/// </summary>
		public VirtualDirectories()
		{
		}
		//����µķ��� 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strName"></param>
		/// <returns></returns>
		public VirtualDirectory Find(string strName)
		{
			return (VirtualDirectory)this[strName];
		}
	}
}
