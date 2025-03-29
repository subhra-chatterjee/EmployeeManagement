using EmployeeInfo;

namespace EmployeeWebService.Service
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllEmployee();
        public Task<Employee> AddEmployee(Employee employee);
        public Task<Employee> GetEmployeeById(int Id);
        public Task<Employee> UpdateEmployee(Employee employee,int Id);
        public bool DeleteEmployee(int Id);
    }
}
