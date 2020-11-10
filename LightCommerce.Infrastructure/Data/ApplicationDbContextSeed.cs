using LightCommerce.Domain.Entities;
using LightCommerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace LightCommerce.Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                FirstName = "Truc",
                Lastname = "Tran",
                UserName = "admin@abc.com",
                Email = "admin@abc.com"
            };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "123@Hvn");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { Name = "Phones" });
                context.Categories.Add(new Category { Name = "Tablets" });
                context.Categories.Add(new Category { Name = "Computers" });
                context.Categories.Add(new Category { Name = "Accessories" });

                await context.SaveChangesAsync();
            }
        }
    }
}
