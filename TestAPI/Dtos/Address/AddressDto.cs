namespace TestAPI.Dtos.Address
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public Guid EmployeeId { get; set; }
        public bool IsDefault { get; set; }
    }
}
