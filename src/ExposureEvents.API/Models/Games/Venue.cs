namespace ExposureEvents.API.Models.Games
{
    public class Venue
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public Address Address { get; set; }
    }
}