using AutoMapper;
using Company.G01.DAL.Models;
using Company.G01.PL.Dtos;
using Company.G01.PL.Helpers;
using Company.G02.BLL.Interfices;
using Microsoft.AspNetCore.Mvc;

namespace Company.G01.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IEmployeeRepositry _employeeRepositry;
        //private readonly IDepartmentRepositry _departmentRepositry;
        private readonly IMapper _mapper;

        //Ask Clr Create Object From DepartmentRepositry
        public EmployeeController(
            //IEmployeeRepositry employeeRepositry,
            //IDepartmentRepositry departmentRepositry,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            //    _employeeRepositry = employeeRepositry;
            //    _departmentRepositry = departmentRepositry;
            _mapper = mapper;
        }
        [HttpGet] // Get: Department/Index
        public async Task < IActionResult> Index(string?SearchInput)

        {
            IEnumerable<Employee> employees;
            if(string.IsNullOrEmpty(SearchInput))
            {
                 employees = await _unitOfWork.EmployeeRepositry.GetAllAsync();
            }
            else
            {
                 employees = await _unitOfWork.EmployeeRepositry.GetByNameAsync(SearchInput);
            }

          
            //Dictionary:3 Property
            //1.ViewData:Transafer Extra Information From Controller (Action) To View

            //ViewData["Message"] = "Hello From ViewData";


            //2.ViewBag :Transafer Extra Information From Controller (Action) To View

           // ViewBag.Message = "Hello From ViewBag";
            //3.TempData
            return View(employees);
          
        }
        [HttpGet]
        public async Task< IActionResult> Create()
        {
            var departments = await _unitOfWork.DepartmentRepositry.GetAllAsync();
            ViewData["departments"] = departments;
            return View();
        }

        [HttpPost]
        public async Task< IActionResult >Create(CreateEmployeeDtos model)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                if(model.Image is not null)
                {
                   model.ImageName = DocumentSettings.UploadFile(model.Image, "images");
                }
               
              



            
                var employee = _mapper.Map<Employee>(model);
                   await  _unitOfWork.EmployeeRepositry.AddAsync(employee);
                   var Count = await _unitOfWork.CompleteAsync();
                    if (Count > 0)
                    {
                        TempData["Message"] = "Employee Is Created!!";
                        return RedirectToAction(nameof(Index));
                    }
                

            }
            return View(model);
        }


        [HttpGet]
        public async Task< IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest("Invalid ID");//400
            var employee = await _unitOfWork.EmployeeRepositry.GetAsync(id.Value);
            if (employee is null) return NotFound(new { statusCode = 400, message = $"Employee With Id{id}is Not Found" });
       
            return View(employee);
        }

        [HttpGet]
        public async Task< IActionResult> Edit(int? id)
        {
            var departments = await _unitOfWork.DepartmentRepositry.GetAllAsync();
            ViewData["departments"] = departments;
            if (id is null) return BadRequest("Invalid ID");//400
            var employee = await _unitOfWork.EmployeeRepositry.GetAsync(id.Value);
            if (employee is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            var employeeDto = new CreateEmployeeDtos()
            {
                
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                CreateAt = employee.CreateAt,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                IsActive = employee.IsActive,
                IsDeleted = employee.IsDeleted,
                Phone = employee.Phone,
                Salary = employee.Salary,

            };

            return View(employeeDto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit([FromRoute] int id, CreateEmployeeDtos model,string ViewName ="Edit")
        {



            if (ModelState.IsValid)
            {
                if(model.ImageName is not null&& model.Image is not null)
                {
                    DocumentSettings.DeleteFile(model.ImageName, "images");
                }
              if(model.Image is not null)
                {
                   model.ImageName = DocumentSettings.UploadFile(model.Image, "images");
                }
                //if (id != model.Id) return BadRequest();//400
                //var employee = new Employee()
                //{
                //    Id=id,
                //    Name = model.Name,
                //    Address = model.Address,
                //    Age = model.Age,
                //    CreateAt = model.CreateAt,
                //    HiringDate = model.HiringDate,
                //    Email = model.Email,
                //    IsActive = model.IsActive,
                //    IsDeleted = model.IsDeleted,
                //    Phone = model.Phone,
                //    Salary = model.Salary,
                //    DepartmentId = model.DepartmentId,

                //};

                var employee= _mapper.Map<Employee>(model);
                employee.Id = id;   
                _unitOfWork.EmployeeRepositry.Update(employee);
                var count = await _unitOfWork.CompleteAsync();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(ViewName,model);

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
        public async Task< IActionResult >Delete(int? id)
        {

            //if (id is null) return BadRequest("Invalid ID");//400
           // var department = await _unitOfWork.DepartmentRepositry.GetAsync(id.Value);
           // if (department is null) return NotFound(new { statusCode = 400, message = $"Department With Id{id}is Not Found" });
            return await Details(id, "Delete");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task < IActionResult> Delete([FromRoute] int id, CreateEmployeeDtos model)
        {



            if (ModelState.IsValid)
            {
              //  if (id != model.Id) return BadRequest();//400
              var employee = _mapper.Map<Employee>(model);
                employee.Id = id;


                 _unitOfWork.EmployeeRepositry.Delete(employee);
                var count = await _unitOfWork.CompleteAsync();
                if (count > 0)
                {
                    if (model.ImageName is not null)
                    {
                        DocumentSettings.DeleteFile(model.ImageName, "images");
                    }
                    return RedirectToAction(nameof(Index));
                }



            }

            return View(model);

        }
    }
}
