using ScorePrediction.Web.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ScorePrediction.Web.Models.Domain
{
    public class MatchWinner
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        public string WinnerEmployeeId { get; set; }
        public string MatchWinnerTitle { get; set; }
        public DateTime PublishedOn { get; set; }


        public MatchPrize MatchPrizeId { get; set; }
        public Match MatchId { get; set; }
    }
}
