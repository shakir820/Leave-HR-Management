using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //[InverseProperty("Employees")]
        public Department PrimaryDepartment { get; set; }

        //[InverseProperty("Employees")]
        public List<Department> Departments { get; set; }
        public EmployeeRole EmployeeRole { get; set; }

        [InverseProperty("Employee")]
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
