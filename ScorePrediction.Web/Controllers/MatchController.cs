using Microsoft.AspNetCore.Mvc;
using ScorePrediction.Web.Models.Domain;
using ScorePrediction.Web.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using ScorePrediction.Web.Models.Dto;

namespace ScorePrediction.Web.Controllers
{
    public class MatchController : BaseController
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

            var objectList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Tournament)
                .Where(e => e.Tournament.Id == id 
                        && e.DeletedOn == null 
                        && e.PublishedOn.HasValue 
                        && DbF.DateDiffDay(todayDate, e.StartOn) >= 1)
                .OrderBy(x => x.StartOn);
            return View(objectList);
        }


        public IActionResult ManageTournamentMatch(Guid? id)
        {
            var objectList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Tournament)
                .Where(e => e.Tournament.Id == id 
                        && e.DeletedOn == null).ToList();
            return View(objectList);
        }


        public IActionResult ManageList()
        {
            var objectList = _dbContext.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Tournament)
                .Where(e => e.DeletedOn == null).ToList();
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tournament model)
        {
            if (ModelState.IsValid)
            {
                // Duplicate check
                if (_dbContext.Tournaments.Any(x => x.Name == model.Name))
                    ModelState.AddModelError("Name", "Tournament with the Name '" + model.Name + "' already exists");

                // comparing date
                int result = DateTime.Compare(model.EndOn, model.StartOn);
                DateTime CreatedOn = DateTime.Now;

                if (result < 0)
                {
                    //it is earlier
                    ModelState.AddModelError("StartOn", "Tournament with the Start On '" + model.StartOn + "' date cannot be grater than  '" + model.EndOn);
                }
                else if (result == 0)
                {
                    //it is the same time as
                    ModelState.AddModelError("StartOn", "Tournament with the Start On '" + model.StartOn + "' date cannot be same date  '" + model.EndOn);
                }
                else
                {
                    //it is later
                }

                return View(nameof(Create));
            }


            if (ModelState.IsValid)
            {
                var mapModel = new Tournament();
                mapModel.Name = model.Name;
                mapModel.StartOn = model.StartOn;
                mapModel.EndOn = model.EndOn;
                mapModel.ScorePrediction = model.ScorePrediction;
                //mapModel.PublishedOn = model.PublishedOn;
                //mapModel.Image = model.Image;
                mapModel.CreatedBy = loggedInUserName;
                mapModel.CreatedOn = DateTime.Now;

                _dbContext.Tournaments.Add(mapModel);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(ManageList));
            }

            return View(nameof(Create));
            //return RedirectToAction(nameof(ManageList));
        }


        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemFromDb = _dbContext.Tournaments.Find(id);
            if (itemFromDb == null)
            {
                return NotFound();
            }

            return View(itemFromDb);
        }



        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemFromDb = _dbContext.Tournaments.Find(id);
            if (itemFromDb == null)
            {
                return NotFound();
            }

            return View(itemFromDb);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tournament model)
        {
            // comparing date
            int result = DateTime.Compare(model.EndOn, model.StartOn);
            DateTime CreatedOn = DateTime.Now;

            if (result < 0)
            {
                //it is earlier
                ModelState.AddModelError("StartOn", "Tournament with the Start On '" + model.StartOn + "' date cannot be grater than  '" + model.EndOn);
            }
            else if (result == 0)
            {
                //it is the same time as
                ModelState.AddModelError("StartOn", "Tournament with the Start On '" + model.StartOn + "' date cannot be same date  '" + model.EndOn);
            }
            else
            {
                //it is later
            }


            if (ModelState.IsValid)
            {
                var mapModel = new Tournament();
                mapModel.Id = model.Id;
                mapModel.Name = model.Name;
                mapModel.StartOn = model.StartOn;
                mapModel.EndOn = model.EndOn;
                mapModel.ScorePrediction = model.ScorePrediction;
                mapModel.PublishedOn = model.PublishedOn;
                mapModel.Image = model.Image;
                mapModel.CreatedBy = loggedInUserName;
                mapModel.CreatedOn = DateTime.Now;

                _dbContext.Tournaments.Update(mapModel);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(ManageList));
            }

            return View(model);
        }


        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemFromDb = _dbContext.Tournaments.Find(id);
            if (itemFromDb == null)
            {
                return NotFound();
            }

            return View(itemFromDb);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Tournament model)
        {
            var softDeleteItem = _dbContext.Tournaments.Find(model.Id);

            if (ModelState.IsValid)
            {
                var mapModel = new Tournament();
                mapModel.Id = softDeleteItem.Id;
                mapModel.Name = softDeleteItem.Name;
                mapModel.StartOn = softDeleteItem.StartOn;
                mapModel.EndOn = softDeleteItem.EndOn;
                mapModel.ScorePrediction = softDeleteItem.ScorePrediction;
                mapModel.PublishedOn = softDeleteItem.PublishedOn;
                mapModel.Image = softDeleteItem.Image;
                mapModel.CreatedBy = softDeleteItem.CreatedBy;
                mapModel.CreatedOn = softDeleteItem.CreatedOn;
                mapModel.DeletedBy = loggedInUserName;
                mapModel.DeletedOn = DateTime.Now;

                _dbContext.Tournaments.Update(softDeleteItem);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(ManageList));
            }

            return View(model);
        }


        public IActionResult Publish(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemFromDb = _dbContext.Tournaments.Find(id);
            if (itemFromDb == null)
            {
                return NotFound();
            }

            return View(itemFromDb);
        }


        [HttpPost, ActionName("Publish")]
        [ValidateAntiForgeryToken]
        public IActionResult Publish(Tournament model)
        {
            var softDeleteItem = _dbContext.Tournaments.Find(model.Id);

            if (ModelState.IsValid)
            {
                var mapModel = new Tournament();
                mapModel.Id = softDeleteItem.Id;
                mapModel.Name = softDeleteItem.Name;
                mapModel.StartOn = softDeleteItem.StartOn;
                mapModel.EndOn = softDeleteItem.EndOn;
                mapModel.ScorePrediction = softDeleteItem.ScorePrediction;
                mapModel.PublishedOn = softDeleteItem.PublishedOn;
                mapModel.Image = softDeleteItem.Image;
                mapModel.CreatedBy = softDeleteItem.CreatedBy;
                mapModel.CreatedOn = softDeleteItem.CreatedOn;
                mapModel.DeletedBy = loggedInUserName;
                mapModel.DeletedOn = DateTime.Now;

                _dbContext.Tournaments.Update(softDeleteItem);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(ManageList));
            }

            return View(model);
        }
    }
}
