
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="ADMIN_FUNCTION"
    /// Columns="FUNCTION_ID,FUNCTION_NAME,FUNCTION_URL,FUNCTION_TYPE,FUNCTION_GROUP_ID,FUNCTION_MODULE_ID,FUNCTION_ORDER,FUNCTION_REMARK,FUNCTION_VIEW_COUNT"
    /// PrimaryKeys="FUNCTION_ID"
    /// </summary>
    public sealed class ADMIN_FUNCTION : Entity.TEAMTOOL.EntityBase
    {
        #region 系统代码，请不要动   生成日期:2015/9/9 14:14:15
        #region 属性
        /// <summary>
        /// 操作ID  INT(4) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FUNCTION_ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int FUNCTION_ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 操作ID  INT(4) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 FUNCTION_ID
        ///	唯一主键
        /// </summary>
        public string FUNCTION_ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        /// 操作名称  NVARCHAR(40)  NOT NULL
        /// </summary>
        public string FUNCTION_NAME
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
        /// 对应链接  NVARCHAR(400)  NULL
        /// </summary>
        public string FUNCTION_URL
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
        /// 是否属于菜单，1：是；0否  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FUNCTION_TYPE_ToString 更加准确
        /// </summary>
        public int FUNCTION_TYPE
        {
            set
            {
                ColumnValues[3] = value.ToString(); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 是否属于菜单，1：是；0否  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 FUNCTION_TYPE
        /// </summary>
        public string FUNCTION_TYPE_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 对应Function_Type=1的Function_Id  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FUNCTION_GROUP_ID_ToString 更加准确
        /// </summary>
        public int FUNCTION_GROUP_ID
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 对应Function_Type=1的Function_Id  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FUNCTION_GROUP_ID
        /// </summary>
        public string FUNCTION_GROUP_ID_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 管理系统模块ID与表[Admin_Module] Module_id关联  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FUNCTION_MODULE_ID_ToString 更加准确
        /// </summary>
        public int FUNCTION_MODULE_ID
        {
            set
            {
                ColumnValues[5] = value.ToString(); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 管理系统模块ID与表[Admin_Module] Module_id关联  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FUNCTION_MODULE_ID
        /// </summary>
        public string FUNCTION_MODULE_ID_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FUNCTION_ORDER_ToString 更加准确
        /// </summary>
        public int FUNCTION_ORDER
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FUNCTION_ORDER
        /// </summary>
        public string FUNCTION_ORDER_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 备注  NVARCHAR(4000)  NULL
        /// </summary>
        public string FUNCTION_REMARK
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
        ///   INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FUNCTION_VIEW_COUNT_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int FUNCTION_VIEW_COUNT
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FUNCTION_VIEW_COUNT
        ///	默认值:0
        /// </summary>
        public string FUNCTION_VIEW_COUNT_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 操作ID 返回 "FUNCTION_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_ID = "FUNCTION_ID";
        /// <summary>
        /// 操作名称 返回 "FUNCTION_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_NAME = "FUNCTION_NAME";
        /// <summary>
        /// 对应链接 返回 "FUNCTION_URL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_URL = "FUNCTION_URL";
        /// <summary>
        /// 是否属于菜单，1：是；0否 返回 "FUNCTION_TYPE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_TYPE = "FUNCTION_TYPE";
        /// <summary>
        /// 对应Function_Type=1的Function_Id 返回 "FUNCTION_GROUP_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_GROUP_ID = "FUNCTION_GROUP_ID";
        /// <summary>
        /// 管理系统模块ID与表[Admin_Module] Module_id关联 返回 "FUNCTION_MODULE_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_MODULE_ID = "FUNCTION_MODULE_ID";
        /// <summary>
        ///   返回 "FUNCTION_ORDER", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_ORDER = "FUNCTION_ORDER";
        /// <summary>
        /// 备注 返回 "FUNCTION_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_REMARK = "FUNCTION_REMARK";
        /// <summary>
        ///  返回 "FUNCTION_VIEW_COUNT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FUNCTION_VIEW_COUNT = "FUNCTION_VIEW_COUNT";

        #endregion
        #region 函数
        /// <summary>
        /// ADMIN_FUNCTION的构造函数
        /// </summary>
        public ADMIN_FUNCTION()
        {
            this.TableName = "ADMIN_FUNCTION";
            this.PrimaryKey = new string[] { _FUNCTION_ID };
            this.IdentityColumn = this._FUNCTION_ID;
            this.columns = new string[] { _FUNCTION_ID, _FUNCTION_NAME, _FUNCTION_URL, _FUNCTION_TYPE, _FUNCTION_GROUP_ID, _FUNCTION_MODULE_ID, _FUNCTION_ORDER, _FUNCTION_REMARK, _FUNCTION_VIEW_COUNT };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表ADMIN_FUNCTION的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, NVARCHAR, NVARCHAR, INT, INT, INT, INT, NVARCHAR, INT };
                this.Lengths = new int[] { 4, 40, 400, 4, 4, 4, 4, 4000, 4 };
                this.IsNullables = new int[] { 0, 0, 1, 0, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", "0" };
                this.Descriptions = new string[] { "操作ID", "操作名称", "对应链接", "是否属于菜单，1：是；0否", "对应Function_Type=1的Function_Id", "管理系统模块ID与表[Admin_Module] Module_id关联", " ", "备注", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="FUNCTION_ID">操作ID</param>
                /// <returns>bool</returns>
                public bool Find(int P_FUNCTION_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_FUNCTION_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝ADMIN_FUNCTION（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public ADMIN_FUNCTION Copy()
                {
                    ADMIN_FUNCTION new_obj=new ADMIN_FUNCTION();
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

        private bool inner_join_admin_module = false;
        private bool left_join_admin_module = false;

        /// <summary>
        /// INNER JOIN ADMIN_MODULE ADMIN_MODULE  ON ADMIN_MODULE.FUNCTION_MODULE_ID=.MODULE_ID
        /// </summary>
        public bool INNER_JOIN_ADMIN_MODULE
        {
            set
            {
                this.inner_join_admin_module = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_MODULE ADMIN_MODULE  ON ADMIN_MODULE.FUNCTION_MODULE_ID=.MODULE_ID
        /// </summary>
        public bool LEFT_JOIN_ADMIN_MODULE
        {
            set
            {
                this.left_join_admin_module = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_ADMIN_MODULE
        /// LEFT_JOIN_ADMIN_MODULE

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_admin_module == true)
            {
                this.NewJoin("", "INNER", "ADMIN_MODULE", "ADMIN_MODULE", "MODULE_ID", "FUNCTION_MODULE_ID");
            }
            if (this.left_join_admin_module == true)
            {
                this.NewJoin("", "LEFT OUTER", "ADMIN_MODULE", "ADMIN_MODULE", "MODULE_ID", "FUNCTION_MODULE_ID");
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