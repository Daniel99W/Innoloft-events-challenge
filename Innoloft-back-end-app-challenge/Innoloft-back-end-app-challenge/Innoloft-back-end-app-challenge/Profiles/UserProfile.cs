using AutoMapper;
using EventsAPI.Core.Entities;
using Innoloft_back_end_app_challenge.Dtos.Users;

namespace Innoloft_back_end_app_challenge.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserPostDto>().ReverseMap();
            CreateMap<User, UserGetDto>().ReverseMap();
        }
    }
}
