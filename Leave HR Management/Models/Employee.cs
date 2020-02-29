using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsApprover { get; set; } = false;
        public DepartmentCatagory PrimaryDepartmentCatergory { get; set; }
        public List<Department> Departments { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public List<LeaveApprover> LeaveApprovers { get; set; }

    }






    public enum EmployeeRole
    {
        Company, 
        Department, 
        Employee
    }




    public enum Gender
    {
        Male, 
        Female
    }
}
