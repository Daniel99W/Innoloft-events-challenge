using System.ComponentModel.DataAnnotations;

namespace Innoloft_back_end_app_challenge.Dtos.Events
{
    public class RegisterToEventDto
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
