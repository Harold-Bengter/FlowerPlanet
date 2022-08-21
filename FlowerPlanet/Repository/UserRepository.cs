using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Repository;

public class UserRepository : IUserRepository
{

    private readonly AppDB _context;
    public UserRepository(AppDB context)
    {
        _context = context;
    }
    public bool Add(AppUser user)
    {
        throw new NotImplementedException();
    }

    public bool Delete(AppUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AppUser>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<AppUser> GetUserById(string Id)
    {
        return await _context.Users.FindAsync(Id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Update(AppUser user)
    {
       _context.Update(user);
        return Save();
    }
}
