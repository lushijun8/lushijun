using System;

namespace Com.AutoCode
{
	/// <summary>
	/// SPCoder 的摘要说明。
	/// </summary>
	public class SPCoder
	{
		#region 私有变量
		private string namespaces="";
		private string database="";
		private string tablename="";
		private string columns="";
		private string primarykeys="";
		private string datatypes="";
		private string lengths="";
		private string isnullables="";
		private string defaults="";
		private string descriptions="";
		private string identity="";

		#endregion
		#region 属性
		/// <summary>
		/// NAMESPACE  NAMESPACE(NAMESPACE)  NOT NULL
		///默认值:NAMESPACE
		/// </summary>
		public string NAMESPACE
		{
			get
			{
				return this.namespaces;
			}
			set
			{
				this.namespaces=value;
			}
		}
		public string DATABASE
		{
			get
			{
				return this.database;
			}
			set
			{
				this.database=value;
			}
		}
		public string TABLENAME
		{
			get
			{
				return this.tablename;
			}
			set
			{
				this.tablename=value;
			}
		}
		public string COLUMNS
		{
			get
			{
				return this.columns;
			}
			set
			{
				this.columns=value;
			}
		}
		public string PRIMARYKEYS
		{
			get
			{
				return this.primarykeys;
			}
			set
			{
				this.primarykeys=value;
			}
		}
		public string DATATYPES
		{
			get
			{
				return this.datatypes;
			}
			set
			{
				this.datatypes=value;
			}
		}
		public string LENGTHS
		{
			get
			{
				return this.lengths;
			}
			set
			{
				this.lengths=value;
			}
		}
		public string ISNULLABLES
		{
			get
			{
				return this.isnullables;
			}
			set
			{
				this.isnullables=value;
			}
		}
		public string DEFAULTS
		{
			get
			{
				return this.defaults;
			}
			set
			{
				this.defaults=value;
			}
		}
		public string DESCRIPTIONS
		{
			get
			{
				return this.descriptions;
			}
			set
			{
				this.descriptions=value;
			}
		}
		public string IDENTITY
		{
			get
			{
				return this.identity;
			}
			set
			{
				this.identity=value;
			}
		}

