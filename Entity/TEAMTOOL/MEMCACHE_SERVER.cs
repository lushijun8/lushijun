using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="MEMCACHE_SERVER"
    /// Columns="MEMCACHE_IP,MEMCACHE_PORT,STATUS,MEMCACHE_LOCAL_IP,ERROR_KEY,WEBSITE,AUTH,CACHETYPE,REMARK"
    /// PrimaryKeys="MEMCACHE_IP,MEMCACHE_PORT"
    /// </summary>
    public sealed class MEMCACHE_SERVER : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2017/10/27 11:07:41
        #region 属性
        /// <summary>
        /// IP地址  VARCHAR(20)  NOT NULL
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT
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
        /// 端口  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MEMCACHE_PORT_ToString 更加准确
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT
        /// </summary>
        public int MEMCACHE_PORT
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 端口  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MEMCACHE_PORT
        ///	主健之一，其他主健还有：MEMCACHE_IP,MEMCACHE_PORT
        /// </summary>
        public string MEMCACHE_PORT_ToString
        {
            get
            {
                return ColumnValues[1];
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
                ColumnValues[2] = value.ToString(); UpdateStatus[2] = 1;
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
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// Memcached本地IP   VARCHAR(100)  NULL
        /// </summary>
        public string MEMCACHE_LOCAL_IP
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
        /// memcache监控用的key，多个可以用;隔开  VARCHAR(200)  NULL
        /// </summary>
        public string ERROR_KEY
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
        /// 调用此memcache端口的网站  VARCHAR(1000)  NULL
        /// </summary>
        public string WEBSITE
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
        /// Redis的权限密码，只有Redis有  VARCHAR(100)  NULL
        /// </summary>
        public string AUTH
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
        /// 0:Memcached;1:Redis  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CACHETYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int CACHETYPE
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 0:Memcached;1:Redis  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CACHETYPE
        ///	默认值:0
        /// </summary>
        public string CACHETYPE_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 备注  NVARCHAR(200)  NULL
        /// </summary>
        public string REMARK
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
        /// 最后回收时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RESETTIME_ToString 更加准确
        ///	默认值:1900-1-1
        /// </summary>
        public DateTime RESETTIME
        {
            set
            {
                ColumnValues[9] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 最后回收时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RESETTIME
        ///	默认值:1900-1-1
        /// </summary>
        public string RESETTIME_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// IP地址 返回 "MEMCACHE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_IP = "MEMCACHE_IP";
        /// <summary>
        /// 端口 返回 "MEMCACHE_PORT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_PORT = "MEMCACHE_PORT";
        /// <summary>
        /// 运行状态，0不可用，1可用 返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        /// Memcached本地IP  返回 "MEMCACHE_LOCAL_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MEMCACHE_LOCAL_IP = "MEMCACHE_LOCAL_IP";
        /// <summary>
        /// memcache监控用的key，多个可以用;隔开 返回 "ERROR_KEY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ERROR_KEY = "ERROR_KEY";
        /// <summary>
        /// 调用此memcache端口的网站 返回 "WEBSITE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBSITE = "WEBSITE";
        /// <summary>
        /// Redis的权限密码，只有Redis有 返回 "AUTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _AUTH = "AUTH";
        /// <summary>
        /// 0:Memcached;1:Redis 返回 "CACHETYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CACHETYPE = "CACHETYPE";
        /// <summary>
        /// 备注 返回 "REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REMARK = "REMARK";
        /// <summary>
        /// 最后回收时间 返回 "RESETTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RESETTIME = "RESETTIME";

        #endregion
        #region 函数
        /// <summary>
        /// MEMCACHE_SERVER的构造函数
        /// </summary>
        public MEMCACHE_SERVER()
        {
            this.TableName = "MEMCACHE_SERVER";
            this.PrimaryKey = new string[] { _MEMCACHE_IP, _MEMCACHE_PORT };

            this.columns = new string[] { _MEMCACHE_IP, _MEMCACHE_PORT, _STATUS, _MEMCACHE_LOCAL_IP, _ERROR_KEY, _WEBSITE, _AUTH, _CACHETYPE, _REMARK, _RESETTIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表MEMCACHE_SERVER的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, INT, INT, VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 20, 4, 4, 100, 200, 1000, 100, 4, 200, 8 };
                this.IsNullables = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", "0", " ", "1900-1-1" };
                this.Descriptions = new string[] { "IP地址", "端口", "运行状态，0不可用，1可用", "Memcached本地IP ", "memcache监控用的key，多个可以用;隔开", "调用此memcache端口的网站", "Redis的权限密码，只有Redis有", "0:Memcached;1:Redis", "备注", "最后回收时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="MEMCACHE_IP">IP地址</param>
        /// <param name="MEMCACHE_PORT">端口</param>
                /// <returns>bool</returns>
                public bool Find(string P_MEMCACHE_IP,int P_MEMCACHE_PORT)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_MEMCACHE_IP;
        this.ColumnValues[1]=P_MEMCACHE_PORT.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝MEMCACHE_SERVER（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public MEMCACHE_SERVER Copy()
                {
                    MEMCACHE_SERVER new_obj=new MEMCACHE_SERVER();
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
                 				
                CREATE TABLE [dbo].[MEMCACHE_SERVER](
                 [MEMCACHE_IP] [VARCHAR]  (20)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [MEMCACHE_PORT] [INT]  NOT NULL ,
                 [STATUS] [INT]  NULL ,
                 [MEMCACHE_LOCAL_IP] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ERROR_KEY] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBSITE] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [AUTH] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CACHETYPE] [INT]  NULL  CONSTRAINT [DF_MEMCACHE_SERVER_CACHETYPE] DEFAULT ('0') ,
                 [REMARK] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [RESETTIME] [DATETIME]  NULL  CONSTRAINT [DF_MEMCACHE_SERVER_RESETTIME] DEFAULT ('1900-1-1') ,
                
                CONSTRAINT [PK_MEMCACHE_SERVER] PRIMARY KEY CLUSTERED 
                (
	             [MEMCACHE_IP] ASC,[MEMCACHE_PORT] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'MEMCACHE_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'端口' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'MEMCACHE_PORT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行状态，0不可用，1可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'STATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Memcached本地IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'MEMCACHE_LOCAL_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'memcache监控用的key，多个可以用;隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'ERROR_KEY'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调用此memcache端口的网站' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'WEBSITE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Redis的权限密码，只有Redis有' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'AUTH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0:Memcached;1:Redis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'CACHETYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'REMARK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后回收时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MEMCACHE_SERVER', @level2type=N'COLUMN',@level2name=N'RESETTIME'
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