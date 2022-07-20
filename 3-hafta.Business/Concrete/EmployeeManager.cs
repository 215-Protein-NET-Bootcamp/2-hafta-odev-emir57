using _3_hafta.Business.Abstract;
using _3_hafta.Business.Validation.FluentValidation;
using _3_hafta.DataAccess.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;

namespace _3_hafta.Business.Concrete
{
    public class EmployeeManager : BaseManager<Employee, EmployeeDto>, IEmployeeService
    {
        public EmployeeManager(IEmployeeDal entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }
        [ValidationAspect(typeof(EmployeeValidator))]
        public override Task<IResult> AddAsync(EmployeeDto entity)
        {
            return base.AddAsync(entity);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public override Task<IResult> UpdateAsync(int id, EmployeeDto entity)
        {
            return base.UpdateAsync(id, entity);
        }
    }
}
