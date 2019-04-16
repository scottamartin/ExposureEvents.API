namespace ExposureEvents.API.Models
{
    public class ExposureSeason
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Session { get; set; }
    }
}