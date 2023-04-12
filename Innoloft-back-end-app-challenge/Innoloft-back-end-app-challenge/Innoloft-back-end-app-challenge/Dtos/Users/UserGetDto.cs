using EventsAPI.Core.Entities;
using Innoloft_back_end_app_challenge.Dtos.Addresses;
using Innoloft_back_end_app_challenge.Dtos.Companies;

namespace Innoloft_back_end_app_challenge.Dtos.Users
{
    public class UserGetDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public AddressGetDto Address { get; set; }
        public CompanyGetDto Company { get; set; }
    }
}
