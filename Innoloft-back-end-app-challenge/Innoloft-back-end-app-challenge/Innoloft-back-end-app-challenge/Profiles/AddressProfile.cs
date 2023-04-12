using AutoMapper;
using EventsAPI.Core.Entities;
using Innoloft_back_end_app_challenge.Dtos.Addresses;

namespace Innoloft_back_end_app_challenge.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressGetDto>().ReverseMap();
        }
    }
}
