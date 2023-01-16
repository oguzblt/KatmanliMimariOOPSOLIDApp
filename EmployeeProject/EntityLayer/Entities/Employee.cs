using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(50)]
        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }
        public bool isActive { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }
    }
}
