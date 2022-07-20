using Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace _3_hafta.Entity.Concrete
{
    public class Employee : IEntity
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }
        //public Folder Folder { get; set; }
    }
}
