using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Com.Data
{
    public class DataBaseHelper
    {
        #region 封装企业库数据库操作
        private DataBaseHelper()
            : this(database)
        {
        }
        private DataBaseHelper(Database db)
        {
            _db = db;
        }
        #endregion

        #region 字段
        private Database _db;
        private static volatile Database db;


        private static object lockObject = new object();
        #endregion


        #region 静态方法
        public static DataBaseHelper GetDB(string databaseInstanceName)
        {
            Database db;
            lock (lockObject)
            {
                db = DatabaseFactory.CreateDatabase(databaseInstanceName);
            }
            if (db == null)
                return DefaultDB;
            else
                return new DataBaseHelper(db);
        }

        public static Database GetDataBaseInstance(string databaseInstanceName)
        {
            lock (lockObject)
            {
                return DatabaseFactory.CreateDatabase(databaseInstanceName);
            }
        }
        #endregion

        #region 静态属性
        private static Database database
        {
            get
            {
                if (db == null)
                {
                    lock (lockObject)
                    {
                        if (db == null)
                        {
                            db = DatabaseFactory.CreateDatabase("DefaultDataBaseInstance");
                        }
                    }

                }
                return db;
            }
        }

        private static DataBaseHelper DefaultDB
        {
            get
            {
                return new DataBaseHelper(database);

            }
        }

        #endregion

        #region 操作
        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            return _db.ExecuteDataSet(commandType, commandText);
        }
        public DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
        {
            return _db.ExecuteDataSet(storedProcedureName, parameterValues);
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return _db.ExecuteNonQuery(commandType, commandText);
        }
        public int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
        {
            return _db.ExecuteNonQuery(storedProcedureName, parameterValues);
        }

        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            return _db.ExecuteScalar(commandType, commandText);
        }
        public object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
        {
            return _db.ExecuteScalar(storedProcedureName, parameterValues);
        }

        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return _db.ExecuteReader(commandType, commandText);
        }
        public IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
        {
            return _db.ExecuteReader(storedProcedureName, parameterValues);
        }
        #endregion

        #region 静态操作
        public static DataSet ExecDataSet(CommandType commandType, string commandText)
        {
            return database.ExecuteDataSet(commandType, commandText);
        }
        public static DataSet ExecDataSet(string storedProcedureName, params object[] parameterValues)
        {
            return database.ExecuteDataSet(storedProcedureName, parameterValues);
        }

        public static int ExecNonQuery(CommandType commandType, string commandText)
        {
            return database.ExecuteNonQuery(commandType, commandText);
        }
        public static int ExecNonQuery(string storedProcedureName, params object[] parameterValues)
        {
            return database.ExecuteNonQuery(storedProcedureName, parameterValues);
        }

        public static object ExecScalar(CommandType commandType, string commandText)
        {
            return database.ExecuteScalar(commandType, commandText);
        }
        public static object ExecScalar(string storedProcedureName, params object[] parameterValues)
        {
            return database.ExecuteScalar(storedProcedureName, parameterValues);
        }

        public static IDataReader ExecReader(CommandType commandType, string commandText)
        {
            return database.ExecuteReader(commandType, commandText);
        }
        public static IDataReader ExecReader(string storedProcedureName, params object[] parameterValues)
        {
            return database.ExecuteReader(storedProcedureName, parameterValues);
        }

        public static DataSet ExecDataSet(string database, CommandType commandType, string commandText)
        {
            return GetDataBaseInstance(database).ExecuteDataSet(commandType, commandText);
        }
        public static DataSet ExecDataSet(string database, string storedProcedureName, params object[] parameterValues)
        {
            return GetDataBaseInstance(database).ExecuteDataSet(storedProcedureName, parameterValues);
        }

        public static int ExecNonQuery(string database, CommandType commandType, string commandText)
        {
            return GetDataBaseInstance(database).ExecuteNonQuery(commandType, commandText);
        }
        public static int ExecNonQuery(string database, string storedProcedureName, params object[] parameterValues)
        {
            return GetDataBaseInstance(database).ExecuteNonQuery(storedProcedureName, parameterValues);
        }

        public static object ExecScalar(string database, CommandType commandType, string commandText)
        {
            return GetDB(database).ExecuteScalar(commandType, commandText);
        }
        public static object ExecScalar(string database, string storedProcedureName, params object[] parameterValues)
        {
            return GetDB(database).ExecuteScalar(storedProcedureName, parameterValues);
        }

        public static IDataReader ExecReader(string database, CommandType commandType, string commandText)
        {
            return GetDataBaseInstance(database).ExecuteReader(commandType, commandText);
        }
        public static IDataReader ExecReader(string database, string storedProcedureName, params object[] parameterValues)
        {
            return GetDataBaseInstance(database).ExecuteReader(storedProcedureName, parameterValues);
        }
        #endregion
    }
}
