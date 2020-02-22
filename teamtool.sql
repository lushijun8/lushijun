USE [TeamTool_test]
GO

/****** Object:  Table [dbo].[Work_Transfer]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Work_Transfer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Work_From_WebManager_Name] [nvarchar](50) NULL,
	[Work_From_WebManager_Realname] [nvarchar](50) NULL,
	[Work_To_WebManager_Name] [nvarchar](50) NULL,
	[Work_To_WebManager_Realname] [nvarchar](50) NULL,
	[Transfer_Type] [int] NULL CONSTRAINT [DF_Work_Transfer_Transfer_Type]  DEFAULT ((0)),
	[Status] [int] NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_Work_Transfer_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Work_Transfer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[WebSite_PageUrl]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WebSite_PageUrl](
	[PageUrl] [varchar](200) NOT NULL,
	[WebManager_Name] [varchar](1000) NULL,
	[WebManager_RealName] [nvarchar](1000) NULL,
	[WebManager_Name_Depend] [varchar](1000) NULL,
	[WebManager_RealName_Depend] [nvarchar](1000) NULL,
	[WebManager_Name_Like] [varchar](1000) NULL,
	[WebManager_RealName_Like] [nvarchar](1000) NULL,
	[IsMy_CreateTime] [varchar](1000) NULL,
	[Analysis] [int] NULL CONSTRAINT [DF_WebSite_PageUrl_Analysis]  DEFAULT ((0)),
	[querystring] [nvarchar](max) NULL,
	[form] [nvarchar](max) NULL,
	[Depend_PageUrl] [nvarchar](max) NULL,
	[Depend_PageUrl_Out] [nvarchar](max) NULL,
	[querystring_Phone_Encrypt] [int] NULL CONSTRAINT [DF_WebSite_PageUrl_querystring_Phone_Encrypt]  DEFAULT ((1)),
	[form_Phone_Encrypt] [int] NULL CONSTRAINT [DF_WebSite_PageUrl_form_Phone_Encrypt]  DEFAULT ((1)),
	[ErrorTime] [datetime] NULL,
	[ErrorInfo] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_WebSite_PageUrl_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_WebSite_PageUrl] PRIMARY KEY CLUSTERED 
(
	[PageUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[WebSite_My_PageUrl_Ignore]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WebSite_My_PageUrl_Ignore](
	[WebManager_name] [varchar](50) NOT NULL,
	[PageUrl] [varchar](500) NOT NULL,
	[PageUrl_Regex] [varchar](500) NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_WebSite_My_PageUrl_Ignore] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[PageUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[WebSite_My_PageUrl]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WebSite_My_PageUrl](
	[WebManager_name] [varchar](50) NOT NULL,
	[PageUrl] [varchar](500) NOT NULL,
	[querystring] [nvarchar](4000) NULL,
	[form] [nvarchar](4000) NULL,
	[PageUrl_Regex] [varchar](500) NULL,
	[CreateTime] [datetime] NULL,
	[Encrypt_Request] [int] NULL CONSTRAINT [DF_WebSite_My_PageUrl_Encrypt_QueryString]  DEFAULT ((0)),
	[Encrypt_Request_Audit] [int] NULL,
	[querystring_Phone_Encrypt] [int] NULL CONSTRAINT [DF_WebSite_My_PageUrl_querystring_Phone_Encrypt]  DEFAULT ((1)),
	[form_Phone_Encrypt] [int] NULL CONSTRAINT [DF_WebSite_My_PageUrl_querystring_Phone_Encrypt1]  DEFAULT ((1)),
 CONSTRAINT [PK_WebSite_My_PageUrl] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[PageUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[WebSite_My_Domain]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WebSite_My_Domain](
	[WebManager_name] [varchar](50) NOT NULL,
	[Domain_Name] [varchar](100) NOT NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_WebSite_My_Domain_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_WebSite_My_Domain] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[Domain_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[WebSite_Depend]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WebSite_Depend](
	[PageUrl] [varchar](200) NOT NULL,
	[Depend_PageUrl] [varchar](200) NOT NULL,
	[Stats_Date] [datetime] NOT NULL,
	[Depend_TimeOut] [bigint] NOT NULL,
	[PageUrl_Regex] [varchar](200) NULL,
	[PageUrl_Detail] [nvarchar](4000) NULL,
	[Depend_PageUrl_Regex] [varchar](200) NULL,
	[Depend_PageUrl_Detail] [nvarchar](4000) NULL,
	[Depend_Content] [nvarchar](max) NULL,
	[Depend_ContentType] [varchar](100) NULL,
	[Depend_ContentType_Error] [int] NULL,
	[Depend_ContentLength] [int] NULL,
	[Depend_Count] [int] NULL,
	[Depend_Count_Error] [int] NULL,
	[Depend_Error_Rate] [float] NULL,
	[Depend_Count_TimeOut] [int] NULL,
	[Depend_TimeOut_Rate] [float] NULL,
	[Depend_TimeSpan_Sum] [bigint] NULL,
	[Depend_TimeSpan_Max] [int] NULL,
	[Depend_TimeSpan_Min] [int] NULL,
	[Depend_TimeSpan_New] [int] NULL,
	[Depend_TimeSpan_Average] [int] NULL,
	[Depend_CreateTime] [datetime] NULL,
 CONSTRAINT [PK_WebSite_Depend] PRIMARY KEY CLUSTERED 
(
	[PageUrl] ASC,
	[Depend_PageUrl] ASC,
	[Stats_Date] ASC,
	[Depend_TimeOut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[TuanTaskAutoRun_Log]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TuanTaskAutoRun_Log](
	[LogID] [bigint] IDENTITY(1,1) NOT NULL,
	[DataBase_Name] [nvarchar](50) NULL,
	[ID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_TuanTaskAutoRun_Log_CreateTime]  DEFAULT (getdate()),
	[WebManager_realname] [nvarchar](50) NULL,
	[Remark] [nvarchar](4000) NULL,
 CONSTRAINT [PK_TuanTaskAutoRun_Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TuanTaskAutoRun]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TuanTaskAutoRun](
	[createdate] [datetime] NOT NULL,
	[DataBase_Name] [nvarchar](50) NOT NULL,
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NULL,
	[Path] [nvarchar](150) NULL,
	[RunType] [int] NULL,
	[runMiniteOf] [decimal](18, 1) NULL,
	[runTimeAt] [time](7) NULL,
	[Author] [nvarchar](150) NULL,
	[LastRunTime] [datetime] NULL,
	[isOpen] [int] NULL,
	[TaskDetail] [varchar](500) NULL,
	[isRunning] [bit] NULL,
	[SvnSourcecode] [nvarchar](500) NULL,
	[CreateTime] [datetime] NULL,
	[KillApp] [int] NULL,
	[logtxt] [nvarchar](max) NULL,
	[logcount] [int] NULL,
	[loglength] [bigint] NULL,
	[config] [nvarchar](max) NULL,
	[cfgfiles] [nvarchar](max) NULL,
	[testDb] [int] NULL,
	[testDb_remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_TuanTaskAutoRun] PRIMARY KEY CLUSTERED 
(
	[createdate] ASC,
	[DataBase_Name] ASC,
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Task]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Task](
	[Task_PageUrl_Or_Sql_Md5] [varchar](200) NOT NULL,
	[Task_Type] [int] NULL CONSTRAINT [DF_Task_Task_Type]  DEFAULT ((0)),
	[Task_Date] [datetime] NULL,
	[Task_Finished] [int] NULL CONSTRAINT [DF_Task_Task_Finished]  DEFAULT ((0)),
	[Task_Finished_Time] [datetime] NULL,
	[Task_WebManager_name] [nvarchar](50) NULL,
	[Task_WebManager_name_Finished] [nvarchar](50) NULL,
	[Task_CreateTime] [datetime] NULL CONSTRAINT [DF_Task_Task_CreateTime]  DEFAULT (getdate()),
	[Task_Remark] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Task_PageUrl_Or_Sql_Md5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SVN_Log_LastUpdate]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SVN_Log_LastUpdate](
	[Commit_File] [nvarchar](400) NOT NULL,
	[Revision] [bigint] NOT NULL,
	[WebManager_Name] [nvarchar](50) NOT NULL,
	[Commit_Server] [varchar](50) NOT NULL CONSTRAINT [DF_SVN_Log_LastUpdate_Commit_Server]  DEFAULT ('svn://192.168.5.215:2002'),
	[Commit_Type] [int] NOT NULL,
	[Commit_File_Md5] [nvarchar](100) NOT NULL,
	[Commit_Time] [datetime] NULL,
	[Commit_Message] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_SVN_Log_LastUpdate_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_SVN_Log_LastUpdate] PRIMARY KEY CLUSTERED 
(
	[Commit_File] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SVN_Log]    Script Date: 2018/11/30 9:55:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SVN_Log](
	[Revision] [bigint] NOT NULL,
	[WebManager_Name] [nvarchar](50) NOT NULL,
	[Commit_Server] [varchar](50) NOT NULL CONSTRAINT [DF_SVN_Log_Commit_Server]  DEFAULT ('svn://192.168.5.215:2002'),
	[Commit_Type] [int] NOT NULL,
	[Commit_File_Md5] [nvarchar](100) NOT NULL,
	[Commit_File] [nvarchar](500) NULL,
	[Commit_Time] [datetime] NULL,
	[Commit_Message] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_SVN_Log_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_SVN_Log] PRIMARY KEY CLUSTERED 
(
	[Revision] ASC,
	[WebManager_Name] ASC,
	[Commit_Server] ASC,
	[Commit_Type] ASC,
	[Commit_File_Md5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Share_View]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Share_View](
	[View_WebManager_name] [nvarchar](50) NOT NULL,
	[View_Time] [datetime] NOT NULL,
	[View_Article_Id] [bigint] NOT NULL,
	[View_Bg_No] [int] NOT NULL CONSTRAINT [DF_Share_View_View_Bg_No]  DEFAULT ((1)),
	[CreateTime] [datetime] NULL CONSTRAINT [DF_Share_View_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Share_View] PRIMARY KEY CLUSTERED 
(
	[View_WebManager_name] ASC,
	[View_Time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Share_Invite]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Share_Invite](
	[Invite_Date] [datetime] NOT NULL,
	[Invite_WebManager_name] [nvarchar](50) NULL,
	[Invite_CreateTime] [datetime] NULL CONSTRAINT [DF_Share_Invite_Invite_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Share_Invite] PRIMARY KEY CLUSTERED 
(
	[Invite_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Share_Article_Good]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Share_Article_Good](
	[Article_Id] [bigint] NOT NULL,
	[WebManager_name] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Share_Article_Good] PRIMARY KEY CLUSTERED 
(
	[Article_Id] ASC,
	[WebManager_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Share_Article]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Share_Article](
	[Article_id] [bigint] IDENTITY(1,1) NOT NULL,
	[Article_type] [int] NULL CONSTRAINT [DF_Share_Article_share_type]  DEFAULT ((0)),
	[Article_Share_WebManager_name] [nvarchar](50) NULL CONSTRAINT [DF_Share_Article_Article_Share_WebManager_name]  DEFAULT (N'lushijun'),
	[Article_Title] [nvarchar](50) NULL,
	[Article_text] [ntext] NULL,
	[Article_createtime] [datetime] NULL CONSTRAINT [DF_Share_Article_createtime]  DEFAULT (getdate()),
	[Article_good] [int] NULL CONSTRAINT [DF_Share_Article_good]  DEFAULT ((0)),
	[Article_viewcount] [int] NULL CONSTRAINT [DF_Share_Article_viewcount]  DEFAULT ((0)),
	[Article_deleted] [int] NULL CONSTRAINT [DF_Share_Article_Article_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Share_Article] PRIMARY KEY CLUSTERED 
(
	[Article_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Server_Update_Password]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Server_Update_Password](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[servername] [nvarchar](100) NULL,
	[create_ip] [nvarchar](100) NULL,
	[create_username] [nvarchar](100) NULL,
	[create_password] [nvarchar](100) NULL,
	[create_time] [datetime] NULL CONSTRAINT [DF_WebSite_Update_Password_create_time]  DEFAULT (getdate()),
	[decrypt_ip] [nvarchar](100) NULL,
	[decrypt_username] [nvarchar](100) NULL,
	[decrypt_password] [nvarchar](100) NULL,
	[decrypt_time] [datetime] NULL,
	[decrypt_status] [int] NULL CONSTRAINT [DF_Server_Update_Password_decrypt_status]  DEFAULT ((0)),
	[decrypt_remark] [nvarchar](4000) NULL,
	[SendEmail] [int] NULL CONSTRAINT [DF_Server_Update_Password_SendEmail]  DEFAULT ((0)),
 CONSTRAINT [PK_WebSite_Update_Password] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Server_Update_Log]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Server_Update_Log](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ip] [varchar](100) NULL,
	[username] [varchar](100) NULL,
	[servername] [varchar](100) NULL,
	[createtime] [datetime] NULL CONSTRAINT [DF_channel_website_update_log_createtime]  DEFAULT (getdate()),
 CONSTRAINT [PK_channel_website_update_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Memcache_Stats]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Memcache_Stats](
	[Memcache_IP] [varchar](20) NOT NULL,
	[Memcache_Port] [int] NOT NULL,
	[Stats_Date] [datetime] NOT NULL,
	[Status] [int] NULL,
	[WebSite] [varchar](1000) NULL,
	[CreateTime] [datetime] NULL,
	[Memcache_Local_IP] [varchar](100) NULL,
	[Error_Key] [varchar](200) NULL,
	[Error] [varchar](max) NULL,
	[pid] [int] NULL,
	[uptime] [bigint] NULL,
	[time] [bigint] NULL,
	[version] [varchar](50) NULL,
	[libevent] [varchar](50) NULL,
	[pointer_size] [bigint] NULL,
	[rusage_user] [float] NULL,
	[rusage_system] [float] NULL,
	[curr_connections] [bigint] NULL,
	[total_connections] [bigint] NULL,
	[connection_structures] [bigint] NULL,
	[reserved_fds] [bigint] NULL,
	[cmd_get] [bigint] NULL,
	[cmd_set] [bigint] NULL,
	[cmd_flush] [bigint] NULL,
	[cmd_touch] [bigint] NULL,
	[get_hits] [bigint] NULL,
	[get_misses] [bigint] NULL,
	[delete_misses] [bigint] NULL,
	[delete_hits] [bigint] NULL,
	[incr_misses] [bigint] NULL,
	[incr_hits] [bigint] NULL,
	[decr_misses] [bigint] NULL,
	[decr_hits] [bigint] NULL,
	[cas_misses] [bigint] NULL,
	[cas_hits] [bigint] NULL,
	[cas_badval] [bigint] NULL,
	[touch_hits] [bigint] NULL,
	[touch_misses] [bigint] NULL,
	[auth_cmds] [bigint] NULL,
	[auth_errors] [bigint] NULL,
	[bytes_read] [bigint] NULL,
	[bytes_written] [bigint] NULL,
	[limit_maxbytes] [bigint] NULL,
	[accepting_conns] [bigint] NULL,
	[listen_disabled_num] [bigint] NULL,
	[threads] [bigint] NULL,
	[conn_yields] [bigint] NULL,
	[hash_power_level] [bigint] NULL,
	[hash_bytes] [bigint] NULL,
	[hash_is_expanding] [bigint] NULL,
	[bytes] [bigint] NULL,
	[curr_items] [bigint] NULL,
	[total_items] [bigint] NULL,
	[expired_unfetched] [bigint] NULL,
	[evicted_unfetched] [bigint] NULL,
	[evictions] [bigint] NULL,
	[reclaimed] [bigint] NULL,
	[StatsInfo] [varchar](max) NULL,
 CONSTRAINT [PK_Memcache_Stats] PRIMARY KEY CLUSTERED 
(
	[Memcache_IP] ASC,
	[Memcache_Port] ASC,
	[Stats_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Memcache_Server]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Memcache_Server](
	[Memcache_IP] [varchar](20) NOT NULL,
	[Memcache_Port] [int] NOT NULL,
	[Status] [int] NULL,
	[Memcache_Local_IP] [varchar](100) NULL,
	[Error_Key] [varchar](200) NULL,
	[WebSite] [varchar](1000) NULL,
	[Auth] [varchar](100) NULL,
	[CacheType] [int] NULL CONSTRAINT [DF_Memcache_Server_CacheType]  DEFAULT ((0)),
	[Remark] [nvarchar](100) NULL,
	[ResetTime] [datetime] NULL CONSTRAINT [DF_Memcache_Server_ResetTime]  DEFAULT (((1900)-(1))-(1)),
 CONSTRAINT [PK_Memcache_Server] PRIMARY KEY CLUSTERED 
(
	[Memcache_IP] ASC,
	[Memcache_Port] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Memcache_Hits]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Memcache_Hits](
	[PageUrl] [varchar](200) NOT NULL,
	[FunctionName] [varchar](500) NOT NULL,
	[Stats_Date] [datetime] NOT NULL,
	[ClassName] [varchar](200) NULL,
	[Memcache_IP] [varchar](20) NULL,
	[Memcache_Port] [int] NULL,
	[get_count] [bigint] NULL CONSTRAINT [DF_Memcache_Hits_get_count]  DEFAULT ((0)),
	[get_misses_count] [bigint] NULL CONSTRAINT [DF_Memcache_Hits_get_misses_count]  DEFAULT ((0)),
	[get_hits_count] [bigint] NULL CONSTRAINT [DF_Memcache_Hits_get_hits_count]  DEFAULT ((0)),
	[set_count] [bigint] NULL CONSTRAINT [DF_Memcache_Hits_set_count]  DEFAULT ((0)),
	[set_misses_count] [bigint] NULL CONSTRAINT [DF_Memcache_Hits_set_misses_count]  DEFAULT ((0)),
	[set_hits_count] [bigint] NULL CONSTRAINT [DF_Memcache_Hits_set_hits_count]  DEFAULT ((0)),
	[createtime] [datetime] NULL CONSTRAINT [DF_Memcache_Hits_createtime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Memcache_Hits] PRIMARY KEY CLUSTERED 
(
	[PageUrl] ASC,
	[FunctionName] ASC,
	[Stats_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Log_Stats]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Log_Stats](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[pageurl] [varchar](4000) NULL,
	[PageUrl_Regex] [varchar](500) NULL,
	[querystring] [nvarchar](4000) NULL,
	[form] [nvarchar](4000) NULL,
	[querystring_Phone_Encrypt] [int] NULL,
	[form_Phone_Encrypt] [int] NULL,
	[log_type] [int] NULL,
	[log_date] [datetime] NULL,
	[log_count] [int] NULL,
	[createtime] [datetime] NULL,
	[teamname] [varchar](50) NULL,
	[ReMarks] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Error_CreateTime] [datetime] NULL,
	[Title] [nvarchar](500) NULL,
	[IP] [nvarchar](100) NULL,
	[username] [nvarchar](50) NULL,
	[classname] [nvarchar](50) NULL,
	[MethodName] [nvarchar](50) NULL,
	[loglevel] [int] NULL,
 CONSTRAINT [PK_Log_Stats] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Log_Error]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Log_Error](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[LogLevel] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[IP] [nvarchar](100) NULL,
	[UserName] [nvarchar](50) NULL,
	[ReMarks] [nvarchar](max) NULL,
	[ClassName] [nvarchar](50) NULL,
	[MethodName] [nvarchar](50) NULL,
	[pageurl] [varchar](500) NULL,
	[PageUrl_Regex] [varchar](500) NULL,
	[teamname] [varchar](50) NULL,
	[servername] [varchar](100) NULL,
	[send_email] [int] NULL,
	[send_WebManager_name] [nvarchar](200) NULL,
	[send_email_time] [datetime] NULL,
 CONSTRAINT [PK_Log_Error] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Log_Business]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Log_Business](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[LogLevel] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[IP] [nvarchar](100) NULL,
	[UserName] [nvarchar](50) NULL,
	[ReMarks] [nvarchar](max) NULL,
	[ClassName] [nvarchar](50) NULL,
	[MethodName] [nvarchar](50) NULL,
	[pageurl] [varchar](500) NULL,
	[teamname] [varchar](50) NULL,
	[servername] [varchar](100) NULL,
	[PageUrl_Regex] [varchar](500) NULL,
	[send_email] [int] NULL,
	[send_WebManager_name] [nvarchar](200) NULL,
	[send_email_time] [datetime] NULL,
 CONSTRAINT [PK_Log_Business] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Job_My]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Job_My](
	[WebManager_name] [varchar](50) NOT NULL,
	[JobName] [varchar](200) NOT NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_Job_My_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Job_My] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[JobName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Job_Log]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Job_Log](
	[job_id] [bigint] IDENTITY(1,1) NOT NULL,
	[DataBase_IP] [varchar](50) NULL,
	[DataBase_Name] [varchar](50) NULL,
	[run_date] [varchar](20) NOT NULL,
	[run_time] [varchar](20) NOT NULL,
	[step_id] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
	[step_name] [nvarchar](100) NULL,
	[message] [nvarchar](4000) NULL,
	[description] [nvarchar](4000) NULL,
	[enabled] [int] NULL,
	[date_created] [datetime] NULL,
	[date_modified] [datetime] NULL,
	[run_status] [int] NULL,
	[run_duration] [int] NULL,
 CONSTRAINT [PK_job_log] PRIMARY KEY CLUSTERED 
(
	[job_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[EC_User_UserInfo_OA_Staff0]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EC_User_UserInfo_OA_Staff0](
	[ID] [nvarchar](255) NULL,
	[����] [nvarchar](255) NULL,
	[����] [nvarchar](255) NULL,
	[����] [nvarchar](255) NULL,
	[���֤] [nvarchar](255) NULL,
	[��ע] [nvarchar](255) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[EC_User_UserInfo_OA_Staff]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EC_User_UserInfo_OA_Staff](
	[id] [bigint] NOT NULL,
	[createdate] [datetime] NOT NULL,
	[hr_num] [bigint] NOT NULL,
	[lastname] [nvarchar](100) NULL,
	[applogourl] [varchar](500) NULL,
	[managerid] [bigint] NULL,
	[subid] [bigint] NULL,
	[depid] [bigint] NULL,
	[labour] [int] NULL,
	[performstandard] [int] NULL,
	[performstandardname] [nvarchar](100) NULL,
	[servicetype] [int] NULL,
	[servicetypename] [nvarchar](100) NULL,
	[dictcityname] [nvarchar](50) NULL,
	[quitdate] [datetime] NULL,
	[entrydate] [datetime] NULL,
	[workgroupid] [bigint] NULL,
	[jobtitle] [bigint] NULL,
	[jobtitlename] [nvarchar](100) NULL,
	[email] [varchar](100) NULL,
	[certificatenum] [varchar](50) NULL,
	[status] [nvarchar](50) NULL,
	[flag] [int] NULL,
	[createtime] [datetime] NULL,
 CONSTRAINT [PK_EC_User_UserInfo_OA_Staff] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[createdate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_User_Authority]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_User_Authority](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataBase_IP_Romote] [varchar](50) NULL,
	[DataBase_Name] [varchar](50) NULL,
	[uName] [varchar](100) NULL,
	[tName] [varchar](100) NULL,
	[tType] [varchar](50) NULL,
	[tReferences] [int] NULL,
	[tInsert] [int] NULL,
	[tSelect] [int] NULL,
	[tUpdate] [int] NULL,
	[tDelete] [int] NULL,
	[tExecute] [int] NULL,
	[ProtectType] [varchar](50) NULL,
	[ProtectTypeSql] [varchar](1000) NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_DataBase_User_Authority_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_DataBase_User_Authority] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_User]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataBase_IP_Romote] [varchar](50) NULL,
	[DataBase_Name] [varchar](50) NULL,
	[uname] [varchar](100) NULL,
	[uStatus] [int] NULL,
	[rId] [int] NULL,
	[rStatus] [int] NULL,
	[rName] [varchar](100) NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_DataBase_User_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_DataBase_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Table_UpdateLog]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Table_UpdateLog](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[WebManager_name] [varchar](50) NULL,
	[DataBase_IP_Romote] [varchar](50) NULL,
	[DataBase_Name] [varchar](50) NULL,
	[Table_Name] [varchar](50) NULL,
	[Column_Name] [varchar](50) NULL,
	[Description] [nvarchar](4000) NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Table_UpdateLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Table_My]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Table_My](
	[DataBase_Name] [varchar](50) NOT NULL,
	[Table_Name] [varchar](50) NOT NULL,
	[WebManager_name] [varchar](50) NOT NULL,
	[WebManager_realname] [varchar](50) NULL,
	[DataBase_IP_Romote] [varchar](50) NULL,
	[RowCounts] [bigint] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts]  DEFAULT ((0)),
	[RowCounts_Increasing] [bigint] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing]  DEFAULT ((0)),
	[RowCounts_Increasing_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing_Rate]  DEFAULT ((0)),
	[RowCounts_Increasing_Week] [bigint] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing_Week]  DEFAULT ((0)),
	[RowCounts_Increasing_Week_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing_Week_Rate]  DEFAULT ((0)),
	[RowCounts_Increasing_Month] [bigint] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing_Month]  DEFAULT ((0)),
	[RowCounts_Increasing_Month_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing_Month_Rate]  DEFAULT ((0)),
	[RowCounts_Increasing_Year] [bigint] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing_Year]  DEFAULT ((0)),
	[RowCounts_Increasing_Year_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_My_RowCounts_Increasing_Year_Rate]  DEFAULT ((0)),
	[ColumnCounts] [bigint] NULL CONSTRAINT [DF_DataBase_Table_My_ColumnCounts]  DEFAULT ((0)),
	[CreateTime] [datetime] NULL CONSTRAINT [DF_DataBase_Table_My_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_DataBase_Table_My] PRIMARY KEY CLUSTERED 
(
	[DataBase_Name] ASC,
	[Table_Name] ASC,
	[WebManager_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Table_Index]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Table_Index](
	[DataBase_Name] [varchar](50) NOT NULL,
	[Table_Name] [varchar](100) NOT NULL,
	[Index_Name] [varchar](200) NOT NULL,
	[Column_Name] [varchar](100) NOT NULL,
	[Colid] [int] NULL,
	[Like_WebManager_name] [nvarchar](500) NULL,
	[Like_WebManager_realname] [nvarchar](500) NULL,
	[WebManager_name] [nvarchar](500) NULL,
	[WebManager_realname] [nvarchar](500) NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Table_Index] PRIMARY KEY CLUSTERED 
(
	[DataBase_Name] ASC,
	[Table_Name] ASC,
	[Index_Name] ASC,
	[Column_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Table_Column]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Table_Column](
	[DataBase_Name] [varchar](50) NOT NULL,
	[Table_Name] [varchar](50) NOT NULL,
	[Column_Name] [varchar](50) NOT NULL,
	[Like_WebManager_name] [nvarchar](500) NULL,
	[Like_WebManager_realname] [nvarchar](500) NULL,
	[WebManager_name] [nvarchar](500) NULL,
	[WebManager_realname] [nvarchar](500) NULL,
	[Column_Type] [varchar](50) NULL,
	[Column_Length] [int] NULL,
	[Column_Is_PrimaryKey] [int] NULL,
	[Column_Null] [int] NULL,
	[Column_Identity] [int] NULL,
	[Column_DefaultValue] [varchar](50) NULL,
	[Column_Description] [varchar](max) NULL,
 CONSTRAINT [PK_DataBase_Table_Column] PRIMARY KEY CLUSTERED 
(
	[DataBase_Name] ASC,
	[Table_Name] ASC,
	[Column_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Table]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Table](
	[DataBase_Name] [varchar](50) NOT NULL,
	[Table_Name] [varchar](50) NOT NULL,
	[CountDate] [datetime] NOT NULL,
	[Like_WebManager_name] [nvarchar](500) NULL,
	[Like_WebManager_realname] [nvarchar](500) NULL,
	[DataBase_IP_Romote] [varchar](50) NULL,
	[RowCounts] [bigint] NULL CONSTRAINT [DF_DataBase_Table_RowCounts]  DEFAULT ((0)),
	[RowCounts_Increasing] [bigint] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing]  DEFAULT ((0)),
	[RowCounts_Increasing_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing_Rate]  DEFAULT ((0)),
	[RowCounts_Increasing_Week] [bigint] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing_Week]  DEFAULT ((0)),
	[RowCounts_Increasing_Week_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing_Week_Rate]  DEFAULT ((0)),
	[RowCounts_Increasing_Month] [bigint] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing_Month]  DEFAULT ((0)),
	[RowCounts_Increasing_Month_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing_Month_Rate]  DEFAULT ((0)),
	[RowCounts_Increasing_Year] [bigint] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing_Year]  DEFAULT ((0)),
	[RowCounts_Increasing_Year_Rate] [float] NULL CONSTRAINT [DF_DataBase_Table_RowCounts_Increasing_Year_Rate]  DEFAULT ((0)),
	[ColumnCounts] [bigint] NULL CONSTRAINT [DF_DataBase_Table_ColumnCounts]  DEFAULT ((0)),
	[CreateTime] [datetime] NULL CONSTRAINT [DF_DataBase_Table_CreateTime]  DEFAULT (getdate()),
	[Space_Allocation] [bigint] NULL,
	[Space_Used] [bigint] NULL,
	[Space_Index_Used] [bigint] NULL,
	[Space_Available] [bigint] NULL,
 CONSTRAINT [PK_DataBase_Table] PRIMARY KEY CLUSTERED 
(
	[DataBase_Name] ASC,
	[Table_Name] ASC,
	[CountDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_Sync]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_Sync](
	[DataBase_Remote_Ip] [varchar](50) NOT NULL,
	[Sync_date] [datetime] NOT NULL,
	[Sync_count] [int] NULL,
 CONSTRAINT [PK_DataBase_Sql_Sync] PRIMARY KEY CLUSTERED 
(
	[DataBase_Remote_Ip] ASC,
	[Sync_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_Stats]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_Stats](
	[Stats_Date] [datetime] NOT NULL,
	[Sql_Md5] [varchar](50) NOT NULL,
	[Source_Md5] [varchar](50) NULL,
	[seemlike_WebManager_name] [nvarchar](50) NULL,
	[seemlike_WebManager_realname] [nvarchar](50) NULL,
	[sql_error] [nvarchar](1000) NULL,
	[IsWriteSql] [int] NULL,
	[IsRuntimeSql] [int] NULL,
	[IsWrongDataBaseUser] [int] NULL,
	[Lack_With_NoLock_Count] [int] NULL,
	[Select_All_Count] [int] NULL,
	[Like_Count] [int] NULL,
	[Lack_Parameter_Count] [int] NULL,
	[Count_All] [int] NULL,
	[sql_handle] [varbinary](64) NULL,
	[DataBase_IP] [varchar](50) NULL,
	[DataBase_User] [varchar](100) NULL,
	[database_name] [varchar](50) NULL,
	[Table_Name] [varchar](50) NULL,
	[statement_text] [varchar](max) NULL,
	[text] [varchar](max) NULL,
	[text_analysis] [varchar](max) NULL,
	[analysis] [int] NULL,
	[creation_time] [datetime] NULL,
	[last_execution_time] [datetime] NULL,
	[execution_count] [bigint] NULL,
	[total_worker_time] [bigint] NULL,
	[last_worker_time] [bigint] NULL,
	[min_worker_time] [bigint] NULL,
	[max_worker_time] [bigint] NULL,
	[total_physical_reads] [bigint] NULL,
	[last_physical_reads] [bigint] NULL,
	[min_physical_reads] [bigint] NULL,
	[max_physical_reads] [bigint] NULL,
	[total_logical_writes] [bigint] NULL,
	[last_logical_writes] [bigint] NULL,
	[min_logical_writes] [bigint] NULL,
	[max_logical_writes] [bigint] NULL,
	[total_logical_reads] [bigint] NULL,
	[last_logical_reads] [bigint] NULL,
	[min_logical_reads] [bigint] NULL,
	[max_logical_reads] [bigint] NULL,
	[total_elapsed_time] [bigint] NULL,
	[last_elapsed_time] [bigint] NULL,
	[min_elapsed_time] [bigint] NULL,
	[max_elapsed_time] [bigint] NULL,
	[total_rows] [bigint] NULL,
	[last_rows] [bigint] NULL,
	[min_rows] [bigint] NULL,
	[max_rows] [bigint] NULL,
	[createtime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Sql_Stats_1] PRIMARY KEY CLUSTERED 
(
	[Stats_Date] ASC,
	[Sql_Md5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_SendEmail_WrongDataBaseUser]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_SendEmail_WrongDataBaseUser](
	[WebManager_name] [varchar](50) NOT NULL,
	[Stats_Date] [datetime] NOT NULL,
	[Sql_Md5] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Sql_SendEmail_WrongDataBaseUser] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[Stats_Date] ASC,
	[Sql_Md5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_SendEmail]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_SendEmail](
	[WebManager_name] [varchar](50) NOT NULL,
	[Stats_Date] [datetime] NOT NULL,
	[Sql_Md5] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Sql_SendEmail] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[Stats_Date] ASC,
	[Sql_Md5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_My_Ignore]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_My_Ignore](
	[WebManager_name] [varchar](50) NOT NULL,
	[Sql_Md5] [varchar](50) NOT NULL,
	[Source_Md5] [varchar](50) NULL,
	[Sql_error] [nvarchar](1000) NULL,
	[TEXT_ANALYSIS] [varchar](max) NULL,
	[DataBase_IP] [varchar](50) NULL,
	[DataBase_User] [varchar](100) NULL,
	[database_name] [varchar](50) NULL,
	[Table_Name] [varchar](50) NULL,
	[creation_time] [datetime] NULL,
	[last_execution_time] [datetime] NULL,
	[execution_count] [bigint] NULL,
	[total_worker_time] [bigint] NULL,
	[last_worker_time] [bigint] NULL,
	[min_worker_time] [bigint] NULL,
	[max_worker_time] [bigint] NULL,
	[total_physical_reads] [bigint] NULL,
	[last_physical_reads] [bigint] NULL,
	[min_physical_reads] [bigint] NULL,
	[max_physical_reads] [bigint] NULL,
	[total_logical_writes] [bigint] NULL,
	[last_logical_writes] [bigint] NULL,
	[min_logical_writes] [bigint] NULL,
	[max_logical_writes] [bigint] NULL,
	[total_logical_reads] [bigint] NULL,
	[last_logical_reads] [bigint] NULL,
	[min_logical_reads] [bigint] NULL,
	[max_logical_reads] [bigint] NULL,
	[total_elapsed_time] [bigint] NULL,
	[last_elapsed_time] [bigint] NULL,
	[min_elapsed_time] [bigint] NULL,
	[max_elapsed_time] [bigint] NULL,
	[total_rows] [bigint] NULL,
	[last_rows] [bigint] NULL,
	[min_rows] [bigint] NULL,
	[max_rows] [bigint] NULL,
	[CreateTime] [datetime] NULL CONSTRAINT [DF_DataBase_Sql_My_Ignore_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_DataBase_Sql_My_Ignore] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[Sql_Md5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_My]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_My](
	[WebManager_name] [varchar](50) NOT NULL,
	[Sql_Md5] [varchar](50) NOT NULL,
	[Source_Md5] [varchar](50) NULL,
	[Sql_error] [nvarchar](1000) NULL,
	[IsWriteSql] [int] NULL,
	[IsRuntimeSql] [int] NULL,
	[IsWrongDataBaseUser] [int] NULL,
	[Lack_With_NoLock_Count] [int] NULL,
	[Select_All_Count] [int] NULL,
	[Like_Count] [int] NULL,
	[Lack_Parameter_Count] [int] NULL,
	[Count_All] [int] NULL,
	[TEXT_ANALYSIS] [varchar](max) NULL,
	[DataBase_IP] [varchar](50) NULL,
	[DataBase_User] [varchar](100) NULL,
	[database_name] [varchar](50) NULL,
	[Table_Name] [varchar](50) NULL,
	[creation_time] [datetime] NULL,
	[last_execution_time] [datetime] NULL,
	[execution_count] [bigint] NULL,
	[total_worker_time] [bigint] NULL,
	[last_worker_time] [bigint] NULL,
	[min_worker_time] [bigint] NULL,
	[max_worker_time] [bigint] NULL,
	[total_physical_reads] [bigint] NULL,
	[last_physical_reads] [bigint] NULL,
	[min_physical_reads] [bigint] NULL,
	[max_physical_reads] [bigint] NULL,
	[total_logical_writes] [bigint] NULL,
	[last_logical_writes] [bigint] NULL,
	[min_logical_writes] [bigint] NULL,
	[max_logical_writes] [bigint] NULL,
	[total_logical_reads] [bigint] NULL,
	[last_logical_reads] [bigint] NULL,
	[min_logical_reads] [bigint] NULL,
	[max_logical_reads] [bigint] NULL,
	[total_elapsed_time] [bigint] NULL,
	[last_elapsed_time] [bigint] NULL,
	[min_elapsed_time] [bigint] NULL,
	[max_elapsed_time] [bigint] NULL,
	[total_rows] [bigint] NULL,
	[last_rows] [bigint] NULL,
	[min_rows] [bigint] NULL,
	[max_rows] [bigint] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Sql_My] PRIMARY KEY CLUSTERED 
(
	[WebManager_name] ASC,
	[Sql_Md5] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_Connect_Stats]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_Connect_Stats](
	[PageUrl] [varchar](500) NOT NULL,
	[Stats_Date] [datetime] NOT NULL,
	[querystring] [nvarchar](4000) NULL,
	[form] [nvarchar](4000) NULL,
	[LastConnectTime] [datetime] NULL,
	[Request_Count] [bigint] NULL,
	[Duration_Sum] [bigint] NULL,
	[Duration_Avg] [bigint] NULL,
	[Duration_Max] [bigint] NULL,
	[Duration_Min] [bigint] NULL,
	[Connect_Times_Sum] [bigint] NULL,
	[Connect_Times_Avg] [bigint] NULL,
	[Connect_Times_Max] [bigint] NULL,
	[Connect_Times_Min] [bigint] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Sql_Connect_Stats] PRIMARY KEY CLUSTERED 
(
	[PageUrl] ASC,
	[Stats_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql_Connect_Log]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Sql_Connect_Log](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PageUrlOrFunction] [varchar](1000) NULL,
	[querystring] [nvarchar](max) NULL,
	[form] [nvarchar](max) NULL,
	[SessionId] [varchar](200) NULL,
	[Sql_Md5] [varchar](100) NULL,
	[DataBase_Ip] [varchar](100) NULL,
	[DataBase_Name] [varchar](100) NULL,
	[DataBase_User] [varchar](100) NULL,
	[ServerInfo] [varchar](200) NULL,
	[ExecutionTime] [datetime] NULL,
	[ExecutionTime_End] [datetime] NULL,
	[Duration] [bigint] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Sql_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Sql]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[DataBase_Sql](
	[id] [bigint] NOT NULL,
	[sql_handle] [varbinary](64) NULL,
	[DataBase_IP] [varchar](50) NULL,
	[DataBase_User] [varchar](100) NULL,
	[database_name] [varchar](50) NULL,
	[Table_Name] [varchar](50) NULL,
	[statement_text] [varchar](max) NULL,
	[text] [varchar](max) NULL,
	[Sql_Md5] [varchar](50) NULL,
	[creation_time] [datetime] NULL,
	[last_execution_time] [datetime] NULL,
	[execution_count] [bigint] NULL,
	[total_worker_time] [bigint] NULL,
	[last_worker_time] [bigint] NULL,
	[min_worker_time] [bigint] NULL,
	[max_worker_time] [bigint] NULL,
	[total_physical_reads] [bigint] NULL,
	[last_physical_reads] [bigint] NULL,
	[min_physical_reads] [bigint] NULL,
	[max_physical_reads] [bigint] NULL,
	[total_logical_writes] [bigint] NULL,
	[last_logical_writes] [bigint] NULL,
	[min_logical_writes] [bigint] NULL,
	[max_logical_writes] [bigint] NULL,
	[total_logical_reads] [bigint] NULL,
	[last_logical_reads] [bigint] NULL,
	[min_logical_reads] [bigint] NULL,
	[max_logical_reads] [bigint] NULL,
	[total_elapsed_time] [bigint] NULL,
	[last_elapsed_time] [bigint] NULL,
	[min_elapsed_time] [bigint] NULL,
	[max_elapsed_time] [bigint] NULL,
	[total_rows] [bigint] NULL,
	[last_rows] [bigint] NULL,
	[min_rows] [bigint] NULL,
	[max_rows] [bigint] NULL,
	[createtime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Sql] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Owner]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Owner](
	[DataBase_Id] [int] NOT NULL,
	[DataBase_IP_Local] [varchar](50) NULL,
	[DataBase_IP_Romote] [varchar](50) NULL,
	[DataBase_VIP_Local] [varchar](50) NULL,
	[DataBase_VIP_Romote] [varchar](50) NULL,
	[DataBase_IP_Special] [varchar](50) NULL,
	[DataBase_IP_Recovery] [varchar](50) NULL,
	[DataBase_Name] [varchar](50) NULL,
	[DataBase_Remark] [nvarchar](500) NULL,
	[DataBase_Admin_User] [varchar](100) NULL,
	[DataBase_Admin_PassWord] [varchar](100) NULL,
	[DataBase_Reader_User] [varchar](100) NULL,
	[DataBase_Reader_PassWord] [varchar](100) NULL,
	[DataBase_Writer_User] [varchar](100) NULL,
	[DataBase_Writer_PassWord] [varchar](100) NULL,
	[DataBase_Table_Description] [nvarchar](max) NULL,
	[DataBase_Is_Main] [int] NULL CONSTRAINT [DF_DataBase_Owner_DataBase_isMain]  DEFAULT ((0)),
	[Last_Update_Time] [datetime] NULL CONSTRAINT [DF_DataBase_Owner_Last_Update_Time]  DEFAULT (getdate()),
	[DataBase_PROC_VIEW_FUNCTION_Bak1] [varchar](max) NULL,
	[DataBase_PROC_VIEW_FUNCTION_Bak2] [varchar](max) NULL,
	[DataBase_PROC_VIEW_FUNCTION_Bak3] [varchar](max) NULL,
	[Space_Used] [bigint] NULL CONSTRAINT [DF_DataBase_Owner_Space_Used]  DEFAULT ((0)),
 CONSTRAINT [PK_DataBase] PRIMARY KEY CLUSTERED 
(
	[DataBase_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Missing_Index]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Missing_Index](
	[DataBase_IP_Romote] [varchar](50) NOT NULL,
	[DataBase_Name] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[index_handle] [bigint] NOT NULL,
	[group_handle] [bigint] NOT NULL,
	[Table_Name] [varchar](100) NULL,
	[equality_columns] [varchar](2000) NULL,
	[inequality_columns] [varchar](2000) NULL,
	[included_columns] [varchar](max) NULL,
	[statement] [varchar](100) NULL,
	[unique_compiles] [bigint] NULL,
	[user_seeks] [bigint] NULL,
	[user_scans] [bigint] NULL,
	[last_user_seek] [datetime] NULL,
	[last_user_scan] [datetime] NULL,
	[avg_total_user_cost] [float] NULL,
	[avg_user_impact] [float] NULL,
	[system_seeks] [bigint] NULL,
	[system_scans] [bigint] NULL,
	[last_system_seek] [datetime] NULL,
	[last_system_scan] [datetime] NULL,
	[avg_total_system_cost] [bigint] NULL,
	[avg_system_impact] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[Total_Cost] [bigint] NULL,
 CONSTRAINT [PK_DataBase_Missing_Index] PRIMARY KEY CLUSTERED 
(
	[DataBase_IP_Romote] ASC,
	[DataBase_Name] ASC,
	[Date] ASC,
	[index_handle] ASC,
	[group_handle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[DataBase_Alter]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DataBase_Alter](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DataBase_IP] [varchar](50) NULL,
	[DataBase_Name] [varchar](50) NULL,
	[WebManager_Name] [nvarchar](50) NULL,
	[Alter_Sql] [varchar](max) NULL,
	[Alter_Status] [int] NULL,
	[Alter_Remark] [nvarchar](1000) NULL,
	[Alter_Problem] [varchar](max) NULL,
	[Alter_Time] [datetime] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_DataBase_Alter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Bill_Receive]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bill_Receive](
	[Bill_Receive_year] [int] NOT NULL,
	[Bill_Receive_month] [int] NOT NULL,
	[Bill_Receive_leader_realname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bill_Receive] PRIMARY KEY CLUSTERED 
(
	[Bill_Receive_year] ASC,
	[Bill_Receive_month] ASC,
	[Bill_Receive_leader_realname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Bill_Lock]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bill_Lock](
	[Bill_Lock_year] [int] NOT NULL,
	[Bill_Lock_month] [int] NOT NULL,
	[Bill_Lock_leader_realname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bill_Lock] PRIMARY KEY CLUSTERED 
(
	[Bill_Lock_year] ASC,
	[Bill_Lock_month] ASC,
	[Bill_Lock_leader_realname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Bill]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bill](
	[bill_WebManager_name] [nvarchar](50) NOT NULL,
	[bill_date] [datetime] NOT NULL,
	[bill_WebManager_realname] [nvarchar](50) NOT NULL,
	[bill_year] [int] NULL,
	[bill_month] [int] NULL,
	[bill_leader_realname] [nvarchar](50) NULL,
	[bill_reason] [nvarchar](500) NULL,
	[bill_staff_worker] [nvarchar](500) NULL,
	[bill_total_money] [int] NULL,
	[bill_lock] [int] NULL,
	[bill_CreateTime] [datetime] NULL CONSTRAINT [DF_Bill_bill_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[bill_WebManager_name] ASC,
	[bill_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Apply]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Apply](
	[Apply_WebManager_name] [nvarchar](50) NOT NULL,
	[Apply_year] [int] NOT NULL,
	[Apply_month] [int] NOT NULL,
	[Apply_WebManager_realname] [nvarchar](50) NULL,
	[Apply_pen] [int] NULL CONSTRAINT [DF_Apply_Apply_pen]  DEFAULT ((0)),
	[Apply_penlead] [int] NULL CONSTRAINT [DF_Apply_Apply_penlead]  DEFAULT ((0)),
	[Apply_book] [int] NULL CONSTRAINT [DF_Apply_Apply_book]  DEFAULT ((0)),
	[Apply_glue] [int] NULL CONSTRAINT [DF_Apply_Apply_glue]  DEFAULT ((0)),
	[Apply_notepaper] [int] NULL CONSTRAINT [DF_Apply_Apply_notepaper]  DEFAULT ((0)),
	[Apply_lock] [int] NULL,
	[Apply_Receive] [int] NULL,
	[Apply_CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Apply] PRIMARY KEY CLUSTERED 
(
	[Apply_WebManager_name] ASC,
	[Apply_year] ASC,
	[Apply_month] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Admin_WebManager_Group]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin_WebManager_Group](
	[Group_id] [int] IDENTITY(1,1) NOT NULL,
	[Group_name] [nvarchar](20) NOT NULL,
	[Group_Createtime] [datetime] NULL CONSTRAINT [DF_Admin_group_Group_Createtime]  DEFAULT (getdate()),
	[Group_Remark] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Admin_group] PRIMARY KEY CLUSTERED 
(
	[Group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Admin_WebManager]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Admin_WebManager](
	[WebManager_id] [int] IDENTITY(1,1) NOT NULL,
	[WebManager_Group_id] [int] NOT NULL,
	[WebManager_Product] [varchar](50) NULL,
	[WebManager_IP] [varchar](50) NULL,
	[WebManager_IP_LastLogin] [varchar](50) NULL,
	[WebManager_leader_realname] [nvarchar](50) NULL,
	[WebManager_leader_level] [int] NULL,
	[WebManager_realname] [nvarchar](50) NULL,
	[WebManager_name] [nvarchar](50) NOT NULL,
	[WebManager_PassWord] [nvarchar](50) NULL,
	[WebManager_Email] [varchar](50) NULL,
	[WebManager_Phone] [nvarchar](50) NULL,
	[WebManager_Oicq] [varchar](50) NULL,
	[WebManager_mobile] [nvarchar](50) NULL,
	[WebManager_Last_logintime] [datetime] NULL CONSTRAINT [DF_Admin_WebManager_WebManager_Last_logintime]  DEFAULT (getdate()),
	[WebManager_Createtime] [datetime] NULL CONSTRAINT [DF_Admin_WebManager_WebManager_Createtime]  DEFAULT (getdate()),
	[WebManager_Remark] [nvarchar](2000) NULL,
	[WebManager_Status] [int] NULL CONSTRAINT [DF_Admin_WebManager_WebManager_Status_1]  DEFAULT ((100)),
	[WebManager_Recieve_AlertEmail] [int] NULL CONSTRAINT [DF_Admin_WebManager_WebManager_Recieve_AlertEmail]  DEFAULT ((1)),
	[WebManager_Is_Admin] [int] NULL CONSTRAINT [DF_Admin_WebManager_WebManager_Is_Admin]  DEFAULT ((0)),
 CONSTRAINT [PK_Admin_WebManager] PRIMARY KEY CLUSTERED 
(
	[WebManager_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Admin_Product]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Admin_Product](
	[ProductId] [int] NOT NULL,
	[ProductName] [nvarchar](20) NULL,
	[TablePrefix] [varchar](20) NULL,
	[ManagerEmail] [varchar](200) NULL,
	[ManagerPhone] [varchar](200) NULL,
 CONSTRAINT [PK_Admin_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Admin_Permission]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin_Permission](
	[Permission_Group_id] [int] NOT NULL,
	[Permission_function_id] [int] NOT NULL,
 CONSTRAINT [PK_Admin_Permission] PRIMARY KEY CLUSTERED 
(
	[Permission_Group_id] ASC,
	[Permission_function_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Admin_Module]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin_Module](
	[Module_id] [int] IDENTITY(1,1) NOT NULL,
	[Module_name] [nvarchar](50) NOT NULL,
	[Module_Order] [int] NULL,
	[Module_Remark] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Admin_Module] PRIMARY KEY CLUSTERED 
(
	[Module_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Admin_Log]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin_Log](
	[MallLogID] [int] IDENTITY(1,1) NOT NULL,
	[Product] [int] NULL CONSTRAINT [DF_Admin_Log_Product_1]  DEFAULT ((0)),
	[UserType] [tinyint] NULL CONSTRAINT [DF_MallLog_2010_UserType]  DEFAULT ((0)),
	[UserID] [int] NULL CONSTRAINT [DF_MallLog_2010_UserID]  DEFAULT ((0)),
	[UserName] [nvarchar](500) NULL CONSTRAINT [DF_MallLog_2010_UserName]  DEFAULT (''),
	[RealName] [nvarchar](500) NULL CONSTRAINT [DF_MallLog_2010_RealName]  DEFAULT (''),
	[ItemType] [tinyint] NULL CONSTRAINT [DF_MallLog_2010_ItemType]  DEFAULT ((0)),
	[ItemID] [int] NULL CONSTRAINT [DF_MallLog_2010_ItemID]  DEFAULT ((0)),
	[Description] [nvarchar](4000) NULL CONSTRAINT [DF_MallLog_2010_Description]  DEFAULT (''),
	[IP] [nvarchar](50) NULL CONSTRAINT [DF_MallLog_2010_IP]  DEFAULT (''),
	[AddedTime] [datetime] NULL CONSTRAINT [DF_MallLog_2010_AddedTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_MallLog_2010] PRIMARY KEY CLUSTERED 
(
	[MallLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Admin_Function]    Script Date: 2018/11/30 9:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin_Function](
	[Function_id] [int] IDENTITY(1,1) NOT NULL,
	[Function_name] [nvarchar](20) NOT NULL,
	[Function_url] [nvarchar](200) NULL,
	[Function_Type] [int] NOT NULL,
	[Function_Group_Id] [int] NULL,
	[Function_Module_id] [int] NULL,
	[Function_Order] [int] NULL,
	[Function_Remark] [nvarchar](2000) NULL,
	[Function_View_Count] [int] NULL CONSTRAINT [DF_Admin_Function_Function_View_Count]  DEFAULT ((0)),
 CONSTRAINT [PK_Admin_Function] PRIMARY KEY CLUSTERED 
(
	[Function_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[WebSite_Depend] ADD  CONSTRAINT [DF_WebSite_Depend_Stats_Date]  DEFAULT (CONVERT([varchar](100),getdate(),(23))) FOR [Stats_Date]
GO

ALTER TABLE [dbo].[WebSite_Depend] ADD  CONSTRAINT [DF_WebSite_Depend_Depend_TimeOut_Max]  DEFAULT ((0)) FOR [Depend_TimeOut]
GO

ALTER TABLE [dbo].[TuanTaskAutoRun] ADD  CONSTRAINT [DF__TuanTaskA__isRun__218BE82B]  DEFAULT ((0)) FOR [isRunning]
GO

ALTER TABLE [dbo].[TuanTaskAutoRun] ADD  CONSTRAINT [DF__TuanTaskA__Creat__45C948A1]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[TuanTaskAutoRun] ADD  CONSTRAINT [DF__TuanTaskA__KillA__6CE315C2]  DEFAULT ((0)) FOR [KillApp]
GO

ALTER TABLE [dbo].[TuanTaskAutoRun] ADD  DEFAULT ((0)) FOR [testDb]
GO

ALTER TABLE [dbo].[Log_Stats] ADD  CONSTRAINT [DF_Log_Stats_querystring_Phone_Encrypt]  DEFAULT ((1)) FOR [querystring_Phone_Encrypt]
GO

ALTER TABLE [dbo].[Log_Stats] ADD  CONSTRAINT [DF_Log_Stats_form_Phone_Encrypt]  DEFAULT ((1)) FOR [form_Phone_Encrypt]
GO

ALTER TABLE [dbo].[Log_Stats] ADD  CONSTRAINT [DF_Log_Stats_log_type]  DEFAULT ((0)) FOR [log_type]
GO

ALTER TABLE [dbo].[Log_Stats] ADD  CONSTRAINT [DF_Log_Stats_log_count]  DEFAULT ((0)) FOR [log_count]
GO

ALTER TABLE [dbo].[Log_Stats] ADD  CONSTRAINT [DF_Log_Stats_createtime]  DEFAULT (getdate()) FOR [createtime]
GO

ALTER TABLE [dbo].[Log_Error] ADD  CONSTRAINT [DF_Log_Error_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[Log_Error] ADD  CONSTRAINT [DF_Log_Error_Content]  DEFAULT ('') FOR [Content]
GO

ALTER TABLE [dbo].[Log_Error] ADD  CONSTRAINT [DF_Log_Error_ReMarks]  DEFAULT ('') FOR [ReMarks]
GO

ALTER TABLE [dbo].[Log_Error] ADD  CONSTRAINT [DF_Log_Error_send_email]  DEFAULT ((0)) FOR [send_email]
GO

ALTER TABLE [dbo].[Log_Business] ADD  CONSTRAINT [DF_Log_Business_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[Log_Business] ADD  CONSTRAINT [DF_Log_Business_Content]  DEFAULT ('') FOR [Content]
GO

ALTER TABLE [dbo].[Log_Business] ADD  CONSTRAINT [DF_Log_Business_ReMarks]  DEFAULT ('') FOR [ReMarks]
GO

ALTER TABLE [dbo].[Log_Business] ADD  CONSTRAINT [DF_Log_Business_send_email]  DEFAULT ((0)) FOR [send_email]
GO

ALTER TABLE [dbo].[DataBase_Table_Index] ADD  CONSTRAINT [DF_DataBase_Table_Index_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_Lack_With_NoLock_Count1]  DEFAULT ((0)) FOR [IsWriteSql]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_IsWriteSql1]  DEFAULT ((0)) FOR [IsRuntimeSql]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_IsWrongDataBaseUSer]  DEFAULT ((0)) FOR [IsWrongDataBaseUser]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_Lack_With_NoLock_Count]  DEFAULT ((0)) FOR [Lack_With_NoLock_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_Select_All_Count]  DEFAULT ((0)) FOR [Select_All_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_Like_Count]  DEFAULT ((0)) FOR [Like_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_Lack_Parameter_Count]  DEFAULT ((0)) FOR [Lack_Parameter_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_Count_All]  DEFAULT ((0)) FOR [Count_All]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_analysis]  DEFAULT ((0)) FOR [analysis]
GO

ALTER TABLE [dbo].[DataBase_Sql_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Stats_createtime]  DEFAULT (getdate()) FOR [createtime]
GO

ALTER TABLE [dbo].[DataBase_Sql_SendEmail_WrongDataBaseUser] ADD  CONSTRAINT [DF_DataBase_Sql_SendEmail_WrongDataBaseUser_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[DataBase_Sql_SendEmail] ADD  CONSTRAINT [DF_DataBase_Sql_SendEmail_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_IsWriteSql]  DEFAULT ((0)) FOR [IsWriteSql]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_IsRuntimeSql]  DEFAULT ((0)) FOR [IsRuntimeSql]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_IsWrongDataBaseUSer]  DEFAULT ((0)) FOR [IsWrongDataBaseUser]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_Lack_With_NoLock_Count]  DEFAULT ((0)) FOR [Lack_With_NoLock_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_Select_All_Count]  DEFAULT ((0)) FOR [Select_All_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_Like_Count]  DEFAULT ((0)) FOR [Like_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_Lack_Parameter_Count]  DEFAULT ((0)) FOR [Lack_Parameter_Count]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_Lack_Parameter_Count1]  DEFAULT ((0)) FOR [Count_All]
GO

ALTER TABLE [dbo].[DataBase_Sql_My] ADD  CONSTRAINT [DF_DataBase_Sql_My_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[DataBase_Sql_Connect_Stats] ADD  CONSTRAINT [DF_DataBase_Sql_Connect_Stats_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[DataBase_Sql] ADD  CONSTRAINT [DF_DataBase_Sql_createtime]  DEFAULT (getdate()) FOR [createtime]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_group_handle]  DEFAULT ((0)) FOR [group_handle]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_unique_compiles]  DEFAULT ((0)) FOR [unique_compiles]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_user_seeks]  DEFAULT ((0)) FOR [user_seeks]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_user_scans]  DEFAULT ((0)) FOR [user_scans]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_avg_total_user_cost]  DEFAULT ((0)) FOR [avg_total_user_cost]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_avg_user_impact]  DEFAULT ((0)) FOR [avg_user_impact]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_system_seeks]  DEFAULT ((0)) FOR [system_seeks]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_system_scans]  DEFAULT ((0)) FOR [system_scans]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_avg_total_system_cost]  DEFAULT ((0)) FOR [avg_total_system_cost]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_avg_system_impact]  DEFAULT ((0)) FOR [avg_system_impact]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[DataBase_Missing_Index] ADD  CONSTRAINT [DF_DataBase_Missing_Index_Total_Cost]  DEFAULT ((0)) FOR [Total_Cost]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ���û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Transfer', @level2type=N'COLUMN',@level2name=N'Work_From_WebManager_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Transfer', @level2type=N'COLUMN',@level2name=N'Work_From_WebManager_Realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Transfer', @level2type=N'COLUMN',@level2name=N'Work_To_WebManager_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Transfer', @level2type=N'COLUMN',@level2name=N'Work_To_WebManager_Realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����������0���ƣ�1ת��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Transfer', @level2type=N'COLUMN',@level2name=N'Transfer_Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'״̬��0�½���1�Ѿ����գ�2�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Transfer', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Transfer', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ˣ���Ӣ�Ķ��Ÿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'WebManager_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������������Ӣ�Ķ��Ÿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'WebManager_RealName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL�����ˣ���Ӣ�Ķ��Ÿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'WebManager_Name_Depend'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL��������������Ӣ�Ķ��Ÿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'WebManager_RealName_Depend'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ƹ����ˣ���Ӣ�Ķ��Ÿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'WebManager_Name_Like'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ƹ�������������Ӣ�Ķ��Ÿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'WebManager_RealName_Like'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'IsMy_CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ���������Ƹ����ˣ�0δ������1������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'Analysis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'querystring'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Form����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'form'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳ���������ⲿURL���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'Depend_PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������URL���ⲿURL���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'Depend_PageUrl_Out'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GET�����ֻ����Ƿ���ܣ�0δ���ܣ�1�Ѽ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'querystring_Phone_Encrypt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POST�����ֻ����Ƿ���� ��0δ���ܣ�1�Ѽ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'form_Phone_Encrypt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'ErrorTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'ErrorInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_PageUrl', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl_Ignore', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ե���ҳURL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl_Ignore', @level2type=N'COLUMN',@level2name=N'PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ե���ҳURL��������ʽ���û�ģ��ƥ�为����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl_Ignore', @level2type=N'COLUMN',@level2name=N'PageUrl_Regex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl_Ignore', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ҵ��û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'querystring'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Form����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'form'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL��������ʽ���û�ģ��ƥ�为���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'PageUrl_Regex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������Ƿ��Ѽ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'Encrypt_Request'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������Ѽ���,���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'Encrypt_Request_Audit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GET�������ֻ����Ƿ��Ѽ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'querystring_Phone_Encrypt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POST�������ֻ����Ƿ��Ѽ���  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_PageUrl', @level2type=N'COLUMN',@level2name=N'form_Phone_Encrypt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ҵ��û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_Domain', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ص�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_Domain', @level2type=N'COLUMN',@level2name=N'Domain_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_My_Domain', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ⲿ������URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Stats_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���õĳ�ʱʱ�䣨���룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_TimeOut'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����URL��ƥ������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'PageUrl_Regex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL������ϸ��������¼�������һ�ε�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'PageUrl_Detail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ⲿ������URL��ƥ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_PageUrl_Regex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ⲿ����URL��������ϸ��������¼�������һ�ε�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_PageUrl_Detail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_Content'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ⲿ���������ͣ��磺text/xml��text/html��text/xml�ȣ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_ContentType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݸ�ʽ�Ƿ��д�0û��1�д�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_ContentType_Error'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݳ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_ContentLength'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ܴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʧ���ܴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_Count_Error'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʧ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_Error_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_Count_TimeOut'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_TimeOut_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ۼ�������ʱ�������룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_TimeSpan_Sum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�����ֵ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_TimeSpan_Max'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ����Сֵ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_TimeSpan_Min'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ������ֵ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_TimeSpan_New'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��ƽ��ֵ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_TimeSpan_Average'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�ε����ⲿ������ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebSite_Depend', @level2type=N'COLUMN',@level2name=N'Depend_CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Դ��SVN��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TuanTaskAutoRun', @level2type=N'COLUMN',@level2name=N'SvnSourcecode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ǿ��ɱ�����̣�0��1��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TuanTaskAutoRun', @level2type=N'COLUMN',@level2name=N'KillApp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ִ�е���־�ļ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TuanTaskAutoRun', @level2type=N'COLUMN',@level2name=N'logtxt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ݿ���ͨ��,0:����Ҫ����,1��Ҫ����,��ͨ����д��remark�ֶ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TuanTaskAutoRun', @level2type=N'COLUMN',@level2name=N'testDb'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ݿ���ͨ�Ա�ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TuanTaskAutoRun', @level2type=N'COLUMN',@level2name=N'testDb_remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PageUr����Sql_Md5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_PageUrl_Or_Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0��PageUrl��1��Sql_Md5��2��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ��Ѿ��������0δ��ɣ�1���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_Finished'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_Finished_Time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_WebManager_name_Finished'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���񴴽�ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ע ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Task', @level2type=N'COLUMN',@level2name=N'Task_Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ���ļ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'Commit_File'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ�汾��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'Revision'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'WebManager_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'Commit_Server'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ���ͣ�0Added��1Modified��2Deleted��3replacing' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'Commit_Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ�ļ���MD5��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'Commit_File_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'Commit_Time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'Commit_Message'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log_LastUpdate', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ�汾��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'Revision'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'WebManager_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'Commit_Server'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ���ͣ�0Added��1Modified��2Deleted��3replacing' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'Commit_Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ�ļ���MD5��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'Commit_File_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύ���ļ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'Commit_File'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ύʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'Commit_Time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'Commit_Message'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SVN_Log', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_View', @level2type=N'COLUMN',@level2name=N'View_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_View', @level2type=N'COLUMN',@level2name=N'View_Time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_View', @level2type=N'COLUMN',@level2name=N'View_Article_Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ͼƬID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_View', @level2type=N'COLUMN',@level2name=N'View_Bg_No'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_View', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Invite', @level2type=N'COLUMN',@level2name=N'Invite_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����˭����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Invite', @level2type=N'COLUMN',@level2name=N'Invite_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Invite', @level2type=N'COLUMN',@level2name=N'Invite_CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article_Good', @level2type=N'COLUMN',@level2name=N'Article_Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article_Good', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article_Good', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0һ�仰����1��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_Share_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���±��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_Title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_good'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_viewcount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Share_Article', @level2type=N'COLUMN',@level2name=N'Article_deleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������ƣ��磺192.168.187.202_api.channelsales.tao.fang.com ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'servername'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'create_ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'create_username'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'create_password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'create_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�鿴��IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'decrypt_ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�鿴���û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'decrypt_username'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�鿴�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'decrypt_password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�鿴��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'decrypt_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����״̬��0��������1����ͨ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'decrypt_status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע��������д���θ��µľ��幦�ܺ�˵��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'decrypt_remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ񷢹��ʼ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Password', @level2type=N'COLUMN',@level2name=N'SendEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Log', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ���IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Log', @level2type=N'COLUMN',@level2name=N'ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Log', @level2type=N'COLUMN',@level2name=N'username'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������ƣ��磺192.168.187.202_api.channelsales.tao.fang.com' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Log', @level2type=N'COLUMN',@level2name=N'servername'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Server_Update_Log', @level2type=N'COLUMN',@level2name=N'createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached������IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'Memcache_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached�������˿� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'Memcache_Port'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'Stats_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����״̬,0������,1����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��վ�������磺api.tuan.tao.fang.com ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'WebSite'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached����������IP  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'Memcache_Local_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcache����õ�key�����������;����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'Error_Key'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'Error'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'pid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'uptime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������ǰunixʱ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������汾' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'version'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'libevent�汾' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'libevent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ϵͳ�ִ�С(64��ʾ��̨��������64λ��)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'pointer_size'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ۼ��û�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'rusage_user'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ۼ�ϵͳʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'rusage_system'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ǰ��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'curr_connections'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���򿪵���������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'total_connections'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������������ӽṹ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'connection_structures'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'reserved_fds ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'reserved_fds'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ִ��get��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'cmd_get'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ִ��set��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'cmd_set'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ָ��flush_all��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'cmd_flush'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'cmd_touch ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'cmd_touch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'get_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'getδ���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'get_misses'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'deleteδ���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'delete_misses'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'delete���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'delete_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'incrδ���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'incr_misses'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'incr���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'incr_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'decrδ���д���?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'decr_misses'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'decr���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'decr_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'casδ���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'cas_misses'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'cas���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'cas_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʹ�ò��ô���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'cas_badval'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'touch_hits' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'touch_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'touch_misses ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'touch_misses'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'auth_cmds ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'auth_cmds'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'auth_errors ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'auth_errors'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ȡ�ֽ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'bytes_read'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'д���ֽ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'bytes_written'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ڴ������ֽڣ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'limit_maxbytes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ŀǰ���ܵ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'accepting_conns'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�߳���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'threads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�洢item�ֽ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'bytes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'item����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'curr_items'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'item����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'total_items'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����memcache�Ŀռ�������ɾ���ɵ�items��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'evictions'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������ã��ѹ��ڵ�������Ŀ���洢������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'reclaimed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'redis�ļ����Ϣ,��json��ʽ�洢' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Stats', @level2type=N'COLUMN',@level2name=N'StatsInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'Memcache_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˿�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'Memcache_Port'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����״̬,0������,1����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached����IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'Memcache_Local_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcache����õ�key�����������;����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'Error_Key'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ô�memcache�˿ڵ���վ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'WebSite'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Redis��Ȩ�����룬ֻ��Redis��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'Auth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0:Memcached;1:Redis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'CacheType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Server', @level2type=N'COLUMN',@level2name=N'ResetTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ռ�ͺ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'FunctionName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'Stats_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcached��IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'Memcache_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcached�Ķ˿�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'Memcache_Port'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get�ܴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'get_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get��ʧ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'get_misses_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'get_hits_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'set�ܴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'set_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'set��ʧ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'set_misses_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'set���д���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'set_hits_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Memcache_Hits', @level2type=N'COLUMN',@level2name=N'createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'pageurl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL������ʽ������ģ��ƥ�为���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'PageUrl_Regex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'querystring'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Form����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'form'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GET�������ֻ����Ƿ���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'querystring_Phone_Encrypt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POST�������ֻ����Ƿ����  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'form_Phone_Encrypt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0������־��1ҵ����־' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'log_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־ͳ������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'log_date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'log_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ŷ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'teamname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'ReMarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'Content'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'Error_CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'Title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ���IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'username'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'classname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ڷ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'MethodName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Stats', @level2type=N'COLUMN',@level2name=N'loglevel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼��־ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'Title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0:�ɹ�;1:����;2:ʧ��;3:��Ҫ���󣨷����ʼ���;4:�ش����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'LogLevel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'Content'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ���IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼���û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'UserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'ReMarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ڷ�����  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'MethodName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'pageurl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL������ʽ������ģ��ƥ�为����  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'PageUrl_Regex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����Ŷ�����  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'teamname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'servername'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ����͵���Email��ַ  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'send_email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ����͸��ĸ�����  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'send_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ�����ʱ��  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Error', @level2type=N'COLUMN',@level2name=N'send_email_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'Title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'LogLevel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'Content'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ���IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼�û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'UserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'ReMarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ڷ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'MethodName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'pageurl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����Ŷ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'teamname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'servername'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҳURL������ʽ������ģ��ƥ�为���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'PageUrl_Regex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ����͵���Email��ַ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'send_email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ����͸��ĸ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'send_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ�����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Log_Business', @level2type=N'COLUMN',@level2name=N'send_email_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_My', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҵ���֣�������windows��ҵ���ļ�Ŀ¼����sqlserver�Ĳ���·��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_My', @level2type=N'COLUMN',@level2name=N'JobName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_My', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ҵID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'job_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'DataBase_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵִ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'run_date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵִ��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'run_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'step_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'step_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'message'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ�����Ƿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'enabled'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'date_created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ�޸�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'date_modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵִ��״̬��0ʧ�ܣ�1�ɹ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'run_status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���ҵ����ִ��ʱ�䣨�룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Job_Log', @level2type=N'COLUMN',@level2name=N'run_duration'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'createdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ա���� ��1:������Ա��0:�Ͷ���Ա��2:�ϻﾭ���ˣ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'labour'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ÿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'performstandardname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'servicetypename'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'dictcityname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʱ�䣨����ְ����ְʱ�����£���ְ��Ա����ְʱ�䲻�䣩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'quitdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�عɸ��ܲü��·����̼����ܲ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'jobtitlename'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ְ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EC_User_UserInfo_OA_Staff', @level2type=N'COLUMN',@level2name=N'createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'uName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������ͼ�ʹ洢������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����Reference' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tReferences'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����Insert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tInsert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����Select' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tSelect'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����Update' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tUpdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����Delete' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����Execute' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'tExecute'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ͣ��ܾ�Deny������GRANT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'ProtectType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ִ�е�SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'ProtectTypeSql'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User_Authority', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'uname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�״̬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'uStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'rId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ״̬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'rStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'rName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_User', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'Column_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_UpdateLog', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ռ�¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ռ�¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ܼ�¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Week'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ܼ�¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Week_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���¼�¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Month'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���¼�¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Month_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Year'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Year_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'ColumnCounts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_My', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'Index_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'Column_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'Like_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'Like_WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Index', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Like_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Like_WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶγ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_Length'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_Is_PrimaryKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_Null'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ������ֶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_Identity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ĭ��ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_DefaultValue'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֶ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table_Column', @level2type=N'COLUMN',@level2name=N'Column_Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'CountDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'Like_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'Like_WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ռ�¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ռ�¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ܼ�¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Week'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ܼ�¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Week_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���¼�¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Month'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���¼�¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Month_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����¼�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Year'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����¼������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'RowCounts_Increasing_Year_Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'ColumnCounts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ռ�(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'Space_Allocation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʹ�ÿռ�(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'Space_Used'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʹ�ÿռ�(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'Space_Index_Used'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'δ�ÿռ�(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Table', @level2type=N'COLUMN',@level2name=N'Space_Available'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Sync', @level2type=N'COLUMN',@level2name=N'DataBase_Remote_Ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͬ�����ڣ�����ִ�е����ڣ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Sync', @level2type=N'COLUMN',@level2name=N'Sync_date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͬ����¼��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Sync', @level2type=N'COLUMN',@level2name=N'Sync_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Stats_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʽ�����SQL��MD5�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Դ������MD5���ܴ�������url�������ռ䡢������SQL��������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Source_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ա' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'seemlike_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ա��ʵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'seemlike_WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ó���SQL������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'sql_error'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ����SQL��0��ֻ����1������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'IsWriteSql'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�������е�SQL��0����,1��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'IsRuntimeSql'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ʹ���˴�������ݿ��û�������Ǹ��µ�SQLȴ���˿�д���Ӵ���ʹ�ÿ�д���ݿ��û�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'IsWrongDataBaseUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȱ��WITH(NOLOCK)����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Lack_With_NoLock_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'select*���ֵĴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Select_All_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Likeģ����ѯ���ִ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Like_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'δʹ�ò�����ֵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Lack_Parameter_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Count(*)����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Count_All'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʾ������ѯ������ѯ��洢���̵ı�ǡ�
ͨ������ sys.dm_exec_sql_text ��̬��������sql_handle ���Ժ� statement_start_offset �� statement_end_offset һ�����ڼ�����ѯ�� SQL �ı���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'sql_handle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'DataBase_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��û�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'DataBase_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'database_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'sql���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'statement_text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����sql����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������sql' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'text_analysis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ������sql' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'analysis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'creation_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴο�ʼִ�мƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'last_execution_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ƻ����ϴα���������ִ�еĴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'execution_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա�������ִ�����õ� CPU ʱ����������΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'total_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ����õ� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'last_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���С CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'min_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'max_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е������ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'total_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'last_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е����������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'min_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е���������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'max_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼�д���ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'total_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ����Ļ����ҳ�������ҳ�ѱ��ࣨ���޸ģ����򲻼���д������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'last_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'min_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'max_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼���ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'total_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е��߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'last_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'min_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'max_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ����ִ�д˼ƻ����õ���ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'total_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�����ִ�д˼ƻ����õ�ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'last_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ���Сʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'min_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ����ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'max_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ص�������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'total_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��һ��ִ�в�ѯ���ص�����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'last_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص���С����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'min_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص��������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'max_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Stats', @level2type=N'COLUMN',@level2name=N'createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail_WrongDataBaseUser', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail_WrongDataBaseUser', @level2type=N'COLUMN',@level2name=N'Stats_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʽ�����SQL��MD5�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail_WrongDataBaseUser', @level2type=N'COLUMN',@level2name=N'Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail_WrongDataBaseUser', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail', @level2type=N'COLUMN',@level2name=N'Stats_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʽ�����SQL��MD5�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail', @level2type=N'COLUMN',@level2name=N'Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_SendEmail', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����˵��û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL��MD5���ܴ�������ʶ���Ƿ�ͬ���SQL   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Դ������MD5���ܴ�������url�������ռ䡢������SQL��������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'Source_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ��URL��MD5��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'Sql_error'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������SQL ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'TEXT_ANALYSIS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'DataBase_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��û�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'DataBase_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'database_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'creation_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴο�ʼִ�мƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'last_execution_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ƻ����ϴα���������ִ�еĴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'execution_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա�������ִ�����õ� CPU ʱ����������΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'total_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ����õ� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'last_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���С CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'min_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'max_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е������ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'total_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'last_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е����������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'min_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е���������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'max_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼�д���ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'total_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ����Ļ����ҳ�������ҳ�ѱ��ࣨ���޸ģ����򲻼���д������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'last_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'min_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'max_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼���ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'total_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е��߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'last_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'min_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'max_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ����ִ�д˼ƻ����õ���ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'total_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�����ִ�д˼ƻ����õ�ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'last_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ���Сʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'min_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ����ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'max_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ص�������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'total_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��һ��ִ�в�ѯ���ص�����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'last_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص���С����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'min_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص��������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'max_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My_Ignore', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����˵��û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL��MD5���ܴ�������ʶ���Ƿ�ͬ���SQL  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Դ������MD5���ܴ�������url�������ռ䡢������SQL��������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Source_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL�����������д���淶������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Sql_error'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ����SQL��0��ֻ����1������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'IsWriteSql'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�������е�SQL��0����,1��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'IsRuntimeSql'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ʹ���˴�������ݿ��û�������Ǹ��µ�SQLȴ���˿�д���Ӵ���ʹ�ÿ�д���ݿ��û�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'IsWrongDataBaseUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȱ��WITH(NOLOCK)����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Lack_With_NoLock_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'select*���ֵĴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Select_All_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Likeģ����ѯ���ִ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Like_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'δʹ�ò�����ֵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Lack_Parameter_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Count(*)����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Count_All'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��д�淶�������SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'TEXT_ANALYSIS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'DataBase_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��û�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'DataBase_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'database_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݱ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'creation_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴο�ʼִ�мƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'last_execution_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ƻ����ϴα���������ִ�еĴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'execution_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա�������ִ�����õ� CPU ʱ����������΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'total_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ����õ� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'last_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���С CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'min_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'max_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е������ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'total_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'last_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е����������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'min_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е���������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'max_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼�д���ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'total_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ����Ļ����ҳ�������ҳ�ѱ��ࣨ���޸ģ����򲻼���д������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'last_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'min_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'max_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼���ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'total_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е��߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'last_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'min_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'max_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ����ִ�д˼ƻ����õ���ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'total_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�����ִ�д˼ƻ����õ�ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'last_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ���Сʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'min_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ����ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'max_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ص�������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'total_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��һ��ִ�в�ѯ���ص�����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'last_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص���С����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'min_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص��������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'max_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_My', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'PageUrl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Stats_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'querystring'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Form����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'form'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����������ݿ�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'LastConnectTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ�������ܴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Request_Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ�������ܺ�ʱ(����)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Duration_Sum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ������ƽ����ʱ(����)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Duration_Avg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ����������ʱ(����)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Duration_Max'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ��������С��ʱ(����)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Duration_Min'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ݿ��ܴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Connect_Times_Sum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ƽ��ÿ�������������ݿ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Connect_Times_Avg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������������ݿ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Connect_Times_Max'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������������ݿ���С��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'Connect_Times_Min'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Stats', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL���ߺ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'PageUrlOrFunction'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'querystring'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Form����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'form'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ڱ�ʶ�ǲ��Ǳ��η���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'SessionId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL��md5���ܴ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʵ����ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'DataBase_Ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'DataBase_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Web��������Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'ServerInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL��ʼִ��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'ExecutionTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQLִ�н���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'ExecutionTime_End'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQLִ���ܺ�ʱ(����)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'Duration'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql_Connect_Log', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʾ������ѯ������ѯ��洢���̵ı�ǡ�
ͨ������ sys.dm_exec_sql_text ��̬��������sql_handle ���Ժ� statement_start_offset �� statement_end_offset һ�����ڼ�����ѯ�� SQL �ı���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'sql_handle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'DataBase_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��û�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'DataBase_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'database_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݱ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'sql���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'statement_text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����sql����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL��MD5���ܴ�������ʶ���Ƿ�ͬ���SQL ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'Sql_Md5'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'creation_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴο�ʼִ�мƻ���ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'last_execution_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ƻ����ϴα���������ִ�еĴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'execution_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա�������ִ�����õ� CPU ʱ����������΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'total_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ����õ� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'last_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���С CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'min_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ����õ���� CPU ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'max_worker_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е������ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'total_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'last_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е����������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'min_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е���������ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'max_physical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼�д���ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'total_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ����Ļ����ҳ�������ҳ�ѱ��ࣨ���޸ģ����򲻼���д������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'last_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'min_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼�д�������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'max_logical_writes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��Ա������ִ���ڼ���ִ�е��߼���ȡ�ܴ�����
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'total_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ִ�мƻ�ʱ��ִ�е��߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'last_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е������߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'min_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˼ƻ��ڵ���ִ���ڼ���ִ�е�����߼���ȡ������
����ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'max_logical_reads'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ����ִ�д˼ƻ����õ���ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'total_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�����ִ�д˼ƻ����õ�ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'last_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ���Сʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'min_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�κ�һ�����ִ�д˼ƻ����õ����ʱ�䣨��΢��Ϊ��λ���棬������ȷ�����룩��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'max_elapsed_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ص�������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'total_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��һ��ִ�в�ѯ���ص�����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'last_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص���С����������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'min_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ѯ���ϴα���������ִ�мƻ��Ĵ��������ص��������������Ϊ null��
����������Ĵ洢���̲�ѯ�ڴ��Ż��ı�ʱ�����ʼ��Ϊ 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'max_rows'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Sql', @level2type=N'COLUMN',@level2name=N'createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Local'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����VIP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_VIP_Local'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����VIP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_VIP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݻ�ר��IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Special'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Recovery'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ����Ա�û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Admin_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ����Ա�û����루���ܴ洢��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Admin_PassWord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�ֻ���û��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Reader_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�ֻ���û����루���ܴ洢��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Reader_PassWord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��д�û���  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Writer_User'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ��д�û����루���ܴ洢��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Writer_PassWord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����˵��HTML' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Table_Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ����⣬ֻ�����������˵��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_Is_Main'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴθ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'Last_Update_Time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�洢���̺���ͼ�������һ�α���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_PROC_VIEW_FUNCTION_Bak1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�洢���̺���ͼ������һ�α���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_PROC_VIEW_FUNCTION_Bak2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�洢���̺���ͼ��������һ�α���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'DataBase_PROC_VIEW_FUNCTION_Bak3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʹ�ÿռ�(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Owner', @level2type=N'COLUMN',@level2name=N'Space_Used'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'DataBase_IP_Romote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͳ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'index_handle ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'index_handle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'group_handle ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'group_handle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'Table_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ν�ʵ��еĶ��ŷָ��б� ���ĸ��ֶ�ȱʧ���������������г���������������where �����ɸѡ�ֶΣ���ν�ʵ���ʽ���£�table.column =constant_value' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'equality_columns'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ɲ���ν�ʵ��еĶ��ŷָ��б�����������ʽ��ν�ʣ�table.column > constant_value ��=��֮����καȽ����������ʾ����ȡ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'inequality_columns'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ڲ�ѯ�ĺ����еĶ��ŷָ��б����������� select ������ֶΣ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'included_columns'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ȱʧ�ı������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'statement'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ӹ�ȱʧ����������ı�������±�������  ��಻ͬ��ѯ�ı�������±����Ӱ�����ֵ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'unique_compiles'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н����������û���ѯ�����µĲ��Ҵ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'user_seeks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н����������û���ѯ�����µ�ɨ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'user_scans'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н����������û���ѯ�����µ��ϴβ������ں�ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'last_user_seek'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н����������û���ѯ�����µ��ϴ�ɨ�����ں�ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'last_user_scan'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ͨ�����е��������ٵ��û���ѯ��ƽ���ɱ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'avg_total_user_cost'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʵ�ִ�ȱʧ��������û���ѯ���ܻ�õ�ƽ���ٷֱ����档  ��ֵ��ʾ���ʵ�ִ�ȱʧ�����飬���ѯ�ɱ������˰ٷֱ�ƽ���½���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'avg_user_impact'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н���������ϵͳ��ѯ�����Զ�ͳ����Ϣ��ѯ�������µĲ��Ҵ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'system_seeks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н���������ϵͳ��ѯ�����µ�ɨ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'system_scans'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н���������ϵͳ��ѯ�����µ��ϴ�ϵͳ�������ں�ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'last_system_seek'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɿ���ʹ�������н���������ϵͳ��ѯ�����µ��ϴ�ϵͳɨ�����ں�ʱ�䡣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'last_system_scan'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ͨ�����е��������ٵ�ϵͳ��ѯ��ƽ���ɱ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'avg_total_system_cost'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʵ�ִ�ȱʧ�������ϵͳ��ѯ���ܻ�õ�ƽ���ٷֱ����档  ��ֵ��ʾ���ʵ�ִ�ȱʧ�����飬���ѯ�ɱ������˰ٷֱ�ƽ���½��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'avg_system_impact'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ɽ�ʡ�ܿ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Missing_Index', @level2type=N'COLUMN',@level2name=N'Total_Cost'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'DataBase_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ݿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'DataBase_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'WebManager_Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ִ�е�SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'Alter_Sql'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'״̬��0�½���1��ִ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'Alter_Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'Alter_Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL���ڵ��������ִ�н��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'Alter_Problem'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ִ��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'Alter_Time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataBase_Alter', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ȡ�ı������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill_Receive', @level2type=N'COLUMN',@level2name=N'Bill_Receive_year'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ȡ�ı����·�  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill_Receive', @level2type=N'COLUMN',@level2name=N'Bill_Receive_month'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ȡ�ı���С�Ŷӳ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill_Receive', @level2type=N'COLUMN',@level2name=N'Bill_Receive_leader_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ı������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill_Lock', @level2type=N'COLUMN',@level2name=N'Bill_Lock_year'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ı����·� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill_Lock', @level2type=N'COLUMN',@level2name=N'Bill_Lock_month'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ı���С�Ŷӳ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill_Lock', @level2type=N'COLUMN',@level2name=N'Bill_Lock_leader_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_year'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�·�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_month'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ŷӳ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_leader_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_reason'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ա�����ÿո����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_staff_worker'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_total_money'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�������0�ɱ༭��1������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_lock'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'bill_CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_year'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�·�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_month'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_pen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��о' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_penlead'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ʼǲ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_book'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ˮ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_glue'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ǩֽ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_notepaper'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_lock'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ��ѷ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_Receive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apply', @level2type=N'COLUMN',@level2name=N'Apply_CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ�޷���ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager_Group', @level2type=N'COLUMN',@level2name=N'Group_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ�޷�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager_Group', @level2type=N'COLUMN',@level2name=N'Group_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ�޷��鴴��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager_Group', @level2type=N'COLUMN',@level2name=N'Group_Createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager_Group', @level2type=N'COLUMN',@level2name=N'Group_Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ�޷���ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Group_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ܲ鿴��product���磺 1|8|9' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Product'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ���IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����¼�Ŀͻ���IP,����������һ������˳���¼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_IP_LastLogin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ŷӳ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_leader_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ŶӼ���0��Ա��1С�Ŷӳ���2���Ŷӳ���3�����Ŷӳ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_leader_level'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʵ���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_realname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���� �����ܴ洢��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_PassWord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�̶��绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Phone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Oicq'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ƶ��绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_mobile'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����¼ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Last_logintime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Createtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�״̬:100����,200ͣ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ���ձ����ʼ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Recieve_AlertEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ񳬼�����Ա' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_WebManager', @level2type=N'COLUMN',@level2name=N'WebManager_Is_Admin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ĳ�ƷID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Product', @level2type=N'COLUMN',@level2name=N'ProductId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ĳ�Ʒ���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Product', @level2type=N'COLUMN',@level2name=N'ProductName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ǰ׺ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Product', @level2type=N'COLUMN',@level2name=N'TablePrefix'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ԱEmail ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Product', @level2type=N'COLUMN',@level2name=N'ManagerEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ա�ֻ��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Product', @level2type=N'COLUMN',@level2name=N'ManagerPhone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ�޷���ID���[Admin_group] Group_id����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Permission', @level2type=N'COLUMN',@level2name=N'Permission_Group_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ID���[Admin_Function] Function_id����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Permission', @level2type=N'COLUMN',@level2name=N'Permission_function_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ϵͳģ��ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Module', @level2type=N'COLUMN',@level2name=N'Module_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ϵͳģ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Module', @level2type=N'COLUMN',@level2name=N'Module_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ģ������ ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Module', @level2type=N'COLUMN',@level2name=N'Module_Order'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Module', @level2type=N'COLUMN',@level2name=N'Module_Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOG����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'MallLogID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ʒ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'Product'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'UserType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�����������ȫƴ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'UserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʵ���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'RealName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־��� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'ItemType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'ItemID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ���IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־��¼ʱ�� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Log', @level2type=N'COLUMN',@level2name=N'AddedTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ӧ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_url'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ����ڲ˵���1���ǣ�0��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ӦFunction_Type=1��Function_Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_Group_Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ϵͳģ��ID���[Admin_Module] Module_id����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_Module_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_Order'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_Remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ҳ��������� ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Function', @level2type=N'COLUMN',@level2name=N'Function_View_Count'
GO


USE [TeamTool_test]
GO

/****** Object:  StoredProcedure [dbo].[SP_CommonPaging]    Script Date: 2018/11/30 9:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[SP_CommonPaging]
(@pagesize int,--ÿҳ�ж��ټ�¼
@pageindex int,--��ǰҪ��ҳ��,��0��ʼ
@selectColumn varchar(1000),--Ҫ��ѯ����
@JoinSql varchar(1000),--���������
@table varchar(1000),--Ҫ��ѯ�ı�
@PrimaryKey varchar(1000),--�����У��Ż��ٶȣ��������û�����������Ƕ��������ÿ�''
@condition varchar(8000),--��ѯ����
@Order varchar(1000),--���򷽷�
@docount bit,--�Ƿ�ȡ��¼����1 ��ʾ ȡ�ܼ�¼����2(����) ��ʾȡ��¼
@bDistinct bit--�Ƿ�Distinct
)
as
set nocount on
if(@docount=1)
  begin
	exec('select count(1) from '+@table+' WITH(NOLOCK) '+@JoinSql+' where 1=1 '+@condition)
  end
if(1=1)
  begin
	 declare @pagesizes varchar(10)
	 declare @TempKEYID varchar(10)
	 declare @Top varchar(10)
	 declare @OrderByStr varchar(500)
	 declare @OrderByColumn varchar(500)
	 declare @OrderByColumns varchar(500)
	 declare @DistinctStr varchar(100)
	 declare @temp varchar(100)
	 declare @bMultiKey bit--�Ƿ����϶�����
	 declare @bIdentityKey bit--�����Ƿ�������
	 declare @OrderColumn varchar(100)--�������
	 declare @OrderType varchar(100)--����ʽ
	 declare @AddColumn varchar(100)--Ϊ������ӵ�������
	 declare @CastPrimaryKey varchar(100)--��Ҫת������������

	 set @pagesizes = Cast(@pagesize as varchar(10))
	 set @TempKEYID = Cast(@pageindex*@pagesize as varchar(10))
	 set @Top = Cast((@pageindex+1)*@pagesize as varchar(10))
	 set @OrderByStr =''
	 set @OrderByColumn=''
	 set @OrderByColumns=''
	 set @DistinctStr =''
	 set @temp=(SELECT right(cast(RAND () as varchar),2)+right(cast(RAND () as varchar),2))
	 if(@PrimaryKey like '%,%')
	   set @bMultiKey=1
	 else
	   set @bMultiKey=0
	 set @bIdentityKey=(SELECT COLUMNPROPERTY(  OBJECT_ID(@table),@PrimaryKey,'IsIdentity'))
	 set @OrderColumn=Replace(Replace(@Order,' ASC',''),' DESC','')--�������
	 set @OrderType=Replace(@Order,@OrderColumn,'')--����ʽ
         if(@selectColumn not like '%'+@OrderColumn+'%')
	   set @AddColumn=','+@OrderColumn
         else
	   set @AddColumn=''
         set  @CastPrimaryKey=@PrimaryKey
	if(@bIdentityKey=1)
	  set  @CastPrimaryKey=' CAST('+@PrimaryKey+' AS INT) AS '+@PrimaryKey+' '
	else
	  set  @CastPrimaryKey=@PrimaryKey
--------------------------------------------------------------------------- 
  if(@Order<>'')
	 begin
	  if(charindex(',',@Order)=0)
	   begin
		 set @OrderByStr=' order by '+@Order
		 set @OrderByColumn=','+@OrderColumn+' AS ORDERCOLUMN '
		 set @OrderByColumns=' ORDER BY ORDERCOLUMN '+@OrderType+' '

		 if(@bIdentityKey=1)--����������������Ұ���������������Ҫת������
         begin
		     if(rtrim(ltrim(@Order))=rtrim(ltrim(@PrimaryKey)))
             begin
  				set @OrderByColumn=',CAST('+@OrderColumn+' AS INT) AS ORDERCOLUMN '
			 end
          end
		 if(@bMultiKey=1)--��������϶�����
		   begin
  		     set @OrderByColumn=','+@OrderColumn+' '
  		     set @OrderByColumns=' ORDER BY '+@OrderColumn+' '+@OrderType+' '
		   end
		end
		ELSE 
		BEGIN
			set @OrderByStr=' order by '+@Order
			set @OrderByColumn=''
			set @OrderByColumns=' ORDER BY '+@Order+' '
		END
	 end
---------------------------------------------------------------------------
	 if(@bDistinct=1)
	   set @DistinctStr=' distinct '
---------------------------------------------------------------------------
	 if(@Order='')
		begin
		  if(@PrimaryKey='')
			 exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@selectColumn+',IDENTITY(int, 1, 1) as KEYID into #temp'+@temp+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where 1=1 '+@condition+'
				   set rowcount '+@pagesizes+'
				   select  * from #temp'+@temp+'  where KEYID>'+@TempKEYID+' Drop Table #temp'+@temp+' '
				  )
		  else
                      begin
----------------------------------------------------
                          if(@bMultiKey=1)--��������϶�����??????
			     exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@PrimaryKey+',IDENTITY(int, 1, 1) as KEYID into #temp'+@temp+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where 1=1 '+@condition+'
				   set rowcount '+@pagesizes+'
				   select  '+@PrimaryKey+' into #temp'+@temp+'1 from #temp'+@temp+'  where KEYID>'+@TempKEYID+'
				   set rowcount 0
				   select '+@DistinctStr+' '+@selectColumn+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'1) Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1 '
				  )
-----------------------------------------------------
                         else--������������
			      exec('set  rowcount '+@Top+' select '+@DistinctStr+@CastPrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where 1=1 '+@condition+'
				   set rowcount '+@pagesizes+'
				   select  '+@PrimaryKey+' into #temp'+@temp+'1 from #temp'+@temp+'  where KEYID>'+@TempKEYID+'
				   set rowcount 0
				   select '+@DistinctStr+' '+@selectColumn+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'1) Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1 '
				  )
-----------------------------------------------------
		     end
		end
---------------------------------------------------------------------------
	 else
---------------------------------------------------------------------------
		begin
		   if(@PrimaryKey='')
			  exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@selectColumn+@OrderByColumn+' into #temp'+@temp+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where 1=1 '+@condition+@OrderByStr+'
					select *,IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+'1 from  #temp'+@temp+@OrderByColumns+'
					set rowcount '+@pagesizes+'
					select  * from #temp'+@temp+'1  where KEYID>'+@TempKEYID+' Drop Table #temp'+@temp+'  Drop Table #temp'+@temp+'1 '
					) 
					
		   else
                      begin
----------------------------------------------------
                          if(@bMultiKey=1)--��������϶�����????
			      exec('set  rowcount '+@Top+' select '+@DistinctStr+' '+@PrimaryKey+@OrderByColumn+' into #temp'+@temp+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where 1=1 '+@condition+@OrderByStr+'
					 select '+@PrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+'1 from  #temp'+@temp+@OrderByColumns+'
					 set rowcount '+@pagesizes+'
					 select  '+@PrimaryKey+' into #temp'+@temp+'2 from #temp'+@temp+'1  where KEYID>'+@TempKEYID+'
					 set rowcount 0
					 select '+@DistinctStr+' '+@selectColumn+@AddColumn+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'2) '+@OrderByStr+' Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1  Drop Table #temp'+@temp+'2 '
					 ) 
					
-----------------------------------------------------
             else--������������
             begin
			       exec('set  rowcount '+@Top+' select '+@DistinctStr+@CastPrimaryKey+@OrderByColumn+' into #temp'+@temp+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where 1=1 '+@condition+@OrderByStr+'
					 select '+@PrimaryKey+',IDENTITY(int, 1, 1)  as KEYID into #temp'+@temp+'1 from  #temp'+@temp+@OrderByColumns+'
					 set rowcount '+@pagesizes+'
					 select  '+@PrimaryKey+' into #temp'+@temp+'2 from #temp'+@temp+'1  where KEYID>'+@TempKEYID+'
					 set rowcount 0
					 select '+@DistinctStr+' '+@selectColumn+@AddColumn+' from  '+@table+' WITH(NOLOCK) '+@JoinSql+' where '+@PrimaryKey+' in(select '+@PrimaryKey+' from #temp'+@temp+'2) '+@OrderByStr+' Drop Table #temp'+@temp+' Drop Table #temp'+@temp+'1  Drop Table #temp'+@temp+'2 '
					 )
					 end
-----------------------------------------------------
		      end
		end
---------------------------------------------------------------------------

  end
set nocount off



GO

/****** Object:  StoredProcedure [dbo].[SP_DataBase_Table_Update]    Script Date: 2018/11/30 9:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




 
CREATE PROCEDURE [dbo].[SP_DataBase_Table_Update](@DataBase_Name_Input varchar(50),@DataBase_IP_Romote_Input varchar(50))
	 
AS
BEGIN
SET NOCOUNT ON;

declare @today varchar(100) ,@yestoday varchar(100),@lastweek varchar(100),@lastmonth varchar(100),@lastyear varchar(100)
SET @today = (SELECT CONVERT(VARCHAR(100), GETDATE(), 23))
set @yestoday=(SELECT CONVERT(VARCHAR(100),Dateadd(day,-1,@today) , 23)) 
set @lastweek=(SELECT CONVERT(VARCHAR(100),Dateadd(week,-1,@today) , 23)) 
set @lastmonth=(SELECT CONVERT(VARCHAR(100),Dateadd(month,-1,@today) , 23)) 
set @lastyear=(SELECT CONVERT(VARCHAR(100),Dateadd(year,-1,@today) , 23)) 
------------------------------------------
exec('
DELETE from DataBase_Table where DataBase_Name='''+@DataBase_Name_Input+''' and DataBase_IP_Romote='''+@DataBase_IP_Romote_Input+''' and CountDate='''+@today+'''
insert into DataBase_Table(DataBase_Name, Table_Name, CountDate, DataBase_IP_Romote, RowCounts, RowCounts_Increasing, RowCounts_Increasing_Rate, ColumnCounts)
SELECT DISTINCT 
'''+@DataBase_Name_Input+''' as DataBase_Name,
[NAME] as Table_Name,
'''+@today+''' as CountDate,
'''+@DataBase_IP_Romote_Input+''' as DataBase_IP_Romote,
0 as RowCounts,
0 as RowCounts_Increasing,
0 as RowCounts_Increasing_Rate,
0 as ColumnCounts 
FROM ['+@DataBase_IP_Romote_Input+'].'+@DataBase_Name_Input+'.dbo.[SYSOBJECTS] WITH(NOLOCK)
WHERE 1=1  AND  (XTYPE=''U'') 
')


---------------------------------------
DECLARE  
	@DataBase_Name varchar(50),
	@Table_Name varchar(50),
	@CountDate datetime,
	@DataBase_IP_Romote varchar(50)

DECLARE contact_cursor CURSOR FOR 
SELECT
	DataBase_Name, Table_Name, CountDate, DataBase_IP_Romote
FROM DataBase_Table WITH(NOLOCK) where DataBase_Name=@DataBase_Name_Input and CountDate=@today 
 

OPEN contact_cursor
 
FETCH NEXT FROM contact_cursor INTO  @DataBase_Name, @Table_Name, @CountDate, @DataBase_IP_Romote
 
WHILE @@FETCH_STATUS = 0
BEGIN
    BEGIN  
	-----------------------------------------------------------------------------------------------------------------
	exec ('	 
	DECLARE @RowCounts_new bigint , @RowCounts_yestoday bigint, @RowCounts_lastweek bigint, @RowCounts_lastmonth bigint, @RowCounts_lastyear bigint,
	@RowCounts_Increasing_new bigint,@RowCounts_Increasing_Rate_new float,	 
	@RowCounts_Increasing_Week_new bigint,@RowCounts_Increasing_Week_Rate_new float,
	@RowCounts_Increasing_Month_new bigint,@RowCounts_Increasing_Month_Rate_new float,
	@RowCounts_Increasing_Year_new bigint,@RowCounts_Increasing_Year_Rate_new float, @ColumnCounts_new bigint

	select @RowCounts_new=count(1) from ['+@DataBase_IP_Romote+'].'+@DataBase_Name+'.dbo.['+@Table_Name+'] WITH(NOLOCK)  
	select @ColumnCounts_new=count(1) from ['+@DataBase_IP_Romote+'].'+@DataBase_Name+'.dbo.[SYSCOLUMNS] WITH(NOLOCK)
	where id=(
	 select id from ['+@DataBase_IP_Romote+'].'+@DataBase_Name+'.dbo.[SYSOBJECTS] WITH(NOLOCK) where NAME='''+@Table_Name+'''
	)	

	if(@RowCounts_new=0)
	begin
		set @RowCounts_new=1
	end 
	--------------------------�����������---------------
	select @RowCounts_yestoday=RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='''+@DataBase_Name+''' and Table_Name='''+@Table_Name+''' and DataBase_IP_Romote='''+@DataBase_IP_Romote+''' and CountDate='''+@yestoday+'''
	if(@RowCounts_yestoday is null)
	begin
		set @RowCounts_yestoday=@RowCounts_new
	end 
	set @RowCounts_Increasing_new=@RowCounts_new-@RowCounts_yestoday
	set @RowCounts_Increasing_Rate_new =(@RowCounts_Increasing_new*100*1.00)/(case @RowCounts_yestoday when 0 then @RowCounts_new else @RowCounts_yestoday end )*1.00
	-----------------------------------------------------
	--------------------------�����������---------------
	select @RowCounts_lastweek=(select top 1 RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='''+@DataBase_Name+''' and Table_Name='''+@Table_Name+''' and DataBase_IP_Romote='''+@DataBase_IP_Romote+''' and CountDate>='''+@lastweek+''' and CountDate!='''+@today+''' order by CountDate asc)
	if(@RowCounts_lastweek is null)
	begin
		set @RowCounts_lastweek=@RowCounts_new
	end 
	set @RowCounts_Increasing_Week_new=@RowCounts_new-@RowCounts_lastweek
	set @RowCounts_Increasing_Week_Rate_new =(@RowCounts_Increasing_Week_new*100*1.00)/(case @RowCounts_lastweek when 0 then @RowCounts_new else @RowCounts_lastweek end )*1.00
	-----------------------------------------------------
	--------------------------�����������---------------
	select @RowCounts_lastmonth=(select top 1 RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='''+@DataBase_Name+''' and Table_Name='''+@Table_Name+''' and DataBase_IP_Romote='''+@DataBase_IP_Romote+''' and CountDate>='''+@lastmonth+''' and CountDate!='''+@today+''' order by CountDate asc)
	if(@RowCounts_lastmonth is null)
	begin
		set @RowCounts_lastmonth=@RowCounts_new
	end 
	set @RowCounts_Increasing_Month_new=@RowCounts_new-@RowCounts_lastmonth
	set @RowCounts_Increasing_Month_Rate_new =(@RowCounts_Increasing_Month_new*100*1.00)/(case @RowCounts_lastmonth when 0 then @RowCounts_new else @RowCounts_lastmonth end )*1.00
	-----------------------------------------------------
	--------------------------�����������---------------
	select @RowCounts_lastyear=(select top 1 RowCounts from DataBase_Table WITH(NOLOCK) where DataBase_Name='''+@DataBase_Name+''' and Table_Name='''+@Table_Name+''' and DataBase_IP_Romote='''+@DataBase_IP_Romote+''' and CountDate>='''+@lastyear+''' and CountDate!='''+@today+''' order by CountDate asc)
	if(@RowCounts_lastyear is null)
	begin
		set @RowCounts_lastyear=@RowCounts_new
	end 
	set @RowCounts_Increasing_Year_new=@RowCounts_new-@RowCounts_lastyear
	set @RowCounts_Increasing_Year_Rate_new =(@RowCounts_Increasing_Year_new*100*1.00)/(case @RowCounts_lastyear when 0 then @RowCounts_new else @RowCounts_lastyear end )*1.00
	-----------------------------------------------------
	update DataBase_Table SET 
	RowCounts=@RowCounts_new,
	ColumnCounts=@ColumnCounts_new,

	RowCounts_Increasing=isnull(@RowCounts_Increasing_new,0),
	RowCounts_Increasing_Rate=isnull(@RowCounts_Increasing_Rate_new,0),	
	
	RowCounts_Increasing_week=isnull(@RowCounts_Increasing_week_new,0),
	RowCounts_Increasing_week_Rate=isnull(@RowCounts_Increasing_week_Rate_new,0),
	
	RowCounts_Increasing_month=isnull(@RowCounts_Increasing_month_new,0),
	RowCounts_Increasing_month_Rate=isnull(@RowCounts_Increasing_month_Rate_new,0),
		
	RowCounts_Increasing_year=isnull(@RowCounts_Increasing_year_new,0),
	RowCounts_Increasing_year_Rate=isnull(@RowCounts_Increasing_year_Rate_new,0)

	where DataBase_Name='''+@DataBase_Name+''' and Table_Name='''+@Table_Name+''' and DataBase_IP_Romote='''+@DataBase_IP_Romote+''' and CountDate='''+@today+''' 

	')
	-----------------------------------------------------------------------------------------------------------------
 	END

	FETCH NEXT FROM  contact_cursor INTO  @DataBase_Name, @Table_Name, @CountDate, @DataBase_IP_Romote
END

CLOSE contact_cursor
DEALLOCATE contact_cursor
 
 
 
 
END
 


GO

/****** Object:  StoredProcedure [dbo].[SP_Update_Data]    Script Date: 2018/11/30 9:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



 
CREATE PROCEDURE [dbo].[SP_Update_Data]
	 
AS
BEGIN
SET NOCOUNT ON;
------------------------------
UPDATE Server_Update_Log
SET Server_Update_Log.username = Admin_WebManager.WebManager_name
FROM Admin_WebManager
WHERE Server_Update_Log.ip = Admin_WebManager.WebManager_ip
AND (Server_Update_Log.username IS NULL
OR Server_Update_Log.username = '')
AND (Server_Update_Log.ip IS NOT NULL
AND Server_Update_Log.ip <> '')
-------------------------------
UPDATE Server_Update_Password
SET Server_Update_Password.create_username = Admin_WebManager.WebManager_name
FROM Admin_WebManager
WHERE Server_Update_Password.create_ip = Admin_WebManager.WebManager_ip
AND (Server_Update_Password.create_username IS NULL
OR Server_Update_Password.create_username = '')
AND (Server_Update_Password.create_ip IS NOT NULL
AND Server_Update_Password.create_ip <> '')
--------------------------------
UPDATE Server_Update_Password
SET Server_Update_Password.decrypt_username = Admin_WebManager.WebManager_name
FROM Admin_WebManager
WHERE Server_Update_Password.decrypt_ip = Admin_WebManager.WebManager_ip
AND (Server_Update_Password.decrypt_username IS NULL
OR Server_Update_Password.decrypt_username = '')
AND (Server_Update_Password.decrypt_ip IS NOT NULL
AND Server_Update_Password.decrypt_ip <> '')
--------------------------------
--update DataBase_ConnectString set DataBase_Connect_Times_Today=0,DataBase_Connect_Times=0
--------------------------------
--select  connectname,count(1) as counts into #temp
--from DataBase_Connect_Log group by connectname
--update DataBase_ConnectString set DataBase_Connect_Times=counts
--from #temp where #temp.connectname=DataBase_ConnectString_Name
--DROP table #temp 
---------------------------------
--declare @date varchar(100)
--SET @date = (SELECT CONVERT(VARCHAR(100), GETDATE(), 23))
 
--select  connectname,count(1) as counts into #temp1
--from DataBase_Connect_Log 
--where connectime>@date and connectime<@date+' 23:59:59'
--group by connectname
--update DataBase_ConnectString set DataBase_Connect_Times_Today=counts
--from #temp1 where #temp1.connectname=DataBase_ConnectString_Name
--DROP table #temp1 
-------------------------ɾ������ҳ���б����Ѿ������ҳ��----------------------
delete from WebSite_My_PageUrl_Ignore where webmanager_name+'_'+pageurl in 
(
select webmanager_name+'_'+pageurl from WebSite_My_PageUrl
)
----------------ɾ������ɾ��Ա������ҳ�桢����ҳ��,SQL������������ݿ��-------------------------------
/*
delete from WebSite_My_PageUrl where webmanager_name not in 
(
	SELECT webmanager_name from Admin_WebManager where WebManager_Status=100
)
delete from WebSite_My_PageUrl_Ignore where webmanager_name not in 
(
	SELECT webmanager_name from Admin_WebManager where WebManager_Status=100
)
delete from DataBase_Sql_My where webmanager_name not in 
(
	SELECT webmanager_name from Admin_WebManager where WebManager_Status=100
)
delete from DataBase_Sql_My_Ignore where webmanager_name not in 
(
	SELECT webmanager_name from Admin_WebManager where WebManager_Status=100
)
delete from DataBase_Table_My where webmanager_name not in 
(
	SELECT webmanager_name from Admin_WebManager where WebManager_Status=100
)

delete from Task where Task_Finished=1 and task_webmanager_name not in 
(
SELECT WebManager_name from Admin_WebManager
)
----ɾ������ɾ��Ա��δ��ɵ�����---
delete from Task where Task_WebManager_name not in 
(
select webmanager_name from Admin_WebManager where WebManager_Status=100
)
and Task_Finished=0*/
-----------------------------------�����ŶӺͷ�������Ϣ----------------------------------------------
--update DataBase_Connect_Log_Stats 
--set DataBase_Connect_Log_Stats.teamname=DataBase_Connect_Log.teamname,DataBase_Connect_Log_Stats.servername=DataBase_Connect_Log.servername
--from DataBase_Connect_Log 
--where DataBase_Connect_Log.pageurl=DataBase_Connect_Log_Stats.pageurl
--and DataBase_Connect_Log_Stats.teamname is null or DataBase_Connect_Log_Stats.servername is NULL
---------------------------��������ҳ��Ĳ�������ʶ���ֻ����Ƿ��Ѿ�����------------------------------
declare @regex varchar(500)
set @regex='(.+?)([^0-9])(13[0-9]|14[0-9]|15[0-9]|17[0-9]|18[0-9])\d{8}([^0-9])'
--------------------------
update WebSite_My_PageUrl set 
WebSite_My_PageUrl.querystring=DataBase_Sql_Connect_Stats.querystring
from DataBase_Sql_Connect_Stats
where WebSite_My_PageUrl.pageurl=DataBase_Sql_Connect_Stats.pageurl and isnull(WebSite_My_PageUrl.querystring,'')='' and isnull(DataBase_Sql_Connect_Stats.querystring,'')<>''
-------------------------
update WebSite_My_PageUrl set 
WebSite_My_PageUrl.form=DataBase_Sql_Connect_Stats.form
from DataBase_Sql_Connect_Stats
where WebSite_My_PageUrl.pageurl=DataBase_Sql_Connect_Stats.pageurl and isnull(WebSite_My_PageUrl.form,'')='' and isnull(DataBase_Sql_Connect_Stats.form,'')<>''

