namespace TestAPI.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
