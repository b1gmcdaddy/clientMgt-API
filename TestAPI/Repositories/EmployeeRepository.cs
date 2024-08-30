using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestAPI.Database;
using TestAPI.Dtos.Employee;
using TestAPI.Helpers;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployeeByIdAsync(Guid guid)
        {
            var existingEmp = await _context.Employee.FindAsync(guid);
            if (existingEmp == null)
            {
                return null; 
            }

            _context.Remove(existingEmp);
            await _context.SaveChangesAsync();
            return existingEmp;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(EmployeeQueries query)
        {
            var employeeList = _context.Employee.AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.FirstName))
            {
                employeeList = employeeList.Where(e => e.FirstName.Contains(query.FirstName));
            }

            if(!string.IsNullOrWhiteSpace(query.LastName))
            {
                employeeList = employeeList.Where(e => e.LastName.Contains(query.LastName));  
            }

            if(!string.IsNullOrWhiteSpace(query.Email))
            {
                employeeList = employeeList.Where(e => e.Email.Contains(query.Email));
            }

            return await employeeList.Include(a => a.Addresses).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid empId)
        {
            return await _context.Employee.Include(a => a.Addresses).FirstOrDefaultAsync(e => e.EmployeeId == empId);
        }

        public async Task<Employee?> UpdateEmployeeAsync(Guid empId, UpdateEmployeeDto updateEmpDto)
        {
            var existingEmp = await _context.Employee.FindAsync(empId);

            if (existingEmp == null)
            {
                return null;
            }

            _mapper.Map(updateEmpDto, existingEmp); 
            await _context.SaveChangesAsync();
            return existingEmp;
        }
    }
}
