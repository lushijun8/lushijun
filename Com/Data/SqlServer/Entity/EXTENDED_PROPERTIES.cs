using System;
using System.Data;
using Com.Data;

namespace Com.Data.SqlServer.Entity
{
    /// <summary>
    ///   本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
    /// DataBase="HOMEDEPOT" 
    /// Table="EXTENDED_PROPERTIES"
    /// Columns="MAJOR_ID,MINOR_ID,CLASS,CLASS_DESC,NAME,VALUE"
    /// PrimaryKeys="MAJOR_ID,MINOR_ID"
    /// </summary>
    public sealed class EXTENDED_PROPERTIES : Com.Common.Entity
    {
        #region 系统代码，请不要动   生成日期:2010-8-23 11:15:12
  
        #region 属性
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MAJOR_ID_ToString 更加准确
        ///	主健之一，其他主健还有：MAJOR_ID,MINOR_ID
        /// </summary>
        public int MAJOR_ID
        {
            set
            {
                this.ColumnValues[0] = value.ToString();
                this.UpdateStatus[0] = 1;
            }
        }
        /// <summary>
        ///   INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MAJOR_ID
        ///	主健之一，其他主健还有：MAJOR_ID,MINOR_ID
        /// </summary>
        public string MAJOR_ID_ToString
        {
            get
            {
                return this.ColumnValues[0];
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 MINOR_ID_ToString 更加准确
        ///	主健之一，其他主健还有：MAJOR_ID,MINOR_ID
        /// </summary>
        public int MINOR_ID
        {
            set
            {
                this.ColumnValues[1] = value.ToString();
                this.UpdateStatus[1] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NOT NULL
        ///	只读属性，如果非要写入该字段，请使用 MINOR_ID
        ///	主健之一，其他主健还有：MAJOR_ID,MINOR_ID
        /// </summary>
        public string MINOR_ID_ToString
        {
            get
            {
                return this.ColumnValues[1];
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只写属性，如果非要读取该字段的字符串,建议使用 CLASS_ToString 更加准确
        /// </summary>
        public int CLASS
        {
            set
            {
                this.ColumnValues[2] = value.ToString();
                this.UpdateStatus[2] = 1;
            }
        }
        /// <summary>
        ///    INT(4)  NULL
        ///	只读属性，如果非要写入该字段，请使用 CLASS
        /// </summary>
        public string CLASS_ToString
        {
            get
            {
                return this.ColumnValues[2];
            }
        }
        /// <summary>
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string CLASS_DESC
        {
            get
            {
                return this.ColumnValues[3];
            }
            set
            {
                this.ColumnValues[3] = value;
                this.UpdateStatus[3] = 1;
            }
        }
        /// <summary>
        ///    VARCHAR(50)  NULL
        /// </summary>
        public string NAME
        {
            get
            {
                return this.ColumnValues[4];
            }
            set
            {
                this.ColumnValues[4] = value;
                this.UpdateStatus[4] = 1;
            }
        }
        /// <summary>
        ///   NVARCHAR(200)  NULL
        /// </summary>
        public string VALUE
        {
            get
            {
                return this.ColumnValues[5];
            }
            set
            {
                this.ColumnValues[5] = value;
                this.UpdateStatus[5] = 1;
            }
        }

        #endregion
        #region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
        /// <summary>
        ///  返回 "MAJOR_ID"
        /// 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MAJOR_ID = "MAJOR_ID";
        /// <summary>
        ///   返回 "MINOR_ID"
        /// 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _MINOR_ID = "MINOR_ID";
        /// <summary>
        ///   返回 "CLASS"
        /// 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CLASS = "CLASS";
        /// <summary>
        ///   返回 "CLASS_DESC"
        /// 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _CLASS_DESC = "CLASS_DESC";
        /// <summary>
        ///   返回 "NAME"
        /// 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _NAME = "NAME";
        /// <summary>
        ///  返回 "VALUE"
        /// 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
        /// </summary>
        public readonly string _VALUE = "VALUE";

        #endregion
        #region 函数
        /// <summary>
        /// PAY的构造函数
        /// </summary>
        public EXTENDED_PROPERTIES()
        {
            this.TableName = "EXTENDED_PROPERTIES";
            this.PrimaryKey = new string[] { this._MAJOR_ID, this._MINOR_ID };

            this.columns = new string[] { _MAJOR_ID, _MINOR_ID, _CLASS, _CLASS_DESC, _NAME, _VALUE };
            this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length]; for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
        }
        /// <summary>
        /// 初始化表PAY的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1, 1, 0, 0, 0, 0 };
                this.DataTypes = new string[] { INT, INT, INT, VARCHAR, VARCHAR, NVARCHAR };
                this.Lengths = new int[] { 4, 4, 4, 50, 50, 200 };
                this.IsNullables = new int[] { 0, 0, 1, 1, 1, 1 };
                this.DefaultValues = new string[] { "", "", "", "", "", "" };
                this.Descriptions = new string[] { "", "", "", "", "", "" };
            }
        }
        #endregion
        #region 实现关联Join方法和属性


        #endregion
        #endregion 系统代码，请不要动

        #region 在此处添加用户自己的业务逻辑代码
        //在此处添加用户自己的业务逻辑代码
        #endregion
    }
}