using Microsoft.AspNetCore.Mvc;

namespace ScorePrediction.Web.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
