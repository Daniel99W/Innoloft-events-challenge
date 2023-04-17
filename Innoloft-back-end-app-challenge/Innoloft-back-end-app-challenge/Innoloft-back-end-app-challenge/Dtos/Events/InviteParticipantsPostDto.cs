namespace Innoloft_back_end_app_challenge.Dtos.Events
{
    public class InviteParticipantsPostDto
    {
        public List<int> participantsIds { get; set; }
        public int EventId { get; set; }
        public int CreatorId { get; set; }
    }
}
