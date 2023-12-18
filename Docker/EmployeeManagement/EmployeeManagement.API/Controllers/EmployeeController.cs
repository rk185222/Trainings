using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeRepository.GetEmployee(id);
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            return employeeRepository.GetEmployees().ToList();
        }

        [HttpPost]
        public Employee AddEmployee(Employee emp)
        {
            return employeeRepository.Add(emp);
        }
    }
}
