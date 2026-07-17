using Interview.BL.Services;
using Interview.Model.Entities;
using Interview.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace Interview.ApiService.Controller
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetEmployees()
        {
            var employees = await employeeService.GetEmployees();
            return Ok(new BaseResponseModel { success = true, data = employees });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetEmployee(int id)
        {
            var employee = await employeeService.GetEmployee(id);
            return Ok(new BaseResponseModel {success = true, data = employee });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateEmployee(EmployeeModel employeeModel)
        {
            var employee = await employeeService.CreateEmployee(employeeModel);
            return Ok(new BaseResponseModel { success = true, message="Create new employee successfully",data = employee });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponseModel>> UpdateEmployee(int id, EmployeeModel employeeModel)
        {
            if(id != employeeModel.id || !await employeeService.EmployeeModelExists(id))
            {
                return Ok(new BaseResponseModel { success = false, ErrorMessage = "bad request" });
            }
            else
            {
                await employeeService.UpdateEmployee(employeeModel);
                return Ok(new BaseResponseModel { success = true, message = "Update employee successfully" });
            }
                

        }
        [HttpDelete("{id}")] 
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (!await employeeService.EmployeeModelExists(id))
            {
                return Ok(new BaseResponseModel { success = false, ErrorMessage = "Not Found" });
            }
            await employeeService.DeleteEmployee(id);
            return Ok(new BaseResponseModel { success = true, message = "Delete employee successfully" });
        }
    }
}
