using System;
using System.Collections.Generic;
using System.Text;
using Interview.BL.Repositories;
using Interview.Model.Entities;
using Interview.Model.Models;

namespace Interview.BL.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentModel>> GetDepartments();
        //Task<DepartmentModel> GetDepartmentById(int id);
        //Task<DepartmentModel> AddDepartment(DepartmentModel department);
        //Task<DepartmentModel> UpdateDepartment(DepartmentModel department);
        //Task<bool> DeleteDepartment(int id);
    }

    public class DepartmentService(IDepartmentRepository DepartmentRepository) : IDepartmentService
    {
        public Task<List<DepartmentModel>> GetDepartments()
        {
            return DepartmentRepository.GetDepartments();
        }
    }

}