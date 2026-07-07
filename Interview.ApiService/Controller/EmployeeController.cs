using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Interview.Model.Models;
using System.Security.Cryptography.Xml;
using Interview.BL.Services;

namespace Interview.ApiService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetEmployees()
        {
            var employees = await employeeService.GetEmployees();
            return Ok(new BaseResponseModel { Success = true, Data = employees });
        }

    }
}
