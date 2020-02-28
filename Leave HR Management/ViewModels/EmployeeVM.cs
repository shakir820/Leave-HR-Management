using Leave_HR_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.ViewModels
{
    public class EmployeeVM
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public bool IsApprover { get; set; } = false;

        public string GenderStr { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DepartmentCatagory PrimaryDepartment { get; set; }
        public List<Department> Departments { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public List<LeaveApproverVM> LeaveApprovers { get; set; }
    }
}
