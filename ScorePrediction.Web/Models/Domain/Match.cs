using ScorePrediction.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FenClub.Models.Domain
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;     
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }



        [Required, DisplayName("Match Title")]
        public string MatchTitle { get; set; }

        [Required, DisplayName("Start On")]
        public DateTime StartOn { get; set; }

        [Required, DisplayName("Prediction Deadline")]
        public DateTime PredictionDeadline { get; set; }

        [DisplayName("Published On")]
        public DateTime PublishedOn { get; set; }


        [ForeignKey("Tournament")]
        Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }


        [ForeignKey("Team")]
        Guid HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }


        [ForeignKey("Team")]
        Guid AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
    }
}
