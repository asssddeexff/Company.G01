using Company.G01.DAL.Models;
using Company.G01.PL.Dtos;
using Company.G02.BLL.Interfices;
using Microsoft.AspNetCore.Mvc;

namespace Company.G01.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepositry _employeeRepositry;
        //Ask Clr Create Object From DepartmentRepositry
        public EmployeeController(IEmployeeRepositry employeeRepositry)
        {
            _employeeRepositry = employeeRepositry;
        }
        [HttpGet] // Get: Department/Index
        public IActionResult Index()
        {

            var employees = _employeeRepositry.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDtos model)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    CreateAt = model.CreateAt,
                    HiringDate = model.HiringDate,
                    Email = model.Email,    
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    Phone = model.Phone,
                    Salary = model.Salary,
                };
                var Count = _employeeRepositry.Add(employee);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest("Invalid ID");//400
            var employee = _employeeRepositry.Get(id.Value);
            if (employee is null) return NotFound(new { statusCode = 400, message = $"Employee With Id{id}is Not Found" });
            return View(viewName,employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            //if (id is null) return BadRequest("Invalid ID");//400
            //var department = _departmentRepositry.Get(id.Value);
            //if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, CreateEmployeeDtos model)
        {



            if (ModelState.IsValid)
            {
                //if (id != model.Id) return BadRequest();//400
                var employee = new Employee()
                {
                    Id=id,
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    CreateAt = model.CreateAt,
                    HiringDate = model.HiringDate,
                    Email = model.Email,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    Phone = model.Phone,
                    Salary = model.Salary,
                };

                var count = _employeeRepositry.Update(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(model);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit([FromRoute] int id, UpdateDepartmentDto model)
        //{



        //    if (ModelState.IsValid)
        //    {


        //        var department = new Department()
        //        {
        //            Id = id,
        //            Name = model.Name,
        //            Code = model.Name,
        //            CreateAt=model.CreateAt,


        //        };
        //        var count = _departmentRepositry.Update(department);
        //        if (count > 0)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }



        //    }

        //    return View(model);

        //}

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            //if (id is null) return BadRequest("Invalid ID");//400
            //var department = _departmentRepositry.Get(id.Value);
            //if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return Details(id, "Delete");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee model)
        {



            if (ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest();//400


                var count = _employeeRepositry.Delete(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(model);

        }
    }
}
