using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace WebApplication1.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            // return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
            // return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }

        public string Lucas()
        {
            return "This is Lucas' custom action";
        }
    }
}
