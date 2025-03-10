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
    public class DepartmentRepositry : GenericRepositry<Department>, IDepartmentRepositry
    {

        public DepartmentRepositry(CompanyDbContext context) : base(context)
        {
            
        }





    }
}
