using Interview.Database.Data;
using Interview.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.BL.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentModel>> GetDepartments();
    }

    public class DepartmentRepository(AppDbContex dbContex) : IDepartmentRepository
    {
        public Task<List<DepartmentModel>> GetDepartments()
        {
            return dbContex.Departments.ToListAsync();  
        }
    }
}
