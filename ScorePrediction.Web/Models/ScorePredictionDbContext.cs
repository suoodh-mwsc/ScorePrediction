using Microsoft.EntityFrameworkCore;
using ScorePrediction.Web.Models.Domain;

namespace ScorePrediction.Web.Models
{
    public class ScorePredictionDbContext : DbContext
    {
        public ScorePredictionDbContext(DbContextOptions<ScorePredictionDbContext> options)
              : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScorePredictionDbContext).Assembly);
        }



        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        //public DbSet<Group> Groups { get; set; }

        //public DbSet<MatchPrize> MatchPrizes { get; set; }
        //public DbSet<MatchWinner> MatchWinners { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        //public DbSet<TournamentGrandPrize> TournamentGrandPrizes { get; set; }
        //public DbSet<TournamentGrandWinner> TournamentGrandWinners { get; set; }

    }
}
