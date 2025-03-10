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
    public class GenericRepositry<T> : IGenericRepositry<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenericRepositry(CompanyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Add(T model)
        {
           _context.Set<T>().Add(model);
            return _context.SaveChanges();
        }

        public int Update(T model)
        {

            _context.Set<T>().Update(model);
            return _context.SaveChanges();
        }
        public int Delete(T model)
        {

            _context.Set<T>().Remove(model);
            return _context.SaveChanges();
        }

      
       

      
    }
}
