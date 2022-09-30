namespace FightersStatsNet.Models
{
    public class Fighter
    {
        public int FighterID { get; set; }
        public string? FighterName { get; set; }
        public char Gender { get; set; }
        public int SkillLevel { get; set; }
        public string? Strengths { get; set; }
        public string? Weaknesses { get; set; }
        public int Game { get; set; }
    }
}
