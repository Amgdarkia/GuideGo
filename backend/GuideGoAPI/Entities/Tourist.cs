﻿namespace GuideGoAPI.Entities
{
    public class Tourist
    {
        public int TouristId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; } 
    }
}
