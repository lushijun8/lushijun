using System;

namespace Entity.TUAN_TEST
{
    /// <summary>
    /// 本类中的(系统生成代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="TUAN_TEST" 
    /// Table="TUANTASKAUTORUN_LOG"
    /// Columns="FILEPATH,TASKID,FILESIZE,LASTWRITETIME,NEEDDELETE,CREATETIME,REMARK"
    /// PrimaryKeys="FILEPATH"
    /// </summary>
    public sealed class TUANTASKAUTORUN_LOG : Entity.TUAN_TEST.EntityBase
    {
        #region 系统生成代码，请不要动 生成日期:2018/1/17 15:52:55
        #region 属性
        /// <summary>
        /// 日志文件路径  VARCHAR(500)  NOT NULL
        ///	唯一主键
        /// </summary>
        public string FILEPATH
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
        /// TuanTaskAutoRun表的ID  NVARCHAR(200)  NULL
        /// </summary>
        public string TASKID
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
        /// 日志文件大小(字节)  BIGINT(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 FILESIZE_ToString 更加准确
        /// </summary>
        public long FILESIZE
        {
            set
            {
                ColumnValues[2] = value.ToString(); UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        /// 日志文件大小(字节)  BIGINT(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 FILESIZE
        /// </summary>
        public string FILESIZE_ToString
        {
            get
            {
                return ColumnValues[2];
            }
        }
        /// <summary>
        /// 最后写入时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 LASTWRITETIME_ToString 更加准确
        /// </summary>
        public DateTime LASTWRITETIME
        {
            set
            {
                ColumnValues[3] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        /// 最后写入时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 LASTWRITETIME
        /// </summary>
        public string LASTWRITETIME_ToString
        {
            get
            {
                return ColumnValues[3];
            }
        }
        /// <summary>
        /// 是否需要删除物理文件  INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 NEEDDELETE_ToString 更加准确
        /// </summary>
        public int NEEDDELETE
        {
            set
            {
                ColumnValues[4] = value.ToString(); UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        /// 是否需要删除物理文件  INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 NEEDDELETE
        /// </summary>
        public string NEEDDELETE_ToString
        {
            get
            {
                return ColumnValues[4];
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CREATETIME_ToString 更加准确
        /// </summary>
        public DateTime CREATETIME
        {
            set
            {
                ColumnValues[5] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[5] = 1;
            }
        }
        /// <summary>
        /// 创建时间  DATETIME(8)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CREATETIME
        /// </summary>
        public string CREATETIME_ToString
        {
            get
            {
                return ColumnValues[5];
            }
        }
        /// <summary>
        /// 备注  NVARCHAR(4000)  NULL
        /// </summary>
        public string REMARK
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

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        /// 日志文件路径 返回 "FILEPATH", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FILEPATH = "FILEPATH";
        /// <summary>
        /// TuanTaskAutoRun表的ID 返回 "TASKID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _TASKID = "TASKID";
        /// <summary>
        /// 日志文件大小(字节) 返回 "FILESIZE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _FILESIZE = "FILESIZE";
        /// <summary>
        /// 最后写入时间 返回 "LASTWRITETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _LASTWRITETIME = "LASTWRITETIME";
        /// <summary>
        /// 是否需要删除物理文件 返回 "NEEDDELETE", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NEEDDELETE = "NEEDDELETE";
        /// <summary>
        /// 创建时间 返回 "CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CREATETIME = "CREATETIME";
        /// <summary>
        /// 备注 返回 "REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
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
            this.PrimaryKey = new string[] { _FILEPATH };

            this.columns = new string[] { _FILEPATH, _TASKID, _FILESIZE, _LASTWRITETIME, _NEEDDELETE, _CREATETIME, _REMARK };
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
                this.IsPrimaryKeys = new int[] { 1, 0, 0, 0, 0, 0, 0 };
                this.DataTypes = new string[] { VARCHAR, NVARCHAR, BIGINT, DATETIME, INT, DATETIME, NVARCHAR };
                this.Lengths = new int[] { 500, 200, 8, 8, 4, 8, 4000 };
                this.IsNullables = new int[] { 0, 1, 1, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { " ", " ", " ", " ", " ", " ", " " };
                this.Descriptions = new string[] { "日志文件路径", "TuanTaskAutoRun表的ID", "日志文件大小(字节)", "最后写入时间", "是否需要删除物理文件", "创建时间", "备注" };
            }
        }

        /*
                /// <summary>
                /// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
                /// </summary>
                /// <param name="FILEPATH">日志文件路径</param>
                /// <returns>bool</returns>
                public bool Find(string P_FILEPATH)
                {
                    bool Value=false;
                    this.ColumnValues[0]=P_FILEPATH;
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
                 [FILEPATH] [VARCHAR]  (500)  COLLATE Chinese_PRC_CI_AS  NOT NULL ,
                 [TASKID] [NVARCHAR]  (100)  COLLATE Chinese_PRC_CI_AS  NULL ,
                 [FILESIZE] [BIGINT]  NULL ,
                 [LASTWRITETIME] [DATETIME]  NULL ,
                 [NEEDDELETE] [INT]  NULL ,
                 [CREATETIME] [DATETIME]  NULL ,
                 [REMARK] [NVARCHAR]  (2000)  COLLATE Chinese_PRC_CI_AS  NULL ,
                
                CONSTRAINT [PK_TUANTASKAUTORUN_LOG] PRIMARY KEY CLUSTERED 
                (
	             [FILEPATH] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]

                ) ON [PRIMARY]
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志文件路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN_LOG', @level2type=N'COLUMN',@level2name=N'FILEPATH'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TuanTaskAutoRun表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN_LOG', @level2type=N'COLUMN',@level2name=N'TASKID'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志文件大小(字节)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN_LOG', @level2type=N'COLUMN',@level2name=N'FILESIZE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后写入时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN_LOG', @level2type=N'COLUMN',@level2name=N'LASTWRITETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否需要删除物理文件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN_LOG', @level2type=N'COLUMN',@level2name=N'NEEDDELETE'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN_LOG', @level2type=N'COLUMN',@level2name=N'CREATETIME'
                GO

                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TUANTASKAUTORUN_LOG', @level2type=N'COLUMN',@level2name=N'REMARK'
                GO


                */
        #endregion

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}