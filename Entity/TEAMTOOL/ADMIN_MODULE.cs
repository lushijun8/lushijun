
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="ADMIN_MODULE"
    /// Columns="MODULE_ID,MODULE_NAME,MODULE_ORDER,MODULE_REMARK"
    /// PrimaryKeys="MODULE_ID"
    /// </summary>
	public sealed class ADMIN_MODULE  : Entity.TEAMTOOL.EntityBase
	{
        #region 系统代码，请不要动   生成日期:2015/9/9 14:13:37
        #region 属性
        /// <summary>
        /// 管理系统模块ID  INT(4) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MODULE_ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int MODULE_ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 管理系统模块ID  INT(4) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MODULE_ID
        ///	唯一主键
        /// </summary>
        public string MODULE_ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        /// 管理系统模块名称  NVARCHAR(100)  NOT NULL
        /// </summary>
        public string MODULE_NAME
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
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MODULE_ORDER_ToString 更加准确
        /// </summary>
        public int MODULE_ORDER
        {
            set
            {
                ColumnValues[2] = value.ToString(); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 MODULE_ORDER
        /// </summary>
        public string MODULE_ORDER_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 备注  NVARCHAR(4000)  NULL
        /// </summary>
        public string MODULE_REMARK
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 管理系统模块ID 返回 "MODULE_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MODULE_ID = "MODULE_ID";
        /// <summary>
        /// 管理系统模块名称 返回 "MODULE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MODULE_NAME = "MODULE_NAME";
        /// <summary>
        ///   返回 "MODULE_ORDER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MODULE_ORDER = "MODULE_ORDER";
        /// <summary>
        /// 备注 返回 "MODULE_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MODULE_REMARK = "MODULE_REMARK";

        #endregion
        #region 函数
        /// <summary>
        /// ADMIN_MODULE的构造函数
        /// </summary>
        public ADMIN_MODULE()
        {
            this.TableName = "ADMIN_MODULE";
            this.PrimaryKey = new string[] { _MODULE_ID };
            this.IdentityColumn = this._MODULE_ID;
            this.columns = new string[] { _MODULE_ID, _MODULE_NAME, _MODULE_ORDER, _MODULE_REMARK };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表ADMIN_MODULE的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0 };
                this.DataTypes = new string[] { INT, NVARCHAR, INT, NVARCHAR };
                this.Lengths = new int[] { 4, 100, 4, 4000 };
                this.IsNullables = new int[] { 0, 0, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " " };
                this.Descriptions = new string[] { "管理系统模块ID", "管理系统模块名称", " ", "备注" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="MODULE_ID">管理系统模块ID</param>
                /// <returns>bool</returns>
                public bool Find(int P_MODULE_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_MODULE_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝ADMIN_MODULE（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public ADMIN_MODULE Copy()
                {
                    ADMIN_MODULE new_obj=new ADMIN_MODULE();
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