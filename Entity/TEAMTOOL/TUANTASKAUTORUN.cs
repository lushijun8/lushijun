using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="TUANTASKAUTORUN"
    /// Columns="CREATEDATE,DATABASE_NAME,ID,NAME,PATH,RUNTYPE,RUNMINITEOF,RUNTIMEAT,AUTHOR,LASTRUNTIME,ISOPEN,TASKDETAIL,ISRUNNING,SVNSOURCECODE,CREATETIME,KILLAPP,LOGTXT,LOGCOUNT,LOGLENGTH,CONFIG,CFGFILES"
    /// PrimaryKeys="CREATEDATE,DATABASE_NAME,ID"
    /// </summary>
    public sealed class TUANTASKAUTORUN : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2017/12/27 15:49:57
        #region 属性
        /// <summary>
        ///   DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATEDATE_ToString 更加准确
        ///	主健之一，其他主健还有：CREATEDATE,DATABASE_NAME,ID
        /// </summary>
        public DateTime CREATEDATE
        {
            set
            {
                ColumnValues[0] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATEDATE
        ///	主健之一，其他主健还有：CREATEDATE,DATABASE_NAME,ID
        /// </summary>
        public string CREATEDATE_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    NVARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：CREATEDATE,DATABASE_NAME,ID
        /// </summary>
        public string DATABASE_NAME
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
        ///    NVARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：CREATEDATE,DATABASE_NAME,ID
        /// </summary>
        public string ID
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
        ///    NVARCHAR(200)  NULL
        /// </summary>
        public string NAME
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
        ///    NVARCHAR(300)  NULL
        /// </summary>
        public string PATH
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
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RUNTYPE_ToString 更加准确
        /// </summary>
        public int RUNTYPE
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RUNTYPE
        /// </summary>
        public string RUNTYPE_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        ///    DECIMAL(9)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RUNMINITEOF_ToString 更加准确
        /// </summary>
        public decimal RUNMINITEOF
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    DECIMAL(9)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RUNMINITEOF
        /// </summary>
        public string RUNMINITEOF_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        ///    TIME(5)  NULL
        /// </summary>
        public string RUNTIMEAT
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
        ///    NVARCHAR(300)  NULL
        /// </summary>
        public string AUTHOR
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
        ///    DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LASTRUNTIME_ToString 更加准确
        /// </summary>
        public DateTime LASTRUNTIME
        {
            set
            {
                ColumnValues[9] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LASTRUNTIME
        /// </summary>
        public string LASTRUNTIME_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ISOPEN_ToString 更加准确
        /// </summary>
        public int ISOPEN
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ISOPEN
        /// </summary>
        public string ISOPEN_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        ///    VARCHAR(500)  NULL
        /// </summary>
        public string TASKDETAIL
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
        ///    BIT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ISRUNNING_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public bool ISRUNNING
        {
            set
            {
                ColumnValues[12] = (value == true ? "1" : "0");
                UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        ///    BIT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ISRUNNING
        ///	默认值:0
        /// </summary>
        public string ISRUNNING_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 源码SVN地址  NVARCHAR(1000)  NULL
        /// </summary>
        public string SVNSOURCECODE
        {
            get
            {
                return ColumnValues[13];
            }
            set
            {
                ColumnValues[13] = value; UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[14] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 是否强制杀死进程，0否，1是  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 KILLAPP_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int KILLAPP
        {
            set
            {
                ColumnValues[15] = value.ToString(); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 是否强制杀死进程，0否，1是  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 KILLAPP
        ///	默认值:0
        /// </summary>
        public string KILLAPP_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        /// 最新执行的日志文件内容  NVARCHAR(-1)  NULL
        /// </summary>
        public string LOGTXT
        {
            get
            {
                return ColumnValues[16];
            }
            set
            {
                ColumnValues[16] = value; UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOGCOUNT_ToString 更加准确
        /// </summary>
        public int LOGCOUNT
        {
            set
            {
                ColumnValues[17] = value.ToString(); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LOGCOUNT
        /// </summary>
        public string LOGCOUNT_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOGLENGTH_ToString 更加准确
        /// </summary>
        public long LOGLENGTH
        {
            set
            {
                ColumnValues[18] = value.ToString(); UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LOGLENGTH
        /// </summary>
        public string LOGLENGTH_ToString
        {
            get
            {
                return ColumnValues[18];
            }
        }
        /// <summary>
        ///    NVARCHAR(-1)  NULL
        /// </summary>
        public string CONFIG
        {
            get
            {
                return ColumnValues[19];
            }
            set
            {
                ColumnValues[19] = value; UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        ///   NVARCHAR(8000)  NULL
        /// </summary>
        public string CFGFILES
        {
            get
            {
                return ColumnValues[20];
            }
            set
            {
                ColumnValues[20] = value; UpdateStatus[20] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "CREATEDATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATEDATE = "CREATEDATE";
        /// <summary>
        ///   返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        ///   返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///   返回 "PATH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PATH = "PATH";
        /// <summary>
        ///   返回 "RUNTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUNTYPE = "RUNTYPE";
        /// <summary>
        ///   返回 "RUNMINITEOF", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUNMINITEOF = "RUNMINITEOF";
        /// <summary>
        ///   返回 "RUNTIMEAT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUNTIMEAT = "RUNTIMEAT";
        /// <summary>
        ///   返回 "AUTHOR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AUTHOR = "AUTHOR";
        /// <summary>
        ///   返回 "LASTRUNTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LASTRUNTIME = "LASTRUNTIME";
        /// <summary>
        ///   返回 "ISOPEN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ISOPEN = "ISOPEN";
        /// <summary>
        ///   返回 "TASKDETAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASKDETAIL = "TASKDETAIL";
        /// <summary>
        ///   返回 "ISRUNNING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ISRUNNING = "ISRUNNING";
        /// <summary>
        /// 源码SVN地址 返回 "SVNSOURCECODE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SVNSOURCECODE = "SVNSOURCECODE";
        /// <summary>
        ///   返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 是否强制杀死进程，0否，1是 返回 "KILLAPP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _KILLAPP = "KILLAPP";
        /// <summary>
        /// 最新执行的日志文件内容 返回 "LOGTXT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOGTXT = "LOGTXT";
        /// <summary>
        ///   返回 "LOGCOUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOGCOUNT = "LOGCOUNT";
        /// <summary>
        ///   返回 "LOGLENGTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOGLENGTH = "LOGLENGTH";
        /// <summary>
        ///   返回 "CONFIG", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONFIG = "CONFIG";
        /// <summary>
        ///  返回 "CFGFILES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CFGFILES = "CFGFILES";

        #endregion
        #region 函数
        /// <summary>
        /// TUANTASKAUTORUN的构造函数
        /// </summary>
        public TUANTASKAUTORUN()
        {
            this.TableName = "TUANTASKAUTORUN";
            this.PrimaryKey = new string[] { _CREATEDATE, _DATABASE_NAME, _ID };

            this.columns = new string[] { _CREATEDATE, _DATABASE_NAME, _ID, _NAME, _PATH, _RUNTYPE, _RUNMINITEOF, _RUNTIMEAT, _AUTHOR, _LASTRUNTIME, _ISOPEN, _TASKDETAIL, _ISRUNNING, _SVNSOURCECODE, _CREATETIME, _KILLAPP, _LOGTXT, _LOGCOUNT, _LOGLENGTH, _CONFIG, _CFGFILES };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表TUANTASKAUTORUN的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { DATETIME, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, INT, DECIMAL, TIME, NVARCHAR, DATETIME, INT, VARCHAR, BIT, NVARCHAR, DATETIME, INT, NVARCHAR, INT, BIGINT, NVARCHAR, NVARCHAR };
                this.Lengths = new int[] { 8, 100, 100, 200, 300, 4, 9, 5, 300, 8, 4, 500, 1, 1000, 8, 4, -1, 4, 8, -1, -1 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "0", " ", "getdate", "0", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "源码SVN地址", " ", "是否强制杀死进程，0否，1是", "最新执行的日志文件内容", " ", " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="CREATEDATE"></param>
        /// <param name="DATABASE_NAME"> </param>
        /// <param name="ID"> </param>
                /// <returns>bool</returns>
                public bool Find(DateTime P_CREATEDATE,string P_DATABASE_NAME,string P_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_CREATEDATE.ToString();
        this.ColumnValues[1]=P_DATABASE_NAME;
        this.ColumnValues[2]=P_ID;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝TUANTASKAUTORUN（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public TUANTASKAUTORUN Copy()
                {
                    TUANTASKAUTORUN new_obj=new TUANTASKAUTORUN();
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
                 				
                CREATE TABLE [dbo].[TUANTASKAUTORUN](
                 [CREATEDATE] [DATETIME]  NOT NULL ,
                 [DATABASE_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [ID] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [NAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [PATH] [NVARCHAR]  (150)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [RUNTYPE] [INT]  NULL ,
                 [RUNMINITEOF] [DECIMAL]  (9)  NULL ,
                 [RUNTIMEAT] [TIME]  (5)  NULL ,
                 [AUTHOR] [NVARCHAR]  (150)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LASTRUNTIME] [DATETIME]  NULL ,
                 [ISOPEN] [INT]  NULL ,
                 [TASKDETAIL] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ISRUNNING] [BIT]  NULL  CONSTRAINT [DF_TUANTASKAUTORUN_ISRUNNING] DEFAULT ('0') ,
                 [SVNSOURCECODE] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_TUANTASKAUTORUN_CREATETIME] DEFAULT ('getdate') ,
                 [KILLAPP] [INT]  NULL  CONSTRAINT [DF_TUANTASKAUTORUN_KILLAPP] DEFAULT ('0') ,
                 [LOGTXT] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LOGCOUNT] [INT]  NULL ,
                 [LOGLENGTH] [BIGINT]  NULL ,
                 [CONFIG] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CFGFILES] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                
                CONSTRAINT [PK_TUANTASKAUTORUN] PRIMARY KEY CLUSTERED 
                (
	             [CREATEDATE] ASC,[DATABASE_NAME] ASC,[ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'源码SVN地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN', @level2type=N'COLUMN',@level2name=N'SVNSOURCECODE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否强制杀死进程，0否，1是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN', @level2type=N'COLUMN',@level2name=N'KILLAPP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最新执行的日志文件内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN', @level2type=N'COLUMN',@level2name=N'LOGTXT'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}