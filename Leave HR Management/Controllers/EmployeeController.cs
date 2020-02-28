using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leave_HR_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leave_HR_Management.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly AbcContext db;

        public EmployeeController(AbcContext abcContext)
        {
            db = abcContext;
        }




        public IActionResult Index()
        {
            
            return View();
        }






        public async Task<IActionResult> GetDepartments()
        {


            var departments = await db.Departments.ToListAsync();
            return Json(departments);
        }






    }
}