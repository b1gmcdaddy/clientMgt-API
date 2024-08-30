using TestAPI.Dtos.Address;
using TestAPI.Models;

namespace TestAPI.Dtos.Employee
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
        public Guid DepartmentId { get; set; }
    }
}
