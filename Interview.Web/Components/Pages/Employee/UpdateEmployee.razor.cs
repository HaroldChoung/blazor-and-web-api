using Blazored.Toast.Services;
using Interview.Model.Entities;
using Interview.Model.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Blazored.Toast.Services;


namespace Interview.Web.Components.Pages.Employee
{
    public partial class UpdateEmployee : ComponentBase
    {
        [Parameter]
        public int ID { get; set; }
        public EmployeeModel Model { get; set; } = new();
        public List<DepartmentModel> departmentModel { get; set; } = new();

        [Inject]
        private ApiClient apiClient { get; set; }
        [Inject]
        private IToastService toastService { get; set; }
        [Inject]
        private NavigationManager navigationManager { get; set; } 
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await apiClient.GetFromJsonAsync<BaseResponseModel>("api/Department");
            if(res != null && res.success)
            {
                departmentModel = JsonSerializer.Deserialize<List<DepartmentModel>>(res.data.ToString());
            }
            
            var res1 = await apiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Employee/{ID}");
            if (res1 != null && res1.success)
            {
                Model = JsonSerializer.Deserialize<EmployeeModel>(res1.data.ToString());
                Console.WriteLine(Model);
            }
        }

        private async Task Submit()
        {
            var res = await apiClient.UpdateAsync<BaseResponseModel, EmployeeModel>($"/api/employee/{ID}",Model);
            Console.WriteLine($"res Response: {JsonSerializer.Serialize(res)}");
            if (res != null && res.success)
            {
                toastService.ShowSuccess("Employee add succssfully.");
                navigationManager.NavigateTo("/employee");
            }
        }
    }
}
