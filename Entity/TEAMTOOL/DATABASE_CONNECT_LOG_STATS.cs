
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_CONNECT_LOG_STATS"
    /// Columns="ID,PAGEURL,QUERYSTRING,FORM,QUERYSTRING_PHONE_ENCRYPT,FORM_PHONE_ENCRYPT,CONNECT_DATE,REQUEST_COUNT,DURATION_MIN,DURATION_MAX,DURATION_SUM,TEAMNAME,SERVERNAME,CONNECTIONSTRING_CHANNELSALES_READ_MIN,CONNECTIONSTRING_CHANNELSALES_WRITER_MIN,CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN,CONNECTIONSTRING_TUAN_READSTATIC_MIN,CONNECTIONSTRING_TUAN_READ_MIN,CONNECTIONSTRING_TUAN_WRITER_MIN,CONNECTIONSTRING_RECORDREAD_MIN,CONNECTIONSTRING_RECORDWRITE_MIN,CONNECTIONSTRING_NORTH_REALTY_READ_MIN,CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN,CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN,CONNECTIONSTRING_SOUTH_REALTY_READ_MIN,CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN,CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN,CONNECTIONSTRING_GLHT_MONITOR_READ_MIN,CHANNELSALES_CONN_READ_MIN,TUANMALL_CONN_READ_MIN,TUAN_CONN_READ_MIN,CONNECTIONSTRING_CHANNELSALES_READ_MAX,CONNECTIONSTRING_CHANNELSALES_WRITER_MAX,CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX,CONNECTIONSTRING_TUAN_READSTATIC_MAX,CONNECTIONSTRING_TUAN_READ_MAX,CONNECTIONSTRING_TUAN_WRITER_MAX,CONNECTIONSTRING_RECORDREAD_MAX,CONNECTIONSTRING_RECORDWRITE_MAX,CONNECTIONSTRING_NORTH_REALTY_READ_MAX,CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX,CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX,CONNECTIONSTRING_SOUTH_REALTY_READ_MAX,CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX,CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX,CONNECTIONSTRING_GLHT_MONITOR_READ_MAX,CHANNELSALES_CONN_READ_MAX,TUANMALL_CONN_READ_MAX,TUAN_CONN_READ_MAX,CONNECTIONSTRING_CHANNELSALES_READ_SUM,CONNECTIONSTRING_CHANNELSALES_WRITER_SUM,CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM,CONNECTIONSTRING_TUAN_READSTATIC_SUM,CONNECTIONSTRING_TUAN_READ_SUM,CONNECTIONSTRING_TUAN_WRITER_SUM,CONNECTIONSTRING_RECORDREAD_SUM,CONNECTIONSTRING_RECORDWRITE_SUM,CONNECTIONSTRING_NORTH_REALTY_READ_SUM,CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM,CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM,CONNECTIONSTRING_SOUTH_REALTY_READ_SUM,CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM,CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM,CONNECTIONSTRING_GLHT_MONITOR_READ_SUM,CHANNELSALES_CONN_READ_SUM,TUANMALL_CONN_READ_SUM,TUAN_CONN_READ_SUM,CREATETIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class DATABASE_CONNECT_LOG_STATS : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/10/9 13:01:21
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
        ///    VARCHAR(4000)  NULL
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
        ///    VARCHAR(4000)  NULL
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
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 QUERYSTRING_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int QUERYSTRING_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 QUERYSTRING_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string QUERYSTRING_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FORM_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int FORM_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FORM_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string FORM_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECT_DATE_ToString 更加准确
        /// </summary>
        public DateTime CONNECT_DATE
        {
            set
            {
                ColumnValues[6] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECT_DATE
        /// </summary>
        public string CONNECT_DATE_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 REQUEST_COUNT_ToString 更加准确
        /// </summary>
        public int REQUEST_COUNT
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 REQUEST_COUNT
        /// </summary>
        public string REQUEST_COUNT_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_MIN_ToString 更加准确
        /// </summary>
        public int DURATION_MIN
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION_MIN
        /// </summary>
        public string DURATION_MIN_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_MAX_ToString 更加准确
        /// </summary>
        public int DURATION_MAX
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION_MAX
        /// </summary>
        public string DURATION_MAX_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DURATION_SUM_ToString 更加准确
        /// </summary>
        public int DURATION_SUM
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DURATION_SUM
        /// </summary>
        public string DURATION_SUM_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 团队名称  VARCHAR(50)  NULL
        /// </summary>
        public string TEAMNAME
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
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string SERVERNAME
        {
            get
            {
                return ColumnValues[12];
            }
            set
            {
                ColumnValues[12] = value; UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_READ_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_READ_MIN
        {
            set
            {
                ColumnValues[13] = value.ToString(); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_READ_MIN
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_WRITER_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_WRITER_MIN
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_WRITER_MIN
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_WRITER_MIN_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN
        {
            set
            {
                ColumnValues[15] = value.ToString(); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_READSTATIC_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_READSTATIC_MIN
        {
            set
            {
                ColumnValues[16] = value.ToString(); UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_READSTATIC_MIN
        /// </summary>
        public string CONNECTIONSTRING_TUAN_READSTATIC_MIN_ToString
        {
            get
            {
                return ColumnValues[16];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_READ_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_READ_MIN
        {
            set
            {
                ColumnValues[17] = value.ToString(); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_READ_MIN
        /// </summary>
        public string CONNECTIONSTRING_TUAN_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_WRITER_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_WRITER_MIN
        {
            set
            {
                ColumnValues[18] = value.ToString(); UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_WRITER_MIN
        /// </summary>
        public string CONNECTIONSTRING_TUAN_WRITER_MIN_ToString
        {
            get
            {
                return ColumnValues[18];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_RECORDREAD_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_RECORDREAD_MIN
        {
            set
            {
                ColumnValues[19] = value.ToString(); UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_RECORDREAD_MIN
        /// </summary>
        public string CONNECTIONSTRING_RECORDREAD_MIN_ToString
        {
            get
            {
                return ColumnValues[19];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_RECORDWRITE_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_RECORDWRITE_MIN
        {
            set
            {
                ColumnValues[20] = value.ToString(); UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_RECORDWRITE_MIN
        /// </summary>
        public string CONNECTIONSTRING_RECORDWRITE_MIN_ToString
        {
            get
            {
                return ColumnValues[20];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_READ_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_READ_MIN
        {
            set
            {
                ColumnValues[21] = value.ToString(); UpdateStatus[21] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_READ_MIN
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[21];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN
        {
            set
            {
                ColumnValues[22] = value.ToString(); UpdateStatus[22] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN_ToString
        {
            get
            {
                return ColumnValues[22];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN
        {
            set
            {
                ColumnValues[23] = value.ToString(); UpdateStatus[23] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN_ToString
        {
            get
            {
                return ColumnValues[23];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_READ_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_READ_MIN
        {
            set
            {
                ColumnValues[24] = value.ToString(); UpdateStatus[24] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_READ_MIN
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[24];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN
        {
            set
            {
                ColumnValues[25] = value.ToString(); UpdateStatus[25] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN_ToString
        {
            get
            {
                return ColumnValues[25];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN
        {
            set
            {
                ColumnValues[26] = value.ToString(); UpdateStatus[26] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN_ToString
        {
            get
            {
                return ColumnValues[26];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_GLHT_MONITOR_READ_MIN_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_GLHT_MONITOR_READ_MIN
        {
            set
            {
                ColumnValues[27] = value.ToString(); UpdateStatus[27] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_GLHT_MONITOR_READ_MIN
        /// </summary>
        public string CONNECTIONSTRING_GLHT_MONITOR_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[27];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CHANNELSALES_CONN_READ_MIN_ToString 更加准确
        /// </summary>
        public int CHANNELSALES_CONN_READ_MIN
        {
            set
            {
                ColumnValues[28] = value.ToString(); UpdateStatus[28] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CHANNELSALES_CONN_READ_MIN
        /// </summary>
        public string CHANNELSALES_CONN_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[28];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TUANMALL_CONN_READ_MIN_ToString 更加准确
        /// </summary>
        public int TUANMALL_CONN_READ_MIN
        {
            set
            {
                ColumnValues[29] = value.ToString(); UpdateStatus[29] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TUANMALL_CONN_READ_MIN
        /// </summary>
        public string TUANMALL_CONN_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[29];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TUAN_CONN_READ_MIN_ToString 更加准确
        /// </summary>
        public int TUAN_CONN_READ_MIN
        {
            set
            {
                ColumnValues[30] = value.ToString(); UpdateStatus[30] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TUAN_CONN_READ_MIN
        /// </summary>
        public string TUAN_CONN_READ_MIN_ToString
        {
            get
            {
                return ColumnValues[30];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_READ_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_READ_MAX
        {
            set
            {
                ColumnValues[31] = value.ToString(); UpdateStatus[31] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_READ_MAX
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[31];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_WRITER_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_WRITER_MAX
        {
            set
            {
                ColumnValues[32] = value.ToString(); UpdateStatus[32] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_WRITER_MAX
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_WRITER_MAX_ToString
        {
            get
            {
                return ColumnValues[32];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX
        {
            set
            {
                ColumnValues[33] = value.ToString(); UpdateStatus[33] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX_ToString
        {
            get
            {
                return ColumnValues[33];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_READSTATIC_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_READSTATIC_MAX
        {
            set
            {
                ColumnValues[34] = value.ToString(); UpdateStatus[34] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_READSTATIC_MAX
        /// </summary>
        public string CONNECTIONSTRING_TUAN_READSTATIC_MAX_ToString
        {
            get
            {
                return ColumnValues[34];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_READ_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_READ_MAX
        {
            set
            {
                ColumnValues[35] = value.ToString(); UpdateStatus[35] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_READ_MAX
        /// </summary>
        public string CONNECTIONSTRING_TUAN_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[35];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_WRITER_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_WRITER_MAX
        {
            set
            {
                ColumnValues[36] = value.ToString(); UpdateStatus[36] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_WRITER_MAX
        /// </summary>
        public string CONNECTIONSTRING_TUAN_WRITER_MAX_ToString
        {
            get
            {
                return ColumnValues[36];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_RECORDREAD_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_RECORDREAD_MAX
        {
            set
            {
                ColumnValues[37] = value.ToString(); UpdateStatus[37] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_RECORDREAD_MAX
        /// </summary>
        public string CONNECTIONSTRING_RECORDREAD_MAX_ToString
        {
            get
            {
                return ColumnValues[37];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_RECORDWRITE_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_RECORDWRITE_MAX
        {
            set
            {
                ColumnValues[38] = value.ToString(); UpdateStatus[38] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_RECORDWRITE_MAX
        /// </summary>
        public string CONNECTIONSTRING_RECORDWRITE_MAX_ToString
        {
            get
            {
                return ColumnValues[38];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_READ_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_READ_MAX
        {
            set
            {
                ColumnValues[39] = value.ToString(); UpdateStatus[39] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_READ_MAX
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[39];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX
        {
            set
            {
                ColumnValues[40] = value.ToString(); UpdateStatus[40] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX_ToString
        {
            get
            {
                return ColumnValues[40];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX
        {
            set
            {
                ColumnValues[41] = value.ToString(); UpdateStatus[41] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX_ToString
        {
            get
            {
                return ColumnValues[41];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_READ_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_READ_MAX
        {
            set
            {
                ColumnValues[42] = value.ToString(); UpdateStatus[42] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_READ_MAX
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[42];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX
        {
            set
            {
                ColumnValues[43] = value.ToString(); UpdateStatus[43] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX_ToString
        {
            get
            {
                return ColumnValues[43];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX
        {
            set
            {
                ColumnValues[44] = value.ToString(); UpdateStatus[44] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX_ToString
        {
            get
            {
                return ColumnValues[44];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_GLHT_MONITOR_READ_MAX_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_GLHT_MONITOR_READ_MAX
        {
            set
            {
                ColumnValues[45] = value.ToString(); UpdateStatus[45] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_GLHT_MONITOR_READ_MAX
        /// </summary>
        public string CONNECTIONSTRING_GLHT_MONITOR_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[45];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CHANNELSALES_CONN_READ_MAX_ToString 更加准确
        /// </summary>
        public int CHANNELSALES_CONN_READ_MAX
        {
            set
            {
                ColumnValues[46] = value.ToString(); UpdateStatus[46] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CHANNELSALES_CONN_READ_MAX
        /// </summary>
        public string CHANNELSALES_CONN_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[46];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TUANMALL_CONN_READ_MAX_ToString 更加准确
        /// </summary>
        public int TUANMALL_CONN_READ_MAX
        {
            set
            {
                ColumnValues[47] = value.ToString(); UpdateStatus[47] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TUANMALL_CONN_READ_MAX
        /// </summary>
        public string TUANMALL_CONN_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[47];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TUAN_CONN_READ_MAX_ToString 更加准确
        /// </summary>
        public int TUAN_CONN_READ_MAX
        {
            set
            {
                ColumnValues[48] = value.ToString(); UpdateStatus[48] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TUAN_CONN_READ_MAX
        /// </summary>
        public string TUAN_CONN_READ_MAX_ToString
        {
            get
            {
                return ColumnValues[48];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_READ_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_READ_SUM
        {
            set
            {
                ColumnValues[49] = value.ToString(); UpdateStatus[49] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_READ_SUM
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[49];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_WRITER_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_WRITER_SUM
        {
            set
            {
                ColumnValues[50] = value.ToString(); UpdateStatus[50] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_WRITER_SUM
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_WRITER_SUM_ToString
        {
            get
            {
                return ColumnValues[50];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM
        {
            set
            {
                ColumnValues[51] = value.ToString(); UpdateStatus[51] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM
        /// </summary>
        public string CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM_ToString
        {
            get
            {
                return ColumnValues[51];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_READSTATIC_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_READSTATIC_SUM
        {
            set
            {
                ColumnValues[52] = value.ToString(); UpdateStatus[52] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_READSTATIC_SUM
        /// </summary>
        public string CONNECTIONSTRING_TUAN_READSTATIC_SUM_ToString
        {
            get
            {
                return ColumnValues[52];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_READ_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_READ_SUM
        {
            set
            {
                ColumnValues[53] = value.ToString(); UpdateStatus[53] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_READ_SUM
        /// </summary>
        public string CONNECTIONSTRING_TUAN_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[53];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_TUAN_WRITER_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_TUAN_WRITER_SUM
        {
            set
            {
                ColumnValues[54] = value.ToString(); UpdateStatus[54] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_TUAN_WRITER_SUM
        /// </summary>
        public string CONNECTIONSTRING_TUAN_WRITER_SUM_ToString
        {
            get
            {
                return ColumnValues[54];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_RECORDREAD_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_RECORDREAD_SUM
        {
            set
            {
                ColumnValues[55] = value.ToString(); UpdateStatus[55] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_RECORDREAD_SUM
        /// </summary>
        public string CONNECTIONSTRING_RECORDREAD_SUM_ToString
        {
            get
            {
                return ColumnValues[55];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_RECORDWRITE_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_RECORDWRITE_SUM
        {
            set
            {
                ColumnValues[56] = value.ToString(); UpdateStatus[56] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_RECORDWRITE_SUM
        /// </summary>
        public string CONNECTIONSTRING_RECORDWRITE_SUM_ToString
        {
            get
            {
                return ColumnValues[56];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_READ_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_READ_SUM
        {
            set
            {
                ColumnValues[57] = value.ToString(); UpdateStatus[57] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_READ_SUM
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[57];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM
        {
            set
            {
                ColumnValues[58] = value.ToString(); UpdateStatus[58] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM_ToString
        {
            get
            {
                return ColumnValues[58];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM
        {
            set
            {
                ColumnValues[59] = value.ToString(); UpdateStatus[59] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM
        /// </summary>
        public string CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM_ToString
        {
            get
            {
                return ColumnValues[59];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_READ_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_READ_SUM
        {
            set
            {
                ColumnValues[60] = value.ToString(); UpdateStatus[60] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_READ_SUM
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[60];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM
        {
            set
            {
                ColumnValues[61] = value.ToString(); UpdateStatus[61] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM_ToString
        {
            get
            {
                return ColumnValues[61];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM
        {
            set
            {
                ColumnValues[62] = value.ToString(); UpdateStatus[62] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM
        /// </summary>
        public string CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM_ToString
        {
            get
            {
                return ColumnValues[62];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTIONSTRING_GLHT_MONITOR_READ_SUM_ToString 更加准确
        /// </summary>
        public int CONNECTIONSTRING_GLHT_MONITOR_READ_SUM
        {
            set
            {
                ColumnValues[63] = value.ToString(); UpdateStatus[63] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTIONSTRING_GLHT_MONITOR_READ_SUM
        /// </summary>
        public string CONNECTIONSTRING_GLHT_MONITOR_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[63];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CHANNELSALES_CONN_READ_SUM_ToString 更加准确
        /// </summary>
        public int CHANNELSALES_CONN_READ_SUM
        {
            set
            {
                ColumnValues[64] = value.ToString(); UpdateStatus[64] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CHANNELSALES_CONN_READ_SUM
        /// </summary>
        public string CHANNELSALES_CONN_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[64];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TUANMALL_CONN_READ_SUM_ToString 更加准确
        /// </summary>
        public int TUANMALL_CONN_READ_SUM
        {
            set
            {
                ColumnValues[65] = value.ToString(); UpdateStatus[65] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TUANMALL_CONN_READ_SUM
        /// </summary>
        public string TUANMALL_CONN_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[65];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TUAN_CONN_READ_SUM_ToString 更加准确
        /// </summary>
        public int TUAN_CONN_READ_SUM
        {
            set
            {
                ColumnValues[66] = value.ToString(); UpdateStatus[66] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TUAN_CONN_READ_SUM
        /// </summary>
        public string TUAN_CONN_READ_SUM_ToString
        {
            get
            {
                return ColumnValues[66];
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[67] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[67] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[67];
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
        ///   返回 "QUERYSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING = "QUERYSTRING";
        /// <summary>
        /// 请求Form参数 返回 "FORM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM = "FORM";
        /// <summary>
        ///   返回 "QUERYSTRING_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING_PHONE_ENCRYPT = "QUERYSTRING_PHONE_ENCRYPT";
        /// <summary>
        ///   返回 "FORM_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM_PHONE_ENCRYPT = "FORM_PHONE_ENCRYPT";
        /// <summary>
        ///   返回 "CONNECT_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECT_DATE = "CONNECT_DATE";
        /// <summary>
        ///   返回 "REQUEST_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REQUEST_COUNT = "REQUEST_COUNT";
        /// <summary>
        ///   返回 "DURATION_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION_MIN = "DURATION_MIN";
        /// <summary>
        ///   返回 "DURATION_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION_MAX = "DURATION_MAX";
        /// <summary>
        ///   返回 "DURATION_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DURATION_SUM = "DURATION_SUM";
        /// <summary>
        /// 团队名称 返回 "TEAMNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TEAMNAME = "TEAMNAME";
        /// <summary>
        ///   返回 "SERVERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SERVERNAME = "SERVERNAME";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_READ_MIN = "CONNECTIONSTRING_CHANNELSALES_READ_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_WRITER_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_WRITER_MIN = "CONNECTIONSTRING_CHANNELSALES_WRITER_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN = "CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_READSTATIC_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_READSTATIC_MIN = "CONNECTIONSTRING_TUAN_READSTATIC_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_READ_MIN = "CONNECTIONSTRING_TUAN_READ_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_WRITER_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_WRITER_MIN = "CONNECTIONSTRING_TUAN_WRITER_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_RECORDREAD_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_RECORDREAD_MIN = "CONNECTIONSTRING_RECORDREAD_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_RECORDWRITE_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_RECORDWRITE_MIN = "CONNECTIONSTRING_RECORDWRITE_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_READ_MIN = "CONNECTIONSTRING_NORTH_REALTY_READ_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN = "CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN = "CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_READ_MIN = "CONNECTIONSTRING_SOUTH_REALTY_READ_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN = "CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN = "CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_GLHT_MONITOR_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_GLHT_MONITOR_READ_MIN = "CONNECTIONSTRING_GLHT_MONITOR_READ_MIN";
        /// <summary>
        ///   返回 "CHANNELSALES_CONN_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CHANNELSALES_CONN_READ_MIN = "CHANNELSALES_CONN_READ_MIN";
        /// <summary>
        ///   返回 "TUANMALL_CONN_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TUANMALL_CONN_READ_MIN = "TUANMALL_CONN_READ_MIN";
        /// <summary>
        ///   返回 "TUAN_CONN_READ_MIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TUAN_CONN_READ_MIN = "TUAN_CONN_READ_MIN";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_READ_MAX = "CONNECTIONSTRING_CHANNELSALES_READ_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_WRITER_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_WRITER_MAX = "CONNECTIONSTRING_CHANNELSALES_WRITER_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX = "CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_READSTATIC_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_READSTATIC_MAX = "CONNECTIONSTRING_TUAN_READSTATIC_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_READ_MAX = "CONNECTIONSTRING_TUAN_READ_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_WRITER_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_WRITER_MAX = "CONNECTIONSTRING_TUAN_WRITER_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_RECORDREAD_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_RECORDREAD_MAX = "CONNECTIONSTRING_RECORDREAD_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_RECORDWRITE_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_RECORDWRITE_MAX = "CONNECTIONSTRING_RECORDWRITE_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_READ_MAX = "CONNECTIONSTRING_NORTH_REALTY_READ_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX = "CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX = "CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_READ_MAX = "CONNECTIONSTRING_SOUTH_REALTY_READ_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX = "CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX = "CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_GLHT_MONITOR_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_GLHT_MONITOR_READ_MAX = "CONNECTIONSTRING_GLHT_MONITOR_READ_MAX";
        /// <summary>
        ///   返回 "CHANNELSALES_CONN_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CHANNELSALES_CONN_READ_MAX = "CHANNELSALES_CONN_READ_MAX";
        /// <summary>
        ///   返回 "TUANMALL_CONN_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TUANMALL_CONN_READ_MAX = "TUANMALL_CONN_READ_MAX";
        /// <summary>
        ///   返回 "TUAN_CONN_READ_MAX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TUAN_CONN_READ_MAX = "TUAN_CONN_READ_MAX";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_READ_SUM = "CONNECTIONSTRING_CHANNELSALES_READ_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_WRITER_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_WRITER_SUM = "CONNECTIONSTRING_CHANNELSALES_WRITER_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM = "CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_READSTATIC_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_READSTATIC_SUM = "CONNECTIONSTRING_TUAN_READSTATIC_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_READ_SUM = "CONNECTIONSTRING_TUAN_READ_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_TUAN_WRITER_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_TUAN_WRITER_SUM = "CONNECTIONSTRING_TUAN_WRITER_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_RECORDREAD_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_RECORDREAD_SUM = "CONNECTIONSTRING_RECORDREAD_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_RECORDWRITE_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_RECORDWRITE_SUM = "CONNECTIONSTRING_RECORDWRITE_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_READ_SUM = "CONNECTIONSTRING_NORTH_REALTY_READ_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM = "CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM = "CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_READ_SUM = "CONNECTIONSTRING_SOUTH_REALTY_READ_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM = "CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM = "CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM";
        /// <summary>
        ///   返回 "CONNECTIONSTRING_GLHT_MONITOR_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTIONSTRING_GLHT_MONITOR_READ_SUM = "CONNECTIONSTRING_GLHT_MONITOR_READ_SUM";
        /// <summary>
        ///   返回 "CHANNELSALES_CONN_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CHANNELSALES_CONN_READ_SUM = "CHANNELSALES_CONN_READ_SUM";
        /// <summary>
        ///   返回 "TUANMALL_CONN_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TUANMALL_CONN_READ_SUM = "TUANMALL_CONN_READ_SUM";
        /// <summary>
        ///   返回 "TUAN_CONN_READ_SUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TUAN_CONN_READ_SUM = "TUAN_CONN_READ_SUM";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_CONNECT_LOG_STATS的构造函数
        /// </summary>
        public DATABASE_CONNECT_LOG_STATS()
        {
            this.TableName = "DATABASE_CONNECT_LOG_STATS";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _PAGEURL, _QUERYSTRING, _FORM, _QUERYSTRING_PHONE_ENCRYPT, _FORM_PHONE_ENCRYPT, _CONNECT_DATE, _REQUEST_COUNT, _DURATION_MIN, _DURATION_MAX, _DURATION_SUM, _TEAMNAME, _SERVERNAME, _CONNECTIONSTRING_CHANNELSALES_READ_MIN, _CONNECTIONSTRING_CHANNELSALES_WRITER_MIN, _CONNECTIONSTRING_CHANNELSALES_READSTATIC_MIN, _CONNECTIONSTRING_TUAN_READSTATIC_MIN, _CONNECTIONSTRING_TUAN_READ_MIN, _CONNECTIONSTRING_TUAN_WRITER_MIN, _CONNECTIONSTRING_RECORDREAD_MIN, _CONNECTIONSTRING_RECORDWRITE_MIN, _CONNECTIONSTRING_NORTH_REALTY_READ_MIN, _CONNECTIONSTRING_NORTH_REALTY_WRITE_MIN, _CONNECTIONSTRING_NORTH_REALTY_ADMIN_MIN, _CONNECTIONSTRING_SOUTH_REALTY_READ_MIN, _CONNECTIONSTRING_SOUTH_REALTY_WRITE_MIN, _CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MIN, _CONNECTIONSTRING_GLHT_MONITOR_READ_MIN, _CHANNELSALES_CONN_READ_MIN, _TUANMALL_CONN_READ_MIN, _TUAN_CONN_READ_MIN, _CONNECTIONSTRING_CHANNELSALES_READ_MAX, _CONNECTIONSTRING_CHANNELSALES_WRITER_MAX, _CONNECTIONSTRING_CHANNELSALES_READSTATIC_MAX, _CONNECTIONSTRING_TUAN_READSTATIC_MAX, _CONNECTIONSTRING_TUAN_READ_MAX, _CONNECTIONSTRING_TUAN_WRITER_MAX, _CONNECTIONSTRING_RECORDREAD_MAX, _CONNECTIONSTRING_RECORDWRITE_MAX, _CONNECTIONSTRING_NORTH_REALTY_READ_MAX, _CONNECTIONSTRING_NORTH_REALTY_WRITE_MAX, _CONNECTIONSTRING_NORTH_REALTY_ADMIN_MAX, _CONNECTIONSTRING_SOUTH_REALTY_READ_MAX, _CONNECTIONSTRING_SOUTH_REALTY_WRITE_MAX, _CONNECTIONSTRING_SOUTH_REALTY_ADMIN_MAX, _CONNECTIONSTRING_GLHT_MONITOR_READ_MAX, _CHANNELSALES_CONN_READ_MAX, _TUANMALL_CONN_READ_MAX, _TUAN_CONN_READ_MAX, _CONNECTIONSTRING_CHANNELSALES_READ_SUM, _CONNECTIONSTRING_CHANNELSALES_WRITER_SUM, _CONNECTIONSTRING_CHANNELSALES_READSTATIC_SUM, _CONNECTIONSTRING_TUAN_READSTATIC_SUM, _CONNECTIONSTRING_TUAN_READ_SUM, _CONNECTIONSTRING_TUAN_WRITER_SUM, _CONNECTIONSTRING_RECORDREAD_SUM, _CONNECTIONSTRING_RECORDWRITE_SUM, _CONNECTIONSTRING_NORTH_REALTY_READ_SUM, _CONNECTIONSTRING_NORTH_REALTY_WRITE_SUM, _CONNECTIONSTRING_NORTH_REALTY_ADMIN_SUM, _CONNECTIONSTRING_SOUTH_REALTY_READ_SUM, _CONNECTIONSTRING_SOUTH_REALTY_WRITE_SUM, _CONNECTIONSTRING_SOUTH_REALTY_ADMIN_SUM, _CONNECTIONSTRING_GLHT_MONITOR_READ_SUM, _CHANNELSALES_CONN_READ_SUM, _TUANMALL_CONN_READ_SUM, _TUAN_CONN_READ_SUM, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_CONNECT_LOG_STATS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, NVARCHAR, INT, INT, DATETIME, INT, INT, INT, INT, VARCHAR, VARCHAR, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, INT, DATETIME };
                this.Lengths = new int[] { 8, 4000, 4000, 8000, 4, 4, 8, 4, 4, 4, 4, 50, 50, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", "1", "1", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { " ", " ", " ", "请求Form参数", " ", " ", " ", " ", " ", " ", " ", "团队名称", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
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
                /// 深度拷贝DATABASE_CONNECT_LOG_STATS（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_CONNECT_LOG_STATS Copy()
                {
                    DATABASE_CONNECT_LOG_STATS new_obj=new DATABASE_CONNECT_LOG_STATS();
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
        #endregion 系统代码，请不要动

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}