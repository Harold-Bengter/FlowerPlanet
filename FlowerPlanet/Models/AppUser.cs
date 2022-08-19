using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerPlanet.Models
{
    public class AppUser : IdentityUser
    {
        public int? NumPlants { get; set; }

        public int? FavPlant { get; set; }
        [ForeignKey("Address")]
        public int Addressid { get; set; }
        public Address? Address { get; set; }
        public ICollection<Shows> Shows { get; set; }
        public ICollection<Club> Clubs { get; set; }
    }
}
