using EmployeeCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCoreProject.DbData
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }


        public DbSet<EmployeeModelClass> EmployeeTable { get; set; }
        public DbSet<DepartmentClass> DepartmentTable { get; set; }
        public DbSet<EmpLogin> LoginTable { get; set; }
    }
}
