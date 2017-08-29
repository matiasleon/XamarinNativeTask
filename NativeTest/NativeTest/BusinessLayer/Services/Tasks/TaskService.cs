using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeTest.BusinessLayer.IServices;
using NativeTest.BusinessLayer.Tasks.Searchers;

namespace NativeTest.BusinessLayer.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly TaskSearcher searcher;

        public TaskService(TaskSearcher searcher)
        {
            this.searcher = searcher;
        }

        public async Task<IList<Task>> GetAll()
        {
            return await this.searcher.GetAll();
        }
    }
}
