using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Model.Entities
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string departmentName { get; set; }

        public ICollection<EmployeeModel> Employee{ get; set; } =  new List<EmployeeModel>();
    }
}