---------------------------
update WebSite_My_PageUrl set querystring_Phone_Encrypt=1,form_Phone_Encrypt=1
--update WebSite_My_PageUrl set querystring_Phone_Encrypt=0 where dbo.regexIsMatch('&'+querystring+'&',@regex,1) =1
--update WebSite_My_PageUrl set form_Phone_Encrypt=0 where dbo.regexIsMatch('&'+form+'&',@regex,1) =1   
-------------------------------���·��������--------------------------------------------
;with T_Article_good as (
select article_id,count(1) as counts from Share_Article_good group by article_id
)
update Share_Article set
Article_good=T_Article_good.counts 
from T_Article_good where T_Article_good.article_id=Share_Article.article_id
--------------------------------------------------------------------------------------------------


declare @today varchar(100)
SET @today = (SELECT CONVERT(VARCHAR(100), GETDATE(), 23))
					
update DataBase_Sql_My set 
DataBase_Sql_My.IsWriteSql=DataBase_Sql_Stats.IsWriteSql,
DataBase_Sql_My.IsRuntimeSql=DataBase_Sql_Stats.IsRuntimeSql,
DataBase_Sql_My.IsWrongDataBaseUser=DataBase_Sql_Stats.IsWrongDataBaseUser,
DataBase_Sql_My.database_ip=DataBase_Sql_Stats.database_ip,
DataBase_Sql_My.database_user=DataBase_Sql_Stats.database_user,
DataBase_Sql_My.database_name=DataBase_Sql_Stats.database_name,
DataBase_Sql_My.Table_Name=DataBase_Sql_Stats.Table_Name,
DataBase_Sql_My.creation_time=DataBase_Sql_Stats.creation_time,
DataBase_Sql_My.last_execution_time=DataBase_Sql_Stats.last_execution_time,	
DataBase_Sql_My.execution_count=DataBase_Sql_Stats.execution_count,
DataBase_Sql_My.total_worker_time=DataBase_Sql_Stats.total_worker_time ,
DataBase_Sql_My.last_worker_time=DataBase_Sql_Stats.last_worker_time ,
DataBase_Sql_My.min_worker_time=DataBase_Sql_Stats.min_worker_time ,
DataBase_Sql_My.max_worker_time=DataBase_Sql_Stats.max_worker_time,
DataBase_Sql_My.total_physical_reads=DataBase_Sql_Stats.total_physical_reads ,
DataBase_Sql_My.last_physical_reads=DataBase_Sql_Stats.last_physical_reads,
DataBase_Sql_My.min_physical_reads=DataBase_Sql_Stats.min_physical_reads ,
DataBase_Sql_My.max_physical_reads=DataBase_Sql_Stats.max_physical_reads ,
DataBase_Sql_My.total_logical_writes=DataBase_Sql_Stats.total_logical_writes ,
DataBase_Sql_My.last_logical_writes=DataBase_Sql_Stats.last_logical_writes,
DataBase_Sql_My.min_logical_writes=DataBase_Sql_Stats.min_logical_writes,
DataBase_Sql_My.max_logical_writes=DataBase_Sql_Stats.max_logical_writes ,
DataBase_Sql_My.total_logical_reads=DataBase_Sql_Stats.total_logical_reads ,
DataBase_Sql_My.last_logical_reads=DataBase_Sql_Stats.last_logical_reads,
DataBase_Sql_My.min_logical_reads=DataBase_Sql_Stats.min_logical_reads ,
DataBase_Sql_My.max_logical_reads=DataBase_Sql_Stats.max_logical_reads ,
DataBase_Sql_My.total_elapsed_time=DataBase_Sql_Stats.total_elapsed_time ,
DataBase_Sql_My.last_elapsed_time=DataBase_Sql_Stats.last_elapsed_time,
DataBase_Sql_My.min_elapsed_time=DataBase_Sql_Stats.min_elapsed_time ,
DataBase_Sql_My.max_elapsed_time=DataBase_Sql_Stats.max_elapsed_time ,
DataBase_Sql_My.total_rows=DataBase_Sql_Stats.total_rows,
DataBase_Sql_My.last_rows=DataBase_Sql_Stats.last_rows,
DataBase_Sql_My.min_rows=DataBase_Sql_Stats.min_rows,
DataBase_Sql_My.max_rows=DataBase_Sql_Stats.max_rows

