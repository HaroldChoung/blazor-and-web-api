using Interview.Model.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Interview.Model.Entities
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }

        //public DepartmentModel DepartmentID { get; set; }
        
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

       public DepartmentModel department { get; set; }
        

    }
}
