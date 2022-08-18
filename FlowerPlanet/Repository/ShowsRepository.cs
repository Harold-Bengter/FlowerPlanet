using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Repository;

public class ShowsRepository : IShowsRepository
{
    private readonly AppDB _context;
    public ShowsRepository(AppDB context)
    {
        _context = context;
    }

    public bool Add(Shows show)
    {
        _context.Add(show);
        return Save();
    }

    public bool Delete(Shows show)
    {
       _context.Remove(show);
        return Save();
    }

    public async Task<IEnumerable<Shows>> GetAll()
    {
        return await _context.Shows.ToListAsync();
    }

    public async Task<Shows> GetByIdAsync(int id)
    {
        return await _context.Shows.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Shows>> GetShowsByCity(string city)
    {
        return await _context.Shows.Where(c => c.Address.city.Contains(city)).ToListAsync();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Update(Shows show)
    {
         _context.Update(show);
        return Save();
    } 
}
