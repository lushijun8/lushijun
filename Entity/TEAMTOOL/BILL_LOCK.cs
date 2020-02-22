using System;
namespace Entity.TEAMTOOL
{
   /// <summary>
	/// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="TEAMTOOL" 
	/// Table="BILL_LOCK"
	/// Columns="BILL_LOCK_YEAR,BILL_LOCK_MONTH,BILL_LOCK_LEADER_REALNAME"
	/// PrimaryKeys="BILL_LOCK_YEAR,BILL_LOCK_MONTH,BILL_LOCK_LEADER_REALNAME"
	/// </summary>
    public sealed class BILL_LOCK : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2016/1/4 15:41:05
        #region 属性
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_LOCK_YEAR_ToString 更加准确
        ///	主健之一，其他主健还有：BILL_LOCK_YEAR,BILL_LOCK_MONTH,BILL_LOCK_LEADER_REALNAME
        /// </summary>
        public int BILL_LOCK_YEAR
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_LOCK_YEAR
        ///	主健之一，其他主健还有：BILL_LOCK_YEAR,BILL_LOCK_MONTH,BILL_LOCK_LEADER_REALNAME
        /// </summary>
        public string BILL_LOCK_YEAR_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 BILL_LOCK_MONTH_ToString 更加准确
        ///	主健之一，其他主健还有：BILL_LOCK_YEAR,BILL_LOCK_MONTH,BILL_LOCK_LEADER_REALNAME
        /// </summary>
        public int BILL_LOCK_MONTH
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 BILL_LOCK_MONTH
        ///	主健之一，其他主健还有：BILL_LOCK_YEAR,BILL_LOCK_MONTH,BILL_LOCK_LEADER_REALNAME
        /// </summary>
        public string BILL_LOCK_MONTH_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        ///   NVARCHAR(100)  NOT NULL
        ///	主健之一，其他主健还有：BILL_LOCK_YEAR,BILL_LOCK_MONTH,BILL_LOCK_LEADER_REALNAME
        /// </summary>
        public string BILL_LOCK_LEADER_REALNAME
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "BILL_LOCK_YEAR", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_LOCK_YEAR = "BILL_LOCK_YEAR";
        /// <summary>
        ///   返回 "BILL_LOCK_MONTH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_LOCK_MONTH = "BILL_LOCK_MONTH";
        /// <summary>
        ///  返回 "BILL_LOCK_LEADER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _BILL_LOCK_LEADER_REALNAME = "BILL_LOCK_LEADER_REALNAME";

        #endregion
        #region 函数
        /// <summary>
        /// BILL_LOCK的构造函数
        /// </summary>
        public BILL_LOCK()
        {
            this.TableName = "BILL_LOCK";
            this.PrimaryKey = new string[] { _BILL_LOCK_YEAR, _BILL_LOCK_MONTH, _BILL_LOCK_LEADER_REALNAME };

            this.columns = new string[] { _BILL_LOCK_YEAR, _BILL_LOCK_MONTH, _BILL_LOCK_LEADER_REALNAME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表BILL_LOCK的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 1 };
                this.DataTypes = new string[] { INT, INT, NVARCHAR };
                this.Lengths = new int[] { 4, 4, 100 };
                this.IsNullables = new int[] { 0, 0, 0 };
                this.DefaultValues = new string[] { " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="BILL_LOCK_YEAR"></param>
        /// <param name="BILL_LOCK_MONTH"> </param>
        /// <param name="BILL_LOCK_LEADER_REALNAME"></param>
                /// <returns>bool</returns>
                public bool Find(int P_BILL_LOCK_YEAR,int P_BILL_LOCK_MONTH,string P_BILL_LOCK_LEADER_REALNAME)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_BILL_LOCK_YEAR.ToString();
        this.ColumnValues[1]=P_BILL_LOCK_MONTH.ToString();
        this.ColumnValues[2]=P_BILL_LOCK_LEADER_REALNAME;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝BILL_LOCK（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public BILL_LOCK Copy()
                {
                    BILL_LOCK new_obj=new BILL_LOCK();
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
        /*
        /// <summary>
        /// 此处根据BILL_LOCK_YEAR每500000条存一个表
        /// </summary>
        protected override void TableNameLogic()
        {
            if (this.BILL_LOCK_YEAR_ToString.Trim() !=  "")
            {
                int length = 10;
                int mod = 500000;
                int bill_lock_year = int.Parse(this.BILL_LOCK_YEAR_ToString);

                int baseId = ((bill_lock_year - 1) / mod) * mod;
                int startId = baseId + 1;
                int endId = baseId + mod;  

                string[] tablenames = Com.Net.HtmlUtil.GetRegexGroupFromString("(.*)_\\d{" + length +  "}_\\d{" + length +  "}", TableName, System.Text.RegularExpressions.RegexOptions.None);
                string tablename_Suffix =  "_" + startId.ToString().PadLeft(length, '0') +  "_" + endId.ToString().PadLeft(length, '0');
                string tablename_Prefix = this.TableName;
                if (tablenames != null && tablenames.Length > 0)
                {
                    tablename_Prefix = tablenames[0];
                }
                this.TableName = tablename_Prefix + tablename_Suffix;
            } 
        }
        */
        #endregion
    }
}