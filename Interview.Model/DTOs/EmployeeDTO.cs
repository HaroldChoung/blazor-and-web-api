using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Model.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
