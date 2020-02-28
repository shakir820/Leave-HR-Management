using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.Models
{
    public class LeaveApprover
    {
        public long Id { get; set; }
        public DepartmentCatagory? Department { get; set; }
        public string Name { get; set; }
        public long EmployeeId { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
    }
}