		#endregion
		public SPCoder()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private string GetValue(string DataType,string ColumnName)
		{
			string Value="";
			DataType=DataType.ToUpper();
			ColumnName=ColumnName.ToUpper();
			Value="'''+@"+ColumnName+"+'''";
			
			if(DataType=="INT" ||
				DataType=="DECIMAL" ||
				DataType=="FLOAT" ||
				DataType=="BIT" ||
				DataType=="BIGINT" ||
				DataType=="MONEY" ||
				DataType=="NUMERIC" ||
				DataType=="REAL" ||
				DataType=="SMALLINT" ||
				DataType=="SMALLMONEY" ||
				DataType=="TIMESTAMP")
			{
					Value="'+CAST(@"+ColumnName+" AS VARCHAR)+'";
			}
			return Value;
		}
		private string GetPropertys(int TYPE)
		{
			string Value="";
			string[] arrPRIMARYKEYS=PRIMARYKEYS.Trim().Split(',');
			string[] arrCOLUMNS=COLUMNS.Trim().Split(',');
			string[] arrDATATYPES=DATATYPES.Trim().Split(',');
			string[] arrLENGTHS=LENGTHS.Trim().Split(',');
			string[] arrISNULLABLES=ISNULLABLES.Trim().Split(',');
			string[] arrDEFAULTS=DEFAULTS.Trim().Split(',');
			string[] arrDESCRIPTIONS=DESCRIPTIONS.Trim().Split(',');
			string[] arrIDENTITY=IDENTITY.Trim().Split(',');
			for(int i=0;i<arrCOLUMNS.Length;i++)
			{
				int isidentity=0;
				for(int k=0;k<arrIDENTITY.Length;k++)
				{
					if(arrCOLUMNS[i].ToUpper()==arrIDENTITY[k].ToUpper())
					{
						isidentity=1;
						break;
					}
				}
				int isprimarykey=0;
				for(int k=0;k<arrPRIMARYKEYS.Length;k++)
				{
					if(arrCOLUMNS[i].ToUpper()==arrPRIMARYKEYS[k].ToUpper())
					{
						isprimarykey=1;
						break;
					}
				}
				string LEN="";
				switch(TYPE)
				{
					case -1://INSERT
						
						if(arrDATATYPES[i].ToUpper()!="INT" && arrDATATYPES[i].ToUpper()!="TEXT"  && arrDATATYPES[i].ToUpper()!="IMAGE" && arrDATATYPES[i].ToUpper()!="BIT" && arrDATATYPES[i].ToUpper()!="DATETIME" && arrDATATYPES[i].ToUpper()!="SMALLDATETIME")
						{
							LEN="("+arrLENGTHS[i]+")";
						}
						Value+="@"+arrCOLUMNS[i].ToUpper()+" "+arrDATATYPES[i].ToUpper()+LEN+(isidentity==1?" OUTPUT ":"")+(
							(i==(arrCOLUMNS.Length-1))?"":",")
							+" --"+arrDESCRIPTIONS[i]+@"
";
						break;
					case 0:
						if(arrDATATYPES[i].ToUpper()!="INT" && arrDATATYPES[i].ToUpper()!="TEXT"  && arrDATATYPES[i].ToUpper()!="IMAGE" && arrDATATYPES[i].ToUpper()!="BIT" && arrDATATYPES[i].ToUpper()!="DATETIME" && arrDATATYPES[i].ToUpper()!="SMALLDATETIME")
							LEN="("+arrLENGTHS[i]+")";
						Value+="@"+arrCOLUMNS[i].ToUpper()+" "+arrDATATYPES[i].ToUpper()+LEN+(
							(i==(arrCOLUMNS.Length-1))?"":",")
							+" --"+arrDESCRIPTIONS[i]+@"
";
						break;
					case 1:
						if(isidentity==0)
							Value+=@"IF(@"+arrCOLUMNS[i].ToUpper()+@" IS NOT NULL)
 BEGIN
   SET @COLUMNS=@COLUMNS+',"+arrCOLUMNS[i].ToUpper()+@"'
   SET @VALUES=@VALUES+',"+this.GetValue(arrDATATYPES[i],arrCOLUMNS[i])+@"'
 END
";
						break;
					case 2:
						if(isprimarykey==0)
						{
							Value+=@"IF(@"+arrCOLUMNS[i].ToUpper()+@" IS NOT NULL)
 BEGIN
   SET @UPDATES=@UPDATES+',"+arrCOLUMNS[i].ToUpper()+"="+this.GetValue(arrDATATYPES[i],arrCOLUMNS[i])+@"'
 END
";
						}
						else
						{
							Value+=@"IF(@"+arrCOLUMNS[i].ToUpper()+@" IS NOT NULL)
 BEGIN
   SET @WHERE=@WHERE+' AND "+arrCOLUMNS[i].ToUpper()+"="+this.GetValue(arrDATATYPES[i],arrCOLUMNS[i])+@" '
 END
";
						}
						break;
					case 3:
						Value+=@"IF(@"+arrCOLUMNS[i].ToUpper()+@" IS NOT NULL)
 BEGIN
   SET @WHERE=@WHERE+' AND "+arrCOLUMNS[i].ToUpper()+"="+this.GetValue(arrDATATYPES[i],arrCOLUMNS[i])+@" '
 END
";
						break;
					case 4:
						if(isprimarykey==1)
						{
							Value+="@"+arrCOLUMNS[i].ToUpper()+" "+arrDATATYPES[i].ToUpper()+"("+arrLENGTHS[i]+")"+(
								(i==(arrCOLUMNS.Length-1))?"":",")
								+" --"+arrDESCRIPTIONS[i]+@"
";
						}
						break;
					case 5:
						if(isprimarykey==1)
						{
							Value+=@"IF(@"+arrCOLUMNS[i].ToUpper()+@" IS NOT NULL)
 BEGIN
   SET @WHERE=@WHERE+' AND "+arrCOLUMNS[i].ToUpper()+"="+this.GetValue(arrDATATYPES[i],arrCOLUMNS[i])+@" '
 END
";
						}
						break;
				}
			}
			return Value.TrimEnd(',');
		}
		public string GET_SP_OBJ_INSERT()
		{
			string Value="";
			Value=@"

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_"+this.tablename.ToUpper()+@"_INSERT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_"+this.tablename.ToUpper()+@"_INSERT]
GO
------------------------------------
--用途：插入一条记录 
--项目名称：
--说明：
--自动生成时间："+System.DateTime.Now.ToString()+@"
------------------------------------
CREATE PROCEDURE SP_"+this.tablename.ToUpper()+@"_INSERT
(
@SPTABLENAME VARCHAR(50),--表名称
"+this.GetPropertys(-1)+@"
)
AS
SET NOCOUNT ON
DECLARE @COLUMNS VARCHAR(8000),@VALUES VARCHAR(8000)
SET @COLUMNS='@@@@'
SET @VALUES='@@@@'
"+this.GetPropertys(1)+@"
SET @COLUMNS=REPLACE(@COLUMNS,'@@@@,','')
SET @VALUES=REPLACE(@VALUES,'@@@@,','')
IF(LEN(@COLUMNS)>0)
 BEGIN
   EXEC('INSERT INTO '+@SPTABLENAME+'('+@COLUMNS+') VALUES('+@VALUES+')')
   "+(IDENTITY.Trim()!=""?"SET @URL_ID = @@IDENTITY":"")+@"
 END

SET NOCOUNT OFF
GO
";
			return Value;
		}
		public string GET_SP_OBJ_UPDATE()
		{
			string Value="";
			Value=@"

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_"+this.tablename.ToUpper()+@"_UPDATE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_"+this.tablename.ToUpper()+@"_UPDATE]
GO
------------------------------------
--用途：更新记录 
--项目名称：
--说明：
--自动生成时间："+System.DateTime.Now.ToString()+@"
------------------------------------
CREATE PROCEDURE SP_"+this.tablename.ToUpper()+@"_UPDATE
(
@SPTABLENAME VARCHAR(50),--表名称
@SPWHERESQL VARCHAR(200),--附加条件
"+this.GetPropertys(0)+@"
)
AS
SET NOCOUNT ON
DECLARE @UPDATES VARCHAR(8000),@WHERE VARCHAR(8000)
SET @UPDATES='1=1'
SET @WHERE='1=1'
"+this.GetPropertys(2)+@"
IF(LEN(LTRIM(RTRIM(@SPWHERESQL)))>0)
 BEGIN
   SET @SPWHERESQL=' AND '+@SPWHERESQL
 END
SET @UPDATES=REPLACE(@UPDATES,'1=1','')
SET @WHERE=REPLACE(@WHERE,'1=1','')
IF(LEN(@WHERE)>0 AND LEN(@UPDATES)>0)
 BEGIN
   SET @UPDATES=SUBSTRING(@UPDATES,2,LEN(@UPDATES)-1)
   EXEC('UPDATE '+@SPTABLENAME+' SET '+@UPDATES+' WHERE 1=1 '+@WHERE+' '+@SPWHERESQL)
 END

SET NOCOUNT OFF
GO
";
			return Value;
		}
		public string GET_SP_OBJ_SELECT()
		{
			string Value="";
			Value=@"

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_"+this.tablename.ToUpper()+@"_SELECT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_"+this.tablename.ToUpper()+@"_SELECT]
GO
------------------------------------
--用途：根据条件查询记录 
--项目名称：
--说明：
--自动生成时间："+System.DateTime.Now.ToString()+@"
------------------------------------
CREATE PROCEDURE SP_"+this.tablename.ToUpper()+@"_SELECT
(
@SPTABLENAME VARCHAR(50),--表名称
@SPWHERESQL VARCHAR(200),--附加条件
@DISTINCT BIT, --是否Distinct
@TOP INT, --提取前多少项,如果是0或者-1则提取所有符合条件的记录
@SELECTCOLUMNS VARCHAR(2000), --需要查询的列,用','隔开,如果为空默认为所有列
@JOINSQL VARCHAR(1000),--关联表语句
@ORDERBY VARCHAR(1000),--排序方法
"+this.GetPropertys(0)+@"
)
AS
SET NOCOUNT ON
DECLARE @WHERE VARCHAR(8000),@SQL VARCHAR(8000),@DISTINCTS VARCHAR(100),@TOPS VARCHAR(100),@ORDERBYS VARCHAR(100)
SET @WHERE='1=1'
SET @SQL=''
SET @DISTINCTS=''
SET @TOPS=''
SET @ORDERBYS=''
IF(@DISTINCT=1)
 SET @DISTINCTS='DISTINCT'
