using System.ComponentModel;

namespace FenClub.Models.Domain
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        public string Name { get; set; }
        [DisplayName("Start On")]

        public DateTime StartOn { get; set; }
        [DisplayName("End On")]

        public DateTime EndOn { get; set; }
        [DisplayName("Score Prediction")]

        public Boolean ScorePrediction { get; set; }
        [DisplayName("Published On")]

        public DateTime PublishedOn { get; set; }

        // public List<Match> TournamentMatches { get; set; }
    }
}
