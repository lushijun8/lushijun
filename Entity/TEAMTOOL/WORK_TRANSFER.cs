
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="WORK_TRANSFER"
    /// Columns="ID,WORK_FROM_WEBMANAGER_NAME,WORK_FROM_WEBMANAGER_REALNAME,WORK_TO_WEBMANAGER_NAME,WORK_TO_WEBMANAGER_REALNAME,TRANSFER_TYPE,STATUS,CREATETIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class WORK_TRANSFER : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/8/12 10:47:13
        #region 属性
        /// <summary>
        ///   INT(4) 自增列 NOT NULL
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
        ///   INT(4) 自增列 NOT NULL
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
        /// 提交人用户名  NVARCHAR(100)  NULL
        /// </summary>
        public string WORK_FROM_WEBMANAGER_NAME
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
        /// 提交人姓名  NVARCHAR(100)  NULL
        /// </summary>
        public string WORK_FROM_WEBMANAGER_REALNAME
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
        /// 接收人用户名  NVARCHAR(100)  NULL
        /// </summary>
        public string WORK_TO_WEBMANAGER_NAME
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
        /// 接收人姓名  NVARCHAR(100)  NULL
        /// </summary>
        public string WORK_TO_WEBMANAGER_REALNAME
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
        /// 工作交接类别：0复制，1转移  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TRANSFER_TYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int TRANSFER_TYPE
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 工作交接类别：0复制，1转移  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TRANSFER_TYPE
        ///	默认值:0
        /// </summary>
        public string TRANSFER_TYPE_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 状态：0新建，1已经接收，2接收完成  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATUS_ToString 更加准确
        /// </summary>
        public int STATUS
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 状态：0新建，1已经接收，2接收完成  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 STATUS
        /// </summary>
        public string STATUS_ToString
        {
            get
            {
                return ColumnValues[6];
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
                ColumnValues[7] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[7] = 1;
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
                return ColumnValues[7];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        /// 提交人用户名 返回 "WORK_FROM_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WORK_FROM_WEBMANAGER_NAME = "WORK_FROM_WEBMANAGER_NAME";
        /// <summary>
        /// 提交人姓名 返回 "WORK_FROM_WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WORK_FROM_WEBMANAGER_REALNAME = "WORK_FROM_WEBMANAGER_REALNAME";
        /// <summary>
        /// 接收人用户名 返回 "WORK_TO_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WORK_TO_WEBMANAGER_NAME = "WORK_TO_WEBMANAGER_NAME";
        /// <summary>
        /// 接收人姓名 返回 "WORK_TO_WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WORK_TO_WEBMANAGER_REALNAME = "WORK_TO_WEBMANAGER_REALNAME";
        /// <summary>
        /// 工作交接类别：0复制，1转移 返回 "TRANSFER_TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TRANSFER_TYPE = "TRANSFER_TYPE";
        /// <summary>
        /// 状态：0新建，1已经接收，2接收完成 返回 "STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATUS = "STATUS";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// WORK_TRANSFER的构造函数
        /// </summary>
        public WORK_TRANSFER()
        {
            this.TableName = "WORK_TRANSFER";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _WORK_FROM_WEBMANAGER_NAME, _WORK_FROM_WEBMANAGER_REALNAME, _WORK_TO_WEBMANAGER_NAME, _WORK_TO_WEBMANAGER_REALNAME, _TRANSFER_TYPE, _STATUS, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表WORK_TRANSFER的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, INT, INT, DATETIME };
                this.Lengths = new int[] { 4, 100, 100, 100, 100, 4, 4, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", "0", " ", "getdate" };
                this.Descriptions = new string[] { " ", "提交人用户名", "提交人姓名", "接收人用户名", "接收人姓名", "工作交接类别：0复制，1转移", "状态：0新建，1已经接收，2接收完成", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="ID"></param>
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
                /// 深度拷贝WORK_TRANSFER（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public WORK_TRANSFER Copy()
                {
                    WORK_TRANSFER new_obj=new WORK_TRANSFER();
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
                 				
                CREATE TABLE [dbo].[WORK_TRANSFER](
                 [ID] [INT]  IDENTITY(1,1)  NOT NULL ,
                 [WORK_FROM_WEBMANAGER_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WORK_FROM_WEBMANAGER_REALNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WORK_TO_WEBMANAGER_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WORK_TO_WEBMANAGER_REALNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [TRANSFER_TYPE] [INT]  NULL  CONSTRAINT [DF_WORK_TRANSFER_TRANSFER_TYPE] DEFAULT ('0') ,
                 [STATUS] [INT]  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_WORK_TRANSFER_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_WORK_TRANSFER] PRIMARY KEY CLUSTERED 
                (
	             [ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交人用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WORK_TRANSFER', @level2type=N'COLUMN',@level2name=N'WORK_FROM_WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WORK_TRANSFER', @level2type=N'COLUMN',@level2name=N'WORK_FROM_WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接收人用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WORK_TRANSFER', @level2type=N'COLUMN',@level2name=N'WORK_TO_WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接收人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WORK_TRANSFER', @level2type=N'COLUMN',@level2name=N'WORK_TO_WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作交接类别：0复制，1转移' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WORK_TRANSFER', @level2type=N'COLUMN',@level2name=N'TRANSFER_TYPE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：0新建，1已经接收，2接收完成' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WORK_TRANSFER', @level2type=N'COLUMN',@level2name=N'STATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WORK_TRANSFER', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}