using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="MEMCACHE_HITS"
    /// Columns="PAGEURL,FUNCTIONNAME,STATS_DATE,CLASSNAME,MEMCACHE_IP,MEMCACHE_PORT,GET_COUNT,GET_MISSES_COUNT,GET_HITS_COUNT,SET_COUNT,SET_MISSES_COUNT,SET_HITS_COUNT,CREATETIME"
    /// PrimaryKeys="PAGEURL,FUNCTIONNAME,STATS_DATE"
    /// </summary>
    public sealed class MEMCACHE_HITS : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/4/27 18:02:56
        #region 属性
        /// <summary>
        /// 网址  VARCHAR(200)  NOT NULL
        ///	主健之一，其他主健还有：PAGEURL,FUNCTIONNAME,STATS_DATE
        /// </summary>
        public string PAGEURL
        {
            get
            {
                return ColumnValues[0];
            }
            set
            {
                ColumnValues[0] = value; UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 命名空间和函数名称  VARCHAR(500)  NOT NULL
        ///	主健之一，其他主健还有：PAGEURL,FUNCTIONNAME,STATS_DATE
        /// </summary>
        public string FUNCTIONNAME
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
        /// 统计日期  DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATS_DATE_ToString 更加准确
        ///	主健之一，其他主健还有：PAGEURL,FUNCTIONNAME,STATS_DATE
        /// </summary>
        public DateTime STATS_DATE
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 统计日期  DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATS_DATE
        ///	主健之一，其他主健还有：PAGEURL,FUNCTIONNAME,STATS_DATE
        /// </summary>
        public string STATS_DATE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 类名称  VARCHAR(200)  NULL
        /// </summary>
        public string CLASSNAME
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
        /// memcached的IP  VARCHAR(20)  NULL
        /// </summary>
        public string MEMCACHE_IP
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
        /// memcached的端口  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MEMCACHE_PORT_ToString 更加准确
        /// </summary>
        public int MEMCACHE_PORT
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// memcached的端口  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 MEMCACHE_PORT
        /// </summary>
        public string MEMCACHE_PORT_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// get总次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 GET_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long GET_COUNT
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// get总次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 GET_COUNT
        ///	默认值:0
        /// </summary>
        public string GET_COUNT_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// get丢失次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 GET_MISSES_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long GET_MISSES_COUNT
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// get丢失次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 GET_MISSES_COUNT
        ///	默认值:0
        /// </summary>
        public string GET_MISSES_COUNT_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// get命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 GET_HITS_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long GET_HITS_COUNT
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// get命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 GET_HITS_COUNT
        ///	默认值:0
        /// </summary>
        public string GET_HITS_COUNT_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// set总次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SET_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long SET_COUNT
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// set总次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SET_COUNT
        ///	默认值:0
        /// </summary>
        public string SET_COUNT_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// set丢失次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SET_MISSES_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long SET_MISSES_COUNT
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// set丢失次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SET_MISSES_COUNT
        ///	默认值:0
        /// </summary>
        public string SET_MISSES_COUNT_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// set命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SET_HITS_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long SET_HITS_COUNT
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// set命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SET_HITS_COUNT
        ///	默认值:0
        /// </summary>
        public string SET_HITS_COUNT_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 更新时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[12] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 更新时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 网址 返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// 命名空间和函数名称 返回 "FUNCTIONNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTIONNAME = "FUNCTIONNAME";
        /// <summary>
        /// 统计日期 返回 "STATS_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATS_DATE = "STATS_DATE";
        /// <summary>
        /// 类名称 返回 "CLASSNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CLASSNAME = "CLASSNAME";
        /// <summary>
        /// memcached的IP 返回 "MEMCACHE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_IP = "MEMCACHE_IP";
        /// <summary>
        /// memcached的端口 返回 "MEMCACHE_PORT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_PORT = "MEMCACHE_PORT";
        /// <summary>
        /// get总次数 返回 "GET_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _GET_COUNT = "GET_COUNT";
        /// <summary>
        /// get丢失次数 返回 "GET_MISSES_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _GET_MISSES_COUNT = "GET_MISSES_COUNT";
        /// <summary>
        /// get命中次数 返回 "GET_HITS_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _GET_HITS_COUNT = "GET_HITS_COUNT";
        /// <summary>
        /// set总次数 返回 "SET_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SET_COUNT = "SET_COUNT";
        /// <summary>
        /// set丢失次数 返回 "SET_MISSES_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SET_MISSES_COUNT = "SET_MISSES_COUNT";
        /// <summary>
        /// set命中次数 返回 "SET_HITS_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SET_HITS_COUNT = "SET_HITS_COUNT";
        /// <summary>
        /// 更新时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// MEMCACHE_HITS的构造函数
        /// </summary>
        public MEMCACHE_HITS()
        {
            this.TableName = "MEMCACHE_HITS";
            this.PrimaryKey = new string[] { _PAGEURL, _FUNCTIONNAME, _STATS_DATE };

            this.columns = new string[] { _PAGEURL, _FUNCTIONNAME, _STATS_DATE, _CLASSNAME, _MEMCACHE_IP, _MEMCACHE_PORT, _GET_COUNT, _GET_MISSES_COUNT, _GET_HITS_COUNT, _SET_COUNT, _SET_MISSES_COUNT, _SET_HITS_COUNT, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表MEMCACHE_HITS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, DATETIME, VARCHAR, VARCHAR, INT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, DATETIME };
                this.Lengths = new int[] { 200, 500, 8, 200, 20, 4, 8, 8, 8, 8, 8, 8, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "getdate" };
                this.Descriptions = new string[] { "网址", "命名空间和函数名称", "统计日期", "类名称", "memcached的IP", "memcached的端口", "get总次数", "get丢失次数", "get命中次数", "set总次数", "set丢失次数", "set命中次数", "更新时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="PAGEURL">网址</param>
        /// <param name="FUNCTIONNAME">命名空间和函数名称</param>
        /// <param name="STATS_DATE">统计日期</param>
                /// <returns>bool</returns>
                public bool Find(string P_PAGEURL,string P_FUNCTIONNAME,DateTime P_STATS_DATE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_PAGEURL;
        this.ColumnValues[1]=P_FUNCTIONNAME;
        this.ColumnValues[2]=P_STATS_DATE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝MEMCACHE_HITS（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public MEMCACHE_HITS Copy()
                {
                    MEMCACHE_HITS new_obj=new MEMCACHE_HITS();
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

        private bool inner_join_memcache_server = false;
        private bool left_join_memcache_server = false; 
        private bool inner_join_website_my_pageurl = false;
        private bool left_join_website_my_pageurl = false;
        private bool right_join_website_my_pageurl = false;

        /// <summary>
        /// INNER JOIN MEMCACHE_SERVER MEMCACHE_SERVER  ON MEMCACHE_SERVER.MEMCACHE_IP=MEMCACHE_HITS.MEMCACHE_IP AND MEMCACHE_SERVER.MEMCACHE_PORT=MEMCACHE_HITS.MEMCACHE_PORT
        /// </summary>
        public bool INNER_JOIN_MEMCACHE_SERVER
        {
            set
            {
                this.inner_join_memcache_server = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN MEMCACHE_SERVER MEMCACHE_SERVER  ON MEMCACHE_SERVER.MEMCACHE_IP=MEMCACHE_HITS.MEMCACHE_IP AND MEMCACHE_SERVER.MEMCACHE_PORT=MEMCACHE_HITS.MEMCACHE_PORT
        /// </summary>
        public bool LEFT_JOIN_MEMCACHE_SERVER
        {
            set
            {
                this.left_join_memcache_server = value;
            }
        }


        /// <summary>
        /// INNER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=MEMCACHE_HITS.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.inner_join_website_my_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=MEMCACHE_HITS.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.left_join_website_my_pageurl = value;
            }
        }
        /// <summary>
        /// RIGHT OUTER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=MEMCACHE_HITS.PAGEURL
        /// </summary>
        public bool RIGHT_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.right_join_website_my_pageurl = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_MEMCACHE_SERVER
        /// LEFT_JOIN_MEMCACHE_SERVER

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_memcache_server == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "MEMCACHE_SERVER", "MEMCACHE_SERVER", "MEMCACHE_IP", "MEMCACHE_IP", "MEMCACHE_PORT", "MEMCACHE_PORT");
            }
            if (this.left_join_memcache_server == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "MEMCACHE_SERVER", "MEMCACHE_SERVER", "MEMCACHE_IP", "MEMCACHE_IP", "MEMCACHE_PORT", "MEMCACHE_PORT");
            }
            if (this.inner_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.left_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.right_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "RIGHT OUTER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }


            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                CREATE TABLE [dbo].[MEMCACHE_HITS](
                 [PAGEURL] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [FUNCTIONNAME] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [STATS_DATE] [DATETIME]  NOT NULL ,
                 [CLASSNAME] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [MEMCACHE_IP] [VARCHAR]  (20)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [MEMCACHE_PORT] [INT]  NULL ,
                 [GET_COUNT] [BIGINT]  (8)  NULL  CONSTRAINT [DF_MEMCACHE_HITS_GET_COUNT] DEFAULT ('0') ,
                 [GET_MISSES_COUNT] [BIGINT]  (8)  NULL  CONSTRAINT [DF_MEMCACHE_HITS_GET_MISSES_COUNT] DEFAULT ('0') ,
                 [GET_HITS_COUNT] [BIGINT]  (8)  NULL  CONSTRAINT [DF_MEMCACHE_HITS_GET_HITS_COUNT] DEFAULT ('0') ,
                 [SET_COUNT] [BIGINT]  (8)  NULL  CONSTRAINT [DF_MEMCACHE_HITS_SET_COUNT] DEFAULT ('0') ,
                 [SET_MISSES_COUNT] [BIGINT]  (8)  NULL  CONSTRAINT [DF_MEMCACHE_HITS_SET_MISSES_COUNT] DEFAULT ('0') ,
                 [SET_HITS_COUNT] [BIGINT]  (8)  NULL  CONSTRAINT [DF_MEMCACHE_HITS_SET_HITS_COUNT] DEFAULT ('0') ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_MEMCACHE_HITS_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_MEMCACHE_HITS] PRIMARY KEY CLUSTERED 
                (
	             [PAGEURL] ASC,[FUNCTIONNAME] ASC,[STATS_DATE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'PAGEURL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'命名空间和函数名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'FUNCTIONNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'STATS_DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'CLASSNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcached的IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'MEMCACHE_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcached的端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'MEMCACHE_PORT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get总次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'GET_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get丢失次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'GET_MISSES_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'GET_HITS_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'set总次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'SET_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'set丢失次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'SET_MISSES_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'set命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'SET_HITS_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_HITS', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO

                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}