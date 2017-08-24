using NativeTest.BusinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTest.BusinessLayer.Tasks.Generators
{
    public class TaskGenearator
    {
        private readonly ITaskRepository repository;

        public TaskGenearator(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public void Generate()
        {
            
        }
    }
}
