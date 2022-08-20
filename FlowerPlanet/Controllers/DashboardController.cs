using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlowerPlanet.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardrepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardrepository = dashboardRepository;
        }
        public AppDB Context { get; }

        public async Task<IActionResult> Index()
        {
            var userShows = await _dashboardrepository.GetAllUserShows();
            var userClubs = await _dashboardrepository.GetAllUserClubs();
            var dashbaordViewModel = new DashboardViewModel()
            {
                Shows = userShows,
                Clubs = userClubs,
            };
            return View(dashbaordViewModel);
        }
    }
}
