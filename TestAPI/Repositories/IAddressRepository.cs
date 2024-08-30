using TestAPI.Dtos.Address;
using TestAPI.Dtos.Department;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address?> GetAddressByIdAsync(Guid addressId);
        Task<Address> CreateAddressAsync(Address address);
        Task<Address?> UpdateAddressAsync(Guid addressId, UpdateAddressDto updateAdressDto);
        Task<Address?> DeleteAddressAsync(Guid addressId);
    }
}