from DataBase_Sql_Stats 
where DataBase_Sql_My.Sql_Md5=DataBase_Sql_Stats.Sql_Md5
AND (
(DataBase_Sql_Stats.Stats_Date=@today 
and DataBase_Sql_My.last_execution_time<DataBase_Sql_Stats. last_execution_time
and DataBase_Sql_My.last_execution_time is NOT null)

OR (DataBase_Sql_My.last_execution_time is null)
)
----------------------------------------------------------------------------------	 		
update DataBase_Sql_My_Ignore set 
DataBase_Sql_My_Ignore.database_ip=DataBase_Sql_Stats.database_ip,
DataBase_Sql_My_Ignore.database_user=DataBase_Sql_Stats.database_user,
DataBase_Sql_My_Ignore.database_name=DataBase_Sql_Stats.database_name,
DataBase_Sql_My_Ignore.Table_Name=DataBase_Sql_Stats.Table_Name,
DataBase_Sql_My_Ignore.creation_time=DataBase_Sql_Stats.creation_time,
DataBase_Sql_My_Ignore.last_execution_time=DataBase_Sql_Stats.last_execution_time,	
DataBase_Sql_My_Ignore.execution_count=DataBase_Sql_Stats.execution_count,
DataBase_Sql_My_Ignore.total_worker_time=DataBase_Sql_Stats.total_worker_time ,
DataBase_Sql_My_Ignore.last_worker_time=DataBase_Sql_Stats.last_worker_time ,
DataBase_Sql_My_Ignore.min_worker_time=DataBase_Sql_Stats.min_worker_time ,
DataBase_Sql_My_Ignore.max_worker_time=DataBase_Sql_Stats.max_worker_time,
DataBase_Sql_My_Ignore.total_physical_reads=DataBase_Sql_Stats.total_physical_reads ,
DataBase_Sql_My_Ignore.last_physical_reads=DataBase_Sql_Stats.last_physical_reads,
DataBase_Sql_My_Ignore.min_physical_reads=DataBase_Sql_Stats.min_physical_reads ,
DataBase_Sql_My_Ignore.max_physical_reads=DataBase_Sql_Stats.max_physical_reads ,
DataBase_Sql_My_Ignore.total_logical_writes=DataBase_Sql_Stats.total_logical_writes ,
DataBase_Sql_My_Ignore.last_logical_writes=DataBase_Sql_Stats.last_logical_writes,
DataBase_Sql_My_Ignore.min_logical_writes=DataBase_Sql_Stats.min_logical_writes,
DataBase_Sql_My_Ignore.max_logical_writes=DataBase_Sql_Stats.max_logical_writes ,
DataBase_Sql_My_Ignore.total_logical_reads=DataBase_Sql_Stats.total_logical_reads ,
DataBase_Sql_My_Ignore.last_logical_reads=DataBase_Sql_Stats.last_logical_reads,
DataBase_Sql_My_Ignore.min_logical_reads=DataBase_Sql_Stats.min_logical_reads ,
DataBase_Sql_My_Ignore.max_logical_reads=DataBase_Sql_Stats.max_logical_reads ,
DataBase_Sql_My_Ignore.total_elapsed_time=DataBase_Sql_Stats.total_elapsed_time ,
DataBase_Sql_My_Ignore.last_elapsed_time=DataBase_Sql_Stats.last_elapsed_time,
DataBase_Sql_My_Ignore.min_elapsed_time=DataBase_Sql_Stats.min_elapsed_time ,
DataBase_Sql_My_Ignore.max_elapsed_time=DataBase_Sql_Stats.max_elapsed_time ,
DataBase_Sql_My_Ignore.total_rows=DataBase_Sql_Stats.total_rows,
DataBase_Sql_My_Ignore.last_rows=DataBase_Sql_Stats.last_rows,
DataBase_Sql_My_Ignore.min_rows=DataBase_Sql_Stats.min_rows,
DataBase_Sql_My_Ignore.max_rows=DataBase_Sql_Stats.max_rows

