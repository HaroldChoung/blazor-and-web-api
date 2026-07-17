using Interview.Database.Data;
using Interview.Model.DTOs;
using Interview.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview.BL.Repositories
{
    public interface IEmployeeRepository
    {
        
        Task<List<EmployeeDTO>> GetEmployees();
        Task<EmployeeModel> GetEmployee(int id);
        Task<bool> EmployeeModelExists(int id);
        Task<EmployeeModel> CreateEmployee(EmployeeModel employeeModel);
        Task UpdateEmployee(EmployeeModel employeeModel);
        Task DeleteEmployee(int id);
    }
    
    public class EmployeeRepository(AppDbContex dbContex): IEmployeeRepository
    {
        public Task<List<EmployeeDTO>> GetEmployees()
        {
            return dbContex.Employees.Include(e => e.department)
                .Select(e => new EmployeeDTO
                {
                    Id = e.id,
                    EmployeeName = e.employeeName,
                    Department = new DepartmentDTO
                    {
                        ID = e.department.id,
                        DepartmentName = e.department.departmentName
                    }
                })
                .ToListAsync();
        }
        public Task<EmployeeModel> GetEmployee(int id)
        {
            return dbContex.Employees.FirstOrDefaultAsync(e => e.id == id);

        }
        public Task<bool> EmployeeModelExists(int id)
        {
            return dbContex.Employees.AnyAsync(e => e.id == id);
        }
        public async Task<EmployeeModel> CreateEmployee(EmployeeModel employeeModel)
        {
            dbContex.Employees.Add(employeeModel);
            await dbContex.SaveChangesAsync();
            return employeeModel;
        }
        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            dbContex.Entry(employeeModel).State = EntityState.Modified;
            await dbContex.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            var employee = dbContex.Employees.FirstOrDefault(e => e.id == id);
            dbContex.Employees.Remove(employee);
            await dbContex.SaveChangesAsync();
        }


    }
}
