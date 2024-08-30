using TestAPI.Dtos.Employee;
using TestAPI.Helpers;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync(EmployeeQueries query);
        Task<Employee?> GetEmployeeByIdAsync(Guid empId);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee?> UpdateEmployeeAsync(Guid empId, UpdateEmployeeDto updateEmpDto);
        Task<Employee?> DeleteEmployeeByIdAsync(Guid empId);
    }
}
