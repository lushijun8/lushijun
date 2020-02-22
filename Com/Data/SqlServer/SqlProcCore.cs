using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Com.Data.SqlServer
{
	/// <summary>
	/// DBProcOperator ��ժҪ˵����
	/// </summary>
	public class SqlProcCore
	{
		public SqlProcCore()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		
		#region insert
		/// <summary>
		/// ��ȡ��������
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		private static SqlParameter[] GetInsertSqlParameter(Com.Common.Entity Obj,out int OutputIndex)
		{
			int OtherParam=1;
			OutputIndex=-1;
			SqlParameter[] Value = new SqlParameter[Obj.ValuesList.Rows.Count+OtherParam];
			Value[0]=new SqlParameter("@SPTABLENAME",Obj.TableName);
			int i=OtherParam;
			foreach(DataRow oDr in Obj.ValuesList.Rows)
			{
				Value[i]=new SqlParameter("@"+oDr["ColumnName"].ToString()+"",System.DBNull.Value);//Ĭ��Ϊ��
				if(oDr["ColumnName"].ToString().ToUpper()==Obj.IdentityColumn)//�����������
				{
					Value[i]=new SqlParameter("@"+oDr["ColumnName"].ToString()+"",System.DBNull.Value);
					Value[i].Direction=ParameterDirection.Output;
					OutputIndex=i;
				}
				else if(oDr["Updated"].ToString()=="1")//������״̬
				{
					Value[i]=new SqlParameter("@"+oDr["ColumnName"].ToString()+"",oDr["ColumnValue"]);
				}
				i++;
			}
			return Value;
		}
		/// <summary>
		///  ����һ�����ݣ�������������򷵻���������ֵ�����򷵻�1�����ص�����С��1ʱΪʧ��
		/// </summary>
		/// <param name="Obj"></param>
		/// <param name="Identity"></param>
		/// <returns></returns>
		public static bool InsertObj(Com.Common.Entity Obj,out string Identity)
		{
			bool Result=false;
			int rowsAffected=0;
			int OutputIndex=0;
			Identity=string.Empty;
			SqlParameter[] parameters = GetInsertSqlParameter(Obj,out OutputIndex);
            rowsAffected=Obj.Database_Writer.ExecuteNonQuery("SP_" + Obj.TableName + @"_INSERT",parameters);
            //Com.Data.DbProcUtil.RunProcedure("SP_" + Obj.TableName + @"_INSERT", parameters, out rowsAffected);
			if(Obj.IdentityColumn!="")
			{
				Identity=(string)parameters[OutputIndex].Value;
			}
			if(rowsAffected>0)
			{
				Result=true;
			}
			return Result;
		}
		/// <summary>
		/// ����һ�����ݣ�������������򷵻���������ֵ�����򷵻�1�����ص�����С��1ʱΪʧ��
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		public static bool InsertObj(Com.Common.Entity Obj)
		{
			string Identity=string.Empty;
			return InsertObj(Obj,out Identity);
		}

		#endregion

		#region update
		/// <summary>
		/// ��ȡ���²���
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		private static SqlParameter[] GetUpdateSqlParameter(Com.Common.Entity Obj)
		{
			int OtherParam=2;
			SqlParameter[] Value = new SqlParameter[Obj.ValuesList.Rows.Count+OtherParam];
			Value[0]=new SqlParameter("@SPTABLENAME",Obj.TableName);
			Value[1]=new SqlParameter("@SPWHERESQL",Obj.WhereSql);
			int i=OtherParam;
			foreach(DataRow oDr in Obj.ValuesList.Rows)
			{
				Value[i]=new SqlParameter("@"+oDr["ColumnName"].ToString()+"",System.DBNull.Value);//Ĭ��Ϊ��
				bool bUpdated=false;
				if(Obj.UpdateColumns!=null && Obj.UpdateColumns.Length>0)//��UpdateColumns����
				{
					for(int j=0;j<Obj.UpdateColumns.Length;j++)
					{
						if(Obj.UpdateColumns[j].ToUpper()==oDr["ColumnName"].ToString())
						{
							bUpdated=true;
							break;
						}
					}
					
				}
				else if(oDr["Updated"].ToString()=="1")//������״̬
				{
					bUpdated=true;
				}
				if(bUpdated==true)
				{
					Value[i]=new SqlParameter("@"+oDr["ColumnName"].ToString()+"",oDr["ColumnValue"]);
				}
				i++;
			}
			return Value;
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		/// <param name="Obj">ʵ�������</param>
		/// <returns></returns>
		public static bool UpdateObj(Com.Common.Entity Obj)
		{
			bool Result=false;
			int rowsAffected=0;
            SqlParameter[] parameters = GetUpdateSqlParameter(Obj);
            rowsAffected = Obj.Database_Writer.ExecuteNonQuery("SP_" + Obj.TableName + @"_UPDATE", parameters);
			//Com.Data.DbProcUtil.RunProcedure("SP_"+Obj.TableName+@"_UPDATE",parameters,out rowsAffected);
			if(rowsAffected>0)
			{
				Result=true;
			}
			return Result;
		}
		#endregion

		#region select
		/// <summary>
		/// ��ȡ��ѯ����
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		private static SqlParameter[] GetSelectSqlParameter(Com.Common.Entity Obj,int Top)
		{
			int OtherParam=7;
			SqlParameter[] Value = new SqlParameter[Obj.ValuesList.Rows.Count+OtherParam];
			Value[0]=new SqlParameter("@SPTABLENAME",Obj.TableName);
			Value[1]=new SqlParameter("@SPWHERESQL",Obj.WhereSql);
			Value[2]=new SqlParameter("@DISTINCT",Obj.Distinct);
			Value[3]=new SqlParameter("@TOP",Top);
			Value[4]=new SqlParameter("@SELECTCOLUMNS",SqlCore.GetSelectColumns(Obj));
			Value[5]=new SqlParameter("@JOINSQL",Obj.JoinSql+" "+SqlCore.GetJoinSql(Obj));
			Value[6]=new SqlParameter("@ORDERBY",Obj.OrderBy);
			int i=OtherParam;
			foreach(DataRow oDr in Obj.ValuesList.Rows)
			{
				Value[i]=new SqlParameter(
					"@"+oDr["ColumnName"].ToString()+"",
					(oDr["ColumnValue"].ToString().Trim()==""?System.DBNull.Value:oDr["ColumnValue"])
					);
				i++;
			}
			return Value;
		}

		/// <summary>
		/// ��ѯ����
		/// </summary>
		public static DataTable SelectObj(Com.Common.Entity Obj,int Top)
		{
			DataTable Result=null;
            SqlParameter[] parameters = GetSelectSqlParameter(Obj, Top);
            Result = Obj.Database_Writer.ExecuteDataSet("SP_" + Obj.TableName + @"_SELECT", parameters).Tables[0];
			//Result=Com.Data.DbProcUtil.RunProcedure("SP_"+Obj.TableName+@"_SELECT",parameters);
			if(Result!=null&& Result.Rows.Count>0)
			{
				Obj.RowCount=Result.Rows.Count;
			}
			return Result;
		}
		#endregion

		#region delete
		/// <summary>
		/// ��ȡɾ������
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		private static SqlParameter[] GetDeleteSqlParameter(Com.Common.Entity Obj)
		{
			int OtherParam=2;
			SqlParameter[] Value = new SqlParameter[Obj.ValuesList.Rows.Count+OtherParam];
			Value[0]=new SqlParameter("@SPTABLENAME",Obj.TableName);
			Value[1]=new SqlParameter("@SPWHERESQL",Obj.WhereSql);
			int i=OtherParam;
			foreach(DataRow oDr in Obj.ValuesList.Rows)
			{
				Value[i]=new SqlParameter(
					"@"+oDr["ColumnName"].ToString()+"",
					(oDr["ColumnValue"].ToString().Trim()==""?System.DBNull.Value:oDr["ColumnValue"])
					);
				i++;
			}
			return Value;
		}

		/// <summary>
		/// ɾ������
		/// </summary>
		public static bool DeleteObj(Com.Common.Entity Obj)
		{
			bool Result=false;
			int rowsAffected=0;
            SqlParameter[] parameters = GetDeleteSqlParameter(Obj);
            rowsAffected = Obj.Database_Writer.ExecuteNonQuery("SP_" + Obj.TableName + @"_DELETE", parameters);
			//Com.Data.DbProcUtil.RunProcedure("SP_"+Obj.TableName+@"_DELETE",parameters,out rowsAffected);
			if(rowsAffected>0)
			{
				Result=true;
			}
			return Result;
		}
		#endregion

	}
}
