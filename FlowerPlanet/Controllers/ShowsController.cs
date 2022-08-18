using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
using FlowerPlanet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Controllers;

public class ShowsController : Controller
{
    private readonly IShowsRepository _showsRepository;
    private readonly IPhotoService _photoService;

    public ShowsController(IShowsRepository showsRepository, IPhotoService photoService)
    {
        _showsRepository = showsRepository;
        _photoService = photoService;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<Shows> shows = await _showsRepository.GetAll();
        return View(shows);
    }
    public async Task<IActionResult> Detail(int id)
    {
        Shows Shows = await _showsRepository.GetByIdAsync(id);
        return View(Shows);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateShowsViewModel showsVM)
    { 
     if(ModelState.IsValid)
        {
            var result = await _photoService.AddPhotoAsync(showsVM.Image);

    var shows = new Shows
    {
        Title = showsVM.Title,
        Description = showsVM.Description,
        Image = result.Url.ToString(),
        Address = new Address
        {
            Street = showsVM.Address.Street,
            city = showsVM.Address.city,
            state = showsVM.Address.state,
        }
    };
    _showsRepository.Add(shows);
            return RedirectToAction("Index");
}
        else
        {
            ModelState.AddModelError("", "Photo upload failed");
        }

        return View(showsVM);
        
    }
}
