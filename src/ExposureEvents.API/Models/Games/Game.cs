namespace ExposureEvents.API.Models.Games
{
    public class Game
    {
        public uint Id { get; set; }
        public int Type { get; set; }
        public Division Division { get; set; }
        public VenueCourt VenueCourt { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}