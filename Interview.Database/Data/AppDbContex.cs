using Microsoft.EntityFrameworkCore;
using Interview.Model.Entities;


using System;
using System.Collections.Generic;
using System.Text;


namespace Interview.Database.Data
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<EmployeeModel> Employees
        {
            get; set;
        }
    }
}
