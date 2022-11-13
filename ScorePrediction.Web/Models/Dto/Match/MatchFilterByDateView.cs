using ScorePrediction.Web.Models.Domain;

namespace ScorePrediction.Web.Models.Dto.Match
{
    public class MatchFilterByDateView
    {
        public ICollection<Models.Domain.Match> TodaysMatches { get; set; }
        public ICollection<Models.Domain.Match> PastMatches { get; set; }
        public ICollection<Models.Domain.Match> FutureMatches { get; set; }
    }
}