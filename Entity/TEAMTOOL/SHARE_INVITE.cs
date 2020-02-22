using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="SHARE_INVITE"
    /// Columns="INVITE_DATE,INVITE_WEBMANAGER_NAME"
    /// PrimaryKeys="INVITE_DATE"
    /// </summary>
    public sealed class SHARE_INVITE : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/11/17 18:42:00
        #region 属性
        /// <summary>
        ///   DATETIME(8)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 INVITE_DATE_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public DateTime INVITE_DATE
        {
            set
            {
                ColumnValues[0] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   DATETIME(8)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 INVITE_DATE
        ///	唯一主键
        /// </summary>
        public string INVITE_DATE_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///   NVARCHAR(100)  NULL
        /// </summary>
        public string INVITE_WEBMANAGER_NAME
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "INVITE_DATE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INVITE_DATE = "INVITE_DATE";
        /// <summary>
        ///  返回 "INVITE_WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _INVITE_WEBMANAGER_NAME = "INVITE_WEBMANAGER_NAME";

        #endregion
        #region 函数
        /// <summary>
        /// SHARE_INVITE的构造函数
        /// </summary>
        public SHARE_INVITE()
        {
            this.TableName = "SHARE_INVITE";
            this.PrimaryKey = new string[] { _INVITE_DATE };

            this.columns = new string[] { _INVITE_DATE, _INVITE_WEBMANAGER_NAME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表SHARE_INVITE的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0 };
                this.DataTypes = new string[] { DATETIME, NVARCHAR };
                this.Lengths = new int[] { 8, 100 };
                this.IsNullables = new int[] { 0, 1 };
                this.DefaultValues = new string[] { " ", " " };
                this.Descriptions = new string[] { " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="INVITE_DATE"></param>
                /// <returns>bool</returns>
                public bool Find(DateTime P_INVITE_DATE)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_INVITE_DATE.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝SHARE_INVITE（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public SHARE_INVITE Copy()
                {
                    SHARE_INVITE new_obj=new SHARE_INVITE();
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