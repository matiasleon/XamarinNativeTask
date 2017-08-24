using NativeTest.BusinessLayer;
using NativeTest.BusinessLayer.IRepository;
using NativeTest.DataAccess;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTest.DataAccessLayer
{
    public class TaskRepository : ITaskRepository
    {
        private Database database;

        public TaskRepository(string path, ISQLitePlatform sQLitePlatform)
        {
            this.database = new Database(path, sQLitePlatform);
        }

        public async Task<IList<BusinessLayer.Task>> GetAll()
        {
            return await this.database.GetAll();
        }
    }
}
