using System;

namespace Com.AutoCode
{
    /// <summary>
    /// ASPXCoder 的摘要说明。
    /// </summary>
    public class ASPXCoder
    {
        public ASPXCoder()
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

            string Value = "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r<tr>\r";
            int i = -1;
            int k = 0;
            foreach (string column in arrCOLUMNS)
            {
                i++;
                if (IDENTITY == column)
                {
                    continue;
                }
                bool bPrimaryKey = false;
                foreach (string primarykey in arrPRIMARYKEYS)
                {
                    if (primarykey == column)
                    {
                        bPrimaryKey = true;
                        break;
                    }
                }
                if (bPrimaryKey)
                    continue;
                Value += "<td>" + arrDESCRIPTIONS[i] + "</td>\r<td>";
                if (arrDATATYPES[i] == "INT" ||
                 arrDATATYPES[i] == "BIT" ||
                 arrDATATYPES[i] == "BIGINT")
                {
                    Value += "<asp:DropDownList ID=\"ddl_" + column + "\" runat=\"server\"></asp:DropDownList>";
                }
                else
                {
                    Value += "<asp:TextBox ID=\"txt_" + column + "\" runat=\"server\" MaxLength=\"" + arrLENGTHS[i] + "\"></asp:TextBox></td>\r";
                }
                k++;
                if (k == 2)
                {
                    Value += "</tr>\r<tr>\r";
                    k = 0;
                }
            }
            Value += "</tr>\r</table>";
            return Value;
        }
        #endregion
    }
}
