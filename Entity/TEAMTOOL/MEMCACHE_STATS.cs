using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="MEMCACHE_STATS"
    /// Columns="MEMCACHE_IP,MEMCACHE_PORT,STATS_DATE,STATUS,WEBSITE,CREATETIME,MEMCACHE_LOCAL_IP,ERROR_KEY,ERROR,PID,UPTIME,TIME,VERSION,LIBEVENT,POINTER_SIZE,RUSAGE_USER,RUSAGE_SYSTEM,CURR_CONNECTIONS,TOTAL_CONNECTIONS,CONNECTION_STRUCTURES,RESERVED_FDS,CMD_GET,CMD_SET,CMD_FLUSH,CMD_TOUCH,GET_HITS,GET_MISSES,DELETE_MISSES,DELETE_HITS,INCR_MISSES,INCR_HITS,DECR_MISSES,DECR_HITS,CAS_MISSES,CAS_HITS,CAS_BADVAL,TOUCH_HITS,TOUCH_MISSES,AUTH_CMDS,AUTH_ERRORS,BYTES_READ,BYTES_WRITTEN,LIMIT_MAXBYTES,ACCEPTING_CONNS,LISTEN_DISABLED_NUM,THREADS,CONN_YIELDS,HASH_POWER_LEVEL,HASH_BYTES,HASH_IS_EXPANDING,BYTES,CURR_ITEMS,TOTAL_ITEMS,EXPIRED_UNFETCHED,EVICTED_UNFETCHED,EVICTIONS,RECLAIMED,STATSINFO"
    /// PrimaryKeys="MEMCACHE_IP,MEMCACHE_PORT,STATS_DATE"
    /// </summary>
    public sealed class MEMCACHE_STATS : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/9/20 11:04:49
        #region 属性
        /// <summary>
        /// Memcached服务器IP   VARCHAR(20)  NOT NULL
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT,STATS_DATE
        /// </summary>
        public string MEMCACHE_IP
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
        /// Memcached服务器端口   INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MEMCACHE_PORT_ToString 更加准确
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT,STATS_DATE
        /// </summary>
        public int MEMCACHE_PORT
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// Memcached服务器端口   INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MEMCACHE_PORT
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT,STATS_DATE
        /// </summary>
        public string MEMCACHE_PORT_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 统计日期   DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATS_DATE_ToString 更加准确
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT,STATS_DATE
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
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT,STATS_DATE
        /// </summary>
        public string STATS_DATE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 运行状态，0不可用，1可用  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATUS_ToString 更加准确
        /// </summary>
        public int STATUS
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 运行状态，0不可用，1可用  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 STATUS
        /// </summary>
        public string STATUS_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 网站域名，如：api.tuan.tao.fang.com   VARCHAR(1000)  NULL
        /// </summary>
        public string WEBSITE
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
        /// 创建时间   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[5] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 创建时间   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// Memcached服务器本地IP    VARCHAR(20)  NULL
        /// </summary>
        public string MEMCACHE_LOCAL_IP
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
        /// memcache监控用的key，多个可以用;隔开  VARCHAR(200)  NULL
        /// </summary>
        public string ERROR_KEY
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
        /// 具体错误信息  VARCHAR(-1)  NULL
        /// </summary>
        public string ERROR
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
        /// 进程ID  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 PID_ToString 更加准确
        /// </summary>
        public int PID
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 进程ID  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 PID
        /// </summary>
        public string PID_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 服务器运行秒数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 UPTIME_ToString 更加准确
        /// </summary>
        public long UPTIME
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 服务器运行秒数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 UPTIME
        /// </summary>
        public string UPTIME_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 服务器当前unix时间戳  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TIME_ToString 更加准确
        /// </summary>
        public long TIME
        {
            set
            {
                ColumnValues[11] = value.ToString(); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 服务器当前unix时间戳  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TIME
        /// </summary>
        public string TIME_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 服务器版本  VARCHAR(50)  NULL
        /// </summary>
        public string VERSION
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
        /// libevent版本  VARCHAR(50)  NULL
        /// </summary>
        public string LIBEVENT
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
        /// 操作系统字大小(64表示这台服务器是64位的)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 POINTER_SIZE_ToString 更加准确
        /// </summary>
        public long POINTER_SIZE
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 操作系统字大小(64表示这台服务器是64位的)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 POINTER_SIZE
        /// </summary>
        public string POINTER_SIZE_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 进程累计用户时间  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RUSAGE_USER_ToString 更加准确
        /// </summary>
        public decimal RUSAGE_USER
        {
            set
            {
                ColumnValues[15] = value.ToString(); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 进程累计用户时间  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RUSAGE_USER
        /// </summary>
        public string RUSAGE_USER_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        /// 进程累计系统时间  FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RUSAGE_SYSTEM_ToString 更加准确
        /// </summary>
        public decimal RUSAGE_SYSTEM
        {
            set
            {
                ColumnValues[16] = value.ToString(); UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 进程累计系统时间  FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RUSAGE_SYSTEM
        /// </summary>
        public string RUSAGE_SYSTEM_ToString
        {
            get
            {
                return ColumnValues[16];
            }
        }
        /// <summary>
        /// 当前打开连接数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CURR_CONNECTIONS_ToString 更加准确
        /// </summary>
        public long CURR_CONNECTIONS
        {
            set
            {
                ColumnValues[17] = value.ToString(); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 当前打开连接数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CURR_CONNECTIONS
        /// </summary>
        public string CURR_CONNECTIONS_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        /// 曾打开的连接总数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TOTAL_CONNECTIONS_ToString 更加准确
        /// </summary>
        public long TOTAL_CONNECTIONS
        {
            set
            {
                ColumnValues[18] = value.ToString(); UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        /// 曾打开的连接总数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TOTAL_CONNECTIONS
        /// </summary>
        public string TOTAL_CONNECTIONS_ToString
        {
            get
            {
                return ColumnValues[18];
            }
        }
        /// <summary>
        /// 服务器分配的连接结构数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONNECTION_STRUCTURES_ToString 更加准确
        /// </summary>
        public long CONNECTION_STRUCTURES
        {
            set
            {
                ColumnValues[19] = value.ToString(); UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        /// 服务器分配的连接结构数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONNECTION_STRUCTURES
        /// </summary>
        public string CONNECTION_STRUCTURES_ToString
        {
            get
            {
                return ColumnValues[19];
            }
        }
        /// <summary>
        /// reserved_fds   BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESERVED_FDS_ToString 更加准确
        /// </summary>
        public long RESERVED_FDS
        {
            set
            {
                ColumnValues[20] = value.ToString(); UpdateStatus[20] = 1;
            }
        }
        /// <summary>
        /// reserved_fds   BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RESERVED_FDS
        /// </summary>
        public string RESERVED_FDS_ToString
        {
            get
            {
                return ColumnValues[20];
            }
        }
        /// <summary>
        /// 执行get命令总数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CMD_GET_ToString 更加准确
        /// </summary>
        public long CMD_GET
        {
            set
            {
                ColumnValues[21] = value.ToString(); UpdateStatus[21] = 1;
            }
        }
        /// <summary>
        /// 执行get命令总数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CMD_GET
        /// </summary>
        public string CMD_GET_ToString
        {
            get
            {
                return ColumnValues[21];
            }
        }
        /// <summary>
        /// 执行set命令总数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CMD_SET_ToString 更加准确
        /// </summary>
        public long CMD_SET
        {
            set
            {
                ColumnValues[22] = value.ToString(); UpdateStatus[22] = 1;
            }
        }
        /// <summary>
        /// 执行set命令总数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CMD_SET
        /// </summary>
        public string CMD_SET_ToString
        {
            get
            {
                return ColumnValues[22];
            }
        }
        /// <summary>
        /// 指向flush_all命令总数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CMD_FLUSH_ToString 更加准确
        /// </summary>
        public long CMD_FLUSH
        {
            set
            {
                ColumnValues[23] = value.ToString(); UpdateStatus[23] = 1;
            }
        }
        /// <summary>
        /// 指向flush_all命令总数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CMD_FLUSH
        /// </summary>
        public string CMD_FLUSH_ToString
        {
            get
            {
                return ColumnValues[23];
            }
        }
        /// <summary>
        /// cmd_touch   BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CMD_TOUCH_ToString 更加准确
        /// </summary>
        public long CMD_TOUCH
        {
            set
            {
                ColumnValues[24] = value.ToString(); UpdateStatus[24] = 1;
            }
        }
        /// <summary>
        /// cmd_touch   BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CMD_TOUCH
        /// </summary>
        public string CMD_TOUCH_ToString
        {
            get
            {
                return ColumnValues[24];
            }
        }
        /// <summary>
        /// get命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 GET_HITS_ToString 更加准确
        /// </summary>
        public long GET_HITS
        {
            set
            {
                ColumnValues[25] = value.ToString(); UpdateStatus[25] = 1;
            }
        }
        /// <summary>
        /// get命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 GET_HITS
        /// </summary>
        public string GET_HITS_ToString
        {
            get
            {
                return ColumnValues[25];
            }
        }
        /// <summary>
        /// get未命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 GET_MISSES_ToString 更加准确
        /// </summary>
        public long GET_MISSES
        {
            set
            {
                ColumnValues[26] = value.ToString(); UpdateStatus[26] = 1;
            }
        }
        /// <summary>
        /// get未命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 GET_MISSES
        /// </summary>
        public string GET_MISSES_ToString
        {
            get
            {
                return ColumnValues[26];
            }
        }
        /// <summary>
        /// delete未命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DELETE_MISSES_ToString 更加准确
        /// </summary>
        public long DELETE_MISSES
        {
            set
            {
                ColumnValues[27] = value.ToString(); UpdateStatus[27] = 1;
            }
        }
        /// <summary>
        /// delete未命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DELETE_MISSES
        /// </summary>
        public string DELETE_MISSES_ToString
        {
            get
            {
                return ColumnValues[27];
            }
        }
        /// <summary>
        /// delete命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DELETE_HITS_ToString 更加准确
        /// </summary>
        public long DELETE_HITS
        {
            set
            {
                ColumnValues[28] = value.ToString(); UpdateStatus[28] = 1;
            }
        }
        /// <summary>
        /// delete命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DELETE_HITS
        /// </summary>
        public string DELETE_HITS_ToString
        {
            get
            {
                return ColumnValues[28];
            }
        }
        /// <summary>
        /// incr未命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INCR_MISSES_ToString 更加准确
        /// </summary>
        public long INCR_MISSES
        {
            set
            {
                ColumnValues[29] = value.ToString(); UpdateStatus[29] = 1;
            }
        }
        /// <summary>
        /// incr未命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 INCR_MISSES
        /// </summary>
        public string INCR_MISSES_ToString
        {
            get
            {
                return ColumnValues[29];
            }
        }
        /// <summary>
        /// incr命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INCR_HITS_ToString 更加准确
        /// </summary>
        public long INCR_HITS
        {
            set
            {
                ColumnValues[30] = value.ToString(); UpdateStatus[30] = 1;
            }
        }
        /// <summary>
        /// incr命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 INCR_HITS
        /// </summary>
        public string INCR_HITS_ToString
        {
            get
            {
                return ColumnValues[30];
            }
        }
        /// <summary>
        /// decr未命中次数   BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DECR_MISSES_ToString 更加准确
        /// </summary>
        public long DECR_MISSES
        {
            set
            {
                ColumnValues[31] = value.ToString(); UpdateStatus[31] = 1;
            }
        }
        /// <summary>
        /// decr未命中次数   BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DECR_MISSES
        /// </summary>
        public string DECR_MISSES_ToString
        {
            get
            {
                return ColumnValues[31];
            }
        }
        /// <summary>
        /// decr命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DECR_HITS_ToString 更加准确
        /// </summary>
        public long DECR_HITS
        {
            set
            {
                ColumnValues[32] = value.ToString(); UpdateStatus[32] = 1;
            }
        }
        /// <summary>
        /// decr命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DECR_HITS
        /// </summary>
        public string DECR_HITS_ToString
        {
            get
            {
                return ColumnValues[32];
            }
        }
        /// <summary>
        /// cas未命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CAS_MISSES_ToString 更加准确
        /// </summary>
        public long CAS_MISSES
        {
            set
            {
                ColumnValues[33] = value.ToString(); UpdateStatus[33] = 1;
            }
        }
        /// <summary>
        /// cas未命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CAS_MISSES
        /// </summary>
        public string CAS_MISSES_ToString
        {
            get
            {
                return ColumnValues[33];
            }
        }
        /// <summary>
        /// cas命中次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CAS_HITS_ToString 更加准确
        /// </summary>
        public long CAS_HITS
        {
            set
            {
                ColumnValues[34] = value.ToString(); UpdateStatus[34] = 1;
            }
        }
        /// <summary>
        /// cas命中次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CAS_HITS
        /// </summary>
        public string CAS_HITS_ToString
        {
            get
            {
                return ColumnValues[34];
            }
        }
        /// <summary>
        /// 使用擦拭次数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CAS_BADVAL_ToString 更加准确
        /// </summary>
        public long CAS_BADVAL
        {
            set
            {
                ColumnValues[35] = value.ToString(); UpdateStatus[35] = 1;
            }
        }
        /// <summary>
        /// 使用擦拭次数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CAS_BADVAL
        /// </summary>
        public string CAS_BADVAL_ToString
        {
            get
            {
                return ColumnValues[35];
            }
        }
        /// <summary>
        /// touch_hits  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TOUCH_HITS_ToString 更加准确
        /// </summary>
        public long TOUCH_HITS
        {
            set
            {
                ColumnValues[36] = value.ToString(); UpdateStatus[36] = 1;
            }
        }
        /// <summary>
        /// touch_hits  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TOUCH_HITS
        /// </summary>
        public string TOUCH_HITS_ToString
        {
            get
            {
                return ColumnValues[36];
            }
        }
        /// <summary>
        /// touch_misses   BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TOUCH_MISSES_ToString 更加准确
        /// </summary>
        public long TOUCH_MISSES
        {
            set
            {
                ColumnValues[37] = value.ToString(); UpdateStatus[37] = 1;
            }
        }
        /// <summary>
        /// touch_misses   BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TOUCH_MISSES
        /// </summary>
        public string TOUCH_MISSES_ToString
        {
            get
            {
                return ColumnValues[37];
            }
        }
        /// <summary>
        /// auth_cmds   BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 AUTH_CMDS_ToString 更加准确
        /// </summary>
        public long AUTH_CMDS
        {
            set
            {
                ColumnValues[38] = value.ToString(); UpdateStatus[38] = 1;
            }
        }
        /// <summary>
        /// auth_cmds   BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 AUTH_CMDS
        /// </summary>
        public string AUTH_CMDS_ToString
        {
            get
            {
                return ColumnValues[38];
            }
        }
        /// <summary>
        /// auth_errors   BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 AUTH_ERRORS_ToString 更加准确
        /// </summary>
        public long AUTH_ERRORS
        {
            set
            {
                ColumnValues[39] = value.ToString(); UpdateStatus[39] = 1;
            }
        }
        /// <summary>
        /// auth_errors   BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 AUTH_ERRORS
        /// </summary>
        public string AUTH_ERRORS_ToString
        {
            get
            {
                return ColumnValues[39];
            }
        }
        /// <summary>
        /// 读取字节总数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BYTES_READ_ToString 更加准确
        /// </summary>
        public long BYTES_READ
        {
            set
            {
                ColumnValues[40] = value.ToString(); UpdateStatus[40] = 1;
            }
        }
        /// <summary>
        /// 读取字节总数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BYTES_READ
        /// </summary>
        public string BYTES_READ_ToString
        {
            get
            {
                return ColumnValues[40];
            }
        }
        /// <summary>
        /// 写入字节总数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BYTES_WRITTEN_ToString 更加准确
        /// </summary>
        public long BYTES_WRITTEN
        {
            set
            {
                ColumnValues[41] = value.ToString(); UpdateStatus[41] = 1;
            }
        }
        /// <summary>
        /// 写入字节总数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BYTES_WRITTEN
        /// </summary>
        public string BYTES_WRITTEN_ToString
        {
            get
            {
                return ColumnValues[41];
            }
        }
        /// <summary>
        /// 分配的内存数（字节）  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LIMIT_MAXBYTES_ToString 更加准确
        /// </summary>
        public long LIMIT_MAXBYTES
        {
            set
            {
                ColumnValues[42] = value.ToString(); UpdateStatus[42] = 1;
            }
        }
        /// <summary>
        /// 分配的内存数（字节）  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LIMIT_MAXBYTES
        /// </summary>
        public string LIMIT_MAXBYTES_ToString
        {
            get
            {
                return ColumnValues[42];
            }
        }
        /// <summary>
        /// 目前接受的链接数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ACCEPTING_CONNS_ToString 更加准确
        /// </summary>
        public long ACCEPTING_CONNS
        {
            set
            {
                ColumnValues[43] = value.ToString(); UpdateStatus[43] = 1;
            }
        }
        /// <summary>
        /// 目前接受的链接数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ACCEPTING_CONNS
        /// </summary>
        public string ACCEPTING_CONNS_ToString
        {
            get
            {
                return ColumnValues[43];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LISTEN_DISABLED_NUM_ToString 更加准确
        /// </summary>
        public long LISTEN_DISABLED_NUM
        {
            set
            {
                ColumnValues[44] = value.ToString(); UpdateStatus[44] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LISTEN_DISABLED_NUM
        /// </summary>
        public string LISTEN_DISABLED_NUM_ToString
        {
            get
            {
                return ColumnValues[44];
            }
        }
        /// <summary>
        /// 线程数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 THREADS_ToString 更加准确
        /// </summary>
        public long THREADS
        {
            set
            {
                ColumnValues[45] = value.ToString(); UpdateStatus[45] = 1;
            }
        }
        /// <summary>
        /// 线程数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 THREADS
        /// </summary>
        public string THREADS_ToString
        {
            get
            {
                return ColumnValues[45];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONN_YIELDS_ToString 更加准确
        /// </summary>
        public long CONN_YIELDS
        {
            set
            {
                ColumnValues[46] = value.ToString(); UpdateStatus[46] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONN_YIELDS
        /// </summary>
        public string CONN_YIELDS_ToString
        {
            get
            {
                return ColumnValues[46];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 HASH_POWER_LEVEL_ToString 更加准确
        /// </summary>
        public long HASH_POWER_LEVEL
        {
            set
            {
                ColumnValues[47] = value.ToString(); UpdateStatus[47] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 HASH_POWER_LEVEL
        /// </summary>
        public string HASH_POWER_LEVEL_ToString
        {
            get
            {
                return ColumnValues[47];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 HASH_BYTES_ToString 更加准确
        /// </summary>
        public long HASH_BYTES
        {
            set
            {
                ColumnValues[48] = value.ToString(); UpdateStatus[48] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 HASH_BYTES
        /// </summary>
        public string HASH_BYTES_ToString
        {
            get
            {
                return ColumnValues[48];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 HASH_IS_EXPANDING_ToString 更加准确
        /// </summary>
        public long HASH_IS_EXPANDING
        {
            set
            {
                ColumnValues[49] = value.ToString(); UpdateStatus[49] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 HASH_IS_EXPANDING
        /// </summary>
        public string HASH_IS_EXPANDING_ToString
        {
            get
            {
                return ColumnValues[49];
            }
        }
        /// <summary>
        /// 存储item字节数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BYTES_ToString 更加准确
        /// </summary>
        public long BYTES
        {
            set
            {
                ColumnValues[50] = value.ToString(); UpdateStatus[50] = 1;
            }
        }
        /// <summary>
        /// 存储item字节数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BYTES
        /// </summary>
        public string BYTES_ToString
        {
            get
            {
                return ColumnValues[50];
            }
        }
        /// <summary>
        /// item个数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CURR_ITEMS_ToString 更加准确
        /// </summary>
        public long CURR_ITEMS
        {
            set
            {
                ColumnValues[51] = value.ToString(); UpdateStatus[51] = 1;
            }
        }
        /// <summary>
        /// item个数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CURR_ITEMS
        /// </summary>
        public string CURR_ITEMS_ToString
        {
            get
            {
                return ColumnValues[51];
            }
        }
        /// <summary>
        /// item总数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TOTAL_ITEMS_ToString 更加准确
        /// </summary>
        public long TOTAL_ITEMS
        {
            set
            {
                ColumnValues[52] = value.ToString(); UpdateStatus[52] = 1;
            }
        }
        /// <summary>
        /// item总数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TOTAL_ITEMS
        /// </summary>
        public string TOTAL_ITEMS_ToString
        {
            get
            {
                return ColumnValues[52];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EXPIRED_UNFETCHED_ToString 更加准确
        /// </summary>
        public long EXPIRED_UNFETCHED
        {
            set
            {
                ColumnValues[53] = value.ToString(); UpdateStatus[53] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EXPIRED_UNFETCHED
        /// </summary>
        public string EXPIRED_UNFETCHED_ToString
        {
            get
            {
                return ColumnValues[53];
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EVICTED_UNFETCHED_ToString 更加准确
        /// </summary>
        public long EVICTED_UNFETCHED
        {
            set
            {
                ColumnValues[54] = value.ToString(); UpdateStatus[54] = 1;
            }
        }
        /// <summary>
        ///    BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EVICTED_UNFETCHED
        /// </summary>
        public string EVICTED_UNFETCHED_ToString
        {
            get
            {
                return ColumnValues[54];
            }
        }
        /// <summary>
        /// 分配给memcache的空间用满后删除旧的items数  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 EVICTIONS_ToString 更加准确
        /// </summary>
        public long EVICTIONS
        {
            set
            {
                ColumnValues[55] = value.ToString(); UpdateStatus[55] = 1;
            }
        }
        /// <summary>
        /// 分配给memcache的空间用满后删除旧的items数  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 EVICTIONS
        /// </summary>
        public string EVICTIONS_ToString
        {
            get
            {
                return ColumnValues[55];
            }
        }
        /// <summary>
        /// 回收再利用，已过期的数据条目来存储新数据  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RECLAIMED_ToString 更加准确
        /// </summary>
        public long RECLAIMED
        {
            set
            {
                ColumnValues[56] = value.ToString(); UpdateStatus[56] = 1;
            }
        }
        /// <summary>
        /// 回收再利用，已过期的数据条目来存储新数据  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RECLAIMED
        /// </summary>
        public string RECLAIMED_ToString
        {
            get
            {
                return ColumnValues[56];
            }
        }
        /// <summary>
        /// redis的监控信息，以json格式存储  VARCHAR(-1)  NULL
        /// </summary>
        public string STATSINFO
        {
            get
            {
                return ColumnValues[57];
            }
            set
            {
                ColumnValues[57] = value; UpdateStatus[57] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// Memcached服务器IP  返回 "MEMCACHE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_IP = "MEMCACHE_IP";
        /// <summary>
        /// Memcached服务器端口  返回 "MEMCACHE_PORT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_PORT = "MEMCACHE_PORT";
        /// <summary>
        /// 统计日期  返回 "STATS_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATS_DATE = "STATS_DATE";
        /// <summary>
        /// 运行状态，0不可用，1可用 返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        /// 网站域名，如：api.tuan.tao.fang.com  返回 "WEBSITE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBSITE = "WEBSITE";
        /// <summary>
        /// 创建时间  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// Memcached服务器本地IP   返回 "MEMCACHE_LOCAL_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_LOCAL_IP = "MEMCACHE_LOCAL_IP";
        /// <summary>
        /// memcache监控用的key，多个可以用;隔开 返回 "ERROR_KEY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ERROR_KEY = "ERROR_KEY";
        /// <summary>
        /// 具体错误信息 返回 "ERROR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ERROR = "ERROR";
        /// <summary>
        /// 进程ID 返回 "PID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PID = "PID";
        /// <summary>
        /// 服务器运行秒数 返回 "UPTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _UPTIME = "UPTIME";
        /// <summary>
        /// 服务器当前unix时间戳 返回 "TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TIME = "TIME";
        /// <summary>
        /// 服务器版本 返回 "VERSION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VERSION = "VERSION";
        /// <summary>
        /// libevent版本 返回 "LIBEVENT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LIBEVENT = "LIBEVENT";
        /// <summary>
        /// 操作系统字大小(64表示这台服务器是64位的) 返回 "POINTER_SIZE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _POINTER_SIZE = "POINTER_SIZE";
        /// <summary>
        /// 进程累计用户时间 返回 "RUSAGE_USER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUSAGE_USER = "RUSAGE_USER";
        /// <summary>
        /// 进程累计系统时间 返回 "RUSAGE_SYSTEM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUSAGE_SYSTEM = "RUSAGE_SYSTEM";
        /// <summary>
        /// 当前打开连接数 返回 "CURR_CONNECTIONS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CURR_CONNECTIONS = "CURR_CONNECTIONS";
        /// <summary>
        /// 曾打开的连接总数 返回 "TOTAL_CONNECTIONS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TOTAL_CONNECTIONS = "TOTAL_CONNECTIONS";
        /// <summary>
        /// 服务器分配的连接结构数 返回 "CONNECTION_STRUCTURES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONNECTION_STRUCTURES = "CONNECTION_STRUCTURES";
        /// <summary>
        /// reserved_fds  返回 "RESERVED_FDS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESERVED_FDS = "RESERVED_FDS";
        /// <summary>
        /// 执行get命令总数 返回 "CMD_GET", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CMD_GET = "CMD_GET";
        /// <summary>
        /// 执行set命令总数 返回 "CMD_SET", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CMD_SET = "CMD_SET";
        /// <summary>
        /// 指向flush_all命令总数 返回 "CMD_FLUSH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CMD_FLUSH = "CMD_FLUSH";
        /// <summary>
        /// cmd_touch  返回 "CMD_TOUCH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CMD_TOUCH = "CMD_TOUCH";
        /// <summary>
        /// get命中次数 返回 "GET_HITS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _GET_HITS = "GET_HITS";
        /// <summary>
        /// get未命中次数 返回 "GET_MISSES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _GET_MISSES = "GET_MISSES";
        /// <summary>
        /// delete未命中次数 返回 "DELETE_MISSES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DELETE_MISSES = "DELETE_MISSES";
        /// <summary>
        /// delete命中次数 返回 "DELETE_HITS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DELETE_HITS = "DELETE_HITS";
        /// <summary>
        /// incr未命中次数 返回 "INCR_MISSES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INCR_MISSES = "INCR_MISSES";
        /// <summary>
        /// incr命中次数 返回 "INCR_HITS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INCR_HITS = "INCR_HITS";
        /// <summary>
        /// decr未命中次数  返回 "DECR_MISSES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECR_MISSES = "DECR_MISSES";
        /// <summary>
        /// decr命中次数 返回 "DECR_HITS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DECR_HITS = "DECR_HITS";
        /// <summary>
        /// cas未命中次数 返回 "CAS_MISSES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CAS_MISSES = "CAS_MISSES";
        /// <summary>
        /// cas命中次数 返回 "CAS_HITS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CAS_HITS = "CAS_HITS";
        /// <summary>
        /// 使用擦拭次数 返回 "CAS_BADVAL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CAS_BADVAL = "CAS_BADVAL";
        /// <summary>
        /// touch_hits 返回 "TOUCH_HITS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TOUCH_HITS = "TOUCH_HITS";
        /// <summary>
        /// touch_misses  返回 "TOUCH_MISSES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TOUCH_MISSES = "TOUCH_MISSES";
        /// <summary>
        /// auth_cmds  返回 "AUTH_CMDS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AUTH_CMDS = "AUTH_CMDS";
        /// <summary>
        /// auth_errors  返回 "AUTH_ERRORS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AUTH_ERRORS = "AUTH_ERRORS";
        /// <summary>
        /// 读取字节总数 返回 "BYTES_READ", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BYTES_READ = "BYTES_READ";
        /// <summary>
        /// 写入字节总数 返回 "BYTES_WRITTEN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BYTES_WRITTEN = "BYTES_WRITTEN";
        /// <summary>
        /// 分配的内存数（字节） 返回 "LIMIT_MAXBYTES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LIMIT_MAXBYTES = "LIMIT_MAXBYTES";
        /// <summary>
        /// 目前接受的链接数 返回 "ACCEPTING_CONNS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ACCEPTING_CONNS = "ACCEPTING_CONNS";
        /// <summary>
        ///   返回 "LISTEN_DISABLED_NUM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LISTEN_DISABLED_NUM = "LISTEN_DISABLED_NUM";
        /// <summary>
        /// 线程数 返回 "THREADS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _THREADS = "THREADS";
        /// <summary>
        ///   返回 "CONN_YIELDS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONN_YIELDS = "CONN_YIELDS";
        /// <summary>
        ///   返回 "HASH_POWER_LEVEL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _HASH_POWER_LEVEL = "HASH_POWER_LEVEL";
        /// <summary>
        ///   返回 "HASH_BYTES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _HASH_BYTES = "HASH_BYTES";
        /// <summary>
        ///   返回 "HASH_IS_EXPANDING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _HASH_IS_EXPANDING = "HASH_IS_EXPANDING";
        /// <summary>
        /// 存储item字节数 返回 "BYTES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BYTES = "BYTES";
        /// <summary>
        /// item个数 返回 "CURR_ITEMS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CURR_ITEMS = "CURR_ITEMS";
        /// <summary>
        /// item总数 返回 "TOTAL_ITEMS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TOTAL_ITEMS = "TOTAL_ITEMS";
        /// <summary>
        ///   返回 "EXPIRED_UNFETCHED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EXPIRED_UNFETCHED = "EXPIRED_UNFETCHED";
        /// <summary>
        ///   返回 "EVICTED_UNFETCHED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EVICTED_UNFETCHED = "EVICTED_UNFETCHED";
        /// <summary>
        /// 分配给memcache的空间用满后删除旧的items数 返回 "EVICTIONS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _EVICTIONS = "EVICTIONS";
        /// <summary>
        /// 回收再利用，已过期的数据条目来存储新数据 返回 "RECLAIMED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RECLAIMED = "RECLAIMED";
        /// <summary>
        /// redis的监控信息，以json格式存储 返回 "STATSINFO", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATSINFO = "STATSINFO";

        #endregion
        #region 函数
        /// <summary>
        /// MEMCACHE_STATS的构造函数
        /// </summary>
        public MEMCACHE_STATS()
        {
            this.TableName = "MEMCACHE_STATS";
            this.PrimaryKey = new string[] { _MEMCACHE_IP, _MEMCACHE_PORT, _STATS_DATE };

            this.columns = new string[] { _MEMCACHE_IP, _MEMCACHE_PORT, _STATS_DATE, _STATUS, _WEBSITE, _CREATETIME, _MEMCACHE_LOCAL_IP, _ERROR_KEY, _ERROR, _PID, _UPTIME, _TIME, _VERSION, _LIBEVENT, _POINTER_SIZE, _RUSAGE_USER, _RUSAGE_SYSTEM, _CURR_CONNECTIONS, _TOTAL_CONNECTIONS, _CONNECTION_STRUCTURES, _RESERVED_FDS, _CMD_GET, _CMD_SET, _CMD_FLUSH, _CMD_TOUCH, _GET_HITS, _GET_MISSES, _DELETE_MISSES, _DELETE_HITS, _INCR_MISSES, _INCR_HITS, _DECR_MISSES, _DECR_HITS, _CAS_MISSES, _CAS_HITS, _CAS_BADVAL, _TOUCH_HITS, _TOUCH_MISSES, _AUTH_CMDS, _AUTH_ERRORS, _BYTES_READ, _BYTES_WRITTEN, _LIMIT_MAXBYTES, _ACCEPTING_CONNS, _LISTEN_DISABLED_NUM, _THREADS, _CONN_YIELDS, _HASH_POWER_LEVEL, _HASH_BYTES, _HASH_IS_EXPANDING, _BYTES, _CURR_ITEMS, _TOTAL_ITEMS, _EXPIRED_UNFETCHED, _EVICTED_UNFETCHED, _EVICTIONS, _RECLAIMED, _STATSINFO };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表MEMCACHE_STATS的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, INT, DATETIME, INT, VARCHAR, DATETIME, VARCHAR, VARCHAR, VARCHAR, INT, BIGINT, BIGINT, VARCHAR, VARCHAR, BIGINT, FLOAT, FLOAT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, BIGINT, VARCHAR };
                this.Lengths = new int[] { 20, 4, 8, 4, 1000, 8, 100, 200, -1, 4, 8, 8, 50, 50, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, -1 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "Memcached服务器IP ", "Memcached服务器端口 ", "统计日期 ", "运行状态，0不可用，1可用", "网站域名，如：api.tuan.tao.fang.com ", "创建时间 ", "Memcached服务器本地IP  ", "memcache监控用的key，多个可以用;隔开", "具体错误信息", "进程ID", "服务器运行秒数", "服务器当前unix时间戳", "服务器版本", "libevent版本", "操作系统字大小(64表示这台服务器是64位的)", "进程累计用户时间", "进程累计系统时间", "当前打开连接数", "曾打开的连接总数", "服务器分配的连接结构数", "reserved_fds ", "执行get命令总数", "执行set命令总数", "指向flush_all命令总数", "cmd_touch ", "get命中次数", "get未命中次数", "delete未命中次数", "delete命中次数", "incr未命中次数", "incr命中次数", "decr未命中次数 ", "decr命中次数", "cas未命中次数", "cas命中次数", "使用擦拭次数", "touch_hits", "touch_misses ", "auth_cmds ", "auth_errors ", "读取字节总数", "写入字节总数", "分配的内存数（字节）", "目前接受的链接数", " ", "线程数", " ", " ", " ", " ", "存储item字节数", "item个数", "item总数", " ", " ", "分配给memcache的空间用满后删除旧的items数", "回收再利用，已过期的数据条目来存储新数据", "redis的监控信息，以json格式存储" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="MEMCACHE_IP">Memcached服务器IP </param>
        /// <param name="MEMCACHE_PORT">Memcached服务器端口 </param>
        /// <param name="STATS_DATE">统计日期 </param>
                /// <returns>bool</returns>
                public bool Find(string P_MEMCACHE_IP,int P_MEMCACHE_PORT,DateTime P_STATS_DATE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_MEMCACHE_IP;
        this.ColumnValues[1]=P_MEMCACHE_PORT.ToString();
        this.ColumnValues[2]=P_STATS_DATE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝MEMCACHE_STATS（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public MEMCACHE_STATS Copy()
                {
                    MEMCACHE_STATS new_obj=new MEMCACHE_STATS();
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

        /// <summary>
        /// INNER JOIN MEMCACHE_SERVER MEMCACHE_SERVER  ON MEMCACHE_SERVER.MEMCACHE_IP=MEMCACHE_STATS.MEMCACHE_IP AND MEMCACHE_SERVER.MEMCACHE_PORT=MEMCACHE_STATS.MEMCACHE_PORT
        /// </summary>
        public bool INNER_JOIN_MEMCACHE_SERVER
        {
            set
            {
                this.inner_join_memcache_server = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN MEMCACHE_SERVER MEMCACHE_SERVER  ON MEMCACHE_SERVER.MEMCACHE_IP=MEMCACHE_STATS.MEMCACHE_IP AND MEMCACHE_SERVER.MEMCACHE_PORT=MEMCACHE_STATS.MEMCACHE_PORT
        /// </summary>
        public bool LEFT_JOIN_MEMCACHE_SERVER
        {
            set
            {
                this.left_join_memcache_server = value;
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

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[MEMCACHE_STATS](
                 [MEMCACHE_IP] [VARCHAR]  (20)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [MEMCACHE_PORT] [INT]  NOT NULL ,
                 [STATS_DATE] [DATETIME]  NOT NULL ,
                 [STATUS] [INT]  NULL ,
                 [WEBSITE] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL ,
                 [MEMCACHE_LOCAL_IP] [VARCHAR]  (20)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ERROR_KEY] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ERROR] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [PID] [INT]  NULL ,
                 [UPTIME] [BIGINT]  NULL ,
                 [TIME] [BIGINT]  NULL ,
                 [VERSION] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [LIBEVENT] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [POINTER_SIZE] [BIGINT]  NULL ,
                 [RUSAGE_USER] [FLOAT]  (8)  NULL ,
                 [RUSAGE_SYSTEM] [FLOAT]  (8)  NULL ,
                 [CURR_CONNECTIONS] [BIGINT]  NULL ,
                 [TOTAL_CONNECTIONS] [BIGINT]  NULL ,
                 [CONNECTION_STRUCTURES] [BIGINT]  NULL ,
                 [RESERVED_FDS] [BIGINT]  NULL ,
                 [CMD_GET] [BIGINT]  NULL ,
                 [CMD_SET] [BIGINT]  NULL ,
                 [CMD_FLUSH] [BIGINT]  NULL ,
                 [CMD_TOUCH] [BIGINT]  NULL ,
                 [GET_HITS] [BIGINT]  NULL ,
                 [GET_MISSES] [BIGINT]  NULL ,
                 [DELETE_MISSES] [BIGINT]  NULL ,
                 [DELETE_HITS] [BIGINT]  NULL ,
                 [INCR_MISSES] [BIGINT]  NULL ,
                 [INCR_HITS] [BIGINT]  NULL ,
                 [DECR_MISSES] [BIGINT]  NULL ,
                 [DECR_HITS] [BIGINT]  NULL ,
                 [CAS_MISSES] [BIGINT]  NULL ,
                 [CAS_HITS] [BIGINT]  NULL ,
                 [CAS_BADVAL] [BIGINT]  NULL ,
                 [TOUCH_HITS] [BIGINT]  NULL ,
                 [TOUCH_MISSES] [BIGINT]  NULL ,
                 [AUTH_CMDS] [BIGINT]  NULL ,
                 [AUTH_ERRORS] [BIGINT]  NULL ,
                 [BYTES_READ] [BIGINT]  NULL ,
                 [BYTES_WRITTEN] [BIGINT]  NULL ,
                 [LIMIT_MAXBYTES] [BIGINT]  NULL ,
                 [ACCEPTING_CONNS] [BIGINT]  NULL ,
                 [LISTEN_DISABLED_NUM] [BIGINT]  NULL ,
                 [THREADS] [BIGINT]  NULL ,
                 [CONN_YIELDS] [BIGINT]  NULL ,
                 [HASH_POWER_LEVEL] [BIGINT]  NULL ,
                 [HASH_BYTES] [BIGINT]  NULL ,
                 [HASH_IS_EXPANDING] [BIGINT]  NULL ,
                 [BYTES] [BIGINT]  NULL ,
                 [CURR_ITEMS] [BIGINT]  NULL ,
                 [TOTAL_ITEMS] [BIGINT]  NULL ,
                 [EXPIRED_UNFETCHED] [BIGINT]  NULL ,
                 [EVICTED_UNFETCHED] [BIGINT]  NULL ,
                 [EVICTIONS] [BIGINT]  NULL ,
                 [RECLAIMED] [BIGINT]  NULL ,
                 [STATSINFO] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                
                CONSTRAINT [PK_MEMCACHE_STATS] PRIMARY KEY CLUSTERED 
                (
	             [MEMCACHE_IP] ASC,[MEMCACHE_PORT] ASC,[STATS_DATE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached服务器IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'MEMCACHE_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached服务器端口 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'MEMCACHE_PORT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计日期 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'STATS_DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行状态，0不可用，1可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'STATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站域名，如：api.tuan.tao.fang.com ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'WEBSITE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached服务器本地IP  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'MEMCACHE_LOCAL_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcache监控用的key，多个可以用;隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'ERROR_KEY'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'具体错误信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'ERROR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进程ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'PID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器运行秒数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'UPTIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器当前unix时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'TIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'VERSION'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'libevent版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'LIBEVENT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作系统字大小(64表示这台服务器是64位的)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'POINTER_SIZE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进程累计用户时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'RUSAGE_USER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进程累计系统时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'RUSAGE_SYSTEM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前打开连接数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CURR_CONNECTIONS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'曾打开的连接总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'TOTAL_CONNECTIONS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器分配的连接结构数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CONNECTION_STRUCTURES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'reserved_fds ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'RESERVED_FDS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行get命令总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CMD_GET'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行set命令总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CMD_SET'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'指向flush_all命令总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CMD_FLUSH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'cmd_touch ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CMD_TOUCH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'GET_HITS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'get未命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'GET_MISSES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'delete未命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'DELETE_MISSES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'delete命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'DELETE_HITS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'incr未命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'INCR_MISSES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'incr命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'INCR_HITS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'decr未命中次数 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'DECR_MISSES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'decr命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'DECR_HITS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'cas未命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CAS_MISSES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'cas命中次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CAS_HITS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用擦拭次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CAS_BADVAL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'touch_hits' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'TOUCH_HITS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'touch_misses ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'TOUCH_MISSES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'auth_cmds ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'AUTH_CMDS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'auth_errors ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'AUTH_ERRORS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'读取字节总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'BYTES_READ'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'写入字节总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'BYTES_WRITTEN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分配的内存数（字节）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'LIMIT_MAXBYTES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目前接受的链接数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'ACCEPTING_CONNS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线程数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'THREADS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储item字节数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'BYTES'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'item个数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'CURR_ITEMS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'item总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'TOTAL_ITEMS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分配给memcache的空间用满后删除旧的items数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'EVICTIONS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回收再利用，已过期的数据条目来存储新数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'RECLAIMED'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'redis的监控信息，以json格式存储' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_STATS', @level2type=N'COLUMN',@level2name=N'STATSINFO'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        /*
        /// <summary>
        /// 此处根据MEMCACHE_PORT每500000条存一个表
        /// </summary>
        protected override void TableNameLogic()
        {
            if (this.MEMCACHE_PORT_ToString.Trim() !=  "")
            {
                int length = 10;
                int mod = 500000;
                int memcache_port = int.Parse(this.MEMCACHE_PORT_ToString);

                int baseId = ((memcache_port - 1) / mod) * mod;
                int startId = baseId + 1;
                int endId = baseId + mod;  

                string[] tablenames = Com.Net.HtmlUtil.GetRegexGroupFromString("(.*)_\\d{" + length +  "}_\\d{" + length +  "}", TableName, System.Text.RegularExpressions.RegexOptions.None);
                string tablename_Suffix =  "_" + startId.ToString().PadLeft(length, '0') +  "_" + endId.ToString().PadLeft(length, '0');
                string tablename_Prefix = this.TableName;
                if (tablenames != null && tablenames.Length > 0)
                {
                    tablename_Prefix = tablenames[0];
                }
                this.TableName = tablename_Prefix + tablename_Suffix;
            } 
        }
        */
        #endregion
    }
}