
using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="ADMIN_WEBMANAGER"
    /// Columns="WEBMANAGER_ID,WEBMANAGER_GROUP_ID,WEBMANAGER_PRODUCT,WEBMANAGER_IP,WEBMANAGER_IP_LASTLOGIN,WEBMANAGER_LEADER_REALNAME,WEBMANAGER_LEADER_LEVEL,WEBMANAGER_REALNAME,WEBMANAGER_NAME,WEBMANAGER_PASSWORD,WEBMANAGER_EMAIL,WEBMANAGER_PHONE,WEBMANAGER_OICQ,WEBMANAGER_MOBILE,WEBMANAGER_LAST_LOGINTIME,WEBMANAGER_CREATETIME,WEBMANAGER_REMARK,WEBMANAGER_STATUS,WEBMANAGER_RECIEVE_ALERTEMAIL,WEBMANAGER_IS_ADMIN"
    /// PrimaryKeys="WEBMANAGER_ID"
    /// </summary>
    public sealed class ADMIN_WEBMANAGER : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/12/6 12:46:44
        #region 属性
        /// <summary>
        /// 用户ID  INT(4) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_ID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public int WEBMANAGER_ID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        /// 用户ID  INT(4) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_ID
        ///	唯一主键
        /// </summary>
        public string WEBMANAGER_ID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        /// 权限分组ID  INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_GROUP_ID_ToString 更加准确
        /// </summary>
        public int WEBMANAGER_GROUP_ID
        {
            set
            {
                ColumnValues[1] = value.ToString(); UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        /// 权限分组ID  INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_GROUP_ID
        /// </summary>
        public string WEBMANAGER_GROUP_ID_ToString
        {
            get
            {
                return ColumnValues[1];
            }
        }
        /// <summary>
        /// 所能查看的product，如： 1|8|9  VARCHAR(50)  NULL
        /// </summary>
        public string WEBMANAGER_PRODUCT
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
        /// 客户端IP   VARCHAR(50)  NULL
        /// </summary>
        public string WEBMANAGER_IP
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
        /// 最后登录的客户端IP，如果跟这个不一样则会退出登录  VARCHAR(50)  NULL
        /// </summary>
        public string WEBMANAGER_IP_LASTLOGIN
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
        /// 团队长姓名  NVARCHAR(100)  NULL
        /// </summary>
        public string WEBMANAGER_LEADER_REALNAME
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
        /// 团队级别：0队员，1小团队长，2大团队长，3更大团队长  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_LEADER_LEVEL_ToString 更加准确
        /// </summary>
        public int WEBMANAGER_LEADER_LEVEL
        {
            set
            {
                ColumnValues[6] = value.ToString(); UpdateStatus[6] = 1;
            }
        }
        /// <summary>
        /// 团队级别：0队员，1小团队长，2大团队长，3更大团队长  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_LEADER_LEVEL
        /// </summary>
        public string WEBMANAGER_LEADER_LEVEL_ToString
        {
            get
            {
                return ColumnValues[6];
            }
        }
        /// <summary>
        /// 真实姓名   NVARCHAR(100)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME
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
        /// 用户名  NVARCHAR(100)  NOT NULL
        /// </summary>
        public string WEBMANAGER_NAME
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
        /// 密码 （加密存储）  NVARCHAR(100)  NULL
        /// </summary>
        public string WEBMANAGER_PASSWORD
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
        /// 邮箱  VARCHAR(50)  NULL
        /// </summary>
        public string WEBMANAGER_EMAIL
        {
            get
            {
                return ColumnValues[10];
            }
            set
            {
                ColumnValues[10] = value; UpdateStatus[10] = 1;
            }
        }
        /// <summary>
        /// 固定电话  NVARCHAR(100)  NULL
        /// </summary>
        public string WEBMANAGER_PHONE
        {
            get
            {
                return ColumnValues[11];
            }
            set
            {
                ColumnValues[11] = value; UpdateStatus[11] = 1;
            }
        }
        /// <summary>
        /// QQ  VARCHAR(50)  NULL
        /// </summary>
        public string WEBMANAGER_OICQ
        {
            get
            {
                return ColumnValues[12];
            }
            set
            {
                ColumnValues[12] = value; UpdateStatus[12] = 1;
            }
        }
        /// <summary>
        /// 移动电话  NVARCHAR(100)  NULL
        /// </summary>
        public string WEBMANAGER_MOBILE
        {
            get
            {
                return ColumnValues[13];
            }
            set
            {
                ColumnValues[13] = value; UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// 最后登录时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_LAST_LOGINTIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime WEBMANAGER_LAST_LOGINTIME
        {
            set
            {
                ColumnValues[14] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// 最后登录时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_LAST_LOGINTIME
        ///	默认值:getdate
        /// </summary>
        public string WEBMANAGER_LAST_LOGINTIME_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime WEBMANAGER_CREATETIME
        {
            set
            {
                ColumnValues[15] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string WEBMANAGER_CREATETIME_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        /// 备注  NVARCHAR(4000)  NULL
        /// </summary>
        public string WEBMANAGER_REMARK
        {
            get
            {
                return ColumnValues[16];
            }
            set
            {
                ColumnValues[16] = value; UpdateStatus[16] = 1;
            }
        }
        /// <summary>
        /// 用户状态:100正常，200停用  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_STATUS_ToString 更加准确
        ///	默认值:100
        /// </summary>
        public int WEBMANAGER_STATUS
        {
            set
            {
                ColumnValues[17] = value.ToString(); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 用户状态:100正常，200停用  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_STATUS
        ///	默认值:100
        /// </summary>
        public string WEBMANAGER_STATUS_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }
        /// <summary>
        /// 是否接收报错邮件  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_RECIEVE_ALERTEMAIL_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int WEBMANAGER_RECIEVE_ALERTEMAIL
        {
            set
            {
                ColumnValues[18] = value.ToString(); UpdateStatus[18] = 1;
            }
        }
        /// <summary>
        /// 是否接收报错邮件  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_RECIEVE_ALERTEMAIL
        ///	默认值:1
        /// </summary>
        public string WEBMANAGER_RECIEVE_ALERTEMAIL_ToString
        {
            get
            {
                return ColumnValues[18];
            }
        }
        /// <summary>
        /// 是否超级管理员  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 WEBMANAGER_IS_ADMIN_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int WEBMANAGER_IS_ADMIN
        {
            set
            {
                ColumnValues[19] = value.ToString(); UpdateStatus[19] = 1;
            }
        }
        /// <summary>
        /// 是否超级管理员  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 WEBMANAGER_IS_ADMIN
        ///	默认值:0
        /// </summary>
        public string WEBMANAGER_IS_ADMIN_ToString
        {
            get
            {
                return ColumnValues[19];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 用户ID 返回 "WEBMANAGER_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_ID = "WEBMANAGER_ID";
        /// <summary>
        /// 权限分组ID 返回 "WEBMANAGER_GROUP_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_GROUP_ID = "WEBMANAGER_GROUP_ID";
        /// <summary>
        /// 所能查看的product，如： 1|8|9 返回 "WEBMANAGER_PRODUCT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_PRODUCT = "WEBMANAGER_PRODUCT";
        /// <summary>
        /// 客户端IP  返回 "WEBMANAGER_IP", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_IP = "WEBMANAGER_IP";
        /// <summary>
        /// 最后登录的客户端IP，如果跟这个不一样则会退出登录 返回 "WEBMANAGER_IP_LASTLOGIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_IP_LASTLOGIN = "WEBMANAGER_IP_LASTLOGIN";
        /// <summary>
        /// 团队长姓名 返回 "WEBMANAGER_LEADER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_LEADER_REALNAME = "WEBMANAGER_LEADER_REALNAME";
        /// <summary>
        /// 团队级别：0队员，1小团队长，2大团队长，3更大团队长 返回 "WEBMANAGER_LEADER_LEVEL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_LEADER_LEVEL = "WEBMANAGER_LEADER_LEVEL";
        /// <summary>
        /// 真实姓名  返回 "WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REALNAME = "WEBMANAGER_REALNAME";
        /// <summary>
        /// 用户名 返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 密码 （加密存储） 返回 "WEBMANAGER_PASSWORD", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_PASSWORD = "WEBMANAGER_PASSWORD";
        /// <summary>
        /// 邮箱 返回 "WEBMANAGER_EMAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_EMAIL = "WEBMANAGER_EMAIL";
        /// <summary>
        /// 固定电话 返回 "WEBMANAGER_PHONE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_PHONE = "WEBMANAGER_PHONE";
        /// <summary>
        /// QQ 返回 "WEBMANAGER_OICQ", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_OICQ = "WEBMANAGER_OICQ";
        /// <summary>
        /// 移动电话 返回 "WEBMANAGER_MOBILE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_MOBILE = "WEBMANAGER_MOBILE";
        /// <summary>
        /// 最后登录时间 返回 "WEBMANAGER_LAST_LOGINTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_LAST_LOGINTIME = "WEBMANAGER_LAST_LOGINTIME";
        /// <summary>
        /// 创建时间 返回 "WEBMANAGER_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_CREATETIME = "WEBMANAGER_CREATETIME";
        /// <summary>
        /// 备注 返回 "WEBMANAGER_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REMARK = "WEBMANAGER_REMARK";
        /// <summary>
        /// 用户状态:100正常，200停用 返回 "WEBMANAGER_STATUS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_STATUS = "WEBMANAGER_STATUS";
        /// <summary>
        /// 是否接收报错邮件 返回 "WEBMANAGER_RECIEVE_ALERTEMAIL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_RECIEVE_ALERTEMAIL = "WEBMANAGER_RECIEVE_ALERTEMAIL";
        /// <summary>
        /// 是否超级管理员 返回 "WEBMANAGER_IS_ADMIN", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_IS_ADMIN = "WEBMANAGER_IS_ADMIN";

        #endregion
        #region 函数
        /// <summary>
        /// ADMIN_WEBMANAGER的构造函数
        /// </summary>
        public ADMIN_WEBMANAGER()
        {
            this.TableName = "ADMIN_WEBMANAGER";
            this.PrimaryKey = new string[] { _WEBMANAGER_ID };
            this.IdentityColumn = this._WEBMANAGER_ID;
            this.columns = new string[] { _WEBMANAGER_ID, _WEBMANAGER_GROUP_ID, _WEBMANAGER_PRODUCT, _WEBMANAGER_IP, _WEBMANAGER_IP_LASTLOGIN, _WEBMANAGER_LEADER_REALNAME, _WEBMANAGER_LEADER_LEVEL, _WEBMANAGER_REALNAME, _WEBMANAGER_NAME, _WEBMANAGER_PASSWORD, _WEBMANAGER_EMAIL, _WEBMANAGER_PHONE, _WEBMANAGER_OICQ, _WEBMANAGER_MOBILE, _WEBMANAGER_LAST_LOGINTIME, _WEBMANAGER_CREATETIME, _WEBMANAGER_REMARK, _WEBMANAGER_STATUS, _WEBMANAGER_RECIEVE_ALERTEMAIL, _WEBMANAGER_IS_ADMIN };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表ADMIN_WEBMANAGER的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, INT, VARCHAR, VARCHAR, VARCHAR, NVARCHAR, INT, NVARCHAR, NVARCHAR, NVARCHAR, VARCHAR, NVARCHAR, VARCHAR, NVARCHAR, DATETIME, DATETIME, NVARCHAR, INT, INT, INT };
                this.Lengths = new int[] { 4, 4, 50, 50, 50, 100, 4, 100, 100, 100, 50, 100, 50, 100, 8, 8, 4000, 4, 4, 4 };
                this.IsNullables = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "getdate", "getdate", " ", "100", "1", "0" };
                this.Descriptions = new string[] { "用户ID", "权限分组ID", "所能查看的product，如： 1|8|9", "客户端IP ", "最后登录的客户端IP，如果跟这个不一样则会退出登录", "团队长姓名", "团队级别：0队员，1小团队长，2大团队长，3更大团队长", "真实姓名 ", "用户名", "密码 （加密存储）", "邮箱", "固定电话", "QQ", "移动电话", "最后登录时间", "创建时间", "备注", "用户状态:100正常，200停用", "是否接收报错邮件", "是否超级管理员" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="WEBMANAGER_ID">用户ID</param>
                /// <returns>bool</returns>
                public bool Find(int P_WEBMANAGER_ID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_WEBMANAGER_ID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝ADMIN_WEBMANAGER（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public ADMIN_WEBMANAGER Copy()
                {
                    ADMIN_WEBMANAGER new_obj=new ADMIN_WEBMANAGER();
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

        private bool inner_join_admin_webmanager_group = false;
        private bool left_join_admin_webmanager_group = false;

        /// <summary>
        /// INNER JOIN ADMIN_WEBMANAGER_GROUP ADMIN_WEBMANAGER_GROUP  ON ADMIN_WEBMANAGER_GROUP.WEBMANAGER_GROUP_ID=ADMIN_WEBMANAGER.GROUP_ID
        /// </summary>
        public bool INNER_JOIN_ADMIN_WEBMANAGER_GROUP
        {
            set
            {
                this.inner_join_admin_webmanager_group = value;
            }
        }
        /// <summary>
        /// LEFT OUTER JOIN ADMIN_WEBMANAGER_GROUP ADMIN_WEBMANAGER_GROUP  ON ADMIN_WEBMANAGER_GROUP.WEBMANAGER_GROUP_ID=ADMIN_WEBMANAGER.GROUP_ID
        /// </summary>
        public bool LEFT_JOIN_ADMIN_WEBMANAGER_GROUP
        {
            set
            {
                this.left_join_admin_webmanager_group = value;
            }
        }

        /// <summary>
        /// 根据关联设置
        /// INNER_JOIN_ADMIN_WEBMANAGER_GROUP
        /// LEFT_JOIN_ADMIN_WEBMANAGER_GROUP

        /// 为基类查询语句设置关联表JoinTableList
        /// </summary>
        protected override void SetJoinValues()
        {
            this.JoinTableListOnInit();
            this.JoinTableList.Rows.Clear();
            if (this.inner_join_admin_webmanager_group == true)
            {
                this.NewJoin("", "INNER", "ADMIN_WEBMANAGER_GROUP", "ADMIN_WEBMANAGER_GROUP", "GROUP_ID", "WEBMANAGER_GROUP_ID");
            }
            if (this.left_join_admin_webmanager_group == true)
            {
                this.NewJoin("", "LEFT OUTER", "ADMIN_WEBMANAGER_GROUP", "ADMIN_WEBMANAGER_GROUP", "GROUP_ID", "WEBMANAGER_GROUP_ID");
            }

            this.JoinTableList.AcceptChanges();
        }

        #endregion
        #endregion 系统代码，请不要动

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[ADMIN_WEBMANAGER](
                 [WEBMANAGER_ID] [INT]  IDENTITY(1,1)  NOT NULL ,
                 [WEBMANAGER_GROUP_ID] [INT]  NOT NULL ,
                 [WEBMANAGER_PRODUCT] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_IP] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_IP_LASTLOGIN] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_LEADER_REALNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_LEADER_LEVEL] [INT]  NULL ,
                 [WEBMANAGER_REALNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [WEBMANAGER_PASSWORD] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_EMAIL] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_PHONE] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_OICQ] [VARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_MOBILE] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_LAST_LOGINTIME] [DATETIME]  NULL  CONSTRAINT [DF_ADMIN_WEBMANAGER_WEBMANAGER_LAST_LOGINTIME] DEFAULT ('getdate') ,
                 [WEBMANAGER_CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_ADMIN_WEBMANAGER_WEBMANAGER_CREATETIME] DEFAULT ('getdate') ,
                 [WEBMANAGER_REMARK] [NVARCHAR]  (2000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_STATUS] [INT]  NULL  CONSTRAINT [DF_ADMIN_WEBMANAGER_WEBMANAGER_STATUS] DEFAULT ('100') ,
                 [WEBMANAGER_RECIEVE_ALERTEMAIL] [INT]  NULL  CONSTRAINT [DF_ADMIN_WEBMANAGER_WEBMANAGER_RECIEVE_ALERTEMAIL] DEFAULT ('1') ,
                 [WEBMANAGER_IS_ADMIN] [INT]  NULL  CONSTRAINT [DF_ADMIN_WEBMANAGER_WEBMANAGER_IS_ADMIN] DEFAULT ('0') ,
                
                CONSTRAINT [PK_ADMIN_WEBMANAGER] PRIMARY KEY CLUSTERED 
                (
	             [WEBMANAGER_ID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限分组ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_GROUP_ID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所能查看的product，如： 1|8|9' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_PRODUCT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户端IP ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_IP'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录的客户端IP，如果跟这个不一样则会退出登录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_IP_LASTLOGIN'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'团队长姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_LEADER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'团队级别：0队员，1小团队长，2大团队长，3更大团队长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_LEADER_LEVEL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码 （加密存储）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_PASSWORD'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_EMAIL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_PHONE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_OICQ'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_MOBILE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_LAST_LOGINTIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REMARK'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态:100正常，200停用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_STATUS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否接收报错邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_RECIEVE_ALERTEMAIL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否超级管理员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN_WEBMANAGER', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_IS_ADMIN'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}