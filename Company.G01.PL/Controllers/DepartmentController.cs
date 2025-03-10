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


        [HttpGet]
        public IActionResult Details(int? id , string viewName ="Details")
        {
            if(id is null) return BadRequest("Invalid ID");//400
          var department =  _departmentRepositry.Get(id.Value);
            if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return View( viewName,department);
        }

        [HttpGet]
        public IActionResult Edit(int? id) {

            //if (id is null) return BadRequest("Invalid ID");//400
            //var department = _departmentRepositry.Get(id.Value);
            //if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return Details(id,"Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {



            if (ModelState.IsValid)
            {
                if (id != department.Id) return BadRequest();//400


                var count = _departmentRepositry.Update(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(department);

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
        public IActionResult Delete (int? id)
        {

            //if (id is null) return BadRequest("Invalid ID");//400
            //var department = _departmentRepositry.Get(id.Value);
            //if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return Details(id,"Delete");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department department)
        {



            if (ModelState.IsValid)
            {
                if (id != department.Id) return BadRequest();//400


                var count = _departmentRepositry.Delete(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(department);

        }
    }
}
