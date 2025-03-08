using Company.G02.BLL.Interfices;
using Company.G02.BLL.Repositres;
using Microsoft.AspNetCore.Mvc;

namespace Company.G01.PL.Controllers
{
    //MVC Controller
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositry _departmentRepositry;
        //Ask Clr Create Object From DepartmentRepositry
        public DepartmentController(IDepartmentRepositry departmentRepositry)
        {
            _departmentRepositry = departmentRepositry;   
        }
        [HttpGet] // Get: Department/Index
        public IActionResult Index()
        {
           
            var departments = _departmentRepositry.GetAll();
            return View(departments);
        }
    }
}
