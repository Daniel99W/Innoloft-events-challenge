using AutoMapper;
using EventsAPI.Core.Entities;
using EventsAPI.Core.Utilities;
using Innoloft_back_end_app_challenge.Dtos.Events;

namespace Innoloft_back_end_app_challenge.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventPostDto>().ReverseMap();
            CreateMap<Event, EventGetDto>().ReverseMap();
            CreateMap<Pagination<EventGetDto>, Pagination<Event>>().ReverseMap();
        }
    }
}
