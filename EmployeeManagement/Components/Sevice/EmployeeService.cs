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

    }
}
