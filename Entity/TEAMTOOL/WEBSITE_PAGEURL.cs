using System;
namespace Entity.TEAMTOOL
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TEAMTOOL" 
    /// Table="WEBSITE_PAGEURL"
    /// Columns="PAGEURL,WEBMANAGER_NAME,WEBMANAGER_REALNAME,WEBMANAGER_NAME_DEPEND,WEBMANAGER_REALNAME_DEPEND,WEBMANAGER_NAME_LIKE,WEBMANAGER_REALNAME_LIKE,ISMY_CREATETIME,ANALYSIS,QUERYSTRING,FORM,DEPEND_PAGEURL,DEPEND_PAGEURL_OUT,QUERYSTRING_PHONE_ENCRYPT,FORM_PHONE_ENCRYPT,ERRORTIME,ERRORINFO,CREATETIME"
    /// PrimaryKeys="PAGEURL"
    /// </summary>
    public sealed class WEBSITE_PAGEURL : Entity.TEAMTOOL.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2016/7/26 16:40:34
        #region 属性
        /// <summary>
        /// 网页URL  VARCHAR(200)  NOT NULL
        ///	唯一主键
        /// </summary>
        public string PAGEURL
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
        /// 负责人，用英文逗号隔开  VARCHAR(1000)  NULL
        /// </summary>
        public string WEBMANAGER_NAME
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
        /// 负责人姓名，用英文逗号隔开  NVARCHAR(2000)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME
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
        /// URL依赖人，用英文逗号隔开  VARCHAR(1000)  NULL
        /// </summary>
        public string WEBMANAGER_NAME_DEPEND
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
        /// URL依赖人姓名，用英文逗号隔开  NVARCHAR(2000)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME_DEPEND
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
        /// 疑似负责人，用英文逗号隔开  VARCHAR(1000)  NULL
        /// </summary>
        public string WEBMANAGER_NAME_LIKE
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
        /// 疑似负责人姓名，用英文逗号隔开  NVARCHAR(2000)  NULL
        /// </summary>
        public string WEBMANAGER_REALNAME_LIKE
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
        /// 认领时间   VARCHAR(1000)  NULL
        /// </summary>
        public string ISMY_CREATETIME
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
        /// 是否分析过疑似负责人，0未分析，1分析过  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ANALYSIS_ToString 更加准确
        ///	默认值:0
        /// </summary>
        public int ANALYSIS
        {
            set
            {
                ColumnValues[8] = value.ToString(); UpdateStatus[8] = 1;
            }
        }
        /// <summary>
        /// 是否分析过疑似负责人，0未分析，1分析过  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ANALYSIS
        ///	默认值:0
        /// </summary>
        public string ANALYSIS_ToString
        {
            get
            {
                return ColumnValues[8];
            }
        }
        /// <summary>
        /// 请求参数  NVARCHAR(-1)  NULL
        /// </summary>
        public string QUERYSTRING
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
        /// 请求Form参数  NVARCHAR(-1)  NULL
        /// </summary>
        public string FORM
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
        /// 本页面依赖的外部URL情况  NVARCHAR(-1)  NULL
        /// </summary>
        public string DEPEND_PAGEURL
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
        /// 依赖本URL的外部URL情况  NVARCHAR(-1)  NULL
        /// </summary>
        public string DEPEND_PAGEURL_OUT
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
        /// GET参数手机号是否加密；0未加密，1已加密  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 QUERYSTRING_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int QUERYSTRING_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[13] = value.ToString(); UpdateStatus[13] = 1;
            }
        }
        /// <summary>
        /// GET参数手机号是否加密；0未加密，1已加密  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 QUERYSTRING_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string QUERYSTRING_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[13];
            }
        }
        /// <summary>
        /// POST参数手机号是否加密 ；0未加密，1已加密  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FORM_PHONE_ENCRYPT_ToString 更加准确
        ///	默认值:1
        /// </summary>
        public int FORM_PHONE_ENCRYPT
        {
            set
            {
                ColumnValues[14] = value.ToString(); UpdateStatus[14] = 1;
            }
        }
        /// <summary>
        /// POST参数手机号是否加密 ；0未加密，1已加密  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FORM_PHONE_ENCRYPT
        ///	默认值:1
        /// </summary>
        public string FORM_PHONE_ENCRYPT_ToString
        {
            get
            {
                return ColumnValues[14];
            }
        }
        /// <summary>
        /// 最近报错时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 ERRORTIME_ToString 更加准确
        /// </summary>
        public DateTime ERRORTIME
        {
            set
            {
                ColumnValues[15] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[15] = 1;
            }
        }
        /// <summary>
        /// 最近报错时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 ERRORTIME
        /// </summary>
        public string ERRORTIME_ToString
        {
            get
            {
                return ColumnValues[15];
            }
        }
        /// <summary>
        /// 最近报错信息  NVARCHAR(-1)  NULL
        /// </summary>
        public string ERRORINFO
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
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        ///	默认值:getdate
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[17] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[17] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        ///	默认值:getdate
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[17];
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 网页URL 返回 "PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _PAGEURL = "PAGEURL";
        /// <summary>
        /// 负责人，用英文逗号隔开 返回 "WEBMANAGER_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME = "WEBMANAGER_NAME";
        /// <summary>
        /// 负责人姓名，用英文逗号隔开 返回 "WEBMANAGER_REALNAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REALNAME = "WEBMANAGER_REALNAME";
        /// <summary>
        /// URL依赖人，用英文逗号隔开 返回 "WEBMANAGER_NAME_DEPEND", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME_DEPEND = "WEBMANAGER_NAME_DEPEND";
        /// <summary>
        /// URL依赖人姓名，用英文逗号隔开 返回 "WEBMANAGER_REALNAME_DEPEND", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REALNAME_DEPEND = "WEBMANAGER_REALNAME_DEPEND";
        /// <summary>
        /// 疑似负责人，用英文逗号隔开 返回 "WEBMANAGER_NAME_LIKE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_NAME_LIKE = "WEBMANAGER_NAME_LIKE";
        /// <summary>
        /// 疑似负责人姓名，用英文逗号隔开 返回 "WEBMANAGER_REALNAME_LIKE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _WEBMANAGER_REALNAME_LIKE = "WEBMANAGER_REALNAME_LIKE";
        /// <summary>
        /// 认领时间  返回 "ISMY_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ISMY_CREATETIME = "ISMY_CREATETIME";
        /// <summary>
        /// 是否分析过疑似负责人，0未分析，1分析过 返回 "ANALYSIS", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ANALYSIS = "ANALYSIS";
        /// <summary>
        /// 请求参数 返回 "QUERYSTRING", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING = "QUERYSTRING";
        /// <summary>
        /// 请求Form参数 返回 "FORM", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM = "FORM";
        /// <summary>
        /// 本页面依赖的外部URL情况 返回 "DEPEND_PAGEURL", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_PAGEURL = "DEPEND_PAGEURL";
        /// <summary>
        /// 依赖本URL的外部URL情况 返回 "DEPEND_PAGEURL_OUT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _DEPEND_PAGEURL_OUT = "DEPEND_PAGEURL_OUT";
        /// <summary>
        /// GET参数手机号是否加密；0未加密，1已加密 返回 "QUERYSTRING_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _QUERYSTRING_PHONE_ENCRYPT = "QUERYSTRING_PHONE_ENCRYPT";
        /// <summary>
        /// POST参数手机号是否加密 ；0未加密，1已加密 返回 "FORM_PHONE_ENCRYPT", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FORM_PHONE_ENCRYPT = "FORM_PHONE_ENCRYPT";
        /// <summary>
        /// 最近报错时间 返回 "ERRORTIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ERRORTIME = "ERRORTIME";
        /// <summary>
        /// 最近报错信息 返回 "ERRORINFO", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _ERRORINFO = "ERRORINFO";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";

        #endregion
        #region 函数
        /// <summary>
        /// WEBSITE_PAGEURL的构造函数
        /// </summary>
        public WEBSITE_PAGEURL()
        {
            this.TableName = "WEBSITE_PAGEURL";
            this.PrimaryKey = new string[] { _PAGEURL };

            this.columns = new string[] { _PAGEURL, _WEBMANAGER_NAME, _WEBMANAGER_REALNAME, _WEBMANAGER_NAME_DEPEND, _WEBMANAGER_REALNAME_DEPEND, _WEBMANAGER_NAME_LIKE, _WEBMANAGER_REALNAME_LIKE, _ISMY_CREATETIME, _ANALYSIS, _QUERYSTRING, _FORM, _DEPEND_PAGEURL, _DEPEND_PAGEURL_OUT, _QUERYSTRING_PHONE_ENCRYPT, _FORM_PHONE_ENCRYPT, _ERRORTIME, _ERRORINFO, _CREATETIME };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表WEBSITE_PAGEURL的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, VARCHAR, NVARCHAR, VARCHAR, NVARCHAR, VARCHAR, NVARCHAR, VARCHAR, INT, NVARCHAR, NVARCHAR, NVARCHAR, NVARCHAR, INT, INT, DATETIME, NVARCHAR, DATETIME };
                this.Lengths = new int[] { 200, 1000, 2000, 1000, 2000, 1000, 2000, 1000, 4, -1, -1, -1, -1, 4, 4, 8, -1, 8 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", "0", " ", " ", " ", " ", "1", "1", " ", " ", "getdate" };
                this.Descriptions = new string[] { "网页URL", "负责人，用英文逗号隔开", "负责人姓名，用英文逗号隔开", "URL依赖人，用英文逗号隔开", "URL依赖人姓名，用英文逗号隔开", "疑似负责人，用英文逗号隔开", "疑似负责人姓名，用英文逗号隔开", "认领时间 ", "是否分析过疑似负责人，0未分析，1分析过", "请求参数", "请求Form参数", "本页面依赖的外部URL情况", "依赖本URL的外部URL情况", "GET参数手机号是否加密；0未加密，1已加密", "POST参数手机号是否加密 ；0未加密，1已加密", "最近报错时间", "最近报错信息", "创建时间" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="PAGEURL">网页URL</param>
                /// <returns>bool</returns>
                public bool Find(string P_PAGEURL)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_PAGEURL;
                    if(this.SelectTop1()!=null)
                        Value=true;
                    return Value;
                }
        */

        /*		
                /// <summary>
                /// 深度拷贝WEBSITE_PAGEURL（新开辟了内存空间）
                /// </summary>
                /// <returns></returns>
                public WEBSITE_PAGEURL Copy()
                {
                    WEBSITE_PAGEURL new_obj=new WEBSITE_PAGEURL();
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
                 				
                CREATE TABLE [dbo].[WEBSITE_PAGEURL](
                 [PAGEURL] [VARCHAR]  (200)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [WEBMANAGER_NAME] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_REALNAME] [NVARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_NAME_DEPEND] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_REALNAME_DEPEND] [NVARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_NAME_LIKE] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [WEBMANAGER_REALNAME_LIKE] [NVARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ISMY_CREATETIME] [VARCHAR]  (1000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [ANALYSIS] [INT]  NULL  CONSTRAINT [DF_WEBSITE_PAGEURL_ANALYSIS] DEFAULT ('0') ,
                 [QUERYSTRING] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [FORM] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DEPEND_PAGEURL] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [DEPEND_PAGEURL_OUT] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [QUERYSTRING_PHONE_ENCRYPT] [INT]  NULL  CONSTRAINT [DF_WEBSITE_PAGEURL_QUERYSTRING_PHONE_ENCRYPT] DEFAULT ('1') ,
                 [FORM_PHONE_ENCRYPT] [INT]  NULL  CONSTRAINT [DF_WEBSITE_PAGEURL_FORM_PHONE_ENCRYPT] DEFAULT ('1') ,
                 [ERRORTIME] [DATETIME]  NULL ,
                 [ERRORINFO] [NVARCHAR]  (0)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [CREATETIME] [DATETIME]  NULL  CONSTRAINT [DF_WEBSITE_PAGEURL_CREATETIME] DEFAULT ('getdate') ,
                
                CONSTRAINT [PK_WEBSITE_PAGEURL] PRIMARY KEY CLUSTERED 
                (
	             [PAGEURL] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网页URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'PAGEURL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'负责人，用英文逗号隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'负责人姓名，用英文逗号隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REALNAME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL依赖人，用英文逗号隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME_DEPEND'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL依赖人姓名，用英文逗号隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REALNAME_DEPEND'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似负责人，用英文逗号隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_NAME_LIKE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疑似负责人姓名，用英文逗号隔开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'WEBMANAGER_REALNAME_LIKE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'认领时间 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'ISMY_CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否分析过疑似负责人，0未分析，1分析过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'ANALYSIS'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'QUERYSTRING'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求Form参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'FORM'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本页面依赖的外部URL情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'DEPEND_PAGEURL'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'依赖本URL的外部URL情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'DEPEND_PAGEURL_OUT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GET参数手机号是否加密；0未加密，1已加密' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'QUERYSTRING_PHONE_ENCRYPT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'POST参数手机号是否加密 ；0未加密，1已加密' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'FORM_PHONE_ENCRYPT'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近报错时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'ERRORTIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近报错信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'ERRORINFO'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WEBSITE_PAGEURL', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}