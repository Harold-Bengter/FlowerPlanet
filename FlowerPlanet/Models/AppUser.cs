using System.ComponentModel.DataAnnotations;

namespace FlowerPlanet.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public int? NumPlants { get; set; }

        public int? FavPlant { get; set; }

        public Address? Address { get; set; }

        public ICollection<Shows> Shows { get; set; }
        public ICollection<Club> Clubs { get; set; }
    }
}
