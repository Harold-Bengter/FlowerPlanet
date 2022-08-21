﻿using FlowerPlanet.Interfaces;
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
            var userVIewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                FavPlant = user.FavPlant,
                NumPlants = user.NumPlants,
            };
            result.Add(userVIewModel);
        }
        return View(result);
    }
}