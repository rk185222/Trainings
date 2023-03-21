using EmployeeManagement.API.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() 
        {
            try
            {
                var emps = await employeeRepository.GetEmployees();
                return Ok(emps);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting employees details");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var emp = await employeeRepository.GetEmployee(id);
                return Ok(emp); 
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting employee details");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeToUpdate = await employeeRepository.GetEmployee(employee.EmployeeId);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {employee.EmployeeId} not found");

                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee details");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var empToDelete = await employeeRepository.GetEmployee(id);

            if(empToDelete  == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            await employeeRepository.DeleteEmployee(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                 
                var emp = (await employeeRepository.GetEmployees()).Where(x=>x.Email == employee.Email);

                if (emp != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

    }
}
