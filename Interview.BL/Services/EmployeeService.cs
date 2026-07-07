using Interview.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interview.BL.Repositories;

namespace Interview.BL.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetEmployees();
    }
    public class EmployeeService(IEmployeeRepository employeeRepositoty) : IEmployeeService
    {
        public Task<List<EmployeeModel>> GetEmployees()
        {
            return employeeRepositoty.GetEmployees();
        }
    }
}
