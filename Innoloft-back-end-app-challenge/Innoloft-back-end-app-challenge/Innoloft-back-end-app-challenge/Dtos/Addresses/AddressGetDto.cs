using EventsAPI.Core.Entities;

namespace Innoloft_back_end_app_challenge.Dtos.Addresses
{
    public class AddressGetDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Suite { get; set; }
        public string ZipCode { get; set; }
    }
}
