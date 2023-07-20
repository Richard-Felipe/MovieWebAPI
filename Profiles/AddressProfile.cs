using AutoMapper;
using MovieWebAPI.Data.Dtos;
using MovieWebAPI.Models;

namespace MovieWebAPI.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, ReadAddressDto>();
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, UpdateAddressDto>();
        CreateMap<CreateAddressDto, Address>();
    }
}
