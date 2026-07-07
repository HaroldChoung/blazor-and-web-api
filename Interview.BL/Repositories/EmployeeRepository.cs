using Interview.Database.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Interview.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interview.BL.Repositories
{
    public interface IEmployeeRepository
    {
        
        Task<List<EmployeeModel>> GetEmployees();
    }
    public class EmployeeRepository(AppDbContex dbContex): IEmployeeRepository
    {
        public Task<List<EmployeeModel>> GetEmployees()
        {
            return  dbContex.Employees.ToListAsync();
        }
    }
}
