using System.ComponentModel.DataAnnotations;

namespace FightersStatsNet.Models
{
    public class Fighter
    {
        public int FighterId { get; set; }

        [Required]
        [Display(Name = "Fighter Name")]
        public string? Name { get; set; }

        [Required]
        public char Gender { get; set; }

        [Required]
        [Display(Name = "Play Style")]
        public string? PlayStyle { get; set; }

        [Display(Name = "Skill Level")]
        [Range(0, 10)]
        public int SkillLevel { get; set; }
        
        public string? Strengths { get; set; }
        
        public string? Weaknesses { get; set; }

        [Display(Name = "Game")]
        public int GameId { get; set; }
        public Game? Game { get; set; }
        public List<Attack>? Attacks { get; set; }
    }
}
