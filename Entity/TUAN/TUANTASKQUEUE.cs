using System;

namespace Entity.TUAN
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TUAN" 
    /// Table="TUANTASKQUEUE"
    /// Columns="ID,URL,XML,CREATETIME,CREATOR,STATE,EXECUTEDTIME,CODETYPE,REQUESTURL"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class TUANTASKQUEUE : Entity.TUAN.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/12/2 11:47:05
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
        /// 任务请求地址  NVARCHAR(3600)  NOT NULL
        /// </summary>
        public string URL
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
        /// 返回xml  TEXT(16)  NULL
        /// </summary>
        public string XML
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
        /// 创建时间  DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[3] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 创建人  NVARCHAR(100)  NULL
        /// </summary>
        public string CREATOR
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
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int STATE
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATE
        ///	默认值:0
        /// </summary>
        public string STATE_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 执行时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EXECUTEDTIME_ToString 更加准确
        /// </summary>
        public DateTime EXECUTEDTIME
        {
            set
            {
                ColumnValues[6] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 执行时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EXECUTEDTIME
        /// </summary>
        public string EXECUTEDTIME_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 0=gb2312编码，1-utf8  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CODETYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int CODETYPE
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 0=gb2312编码，1-utf8  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 CODETYPE
        ///	默认值:0
        /// </summary>
        public string CODETYPE_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 发起页面url  NVARCHAR(3000)  NULL
        /// </summary>
        public string REQUESTURL
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 任务请求地址 返回 "URL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _URL = "URL";
        /// <summary>
        /// 返回xml 返回 "XML", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _XML = "XML";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 创建人 返回 "CREATOR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATOR = "CREATOR";
        /// <summary>
        ///   返回 "STATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATE = "STATE";
        /// <summary>
        /// 执行时间 返回 "EXECUTEDTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EXECUTEDTIME = "EXECUTEDTIME";
        /// <summary>
        /// 0=gb2312编码，1-utf8 返回 "CODETYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CODETYPE = "CODETYPE";
        /// <summary>
        /// 发起页面url 返回 "REQUESTURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REQUESTURL = "REQUESTURL";

        #endregion
        #region 函数
        /// <summary>
        /// TUANTASKQUEUE的构造函数
        /// </summary>
        public TUANTASKQUEUE()
        {
            this.TableName = "TUANTASKQUEUE";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _URL, _XML, _CREATETIME, _CREATOR, _STATE, _EXECUTEDTIME, _CODETYPE, _REQUESTURL };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表TUANTASKQUEUE的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, NVARCHAR, TEXT, DATETIME, NVARCHAR, INT, DATETIME, INT, NVARCHAR };
                this.Lengths = new int[] { 8, 3600, 16, 8, 100, 4, 8, 4, 3000 };
                this.IsNullables = new int[] { 0, 0, 1, 0, 1, 0, 1, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", "getdate", " ", "0", " ", "0", " " };
                this.Descriptions = new string[] { " ", "任务请求地址", "返回xml", "创建时间", "创建人", " ", "执行时间", "0=gb2312编码，1-utf8", "发起页面url" };
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
                /// 深度拷贝TUANTASKQUEUE（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public TUANTASKQUEUE Copy()
                {
                    TUANTASKQUEUE new_obj=new TUANTASKQUEUE();
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
                 				
                CREATE TABLE [dbo].[TUANTASKQUEUE](
                 [ID] [BIGINT]  IDENTITY(1,1)  NOT NULL ,
                 [URL] [NVARCHAR]  (1800)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [XML] [TEXT]  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NOT NULL  CONSTRAINT [DF_TUANTASKQUEUE_CREATETIME] DEFAULT ('getdate') ,
                 [CREATOR] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [STATE] [INT]  NOT NULL  CONSTRAINT [DF_TUANTASKQUEUE_STATE] DEFAULT ('0') ,
                 [EXECUTEDTIME] [DATETIME]  NULL ,
                 [CODETYPE] [INT]  NOT NULL  CONSTRAINT [DF_TUANTASKQUEUE_CODETYPE] DEFAULT ('0') ,
                 [REQUESTURL] [NVARCHAR]  (1500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                
                CONSTRAINT [PK_TUANTASKQUEUE] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务请求地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKQUEUE', @level2type=N'COLUMN',@level2name=N'URL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回xml' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKQUEUE', @level2type=N'COLUMN',@level2name=N'XML'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKQUEUE', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKQUEUE', @level2type=N'COLUMN',@level2name=N'CREATOR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKQUEUE', @level2type=N'COLUMN',@level2name=N'EXECUTEDTIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=gb2312编码，1-utf8' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKQUEUE', @level2type=N'COLUMN',@level2name=N'CODETYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发起页面url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKQUEUE', @level2type=N'COLUMN',@level2name=N'REQUESTURL'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}