using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Dtos.Department;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, ICompanyRepository companyRepository,
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departmentList = await _departmentRepository.GetAllDepartmentsAsync();
            var deptToDto = _mapper.Map<IEnumerable<DepartmentDto>>(departmentList);
            return Ok(deptToDto);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] Guid guid)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(guid);

            if (department == null)
            {
                return NotFound();
            }

            var deptDto = _mapper.Map<DepartmentDto>(department);
            return Ok(deptDto);
        }

        [HttpPost("{companyId}")]
        public async Task<IActionResult> CreateDepartment([FromRoute] Guid companyId, [FromBody] CreateDepartmentDto deptDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDepartment = _mapper.Map<Department>(deptDto);
            newDepartment.CompanyId = companyId;
            await _departmentRepository.CreateDepartmentAsync(newDepartment);
            return CreatedAtAction(nameof(GetDepartmentById), new { guid = newDepartment.DepartmentId }, newDepartment);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] Guid guid, [FromBody] UpdateDepartmentDto updateDeptDto)
        {
            var updatedDept = await _departmentRepository.UpdateDepartmentAsync(guid, updateDeptDto);

            if (updatedDept == null)
            {
                return NotFound();
            }

            return Ok(updatedDept);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] Guid guid)
        {
            var deptToDelete = await _departmentRepository.DeleteDepartmentAsync(guid);
            return Ok(deptToDelete);
        }

    }
}
