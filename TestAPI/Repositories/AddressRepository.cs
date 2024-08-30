using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestAPI.Database;
using TestAPI.Dtos.Address;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address?> DeleteAddressAsync(Guid addressId)
        {
            var existingAddress = await _context.Address.FindAsync(addressId);
            if (existingAddress == null)
            {
                return null;
            }

            _context.Address.Remove(existingAddress);
            await _context.SaveChangesAsync();
            return existingAddress;
        }

        public async Task<Address?> GetAddressByIdAsync(Guid addressId)
        {
            return await _context.Address.FindAsync(addressId);
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<Address?> UpdateAddressAsync(Guid addressId, UpdateAddressDto updateAdressDto)
        {
            var existingAddress = await _context.Address.FindAsync(addressId);

            if (existingAddress == null)
            {
                return null;
            }

            _mapper.Map(updateAdressDto, existingAddress);
            await _context.SaveChangesAsync();
            return existingAddress;
        }
    }
}
