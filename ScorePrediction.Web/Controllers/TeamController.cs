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
            var objectList = _dbContext.Teams
                .Include(m => m.Tournament)
                .Where(e => e.DeletedOn == null).ToList();
            return View(objectList);
        }


        public IActionResult ManageTournamentTeam(Guid? id)
        {
            var objectList = _dbContext.Teams
                .Include(m => m.Tournament)
                .Where(e => e.Tournament.Id == id
                        && e.DeletedOn == null).ToList();
            return View(objectList);
        }


        public IActionResult ManageList()
        {
            var objectList = _dbContext.Teams
                .Include(m => m.Tournament)
                .Where(e => e.DeletedOn == null).ToList();
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
