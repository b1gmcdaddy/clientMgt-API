using TestAPI.Dtos.Department;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(Guid departmentId);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(Guid departmentId, UpdateDepartmentDto departmentDto);
        Task<Department?> DeleteDepartmentAsync(Guid departmentId);
    }
}
