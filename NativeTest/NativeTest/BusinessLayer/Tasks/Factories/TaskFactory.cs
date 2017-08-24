using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTest.BusinessLayer
{
    public class TaskFactory
    {
        public TaskFactory()
        {
            
        }

        public Task Create()
        {
            return new Task();
        }
    }
}
