using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Web.Models.Domain;
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
            DateTime todayDate = DateTime.Now; 
            IEnumerable<Tournament> objectList = _dbContext.Tournaments.Where(e => e.DeletedOn == null && e.PublishedOn <= DateTime.Now);
            return View(objectList);
        }

        public IActionResult ManageList()
        {
            IEnumerable<Tournament> objectList = _dbContext.Tournaments.Where(e => e.DeletedOn == null);
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //public Task<IActionResult> Edit(Guid? id)
        //{
        //    return View();
        //}

        //public Task<IActionResult> Delete(Guid? id)
        //{


        //    return View();
        //}
    }
}
