using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public class DataSeeder
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check if any data already exists
                if (context.Products.Any())
                {
                    return; // DB has been seeded
                }

                // Seed your data
                var random = new Random();
                var products = Enumerable.Range(1, 30).Select(i => new Product
                {
                    Name = $"Product {i}",
                    Price = random.Next(100, 1000), // Random integer price
                }).ToList();

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
