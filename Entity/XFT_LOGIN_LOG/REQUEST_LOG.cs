using System;
namespace Entity.XFT_LOGIN_LOG
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="XFT_LOGIN_LOG" 
    /// Table="REQUEST_LOG"
    /// Columns="ID,PAGEURL,REQUESTURL,HTTPSTATUSCODE,CONTENTTYPE,CONTENTLENGTH,CONTENT,TIMESPAN,CREATETIME"
    /// PrimaryKeys="ID"
    /// </summary>
    public sealed class REQUEST_LOG : Entity.XFT_LOGIN_LOG.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/3/19 12:16:44
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
        ///    NVARCHAR(2048)  NULL
        /// </summary>
        public string PAGEURL
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
        ///    NVARCHAR(2048)  NULL
        /// </summary>
        public string REQUESTURL
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
        ///    NVARCHAR(100)  NULL
        /// </summary>
        public string HTTPSTATUSCODE
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
        ///    NVARCHAR(100)  NULL
        /// </summary>
        public string CONTENTTYPE
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
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CONTENTLENGTH_ToString 更加准确
        /// </summary>
        public int CONTENTLENGTH
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CONTENTLENGTH
        /// </summary>
        public string CONTENTLENGTH_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        ///    NVARCHAR(2048)  NULL
        /// </summary>
        public string CONTENT
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
        ///    FLOAT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 TIMESPAN_ToString 更加准确
        /// </summary>
        public decimal TIMESPAN
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    FLOAT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 TIMESPAN
        /// </summary>
        public string TIMESPAN_ToString
        {
            get
            {
                return ColumnValues[7];
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
                ColumnValues[8] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[8] = 1;
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
                return ColumnValues[8];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        ///   返回 "REQUESTURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REQUESTURL = "REQUESTURL";
        /// <summary>
        ///   返回 "HTTPSTATUSCODE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _HTTPSTATUSCODE = "HTTPSTATUSCODE";
        /// <summary>
        ///   返回 "CONTENTTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONTENTTYPE = "CONTENTTYPE";
        /// <summary>
        ///   返回 "CONTENTLENGTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONTENTLENGTH = "CONTENTLENGTH";
        /// <summary>
        ///   返回 "CONTENT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CONTENT = "CONTENT";
        /// <summary>
        ///   返回 "TIMESPAN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TIMESPAN = "TIMESPAN";
        /// <summary>
        ///  返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// REQUEST_LOG的构造函数
        /// </summary>
        public REQUEST_LOG()
        {
            this.TableName = "REQUEST_LOG";
            this.PrimaryKey = new string[] { _ID };
            this.IdentityColumn = this._ID;
            this.columns = new string[] { _ID, _PAGEURL, _REQUESTURL, _HTTPSTATUSCODE, _CONTENTTYPE, _CONTENTLENGTH, _CONTENT, _TIMESPAN, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表REQUEST_LOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, INT, NVARCHAR, FLOAT, DATETIME };
                this.Lengths = new int[] { 4, 2048, 2048, 100, 100, 4, 2048, 8, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
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
                /// 深度拷贝REQUEST_LOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public REQUEST_LOG Copy()
                {
                    REQUEST_LOG new_obj=new REQUEST_LOG();
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