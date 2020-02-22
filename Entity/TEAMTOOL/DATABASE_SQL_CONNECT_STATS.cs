using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_SQL_CONNECT_STATS"
    /// Columns="PAGEURL,STATS_DATE,LASTCONNECTTIME,REQUEST_COUNT,DURATION_SUM,DURATION_AVG,DURATION_MAX,DURATION_MIN,CONNECT_TIMES_SUM,CONNECT_TIMES_AVG,CONNECT_TIMES_MAX,CONNECT_TIMES_MIN,CREATETIME"
    /// PrimaryKeys="PAGEURL,STATS_DATE"
    /// </summary>
    public sealed class DATABASE_SQL_CONNECT_STATS : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/7/23 15:54:02
        #region 属性
        /// <summary>
        /// Url地址  VARCHAR(500)  NOT NULL
        ///	主健之一，其他主健还有：PAGEURL,STATS_DATE
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
        /// 统计日期  DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATS_DATE_ToString 更加准确
        ///	主健之一，其他主健还有：PAGEURL,STATS_DATE
        /// </summary>
        public DateTime STATS_DATE
        {
            set
            {
                ColumnValues[1] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 统计日期  DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATS_DATE
        ///	主健之一，其他主健还有：PAGEURL,STATS_DATE
        /// </summary>
        public string STATS_DATE_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 请求参数  NVARCHAR(8000)  NULL
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
        /// 请求Form参数  NVARCHAR(8000)  NULL
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
        /// 最后连接数据库时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LASTCONNECTTIME_ToString 更加准确
        /// </summary>
        public DateTime LASTCONNECTTIME
        {
            set
            {
                ColumnValues[4] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 最后连接数据库时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LASTCONNECTTIME
        /// </summary>
        public string LASTCONNECTTIME_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 页面请求总次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 REQUEST_COUNT_ToString 更加准确
        /// </summary>
        public long REQUEST_COUNT
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 页面请求总次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 REQUEST_COUNT
        /// </summary>
        public string REQUEST_COUNT_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 页面请求总耗时(毫秒)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_SUM_ToString 更加准确
        /// </summary>
        public long DURATION_SUM
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 页面请求总耗时(毫秒)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION_SUM
        /// </summary>
        public string DURATION_SUM_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 页面请求平均耗时(毫秒)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_AVG_ToString 更加准确
        /// </summary>
        public long DURATION_AVG
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 页面请求平均耗时(毫秒)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION_AVG
        /// </summary>
        public string DURATION_AVG_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 页面请求最大耗时(毫秒)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_MAX_ToString 更加准确
        /// </summary>
        public long DURATION_MAX
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 页面请求最大耗时(毫秒)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION_MAX
        /// </summary>
        public string DURATION_MAX_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 页面请求最小耗时(毫秒)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_MIN_ToString 更加准确
        /// </summary>
        public long DURATION_MIN
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 页面请求最小耗时(毫秒)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION_MIN
        /// </summary>
        public string DURATION_MIN_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 连接数据库总次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECT_TIMES_SUM_ToString 更加准确
        /// </summary>
        public long CONNECT_TIMES_SUM
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 连接数据库总次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECT_TIMES_SUM
        /// </summary>
        public string CONNECT_TIMES_SUM_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 平均每次请求连接数据库次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECT_TIMES_AVG_ToString 更加准确
        /// </summary>
        public long CONNECT_TIMES_AVG
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 平均每次请求连接数据库次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECT_TIMES_AVG
        /// </summary>
        public string CONNECT_TIMES_AVG_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 单次请求连接数据库最大数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECT_TIMES_MAX_ToString 更加准确
        /// </summary>
        public long CONNECT_TIMES_MAX
        {
            set
            {
                ColumnValues[12] = value.ToString(); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 单次请求连接数据库最大数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECT_TIMES_MAX
        /// </summary>
        public string CONNECT_TIMES_MAX_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 单次请求连接数据库最小数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECT_TIMES_MIN_ToString 更加准确
        /// </summary>
        public long CONNECT_TIMES_MIN
        {
            set
            {
                ColumnValues[13] = value.ToString(); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 单次请求连接数据库最小数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECT_TIMES_MIN
        /// </summary>
        public string CONNECT_TIMES_MIN_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
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
        /// 创建时间  DATETIME(8)  NULL
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// Url地址 返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// 统计日期 返回 "STATS_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATS_DATE = "STATS_DATE";
        /// <summary>
        /// 请求参数 返回 "QUERYSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING = "QUERYSTRING";
        /// <summary>
        /// 请求Form参数 返回 "FORM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM = "FORM";
        /// <summary>
        /// 最后连接数据库时间 返回 "LASTCONNECTTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LASTCONNECTTIME = "LASTCONNECTTIME";
        /// <summary>
        /// 页面请求总次数 返回 "REQUEST_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REQUEST_COUNT = "REQUEST_COUNT";
        /// <summary>
        /// 页面请求总耗时(毫秒) 返回 "DURATION_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION_SUM = "DURATION_SUM";
        /// <summary>
        /// 页面请求平均耗时(毫秒) 返回 "DURATION_AVG", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION_AVG = "DURATION_AVG";
        /// <summary>
        /// 页面请求最大耗时(毫秒) 返回 "DURATION_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION_MAX = "DURATION_MAX";
        /// <summary>
        /// 页面请求最小耗时(毫秒) 返回 "DURATION_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION_MIN = "DURATION_MIN";
        /// <summary>
        /// 连接数据库总次数 返回 "CONNECT_TIMES_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECT_TIMES_SUM = "CONNECT_TIMES_SUM";
        /// <summary>
        /// 平均每次请求连接数据库次数 返回 "CONNECT_TIMES_AVG", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECT_TIMES_AVG = "CONNECT_TIMES_AVG";
        /// <summary>
        /// 单次请求连接数据库最大数 返回 "CONNECT_TIMES_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECT_TIMES_MAX = "CONNECT_TIMES_MAX";
        /// <summary>
        /// 单次请求连接数据库最小数 返回 "CONNECT_TIMES_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECT_TIMES_MIN = "CONNECT_TIMES_MIN";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_SQL_CONNECT_STATS的构造函数
        /// </summary>
        public DATABASE_SQL_CONNECT_STATS()
        {
            this.TableName = "DATABASE_SQL_CONNECT_STATS";
            this.PrimaryKey = new string[] { _PAGEURL, _STATS_DATE };

            this.columns = new string[] { _PAGEURL, _STATS_DATE, _QUERYSTRING, _FORM, _LASTCONNECTTIME, _REQUEST_COUNT, _DURATION_SUM, _DURATION_AVG, _DURATION_MAX, _DURATION_MIN, _CONNECT_TIMES_SUM, _CONNECT_TIMES_AVG, _CONNECT_TIMES_MAX, _CONNECT_TIMES_MIN, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_SQL_CONNECT_STATS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, DATETIME, NVARCHAR, NVARCHAR, DATETIME, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, DATETIME };
                this.Lengths = new int[] { 500, 8, 8000, 8000, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
                this.IsNullables = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { "Url地址", "统计日期", "请求参数", "请求Form参数", "最后连接数据库时间", "页面请求总次数", "页面请求总耗时(毫秒)", "页面请求平均耗时(毫秒)", "页面请求最大耗时(毫秒)", "页面请求最小耗时(毫秒)", "连接数据库总次数", "平均每次请求连接数据库次数", "单次请求连接数据库最大数", "单次请求连接数据库最小数", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="PAGEURL">Url地址</param>
        /// <param name="STATS_DATE">统计日期</param>
                /// <returns>bool</returns>
                public bool Find(string P_PAGEURL,DateTime P_STATS_DATE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_PAGEURL;
        this.ColumnValues[1]=P_STATS_DATE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_SQL_CONNECT_STATS（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_SQL_CONNECT_STATS Copy()
                {
                    DATABASE_SQL_CONNECT_STATS new_obj=new DATABASE_SQL_CONNECT_STATS();
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

        private bool inner_join_website_pageurl = false;
        private bool left_join_website_pageurl = false;

        private bool inner_join_website_my_pageurl = false;
        private bool left_join_website_my_pageurl = false;
        private bool right_join_website_my_pageurl = false;
        /// <summary>
        /// INNER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=DATABASE_SQL_CONNECT_STATS.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_PAGEURL
        {
            set
            {
                this.inner_join_website_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=DATABASE_SQL_CONNECT_STATS.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_PAGEURL
        {
            set
            {
                this.left_join_website_pageurl = value;
            }
        }

        /// <summary>
        /// INNER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=DATABASE_SQL_CONNECT_STATS.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.inner_join_website_my_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=DATABASE_SQL_CONNECT_STATS.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.left_join_website_my_pageurl = value;
            }
        }
        /// <summary>
        /// RIGHT OUTER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=DATABASE_SQL_CONNECT_STATS.PAGEURL
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
        /// INNER_JOIN_WEBSITE_PAGEURL
        /// LEFT_JOIN_WEBSITE_PAGEURL

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_website_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.left_join_website_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "PAGEURL");
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
                 				
                CREATE TABLE [dbo].[DATABASE_SQL_CONNECT_STATS](
                 [PAGEURL] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [STATS_DATE] [DATETIME]  NOT NULL ,
                 [QUERYSTRING] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [FORM] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LASTCONNECTTIME] [DATETIME]  NULL ,
                 [REQUEST_COUNT] [BIGINT]  NULL ,
                 [DURATION_SUM] [BIGINT]  NULL ,
                 [DURATION_AVG] [BIGINT]  NULL ,
                 [DURATION_MAX] [BIGINT]  NULL ,
                 [DURATION_MIN] [BIGINT]  NULL ,
                 [CONNECT_TIMES_SUM] [BIGINT]  NULL ,
                 [CONNECT_TIMES_AVG] [BIGINT]  NULL ,
                 [CONNECT_TIMES_MAX] [BIGINT]  NULL ,
                 [CONNECT_TIMES_MIN] [BIGINT]  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_SQL_CONNECT_STATS_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_DATABASE_SQL_CONNECT_STATS] PRIMARY KEY CLUSTERED 
                (
	             [PAGEURL] ASC,[STATS_DATE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'PAGEURL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'STATS_DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'QUERYSTRING'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求Form参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'FORM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后连接数据库时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'LASTCONNECTTIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面请求总次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'REQUEST_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面请求总耗时(毫秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'DURATION_SUM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面请求平均耗时(毫秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'DURATION_AVG'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面请求最大耗时(毫秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'DURATION_MAX'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面请求最小耗时(毫秒)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'DURATION_MIN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连接数据库总次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'CONNECT_TIMES_SUM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平均每次请求连接数据库次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'CONNECT_TIMES_AVG'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单次请求连接数据库最大数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'CONNECT_TIMES_MAX'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单次请求连接数据库最小数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'CONNECT_TIMES_MIN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_SQL_CONNECT_STATS', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}