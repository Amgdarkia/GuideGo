using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; // Import this for [JsonIgnore]

namespace GuideGoAPI.Entities
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        [ForeignKey("Guide")]
        public int GuideId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Duration { get; set; }

        [Required]
        [StringLength(50)]
        public string DifficultyLevel { get; set; }

        [Required]
        [StringLength(100)]
        public string StartPoint { get; set; }

        [Required]
        [StringLength(100)]
        public string EndPoint { get; set; }

        [Required]
        [StringLength(50)]
        public string RouteType { get; set; }

     
        public Guide Guide { get; set; }
    }
}
