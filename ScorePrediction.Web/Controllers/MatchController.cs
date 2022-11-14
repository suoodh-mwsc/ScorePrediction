using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Web.Models.Domain;
using ScorePrediction.Web.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using ScorePrediction.Web.Models.Dto;

namespace ScorePrediction.Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly ScorePredictionDbContext _dbContext;
        public MatchController(ScorePredictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        //public async Task<IActionResult> GotoList(Guid? id)
        //{
        //    if (id == null || _dbContext.Matches == null)
        //    {
        //        return NotFound();
        //    }

        //    var matches = _dbContext.Matches.Find(id);
        //    if (matches == null)
        //    {
        //        return NotFound();
        //    }

        //    //return RedirectToAction("List", new { @id = id });
        //    return RedirectToAction("List", "Match", new { id = id });
        //}


        // public IActionResult List(Guid? id)
        public IActionResult List(Guid? id)
        {
            DateTime todayDate = DateTime.Now.Date;
            var objList = new MatchFilterByDate();
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;

            objList.TodaysMatches = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Tournament)
                .Where(e => e.Tournament.Id == id && e.DeletedOn == null 
                        && e.PublishedOn.HasValue && DbF.DateDiffDay(todayDate, e.StartOn) ==0)
                .OrderBy(x => x.StartOn).ToList();


            objList.FutureMatches = _dbContext.Matches
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


        public IActionResult HistoryList(Guid? id)
        {
            DateTime todayDate = DateTime.Now.Date;
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;

            IEnumerable<Match> objectList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Where(e => e.Tournament.Id == id 
                        && e.DeletedOn == null 
                        && e.PublishedOn.HasValue 
                        && DbF.DateDiffDay(todayDate, e.StartOn) >= 1)
                .OrderBy(x => x.StartOn);
            return View(objectList);
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
