using System.ComponentModel.DataAnnotations;

namespace FenClub.Models.Domain
{
    public class MatchWinner
    {
        [Key]
        public Guid Id { get; set; }
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
