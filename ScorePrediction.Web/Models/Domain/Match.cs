using ScorePrediction.Web.Models.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScorePrediction.Web.Models.Domain
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
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
        public DateTime? PublishedOn { get; set; }



        [DisplayName("Home Team Score")]
        public int? HomeTeamScore { get; set; } = 0;
        [DisplayName("Away Team Score")]
        public int? AwayTeamScore { get; set; } = 0;



        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }



        [ForeignKey("Tournament")]
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }


        //Guid HomeTeamId { get; set; }
        //[ForeignKey("HomeTeamId")]
        [DisplayName("Home Team")]
        public virtual Team HomeTeam { get; set; }

        //[ForeignKey("AwayTeamId")]
        //Guid AwayTeamId { get; set; }
        [DisplayName("Away Team")]
        public virtual Team AwayTeam { get; set; }


        //public ICollection<MatchPrize> MatchPrize { get; set; }

        public IList<Prediction> Prediction { get; set; }
    }
}
