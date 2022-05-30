using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCoreProject.Models
{
    public class DepartmentClass
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Department { get; set; }
    }
}
