
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="ADMIN_LOG"
    /// Columns="MALLLOGID,PRODUCT,USERTYPE,USERID,USERNAME,REALNAME,ITEMTYPE,ITEMID,DESCRIPTION,IP,ADDEDTIME"
    /// PrimaryKeys="MALLLOGID"
    /// </summary>
    public sealed class ADMIN_LOG : Entity.TEAMTOOL.EntityBase
	{
        #region 系统代码，请不要动   生成日期:2015/9/7 16:50:03
        #region 属性
        /// <summary>
        /// LOG主键  INT(4) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MALLLOGID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int MALLLOGID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// LOG主键  INT(4) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MALLLOGID
        ///	唯一主键
        /// </summary>
        public string MALLLOGID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 PRODUCT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int PRODUCT
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 PRODUCT
        ///	默认值:0
        /// </summary>
        public string PRODUCT_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USERTYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public byte USERTYPE
        {
            set
            {
                ColumnValues[2] = value.ToString(); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 USERTYPE
        ///	默认值:0
        /// </summary>
        public string USERTYPE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 USERID_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int USERID
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 USERID
        ///	默认值:0
        /// </summary>
        public string USERID_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        ///    NVARCHAR(1000)  NULL
        /// </summary>
        public string USERNAME
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
        ///    NVARCHAR(1000)  NULL
        /// </summary>
        public string REALNAME
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
        ///    TINYINT(1)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ITEMTYPE_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public byte ITEMTYPE
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    TINYINT(1)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ITEMTYPE
        ///	默认值:0
        /// </summary>
        public string ITEMTYPE_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ITEMID_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int ITEMID
        {
            set
            {
                ColumnValues[7] = value.ToString(); UpdateStatus[7] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ITEMID
        ///	默认值:0
        /// </summary>
        public string ITEMID_ToString
        {
            get
            {
                return ColumnValues[7];
            }
        }
        /// <summary>
        ///    NVARCHAR(8000)  NULL
        /// </summary>
        public string DESCRIPTION
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
        ///    NVARCHAR(100)  NULL
        /// </summary>
        public string IP
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
        ///   DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ADDEDTIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime ADDEDTIME
        {
            set
            {
                ColumnValues[10] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ADDEDTIME
        ///	默认值:getdate
        /// </summary>
        public string ADDEDTIME_ToString
        {
            get
            {
                return ColumnValues[10];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// LOG主键 返回 "MALLLOGID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MALLLOGID = "MALLLOGID";
        /// <summary>
        ///   返回 "PRODUCT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PRODUCT = "PRODUCT";
        /// <summary>
        ///   返回 "USERTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERTYPE = "USERTYPE";
        /// <summary>
        ///   返回 "USERID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERID = "USERID";
        /// <summary>
        ///   返回 "USERNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _USERNAME = "USERNAME";
        /// <summary>
        ///   返回 "REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REALNAME = "REALNAME";
        /// <summary>
        ///   返回 "ITEMTYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ITEMTYPE = "ITEMTYPE";
        /// <summary>
        ///   返回 "ITEMID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ITEMID = "ITEMID";
        /// <summary>
        ///   返回 "DESCRIPTION", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DESCRIPTION = "DESCRIPTION";
        /// <summary>
        ///   返回 "IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _IP = "IP";
        /// <summary>
        ///  返回 "ADDEDTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ADDEDTIME = "ADDEDTIME";

        #endregion
        #region 函数
        /// <summary>
        /// ADMIN_LOG的构造函数
        /// </summary>
        public ADMIN_LOG()
        {
            this.TableName = "ADMIN_LOG";
            this.PrimaryKey = new string[] { _MALLLOGID };
            this.IdentityColumn = this._MALLLOGID;
            this.columns = new string[] { _MALLLOGID, _PRODUCT, _USERTYPE, _USERID, _USERNAME, _REALNAME, _ITEMTYPE, _ITEMID, _DESCRIPTION, _IP, _ADDEDTIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表ADMIN_LOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, INT, TINYINT, INT, NVARCHAR, NVARCHAR, TINYINT, INT, NVARCHAR, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 4, 4, 1, 4, 1000, 1000, 1, 4, 8000, 100, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", "0", "0", "0", "", "", "0", "0", "", "", "getdate" };
                this.Descriptions = new string[] { "LOG主键", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="MALLLOGID">LOG主键</param>
                /// <returns>bool</returns>
                public bool Find(int P_MALLLOGID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_MALLLOGID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝ADMIN_LOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public ADMIN_LOG Copy()
                {
                    ADMIN_LOG new_obj=new ADMIN_LOG();
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