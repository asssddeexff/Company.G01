using AutoMapper;
using Company.G01.DAL.Models;
using Company.G01.PL.Dtos;

namespace Company.G01.PL.Mapping
{
    public class EmployeeProfile : Profile
    {
        //CLR
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDtos, Employee>().ForMember(d=>d.Name,o=>o.MapFrom(s=>s.Name));
            CreateMap<Employee,CreateEmployeeDtos>();
        }
    }
}
