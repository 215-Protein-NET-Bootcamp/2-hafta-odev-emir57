using Core.Entity;

namespace _3_hafta.Dto.Concrete
{
    public class DepartmentCountryDto : IDto
    {
        public string DeptName { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string Currency { get; set; }
    }
}
