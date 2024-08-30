namespace TestAPI.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Address> Addresses { get; set; } = new List<Address>();
        public Guid DepartmentId { get; set; }  
        public Department Department { get; set; }
    }
}
