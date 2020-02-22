
using System;
namespace Entity.TEAMTOOL
{
	/// <summary>
	/// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="TEAMTOOL" 
	/// Table="ADMIN_PERMISSION"
	/// Columns="PERMISSION_GROUP_ID,PERMISSION_FUNCTION_ID"
	/// PrimaryKeys="PERMISSION_GROUP_ID,PERMISSION_FUNCTION_ID"
	/// </summary>
	public sealed class ADMIN_PERMISSION  : Entity.TEAMTOOL.EntityBase
	{
				#region 系统代码，请不要动   生成日期:2015/9/7 16:12:17
				#region 属性
		/// <summary>
/// 权限分组ID与表[Admin_group] Group_id关联  INT(4)  NOT NULL
///	只写属性，如果非要读取该字段的字符串,建议使用 PERMISSION_GROUP_ID_ToString 更加准确
///	主健之一，其他主健还有：PERMISSION_GROUP_ID,PERMISSION_FUNCTION_ID
/// </summary>
public int PERMISSION_GROUP_ID
{
set
{
  ColumnValues[0]=value.ToString();UpdateStatus[0]=1;
}
}
/// <summary>
/// 权限分组ID与表[Admin_group] Group_id关联  INT(4)  NOT NULL
///	只读属性，如果非要写入该字段，请使用 PERMISSION_GROUP_ID
///	主健之一，其他主健还有：PERMISSION_GROUP_ID,PERMISSION_FUNCTION_ID
/// </summary>
public string PERMISSION_GROUP_ID_ToString
{
get
{
 return ColumnValues[0];
}
}
/// <summary>
/// 允许操作ID与表[Admin_Function] Function_id关联  INT(4)  NOT NULL
///	只写属性，如果非要读取该字段的字符串,建议使用 PERMISSION_FUNCTION_ID_ToString 更加准确
///	主健之一，其他主健还有：PERMISSION_GROUP_ID,PERMISSION_FUNCTION_ID
/// </summary>
public int PERMISSION_FUNCTION_ID
{
set
{
  ColumnValues[1]=value.ToString();UpdateStatus[1]=1;
}
}
/// <summary>
/// 允许操作ID与表[Admin_Function] Function_id关联  INT(4)  NOT NULL
///	只读属性，如果非要写入该字段，请使用 PERMISSION_FUNCTION_ID
///	主健之一，其他主健还有：PERMISSION_GROUP_ID,PERMISSION_FUNCTION_ID
/// </summary>
public string PERMISSION_FUNCTION_ID_ToString
{
get
{
 return ColumnValues[1];
}
}

				#endregion
				#region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
		/// <summary>
/// 权限分组ID与表[Admin_group] Group_id关联 返回 "PERMISSION_GROUP_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
/// </summary>
public readonly string _PERMISSION_GROUP_ID= "PERMISSION_GROUP_ID"; 
/// <summary>
/// 允许操作ID与表[Admin_Function] Function_id关联 返回 "PERMISSION_FUNCTION_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
/// </summary>
public readonly string _PERMISSION_FUNCTION_ID= "PERMISSION_FUNCTION_ID"; 

				#endregion
#region 函数
        /// <summary>
		/// ADMIN_PERMISSION的构造函数
		/// </summary>
		public ADMIN_PERMISSION()
		{
			this.TableName="ADMIN_PERMISSION";
			this.PrimaryKey=new string[]{_PERMISSION_GROUP_ID,_PERMISSION_FUNCTION_ID};
            
			this.columns=new string[]{_PERMISSION_GROUP_ID,_PERMISSION_FUNCTION_ID};
			this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
		}
        /// <summary>
        /// 初始化表ADMIN_PERMISSION的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1,1};
                this.DataTypes = new string[] { INT,INT };
                this.Lengths = new int[] { 4,4 };
                this.IsNullables = new int[] { 0,0 };
                this.DefaultValues = new string[]  { " "," " };
                this.Descriptions = new string[] { "权限分组ID与表[Admin_group] Group_id关联","允许操作ID与表[Admin_Function] Function_id关联" };
            }
        }			
		
/*
		/// <summary>
		/// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
		/// </summary>
		/// <param name="PERMISSION_GROUP_ID">权限分组ID与表[Admin_group] Group_id关联</param>
/// <param name="PERMISSION_FUNCTION_ID">允许操作ID与表[Admin_Function] Function_id关联</param>
		/// <returns>bool</returns>
		public bool Find(int P_PERMISSION_GROUP_ID,int P_PERMISSION_FUNCTION_ID)
		{
			bool Value=false;
			this.ColumnValues[0]=P_PERMISSION_GROUP_ID.ToString();
this.ColumnValues[1]=P_PERMISSION_FUNCTION_ID.ToString();
			if(this.SelectTop1()!=null)
				Value=true;
			return Value;
		}
*/

/*		
		/// <summary>
		/// 深度拷贝ADMIN_PERMISSION（新开辟了内存空间）
		/// </summary>
		/// <returns></returns>
		public ADMIN_PERMISSION Copy()
		{
			ADMIN_PERMISSION new_obj=new ADMIN_PERMISSION();
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
   /*
        /// <summary>
        /// 此处根据PERMISSION_GROUP_ID每500000条存一个表
        /// </summary>
        protected override void TableNameLogic()
        {
            if (this.PERMISSION_GROUP_ID_ToString.Trim() !=  "")
            {
                int length = 10;
                int mod = 500000;
                int permission_group_id = int.Parse(this.PERMISSION_GROUP_ID_ToString);

                int baseId = ((permission_group_id - 1) / mod) * mod;
                int startId = baseId + 1;
                int endId = baseId + mod;  

                string[] tablenames = Com.Net.HtmlUtil.GetRegexGroupFromString("(.*)_\\d{" + length +  "}_\\d{" + length +  "}", TableName, System.Text.RegularExpressions.RegexOptions.None);
                string tablename_Suffix =  "_" + startId.ToString().PadLeft(length, '0') +  "_" + endId.ToString().PadLeft(length, '0');
                string tablename_Prefix = this.TableName;
                if (tablenames != null && tablenames.Length > 0)
                {
                    tablename_Prefix = tablenames[0];
                }
                this.TableName = tablename_Prefix + tablename_Suffix;
            } 
        }
        */
#endregion
	}
}