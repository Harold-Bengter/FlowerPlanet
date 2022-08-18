using FlowerPlanet.Data;
using FlowerPlanet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Controllers;

public class ShowsController : Controller
{
    private readonly AppDB _context;

    public ShowsController(AppDB context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var shows = _context.Shows.ToList();
        return View(shows);
    }
    public IActionResult Detail(int id)
    {
        Shows Shows = _context.Shows.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
        return View(Shows);
    }
}
