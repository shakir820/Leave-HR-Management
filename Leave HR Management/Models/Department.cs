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
        public DepartmentCatagory Catagory { get; set; }
        public string Name { get; set; }
    }


    public enum DepartmentCatagory
    {
        HR = 1,
        IT = 2,
        Creative = 3,
        Marketing = 4,
        Sales = 5
    }
}
