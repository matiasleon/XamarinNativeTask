using System.Collections.Generic;
using System.Linq;
using NativeTest.BusinessLayer;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System.Threading.Tasks;

namespace NativeTest.DataAccess
{
    public class Database
    {
        private SQLiteAsyncConnection connection;

        public Database(string databasepath, ISQLitePlatform sQLitePlataform)
        {
            this.connection = SQLiteConnectionDatabase.GetConnection(databasepath, sQLitePlataform);
            this.CreateTable();
        }

        private async void  CreateTable()
        {
            await this.connection.CreateTableAsync<BusinessLayer.Task>();
        }

        public async Task<IList<BusinessLayer.Task>> GetAll()
        {
            return await this.connection.Table<BusinessLayer.Task>().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<int> Save(BusinessLayer.Task task)
        {
            return await this.connection.InsertAsync(task);
        }
    }
}
