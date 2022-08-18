using FlowerPlanet.Data;
using FlowerPlanet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Controllers;

public class ClubController : Controller
{
    private readonly AppDB _context;
    public ClubController(AppDB context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Club> clubs = _context.Club.ToList();
        return View(clubs);
    }

    public IActionResult Detail(int id)
    {
        Club club = _context.Club.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
        return View(club);
    }
}

