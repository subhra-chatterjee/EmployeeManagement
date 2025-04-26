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
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/employee/", employee);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Employee>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            //finally
            //{
            //    _httpClient.Dispose();
            //}

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/employee/{id}");
                response.EnsureSuccessStatusCode(); 

                
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw; 
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/employee");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<IEnumerable<Employee>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            //finally
            //{
            //    _httpClient.Dispose();
            //}

        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/employee/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Employee>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            //finally
            //{
            //    _httpClient.Dispose();
            //}

        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/employee/", employee);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Employee>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            //finally
            //{
            //    _httpClient.Dispose();
            //}
        }
    }
}
