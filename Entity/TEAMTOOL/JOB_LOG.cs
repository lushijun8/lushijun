using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="JOB_LOG"
    /// Columns="JOB_ID,DATABASE_IP,DATABASE_NAME,RUN_DATE,RUN_TIME,STEP_ID,NAME,STEP_NAME,MESSAGE,DESCRIPTION,ENABLED,DATE_CREATED,DATE_MODIFIED,RUN_STATUS,RUN_DURATION"
    /// PrimaryKeys="JOB_ID"
    /// </summary>
    public sealed class JOB_LOG : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/4/7 16:35:34
        #region 属性
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 JOB_ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public long JOB_ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 JOB_ID
        ///	唯一主键
        /// </summary>
        public string JOB_ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string DATABASE_IP
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
        ///    VARCHAR(50)  NULL
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
        /// 数据库作业执行日期  VARCHAR(20)  NOT NULL
        /// </summary>
        public string RUN_DATE
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
        /// 数据库作业执行时间  VARCHAR(20)  NOT NULL
        /// </summary>
        public string RUN_TIME
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
        /// 数据库作业步骤序号  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STEP_ID_ToString 更加准确
        /// </summary>
        public int STEP_ID
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 数据库作业步骤序号  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STEP_ID
        /// </summary>
        public string STEP_ID_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 数据库作业名称  NVARCHAR(200)  NULL
        /// </summary>
        public string NAME
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
        /// 数据库作业步骤名称  NVARCHAR(200)  NULL
        /// </summary>
        public string STEP_NAME
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
        /// 数据库作业报错信息  NVARCHAR(8000)  NULL
        /// </summary>
        public string MESSAGE
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
        /// 数据库作业步骤描述  NVARCHAR(8000)  NULL
        /// </summary>
        public string DESCRIPTION
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
        /// 数据库作业步骤是否开启  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ENABLED_ToString 更加准确
        /// </summary>
        public int ENABLED
        {
            set
            {
                ColumnValues[10] = value.ToString(); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 数据库作业步骤是否开启  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ENABLED
        /// </summary>
        public string ENABLED_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }
        /// <summary>
        /// 数据库作业建立时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DATE_CREATED_ToString 更加准确
        /// </summary>
        public DateTime DATE_CREATED
        {
            set
            {
                ColumnValues[11] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// 数据库作业建立时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DATE_CREATED
        /// </summary>
        public string DATE_CREATED_ToString
        {
            get
            {
                return ColumnValues[11];
            }
        }
        /// <summary>
        /// 数据库作业修改时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DATE_MODIFIED_ToString 更加准确
        /// </summary>
        public DateTime DATE_MODIFIED
        {
            set
            {
                ColumnValues[12] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 数据库作业修改时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DATE_MODIFIED
        /// </summary>
        public string DATE_MODIFIED_ToString
        {
            get
            {
                return ColumnValues[12];
            }
        }
        /// <summary>
        /// 数据库作业执行状态，0失败，1成功  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RUN_STATUS_ToString 更加准确
        /// </summary>
        public int RUN_STATUS
        {
            set
            {
                ColumnValues[13] = value.ToString(); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 数据库作业执行状态，0失败，1成功  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RUN_STATUS
        /// </summary>
        public string RUN_STATUS_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        /// 数据库作业步骤执行时间（秒）  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 RUN_DURATION_ToString 更加准确
        /// </summary>
        public int RUN_DURATION
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 数据库作业步骤执行时间（秒）  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 RUN_DURATION
        /// </summary>
        public string RUN_DURATION_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "JOB_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _JOB_ID = "JOB_ID";
        /// <summary>
        ///   返回 "DATABASE_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP = "DATABASE_IP";
        /// <summary>
        ///   返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        /// 数据库作业执行日期 返回 "RUN_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUN_DATE = "RUN_DATE";
        /// <summary>
        /// 数据库作业执行时间 返回 "RUN_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUN_TIME = "RUN_TIME";
        /// <summary>
        /// 数据库作业步骤序号 返回 "STEP_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STEP_ID = "STEP_ID";
        /// <summary>
        /// 数据库作业名称 返回 "NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        /// 数据库作业步骤名称 返回 "STEP_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STEP_NAME = "STEP_NAME";
        /// <summary>
        /// 数据库作业报错信息 返回 "MESSAGE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MESSAGE = "MESSAGE";
        /// <summary>
        /// 数据库作业步骤描述 返回 "DESCRIPTION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DESCRIPTION = "DESCRIPTION";
        /// <summary>
        /// 数据库作业步骤是否开启 返回 "ENABLED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ENABLED = "ENABLED";
        /// <summary>
        /// 数据库作业建立时间 返回 "DATE_CREATED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATE_CREATED = "DATE_CREATED";
        /// <summary>
        /// 数据库作业修改时间 返回 "DATE_MODIFIED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATE_MODIFIED = "DATE_MODIFIED";
        /// <summary>
        /// 数据库作业执行状态，0失败，1成功 返回 "RUN_STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUN_STATUS = "RUN_STATUS";
        /// <summary>
        /// 数据库作业步骤执行时间（秒） 返回 "RUN_DURATION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _RUN_DURATION = "RUN_DURATION";

        #endregion
        #region 函数
        /// <summary>
        /// JOB_LOG的构造函数
        /// </summary>
        public JOB_LOG()
        {
            this.TableName = "JOB_LOG";
            this.PrimaryKey = new string[] { _JOB_ID };
            this.IdentityColumn = this._JOB_ID;
            this.columns = new string[] { _JOB_ID, _DATABASE_IP, _DATABASE_NAME, _RUN_DATE, _RUN_TIME, _STEP_ID, _NAME, _STEP_NAME, _MESSAGE, _DESCRIPTION, _ENABLED, _DATE_CREATED, _DATE_MODIFIED, _RUN_STATUS, _RUN_DURATION };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表JOB_LOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, INT, DATETIME, DATETIME, INT, INT };
                this.Lengths = new int[] { 8, 50, 50, 20, 20, 4, 200, 200, 8000, 8000, 4, 8, 8, 4, 4 };
                this.IsNullables = new int[] { 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", "数据库作业执行日期", "数据库作业执行时间", "数据库作业步骤序号", "数据库作业名称", "数据库作业步骤名称", "数据库作业报错信息", "数据库作业步骤描述", "数据库作业步骤是否开启", "数据库作业建立时间", "数据库作业修改时间", "数据库作业执行状态，0失败，1成功", "数据库作业步骤执行时间（秒）" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="JOB_ID"></param>
                /// <returns>bool</returns>
                public bool Find(long P_JOB_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_JOB_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝JOB_LOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public JOB_LOG Copy()
                {
                    JOB_LOG new_obj=new JOB_LOG();
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

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}