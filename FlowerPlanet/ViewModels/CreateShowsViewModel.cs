using FlowerPlanet.Data.Enum;
using FlowerPlanet.Models;

namespace FlowerPlanet.ViewModels;

public class CreateShowsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Address Address { get; set; }
    public IFormFile Image { get; set; }
    public ShowCategory ShowsCategory { get; set; }
    public string AppUserId  { get; set; }
}
