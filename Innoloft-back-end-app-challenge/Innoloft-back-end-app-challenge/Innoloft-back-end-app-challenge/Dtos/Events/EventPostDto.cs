using System.ComponentModel.DataAnnotations;

namespace Innoloft_back_end_app_challenge.Dtos.Events
{
    public class EventPostDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
