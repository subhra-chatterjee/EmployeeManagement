using EmployeeInfo;

namespace EmployeeManagement.Components.Sevice
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllEmployee();
    }
}
