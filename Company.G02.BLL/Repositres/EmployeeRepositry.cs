using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G01.DAL.Data.Contexts;
using Company.G01.DAL.Models;
using Company.G02.BLL.Interfices;
using Microsoft.EntityFrameworkCore;

namespace Company.G02.BLL.Repositres
{
    public class EmployeeRepositry :GenericRepositry<Employee> , IEmployeeRepositry
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepositry(CompanyDbContext context) : base(context)//Ask CLR Create Object From CompanyDbContext
        {
            _context = context;
        }

        public List<Employee> GetByName(string name)
        {
           return _context.Employees.Include(E => E.Department).Where(E=>E.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
