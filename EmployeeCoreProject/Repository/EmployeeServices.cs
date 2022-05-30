using EmployeeCoreProject.DbData;
using EmployeeCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCoreProject.Repository
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly EmployeeContext _db;

        public EmployeeServices(EmployeeContext db)
        {
            _db = db;
        }

        public void delete(int Id)
        {
            var deleteitem = _db.EmployeeTable.Where(m => m.Id == Id).First();
            _db.EmployeeTable.Remove(deleteitem);
            _db.SaveChanges();

            //return _db.EmployeeTable.ToList();

        }


        public void Save(EmployeeModelClass obj)
        {
            if (obj.Id == 0)
            {
                _db.EmployeeTable.Add(obj);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(obj).State = EntityState.Modified;
                _db.SaveChanges();
            }

        }

      

        public List<EmployeeModelClass> TableShow()
        {
            //var res = _db.EmployeeTable.ToList();
            return _db.EmployeeTable.ToList();
        
        }

        public EmployeeModelClass Edit(EmployeeModelClass abj,int Id)
        {
            

           var edititem= _db.EmployeeTable.Where(m => m.Id == Id).FirstOrDefault();

            abj.Id = edititem.Id;
            abj.Name = edititem.Name;
            abj.Email = edititem.Email;
            abj.PhoneNo = edititem.PhoneNo;
            abj.Department = edititem.Department;

            return abj;
           
        }
    }
}
