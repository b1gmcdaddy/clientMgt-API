using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestAPI.Models;

namespace TestAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
            public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
            {

            }

            public DbSet<Address> Address { get; set; }
            public DbSet<Company> Company { get; set; }
            public DbSet<Department> Department { get; set; }
            public DbSet<Employee> Employee { get; set; }
    }
}
