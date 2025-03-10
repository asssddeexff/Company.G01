﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G01.DAL.Data.Contexts;
using Company.G01.DAL.Models;
using Company.G02.BLL.Interfices;

namespace Company.G02.BLL.Repositres
{
    public class DepartmentRepositry : IDepartmentRepositry
    {
        private readonly CompanyDbContext _context;//Null
        //Ask CLR Create Object From CompanyDbContext
        public DepartmentRepositry(CompanyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetAll()
        {
            
            return _context.Departments.ToList();
        }
        public Department? Get(int id)
        {
            return _context.Departments.Find(id);
        }
        public int Add(Department model)
        {
         
             _context.Departments.Add(model);
            return _context.SaveChanges();
        }

        public int Update(Department model)
        {

           
            _context.Departments.Update(model);
            return _context.SaveChanges();
        }

        public int Delete(Department model)
        {

       
            _context.Departments.Remove(model);
            return _context.SaveChanges();
        }

     


        
    }
}
