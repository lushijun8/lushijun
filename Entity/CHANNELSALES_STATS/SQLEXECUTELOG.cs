using System;
namespace Entity.CHANNELSALES_STATS
{/// <summary>
	/// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="XFT_LOGIN_LOG" 
	/// Table="SQLEXECUTELOG"
	/// Columns="ID,PAGEURL,SESSIONID,SERVERINFO,SENTENCE,CONNECTIONSTRING,EXECUTIONTIME,EXECUTIONTIME_END,QUERYSTRING,FORM,CREATETIME"
	/// PrimaryKeys="ID"
	/// </summary>
    public sealed class SQLEXECUTELOG : Entity.CHANNELSALES_STATS.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/7/28 11:03:58
        #region 属性
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
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
        ///   BIGINT(8) 自增列 NOT NULL
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
        ///    VARCHAR(500)  NULL
        /// </summary>
        public string PAGEURL
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
        /// SessionID，确定唯一值  VARCHAR(100)  NULL
        /// </summary>
        public string SESSIONID
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
        /// 服务器信息  VARCHAR(200)  NULL
        /// </summary>
        public string SERVERINFO
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
        /// Sql语句  VARCHAR(-1)  NULL
        /// </summary>
        public string SENTENCE
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
        /// 数据库连接串  VARCHAR(500)  NULL
        /// </summary>
        public string CONNECTIONSTRING
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
        /// 执行开始时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EXECUTIONTIME_ToString 更加准确
        /// </summary>
        public DateTime EXECUTIONTIME
        {
            set
            {
                ColumnValues[6] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 执行开始时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EXECUTIONTIME
        /// </summary>
        public string EXECUTIONTIME_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 执行结束时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EXECUTIONTIME_END_ToString 更加准确
        /// </summary>
        public DateTime EXECUTIONTIME_END
        {
            set
            {
                ColumnValues[7] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 执行结束时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EXECUTIONTIME_END
        /// </summary>
        public string EXECUTIONTIME_END_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        ///    NVARCHAR(8000)  NULL
        /// </summary>
        public string QUERYSTRING
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
        ///    NVARCHAR(8000)  NULL
        /// </summary>
        public string FORM
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
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[10] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[10] = 1;
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
                return ColumnValues[10];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// SessionID，确定唯一值 返回 "SESSIONID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SESSIONID = "SESSIONID";
        /// <summary>
        /// 服务器信息 返回 "SERVERINFO", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SERVERINFO = "SERVERINFO";
        /// <summary>
        /// Sql语句 返回 "SENTENCE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SENTENCE = "SENTENCE";
        /// <summary>
        /// 数据库连接串 返回 "CONNECTIONSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING = "CONNECTIONSTRING";
        /// <summary>
        /// 执行开始时间 返回 "EXECUTIONTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EXECUTIONTIME = "EXECUTIONTIME";
        /// <summary>
        /// 执行结束时间 返回 "EXECUTIONTIME_END", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EXECUTIONTIME_END = "EXECUTIONTIME_END";
        /// <summary>
        ///   返回 "QUERYSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING = "QUERYSTRING";
        /// <summary>
        ///   返回 "FORM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM = "FORM";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// SQLEXECUTELOG的构造函数
        /// </summary>
        public SQLEXECUTELOG()
        {
            this.TableName = "SQLEXECUTELOG";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _PAGEURL, _SESSIONID, _SERVERINFO, _SENTENCE, _CONNECTIONSTRING, _EXECUTIONTIME, _EXECUTIONTIME_END, _QUERYSTRING, _FORM, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SQLEXECUTELOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, DATETIME, DATETIME, NVARCHAR, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 8, 500, 100, 200, -1, 500, 8, 8, 8000, 8000, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", "SessionID，确定唯一值", "服务器信息", "Sql语句", "数据库连接串", "执行开始时间", "执行结束时间", " ", " ", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID"></param>
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
                /// 深度拷贝SQLEXECUTELOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SQLEXECUTELOG Copy()
                {
                    SQLEXECUTELOG new_obj=new SQLEXECUTELOG();
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
                 				
                CREATE TABLE [dbo].[SQLEXECUTELOG](
                 [ID] [BIGINT]  IDENTITY(1,1)  NOT NULL ,
                 [PAGEURL] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SESSIONID] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SERVERINFO] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SENTENCE] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CONNECTIONSTRING] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [EXECUTIONTIME] [DATETIME]  NULL ,
                 [EXECUTIONTIME_END] [DATETIME]  NULL ,
                 [QUERYSTRING] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [FORM] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL ,
                
                CONSTRAINT [PK_SQLEXECUTELOG] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SessionID，确定唯一值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SQLEXECUTELOG', @level2type=N'COLUMN',@level2name=N'SESSIONID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SQLEXECUTELOG', @level2type=N'COLUMN',@level2name=N'SERVERINFO'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sql语句' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SQLEXECUTELOG', @level2type=N'COLUMN',@level2name=N'SENTENCE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库连接串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SQLEXECUTELOG', @level2type=N'COLUMN',@level2name=N'CONNECTIONSTRING'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SQLEXECUTELOG', @level2type=N'COLUMN',@level2name=N'EXECUTIONTIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SQLEXECUTELOG', @level2type=N'COLUMN',@level2name=N'EXECUTIONTIME_END'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SQLEXECUTELOG', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}