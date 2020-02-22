using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="BILL"
    /// Columns="BILL_WEBMANAGER_NAME,BILL_DATE,BILL_WEBMANAGER_REALNAME,BILL_YEAR,BILL_MONTH,BILL_LEADER_REALNAME,BILL_REASON,BILL_STAFF_WORKER,BILL_TOTAL_MONEY,BILL_LOCK,BILL_CREATETIME"
    /// PrimaryKeys="BILL_WEBMANAGER_NAME,BILL_DATE"
    /// </summary>
    public sealed class BILL : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/12/5 20:08:38
        #region 属性
        /// <summary>
        /// 报销人  NVARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：BILL_WEBMANAGER_NAME,BILL_DATE
        /// </summary>
        public string BILL_WEBMANAGER_NAME
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
        /// 报销日期  DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_DATE_ToString 更加准确
        ///	主健之一，其他主健还有：BILL_WEBMANAGER_NAME,BILL_DATE
        /// </summary>
        public DateTime BILL_DATE
        {
            set
            {
                ColumnValues[1] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 报销日期  DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_DATE
        ///	主健之一，其他主健还有：BILL_WEBMANAGER_NAME,BILL_DATE
        /// </summary>
        public string BILL_DATE_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 报销人  NVARCHAR(100)  NOT NULL
        /// </summary>
        public string BILL_WEBMANAGER_REALNAME
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
        /// 年份  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_YEAR_ToString 更加准确
        /// </summary>
        public int BILL_YEAR
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 年份  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_YEAR
        /// </summary>
        public string BILL_YEAR_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 月份  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_MONTH_ToString 更加准确
        /// </summary>
        public int BILL_MONTH
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 月份  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_MONTH
        /// </summary>
        public string BILL_MONTH_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 团队长姓名  NVARCHAR(100)  NULL
        /// </summary>
        public string BILL_LEADER_REALNAME
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
        /// 事由  NVARCHAR(1000)  NULL
        /// </summary>
        public string BILL_REASON
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
        /// 人员，请用空格隔开  NVARCHAR(1000)  NULL
        /// </summary>
        public string BILL_STAFF_WORKER
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
        /// 报销金额  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_TOTAL_MONEY_ToString 更加准确
        /// </summary>
        public int BILL_TOTAL_MONEY
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 报销金额  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_TOTAL_MONEY
        /// </summary>
        public string BILL_TOTAL_MONEY_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 是否锁定，0可编辑，1已锁定  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_LOCK_ToString 更加准确
        /// </summary>
        public int BILL_LOCK
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 是否锁定，0可编辑，1已锁定  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_LOCK
        /// </summary>
        public string BILL_LOCK_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime BILL_CREATETIME
        {
            set
            {
                ColumnValues[10] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_CREATETIME
        /// </summary>
        public string BILL_CREATETIME_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 报销人 返回 "BILL_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_WEBMANAGER_NAME = "BILL_WEBMANAGER_NAME";
        /// <summary>
        /// 报销日期 返回 "BILL_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_DATE = "BILL_DATE";
        /// <summary>
        /// 报销人 返回 "BILL_WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_WEBMANAGER_REALNAME = "BILL_WEBMANAGER_REALNAME";
        /// <summary>
        /// 年份 返回 "BILL_YEAR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_YEAR = "BILL_YEAR";
        /// <summary>
        /// 月份 返回 "BILL_MONTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_MONTH = "BILL_MONTH";
        /// <summary>
        /// 团队长姓名 返回 "BILL_LEADER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_LEADER_REALNAME = "BILL_LEADER_REALNAME";
        /// <summary>
        /// 事由 返回 "BILL_REASON", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_REASON = "BILL_REASON";
        /// <summary>
        /// 人员，请用空格隔开 返回 "BILL_STAFF_WORKER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_STAFF_WORKER = "BILL_STAFF_WORKER";
        /// <summary>
        /// 报销金额 返回 "BILL_TOTAL_MONEY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_TOTAL_MONEY = "BILL_TOTAL_MONEY";
        /// <summary>
        /// 是否锁定，0可编辑，1已锁定 返回 "BILL_LOCK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_LOCK = "BILL_LOCK";
        /// <summary>
        ///  返回 "BILL_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_CREATETIME = "BILL_CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// BILL的构造函数
        /// </summary>
        public BILL()
        {
            this.TableName = "BILL";
            this.PrimaryKey = new string[] { _BILL_WEBMANAGER_NAME, _BILL_DATE };

            this.columns = new string[] { _BILL_WEBMANAGER_NAME, _BILL_DATE, _BILL_WEBMANAGER_REALNAME, _BILL_YEAR, _BILL_MONTH, _BILL_LEADER_REALNAME, _BILL_REASON, _BILL_STAFF_WORKER, _BILL_TOTAL_MONEY, _BILL_LOCK, _BILL_CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表BILL的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { NVARCHAR, DATETIME, NVARCHAR, INT, INT, NVARCHAR, NVARCHAR, NVARCHAR, INT, INT, DATETIME };
                this.Lengths = new int[] { 100, 8, 100, 4, 4, 100, 1000, 1000, 4, 4, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "报销人", "报销日期", "报销人", "年份", "月份", "团队长姓名", "事由", "人员，请用空格隔开", "报销金额", "是否锁定，0可编辑，1已锁定", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="BILL_WEBMANAGER_NAME">报销人</param>
        /// <param name="BILL_DATE">报销日期</param>
                /// <returns>bool</returns>
                public bool Find(string P_BILL_WEBMANAGER_NAME,DateTime P_BILL_DATE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_BILL_WEBMANAGER_NAME;
        this.ColumnValues[1]=P_BILL_DATE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝BILL（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public BILL Copy()
                {
                    BILL new_obj=new BILL();
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

        private bool inner_join_admin_webmanager = false;
        private bool left_join_admin_webmanager = false;

        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.BILL_WEBMANAGER_NAME=BILL.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.BILL_WEBMANAGER_NAME=BILL.WEBMANAGER_NAME
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.left_join_admin_webmanager = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_ADMIN_WEBMANAGER
        /// LEFT_JOIN_ADMIN_WEBMANAGER

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "BILL_WEBMANAGER_NAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "BILL_WEBMANAGER_NAME");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统代码，请不要动

        #region 数据库表生成SQL
        /*
                CREATE TABLE [dbo].[BILL](
                 [BILL_WEBMANAGER_NAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [BILL_DATE] [DATETIME]  NOT NULL ,
                 [BILL_WEBMANAGER_REALNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [BILL_YEAR] [INT]  NULL ,
                 [BILL_MONTH] [INT]  NULL ,
                 [BILL_LEADER_REALNAME] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [BILL_REASON] [NVARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [BILL_STAFF_WORKER] [NVARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [BILL_TOTAL_MONEY] [INT]  NULL ,
                 [BILL_LOCK] [INT]  NULL ,
                 [BILL_CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_BILL_BILL_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_BILL] PRIMARY KEY CLUSTERED 
                (
	             [BILL_WEBMANAGER_NAME] ASC,[BILL_DATE] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报销人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报销日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_DATE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报销人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_YEAR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'月份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_MONTH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'团队长姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_LEADER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_REASON'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员，请用空格隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_STAFF_WORKER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报销金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_TOTAL_MONEY'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否锁定，0可编辑，1已锁定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BILL', @level2type=N'COLUMN',@level2name=N'BILL_LOCK'
                GO

                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}