using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerPlanet.Models
{
    public class AppUser : IdentityUser
    {
        public int? NumPlants { get; set; }
        public string? FavPlant { get; set; }
        public string ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [ForeignKey("Address")]
        public int? Addressid { get; set; }
        public Address? Address { get; set; }
        public ICollection<Shows> Shows { get; set; }
        public ICollection<Club> Clubs { get; set; }
    }
}
