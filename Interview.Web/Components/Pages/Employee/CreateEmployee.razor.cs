using Blazored.Toast.Services;
using Interview.Model.Entities;
using Interview.Model.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Text.Json;
using Blazored.Toast.Services;


namespace Interview.Web.Components.Pages.Employee
{
    
    public partial class CreateEmployee
    {
        public EmployeeModel model = new();
        [Inject]
        public ApiClient ApiClient { get; set; }

        [Inject]
        private IToastService toastService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public EmployeeModel Model { get; set; } = new();

        public async Task Submit()
        {
            
            var res = await ApiClient.PostAsync<BaseResponseModel, EmployeeModel>("/api/employee", Model);
            if (res != null && res.success)
            {
                toastService.ShowSuccess("Employee add succssfully.");
                navigationManager.NavigateTo("/employee");
            }

        }   
        
        public List<DepartmentModel> departmentModel { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Department");
            if (res != null && res.success)
            {
                departmentModel = JsonSerializer.Deserialize<List<DepartmentModel>>(res.data.ToString());
            }

            await base.OnInitializedAsync();
        }
    }

    
}
