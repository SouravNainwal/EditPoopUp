using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCoreProject.Models
{
    public class EmpLogin
    {
        [Key]

        public int EmpId { get; set; }
        [Required(ErrorMessage = "Valid Email Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the password")]
        public string Password { get; set; }
    }
}
