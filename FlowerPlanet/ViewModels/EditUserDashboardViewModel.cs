namespace FlowerPlanet.ViewModels;

public class EditUserDashboardViewModel
{
    public string Id { get; set; }
    public string? FavPlant { get; set; }
    public int? NumPlants { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string City { get; set; }
    public string State { get; set; }   
    public IFormFile Image { get; set; }

}
