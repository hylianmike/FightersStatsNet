using System.ComponentModel.DataAnnotations;

namespace FightersStatsNet.Models
{
    public class Game
    {
        public int GameId { get; set; }

        [Required]
        [Display(Name = "Game Name")]
        public string? Name { get; set; }

        [Display(Name = "Release Year")]
        public int YearOfRelease { get; set; }

        public List<Fighter>? Fighters { get; set; }
    }
}
