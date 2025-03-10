using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G01.DAL.Data.Contexts;
using Company.G01.DAL.Models;
using Company.G02.BLL.Interfices;

namespace Company.G02.BLL.Repositres
{
    public class EmployeeRepositry : IEmployeeRepositry
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepositry(CompanyDbContext context)
        {
              _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee? Get(int id)
        {
          return _context.Employees.Find(id);
        }

        public int Add(Employee model)
        {
             _context.Employees.Add(model);
            return _context.SaveChanges();
        }

        public int Update(Employee model)
        {

            _context.Employees.Update(model);
            return _context.SaveChanges();
        }
        public int Delete(Employee model)
        {

            _context.Employees.Remove(model);
            return _context.SaveChanges();
        }

       

        
    }
}
