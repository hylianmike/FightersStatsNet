namespace FightersStatsNet.Models
{
    public class Attack
    {
        public int AttackId { get; set; }
        public string? Name { get; set; }
        public string? ButtonInput { get; set; }
        public int FighterId { get; set; }
        public Fighter? Fighter { get; set; }
    }
}
