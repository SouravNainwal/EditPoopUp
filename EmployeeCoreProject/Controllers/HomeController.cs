using EmployeeCoreProject.DbData;
using EmployeeCoreProject.Models;
using EmployeeCoreProject.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeCoreProject.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEmployeeServices _EmployeeServices;
        public HomeController(IEmployeeServices _EmployeeServices)
        {
            this._EmployeeServices = _EmployeeServices;
        }


        [Authorize]
      
        public IActionResult Table()
        {
            var res=_EmployeeServices.TableShow();
            return View(res);
        }

        [Authorize]
        //[Route("Homw/GetData") ]
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form(EmployeeModelClass obj)
        {
            _EmployeeServices.Save(obj);
            return RedirectToAction("Table");
        }

        [Authorize]
        public IActionResult Delete(int Id)
        {
            
            _EmployeeServices.delete(Id);

            return RedirectToAction("Table");
        }

        public JsonResult GetbyID(int ID)
        {
            var Employee = _EmployeeServices.TableShow().Find(x => x.Id.Equals(ID));
            return Json(Employee);
        }

        //[Authorize]
        //public void Update(EmployeeModelClass obj)
        //{
        //    _EmployeeServices.Save(obj);

        //}
        [AcceptVerbs("Post")]
        public JsonResult Update(EmployeeModelClass emp)
        {
            _EmployeeServices.Save(emp);
            return Json("Success");
        }


    }
}
