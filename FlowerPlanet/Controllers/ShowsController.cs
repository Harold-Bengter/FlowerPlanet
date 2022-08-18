using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Controllers;

public class ShowsController : Controller
{
    private readonly IShowsRepository _showsRepository;

    public ShowsController(IShowsRepository showsRepository)
    {
        _showsRepository = showsRepository;
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
    public async Task<IActionResult> Create(Shows shows)
    {
        if (!ModelState.IsValid)
        {
            return View(shows);
        }
        _showsRepository.Add(shows);
        return RedirectToAction("Index");
    }
}
