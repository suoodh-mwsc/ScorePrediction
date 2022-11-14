using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Web.Models.Domain;
using ScorePrediction.Web.Models;
using Microsoft.EntityFrameworkCore;
using ScorePrediction.Web.Models.Dto.Tournament;

namespace ScorePrediction.Web.Controllers
{
    public class TournamentController : BaseController
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


        public IActionResult HistoryList()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTournamentDto tournament)
        {
            if (ModelState.IsValid)
            {
                // Duplicate check
                if (_dbContext.Tournaments.Any(x => x.Name == tournament.Name))
                    ModelState.AddModelError("Name", "Tournament with the Name '" + tournament.Name + "' already exists");

                // comparing date
                int result = DateTime.Compare(tournament.EndOn, tournament.StartOn);
                DateTime CreatedOn = DateTime.Now;

                if (result < 0)
                {
                    //it is earlier
                    ModelState.AddModelError("StartOn", "Tournament with the Start On '" + tournament.StartOn + "' date cannot be grater than  '" + tournament.EndOn);
                }
                else if (result == 0)
                {
                    //it is the same time as
                    ModelState.AddModelError("StartOn", "Tournament with the Start On '" + tournament.StartOn + "' date cannot be same date  '" + tournament.EndOn);
                }
                else
                {
                    //it is later
                }

                return View(nameof(Create));
            }


            if (ModelState.IsValid)
            {
                // Created
                var tournamentObj = new Tournament()
                {
                    CreatedBy = loggedInUserName,
                    CreatedOn = DateTime.Now,
                };
                // Mapping
                tournamentObj.StartOn = tournament.StartOn;
                tournamentObj.EndOn = tournament.EndOn;
                tournamentObj.Name = tournament.Name;
                // Mapping Create Model
                // tournamentObj = _mapper.Map<TournamentCreateDto, Tournament>(tournament);

                _dbContext.Tournaments.Add(tournamentObj);
                // or
                // _context.Add<Tournament>(tournamentObj);


                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(ManageList));
            }

            return View(nameof(Create));
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
