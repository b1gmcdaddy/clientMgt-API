using TestAPI.Dtos.Employee;

namespace TestAPI.Dtos.Department
{
    public class DepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public Guid CompanyId { get; set; }
    }
}
