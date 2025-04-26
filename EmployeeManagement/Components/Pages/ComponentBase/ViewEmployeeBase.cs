using EmployeeInfo;
using Microsoft.AspNetCore.Components;
using EmployeeManagement.Components.Sevice;

namespace EmployeeManagement.Components.Pages
{
    public class ViewEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService? EmployeeService { get; set; }

        protected Employee employee { get; set; } = new Employee();

        [Parameter]
        public int Id { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                employee = await EmployeeService.GetEmployeeById(Id);
            }
            else
            {
                employee = null;
            }
        }
        private void GoBack()
        {
            NavigationManager.NavigateTo("/employee-list");
        }
    }
}
