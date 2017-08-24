using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTest.BusinessLayer.IRepository
{
    public interface ITaskRepository
    {
        Task<IList<Task>> GetAll();
    }
}
