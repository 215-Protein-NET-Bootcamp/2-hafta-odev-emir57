using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using AutoMapper;

namespace _3_hafta.Business.Mapper
{
    public class BusinessMapper : Profile
    {
        public BusinessMapper()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Folder, FolderDto>().ReverseMap();
        }
    }
}
