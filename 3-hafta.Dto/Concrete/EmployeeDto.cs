using Core.Entity;

namespace _3_hafta.Dto.Concrete
{
    public class EmployeeDto : IDto
    {
        public string EmpName { get; set; }
        public int DeptId { get; set; }
    }
}
