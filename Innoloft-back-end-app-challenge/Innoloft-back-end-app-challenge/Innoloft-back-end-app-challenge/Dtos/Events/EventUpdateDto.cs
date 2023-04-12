using System.ComponentModel.DataAnnotations;

namespace Innoloft_back_end_app_challenge.Dtos.Events
{
    public class EventUpdateDto
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
