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
    public class EmployeeRepositry :GenericRepositry<Employee> , IEmployeeRepositry
    {
        public EmployeeRepositry(CompanyDbContext context) : base(context)//Ask CLR Create Object From CompanyDbContext
        {
            
        }



    }
}
