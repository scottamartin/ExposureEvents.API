using System.Collections.Generic;

namespace ExposureEvents.API.Models
{
    public class ExposureVenue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public ExposureAddress Address { get; set; }
        public IEnumerable<ExposureLocation> Locations { get; set; } = new List<ExposureLocation>();
    }
}