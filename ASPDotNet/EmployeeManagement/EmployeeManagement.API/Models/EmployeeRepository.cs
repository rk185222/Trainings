using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await appDbContext.Employees
                    .Include(e=> e.Department)
                    .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees
                          .Include(e => e.Department)
                            .ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(z => z.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;
                
                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(z => z.EmployeeId == employeeId);

            if(result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

    }
}
