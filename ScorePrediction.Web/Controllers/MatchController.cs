using Microsoft.AspNetCore.Mvc;

namespace ScorePrediction.Web.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
