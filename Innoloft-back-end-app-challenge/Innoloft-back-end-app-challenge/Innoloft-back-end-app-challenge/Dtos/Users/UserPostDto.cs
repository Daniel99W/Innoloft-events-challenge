﻿using EventsAPI.Core.Entities;

namespace Innoloft_back_end_app_challenge.Dtos.Users
{
    public class UserPostDto
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }

    }
}
