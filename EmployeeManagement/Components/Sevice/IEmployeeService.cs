using EmployeeInfo;

namespace EmployeeManagement.Components.Sevice
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllEmployee();
        public Task<Employee> GetEmployeeById(int id);
        public Task<Employee> UpdateEmployee(Employee employee);
        public Task<Employee> AddEmployee(Employee employee);
        public Task<bool> DeleteEmployee(int Id);
    }
}
