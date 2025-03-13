namespace GuideGoAPI.DTOs
{
    public class BookingDTO
    {
        public int TouristId { get; set; }
        public int GuideId { get; set; }
        public int RouteId { get; set; }
        public DateTime TourDate { get; set; }
        public string BookingStatus { get; set; }
        public string? SpecialRequests { get; set; }
    }
}
