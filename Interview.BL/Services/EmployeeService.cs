using Interview.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Interview.BL.Repositories;
using Interview.Model.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace Interview.BL.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployees();
        Task<EmployeeModel> GetEmployee(int id);
        Task<bool> EmployeeModelExists(int id);
        Task<EmployeeModel> CreateEmployee(EmployeeModel employee);
        Task UpdateEmployee(EmployeeModel employee);
        Task DeleteEmployee(int id);
    }
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var employees = await employeeRepository.GetEmployees();
            return employees;
        }
        public async Task<EmployeeModel> GetEmployee(int id)
        {
            var employee =  await employeeRepository.GetEmployee(id);
            return employee;
        }
        public Task<bool> EmployeeModelExists(int id)
        {
            return employeeRepository.EmployeeModelExists(id);
        }
        public Task<EmployeeModel> CreateEmployee(EmployeeModel employeeModel)
        {
            return employeeRepository.CreateEmployee(employeeModel);
        }
        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            await employeeRepository.UpdateEmployee(employeeModel);
        }
        public async Task DeleteEmployee(int id)
        {
            await employeeRepository.DeleteEmployee(id);
        }
    }
}
