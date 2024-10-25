using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FloraEmployeeInfo.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
        }

        public int DesignationId { get; set; }
        public int? DepartmentId { get; set; }
        public string DesignationName { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
