namespace ExposureEvents.API.Models
{
    public class ExposureDivision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public int Order { get; set; }
    }
}