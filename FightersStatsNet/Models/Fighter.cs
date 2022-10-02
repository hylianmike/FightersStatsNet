namespace FightersStatsNet.Models
{
    public class Fighter
    {
        public int FighterId { get; set; }
        public string? Name { get; set; }
        public char Gender { get; set; }
        public int SkillLevel { get; set; }
        public string? Strengths { get; set; }
        public string? Weaknesses { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }
        public List<Attack>? Attacks { get; set; }
    }
}
