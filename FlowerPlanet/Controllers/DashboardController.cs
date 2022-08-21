using CloudinaryDotNet.Actions;
using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
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
       private void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM, ImageUploadResult photoResult)
        {
            user.Id = editVM.Id;
            user.FavPlant = editVM.FavPlant;
            user.NumPlants = editVM.NumPlants;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.City = editVM.City;
            user.State = editVM.State;           
        }

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

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);
            }

            var user = await _dashboardrepository.GetByIdNoTracking(editVM.Id);

            if(user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardrepository.Update(user);

                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(editVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardrepository.Update(user);

                return RedirectToAction("Index");
            }
        }

    }
}
