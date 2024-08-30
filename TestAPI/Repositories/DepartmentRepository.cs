using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestAPI.Database;
using TestAPI.Dtos.Department;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department?> DeleteDepartmentAsync(Guid departmentId)
        {
            var dept = await _context.Department.FindAsync(departmentId);
            
            if (dept == null)
            {
                return null;
            }

            _context.Remove(dept);
            await _context.SaveChangesAsync();
            return dept;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Department.Include(e => e.Employees).ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(Guid departmentId)
        {
            return await _context.Department.Include(e => e.Employees).FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<Department?> UpdateDepartmentAsync(Guid departmentId, UpdateDepartmentDto departmentDto)
        {
            var existingDepartment = await _context.Department.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (existingDepartment == null)
            {
                return null;
            }

            _mapper.Map(departmentDto, existingDepartment);
            await _context.SaveChangesAsync();
            return existingDepartment;
        }
    }
}
