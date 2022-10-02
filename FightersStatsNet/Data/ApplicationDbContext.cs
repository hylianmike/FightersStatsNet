using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FightersStatsNet.Models;

namespace FightersStatsNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FightersStatsNet.Models.Game> Game { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Attack> Attacks { get; set; }
    }
}