
using System.Xml.Linq;

namespace EmployeeManagement.API.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>();

            _employees.Add(new Employee()
            {
                Id = 1,
                Name = "Test",
                Email = "Test1@gmail.com",
                Department = Dept.IT
            });
            _employees.Add(new Employee()
            {
                Id = 2,
                Name = "Test2",
                Email = "Test2@gmail.com",
                Department = Dept.HR
            });
            _employees.Add(new Employee()
            {
                Id = 3,
                Name = "Test3",
                Email = "Test3@gmail.com",
                Department = Dept.Admin
            });
        }

        public Employee Add(Employee employee)
        {
            _employees.Add(employee);
            return employee;
        }


        public Employee Delete(int id)
        {
            var emp = _employees.FirstOrDefault(x => x.Id == id);
            _employees.Remove(emp);
            return emp;
        }


        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee Update(Employee employee)
        {
            var emp = _employees.FirstOrDefault(x => x.Id == employee.Id);
            if(emp != null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
            }

            return emp;
        }

    }
}
