
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_USER"
    /// Columns="ID,DATABASE_IP_ROMOTE,DATABASE_NAME,UNAME,USTATUS,RID,RSTATUS,RNAME,CREATETIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class DATABASE_USER : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/11/8 17:47:03
        #region 属性
        /// <summary>
        /// 自增主键  INT(4) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 自增主键  INT(4) 自增列 NOT NULL
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
        /// 数据库IP  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP_ROMOTE
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
        /// 数据库名称  VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_NAME
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
        /// 用户名  VARCHAR(100)  NULL
        /// </summary>
        public string UNAME
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
        /// 用户状态  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USTATUS_ToString 更加准确
        /// </summary>
        public int USTATUS
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 用户状态  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 USTATUS
        /// </summary>
        public string USTATUS_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 角色id  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RID_ToString 更加准确
        /// </summary>
        public int RID
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 角色id  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RID
        /// </summary>
        public string RID_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 角色状态  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RSTATUS_ToString 更加准确
        /// </summary>
        public int RSTATUS
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 角色状态  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RSTATUS
        /// </summary>
        public string RSTATUS_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 角色名  VARCHAR(100)  NULL
        /// </summary>
        public string RNAME
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
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[8] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[8] = 1;
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
                return ColumnValues[8];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 自增主键 返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 数据库IP 返回 "DATABASE_IP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_ROMOTE = "DATABASE_IP_ROMOTE";
        /// <summary>
        /// 数据库名称 返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 用户名 返回 "UNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _UNAME = "UNAME";
        /// <summary>
        /// 用户状态 返回 "USTATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USTATUS = "USTATUS";
        /// <summary>
        /// 角色id 返回 "RID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RID = "RID";
        /// <summary>
        /// 角色状态 返回 "RSTATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RSTATUS = "RSTATUS";
        /// <summary>
        /// 角色名 返回 "RNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RNAME = "RNAME";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_USER的构造函数
        /// </summary>
        public DATABASE_USER()
        {
            this.TableName = "DATABASE_USER";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _DATABASE_IP_ROMOTE, _DATABASE_NAME, _UNAME, _USTATUS, _RID, _RSTATUS, _RNAME, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_USER的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, VARCHAR, VARCHAR, VARCHAR, INT, INT, INT, VARCHAR, DATETIME };
                this.Lengths = new int[] { 4, 50, 50, 100, 4, 4, 4, 100, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { "自增主键", "数据库IP", "数据库名称", "用户名", "用户状态", "角色id", "角色状态", "角色名", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID">自增主键</param>
                /// <returns>bool</returns>
                public bool Find(int P_ID)
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
                /// 深度拷贝DATABASE_USER（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_USER Copy()
                {
                    DATABASE_USER new_obj=new DATABASE_USER();
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
                 				
                CREATE TABLE [dbo].[DATABASE_USER](
                 [ID] [INT]  IDENTITY(1,1)  NOT NULL ,
                 [DATABASE_IP_ROMOTE] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DATABASE_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [UNAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [USTATUS] [INT]  NULL ,
                 [RID] [INT]  NULL ,
                 [RSTATUS] [INT]  NULL ,
                 [RNAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_DATABASE_USER_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_DATABASE_USER] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'DATABASE_IP_ROMOTE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'DATABASE_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'UNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'USTATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'RID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'RSTATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'RNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DATABASE_USER', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}