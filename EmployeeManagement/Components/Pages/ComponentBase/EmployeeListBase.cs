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

        protected override async Task OnInitializedAsync()
        {
            
            Employees = await EmployeeService.GetAllEmployee();
           
        }
        
    }
    }
