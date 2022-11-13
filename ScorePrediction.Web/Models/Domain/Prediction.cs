using System.ComponentModel.DataAnnotations;

namespace FenClub.Models.Domain
{
    public class Prediction
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }



        public Team HomeTeamScore { get; set; }
        public Team AwayTeamScore { get; set; }



        public string MatchId { get; set; }
        public Match Match { get; set; }


        public Guid HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public Guid AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
    }
}
