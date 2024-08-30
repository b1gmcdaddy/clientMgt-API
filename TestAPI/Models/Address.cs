namespace TestAPI.Models
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;    
        public string PostalCode {  get; set; } = string.Empty;
        public Guid EmployeeId { get; set; }
        public bool IsDefault { get; set; }
        public Employee Employee { get; set; }

    }
}
