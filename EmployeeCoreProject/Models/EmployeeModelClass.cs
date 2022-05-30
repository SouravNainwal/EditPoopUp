using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCoreProject.Models
{
    public class EmployeeModelClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

     
        
        public string Email { get; set; }

       
        [RegularExpression(@"^\(?([6-9]{1})\)?([0-9]{9})$",
                  ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNo {get; set;}
        //public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public string Department  { get; set; }
    }
}
