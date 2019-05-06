namespace ExposureEvents.API.Models.Games
{
    public class Team
    {
        public string Name { get; set; }
        public string Pool { get; set; }
        public string PoolName { get; set; }
        public uint PoolNumber { get; set; }
        public uint PoolId { get; set; }
        public double Score { get; set; }
        public uint TeamId { get; set; }
        public string Color { get; set; }
    }
}