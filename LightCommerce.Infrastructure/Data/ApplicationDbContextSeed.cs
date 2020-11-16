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

            if (!context.Products.Any())
            {
                context.Products.Add(new Product { Name = "IPhone 1", Description = "This is an IPhone 1", Price = 100 });
                context.Products.Add(new Product { Name = "IPhone 2", Description = "This is an IPhone 2", Price = 200 });
                context.Products.Add(new Product { Name = "IPhone 3", Description = "This is an IPhone 3", Price = 300 });
                context.Products.Add(new Product { Name = "IPhone 4", Description = "This is an IPhone 4", Price = 400 });
                context.Products.Add(new Product { Name = "IPhone 5", Description = "This is an IPhone 5", Price = 500 });
                context.Products.Add(new Product { Name = "IPhone 6", Description = "This is an IPhone 6", Price = 600 });
                context.Products.Add(new Product { Name = "IPhone 7", Description = "This is an IPhone 7", Price = 700 });
                context.Products.Add(new Product { Name = "IPhone 8", Description = "This is an IPhone 8", Price = 800 });
                context.Products.Add(new Product { Name = "IPhone 9", Description = "This is an IPhone 9", Price = 900 });
                context.Products.Add(new Product { Name = "IPhone 10", Description = "This is an IPhone 10", Price = 1000 });
                context.Products.Add(new Product { Name = "IPhone 11", Description = "This is an IPhone 11", Price = 1100 });
                context.Products.Add(new Product { Name = "IPhone 12", Description = "This is an IPhone 12", Price = 1200 });
                context.Products.Add(new Product { Name = "IPhone 13", Description = "This is an IPhone 13", Price = 1300 });
                context.Products.Add(new Product { Name = "IPhone 14", Description = "This is an IPhone 14", Price = 1400 });

                await context.SaveChangesAsync();
            }
        }
    }
}
