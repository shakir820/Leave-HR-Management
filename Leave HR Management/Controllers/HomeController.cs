using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Leave_HR_Management.Models;
using Microsoft.EntityFrameworkCore;
using Leave_HR_Management.ViewModels;

namespace Leave_HR_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AbcContext db;



        public HomeController(ILogger<HomeController> logger, AbcContext context)
        {
            _logger = logger;
            db = context;
        }






        public async Task<IActionResult> IndexAsync()
        {
            var Employees = new List<EmployeeVM>();

            var employees = await db.Employees.Include(a=>a.LeaveApprovers).Include(a => a.Departments).AsNoTracking().ToListAsync();
            //var leaveApprovers = await db.LeaveApprovers.Include(a => a.Employees).ToListAsync();
            //var leaveApproverEmployees = leaveApprovers.SelectMany(a => a.Employees).ToList();
            

            foreach (var employee in employees)
            {
                var employeeVM = new EmployeeVM();
                employeeVM.Departments = employee.Departments;


                employeeVM.Email = employee.Email;
                employeeVM.EmployeeRole = employee.EmployeeRole;
                employeeVM.FullName = employee.FirstName + " " + employee.LastName;
                employeeVM.Gender = employee.Gender;
                employeeVM.Id = employee.Id;
                employeeVM.LeaveApprovers = new List<LeaveApproverVM>();
                foreach (var item in employee.LeaveApprovers)
                {
                    employeeVM.LeaveApprovers.Add(new LeaveApproverVM { Id = item.Id, Name = item.Name });
                }
                employeeVM.PrimaryDepartment = employee.PrimaryDepartmentCatergory;
                Employees.Add(employeeVM);
            }
            return View(Employees);
        }



















        public async Task<IActionResult> SetLeaveApproverAsync(long? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var employee = await db.Employees.Include(a=>a.LeaveApprovers).AsNoTracking().FirstOrDefaultAsync(a=>a.Id == id);
            if(employee == null)
            {
                return NotFound();
            }

            var Employee = new EmployeeVM();
            Employee.Email = employee.Email;
            Employee.EmployeeRole = employee.EmployeeRole;
            Employee.FullName = employee.FirstName + " " + employee.LastName;
            Employee.PrimaryDepartment = employee.PrimaryDepartmentCatergory;
            Employee.LeaveApprovers = new List<LeaveApproverVM>();
            foreach(var item in employee.LeaveApprovers)
            {
                Employee.LeaveApprovers.Add(
                    new LeaveApproverVM
                    {
                        Id = item.Id,
                        Department = item.Department,
                        EmployeeId = item.EmployeeId,
                        EmployeeRole = item.EmployeeRole,
                        Name = item.Name
                    });
            }


            return View(Employee);
        }


        [HttpPost]
        public async Task<IActionResult> SetLeaveApproverAsync(SetEmployeeApproverVM formData)
        {
            if(formData != null)
            {
                var Employee = await db.Employees.Include(a => a.LeaveApprovers).FirstOrDefaultAsync(a => a.Id == formData.EmployeeId);
                var employeeLeaveApprovers = Employee.LeaveApprovers;
                //try
                //{
                //    foreach (var item in Employee.LeaveApprovers)
                //    {
                //        var leavApprover = await db.LeaveApprovers.FindAsync(item.Id);
                //        if (leavApprover != null)
                //        {
                //            db.LeaveApprovers.Remove(leavApprover);
                //            await db.SaveChangesAsync();
                //        }

                //    }
                //}
                //catch (Exception ex)
                //{

                //}



                try
                {
                    Employee.LeaveApprovers.Clear();
                    await db.SaveChangesAsync();

                }
                catch(Exception ex)
                {

                }


                var newEmployeeApprovers = formData.LeaveApprovers.Where(a => a.IsChecked == true); 

                foreach(var item in newEmployeeApprovers)
                {
                    var approver = new LeaveApprover();
                    if(item.Department > 0)
                    {
                        approver.Department = (DepartmentCatagory)Enum.Parse(typeof(DepartmentCatagory), item.Department.ToString());
                    }
                    approver.EmployeeId = item.EmployeeId;
                    if(item.EmployeeRole == 0)
                    {
                        approver.EmployeeRole = EmployeeRole.Company;
                    }
                    if (item.EmployeeRole == 1)
                    {
                        approver.EmployeeRole = EmployeeRole.Department;
                    }
                    if (item.EmployeeRole == 2)
                    {
                        approver.EmployeeRole = EmployeeRole.Employee;
                    }
                    approver.Name = item.Name;
                    db.LeaveApprovers.Add(approver);
                    await db.SaveChangesAsync();
                    Employee.LeaveApprovers.Add(approver);
                    await db.SaveChangesAsync();
                }


                return Json(new { isSuccess = true });
            }
            return Json(new { isSuccess = false });
        }



        public static EmployeeRole GetEmployeeRole(int i)
        {
            if (i == 1)
            {
                return EmployeeRole.Company;
            }
            if (i == 2)
            {
                return EmployeeRole.Department;
            }
            if (i == 3)
            {
                return EmployeeRole.Employee;
            }
            return EmployeeRole.Employee;
        }


        private DepartmentCatagory? GetDepartment(int? i)
        {
            if(i == null)
            {
                return null;
            }

            if (i == 1)
            {
                return DepartmentCatagory.HR;
            }
            if (i == 2)
            {
                return DepartmentCatagory.IT;
            }
            if (i == 3)
            {
                return DepartmentCatagory.Creative;
            }
            if (i == 4)
            {
                return DepartmentCatagory.Marketing;
            }
            if (i == 5)
            {
                return DepartmentCatagory.Sales;
            }
            else return DepartmentCatagory.Sales;
        }



        public async Task<IActionResult> GetEmployeesByEmployeeAsync()
        {
            var employees = await db.Employees.Include(a => a.Departments).
                Where(a => a.EmployeeRole == EmployeeRole.Employee).AsNoTracking().ToListAsync();
            return Json(employees);
        }


        public async Task<IActionResult> GetEmployeesByDepartment(int id)
        {
            var employees = await db.Employees.Include(a => a.Departments).AsNoTracking().ToListAsync();
            var departmentEmployees = new List<Employee>();
            foreach (var item in employees)
            {
                var doesExist = item.Departments.Any(a => a.Catagory == (DepartmentCatagory)Enum.Parse(typeof(DepartmentCatagory), id.ToString()));
                if (doesExist == true)
                {
                    departmentEmployees.Add(item);
                }
            }
            return Json(departmentEmployees);
        }


        public async Task<IActionResult> GetEmployeesByCompanyAsync()
        {
            var employees = await db.Employees.Include(a => a.Departments).
                Where(a => a.EmployeeRole == EmployeeRole.Company).AsNoTracking().ToListAsync();
            return Json(employees);
        }




        public async Task<IActionResult> GetLeaveApproversByEmployee(long id)
        {
            var employee = await db.Employees.Include(a => a.LeaveApprovers).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if(employee == null)
            {
                return null;
            }
            return Json(employee.LeaveApprovers);
        }
























        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
