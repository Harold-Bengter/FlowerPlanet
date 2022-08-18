using FlowerPlanet.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerPlanet.Models
{
    public class Shows
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ShowCategory ShowCategory { get; set; }
        [ForeignKey("AppUser")]

        public string? AppUserId { get; set; }

        public AppUser? Appuser { get; set; }

    }
}
