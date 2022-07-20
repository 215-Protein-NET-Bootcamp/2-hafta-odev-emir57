using _3_hafta.Business.Abstract;
using _3_hafta.Business.Constants;
using _3_hafta.Business.Validation.FluentValidation;
using _3_hafta.DataAccess.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;

namespace _3_hafta.Business.Concrete
{
    public class DepartmentManager : BaseManager<Department, DepartmentDto>, IDepartmentService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICountryService _countryService;
        public DepartmentManager(IDepartmentDal entityRepository, IMapper mapper, IEmployeeService employeeService, ICountryService countryService) : base(entityRepository, mapper)
        {
            _employeeService = employeeService;
            _countryService = countryService;
        }
        [ValidationAspect(typeof(DepartmentValidator))]
        public override Task<IResult> AddAsync(DepartmentDto entity)
        {
            return base.AddAsync(entity);
        }

        public async Task<IDataResult<List<DepartmentCountryDto>>> GetDepartmentsByEmployeeIdAsync(int employeeId)
        {
            var employee = await _employeeService.GetByIdAsync(employeeId);
            if (employee.Success == false)
                return new ErrorDataResult<List<DepartmentCountryDto>>(BusinessMessages.NotFoundEntity);

            var departments = await _entityRepository.GetAllAsync();
            List<Department> employeeDepartments = departments.Where(x => x.DepartmentId == employee.Data?.DeptId)?.ToList();
            List<DepartmentCountryDto> departmentsCountry = getDepartmentsWithCountry(employeeDepartments).ToList();

            return new SuccessDataResult<List<DepartmentCountryDto>>(departmentsCountry);
        }

        private IEnumerable<DepartmentCountryDto> getDepartmentsWithCountry(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                CountryDto country = _countryService.GetByIdAsync(department.CountryId).Result.Data;
                yield return new DepartmentCountryDto
                {
                    CountryName = country.CountryName,
                    Continent = country.Continent,
                    Currency = country.Currency,
                    DeptName = department.DeptName
                };
            }
        }

        [ValidationAspect(typeof(DepartmentValidator))]
        public override Task<IResult> UpdateAsync(int id, DepartmentDto entity)
        {
            return base.UpdateAsync(id, entity);
        }
    }
}
