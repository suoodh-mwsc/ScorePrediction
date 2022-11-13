using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Web.Models.Domain;
using ScorePrediction.Web.Models;

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
            IEnumerable<Match> objectList = _dbContext.Matches.Where(e => e.DeletedOn == null && e.PublishedOn >= DateTime.Now);
            return View(objectList);
        }

        public IActionResult manageList()
        {
            IEnumerable<Match> objectList = _dbContext.Matches.Where(e => e.DeletedOn == null);
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
