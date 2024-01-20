using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models
{
    public class HelloWorldGenreViewModel
    {
        public List<HelloWorld>? HelloWorlds { get; set; }
        public SelectList? Genres { get; set; }
        public string? MovieGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
