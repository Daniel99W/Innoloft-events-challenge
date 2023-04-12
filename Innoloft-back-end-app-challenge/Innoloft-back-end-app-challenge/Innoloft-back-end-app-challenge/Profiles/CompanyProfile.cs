using AutoMapper;
using EventsAPI.Core.Entities;
using Innoloft_back_end_app_challenge.Dtos.Companies;

namespace Innoloft_back_end_app_challenge.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyGetDto>().ReverseMap();
        }
    }
}
