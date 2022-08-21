using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Repository;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDB _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DashboardRepository(AppDB context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<List<Club>> GetAllUserClubs()
    {
        var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
        var userClubs = _context.Club.Where(r => r.Appuser.Id == curUser);
        return userClubs.ToList();
    }

    public async Task<List<Shows>> GetAllUserShows()
    {
        var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
        var userShows = _context.Shows.Where(r => r.Appuser.Id == curUser);
        return userShows.ToList();
    }

    public async Task<AppUser> GetUserById(string id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<AppUser> GetByIdNoTracking(string id)
    {
        return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
    }

    public bool Update(AppUser user)
    {
        _context.Users.Update(user);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}
