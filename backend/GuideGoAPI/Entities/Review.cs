using System.ComponentModel.DataAnnotations.Schema;

namespace GuideGoAPI.Entities
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        
        [ForeignKey("Guide")]
        public int GuideId { get; set; }
        [ForeignKey("Tourist")]
        public int TouristId { get; set; }
        
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        // Navigation properties (optional but useful)
        public Guide? Guide { get; set; }
        public Tourist? Tourist { get; set; }
    }
}
