using System;
using System.Collections.Generic;
using System.Text;

namespace Com.AutoCode
{
    public class CreateTableCoder
    {
        public static string CetSql(string TABLENAME, string columns, string datatypes, string lengths, string isnullables, string defaults, string descriptions, string primarykeys, string identity)
        {
            string Value = "";
            Value += @"				
                CREATE TABLE [dbo].[" + TABLENAME + @"](
                ";
            string[] arrcolumns = columns.Split(',');
            string[] arrisnullables = isnullables.Split(',');
            string[] arrlengths = lengths.Split(',');
            string[] arrdefaults = defaults.Split(',');
            string[] arrdescriptions = descriptions.Split(',');
            string[] arrdatatypes = datatypes.Split(',');
            string[] arrprimarykeys = primarykeys.Split(',');
            string PrimaryKeys = "";
            string Descriptions = "";
            int k = 0;
            foreach (string arrcolumn in arrcolumns)
            {
                Value += @" [" + arrcolumn + "] [" + arrdatatypes[k] + "] ";
                if (arrdatatypes[k].ToUpper() != "INT"
                    && arrdatatypes[k].ToUpper() != "DATETIME"
                    && arrdatatypes[k].ToUpper() != "TEXT"
                    && arrdatatypes[k].ToUpper() != "SMALLDATETIME"
                    && arrdatatypes[k].ToUpper() != "NTEXT"
                    && arrdatatypes[k].ToUpper() != "BIT"
                    && arrdatatypes[k].ToUpper() != "BIGINT")
                {
                    string len = arrlengths[k];

                    if (arrdatatypes[k].ToUpper() == "NCHAR" || arrdatatypes[k].ToUpper() == "NVARCHAR")
                    {
                        len = (int.Parse(arrlengths[k]) / 2).ToString();
                    }
                    else if (arrlengths[k] == "-1")
                    {
                        len = "max";
                    }
                    Value += @" (" + len + ") ";
                }

                if (arrdatatypes[k].ToUpper() == "CHAR"
                    || arrdatatypes[k].ToUpper() == "VARCHAR"
                    || arrdatatypes[k].ToUpper() == "NCHAR"
                    || arrdatatypes[k].ToUpper() == "NVARCHAR"
                    || arrdatatypes[k].ToUpper() == "TEXT"
                    || arrdatatypes[k].ToUpper() == "NTEXT"
                    || arrdatatypes[k].ToUpper() == "SYSNAME")
                {
                    Value += @" COLLATE Chinese_PRC_CI_AS ";
                }
                if (identity.ToUpper() == arrcolumn.ToUpper())
                {
                    Value += " IDENTITY(1,1) ";
                }

                Value += arrisnullables[k] == "1" ? " NULL " : " NOT NULL ";
                if (arrdefaults[k].Trim() != "")
                {
                    Value += @" CONSTRAINT [DF_" + TABLENAME + @"_" + arrcolumn + "] DEFAULT ('" + arrdefaults[k].Replace("'", "''") + "') ";
                }
                Value += @",
                ";

                bool bPrimary = false;
                foreach (string arrprimarykey in arrprimarykeys)
                {
                    if (arrprimarykey == arrcolumn)
                    {
                        bPrimary = true;
                        break;
                    }
                }
                if (bPrimary)
                {
                    PrimaryKeys += "[" + arrcolumn + @"] ASC,";
                }
                if (arrdescriptions[k].Trim() != "")
                {
                    Descriptions += @"
                EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'" + arrdescriptions[k] + "' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" + TABLENAME + @"', @level2type=N'COLUMN',@level2name=N'" + arrcolumn + @"'
                GO
";
                }
                k++;
            }

            if (!string.IsNullOrEmpty(PrimaryKeys))
            {

                Value += @"
                CONSTRAINT [PK_" + TABLENAME + @"] PRIMARY KEY CLUSTERED 
                (
	             " + PrimaryKeys.TrimEnd(',') + @"
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
";
            }
            Value += @"
                ) ON [PRIMARY]
                GO
";
            Value += Descriptions;
            return Value;
        }
    }
}
