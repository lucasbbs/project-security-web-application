using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebApplication1Context>>()))
            {
                // Look for any movies.
                if (context.HelloWorld.Any())
                {
                    return;   // DB has been seeded
                }
                context.HelloWorld.AddRange(
                    new HelloWorld
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },
                    new HelloWorld
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 8.99M
                    },
                    new HelloWorld
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 9.99M
                    },
                    new HelloWorld
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
