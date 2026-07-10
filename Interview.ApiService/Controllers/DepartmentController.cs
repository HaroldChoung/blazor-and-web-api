using Interview.BL.Services;
using Interview.Model.Entities;
using Interview.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService departmentService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetDepartment()
        {
            var department = await departmentService.GetDepartments();
            return Ok(new BaseResponseModel { Success = true, Data = department });
        }
    }
}
