using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="TASK"
    /// Columns="TASK_PAGEURL_OR_SQL_MD5,TASK_TYPE,TASK_DATE,TASK_FINISHED,TASK_FINISHED_TIME,TASK_WEBMANAGER_NAME,TASK_WEBMANAGER_NAME_FINISHED,TASK_CREATETIME,TASK_REMARK"
    /// PrimaryKeys="TASK_PAGEURL_OR_SQL_MD5"
    /// </summary>
    public sealed class TASK : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/12/8 11:50:14
        #region 属性
        /// <summary>
        /// PageUr或者Sql_Md5  VARCHAR(200)  NOT NULL
        ///	唯一主键
        /// </summary>
        public string TASK_PAGEURL_OR_SQL_MD5
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
        /// 0：PageUrl；1：Sql_Md5；2分享任务  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TASK_TYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int TASK_TYPE
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 0：PageUrl；1：Sql_Md5；2分享任务  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TASK_TYPE
        ///	默认值:0
        /// </summary>
        public string TASK_TYPE_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 任务分配日期  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TASK_DATE_ToString 更加准确
        /// </summary>
        public DateTime TASK_DATE
        {
            set
            {
                ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 任务分配日期  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TASK_DATE
        /// </summary>
        public string TASK_DATE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 是否已经完成任务，0未完成，1完成  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TASK_FINISHED_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int TASK_FINISHED
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 是否已经完成任务，0未完成，1完成  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TASK_FINISHED
        ///	默认值:0
        /// </summary>
        public string TASK_FINISHED_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 任务完成时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TASK_FINISHED_TIME_ToString 更加准确
        /// </summary>
        public DateTime TASK_FINISHED_TIME
        {
            set
            {
                ColumnValues[4] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 任务完成时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TASK_FINISHED_TIME
        /// </summary>
        public string TASK_FINISHED_TIME_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 任务接收人  NVARCHAR(100)  NULL
        /// </summary>
        public string TASK_WEBMANAGER_NAME
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
        /// 任务完成人  NVARCHAR(100)  NULL
        /// </summary>
        public string TASK_WEBMANAGER_NAME_FINISHED
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
        ///    DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TASK_CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime TASK_CREATETIME
        {
            set
            {
                ColumnValues[7] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TASK_CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string TASK_CREATETIME_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        ///   NVARCHAR(4000)  NULL
        /// </summary>
        public string TASK_REMARK
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// PageUr或者Sql_Md5 返回 "TASK_PAGEURL_OR_SQL_MD5", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_PAGEURL_OR_SQL_MD5 = "TASK_PAGEURL_OR_SQL_MD5";
        /// <summary>
        /// 0：PageUrl；1：Sql_Md5；2分享任务 返回 "TASK_TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_TYPE = "TASK_TYPE";
        /// <summary>
        /// 任务分配日期 返回 "TASK_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_DATE = "TASK_DATE";
        /// <summary>
        /// 是否已经完成任务，0未完成，1完成 返回 "TASK_FINISHED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_FINISHED = "TASK_FINISHED";
        /// <summary>
        /// 任务完成时间 返回 "TASK_FINISHED_TIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_FINISHED_TIME = "TASK_FINISHED_TIME";
        /// <summary>
        /// 任务接收人 返回 "TASK_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_WEBMANAGER_NAME = "TASK_WEBMANAGER_NAME";
        /// <summary>
        /// 任务完成人 返回 "TASK_WEBMANAGER_NAME_FINISHED", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_WEBMANAGER_NAME_FINISHED = "TASK_WEBMANAGER_NAME_FINISHED";
        /// <summary>
        ///   返回 "TASK_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_CREATETIME = "TASK_CREATETIME";
        /// <summary>
        ///  返回 "TASK_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASK_REMARK = "TASK_REMARK";

        #endregion
        #region 函数
        /// <summary>
        /// TASK的构造函数
        /// </summary>
        public TASK()
        {
            this.TableName = "TASK";
            this.PrimaryKey = new string[] { _TASK_PAGEURL_OR_SQL_MD5 };

            this.columns = new string[] { _TASK_PAGEURL_OR_SQL_MD5, _TASK_TYPE, _TASK_DATE, _TASK_FINISHED, _TASK_FINISHED_TIME, _TASK_WEBMANAGER_NAME, _TASK_WEBMANAGER_NAME_FINISHED, _TASK_CREATETIME, _TASK_REMARK };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表TASK的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, INT, DATETIME, INT, DATETIME, NVARCHAR, NVARCHAR, DATETIME, NVARCHAR };
                this.Lengths = new int[] { 200, 4, 8, 4, 8, 100, 100, 8, 4000 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", "0", " ", "0", " ", " ", " ", "getdate", " " };
                this.Descriptions = new string[] { "PageUr或者Sql_Md5", "0：PageUrl；1：Sql_Md5；2分享任务", "任务分配日期", "是否已经完成任务，0未完成，1完成", "任务完成时间", "任务接收人", "任务完成人", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="TASK_PAGEURL_OR_SQL_MD5">PageUr或者Sql_Md5</param>
                /// <returns>bool</returns>
                public bool Find(string P_TASK_PAGEURL_OR_SQL_MD5)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_TASK_PAGEURL_OR_SQL_MD5;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝TASK（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public TASK Copy()
                {
                    TASK new_obj=new TASK();
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
        /// INNER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.TASK_WEBMANAGER_NAME=TASK.WEBMANAGER_NAME
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER
        {
            set
            {
                this.inner_join_admin_webmanager = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER ADMIN_WEBMANAGER  ON ADMIN_WEBMANAGER.TASK_WEBMANAGER_NAME=TASK.WEBMANAGER_NAME
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
                this.NewJoin("TEAMTOOL", "INNER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "TASK_WEBMANAGER_NAME");
            }
            if (this.left_join_admin_webmanager == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "ADMIN_WEBMANAGER", "ADMIN_WEBMANAGER", "WEBMANAGER_NAME", "TASK_WEBMANAGER_NAME");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统代码，请不要动

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}