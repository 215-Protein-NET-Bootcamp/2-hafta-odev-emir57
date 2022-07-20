using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Core.Utilities.Result;

namespace _3_hafta.Business.Abstract
{
    public interface IDepartmentService : IBaseService<Department, DepartmentDto>
    {
        Task<IDataResult<List<DepartmentCountryDto>>> GetDepartmentsByEmployeeIdAsync(int employeeId);
    }
}
