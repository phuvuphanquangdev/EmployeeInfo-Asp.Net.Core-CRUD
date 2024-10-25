using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FloraEmployeeInfo.Models
{
    public partial class Employee
    {
        public int EployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
