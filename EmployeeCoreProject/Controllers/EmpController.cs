using EmployeeCoreProject.DbData;
using EmployeeCoreProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeCoreProject.Controllers
{
    public class EmpController : Controller
    {

        private readonly EmployeeContext _db;

        public EmpController(EmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(EmpLogin objUser)
        {
            var res = _db.LoginTable.Where(a => a.Email == objUser.Email && a.Password==objUser.Password).FirstOrDefault();

            if (res == null)
            {

                TempData["Invalid"] = "Invalid crendiential";
                return View("Login");
            }
            else
            {
                
                    var claims = new[] { /*new Claim(ClaimTypes.Name, res.Name),*/
                                        new Claim(ClaimTypes.Email, res.Email),
                    
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    authProperties);

                    //HttpContext.Session.SetString("Name", objUser.Email);

                    return RedirectToAction("Table", "Home");              

                
            }           
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(EmpLogin abc)
        {

            _db.LoginTable.Add(abc);
            _db.SaveChanges();

            return RedirectToAction("Login");
        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return View("Login");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModelClass = await _db.EmployeeTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeModelClass == null)
            {
                return NotFound();
            }

            return View(employeeModelClass);
        }
    }
}
