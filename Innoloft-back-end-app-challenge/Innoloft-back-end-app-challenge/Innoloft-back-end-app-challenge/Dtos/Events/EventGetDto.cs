using EventsAPI.Core.Entities;
using Innoloft_back_end_app_challenge.Dtos.Users;

namespace Innoloft_back_end_app_challenge.Dtos.Events
{
    public class EventGetDto
    {
        public int Id { get; set; }
        public UserGetDto? Creator { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
