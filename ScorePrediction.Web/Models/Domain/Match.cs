using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FenClub.Models.Domain
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }



        [DisplayName("Match Title")]
        public string MatchTitle { get; set; }

        [DisplayName("Start On")]
        public DateTime StartOn { get; set; }

        [DisplayName("Prediction Deadline")]
        public DateTime PredictionDeadline { get; set; }

        [DisplayName("Published On")]
        public DateTime PublishedOn { get; set; }



        //int TournamentId { get; set; }
        public Tournament Tournament { get; set; }



        //int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        //int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
    }
}
