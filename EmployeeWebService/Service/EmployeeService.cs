using EmployeeInfo;
using EmployeeWebService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeWebService.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeService(AppDbContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                var res = await _appDbContext.Employees.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool DeleteEmployee(int Id)
        {
            try
            {
                var data =  _appDbContext.Employees.FirstOrDefault(x => x.EmployeeID == Id);
                if (data is null)
                    return false;
                _appDbContext.Employees.Remove(data);

                _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            try
            {
                var data =await _appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == Id);
                if (data == null)
                    return null;

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee, int Id)
        {
            try
            {
                // Retrieve the employee by ID
                var existingEmployee = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == Id);

                if (existingEmployee == null)
                {
                    return null; // Return null if employee doesn't exist
                }

                // Update the fields
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Email = employee.Email;
                existingEmployee.Position = employee.Position;
                existingEmployee.Department = employee.Department;
                existingEmployee.IsActive = employee.IsActive;
                existingEmployee.DateOfJoining = employee.DateOfJoining;
                existingEmployee.PhoneNumber = employee.PhoneNumber;
                existingEmployee.Salary = employee.Salary;

                // Save the updated entity
               var res = _appDbContext.Employees.Update(existingEmployee);
                await _appDbContext.SaveChangesAsync();
                return existingEmployee; // Return the updated employee
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null; // Return null in case of an error
            }
        }

    }
}
