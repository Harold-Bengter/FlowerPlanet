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
    public async Task<IActionResult> Edit(int id)
    {
        var show = await _showsRepository.GetByIdAsync(id);
        if (show == null) return View("Error");
        var showsVM = new EditShowViewModel
        {
            Title = show.Title,
            Description = show.Description,
            AddressId = show.AddressId,
            Address = show.Address,
            URL = show.Image,
            ShowCategory = show.ShowCategory
        };
        return View(showsVM);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditShowViewModel showsVM)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Failed to edit club");
            return View("Edit", showsVM);
        }
        var userClub = await _showsRepository.GetByIdAsyncNoTracking(id);

        if (userClub != null)
        {
            try
            {
                await _photoService.DeletePhotoAsync(userClub.Image);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Could not delete Photo");
                return View(showsVM);
            }
            var photoresult = await _photoService.AddPhotoAsync(showsVM.Image);

            var show = new Shows
            {
                Id = id,
                Title = showsVM.Title,
                Description = showsVM.Description,
                Image = photoresult.Url.ToString(),
                AddressId = showsVM.AddressId,
                Address = showsVM.Address,
            };

            _showsRepository.Update(show);

            return RedirectToAction("Index");
        }
        else
        {
            return View(showsVM);
        }

    }
    public async Task<IActionResult> Delete(int id)
    {
        var showDetails = await _showsRepository.GetByIdAsync(id);
        if (showDetails == null) return View("Error");
        return View(showDetails);
    }

    [HttpPost, ActionName("Delete")]

    public async Task<IActionResult> DeleteShow(int id)
    {
        var showdetails = await _showsRepository.GetByIdAsync(id);
        if (showdetails == null) return View("Error");


        _showsRepository.Delete(showdetails);
        return RedirectToAction("Index");
    }

}
