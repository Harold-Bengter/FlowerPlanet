using FlowerPlanet.Models;

namespace FlowerPlanet.Interfaces;

public interface IDashboardRepository
{
    Task<List<Shows>> GetAllUserShows();
    Task<List<Club>> GetAllUserClubs();
    Task<AppUser> GetUserById(string id);
    Task<AppUser> GetByIdNoTracking(string id);
    bool Update(AppUser user);
    bool Save();
}
