using FlowerPlanet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerPlanet.Data
{
    public class AppDB : IdentityDbContext<AppUser>
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options)
        {

        }

        public DbSet<Club> Club { get; set; }
        public DbSet<Shows> Shows { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
