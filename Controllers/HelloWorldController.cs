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

        /*
         * This method is responsible for handling HTTP GET requests to display a welcome message.
         * It accepts two parameters: 'name' (string) and 'numTimes' (int, optional with a default value of 1).
         * The method performs the following operations:
         * 1. Sets ViewData variables to store the 'name' and 'numTimes' parameters.
         * 2. Constructs a welcome message using the provided 'name'.
         * 3. Returns a View for displaying the welcome message along with the number of times to display it.
         */
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }

        /*
         * This method is a custom action named 'Lucas' that returns a string.
         * The method performs the following operation:
         * 1. Returns a string indicating that it is Lucas' custom action.
         */
        public string Lucas()
        {
            return "This is Lucas' custom action";
        }
    }
}
