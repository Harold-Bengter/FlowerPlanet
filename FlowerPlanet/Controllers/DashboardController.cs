using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlowerPlanet.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardrepository;
        private readonly IHttpContextAccessor _httpcontextAccessor;
        private readonly IPhotoService _photoService;
        public DashboardController(IDashboardRepository dashboardRepository,
             IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _dashboardrepository = dashboardRepository;
            _httpcontextAccessor = httpContextAccessor;
            _photoService = photoService;
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

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpcontextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardrepository.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                FavPlant = user.FavPlant,
                NumPlants = user.NumPlants,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                State = user.State
            };
            return View(editUserViewModel);

        }
    }
}
