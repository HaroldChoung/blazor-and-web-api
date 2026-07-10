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
    }
    
    public class EmployeeRepository(AppDbContex dbContex): IEmployeeRepository
    {
        public Task<List<EmployeeDTO>> GetEmployees()
        {
            return dbContex.Employees.Include(e => e.department)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    EmployeeName = e.EmployeeName,
                    Department = new DepartmentDTO
                    {
                        ID = e.department.Id,
                        DepartmentName = e.department.departmentName
                    }
                })
                .ToListAsync();

        }
    }
}
