using Interview.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interview.BL.Repositories;
using Interview.Model.DTOs;

namespace Interview.BL.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployees();
    }
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public Task<List<EmployeeDTO>> GetEmployees()
        {
            return employeeRepository.GetEmployees();
        }
    }
}
