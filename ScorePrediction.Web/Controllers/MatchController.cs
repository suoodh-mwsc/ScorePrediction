using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Web.Models.Domain;
using ScorePrediction.Web.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using ScorePrediction.Web.Models.Dto.Match;

namespace ScorePrediction.Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly ScorePredictionDbContext _dbContext;
        public MatchController(ScorePredictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult List()
        {

            DateTime todayDate = DateTime.Now;
            IEnumerable<Match> todayList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Where(e => e.DeletedOn == null);

            IEnumerable<Match> pastList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Where(e => e.DeletedOn == null && e.PublishedOn >= DateTime.Now);

            IEnumerable<Match> futureList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Where(e => e.DeletedOn == null && e.PublishedOn >= DateTime.Now);

            return View(todayList);
        }

        public IActionResult ManageList()
        {
            IEnumerable<Match> objectList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Where(e => e.DeletedOn == null);
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
