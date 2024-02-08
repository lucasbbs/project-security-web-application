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
                        Title = "Harry Potter",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Fantasy",
                        Rating = "Good",
                        Price = 7.99M
                    },
                    new HelloWorld
                    {
                        Title = "Titanic ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Romance",
                        Rating = "Good",
                        Price = 8.99M
                    },
                    new HelloWorld
                    {
                        Title = "Spider Man",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Adventure",
                        Rating = "Good",
                        Price = 9.99M
                    },
                    new HelloWorld
                    {
                        Title = "Toy Story",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Animation",
                        Rating = "Good",
                        Price = 3.99M
                    },
                    new HelloWorld
                    {
                        Title = "The Lion King",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Animation",
                        Rating = "Good",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
