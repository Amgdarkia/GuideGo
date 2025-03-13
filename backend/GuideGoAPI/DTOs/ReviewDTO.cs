namespace GuideGoAPI.DTOs
{
    public class ReviewDTO
    {
        public int GuideId { get; set; }
        public int TouristId { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
