using SQLite.Net;
using SQLite.Net.Async;
using System;

namespace NativeTest.DataAccess
{
    public class SQLiteConnectionDatabase
    {
        public static SQLiteAsyncConnection GetConnection(string path, SQLite.Net.Interop.ISQLitePlatform sqlitePlatform)
        {
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(sqlitePlatform, new SQLiteConnectionString(path, false)));
            return new SQLiteAsyncConnection(connectionFactory);
        }
    }
}
