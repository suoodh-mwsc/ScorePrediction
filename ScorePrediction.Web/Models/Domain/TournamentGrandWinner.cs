using ScorePrediction.Web.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScorePrediction.Web.Models.Domain
{
    public class TournamentGrandWinner
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        public string WinnerEmployeeId { get; set; }
        public string GrandWinnerTitle { get; set; }
        public DateTime? PublishedOn { get; set; }


   
        public Tournament TournamentId { get; set; }



        [ForeignKey("TournamentGrandPrize")]
        public Guid TournamentGrandPrizeId { get; set; }
        public TournamentGrandPrize TournamentGrandPrize { get; set; }
    }
}
