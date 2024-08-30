using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Dtos.Employee;
using TestAPI.Helpers;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] EmployeeQueries query)
        {
            var empList = await _employeeRepository.GetAllEmployeesAsync(query);

            if (empList == null)
            {
                return NotFound();
            }

            var empListDto = _mapper.Map<IEnumerable<EmployeeDto>>(empList);    
            return Ok(empListDto);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid guid)
        {
            var emp = await _employeeRepository.GetEmployeeByIdAsync(guid);
            if (emp == null)
            {
                return NotFound();
            }
            var empDto = _mapper.Map<EmployeeDto>(emp);
            return Ok(empDto);
        }

        [HttpPost("{deptId}")]
        public async Task<IActionResult> CreateEmployee([FromRoute] Guid deptId, [FromBody] CreateEmployeeDto empDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEmp = _mapper.Map<Employee>(empDto);
            newEmp.DepartmentId = deptId;   
            await _employeeRepository.CreateEmployeeAsync(newEmp);
            return Ok(newEmp);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid guid,  [FromBody] UpdateEmployeeDto empDto)
        {
            var updateEmp = await _employeeRepository.UpdateEmployeeAsync(guid, empDto);
            if (updateEmp == null)
            {
                return NotFound();
            }
            return Ok(updateEmp);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid guid)
        {
            var empToDel = await _employeeRepository.DeleteEmployeeByIdAsync(guid);

            if (empToDel == null)
            {
                return NotFound();
            }

            return Ok(empToDel);
        }
    }
}
