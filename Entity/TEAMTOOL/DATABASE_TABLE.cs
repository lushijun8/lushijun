
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_TABLE"
    /// Columns="DATABASE_NAME,TABLE_NAME,COUNTDATE,LIKE_WEBMANAGER_NAME,LIKE_WEBMANAGER_REALNAME,DATABASE_IP_ROMOTE,ROWCOUNTS,ROWCOUNTS_INCREASING,ROWCOUNTS_INCREASING_RATE,ROWCOUNTS_INCREASING_WEEK,ROWCOUNTS_INCREASING_WEEK_RATE,ROWCOUNTS_INCREASING_MONTH,ROWCOUNTS_INCREASING_MONTH_RATE,ROWCOUNTS_INCREASING_YEAR,ROWCOUNTS_INCREASING_YEAR_RATE,COLUMNCOUNTS,CREATETIME,SPACE_ALLOCATION,SPACE_USED,SPACE_INDEX_USED,SPACE_AVAILABLE"
    /// PrimaryKeys="DATABASE_NAME,TABLE_NAME,COUNTDATE"
    /// </summary>
    public sealed class DATABASE_TABLE : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2017/3/29 17:38:19
        #region 属性
        /// <summary>
        /// 数据库名称  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,COUNTDATE
        /// </summary>
        public string DATABASE_NAME
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
        /// 表名  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,COUNTDATE
        /// </summary>
        public string TABLE_NAME
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
        /// 日期  DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COUNTDATE_ToString 更加准确
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,COUNTDATE
        /// </summary>
        public DateTime COUNTDATE
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 日期  DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 COUNTDATE
        ///	主健之一，其他主健还有：DATABASE_NAME,TABLE_NAME,COUNTDATE
        /// </summary>
        public string COUNTDATE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 疑似领用人  NVARCHAR(1000)  NULL
        /// </summary>
        public string LIKE_WEBMANAGER_NAME
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
        /// 疑似领用人姓名  NVARCHAR(1000)  NULL
        /// </summary>
        public string LIKE_WEBMANAGER_REALNAME
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
        /// 服务器IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_ROMOTE
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
        /// 记录数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 记录数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 今日记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 今日记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 今日记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_RATE
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 今日记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_RATE_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 本周记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_WEEK_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING_WEEK
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 本周记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_WEEK
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_WEEK_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 本周记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_WEEK_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_WEEK_RATE
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 本周记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_WEEK_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_WEEK_RATE_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 本月记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_MONTH_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING_MONTH
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 本月记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_MONTH
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_MONTH_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 本月记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_MONTH_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_MONTH_RATE
        {
            set
            {
                ColumnValues[12] = value.ToString(); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 本月记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_MONTH_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_MONTH_RATE_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 本年记录增长情况  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_YEAR_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long ROWCOUNTS_INCREASING_YEAR
        {
            set
            {
                ColumnValues[13] = value.ToString(); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 本年记录增长情况  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_YEAR
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_YEAR_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        /// 本年记录增长率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ROWCOUNTS_INCREASING_YEAR_RATE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal ROWCOUNTS_INCREASING_YEAR_RATE
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 本年记录增长率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ROWCOUNTS_INCREASING_YEAR_RATE
        ///	默认值:0
        /// </summary>
        public string ROWCOUNTS_INCREASING_YEAR_RATE_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 列数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 COLUMNCOUNTS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long COLUMNCOUNTS
        {
            set
            {
                ColumnValues[15] = value.ToString(); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 列数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 COLUMNCOUNTS
        ///	默认值:0
        /// </summary>
        public string COLUMNCOUNTS_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[16] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[16];
            }
        }
        /// <summary>
        /// 保留空间(KB)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SPACE_ALLOCATION_ToString 更加准确
        /// </summary>
        public long SPACE_ALLOCATION
        {
            set
            {
                ColumnValues[17] = value.ToString(); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 保留空间(KB)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SPACE_ALLOCATION
        /// </summary>
        public string SPACE_ALLOCATION_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        /// 已使用空间(KB)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SPACE_USED_ToString 更加准确
        /// </summary>
        public long SPACE_USED
        {
            set
            {
                ColumnValues[18] = value.ToString(); UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        /// 已使用空间(KB)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SPACE_USED
        /// </summary>
        public string SPACE_USED_ToString
        {
            get
            {
                return ColumnValues[18];
            }
        }
        /// <summary>
        /// 索引使用空间(KB)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SPACE_INDEX_USED_ToString 更加准确
        /// </summary>
        public long SPACE_INDEX_USED
        {
            set
            {
                ColumnValues[19] = value.ToString(); UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        /// 索引使用空间(KB)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SPACE_INDEX_USED
        /// </summary>
        public string SPACE_INDEX_USED_ToString
        {
            get
            {
                return ColumnValues[19];
            }
        }
        /// <summary>
        /// 未用空间(KB)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SPACE_AVAILABLE_ToString 更加准确
        /// </summary>
        public long SPACE_AVAILABLE
        {
            set
            {
                ColumnValues[20] = value.ToString(); UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        /// 未用空间(KB)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SPACE_AVAILABLE
        /// </summary>
        public string SPACE_AVAILABLE_ToString
        {
            get
            {
                return ColumnValues[20];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 数据库名称 返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 表名 返回 "TABLE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TABLE_NAME = "TABLE_NAME";
        /// <summary>
        /// 日期 返回 "COUNTDATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COUNTDATE = "COUNTDATE";
        /// <summary>
        /// 疑似领用人 返回 "LIKE_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LIKE_WEBMANAGER_NAME = "LIKE_WEBMANAGER_NAME";
        /// <summary>
        /// 疑似领用人姓名 返回 "LIKE_WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LIKE_WEBMANAGER_REALNAME = "LIKE_WEBMANAGER_REALNAME";
        /// <summary>
        /// 服务器IP 返回 "DATABASE_IP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_ROMOTE = "DATABASE_IP_ROMOTE";
        /// <summary>
        /// 记录数 返回 "ROWCOUNTS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS = "ROWCOUNTS";
        /// <summary>
        /// 今日记录增长情况 返回 "ROWCOUNTS_INCREASING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING = "ROWCOUNTS_INCREASING";
        /// <summary>
        /// 今日记录增长率 返回 "ROWCOUNTS_INCREASING_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_RATE = "ROWCOUNTS_INCREASING_RATE";
        /// <summary>
        /// 本周记录增长情况 返回 "ROWCOUNTS_INCREASING_WEEK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_WEEK = "ROWCOUNTS_INCREASING_WEEK";
        /// <summary>
        /// 本周记录增长率 返回 "ROWCOUNTS_INCREASING_WEEK_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_WEEK_RATE = "ROWCOUNTS_INCREASING_WEEK_RATE";
        /// <summary>
        /// 本月记录增长情况 返回 "ROWCOUNTS_INCREASING_MONTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_MONTH = "ROWCOUNTS_INCREASING_MONTH";
        /// <summary>
        /// 本月记录增长率 返回 "ROWCOUNTS_INCREASING_MONTH_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_MONTH_RATE = "ROWCOUNTS_INCREASING_MONTH_RATE";
        /// <summary>
        /// 本年记录增长情况 返回 "ROWCOUNTS_INCREASING_YEAR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_YEAR = "ROWCOUNTS_INCREASING_YEAR";
        /// <summary>
        /// 本年记录增长率 返回 "ROWCOUNTS_INCREASING_YEAR_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ROWCOUNTS_INCREASING_YEAR_RATE = "ROWCOUNTS_INCREASING_YEAR_RATE";
        /// <summary>
        /// 列数 返回 "COLUMNCOUNTS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _COLUMNCOUNTS = "COLUMNCOUNTS";
        /// <summary>
        /// 创建时间  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 保留空间(KB) 返回 "SPACE_ALLOCATION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SPACE_ALLOCATION = "SPACE_ALLOCATION";
        /// <summary>
        /// 已使用空间(KB) 返回 "SPACE_USED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SPACE_USED = "SPACE_USED";
        /// <summary>
        /// 索引使用空间(KB) 返回 "SPACE_INDEX_USED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SPACE_INDEX_USED = "SPACE_INDEX_USED";
        /// <summary>
        /// 未用空间(KB) 返回 "SPACE_AVAILABLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SPACE_AVAILABLE = "SPACE_AVAILABLE";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_TABLE的构造函数
        /// </summary>
        public DATABASE_TABLE()
        {
            this.TableName = "DATABASE_TABLE";
            this.PrimaryKey = new string[] { _DATABASE_NAME, _TABLE_NAME, _COUNTDATE };

            this.columns = new string[] { _DATABASE_NAME, _TABLE_NAME, _COUNTDATE, _LIKE_WEBMANAGER_NAME, _LIKE_WEBMANAGER_REALNAME, _DATABASE_IP_ROMOTE, _ROWCOUNTS, _ROWCOUNTS_INCREASING, _ROWCOUNTS_INCREASING_RATE, _ROWCOUNTS_INCREASING_WEEK, _ROWCOUNTS_INCREASING_WEEK_RATE, _ROWCOUNTS_INCREASING_MONTH, _ROWCOUNTS_INCREASING_MONTH_RATE, _ROWCOUNTS_INCREASING_YEAR, _ROWCOUNTS_INCREASING_YEAR_RATE, _COLUMNCOUNTS, _CREATETIME, _SPACE_ALLOCATION, _SPACE_USED, _SPACE_INDEX_USED, _SPACE_AVAILABLE };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_TABLE的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, DATETIME, NVARCHAR, NVARCHAR, VARCHAR, BIGINT, BIGINT, FLOAT, BIGINT, FLOAT, BIGINT, FLOAT, BIGINT, FLOAT, BIGINT, DATETIME, BIGINT, BIGINT, BIGINT, BIGINT };
                this.Lengths = new int[] { 50, 50, 8, 1000, 1000, 50, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "getdate", " ", " ", " ", " " };
                this.Descriptions = new string[] { "数据库名称", "表名", "日期", "疑似领用人", "疑似领用人姓名", "服务器IP", "记录数", "今日记录增长情况", "今日记录增长率", "本周记录增长情况", "本周记录增长率", "本月记录增长情况", "本月记录增长率", "本年记录增长情况", "本年记录增长率", "列数", "创建时间 ", "保留空间(KB)", "已使用空间(KB)", "索引使用空间(KB)", "未用空间(KB)" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_NAME">数据库名称</param>
        /// <param name="TABLE_NAME">表名</param>
        /// <param name="COUNTDATE">日期</param>
                /// <returns>bool</returns>
                public bool Find(string P_DATABASE_NAME,string P_TABLE_NAME,DateTime P_COUNTDATE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_NAME;
        this.ColumnValues[1]=P_TABLE_NAME;
        this.ColumnValues[2]=P_COUNTDATE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_TABLE（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_TABLE Copy()
                {
                    DATABASE_TABLE new_obj=new DATABASE_TABLE();
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
                 				
                CREATE TABLE [dbo].[DATABASE_TABLE](
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [TABLE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [COUNTDATE] [DATETIME]  NOT NULL ,
                 [LIKE_WEBMANAGER_NAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LIKE_WEBMANAGER_REALNAME] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IP_ROMOTE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ROWCOUNTS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING_RATE] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_WEEK] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING_WEEK] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_WEEK_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING_WEEK_RATE] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_MONTH] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING_MONTH] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_MONTH_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING_MONTH_RATE] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_YEAR] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING_YEAR] DEFAULT ('0') ,
                 [ROWCOUNTS_INCREASING_YEAR_RATE] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_TABLE_ROWCOUNTS_INCREASING_YEAR_RATE] DEFAULT ('0') ,
                 [COLUMNCOUNTS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_TABLE_COLUMNCOUNTS] DEFAULT ('0') ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_TABLE_CREATETIME] DEFAULT ('getdate') ,
                 [SPACE_ALLOCATION] [BIGINT]  NULL ,
                 [SPACE_USED] [BIGINT]  NULL ,
                 [SPACE_INDEX_USED] [BIGINT]  NULL ,
                 [SPACE_AVAILABLE] [BIGINT]  NULL ,
                
                CONSTRAINT [PK_DATABASE_TABLE] PRIMARY KEY CLUSTERED 
                (
	             [DATABASE_NAME] ASC,[TABLE_NAME] ASC,[COUNTDATE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'TABLE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'COUNTDATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似领用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'LIKE_WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似领用人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'LIKE_WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_ROMOTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'今日记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'今日记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本周记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_WEEK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本周记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_WEEK_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本月记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_MONTH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本月记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_MONTH_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本年记录增长情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_YEAR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本年记录增长率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'ROWCOUNTS_INCREASING_YEAR_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'COLUMNCOUNTS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留空间(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'SPACE_ALLOCATION'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已使用空间(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'SPACE_USED'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'索引使用空间(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'SPACE_INDEX_USED'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'未用空间(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_TABLE', @level2type=N'COLUMN',@level2name=N'SPACE_AVAILABLE'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}