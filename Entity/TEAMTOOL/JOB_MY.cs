using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="JOB_MY"
    /// Columns="WEBMANAGER_NAME,JOBNAME,CREATETIME"
    /// PrimaryKeys="WEBMANAGER_NAME,JOBNAME"
    /// </summary>
    public sealed class JOB_MY : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/8/4 9:49:54
        #region 属性
        /// <summary>
        /// 用户名  VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,JOBNAME
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
        /// 作业名字，可能是windows作业的文件目录或者sqlserver的步骤路径  VARCHAR(200)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,JOBNAME
        /// </summary>
        public string JOBNAME
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
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
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
        /// 用户名 返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 作业名字，可能是windows作业的文件目录或者sqlserver的步骤路径 返回 "JOBNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _JOBNAME = "JOBNAME";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// JOB_MY的构造函数
        /// </summary>
        public JOB_MY()
        {
            this.TableName = "JOB_MY";
            this.PrimaryKey = new string[] { _WEBMANAGER_NAME, _JOBNAME };

            this.columns = new string[] { _WEBMANAGER_NAME, _JOBNAME, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表JOB_MY的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, DATETIME };
                this.Lengths = new int[] { 50, 200, 8 };
                this.IsNullables = new int[] { 0, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " " };
                this.Descriptions = new string[] { "用户名", "作业名字，可能是windows作业的文件目录或者sqlserver的步骤路径", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="WEBMANAGER_NAME">用户名</param>
        /// <param name="JOBNAME">作业名字，可能是windows作业的文件目录或者sqlserver的步骤路径</param>
                /// <returns>bool</returns>
                public bool Find(string P_WEBMANAGER_NAME,string P_JOBNAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_WEBMANAGER_NAME;
        this.ColumnValues[1]=P_JOBNAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝JOB_MY（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public JOB_MY Copy()
                {
                    JOB_MY new_obj=new JOB_MY();
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
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=JOB_MY.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.WEBMANAGER_NAME=JOB_MY.WEBMANAGER_NAME
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
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "WEBMANAGER_NAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "WEBMANAGER_NAME");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统生成代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[JOB_MY](
                 [WEBMANAGER_NAME] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [JOBNAME] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [CREATETIME] [DATETIME]  NULL ,
                
                CONSTRAINT [PK_JOB_MY] PRIMARY KEY CLUSTERED 
                (
	             [WEBMANAGER_NAME] ASC,[JOBNAME] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JOB_MY', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作业名字，可能是windows作业的文件目录或者sqlserver的步骤路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JOB_MY', @level2type=N'COLUMN',@level2name=N'JOBNAME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}