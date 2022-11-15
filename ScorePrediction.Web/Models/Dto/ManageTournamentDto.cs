using ScorePrediction.Web.Models.Domain;

namespace ScorePrediction.Web.Models.Dto
{
    public class ManageTournamentDto
    {
        public Guid TournamentId { get; set; }
        public Tournament SelectedTournament { get; set; }
        public List<Match> TournamentMatches { get; set; }
        public List<Team> TournamentTeams { get; set; }
        public List<MatchPrize> TournamentMatchPrizes { get; set; }
        public List<MatchWinner> TournamentMatchWinners { get; set; }
        public List<TournamentGrandPrize> TournamentGrandPrizes { get; set; }
        public List<TournamentGrandWinner> TournamentGrandWinners { get; set; }
    }
}
