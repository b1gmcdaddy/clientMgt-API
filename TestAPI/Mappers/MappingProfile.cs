using AutoMapper;
using TestAPI.Dtos.Address;
using TestAPI.Dtos.Company;
using TestAPI.Dtos.Department;
using TestAPI.Dtos.Employee;
using TestAPI.Models;

namespace TestAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateCompanyDto, Company>();

            CreateMap<Department, DepartmentDto>().ForMember(dto => dto.Employees, opt => opt.MapFrom(src => src.Employees));
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();

            CreateMap<Employee, EmployeeDto>().ForMember(dto => dto.Addresses, opt => opt.MapFrom(src => src.Addresses));
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
        }
    }
}
