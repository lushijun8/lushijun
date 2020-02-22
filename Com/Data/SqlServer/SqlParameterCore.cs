using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Com.Data.SqlServer
{
    /// <summary>
    /// DBParamOperator 的摘要说明。
    /// </summary>
    public sealed class SqlParameterCore
    {
        public SqlParameterCore()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static SqlDbType SqlDbTypeOf(string SqlType)
        {
            SqlDbType Value;
            switch (SqlType.ToUpper())
            {
                case "BIGINT": Value = SqlDbType.BigInt; break;
                case "BINARY": Value = SqlDbType.Binary; break;
                case "BIT": Value = SqlDbType.Bit; break;
                case "CHAR": Value = SqlDbType.Char; break;
                case "DATETIME": Value = SqlDbType.DateTime; break;
                case "DECIMAL": Value = SqlDbType.Decimal; break;
                case "FLOAT": Value = SqlDbType.Float; break;
                case "IMAGE": Value = SqlDbType.Image; break;
                case "INT": Value = SqlDbType.Int; break;
                case "MONEY": Value = SqlDbType.Money; break;
                case "NCHAR": Value = SqlDbType.NChar; break;
                case "NTEXT": Value = SqlDbType.NText; break;
                case "NUMERIC": Value = SqlDbType.Decimal; break;
                case "NVARCHAR": Value = SqlDbType.NVarChar; break;
                case "REAL": Value = SqlDbType.Real; break;
                case "SMALLDATETIME": Value = SqlDbType.SmallDateTime; break;
                case "SMALLINT": Value = SqlDbType.SmallInt; break;
                case "SMALLMONEY": Value = SqlDbType.SmallMoney; break;
                case "SQL_VARIANT": Value = SqlDbType.Variant; break;
                case "SYSNAME": Value = SqlDbType.Text; break;
                case "TEXT": Value = SqlDbType.Text; break;
                case "TIMESTAMP": Value = SqlDbType.Timestamp; break;
                case "TINYINT": Value = SqlDbType.TinyInt; break;
                case "UNIQUEIDENTIFIER": Value = SqlDbType.UniqueIdentifier; break;
                case "VARBINARY": Value = SqlDbType.VarBinary; break;
                case "VARCHAR": Value = SqlDbType.VarChar; break;
                default: Value = SqlDbType.VarChar; break;
            }
            return Value;
        }

        #region update
        /// <summary>
        /// 获得更新的条件语句,根据主键更新,如果没有主键则不进行更新
        /// </summary>
        /// <returns></returns>
        private static string GetUpdateWhereSql(Com.Common.Entity Obj, ArrayList Params)
        {
            StringBuilder Value = new StringBuilder();
            for (int i = 0; i < Obj.PrimaryKey.Length; i++)
            {
                if (Obj.PrimaryKey[i].Trim() != "")
                {
                    foreach (DataRow oDr in Obj.ValuesList.Rows)
                    {
                        if (Obj.PrimaryKey[i].Trim() == oDr["ColumnName"].ToString())
                        {
                            Value.Append(" AND " + Obj.PrimaryKey[i] + "=@" + Obj.PrimaryKey[i] + " ");
                            Params.Add(Obj.PrimaryKey[i]);
                        }
                    }
                }
            }
            if (Obj.UpdateWhereSql.Trim() != "")
            {
                Value.Append(" AND " + Obj.UpdateWhereSql + " ");
            }
            return Value.ToString();
        }

        private static string GetUpdateColumns(Com.Common.Entity Obj, ArrayList Params)
        {
            StringBuilder Value = new StringBuilder();
            if (Obj.UpdateColumns != null && Obj.UpdateColumns.Length > 0)
            {
                foreach (DataRow oDr in Obj.ValuesList.Rows)
                {
                    int flag = 0;
                    string ColumnName = oDr["ColumnName"].ToString().ToUpper();
                    for (int k = 0; k < Obj.PrimaryKey.Length; k++)
                    {
                        if (Obj.PrimaryKey[k].ToUpper() == ColumnName)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        for (int j = 0; j < Obj.UpdateColumns.Length; j++)
                        {
                            if (Obj.UpdateColumns[j].ToUpper() == ColumnName)
                            {
                                Value.Append(ColumnName + "=@" + ColumnName + ",");
                                Params.Add(ColumnName);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow oDr in Obj.ValuesList.Rows)
                {
                    if (oDr["Updated"].ToString() == "1")
                    {
                        int flag = 0;
                        string ColumnName = oDr["ColumnName"].ToString().ToUpper();
                        for (int k = 0; k < Obj.PrimaryKey.Length; k++)
                        {
                            if (Obj.PrimaryKey[k].ToUpper() == ColumnName)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {

                            Value.Append(ColumnName + "=@" + ColumnName + ",");
                            Params.Add(ColumnName);
                        }
                    }
                }
            }
            if (Value.ToString().TrimEnd(',') == "")//如果更新内容为空，为了兼容老版本
            {
                foreach (DataRow oDr in Obj.ValuesList.Rows)
                {
                    if (oDr["ColumnValue"].ToString() != "")
                    {
                        int flag = 0;
                        string ColumnName = oDr["ColumnName"].ToString().ToUpper();
                        for (int k = 0; k < Obj.PrimaryKey.Length; k++)
                        {
                            if (Obj.PrimaryKey[k].ToUpper() == ColumnName)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            Value.Append(ColumnName + "=@" + ColumnName + ",");
                            Params.Add(ColumnName);
                        }
                    }
                }
            }

            return Value.ToString().TrimEnd(',');
        }

        private static SqlParameter[] GetSqlParameter(Com.Common.Entity Obj, ArrayList Params)
        {
            //用户自己添加的SqlParameters参数
            int AddInParameterCount = 0;
            if (Obj.SqlParameters != null && Obj.SqlParameters.Length > 0)
            {
                AddInParameterCount = Obj.SqlParameters.Length;
            }
            SqlParameter[] Value = new SqlParameter[Params.Count + AddInParameterCount];

            int i = 0;
            foreach (string param in Params)
            {
                foreach (DataRow oDr in Obj.ValuesList.Rows)
                {
                    string ColumnName = oDr["ColumnName"].ToString().ToUpper();
                    if (ColumnName == param.ToUpper())
                    {
                        SqlDbType SqlDbType = SqlDbTypeOf(oDr["DataType"].ToString().ToUpper());
                        Value[i] = new SqlParameter("@" + ColumnName, oDr["ColumnValue"].ToString());                     
                        Value[i].SqlDbType = SqlDbType;
                        i++;
                        break;
                    }
                }
            }
            if (AddInParameterCount > 0)//用户自己添加的SqlParameters参数
            {
                foreach (SqlParameter sqlparameter in Obj.SqlParameters)
                {
                    Value[i] = sqlparameter;
                    i++;
                }
            }

            return Value;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateObj(Com.Common.Entity Obj)
        {
            bool Value = false;
            ArrayList Params = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            string UpdateColumns = SqlParameterCore.GetUpdateColumns(Obj, Params);
            if (UpdateColumns.Trim() == "")//如果没有更新任何列则不让更新
            {
                return false;
            }
            strSql.Append(" UPDATE [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "] SET ");
            strSql.Append(" " + UpdateColumns + " ");
            strSql.Append(" WHERE 1=1 ");
            string UpdateWhereSql = SqlParameterCore.GetUpdateWhereSql(Obj, Params);
            strSql.Append(UpdateWhereSql);
            if (UpdateWhereSql.Trim() == "")//如果没有设置任何主键和条件则不让更新
            {
                return false;
            }

            SqlParameter[] parameters = SqlParameterCore.GetSqlParameter(Obj, Params);
            DBCommandWrapper cw = Obj.Database_Writer.GetSqlStringCommandWrapper(strSql.ToString());
            foreach (SqlParameter param in parameters)
            {
                object ParamValue = param.Value;
                if (param.DbType == DbType.String)
                {
                    cw.AddParameter(param.ParameterName, param.DbType, param.Size, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, ParamValue);
                }
                else if (param.DbType == DbType.Boolean)
                {
                    bool boolValue = ParamValue.ToString() == "0" ? false : true;
                    cw.AddInParameter(param.ParameterName, param.DbType, boolValue);
                }
                else if (param.DbType == DbType.AnsiString)
                {
                    cw.AddInParameter(param.ParameterName, DbType.String, ParamValue);
                }
                else
                {
                    cw.AddInParameter(param.ParameterName, param.DbType, ParamValue);
                }
            }
            try
            {
                Obj.Database_Writer.ExecuteNonQuery(cw);
                Value = true;
            }
            catch (Exception ex)
            {
                File.FileLog.WriteLog("Com.Data.SqlServer.SqlParameterCore.UpdateObj(Com.Common.Entity Obj)", ex.ToString() + ";Sql:" + strSql.ToString());
            }
            return Value;
        }
        #endregion

        #region insert
        /// <summary>
        /// 插入一条数据
        /// </summary>
        public static bool InsertObjIdentity(Com.Common.Entity Obj, out string Identity)
        {
            bool bInsert = false;
            Identity = "";
            ArrayList Params = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "]");
            strSql.Append("(" + SqlCore.GetInsertColumns(Obj) + ")");
            strSql.Append(" VALUES(" + SqlParameterCore.GetInsertValues(Obj, Params) + ") SELECT TOP 1 @@identity FROM [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "] ");
            SqlParameter[] parameters = SqlParameterCore.GetSqlParameter(Obj, Params);
            DataTable dtValue = new DataTable();

            DBCommandWrapper cw = Obj.Database_Writer.GetSqlStringCommandWrapper(strSql.ToString());
            foreach (SqlParameter param in parameters)
            {
                object ParamValue = param.Value;
                if (param.DbType == DbType.String)
                {
                    cw.AddParameter(param.ParameterName, param.DbType, param.Size, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, ParamValue);
                }
                else if (param.DbType == DbType.Boolean)
                {
                    bool boolValue = ParamValue.ToString() == "0" ? false : true;
                    cw.AddInParameter(param.ParameterName, param.DbType, boolValue);
                }
                else if (param.DbType == DbType.AnsiString)
                {
                    cw.AddInParameter(param.ParameterName, DbType.String, ParamValue);
                }
                else
                {
                    cw.AddInParameter(param.ParameterName, param.DbType, ParamValue);
                }
            }
            dtValue = Obj.Database_Writer.ExecuteDataSet(cw).Tables[0];
            if (dtValue.Rows.Count > 0 && dtValue.Rows[0][0].ToString() != "NULL" && dtValue.Rows[0][0].ToString().Trim() != "")
            {
                Identity = dtValue.Rows[0][0].ToString();
                bInsert = true;
            }
            return bInsert;
        }
        public static bool InsertObj(Com.Common.Entity Obj)
        {
            bool Value = false;
            ArrayList Params = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "]");
            strSql.Append("(" + SqlCore.GetInsertColumns(Obj) + ")");
            strSql.Append(" VALUES(" + SqlParameterCore.GetInsertValues(Obj, Params) + ") ");
            SqlParameter[] parameters = SqlParameterCore.GetSqlParameter(Obj, Params);

            DBCommandWrapper cw = Obj.Database_Writer.GetSqlStringCommandWrapper(strSql.ToString());
            foreach (SqlParameter param in parameters)
            {
                object ParamValue = param.Value;
                if (param.DbType == DbType.String)
                {
                    cw.AddParameter(param.ParameterName, param.DbType, param.Size, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, ParamValue);
                }
                else if (param.DbType == DbType.Boolean)
                {
                    bool boolValue = ParamValue.ToString() == "0" ? false : true;
                    cw.AddInParameter(param.ParameterName, param.DbType, boolValue);
                }
                else if (param.DbType == DbType.AnsiString)
                {
                    cw.AddInParameter(param.ParameterName, DbType.String, ParamValue);
                }
                else
                {
                    cw.AddInParameter(param.ParameterName, param.DbType, ParamValue);
                }
            }
            try
            {
                Obj.Database_Writer.ExecuteNonQuery(cw);
                Value = true;
            }
            catch (Exception ex)
            {
                File.FileLog.WriteLog("Com.Data.SqlServer.SqlParameterCore.InsertObj(Com.Common.Entity Obj)", ex.ToString() + ";Sql:" + strSql.ToString());
            }
            return Value;
        }
        private static string GetInsertValues(Com.Common.Entity Obj, ArrayList Params)
        {
            StringBuilder Value = new StringBuilder();
            foreach (DataRow oDr in Obj.ValuesList.Rows)
            {
                string ColumnValue = oDr["ColumnValue"].ToString();
                string ColumnName = oDr["ColumnName"].ToString();
                if (ColumnValue != "")
                {
                    Value.Append("@" + ColumnName + ",");
                    Params.Add(ColumnName);
                }
                else
                {
                    #region 如果插入的值没有赋值则使用默认值
                    if (oDr["Default"].ToString().Trim() != "")
                    {
                        string DefaultValue = oDr["Default"].ToString().ToUpper();
                        string DataType = oDr["DataType"].ToString().ToUpper();
                        string text1 = "'";
                        if (DataType == "DATETIME" || DataType == "SMALLDATETIME")
                        {
                            if (DefaultValue == "GETDATE()" || DefaultValue == "GETDATE")
                            {
                                DefaultValue = "GETDATE()";
                                text1 = "";
                            }
                            else if (Com.Common.StringUtil.IsNumber(DefaultValue) == true)
                            {
                                DefaultValue = new System.DateTime(1900, 1, 1).AddDays(int.Parse(DefaultValue)).ToString();
                            }
                        }
                        else if (DataType == "INT" || DataType == "BIT" || DataType == "DECIMAL" || DataType == "FLOAT"
                            || DataType == "MONEY" || DataType == "NUMERIC" || DataType == "REAL" || DataType == "SMALLINT"
                            || DataType == "SMALLMONEY" || DataType == "TINYINT")
                        {
                            text1 = "";
                        }
                        Value.Append(text1 + DefaultValue + text1 + ",");
                    }
                    #endregion
                }
            }
            return Value.ToString().TrimEnd(',');
        }
        #endregion

        #region delete
        /// <summary>
        /// 删除数据
        /// </summary>
        public static bool DeleteObj(Com.Common.Entity Obj)
        {
            bool Value = false;
            ArrayList Params = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" DELETE FROM [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "]  WHERE 1=1 ");

            string DeleteWhereSql = SqlParameterCore.GetDeleteWhereSql(Obj, Params);
            if (DeleteWhereSql.Trim() != "")
            {
                strSql.Append(" " + DeleteWhereSql + " ");
            }
            if (Obj.WhereSql.Trim() != "")
            {
                strSql.Append(" AND " + Obj.WhereSql);
            }
            if (DeleteWhereSql.Trim() == "" && Obj.WhereSql.Trim() == "")//如果没有设置任何主键和条件则不让删除
            {
                return false;
            }

            SqlParameter[] parameters = SqlParameterCore.GetSqlParameter(Obj, Params);
            DBCommandWrapper cw = Obj.Database_Writer.GetSqlStringCommandWrapper(strSql.ToString());
            foreach (SqlParameter param in parameters)
            {
                object ParamValue = param.Value;
                if (param.DbType == DbType.String)
                {
                    cw.AddParameter(param.ParameterName, param.DbType, param.Size, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, ParamValue);
                }
                else if (param.DbType == DbType.Boolean)
                {
                    bool boolValue = ParamValue.ToString() == "0" ? false : true;
                    cw.AddInParameter(param.ParameterName, param.DbType, boolValue);
                }
                else if (param.DbType == DbType.AnsiString)
                {
                    cw.AddInParameter(param.ParameterName, DbType.String, ParamValue);
                }
                else
                {
                    cw.AddInParameter(param.ParameterName, param.DbType, ParamValue);
                }
            }
            try
            {
                Obj.Database_Writer.ExecuteNonQuery(cw);
                Value = true;
            }
            catch (Exception ex)
            {
                File.FileLog.WriteLog("Com.Data.SqlServer.SqlParameterCore.DeleteObj(Com.Common.Entity Obj)", ex.ToString() + ";Sql:" + strSql.ToString());
            }
            return Value;
        }
        /// <summary>
        /// 获得删除实体的条件语句
        /// </summary>
        /// <returns></returns>
        private static string GetDeleteWhereSql(Com.Common.Entity Obj, ArrayList Params)
        {
            StringBuilder Value = new StringBuilder();
            for (int i = 0; i < Obj.PrimaryKey.Length; i++)
            {
                if (Obj.PrimaryKey[i].Trim() != "")
                {
                    foreach (DataRow oDr in Obj.ValuesList.Rows)
                    {
                        if (Obj.PrimaryKey[i].Trim() == oDr["ColumnName"].ToString())
                        {
                            Value.Append(" AND " + Obj.PrimaryKey[i] + "=@" + Obj.PrimaryKey[i] + " ");
                            Params.Add(Obj.PrimaryKey[i]);
                        }
                    }
                }
            }
            if (Obj.DeleteWhereSql.Trim() != "")
            {
                Value.Append(" AND " + Obj.DeleteWhereSql + " ");
            }
            return Value.ToString();

        }
        #endregion

        #region select
        public static DataTable SelectObj(Com.Common.Entity Obj, int Top)
        {
            ArrayList Params = new ArrayList();

            string strTop = "";
            string OrderColumn = "";
            string Sql = "";
            string DISTINCT = (Obj.Distinct == true ? "DISTINCT" : "");
            if (Obj.Distinct == true)
            {

                //如果查询的字段中含有Text/nText/Image类型字段，则强行将DISTINCT设置为false
                for (int i = 0; i < Obj.SelectColumns.Length; i++)
                {
                    if (Obj.SelectColumns[i] != null && Obj.SelectColumns[i].Trim() != "")
                    {
                        string SelectColumn = Obj.SelectColumns[i];
                        DataRow[] oDr = Obj.ValuesList.Select("ColumnName='" + SelectColumn.Replace("'", "''") + "'");
                        if (oDr.Length > 0 && (oDr[0]["DataType"].ToString() == "TEXT" || oDr[0]["DataType"].ToString() == "NTEXT" || oDr[0]["DataType"].ToString() == "IMAGE"))
                        {
                            DISTINCT = "";
                            break;
                        }

                    }
                }
                if (DISTINCT == "DISTINCT" && Obj.OrderBy != "")
                {
                    string Order = Obj.OrderBy.TrimEnd().TrimStart().Split(' ')[0].ToUpper();
                    int flag = 0;
                    for (int i = 0; i < Obj.SelectColumns.Length; i++)
                    {
                        if (Obj.SelectColumns[i] != null && Obj.SelectColumns[i].Trim() != "")
                        {
                            string[] SplitColumns = Obj.SelectColumns[i].TrimEnd().TrimStart().Split(' ');
                            for (int k = 0; k < SplitColumns.Length; k++)
                            {
                                if (SplitColumns[k].ToUpper() == Order)
                                {
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 1)
                            {
                                break;
                            }
                        }
                    }
                    if (flag == 0)
                    {
                        OrderColumn = "," + Order;
                    }
                }
            }
            if (Top != 0)
                strTop = "TOP " + Top.ToString();
            Sql = @" SELECT " + DISTINCT + " " + strTop + " " + SqlCore.GetSelectColumns(Obj) + OrderColumn + " FROM [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "] [" + Obj.TableName + "]  WITH(NOLOCK) " + Obj.JoinSql + " " + SqlCore.GetJoinSql(Obj) + " WHERE 1=1 " + SqlParameterCore.GetWhereSql(Obj, Params);
            if (Obj.GroupBy != "")
                Sql += " GROUP BY " + Obj.GroupBy + " ";
            if (Obj.OrderBy != "")
                Sql += " ORDER BY " + Obj.OrderBy + " ";

            SqlParameter[] parameters = SqlParameterCore.GetSqlParameter(Obj, Params);

            DataTable dtValue = new DataTable();

            DBCommandWrapper cw = Obj.Database_Reader.GetSqlStringCommandWrapper(Sql.ToString());
            foreach (SqlParameter param in parameters)
            {
                object ParamValue = param.Value;
                if (param.DbType == DbType.String)
                {
                    cw.AddParameter(param.ParameterName, param.DbType, param.Size, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, ParamValue);
                }
                else if (param.DbType == DbType.Boolean)
                {
                    bool boolValue = ParamValue.ToString() == "0" ? false : true;
                    cw.AddInParameter(param.ParameterName, param.DbType, boolValue);
                }
                else if (param.DbType == DbType.AnsiString)
                {
                    cw.AddInParameter(param.ParameterName, DbType.String, ParamValue);
                }
                else
                {
                    cw.AddInParameter(param.ParameterName, param.DbType, ParamValue);
                }
            }
            //try
            //{
            dtValue = Obj.Database_Reader.ExecuteDataSet(cw).Tables[0];
            //}
            //catch
            //{
            //    Com.File.FileLog.WriteLog("DBParamOperator", "ConnectionString:" + Obj.Database_Reader.GetConnection().ConnectionString + ";;;;Sql:" + cw.Command.CommandText);
            //}
            if (dtValue != null && dtValue.Rows.Count > 0)
            {
                Obj.RowCount = dtValue.Rows.Count;
            }


            return dtValue;
        }
        private static string GetWhereSql(Com.Common.Entity Obj, ArrayList Params)
        {
            if (Obj.Split_Or_And == true)
            {
                return SqlParameterCore.GetWhereSqlForSplit_Or_And(Obj, Params);
            }
            bool bJoinSelf = SqlCore.IsSelfTableJoin(Obj);
            StringBuilder Value = new StringBuilder();
            foreach (DataRow oDr in Obj.ValuesList.Rows)
            {
                string columnname = oDr["ColumnName"].ToString();
                string OriColumnName = oDr["ColumnName"].ToString();
                if (bJoinSelf)
                {
                    columnname = "[" + Obj.TableName + "].[" + OriColumnName + "]";
                }
                if (oDr["ColumnValue"].ToString() != "")
                {
                    if (oDr["ColumnValue"].ToString().IndexOf("%") > -1 || oDr["ColumnValue"].ToString().IndexOf("_") > -1)
                    {
                        Value.Append(" AND " + columnname + " LIKE @" + OriColumnName + " ");
                    }
                    else
                    {
                        Value.Append(" AND " + columnname + "=@" + OriColumnName + " ");
                    }
                    Params.Add(OriColumnName);
                }
            }
            if (Obj.WhereSql.Trim() != "")
                Value.Append(" AND " + Obj.WhereSql);
            return Value.ToString();
        }

        private static string GetWhereSqlForSplit_Or_And(Com.Common.Entity Obj, ArrayList Params)
        {
            StringBuilder Value = new StringBuilder();
            bool bJoinSelf = SqlCore.IsSelfTableJoin(Obj);
            foreach (DataRow oDr in Obj.ValuesList.Rows)
            {
                string columnname = oDr["ColumnName"].ToString();
                string OriColumnName = oDr["ColumnName"].ToString();
                if (bJoinSelf)
                {
                    columnname = "[" + Obj.TableName + "].[" + OriColumnName + "]";
                }
                if (oDr["ColumnValue"].ToString() != "")
                {
                    char split = ' ';
                    if (oDr["ColumnValue"].ToString().IndexOf("|") > -1)
                    {
                        split = '|';
                    }
                    else if (oDr["ColumnValue"].ToString().IndexOf("&") > -1)
                    {
                        split = '&';
                    }
                    if (split != ' ')
                    {
                        string[] ColumnValues = oDr["ColumnValue"].ToString().Split(split);
                        Value.Append(" AND ( ");
                        for (int i = 0; i < ColumnValues.Length; i++)
                        {
                            if (ColumnValues[i].IndexOf("%") > -1 || ColumnValues[i].IndexOf("_") > -1)
                                Value.Append(" " + columnname + " LIKE '" + ColumnValues[i].Replace("'", "''") + "' ");
                            else
                                Value.Append(" " + columnname + "='" + ColumnValues[i].Replace("'", "''") + "' ");
                            if (i != ColumnValues.Length - 1)
                                Value.Append(" " + (split == '|' ? "OR" : "AND") + " ");
                        }
                        Value.Append(" ) ");
                    }
                    else
                    {
                        if (oDr["ColumnValue"].ToString().IndexOf("%") > -1 || oDr["ColumnValue"].ToString().IndexOf("_") > -1)
                        {
                            Value.Append(" AND " + columnname + " LIKE @" + OriColumnName + " ");
                        }
                        else
                        {
                            Value.Append(" AND " + columnname + "=@" + OriColumnName + " ");
                        }
                        Params.Add(OriColumnName);
                    }

                }
            }
            if (Obj.WhereSql.Trim() != "")
                Value.Append(" AND " + Obj.WhereSql);
            return Value.ToString();
        }

        /// <summary>
        /// 根据输入的条件,由存储过程获得分页数据(需要分页时的优化,跟AspNetPager控件联合使用)
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页码(从1开始)</param>
        /// <param name="bCount">是否获得总记录数</param>
        /// <param name="AllCount">总记录数</param>
        /// <returns>数据表</returns>
        public static DataTable SelectObjByPagingProcedure(int PageSize, int PageIndex, bool bCount, out int AllCount, Com.Common.Entity Obj)
        {
            DataTable Value = null;
            AllCount = 0;
            string OrderColumn = "";
            string DISTINCT = (Obj.Distinct == true ? "DISTINCT" : "");
            if (Obj.Distinct == true)
            {
                //如果查询的字段中含有Text/nText/Image类型字段，则强行将DISTINCT设置为false
                for (int i = 0; i < Obj.SelectColumns.Length; i++)
                {
                    if (Obj.SelectColumns[i] != null && Obj.SelectColumns[i].Trim() != "")
                    {
                        string SelectColumn = Obj.SelectColumns[i];
                        DataRow[] oDr = Obj.ValuesList.Select("ColumnName='" + SelectColumn.Replace("'", "''") + "'");
                        if (oDr.Length > 0 && (oDr[0]["DataType"].ToString() == "TEXT" || oDr[0]["DataType"].ToString() == "NTEXT" || oDr[0]["DataType"].ToString() == "IMAGE"))
                        {
                            DISTINCT = "";
                            break;
                        }

                    }
                }
                if (DISTINCT == "DISTINCT" && Obj.OrderBy != "")
                {
                    string Order = Obj.OrderBy.TrimEnd().TrimStart().Split(' ')[0].ToUpper();
                    int flag = 0;
                    for (int i = 0; i < Obj.SelectColumns.Length; i++)
                    {
                        if (Obj.SelectColumns[i] != null && Obj.SelectColumns[i].Trim() != "" && Obj.SelectColumns[i].TrimEnd().TrimStart().Split(' ')[0].ToUpper() == Order)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        OrderColumn = "," + Order + " AS [ORDERBYME]";
                    }
                }
            }
            string PrimaryKeys = "";
            if (Obj.PrimaryKey.Length == 1)
            {
                if (Obj.IdentityColumn.Trim() == "")
                {
                    PrimaryKeys = Obj.PrimaryKey[0].ToString();
                }
            }
            string OrderBy = Obj.OrderBy.ToUpper();
            if (Obj.IdentityColumn.Trim() != "" && OrderBy.Trim() != "" && OrderBy.ToUpper().IndexOf(Obj.IdentityColumn.ToUpper()) == 0)
            {
                OrderBy = OrderBy.Replace(Obj.IdentityColumn.ToUpper(), "CAST(" + Obj.IdentityColumn.ToUpper() + " AS INT)");
            }
            string sql = "EXECUTE SP_CommonPaging @pagesize,@pageindex,@selectColumn,@JoinSql,@table,@PrimaryKey,@condition,@Order,@docount,@bDistinct";
            DBCommandWrapper cw = Obj.Database_Reader.GetSqlStringCommandWrapper(sql);
            cw.AddInParameter("@pagesize", DbType.Int32, PageSize);
            cw.AddInParameter("@pageindex", DbType.Int32, PageIndex);
            cw.AddParameter("@selectColumn", DbType.String, 1000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, SqlCore.GetSelectColumns(Obj) + " " + OrderColumn);
            cw.AddParameter("@JoinSql", DbType.String, 1000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, Obj.JoinSql + " " + SqlCore.GetJoinSql(Obj));
            cw.AddParameter("@table", DbType.String, 1000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, Obj.DataBase + "." + Obj.TableOwner + ".[" + Obj.TableName + "] [" + Obj.TableName + "]");
            cw.AddParameter("@PrimaryKey", DbType.String, 1000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, PrimaryKeys);
            cw.AddParameter("@condition", DbType.String, 4000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, SqlCore.GetWhereSql(Obj));
            cw.AddParameter("@Order", DbType.String, 1000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, OrderBy);
            cw.AddInParameter("@docount", DbType.Boolean, bCount);
            cw.AddInParameter("@bDistinct", DbType.Boolean, (DISTINCT == "" ? false : true));

            DataSet dsResult = Obj.Database_Reader.ExecuteDataSet(cw);
            if (bCount == true)
            {
                AllCount = int.Parse(dsResult.Tables[0].Rows[0][0].ToString());
                Value = dsResult.Tables[1];
            }
            else
            {
                Value = dsResult.Tables[0];
            }

            return Value;
        }

        #endregion

        #region 获取计算列　MAX MIN　。。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="columnName"></param>
        /// <param name="defaultValue"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Eval(Com.Common.Entity Obj, string columnName, string defaultValue, string function)
        {
            ArrayList Params = new ArrayList();
            string OrderColumn = "";
            string Sql = "";
            string DISTINCT = (Obj.Distinct == true ? "DISTINCT" : "");
            if (Obj.Distinct == true)
            {

                //如果查询的字段中含有Text/nText/Image类型字段，则强行将DISTINCT设置为false
                for (int i = 0; i < Obj.SelectColumns.Length; i++)
                {
                    if (Obj.SelectColumns[i] != null && Obj.SelectColumns[i].Trim() != "")
                    {
                        string SelectColumn = Obj.SelectColumns[i];
                        DataRow[] oDr = Obj.ValuesList.Select("ColumnName='" + SelectColumn.Replace("'", "''") + "'");
                        if (oDr.Length > 0 && (oDr[0]["DataType"].ToString() == "TEXT" || oDr[0]["DataType"].ToString() == "NTEXT" || oDr[0]["DataType"].ToString() == "IMAGE"))
                        {
                            DISTINCT = "";
                            break;
                        }

                    }
                }
                if (DISTINCT == "DISTINCT" && Obj.OrderBy != "")
                {
                    string Order = Obj.OrderBy.TrimEnd().TrimStart().Split(' ')[0].ToUpper();
                    int flag = 0;
                    for (int i = 0; i < Obj.SelectColumns.Length; i++)
                    {
                        if (Obj.SelectColumns[i] != null && Obj.SelectColumns[i].Trim() != "")
                        {
                            string[] SplitColumns = Obj.SelectColumns[i].TrimEnd().TrimStart().Split(' ');
                            for (int k = 0; k < SplitColumns.Length; k++)
                            {
                                if (SplitColumns[k].ToUpper() == Order)
                                {
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 1)
                            {
                                break;
                            }
                        }
                    }
                    if (flag == 0)
                    {
                        OrderColumn = "," + Order;
                    }
                }
            }
            string column = " ISNULL(" + columnName + ",'" + defaultValue + "')";
            if (defaultValue.Trim() == "")
            {
                DataRow[] drs = Obj.ValuesList.Select("ColumnName='" + columnName + "'");

                if (drs.Length > 0)
                {
                    defaultValue = drs[0]["Default"].ToString();
                }
                else
                {
                    column = columnName;
                }
            }
            Sql = @" SELECT " + function + "(" + column + ") AS " + function + "VALUE FROM [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "] [" + Obj.TableName + "]  WITH(NOLOCK) WHERE 1=1 " + SqlParameterCore.GetWhereSql(Obj, Params);

            SqlParameter[] parameters = SqlParameterCore.GetSqlParameter(Obj, Params);

            string sValue = "";

            DBCommandWrapper cw = Obj.Database_Reader.GetSqlStringCommandWrapper(Sql.ToString());
            foreach (SqlParameter param in parameters)
            {
                object ParamValue = param.Value;
                if (param.DbType == DbType.String)
                {
                    cw.AddParameter(param.ParameterName, param.DbType, param.Size, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, ParamValue);
                }
                else if (param.DbType == DbType.Boolean)
                {
                    bool boolValue = ParamValue.ToString() == "0" ? false : true;
                    cw.AddInParameter(param.ParameterName, param.DbType, boolValue);
                }
                else if (param.DbType == DbType.AnsiString)
                {
                    cw.AddInParameter(param.ParameterName, DbType.String, ParamValue);
                }
                else
                {
                    cw.AddInParameter(param.ParameterName, param.DbType, ParamValue);
                }
            }
            sValue = Obj.Database_Reader.ExecuteScalar(cw).ToString();

            return sValue;
        }
        #endregion
    }
}
