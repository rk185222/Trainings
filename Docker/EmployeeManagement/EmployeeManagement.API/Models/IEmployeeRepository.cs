namespace EmployeeManagement.API.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);

        IEnumerable<Employee> GetEmployees();

        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
    }
}
