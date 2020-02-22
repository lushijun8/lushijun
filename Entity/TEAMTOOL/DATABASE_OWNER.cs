
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_OWNER"
    /// Columns="DATABASE_ID,DATABASE_IP_LOCAL,DATABASE_IP_ROMOTE,DATABASE_VIP_LOCAL,DATABASE_VIP_ROMOTE,DATABASE_IP_SPECIAL,DATABASE_IP_RECOVERY,DATABASE_NAME,DATABASE_REMARK,DATABASE_ADMIN_USER,DATABASE_ADMIN_PASSWORD,DATABASE_READER_USER,DATABASE_READER_PASSWORD,DATABASE_WRITER_USER,DATABASE_WRITER_PASSWORD,DATABASE_TABLE_DESCRIPTION,DATABASE_IS_MAIN,LAST_UPDATE_TIME,DATABASE_PROC_VIEW_FUNCTION_BAK1,DATABASE_PROC_VIEW_FUNCTION_BAK2,DATABASE_PROC_VIEW_FUNCTION_BAK3,SPACE_USED"
    /// PrimaryKeys="DATABASE_ID"
    /// </summary>
    public sealed class DATABASE_OWNER : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2017/3/30 14:53:19
        #region 属性
        /// <summary>
        /// 数据库ID   INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DATABASE_ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int DATABASE_ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 数据库ID   INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 DATABASE_ID
        ///	唯一主键
        /// </summary>
        public string DATABASE_ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        /// 内网IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_LOCAL
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
        /// 外网IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_ROMOTE
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
        /// 内网VIP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_VIP_LOCAL
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
        /// 外网VIP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_VIP_ROMOTE
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
        /// 堡垒机专线IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_SPECIAL
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
        /// 容灾IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_RECOVERY
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
        /// 数据库名称   VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_NAME
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
        /// 备注   NVARCHAR(1000)  NULL
        /// </summary>
        public string DATABASE_REMARK
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
        /// 数据库管理员用户名   VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_ADMIN_USER
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
        /// 数据库管理员用户密码（加密存储）  VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_ADMIN_PASSWORD
        {
            get
            {
                return ColumnValues[10];
            }
            set
            {
                ColumnValues[10] = value; UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 数据库只读用户名   VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_READER_USER
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
        /// 数据库只读用户密码（加密存储）  VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_READER_PASSWORD
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
        /// 数据库可写用户名    VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_WRITER_USER
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
        /// 数据库可写用户密码（加密存储）  VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_WRITER_PASSWORD
        {
            get
            {
                return ColumnValues[14];
            }
            set
            {
                ColumnValues[14] = value; UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 表结果说明HTML  NVARCHAR(-1)  NULL
        /// </summary>
        public string DATABASE_TABLE_DESCRIPTION
        {
            get
            {
                return ColumnValues[15];
            }
            set
            {
                ColumnValues[15] = value; UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 是否主库，只有主库才生成说明  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DATABASE_IS_MAIN_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int DATABASE_IS_MAIN
        {
            set
            {
                ColumnValues[16] = value.ToString(); UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 是否主库，只有主库才生成说明  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DATABASE_IS_MAIN
        ///	默认值:0
        /// </summary>
        public string DATABASE_IS_MAIN_ToString
        {
            get
            {
                return ColumnValues[16];
            }
        }
        /// <summary>
        /// 上次更新时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LAST_UPDATE_TIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime LAST_UPDATE_TIME
        {
            set
            {
                ColumnValues[17] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 上次更新时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LAST_UPDATE_TIME
        ///	默认值:getdate
        /// </summary>
        public string LAST_UPDATE_TIME_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        /// 存储过程和视图函数最近一次备份  VARCHAR(-1)  NULL
        /// </summary>
        public string DATABASE_PROC_VIEW_FUNCTION_BAK1
        {
            get
            {
                return ColumnValues[18];
            }
            set
            {
                ColumnValues[18] = value; UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        /// 存储过程和视图函数上一次备份  VARCHAR(-1)  NULL
        /// </summary>
        public string DATABASE_PROC_VIEW_FUNCTION_BAK2
        {
            get
            {
                return ColumnValues[19];
            }
            set
            {
                ColumnValues[19] = value; UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        /// 存储过程和视图函数上上一次备份  VARCHAR(-1)  NULL
        /// </summary>
        public string DATABASE_PROC_VIEW_FUNCTION_BAK3
        {
            get
            {
                return ColumnValues[20];
            }
            set
            {
                ColumnValues[20] = value; UpdateStatus[20] = 1;
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
                ColumnValues[21] = value.ToString(); UpdateStatus[21] = 1;
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
                return ColumnValues[21];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 数据库ID  返回 "DATABASE_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_ID = "DATABASE_ID";
        /// <summary>
        /// 内网IP 返回 "DATABASE_IP_LOCAL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_LOCAL = "DATABASE_IP_LOCAL";
        /// <summary>
        /// 外网IP 返回 "DATABASE_IP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_ROMOTE = "DATABASE_IP_ROMOTE";
        /// <summary>
        /// 内网VIP 返回 "DATABASE_VIP_LOCAL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_VIP_LOCAL = "DATABASE_VIP_LOCAL";
        /// <summary>
        /// 外网VIP 返回 "DATABASE_VIP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_VIP_ROMOTE = "DATABASE_VIP_ROMOTE";
        /// <summary>
        /// 堡垒机专线IP 返回 "DATABASE_IP_SPECIAL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_SPECIAL = "DATABASE_IP_SPECIAL";
        /// <summary>
        /// 容灾IP 返回 "DATABASE_IP_RECOVERY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_RECOVERY = "DATABASE_IP_RECOVERY";
        /// <summary>
        /// 数据库名称  返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 备注  返回 "DATABASE_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_REMARK = "DATABASE_REMARK";
        /// <summary>
        /// 数据库管理员用户名  返回 "DATABASE_ADMIN_USER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_ADMIN_USER = "DATABASE_ADMIN_USER";
        /// <summary>
        /// 数据库管理员用户密码（加密存储） 返回 "DATABASE_ADMIN_PASSWORD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_ADMIN_PASSWORD = "DATABASE_ADMIN_PASSWORD";
        /// <summary>
        /// 数据库只读用户名  返回 "DATABASE_READER_USER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_READER_USER = "DATABASE_READER_USER";
        /// <summary>
        /// 数据库只读用户密码（加密存储） 返回 "DATABASE_READER_PASSWORD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_READER_PASSWORD = "DATABASE_READER_PASSWORD";
        /// <summary>
        /// 数据库可写用户名   返回 "DATABASE_WRITER_USER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_WRITER_USER = "DATABASE_WRITER_USER";
        /// <summary>
        /// 数据库可写用户密码（加密存储） 返回 "DATABASE_WRITER_PASSWORD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_WRITER_PASSWORD = "DATABASE_WRITER_PASSWORD";
        /// <summary>
        /// 表结果说明HTML 返回 "DATABASE_TABLE_DESCRIPTION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_TABLE_DESCRIPTION = "DATABASE_TABLE_DESCRIPTION";
        /// <summary>
        /// 是否主库，只有主库才生成说明 返回 "DATABASE_IS_MAIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IS_MAIN = "DATABASE_IS_MAIN";
        /// <summary>
        /// 上次更新时间 返回 "LAST_UPDATE_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LAST_UPDATE_TIME = "LAST_UPDATE_TIME";
        /// <summary>
        /// 存储过程和视图函数最近一次备份 返回 "DATABASE_PROC_VIEW_FUNCTION_BAK1", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_PROC_VIEW_FUNCTION_BAK1 = "DATABASE_PROC_VIEW_FUNCTION_BAK1";
        /// <summary>
        /// 存储过程和视图函数上一次备份 返回 "DATABASE_PROC_VIEW_FUNCTION_BAK2", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_PROC_VIEW_FUNCTION_BAK2 = "DATABASE_PROC_VIEW_FUNCTION_BAK2";
        /// <summary>
        /// 存储过程和视图函数上上一次备份 返回 "DATABASE_PROC_VIEW_FUNCTION_BAK3", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_PROC_VIEW_FUNCTION_BAK3 = "DATABASE_PROC_VIEW_FUNCTION_BAK3";
        /// <summary>
        /// 已使用空间(KB) 返回 "SPACE_USED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SPACE_USED = "SPACE_USED";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_OWNER的构造函数
        /// </summary>
        public DATABASE_OWNER()
        {
            this.TableName = "DATABASE_OWNER";
            this.PrimaryKey = new string[] { _DATABASE_ID };

            this.columns = new string[] { _DATABASE_ID, _DATABASE_IP_LOCAL, _DATABASE_IP_ROMOTE, _DATABASE_VIP_LOCAL, _DATABASE_VIP_ROMOTE, _DATABASE_IP_SPECIAL, _DATABASE_IP_RECOVERY, _DATABASE_NAME, _DATABASE_REMARK, _DATABASE_ADMIN_USER, _DATABASE_ADMIN_PASSWORD, _DATABASE_READER_USER, _DATABASE_READER_PASSWORD, _DATABASE_WRITER_USER, _DATABASE_WRITER_PASSWORD, _DATABASE_TABLE_DESCRIPTION, _DATABASE_IS_MAIN, _LAST_UPDATE_TIME, _DATABASE_PROC_VIEW_FUNCTION_BAK1, _DATABASE_PROC_VIEW_FUNCTION_BAK2, _DATABASE_PROC_VIEW_FUNCTION_BAK3, _SPACE_USED };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_OWNER的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, NVARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, VARCHAR, NVARCHAR, INT, DATETIME, VARCHAR, VARCHAR, VARCHAR, BIGINT };
                this.Lengths = new int[] { 4, 50, 50, 50, 50, 50, 50, 50, 1000, 100, 100, 100, 100, 100, 100, -1, 4, 8, -1, -1, -1, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "0", "getdate", " ", " ", " ", " " };
                this.Descriptions = new string[] { "数据库ID ", "内网IP", "外网IP", "内网VIP", "外网VIP", "堡垒机专线IP", "容灾IP", "数据库名称 ", "备注 ", "数据库管理员用户名 ", "数据库管理员用户密码（加密存储）", "数据库只读用户名 ", "数据库只读用户密码（加密存储）", "数据库可写用户名  ", "数据库可写用户密码（加密存储）", "表结果说明HTML", "是否主库，只有主库才生成说明", "上次更新时间", "存储过程和视图函数最近一次备份", "存储过程和视图函数上一次备份", "存储过程和视图函数上上一次备份", "已使用空间(KB)" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_ID">数据库ID </param>
                /// <returns>bool</returns>
                public bool Find(int P_DATABASE_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_OWNER（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_OWNER Copy()
                {
                    DATABASE_OWNER new_obj=new DATABASE_OWNER();
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
                 				
                CREATE TABLE [dbo].[DATABASE_OWNER](
                 [DATABASE_ID] [INT]  NOT NULL ,
                 [DATABASE_IP_LOCAL] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IP_ROMOTE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_VIP_LOCAL] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_VIP_ROMOTE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IP_SPECIAL] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IP_RECOVERY] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_REMARK] [NVARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_ADMIN_USER] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_ADMIN_PASSWORD] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_READER_USER] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_READER_PASSWORD] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_WRITER_USER] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_WRITER_PASSWORD] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_TABLE_DESCRIPTION] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_IS_MAIN] [INT]  NULL  CONSTRAINT [DF_DATABASE_OWNER_DATABASE_IS_MAIN] DEFAULT ('0') ,
                 [LAST_UPDATE_TIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_OWNER_LAST_UPDATE_TIME] DEFAULT ('getdate') ,
                 [DATABASE_PROC_VIEW_FUNCTION_BAK1] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_PROC_VIEW_FUNCTION_BAK2] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_PROC_VIEW_FUNCTION_BAK3] [VARCHAR]  (max)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [SPACE_USED] [BIGINT]  NULL ,
                
                CONSTRAINT [PK_DATABASE_OWNER] PRIMARY KEY CLUSTERED 
                (
	             [DATABASE_ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库ID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内网IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_LOCAL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外网IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_ROMOTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内网VIP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_VIP_LOCAL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外网VIP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_VIP_ROMOTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'堡垒机专线IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_SPECIAL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容灾IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_RECOVERY'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_REMARK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库管理员用户名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_ADMIN_USER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库管理员用户密码（加密存储）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_ADMIN_PASSWORD'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库只读用户名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_READER_USER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库只读用户密码（加密存储）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_READER_PASSWORD'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库可写用户名  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_WRITER_USER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库可写用户密码（加密存储）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_WRITER_PASSWORD'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表结果说明HTML' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_TABLE_DESCRIPTION'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否主库，只有主库才生成说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_IS_MAIN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'LAST_UPDATE_TIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储过程和视图函数最近一次备份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_PROC_VIEW_FUNCTION_BAK1'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储过程和视图函数上一次备份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_PROC_VIEW_FUNCTION_BAK2'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储过程和视图函数上上一次备份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'DATABASE_PROC_VIEW_FUNCTION_BAK3'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已使用空间(KB)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_OWNER', @level2type=N'COLUMN',@level2name=N'SPACE_USED'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        /*
        /// <summary>
        /// 此处根据DATABASE_ID每500000条存一个表
        /// </summary>
        protected override void TableNameLogic()
        {
            if (this.DATABASE_ID_ToString.Trim() !=  "")
            {
                int length = 10;
                int mod = 500000;
                int database_id = int.Parse(this.DATABASE_ID_ToString);

                int baseId = ((database_id - 1) / mod) * mod;
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