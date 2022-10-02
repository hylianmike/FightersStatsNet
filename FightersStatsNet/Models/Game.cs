namespace FightersStatsNet.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string? Name { get; set; }
        public int YearOfRelease { get; set; }
        public List<Fighter>? Fighters { get; set; }
    }
}
