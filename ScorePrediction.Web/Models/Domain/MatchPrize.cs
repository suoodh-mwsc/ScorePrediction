using ScorePrediction.Web.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ScorePrediction.Web.Models.Domain
{
    public class MatchPrize
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }


        public Guid MatchId { get; set; }
        public Match Match { get; set; }
    }
}
