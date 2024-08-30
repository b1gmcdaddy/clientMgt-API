using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Dtos.Address;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _addressRepository.GetAllAddressesAsync();
            var addressDto = _mapper.Map<IEnumerable<AddressDto>>(addresses);
            return Ok(addressDto);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetAddressById([FromRoute] Guid guid)
        {
            var address = await _addressRepository.GetAddressByIdAsync(guid);
            var addressDto = _mapper.Map<AddressDto>(address);
            return Ok(addressDto);
        }

        [HttpPost("{empId}")]
        public async Task<IActionResult> CreateAddress([FromRoute] Guid empId, [FromBody] CreateAddressDto addressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAddress = _mapper.Map<Address>(addressDto);
            newAddress.EmployeeId = empId;  
            await _addressRepository.CreateAddressAsync(newAddress);
            return Ok(newAddress);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] Guid guid,  [FromBody] UpdateAddressDto addressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _addressRepository.UpdateAddressAsync(guid, addressDto);
            return Ok(addressDto);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] Guid guid)
        {
            var addressToDelete = await _addressRepository.DeleteAddressAsync(guid);
            return Ok(addressToDelete); 
        }
    }
}
