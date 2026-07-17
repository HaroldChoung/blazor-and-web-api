using Interview.Model.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Interview.Model.Entities
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string employeeName { get; set; }

        //public DepartmentModel DepartmentID { get; set; }
        
        [ForeignKey("Department")]
        public int departmentID { get; set; }

        public virtual DepartmentModel department { get; set; }
        

    }
}
