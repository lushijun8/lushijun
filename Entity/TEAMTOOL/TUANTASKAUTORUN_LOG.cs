using System;
namespace Entity.TEAMTOOL
{
   /// <summary>
	/// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="TEAMTOOL" 
	/// Table="TUANTASKAUTORUN_LOG"
	/// Columns="LOGID,DATABASE_NAME,ID,CREATETIME,WEBMANAGER_REALNAME,REMARK"
	/// PrimaryKeys="LOGID"
	/// </summary>
    public sealed class TUANTASKAUTORUN_LOG : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2017/6/2 12:01:12
        #region 属性
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LOGID_ToString 更加准确
        ///	唯一主键
        /// </summary>
        public long LOGID
        {
            set
            {
                ColumnValues[0] = value.ToString(); UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   BIGINT(8) 自增列 NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 LOGID
        ///	唯一主键
        /// </summary>
        public string LOGID_ToString
        {
            get
            {
                return ColumnValues[0];
            }
        }
        /// <summary>
        ///    NVARCHAR(100)  NULL
        /// </summary>
        public string DATABASE_NAME
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
        ///    NVARCHAR(100)  NULL
        /// </summary>
        public string ID
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
        ///    DATETIME(8)  NULL
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
        ///    DATETIME(8)  NULL
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
        /// <summary>
        ///    NVARCHAR(100)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME
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
        ///   NVARCHAR(8000)  NULL
        /// </summary>
        public string REMARK
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "LOGID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LOGID = "LOGID";
        /// <summary>
        ///   返回 "DATABASE_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DATABASE_NAME = "DATABASE_NAME";
        /// <summary>
        ///   返回 "ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ID = "ID";
        /// <summary>
        ///   返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        ///   返回 "WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REALNAME = "WEBMANAGER_REALNAME";
        /// <summary>
        ///  返回 "REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _REMARK = "REMARK";

        #endregion
        #region 函数
        /// <summary>
        /// TUANTASKAUTORUN_LOG的构造函数
        /// </summary>
        public TUANTASKAUTORUN_LOG()
        {
            this.TableName = "TUANTASKAUTORUN_LOG";
            this.PrimaryKey = new string[] { _LOGID };
            this.IdentityColumn = this._LOGID;
            this.columns = new string[] { _LOGID, _DATABASE_NAME, _ID, _CREATETIME, _WEBMANAGER_REALNAME, _REMARK };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表TUANTASKAUTORUN_LOG的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { BIGINT, NVARCHAR, NVARCHAR, DATETIME, NVARCHAR, NVARCHAR };
                this.Lengths = new int[] { 8, 100, 100, 8, 100, 8000 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", "getdate", " ", " " };
                this.Descriptions = new string[] { " ", " ", " ", " ", " ", " " };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="LOGID"></param>
                /// <returns>bool</returns>
                public bool Find(long P_LOGID)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_LOGID.ToString();
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝TUANTASKAUTORUN_LOG（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public TUANTASKAUTORUN_LOG Copy()
                {
                    TUANTASKAUTORUN_LOG new_obj=new TUANTASKAUTORUN_LOG();
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

        #region 数据库表生成SQL
        /*
                 				
                CREATE TABLE [dbo].[TUANTASKAUTORUN_LOG](
                 [LOGID] [BIGINT]  IDENTITY(1,1)  NOT NULL ,
                 [DATABASE_NAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ID] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_TUANTASKAUTORUN_LOG_CREATETIME] DEFAULT ('getdate') ,
                 [WEBMANAGER_REALNAME] [NVARCHAR]  (50)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [REMARK] [NVARCHAR]  (4000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                
                CONSTRAINT [PK_TUANTASKAUTORUN_LOG] PRIMARY KEY CLUSTERED 
                (
	             [LOGID] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}