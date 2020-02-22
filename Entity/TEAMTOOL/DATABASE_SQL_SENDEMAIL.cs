
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_SQL_SENDEMAIL"
    /// Columns="WEBMANAGER_NAME,STATS_DATE,SQL_MD5,CREATETIME"
    /// PrimaryKeys="WEBMANAGER_NAME,STATS_DATE,SQL_MD5"
    /// </summary>
    public sealed class DATABASE_SQL_SENDEMAIL : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2016/1/20 12:03:25
        #region 属性
        /// <summary>
        ///   VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,STATS_DATE,SQL_MD5
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
        ///    DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 STATS_DATE_ToString 更加准确
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,STATS_DATE,SQL_MD5
        /// </summary>
        public DateTime STATS_DATE
        {
            set
            {
                ColumnValues[1] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 STATS_DATE
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,STATS_DATE,SQL_MD5
        /// </summary>
        public string STATS_DATE_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        ///    VARCHAR(50)  NOT NULL
        ///	主健之一，其他主健还有：WEBMANAGER_NAME,STATS_DATE,SQL_MD5
        /// </summary>
        public string SQL_MD5
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
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[3] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        ///   返回 "STATS_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _STATS_DATE = "STATS_DATE";
        /// <summary>
        ///   返回 "SQL_MD5", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _SQL_MD5 = "SQL_MD5";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_SQL_SENDEMAIL的构造函数
        /// </summary>
        public DATABASE_SQL_SENDEMAIL()
        {
            this.TableName = "DATABASE_SQL_SENDEMAIL";
            this.PrimaryKey = new string[] { _WEBMANAGER_NAME, _STATS_DATE, _SQL_MD5 };

            this.columns = new string[] { _WEBMANAGER_NAME, _STATS_DATE, _SQL_MD5, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_SQL_SENDEMAIL的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1, 0 };
                this.DataTypes = new string[] { VARCHAR, DATETIME, VARCHAR, DATETIME };
                this.Lengths = new int[] { 50, 8, 50, 8 };
                this.IsNullables = new int[] { 0, 0, 0, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", "getdate" };
                this.Descriptions = new string[] { " ", " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="WEBMANAGER_NAME"></param>
        /// <param name="STATS_DATE"> </param>
        /// <param name="SQL_MD5"> </param>
                /// <returns>bool</returns>
                public bool Find(string P_WEBMANAGER_NAME,DateTime P_STATS_DATE,string P_SQL_MD5)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_WEBMANAGER_NAME;
        this.ColumnValues[1]=P_STATS_DATE.ToString();
        this.ColumnValues[2]=P_SQL_MD5;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_SQL_SENDEMAIL（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_SQL_SENDEMAIL Copy()
                {
                    DATABASE_SQL_SENDEMAIL new_obj=new DATABASE_SQL_SENDEMAIL();
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
        #endregion 系统代码，请不要动

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}