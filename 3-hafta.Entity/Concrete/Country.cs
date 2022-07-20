using Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace _3_hafta.Entity.Concrete
{
    public class Country : IEntity
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string Currency { get; set; }

        //public ICollection<Department> Departments { get; set; }
    }
}
