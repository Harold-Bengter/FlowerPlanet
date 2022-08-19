using FlowerPlanet.Data.Enum;
using FlowerPlanet.Models;
using Microsoft.AspNetCore.Identity;

namespace FlowerPlanet.Data;

public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDB>();

            context.Database.EnsureCreated();

            if (!context.Shows.Any())
            {
                List<Club> clubs = new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Succulent Club",
                            Image = "https://images.unsplash.com/photo-1520302630591-fd1c66edc19d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                            Description = "Club for succulent lovers!",
                            ClubCategory = ClubCategory.Succulent,
                            Address = new Address()
                            {
                                Street = "540 Lankford Lane",
                                city = "Atlanta",
                                state = "GA"
                            }
                         },
                        new Club()
                        {
                            Title = "Cactus Club",
                            Image = "https://images.unsplash.com/photo-1463936575829-25148e1db1b8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1817&q=80",
                            Description = "Club for cacti lovers!",
                            ClubCategory = ClubCategory.Cactus,
                            Address = new Address()
                            {
                                Street = "8203 mays ave",
                                city = "Phoneix",
                                state = "AZ"
                            }
                        },
                        new Club()
                        {
                            Title = "Tree Club",
                            Image = "https://images.unsplash.com/photo-1615761668828-207b090c8514?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1841&q=80",
                            Description = "Club for tree lovers",
                            ClubCategory = ClubCategory.Trees,
                            Address = new Address()
                            {
                                Street = "192 Bennetts lane",
                                city = "Sommerset",
                                state = "NJ"
                            }
                        },
                        new Club()
                        {
                            Title = "Perennial Club",
                            Image = "https://images.unsplash.com/photo-1617624863304-fd54ca805bbf?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                            Description = "Club for lovers of perennials",
                            ClubCategory = ClubCategory.Perennials,
                            Address = new Address()
                            {
                                Street = "5150 Drakeford road",
                                city = "Dekalb",
                                state = "GA"
                            }
                        },
                        new Club()
                        {
                            Title = "Rose Club",
                            Image = "https://images.unsplash.com/photo-1556712691-5c39e0e32a8e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                            Description = "Club for lovers of roses",
                            ClubCategory = ClubCategory.Roses,
                            Address = new Address()
                            {
                                Street = "155 Creek lane",
                                city = "Tampa",
                                state = "FL"
                            }
                        },
                          new Club()
                        {
                            Title = "Annuals Club",
                            Image = "https://images.unsplash.com/16/unsplash_525b54bcc32ba_1.JPG?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                            Description = "Club for lovers of annuals",
                            ClubCategory = ClubCategory.annuals,
                            Address = new Address()
                            {
                                Street = "220 Myrtle ave",
                                city = "Los Angeles",
                                state = "CA"
                            }
                        },
                            new Club()
                        {
                            Title = "Foliage Club",
                            Image = "https://images.unsplash.com/photo-1592150621744-aca64f48394a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1782&q=80",
                            Description = "Club for big leaf and foliage lovers",
                            ClubCategory = ClubCategory.Foliage,
                            Address = new Address()
                            {
                                Street = "3365 Benz ave",
                                city = "New york",
                                state = "NY"
                            }
                        },
                        new Club()
                        {
                            Title = "Orchids club",
                            Image = "https://images.unsplash.com/photo-1571677179476-ab32559a6c7c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                            Description = "Club for orchid lovers!",
                            ClubCategory = ClubCategory.Orchids,
                            Address = new Address()
                            {
                                Street = "71 turtle road",
                                city = "Edison",
                                state = "NJ"
                            }
                        }
                    };
                context.Shows.AddRange((IEnumerable<Shows>)clubs);
                context.SaveChanges();
            }
            //Shows
            if (!context.Shows.Any())
            {
                context.Shows.AddRange(new List<Shows>()
                    {
                        new Shows()
                        {
                            Title = "Flea market",
                            Image = "https://images.unsplash.com/photo-1627629465560-09951aaba475?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
                            Description = "Come find a flea market for flowers near you!",
                           ShowCategory = ShowCategory.FleaMarket,
                            Address = new Address()
                            {
                                Street = "202 Cresent road",
                                city = "Clearwater",
                                state = "FL"
                            }
                        },
                        new Shows()
                        {
                            Title = "Best in class",
                            Image = "https://images.unsplash.com/photo-1614036417651-efe5912149d8?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1838&q=80",
                            Description = "Come find a best in class show near you!",
                            ShowCategory = ShowCategory.BestInClass,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "798 Blues Ave",
                                city = "Macon",
                                state = "GA"
                            }
                        },
                        new Shows()
                        {
                            Title = "Show and tell",
                            Image = "https://i2-prod.mylondon.news/incoming/article13071581.ece/ALTERNATES/s1227b/JS120324177.jpg",
                            Description = "Come show off your flowers!",
                            ShowCategory = ShowCategory.ShowAndTell,
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "220 Wellsley court",
                                city = "Myrtle Beach",
                                state = "SC"
                            }
                        }
                    });
                context.SaveChanges();
            }
        }
    }


    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            //Roles
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //Users
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            string adminUserEmail = "Haroldbe55@yahoo.com";

            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new AppUser()
                {
                    UserName = "HBengterDev",
                    Email = adminUserEmail,
                    EmailConfirmed = true,
                    Address = new Address()
                    {
                        Street = "1545 Idlewood",
                        city = "Lilburn",
                        state = "GA"
                    }
                };
                await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

            string appUserEmail = "user@etickets.com";

            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new AppUser()
                {
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                    Address = new Address()
                    {
                        Street = "182 Bennetts lane",
                        city = "Somerset",
                        state = "NJ"
                    }
                };
                await userManager.CreateAsync(newAppUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
    }

}

