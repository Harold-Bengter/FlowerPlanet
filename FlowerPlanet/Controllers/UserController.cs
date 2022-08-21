using FlowerPlanet.Interfaces;
using FlowerPlanet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlowerPlanet.Controllers;

public class UserController : Controller
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpGet("users")]
    public async Task<IActionResult> Index()
    {
        var users = await _userRepository.GetAllUsers();
        List<UserViewModel> result = new List<UserViewModel>();
        foreach(var user in users)
        {
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                FavPlant = user.FavPlant,
                NumPlants = user.NumPlants,
                ProfileImageUrl = user.ProfileImageUrl,
            };
            result.Add(userViewModel);
        }
        return View(result);
    }

    public async Task<IActionResult> Detail(string id)
    {
        var user = await _userRepository.GetUserById(id);
        var userDetailViewMdoel = new UserDetailViewModel()
        {
            Id = user.Id,
            UserName = user.UserName,
            FavPlant = user.FavPlant,
            NumPlants = user.NumPlants,
        };
        return View(userDetailViewMdoel);
    }
}
