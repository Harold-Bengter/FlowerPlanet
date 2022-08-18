using FlowerPlanet.Models;

namespace FlowerPlanet.Interfaces;

public interface IShowsRepository
{
    Task<IEnumerable<Shows>> GetAll();
    Task<Shows> GetByIdAsync(int id);
    Task<IEnumerable<Shows>> GetShowsByCity(string city);
    bool Add(Shows show);
    bool Update(Shows show);
    bool Delete(Shows show);
    bool Save();
}
