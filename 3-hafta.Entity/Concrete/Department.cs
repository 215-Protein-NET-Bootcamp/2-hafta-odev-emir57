using Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace _3_hafta.Entity.Concrete
{
    public class Department : IEntity
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
        public int CountryId { get; set; }

        //public Country Country { get; set; }
    }
}
