using System.Text.Json;
using EmployeeInfo;

namespace EmployeeManagement.Components.Sevice
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/employee/", employee);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            var response = await _httpClient.GetAsync("api/employee");
            response.EnsureSuccessStatusCode(); 

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Employee>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var response = await _httpClient.GetAsync($"api/employee/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Employee>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/employee/", employee);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Employee>();
        }
    }
}
