using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee)
        {
            return await httpClient.PutAsJsonAsync<Employee>("api/employees", updatedEmployee);
        }
        public async Task<HttpResponseMessage> CreateEmployee(Employee newEmployee)
        {
            return await httpClient.PostAsJsonAsync<Employee>("api/employees", newEmployee);
        }

        public async Task<HttpResponseMessage> DeleteEmployee(int id)
        {
            return await httpClient.DeleteAsync($"api/employees/{id}");
        }

    }
}
