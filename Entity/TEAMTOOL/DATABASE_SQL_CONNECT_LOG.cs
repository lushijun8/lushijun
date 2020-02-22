using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_SQL_CONNECT_LOG"
    /// Columns="ID,PAGEURLORFUNCTION,SESSIONID,SQL_MD5,DATABASE_IP,DATABASE_NAME,DATABASE_USER,SERVERINFO,EXECUTIONTIME,EXECUTIONTIME_END,DURATION,CREATETIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class DATABASE_SQL_CONNECT_LOG : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/7/22 19:01:01
        #region 属性
        /// <summary>
        /// 自增ID  BIGINT(8) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public long ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 自增ID  BIGINT(8) 自增列 NOT NULL
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
        /// URL或者函数名  VARCHAR(1000)  NULL
        /// </summary>
        public string PAGEURLORFUNCTION
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
        /// 请求参数  NVARCHAR(-1)  NULL
        /// </summary>
        public string QUERYSTRING
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
        /// 请求Form参数  NVARCHAR(-1)  NULL
        /// </summary>
        public string FORM
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
        /// 用于标识是不是本次访问  VARCHAR(200)  NULL
        /// </summary>
        public string SESSIONID
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
        /// SQL的md5加密串  VARCHAR(100)  NULL
        /// </summary>
        public string SQL_MD5
        {
            get
            {
                return ColumnValues[5];
            }
            set
            {
                ColumnValues[5] = value; UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 访问的数据库IP  VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_IP
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
        /// 数据库名称  VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_NAME
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
        /// 数据库用户名  VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_USER
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
        /// Web服务器信息  VARCHAR(200)  NULL
        /// </summary>
        public string SERVERINFO
        {
            get
            {
                return ColumnValues[9];
            }
            set
            {
                ColumnValues[9] = value; UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// SQL开始执行时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EXECUTIONTIME_ToString 更加准确
        /// </summary>
        public DateTime EXECUTIONTIME
        {
            set
            {
                ColumnValues[10] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// SQL开始执行时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EXECUTIONTIME
        /// </summary>
        public string EXECUTIONTIME_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// SQL执行结束时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EXECUTIONTIME_END_ToString 更加准确
        /// </summary>
        public DateTime EXECUTIONTIME_END
        {
            set
            {
                ColumnValues[11] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// SQL执行结束时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EXECUTIONTIME_END
        /// </summary>
        public string EXECUTIONTIME_END_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// SQL执行总耗时(毫秒)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_ToString 更加准确
        /// </summary>
        public long DURATION
        {
            set
            {
                ColumnValues[12] = value.ToString(); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// SQL执行总耗时(毫秒)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION
        /// </summary>
        public string DURATION_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[13] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 自增ID 返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// URL或者函数名 返回 "PAGEURLORFUNCTION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURLORFUNCTION = "PAGEURLORFUNCTION";
        /// <summary>
        /// 请求参数 返回 "QUERYSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING = "QUERYSTRING";
        /// <summary>
        /// 请求Form参数 返回 "FORM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM = "FORM";
        /// <summary>
        /// 用于标识是不是本次访问 返回 "SESSIONID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SESSIONID = "SESSIONID";
        /// <summary>
        /// SQL的md5加密串 返回 "SQL_MD5", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SQL_MD5 = "SQL_MD5";
        /// <summary>
        /// 访问的数据库IP 返回 "DATABASE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP = "DATABASE_IP";
        /// <summary>
        /// 数据库名称 返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 数据库用户名 返回 "DATABASE_USER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_USER = "DATABASE_USER";
        /// <summary>
        /// Web服务器信息 返回 "SERVERINFO", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SERVERINFO = "SERVERINFO";
        /// <summary>
        /// SQL开始执行时间 返回 "EXECUTIONTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EXECUTIONTIME = "EXECUTIONTIME";
        /// <summary>
        /// SQL执行结束时间 返回 "EXECUTIONTIME_END", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EXECUTIONTIME_END = "EXECUTIONTIME_END";
        /// <summary>
        /// SQL执行总耗时(毫秒) 返回 "DURATION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION = "DURATION";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_SQL_CONNECT_LOG的构造函数
        /// </summary>
        public DATABASE_SQL_CONNECT_LOG()
        {
            this.TableName = "DATABASE_SQL_CONNECT_LOG";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _PAGEURLORFUNCTION, _QUERYSTRING, _FORM, _SESSIONID, _SQL_MD5, _DATABASE_IP, _DATABASE_NAME, _DATABASE_USER, _SERVERINFO, _EXECUTIONTIME, _EXECUTIONTIME_END, _DURATION, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_SQL_CONNECT_LOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, NVARCHAR, NVARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, DATETIME, DATETIME, BIGINT, DATETIME };
                this.Lengths = new int[] { 8, 1000, -1, -1, 200, 100, 100, 100, 100, 200, 8, 8, 8, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "自增ID", "URL或者函数名", "请求参数", "请求Form参数", "用于标识是不是本次访问", "SQL的md5加密串", "访问的数据库IP", "数据库名称", "数据库用户名", "Web服务器信息", "SQL开始执行时间", "SQL执行结束时间", "SQL执行总耗时(毫秒)", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID">自增ID</param>
                /// <returns>bool</returns>
                public bool Find(long P_ID)
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
                /// 深度拷贝DATABASE_SQL_CONNECT_LOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_SQL_CONNECT_LOG Copy()
                {
                    DATABASE_SQL_CONNECT_LOG new_obj=new DATABASE_SQL_CONNECT_LOG();
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

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[DATABASE_SQL_CONNECT_LOG](
                 [ID] [BIGINT]  IDENTITY(1,1)  NOT NULL ,
                 [PAGEURLORFUNCTION] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [QUERYSTRING] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [FORM] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SESSIONID] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SQL_MD5] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IP] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_NAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_USER] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SERVERINFO] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [EXECUTIONTIME] [DATETIME]  NULL ,
                 [EXECUTIONTIME_END] [DATETIME]  NULL ,
                 [DURATION] [BIGINT]  NULL ,
                 [CREATETIME] [DATETIME]  NULL ,
                
                CONSTRAINT [PK_DATABASE_SQL_CONNECT_LOG] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL或者函数名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'PAGEURLORFUNCTION'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'QUERYSTRING'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求Form参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'FORM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用于标识是不是本次访问' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'SESSIONID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL的md5加密串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'SQL_MD5'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问的数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'DATABASE_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'DATABASE_USER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Web服务器信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'SERVERINFO'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL开始执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'EXECUTIONTIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL执行结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'EXECUTIONTIME_END'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL执行总耗时(毫秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'DURATION'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_LOG', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}