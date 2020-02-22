
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="SERVER_UPDATE_PASSWORD"
    /// Columns="ID,SERVERNAME,CREATE_IP,CREATE_USERNAME,CREATE_PASSWORD,CREATE_TIME,DECRYPT_IP,DECRYPT_USERNAME,DECRYPT_PASSWORD,DECRYPT_TIME,DECRYPT_STATUS,DECRYPT_REMARK,SENDEMAIL"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class SERVER_UPDATE_PASSWORD : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/12/1 11:35:51
        #region 属性
        /// <summary>
        /// ID   INT(4) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// ID   INT(4) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 ID
        ///	唯一主键
        /// </summary>
        public string ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        /// 服务器名称，如：192.168.187.202_api.channelsales.tao.fang.com   NVARCHAR(200)  NULL
        /// </summary>
        public string SERVERNAME
        {
            get
            {
                return ColumnValues[1];
            }
            set
            {
                ColumnValues[1] = value; UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 创建者IP   NVARCHAR(200)  NULL
        /// </summary>
        public string CREATE_IP
        {
            get
            {
                return ColumnValues[2];
            }
            set
            {
                ColumnValues[2] = value; UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 创建者用户名   NVARCHAR(200)  NULL
        /// </summary>
        public string CREATE_USERNAME
        {
            get
            {
                return ColumnValues[3];
            }
            set
            {
                ColumnValues[3] = value; UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 创建的密码   NVARCHAR(200)  NULL
        /// </summary>
        public string CREATE_PASSWORD
        {
            get
            {
                return ColumnValues[4];
            }
            set
            {
                ColumnValues[4] = value; UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATE_TIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATE_TIME
        {
            set
            {
                ColumnValues[5] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATE_TIME
        ///	默认值:getdate
        /// </summary>
        public string CREATE_TIME_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 查看者IP   NVARCHAR(200)  NULL
        /// </summary>
        public string DECRYPT_IP
        {
            get
            {
                return ColumnValues[6];
            }
            set
            {
                ColumnValues[6] = value; UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 查看者用户名  NVARCHAR(200)  NULL
        /// </summary>
        public string DECRYPT_USERNAME
        {
            get
            {
                return ColumnValues[7];
            }
            set
            {
                ColumnValues[7] = value; UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 查看后的密码  NVARCHAR(200)  NULL
        /// </summary>
        public string DECRYPT_PASSWORD
        {
            get
            {
                return ColumnValues[8];
            }
            set
            {
                ColumnValues[8] = value; UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 查看的时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DECRYPT_TIME_ToString 更加准确
        /// </summary>
        public DateTime DECRYPT_TIME
        {
            set
            {
                ColumnValues[9] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 查看的时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DECRYPT_TIME
        /// </summary>
        public string DECRYPT_TIME_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 申请状态：0待审批，1审批通过  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DECRYPT_STATUS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int DECRYPT_STATUS
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 申请状态：0待审批，1审批通过  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DECRYPT_STATUS
        ///	默认值:0
        /// </summary>
        public string DECRYPT_STATUS_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 备注，可以填写本次更新的具体功能和说明  NVARCHAR(8000)  NULL
        /// </summary>
        public string DECRYPT_REMARK
        {
            get
            {
                return ColumnValues[11];
            }
            set
            {
                ColumnValues[11] = value; UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 是否发过邮件  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SENDEMAIL_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int SENDEMAIL
        {
            set
            {
                ColumnValues[12] = value.ToString(); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 是否发过邮件  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SENDEMAIL
        ///	默认值:0
        /// </summary>
        public string SENDEMAIL_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// ID  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 服务器名称，如：192.168.187.202_api.channelsales.tao.fang.com  返回 "SERVERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SERVERNAME = "SERVERNAME";
        /// <summary>
        /// 创建者IP  返回 "CREATE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATE_IP = "CREATE_IP";
        /// <summary>
        /// 创建者用户名  返回 "CREATE_USERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATE_USERNAME = "CREATE_USERNAME";
        /// <summary>
        /// 创建的密码  返回 "CREATE_PASSWORD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATE_PASSWORD = "CREATE_PASSWORD";
        /// <summary>
        /// 创建时间  返回 "CREATE_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATE_TIME = "CREATE_TIME";
        /// <summary>
        /// 查看者IP  返回 "DECRYPT_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECRYPT_IP = "DECRYPT_IP";
        /// <summary>
        /// 查看者用户名 返回 "DECRYPT_USERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECRYPT_USERNAME = "DECRYPT_USERNAME";
        /// <summary>
        /// 查看后的密码 返回 "DECRYPT_PASSWORD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECRYPT_PASSWORD = "DECRYPT_PASSWORD";
        /// <summary>
        /// 查看的时间 返回 "DECRYPT_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECRYPT_TIME = "DECRYPT_TIME";
        /// <summary>
        /// 申请状态：0待审批，1审批通过 返回 "DECRYPT_STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECRYPT_STATUS = "DECRYPT_STATUS";
        /// <summary>
        /// 备注，可以填写本次更新的具体功能和说明 返回 "DECRYPT_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECRYPT_REMARK = "DECRYPT_REMARK";
        /// <summary>
        /// 是否发过邮件 返回 "SENDEMAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SENDEMAIL = "SENDEMAIL";

        #endregion
        #region 函数
        /// <summary>
        /// SERVER_UPDATE_PASSWORD的构造函数
        /// </summary>
        public SERVER_UPDATE_PASSWORD()
        {
            this.TableName = "SERVER_UPDATE_PASSWORD";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _SERVERNAME, _CREATE_IP, _CREATE_USERNAME, _CREATE_PASSWORD, _CREATE_TIME, _DECRYPT_IP, _DECRYPT_USERNAME, _DECRYPT_PASSWORD, _DECRYPT_TIME, _DECRYPT_STATUS, _DECRYPT_REMARK, _SENDEMAIL };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SERVER_UPDATE_PASSWORD的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, DATETIME, NVARCHAR, NVARCHAR, NVARCHAR, DATETIME, INT, NVARCHAR, INT };
                this.Lengths = new int[] { 4, 200, 200, 200, 200, 8, 200, 200, 200, 8, 4, 8000, 4 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", "getdate", " ", " ", " ", " ", "0", " ", "0" };
                this.Descriptions = new string[] { "ID ", "服务器名称，如：192.168.187.202_api.channelsales.tao.fang.com ", "创建者IP ", "创建者用户名 ", "创建的密码 ", "创建时间 ", "查看者IP ", "查看者用户名", "查看后的密码", "查看的时间", "申请状态：0待审批，1审批通过", "备注，可以填写本次更新的具体功能和说明", "是否发过邮件" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID">ID </param>
                /// <returns>bool</returns>
                public bool Find(int P_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝SERVER_UPDATE_PASSWORD（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SERVER_UPDATE_PASSWORD Copy()
                {
                    SERVER_UPDATE_PASSWORD new_obj=new SERVER_UPDATE_PASSWORD();
                    base.CopyObj(new_obj);
                    int columnindex=0;
                    foreach (string column in this.Columns)
                    {
                        new_obj.SetColumnValue(column, this[column],columnindex);
                        columnindex++;
                    }
                    return new_obj;
                }
        */
        #endregion

        #region 实现关联Join方法和属性

        private bool inner_join_admin_webmanager_create_username = false;
        private bool left_join_admin_webmanager_create_username = false;
        private bool inner_join_admin_webmanager_decrypt_username = false;
        private bool left_join_admin_webmanager_decrypt_username = false;


        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.CREATE_USERNAME=SERVER_UPDATE_PASSWORD.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER_CREATE_USERNAME
        {
            set
            {
                this.inner_join_admin_webmanager_create_username = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.CREATE_USERNAME=SERVER_UPDATE_PASSWORD.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER_CREATE_USERNAME
        {
            set
            {
                this.left_join_admin_webmanager_create_username = value;
            }
        }
        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.CREATE_USERNAME=SERVER_UPDATE_PASSWORD.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER_DECRYPT_USERNAME
        {
            set
            {
                this.inner_join_admin_webmanager_decrypt_username = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.CREATE_USERNAME=SERVER_UPDATE_PASSWORD.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER_DECRYPT_USERNAME
        {
            set
            {
                this.left_join_admin_webmanager_decrypt_username = value;
            }
        }
        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_ADMIN_WEBMANAGER
        /// LEFT_JOIN_ADMIN_WEBMANAGER

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_admin_webmanager_create_username == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "CREATE_USERNAME");
            }
            if (this.left_join_admin_webmanager_create_username == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "CREATE_USERNAME");
            }

            if (this.inner_join_admin_webmanager_decrypt_username == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER_DECRYPT_USERNAME", "WEBMANAGER_NAME", "DECRYPT_USERNAME");
            }
            if (this.left_join_admin_webmanager_decrypt_username == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER_DECRYPT_USERNAME", "WEBMANAGER_NAME", "DECRYPT_USERNAME");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion

        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[SERVER_UPDATE_PASSWORD](
                 [ID] [INT]  IDENTITY(1,1)  NOT NULL ,
                 [SERVERNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATE_IP] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATE_USERNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATE_PASSWORD] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATE_TIME] [DATETIME]  NULL  CONSTRAINT [DF_SERVER_UPDATE_PASSWORD_CREATE_TIME] DEFAULT ('getdate') ,
                 [DECRYPT_IP] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DECRYPT_USERNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DECRYPT_PASSWORD] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DECRYPT_TIME] [DATETIME]  NULL ,
                 [DECRYPT_STATUS] [INT]  NULL  CONSTRAINT [DF_SERVER_UPDATE_PASSWORD_DECRYPT_STATUS] DEFAULT ('0') ,
                 [DECRYPT_REMARK] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SENDEMAIL] [INT]  NULL  CONSTRAINT [DF_SERVER_UPDATE_PASSWORD_SENDEMAIL] DEFAULT ('0') ,
                
                CONSTRAINT [PK_SERVER_UPDATE_PASSWORD] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器名称，如：192.168.187.202_api.channelsales.tao.fang.com ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'SERVERNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'CREATE_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者用户名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'CREATE_USERNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建的密码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'CREATE_PASSWORD'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'CREATE_TIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看者IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'DECRYPT_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看者用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'DECRYPT_USERNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看后的密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'DECRYPT_PASSWORD'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看的时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'DECRYPT_TIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请状态：0待审批，1审批通过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'DECRYPT_STATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注，可以填写本次更新的具体功能和说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'DECRYPT_REMARK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否发过邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SERVER_UPDATE_PASSWORD', @level2type=N'COLUMN',@level2name=N'SENDEMAIL'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}