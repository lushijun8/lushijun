using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Business
{
    public  class Excel
    {
        /// <summary>
        /// 读取excel表里的信息，转换成dataset
        /// </summary>
        /// <param name="fileName">要读取的excel表</param>
        /// <returns></returns>
        public static DataTable ReadExcelDataTable(string fileName)
        {
            int intColCount = 0;
            DataTable mydt = new DataTable("myTableName");
            DataColumn mydc;
            DataRow mydr;

            string strpath = "";
            string strline;
            string[] aryline;

            System.IO.StreamReader mysr = new System.IO.StreamReader(fileName, System.Text.Encoding.Default);

            while ((strline = mysr.ReadLine()) != null)
            {
                aryline = strline.Split(new char[] { ',' });

                intColCount = aryline.Length;
                for (int i = 0; i < aryline.Length; i++)
                {
                    mydc = new DataColumn();
                    mydt.Columns.Add(mydc);
                }

                mydr = mydt.NewRow();
                for (int i = 0; i < intColCount; i++)
                {
                    mydr[i] = aryline[i];
                }
                mydt.Rows.Add(mydr);
            }
            mysr.Close();
            return mydt;

        }

        ///   <summary>   
        ///   将DataTable中的数据导出到指定的Excel文件中   
        ///   </summary>   
        ///   <param   name="tab">包含被导出数据的DataTable对象</param>   
        ///   <param   name="filePath">excel保存在服务器上的路径</param>         
        public static bool SaveDataTableToExcel(System.Data.DataTable tab, string filePath)
        {
            try
            {
                string tw = "";
                int i, j = 0;
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        tw += tab.Rows[i][j].ToString();
                        if (j != 3)
                            tw += ",";
                    }
                    tw += "\r\n";
                }
                for (i = 2; i < tab.Rows.Count; i++)
                {
                    for (j = 0; j < tab.Columns.Count; j++)
                    {
                        tw += tab.Rows[i][j].ToString();
                        if (j != tab.Columns.Count - 1)
                            tw += ",";
                    }
                    if (i != tab.Rows.Count - 1)
                        tw += "\r\n";
                }
                Com.File.FileUtil.FileCreate(filePath,0);
                FileStream fsFile = new FileStream(filePath, FileMode.Create);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fsFile, System.Text.Encoding.GetEncoding("gbk"));
                sw.Write(tw);
                sw.Close();
                return true;
            }
            catch (Exception err)
            {
                throw new Exception("在服务器上将DataTable导入到Excel出错！错误原因：" + err.Message);
                return false;
            }
            finally
            {
            }

        }
    }
}
