﻿using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
using FlowerPlanet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Controllers;

public class ClubController : Controller
{
    private readonly IClubRepository _clubRepository;
    private readonly IPhotoService _photoService;
    public ClubController(IClubRepository clubRepository, IPhotoService photoService)
    {
        _clubRepository = clubRepository;
        _photoService = photoService;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<Club> clubs = await _clubRepository.GetAll();
        return View(clubs);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Club club = await _clubRepository.GetByIdAsync(id);
        return View(club);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateClubViewModel clubVM)
    {
        if(ModelState.IsValid)
        {
            var result = await _photoService.AddPhotoAsync(clubVM.Image);

            var club = new Club
            {
                Title = clubVM.Title,
                Description = clubVM.Description,
                Image = result.Url.ToString(),
                Address = new Address
                {
                    Street = clubVM.Address.Street,
                    city = clubVM.Address.city,
                    state = clubVM.Address.state,
                }
            };
            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }
        else
        {
            ModelState.AddModelError("", "Photo upload failed");
        }

        return View(clubVM);    
    }
    public async Task<IActionResult> Edit(int id)
    {
        var club = await _clubRepository.GetByIdAsync(id);
        if(club == null) return View("Error");
        var clubVM = new EditClubViewModel
        {
            Title = club.Title,
            Description = club.Description,
            AddressId = club.AddressId,
            Address = club.Address,
            URL = club.Image,
            ClubCategory = club.ClubCategory
        };
        return View(clubVM);

    }
}

