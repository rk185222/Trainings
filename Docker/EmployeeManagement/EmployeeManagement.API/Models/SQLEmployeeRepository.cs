
namespace EmployeeManagement.API.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context) 
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            var emp = context.Employees.Find(id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public Employee Update(Employee employee)
        {
            var emp = context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return employee;
        }
    }
}
