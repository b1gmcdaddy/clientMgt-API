using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestAPI.Database;
using TestAPI.Dtos.Company;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 

        public CompanyRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Company> CreateCompanyAsync(Company company)
        {
            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company?> DeleteCompanyAsync(Guid companyId)
        {
            var companyToDelete = await _context.Company.FirstOrDefaultAsync(c => c.CompanyId == companyId);

            if (companyToDelete == null)
            {
                return null;
            }

            _context.Remove(companyToDelete);
            await _context.SaveChangesAsync();
            return companyToDelete;

        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<Company?> GetCompanyByIdAsync(Guid companyId)
        {
            return await _context.Company.FindAsync(companyId);
        }

        public async Task<Company?> UpdateCompanyAsync(Guid companyId, UpdateCompanyDto companyDto)
        {
            var existingCompany = await _context.Company.FirstOrDefaultAsync(c => c.CompanyId == companyId);

            if (existingCompany == null)
            {
                return null;
            }

            _mapper.Map(companyDto, existingCompany);
            await _context.SaveChangesAsync();
            return existingCompany;
        }
    }
}
