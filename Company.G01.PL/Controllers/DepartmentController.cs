using Company.G01.DAL.Models;
using Company.G01.PL.Dtos;
using Company.G02.BLL.Interfices;
using Company.G02.BLL.Repositres;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.G01.PL.Controllers
{
    [Authorize]
    //MVC Controller
    public class DepartmentController : Controller
    {
       // private readonly IDepartmentRepositry _departmentRepositry;
        private readonly IUnitOfWork _unitOfWork;

        //Ask Clr Create Object From DepartmentRepositry
        public DepartmentController(/*IDepartmentRepositry departmentRepositry*/ IUnitOfWork unitOfWork)
        {
           // _departmentRepositry = departmentRepositry;
            _unitOfWork = unitOfWork;
        }
        [HttpGet] // Get: Department/Index
        public async Task< IActionResult> Index()
        {
           
            var departments = await _unitOfWork.DepartmentRepositry.GetAllAsync();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var department = new Department()
                {
                    Code= model.Code,
                    Name= model.Name,
                    CreateAt=model.CreateAt

                };
               await _unitOfWork.DepartmentRepositry.AddAsync(department);
                var Count = await _unitOfWork.CompleteAsync();
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }


        [HttpGet]
        public async Task < IActionResult >Details(int? id , string viewName ="Details")
        {
            if(id is null) return BadRequest("Invalid ID");//400
          var department =  await _unitOfWork.DepartmentRepositry.GetAsync(id.Value);
            if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return View( viewName,department);
        }

        [HttpGet]
        public async Task< IActionResult> Edit(int? id) {

            //if (id is null) return BadRequest("Invalid ID");//400
            var department = await _unitOfWork.DepartmentRepositry.GetAsync(id.Value);
            if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });


            var dto = new CreateDepartmentDto()
            {
                Name = department.Name,
                Code = department.Code,
                CreateAt = department.CreateAt,

            };

            return View (dto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task < IActionResult> Edit([FromRoute] int id, CreateDepartmentDto model)
        {



            if (ModelState.IsValid)
            {
                //  if (id != department.Id) return BadRequest();//400
                var department = new Department()
                {
                    Id=id,
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt,

                };

                 _unitOfWork.DepartmentRepositry.Update(department);
                var count = await _unitOfWork.CompleteAsync();
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
        public async Task< IActionResult> Delete (int? id)
        {

            if (id is null) return BadRequest("Invalid ID");//400
            var department = await _unitOfWork.DepartmentRepositry.GetAsync(id.Value);
            if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return await Details(id,"Delete");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task < IActionResult> Delete([FromRoute] int id, CreateDepartmentDto model)
        {



            if (ModelState.IsValid)
            {
                //  if (id != department.Id) return BadRequest();//400
                var department = new Department()
                {
                    Id = id,
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt

                    
                };


                 _unitOfWork.DepartmentRepositry.Delete(department);
                var count = await _unitOfWork.CompleteAsync();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(model);

        }
    }
}
