
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="ADMIN_PRODUCT"
    /// Columns="PRODUCTID,PRODUCTNAME,TABLEPREFIX,MANAGEREMAIL,MANAGERPHONE"
    /// PrimaryKeys="PRODUCTID"
    /// </summary>
    public sealed class ADMIN_PRODUCT : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/9/7 16:50:37
        #region 属性
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 PRODUCTID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int PRODUCTID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 PRODUCTID
        ///	唯一主键
        /// </summary>
        public string PRODUCTID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    NVARCHAR(40)  NULL
        /// </summary>
        public string PRODUCTNAME
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
        ///    VARCHAR(20)  NULL
        /// </summary>
        public string TABLEPREFIX
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
        ///    VARCHAR(200)  NULL
        /// </summary>
        public string MANAGEREMAIL
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
        ///   VARCHAR(200)  NULL
        /// </summary>
        public string MANAGERPHONE
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "PRODUCTID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PRODUCTID = "PRODUCTID";
        /// <summary>
        ///   返回 "PRODUCTNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PRODUCTNAME = "PRODUCTNAME";
        /// <summary>
        ///   返回 "TABLEPREFIX", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TABLEPREFIX = "TABLEPREFIX";
        /// <summary>
        ///   返回 "MANAGEREMAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MANAGEREMAIL = "MANAGEREMAIL";
        /// <summary>
        ///  返回 "MANAGERPHONE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MANAGERPHONE = "MANAGERPHONE";

        #endregion
        #region 函数
        /// <summary>
        /// ADMIN_PRODUCT的构造函数
        /// </summary>
        public ADMIN_PRODUCT()
        {
            this.TableName = "ADMIN_PRODUCT";
            this.PrimaryKey = new string[] { _PRODUCTID };

            this.columns = new string[] { _PRODUCTID, _PRODUCTNAME, _TABLEPREFIX, _MANAGEREMAIL, _MANAGERPHONE };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表ADMIN_PRODUCT的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, NVARCHAR, VARCHAR, VARCHAR, VARCHAR };
                this.Lengths = new int[] { 4, 40, 20, 200, 200 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="PRODUCTID"></param>
                /// <returns>bool</returns>
                public bool Find(int P_PRODUCTID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_PRODUCTID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝ADMIN_PRODUCT（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public ADMIN_PRODUCT Copy()
                {
                    ADMIN_PRODUCT new_obj=new ADMIN_PRODUCT();
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
        /// 此处根据PRODUCTID每500000条存一个表
        /// </summary>
        protected override void TableNameLogic()
        {
            if (this.PRODUCTID_ToString.Trim() !=  "")
            {
                int length = 10;
                int mod = 500000;
                int productid = int.Parse(this.PRODUCTID_ToString);

                int baseId = ((productid - 1) / mod) * mod;
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