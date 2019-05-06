namespace ExposureEvents.API.Models
{
    public class Address
    {
        public string Location { get; set; }
        public string StreetAddress { get; set; }
        public string ExtendedAddress { get; set; }
        public string City { get; set; }
        public string StateRegion { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}