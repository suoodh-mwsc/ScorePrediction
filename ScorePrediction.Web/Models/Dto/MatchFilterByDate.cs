using ScorePrediction.Web.Models.Domain;

namespace ScorePrediction.Web.Models.Dto
{
    public class MatchFilterByDate
    {
        public List<Match> TodaysMatches { get; set; }
        public List<Match> FutureMatches { get; set; }
    }
}