using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Leave_HR_Management.Controllers
{
    public class EmployeeController : Controller
    {
        

        public IActionResult Index()
        {
            
            return View();
        }
    }
}