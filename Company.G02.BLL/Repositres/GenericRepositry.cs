﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G01.DAL.Data.Contexts;
using Company.G01.DAL.Models;
using Company.G02.BLL.Interfices;
using Microsoft.EntityFrameworkCore;

namespace Company.G02.BLL.Repositres
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenericRepositry(CompanyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>>GetAllAsync()
        {
            if(typeof(T)== typeof(Employee))
            {
                return (IEnumerable<T>)  await _context.Employees.Include(E=>E.Department).ToListAsync();
            }
            return await _context.Set<T>().ToListAsync();
        }
        public async Task< T?> GetAsync(int id)
        {
            if (typeof(T) == typeof(Employee))
            {
                return await _context.Employees.Include(E => E.Department).FirstOrDefaultAsync(E=>E.Id== id) as T;
            }
            return _context.Set<T>().Find(id);
        }

        public async Task  AddAsync(T model)
        {
          await _context.Set<T>().AddAsync(model);
           
        }

        public void Update(T model)
        {

            _context.Set<T>().Update(model);
            
        }
        public void Delete(T model)
        {

            _context.Set<T>().Remove(model);
            
        }

        //public IEnumerable<T> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
