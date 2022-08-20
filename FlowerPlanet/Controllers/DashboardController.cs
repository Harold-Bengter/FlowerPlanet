using Microsoft.AspNetCore.Mvc;

namespace FlowerPlanet.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
