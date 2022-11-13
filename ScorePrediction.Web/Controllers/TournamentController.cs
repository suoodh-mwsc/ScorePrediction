using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Domain;
using ScorePrediction.Web.Models;

namespace ScorePrediction.Web.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ScorePredictionDbContext _dbContext;
        public TournamentController(ScorePredictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult List()
        {
            IEnumerable<Tournament> objectList = _dbContext.Tournaments;
            return View(objectList);
        }
    }
}
