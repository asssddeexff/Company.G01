using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G01.DAL.Models;

namespace Company.G02.BLL.Interfices
{
    public interface IEmployeeRepositry : IGenericRepositry<Employee>
    {
        List<Employee>? GetByName(string name);

        //IEnumerable<Employee> GetAll();
        //Employee? Get(int id);

        //int Add(Employee model);
        //int Update(Employee model);
        //int Delete( Employee model);
    }
}
