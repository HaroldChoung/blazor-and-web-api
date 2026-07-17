using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Model.Models;
using Interview.Model.Entities;
using System.Text.Json;
using Interview.Model.DTOs;
using Interview.Web.Components.BaseComponents;

//using Newtonsoft.Json;


namespace Interview.Web.Components.Pages.Employee
{
    public partial class IndexEmployee
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        
        public IndexEmployee()
        {

        }
        public List<EmployeeModel> employeeModel { get; set; }
        public AppModal Modal { get; set; }
        public int DeleteID { get; set; } = 0;
        protected override async Task OnInitializedAsync()
        {
            
            await base.OnInitializedAsync();
            await loadProduct();
        }
        protected async Task loadProduct()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("api/employee");
            if (res != null && res.success)
            {
                employeeModel = JsonSerializer.Deserialize<List<EmployeeModel>>(res.data.ToString());
            }
        }
        public async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/employee/{DeleteID}");
            if (res != null && res.success)
            {
                await loadProduct();
                Modal.Close();
            }

        }
    }
}
