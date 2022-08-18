using System.ComponentModel.DataAnnotations;

namespace FlowerPlanet.Models
{
    public class Address
    {
        [Key]

        public int Id { get; set; }
        public string Street { get; set; }
        public string city { get; set; }
        public string state { get; set; }

    }
}
