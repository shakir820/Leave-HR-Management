using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leave_HR_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leave_HR_Management.Controllers
{
    public class LoginController : Controller
    {



        public IActionResult Index()
        {
            ViewData.Add("InLoginPage", true);

            return View();
        }


        public IActionResult Registration()
        {
            ViewData.Add("InRegistrationPage", true);

            return View();
        }




        public IActionResult LoginUser(Employee employee)
        {
            using (var db = new AbcContext())
            {
                if (!db.Employees.Any())
                {
                    return Json(new { UserExist = false , LoginSuccess = false });
                }

                var Employee = db.Employees.FirstOrDefault(a => a.Email == employee.Email);
                
                if(Employee == null)
                {
                    return Json(new { UserExist = false , LoginSuccess = false });
                }

                if(Employee.Password == employee.Password)
                {
                    return Json(new { LoginSuccess = true, UserExist = true });
                }
                else
                {
                    return Json(new { LoginSuccess = false, UserExist = true });
                }
            }
        } 
    }
}