IF(@TOP>0)
 SET @TOPS='TOP '+CAST(@TOP AS VARCHAR)
IF(LTRIM(RTRIM(@SELECTCOLUMNS))='')
 SET @SELECTCOLUMNS='*'
IF(LTRIM(RTRIM(@ORDERBY))='')
 SET @ORDERBYS='ORDER BY '+@ORDERBY
"+this.GetPropertys(3)+@"
IF(LEN(LTRIM(RTRIM(@SPWHERESQL)))>0)
 BEGIN
   SET @SPWHERESQL=' AND '+@SPWHERESQL
 END
SET @WHERE=REPLACE(@WHERE,'1=1','')
IF(LEN(@WHERE)>0)
 BEGIN
   SET @SQL='SELECT '+@DISTINCTS+' '+@TOPS+' '+@SELECTCOLUMNS+' FROM '+@SPTABLENAME+' '+@JOINSQL+'  WHERE 1=1 '+@WHERE+' '+@SPWHERESQL+' '+@ORDERBYS
   EXEC(@SQL)
 END

SET NOCOUNT OFF
GO
";
			return Value;
		}
		public string GET_SP_OBJ_DELETE()
		{
			string Value="";
			Value=@"

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_"+this.tablename.ToUpper()+@"_DELETE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_"+this.tablename.ToUpper()+@"_DELETE]
GO
------------------------------------
--用途：删除记录 
--项目名称：
--说明：
--自动生成时间："+System.DateTime.Now.ToString()+@"
------------------------------------
CREATE PROCEDURE SP_"+this.tablename.ToUpper()+@"_DELETE
(
@SPTABLENAME VARCHAR(50),--表名称
@SPWHERESQL VARCHAR(200),--附加条件
"+this.GetPropertys(0)+@"
)
AS
SET NOCOUNT ON
DECLARE @WHERE VARCHAR(8000)
SET @WHERE='1=1'
"+this.GetPropertys(3)+@"
IF(LEN(LTRIM(RTRIM(@SPWHERESQL)))>0)
 BEGIN
   SET @SPWHERESQL=' AND '+@SPWHERESQL
 END
SET @WHERE=REPLACE(@WHERE,'1=1','')
IF(LEN(@WHERE)>0)
 BEGIN
   EXEC('DELETE FROM '+@SPTABLENAME+' WHERE 1=1 '+@WHERE+' '+@SPWHERESQL)
 END

SET NOCOUNT OFF
GO
";
			return Value;
		}
	}
}
