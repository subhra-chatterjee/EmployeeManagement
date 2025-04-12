using EmployeeInfo;
using EmployeeManagement.Components.Sevice;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Components.Pages
{
    public class EditEpmloyeeBase: ComponentBase
    {
        [Inject]
        public IEmployeeService? EmployeeService { get; set; }

        protected Employee employee { get; set; } = new Employee();
        protected string Title = "Add";

        [Parameter]
        public int Id { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }

        
        protected Dictionary<string, object> dateAttributes = new()
    {
        { "min", "1990-01-01" },
        { "max", DateTime.Today.ToString("yyyy-MM-dd") }
    };
        protected override async Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                Title = "Edit";
                employee = await EmployeeService.GetEmployeeById(Id);
            }

        }

        protected async Task HandleValidSubmit()
        {
            Console.WriteLine($"FirstName: {employee.FirstName}");
            Console.WriteLine($"Salary: {employee.Salary}");
            if (employee?.EmployeeID != 0)
            {
                await EmployeeService.UpdateEmployee(employee);
                
            }
            else
            {
                await EmployeeService.AddEmployee(employee);

            }
            Navigation.NavigateTo("/employee-list");
        }

    }
}
