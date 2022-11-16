using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScorePrediction.Web.Models;
using ScorePrediction.Web.Models.Dto;

namespace ScorePrediction.Web.Controllers
{
    public class ManageTournamentController : BaseController
    {
        private readonly ScorePredictionDbContext _dbContext;

        public ManageTournamentController(ScorePredictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult TournamentList(Guid? id)
        {
            DateTime todayDate = DateTime.Now.Date;
            var objList = new ManageTournamentDto();
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;

           // objList.TournamentId = id;

            objList.SelectedTournament = _dbContext.Tournaments.Find(id);

            objList.TournamentTeams = _dbContext.Teams
                .Include(m => m.Tournament)
                .Where(e => e.Tournament.Id == id && e.DeletedOn == null)
                .OrderBy(x => x.CreatedOn).ToList();


            objList.TournamentMatches = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Tournament)
                .Where(e => e.Tournament.Id == id
                        && e.DeletedOn == null
                        && e.PublishedOn.HasValue
                        && DbF.DateDiffDay(todayDate, e.StartOn) >= 1)
                .OrderBy(x => x.StartOn).ToList();

            return View(objList);
        }

        public IActionResult ManageTournamentList()
        {
            var objectList = _dbContext.Tournaments.ToList();
            return View(objectList);
        }
    }
}
