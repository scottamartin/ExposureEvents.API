namespace ExposureEvents.API.Models.Games
{
    public class VenueCourt
    {
        public uint Id { get; set; }
        public Court Court { get; set; }
        public Venue Venue { get; set; }
    }
}