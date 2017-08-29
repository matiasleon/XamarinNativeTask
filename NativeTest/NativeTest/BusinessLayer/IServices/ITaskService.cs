using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTest.BusinessLayer.IServices
{
    public interface ITaskService
    {
        Task<IList<Task>> GetAll();
    }
}
