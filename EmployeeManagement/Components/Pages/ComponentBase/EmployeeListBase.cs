using EmployeeInfo;
using EmployeeManagement.Components.Sevice;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Components.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService? EmployeeService { get; set; }
        protected IEnumerable<Employee>? Employees { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            Employees = await EmployeeService.GetAllEmployee();
           
        }

        protected async Task Delete_Button(int employeeId)
        {
            // Delete the employee with the given EmployeeId
            await EmployeeService.DeleteEmployee(employeeId);

            // Refresh the employee list after deletion
            Employees = await EmployeeService.GetAllEmployee();

            // Navigate to the employee list page if needed
            Navigation.NavigateTo("/employee-list", forceLoad: true);

        }

    }
    }
