using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Interfices
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        public IDepartmentRepositry DepartmentRepositry { get;  }
        public IEmployeeRepositry EmployeeRepositry { get; }

        Task<int> CompleteAsync();
    }
}