from DataBase_Sql_Stats 
where DataBase_Sql_My_Ignore.Sql_Md5=DataBase_Sql_Stats.Sql_Md5
AND (
(DataBase_Sql_Stats.Stats_Date=@today 
and DataBase_Sql_My_Ignore.last_execution_time<DataBase_Sql_Stats. last_execution_time
and DataBase_Sql_My_Ignore.last_execution_time is NOT null)

OR (DataBase_Sql_My_Ignore.last_execution_time is null)
)
----------------------------------------------------------------------------------
END
 


GO

/****** Object:  StoredProcedure [dbo].[SP_Update_Data_1day]    Script Date: 2018/11/30 9:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



  
 
CREATE PROCEDURE [dbo].[SP_Update_Data_1day]
	 
AS
BEGIN
SET NOCOUNT ON;
------------------------------ 
--update Admin_WebManager set WebManager_IP=null
----------------ɾ����365��ǰ�ķ��������¼----------------------------------
delete from [Share_View] 
where [View_Time]<   CONVERT(varchar(100), Dateadd(day,-365,getdate()) , 23)
----------------ɾ����60��ǰ�Ĺ���Ա��־----------------------------------
delete from [Admin_Log] 
where [AddedTime]<   CONVERT(varchar(100), Dateadd(day,-60,getdate()) , 23)
----------------ɾ����60��ǰ��[SVN_Log]----------------------------------
delete from [SVN_Log] 
where [Commit_Time]<   CONVERT(varchar(100), Dateadd(day,-60,getdate()) , 23)
----------------ɾ����15��ǰ�Ļ�������������----------------------------------
delete from [Memcache_Stats] 
where Stats_Date<CONVERT(varchar(100), Dateadd(day,-7,getdate()) , 23)
delete from [Memcache_Hits] 
where Stats_Date<CONVERT(varchar(100), Dateadd(day,-7,getdate()) , 23)
----------------ɾ����30��ǰ���͵��ʼ�����----------------------------------
delete from [DataBase_Sql_SendEmail] 
where Stats_Date<CONVERT(varchar(100), Dateadd(day,-30,getdate()) , 23)
--------------------ɾ����30��ǰDataBase_Table]����--------------
delete from [DataBase_Table] 
where CreateTime<CONVERT(varchar(100), Dateadd(day,-30,getdate()) , 23)
--------------------ɾ����30��ǰ[DataBase_Missing_Index]����-------
delete from DataBase_Missing_Index 
where CreateTime<CONVERT(varchar(100), Dateadd(day,-10,getdate()) , 23)
--------------------ɾ����30��ǰ[DataBase_Table_Index]����-------
delete from DataBase_Table_Index 
where CreateTime<CONVERT(varchar(100), Dateadd(day,-10,getdate()) , 23)
--------------------ɾ����7��ǰ[TuanTaskAutoRun]����-------
delete from TuanTaskAutoRun 
where createdate<CONVERT(varchar(100), Dateadd(day,-7,getdate()) , 23)
-----------------------------------------------------------------------
delete from [DataBase_Sql_SendEmail_WrongDataBaseUser] 
where Stats_Date<CONVERT(varchar(100), Dateadd(day,-20,getdate()) , 23)
----------------ɾ��������ͺ��Գ���30��δִ�е�SQL-------------------------------
delete from DataBase_Sql_My where last_execution_time<CONVERT(VARCHAR(100),DATEADD(month,-1,GetDate()), 23) 
delete from DataBase_Sql_My_Ignore where last_execution_time<CONVERT(VARCHAR(100),DATEADD(month,-1,GetDate()), 23) 
----------------ֻ����20w������-----------------
--select top 200000 id into #temp2 from DataBase_Connect_Log order by id desc
--delete from DataBase_Connect_Log where id< (select isnull(min(id),0) from #temp2)
--DROP table #temp2 
----------------ɾ����2��ǰ����-----------------
--delete from DataBase_Connect_Log 
--where createtime<CONVERT(varchar(100), Dateadd(day,-2,getdate()) , 23)
--------
delete from Log_Business 
where createtime<CONVERT(varchar(100), Dateadd(day,-2,getdate()) , 23)
--------
delete from Log_Error 
where createtime<CONVERT(varchar(100), Dateadd(day,-2,getdate()) , 23)

---------------ɾ��15��ǰ��ͳ������----------------
--delete from DataBase_Connect_Log_Stats where connect_Date<Dateadd(day,-7,getdate()) 
delete from Log_Stats where log_date<Dateadd(day,-7,getdate()) 
delete from WebSite_Depend where Stats_date<Dateadd(day,-30,getdate()) 
-------------------------------ɾ��10��ǰ������-----------------------------------
delete from Task where Task_Finished=0 and Task_CreateTime<Dateadd(day,-10,getdate()) 
-------------------------------ɾ��7��ǰ��JOB-----------------------------------
delete from job_log where run_date<replace(CONVERT(VARCHAR(100),Dateadd(day,-4,GETDATE()) , 23),'-','')
-------------------------------ɾ��11ǰ�����ݿ�����ͳ������-----------------------------------
delete from DataBase_Sql_Connect_Log where ExecutionTime<Dateadd(day,-11,getdate()) 
delete from DataBase_Sql_Connect_Stats where STATS_DATE<Dateadd(day,-11,getdate())  
------------------------------------����WebSite_PageUrl����------------------------------------------
TRUNCATE Table WebSite_PageUrl
INSERT INTO WebSite_PageUrl (PageUrl)
	SELECT DISTINCT	PageUrl	FROM (
	SELECT DISTINCT	PageUrl FROM DataBase_Sql_Connect_Stats  UNION 
	SELECT DISTINCT	PageUrl	FROM Log_Stats UNION
	SELECT DISTINCT	PageUrl	FROM Log_Error UNION 
	SELECT DISTINCT PageUrl	FROM Log_Business UNION
	SELECT DISTINCT PageUrl	FROM WebSite_My_PageUrl UNION
	SELECT DISTINCT	PageUrl	FROM WebSite_My_PageUrl_Ignore UNION
	SELECT DISTINCT	PageUrl	FROM WebSite_Depend UNION
	SELECT DISTINCT	Depend_PageUrl AS PageUrl FROM WebSite_Depend UNION
	SELECT DISTINCT PageUrl FROM Memcache_Hits where Stats_Date= Dateadd(day,-1,CONVERT(VARCHAR(100), GETDATE(), 23)) 

	) WebSite_PageUrl  WHERE PageUrl LIKE 'h%'
------------------
DELETE FROM WebSite_PageUrl WHERE  pageurl  like '%\%%' escape '\' or PageUrl  like '%=%' or PageUrl  like '%?%'
----------------------------------����������ص�����----------------------------
TRUNCATE TABLE WebSite_My_Domain
INSERT INTO WebSite_My_Domain (WebManager_name, Domain_Name, CreateTime)
	SELECT DISTINCT
		[WebManager_name],
		SUBSTRING(pageurl, 1, CHARINDEX('/', REPLACE(REPLACE(pageurl, 'http://', ''), 'https://', '') + '/') + 6),
		GETDATE()
	FROM [WebSite_My_PageUrl]	
------------------------------------------------------------------------------

END 


GO

/****** Object:  StoredProcedure [dbo].[SP_Update_WebSite_Log_From_LogDataBase]    Script Date: 2018/11/30 9:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





 
CREATE PROCEDURE [dbo].[SP_Update_WebSite_Log_From_LogDataBase]
	 
AS
BEGIN
	DECLARE @Today varchar(100)
	DECLARE @teamname1 varchar(100),@teamname2 varchar(100),@teamname3 varchar(100),@teamname4 varchar(100),@teamname5 varchar(100),@teamname6 varchar(100),@teamname7 varchar(100),@teamname8 varchar(100)
	DECLARE @servername1 varchar(100),@servername2 varchar(100),@servername3 varchar(100),@servername4 varchar(100),@servername5 varchar(100),@servername6 varchar(100),@servername7 varchar(100),@servername8 varchar(100)
	DECLARE @tablename1 varchar(100),@tablename2 varchar(100),@tablename3 varchar(100),@tablename4 varchar(100),@tablename5 varchar(100),@tablename6 varchar(100),@tablename7 varchar(100),@tablename8 varchar(100)
	select @Today=CONVERT(varchar(100), Dateadd(day,0,getdate()) , 23)
	print @Today
	SET @teamname1='channelsales'
	SET @servername1='[124.251.44.233].xft_login_log.dbo.channel_log'
	SET @tablename1='Log_Error'
	SET @teamname2='channelsales'
	SET @servername2='[124.251.44.233].xft_login_log.dbo.channel_business_log'
	SET @tablename2='Log_Business'
	SET @teamname3='channelsales'
	SET @servername3='[124.251.44.233].xft_login_log.dbo.api_channel_log'
	SET @tablename3='Log_Error'
	SET @teamname4='channelsales'
	SET @servername4='[124.251.44.233].xft_login_log.dbo.api_business_channel_log'
	SET @tablename4='Log_Business'
	 
	SET @teamname5='channelsales'
	SET @servername5='[124.251.46.179].channelsales_test.dbo.channel_log'
	SET @tablename5='Log_Error'
	SET @teamname6='channelsales'
	SET @servername6='[124.251.46.179].channelsales_test.dbo.channel_business_log'
	SET @tablename6='Log_Business'
	SET @teamname7='channelsales'
	SET @servername7='[124.251.46.179].channelsales_test.dbo.api_channel_log'
	SET @tablename7='Log_Error'
	SET @teamname8='channelsales'
	SET @servername8='[124.251.46.179].channelsales_test.dbo.api_business_channel_log'
	SET @tablename8='Log_Business'
	
	DECLARE @i int
	SET @i=1
	WHILE(@i<=8)
	BEGIN   
		DECLARE @i_str VARCHAR(2);
		DECLARE @teamname varchar(100),@servername varchar(100),@tablename varchar(100)
		SELECT @i_str=CAST(@i as VARCHAR(2));
		if(@i=1)
		BEGIN
			SET @teamname=@teamname1;SET @servername=@servername1;SET @tablename=@tablename1;
		END
		ELSE IF(@i=2)
		BEGIN
			SET @teamname=@teamname2;SET @servername=@servername2;SET @tablename=@tablename2;
		END
		ELSE IF(@i=3)
		BEGIN
			SET @teamname=@teamname3;SET @servername=@servername3;SET @tablename=@tablename3;
		END
		ELSE IF(@i=4)
		BEGIN
			SET @teamname=@teamname4;SET @servername=@servername4;SET @tablename=@tablename4;
		END
		ELSE IF(@i=5)
		BEGIN
			SET @teamname=@teamname5;SET @servername=@servername5;SET @tablename=@tablename5;
		END
		ELSE IF(@i=6)
		BEGIN
			SET @teamname=@teamname6;SET @servername=@servername6;SET @tablename=@tablename6;
		END
		ELSE IF(@i=7)
		BEGIN
			SET @teamname=@teamname7;SET @servername=@servername7;SET @tablename=@tablename7;
		END
		ELSE IF(@i=8)
		BEGIN
			SET @teamname=@teamname8;SET @servername=@servername8;SET @tablename=@tablename8;
		END

		EXEC('
			DECLARE @max_createtime_teamtool datetime 			
			-------------------------
			SELECT	@max_createtime_teamtool = ISNULL((SELECT
			MAX(createtime)
			FROM TeamTool..'+@tablename+'  WITH(NOLOCK) where servername='''+@servername+''' and teamname='''+@teamname+'''), '''+@Today+' 00:00:00'')
			-------------------------
			INSERT INTO TeamTool..'+@tablename+' 
			(CreateTime, Title, LogLevel, Content, IP, UserName, ReMarks, ClassName, MethodName, pageurl,PageUrl_Regex, teamname, servername)
			SELECT TOP 500
			CreateTime, Title, LogLevel, Content, IP, UserName, ReMarks, ClassName, MethodName, pageurl,''http://(www.)?[a-z0-9\.]+''+ SUBSTRING(PageUrl,  charindex(''/'',replace(replace(PageUrl,''http://'',''''),''https://'','''') )+7,5000), '''+@teamname+''','''+@servername+'''
			FROM '+@servername+' WITH(NOLOCK)
			WHERE createtime > @max_createtime_teamtool
			ORDER BY createtime ASC
			-------------------------
			--SELECT @max_createtime_teamtool = ISNULL((SELECT
			--MAX(createtime)
			--FROM TeamTool..'+@tablename+'  WITH(NOLOCK) where servername='''+@servername+''' and teamname='''+@teamname+'''), ''1900-1-1'')
			--DELETE FROM '+@servername+'
			--WHERE createtime <= @max_createtime_teamtool
		');
		SET @i=@i+1
	END
END



GO

/****** Object:  StoredProcedure [dbo].[SP_WebSite_Log_Stats]    Script Date: 2018/11/30 9:55:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_WebSite_Log_Stats] 
AS
BEGIN
SET NOCOUNT ON;
-------------------
DECLARE @i int
SET @i=0
WHILE(@i<=1)
	BEGIN 
		DECLARE @i_str VARCHAR(2),@tablename VARCHAR(50);
		SELECT @i_str=CAST(@i as VARCHAR(2));  
		IF(@i=0)
			BEGIN
				SET @tablename='Log_Error';
			END
		ELSE IF(@i=1)
			BEGIN
				SET @tablename='Log_Business';
			END
		EXEC('
			DECLARE @date VARCHAR(100)
			SET @date = (SELECT	CONVERT(VARCHAR(100), GETDATE(), 23))
			delete from Log_Stats where log_date=@date + '' 00:00:00'' and log_type='+@i_str+'
			insert into Log_Stats(pageurl, PageUrl_Regex, log_type, log_date, log_count, createtime,teamname)
			SELECT
				pageurl,
				''http://(www.)?[a-z0-9\.]+''+ SUBSTRING(PageUrl,  charindex(''/'',replace(replace(PageUrl,''http://'',''''),''https://'','''') )+7,5000),
				'+@i_str+' as log_type,				
				CONVERT(VARCHAR(100), CreateTime, 23) as log_date,
				COUNT(1) AS log_count,
				GETDATE() as createtime,
				teamname
			FROM '+@tablename+'
			WHERE CreateTime >= @date + '' 00:00:00''
			AND CreateTime <= @date + '' 23:59:59''
			AND PAGEURL IS NOT NULL
			GROUP BY pageurl,CONVERT(VARCHAR(100), CreateTime, 23),teamname
			ORDER BY log_count DESC
			')
			SET @i=@i+1;
	END
	---------------------------�������µı�����־------------------------------
	 UPDATE Log_Stats SET 
	 Log_Stats.Content=(select Content from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.ReMarks=(select ReMarks from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.Error_CreateTime=(select CreateTime from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.Title=(select Title from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.IP=(select IP from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.username=(select username from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.classname=(select classname from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.MethodName=(select MethodName from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) )),
	 Log_Stats.loglevel=(select loglevel from Log_Error where id=(select max(id) from Log_Error where Log_Error.pageurl=Log_Stats.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) ))
	 FROM Log_Error 
	 WHERE Log_Stats.pageurl=Log_Error.pageurl and Log_Error.CreateTime>=Dateadd(day,-1, GETDATE()) 
	---------------------------������־ͳ�Ʊ���ʶ���ֻ����Ƿ��Ѿ�����------------------------------
	DECLARE @regex VARCHAR(500)
	SET @regex='(.+?)([^0-9])(13[0-9]|14[0-9]|15[0-9]|17[0-9]|18[0-9])\d{8}([^0-9])'
	-----------------------
	UPDATE Log_Stats SET 
	Log_Stats.querystring=DataBase_Sql_Connect_Stats.querystring,
	Log_Stats.form=DataBase_Sql_Connect_Stats.form
	FROM DataBase_Sql_Connect_Stats
	WHERE Log_Stats.pageurl=DataBase_Sql_Connect_Stats.pageurl
	--------------------------
	UPDATE Log_Stats SET querystring_Phone_Encrypt=1,form_Phone_Encrypt=1
	UPDATE Log_Stats SET querystring_Phone_Encrypt=0 WHERE dbo.regexIsMatch('&'+querystring+'&',@regex,1) =1
	UPDATE Log_Stats SET form_Phone_Encrypt=0 WHERE dbo.regexIsMatch('&'+form+'&',@regex,1) =1    
END
 


GO


