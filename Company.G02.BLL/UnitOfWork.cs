using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G01.DAL.Data.Contexts;
using Company.G02.BLL.Interfices;
using Company.G02.BLL.Repositres;

namespace Company.G02.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public IDepartmentRepositry DepartmentRepositry { get; }//Null

        public IEmployeeRepositry EmployeeRepositry { get; }//Null


        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
            DepartmentRepositry = new DepartmentRepositry(_context);
            EmployeeRepositry = new EmployeeRepositry(_context);
           
        }

        public async Task<int> CompleteAsync()
        {
           return await _context.SaveChangesAsync();
        }

        //public void Dispose()
        //{
        //   _context.Dispose();
        //}

        public async ValueTask DisposeAsync()
        {
          await _context.DisposeAsync();
        }
    }
}
