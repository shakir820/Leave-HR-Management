using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_HR_Management.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //public bool? IsPrimary { get; set; }

        [InverseProperty("PrimaryDepartment")]
        public List<Employee> Employees { get; set; }

        public List<LeaveApprover> LeaveApprovers { get; set; }
    }
}
