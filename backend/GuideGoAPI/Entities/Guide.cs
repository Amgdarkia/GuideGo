using System.ComponentModel.DataAnnotations;

namespace GuideGoAPI.Entities
{
    public class Guide
    {
        public int GuideId { get; set; }
        [StringLength(15)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool HasCar { get; set; }
        public decimal? AverageRating { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Languages { get; set; }

    }
}
