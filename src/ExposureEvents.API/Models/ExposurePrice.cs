namespace ExposureEvents.API.Models
{
    public class ExposurePrice
    {
        public int Id { get; set; }
        public PriceType Type { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}