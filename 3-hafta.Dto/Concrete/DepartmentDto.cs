using Core.Entity;

namespace _3_hafta.Dto.Concrete
{
    public class DepartmentDto : IDto
    {
        public string DeptName { get; set; }
        public int CountryId { get; set; }
    }
}
