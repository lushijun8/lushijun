using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Com.Data
{
    public sealed class DatabaseOperater
    {
        private DatabaseOperater() { }

        private static volatile Database writer;
        private static volatile Database reader;
        private static volatile Database owner;
        private static volatile Database owner_teamtool;
        private static volatile Database reader_teamtool;
        private static volatile Database writer_teamtool;
        private static volatile Database owner_xft_login_log;
        private static volatile Database reader_xft_login_log;
        private static volatile Database writer_xft_login_log;
        private static volatile Database owner_channelsales_test;
        private static volatile Database reader_channelsales_test;
        private static volatile Database writer_channelsales_test;
        private static volatile Database owner_channelsales_stats;
        private static volatile Database reader_channelsales_stats;
        private static volatile Database writer_channelsales_stats;
        private static volatile Database owner_tuan;
        private static volatile Database reader_tuan;
        private static volatile Database writer_tuan;
        private static volatile Database owner_tuan_test;
        private static volatile Database reader_tuan_test;
        private static volatile Database writer_tuan_test;

        private static object lockObject = new object();

        #region TeamTool 数据库用户
        /// <summary>
        /// 数据库dbo用户
        /// </summary>
        public static Database DataBaseOwner_TeamTool
        {
            get
            {
                if (owner_teamtool == null)
                    lock (lockObject)
                    {
                        if (owner_teamtool == null)
                        {
                            owner_teamtool = DatabaseFactory.CreateDatabase("DataBaseInstanceOwner");
                        }
                    }
                return owner_teamtool;
            }
        }
        /// <summary>
        /// 数据库只读用户
        /// </summary>
        public static Database DataBaseReader_TeamTool
        {
            get
            {
                if (reader_teamtool == null)
                    lock (lockObject)
                    {
                        if (reader_teamtool == null)
                        {
                            reader_teamtool = DatabaseFactory.CreateDatabase("DataBaseInstanceReader");
                        }
                    }
                return reader_teamtool;
            }
        }


        /// <summary>
        /// 数据库读写用户
        /// </summary>
        public static Database DataBaseWriter_TeamTool
        {
            get
            {
                if (writer_teamtool == null)
                    lock (lockObject)
                    {
                        if (writer_teamtool == null)
                        {
                            writer_teamtool = DatabaseFactory.CreateDatabase("DataBaseInstanceWriter");
                        }
                    }
                return writer_teamtool;
            }
        }

        #endregion

        #region Xft_Login_Log 数据库用户
        /// <summary>
        /// 数据库dbo用户
        /// </summary>
        public static Database DataBaseOwner_Xft_Login_Log
        {
            get
            {
                if (owner_xft_login_log == null)
                    lock (lockObject)
                    {
                        if (owner_xft_login_log == null)
                        {
                            owner_xft_login_log = DatabaseFactory.CreateDatabase("124.251.44.233_xft_login_log_DataBaseInstance");
                        }
                    }
                return owner_xft_login_log;
            }
        }
        /// <summary>
        /// 数据库只读用户
        /// </summary>
        public static Database DataBaseReader_Xft_Login_Log
        {
            get
            {
                if (reader_xft_login_log == null)
                    lock (lockObject)
                    {
                        if (reader_xft_login_log == null)
                        {
                            reader_xft_login_log = DatabaseFactory.CreateDatabase("124.251.44.233_xft_login_log_DataBaseInstance");
                        }
                    }
                return reader_xft_login_log;
            }
        }


        /// <summary>
        /// 数据库读写用户
        /// </summary>
        public static Database DataBaseWriter_Xft_Login_Log
        {
            get
            {
                if (writer_xft_login_log == null)
                    lock (lockObject)
                    {
                        if (writer_xft_login_log == null)
                        {
                            writer_xft_login_log = DatabaseFactory.CreateDatabase("124.251.44.233_xft_login_log_DataBaseInstance");
                        }
                    }
                return writer_xft_login_log;
            }
        }

        #endregion

        #region Channelsales_Test 数据库用户
        /// <summary>
        /// 数据库dbo用户
        /// </summary>
        public static Database DataBaseOwner_Channelsales_Test
        {
            get
            {
                if (owner_channelsales_test == null)
                    lock (lockObject)
                    {
                        if (owner_channelsales_test == null)
                        {
                            owner_channelsales_test = DatabaseFactory.CreateDatabase("124.251.46.19_channelsales_test_DataBaseInstance");
                        }
                    }
                return owner_channelsales_test;
            }
        }
        /// <summary>
        /// 数据库只读用户
        /// </summary>
        public static Database DataBaseReader_Channelsales_Test
        {
            get
            {
                if (reader_channelsales_test == null)
                    lock (lockObject)
                    {
                        if (reader_channelsales_test == null)
                        {
                            reader_channelsales_test = DatabaseFactory.CreateDatabase("124.251.46.19_channelsales_test_DataBaseInstance");
                        }
                    }
                return reader_channelsales_test;
            }
        }


        /// <summary>
        /// 数据库读写用户
        /// </summary>
        public static Database DataBaseWriter_Channelsales_Test
        {
            get
            {
                if (writer_channelsales_test == null)
                    lock (lockObject)
                    {
                        if (writer_channelsales_test == null)
                        {
                            writer_channelsales_test = DatabaseFactory.CreateDatabase("124.251.46.19_channelsales_test_DataBaseInstance");
                        }
                    }
                return writer_channelsales_test;
            }
        }

        #endregion

        #region Channelsales_Stats 数据库用户
        /// <summary>
        /// 数据库dbo用户
        /// </summary>
        public static Database DataBaseOwner_Channelsales_Stats
        {
            get
            {
                if (owner_channelsales_stats == null)
                    lock (lockObject)
                    {
                        if (owner_channelsales_stats == null)
                        {
                            owner_channelsales_stats = DatabaseFactory.CreateDatabase("124.251.44.244_channelsales_stats_DataBaseInstance");
                        }
                    }
                return owner_channelsales_stats;
            }
        }
        /// <summary>
        /// 数据库只读用户
        /// </summary>
        public static Database DataBaseReader_Channelsales_Stats
        {
            get
            {
                if (reader_channelsales_stats == null)
                    lock (lockObject)
                    {
                        if (reader_channelsales_stats == null)
                        {
                            reader_channelsales_stats = DatabaseFactory.CreateDatabase("124.251.44.244_channelsales_stats_DataBaseInstance");
                        }
                    }
                return reader_channelsales_stats;
            }
        }


        /// <summary>
        /// 数据库读写用户
        /// </summary>
        public static Database DataBaseWriter_Channelsales_Stats
        {
            get
            {
                if (writer_channelsales_stats == null)
                    lock (lockObject)
                    {
                        if (writer_channelsales_stats == null)
                        {
                            writer_channelsales_stats = DatabaseFactory.CreateDatabase("124.251.44.244_channelsales_stats_DataBaseInstance");
                        }
                    }
                return writer_channelsales_stats;
            }
        }

        #endregion

        #region Tuan 数据库用户
        /// <summary>
        /// 数据库dbo用户
        /// </summary>
        public static Database DataBaseOwner_Tuan
        {
            get
            {
                if (owner_tuan == null)
                    lock (lockObject)
                    {
                        if (owner_tuan == null)
                        {
                            owner_tuan = DatabaseFactory.CreateDatabase("124.251.44.220_tuan_DataBaseInstance");
                        }
                    }
                return owner_tuan;
            }
        }
        /// <summary>
        /// 数据库只读用户
        /// </summary>
        public static Database DataBaseReader_Tuan
        {
            get
            {
                if (reader_tuan == null)
                    lock (lockObject)
                    {
                        if (reader_tuan == null)
                        {
                            reader_tuan = DatabaseFactory.CreateDatabase("124.251.44.220_tuan_DataBaseInstance");
                        }
                    }
                return reader_tuan;
            }
        }


        /// <summary>
        /// 数据库读写用户
        /// </summary>
        public static Database DataBaseWriter_Tuan
        {
            get
            {
                if (writer_tuan == null)
                    lock (lockObject)
                    {
                        if (writer_tuan == null)
                        {
                            writer_tuan = DatabaseFactory.CreateDatabase("124.251.44.220_tuan_DataBaseInstance");
                        }
                    }
                return writer_tuan;
            }
        }

        #endregion

        #region Tuan_Test 数据库用户
        /// <summary>
        /// 数据库dbo用户
        /// </summary>
        public static Database DataBaseOwner_Tuan_Test
        {
            get
            {
                if (owner_tuan_test == null)
                    lock (lockObject)
                    {
                        if (owner_tuan_test == null)
                        {
                            owner_tuan_test = DatabaseFactory.CreateDatabase("124.251.46.19_tuan_test_DataBaseInstance");
                        }
                    }
                return owner_tuan_test;
            }
        }
        /// <summary>
        /// 数据库只读用户
        /// </summary>
        public static Database DataBaseReader_Tuan_Test
        {
            get
            {
                if (reader_tuan_test == null)
                    lock (lockObject)
                    {
                        if (reader_tuan_test == null)
                        {
                            reader_tuan_test = DatabaseFactory.CreateDatabase("124.251.46.19_tuan_test_DataBaseInstance");
                        }
                    }
                return reader_tuan_test;
            }
        }


        /// <summary>
        /// 数据库读写用户
        /// </summary>
        public static Database DataBaseWriter_Tuan_Test
        {
            get
            {
                if (writer_tuan_test == null)
                    lock (lockObject)
                    {
                        if (writer_tuan_test == null)
                        {
                            writer_tuan_test = DatabaseFactory.CreateDatabase("124.251.46.19_tuan_test_DataBaseInstance");
                        }
                    }
                return writer_tuan_test;
            }
        }

        #endregion
        #region 方法
        /// <summary>
        /// 数据库dbo用户
        /// </summary>
        public static Database DataBaseOwner
        {
            get
            {
                if (owner == null)
                    lock (lockObject)
                    {
                        if (owner == null)
                        {
                            owner = DatabaseFactory.CreateDatabase("DataBaseInstanceOwner");
                        }
                    }
                return owner;
            }
        }
        /// <summary>
        /// 数据库只读用户
        /// </summary>
        public static Database DataBaseReader
        {
            get
            {
                if (reader == null)
                    lock (lockObject)
                    {
                        if (reader == null)
                        {
                            reader = DatabaseFactory.CreateDatabase("DataBaseInstanceReader");
                        }
                    }
                return reader;
            }
        }

        /// <summary>
        /// 数据库读写用户
        /// </summary>
        public static Database DataBaseWriter
        {
            get
            {
                if (writer == null)
                    lock (lockObject)
                    {
                        if (writer == null)
                        {
                            writer = DatabaseFactory.CreateDatabase("DataBaseInstanceWriter");
                        }
                    }
                return writer;
            }
        }
        /// <summary>
        /// 根据数据库实例返回Database
        /// </summary>
        /// <param name="cacheManagerName"></param>
        /// <returns></returns>
        public static Database GetDatabase(string databaseInstance)
        {
            lock (lockObject)
            {
                return DatabaseFactory.CreateDatabase(databaseInstance);
            }
        }
        #endregion
    }
}