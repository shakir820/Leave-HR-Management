using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.Models
{
    public class LeaveApprover
    {
        public long Id { get; set; }
        public Employee Employee { get; set; }
    }
}
