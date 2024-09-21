using EmployeeManagement.model;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
public class EmployeeService : IEmployeeServices
{
    private readonly HttpClient httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Employee> CreateEmployee(Employee newEmployee)
    {

        var response = await httpClient.PostAsJsonAsync("api/employees", newEmployee);
        if (response != null && response.IsSuccessStatusCode)
        {

            var result = JsonSerializer.Deserialize<Employee>(response.Content.ReadAsStringAsync().Result);
            return result;

        }
        return null;
    }

    public async Task DeleteEmployee(int id)
    {
       await httpClient.DeleteAsync($"api/employees/{id}");
    }

    public async Task<Employee> GetEmployee(int id)
    {
        return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        //return await httpClient.GetJsonAsync($"api/employees/{id}");
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
    }

    public async Task<Employee> UpdateEmployee(Employee UpdatedEmployee)
    {
        var response = await httpClient.PutAsJsonAsync("api/employees", UpdatedEmployee);
        if (response.IsSuccessStatusCode)
        {
            //handle the success response
            var responseData = await response.Content.ReadAsStringAsync();
            //do something with the response data if needed
            Employee objEmp = JsonSerializer.Deserialize<Employee>(responseData);
            return objEmp;
        }
        else
        {
            //handle the error response
            var errorMessage = await response.Content.ReadAsStringAsync();
            return null;
            //handle or log the error nmessage

        }


    }
}