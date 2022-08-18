using FlowerPlanet.Data;
using FlowerPlanet.Interfaces;
using FlowerPlanet.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly AppDB _context;
        public ClubRepository(AppDB context)
        {
            _context = context;
        }
        
        public bool Add(Club club)
        {
          _context.Add(club);
            return Save();  
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Club.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Club.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Club.Where(c => c.Address.city.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            throw new NotImplementedException();
        }
    }
}
