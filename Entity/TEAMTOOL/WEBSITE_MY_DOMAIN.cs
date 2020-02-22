
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="WEBSITE_MY_DOMAIN"
    /// Columns="WEBMANAGER_NAME,DOMAIN_NAME,CREATETIME"
    /// PrimaryKeys="WEBMANAGER_NAME,DOMAIN_NAME"
    /// </summary>
    public sealed class WEBSITE_MY_DOMAIN : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/7/27 11:12:32
        #region 属性
        /// <summary>
        /// 我的用户名   VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,DOMAIN_NAME
        /// </summary>
        public string WEBMANAGER_NAME
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
        /// 我相关的域名  VARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,DOMAIN_NAME
        /// </summary>
        public string DOMAIN_NAME
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
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
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
                return ColumnValues[2];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 我的用户名  返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 我相关的域名 返回 "DOMAIN_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DOMAIN_NAME = "DOMAIN_NAME";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// WEBSITE_MY_DOMAIN的构造函数
        /// </summary>
        public WEBSITE_MY_DOMAIN()
        {
            this.TableName = "WEBSITE_MY_DOMAIN";
            this.PrimaryKey = new string[] { _WEBMANAGER_NAME, _DOMAIN_NAME };

            this.columns = new string[] { _WEBMANAGER_NAME, _DOMAIN_NAME, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表WEBSITE_MY_DOMAIN的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, DATETIME };
                this.Lengths = new int[] { 50, 100, 8 };
                this.IsNullables = new int[] { 0, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", "getdate" };
                this.Descriptions = new string[] { "我的用户名 ", "我相关的域名", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="WEBMANAGER_NAME">我的用户名 </param>
        /// <param name="DOMAIN_NAME">我相关的域名</param>
                /// <returns>bool</returns>
                public bool Find(string P_WEBMANAGER_NAME,string P_DOMAIN_NAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_WEBMANAGER_NAME;
        this.ColumnValues[1]=P_DOMAIN_NAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝WEBSITE_MY_DOMAIN（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public WEBSITE_MY_DOMAIN Copy()
                {
                    WEBSITE_MY_DOMAIN new_obj=new WEBSITE_MY_DOMAIN();
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
                 				
                CREATE TABLE [dbo].[WEBSITE_MY_DOMAIN](
                 [WEBMANAGER_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [DOMAIN_NAME] [VARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_WEBSITE_MY_DOMAIN_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_WEBSITE_MY_DOMAIN] PRIMARY KEY CLUSTERED 
                (
	             [WEBMANAGER_NAME] ASC,[DOMAIN_NAME] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'我的用户名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_MY_DOMAIN', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'我相关的域名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_MY_DOMAIN', @level2type=N'COLUMN',@level2name=N'DOMAIN_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_MY_DOMAIN', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}