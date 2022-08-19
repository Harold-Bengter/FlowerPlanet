using FlowerPlanet.Data.Enum;
using FlowerPlanet.Models;

namespace FlowerPlanet.ViewModels;

public class EditShowViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public string? URL { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public ShowCategory ShowCategory { get; set; }
}
