using Leave_HR_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.ViewModels
{
    public class LeaveApproverVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long EmployeeId { get; set; }
        public DepartmentCatagory? Department { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
    }
}
