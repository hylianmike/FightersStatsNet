using System.ComponentModel.DataAnnotations;

namespace FightersStatsNet.Models
{
    public class Attack
    {
        public int AttackId { get; set; }

        [Required]
        [Display(Name = "Atack Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Button Input")]
        public string? ButtonInput { get; set; }

        [Display(Name = "Associated Fighter")]
        public int FighterId { get; set; }
        
        public Fighter? Fighter { get; set; }
    }
}
