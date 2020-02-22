
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="WEBSITE_DEPEND"
    /// Columns="PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT,PAGEURL_REGEX,PAGEURL_DETAIL,DEPEND_PAGEURL_REGEX,DEPEND_PAGEURL_DETAIL,DEPEND_CONTENT,DEPEND_CONTENTTYPE,DEPEND_CONTENTTYPE_ERROR,DEPEND_CONTENTLENGTH,DEPEND_COUNT,DEPEND_COUNT_ERROR,DEPEND_ERROR_RATE,DEPEND_COUNT_TIMEOUT,DEPEND_TIMEOUT_RATE,DEPEND_TIMESPAN_SUM,DEPEND_TIMESPAN_MAX,DEPEND_TIMESPAN_MIN,DEPEND_TIMESPAN_NEW,DEPEND_TIMESPAN_AVERAGE,DEPEND_CREATETIME"
    /// PrimaryKeys="PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT"
    /// </summary>
    public sealed class WEBSITE_DEPEND : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/7/26 16:03:59
        #region 属性
        /// <summary>
        /// 本地URL  VARCHAR(200)  NOT NULL
        ///	主健之一，其他主健还有：PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT
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
        /// 外部依赖的URL  VARCHAR(200)  NOT NULL
        ///	主健之一，其他主健还有：PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT
        /// </summary>
        public string DEPEND_PAGEURL
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
        /// 统计日期   DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATS_DATE_ToString 更加准确
        ///	默认值:CONVERT[varchar]100
        ///	主健之一，其他主健还有：PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT
        /// </summary>
        public DateTime STATS_DATE
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 统计日期   DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATS_DATE
        ///	默认值:CONVERT[varchar]100
        ///	主健之一，其他主健还有：PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT
        /// </summary>
        public string STATS_DATE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 设置的超时时间（毫秒）  BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_TIMEOUT_ToString 更加准确
        ///	默认值:getdate
        ///	主健之一，其他主健还有：PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT
        /// </summary>
        public long DEPEND_TIMEOUT
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 设置的超时时间（毫秒）  BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_TIMEOUT
        ///	默认值:getdate
        ///	主健之一，其他主健还有：PAGEURL,DEPEND_PAGEURL,STATS_DATE,DEPEND_TIMEOUT
        /// </summary>
        public string DEPEND_TIMEOUT_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 本地URL的匹配正则   VARCHAR(200)  NULL
        ///	默认值:23
        /// </summary>
        public string PAGEURL_REGEX
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
        /// URL包括详细参数，记录的是最后一次的  NVARCHAR(8000)  NULL
        ///	默认值:0
        /// </summary>
        public string PAGEURL_DETAIL
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
        /// 外部依赖的URL的匹配正则  VARCHAR(200)  NULL
        /// </summary>
        public string DEPEND_PAGEURL_REGEX
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
        /// 外部依赖URL，包括详细参数，记录的是最后一次的  NVARCHAR(8000)  NULL
        /// </summary>
        public string DEPEND_PAGEURL_DETAIL
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
        /// 内容  NVARCHAR(-1)  NULL
        /// </summary>
        public string DEPEND_CONTENT
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
        /// 外部依赖的类型（如：text/xml，text/html，text/xml等）  VARCHAR(100)  NULL
        /// </summary>
        public string DEPEND_CONTENTTYPE
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
        /// 数据格式是否有错，0没错，1有错  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_CONTENTTYPE_ERROR_ToString 更加准确
        /// </summary>
        public int DEPEND_CONTENTTYPE_ERROR
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 数据格式是否有错，0没错，1有错  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_CONTENTTYPE_ERROR
        /// </summary>
        public string DEPEND_CONTENTTYPE_ERROR_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 内容长度  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_CONTENTLENGTH_ToString 更加准确
        /// </summary>
        public int DEPEND_CONTENTLENGTH
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 内容长度  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_CONTENTLENGTH
        /// </summary>
        public string DEPEND_CONTENTLENGTH_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 调用总次数  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_COUNT_ToString 更加准确
        /// </summary>
        public int DEPEND_COUNT
        {
            set
            {
                ColumnValues[12] = value.ToString(); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 调用总次数  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_COUNT
        /// </summary>
        public string DEPEND_COUNT_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 请求失败总次数  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_COUNT_ERROR_ToString 更加准确
        /// </summary>
        public int DEPEND_COUNT_ERROR
        {
            set
            {
                ColumnValues[13] = value.ToString(); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 请求失败总次数  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_COUNT_ERROR
        /// </summary>
        public string DEPEND_COUNT_ERROR_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        /// 失败率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_ERROR_RATE_ToString 更加准确
        /// </summary>
        public decimal DEPEND_ERROR_RATE
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 失败率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_ERROR_RATE
        /// </summary>
        public string DEPEND_ERROR_RATE_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 超时数  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_COUNT_TIMEOUT_ToString 更加准确
        /// </summary>
        public int DEPEND_COUNT_TIMEOUT
        {
            set
            {
                ColumnValues[15] = value.ToString(); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 超时数  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_COUNT_TIMEOUT
        /// </summary>
        public string DEPEND_COUNT_TIMEOUT_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        /// 超时率  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_TIMEOUT_RATE_ToString 更加准确
        /// </summary>
        public decimal DEPEND_TIMEOUT_RATE
        {
            set
            {
                ColumnValues[16] = value.ToString(); UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 超时率  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_TIMEOUT_RATE
        /// </summary>
        public string DEPEND_TIMEOUT_RATE_ToString
        {
            get
            {
                return ColumnValues[16];
            }
        }
        /// <summary>
        /// 累计总消耗时长（毫秒）  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_TIMESPAN_SUM_ToString 更加准确
        /// </summary>
        public long DEPEND_TIMESPAN_SUM
        {
            set
            {
                ColumnValues[17] = value.ToString(); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 累计总消耗时长（毫秒）  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_TIMESPAN_SUM
        /// </summary>
        public string DEPEND_TIMESPAN_SUM_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        /// 消耗时长最大值（毫秒）  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_TIMESPAN_MAX_ToString 更加准确
        /// </summary>
        public int DEPEND_TIMESPAN_MAX
        {
            set
            {
                ColumnValues[18] = value.ToString(); UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        /// 消耗时长最大值（毫秒）  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_TIMESPAN_MAX
        /// </summary>
        public string DEPEND_TIMESPAN_MAX_ToString
        {
            get
            {
                return ColumnValues[18];
            }
        }
        /// <summary>
        /// 消耗时长最小值（毫秒）  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_TIMESPAN_MIN_ToString 更加准确
        /// </summary>
        public int DEPEND_TIMESPAN_MIN
        {
            set
            {
                ColumnValues[19] = value.ToString(); UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        /// 消耗时长最小值（毫秒）  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_TIMESPAN_MIN
        /// </summary>
        public string DEPEND_TIMESPAN_MIN_ToString
        {
            get
            {
                return ColumnValues[19];
            }
        }
        /// <summary>
        /// 消耗时长最新值（毫秒）  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_TIMESPAN_NEW_ToString 更加准确
        /// </summary>
        public int DEPEND_TIMESPAN_NEW
        {
            set
            {
                ColumnValues[20] = value.ToString(); UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        /// 消耗时长最新值（毫秒）  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_TIMESPAN_NEW
        /// </summary>
        public string DEPEND_TIMESPAN_NEW_ToString
        {
            get
            {
                return ColumnValues[20];
            }
        }
        /// <summary>
        /// 消耗时长平均值（毫秒）  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_TIMESPAN_AVERAGE_ToString 更加准确
        /// </summary>
        public int DEPEND_TIMESPAN_AVERAGE
        {
            set
            {
                ColumnValues[21] = value.ToString(); UpdateStatus[21] = 1;
            }
        }
        /// <summary>
        /// 消耗时长平均值（毫秒）  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_TIMESPAN_AVERAGE
        /// </summary>
        public string DEPEND_TIMESPAN_AVERAGE_ToString
        {
            get
            {
                return ColumnValues[21];
            }
        }
        /// <summary>
        /// 最后一次调用外部依赖的时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DEPEND_CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime DEPEND_CREATETIME
        {
            set
            {
                ColumnValues[22] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[22] = 1;
            }
        }
        /// <summary>
        /// 最后一次调用外部依赖的时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DEPEND_CREATETIME
        /// </summary>
        public string DEPEND_CREATETIME_ToString
        {
            get
            {
                return ColumnValues[22];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 本地URL 返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// 外部依赖的URL 返回 "DEPEND_PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_PAGEURL = "DEPEND_PAGEURL";
        /// <summary>
        /// 统计日期  返回 "STATS_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATS_DATE = "STATS_DATE";
        /// <summary>
        /// 设置的超时时间（毫秒） 返回 "DEPEND_TIMEOUT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_TIMEOUT = "DEPEND_TIMEOUT";
        /// <summary>
        /// 本地URL的匹配正则  返回 "PAGEURL_REGEX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL_REGEX = "PAGEURL_REGEX";
        /// <summary>
        /// URL包括详细参数，记录的是最后一次的 返回 "PAGEURL_DETAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL_DETAIL = "PAGEURL_DETAIL";
        /// <summary>
        /// 外部依赖的URL的匹配正则 返回 "DEPEND_PAGEURL_REGEX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_PAGEURL_REGEX = "DEPEND_PAGEURL_REGEX";
        /// <summary>
        /// 外部依赖URL，包括详细参数，记录的是最后一次的 返回 "DEPEND_PAGEURL_DETAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_PAGEURL_DETAIL = "DEPEND_PAGEURL_DETAIL";
        /// <summary>
        /// 内容 返回 "DEPEND_CONTENT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_CONTENT = "DEPEND_CONTENT";
        /// <summary>
        /// 外部依赖的类型（如：text/xml，text/html，text/xml等） 返回 "DEPEND_CONTENTTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_CONTENTTYPE = "DEPEND_CONTENTTYPE";
        /// <summary>
        /// 数据格式是否有错，0没错，1有错 返回 "DEPEND_CONTENTTYPE_ERROR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_CONTENTTYPE_ERROR = "DEPEND_CONTENTTYPE_ERROR";
        /// <summary>
        /// 内容长度 返回 "DEPEND_CONTENTLENGTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_CONTENTLENGTH = "DEPEND_CONTENTLENGTH";
        /// <summary>
        /// 调用总次数 返回 "DEPEND_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_COUNT = "DEPEND_COUNT";
        /// <summary>
        /// 请求失败总次数 返回 "DEPEND_COUNT_ERROR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_COUNT_ERROR = "DEPEND_COUNT_ERROR";
        /// <summary>
        /// 失败率 返回 "DEPEND_ERROR_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_ERROR_RATE = "DEPEND_ERROR_RATE";
        /// <summary>
        /// 超时数 返回 "DEPEND_COUNT_TIMEOUT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_COUNT_TIMEOUT = "DEPEND_COUNT_TIMEOUT";
        /// <summary>
        /// 超时率 返回 "DEPEND_TIMEOUT_RATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_TIMEOUT_RATE = "DEPEND_TIMEOUT_RATE";
        /// <summary>
        /// 累计总消耗时长（毫秒） 返回 "DEPEND_TIMESPAN_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_TIMESPAN_SUM = "DEPEND_TIMESPAN_SUM";
        /// <summary>
        /// 消耗时长最大值（毫秒） 返回 "DEPEND_TIMESPAN_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_TIMESPAN_MAX = "DEPEND_TIMESPAN_MAX";
        /// <summary>
        /// 消耗时长最小值（毫秒） 返回 "DEPEND_TIMESPAN_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_TIMESPAN_MIN = "DEPEND_TIMESPAN_MIN";
        /// <summary>
        /// 消耗时长最新值（毫秒） 返回 "DEPEND_TIMESPAN_NEW", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_TIMESPAN_NEW = "DEPEND_TIMESPAN_NEW";
        /// <summary>
        /// 消耗时长平均值（毫秒） 返回 "DEPEND_TIMESPAN_AVERAGE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_TIMESPAN_AVERAGE = "DEPEND_TIMESPAN_AVERAGE";
        /// <summary>
        /// 最后一次调用外部依赖的时间 返回 "DEPEND_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_CREATETIME = "DEPEND_CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// WEBSITE_DEPEND的构造函数
        /// </summary>
        public WEBSITE_DEPEND()
        {
            this.TableName = "WEBSITE_DEPEND";
            this.PrimaryKey = new string[] { _PAGEURL, _DEPEND_PAGEURL, _STATS_DATE, _DEPEND_TIMEOUT };

            this.columns = new string[] { _PAGEURL, _DEPEND_PAGEURL, _STATS_DATE, _DEPEND_TIMEOUT, _PAGEURL_REGEX, _PAGEURL_DETAIL, _DEPEND_PAGEURL_REGEX, _DEPEND_PAGEURL_DETAIL, _DEPEND_CONTENT, _DEPEND_CONTENTTYPE, _DEPEND_CONTENTTYPE_ERROR, _DEPEND_CONTENTLENGTH, _DEPEND_COUNT, _DEPEND_COUNT_ERROR, _DEPEND_ERROR_RATE, _DEPEND_COUNT_TIMEOUT, _DEPEND_TIMEOUT_RATE, _DEPEND_TIMESPAN_SUM, _DEPEND_TIMESPAN_MAX, _DEPEND_TIMESPAN_MIN, _DEPEND_TIMESPAN_NEW, _DEPEND_TIMESPAN_AVERAGE, _DEPEND_CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表WEBSITE_DEPEND的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, DATETIME, BIGINT, VARCHAR, NVARCHAR, VARCHAR, NVARCHAR, NVARCHAR, VARCHAR, INT, INT, INT, INT, FLOAT, INT, FLOAT, BIGINT, INT, INT, INT, INT, DATETIME };
                this.Lengths = new int[] { 200, 200, 8, 8, 200, 8000, 200, 8000, -1, 100, 4, 4, 4, 4, 8, 4, 8, 8, 4, 4, 4, 4, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", "CONVERT[varchar]100", "getdate", "23", "0", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "本地URL", "外部依赖的URL", "统计日期 ", "设置的超时时间（毫秒）", "本地URL的匹配正则 ", "URL包括详细参数，记录的是最后一次的", "外部依赖的URL的匹配正则", "外部依赖URL，包括详细参数，记录的是最后一次的", "内容", "外部依赖的类型（如：text/xml，text/html，text/xml等）", "数据格式是否有错，0没错，1有错", "内容长度", "调用总次数", "请求失败总次数", "失败率", "超时数", "超时率", "累计总消耗时长（毫秒）", "消耗时长最大值（毫秒）", "消耗时长最小值（毫秒）", "消耗时长最新值（毫秒）", "消耗时长平均值（毫秒）", "最后一次调用外部依赖的时间 " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="PAGEURL">本地URL</param>
        /// <param name="DEPEND_PAGEURL">外部依赖的URL</param>
        /// <param name="STATS_DATE">统计日期 </param>
        /// <param name="DEPEND_TIMEOUT">设置的超时时间（毫秒）</param>
                /// <returns>bool</returns>
                public bool Find(string P_PAGEURL,string P_DEPEND_PAGEURL,DateTime P_STATS_DATE,long P_DEPEND_TIMEOUT)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_PAGEURL;
        this.ColumnValues[1]=P_DEPEND_PAGEURL;
        this.ColumnValues[2]=P_STATS_DATE.ToString();
        this.ColumnValues[3]=P_DEPEND_TIMEOUT.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝WEBSITE_DEPEND（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public WEBSITE_DEPEND Copy()
                {
                    WEBSITE_DEPEND new_obj=new WEBSITE_DEPEND();
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

        private bool inner_join_website_pageurl_on_pageurl = false;
        private bool left_join_website_pageurl_on_pageurl = false;
        private bool inner_join_website_pageurl_on_depend_pageurl = false;
        private bool left_join_website_pageurl_on_depend_pageurl = false;

        private bool inner_join_website_my_pageurl = false;
        private bool left_join_website_my_pageurl = false;

        /// <summary>
        /// INNER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=WEBSITE_DEPEND.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_PAGEURL_ON_PAGEURL
        {
            set
            {
                this.inner_join_website_pageurl_on_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=WEBSITE_DEPEND.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_PAGEURL_ON_PAGEURL
        {
            set
            {
                this.left_join_website_pageurl_on_pageurl = value;
            }
        }
        /// <summary>
        /// INNER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=WEBSITE_DEPEND.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_PAGEURL_ON_DEPEND_PAGEURL
        {
            set
            {
                this.inner_join_website_pageurl_on_depend_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_PAGEURL WEBSITE_PAGEURL  ON WEBSITE_PAGEURL.PAGEURL=WEBSITE_DEPEND.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_PAGEURL_ON_DEPEND_PAGEURL
        {
            set
            {
                this.left_join_website_pageurl_on_depend_pageurl = value;
            }
        }
        /// <summary>
        /// INNER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=WEBSITE_DEPEND.PAGEURL
        /// </summary>
        public bool INNER_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.inner_join_website_my_pageurl = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN WEBSITE_MY_PAGEURL WEBSITE_MY_PAGEURL  ON WEBSITE_MY_PAGEURL.PAGEURL=WEBSITE_DEPEND.PAGEURL
        /// </summary>
        public bool LEFT_JOIN_WEBSITE_MY_PAGEURL
        {
            set
            {
                this.left_join_website_my_pageurl = value;
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
            if (this.inner_join_website_pageurl_on_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.left_join_website_pageurl_on_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.inner_join_website_pageurl_on_depend_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "DEPEND_PAGEURL");
            }
            if (this.left_join_website_pageurl_on_depend_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "WEBSITE_PAGEURL", "WEBSITE_PAGEURL", "PAGEURL", "DEPEND_PAGEURL");
            }
            if (this.inner_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }
            if (this.left_join_website_my_pageurl == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "WEBSITE_MY_PAGEURL", "WEBSITE_MY_PAGEURL", "PAGEURL", "PAGEURL");
            }
            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[WEBSITE_DEPEND](
                 [PAGEURL] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [DEPEND_PAGEURL] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [STATS_DATE] [DATETIME]  NOT NULL  CONSTRAINT [DF_WEBSITE_DEPEND_STATS_DATE] DEFAULT ('CONVERT[varchar]100') ,
                 [DEPEND_TIMEOUT] [BIGINT]  NOT NULL  CONSTRAINT [DF_WEBSITE_DEPEND_DEPEND_TIMEOUT] DEFAULT ('getdate') ,
                 [PAGEURL_REGEX] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL  CONSTRAINT [DF_WEBSITE_DEPEND_PAGEURL_REGEX] DEFAULT ('23') ,
                 [PAGEURL_DETAIL] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL  CONSTRAINT [DF_WEBSITE_DEPEND_PAGEURL_DETAIL] DEFAULT ('0') ,
                 [DEPEND_PAGEURL_REGEX] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DEPEND_PAGEURL_DETAIL] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DEPEND_CONTENT] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DEPEND_CONTENTTYPE] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DEPEND_CONTENTTYPE_ERROR] [INT]  NULL ,
                 [DEPEND_CONTENTLENGTH] [INT]  NULL ,
                 [DEPEND_COUNT] [INT]  NULL ,
                 [DEPEND_COUNT_ERROR] [INT]  NULL ,
                 [DEPEND_ERROR_RATE] [FLOAT]  (8)  NULL ,
                 [DEPEND_COUNT_TIMEOUT] [INT]  NULL ,
                 [DEPEND_TIMEOUT_RATE] [FLOAT]  (8)  NULL ,
                 [DEPEND_TIMESPAN_SUM] [BIGINT]  NULL ,
                 [DEPEND_TIMESPAN_MAX] [INT]  NULL ,
                 [DEPEND_TIMESPAN_MIN] [INT]  NULL ,
                 [DEPEND_TIMESPAN_NEW] [INT]  NULL ,
                 [DEPEND_TIMESPAN_AVERAGE] [INT]  NULL ,
                 [DEPEND_CREATETIME] [DATETIME]  NULL ,
                
                CONSTRAINT [PK_WEBSITE_DEPEND] PRIMARY KEY CLUSTERED 
                (
	             [PAGEURL] ASC,[DEPEND_PAGEURL] ASC,[STATS_DATE] ASC,[DEPEND_TIMEOUT] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本地URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'PAGEURL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部依赖的URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_PAGEURL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计日期 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'STATS_DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设置的超时时间（毫秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_TIMEOUT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本地URL的匹配正则 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'PAGEURL_REGEX'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL包括详细参数，记录的是最后一次的' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'PAGEURL_DETAIL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部依赖的URL的匹配正则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_PAGEURL_REGEX'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部依赖URL，包括详细参数，记录的是最后一次的' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_PAGEURL_DETAIL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_CONTENT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部依赖的类型（如：text/xml，text/html，text/xml等）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_CONTENTTYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据格式是否有错，0没错，1有错' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_CONTENTTYPE_ERROR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_CONTENTLENGTH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调用总次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_COUNT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求失败总次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_COUNT_ERROR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'失败率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_ERROR_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超时数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_COUNT_TIMEOUT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超时率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_TIMEOUT_RATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'累计总消耗时长（毫秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_TIMESPAN_SUM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消耗时长最大值（毫秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_TIMESPAN_MAX'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消耗时长最小值（毫秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_TIMESPAN_MIN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消耗时长最新值（毫秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_TIMESPAN_NEW'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消耗时长平均值（毫秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_TIMESPAN_AVERAGE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次调用外部依赖的时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_DEPEND', @level2type=N'COLUMN',@level2name=N'DEPEND_CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}