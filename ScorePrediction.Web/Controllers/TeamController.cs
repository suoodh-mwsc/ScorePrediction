using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Web.Models.Domain;
using ScorePrediction.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ScorePrediction.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ScorePredictionDbContext _dbContext;
        public TeamController(ScorePredictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult List()
        {
            DateTime todayDate = DateTime.Now;
            IEnumerable<Team> objectList = _dbContext.Teams
                .Include(m => m.Tournament)
                .Where(e => e.DeletedOn == null);
            return View(objectList);
        }

        public IActionResult ManageList()
        {
            IEnumerable<Team> objectList = _dbContext.Teams.Where(e => e.DeletedOn == null);
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
