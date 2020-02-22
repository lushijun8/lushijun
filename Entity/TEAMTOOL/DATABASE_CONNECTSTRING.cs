
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="DATABASE_CONNECTSTRING"
    /// Columns="DATABASE_CONNECTSTRING_NAME,DATABASE_IP_ROMOTE,DATABASE_NAME,DATABASE_REMARK,DATABASE_CONNECT_TIMES,DATABASE_CONNECT_TIMES_TODAY"
    /// PrimaryKeys="DATABASE_CONNECTSTRING_NAME"
    /// </summary>
    public sealed class DATABASE_CONNECTSTRING : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/9/10 17:47:43
        #region 属性
        /// <summary>
        ///   VARCHAR(100)  NOT NULL
        ///	唯一主键
        /// </summary>
        public string DATABASE_CONNECTSTRING_NAME
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
        ///    VARCHAR(100)  NULL
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
        ///    VARCHAR(100)  NULL
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
        ///    VARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_REMARK
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
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DATABASE_CONNECT_TIMES_ToString 更加准确
        /// </summary>
        public int DATABASE_CONNECT_TIMES
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DATABASE_CONNECT_TIMES
        /// </summary>
        public string DATABASE_CONNECT_TIMES_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        ///   INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 DATABASE_CONNECT_TIMES_TODAY_ToString 更加准确
        /// </summary>
        public int DATABASE_CONNECT_TIMES_TODAY
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 DATABASE_CONNECT_TIMES_TODAY
        /// </summary>
        public string DATABASE_CONNECT_TIMES_TODAY_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "DATABASE_CONNECTSTRING_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_CONNECTSTRING_NAME = "DATABASE_CONNECTSTRING_NAME";
        /// <summary>
        ///   返回 "DATABASE_IP_ROMOTE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_IP_ROMOTE = "DATABASE_IP_ROMOTE";
        /// <summary>
        ///   返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        ///   返回 "DATABASE_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_REMARK = "DATABASE_REMARK";
        /// <summary>
        ///   返回 "DATABASE_CONNECT_TIMES", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_CONNECT_TIMES = "DATABASE_CONNECT_TIMES";
        /// <summary>
        ///  返回 "DATABASE_CONNECT_TIMES_TODAY", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_CONNECT_TIMES_TODAY = "DATABASE_CONNECT_TIMES_TODAY";

        #endregion
        #region 函数
        /// <summary>
        /// DATABASE_CONNECTSTRING的构造函数
        /// </summary>
        public DATABASE_CONNECTSTRING()
        {
            this.TableName = "DATABASE_CONNECTSTRING";
            this.PrimaryKey = new string[] { _DATABASE_CONNECTSTRING_NAME };

            this.columns = new string[] { _DATABASE_CONNECTSTRING_NAME, _DATABASE_IP_ROMOTE, _DATABASE_NAME, _DATABASE_REMARK, _DATABASE_CONNECT_TIMES, _DATABASE_CONNECT_TIMES_TODAY };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表DATABASE_CONNECTSTRING的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, VARCHAR, VARCHAR, INT, INT };
                this.Lengths = new int[] { 100, 100, 100, 100, 4, 4 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="DATABASE_CONNECTSTRING_NAME"></param>
                /// <returns>bool</returns>
                public bool Find(string P_DATABASE_CONNECTSTRING_NAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_DATABASE_CONNECTSTRING_NAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝DATABASE_CONNECTSTRING（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public DATABASE_CONNECTSTRING Copy()
                {
                    DATABASE_CONNECTSTRING new_obj=new DATABASE_CONNECTSTRING();
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

        private bool inner_join_database_connectstring = false;
        private bool left_join_database_connectstring = false;

        /// <summary>
        /// INNER JOIN DATABASE_CONNECTSTRING DATABASE_CONNECTSTRING1  ON DATABASE_CONNECTSTRING1.CONNECTNAME=DATABASE_CONNECTSTRING.DATABASE_CONNECTSTRING_NAME
        /// </summary>
        public bool INNER_JOIN_DATABASE_CONNECTSTRING
        {
            set
            {
                this.inner_join_database_connectstring = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN DATABASE_CONNECTSTRING DATABASE_CONNECTSTRING1  ON DATABASE_CONNECTSTRING1.CONNECTNAME=DATABASE_CONNECTSTRING.DATABASE_CONNECTSTRING_NAME
        /// </summary>
        public bool LEFT_JOIN_DATABASE_CONNECTSTRING
        {
            set
            {
                this.left_join_database_connectstring = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_DATABASE_CONNECTSTRING
        /// LEFT_JOIN_DATABASE_CONNECTSTRING

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_database_connectstring == true)
            {
                this.NewJoin("TEAMTOOL", "INNER", "DATABASE_CONNECTSTRING", "DATABASE_CONNECTSTRING1", "DATABASE_CONNECTSTRING_NAME", "CONNECTNAME");
            }
            if (this.left_join_database_connectstring == true)
            {
                this.NewJoin("TEAMTOOL", "LEFT OUTER", "DATABASE_CONNECTSTRING", "DATABASE_CONNECTSTRING1", "DATABASE_CONNECTSTRING_NAME", "CONNECTNAME");
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