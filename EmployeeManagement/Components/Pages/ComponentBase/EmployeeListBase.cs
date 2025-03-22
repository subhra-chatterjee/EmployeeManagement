using EmployeeInfo;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Components.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        protected List<Employee> Employees { get; set; }

        protected override void OnInitialized()
        {
            LoadEmployee();
            base.OnInitialized();
        }
        public void LoadEmployee()
        {
            Employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    Department = "HR",
                    Position = "Manager",
                    Salary = 60000,
                    DateOfJoining = new DateTime(2020, 5, 1),
                    IsActive = true
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "987-654-3210",
                    Department = "IT",
                    Position = "Developer",
                    Salary = 80000,
                    DateOfJoining = new DateTime(2021, 6, 15),
                    IsActive=true
                }
            };
        }
    }
    }
