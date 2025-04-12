using EmployeeInfo;
using EmployeeWebService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var res = await employeeService.GetAllEmployee();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                var res = await employeeService.AddEmployee(employee);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Employee>> GetEmployeById(int Id)
        {
            try
            {
                var res = await employeeService.GetEmployeeById(Id);
                if (res == null)
                    return NotFound();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                var res = await employeeService.UpdateEmployee(employee,employee.EmployeeID);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteEmployee(int Id)
        {
            try
            {
                var res=employeeService.DeleteEmployee(Id);
                return Ok(res);

            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
