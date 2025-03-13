namespace GuideGoAPI.DTOs
{
    public class RouteDTO
    {
        public int GuideId { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public string DifficultyLevel { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string RouteType { get; set; }
    }
}
