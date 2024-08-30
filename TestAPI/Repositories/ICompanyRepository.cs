using System.Reflection;
using TestAPI.Dtos.Company;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompaniesAsync();
        Task<Company?> GetCompanyByIdAsync(Guid companyId);
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company?> UpdateCompanyAsync(Guid companyId, UpdateCompanyDto companyDto);
        Task<Company?> DeleteCompanyAsync(Guid companyId);
    }
}
