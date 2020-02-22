using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Xml;
namespace Business.DataConfiguration
{
    public class InitConfig
    {
        public static bool UpdateConfig(string FilePath)
        {
            XmlDocument doc = Com.Xml.XmlUtil.GetDocFromFile(FilePath);
            string InnerXml = doc.InnerXml;

            Entity.TEAMTOOL.DATABASE_OWNER database_owner = new Entity.TEAMTOOL.DATABASE_OWNER();
            database_owner.SelectColumns = new string[] { 
                database_owner._DATABASE_ID,
                database_owner._DATABASE_IP_LOCAL,
                database_owner._DATABASE_IP_ROMOTE,
                database_owner._DATABASE_NAME, 
                database_owner._DATABASE_IS_MAIN, 
                database_owner._DATABASE_ADMIN_USER,
                database_owner._DATABASE_ADMIN_PASSWORD, 
                database_owner._DATABASE_READER_USER, 
                database_owner._DATABASE_READER_PASSWORD, 
                database_owner._DATABASE_WRITER_USER,
                database_owner._DATABASE_WRITER_PASSWORD
            };
            DataTable oDt_database_owner = database_owner.Select();
            foreach (DataRow oDr_database_owner in oDt_database_owner.Rows)
            {
                InnerXml = Regex.Replace(InnerXml, "<connectionString name=\"" + oDr_database_owner[database_owner._DATABASE_IP_ROMOTE].ToString() + "_" + oDr_database_owner[database_owner._DATABASE_NAME].ToString() + "_DataBaseOwner\">" +
                    "<parameters>" +
                    "<parameter name=\"database\" value=\"" + oDr_database_owner[database_owner._DATABASE_NAME].ToString() + "\" isSensitive=\"false\" />" +
                    "<parameter name=\"pwd\" value=\".*\" isSensitive=\"false\" />" +
                    "<parameter name=\"server\" value=\"" + oDr_database_owner[database_owner._DATABASE_IP_ROMOTE].ToString() + "\" isSensitive=\"false\" />" +
                    "<parameter name=\"user id\" value=\"" + oDr_database_owner[database_owner._DATABASE_ADMIN_USER].ToString() + "\" isSensitive=\"false\" />" +
                    "</parameters>" +
                    "</connectionString>",

                    "<connectionString name=\"" + oDr_database_owner[database_owner._DATABASE_IP_ROMOTE].ToString() + "_" + oDr_database_owner[database_owner._DATABASE_NAME].ToString() + "_DataBaseOwner\">" +
                    "<parameters>" +
                    "<parameter name=\"database\" value=\"" + oDr_database_owner[database_owner._DATABASE_NAME].ToString() + "\" isSensitive=\"false\" />" +
                    "<parameter name=\"pwd\" value=\"" + Com.Common.EncDec.Decrypt(oDr_database_owner[database_owner._DATABASE_ADMIN_PASSWORD].ToString(), Business.ManageWeb.encrypt_key) + "\" isSensitive=\"false\" />" +
                    "<parameter name=\"server\" value=\"" + oDr_database_owner[database_owner._DATABASE_IP_ROMOTE].ToString() + "\" isSensitive=\"false\" />" +
                    "<parameter name=\"user id\" value=\"" + oDr_database_owner[database_owner._DATABASE_ADMIN_USER].ToString() + "\" isSensitive=\"false\" />" +
                    "</parameters>" +
                    "</connectionString>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }
            doc.InnerXml = InnerXml;
            if (!string.IsNullOrEmpty(InnerXml))
            {
                Com.File.FileUtil.FileCreate(FilePath, 1);
                Com.File.FileUtil.AppendFileContent(FilePath, Com.Xml.XmlUtil.Serialize(typeof(System.Xml.XmlDocument), doc));
            }
            return true;
        }
    }
}
