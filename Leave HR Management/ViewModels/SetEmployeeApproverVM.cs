using Leave_HR_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.ViewModels
{
    public class SetEmployeeApproverVM
    {
        public long EmployeeId { get; set; }
        public int EmployeeRole { get; set; }
        public int? Department { get; set; }

        public List<LeaveApprover> LeaveApprovers { get; set; }
    }
}
