using EventsAPI.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Innoloft_back_end_app_challenge.Dtos.Users
{
    public class UserPostDto
    {
       public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public Company Company { get; set; }

    }
}
