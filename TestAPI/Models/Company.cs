using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; } = string.Empty;

    }
}
