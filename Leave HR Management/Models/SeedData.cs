using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.Models
{
    public static class SeedData
    {
        public static async void Initialize()
        {

            using (var context = new AbcContext())
            {
                if (context.Employees.Any())
                {
                    return;
                }

                //var random = new Random();
                for(var i = 0; i < 100; i++)
                {

                    var departments = new List<Department>();
                    var random = new Random();
                    var randomValue = random.Next(1, 6);
                    for (var j = 1; j <= randomValue; j++)
                    {
                        var department = new Department();
                        department.Name = "Department" + i;
                        department.Catagory = GetDepartmentCategory(j);
                        context.Departments.Add(department);
                        await context.SaveChangesAsync();
                        departments.Add(department);
                    }


                    var employee = new Employee();
                    employee.Email = "employee" + (i + 1) + "@gmail.com";
                    employee.EmployeeRole = GetEmployeeRole();
                    employee.FirstName = "Employee" + (i + 1);
                    employee.LastName = "Surname";
                    employee.Password = "123456";
                    //employee.Departments = new List<Department>();
                    if(i%2 == 0)
                    {
                        employee.Gender = Gender.Male;
                    }
                    else
                    {
                        employee.Gender = Gender.Female;
                    }
                  
                    //var randomValue = random.Next(1, 6);
                    employee.PrimaryDepartmentCatergory = GetDepartmentCategory(randomValue);
                    //await context.SaveChangesAsync();

                    //employee = await context.Employees.Include(a=>a.Departments).SingleOrDefaultAsync(a=>a.Id == employee.Id);
                    employee.Departments = new List<Department>();

                    foreach (var item in departments)
                    {
                        employee.Departments.Add(item);
                    }
                    //for (var j = 1; i <= randomValue; i++)
                    //{
                    //    var department = new Department();
                    //    department.Name = "Department" + i;
                    //    department.Catagory = GetDepartmentCategory(randomValue);
                    //    context.Departments.Add(department);
                    //    await context.SaveChangesAsync();
                    //    //employee = await context.Employees.Include(a => a.Departments).SingleOrDefaultAsync(a => a.Id == employee.Id);
                    //    employee.Departments.Add(department);
                    //    //await context.SaveChangesAsync();
                    //}
                    context.Employees.Add(employee);
                    await context.SaveChangesAsync();
                }
            }
        }


        private static DepartmentCatagory GetDepartmentCategory(int i)
        {
            if(i == 1)
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



        //private static async Task<List<Department>> GetDepartmentsAsync(AbcContext context)
        //{
        //    var random = new Random();
        //    var randomNumber = random.Next(1, 6);
        //    if (randomNumber == 1)
        //    {
        //        var departments = await context.Departments.Include(a=>a.Employees).Take(randomNumber).ToListAsync();
              
        //        return departments;
        //    }
        //    if (randomNumber == 2)
        //    {
        //        var departments = await context.Departments.Include(a=>a.Employees).Take(randomNumber).ToListAsync();
              
        //        return departments;
        //    }
        //    if (randomNumber == 3)
        //    {
        //        var departments = await context.Departments.Include(a=>a.Employees).Take(randomNumber).ToListAsync();
                
        //        return departments;
        //    }
        //    if (randomNumber == 4)
        //    {
        //        var departments = await context.Departments.Include(a=>a.Employees).Take(randomNumber).ToListAsync();
               
        //        return departments;
        //    }
        //    else
        //    {
        //        var departments = await context.Departments.Include(a=>a.Employees).Take(randomNumber).ToListAsync();
               
        //        return departments;
        //    }

        //}



        //private static async Task<Department> GetPrimaryDepartmentAsync(AbcContext context)
        //{
        //    var random = new Random();
        //    var randomNumber = random.Next(1, 6);
        //    if (randomNumber == 1)
        //    {
        //        var department = await context.Departments.Include(a=>a.Employees).FirstOrDefaultAsync(a => a.Name == "IT");
        //        return department;
        //    }
        //    if (randomNumber == 2)
        //    {
        //        var department = await context.Departments.Include(a => a.Employees).FirstOrDefaultAsync(a => a.Name == "HR");
        //        return department;
        //    }
        //    if (randomNumber == 3)
        //    {
        //        var department = await context.Departments.Include(a => a.Employees).FirstOrDefaultAsync(a => a.Name == "Sales");
        //        return department;
        //    }
        //    if (randomNumber == 4)
        //    {
        //        var department = await context.Departments.Include(a => a.Employees).FirstOrDefaultAsync(a => a.Name == "Marketing");
        //        return department;
        //    }
        //    else
        //    {
        //        var department = await context.Departments.Include(a => a.Employees).FirstOrDefaultAsync(a => a.Name == "Creative");
        //        return department;
        //    }
            
        //}

        public static EmployeeRole GetEmployeeRole()
        {
            var random = new Random();
            var randomNumber = random.Next(1, 4);
            if(randomNumber == 1)
            {
                return EmployeeRole.Company;
            }
            if(randomNumber == 2)
            {
                return EmployeeRole.Department;
            }
            if(randomNumber == 3)
            {
                return EmployeeRole.Employee;
            }
            return EmployeeRole.Employee;
        }
    }
}
