using EmployeeCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCoreProject.Repository
{
    public interface IEmployeeServices
    {
        List<EmployeeModelClass> TableShow();
        void delete(int Id);
         void Save(EmployeeModelClass obj);
        EmployeeModelClass Edit(EmployeeModelClass abj,int Id);
      
    }
}
