using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.TEAMTOOL
{
    public class REDISINFO
    {
        public static string[] Keys = new string[]{
                                            "redis_version",
                                            "redis_git_sha1",
                                            "redis_git_dirty",
                                            "redis_mode",
                                            "os",
                                            "arch_bits",
                                            "multiplexing_api",
                                            "gcc_version",
                                            "process_id",
                                            "run_id",
                                            "tcp_port",
                                            "uptime_in_seconds",
                                            "uptime_in_days",
                                            "hz",
                                            "lru_clock",
                                            "config_file",
                                            "connected_clients",
                                            "client_longest_output_list",
                                            "client_biggest_input_buf",
                                            "client_longest_input_buf",
                                            "blocked_clients",
                                            "used_memory",
                                            "used_memory_human",
                                            "used_memory_rss",
                                            "used_memory_peak",
                                            "used_memory_peak_human",
                                            "used_memory_lua",
                                            "mem_fragmentation_ratio",
                                            "mem_allocator",
                                            "aof_current_size",
                                            "aof_base_size",
                                            "aof_pending_rewrite",
                                            "aof_buffer_length",
                                            "aof_rewrite_buffer_length",
                                            "aof_pending_bio_fsync",
                                            "aof_delayed_fsync",
                                            "loading",
                                            "rdb_changes_since_last_save",
                                            "rdb_bgsave_in_progress",
                                            "rdb_last_save_time",
                                            "rdb_last_bgsave_status",
                                            "rdb_last_bgsave_time_sec",
                                            "rdb_current_bgsave_time_sec",
                                            "aof_enabled",
                                            "aof_rewrite_in_progress",
                                            "aof_rewrite_scheduled",
                                            "aof_last_rewrite_time_sec",
                                            "aof_current_rewrite_time_sec",
                                            "aof_last_bgrewrite_status",
                                            "aof_last_write_status",
                                            "total_connections_received",
                                            "total_commands_processed",
                                            "instantaneous_ops_per_sec",
                                            "total_net_input_bytes",
                                            "total_net_output_bytes",
                                            "instantaneous_input_kbps",
                                            "instantaneous_output_kbps",
                                            "rejected_connections",
                                            "expired_keys",
                                            "evicted_keys",
                                            "keyspace_hits",
                                            "keyspace_misses",
                                            "pubsub_channels",
                                            "pubsub_patterns",
                                            "latest_fork_usec",
                                            "slave0",//slaveXXX
                                            "slave1",//slaveXXX
                                            "slave2",//slaveXXX
                                            "slave3",//slaveXXX
                                            "slave4",//slaveXXX
                                            "slave5",//slaveXXX
                                            "slave6",//slaveXXX
                                            "slave7",//slaveXXX
                                            "slave8",//slaveXXX
                                            "connected_slaves",
                                            "master_link_down_since_seconds",
                                            "master_sync_left_bytes",
                                            "master_sync_last_io_seconds_ago",
                                            "master_host",
                                            "master_port",
                                            "master_link_status",
                                            "master_last_io_seconds_ago",
                                            "master_sync_in_progress",
                                            "slave_priority",
                                            "slave_read_only",
                                            "role",
                                            "used_cpu_sys",
                                            "used_cpu_user",
                                            "used_cpu_sys_children",
                                            "used_cpu_user_children",
                                            "cluster_enabled",
                                            "db0",//dbXXX
                                            "db1",//dbXXX
                                            "db2",//dbXXX
                                            "db3",//dbXXX
                                            "db4",//dbXXX
                                            "db5",//dbXXX
                                            "db6",//dbXXX
                                            "db7",//dbXXX
                                            "db8",//dbXXX
                                            "db9",//dbXXX
                                            "db10",//dbXXX
                                            "db11",//dbXXX
                                            "db12",//dbXXX
                                            "db13",//dbXXX
                                            "db14",//dbXXX
                                            "db15",//dbXXX
                                            };

        public static string[] Remarks = new string[] { 
                                            "Redis 服务器版本",
                                            "GitSHA1",
                                            "Gitdirtyflag",
                                            "redis运行模式",
                                            "Redis服务器的宿主操作系统",
                                            "架构（32或64位）",
                                            "Redis所使用的事件处理机制",
                                            "编译Redis时所使用的GCC版本",
                                            "服务器进程的PID",
                                            "Redis服务器的随机标识符（用于Sentinel和集群）",
                                            "TCP/IP监听端口",
                                            "自Redis服务器启动以来，经过的秒数",
                                            "自Redis服务器启动以来，经过的天数",
                                            "RedisServer执行后台任务的频率,默认为10,此值过小就意味着更多的cpu周期消耗,后台task被轮询的次数更频繁,此值过大意味着内存敏感性较差",
                                            "以分钟为单位进行自增的时钟，用于LRU管理",
                                            "配置文件路径",
                                            "已连接客户端的数量（不包括通过从属服务器连接的客户端）",
                                            "当前连接的客户端当中，最长的输出列表",
                                            "当前连接的客户端中最大的输出缓存",
                                            "当前连接的客户端当中，最大输入缓存",
                                            "正在等待阻塞命令（BLPOP、BRPOP、BRPOPLPUSH）的客户端的数量",
                                            "由Redis分配器分配的内存总量，以字节（byte）为单位",
                                            "以人类可读的格式返回Redis分配的内存总量",
                                            "从操作系统的角度，返回Redis已分配的内存总量（俗称常驻集大小）",
                                            "Redis的内存消耗峰值（以字节为单位）",
                                            "以人类可读的格式返回Redis的内存消耗峰值",
                                            "Lua引擎所使用的内存大小（以字节为单位）",
                                            "used_memory_rss和used_memory之间的比率吗，内存碎片比率",
                                            "在编译时指定的，Redis所使用的内存分配器。可以是libc、jemalloc或者tcmalloc",
                                            "AOF文件目前的大小",
                                            "服务器启动时或者AOF重写最近一次执行之后，AOF文件的大小",
                                            "一个标志值，记录了是否有AOF重写操作在等待RDB文件创建完毕之后执行",
                                            "AOF缓冲区的大小",
                                            "AOF重写缓冲区的大小",
                                            "后台I/O队列里面，等待执行的fsync调用数量",
                                            "被延迟的fsync调用数量",
                                            "一个标志值，记录了服务器是否正在载入持久化文件",
                                            "距离最近一次成功创建持久化文件之后，经过了多少秒",
                                            "一个标志值，记录了服务器是否正在创建RDB文件",
                                            "最近一次成功创建RDB文件的UNIX时间戳",
                                            "一个标志值，记录了最近一次创建RDB文件的结果是成功还是失败",
                                            "记录了最近一次创建RDB文件耗费的秒数",
                                            "如果服务器正在创建RDB文件，那么这个域记录的就是当前的创建操作已经耗费的秒数",
                                            "一个标志值，记录了AOF是否处于打开状态为1时表示已打开",
                                            "一个标志值，记录了服务器是否正在创建AOF文件",
                                            "一个标志值，记录了在RDB文件创建完毕之后，是否需要执行预约的AOF重写操作",
                                            "最近一次创建AOF文件耗费的时长",
                                            "如果服务器正在创建AOF文件，那么这个域记录的就是当前的创建操作已经耗费的秒数",
                                            "一个标志值，记录了最近一次创建AOF文件的结果是成功还是失败",
                                            "上次写入状态",
                                            "服务器已接受的连接请求数量",
                                            "服务器已执行的命令数量",
                                            "服务器每秒钟执行的命令数量",
                                            "redis网络入口流量字节数",
                                            "redis网络出口流量字节数",
                                            "redis网络入口kps",
                                            "redis网络出口kps",
                                            "因为最大客户端数量限制而被拒绝的连接请求数量",
                                            "因为过期而被自动删除的数据库键数量",
                                            "因为最大内存容量限制而被驱逐（evict）的键数量",
                                            "查找数据库键成功的次数",
                                            "查找数据库键失败的次数",
                                            "目前被订阅的频道数量",
                                            "目前被订阅的模式数量",
                                            "最近一次fork()操作耗费的毫秒数",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "ID、IP地址、端口号、连接状态",
                                            "已连接的从服务器数量",
                                            "主从服务器连接断开了多少秒",
                                            "距离同步完成还缺少多少字节数据",
                                            "距离最近一次因为SYNC操作而进行I/O已经过去了多少秒",
                                            "主服务器的IP地址",
                                            "主服务器的TCP监听端口号",
                                            "复制连接当前的状态，up表示连接正常，down表示连接断开",
                                            "距离最近一次与主服务器进行通信已经过去了多少秒钟",
                                            "一个标志值，记录了主服务器是否正在与这个从服务器进行同步",
                                            "指定slave的优先级,当master宕机时，RedisSentinel会将priority值最小的slave提升为master；为0时对应的slave永远不会自动提升为master",
                                            "是否允许slave服务器节点只提供读服务",
                                            "如果当前服务器没有在复制任何其他服务器，那么这个域的值就是master；否则的话，这个域的值就是slave",
                                            "Redis服务器耗费的系统CPU",
                                            "Redis服务器耗费的用户CPU",
                                            "后台进程耗费的系统CPU",
                                            "后台进程耗费的用户CPU",
                                            "一个标志值，记录集群功能是否已经开启",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间",
                                            "各个数据库的key的数量,以及带有生存期的key的数量,数据近似平均过期时间"
        };
        // Server
        public string redis_version { get; set; }
        public string redis_git_sha1 { get; set; }
        public string redis_git_dirty { get; set; }
        public string redis_build_id { get; set; }
        public string redis_mode { get; set; }
        public string os { get; set; }
        public string arch_bits { get; set; }
        public string multiplexing_api { get; set; }
        public string gcc_version { get; set; }
        public string process_id { get; set; }
        public string run_id { get; set; }
        public string tcp_port { get; set; }
        public string uptime_in_seconds { get; set; }
        public string uptime_in_days { get; set; }
        public string hz { get; set; }
        public string lru_clock { get; set; }
        public string config_file { get; set; }

        // Clients
        public string connected_clients { get; set; }
        public string client_longest_output_list { get; set; }
        public string client_biggest_input_buf { get; set; }
        public string blocked_clients { get; set; }

        // Memory
        public string used_memory { get; set; }
        public string used_memory_human { get; set; }
        public string used_memory_rss { get; set; }
        public string used_memory_peak { get; set; }
        public string used_memory_peak_human { get; set; }
        public string used_memory_lua { get; set; }
        public string mem_fragmentation_ratio { get; set; }
        public string mem_allocator { get; set; }

        // Persistence
        public string loading { get; set; }
        public string rdb_changes_since_last_save { get; set; }
        public string rdb_bgsave_in_progress { get; set; }
        public string rdb_last_save_time { get; set; }
        public string rdb_last_bgsave_status { get; set; }
        public string rdb_last_bgsave_time_sec { get; set; }
        public string rdb_current_bgsave_time_sec { get; set; }
        public string aof_enabled { get; set; }
        public string aof_rewrite_in_progress { get; set; }
        public string aof_rewrite_scheduled { get; set; }
        public string aof_last_rewrite_time_sec { get; set; }
        public string aof_current_rewrite_time_sec { get; set; }
        public string aof_last_bgrewrite_status { get; set; }
        public string aof_last_write_status { get; set; }
        public string aof_current_size { get; set; }
        public string aof_base_size { get; set; }
        public string aof_pending_rewrite { get; set; }
        public string aof_buffer_length { get; set; }
        public string aof_rewrite_buffer_length { get; set; }
        public string aof_pending_bio_fsync { get; set; }
        public string aof_delayed_fsync { get; set; }

        // Stats
        public string total_connections_received { get; set; }
        public string total_commands_processed { get; set; }
        public string instantaneous_ops_per_sec { get; set; }
        public string total_net_input_bytes { get; set; }
        public string total_net_output_bytes { get; set; }
        public string instantaneous_input_kbps { get; set; }
        public string instantaneous_output_kbps { get; set; }
        public string rejected_connections { get; set; }
        public string sync_full { get; set; }
        public string sync_partial_ok { get; set; }
        public string sync_partial_err { get; set; }
        public string expired_keys { get; set; }
        public string evicted_keys { get; set; }
        public string keyspace_hits { get; set; }
        public string keyspace_misses { get; set; }
        public string pubsub_channels { get; set; }
        public string pubsub_patterns { get; set; }
        public string latest_fork_usec { get; set; }
        public string migrate_cached_sockets { get; set; }

        // Replication
        public string role { get; set; }
        public string connected_slaves { get; set; }
        public string master_repl_offset { get; set; }
        public string repl_backlog_active { get; set; }
        public string repl_backlog_size { get; set; }
        public string repl_backlog_first_byte_offset { get; set; }
        public string repl_backlog_histlen { get; set; }

        // CPU
        public string used_cpu_sys { get; set; }
        public string used_cpu_user { get; set; }
        public string used_cpu_sys_children { get; set; }
        public string used_cpu_user_children { get; set; }

        // Cluster
        public string cluster_enabled { get; set; }

        // Keyspace
        public string db0 { get; set; }
        public string db1 { get; set; }
        public string db2 { get; set; }
        public string db5 { get; set; }
        public string db6 { get; set; }
    }
}
