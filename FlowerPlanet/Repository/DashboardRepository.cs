using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;

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
}
