using Company.G01.DAL.Models;
using Company.G01.PL.Dtos;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var department = new Department()
                {
                    Code= model.Code,
                    Name= model.Name,
                    CreateAt=model.CreateAt

                };
              var Count =  _departmentRepositry.Add(department);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }
    }
}
