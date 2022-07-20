using Core.Entity;

namespace _3_hafta.Dto.Concrete
{
    public class CountryDto : IDto
    {
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string Currency { get; set; }
    }
}
