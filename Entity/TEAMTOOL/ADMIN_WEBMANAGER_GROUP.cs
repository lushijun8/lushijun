
using System;
namespace Entity.TEAMTOOL
{
	/// <summary>
	/// 本类中的(系统代码部分)由代码生成器自动生成,如果数据库表结构有所改动请及时更新
	/// DataBase="TEAMTOOL" 
	/// Table="ADMIN_WEBMANAGER_GROUP"
	/// Columns="GROUP_ID,GROUP_NAME,GROUP_CREATETIME,GROUP_REMARK"
	/// PrimaryKeys="GROUP_ID"
	/// </summary>
	public sealed class ADMIN_WEBMANAGER_GROUP  : Entity.TEAMTOOL.EntityBase
	{
				#region 系统代码，请不要动   生成日期:2015/9/7 16:12:17
				#region 属性
		/// <summary>
/// 权限分组ID  INT(4) 自增列 NOT NULL
///	只写属性，如果非要读取该字段的字符串,建议使用 GROUP_ID_ToString 更加准确
///	唯一主键
/// </summary>
public int GROUP_ID
{
set
{
  ColumnValues[0]=value.ToString();UpdateStatus[0]=1;
}
}
/// <summary>
/// 权限分组ID  INT(4) 自增列 NOT NULL
///	只读属性，如果非要写入该字段，请使用 GROUP_ID
///	唯一主键
/// </summary>
public string GROUP_ID_ToString
{
get
{
 return ColumnValues[0];
}
}
/// <summary>
/// 权限分组名称  NVARCHAR(40)  NOT NULL
/// </summary>
public string GROUP_NAME
{
get
{
 return ColumnValues[1];
}
set
{
  ColumnValues[1]=value;UpdateStatus[1]=1;
}
}
/// <summary>
/// 权限分组创建时间  DATETIME(8)  NULL
///	只写属性，如果非要读取该字段的字符串,建议使用 GROUP_CREATETIME_ToString 更加准确
///	默认值:getdate
/// </summary>
public DateTime GROUP_CREATETIME
{
set
{
    ColumnValues[2] = value.ToString("yyyy-MM-dd HH:mm:ss.fff"); UpdateStatus[2] = 1;
}
}
/// <summary>
/// 权限分组创建时间  DATETIME(8)  NULL
///	只读属性，如果非要写入该字段，请使用 GROUP_CREATETIME
///	默认值:getdate
/// </summary>
public string GROUP_CREATETIME_ToString
{
get
{
 return ColumnValues[2];
}
}
/// <summary>
/// 备注  NVARCHAR(4000)  NULL
/// </summary>
public string GROUP_REMARK
{
get
{
 return ColumnValues[3];
}
set
{
  ColumnValues[3]=value;UpdateStatus[3]=1;
}
}

				#endregion
				#region  同名列变量 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用以下同名列变量
		/// <summary>
/// 权限分组ID 返回 "GROUP_ID", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
/// </summary>
public readonly string _GROUP_ID= "GROUP_ID"; 
/// <summary>
/// 权限分组名称 返回 "GROUP_NAME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
/// </summary>
public readonly string _GROUP_NAME= "GROUP_NAME"; 
/// <summary>
/// 权限分组创建时间 返回 "GROUP_CREATETIME", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
/// </summary>
public readonly string _GROUP_CREATETIME= "GROUP_CREATETIME"; 
/// <summary>
/// 备注 返回 "GROUP_REMARK", 为了与数据库同步，避免列名写错，如果用到表的列名，请尽量使用同名列变量
/// </summary>
public readonly string _GROUP_REMARK= "GROUP_REMARK"; 

				#endregion
#region 函数
        /// <summary>
		/// ADMIN_WEBMANAGER_GROUP的构造函数
		/// </summary>
		public ADMIN_WEBMANAGER_GROUP()
		{
			this.TableName="ADMIN_WEBMANAGER_GROUP";
			this.PrimaryKey=new string[]{_GROUP_ID};
            this.IdentityColumn=this._GROUP_ID;
			this.columns=new string[]{_GROUP_ID,_GROUP_NAME,_GROUP_CREATETIME,_GROUP_REMARK};
			this.SelectColumns = this.Columns;
            this.ColumnValues = new string[this.Columns.Length];
            this.UpdateStatus = new int[this.Columns.Length];
            for (int i = 0; i < this.Columns.Length; i++) { this.UpdateStatus[i] = 0; this.ColumnValues[i] = ""; };
		}
        /// <summary>
        /// 初始化表ADMIN_WEBMANAGER_GROUP的各种相关值
        /// </summary>
        protected override void SetValuesOnInit()
        {
            if (this.DataTypes == null || this.DataTypes.Length == 0)
            {
                this.IsPrimaryKeys = new int[] { 1,0,0,0};
                this.DataTypes = new string[] { INT,NVARCHAR,DATETIME,NVARCHAR };
                this.Lengths = new int[] { 4,40,8,4000 };
                this.IsNullables = new int[] { 0,0,1,1 };
                this.DefaultValues = new string[]  { " "," ","getdate"," " };
                this.Descriptions = new string[] { "权限分组ID","权限分组名称","权限分组创建时间","备注" };
            }
        }			
		
/*
		/// <summary>
		/// 根据设置的主键，获得实体的表入口,并且给各个属性赋值，注意：WhereSql,JoinSql对该方法无用
		/// </summary>
		/// <param name="GROUP_ID">权限分组ID</param>
		/// <returns>bool</returns>
		public bool Find(int P_GROUP_ID)
		{
			bool Value=false;
			this.ColumnValues[0]=P_GROUP_ID.ToString();
			if(this.SelectTop1()!=null)
				Value=true;
			return Value;
		}
*/

/*		
		/// <summary>
		/// 深度拷贝ADMIN_WEBMANAGER_GROUP（新开辟了内存空间）
		/// </summary>
		/// <returns></returns>
		public ADMIN_WEBMANAGER_GROUP Copy()
		{
			ADMIN_WEBMANAGER_GROUP new_obj=new ADMIN_WEBMANAGER_GROUP();
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
//在此处添加用户自己的业务逻辑代码
#endregion
	}
}