using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Dtos.Company;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();
            var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companyDto);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] Guid guid)
        {
            var companies = await _companyRepository.GetCompanyByIdAsync(guid);

            if (companies == null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(companies);  
            return Ok(companyDto);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto companyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCompany = _mapper.Map<Company>(companyDto);
            await _companyRepository.CreateCompanyAsync(newCompany);
            return CreatedAtAction(nameof(GetCompanyById), new { guid = newCompany.CompanyId }, newCompany);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateCompany([FromRoute] Guid guid, [FromBody] UpdateCompanyDto companyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _companyRepository.UpdateCompanyAsync(guid, companyDto);
            return NoContent();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] Guid guid)
        {
            var deleteCompany = await _companyRepository.DeleteCompanyAsync(guid);
            return NoContent();
        }
    }
}
