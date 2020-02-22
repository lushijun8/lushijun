using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="APPLY"
    /// Columns="APPLY_WEBMANAGER_NAME,APPLY_YEAR,APPLY_MONTH,APPLY_WEBMANAGER_REALNAME,APPLY_PEN,APPLY_PENLEAD,APPLY_BOOK,APPLY_GLUE,APPLY_NOTEPAPER,APPLY_LOCK,APPLY_RECEIVE,APPLY_CREATETIME"
    /// PrimaryKeys="APPLY_WEBMANAGER_NAME,APPLY_YEAR,APPLY_MONTH"
    /// </summary>
    public sealed class APPLY : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/9/2 16:27:50
        #region 属性
        /// <summary>
        /// 申请人  NVARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：APPLY_WEBMANAGER_NAME,APPLY_YEAR,APPLY_MONTH
        /// </summary>
        public string APPLY_WEBMANAGER_NAME
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
        /// 年份  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_YEAR_ToString 更加准确
        ///	主健之一，其他主健还有：APPLY_WEBMANAGER_NAME,APPLY_YEAR,APPLY_MONTH
        /// </summary>
        public int APPLY_YEAR
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 年份  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_YEAR
        ///	主健之一，其他主健还有：APPLY_WEBMANAGER_NAME,APPLY_YEAR,APPLY_MONTH
        /// </summary>
        public string APPLY_YEAR_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 月份  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_MONTH_ToString 更加准确
        ///	主健之一，其他主健还有：APPLY_WEBMANAGER_NAME,APPLY_YEAR,APPLY_MONTH
        /// </summary>
        public int APPLY_MONTH
        {
            set
            {
                ColumnValues[2] = value.ToString(); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 月份  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_MONTH
        ///	主健之一，其他主健还有：APPLY_WEBMANAGER_NAME,APPLY_YEAR,APPLY_MONTH
        /// </summary>
        public string APPLY_MONTH_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 真实姓名  NVARCHAR(100)  NULL
        /// </summary>
        public string APPLY_WEBMANAGER_REALNAME
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
        /// 笔  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_PEN_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int APPLY_PEN
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 笔  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_PEN
        ///	默认值:0
        /// </summary>
        public string APPLY_PEN_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 笔芯  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_PENLEAD_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int APPLY_PENLEAD
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 笔芯  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_PENLEAD
        ///	默认值:0
        /// </summary>
        public string APPLY_PENLEAD_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 笔记簿  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_BOOK_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int APPLY_BOOK
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 笔记簿  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_BOOK
        ///	默认值:0
        /// </summary>
        public string APPLY_BOOK_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 胶水  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_GLUE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int APPLY_GLUE
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        /// 胶水  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_GLUE
        ///	默认值:0
        /// </summary>
        public string APPLY_GLUE_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        /// 便签纸  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_NOTEPAPER_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int APPLY_NOTEPAPER
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 便签纸  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_NOTEPAPER
        ///	默认值:0
        /// </summary>
        public string APPLY_NOTEPAPER_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 是否已锁定  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_LOCK_ToString 更加准确
        /// </summary>
        public int APPLY_LOCK
        {
            set
            {
                ColumnValues[9] = value.ToString(); UpdateStatus[9] = 1;
            }
        }
        /// <summary>
        /// 是否已锁定  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_LOCK
        /// </summary>
        public string APPLY_LOCK_ToString
        {
            get
            {
                return ColumnValues[9];
            }
        }
        /// <summary>
        /// 是否已发放  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_RECEIVE_ToString 更加准确
        /// </summary>
        public int APPLY_RECEIVE
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 是否已发放  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_RECEIVE
        /// </summary>
        public string APPLY_RECEIVE_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 APPLY_CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime APPLY_CREATETIME
        {
            set
            {
                ColumnValues[11] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 APPLY_CREATETIME
        /// </summary>
        public string APPLY_CREATETIME_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 申请人 返回 "APPLY_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_WEBMANAGER_NAME = "APPLY_WEBMANAGER_NAME";
        /// <summary>
        /// 年份 返回 "APPLY_YEAR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_YEAR = "APPLY_YEAR";
        /// <summary>
        /// 月份 返回 "APPLY_MONTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_MONTH = "APPLY_MONTH";
        /// <summary>
        /// 真实姓名 返回 "APPLY_WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_WEBMANAGER_REALNAME = "APPLY_WEBMANAGER_REALNAME";
        /// <summary>
        /// 笔 返回 "APPLY_PEN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_PEN = "APPLY_PEN";
        /// <summary>
        /// 笔芯 返回 "APPLY_PENLEAD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_PENLEAD = "APPLY_PENLEAD";
        /// <summary>
        /// 笔记簿 返回 "APPLY_BOOK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_BOOK = "APPLY_BOOK";
        /// <summary>
        /// 胶水 返回 "APPLY_GLUE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_GLUE = "APPLY_GLUE";
        /// <summary>
        /// 便签纸 返回 "APPLY_NOTEPAPER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_NOTEPAPER = "APPLY_NOTEPAPER";
        /// <summary>
        /// 是否已锁定 返回 "APPLY_LOCK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_LOCK = "APPLY_LOCK";
        /// <summary>
        /// 是否已发放 返回 "APPLY_RECEIVE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_RECEIVE = "APPLY_RECEIVE";
        /// <summary>
        /// 创建时间 返回 "APPLY_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _APPLY_CREATETIME = "APPLY_CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// APPLY的构造函数
        /// </summary>
        public APPLY()
        {
            this.TableName = "APPLY";
            this.PrimaryKey = new string[] { _APPLY_WEBMANAGER_NAME, _APPLY_YEAR, _APPLY_MONTH };

            this.columns = new string[] { _APPLY_WEBMANAGER_NAME, _APPLY_YEAR, _APPLY_MONTH, _APPLY_WEBMANAGER_REALNAME, _APPLY_PEN, _APPLY_PENLEAD, _APPLY_BOOK, _APPLY_GLUE, _APPLY_NOTEPAPER, _APPLY_LOCK, _APPLY_RECEIVE, _APPLY_CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表APPLY的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { NVARCHAR, INT, INT, NVARCHAR, INT, INT, INT, INT, INT, INT, INT, DATETIME };
                this.Lengths = new int[] { 100, 4, 4, 100, 4, 4, 4, 4, 4, 4, 4, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", "0", "0", "0", "0", "0", " ", " ", " " };
                this.Descriptions = new string[] { "申请人", "年份", "月份", "真实姓名", "笔", "笔芯", "笔记簿", "胶水", "便签纸", "是否已锁定", "是否已发放", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="APPLY_WEBMANAGER_NAME">申请人</param>
        /// <param name="APPLY_YEAR">年份</param>
        /// <param name="APPLY_MONTH">月份</param>
                /// <returns>bool</returns>
                public bool Find(string P_APPLY_WEBMANAGER_NAME,int P_APPLY_YEAR,int P_APPLY_MONTH)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_APPLY_WEBMANAGER_NAME;
        this.ColumnValues[1]=P_APPLY_YEAR.ToString();
        this.ColumnValues[2]=P_APPLY_MONTH.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝APPLY（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public APPLY Copy()
                {
                    APPLY new_obj=new APPLY();
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
                 				
                CREATE TABLE [dbo].[APPLY](
                 [APPLY_WEBMANAGER_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [APPLY_YEAR] [INT]  NOT NULL ,
                 [APPLY_MONTH] [INT]  NOT NULL ,
                 [APPLY_WEBMANAGER_REALNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [APPLY_PEN] [INT]  NULL  CONSTRAINT [DF_APPLY_APPLY_PEN] DEFAULT ('0') ,
                 [APPLY_PENLEAD] [INT]  NULL  CONSTRAINT [DF_APPLY_APPLY_PENLEAD] DEFAULT ('0') ,
                 [APPLY_BOOK] [INT]  NULL  CONSTRAINT [DF_APPLY_APPLY_BOOK] DEFAULT ('0') ,
                 [APPLY_GLUE] [INT]  NULL  CONSTRAINT [DF_APPLY_APPLY_GLUE] DEFAULT ('0') ,
                 [APPLY_NOTEPAPER] [INT]  NULL  CONSTRAINT [DF_APPLY_APPLY_NOTEPAPER] DEFAULT ('0') ,
                 [APPLY_LOCK] [INT]  NULL ,
                 [APPLY_RECEIVE] [INT]  NULL ,
                 [APPLY_CREATETIME] [DATETIME]  NULL ,
                
                CONSTRAINT [PK_APPLY] PRIMARY KEY CLUSTERED 
                (
	             [APPLY_WEBMANAGER_NAME] ASC,[APPLY_YEAR] ASC,[APPLY_MONTH] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_YEAR'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'月份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_MONTH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'笔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_PEN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'笔芯' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_PENLEAD'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'笔记簿' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_BOOK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'胶水' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_GLUE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'便签纸' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_NOTEPAPER'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已锁定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_LOCK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已发放' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_RECEIVE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'APPLY', @level2type=N'COLUMN',@level2name=N'APPLY_CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        /*
        /// <summary>
        /// 此处根据APPLY_YEAR每500000条存一个表
        /// </summary>
        protected override void TableNameLogic()
        {
            if (this.APPLY_YEAR_ToString.Trim() !=  "")
            {
                int length = 10;
                int mod = 500000;
                int apply_year = int.Parse(this.APPLY_YEAR_ToString);

                int baseId = ((apply_year - 1) / mod) * mod;
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