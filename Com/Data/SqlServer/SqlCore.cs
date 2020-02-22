using System;
using System.Data;
using System.Text;
using System.Collections;

namespace Com.Data.SqlServer
{
    /// <summary>
    /// DBOperator 的摘要说明。
    /// </summary>
    internal sealed class SqlCore
    {
        public SqlCore()
        {
            #region 基本的数据库操作
            /*
			 * ----------------------------------------------
--------------- MS SQLServer -----------------
----------------------------------------------

--表说明
SELECT dbo.sysobjects.name AS TableName, 
      dbo.sysproperties.[value] AS TableDesc
FROM dbo.sysproperties INNER JOIN
      dbo.sysobjects ON dbo.sysproperties.id = dbo.sysobjects.id
WHERE (dbo.sysproperties.smallid = 0)
ORDER BY dbo.sysobjects.name

--字段说明
SELECT dbo.sysobjects.name AS TableName, dbo.syscolumns.colid, 
      dbo.syscolumns.name AS ColName, dbo.sysproperties.[value] AS ColDesc
FROM dbo.sysproperties INNER JOIN
      dbo.sysobjects ON dbo.sysproperties.id = dbo.sysobjects.id INNER JOIN
      dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id AND 
      dbo.sysproperties.smallid = dbo.syscolumns.colid
ORDER BY dbo.sysobjects.name, dbo.syscolumns.colid

 

--主键、外键信息(简化)
select
 c_obj.name    as CONSTRAINT_NAME
 ,t_obj.name    as TABLE_NAME
 ,col.name    as COLUMN_NAME
 ,case col.colid 
  when ref.fkey1 then 1   
  when ref.fkey2 then 2   
  when ref.fkey3 then 3   
  when ref.fkey4 then 4   
  when ref.fkey5 then 5   
  when ref.fkey6 then 6   
  when ref.fkey7 then 7   
  when ref.fkey8 then 8   
  when ref.fkey9 then 9   
  when ref.fkey10 then 10   
  when ref.fkey11 then 11   
  when ref.fkey12 then 12   
  when ref.fkey13 then 13   
  when ref.fkey14 then 14   
  when ref.fkey15 then 15   
  when ref.fkey16 then 16
 end      as ORDINAL_POSITION
from
 sysobjects c_obj
 ,sysobjects t_obj
 ,syscolumns col
 ,sysreferences  ref
where
 permissions(t_obj.id) != 0
 and c_obj.xtype in ('F ')
 and t_obj.id = c_obj.parent_obj
 and t_obj.id = col.id
 and col.colid   in 
 (ref.fkey1,ref.fkey2,ref.fkey3,ref.fkey4,ref.fkey5,ref.fkey6,
 ref.fkey7,ref.fkey8,ref.fkey9,ref.fkey10,ref.fkey11,ref.fkey12,
 ref.fkey13,ref.fkey14,ref.fkey15,ref.fkey16)
 and c_obj.id = ref.constid
union
 select
 i.name     as CONSTRAINT_NAME
 ,t_obj.name    as TABLE_NAME
 ,col.name    as COLUMN_NAME
 ,v.number    as ORDINAL_POSITION
from
 sysobjects  c_obj
 ,sysobjects  t_obj
 ,syscolumns  col
 ,master.dbo.spt_values  v
 ,sysindexes  i
where
 permissions(t_obj.id) != 0
 and c_obj.xtype in ('UQ' ,'PK')
 and t_obj.id = c_obj.parent_obj
 and t_obj.xtype  = 'U'
 and t_obj.id = col.id
 and col.name = index_col(t_obj.name,i.indid,v.number)
 and t_obj.id = i.id
 and c_obj.name  = i.name
 and v.number  > 0 
  and v.number  <= i.keycnt 
  and v.type  = 'P'

order by CONSTRAINT_NAME, ORDINAL_POSITION


--主键、外键对照(简化)
select
 fc_obj.name   as CONSTRAINT_NAME
 ,i.name     as UNIQUE_CONSTRAINT_NAME
from 
 sysobjects fc_obj
 ,sysreferences r
 ,sysindexes i
 ,sysobjects pc_obj
where 
 permissions(fc_obj.parent_obj) != 0
 and fc_obj.xtype = 'F'
 and r.constid  = fc_obj.id
 and r.rkeyid  = i.id
 and r.rkeyindid  = i.indid
 and r.rkeyid  = pc_obj.id

			
			
			
			
			
			
			
			
			
			
			SELECT  表名=case when a.colorder=1 then d.name else '' end, 
 --字段序号=a.colorder, 
 字段名=a.name, 
 --标识=case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end, 
--主键=case when exists(SELECT 1 FROM sysobjects where xtype='PK' and name 
  -- in (  SELECT name FROM sysindexes WHERE indid 
  --  in(   SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid  ))) 
   --  then '√' else '' end, 
--
 类型=b.name, 
 --占用字节数=a.length, 
 长度=COLUMNPROPERTY(a.id,a.name,'PRECISION'), 
 小数位数=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0), 
 允许空=case when a.isnullable=1 then '√'else '' end, 
 默认值=isnull(e.text,''), 
 字段说明=isnull(g.[value],'')
 FROM syscolumns a left join systypes b on a.xtype=b.xusertype inner join sysobjects d on a.id=d.id  
   and d.xtype='U' and  d.name<>'dtproperties' 
   left join syscomments e on a.cdefault=e.id left join sysproperties g on a.id=g.id 
   and a.colid=g.smallid  
   order by a.id,a.colorder


			 */
            #endregion
        }
        /// <summary>
        /// 从SqlServer类型转换成.net类型	
        /// </summary>
        /// <param name="SqlType">SqlServer类型</param>
        /// <returns></returns>
        public static string TypeOf(string SqlType)
        {
            string Value = "string";
            string SqlTypeUpper = SqlType.ToUpper();

            if (SqlTypeUpper == "BIGINT") { Value = "long"; }
            else if (SqlTypeUpper == "BINARY") { Value = "int"; }
            else if (SqlTypeUpper == "BIT") { Value = "bool"; }
            else if (SqlTypeUpper == "CHAR") { Value = "string"; }
            else if (SqlTypeUpper == "DATETIME") { Value = "DateTime"; }
            else if (SqlTypeUpper == "DECIMAL") { Value = "decimal"; }
            else if (SqlTypeUpper == "FLOAT") { Value = "decimal"; }
            else if (SqlTypeUpper == "IMAGE") { Value = "byte[]"; }
            else if (SqlTypeUpper == "INT") { Value = "int"; }
            else if (SqlTypeUpper == "MONEY") { Value = "decimal"; }
            else if (SqlTypeUpper == "NCHAR") { Value = "string"; }
            else if (SqlTypeUpper == "NTEXT") { Value = "string"; }
            else if (SqlTypeUpper == "NUMERIC") { Value = "double"; }
            else if (SqlTypeUpper == "NVARCHAR") { Value = "string"; }
            else if (SqlTypeUpper == "REAL") { Value = "float"; }
            else if (SqlTypeUpper == "SMALLDATETIME") { Value = "DateTime"; }
            else if (SqlTypeUpper == "SMALLINT") { Value = "int"; }
            else if (SqlTypeUpper == "SMALLMONEY") { Value = "float"; }
            else if (SqlTypeUpper == "SQL_VARIANT") { Value = "string"; }
            else if (SqlTypeUpper == "SYSNAME") { Value = "string"; }
            else if (SqlTypeUpper == "TEXT") { Value = "string"; }
            else if (SqlTypeUpper == "TIMESTAMP") { Value = "int"; }
            else if (SqlTypeUpper == "TINYINT") { Value = "byte"; }
            else if (SqlTypeUpper == "UNIQUEIDENTIFIER") { Value = "string"; }
            else if (SqlTypeUpper == "VARBINARY") { Value = "string"; }
            else if (SqlTypeUpper == "VARCHAR") { Value = "string"; }
            else { Value = "string"; }

            return Value;
        }
        private static string GetValue(DataRow oDr)
        {
            string Value = "";
            string ColumnValue = oDr["ColumnValue"].ToString().Replace("'", "''");
            string DataType = oDr["DataType"].ToString().ToUpper();
            Value = "'" + ColumnValue + "'";
            if (DataType == "INT" || DataType == "DECIMAL" || DataType == "FLOAT" || DataType == "BIT")
                Value = ColumnValue;
            return Value;
        }
        internal static string GetSelectColumns(Com.Common.Entity Obj)
        {
            //使用StringBuilder为了提高效率
            StringBuilder Value = new StringBuilder();
            bool bJoinSelf = IsSelfTableJoin(Obj);
            for (int i = 0; i < Obj.SelectColumns.Length; i++)
            {
                string columnname = Obj.SelectColumns[i];
                if (columnname != null && columnname.Trim() != "")
                {
                    string OriColumnName = columnname;
                    bool bSelfColumn = false;
                    if (bJoinSelf)
                    {
                        for (int k = 0; k < Obj.Columns.Length; k++)
                        {
                            if (columnname.ToUpper() == Obj.Columns[k])
                            {
                                OriColumnName = "[" + Obj.TableName + "].[" + columnname + "] ";
                                bSelfColumn = true;
                                break;
                            }
                        }
                    }

                    if (Obj.IdentityColumn.Trim() != "" && Obj.IdentityColumn.ToUpper() == columnname.ToUpper())
                    {
                        Value.Append("CAST(" + OriColumnName + " AS INT) AS [" + columnname + "],");
                    }
                    else
                    {
                        string prefix = "[";
                        string endfix = "]";
                        if (OriColumnName.IndexOf(" ") > -1 || OriColumnName.IndexOf("*") > -1 || OriColumnName.IndexOf(")") > -1 || OriColumnName.IndexOf("(") > -1 || OriColumnName.IndexOf(".") > -1)
                        {
                            prefix = "";
                            endfix = "";
                        }
                        Value.Append(prefix + OriColumnName + endfix);
                        if (bJoinSelf == true && bSelfColumn == true)
                        {
                            Value.Append(" AS [" + columnname + "]");
                        }
                        Value.Append(",");
                    }
                }
            }
            return Value.ToString().TrimEnd(',');
        }
        private static string GetUpdateColumns(Com.Common.Entity Obj)
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
                                if (oDr["ColumnValue"].ToString().Replace("'", "''").Trim() == "" && oDr["IsNullable"].ToString() == "1")//是否为NULL
                                {
                                    Value.Append(ColumnName + "=NULL,");
                                }
                                else
                                {
                                    Value.Append(ColumnName + "=" + GetValue(oDr) + ",");
                                }
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
                            if (oDr["ColumnValue"].ToString().Replace("'", "''").Trim() == "" && oDr["IsNullable"].ToString() == "1")//是否为NULL
                            {
                                Value.Append(ColumnName + "=NULL,");
                            }
                            else
                            {
                                Value.Append(ColumnName + "=" + GetValue(oDr) + ",");
                            }
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
                            Value.Append(ColumnName + "=" + GetValue(oDr) + ",");
                        }
                    }
                }
            }

            return Value.ToString().TrimEnd(',');
        }
        internal static string GetInsertColumns(Com.Common.Entity Obj)
        {
            StringBuilder Value = new StringBuilder();
            foreach (DataRow oDr in Obj.ValuesList.Rows)
            {
                if (oDr["ColumnValue"].ToString() != "")
                {
                    Value.Append(oDr["ColumnName"].ToString() + ",");
                }
                else
                {
                    #region 如果插入的值没有赋值则使用默认值
                    if (oDr["Default"].ToString().Trim() != "")
                    {
                        Value.Append(oDr["ColumnName"].ToString() + ",");
                    }
                    #endregion
                }
            }
            return Value.ToString().TrimEnd(',');
        }

        private static string GetInsertValues(Com.Common.Entity Obj)
        {
            StringBuilder Value = new StringBuilder();
            foreach (DataRow oDr in Obj.ValuesList.Rows)
            {
                if (oDr["ColumnValue"].ToString() != "")
                {
                    Value.Append(GetValue(oDr) + ",");
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

        internal static string GetJoinSql(Com.Common.Entity Obj)
        {
            StringBuilder Value = new StringBuilder();
            foreach (DataRow oDr in Obj.JoinTableList.Rows)
            {
                Value.Append(" " + oDr["JoinType"].ToString() + " JOIN " + oDr["JoinDataBase"].ToString() +
                    (oDr["JoinDataBase"].ToString().Trim() == "" ? "" : "." + Obj.TableOwner + ".")
                    + oDr["JoinTableName"].ToString() +
                    " " + oDr["JoinTableAs"].ToString() + " WITH(NOLOCK) ON " + Obj.TableName + "." + oDr["ColumnName"].ToString() + " = " + //2007-3-10
                    (oDr["JoinTableAs"].ToString().Trim() == "" ? oDr["JoinTableName"].ToString() : oDr["JoinTableAs"].ToString()) +
                    "." +
                    oDr["JoinColumnName"].ToString() + " ");

                if (oDr["JoinColumnName1"].ToString().Trim() != "" && oDr["ColumnName1"].ToString().Trim() != "")
                {
                    Value.Append(" AND " + Obj.TableName + "." + oDr["ColumnName1"].ToString() + " = " + //2007-3-10
                    (oDr["JoinTableAs"].ToString().Trim() == "" ? oDr["JoinTableName"].ToString() : oDr["JoinTableAs"].ToString()) +
                    "." +
                    oDr["JoinColumnName1"].ToString() + " ");
                }
                if (oDr["JoinColumnName2"].ToString().Trim() != "" && oDr["ColumnName2"].ToString().Trim() != "")
                {
                    Value.Append(" AND " + Obj.TableName + "." + oDr["ColumnName2"].ToString() + " = " + //2017-3-30
                    (oDr["JoinTableAs"].ToString().Trim() == "" ? oDr["JoinTableName"].ToString() : oDr["JoinTableAs"].ToString()) +
                    "." +
                    oDr["JoinColumnName2"].ToString() + " ");
                }

            }
            return Value.ToString();
        }
        private static string GetWhereSqlForSplit_Or_And(Com.Common.Entity Obj)
        {
            StringBuilder Value = new StringBuilder();
            bool bJoinSelf = IsSelfTableJoin(Obj);
            foreach (DataRow oDr in Obj.ValuesList.Rows)
            {
                string columnname = oDr["ColumnName"].ToString();
                if (bJoinSelf)
                {
                    columnname = "[" + Obj.TableName + "].[" + oDr["ColumnName"].ToString() + "]";
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
                            Value.Append(" AND " + columnname + " LIKE " + GetValue(oDr) + " ");
                        else
                            Value.Append(" AND " + columnname + "=" + GetValue(oDr) + " ");
                    }

                }
            }
            if (Obj.WhereSql.Trim() != "")
                Value.Append(" AND " + Obj.WhereSql);
            return Value.ToString();
        }
        public static bool IsSelfTableJoin(Com.Common.Entity Obj)
        {
            bool bJoinSelf = false;//是否自关联
            foreach (DataRow oDr in Obj.JoinTableList.Rows)
            {
                if (oDr["JoinTableName"].ToString().ToUpper() == Obj.TableName.ToUpper())
                {
                    bJoinSelf = true;
                    break;
                }
            }

            return bJoinSelf;
        }
        internal static string GetWhereSql(Com.Common.Entity Obj)
        {
            if (Obj.Split_Or_And == true)
            {
                return GetWhereSqlForSplit_Or_And(Obj);
            }
            StringBuilder Value = new StringBuilder();
            bool bJoinSelf = IsSelfTableJoin(Obj);
            foreach (DataRow oDr in Obj.ValuesList.Rows)
            {
                string columnname = oDr["ColumnName"].ToString();
                if (bJoinSelf)
                {
                    columnname = "[" + Obj.TableName + "].[" + oDr["ColumnName"].ToString() + "]";
                }
                if (oDr["ColumnValue"].ToString() != "")
                {
                    if (oDr["ColumnValue"].ToString().IndexOf("%") > -1 || oDr["ColumnValue"].ToString().IndexOf("_") > -1)
                        Value.Append(" AND " + columnname + " LIKE " + GetValue(oDr) + " ");
                    else
                        Value.Append(" AND " + columnname + "=" + GetValue(oDr) + " ");
                }
            }
            if (Obj.WhereSql.Trim() != "")
                Value.Append(" AND " + Obj.WhereSql);
            return Value.ToString();
        }
        /// <summary>
        /// 获得更新的条件语句,根据主键更新,如果没有主键则不进行更新
        /// </summary>
        /// <returns></returns>
        private static string GetUpdateWhereSql(Com.Common.Entity Obj)
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
                            Value.Append(" AND " + Obj.PrimaryKey[i] + "=" + GetValue(oDr) + " ");
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
        /// <summary>
        /// 获得删除实体的条件语句
        /// </summary>
        /// <returns></returns>
        private static string GetDeleteWhereSql(Com.Common.Entity Obj)
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
                            Value.Append(" AND " + Obj.PrimaryKey[i] + "=" + GetValue(oDr) + " ");
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
        public static string GetCreateObjSql(Com.Common.Entity Obj)
        {
            StringBuilder Value = new StringBuilder();
            Value.Append(@"
				CREATE TABLE [" + Obj.TableName + @"] (
");
            string PrimaryKeys = "";
            for (int i = 0; i < Obj.ValuesList.Rows.Count; i++)
            {
                Value.Append("[" + Obj.ValuesList.Rows[i]["ColumnName"].ToString() + "] [" +
                    Obj.ValuesList.Rows[i]["DataType"].ToString() + "] ");
                if (Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() != "INT"
                    && Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() != "DATETIME"
                    && Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() != "TEXT"
                    && Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() != "SMALLDATETIME"
                    && Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() != "NTEXT"
                    && Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() != "BIT")
                    Value.Append(" (" +
                        Obj.ValuesList.Rows[i]["Length"].ToString() + ") ");
                if (Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() == "CHAR"
                    || Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() == "VARCHAR"
                    || Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() == "NCHAR"
                    || Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() == "NVARCHAR"
                    || Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() == "TEXT"
                    || Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() == "NTEXT"
                    || Obj.ValuesList.Rows[i]["DataType"].ToString().ToUpper() == "SYSNAME")
                    Value.Append(" COLLATE Chinese_PRC_CI_AS ");
                if (Obj.ValuesList.Rows[i]["IsNullable"].ToString() == "1")
                    Value.Append(" NULL ");
                else
                    Value.Append(" NOT NULL ");
                if (Obj.ValuesList.Rows[i]["Default"].ToString().Trim() != "")
                    Value.Append(" CONSTRAINT [DF_" + Obj.TableName + "_" + Obj.ValuesList.Rows[i]["ColumnName"].ToString() + "] DEFAULT ('" + Obj.ValuesList.Rows[i]["Default"].ToString() + "') ");
                Value.Append("  ," + " \r\n");
                if (Obj.ValuesList.Rows[i]["IsPrimaryKey"].ToString() == "1")
                    PrimaryKeys += "[" + Obj.ValuesList.Rows[i]["ColumnName"].ToString() + "],";

            }

            if (PrimaryKeys.TrimEnd() != "")
                Value.Append(@"
	CONSTRAINT [PK_" + Obj.TableName + @"] PRIMARY KEY  CLUSTERED 
	(
		" + PrimaryKeys.TrimEnd(',') + @"
	)  ON [PRIMARY] ");
            Value.Append(@"
) ON [PRIMARY]
GO
");
            return Value.ToString();
        }
        /// <summary>
        /// 获取提取数据的Sql语句
        /// </summary>
        /// <param name="Top">记录数</param>
        /// <returns></returns>
        public static string GetSelectObjSql(int Top, Com.Common.Entity Obj)
        {
            string strTop = "";
            string OrderColumn = "";
            string Value = "";
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
                if (DISTINCT == "DISTINCT" && Obj.OrderBy != "" && Obj.OrderBy.TrimEnd().ToUpper() != "NEWID()")
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
            Value = @" SELECT " + DISTINCT + " " + strTop + " " + SqlCore.GetSelectColumns(Obj) + OrderColumn + " FROM [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "] [" + Obj.TableName + "] WITH(NOLOCK) " + Obj.JoinSql + " " + SqlCore.GetJoinSql(Obj) + " WHERE 1=1 " + SqlCore.GetWhereSql(Obj);
            if (Obj.GroupBy != "")
                Value += " GROUP BY " + Obj.GroupBy + " ";
            if (Obj.OrderBy != "")
                Value += " ORDER BY " + Obj.OrderBy + " ";
            return Value;
        }
        /// <summary>
        /// 获取插入数据的Sql语句
        /// </summary>
        /// <returns></returns>
        public static string GetInsertObjSql(Com.Common.Entity Obj)
        {
            string Value = "";
            Value = @" INSERT INTO [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + @"](" + SqlCore.GetInsertColumns(Obj) + ") VALUES(" + SqlCore.GetInsertValues(Obj) + ") ";
            return Value;
        }
        /// <summary>
        /// 获取更新数据的Sql语句,根据已设置的主键来更新数据
        /// </summary>
        /// <returns></returns>
        public static string GetUpdateObjSql(Com.Common.Entity Obj)
        {
            string Value = "";
            string UpdateWhereSql = SqlCore.GetUpdateWhereSql(Obj);
            string UpdateColumns = SqlCore.GetUpdateColumns(Obj);
            if (UpdateColumns.Trim() == "")
            {
                return ";";
            }
            Value = " UPDATE [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "] SET " + UpdateColumns + "  WHERE 1=1 ";
            if (UpdateWhereSql.Trim() != "")
            {
                Value += UpdateWhereSql;
            }
            else
            {
                Value += " AND 1<>1 ";
            }
            return Value;
        }
        /// <summary>
        /// 获取删除数据的Sql语句
        /// </summary>
        /// <returns></returns>
        public static string GetDeleteObjSql(Com.Common.Entity Obj)
        {
            string Value = "";
            Value = " DELETE FROM [" + Obj.DataBase + "]." + Obj.TableOwner + ".[" + Obj.TableName + "] WHERE 1=1 ";
            string DeleteWhereSql = SqlCore.GetDeleteWhereSql(Obj);
            if (Obj.WhereSql.Trim() != "")
            {
                DeleteWhereSql += " AND " + Obj.WhereSql;
            }

            if (DeleteWhereSql.Trim() != "")
            {
                Value += DeleteWhereSql;
            }
            else
            {
                Value += " AND 1<>1 ";
            }
            return Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="PageIndex">页码(从1开始)</param>
        /// <param name="bCount">是否获得总记录数</param>
        /// <returns></returns>
        internal static string GetSelectObjSqlByProcedure(int PageSize, int PageIndex, bool bCount, Com.Common.Entity Obj)
        {
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
            string sql = "EXECUTE SP_CommonPaging " + PageSize.ToString() +
                "," + PageIndex.ToString() + ",'" + Data.SqlServer.SqlCore.GetSelectColumns(Obj).Replace("'", "''") + OrderColumn.Replace("'", "''") + "','" + Obj.JoinSql.Replace("'", "''") +
                " " + Data.SqlServer.SqlCore.GetJoinSql(Obj).Replace("'", "''") + " ','" + Obj.DataBase.Replace("'", "''") + "." + Obj.TableOwner + ".[" + Obj.TableName.Replace("'", "''") + "] [" + Obj.TableName.Replace("'", "''") + " ]','" + PrimaryKeys.Replace("'", "''") + "','" + Data.SqlServer.SqlCore.GetWhereSql(Obj).Replace("'", "''") + "','" + OrderBy.Replace("'", "''") + "'," + Convert.ToInt16(bCount) + "," + (DISTINCT == "" ? "0" : "1");

            return sql;
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
            string sql = GetSelectObjSqlByProcedure(PageSize, PageIndex, bCount, Obj);
            DataSet dsResult = Obj.Database_Reader.ExecuteDataSet(CommandType.Text, sql);
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
        #region 实现数据库的基本函数，如：COUNT(*),SUM(),GETDATE()等
        /// <summary>
        /// 从数据库获取记录数 COUNT ( { [ ALL | DISTINCT ] expression ] | * } )
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string COUNT(string Expression)
        {
            return " COUNT(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取总和数 SUM ( [ ALL | DISTINCT ] expression ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string SUM(string Expression)
        {
            return " SUM(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取最大值
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string MAX(string Expression)
        {
            return " MAX(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取最小值
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string MIN(string Expression)
        {
            return " MIN(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取字段的子串 SUBSTRING ( expression , start , length ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <param name="Start"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string SUBSTRING(string Expression, int Start, int Length)
        {
            return " SUBSTRING(" + Expression + "," + Start + "," + Length + ") ";
        }
        /// <summary>
        /// 从数据库获取数据库当前日期
        /// </summary>
        /// <returns></returns>
        public static string GETDATE()
        {
            return " GETDATE() ";
        }
        /// <summary>
        /// 从数据库获取表达式的平均值 AVG ( [ ALL | DISTINCT ] expression )
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string AVG(string Expression)
        {
            return " AVG(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取正弦值函数
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string SIN(float Expression)
        {
            return " SIN(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取余弦值函数
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string COS(float Expression)
        {
            return " COS(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取数值的绝对值 ABS ( numeric_expression ) 
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string ABS(float Expression)
        {
            return " ABS(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取随机生成的新NEWID
        /// </summary>
        /// <returns></returns>
        public static string NEWID()
        {
            return " NEWID() ";
        }
        /// <summary>
        /// 从数据库获取随机数
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string RAND(float Expression)
        {
            return " RAND(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取反余弦值
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string ACOS(float Expression)
        {
            return " ACOS(" + Expression + ") ";
        }
        /// <summary>
        /// 从数据库获取字符的ASCII值
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string ASCII(char Expression)
        {
            return " ASCII('" + Expression + "') ";
        }
        /// <summary>
        /// 除去左边控格
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string LTRIM(string Expression)
        {
            return " LTRIM('" + Expression + "') ";

        }
        /// <summary>
        /// 除去右边控格
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string RTRIM(string Expression)
        {
            return " RTRIM('" + Expression + "') ";

        }
        /// <summary>
        /// 判断是NULL
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string ISNULL(string Expression)
        {
            return " " + Expression + " IS NULL ";

        }
        /// <summary>
        /// 判断是NOTNULL
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static string ISNOTNULL(string Expression)
        {
            return " " + Expression + " IS NOT NULL ";

        }
        #endregion
    }
}
