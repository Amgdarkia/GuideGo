using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideGoAPI.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [ForeignKey("Tourist")]
        public int TouristId { get; set; }

        [ForeignKey("Guide")]
        public int GuideId { get; set; }

        [ForeignKey("Route")]
        public int RouteId { get; set; }

        [Required]
        public DateTime TourDate { get; set; }

        [Required]
        [StringLength(20)]
        public string BookingStatus { get; set; } // Example: "Pending", "Confirmed", "Cancelled"

        public string? SpecialRequests { get; set; } // Nullable

        // Navigation properties (optional)
        public Guide? Guide { get; set; }
        public Tourist? Tourist { get; set; }
        public Route? Route { get; set; }
    }
}
