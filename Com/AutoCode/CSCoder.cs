using System;

namespace Com.AutoCode
{
    /// <summary>
    /// CSCoder 的摘要说明。
    /// </summary>
    public class CSCoder
    {
        public string TableName = "";
        public CSCoder()
        {
        }

        #region AutoCode

        public string GetAutoCode(string COLUMNS, string DATATYPES, string DESCRIPTIONS, string LENGTHS, string PRIMARYKEYS, string IDENTITY)
        {
            #region this.namespaces this.database ...
            string[] arrCOLUMNS = COLUMNS.Trim().Split(',');
            string[] arrDATATYPES = DATATYPES.Trim().Split(',');
            string[] arrDESCRIPTIONS = DESCRIPTIONS.Trim().Split(',');
            string[] arrLENGTHS = LENGTHS.Trim().Split(',');
            string[] arrPRIMARYKEYS = PRIMARYKEYS.Trim().Split(',');
            #endregion

            string Value = "";
            int i = -1;
            foreach (string column in arrCOLUMNS)
            {
                i++;
                if (IDENTITY == column)
                {
                    continue;
                }
                if (arrDATATYPES[i] == "INT" || arrDATATYPES[i] == "BIGINT")
                {
                    Value += "if(this.ddl_" + column + ".SelectedItem.Value.Trim()!=\"\")\r";
                    Value += "{\r";
                    Value += TableName.ToLower() + "." + column + " =Convert.ToInt32( this.ddl_" + column + ".SelectedItem.Value);//" + arrDESCRIPTIONS[i] + "\r";
                    Value += "}\r";
                }
                else if (arrDATATYPES[i] == "DATETIME")
                {
                    Value += "if(this.txt_" + column + ".Text.Trim()!=\"\")\r";
                    Value += "{\r";
                    Value += TableName.ToLower() + "." + column + " =Convert.ToDateTime( this.txt_" + column + ".Text);//" + arrDESCRIPTIONS[i] + "\r";
                    Value += "}\r";
                }
                else if (arrDATATYPES[i] == "BIT")
                {
                    Value += "if(this.ddl_" + column + ".SelectedItem.Value.Trim()!=\"\")\r";
                    Value += "{\r";
                    Value += TableName.ToLower() + "." + column + " =Convert.ToBoolean( this.ddl_" + column + ".SelectedItem.Value);//" + arrDESCRIPTIONS[i] + "\r";
                    Value += "}\r";
                }
                else
                {
                    Value += TableName.ToLower() + "." + column + " = this.txt_" + column + ".Text;//" + arrDESCRIPTIONS[i] + "\r";
                }
            }
            Value += "\n\r\n\r//=========================================\r";
            i = -1;
            foreach (string column in arrCOLUMNS)
            {
                i++;
                if (arrDATATYPES[i] == "INT" ||
                arrDATATYPES[i] == "DECIMAL" ||
                arrDATATYPES[i] == "FLOAT" ||
                arrDATATYPES[i] == "BIT" ||
                arrDATATYPES[i] == "BIGINT" ||
                arrDATATYPES[i] == "MONEY" ||
                arrDATATYPES[i] == "NUMERIC" ||
                arrDATATYPES[i] == "REAL" ||
                arrDATATYPES[i] == "SMALLINT" ||
                arrDATATYPES[i] == "SMALLMONEY" ||
                arrDATATYPES[i] == "TIMESTAMP")
                {
                    Value += "this.ddl_" + column + ".SelectedValue=" + TableName.ToLower() + "." + column + "_ToString;//" + arrDESCRIPTIONS[i] + "\r";
                }
                else if (arrDATATYPES[i] == "DATETIME")
                {
                    Value += " this.txt_" + column + ".Text=" + TableName.ToLower() + "." + column + "_ToString ;//" + arrDESCRIPTIONS[i] + "\r";
                }
                else
                {
                    Value += " this.txt_" + column + ".Text=" + TableName.ToLower() + "." + column + " ;//" + arrDESCRIPTIONS[i] + "\r";
                }
            }

            return Value;
        }
        #endregion
    }
}
