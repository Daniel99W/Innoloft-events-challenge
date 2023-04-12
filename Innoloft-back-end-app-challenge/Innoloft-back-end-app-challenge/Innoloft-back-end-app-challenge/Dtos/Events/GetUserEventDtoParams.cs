using System.ComponentModel.DataAnnotations;

namespace Innoloft_back_end_app_challenge.Dtos.Events
{
    public class GetUserEventDtoParams
    {
        [Required]
        public int Page { get; set; }
        [Required]
        public int ItemsPerPage { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
