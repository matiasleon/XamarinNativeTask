using NativeTest.BusinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTest.BusinessLayer.Tasks.Searchers
{
    public class TaskSearcher
    {
        private readonly ITaskRepository repository;

        public TaskSearcher(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public Task<IList<BusinessLayer.Task>> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
