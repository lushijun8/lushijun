using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_MISSING_INDEX"
    /// Columns="DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE,TABLE_NAME,EQUALITY_COLUMNS,INEQUALITY_COLUMNS,INCLUDED_COLUMNS,STATEMENT,UNIQUE_COMPILES,USER_SEEKS,USER_SCANS,LAST_USER_SEEK,LAST_USER_SCAN,AVG_TOTAL_USER_COST,AVG_USER_IMPACT,SYSTEM_SEEKS,SYSTEM_SCANS,LAST_SYSTEM_SEEK,LAST_SYSTEM_SCAN,AVG_TOTAL_SYSTEM_COST,AVG_SYSTEM_IMPACT,CREATETIME,TOTAL_COST"
    /// PrimaryKeys="DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE"
    /// </summary>
    public sealed class DATABASE_MISSING_INDEX : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/4/29 16:59:10
        #region 属性
        /// <summary>
        /// 数据库IP  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
        /// </summary>
        public string DATABASE_IP_ROMOTE
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
        /// 数据库名称  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
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
        /// 统计日期  DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DATE_ToString 更加准确
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
        /// </summary>
        public DateTime DATE
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 统计日期  DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 DATE
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
        /// </summary>
        public string DATE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INDEX_HANDLE_ToString 更加准确
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
        /// </summary>
        public long INDEX_HANDLE
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 INDEX_HANDLE
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
        /// </summary>
        public string INDEX_HANDLE_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 GROUP_HANDLE_ToString 更加准确
        ///	默认值:0
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
        /// </summary>
        public long GROUP_HANDLE
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 GROUP_HANDLE
        ///	默认值:0
        ///	主健之一，其他主健还有：DATABASE_IP_ROMOTE,DATABASE_NAME,DATE,INDEX_HANDLE,GROUP_HANDLE
        /// </summary>
        public string GROUP_HANDLE_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 数据库表名  VARCHAR(50)  NULL
        /// </summary>
        public string TABLE_NAME
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
        /// 构成相等谓词的列的逗号分隔列表 即哪个字段缺失了索引会在这里列出来（简单来讲就是where 后面的筛选字段），谓词的形式如下：table.column =constant_value  VARCHAR(2000)  NULL
        /// </summary>
        public string EQUALITY_COLUMNS
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
        /// 构成不等谓词的列的逗号分隔列表，例如以下形式的谓词：table.column > constant_value “=”之外的任何比较运算符都表示不相等。  VARCHAR(2000)  NULL
        /// </summary>
        public string INEQUALITY_COLUMNS
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
        /// 用于查询的涵盖列的逗号分隔列表（简单来讲就是 select 后面的字段）。  VARCHAR(-1)  NULL
        /// </summary>
        public string INCLUDED_COLUMNS
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
        /// 索引缺失的表的名称  VARCHAR(100)  NULL
        /// </summary>
        public string STATEMENT
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
        /// 将从该缺失索引组受益的编译和重新编译数。  许多不同查询的编译和重新编译可影响该列值。  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 UNIQUE_COMPILES_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long UNIQUE_COMPILES
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 将从该缺失索引组受益的编译和重新编译数。  许多不同查询的编译和重新编译可影响该列值。  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 UNIQUE_COMPILES
        ///	默认值:0
        /// </summary>
        public string UNIQUE_COMPILES_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的查找次数。  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USER_SEEKS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long USER_SEEKS
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的查找次数。  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 USER_SEEKS
        ///	默认值:0
        /// </summary>
        public string USER_SEEKS_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的扫描次数。  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USER_SCANS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long USER_SCANS
        {
            set
            {
                ColumnValues[12] = value.ToString(); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的扫描次数。  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 USER_SCANS
        ///	默认值:0
        /// </summary>
        public string USER_SCANS_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的上次查找日期和时间。  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LAST_USER_SEEK_ToString 更加准确
        /// </summary>
        public DateTime LAST_USER_SEEK
        {
            set
            {
                ColumnValues[13] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的上次查找日期和时间。  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LAST_USER_SEEK
        /// </summary>
        public string LAST_USER_SEEK_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的上次扫描日期和时间。  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LAST_USER_SCAN_ToString 更加准确
        /// </summary>
        public DateTime LAST_USER_SCAN
        {
            set
            {
                ColumnValues[14] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的上次扫描日期和时间。  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LAST_USER_SCAN
        /// </summary>
        public string LAST_USER_SCAN_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 可通过组中的索引减少的用户查询的平均成本。  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 AVG_TOTAL_USER_COST_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal AVG_TOTAL_USER_COST
        {
            set
            {
                ColumnValues[15] = value.ToString(); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 可通过组中的索引减少的用户查询的平均成本。  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 AVG_TOTAL_USER_COST
        ///	默认值:0
        /// </summary>
        public string AVG_TOTAL_USER_COST_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        /// 实现此缺失索引组后，用户查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 AVG_USER_IMPACT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public decimal AVG_USER_IMPACT
        {
            set
            {
                ColumnValues[16] = value.ToString(); UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 实现此缺失索引组后，用户查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 AVG_USER_IMPACT
        ///	默认值:0
        /// </summary>
        public string AVG_USER_IMPACT_ToString
        {
            get
            {
                return ColumnValues[16];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询（如自动统计信息查询）所导致的查找次数。  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SYSTEM_SEEKS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long SYSTEM_SEEKS
        {
            set
            {
                ColumnValues[17] = value.ToString(); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询（如自动统计信息查询）所导致的查找次数。  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SYSTEM_SEEKS
        ///	默认值:0
        /// </summary>
        public string SYSTEM_SEEKS_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的扫描次数。  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 SYSTEM_SCANS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long SYSTEM_SCANS
        {
            set
            {
                ColumnValues[18] = value.ToString(); UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的扫描次数。  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 SYSTEM_SCANS
        ///	默认值:0
        /// </summary>
        public string SYSTEM_SCANS_ToString
        {
            get
            {
                return ColumnValues[18];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的上次系统查找日期和时间。  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LAST_SYSTEM_SEEK_ToString 更加准确
        /// </summary>
        public DateTime LAST_SYSTEM_SEEK
        {
            set
            {
                ColumnValues[19] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的上次系统查找日期和时间。  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LAST_SYSTEM_SEEK
        /// </summary>
        public string LAST_SYSTEM_SEEK_ToString
        {
            get
            {
                return ColumnValues[19];
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的上次系统扫描日期和时间。  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LAST_SYSTEM_SCAN_ToString 更加准确
        /// </summary>
        public DateTime LAST_SYSTEM_SCAN
        {
            set
            {
                ColumnValues[20] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的上次系统扫描日期和时间。  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LAST_SYSTEM_SCAN
        /// </summary>
        public string LAST_SYSTEM_SCAN_ToString
        {
            get
            {
                return ColumnValues[20];
            }
        }
        /// <summary>
        /// 可通过组中的索引减少的系统查询的平均成本。  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 AVG_TOTAL_SYSTEM_COST_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long AVG_TOTAL_SYSTEM_COST
        {
            set
            {
                ColumnValues[21] = value.ToString(); UpdateStatus[21] = 1;
            }
        }
        /// <summary>
        /// 可通过组中的索引减少的系统查询的平均成本。  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 AVG_TOTAL_SYSTEM_COST
        ///	默认值:0
        /// </summary>
        public string AVG_TOTAL_SYSTEM_COST_ToString
        {
            get
            {
                return ColumnValues[21];
            }
        }
        /// <summary>
        /// 实现此缺失索引组后，系统查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。   BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 AVG_SYSTEM_IMPACT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long AVG_SYSTEM_IMPACT
        {
            set
            {
                ColumnValues[22] = value.ToString(); UpdateStatus[22] = 1;
            }
        }
        /// <summary>
        /// 实现此缺失索引组后，系统查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。   BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 AVG_SYSTEM_IMPACT
        ///	默认值:0
        /// </summary>
        public string AVG_SYSTEM_IMPACT_ToString
        {
            get
            {
                return ColumnValues[22];
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
                ColumnValues[23] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[23] = 1;
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
                return ColumnValues[23];
            }
        }
        /// <summary>
        /// 可节省总开销  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TOTAL_COST_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public long TOTAL_COST
        {
            set
            {
                ColumnValues[24] = value.ToString(); UpdateStatus[24] = 1;
            }
        }
        /// <summary>
        /// 可节省总开销  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TOTAL_COST
        ///	默认值:0
        /// </summary>
        public string TOTAL_COST_ToString
        {
            get
            {
                return ColumnValues[24];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 数据库IP 返回 "DATABASE_IP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_ROMOTE = "DATABASE_IP_ROMOTE";
        /// <summary>
        /// 数据库名称 返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 统计日期 返回 "DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATE = "DATE";
        /// <summary>
        ///   返回 "INDEX_HANDLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INDEX_HANDLE = "INDEX_HANDLE";
        /// <summary>
        ///   返回 "GROUP_HANDLE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _GROUP_HANDLE = "GROUP_HANDLE";
        /// <summary>
        /// 数据库表名 返回 "TABLE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TABLE_NAME = "TABLE_NAME";
        /// <summary>
        /// 构成相等谓词的列的逗号分隔列表 即哪个字段缺失了索引会在这里列出来（简单来讲就是where 后面的筛选字段），谓词的形式如下：table.column =constant_value 返回 "EQUALITY_COLUMNS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EQUALITY_COLUMNS = "EQUALITY_COLUMNS";
        /// <summary>
        /// 构成不等谓词的列的逗号分隔列表，例如以下形式的谓词：table.column > constant_value “=”之外的任何比较运算符都表示不相等。 返回 "INEQUALITY_COLUMNS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INEQUALITY_COLUMNS = "INEQUALITY_COLUMNS";
        /// <summary>
        /// 用于查询的涵盖列的逗号分隔列表（简单来讲就是 select 后面的字段）。 返回 "INCLUDED_COLUMNS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INCLUDED_COLUMNS = "INCLUDED_COLUMNS";
        /// <summary>
        /// 索引缺失的表的名称 返回 "STATEMENT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATEMENT = "STATEMENT";
        /// <summary>
        /// 将从该缺失索引组受益的编译和重新编译数。  许多不同查询的编译和重新编译可影响该列值。 返回 "UNIQUE_COMPILES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _UNIQUE_COMPILES = "UNIQUE_COMPILES";
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的查找次数。 返回 "USER_SEEKS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USER_SEEKS = "USER_SEEKS";
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的扫描次数。 返回 "USER_SCANS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USER_SCANS = "USER_SCANS";
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的上次查找日期和时间。 返回 "LAST_USER_SEEK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LAST_USER_SEEK = "LAST_USER_SEEK";
        /// <summary>
        /// 由可能使用了组中建议索引的用户查询所导致的上次扫描日期和时间。 返回 "LAST_USER_SCAN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LAST_USER_SCAN = "LAST_USER_SCAN";
        /// <summary>
        /// 可通过组中的索引减少的用户查询的平均成本。 返回 "AVG_TOTAL_USER_COST", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AVG_TOTAL_USER_COST = "AVG_TOTAL_USER_COST";
        /// <summary>
        /// 实现此缺失索引组后，用户查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。 返回 "AVG_USER_IMPACT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AVG_USER_IMPACT = "AVG_USER_IMPACT";
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询（如自动统计信息查询）所导致的查找次数。 返回 "SYSTEM_SEEKS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SYSTEM_SEEKS = "SYSTEM_SEEKS";
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的扫描次数。 返回 "SYSTEM_SCANS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SYSTEM_SCANS = "SYSTEM_SCANS";
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的上次系统查找日期和时间。 返回 "LAST_SYSTEM_SEEK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LAST_SYSTEM_SEEK = "LAST_SYSTEM_SEEK";
        /// <summary>
        /// 由可能使用了组中建议索引的系统查询所导致的上次系统扫描日期和时间。 返回 "LAST_SYSTEM_SCAN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LAST_SYSTEM_SCAN = "LAST_SYSTEM_SCAN";
        /// <summary>
        /// 可通过组中的索引减少的系统查询的平均成本。 返回 "AVG_TOTAL_SYSTEM_COST", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AVG_TOTAL_SYSTEM_COST = "AVG_TOTAL_SYSTEM_COST";
        /// <summary>
        /// 实现此缺失索引组后，系统查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。  返回 "AVG_SYSTEM_IMPACT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AVG_SYSTEM_IMPACT = "AVG_SYSTEM_IMPACT";
        /// <summary>
        ///   返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 可节省总开销 返回 "TOTAL_COST", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TOTAL_COST = "TOTAL_COST";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_MISSING_INDEX的构造函数
        /// </summary>
        public DATABASE_MISSING_INDEX()
        {
            this.TableName = "DATABASE_MISSING_INDEX";
            this.PrimaryKey = new string[] { _DATABASE_IP_ROMOTE, _DATABASE_NAME, _DATE, _INDEX_HANDLE, _GROUP_HANDLE };

            this.columns = new string[] { _DATABASE_IP_ROMOTE, _DATABASE_NAME, _DATE, _INDEX_HANDLE, _GROUP_HANDLE, _TABLE_NAME, _EQUALITY_COLUMNS, _INEQUALITY_COLUMNS, _INCLUDED_COLUMNS, _STATEMENT, _UNIQUE_COMPILES, _USER_SEEKS, _USER_SCANS, _LAST_USER_SEEK, _LAST_USER_SCAN, _AVG_TOTAL_USER_COST, _AVG_USER_IMPACT, _SYSTEM_SEEKS, _SYSTEM_SCANS, _LAST_SYSTEM_SEEK, _LAST_SYSTEM_SCAN, _AVG_TOTAL_SYSTEM_COST, _AVG_SYSTEM_IMPACT, _CREATETIME, _TOTAL_COST };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_MISSING_INDEX的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, DATETIME, BIGINT, BIGINT, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, BIGINT, BIGINT, BIGINT, DATETIME, DATETIME, FLOAT, FLOAT, BIGINT, BIGINT, DATETIME, DATETIME, BIGINT, BIGINT, DATETIME, BIGINT };
                this.Lengths = new int[] { 50, 50, 8, 8, 8, 100, 2000, 2000, -1, 100, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", "0", " ", " ", " ", " ", " ", "0", "0", "0", " ", " ", "0", "0", "0", "0", " ", " ", "0", "0", "getdate", "0" };
                this.Descriptions = new string[] { "数据库IP", "数据库名称", "统计日期", " ", " ", "数据库表名", "构成相等谓词的列的逗号分隔列表 即哪个字段缺失了索引会在这里列出来（简单来讲就是where 后面的筛选字段），谓词的形式如下：table.column =constant_value", "构成不等谓词的列的逗号分隔列表，例如以下形式的谓词：table.column > constant_value “=”之外的任何比较运算符都表示不相等。", "用于查询的涵盖列的逗号分隔列表（简单来讲就是 select 后面的字段）。", "索引缺失的表的名称", "将从该缺失索引组受益的编译和重新编译数。  许多不同查询的编译和重新编译可影响该列值。", "由可能使用了组中建议索引的用户查询所导致的查找次数。", "由可能使用了组中建议索引的用户查询所导致的扫描次数。", "由可能使用了组中建议索引的用户查询所导致的上次查找日期和时间。", "由可能使用了组中建议索引的用户查询所导致的上次扫描日期和时间。", "可通过组中的索引减少的用户查询的平均成本。", "实现此缺失索引组后，用户查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。", "由可能使用了组中建议索引的系统查询（如自动统计信息查询）所导致的查找次数。", "由可能使用了组中建议索引的系统查询所导致的扫描次数。", "由可能使用了组中建议索引的系统查询所导致的上次系统查找日期和时间。", "由可能使用了组中建议索引的系统查询所导致的上次系统扫描日期和时间。", "可通过组中的索引减少的系统查询的平均成本。", "实现此缺失索引组后，系统查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。 ", " ", "可节省总开销" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_IP_ROMOTE">数据库IP</param>
        /// <param name="DATABASE_NAME">数据库名称</param>
        /// <param name="DATE">统计日期</param>
        /// <param name="INDEX_HANDLE"> </param>
        /// <param name="GROUP_HANDLE"> </param>
                /// <returns>bool</returns>
                public bool Find(string P_DATABASE_IP_ROMOTE,string P_DATABASE_NAME,DateTime P_DATE,long P_INDEX_HANDLE,long P_GROUP_HANDLE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_IP_ROMOTE;
        this.ColumnValues[1]=P_DATABASE_NAME;
        this.ColumnValues[2]=P_DATE.ToString();
        this.ColumnValues[3]=P_INDEX_HANDLE.ToString();
        this.ColumnValues[4]=P_GROUP_HANDLE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_MISSING_INDEX（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_MISSING_INDEX Copy()
                {
                    DATABASE_MISSING_INDEX new_obj=new DATABASE_MISSING_INDEX();
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

        private bool inner_join_database_table = false;
        private bool left_join_database_table = false;
        private bool right_join_database_table = false;

        /// <summary>
        /// INNER JOIN DATABASE_TABLE DATABASE_TABLE  ON DATABASE_TABLE.DATABASE_NAME=DATABASE_MISSING_INDEX.DATABASE_NAME AND DATABASE_TABLE.TABLE_NAME=DATABASE_MISSING_INDEX.TABLE_NAME  AND DATABASE_TABLE.COUNTDATE=DATABASE_MISSING_INDEX.DATE
        /// </summary>
        public bool INNER_JOIN_DATABASE_TABLE
        {
            set
            {
                this.inner_join_database_table = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN DATABASE_TABLE DATABASE_TABLE  ON DATABASE_TABLE.DATABASE_NAME=DATABASE_MISSING_INDEX.DATABASE_NAME AND DATABASE_TABLE.TABLE_NAME=DATABASE_MISSING_INDEX.TABLE_NAME  AND DATABASE_TABLE.COUNTDATE=DATABASE_MISSING_INDEX.DATE
        /// </summary>
        public bool LEFT_JOIN_DATABASE_TABLE
        {
            set
            {
                this.left_join_database_table = value;
            }
        }
        /// <summary>
        /// RIGHT OUTER JOIN DATABASE_TABLE DATABASE_TABLE  ON DATABASE_TABLE.DATABASE_NAME=DATABASE_MISSING_INDEX.DATABASE_NAME AND DATABASE_TABLE.TABLE_NAME=DATABASE_MISSING_INDEX.TABLE_NAME  AND DATABASE_TABLE.COUNTDATE=DATABASE_MISSING_INDEX.DATE
        /// </summary>
        public bool RIGHT_JOIN_DATABASE_TABLE
        {
            set
            {
                this.right_join_database_table = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_DATABASE_TABLE
        /// LEFT_JOIN_DATABASE_TABLE
        /// RIGHT_JOIN_DATABASE_TABLE
        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_database_table == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "DATABASE_TABLE", "DATABASE_TABLE", "DATABASE_NAME", "DATABASE_NAME", "TABLE_NAME", "TABLE_NAME", "COUNTDATE", "DATE");
            }
            if (this.left_join_database_table == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "DATABASE_TABLE", "DATABASE_TABLE", "DATABASE_NAME", "DATABASE_NAME", "TABLE_NAME", "TABLE_NAME", "COUNTDATE", "DATE");
            }
            if (this.right_join_database_table == true)
            {
                this.NewJoin("TEAMTOOL", "RIGHT OUTER", "DATABASE_TABLE", "DATABASE_TABLE", "DATABASE_NAME", "DATABASE_NAME", "TABLE_NAME", "TABLE_NAME", "COUNTDATE", "DATE");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[DATABASE_MISSING_INDEX](
                 [DATABASE_IP_ROMOTE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [DATE] [DATETIME]  NOT NULL ,
                 [INDEX_HANDLE] [BIGINT]  NOT NULL ,
                 [GROUP_HANDLE] [BIGINT]  NOT NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_GROUP_HANDLE] DEFAULT ('0') ,
                 [TABLE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [EQUALITY_COLUMNS] [VARCHAR]  (2000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [INEQUALITY_COLUMNS] [VARCHAR]  (2000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [INCLUDED_COLUMNS] [VARCHAR]  (-1)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [STATEMENT] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [UNIQUE_COMPILES] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_UNIQUE_COMPILES] DEFAULT ('0') ,
                 [USER_SEEKS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_USER_SEEKS] DEFAULT ('0') ,
                 [USER_SCANS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_USER_SCANS] DEFAULT ('0') ,
                 [LAST_USER_SEEK] [DATETIME]  NULL ,
                 [LAST_USER_SCAN] [DATETIME]  NULL ,
                 [AVG_TOTAL_USER_COST] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_AVG_TOTAL_USER_COST] DEFAULT ('0') ,
                 [AVG_USER_IMPACT] [FLOAT]  (8)  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_AVG_USER_IMPACT] DEFAULT ('0') ,
                 [SYSTEM_SEEKS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_SYSTEM_SEEKS] DEFAULT ('0') ,
                 [SYSTEM_SCANS] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_SYSTEM_SCANS] DEFAULT ('0') ,
                 [LAST_SYSTEM_SEEK] [DATETIME]  NULL ,
                 [LAST_SYSTEM_SCAN] [DATETIME]  NULL ,
                 [AVG_TOTAL_SYSTEM_COST] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_AVG_TOTAL_SYSTEM_COST] DEFAULT ('0') ,
                 [AVG_SYSTEM_IMPACT] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_AVG_SYSTEM_IMPACT] DEFAULT ('0') ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_CREATETIME] DEFAULT ('getdate') ,
                 [TOTAL_COST] [BIGINT]  NULL  CONSTRAINT [DF_DATABASE_MISSING_INDEX_TOTAL_COST] DEFAULT ('0') ,
                
                CONSTRAINT [PK_DATABASE_MISSING_INDEX] PRIMARY KEY CLUSTERED 
                (
	             [DATABASE_IP_ROMOTE] ASC,[DATABASE_NAME] ASC,[DATE] ASC,[INDEX_HANDLE] ASC,[GROUP_HANDLE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_ROMOTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'TABLE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'构成相等谓词的列的逗号分隔列表 即哪个字段缺失了索引会在这里列出来（简单来讲就是where 后面的筛选字段），谓词的形式如下：table.column =constant_value' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'EQUALITY_COLUMNS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'构成不等谓词的列的逗号分隔列表，例如以下形式的谓词：table.column > constant_value “=”之外的任何比较运算符都表示不相等。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'INEQUALITY_COLUMNS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用于查询的涵盖列的逗号分隔列表（简单来讲就是 select 后面的字段）。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'INCLUDED_COLUMNS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'索引缺失的表的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'STATEMENT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'将从该缺失索引组受益的编译和重新编译数。  许多不同查询的编译和重新编译可影响该列值。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'UNIQUE_COMPILES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的用户查询所导致的查找次数。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'USER_SEEKS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的用户查询所导致的扫描次数。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'USER_SCANS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的用户查询所导致的上次查找日期和时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'LAST_USER_SEEK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的用户查询所导致的上次扫描日期和时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'LAST_USER_SCAN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可通过组中的索引减少的用户查询的平均成本。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'AVG_TOTAL_USER_COST'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实现此缺失索引组后，用户查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'AVG_USER_IMPACT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的系统查询（如自动统计信息查询）所导致的查找次数。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'SYSTEM_SEEKS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的系统查询所导致的扫描次数。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'SYSTEM_SCANS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的系统查询所导致的上次系统查找日期和时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'LAST_SYSTEM_SEEK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由可能使用了组中建议索引的系统查询所导致的上次系统扫描日期和时间。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'LAST_SYSTEM_SCAN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可通过组中的索引减少的系统查询的平均成本。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'AVG_TOTAL_SYSTEM_COST'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实现此缺失索引组后，系统查询可能获得的平均百分比收益。  该值表示如果实现此缺失索引组，则查询成本将按此百分比平均下降。 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'AVG_SYSTEM_IMPACT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可节省总开销' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_MISSING_INDEX', @level2type=N'COLUMN',@level2name=N'TOTAL_COST'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}